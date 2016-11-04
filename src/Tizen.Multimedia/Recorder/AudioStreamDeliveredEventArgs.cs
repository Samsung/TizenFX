/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class containing details of audio stream.
    /// </summary>
    public class AudioStreamDeliveredEventArgs : EventArgs
    {
        private byte[] _stream = null;
        private AudioSampleType _type = AudioSampleType.S16Le;
        private int _channel = 0;
        private uint _recordingTime = 0;

        internal AudioStreamDeliveredEventArgs(byte[] stream, AudioSampleType type, int channel, uint recordingTime)
        {
            _stream = stream;
            _type = type;
            _channel = channel;
            _recordingTime = recordingTime;
        }

        /// <summary>
        /// The audio stream data.
        /// </summary>
        public byte[] Stream {
            get {
                return _stream;
            }
        }

        /// <summary>
        /// The audio format type.
        /// </summary>
        public AudioSampleType Type {
            get {
                return _type;
            }
        }

        /// <summary>
        /// The number of channels.
        /// </summary>
        public int Channel {
            get {
                return _channel;
            }
        }

        /// <summary>
        /// The recording time of the stream buffer in milliseconds.
        /// </summary>
        public uint RecordingTime {
            get {
                return _recordingTime;
            }
        }
    }
}
