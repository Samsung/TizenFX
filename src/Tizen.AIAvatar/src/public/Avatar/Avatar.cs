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

using System.ComponentModel;
using Tizen.NUI.Scene3D;
using Tizen.NUI;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Avatar is a Class to show 3D avatar objects.
    /// It is subclass of Model s.t. we can control Avatar like models animation easly.
    /// For example, 
    /// 
    /// Avatar supports AR Emoji.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Avatar : Model
    {
        private AvatarProperties avatarProperties = new DefaultAvatarProperties();
        private AvatarMotions avatarMotions;

        private BlendShapePlayer avatarAnimator;
        private MotionPlayer motionPlayer;
        private JointTransformer jointTransformer;

        /// <summary>
        /// Create an initialized AvatarModel.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar() : base()
        {
            InitAvatar();
        }

        /// <summary>
        /// Create an initialized AREmojiDefaultAvatar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(AvatarInfo avatarInfo) : base(avatarInfo.ResourcePath)
        {
            InitAvatar();
        }

        /// <summary>
        /// Create an initialized Avatar.
        /// </summary>
        /// <param name="avatarlUrl">avatar file url.(e.g. glTF, and DLI).</param>
        /// <param name="resourceDirectoryUrl"> The url to derectory containing resources: binary, image etc.</param>
        /// <remarks>
        /// If resourceDirectoryUrl is empty, the parent directory url of avatarUrl is used for resource url.
        ///
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(string avatarUrl, string resourceDirectoryUrl = "") : base(avatarUrl, resourceDirectoryUrl)
        {
            InitAvatar();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="avatar">Source object to copy.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(Avatar avatar) : base(avatar)
        {
            InitAvatar();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarProperties AvatarProperties
        {
            get => avatarProperties;
            set => avatarProperties = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal BlendShapePlayer AvatarAnimator
        {
            get => avatarAnimator; 
            set => avatarAnimator = value;
        }


        /// <summary>
        /// Play avatar animation by AnimationInfo
        /// </summary>
        /// <param name="index">index of default avatar animations</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void PlayAnimation(AnimationInfo animationInfo, int duration = 3000, bool isLooping = false, int loopCount = 1)
        {
            if (animationInfo == null)
            {
                Tizen.Log.Error(LogTag, "animationInfo is null");
                return;
            }
            if (animationInfo.MotionData == null)
            {
                Tizen.Log.Error(LogTag, "animationInfo.MotionData is null");
                return;
            }
            var motionAnimation = GenerateMotionDataAnimation(animationInfo.MotionData);
            if (motionAnimation != null)
            {
                motionAnimation.Duration = duration;
                motionAnimation.Looping = isLooping;
                motionAnimation.LoopCount = loopCount;
                motionAnimation.BlendPoint = 0.2f;
                motionPlayer.PlayAnimation(motionAnimation);
            }
            else
            {
                Tizen.Log.Error(LogTag, "motionAnimation is null");
            }
        }

        /// <summary>
        /// Play avatar animation by MotionData
        /// </summary>
        /// <param name="index">index of default avatar animations</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void PlayAnimation(MotionData motionData, int duration = 3000, bool isLooping = false, int loopCount = 1)
        {

            if (motionData == null)
            {
                Tizen.Log.Error(LogTag, "motionData is null");
                return;
            }
            var motionAnimation = GenerateMotionDataAnimation(motionData);
            if (motionAnimation != null)
            {
                motionAnimation.Duration = duration;
                motionAnimation.Looping = isLooping;
                motionAnimation.LoopCount = loopCount;
                motionAnimation.BlendPoint = 0.2f;
                motionPlayer.PlayAnimation(motionAnimation);
            }
            else
            {
                Tizen.Log.Error(LogTag, "motionAnimation is null");
            }
        }

        private void PlayAnimation(int index, int duration = 3000, bool isLooping = false, int loopCount = 1)
        {
            //TODO by index
            //var motionAnimation = GenerateMotionDataAnimation(animationInfoList[index].MotionData);
            /*motionAnimation.Duration = duration;
            motionAnimation.Looping = isLooping;
            motionAnimation.LoopCount = loopCount;
            motionAnimation.BlendPoint = 0.2f;

            motionPlayer.PlayAnimation(motionAnimation);*/
        }

        /// <summary>
        /// Pause avatar animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void PauseMotionAnimation()
        {
            motionPlayer.PauseMotionAnimation();
        }

        /// <summary>
        /// Stop avatar animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void StopMotionAnimation()
        {
            motionPlayer?.StopMotionAnimation();
        }


        private void InitAvatar()
        {
            avatarMotions = new AvatarMotions(avatarProperties);

            AvatarAnimator = new BlendShapePlayer();

            avatarProperties.AvatarPropertiesChanged += (s, e) =>
            {
                var eyeAnimation = CreateMotionAnimation(avatarMotions.EyeMotionData);
                if (eyeAnimation != null)
                {
                    avatarAnimator.SetBlinkAnimation(eyeAnimation);
                }
            };

            ResourcesLoaded += (s, e) =>
            {
                var eyeAnimation = CreateMotionAnimation(avatarMotions.EyeMotionData);
                if (eyeAnimation != null)
                {
                    avatarAnimator.SetBlinkAnimation(eyeAnimation);
                }
            };
        }

        private Animation CreateMotionAnimation(MotionData data)
        {
            return GenerateMotionDataAnimation(data);
        }
    }
}
