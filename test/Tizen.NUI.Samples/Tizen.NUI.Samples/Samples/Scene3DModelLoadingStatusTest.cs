using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Samples
{
    public class Scene3DModelLoadingStatusTest : IExample
    {
        private Window window;
        private SceneView sceneView;
        private Model model;
        private string validModelPath;
        private const string invalidModelPath = "non_existent_model.glb";
        private bool loadValidModel = true;
        private Scene3D.Camera camera;
        private Timer statusCheckTimer;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.SetBackgroundColor(Color.White);

            string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            validModelPath = resourcePath + "models/BoxAnimated.glb";

            // Initialize SceneView to fill the window
            sceneView = new SceneView()
            {
                Size = new Size(window.Size.Width, window.Size.Height),
                PivotPoint = PivotPoint.TopLeft,
                ParentOrigin = ParentOrigin.TopLeft,
                PositionUsesPivotPoint = true,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f), // Dark grey background for scene
                UseFramebuffer = true,
            };
            window.Add(sceneView);

            SetupCameraAndScene();
            LoadModel();

            // Set up a timer to check loading status periodically
            statusCheckTimer = new Timer(1000); // Check every 1000ms
            statusCheckTimer.Tick += OnStatusCheckTimer;
            statusCheckTimer.Start();

            window.KeyEvent += OnKeyEvent;
        }

        public void Deactivate()
        {
            window.KeyEvent -= OnKeyEvent;
            if (model != null)
            {
                model.ResourcesLoaded -= OnModelResourcesLoaded;
                if (sceneView != null && model.GetParent() == sceneView)
                {
                   sceneView.Remove(model);
                }
                model.Dispose();
                model = null;
            }
            if (camera != null)
            {
                // Camera is managed by SceneView, but if we created it, we should remove and dispose.
                // Scene3DCameraTransitionTest adds camera to SceneView.
                // Let's assume SceneView handles disposal of cameras it contains.
                // If we explicitly added it, we might need to remove it.
                // For now, let SceneView handle it.
                camera = null;
            }
            if (sceneView != null)
            {
                window.Remove(sceneView);
                sceneView.Dispose();
                sceneView = null;
            }
            window = null;
        }

        private void SetupCameraAndScene()
        {
            // Create and add camera to SceneView
            camera = new Scene3D.Camera()
            {
                Name = "camera1",
                Position = new Position(5.0f, -5.0f, 5.0f),
                NearPlaneDistance = 1.0f,
                FarPlaneDistance = 10.0f,
            };
            camera.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
            sceneView.AddCamera(camera);
            sceneView.SelectCamera("camera1"); // Select the camera we just added
        }

        private void LoadModel()
        {
            if (model != null)
            {
                model.ResourcesLoaded -= OnModelResourcesLoaded;
                if (sceneView != null && model.GetParent() == sceneView)
                {
                    sceneView.Remove(model);
                }
                model.Dispose();
                model = null;
            }

            string modelPathToLoad = loadValidModel ? validModelPath : invalidModelPath;

            model = new Model(modelPathToLoad)
            {
                Size = new Size(1.0f, 1.0f, 1.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };

            // The ResourcesLoaded event is used to react to loading completion.
            model.ResourcesLoaded += OnModelResourcesLoaded;
            sceneView.Add(model);
        }

        private void OnModelResourcesLoaded(object sender, EventArgs e)
        {
            if (model != null)
            {
                if (model.LoadingStatus == ModelLoadingStatusType.Ready)
                {
                    model.BackgroundColor = Color.Red;
                    model.GetAnimation(0).Play();
                }
                else
                {
                    model.BackgroundColor = Color.Blue;
                }
            }
        }

        private bool OnStatusCheckTimer(object sender, Timer.TickEventArgs e)
        {
            // Toggle between valid and invalid model
            loadValidModel = !loadValidModel;
            LoadModel();
            return true; // Keep the timer running
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "XF86Back")
                {
                    Deactivate();
                }
            }
        }
    }
}
