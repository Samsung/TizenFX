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
using Tizen.NUI;
using Tizen.NUI.Scene3D;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class LipSyncer : AnimationModule
    {
        private Avatar avatar;
        private Animation lipAnimation = null;

        //private VowelConverter vowelConverter;
        private AudioPlayer audioPlayer;

        //Mic
        private Queue<string[]> vowelPools = new Queue<string[]>();
        private string prevVowel = "sil";

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal LipSyncer()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AudioPlayer AudioPlayer { get { return audioPlayer; } }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Init(Animation lipAnimation)
        {
            this.lipAnimation = lipAnimation;
            //vowelConverter = new VowelConverter();
            audioPlayer = new AudioPlayer();

            CurrentMotionState = AvatarMotionState.Ready;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Play(IAnimationModuleData data)
        {
            if (data is LipSyncData lipSyncData)
            {
                if (lipSyncData.AudioFile != null)
                {
                    PlayLipSync(lipSyncData.AudioFile, lipSyncData.SampleRate);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Stop()
        {
            StopLipSync();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Pause()
        {
            PauseLipSync();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Destroy()
        {
            DestroyLipAnimation();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Animation CreateAsyncLipAnimation(byte[] buffer, int sampleRate)
        {
            EnqueueVowels(buffer, false);
            return CreateLipAnimationByVowelsQueue(sampleRate);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //TODO : lipAnimation 자체를 Animator안에서 생성하고 관리될 수 있게 수정.
        protected void ResetLipAnimation(Animation lipAnimation)
        {
            DestroyLipAnimation();
            this.lipAnimation = lipAnimation;
            if (this.lipAnimation != null)
            {
                this.lipAnimation.Finished += OnLipAnimationFinished;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void PlayLipAnimation()
        {
            if (lipAnimation == null)
            {
                Log.Error(LogTag, "Current Lip Animation is null");
            }
            lipAnimation?.Play();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnLipAnimationFinished(object sender, EventArgs e)
        {
            CurrentMotionState = AvatarMotionState.Stopped;
        }

        private void PlayLipSync(byte[] audio)
        {
            if (audio == null)
            {
                Tizen.Log.Error(LogTag, "audi data is null");
                return;
            }

            DestroyLipAnimation();
            var lipAnimation = CreateLipAnimation(audio, CurrentAudioOptions.SampleRate);
            if (lipAnimation != null)
            {
                ResetLipAnimation(lipAnimation);
                PlayLipAnimation();
            }
            else
            {

                Tizen.Log.Error(LogTag, "lipAnimation is null");
            }
            audioPlayer.Play(audio);
            CurrentMotionState = AvatarMotionState.Playing;
        }

        private void PlayLipSync(byte[] audio, int sampleRate)
        {
            DestroyLipAnimation();
            var lipAnimation = CreateLipAnimation(audio, sampleRate);
            if (lipAnimation != null)
            {
                ResetLipAnimation(lipAnimation);
                PlayLipAnimation();
            }
            audioPlayer.Play(audio, sampleRate);
            CurrentMotionState = AvatarMotionState.Playing;
        }

        private void PlayLipSync(string path)
        {
            var bytes = Utils.ReadAllBytes(path);
            if (bytes != null)
            {
                PlayLipSync(bytes);
            }
            else
            {
                Log.Error(LogTag, "Failed to load audio file");
            }
        }

        private void PauseLipSync()
        {
            PauseLipAnimation();
            audioPlayer.Pause();
            CurrentMotionState = AvatarMotionState.Paused;
        }

        private void StopLipSync()
        {
            StopLipAnimation();
            audioPlayer.Stop();
            CurrentMotionState = AvatarMotionState.Stopped;
        }

        private void PauseLipAnimation()
        {
            if (lipAnimation != null)
            {
                lipAnimation?.Pause();
            }
            else
            {
                Log.Error(LogTag, "Current Lip Animation is null");
            }
        }

        private void StopLipAnimation()
        {
            if (lipAnimation != null)
            {
                DestroyLipAnimation();

                var lipAnimation = ResetLipAnimation();
                if (lipAnimation != null)
                {
                    ResetLipAnimation(lipAnimation);
                    PlayLipAnimation();
                }
                else
                {
                    Log.Error(LogTag, "Current Lip Animation is null");
                }
            }
            else
            {
                Log.Error(LogTag, "Current Lip Animation is null");
            }
        }

        private void DestroyLipAnimation()
        {
            if (lipAnimation != null)
            {
                lipAnimation.Stop();
                lipAnimation.Dispose();
                lipAnimation = null;
            }
        }

        private Animation CreateLipAnimation(byte[] array, int sampleRate)
        {
            Animation lipKeyframes = null;// CreateKeyFrame(array, sampleRate);
            if (lipKeyframes != null)
            {

                return null;// CreateLipAnimation(lipKeyframes);
            }
            return null;
        }

        private void EnqueueVowels(byte[] buffer, bool deleteLast = false)
        {
            var vowels = PredictVowels(buffer);
            if (vowels != null)
            {
                vowelPools.Enqueue(vowels);
                if (deleteLast)
                {
                    var vowelList = new List<string>(vowels);
                    vowelList.RemoveAt(vowelList.Count - 1);
                    vowels = vowelList.ToArray();
                }
            }
        }

        private Animation CreateLipAnimationByVowelsQueue(int sampleRate = 0)
        {
            if (sampleRate == 0)
            {
                sampleRate = CurrentAudioOptions.SampleRate;
            }
            if (vowelPools.Count > 0)
            {
                AttachPreviousVowel(vowelPools.Dequeue(), out var newVowels);
                Log.Info(LogTag, $"vowelRecognition: {String.Join(", ", newVowels)}");

                //var lipKeyFrames = vowelConverter?.CreateKeyFrames(newVowels, sampleRate, true);
                return null;// CreateLipAnimation(lipKeyFrames, true);
            }
            return null;
        }

        private Animation ResetLipAnimation()
        {
            vowelPools.Clear();
            var newVowels = new string[1];
            newVowels[0] = prevVowel = "sil";
            vowelPools.Enqueue(newVowels);
            return CreateLipAnimationByVowelsQueue();
        }

        private string[] PredictVowels(byte[] audioData)
        {
            string[] vowels = null;// vowelConverter?.PredictVowels(audioData);
            return vowels;
        }

        private void AttachPreviousVowel(in string[] vowels, out string[] newVowels)
        {
            newVowels = new string[vowels.Length + 1];
            newVowels[0] = prevVowel;
            Array.Copy(vowels, 0, newVowels, 1, vowels.Length);
            prevVowel = vowels[vowels.Length - 1];
        }

        /*
        private AnimationKeyFrame CreateKeyFrame(byte[] audio, int sampleRate)
        {
            var keyFrames = vowelConverter?.CreateKeyFrames(audio, sampleRate);
            if (keyFrames == null)
            {
                Log.Error(LogTag, $"Failed to initialize KeyFrames");
            }

            return keyFrames;
        }

        private Animation CreateLipAnimation(AnimationKeyFrame animationKeyFrames, bool isMic = false)
        {
            var animationTime = (int)(animationKeyFrames.AnimationTime * 1000f);
            var lipAnimation = new Animation(animationTime);

            var motionData = new MotionData(animationTime);
            for (var i = 0; i < animationKeyFrames.NodeNames.Length; i++)
            {
                var nodeName = animationKeyFrames.NodeNames[i];
                for (var j = 0; j < animationKeyFrames.BlendShapeCounts[i]; j++)
                {
                    var blendShapeIndex = new BlendShapeIndex(new PropertyKey(nodeName), new PropertyKey(j));
                    var keyFrameList = animationKeyFrames.GetKeyFrames(nodeName, j);
                    if (keyFrameList.Count == 0)
                    {
                        continue;
                    }

                    var keyFrames = new KeyFrames();
                    CreateKeyTimeFrames(ref keyFrames, keyFrameList, isMic);

                    motionData.Add(blendShapeIndex, new MotionValue(keyFrames));
                    lipAnimation = avatar.GenerateMotionDataAnimation(motionData);
                }
            }
            return lipAnimation;
        }
        private KeyFrames CreateKeyTimeFrames(ref KeyFrames keyFrames, List<KeyFrame> keyFrameList, bool isMic = false)
        {
            foreach (var key in keyFrameList)
            {
                keyFrames.Add(key.time, key.value);
            }
            if (!isMic) keyFrames.Add(1.0f, 0.0f);

            return keyFrames;
        }
        */

        internal void OnRecordBufferChanged(byte[] recordBuffer, int sampleRate)
        {
            EnqueueVowels(recordBuffer);
        }

        internal void OnRecodingTick()
        {
            var lipAnimation = CreateLipAnimationByVowelsQueue();
            if (lipAnimation != null)
            {
                ResetLipAnimation(lipAnimation);
                PlayLipAnimation();
            }
            else
            {
                Log.Error(LogTag, "Current Lip Animation is null");
            }
        }
    }
}
