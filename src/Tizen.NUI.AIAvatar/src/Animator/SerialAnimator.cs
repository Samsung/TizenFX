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
using Tizen.Applications;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Represents an animator that plays animations in a serial manner.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SerialAnimator : AnimatorBase
    {
        private uint playIndex;

        private void PlayMainThreadAnimation()
        {
            animations[playIndex].Finished += OnAnimationFinished;
            animations[playIndex].Play();

            ChangeAnimatorState(AnimatorState.Playing, GetNameByIndex(playIndex));
        }

        /// <summary>
        /// Plays the animation corresponding to the specified index.
        /// </summary>
        /// <param name="index">The index of the animation to play.</param>
        /// <exception cref="ArgumentException">Thrown when the specified animation index does not exist.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Play(uint index)
        {
            Stop();

            if (!animations.ContainsKey(index))
            {
                throw new ArgumentException($"Animation with index {index} does not exist.");
            }

            playIndex = index;
            CoreApplication.Post(PlayMainThreadAnimation);
        }

        /// <summary>
        /// Stops the currently playing animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Stop()
        {
            if (animations.ContainsKey(playIndex))
            {
                animations[playIndex].Finished -= OnAnimationFinished;
                animations[playIndex].Stop();

                ChangeAnimatorState(AnimatorState.Stopped, GetNameByIndex(playIndex));
            }
        }

        /// <summary>
        /// Pauses the currently playing animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Pause()
        {
            if (animations.ContainsKey(playIndex))
            {
                animations[playIndex].Finished -= OnAnimationFinished;
                animations[playIndex].Pause();

                ChangeAnimatorState(AnimatorState.Paused, GetNameByIndex(playIndex));
            }
        }
    }
}
