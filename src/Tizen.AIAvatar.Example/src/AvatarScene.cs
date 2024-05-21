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

using global::System;
using System.IO;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;
using Tizen.AIAvatar;
using Tizen;
using Tizen.Uix.Tts;

namespace AIAvatar
{
    public class AvatarScene : SceneView
    {
        private static string resourcePath = Utils.ResourcePath;
        private const int cameraAnimationDurationMilliSeconds = 2000;
        private const int sceneTransitionDurationMilliSeconds = 1500;

        private Avatar defaultAIAvatar;
        private List<AvatarInfo> avatarList;
        private int avatarIndex = 0;

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

        public void StartAvatarTalk_1()
        {
            //var text = "test";// editor.Text;
            //defaultAIAvatar.Speak(text);
            PlayLip("cs-CZ-Wavenet-A.wav");
        }

        public void StartAvatarTalk_2()
        {
            //var text = "test";// editor.Text;
            //defaultAIAvatar.Speak(text);
            PlayLip("da-DK-Wavenet-A.wav");
        }

        public void StartAvatarTalk_3()
        {
            //var text = "test";// editor.Text;
            //defaultAIAvatar.Speak(text);
            PlayLip("el-GR-Wavenet-A.wav");
        }

        public void StartAvatarTalkByPath()
        {
            //defaultAIAvatar.PlayLipSync($"{resourcePath}/voice/voice_0.bin");
        }

        internal static string GetFileNameWithoutExtension(string path)
        {
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }
        internal static readonly string ApplicationResourcePath = "/usr/apps/org.tizen.default-avatar-resource/shared/res/";
        internal static readonly string EmojiAvatarResourcePath = "/models/EmojiAvatar/";
        internal static readonly string DefaultMotionResourcePath = "/animation/motion/";
        public void StartRandomAnimation()
        {
            //defaultAIAvatar.PlayRandomAnimation(3000);
            
            var motionAnimations = Directory.GetFiles(ApplicationResourcePath + DefaultMotionResourcePath, "*.bvh");
            var animationInfoList = new List<AnimationInfo>();
            MotionData motionData = new MotionData();
                Tizen.Log.Error("MYLOG", "Path : "+motionAnimations[0]);
            motionData.LoadMotionCaptureAnimation(motionAnimations[0], true, new Vector3(0.01f, 0.01f, 0.01f), false);

            if(motionData == null)
            {
                Tizen.Log.Error("MYLOG", "MotionData is not null\n");
            }
            else
            {

                Tizen.Log.Error("MYLOG", "MotionData is null\n");
            }
            defaultAIAvatar.PlayAnimation(motionData);
        }

        public void InitMic()
        {
            //defaultAIAvatar.InitializeMicrophone();
        }

        public void StartMic()
        {
            //defaultAIAvatar.StartMicrophone();
        }

        public void StopMic()
        {
            //defaultAIAvatar.StopMicrophone();
        }

        private bool isBlink = false;

        public void EyeBlink()
        {
            if(!isBlink)
            {
                defaultAIAvatar.StartEyeBlink();
            }
            else
            {
                defaultAIAvatar.StopEyeBlink();
            }
            isBlink = !isBlink;
        }

        private bool isShowing = true;

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

        public void InintTTsTest()
        {
            //defaultAIAvatar.InitTTS();
        }

        public void StartTTSTest()
        {
            /*
            defaultAIAvatar.StopTTS();
            VoiceInfo voiceInfo;
            voiceInfo.Lang = "en_US";
            voiceInfo.Type = Voice.Female;

            defaultAIAvatar.PrepareTTS(Utils.TTSText, voiceInfo, (o, e)=>{
                CallSpeechBubble();
                defaultAIAvatar.PlayPreparedTTS();
            });
            */
        }

        
        public void CallSpeechBubble()
        {
            //말풍선 보여주기(로그 테스트)
            Log.Error("Tizen.AIAvatar", "Bubble Speach Test Text");
        }

        public void StopTTSTest()
        {
            //defaultAIAvatar.StopTTS();
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
            if(avatarIndex + 1 <= avatarList.Count - 1)
            {
                avatarIndex++;
            }
            else
            {
                avatarIndex = 0;
            }
            CreateAvatar();

        }

        private void PlayLip(string source)
        {
            var bytes = ReadAllBytes($"{resourcePath}/voice/{source}");
            if (bytes != null)
            {
                //defaultAIAvatar.PlayLipSync(bytes);
            }
            else
            {
                Tizen.Log.Error("AIAvatar", "Fail to load bytes");

            }
        }

        private byte[] ReadAllBytes(string path)
        {
            try
            {
                var bytes = File.ReadAllBytes(path);
                return bytes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetupDefaultAvatar()
        {
            avatarList = AvatarExtension.GetDefaultAvatarList();
            foreach(var info in avatarList)
            {
                Tizen.Log.Info("AvatarSample", $"Avatar Name :{info.Name}\n");
                Tizen.Log.Info("AvatarSample", $"Avatar Thumbnail :{info.ThumbnailPath}\n");
            }

            CreateAvatar();
        }

        private void CreateAvatar()
        {
            defaultAIAvatar = new Avatar(avatarList[avatarIndex])
            {
                Position = new Position(0.0f, -1.70f, -2.0f),
                Size = new Size(2.0f, 2.0f, 2.0f),
                Orientation = new Rotation(new Radian(new Degree(0.0f)), Vector3.YAxis)
            };
            //var animator = defaultAIAvatar.CurrentAnimator;
            //animator.MotionStateChanged += OnMotionStateChanged;
            //animator.LipStateChanged += OnLipStateChanged;
            Add(defaultAIAvatar);

//            var tracker= new AvatarMotionTracker(defaultAIAvatar);
        }

        private void DestroyAvatar()
        {
            if (defaultAIAvatar != null)
            {
                Remove(defaultAIAvatar);
                /*
                var animator = defaultAIAvatar.CurrentAnimator;
                animator.MotionStateChanged -= OnMotionStateChanged;
                animator.LipStateChanged -= OnLipStateChanged;
*/
                defaultAIAvatar.Dispose();
                defaultAIAvatar = null;
            }

        }

        private void OnMotionStateChanged(object sender, AvatarMotionChangedEventArgs e)
        {
            var avatar = sender as Avatar;//Avatar changed state

            switch (e.Current)
            {
                case AvatarMotionState.Ready:
                    Log.Error(Utils.LogTag, "Current Avatar State is Ready");
                    break;

                case AvatarMotionState.Playing:
                    Log.Error(Utils.LogTag, "Current Avatar State is Playing");
                    break;

                case AvatarMotionState.Paused:
                    Log.Error(Utils.LogTag, "Current Avatar State is Paused");
                    break;

                case AvatarMotionState.Stopped:
                    Log.Error(Utils.LogTag, "Current Avatar State is Stopped");
                    break;
            }
        }

        private void OnLipStateChanged(object sender, AvatarMotionChangedEventArgs e)
        {
            var avatar = sender as Avatar;//Avatar changed state

            switch (e.Current)
            {
                case AvatarMotionState.Ready:
                    Log.Error(Utils.LogTag, "Current Avatar Lip is Ready");
                    break;

                case AvatarMotionState.Playing:
                    Log.Error(Utils.LogTag, "Current Avatar Lip is Playing");
                    break;

                case AvatarMotionState.Paused:
                    Log.Error(Utils.LogTag, "Current Avatar Lip is Paused");
                    break;

                case AvatarMotionState.Stopped:
                    Log.Error(Utils.LogTag, "Current Avatar Lip is Stopped");
                    break;
            }
        }

        private void SetupSceneViewIBL()
        {
            SetImageBasedLightSource(resourcePath + "images/" + "Irradiance.ktx", resourcePath + "images/" + "Radiance.ktx", IBLFactor);
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
