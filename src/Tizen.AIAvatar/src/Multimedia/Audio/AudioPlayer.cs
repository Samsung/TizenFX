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

using Tizen.Multimedia;
using System.IO;
using System;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class AudioPlayer : IDisposable
    {
        private AudioPlayback audioPlayback;
        private MemoryStream audioStream;

        internal AudioPlayer()
        {
        }

        internal void PlayAsync(byte[] buffer, int sampleRate = 0)
        {
            if (audioPlayback == null)
            {
                Play(buffer, sampleRate);
            }
            else
            {
                audioPlayback.Write(buffer);
            }
        }

        internal void Play(byte[] audioBytes, int sampleRate = 0)
        {
            if (audioBytes == null)
            {
                return;
            }

            try
            {
                if (audioPlayback != null)
                {
                    Destroy();
                }
                if (sampleRate == 0)
                {
                    sampleRate = CurrentAudioOptions.SampleRate;
                }
                audioPlayback = new AudioPlayback(sampleRate, CurrentAudioOptions.Channel, CurrentAudioOptions.SampleType);
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"Failed to create AudioPlayback. {e.Message}");
            }

            if (audioPlayback != null)
            {
                audioPlayback.Prepare();
                audioPlayback.BufferAvailable += (sender, args) =>
                {
                    if (audioStream.Position == audioStream.Length)
                    {
                        return;
                    }

                    try
                    {
                        var buffer = new byte[args.Length];
                        audioStream.Read(buffer, 0, args.Length);
                        audioPlayback.Write(buffer);
                    }
                    catch (Exception e)
                    {
                        Log.Error(LogTag, $"Failed to write. {e.Message}");
                    }
                };

                audioStream = new MemoryStream(audioBytes);
            }
        }

        internal void Pause()
        {
            if (audioPlayback != null)
            {
                audioPlayback.Pause();
            }
            else
            {
                Log.Error(LogTag, $"audioPlayBack is null");
            }
        }

        internal void Stop()
        {
            if (audioPlayback != null)
            {
                audioPlayback.Pause();
                Destroy();
            }
            else
            {
                Log.Error(LogTag, $"audioPlayBack is null");
            }
        }

        public void Dispose()
        {
            Destroy();

            audioStream?.Flush();
            audioStream?.Dispose();
            audioStream = null;
        }

        private void Destroy()
        {
            audioPlayback?.Unprepare();
            audioPlayback?.Dispose();
            audioPlayback = null;
        }
    }
}
