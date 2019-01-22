/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// This Class contains audio formats necessary for playing TTS feedback.
    /// </summary>
    public class FeedbackAudioFormatEventArgs
    {
        internal FeedbackAudioFormatEventArgs(int rate, AudioChanelType channel, AudioType audioType)
        {
            Rate = rate;
            Channel = channel;
            Audio = audioType;
        }

        /// <summary>
        /// Enumerations for audio channels
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum AudioChanelType
        {
            /// <summary>
            /// 1 channel, mono
            /// </summary>
            Mono = 0,
            /// <summary>
            /// 2 channels, stereo
            /// </summary>
            Stereo
        }

        /// <summary>
        /// Enumerations of audio types
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum AudioType
        {
            /// <summary>
            /// Signed 16bit audio type, Little endian
            /// </summary>
            PcmS16Le = 0,
            /// <summary>
            /// Unsigned 8bit audio type
            /// </summary>
            PcmU8
        } 

        /// <summary>
        /// Audio sampling rate
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Rate
        {
            get;
            private set;
        }

        /// <summary>
        /// Audio channel
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AudioChanelType Channel
        {
            get;
            private set;
        }

        /// <summary>
        /// Audio type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public AudioType Audio
        {
            get;
            private set;
        }
    }
}