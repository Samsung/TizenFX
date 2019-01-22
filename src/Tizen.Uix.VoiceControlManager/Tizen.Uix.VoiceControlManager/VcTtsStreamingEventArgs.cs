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
    /// This Class contains the vc client sends audio streaming for TTS feedback.
    /// </summary>
    public class VcTtsStreamingEventArgs
    {
        internal VcTtsStreamingEventArgs(int pid, int uttId, FeedbackEventType evt, string buffer, int len)
        {
            Pid = pid;
            UttId = uttId;
            Evt = evt;
            Buffer = buffer;
            Length = len;
        }

        /// <summary>
        /// Enumeration for TTS feedback events
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum FeedbackEventType
        {
            /// <summary>
            /// Failed
            /// </summary>
            Fail = -1,
            /// <summary>
            /// Start event
            /// </summary>
            Start = 1,
            /// <summary>
            /// Continue event
            /// </summary>
            Continue = 2,
            /// <summary>
            /// Finish event
            /// </summary>
            Finish = 3
        }

        /// <summary>
        /// The process id of the vc client
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Pid
        {
            get;
            private set;
        }

        /// <summary>
        /// The utterance id
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int UttId
        {
            get;
            private set;
        }

        /// <summary>
        /// TTS feedback event
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public FeedbackEventType Evt
        {
            get;
            private set;
        }

        /// <summary>
        /// Audio streaming data
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Buffer
        {
            get;
            private set;
        }

        /// <summary>
        /// Length of the audio streaming data
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Length
        {
            get;
            private set;
        }
    }
}