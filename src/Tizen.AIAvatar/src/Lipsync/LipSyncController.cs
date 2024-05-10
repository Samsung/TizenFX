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

namespace Tizen.AIAvatar
{
     /// <summary>
     /// A controller class used to manage lip sync functionality for avatars.
     /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LipSyncController : IDisposable
    {
        private TTSController ttsLipSyncer;

        private event EventHandler ttsReadyFinished;
        private readonly Object ttsReadyFinishedLock = new Object();

        /// <summary>  
        /// Initializes a new instance of the <see cref="LipSyncController"/> class.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipSyncController()
        {
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
        public TtsClient CurrentTTSClient => ttsLipSyncer?.TtsHandle;

        /// <summary>
        /// Initializes the Text-To-Speech system for use with the Lip Sync Controller.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitializeTTS()
        {
            if (ttsLipSyncer == null)
            {
                try
                {
                    ttsLipSyncer = new TTSController();
                    //TODO : LipSync Event Connect
                }
                catch (Exception e)
                {
                    Log.Error(LogTag, $"error :{e.Message}");
                    Log.Error(LogTag, $"{e.StackTrace}");
                }
            }
        }

        /// <summary>  
        /// Deinitializes the Text-To-Speech system for use with the Lip Sync Controller. 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeInitializeTTS()
        {
            if (ttsLipSyncer != null)
            {
                try
                {
                    ttsLipSyncer.DeinitTts();
                    ttsLipSyncer = null;
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
            return ttsLipSyncer.GetSupportedVoices();
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }


            if (!ttsLipSyncer.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsLipSyncer.AddText(text, voiceInfo);
                ttsLipSyncer.Prepare(ttsReadyFinishedCallback);
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsLipSyncer.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsLipSyncer.AddText(text, lang);
                ttsLipSyncer.Prepare(ttsReadyFinishedCallback);
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            return ttsLipSyncer.PlayPreparedText();
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsLipSyncer.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsLipSyncer.AddText(text, voiceInfo);
                ttsLipSyncer.Play();
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsLipSyncer.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsLipSyncer.AddText(text, lang);
                ttsLipSyncer.Play();
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsLipSyncer.IsSupportedVoice(voiceInfo))
            {
                Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Info(LogTag, "TTS is not ready");
                return false;
            }

            try
            {
                ttsLipSyncer.AddText(text, voiceInfo);
                ttsLipSyncer.PlayAsync(ttsReadyFinishedCallback);
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return false;
            }

            if (!ttsLipSyncer.IsSupportedVoice(lang))
            {
                Log.Error(LogTag, $"{lang} is not supported");
                return false;
            }

            Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
            if (ttsLipSyncer.TtsHandle.CurrentState != Tizen.Uix.Tts.State.Ready)
            {
                Log.Error(LogTag, "TTS is not ready");
                return false;
            }
            try
            {
                ttsLipSyncer.AddText(text, lang);
                ttsLipSyncer.PlayAsync(ttsReadyFinishedCallback);
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return;
            }

            try
            {
                Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
                ttsLipSyncer?.Pause();
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
            if (ttsLipSyncer == null || ttsLipSyncer.TtsHandle == null)
            {
                Log.Error(LogTag, "tts is null");
                return;
            }

            try
            {
                Log.Info(LogTag, "Current TTS State :" + ttsLipSyncer.TtsHandle.CurrentState);
                ttsLipSyncer?.Stop();
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"error :{e.Message}");
                Log.Error(LogTag, $"{e.StackTrace}");
            }
        }

        /// <summary>  
        /// Releases unmanaged resources used by this instance.  
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
        }
    }
}
