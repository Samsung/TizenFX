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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.Scene3D;
using Tizen.NUI;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class BlendShapePlayer
    {
        private Dictionary<AnimationModuleType, AnimationModule> animationModules = new Dictionary<AnimationModuleType, AnimationModule>();

        private EyeBlinker blinker;
        private AsyncLipSyncer lipSyncer;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapePlayer()
        {
            blinker = new EyeBlinker();
            lipSyncer = new AsyncLipSyncer();

            animationModules.Add(AnimationModuleType.EyeBlinker, blinker);
            animationModules.Add(AnimationModuleType.LipSyncer, lipSyncer);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AsyncLipSyncer LipSyncer => lipSyncer;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBlinkAnimation(Animation blinkerAnimation)
        {
            animationModules[AnimationModuleType.EyeBlinker].Init(blinkerAnimation);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLipSyncAnimation(Animation lipsyncAnimation)
        {
            animationModules[AnimationModuleType.LipSyncer].Init(lipsyncAnimation);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimationModule GetAnimationModule(AnimationModuleType type)
        {
            return animationModules[type];
        }

        /// <summary>
        /// Start eye blink animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartEyeBlink()
        {
            animationModules[AnimationModuleType.EyeBlinker]?.Play(null);
        }

        /// <summary>
        /// Stop eye blink animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopEyeBlink()
        {
            animationModules[AnimationModuleType.EyeBlinker]?.Stop();
        }

        /// <summary>
        /// Play synchronization avatar lip based on the voice file(byte[])
        /// </summary>
        /// <param name="audio">byte array of voice</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PlayLipSync(byte[] audio)
        {
            if (animationModules[AnimationModuleType.LipSyncer] == null)
            {
                Log.Error(LogTag, $"error : avatarLipSync is null");
                return;
            }
            var lipData = new LipSyncData();

            lipData.AudioFile = new byte[audio.Length];
            Buffer.BlockCopy(audio, 0, lipData.AudioFile, 0, audio.Length);
            animationModules[AnimationModuleType.LipSyncer].Play(lipData);
        }

        /// <summary>
        /// Play synchronization avatar lip based on the voice file(byte[])
        /// </summary>
        /// <param name="audio">byte array of voice</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PlayLipSync(byte[] audio, int sampleRate)
        {
            if (animationModules[AnimationModuleType.LipSyncer] == null)
            {
                Log.Error(LogTag, $"error : avatarLipSync is null");
                return;
            }
            var lipData = new LipSyncData();

            lipData.AudioFile = new byte[audio.Length];
            Buffer.BlockCopy(audio, 0, lipData.AudioFile, 0, audio.Length);
            lipData.SampleRate = sampleRate;
            animationModules[AnimationModuleType.LipSyncer].Play(lipData);
        }

        /// <summary>
        /// Pause lip synchronization
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseLipSync()
        {
            if (animationModules[AnimationModuleType.LipSyncer] == null)
            {
                Log.Error(LogTag, $"error : avatarLipSync is null");
                return;
            }
            animationModules[AnimationModuleType.LipSyncer].Pause();
        }

        /// <summary>
        /// Stop lip synchronization
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopLipSync()
        {
            if (animationModules[AnimationModuleType.LipSyncer] == null)
            {
                Log.Error(LogTag, $"error : avatarLipSync is null");
                return;
            }
            animationModules[AnimationModuleType.LipSyncer].Stop();
        }

        internal void DestroyAnimations()
        {
            foreach ( var animationModule in animationModules.Values )
            {
                animationModule.Destroy();
            }
        }
    }
}
