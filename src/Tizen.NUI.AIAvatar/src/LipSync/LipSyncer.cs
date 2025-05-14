/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// LipSyncer class manages the synchronization of an avatar's mouth movements with audio input.
    /// It handles the creation, enqueuing, playing, pausing, and stopping of animations based on lip-sync data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LipSyncer
    {
        private Model avatar;
        private Animation currentAnimation;
        private Animation silenceAnimation;
        private Queue<Animation> queuedAnimations = new Queue<Animation>();
        private Timer animationTimer;

        private readonly AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);
        private readonly LipSyncTransformer lipSyncTransformer = new LipSyncTransformer();
        private AnimatorState currentAnimatorState = AnimatorState.Unavailable;

        private string prevVowel = "sil";

        /// <summary>
        /// Event triggered when the state of the animator changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AnimatorChangedEventArgs> AnimatorStateChanged;

        /// <summary>
        /// Initializes a new instance of the LipSyncer class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipSyncer()
        {
          
        }

        /// <summary>
        /// Initializes the LipSyncer with the given avatar and viseme definition path.
        /// </summary>
        /// <param name="avatar">The avatar to apply lip-sync animations to.</param>
        /// <param name="visemeDefinitionPath">The path to the viseme definition file.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Initialize(Model avatar, string visemeDefinitionPath)
        {
            this.avatar = avatar;
            lipSyncTransformer.Initialize(visemeDefinitionPath);
            silenceAnimation = GenerateAnimationFromVowels(new string[] { "sil", "sil" }, 0.5f);
        }

        /// <summary>
        /// Enqueues a lip-sync animation to be played later.
        /// </summary>
        /// <param name="lipAnimation">The animation to enqueue.</param>
        /// <param name="isAutoPlay">is auto play (default is true).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Enqueue(Animation lipAnimation, bool isAutoPlay = true)
        {
            queuedAnimations.Enqueue(lipAnimation);
            if (isAutoPlay)
            {
                Play();
            }
        }

        /// <summary>
        /// Generates an animation from a list of vowels.
        /// </summary>
        /// <param name="vowels">The list of vowels to generate the animation from.</param>
        /// <param name="stepTime">The time interval between each key frame (default is 0.08 seconds).</param>
        /// <param name="isStreaming">Indicates whether the animation is streaming (default is false).</param>
        /// <returns>The generated animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation GenerateAnimationFromVowels(string[] vowels, float stepTime = 0.08f, bool isStreaming = false)
        {
            if (isStreaming)
            {
                var vowelList = new List<string>(vowels);
                vowelList.Insert(0, prevVowel);
                prevVowel = vowelList[vowelList.Count - 1];
                vowels = vowelList.ToArray();
            }

            var lipData = lipSyncTransformer.TransformVowelsToLipData(vowels, stepTime, isStreaming);
            using var motionData = GenerateMotionFromLipData(lipData);
            var animation = avatar.GenerateMotionDataAnimation(motionData);
        
            return animation;
        }


        /// <summary>
        /// Plays the current animation or dequeues and plays the next animation if available.
        /// If no animations are queued, plays a silence animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play()
        {         
            if (animationTimer == null)
            {
                PlayNextAnimation(null, null);
                return;
            }

            if (animationTimer != null && !animationTimer.IsRunning())
            {
                PlayNextAnimation(null, null);
            }
        }

        /// <summary>
        /// Pauses the current animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
            if (currentAnimation != null)
            {
                currentAnimation.Pause();
                CurrentAnimatorState = AnimatorState.Paused;
            }
        }

        /// <summary>
        /// Stops and disposes of the current animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            if (currentAnimation != null)
            {
                currentAnimation.Stop();
                currentAnimation.Dispose();
                currentAnimation = null;
                
                queuedAnimations.Clear();
                animationTimer.Stop();
                animationTimer.Dispose();

                CurrentAnimatorState = AnimatorState.Stopped;
            }
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

                AnimatorStateChanged?.Invoke(this, new AnimatorChangedEventArgs(preState, currentAnimatorState));
            }
        }

        private bool PlayNextAnimation(object source, Timer.TickEventArgs e)
        {
            // 현재 애니메이션을 정지 및 해제
            currentAnimation?.Stop();
            currentAnimation?.Dispose();
            currentAnimation = null;

            if (queuedAnimations.Count > 0)
            {
                currentAnimation = queuedAnimations.Dequeue();
                currentAnimation.Play();
                CurrentAnimatorState = AnimatorState.Playing;

                // 현재 애니메이션의 Duration을 기준으로 타이머 설정
                animationTimer = new Timer((uint)currentAnimation.Duration - 1); // 밀리초 단위
                animationTimer.Tick += PlayNextAnimation;
                animationTimer.Start();
            }
            else
            {
                prevVowel = "sil";
                silenceAnimation.Play();
                CurrentAnimatorState = AnimatorState.AnimationFinished;
            }

            return false;
        }


        private void OnAnimationFinished(object sender, EventArgs e)
        {
            currentAnimation.Dispose();
            currentAnimation = null;
            Play();
        }

        private MotionData GenerateMotionFromLipData(LipData animationKeyFrames)
        {
            int animationTime = (int)(animationKeyFrames.Duration * 1000f);

            var motionData = new MotionData(animationTime);
            for (var i = 0; i < animationKeyFrames.NodeNames.Length; i++)
            {
                string nodeName = animationKeyFrames.NodeNames[i];
                for (var j = 0; j < animationKeyFrames.BlendShapeCounts[i]; j++)
                {
                    using var modelNodeID = new PropertyKey(nodeName);
                    using var blendShapeID = new PropertyKey(j);
                    var blendShapeIndex = new BlendShapeIndex(modelNodeID, blendShapeID);
                    var keyFrameList = animationKeyFrames.GetKeyFrames(nodeName, j);
                    if (keyFrameList.Count == 0)
                    {
                        continue;
                    }

                    var keyFrames = CreateKeyTimeFrames(keyFrameList);

                    motionData.Add(blendShapeIndex, new MotionValue(keyFrames));
                }
            }

            return motionData;
        }

        private KeyFrames CreateKeyTimeFrames(List<KeyFrame> keyFrameList)
        {
            var keyFrames = new KeyFrames();

            foreach (var key in keyFrameList)
            {
                keyFrames.Add(key.time, key.value, alphaFunction);
            }

            return keyFrames;
        }
    }
}
