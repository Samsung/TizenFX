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
        private int currentFrameIndex = 0;
        private const int INIT_WIDTH = 600;
        private const int INIT_HEIGHT = 400;
        private const int INIT_BUFFER_WIDTH = 128; //600;
        private const int INIT_BUFFER_HEIGHT = 128; //400;
        private const NativeImageSource.ColorDepth COLOR_DEPTH = NativeImageSource.ColorDepth.Bits24;// NativeImageSource.ColorDepth.Bits32;
        private const int FRAME_UPDATE_INTERVAL_MS = 2500; // Interval for frame updates
        private const int SLEEP_CHECK_INTERVAL_MS = 100; // Check interval for thread shutdown

        // Worker thread related fields
        private Thread frameUpdateWorkerThread;
        private volatile bool stopWorkerThread = false;

        public void Activate()
        {
            Tizen.Log.Error(tag, "Activate(): start \n");
            window = NUIApplication.GetDefaultWindow();

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

            // Start the worker thread for video frame buffer updates.
            // The first frame will be set by the worker thread.
            stopWorkerThread = false;
            frameUpdateWorkerThread = new Thread(FrameUpdateWorkerLoop)
            {
                IsBackground = true // Ensure thread doesn't prevent app exit
            };
            frameUpdateWorkerThread.Start();
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

                    // Update currentFrameIndex for the next cycle
                    currentFrameIndex = (currentFrameIndex + 1) % 3;

                    // Wait for the specified interval or until stop is requested
                    // This loop allows for quicker shutdown if stopWorkerThread becomes true
                    for (int i = 0; i < FRAME_UPDATE_INTERVAL_MS / SLEEP_CHECK_INTERVAL_MS; i++) // Check every SLEEP_CHECK_INTERVAL_MS ms
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
                if (!frameUpdateWorkerThread.Join(500 + FRAME_UPDATE_INTERVAL_MS)) // Wait for thread to finish, considering its sleep interval
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
