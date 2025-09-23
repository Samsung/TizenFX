using System;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class VideoViewWithOffScreenRenderingTest : IExample
    {
        private Window window;
        private View root;
        private VideoView videoView;
        private View blurView;
        private NativeImageSource[] testNativeImageSources = new NativeImageSource[3];
        private int currentFrameIndex = -1;
        private volatile int frameUpdateIntervalMs = 2500; // Interval for frame updates (volatile for thread safety)
        private const int INIT_WIDTH = 600;
        private const int INIT_HEIGHT = 400;
        private const int INIT_BUFFER_WIDTH = 128; //600;
        private const int INIT_BUFFER_HEIGHT = 128; //400;
        private const NativeImageSource.ColorDepth COLOR_DEPTH = NativeImageSource.ColorDepth.Bits24;// NativeImageSource.ColorDepth.Bits32;
        private const int SLEEP_CHECK_INTERVAL_MS = 10; // Check interval for thread shutdown (reduced for better precision with short intervals)
        private TextLabel testGuide;
        private TextLabel intervalGuide;
        private TextLabel useVideoBufferGuide;
        private TextLabel bufferIndexGuide;
        private bool useVideoBuffer = true;
        private static SynchronizationContext mainContext;

        // Worker thread related fields
        private Thread frameUpdateWorkerThread;
        private volatile bool stopWorkerThread = false;
        private readonly object threadLockObject = new object(); // For thread synchronization
        private volatile bool isThreadStopping = false; // Track if thread is currently being stopped

        public void Activate()
        {
            Tizen.Log.Error(tag, "Activate(): start \n");
            window = NUIApplication.GetDefaultWindow();

            mainContext = SynchronizationContext.Current ?? new SynchronizationContext();

            // Create a root view with blue background
            root = new View()
            {
                Size = new Size(window.WindowSize.Width, window.WindowSize.Height),
                BackgroundColor = Color.Coral,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            // Create a red rectangle view
            View redRec = new View()
            {
                Size = new Size(500, 500),
                BackgroundColor = Color.Red,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            root.Add(redRec);

            // Create VideoView
            videoView = new VideoView()
            {
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "v.mp4",
                Size = new Size(INIT_WIDTH, INIT_HEIGHT),
                Position = new Position(500.0f, 0.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Looping = true,
                Muted = false,
                CornerRadius = new Vector4(150.0f, 150.0f, 150.0f, 150.0f),
            };
            root.Add(videoView);
            videoView.Play();

            // Create a view with BackgroundBlurEffect
            blurView = new View()
            {
                Size = new Size(500, 500),
                Position = new Position(250, -250),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            var blurEffect = RenderEffect.CreateBackgroundBlurEffect(50.0f);
            blurView.SetRenderEffect(blurEffect); // Blur radius 50
            root.Add(blurView);

            // Create test NativeImageSources (R, G, B)
            CreateTestNativeImageSources();

            // Set to underlay mode for frame interpolation
            videoView.Underlay = true;

            // Enable offscreen frame rendering for better video interpolation quality
            videoView.EnableOffscreenFrameRendering(true);

            // Set frame interpolation interval (e.g., 2.5s)
            videoView.FrameInterpolationInterval = 2.5f;

            testGuide = new TextLabel()
            {
                Position = new Position(50.0f, 50.0f),
                Text = "Instructions:\n• Touch screen to toggle video buffer on/off\n• Wait 1 second after turning off before touching again\n• Use Arrow Up/Down keys to adjust frame interpolation interval",
                MultiLine = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
                PixelSize = 30
            };
            window.Add(testGuide);

            intervalGuide = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                Text = "Interval: 2.5s",
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.TopLeft,
                PixelSize = 30
            };
            testGuide.Add(intervalGuide);

            useVideoBufferGuide = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                Text = "Video Buffer: On",
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.TopLeft,
                PixelSize = 30
            };
            intervalGuide.Add(useVideoBufferGuide);

            bufferIndexGuide = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                Text = "Buffer Index: 0",
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.TopLeft,
                PixelSize = 30
            };
            useVideoBufferGuide.Add(bufferIndexGuide);

            // Start the worker thread for video frame buffer updates.
            // The first frame will be set by the worker thread.
            stopWorkerThread = false;
            frameUpdateWorkerThread = new Thread(FrameUpdateWorkerLoop)
            {
                IsBackground = true // Ensure thread doesn't prevent app exit
            };
            frameUpdateWorkerThread.Start();

            window.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    useVideoBuffer = !useVideoBuffer;
                    videoView.EnableOffscreenFrameRendering(useVideoBuffer);
                    useVideoBufferGuide.Text = $"Video Buffer: " + (useVideoBuffer ? "On" : "Off");

                    // Use lock to prevent race conditions during rapid consecutive touches
                    lock (threadLockObject)
                    {
                        // Stop worker thread when useVideoBuffer is false
                        if (!useVideoBuffer)
                        {
                            Tizen.Log.Error(tag, "TouchEvent: Stopping worker thread as useVideoBuffer is false");

                            // Check if thread is already being stopped to prevent race conditions
                            if (!isThreadStopping && frameUpdateWorkerThread != null)
                            {
                                isThreadStopping = true;
                                stopWorkerThread = true;

                                // Use reasonable timeout since worker thread checks stop flag every SLEEP_CHECK_INTERVAL_MS
                                if (!frameUpdateWorkerThread.Join(1000)) // 1 second timeout should be enough
                                {
                                    log.Warn(tag, "FrameUpdateWorkerThread did not terminate in time.");
                                }
                                frameUpdateWorkerThread = null;
                                isThreadStopping = false;
                            }
                            else if (isThreadStopping)
                            {
                                Tizen.Log.Error(tag, "TouchEvent: Thread is already being stopped, ignoring duplicate stop request");
                            }
                        }
                        else
                        {
                            // Restart worker thread when useVideoBuffer is true
                            Tizen.Log.Error(tag, "TouchEvent: Starting worker thread as useVideoBuffer is true");

                            // Ensure any existing thread is properly stopped before starting new one
                            if (frameUpdateWorkerThread != null && !isThreadStopping)
                            {
                                isThreadStopping = true;
                                stopWorkerThread = true;

                                if (!frameUpdateWorkerThread.Join(1000))
                                {
                                    log.Warn(tag, "FrameUpdateWorkerThread did not terminate in time during restart.");
                                }
                                frameUpdateWorkerThread = null;
                                isThreadStopping = false;
                            }

                            stopWorkerThread = false;
                            currentFrameIndex = -1; // Reset frame index
                            frameUpdateWorkerThread = new Thread(FrameUpdateWorkerLoop)
                            {
                                IsBackground = true // Ensure thread doesn't prevent app exit
                            };
                            frameUpdateWorkerThread.Start();
                        }
                    }
                }
            };

            window.KeyEvent += (s, e) =>
            {
                if (e.Key.State == Key.StateType.Down)
                {
                    float interval = videoView.FrameInterpolationInterval;
                    if (e.Key.KeyPressedName == "Up")
                    {
                        interval += 0.2f;
                    }
                    else if (e.Key.KeyPressedName == "Down")
                    {
                        interval -= 0.2f;
                        interval = interval <= 0.0f ? 0.2f : interval;
                    }
                    videoView.FrameInterpolationInterval = interval;
                    frameUpdateIntervalMs = (int)(interval * 1000.0f);
                    intervalGuide.Text = $"Interval : {interval}s";
                }
            };
        }

        private void CreateTestNativeImageSources()
        {
            testNativeImageSources[0] = CreateColorNativeImageSourceImage(INIT_BUFFER_WIDTH, INIT_BUFFER_HEIGHT, Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/Dali/ContactCard/gallery-small-14.jpg");
            testNativeImageSources[1] = CreateColorNativeImageSourceImage(INIT_BUFFER_WIDTH, INIT_BUFFER_HEIGHT, Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/Dali/ContactCard/gallery-small-18.jpg");
            testNativeImageSources[2] = CreateColorNativeImageSourceImage(INIT_BUFFER_WIDTH, INIT_BUFFER_HEIGHT, Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/Dali/ContactCard/gallery-small-19.jpg");
        }

        private NativeImageSource CreateColorNativeImageSourceImage(int width, int height, string path)
        {
            var source = new NativeImageSource((uint)width, (uint)height, COLOR_DEPTH);
            AssignBufferImage(source, width, height, path);
            return source;
        }

        private void AssignBufferImage(NativeImageSource source, int width, int height, string path)
        {
            PixelBuffer pixelBuffer = ImageLoader.LoadImageFromFile(path);
            IntPtr pixelBufferIntPtr = pixelBuffer.GetBuffer();

            int bufferWidth = 0;
            int bufferHeight = 0;
            int bufferStride = 0;
            var buffer = source.AcquireBuffer(ref bufferWidth, ref bufferHeight, ref bufferStride);
            uint size = (uint)bufferWidth * (uint)bufferHeight * 3;

            Tizen.Log.Error("VIDEO_TEST", $"w : {pixelBuffer.GetWidth()}, h : {pixelBuffer.GetHeight()}\n");
            unsafe
            {
                byte* sourData = (byte*)pixelBufferIntPtr.ToPointer();
                byte* destData = (byte*)buffer.ToPointer();
                for (int i = 0; i < size; i += 3)
                {
                    destData[i] = sourData[i + 2];     // R
                    destData[i + 1] = sourData[i + 1]; // G
                    destData[i + 2] = sourData[i];     // B
                }
            }
            Tizen.Log.Error("NUI", $"ReleaseBuffer\n");
            source.ReleaseBuffer();
        }

        private void FrameUpdateWorkerLoop()
        {
            Tizen.Log.Error(tag, "FrameUpdateWorkerLoop: Started.");
            try
            {
                while (!stopWorkerThread)
                {
                    // currentFrameIndex is now only accessed and modified by this worker thread,
                    // so no lock is needed.
                    Tizen.Log.Error(tag, $"FrameUpdateWorkerLoop: Processing frame idx : {currentFrameIndex}");


                    int previousIndex = currentFrameIndex;

                    // Update currentFrameIndex for the next cycle
                    currentFrameIndex = (currentFrameIndex + 1) % 3;

                    NativeImageSource frameToUpdate = testNativeImageSources[currentFrameIndex];

                    if (frameToUpdate != null && videoView != null)
                    {
                        // Call SetVideoFrameBuffer directly from the worker thread
                        try
                        {
                            Tizen.Log.Error(tag, "FrameUpdateWorkerLoop (Worker Thread): Executing SetVideoFrameBuffer.");
                            videoView.SetVideoFrameBuffer(frameToUpdate);
                        }
                        catch (Exception ex)
                        {
                            Tizen.Log.Error(tag, $"Exception in SetVideoFrameBuffer on worker thread: {ex.Message}");
                        }
                    }

                    // Only update UI if the thread is still running (not stopped during the Post operation)
                    if (!stopWorkerThread)
                    {
                        mainContext.Post(_ =>
                        {
                            if (previousIndex == -1)
                            {
                                bufferIndexGuide.Text = $"BufferIndex : {currentFrameIndex}";
                            }
                            else
                            {
                                bufferIndexGuide.Text = $"BufferIndex : {previousIndex} => {currentFrameIndex}";
                            }
                        }, null);
                    }

                    // Read the current interval value to a local variable to ensure consistency within this iteration
                    int currentInterval = frameUpdateIntervalMs;
                    
                    // Ensure minimum interval to prevent excessive CPU usage and maintain stability
                    int effectiveInterval = Math.Max(currentInterval, SLEEP_CHECK_INTERVAL_MS);

                    // Wait for the specified interval or until stop is requested
                    // This loop allows for quicker shutdown if stopWorkerThread becomes true
                    for (int i = 0; i < effectiveInterval / SLEEP_CHECK_INTERVAL_MS; i++) // Check every SLEEP_CHECK_INTERVAL_MS ms
                    {
                        if (stopWorkerThread)
                        {
                            Tizen.Log.Error(tag, "FrameUpdateWorkerLoop: Stop requested during sleep, exiting.");
                            break;
                        }
                        Thread.Sleep(SLEEP_CHECK_INTERVAL_MS);
                    }
                    if (stopWorkerThread) break; // Exit main loop if stop was requested
                }
            }
            catch (Exception ex)
            {
                Tizen.Log.Error(tag, $"FrameUpdateWorkerLoop: Unhandled exception: {ex.Message}");
            }
            finally
            {
                Tizen.Log.Error(tag, "FrameUpdateWorkerLoop: Finished.");
            }
        }

        public void Deactivate()
        {
            Tizen.Log.Error(tag, "Deactivate(): start \n");

            // Signal the worker thread to stop
            stopWorkerThread = true;

            if (frameUpdateWorkerThread != null)
            {
                // Use reasonable timeout since worker thread checks stop flag every SLEEP_CHECK_INTERVAL_MS
                if (!frameUpdateWorkerThread.Join(1000)) // 1 second timeout should be enough
                {
                    log.Warn(tag, "FrameUpdateWorkerThread did not terminate in time.");
                }
                frameUpdateWorkerThread = null;
            }

            if (window != null)
            {
                if (root != null)
                {
                    window.Remove(root);
                }
            }

            if (testNativeImageSources != null)
            {
                foreach (var nativeImageSource in testNativeImageSources)
                {
                    nativeImageSource?.Dispose();
                }
                testNativeImageSources = null;
            }
            videoView?.Dispose();
            videoView = null;
            root?.Dispose();
            root = null;
            blurView?.Dispose();
            blurView = null;

            Tizen.Log.Error(tag, "Deactivate(): end \n");
        }

        const string tag = "NUITEST";
    }
}
