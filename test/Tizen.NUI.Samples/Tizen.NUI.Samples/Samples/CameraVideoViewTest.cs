
using global::System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;

    public class CameraVideoViewTest : IExample
    {

        Window win;
        CameraView cameraView;
        VideoView videoView;
        Tizen.Multimedia.Camera camera;

        const string tag = "gab_test";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = new Color(1, 1, 1, 0);
            win.KeyEvent += Win_KeyEvent;

            AddCameraView();
            AddVideoView();
        }

        private void AddCameraView()
        {
            camera = new Tizen.Multimedia.Camera(Tizen.Multimedia.CameraDevice.Front);

            // default display type is Window (Overlay mode)
            cameraView = new CameraView(camera.Handle, CameraView.DisplayType.Window);
            cameraView.Size = new Size(300, 300);
            cameraView.Position = new Position(100, 50);

            if (camera != null && camera.State == Tizen.Multimedia.CameraState.Created)
            {
                camera.StartPreview();
            }
            win.Add(cameraView);
        }

        private void AddVideoView()
        {
            videoView = new VideoView();
            videoView.Underlay = false;
            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "v.mp4";
            videoView.ResourceUrl = resourcePath;
            videoView.Looping = true;
            videoView.Size = new Size(300, 300);
            videoView.Position = new Position(100, 360);
            videoView.Play();
            win.Add(videoView);
        }

        public void Deactivate()
        {
            win.KeyEvent -= Win_KeyEvent;

            if (camera != null )
            {
                if(camera.State == Tizen.Multimedia.CameraState.Preview)
                    camera.StopPreview();

                camera.Dispose();
            }

            videoView.Dispose();

            tlog.Fatal(tag, $"Deactivate()! cameraView dispsed");
        }


        private void Win_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                tlog.Fatal(tag, $"key pressed name={e.Key.KeyPressedName}");
                if (e.Key.KeyPressedName == "XF86Back")
                {
                    Deactivate();
                }
            }
        }

    }
}


