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

using System;
using Tizen.NUI;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class EyeBlinker : IBlendShapeModule, IDisposable
    {
        private AvatarMotionState currentMotionState = AvatarMotionState.Unavailable;

        private readonly Object motionChangedLock = new Object();
        private event EventHandler<AvatarMotionChangedEventArgs> motionChanged;

        private const int blinkIntervalMinimum = 800;
        private const int blinkIntervalMaximum = 3000;
        private Animation eyeAnimation;

        private Timer blinkTimer;

        private bool isPlaying = false;
        private const int blinkDuration = 200;

        public AvatarMotionState CurrentMotionState
        {
            get
            {
                return currentMotionState;
            }
            set
            {
                if (currentMotionState == value)
                {
                    return;
                }
                var preState = currentMotionState;
                currentMotionState = value;
                if (motionChanged != null)
                {
                    motionChanged?.Invoke(this, new AvatarMotionChangedEventArgs(preState, currentMotionState));
                }
            }
        }

        public event EventHandler<AvatarMotionChangedEventArgs> MotionStateChanged
        {
            add
            {
                lock (motionChangedLock)
                {
                    motionChanged += value;
                }

            }

            remove
            {
                lock (motionChangedLock)
                {
                    if (motionChanged == null)
                    {
                        Log.Error(LogTag, "Remove StateChanged Failed : motionChanged is null");
                        return;
                    }
                    motionChanged -= value;
                }
            }
        }

        public EyeBlinker()
        {

        }

        public void Dispose()
        {
            DestroyAnimation();
        }

        public void Init(Animation eyeAnimation)
        {
            this.eyeAnimation = eyeAnimation;
        }

        public void Play()
        {
            //data
            StartEyeBlink();
        }

        public void Stop()
        {
            StopEyeBlink();
        }

        public void Pause()
        {
            eyeAnimation?.Pause();
        }

        public void Destroy()
        {
            DestroyAnimation();
        }

        private void StartEyeBlink()
        {
            DestroyBlinkTimer();

            blinkTimer = new Timer(blinkDuration);
            if (blinkTimer != null)
            {
                blinkTimer.Tick += OnBlinkTimer;
                blinkTimer?.Start();
                isPlaying = true;
            }
        }

        private void PauseEyeBlink()
        {
            blinkTimer?.Stop();
            isPlaying = false;
        }

        private void StopEyeBlink()
        {
            blinkTimer?.Stop();
            isPlaying = false;
        }

        private void DestroyAnimation()
        {
            DestroyBlinkTimer();
            if (eyeAnimation != null)
            {
                eyeAnimation.Stop();
                eyeAnimation.Dispose();
                eyeAnimation = null;
            }
            isPlaying = false;
        }

        private bool OnBlinkTimer(object source, Timer.TickEventArgs e)
        {
            if (eyeAnimation == null)
            {
                Log.Error(LogTag, "eye animation is not ready");
                return false;
            }
            eyeAnimation?.Play();

            var random = new Random();
            var fortimerinterval = (uint)random.Next(blinkIntervalMinimum, blinkIntervalMaximum);
            blinkTimer.Interval = fortimerinterval;
            return true;
        }

        private void DestroyBlinkTimer()
        {
            if (blinkTimer != null)
            {
                blinkTimer.Tick -= OnBlinkTimer;
                blinkTimer.Stop();
                blinkTimer.Dispose();
                blinkTimer = null;
            }
        }
    }
}
