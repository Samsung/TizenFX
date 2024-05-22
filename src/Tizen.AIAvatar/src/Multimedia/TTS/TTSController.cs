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
using System.Linq;
using Tizen.Uix.Tts;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class TTSControllerEventArgs : EventArgs
    {
        public TTSControllerEventArgs()
        {
        }

        public TTSControllerEventArgs(byte[] audioData, int sampleRate)
        {
            //AudioData = audioData;
            AudioData = new byte[audioData.Length];
            Buffer.BlockCopy(audioData, 0, AudioData, 0, audioData.Length);
            SampleRate = sampleRate;
        }

        public byte[] AudioData
        {
            get;
            internal set;
        }

        public int SampleRate
        {
            get;
            internal set;
        }
    }

    internal class TTSController : IDisposable
    {
        private List<UtteranceText> textList;
        private TtsClient ttsHandle;
        private VoiceInfo voiceInfo;
        private List<Byte> byteList;

        private byte[] recordedBuffer;
        private byte[] audioTailBuffer;

        private int sampleRate;
        private float desiredBufferDuration = 0.175f;
        private float audioTailLengthFactor = 0.015f;
        private float audioBufferMultiflier = 2f;

        private int desiredBufferLength;
        private int audioTailLength;

        private bool isPrepared = false;
        private bool isAsync = false;

        private Action<byte[], int> bufferChangedAction;

        private int audioLength;
        private bool isAsyncLipStarting;

        internal event EventHandler PlayReadyCallback;

        internal event EventHandler<TTSControllerEventArgs> PreparedSyncText;
        internal event EventHandler<TTSControllerEventArgs> StoppedTTS;
        
        
        internal event EventHandler<TTSControllerEventArgs> UpdatedBuffer;

        internal TTSController()
        {
            InitTts();
        }

        ~TTSController()
        {
            DeinitTts();
        }

        internal TtsClient TtsHandle
        {
            get { return ttsHandle; }
        }

        internal VoiceInfo VoiceInfo
        {
            get { return voiceInfo; }
            set
            {
                voiceInfo = value;
            }
        }

        internal List<VoiceInfo> GetSupportedVoices()
        {
            var voiceInfoList = new List<VoiceInfo>();

            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return voiceInfoList;
            }

            var supportedVoices = ttsHandle.GetSupportedVoices();
            foreach (var supportedVoice in supportedVoices)
            {
                Log.Info(LogTag, $"{supportedVoice.Language} & {supportedVoice.VoiceType} is supported");
                voiceInfoList.Add(new VoiceInfo() { Language = supportedVoice.Language, Type = (VoiceType)supportedVoice.VoiceType });
            }
            return voiceInfoList;
        }

        internal bool IsSupportedVoice(string lang)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return false;
            }
            var supportedVoices = ttsHandle.GetSupportedVoices();

            foreach (var supportedVoice in supportedVoices)
            {
                if (supportedVoice.Language.Equals(lang))
                {
                    Log.Info(LogTag, $"{lang} is supported");
                    return true;
                }
            }
            return false;
        }

        internal bool IsSupportedVoice(VoiceInfo voiceInfo)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return false;
            }
            var supportedVoices = ttsHandle.GetSupportedVoices();
            foreach (var supportedVoice in supportedVoices)
            {
                if (supportedVoice.Language.Equals(voiceInfo.Language) && ((VoiceType)supportedVoice.VoiceType == voiceInfo.Type))
                {
                    Log.Info(LogTag, $"{voiceInfo.Language} & {voiceInfo.Type} is supported");
                    return true;
                }
            }
            return false;
        }


        internal void AddText(string txt, VoiceInfo voiceInfo)
        {
            if (voiceInfo.Language == null)
            {
                Log.Error(LogTag, "VoiceInfo's value is null");
            }
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }
            var temp = new UtteranceText();
            temp.Text = txt;
            temp.UttID = ttsHandle.AddText(txt, voiceInfo.Language, (int)voiceInfo.Type, 0);
            try
            {
                textList.Add(temp);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"Error AddText" + e.Message);
            }
        }

        internal void AddText(string txt, string lang)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }
            var temp = new UtteranceText();
            temp.Text = txt;
            temp.UttID = ttsHandle.AddText(txt, lang, (int)voiceInfo.Type, 0);
            try
            {
                textList.Add(temp);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"Error AddText" + e.Message);
            }
        }

        internal void Prepare(EventHandler playReadyCallback)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }
            Log.Info(LogTag, "Prepare TTS");
            isPrepared = true;
            isAsync = false;
            PlayReadyCallback = playReadyCallback;
            Play(true);
        }


        internal bool PlayPreparedText()
        {
            if (byteList != null && byteList.Count != 0)
            {
                Log.Info(LogTag, "PlayPreparedText TTS");

                PreparedSyncText?.Invoke(this, new TTSControllerEventArgs(byteList.ToArray(), sampleRate));
                return true;
            }
            return false;
        }

        internal void Play(bool isPrepared = false)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }

            this.isPrepared = isPrepared;
            isAsync = false;
            ttsHandle.Play();
        }

        internal void PlayAsync(EventHandler playReadyCallback)
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }

            isPrepared = false;
            isAsync = true;
            PlayReadyCallback = playReadyCallback;
            ttsHandle.Play();
        }

        public void Pause()
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }
            ttsHandle.Pause();
        }

        internal void Stop()
        {
            if (ttsHandle == null)
            {
                Log.Error(LogTag, $"ttsHandle is null");
                return;
            }
            ttsHandle.Stop();
            StoppedTTS?.Invoke(this, new TTSControllerEventArgs());
        }

        internal void DeinitTts()
        {
            try
            {
                if (ttsHandle != null)
                {
                    ttsHandle.Unprepare();

                    // Unregister Callbacks
                    ttsHandle.DefaultVoiceChanged -= TtsDefaultVoiceChangedCallback;
                    ttsHandle.EngineChanged -= TtsEngineChangedCallback;
                    ttsHandle.ErrorOccurred -= TtsErrorOccuredCallback;
                    ttsHandle.StateChanged -= TtsStateChangedCallback;
                    ttsHandle.UtteranceCompleted -= TtsUtteranceCompletedCallback;
                    ttsHandle.UtteranceStarted -= TtsUtteranceStartedCallback;

                    ttsHandle.Dispose();
                    ttsHandle = null;
                }

                if (textList != null)
                {
                    textList.Clear();
                    textList = null;
                }

                if (byteList != null)
                {
                    byteList.Clear();
                    byteList = null;
                }
            }
            catch (Exception e)
            {
                Log.Error(LogTag, "[ERROR] Fail to unprepare Tts");
                Log.Error(LogTag, e.Message);
            }
        }

        private void InitTts()
        {
            try
            {
                ttsHandle = new TtsClient();

                // Register Callbacks
                ttsHandle.DefaultVoiceChanged += TtsDefaultVoiceChangedCallback;
                ttsHandle.EngineChanged += TtsEngineChangedCallback;
                ttsHandle.ErrorOccurred += TtsErrorOccuredCallback;
                ttsHandle.StateChanged += TtsStateChangedCallback;
                ttsHandle.UtteranceCompleted += TtsUtteranceCompletedCallback;
                ttsHandle.UtteranceStarted += TtsUtteranceStartedCallback;

                ttsHandle.SynthesizedPcm += TtsSyntheiszedPCM;
                ttsHandle.PlayingMode = PlayingMode.ByClient;

                ttsHandle.Prepare();

                voiceInfo = new VoiceInfo
                {
                    Language = ttsHandle.DefaultVoice.Language,
                    Type = (VoiceType)ttsHandle.DefaultVoice.VoiceType
                };

                textList = new List<UtteranceText>();
                Log.Info(LogTag, voiceInfo.Language + ", " + voiceInfo.Type.ToString());

            }
            catch (Exception e)
            {
                Log.Error(LogTag, "[ERROR] Fail to prepare Tts");
                Log.Error(LogTag, e.Message);
            }
        }

        private void TtsSyntheiszedPCM(object sender, SynthesizedPcmEventArgs e)
        {
            var dataSize = e.Data.Length;
            var audio = new byte[dataSize];
            sampleRate = e.SampleRate;

            //Marshal.Copy(e.Data, audio, 0, dataSize);
            switch (e.EventType) //START
            {
                case SynthesizedPcmEvent.Start://start
                    Tizen.Log.Info(LogTag, "------------------Start : " + e.UtteranceId);
                    Tizen.Log.Info(LogTag, "Output audio Size : " + dataSize);
                    Tizen.Log.Info(LogTag, "SampleRate" + e.SampleRate);
                    if (byteList == null)
                    {
                        byteList = new List<byte>();
                    }
                    if (recordedBuffer == null)
                    {
                        recordedBuffer = new byte[0];
                    }
                    byteList.Clear();

                    if (isAsync)
                    {
                        recordedBuffer = Array.Empty<byte>();

                        desiredBufferLength = (int)(e.SampleRate * desiredBufferDuration * audioBufferMultiflier);
                        audioTailLength = (int)(sampleRate * audioTailLengthFactor * audioBufferMultiflier);
                        audioTailBuffer = new byte[audioTailLength];
                        PlayReadyCallback?.Invoke(null, EventArgs.Empty);
                        //InitAsyncBuffer();
                    }
                    break;
                case SynthesizedPcmEvent.Continue://continue
                    if (isAsync)
                    {
                        recordedBuffer = recordedBuffer.Concat(e.Data).ToArray();
                        //PlayAsync
                        if (recordedBuffer.Length >= desiredBufferLength)
                        {
                            Tizen.Log.Error(LogTag, "Current recordbuffer length :" + recordedBuffer.Length);
                            //UpdateBuffer(recordedBuffer, sampleRate);

                            Buffer.BlockCopy(recordedBuffer, recordedBuffer.Length - audioTailLength, audioTailBuffer, 0, audioTailLength);

                            recordedBuffer = Array.Empty<byte>();
                            recordedBuffer = recordedBuffer.Concat(audioTailBuffer).ToArray();
                            Array.Clear(audioTailBuffer, 0, audioTailLength);
                        }
                    }
                    else
                    {
                        byteList.AddRange(e.Data);
                    }
                    break;
                case SynthesizedPcmEvent.Finish://finish
                    Tizen.Log.Info(LogTag, "------------------Finish : " + e.UtteranceId);
                    if (!isAsync)
                    {
                        if (!isPrepared)
                        {
                            //Play voice immediately
                            PlayPreparedText();
                        }
                        else
                        {
                            //Notify finished state
                            Log.Info(LogTag, "Notify finished state");
                            PlayReadyCallback?.Invoke(null, EventArgs.Empty);
                        }
                    }
                    else
                    {//async
                        //FinishedSynthesizedPcm?.Invoke(null, EventArgs.Empty);
                        //lipSyncer.SetFinishAsyncLip(true);
                    }
                    break;
                case SynthesizedPcmEvent.Fail: //fail
                    break;

            }
        }

        private void TtsUtteranceStartedCallback(object sender, UtteranceEventArgs e)
        {
            Log.Debug(LogTag, "Utterance start now (" + e.UtteranceId + ")");
        }

        private void TtsUtteranceCompletedCallback(object sender, UtteranceEventArgs e)
        {
            Log.Debug(LogTag, "Utterance complete (" + e.UtteranceId + ")");

            foreach (UtteranceText item in textList)
            {
                if (item.UttID == e.UtteranceId)
                {
                    textList.Remove(item);
                    Log.Debug(LogTag, "TextList Count (" + textList.Count.ToString() + ")");
                    break;
                }
            }
        }

        private void TtsStateChangedCallback(object sender, StateChangedEventArgs e)
        {
            Log.Debug(LogTag, "Current state is changed from (" + e.Previous + ") to (" + e.Current + ")");
        }

        private void TtsErrorOccuredCallback(object sender, ErrorOccurredEventArgs e)
        {
            Log.Error(LogTag, "Error is occured (" + e.ErrorMessage + ")");
        }

        private void TtsEngineChangedCallback(object sender, EngineChangedEventArgs e)
        {
            Log.Debug(LogTag, "Prefered engine is changed (" + e.EngineId + ") (" + e.VoiceType.Language + ")");
        }

        private void TtsDefaultVoiceChangedCallback(object sender, DefaultVoiceChangedEventArgs e)
        {
            Log.Debug(LogTag, "Default voice is changed from (" + e.Previous + ") to (" + e.Current + ")");
        }

        private void InitAsyncBuffer()
        {
            /*
            InitedAsyncBuffer?.Invoke(null, EventArgs.Empty);
            if (!lipSyncer.IsAsyncInit)
            {
                audioLength = (int)(sampleRate * 0.16f * 2f);

                lipSyncer.InitAsyncLipsync();
                lipSyncer.IsAsyncInit = true;

                lipSyncer.SetFinishAsyncLip(false);
                isAsyncLipStarting = false;
            }*/
        }

        private void UpdateBuffer(byte[] recordBuffer, int sampleRate)
        {
            UpdatedBuffer?.Invoke(this, new TTSControllerEventArgs(recordBuffer, sampleRate));
            /*
            if (lipSyncer != null)
            {
                Log.Error(LogTag, "OnTTSBufferChanged");
                lipSyncer.EnqueueAnimation(recordBuffer, sampleRate, audioLength);
                if (!isAsyncLipStarting)
                {
                    lipSyncer.StartAsyncLipPlayTimer();
                    isAsyncLipStarting = true;
                }
            }
            else
            {
                Log.Error(LogTag, "avatarLipSyncer is null");
            }*/
        }

        public void Dispose()
        {
            ttsHandle.Stop();
            ttsHandle.Dispose();
            ttsHandle = null;
        }
    }
}
