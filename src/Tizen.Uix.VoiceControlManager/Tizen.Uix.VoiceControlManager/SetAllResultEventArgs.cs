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
    /// This Class contains the recognition results from vc-daemon.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SetAllResultEventArgs
    {
        internal SetAllResultEventArgs(ResultEvent evt, VoiceCommandList cmdList, string resultString, string msgString)
        {
            ResultEvent = evt;
            CommandList = cmdList;
            Result = resultString;
            Message = msgString;
        }

        /// <summary>
        /// The result event
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ResultEvent ResultEvent
        {
            get;
            private set;
        }

        /// <summary>
        /// Command list
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public VoiceCommandList CommandList
        {
            get;
            private set;
        }

        /// <summary>
        /// Command text
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Result
        {
            get;
            private set;
        }

        /// <summary>
        /// Engine message, it can be one of the below:
        /// 1. "vc.result.message.none"
        /// 2. "vc.result.message.asr.result.consumed"
        /// 3. "vc.result.message.error.too.loud"
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Message
        {
            get;
            private set;
        }
    }
}