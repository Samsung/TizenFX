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

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The base class for all animator implementations. Provides basic functionality for adding, playing, stopping, pausing, and removing animations.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class AnimatorBase : IAnimator
    {
        private bool disposed = false;
        private string animationName = "";
        private AnimatorState currentAnimatorState = AnimatorState.Unavailable;


        private Dictionary<string, uint> nameToIndex = new Dictionary<string, uint>();
        private Dictionary<uint, string> indexToName = new Dictionary<uint, string>();

        /// <summary>
        /// A dictionary to store animations. Each animation has a unique ID of type uint, which can be used as a key to store and retrieve the animations.
        /// </summary>
        protected Dictionary<uint, Animation> animations = new Dictionary<uint, Animation>();


        /// <summary>
        /// Event triggered when the state of the animator changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AnimatorChangedEventArgs> AnimatorStateChanged;

        /// <summary>
        /// Initializes a new instance of the AnimatorBase class.
        /// </summary>
        protected AnimatorBase() { }

        /// <summary>
        /// Adds an animation to the animator.
        /// </summary>
        /// <param name="animation">The animation to add.</param>
        /// <param name="name">The name of the animation.</param>
        /// <returns>The index of the added animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Add(Animation animation, string name)
        {
            if (animation == null)
            {
                throw new ArgumentNullException(nameof(animation));
            }

            if (!nameToIndex.ContainsKey(name))
            {
                uint index = animation.ID;
                animations.Add(index, animation);
                nameToIndex.Add(name, index);
                indexToName.Add(index, name);

                return (int)index;
            }
            else
            {
                throw new ArgumentException("Duplicate name: " + name);
            }

            
        }

        /// <summary>
        /// Gets the number of animations currently added to the animator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count
        {
            get
            {
                return animations.Count;
            }
        }

        /// <summary>
        /// Plays an animation by its index.
        /// </summary>
        /// <param name="index">The index of the animation to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Play(uint index);

        /// <summary>
        /// Plays an animation by its name.
        /// </summary>
        /// <param name="name">The name of the animation to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play(string name)
        {
            if (nameToIndex.TryGetValue(name, out uint index))
            {
                Play(index);
            }
            else
            {
                throw new ArgumentException($"Animation with name {name} does not exist.");
            }
        }

        /// <summary>
        /// Stops all currently playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Stop();

        /// <summary>
        /// Pauses all currently playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Pause();

        /// <summary>
        /// Removes an animation by its index.
        /// </summary>
        /// <param name="index">The index of the animation to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(uint index)
        {
            if (!animations.ContainsKey(index))
            {
                throw new ArgumentException($"Animation with index {index} does not exist.");
            }

            Stop();
            animations.Remove(index);
            nameToIndex.Remove(indexToName[index]);
            indexToName.Remove(index);
        }

        /// <summary>
        /// Removes an animation by its name.
        /// </summary>
        /// <param name="name">The name of the animation to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(string name)
        {
            uint index = GetIndexByName(name);

            animations.Remove(index);
            nameToIndex.Remove(name);
            indexToName.Remove(index);
        }

        /// <summary>
        /// Gets the index of an animation by its name.
        /// </summary>
        /// <param name="name">The name of the animation.</param>
        /// <returns>The index of the animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetIndexByName(string name)
        {
            if (!nameToIndex.TryGetValue(name, out uint index))
            {
                throw new ArgumentException($"Animation with name {name} does not exist.");
            }
            return index;
        }

        /// <summary>
        /// Gets the name of an animation by its index.
        /// </summary>
        /// <param name="index">The index of the animation.</param>
        /// <returns>The name of the animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetNameByIndex(uint index)
        {
            if (!indexToName.TryGetValue(index, out string name))
            {
                throw new ArgumentException($"Animation with index {index} does not exist.");
            }
            return name;
        }

        /// <summary>
        /// Gets the key element at the specified index in the animations dictionary.
        /// </summary>
        /// <param name="index">The zero-based index of the key element to retrieve.</param>
        /// <returns>The key element at the specified index.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetKeyElementAt(int index)
        {
            return animations.Keys.ElementAt(index);
        }

        /// <summary>
        /// Gets or sets the current state of the animator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatorState CurrentAnimatorState
        {
            get => currentAnimatorState;
            protected set
            {
                if (currentAnimatorState != AnimatorState.AnimationFinished && currentAnimatorState == value) return;

                var preState = currentAnimatorState;
                currentAnimatorState = value;

                var message = animationName;
                AnimatorStateChanged?.Invoke(this, new AnimatorChangedEventArgs(preState, currentAnimatorState, message));
                animationName = "";
            }
        }

        /// <summary>
        /// Changes the state of the animator.
        /// </summary>
        /// <param name="newState">The new state of the animator.</param>
        /// <param name="animationName">The name of the animation associated with the state change.</param>
        protected void ChangeAnimatorState(AnimatorState newState, string animationName)
        {
            this.animationName = animationName;
            CurrentAnimatorState = newState;
        }

        /// <summary>
        /// Handles the Finished event of an animation.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        protected void OnAnimationFinished(object sender, EventArgs e)
        {
            if (!(sender is Animation anim)) return;

            anim.Finished -= OnAnimationFinished;
            foreach (var animation in animations.Values)
            {
                if (animation.State == Animation.States.Playing)
                {
                    ChangeAnimatorState(AnimatorState.AnimationFinished, indexToName[anim.ID]);
                    return;
                }
            }

            ChangeAnimatorState(AnimatorState.Stopped, indexToName[anim.ID]);
        }

        /// <summary>
        /// Releases all resources used by the AnimatorBase class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the AnimatorBase class and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Managed resources cleanup
                    if (animations != null)
                    {
                        foreach (var animation in animations.Values)
                        {
                            animation.Dispose();
                        }
                        animations.Clear();
                        animations = null;
                    }
                }
                // Unmanaged resources cleanup

                disposed = true;
            }
        }
    }
}
