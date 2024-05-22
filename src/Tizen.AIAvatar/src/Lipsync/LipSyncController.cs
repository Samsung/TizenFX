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

using System.Collections.Generic;
using System.ComponentModel;
using System;
using Tizen.Uix.Tts;

using static Tizen.AIAvatar.AIAvatar;
using Tizen.Multimedia;
using Tizen.NUI.Scene3D;
using Tizen.NUI;

namespace Tizen.AIAvatar
{
     /// <summary>
     /// A controller class used to manage lip sync functionality for avatars.
     /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LipSyncController : IDisposable
    {
        private TTSController ttsController;
        private AudioRecorder audioRecorder;
        private LipSyncer lipSyncer;

        private Avatar avatar;

        private event EventHandler ttsReadyFinished;
        private readonly Object ttsReadyFinishedLock = new Object();

        /// <summary>  
        /// Initializes a new instance of the <see cref="LipSyncController"/> class.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipSyncController(Avatar avatar)
        {
            this.avatar = avatar;

            audioRecorder = new AudioRecorder();
            lipSyncer = new LipSyncer();

            lipSyncer.CreatedKeyFrameAnimation += OnCreatedKeyFrameAnimation;
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

        private Animation OnCreatedKeyFrameAnimation(AnimationKeyFrame animationKeyFrame, bool isMic)
        {
            if (animationKeyFrame == null)
            {
                Tizen.Log.Error(LogTag, "animtionKeyFrame is null");
            }
            var lipAnimation = CreateLipAnimation(animationKeyFrame, isMic);
            return lipAnimation;
        }

        /// <summary>  
        /// Occurs when text-to-speech synthesis has finished and the audio data is ready to play.  
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TTSReadyFinished
        {
            add
            {
                lock (ttsReadyFinishedLock)
                {
                    ttsReadyFinished += value;
                }

            }

            remove
            {
                lock (ttsReadyFinishedLock)
                {
                    if (ttsReadyFinished == null)
                    {
                        Log.Error(LogTag, "ttsReadyFinished is null");
                        return;
                    }
                    ttsReadyFinished -= value;
                }
            }
        }

        /// <summary>  
        /// Gets the current Text-To-Speech client associated with the Lip Sync Controller.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TtsClient CurrentTTSClient => ttsController?.TtsHandle;

        /// <summary>
        /// Initializes the Text-To-Speech system for use with the Lip Sync Controller.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitializeTTS()
        {
            if (ttsController == null)
            {
                try
                {
                    ttsController = new TTSController();
                    //TODO : LipSync Event Connect
                    ttsController.PreparedSyncText += OnPreparedSyncText;
                    ttsController.StoppedTTS += OnStoppedTTS;
                    ttsController.UpdatedBuffer += OnUpdatedBuffer;
                }
                catch (Exception e)
                {
                    Log.Error(LogTag, $"error :{e.Message}");
                    Log.Error(LogTag, $"{e.StackTrace}");
                }
            }
        }

        private void OnUpdatedBuffer(object sender, TTSControllerEventArgs e)
        {
            throw new NotImplementedException();
            if (lipSyncer != null)
            {
                Log.Error(LogTag, "OnTTSBufferChanged");
                /*
                lipSyncer.EnqueueAnimation(recordBuffer, sampleRate, audioLength);
                if (!isAsyncLipStarting)
                {
                    lipSyncer.StartAsyncLipPlayTimer();
                    isAsyncLipStarting = true;
                }*/
            }
            else
            {
                Log.Error(LogTag, "avatarLipSyncer is null");
            }
        }

        private void OnStoppedTTS(object sender, TTSControllerEventArgs e)
        {
            lipSyncer.Stop();
        }

        private void OnPreparedSyncText(object sender, TTSControllerEventArgs e)
        {
            var data = e.AudioData;
            var sampleRate = e.SampleRate;
            
            // Play Lipsync Animation by Audio
            lipSyncer.PlayAudio(data, sampleRate);
        }

        /// <summary>  
        /// Deinitializes the Text-To-Speech system for use with the Lip Sync Controller. 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeInitializeTTS()
        {
            if (ttsController != null)
            {
                try
                {
                    ttsController.DeinitTts();
                    ttsController = null;
                }
                catch (Exception e)
                {
                    Log.Error(LogTag, $"error :{e.Message}");
                    Log.Error(LogTag, $"{e.StackTrace}");
                }
            }
        }

        /// <summary>  
        /// Returns a list of supported voices for the Text-To-Speech system.  
        /// </summary>  
        /// <returns></returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<VoiceInfo> GetSupportedVoices()
        {
            return ttsController.GetSupportedVoices();
        }

        /// <summary>  
        /// Plays the given audio with LipSync and returns whether it was successful or not. 
        /// If the lip syncer is null, logs an error and returns false.
        /// The lipSyncer plays the audio using the provided byte array and sample rate.  
        /// </summary>  
        /// <param name="audio">The audio data to be played in a byte array format.</param>  
        /// <param name="sampleRate">The sampling rate of the audio data, default value is 24000 Hz.</param>
        public bool PlayLipSync(byte[] audio, int sampleRate = 24000)
        {
            if (lipSyncer == null)
            {
                Log.Error(LogTag, "lipSyncer is null");
                return false;
            }
            lipSyncer.PlayAudio(audio, sampleRate);

            return true;
        }

        /// <summary>  
        /// Plays the given audio with LipSync and returns whether it was successful or not. 
        /// If the lip syncer is null, logs an error and returns false.
        /// The lipSyncer plays the audio using the provided byte array and sample rate.  
        /// </summary>  
        /// <param name="audio">The audio data to be played in a byte array format.</param>  
        /// <param name="sampleRate">The sampling rate of the audio data, default value is 16000 Hz.</param>
        public bool PlayLipSync(string path, int sampleRate = 24000)
        {
            var audio = Utils.ReadAllBytes(path);
            if (audio == null)
            {
                Log.Error(LogTag, "audio data is null");
                return false;
            }
            lipSyncer.PlayAudio(audio, sampleRate);

            return true;
        }

        /// <summary>  
        /// Prepares the Text-To-Speech engine to synthesize speech from the provided text and voice info.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="voiceInfo">The voice info to use for converting the text into speech.</param>  
        /// <param name="ttsReadyFinishedCallback">An optional callback that will be invoked when the TTS process is complete.</param>  
        /// <returns><c>True</c> if preparation was successful, otherwise <c>False</c>.</returns> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PrepareTTS(string text, VoiceInfo voiceInfo, EventHandler ttsReadyFinishedCallback = null)
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }


            if (!ttsController.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsController.AddText(text, voiceInfo);
                ttsController.Prepare(ttsReadyFinishedCallback);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Prepares the Text-To-Speech engine to synthesize speech from the provided text and language code.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="lang">The two-letter ISO 639-1 language code to use for converting the text into speech (default is Korean - ko_KR).</param>  
        /// <param name="ttsReadyFinishedCallback">An optional callback that will be invoked when the TTS process is complete.</param>  
        /// <returns><c>True</c> if preparation was successful, otherwise <c>False</c>.</returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PrepareTTS(string text, string lang = "ko_KR", EventHandler ttsReadyFinishedCallback = null)
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsController.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsController.AddText(text, lang);
                ttsController.Prepare(ttsReadyFinishedCallback);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Plays the previously prepared Text-To-Speech audio data.  
        /// </summary>  
        /// <returns><c>True</c> if playback started successfully, otherwise <c>False</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PlayPreparedTTS()
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            return ttsController.PlayPreparedText();
        }

        /// <summary>  
        /// Converts the given text into speech using the specified voice info and plays the resulting audio immediately.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="voiceInfo">The voice info to use for converting the text into speech.</param>  
        /// <returns><c>True</c> if playback started successfully, otherwise <c>False</c>.</returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PlayTTS(string text, VoiceInfo voiceInfo)
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsController.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsController.AddText(text, voiceInfo);
                ttsController.Play();
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Converts the given text into speech using the specified language code and plays the resulting audio immediately.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="lang">The two-letter ISO 639-1 language code to use for converting the text into speech (default is Korean - ko_KR).</param>  
        /// <returns><c>True</c> if playback started successfully, otherwise <c>False</c>.</returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PlayTTS(string text, string lang = "ko_KR")
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsController.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsController.AddText(text, lang);
                ttsController.Play();
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Asynchronously converts the given text into speech using the specified voice info and plays the resulting audio once it's ready.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="voiceInfo">The voice info to use for converting the text into speech.</param>  
        /// <param name="ttsReadyFinishedCallback">An optional callback that will be invoked when the TTS process is complete.</param>  
        /// <returns><c>True</c> if asynchronous conversion was initiated successfully, otherwise <c>False</c>.</returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PlayTTSAsync(string text, VoiceInfo voiceInfo, EventHandler ttsReadyFinishedCallback = null)
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsController.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsController.AddText(text, voiceInfo);
                ttsController.PlayAsync(ttsReadyFinishedCallback);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Asynchronously converts the given text into speech using the specified language code and plays the resulting audio once it's ready.  
        /// </summary>  
        /// <param name="text">The text to convert into speech.</param>  
        /// <param name="lang">The two-letter ISO 639-1 language code to use for converting the text into speech (default is Korean - ko_KR).</param>  
        /// <param name="ttsReadyFinishedCallback">An optional callback that will be invoked when the TTS process is complete.</param>  
        /// <returns><c>True</c> if asynchronous conversion was initiated successfully, otherwise <c>False</c>.</returns>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PlayTTS(string text, string lang = "ko_KR", EventHandler ttsReadyFinishedCallback = null)
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsController.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
            if (ttsController.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsController.AddText(text, lang);
                ttsController.PlayAsync(ttsReadyFinishedCallback);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
                return false;
            }
            return true;
        }

        /// <summary>  
        /// Pauses the currently playing Text-To-Speech audio.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseTTS()
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return;
            }

            try
            {
                Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
                ttsController?.Pause();
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
            }
        }

        /// <summary>  
        /// Stops the currently playing Text-To-Speech audio.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopTTS()
        {
            if (ttsController == null || ttsController.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return;
            }

            try
            {
                Log.Info(LogTag, "Current TTS State :" + ttsController.TtsHandle.CurrentState);
                ttsController?.Stop();
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
            }
        }

        public void InitializeMic()
        {
            if (audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.InitializeMic(lipSyncer, 160);
        }

        public void DeinitializeMic()
        {
            if (audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.StartRecording();
        }

        public void StartMic()
        {
            if (audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.StartRecording();
        }

        public void StopMic()
        {
            if (audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.StopRecording();
        }

        public void PauseMic()
        {
            if (audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.PauseRecording();
        }

        public void ResumeMic()
        {
            if(audioRecorder == null)
            {
                Tizen.Log.Error(LogTag, "audio record is null");
                return;
            }
            audioRecorder.ResumeRecording();
        }

        /// <summary>  
        /// Releases unmanaged resources used by this instance.  
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            if (ttsController != null)
            {
                ttsController.Dispose();
                ttsController = null;
            }

            if (audioRecorder != null)
            {
                audioRecorder.Dispose();
                audioRecorder = null;
            }
        }
    }
}
