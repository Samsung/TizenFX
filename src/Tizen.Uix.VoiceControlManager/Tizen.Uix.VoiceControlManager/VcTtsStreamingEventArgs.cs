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

using System;

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// This Class contains the vc client sends audio streaming for TTS feedback.
    /// </summary>
    public class VcTtsStreamingEventArgs : EventArgs
    {
        internal VcTtsStreamingEventArgs(string appId, int uttId, FeedbackType type, byte[] buffer)
        {
            AppId = appId;
            UtteranceId = uttId;
            FeedbackType = type;
            Buffer = buffer;
        }

        /// <summary>
        /// The application id of the vc client
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// The utterance id
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int UtteranceId
        {
            get;
            private set;
        }

        /// <summary>
        /// TTS feedback event which knows current status, app should receive until finish events comes up.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public FeedbackType FeedbackType
        {
            get;
            private set;
        }

        /// <summary>
        /// Audio streaming data
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public byte[] Buffer
        {
            get;
            private set;
        }
    }
}
