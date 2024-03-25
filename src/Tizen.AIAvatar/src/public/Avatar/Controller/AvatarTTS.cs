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

using System.Collections.Generic;
using System.ComponentModel;
using System;
using Tizen.Uix.Tts;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarTTS
    {
        private TTSLipSyncer ttsLipSyncer;

        private event EventHandler ttsReadyFinished;
        private readonly Object ttsReadyFinishedLock = new Object();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarTTS()
        {
        }

        /// <summary>
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
        /// <param name=""></param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TtsClient CurrentTTSClient => ttsLipSyncer?.TtsHandle;

        /// <summary>
        /// <param name=""></param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitTTS(Avatar avatar)
        {
            if (ttsLipSyncer == null)
            {
                try
                {
                    ttsLipSyncer = new TTSLipSyncer(avatar);
                }
                catch (Exception e)
                {
                    Log.Error(LogTag, $"error :{e.Message}");
                    Log.Error(LogTag, $"{e.StackTrace}");
                }
            }
        }

        /// <summary>
        /// <param name=""></param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeinitTTS()
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
        /// <param name=""></param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<VoiceInfo> GetSupportedVoices()
        {
            return ttsLipSyncer.GetSupportedVoices();
        }

        /// <summary>
        /// <param name=""></param>
        /// </summary>
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
                Log.Info(LogTag, $"{voiceInfo.Lang} & {voiceInfo.Type} is not supported");
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
        /// <param name=""></param>
        /// </summary>
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
        /// <param name=""></param>
        /// </summary>
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
        /// <param name=""></param>
        /// </summary>
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
                Log.Info(LogTag, $"{voiceInfo.Lang} & {voiceInfo.Type} is not supported");
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
        /// <param name=""></param>
        /// </summary>
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
        /// <param name=""></param>
        /// </summary>
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
                Log.Info(LogTag, $"{voiceInfo.Lang} & {voiceInfo.Type} is not supported");
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
        /// <param name=""></param>
        /// </summary>
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
        /// <param name=""></param>
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
        /// <param name=""></param>
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
    }
}
