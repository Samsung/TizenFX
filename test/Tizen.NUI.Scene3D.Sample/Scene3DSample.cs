/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Accessibility;

class Scene3DSample : NUIApplication
{
    static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";
    static string MODEL_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "model/";

    Window mWindow;
    Vector2 mWindowSize;

    private float mSceneViewSizeRate = 0.95f; // The scene view size relation as window size.

    SceneView mSceneView;
    Model mModel;
    Animation mModelAnimation;
    bool mModelLoadFinished;
    bool mIsCustomOverlay = false;

    // Note : This motion data works well only if model is MorthStressTest!
    MotionData mStaticMotionData;
    MotionData mStaticRevertMotionData;
    MotionData mAnimateMotionData;
    Animation mMotionAnimation;
    const int modelMotionAnimationDurationMilliseconds = 2000; // milliseconds

    Animation mModelRotateAnimation;
    const int modelRotateAnimationDurationMilliseconds = 10000; // milliseconds

    private bool mMutex = false; // Lock key event during some transition / Change informations

    #region Model list define
    /*
     * Copyright 2021 Analytical Graphics, Inc.
     * CC-BY 4.0 https://creativecommons.org/licenses/by/4.0/
     */
    private static readonly List<string> ModelUrlList = new List<string>()
    {
        // Model reference : https://sketchfab.com/models/b81008d513954189a063ff901f7abfe4
        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/DamagedHelmet
        "DamagedHelmet/DamagedHelmet.gltf",

        //Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/MorphStressTest
        "MorphStressTest/MorphStressTest.gltf",

        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/2CylinderEngine
        "2CylinderEngine/2CylinderEngine_e.gltf",

        // Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/ToyCar
        "ToyCar/ToyCar.glb",

        //Get from KhronosGroup https://github.com/KhronosGroup/glTF-Sample-Models/tree/master/2.0/BoxAnimated
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
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Rotation Orientation { get; set; } = null;
        public Radian Fov { get; set; } = null;
        public float Near { get; set; } = 0.5f;
        public float Far { get; set; } = 50.0f;
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
    List<Tizen.NUI.Scene3D.Camera> additionalCameraList;
    const int cameraAnimationDurationMilliseconds = 2000; // milliseconds
    #endregion

    protected void CreateSceneView()
    {
        mSceneView = new SceneView()
        {
            SizeWidth = mWindowSize.Width * mSceneViewSizeRate,
            SizeHeight = mWindowSize.Height * mSceneViewSizeRate,
            PositionX = 0.0f,
            PositionY = 0.0f,
            PivotPoint = PivotPoint.Center,
            ParentOrigin = ParentOrigin.Center,
            PositionUsesPivotPoint = true,

            UseFramebuffer = true,
            BackgroundColor = Color.DarkOrchid,
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

        // Release old animation if exist
        if (mModelAnimation != null)
        {
            mModelAnimation.Stop();
            mModelAnimation.Dispose();
            mModelAnimation = null;
        }

        // Release old camera if exist
        if (additionalCameraList != null)
        {
            if (currentCameraIndex >= CameraInfoList.Count)
            {
                currentCameraIndex = 0u;
                Tizen.Log.Error("NUI", $"Use camera [{currentCameraIndex}]\n");
                mSceneView.SelectCamera(currentCameraIndex);
            }
            foreach (var additionalCamera in additionalCameraList)
            {
                mSceneView.RemoveCamera(additionalCamera);
                additionalCamera.Dispose();
            }
            additionalCameraList = null;
        }

        mModelLoadFinished = false;

        mModel = new Model(MODEL_DIR + modelUrl)
        {
            Name = modelUrl,
        };

        mModel.SetAccessibilityRoleV2(AccessibilityRoleV2.Model);
        mModel.AccessibilityName = "Model";
        mModel.AccessibilityHighlightable = true;

        mModel.ResourcesLoaded += (s, e) =>
        {
            Model model = s as Model;

            // You can play animation if the animation exists.
            if (model.GetAnimationCount() > 0u)
            {
                mModelAnimation = model.GetAnimation(0u);
                if (mModelAnimation != null)
                {
                    mModelAnimation.Looping = true;
                    mModelAnimation.Play();
                }
            }
            // You can apply camera properties if the camera parameter exists.
            if (model.GetCameraCount() > 0u)
            {
                additionalCameraList = new List<Tizen.NUI.Scene3D.Camera>();
                bool firstSucceededCamera = true;
                for (uint i = 0; i < model.GetCameraCount(); ++i)
                {
                    Tizen.NUI.Scene3D.Camera additionalCamera = new Tizen.NUI.Scene3D.Camera();
                    // If we success to make additional camera from model, Add that camera into sceneview, and select that.
                    if (model.ApplyCamera(i, additionalCamera))
                    {
                        mSceneView.AddCamera(additionalCamera);
                        if (firstSucceededCamera)
                        {
                            currentCameraIndex = mSceneView.GetCameraCount() - 1u;

                            Tizen.Log.Error("NUI", $"Use additional camera [{currentCameraIndex}]\n");
                            mSceneView.SelectCamera(currentCameraIndex);
                            firstSucceededCamera = false;
                        }
                        additionalCameraList.Add(additionalCamera);
                    }
                    else
                    {
                        Tizen.Log.Error("NUI", $"Error! camera at [{i}] have some problem\n");
                        additionalCamera.Dispose();
                    }
                }
            }
            Tizen.Log.Error("NUI", $"{model.Name} size : {model.Size.Width}, {model.Size.Height}, {model.Size.Depth}\n");
            Tizen.Log.Error("NUI", $"Animation count {model.GetAnimationCount()} , Camera count {model.GetCameraCount()}\n");

            // Auto rotate model only if it don't have camera.
            if (mModel.GetCameraCount() == 0u)
            {
                mModelRotateAnimation.Play();
            }

            mModelLoadFinished = true;

            if (mMutex)
            {
                mMutex = false;
            }
        };

        if (mModelRotateAnimation != null)
        {
            mModelRotateAnimation.Stop();
            mModelRotateAnimation.Dispose();
            mModelRotateAnimation = null;
        }

        mModelRotateAnimation = new Animation(modelRotateAnimationDurationMilliseconds);
        mModelRotateAnimation.AnimateBy(mModel, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.YAxis));

        mModelRotateAnimation.Looping = true;

        mSceneView.Add(mModel);

        mMutex = true;
    }

    // Note : This motion data works well only if model is MorthStressTest!
    private void CreateMotionData()
    {
        mStaticMotionData = new MotionData();
        mStaticRevertMotionData = new MotionData();
        mAnimateMotionData = new MotionData();

        mAnimateMotionData.Duration = modelMotionAnimationDurationMilliseconds;

        mStaticMotionData.Add(
            new MotionTransformIndex()
            {
                ModelNodeId = new PropertyKey("Main"),
                TransformType = MotionTransformIndex.TransformTypes.Orientation,
            },
            new MotionValue()
            {
                PropertyValue = new PropertyValue(new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis)),
            }
        );
        mStaticRevertMotionData.Add(
            new MotionTransformIndex()
            {
                ModelNodeId = new PropertyKey("Main"),
                TransformType = MotionTransformIndex.TransformTypes.Orientation,
            },
            new MotionValue()
            {
                PropertyValue = new PropertyValue(new Rotation(new Radian(new Degree(0.0f)), Vector3.ZAxis)),
            }
        );
        mStaticRevertMotionData.Add(
            new MotionTransformIndex()
            {
                ModelNodeId = new PropertyKey("Main"),
                TransformType = MotionTransformIndex.TransformTypes.Scale,
            },
            new MotionValue()
            {
                PropertyValue = new PropertyValue(Vector3.One),
            }
        );

        mAnimateMotionData.Add(
            new MotionTransformIndex()
            {
                ModelNodeId = new PropertyKey("Main"),
                TransformType = MotionTransformIndex.TransformTypes.Scale,
            },
            new MotionValue()
            {
                PropertyValue = new PropertyValue(new Vector3(0.5f, 1.5f, 1.0f)),
            }
        );
        for (int i = 0; i < 8; ++i)
        {
            MotionIndex index = new BlendShapeIndex()
            {
                ModelNodeId = new PropertyKey("Main"),
                BlendShapeId = new PropertyKey(i),
            };
            MotionValue value = new MotionValue()
            {
                KeyFramesValue = new KeyFrames()
            };
            value.KeyFramesValue.Add(0.0f, 0.0f);
            value.KeyFramesValue.Add(1.0f, 1.0f * ((float)Math.Abs(i - 3.5f) + 0.5f) / 4.0f);

            mAnimateMotionData.Add(index, value);
        }
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

                    Tizen.Log.Error("NUI", $"Use camera [{currentCameraIndex}]\n");
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

                    Tizen.Log.Error("NUI", $"Create model [{currentModelIndex}]\n");
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

                    Tizen.Log.Error("NUI", $"Use Light image [{currentIBLIndex}]\n");
                    SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, IBLFactor);
                    break;
                }
                case "r":
                {
                    if (mModelRotateAnimation.State == Animation.States.Playing)
                    {
                        mModelRotateAnimation.Pause();
                    }
                    else
                    {
                        mModelRotateAnimation.Play();
                    }
                    break;
                }
                case "f":
                {
                    if (mModel != null && mModelLoadFinished)
                    {
                        if (mModelAnimation != null && mModelAnimation.State == Animation.States.Playing)
                        {
                            mMotionAnimation = mModel.GenerateMotionDataAnimation(mAnimateMotionData);

                            if (mMotionAnimation != null)
                            {
                                // Stop original model animation
                                mModelAnimation.Stop();

                                mModel.SetMotionData(mStaticMotionData);
                                mMotionAnimation.Looping = true;
                                mMotionAnimation.BlendPoint = 0.25f;
                                mMotionAnimation.Play();
                                Tizen.Log.Error("NUI", $"Animate pre-defined motion data!\n");
                            }
                        }
                    }
                    break;
                }
                case "c":
                {
                    if (mSceneView != null)
                    {
                        mSceneView.CornerRadius = new Vector4(60.0f, 60.0f, 60.0f, 60.0f);
                        mSceneView.CornerSquareness = new Vector4(0.6f, 0.6f, 0.6f, 0.6f);
                        mSceneView.CornerRadiusPolicy = VisualTransformPolicyType.Absolute;
                        mSceneView.BorderlineWidth = 20.0f;
                        mSceneView.BorderlineColor = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
                        mSceneView.BorderlineOffset = -1.0f;
                    }
                    break;
                }
                case "a":
                {
                    if (!mIsCustomOverlay)
                    {
                        var newSize = new Size2D(500, 500);
                        var newPosition = new Position2D(100, 100);
                        Accessibility.SetCustomHighlightOverlay(mModel, newPosition, newSize);
                    }
                    else
                    {
                        Accessibility.ResetCustomHighlightOverlay(mModel);
                    }
                    mIsCustomOverlay = !mIsCustomOverlay;
                    break;
                }
            }

            FullGC();
        }
        else if (e.Key.State == Key.StateType.Up)
        {
            if (mModelAnimation != null && mModelAnimation.State == Animation.States.Stopped)
            {
                if (mMotionAnimation != null)
                {
                    mMotionAnimation.Stop();
                    mMotionAnimation.Dispose();
                    mMotionAnimation = null;

                    // Revert motion data
                    mModel.SetMotionData(mStaticRevertMotionData);

                    // Replay original model animation
                    mModelAnimation.Play();
                }
            }
            if (mSceneView != null)
            {
                mSceneView.CornerRadius = Vector4.Zero;
                mSceneView.BorderlineWidth = 0.0f;
            }
        }
    }

    public void Activate()
    {
        mWindow = Window.Default;
        mWindow.BackgroundColor = Color.Blue;
        mWindowSize = mWindow.WindowSize;

        mWindow.Resized += (o, e) =>
        {
            mWindowSize = mWindow.WindowSize;
            mSceneView.Size = new Size(mWindowSize * mSceneViewSizeRate);
        };

        mWindow.KeyEvent += OnKeyEvent;

        // Create motion data for MorphStressTest.gltf
        CreateMotionData();

        CreateSceneView();
        SetupIBLimage(IBLUrlList[currentIBLIndex].Item1, IBLUrlList[currentIBLIndex].Item2, IBLFactor);
        CreateModel(ModelUrlList[currentModelIndex]);
    }
    public void FullGC()
    {
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
