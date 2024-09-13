using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;
    public class Scene3DCameraTransitionTest : IExample
    {
        private Window window;
        private SceneView sceneView;
        private static readonly string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Tizen.NUI.Scene3D.Camera[] cameras;
        private string[] cameraName;
        private int cameraIndex;
        private bool inCameraTransition;
        private int sourceCameraIndex, destinationCameraIndex;

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
            cameraName = new string[] { "camera1", "camera2" };
            Vector3[] cameraPosition = new Vector3[] { new Vector3(1.5f, 0.0f, 1.5f), new Vector3(-1.5f, -1.5f, 1.5f) };
            Vector3 modelPosition = new Vector3(-1.5f, 0.0f, 0.0f);

            cameraIndex = 0;
            for (uint i = 0; i < 2; ++i)
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
            sceneView.Add(cameras[1]);
            inCameraTransition = false;

            cameras[0].LookAt(modelPosition);
            cameras[1].LookAt(modelPosition);

            sceneView.CameraTransitionFinished += (s, e) =>
            {
                inCameraTransition = false;
                Tizen.Log.Error("NUI", $"Camera transition finished from {cameraName[sourceCameraIndex]} to {cameraName[destinationCameraIndex]}.\n");
            };

            window.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    if (inCameraTransition)
                    {
                        return;
                    }

                    inCameraTransition = true;
                    sourceCameraIndex = cameraIndex;
                    destinationCameraIndex = 1 - cameraIndex;
                    Tizen.Log.Error("NUI", $"Request to transition of Camera from {cameraName[sourceCameraIndex]} to {cameraName[destinationCameraIndex]}.\n");

                    cameraIndex = 1 - cameraIndex;
                    sceneView.CameraTransition(cameraName[cameraIndex], 2000);
                }
            };
        }

        public void Deactivate()
        {
        }
    }
}
