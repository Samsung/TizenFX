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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Scene3D;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class AnimationModule
    {
        private AvatarMotionState currentMotionState = AvatarMotionState.Unavailable;

        private readonly Object motionChangedLock = new Object();
        private event EventHandler<AvatarMotionChangedEventArgs> motionChanged;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationModule()
        {

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Init(Animation animation);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Play(IAnimationModuleData data);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Stop();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Pause();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Destroy();

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetCurrentState(AvatarMotionState state)
        {
            CurrentMotionState = state;
        }


        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AnimationModuleType
    {
        EyeBlinker,
        LipSyncer,
        MotionBehavior,
        JointTransformer,
    }
}
