
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
            log.Debug(tag, $"Activate(): start \n");
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

            log.Debug(tag, $"root view added \n");

            capturedView0 = new ImageView(resourcePath + "/images/image1.jpg")
            {
                Name = "test_v0",
                Size = new Size(100, 100),
                BackgroundColor = Color.Red,
            };
            root.Add(capturedView0);

            capturedView1 = new ImageView(resourcePath + "/images/image2.jpg")
            {
                Name = "test_v1",
                Size = new Size(150, 150),
                Position = new Position(150, 150),
                BackgroundColor = Color.Yellow,
            };
            root.Add(capturedView1);

            //TDD
            //tddTest();
            //checkCaptureNew();
        }

        private void onCaptureFinished(object sender, CaptureFinishedEventArgs e)
        {
            log.Debug(tag, $"onCaptureFinished() statue={e.Success} \n");

            if (sender is Capture)
            {
                log.Debug(tag, $"sender is Capture \n");
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
                    capture = new Capture();
                    capture.Start(root, new Size(510, 510), @"/opt/usr/nui_captured.jpg");
                    capture.Finished += onCaptureFinished;
                    log.Debug(tag, $"capture done \n");
                }
            }
        }

        private void tddTest()
        {
            log.Debug(tag, $"TDD test before Assert");

            Assert.IsFalse(true, "TDD test, Exception throw");

            Assert.IsFalse(false, "TDD test, Exception throw");

            log.Debug(tag, $"TDD test after Assert");
        }

        private void checkCaptureNew()
        {
            var target = new Capture();
            Assert.IsNotNull(target, "target should not be null");
            Assert.IsTrue(target is Capture, "target should be Capture class");
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
