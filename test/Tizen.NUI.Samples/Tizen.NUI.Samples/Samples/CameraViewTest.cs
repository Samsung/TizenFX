
using global::System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;

    public class CameraViewTest : IExample
    {

        Window win;
        CameraView overlayCameraView;
        CameraView imageCameraView;
        Button overlayButton;
        Button nativeButton;
        Button sizeButton;
        Button rotationButton;

        Tizen.Multimedia.Camera overlayCamera;
        Tizen.Multimedia.Camera imageCamera;

        const string tag = "NUI";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = new Color(1, 1, 1, 0);
            win.KeyEvent += Win_KeyEvent;

            overlayButton = new Button();
            overlayButton.Text = "Overlay";
            overlayButton.Size = new Size(100, 100);
            overlayButton.Position = new Position( 50, 750);
            overlayButton.Clicked += OverlayButtonClicked;
            win.Add(overlayButton);

            nativeButton = new Button();
            nativeButton.Text = "Image";
            nativeButton.Size = new Size(100, 100);
            nativeButton.Position = new Position( 160, 750);
            nativeButton.Clicked += NativeButtonClicked;
            win.Add(nativeButton);

            sizeButton = new Button();
            sizeButton.Text = "Size";
            sizeButton.Size = new Size(100, 100);
            sizeButton.Position = new Position(50, 850);
            sizeButton.Clicked += sizeButtonClicked;
            win.Add(sizeButton);


            rotationButton = new Button();
            rotationButton.Text = "Rotation";
            rotationButton.Size = new Size(100, 100);
            rotationButton.Position = new Position(160, 850);
            rotationButton.Clicked += rotationButtonClicked;
            win.Add(rotationButton);

            OverlayCamera();
            // ImageCamera();

        }

        private int rotationCnt = 0;
        private void rotationButtonClicked(object sender, ClickedEventArgs e)
        {
            int rotation = rotationCnt % 4;
            Vector3 axis;
            Degree degree;
            if(overlayCamera != null) {
                switch(rotation)
                {
                    case 0 :
                        overlayCamera.DisplaySettings.Rotation = Tizen.Multimedia.Rotation.Rotate0;
                        overlayCameraView.Update();
                        break;
                    case 1:
                        overlayCamera.DisplaySettings.Rotation = Tizen.Multimedia.Rotation.Rotate90;
                        overlayCameraView.Update();
                        break;
                    case 2:
                        overlayCamera.DisplaySettings.Rotation = Tizen.Multimedia.Rotation.Rotate180;
                        overlayCameraView.Update();
                        break;
                    case 3:
                        overlayCamera.DisplaySettings.Rotation = Tizen.Multimedia.Rotation.Rotate270;
                        overlayCameraView.Update();
                        break;
                    default:
                        overlayCamera.DisplaySettings.Rotation = Tizen.Multimedia.Rotation.Rotate0;
                        overlayCameraView.Update();
                        break;
                }
            }
            rotationCnt++;
        }

        private void OverlayButtonClicked(object sender, ClickedEventArgs e)
        {
            if(imageCamera != null)
            {
                imageCamera.StopPreview();
                imageCamera.Dispose();
                imageCamera = null;
                win.Remove(imageCameraView);
            }
            if(overlayCamera == null)
            {
                OverlayCamera();
            }
        }

        private void NativeButtonClicked(object sender, ClickedEventArgs e)
        {
            if(overlayCamera != null)
            {
                overlayCamera.StopPreview();
                overlayCamera.Dispose();
                overlayCamera = null;
                win.Remove(overlayCameraView);
            }
            if(imageCamera == null)
            {
                ImageCamera();
            }
        }

        private void OverlayCamera()
        {

            overlayCamera = new Tizen.Multimedia.Camera(Tizen.Multimedia.CameraDevice.Front);
            // default display type is Window (Overlay mode)
            overlayCameraView = new CameraView(overlayCamera.Handle);
            overlayCameraView.PositionUsesPivotPoint = true;
            overlayCameraView.ParentOrigin = ParentOrigin.TopLeft;
            overlayCameraView.PivotPoint = PivotPoint.TopLeft;
            overlayCameraView.Size = new Size(300, 400);
            overlayCameraView.Position = new Position(100, 200);

            overlayCamera.StartPreview();

            win.Add(overlayCameraView);
        }

        private void ImageCamera()
        {

            imageCamera = new Tizen.Multimedia.Camera(Tizen.Multimedia.CameraDevice.Front);
            // default display type is Window (Overlay mode)
            imageCameraView = new CameraView(imageCamera.Handle, CameraView.DisplayType.Image);
            imageCameraView.PositionUsesPivotPoint = true;
            imageCameraView.ParentOrigin = ParentOrigin.TopLeft;
            imageCameraView.PivotPoint = PivotPoint.TopLeft;
            imageCameraView.Position = new Position(0, 400);
            imageCameraView.Size = new Size(300, 300);

            imageCamera.StartPreview();

            win.Add(imageCameraView);
        }

        private int size = 300;
        private void sizeButtonClicked(object sender, ClickedEventArgs e)
        {
            if(overlayCameraView != null)
                overlayCameraView.Size = new Size(size, size);
            if(imageCameraView != null)
                imageCameraView.Size = new Size(size, size);
            size += 20;
        }


        public void Deactivate()
        {
            win.KeyEvent -= Win_KeyEvent;

             if(imageCamera != null)
            {

                imageCamera.StopPreview();
                imageCamera.Dispose();
                imageCamera = null;

                win.Remove(imageCameraView);
                imageCameraView.Dispose();
            }

            if(overlayCamera != null)
            {
                overlayCamera.StopPreview();
                overlayCamera.Dispose();
                overlayCamera = null;
                win.Remove(overlayCameraView);
                overlayCameraView.Dispose();
            }


            tlog.Fatal(tag, $"Deactivate()! cameraView disposed");
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



