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
using Tizen.NUI;
using Tizen.NUI.Scene3D;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class LipSyncer
    {
        private Animation lipAnimation = null;

        private VowelConverter vowelConverter;
        private AudioPlayer audioPlayer;
        private event Func<AnimationKeyFrame, bool, Animation> TheEvent;

        internal Func<AnimationKeyFrame, bool, Animation> CreatedKeyFrameAnimation;

        //Mic
        private Queue<string[]> vowelPools = new Queue<string[]>();
        private string prevVowel = "sil";

        internal LipSyncer()
        {
            vowelConverter = new VowelConverter();
            audioPlayer = new AudioPlayer();
        }

        internal AudioPlayer AudioPlayer { get { return audioPlayer; } }

        public void SetLipAnimation(Animation lipAnimation)
        {
            this.lipAnimation = lipAnimation;
        }

        public void PlayAudio(byte[] audio, int sampleRate)
        {
            if (audio != null)
            {
                PlayLipSync(audio, sampleRate);
            }
        }

        public void Stop()
        {
            StopLipSync();
        }

        public void Pause()
        {
            PauseLipSync();
        }

        public void Destroy()
        {
            DestroyLipAnimation();
        }

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

        protected void PlayLipAnimation()
        {
            if (lipAnimation == null)
            {
                Log.Error(LogTag, "Current Lip Animation is null");
            }
            lipAnimation?.Play();
        }

        protected void OnLipAnimationFinished(object sender, EventArgs e)
        {
        }

        private void PlayLipSync(byte[] audio)
        {
            if (audio == null)
            {
                Tizen.Log.Error(LogTag, "audi data is null");
                return;
            }
            DestroyLipAnimation();

            var lipKeyframes = CreateKeyFrame(audio, CurrentAudioOptions.SampleRate);
            if (lipKeyframes != null)
            {
                var lipAnimation = CreatedKeyFrameAnimation?.Invoke(lipKeyframes, false);

                if (lipAnimation != null)
                {
                    ResetLipAnimation(lipAnimation);
                    PlayLipAnimation();
                    audioPlayer.Play(audio);
                }
                else
                {
                    Tizen.Log.Error(LogTag, "lipAnimation is null");
                }
            }
            else
            {
                Tizen.Log.Error(LogTag, "lipKeyframes is null");
            }
        }

        private void PlayLipSync(byte[] audio, int sampleRate)
        {
            DestroyLipAnimation();
            var lipKeyFrames = CreateKeyFrame(audio, sampleRate);
            var lipAnimation = CreatedKeyFrameAnimation?.Invoke(lipKeyFrames, false);
            if (lipAnimation != null)
            {
                ResetLipAnimation(lipAnimation);
                PlayLipAnimation();
            }
            audioPlayer.Play(audio, sampleRate);
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
        }

        private void StopLipSync()
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
            audioPlayer.Stop();
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

        private void DestroyLipAnimation()
        {
            if (lipAnimation != null)
            {
                lipAnimation.Stop();
                lipAnimation.Dispose();
                lipAnimation = null;
            }
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

                var lipKeyFrames = vowelConverter?.CreateKeyFrames(newVowels, sampleRate, true);
                var lipAnimation = CreatedKeyFrameAnimation?.Invoke(lipKeyFrames, true);

                return lipAnimation;
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
            string[] vowels = vowelConverter?.PredictVowels(audioData);
            return vowels;
        }

        private void AttachPreviousVowel(in string[] vowels, out string[] newVowels)
        {
            newVowels = new string[vowels.Length + 1];
            newVowels[0] = prevVowel;
            Array.Copy(vowels, 0, newVowels, 1, vowels.Length);
            prevVowel = vowels[vowels.Length - 1];
        }

        private AnimationKeyFrame CreateKeyFrame(byte[] audio, int sampleRate)
        {
            var keyFrames = vowelConverter?.CreateKeyFrames(audio, sampleRate);
            if (keyFrames == null)
            {
                Log.Error(LogTag, $"Failed to initialize KeyFrames");
            }

            return keyFrames;
        }


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
