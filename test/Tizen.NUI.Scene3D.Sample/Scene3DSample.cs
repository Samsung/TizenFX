/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd.
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
    Model     mModel;

    uint currentCameraIndex = 0u;
    const int cameraAnimationDurationMilliSeconds = 2000; // milliSeconds

    Animation mModelRotateAnimation;
    const int modelRotateAnimationDurationMilliSeconds = 10000; // milliSeconds

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

        SetupSceneViewCamera(mSceneView);

        mWindow.Add(mSceneView);
    }
    private void SetupSceneViewCamera(SceneView sceneView)
    {
        // Default camera setting
        // Note : SceneView always have 1 default camera.
        Tizen.NUI.Scene3D.Camera defaultCamera = sceneView.GetCamera(0u);

        defaultCamera.PositionX = 0.0f;
        defaultCamera.PositionY = 0.0f;
        defaultCamera.PositionZ = 5.55f;
        defaultCamera.NearPlaneDistance = 0.5f;
        defaultCamera.FarPlaneDistance = 50.0f;
        //defaultCamera.Orientation = new Rotation(new Radian(new Degree(180.0f)), Vector3.YAxis);
        defaultCamera.FieldOfView = new Radian(new Degree(45.0f));
        defaultCamera.OrthographicSize = 2.7f;

        // Additional camera setting (top view camera).
        Tizen.NUI.Scene3D.Camera camera = new Tizen.NUI.Scene3D.Camera()
        {
            PositionX = 0.0f,
            PositionY = -3.95f,
            PositionZ = 0.0f,
            NearPlaneDistance = 0.5f,
            FarPlaneDistance = 50.0f,
            // Rotate by XAxis first, and then rotate by YAxis
            Orientation = new Rotation(new Radian(new Degree(90.0f)), Vector3.YAxis) *
                            new Rotation(new Radian(new Degree(-90.0f)), Vector3.XAxis),
            FieldOfView = new Radian(new Degree(70.0f)),
            OrthographicSize = 2.7f,
        };
        sceneView.AddCamera(camera);
    }

    protected void CreateModel(string modelUrl)
    {
        // Release old one.
        if(mModel != null)
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

            // You can play animation if it has.
            if(model.GetAnimationCount() > 0u)
            {
                model.GetAnimation(0u).Looping = true;
                model.GetAnimation(0u).Play();
            }
            Tizen.Log.Error("NUI", $"{model.Name} size : {model.Size.Width}, {model.Size.Height}, {model.Size.Depth}\n");
        };
        mModelRotateAnimation = new Animation(modelRotateAnimationDurationMilliSeconds);
        mModelRotateAnimation.AnimateBy(mModel, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.YAxis));

        mModelRotateAnimation.Looping = true;
        mModelRotateAnimation.Play();

        mSceneView.Add(mModel);
    }

    void SetupIBLimage(string specularUrl, string diffuseUrl, float iblFactor)
    {
        mSceneView.SetImageBasedLightSource(IMAGE_DIR + specularUrl, IMAGE_DIR + diffuseUrl,iblFactor);
    }

    void OnKeyEvent(object source, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            FullGC();
            //Streamline.AnnotateChannelEnd(0);

            switch( e.Key.KeyPressedName )
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
                    if(currentCameraIndex >= mSceneView.GetCameraCount())
                    {
                        currentCameraIndex = 0;
                    }

                    mSceneView.CameraTransition(currentCameraIndex, cameraAnimationDurationMilliSeconds);
                    break;
                }

                case "1":
                {
                    currentModelIndex++;
                    if(currentModelIndex >= ModelUrlList.Count)
                    {
                        currentModelIndex = 0;
                    }

                    CreateModel(ModelUrlList[currentModelIndex]);
                    break;
                }
                case "2":
                {
                    currentIBLIndex++;
                    if(currentIBLIndex >= IBLUrlList.Count)
                    {
                        currentIBLIndex = 0;
                    }

                    SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, 0.7f);
                    break;
                }
            }
        }
    }

    private static readonly List<string> ModelUrlList = new List<string>()
    {
        // Model reference : https://sketchfab.com/models/b81008d513954189a063ff901f7abfe4
        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/DamagedHelmet
        "DamagedHelmet/DamagedHelmet.gltf",
        "BoxAnimated/BoxAnimated.gltf",
    };
    private int currentModelIndex = 0;

    private static readonly List<(string, string)> IBLUrlList = new List<(string, string)>
    {
        ("forest_diffuse_cubemap.png", "forest_specular_cubemap.png"),
        ("papermill_E_diffuse-64.ktx", "papermill_pmrem.ktx"),
        ("Irradiance.ktx", "Radiance.ktx"),
    };
    private int currentIBLIndex = 0;

    public void Activate()
    {
        mWindow = Window.Instance;
        mWindow.BackgroundColor = Color.DarkOrchid;
        mWindowSize = mWindow.WindowSize;

        mWindow.KeyEvent += OnKeyEvent;

        CreateSceneView();
        SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, 0.7f);
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
