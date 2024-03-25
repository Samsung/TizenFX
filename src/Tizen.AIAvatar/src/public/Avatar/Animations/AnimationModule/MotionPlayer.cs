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
using Tizen.NUI;
using Tizen.NUI.Scene3D;

namespace Tizen.AIAvatar
{
    internal class MotionPlayer
    {
        private Animation motionAnimation;
        internal Animation MotionAnimation { get => motionAnimation; private set => motionAnimation = value; }

        internal MotionPlayer()
        {

        }

        /// <summary>
        /// Play avatar animation by AnimationInfo
        /// </summary>
        /// <param name="index">index of default avatar animations</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void PlayAnimation(Animation motionAnimation, int duration = 3000, bool isLooping = false, int loopCount = 1)
        {
            ResetAnimations();

            MotionAnimation = this.motionAnimation;
            MotionAnimation.Play();
        }

        /// <summary>
        /// Pause avatar animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void PauseMotionAnimation()
        {
            MotionAnimation?.Pause();
        }

        /// <summary>
        /// Stop avatar animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void StopMotionAnimation()
        {
            MotionAnimation?.Stop();
        }

        private void ResetAnimations()
        {
            if (MotionAnimation != null)
            {
                MotionAnimation.Stop();
                MotionAnimation.Dispose();
                MotionAnimation = null;
            }
        }
    }
}
