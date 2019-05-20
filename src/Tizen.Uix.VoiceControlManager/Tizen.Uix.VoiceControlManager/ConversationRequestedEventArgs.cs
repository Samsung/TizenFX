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
    /// This Class contains the requests conversation from vc-daemon.
    /// </summary>
    public class ConversationRequestedEventArgs : EventArgs
    {
        internal ConversationRequestedEventArgs(string appId, string dispTextString, string uttTextString, bool continuous)
        {
            AppId = appId;
            DisplayText = dispTextString;
            UtterenceText = uttTextString;
            IsContinuous = continuous;
        }

        /// <summary>
        /// The application id of VC client to request dialog
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// The display text requested to be displayed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string DisplayText
        {
            get;
            private set;
        }

        /// <summary>
        /// The utterence text requested to be spoken
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string UtterenceText
        {
            get;
            private set;
        }

        /// <summary>
        /// If true, VoiceControlManager still has a conversation to deal with. And Start() should be called again.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsContinuous
        {
            get;
            private set;
        }
    }
}