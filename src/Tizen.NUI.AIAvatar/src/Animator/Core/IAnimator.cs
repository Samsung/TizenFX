
using System;
using System.ComponentModel;
using Tizen.NUI;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Represents an animator that can play and manage a collection of animations.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAnimator : IDisposable
    {
        /// <summary>
        /// Adds an animation to the animator with a given name.
        /// </summary>
        /// <param name="animation">The animation to add.</param>
        /// <param name="name">The name to associate with the animation.</param>
        /// <returns>The index of the added animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int Add(Animation animation, string name);

        /// <summary>
        /// Gets the number of animations currently managed by the animator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int Count { get; }

        /// <summary>
        /// Plays the animation at the specified index.
        /// </summary>
        /// <param name="index">The index of the animation to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Play(uint index);

        /// <summary>
        /// Plays the animation with the specified name.
        /// </summary>
        /// <param name="name">The name of the animation to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Play(string name);

        /// <summary>
        /// Stops all currently playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Stop();

        /// <summary>
        /// Pauses all currently playing animations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Pause();

        /// <summary>
        /// Removes the animation at the specified index.
        /// </summary>
        /// <param name="index">The index of the animation to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Remove(uint index);

        /// <summary>
        /// Removes the animation with the specified name.
        /// </summary>
        /// <param name="name">The name of the animation to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Remove(string name);

        /// <summary>
        /// Gets the index of the animation with the specified name.
        /// </summary>
        /// <param name="name">The name of the animation to find.</param>
        /// <returns>The index of the animation with the specified name.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint GetIndexByName(string name);

        /// <summary>
        /// Gets the name of the animation at the specified index.
        /// </summary>
        /// <param name="index">The index of the animation to find.</param>
        /// <returns>The name of the animation at the specified index.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string GetNameByIndex(uint index);

        /// <summary>
        /// Gets the key element at the specified index in the animator's collection.
        /// </summary>
        /// <param name="index">The index of the key element to retrieve.</param>
        /// <returns>The key element at the specified index.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint GetKeyElementAt(int index);

        /// <summary>
        /// Gets the current state of the animator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AnimatorState CurrentAnimatorState { get; }
    }
}
