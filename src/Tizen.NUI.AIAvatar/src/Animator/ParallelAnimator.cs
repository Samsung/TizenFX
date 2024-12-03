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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tizen.NUI;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The ParallelAnimator class extends the AnimatorBase class and provides methods to play, stop, and pause animations in parallel.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ParallelAnimator : AnimatorBase
    {
        /// <summary>
        /// Plays the animation at the specified index.
        /// </summary>
        /// <param name="index">The index of the animation to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Play(uint index)
        {
            Play(new List<uint> { index });
        }

        /// <summary>
        /// Stops all playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Stop()
        {
            Stop(null);
        }

        /// <summary>
        /// Pauses all playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Pause()
        {
            Pause(null);
        }

        /// <summary>
        /// Plays the specified animations in parallel.
        /// </summary>
        /// <param name="indexes">A list of indices of the animations to play. If null, all animations will be played.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play(IEnumerable<uint> indexes = null)
        {
            string names = string.Join(", ", indexes?.Select(index => GetNameByIndex(animations[index].ID)).Where(name => !string.IsNullOrEmpty(name)) ?? Enumerable.Empty<string>());

            if (indexes == null)
            {
                foreach (var animation in animations.Values)
                {
                    animation.Finished += OnAnimationFinished;
                    animation.Play();
                }
            }
            else
            {
                foreach (var index in indexes)
                {
                    if (animations.TryGetValue(index, out var animation))
                    {
                        animation.Finished += OnAnimationFinished;
                        animation.Play();
                    }
                }
            }

            ChangeAnimatorState(AnimatorState.Playing, names);
        }

        /// <summary>
        /// Stops the specified animations or all playing animations if no indices are provided.
        /// </summary>
        /// <param name="indexes">A list of indices of the animations to stop. If null, all playing animations will be stopped.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop(IEnumerable<uint> indexes = null)
        {
            int count = 0;
            string names = string.Join(", ", indexes?.Select(index => GetNameByIndex(animations[index].ID)).Where(name => !string.IsNullOrEmpty(name)) ?? Enumerable.Empty<string>());

            if (indexes == null)
            {
                foreach (var animation in animations.Values)
                {
                    if (animation.State == Animation.States.Playing)
                    {
                        animation.Finished -= OnAnimationFinished;
                        animation.Stop();
                        count++;
                    }
                }
            }
            else
            {
                foreach (var index in indexes)
                {
                    if (animations.TryGetValue(index, out var animation))
                    {
                        if (animation.State == Animation.States.Playing)
                        {
                            animation.Finished -= OnAnimationFinished;
                            animation.Stop();
                            count++;
                        }
                    }
                }
            }

            if(count > 0) ChangeAnimatorState(AnimatorState.Stopped, names);
        }

        /// <summary>
        /// Pauses the specified animations or all playing animations if no indices are provided.
        /// </summary>
        /// <param name="indexes">A list of indices of the animations to pause. If null, all playing animations will be paused.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause(IEnumerable<uint> indexes = null)
        {
            int count = 0;
            string names = string.Join(", ", indexes?.Select(index => GetNameByIndex(animations[index].ID)).Where(name => !string.IsNullOrEmpty(name)) ?? Enumerable.Empty<string>());

            if (indexes == null)
            {
                foreach (var animation in animations.Values)
                {
                    if (animation.State == Animation.States.Playing)
                    {
                        animation.Finished -= OnAnimationFinished;
                        animation.Pause();
                        count++;
                    }
                }
            }
            else
            {
                foreach (var index in indexes)
                {
                    if (animations.TryGetValue(index, out var animation))
                    {
                        if (animation.State == Animation.States.Playing)
                        {
                            animation.Finished -= OnAnimationFinished;
                            animation.Pause();
                            count++;
                        }
                    }
                }
            }

            if(count > 0) ChangeAnimatorState(AnimatorState.Paused, names);
        }
    }
}
