/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
    /// The Avatar class displays 3D avatars and provides easy access to their animations.
    /// This class is a sub-class of the Model class which allows us to easily control the Avatar's animations.
    /// Avatar also supports AR Emoji for humanoid-based 3D models.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Avatar : Model
    {
        private AvatarProperties avatarProperties = new DefaultAvatarProperties();

        private MotionPlayer motionPlayer;

        /// <summary>  
        /// The AvatarProperties property gets or sets the AvatarProperties object containing various information about the Avatar.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarProperties Properties
        {
            get => avatarProperties;
            set
            {
                avatarProperties = value;
            }
        }

        /// <summary>
        /// Create an initialized AvatarModel.
        /// </summary>
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
        /// <param name="avatarUrl">avatar file url.(e.g. glTF).</param>
        /// <param name="resourceDirectoryUrl"> The url to derectory containing resources: binary, image etc.</param>
        /// <remarks>
        /// If resourceDirectoryUrl is empty, the parent directory url of avatarUrl is used for resource url.
        ///
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(string avatarUrl, string resourceDirectoryUrl = "") : base(avatarUrl, resourceDirectoryUrl)
        {
            InitAvatar();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="avatar">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(Avatar avatar) : base(avatar)
        {
            InitAvatar();
        }

        #region Manage Animating

        /// <summary>  
        /// Plays the specified avatar animation with an optional duration and loop count.  
        /// </summary>  
        /// <param name="animationInfo">The AnimationInfo object containing information about the desired avatar animation.</param>  
        /// <param name="duration">The duration of the animation in milliseconds (default is 3000).</param>  
        /// <param name="isLooping">A boolean indicating whether the animation should be looped or not.</param>  
        /// <param name="loopCount">The number of times to repeat the animation if it's set to loop.</param>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PlayAnimation(AnimationInfo animationInfo, int duration = 3000, bool isLooping = false, int loopCount = 1)
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
            motionAnimation = GenerateMotionDataAnimation(animationInfo.MotionData);
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

        Animation motionAnimation;

        /// <summary>  
        /// Plays the specified avatar animation with MotionData and an optional duration and loop count.  
        /// </summary>  
        /// <param name="motionData">The MotionData object containing information about the desired avatar animation.</param>  
        /// <param name="duration">The duration of the animation in milliseconds (default is 3000).</param>  
        /// <param name="isLooping">A boolean indicating whether the animation should be looped or not.</param>  
        /// <param name="loopCount">The number of times to repeat the animation if it's set to loop.</param>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PlayAnimation(MotionData motionData, int duration = 3000, bool isLooping = false, int loopCount = 1)
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

        /// <summary>  
        /// Plays the specified avatar animation based on its index within the available animations and an optional duration and loop count.  
        /// </summary>  
        /// <param name="index">The zero-based index of the desired avatar animation within the list of available animations.</param>  
        /// <param name="duration">The duration of the animation in milliseconds (default is 3000).</param>  
        /// <param name="isLooping">A boolean indicating whether the animation should be looped or not.</param>  
        /// <param name="loopCount">The number of times to repeat the animation if it's set to loop.</param>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PlayAnimation(int index, int duration = 3000, bool isLooping = false, int loopCount = 1)
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
        /// Pauses the currently playing avatar animation.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseMotionAnimation()
        {
            motionPlayer.PauseMotionAnimation();
        }

        /// <summary>  
        /// Stops the currently playing avatar animation.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopMotionAnimation()
        {
            motionPlayer?.StopMotionAnimation();
        }

        /// <summary>  
        /// Starts the eye blink animation for the current avatar.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartEyeBlink()
        {
            motionPlayer?.StartEyeBlink();
        }

        /// <summary>  
        /// Pauses the eye blink animation for the current avatar.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseEyeBlink()
        {
            motionPlayer?.PauseEyeBlink();
        }

        /// <summary>  
        /// Stops the eye blink animation for the current avatar.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopEyeBlink()
        {
            motionPlayer?.StopEyeBlink();
        }
        #endregion
        
        private void InitAvatar()
        {
            motionPlayer = new MotionPlayer();
            var eyeMotionData = CreateEyeBlinkMotionData(200);
            if (eyeMotionData == null)
            {
                Tizen.Log.Info(LogTag, "Failed Loading eyeAnimation");
            }

            ResourcesLoaded += (s, e) =>
            {
                var eyeAnimation = GenerateMotionDataAnimation(eyeMotionData);
                if (eyeAnimation != null)
                {
                    motionPlayer.SetBlinkAnimation(eyeAnimation);
                }
            };
        }

        private MotionData CreateEyeBlinkMotionData(int ms)
        {
            var keyFrames = new KeyFrames();
            keyFrames.Add(0.1f, 0.0f);
            keyFrames.Add(0.5f, 1.0f);
            keyFrames.Add(0.9f, 0.0f);

            var headBlendShapeEyeLeft = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.HeadGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkLeft);
            var headBlendShapeEyeRight = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.HeadGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkRight);
            var eyelashBlendShapeEyeLeft = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.EyelashGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkLeft);
            var eyelashBlendShapeEyeRight = new AvatarBlendShapeIndex(avatarProperties.NodeMapper, NodeType.EyelashGeo, avatarProperties.BlendShapeMapper, BlendShapeType.EyeBlinkRight);

            var motionData = new MotionData(ms);
            motionData.Add(headBlendShapeEyeLeft, new MotionValue(keyFrames));
            motionData.Add(headBlendShapeEyeRight, new MotionValue(keyFrames));
            motionData.Add(eyelashBlendShapeEyeLeft, new MotionValue(keyFrames));
            motionData.Add(eyelashBlendShapeEyeRight, new MotionValue(keyFrames));

            return motionData;
        }
    }
}
