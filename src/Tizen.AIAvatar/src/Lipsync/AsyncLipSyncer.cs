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
using Tizen.NUI;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AsyncLipSyncer
    {
        private readonly uint AsyncPlayTime = 160;
        private Queue<Animation> lipAnimations;
        private Queue<byte[]> lipAudios;
        private Timer asyncVowelTimer;

        private bool isAsyncInit = false;
        private bool isFinishAsyncLip = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AsyncLipSyncer()
        {

        }

        internal int SampleRate { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool IsAsyncInit { get=>isAsyncInit; set=>isAsyncInit = value; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetFinishAsyncLip(bool finished)
        {
            isFinishAsyncLip = finished;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected new void OnLipAnimationFinished(object sender, EventArgs e)
        {
            if (!isAsyncInit)
            {
                //TODO : State is Stop
            }
            else
            {
                Tizen.Log.Error(LogTag, "OnLipAnimationFinished---------------c");
                //Async State
                if (isFinishAsyncLip && lipAnimations.Count == 0)
                {
                    Tizen.Log.Error(LogTag, "Finish vowel lip sync");

                    
                    //Audio Player is Stop, AudioPlayer.Stop();
                    //TODO : State is Stop
                    DestroyVowelTimer();
                    isAsyncInit = false;
                }
            }
        }

        internal void InitAsyncLipsync()
        {
            if (lipAnimations == null)
            {
                lipAnimations = new Queue<Animation>();
            }
            else
            {
                lipAnimations.Clear();
            }

            if (lipAudios == null)
            {
                lipAudios = new Queue<byte[]>();
            }
            else
            {
                lipAudios.Clear();
            }
        }

        private void EnqueueVowels(byte[] buffer, bool deleteLast = false)
        {
            /*
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
            }*/
        }

        internal Animation CreateAsyncLipAnimation(byte[] buffer, int sampleRate)
        {
            EnqueueVowels(buffer, false);
            return null;
            //return CreateLipAnimationByVowelsQueue(sampleRate);
        }

        internal void EnqueueAnimation(byte[] recordBuffer, int sampleRate, int audioLength)
        {
            var createdAni = CreateAsyncLipAnimation(recordBuffer, sampleRate);
            if (createdAni != null)
            {
                lipAnimations.Enqueue(createdAni);
            }

            //Use Audio Full File
            ///var createdAni = avatarLipSyncer.CreateLipAnimation(recordBuffer, sampleRate);
            //lipAnimations.Enqueue(createdAni);

            var currentAudioBuffer = new byte[audioLength];
            Buffer.BlockCopy(recordBuffer, 0, currentAudioBuffer, 0, audioLength);

            lipAudios.Enqueue(currentAudioBuffer);
        }

        internal bool PlayAsyncLip(int sampleRate, bool isFinishAsyncLip)
        {
            try
            {
                if (lipAudios.Count <= 0 && lipAnimations.Count <= 0)
                {
                    Tizen.Log.Info(LogTag, "Return lipaudio 0");
                    if (isFinishAsyncLip)
                    {
                        Tizen.Log.Info(LogTag, "Finish Async lipsync");
                        return false;
                    }
                    return true;
                }
                Tizen.Log.Info(LogTag, "Async timer tick lipAudios : " + lipAudios.Count);
                Tizen.Log.Info(LogTag, "Async timer tick lipAnimations : " + lipAnimations.Count);

                var lipAnimation = lipAnimations.Dequeue();
                lipAnimation.Finished += OnLipAnimationFinished;

                //ResetLipAnimation(lipAnimation);
                //PlayLipAnimation();
                var audioBuffer = lipAudios.Dequeue();
                
                //Audio Playe rAsync Play
                //AudioPlayer.PlayAsync(audioBuffer, sampleRate);
                return true;

            }
            catch (Exception ex)
            {
                Log.Error(LogTag, $"---Log Tick : {ex.StackTrace}");

                return false;
            }
        }

        internal void StartAsyncLipPlayTimer()
        {
            if (asyncVowelTimer == null)
            {
                Tizen.Log.Info(LogTag, "Start Async");
                asyncVowelTimer = new Timer(AsyncPlayTime);
                asyncVowelTimer.Tick += OnAsyncVowelTick;
                asyncVowelTimer.Start();
            }
            return;
        }

        private void DestroyVowelTimer()
        {
            if (asyncVowelTimer != null)
            {

                asyncVowelTimer.Tick -= OnAsyncVowelTick;
                asyncVowelTimer.Stop();
                asyncVowelTimer.Dispose();
                asyncVowelTimer = null;
            }
        }

        private bool OnAsyncVowelTick(object source, Tizen.NUI.Timer.TickEventArgs e)
        {
            return PlayAsyncLip(SampleRate, isFinishAsyncLip);
        }
    }
}
