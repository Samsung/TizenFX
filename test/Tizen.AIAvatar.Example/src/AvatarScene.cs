/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

using Tizen;
using Tizen.NUI;
using Tizen.NUI.Scene3D;
using System.Collections.Generic;
using System.IO;

namespace AIAvatar
{
    public class AvatarScene : SceneView
    {
        private static string resourcePath = Utils.ResourcePath;

        private const int cameraAnimationDurationMilliSeconds = 2000;
        private const int sceneTransitionDurationMilliSeconds = 1500;

        private AIAvatar defaultAIAvatar;
        private readonly string avatarFilename = "/model_external.gltf";
        private List<string> avatarPathList = new List<string>();
        private int avatarIndex = 0;

        private bool isShowing = true;

        private float iblFactor = 0.3f;
            
        public float IBLFactor
        {
            get
            {
                return iblFactor;
            }
            set
            {
                iblFactor = value;
                ImageBasedLightScaleFactor = value;
            }
        }

        public AvatarScene()
        {
            PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
            PositionUsesPivotPoint = true;

            // Setup Image Based Light
            SetupSceneViewIBL();

            // Setup camera preset
            SetupDefaultCamera();

            // Setup Default Avatar Position & Orientation
            SetupDefaultAvatar();
        }


        public void SetupSceneViewIBLFactor(float value)
        {
            IBLFactor = value;
        }


        public void ShowHide()
        {
            if (!isShowing)
            {
                defaultAIAvatar.Show();
            }
            else
            {
                defaultAIAvatar.Hide();
            }
            isShowing = !isShowing;
        }

       
        public void SwitchCamera()
        {
            CameraTransition(1, cameraAnimationDurationMilliSeconds);
        }

        public void SetupSceneViewCameraFov(float value)
        {
            var camera = GetSelectedCamera();
            camera.FieldOfView = new Radian(value);
        }

        public void ChangeAvatar()
        {
            DestroyAvatar();

            if (avatarPathList.Count != 0)
            {
                avatarIndex = (avatarIndex + 1) % avatarPathList.Count;
                defaultAIAvatar = CreateAvatar(avatarPathList[avatarIndex] + avatarFilename);
                Add(defaultAIAvatar);
            }

        }

        public void TriggerRandomBodyAnimation()
        {
            defaultAIAvatar.PlayRandomBodyAnimation();
        }

        public void TriggerMultipleFacialAnimations()
        {
            defaultAIAvatar.PlayMultipleFacialAnimations();
        }

        public void TriggerExpressionAniatmion()
        {
            defaultAIAvatar.PlayExpressionAniatmion();
        }

        public void TriggerLipSync()
        {
            defaultAIAvatar.PlayLipSync();
        }

        public void TriggerAudioLipSync()
        {
            defaultAIAvatar.PlayAudioLipSync();
        }

        public void TriggerEyeBlink()
        {
            defaultAIAvatar.StartEyeBlink();
        }

        public void TriggerPauseAnimations()
        {
            defaultAIAvatar.PauseAnimations();
        }

        public void TriggerStopAnimations()
        {
            defaultAIAvatar.StopAnimations();
        }


        public void TriggerSamsungAIService()
        {
            defaultAIAvatar.TestSamsungAIService();
        }


        public bool CheckFilesInFolder(string folderPath, params string[] fileExtensions)
        {
            foreach (var extension in fileExtensions)
            {
                if (Directory.GetFiles(folderPath, $"*{extension}").Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetupDefaultAvatar()
        {
            var avatarPaths = Directory.GetDirectories(resourcePath + "/Model/");
            foreach (var directoryInfo in avatarPaths)
            {                
                Log.Info(Utils.LogTag, $"Model Path : {directoryInfo}");
                if(CheckFilesInFolder(directoryInfo, ".gltf", ".GLTF"))
                {
                    avatarPathList.Add(directoryInfo);
                }
            }

            if (avatarPathList.Count == 0)
            {
                Log.Error(Utils.LogTag, "The avatar model is not available in the resource folder.");
            }
            else
            {
                defaultAIAvatar = CreateAvatar(avatarPathList[avatarIndex] + avatarFilename);
                Add(defaultAIAvatar);
            }            
        }

        private AIAvatar CreateAvatar(string path)
        {
            AIAvatar avatar = new AIAvatar(path)
            {
                Position = new Position(0.0f, -1.70f, -2.0f),
                Size = new Size(1.0f, 1.0f, 1.0f),
                Orientation = new Rotation(new Radian(new Degree(0.0f)), Vector3.YAxis)
            };


            avatar.ResourcesLoaded += (sender, args) => 
            {
                avatar.Initialize();
                Log.Debug(Utils.LogTag, "Resource Loaded");
            };

            return avatar;
            
        }

        private void DestroyAvatar()
        {
            if (defaultAIAvatar != null)
            {
                defaultAIAvatar.StopAnimations();
                Remove(defaultAIAvatar);
                defaultAIAvatar.Dispose();
                defaultAIAvatar = null;
            }
        }

    

        private void SetupSceneViewIBL()
        {
            SetImageBasedLightSource(resourcePath + "Images/" + "Irradiance.ktx", resourcePath + "Images/" + "Radiance.ktx", IBLFactor);
        }

        private void SetupDefaultCamera()
        {
            // Default camera setting
            // Note : SceneView always have 1 default camera.
            var defaultCamera = GetCamera(0u);

            defaultCamera.PositionX = 0.0f;
            defaultCamera.PositionY = -2.3f;
            defaultCamera.PositionZ = 0.0f;
            defaultCamera.FieldOfView = new Radian(new Degree(45.0f));
        }
    }
}
