using global::System;
using System.Threading.Tasks;
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
        private Timer frameUpdateTimer;
        private int currentFrameIndex = 0;
        private const int INIT_WIDTH = 600;
        private const int INIT_HEIGHT = 400;
        private const int INIT_BUFFER_WIDTH = 128; //600;
        private const int INIT_BUFFER_HEIGHT = 128; //400;
        private const NativeImageSource.ColorDepth COLOR_DEPTH = NativeImageSource.ColorDepth.Bits24;// NativeImageSource.ColorDepth.Bits32;

        public void Activate()
        {
            log.Debug(tag, "Activate(): start \n");
            window = NUIApplication.GetDefaultWindow();

            // Create a root view with blue background
            root = new View()
            {
                Size = new Size(window.WindowSize.Width, window.WindowSize.Height),
                BackgroundColor = Color.Blue,
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

            // Set frame interpolation interval (e.g., 0.5s)
            videoView.FrameInterpolationInterval = 2.5f;

            // Initialize video size by setting the first frame.
            if (testNativeImageSources[0] != null)
            {
                videoView.SetNativeImageSourceForCurrentFrame(testNativeImageSources[0]);
                currentFrameIndex = (currentFrameIndex + 1) % 3;
            }

            // Set up timer to update frames
            frameUpdateTimer = new Timer(2500); // Update every 500ms
            frameUpdateTimer.Tick += OnFrameUpdateTimerTick;
            frameUpdateTimer.Start();
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
            Task task = new Task(() =>
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
                        destData[i + 2] = sourData[i]; // B
                    }
                }
                Tizen.Log.Error("NUI", $"ReleaseBuffer\n");
                source.ReleaseBuffer();
            });
            task.Start();
            task.Wait(); // Wait for buffer assignment to complete before using the source
        }

        private bool OnFrameUpdateTimerTick(object source, Timer.TickEventArgs e)
        {
            log.Debug(tag, $"idx : {currentFrameIndex}\n");
            // Cycle through R, G, B frames
            if (testNativeImageSources[currentFrameIndex] != null)
            {
                videoView.SetNativeImageSourceForCurrentFrame(testNativeImageSources[currentFrameIndex]);
            }
            currentFrameIndex = (currentFrameIndex + 1) % 3;
            return true; // Keep timer running
        }

        public void Deactivate()
        {
            if (frameUpdateTimer != null)
            {
                frameUpdateTimer.Stop();
                frameUpdateTimer.Tick -= OnFrameUpdateTimerTick;
                frameUpdateTimer.Dispose();
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
            }
            videoView?.Dispose();
            root?.Dispose();
            blurView?.Dispose();
        }

        const string tag = "NUITEST";
    }
}
