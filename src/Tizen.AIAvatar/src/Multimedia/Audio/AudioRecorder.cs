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
using System.Linq;
using Tizen.Multimedia;
using Tizen.NUI;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class AudioRecorder : IDisposable
    {
        private const string privilegeForRecording = "http://tizen.org/privilege/recorder";

        private AsyncAudioCapture asyncAudioCapture;

        private byte[] recordedBuffer;
        private float desiredBufferDuration = 0.16f;
        private int desiredBufferLength;

        private Timer audioRecordingTimer;

        private Action audioRecdingAction;
        private Action<byte[], int> bufferAction;

        private static AudioRecorder instance;

        internal static AudioRecorder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioRecorder();
                }
                return instance;
            }
        }

        internal event EventHandler<RecordBufferChangedEventArgs> BufferChanged;

        internal AudioRecorder()
        {
            Utils.CheckPrivilege(privilegeForRecording);
            desiredBufferLength = (int)(CurrentAudioOptions.SampleRate * desiredBufferDuration * 2);
        }

        internal void InitializeMic(LipSyncer lipSyncer, uint recordingTime = 160)
        {
            audioRecordingTimer = new Timer(recordingTime);
            if (lipSyncer != null)
            {
                Tizen.Log.Error(LogTag, "LipSyncer of animator is null");
                return;
            }
            this.audioRecdingAction = lipSyncer.OnRecodingTick;
            this.bufferAction = lipSyncer.OnRecordBufferChanged;

            BufferChanged += OnRecordBufferChanged;
            audioRecordingTimer.Tick += AudioRecordingTimerTick;
        }


        internal void DeinitializeMic()
        {
            StopRecording();
            BufferChanged -= OnRecordBufferChanged;

            if (audioRecordingTimer != null)
            {
                audioRecordingTimer.Stop();
                audioRecordingTimer.Tick -= AudioRecordingTimerTick;

                audioRecordingTimer.Dispose();
                audioRecordingTimer = null;
            }
            audioRecdingAction = null;
        }

        internal void StartRecording()
        {
            audioRecordingTimer?.Start();
            asyncAudioCapture = new AsyncAudioCapture(CurrentAudioOptions.SampleRate, CurrentAudioOptions.Channel, CurrentAudioOptions.SampleType);

            recordedBuffer = new byte[0];
            asyncAudioCapture.DataAvailable += (s, e) =>
            {
                recordedBuffer = recordedBuffer.Concat(e.Data).ToArray();
                if (recordedBuffer.Length >= desiredBufferLength)
                {
                    var recordedBuffer = this.recordedBuffer;
                    this.recordedBuffer = Array.Empty<byte>();

                    BufferChanged?.Invoke(this, new RecordBufferChangedEventArgs(recordedBuffer, CurrentAudioOptions.SampleRate));
                }
            };
            asyncAudioCapture.Prepare();
            Log.Info(LogTag, "Start Recording - Preapre AsyncAudioCapture");
        }

        internal void StopRecording()
        {
            audioRecordingTimer?.Stop();
            asyncAudioCapture.Dispose();
        }

        internal void PauseRecording()
        {
            asyncAudioCapture.Pause();
        }

        internal void ResumeRecording()
        {
            asyncAudioCapture.Resume();
        }

        private void OnRecordBufferChanged(object sender, RecordBufferChangedEventArgs e)
        {
            bufferAction?.Invoke(e.RecordedBuffer, CurrentAudioOptions.SampleRate);
        }

        private bool AudioRecordingTimerTick(object source, Timer.TickEventArgs e)
        {
            Log.Info(LogTag, "TickTimer");
            audioRecdingAction?.Invoke();
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
