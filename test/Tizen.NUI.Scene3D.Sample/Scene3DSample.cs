/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;
using Tizen.NUI.Scene3D;
using System.Collections.Generic;

class Scene3DSample : NUIApplication
{
    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";
    static string MODEL_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "model/";

    Window mWindow;
    Vector2 mWindowSize;

    SceneView mSceneView;
    Model mModel;

    Animation mModelRotateAnimation;
    const int modelRotateAnimationDurationMilliseconds = 10000; // milliseconds

    private bool mMutex = false; // Lock key event during some transition / Change informations

    #region Model list define
    private static readonly List<string> ModelUrlList = new List<string>()
    {
        // Model reference : https://sketchfab.com/models/b81008d513954189a063ff901f7abfe4
        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/DamagedHelmet
        "DamagedHelmet/DamagedHelmet.gltf",
        "BoxAnimated/BoxAnimated.gltf",
    };
    private int currentModelIndex = 0;
    #endregion

    #region Image based light list define
    private static readonly List<(string, string)> IBLUrlList = new List<(string, string)>
    {
        ("forest_diffuse_cubemap.png", "forest_specular_cubemap.png"),
        ("papermill_E_diffuse-64.ktx", "papermill_pmrem.ktx"),
        ("Irradiance.ktx", "Radiance.ktx"),
    };
    private int currentIBLIndex = 0;
    private float IBLFactor = 0.7f;
    #endregion

    #region Camera list define
    private class CameraInfo
    {
        public Vector3 Position {get; set;} = Vector3.Zero;
        public Rotation Orientation {get; set;} = null;
        public Radian Fov {get; set;} = null;
        public float Near {get; set;} = 0.5f;
        public float Far {get; set;} = 50.0f;
    };
    private static readonly List<CameraInfo> CameraInfoList = new List<CameraInfo>()
    {
        // -Z front and -Y up.
        new CameraInfo(){
            Position = new Vector3(0.0f, 0.0f, 5.55f),
            // Basic camera           : +Z front and -Y up
            // After YAxis 180 rotate : -Z front and -Y up
            // Note : Default camera has YAxis 180.0f rotation even we didn't setup.
            Orientation = new Rotation(new Radian(new Degree(180.0f)), Vector3.YAxis),
            Fov = new Radian(new Degree(45.0f)),
            Near = 0.5f,
            Far = 50.0f,
        },

        // +Y front and +X up.
        new CameraInfo(){
            Position = new Vector3(0.0f, -3.95f, 0.0f),
            // Rotate by XAxis first, and then rotate by YAxis
            // Basic camera           : +Z front and -Y up
            // After XAxis -90 rotate : +Y front and +Z up
            // After YAxis 90 rotate  : +Y front and +X up
            Orientation = new Rotation(new Radian(new Degree(90.0f)), Vector3.YAxis) *
                          new Rotation(new Radian(new Degree(-90.0f)), Vector3.XAxis),
            Fov = new Radian(new Degree(70.0f)),
            Near = 0.5f,
            Far = 50.0f,
        },
    };
    uint currentCameraIndex = 0u;
    const int cameraAnimationDurationMilliseconds = 2000; // milliseconds
    #endregion

    protected void CreateSceneView()
    {
        mSceneView = new SceneView()
        {
            SizeWidth = mWindowSize.Width,
            SizeHeight = mWindowSize.Height,
            PositionX = 0.0f,
            PositionY = 0.0f,
            PivotPoint = PivotPoint.TopLeft,
            ParentOrigin = ParentOrigin.TopLeft,
            PositionUsesPivotPoint = true,
        };

        mSceneView.CameraTransitionFinished += (o, e) =>
        {
            if (mMutex)
            {
                mMutex = false;
            }
        };

        mSceneView.ResourcesLoaded += (o, e) =>
        {
            Tizen.Log.Error("NUI", $"IBL image loaded done\n");
            if (mMutex)
            {
                mMutex = false;
            }
        };

        SetupSceneViewCamera(mSceneView);

        mWindow.Add(mSceneView);
    }
    private void SetupSceneViewCamera(SceneView sceneView)
    {
        int cameraCount = CameraInfoList.Count;
        for (int i = 0; i < cameraCount; ++i)
        {
            var cameraInfo = CameraInfoList[i];
            Tizen.NUI.Scene3D.Camera camera;
            if (i == 0)
            {
                // Default camera setting
                // Note : SceneView always have 1 default camera.
                camera = sceneView.GetCamera(0u);
            }
            else
            {
                // Additional camera setting (top view camera).
                camera = new Tizen.NUI.Scene3D.Camera();
                sceneView.AddCamera(camera);
            }
            camera.PositionX = cameraInfo?.Position?.X ?? 0.0f;
            camera.PositionY = cameraInfo?.Position?.Y ?? 0.0f;
            camera.PositionZ = cameraInfo?.Position?.Z ?? 0.0f;
            camera.Orientation = cameraInfo?.Orientation ?? new Rotation(new Radian(new Degree(180.0f)), Vector3.YAxis);

            camera.NearPlaneDistance = cameraInfo?.Near ?? 0.5f;
            camera.FarPlaneDistance = cameraInfo?.Far ?? 50.0f;
            camera.FieldOfView = cameraInfo?.Fov ?? new Radian(new Degree(45.0f));
        }
    }

    protected void CreateModel(string modelUrl)
    {
        // Release old one.
        if (mModel != null)
        {
            mModel.Unparent();
            mModel.Dispose();
        }

        mModel = new Model(MODEL_DIR + modelUrl)
        {
            Name = modelUrl,
        };
        mModel.ResourcesLoaded += (s, e) =>
        {
            Model model = s as Model;

            // You can play animation if the animation exists.
            if (model.GetAnimationCount() > 0u)
            {
                model.GetAnimation(0u).Looping = true;
                model.GetAnimation(0u).Play();
            }
            Tizen.Log.Error("NUI", $"{model.Name} size : {model.Size.Width}, {model.Size.Height}, {model.Size.Depth}\n");

            if (mMutex)
            {
                mMutex = false;
            }
        };
        mModelRotateAnimation = new Animation(modelRotateAnimationDurationMilliseconds);
        mModelRotateAnimation.AnimateBy(mModel, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.YAxis));

        mModelRotateAnimation.Looping = true;
        mModelRotateAnimation.Play();

        mSceneView.Add(mModel);

        mMutex = true;
    }

    void SetupIBLimage(string specularUrl, string diffuseUrl, float iblFactor)
    {
        mSceneView.SetImageBasedLightSource(IMAGE_DIR + specularUrl, IMAGE_DIR + diffuseUrl, iblFactor);

        mMutex = true;
    }

    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        // Skip interaction when some resources are changing now.
        if (mMutex)
        {
            return;
        }
        if (e.Key.State == Key.StateType.Down)
        {
            FullGC();

            switch (e.Key.KeyPressedName)
            {
                case "Escape":
                case "Back":
                {
                    Deactivate();
                    Exit();
                    break;
                }

                case "Return":
                case "Select":
                {
                    currentCameraIndex++;
                    if (currentCameraIndex >= mSceneView.GetCameraCount())
                    {
                        currentCameraIndex = 0;
                    }

                    mSceneView.CameraTransition(currentCameraIndex, cameraAnimationDurationMilliseconds);

                    mMutex = true;
                    break;
                }

                case "1":
                {
                    currentModelIndex++;
                    if (currentModelIndex >= ModelUrlList.Count)
                    {
                        currentModelIndex = 0;
                    }

                    CreateModel(ModelUrlList[currentModelIndex]);
                    break;
                }
                case "2":
                {
                    currentIBLIndex++;
                    if (currentIBLIndex >= IBLUrlList.Count)
                    {
                        currentIBLIndex = 0;
                    }

                    SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, IBLFactor);
                    break;
                }
            }
        }
    }


    public void Activate()
    {
        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.DarkOrchid;
        mWindowSize = mWindow.WindowSize;

        mWindow.KeyEvent += OnKeyEvent;

        CreateSceneView();
        SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, IBLFactor);
        CreateModel(ModelUrlList[currentModelIndex]);
    }
    public void FullGC(){
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    public void Deactivate()
    {
        DestroyScene();
    }
    private void DestroyScene()
    {
    }

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();
        Activate();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        Scene3DSample example = new Scene3DSample();
        example.Run(args);
    }
}
