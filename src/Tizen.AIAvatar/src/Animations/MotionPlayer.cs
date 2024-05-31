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

using Tizen.NUI;
using Tizen.NUI.Scene3D;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class MotionPlayer
    {
        private Animation motionAnimation;
        private EyeBlinker eyeBlinker;

        internal Animation MotionAnimation { get => motionAnimation; private set => motionAnimation = value; }

        internal MotionPlayer()
        {
            eyeBlinker = new EyeBlinker();


        }

        internal void PlayAnimation(Animation motionAnimation, int duration = 3000, bool isLooping = false, int loopCount = 1)
        {
            ResetAnimations();
            if (motionAnimation != null)
            {
                MotionAnimation = motionAnimation;
                MotionAnimation?.Play();
            }
            else
            {
                Tizen.Log.Error(LogTag, "motionAnimation is null");
            }
        }

        internal void PauseMotionAnimation()
        {
            MotionAnimation?.Pause();
        }

        internal void StopMotionAnimation()
        {
            MotionAnimation?.Stop();
        }

        internal void SetBlinkAnimation(Animation blinkerAnimation)
        {
            eyeBlinker?.Init(blinkerAnimation);
        }

        internal void StartEyeBlink()
        {
            eyeBlinker?.Play();
        }

        internal void PauseEyeBlink()
        {
            eyeBlinker?.Pause();
        }


        internal void StopEyeBlink()
        {
            eyeBlinker?.Stop();
        }

        internal void DestroyAnimations()
        {
            eyeBlinker?.Destroy();
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
