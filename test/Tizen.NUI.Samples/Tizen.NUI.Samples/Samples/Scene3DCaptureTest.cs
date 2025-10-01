using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class Scene3DCaptureTest : IExample
    {
        private Window window;
        private SceneView sceneView;
        private static readonly string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Tizen.NUI.Scene3D.Camera[] cameras;
        private string[] cameraName;
        private int cameraIndex;
        int captureId;
        ImageView imageView;
        ImageUrl imageUrl;
        bool inCapture = false;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            Size2D windowSize = window.Size;

            sceneView = new SceneView()
            {
                Size = new Size(windowSize.Width, windowSize.Height),
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                PositionUsesPivotPoint = true,
                BackgroundColor = new Color(0.85f, 0.85f, 0.85f, 1.0f),
                UseFramebuffer = true,
            };
            window.Add(sceneView);

            Light light = new Light()
            {
                Color = new Vector4(0.4f, 0.4f, 0.4f, 1.0f),
                Position = new Vector3(-1.0f, 0.0f, 1.1f),
                PositionUsesPivotPoint = true,
            };
            light.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
            sceneView.Add(light);

            cameras = new Scene3D.Camera[2];
            cameraName = new string[]{"camera1", "camera2"};
            Vector3[] cameraPosition = new Vector3[]{new Vector3(1.5f, 0.0f, 1.5f), new Vector3(-1.5f, -1.5f, 1.5f)};
            Vector3 modelPosition = new Vector3(-1.5f, 0.0f, 0.0f);

            cameraIndex = 0;
            for(uint i = 0; i<2; ++i)
            {
                cameras[i] = new Scene3D.Camera()
                {
                    Name = cameraName[i],
                    Position = cameraPosition[i],
                    NearPlaneDistance = 1.0f,
                    FarPlaneDistance = 10.0f,
                };
                sceneView.AddCamera(cameras[i]);
            }
            cameras[1].FieldOfView = new Radian(new Degree(70.0f));

            Model model = new Model(resourcePath + "models/BoxAnimated.glb")
            {
                PositionUsesPivotPoint = true,
                Position = modelPosition,
                Size = new Size(0.5f, 0.5f, 0.5f),
            };
            sceneView.Add(model);
            model.Add(cameras[0]);
            sceneView.SelectCamera(cameraName[0]);
            model.ResourcesLoaded += (s, e) =>
            {
                SceneCapture(1);
            };
            sceneView.Add(cameras[1]);

            cameras[0].LookAt(modelPosition);
            cameras[1].LookAt(modelPosition);

            sceneView.CaptureFinished += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"Finished Capture ID : {e.CaptureId}\n");
                if(e.CapturedImageUrl == null)
                {
                    Tizen.Log.Error("NUI", $"Capture Failed\n");
                    return;
                }
                CreateImageView(e.CapturedImageUrl);
            };

            window.KeyEvent += WindowKeyEvent;
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    SceneCapture(cameraIndex);
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    SceneCaptureAsync(cameraIndex);
                }
                else
                {
                    return;
                }

                cameraIndex = 1 - cameraIndex;
                sceneView.SelectCamera(cameraName[cameraIndex]);
            }
        }

        void SceneCapture(int captureCameraIndex)
        {
            captureId = sceneView.Capture(cameras[captureCameraIndex], new Vector2(300, 300));
            Tizen.Log.Error("NUI", $"Requestd Capture ID : {captureId}\n");
        }

        async void SceneCaptureAsync(int captureCameraIndex)
        {
            try
            {
                var url = await sceneView.CaptureAsync(cameras[captureCameraIndex], new Vector2(300, 300));
                Tizen.Log.Error("NUI", $"Finished Capture url : {url.ToString()}\n");
                CreateImageView(url);
            }
            catch (InvalidOperationException e)
            {
                Tizen.Log.Error("NUI", "Oops Capture is failed.\n");
            }
        }

        void CreateImageView(ImageUrl capturedImageUrl)
        {
            if (imageView != null)
            {
                imageView.Dispose();
            }
            if (imageUrl != null)
            {
                imageUrl.Dispose();
            }
            imageUrl = capturedImageUrl;

            imageView = new ImageView(imageUrl.ToString())
            {
                Size = new Size(300, 300),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.BottomLeft,
                PivotPoint = PivotPoint.BottomLeft
            };
            window.Add(imageView);
        }

        public void Deactivate()
        {
            window.KeyEvent -= WindowKeyEvent;
            sceneView?.DisposeRecursively();
        }
    }
}
