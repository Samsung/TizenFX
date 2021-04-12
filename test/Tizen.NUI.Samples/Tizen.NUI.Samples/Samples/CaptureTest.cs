
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class CaptureTest : IExample
    {
        public void Activate()
        {
            resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            window = NUIApplication.GetDefaultWindow();
            window.TouchEvent += Win_TouchEvent;

            root = new View()
            {
                Name = "test_root",
                Size = new Size(500, 500),
                Position = new Position(10, 10),
                BackgroundColor = Color.White,
            };

            window.Add(root);

            capturedView0 = new ImageView(resourcePath + "/images/image1.jpg")
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Red,
            };
            root.Add(capturedView0);

            capturedView1 = new ImageView(resourcePath + "/images/image2.jpg")
            {
                Size = new Size(150, 150),
                Position = new Position(150, 150),
                BackgroundColor = Color.Yellow,
            };
            root.Add(capturedView1);
        }

        private void onCaptureFinished(object sender, CaptureFinishedEventArgs e)
        {
            log.Debug(tag, $"onCaptureFinished() statue={e.Success} \n");

            if (sender is Capture)
            {
                var url = capture.GetNativeImageSource().Url;
                capturedImage = new ImageView(url);
                log.Debug(tag, $"url={url} \n");

                capturedImage.Size = new Size(510, 510);
                capturedImage.Position = new Position(10, 10);
                root.Add(capturedImage);
                done = false;
            }
        }

        private void Win_TouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                if (!done)
                {
                    done = true;
                    capture = new Capture()
                    {
                        Size = new Size(510, 510),
                        ClearColor = Color.White,
                        Path = "/opt/usr/nui_captured.jpg",
                    };
                    capture.Start(capturedView0);
                    capture.Finished += onCaptureFinished;
                    log.Debug(tag, $"capture done \n");
                }
            }
        }

        public void Deactivate()
        {
        }

        const string tag = "NUITEST";
        private Window window;
        private View root, capturedView0, capturedView1;
        private Capture capture;
        private ImageView capturedImage;
        private bool done = false;
        private string resourcePath;
    }
}
