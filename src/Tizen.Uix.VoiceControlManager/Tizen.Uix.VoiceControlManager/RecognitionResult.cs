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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.VoiceControlManager;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// The recognition result from the engine.
    /// If the duplicated commands are recognized, the event(e.g. Result.Rejected) of a command may be rejected
    /// for selecting the command as a priority. If you set similar or same commands, or the recognized results are multi-results, the CommandList has multi commands.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class RecognitionResult
    {
        private ResultEvent _resultEvent;
        private VoiceCommandList _list;
        private string _result;

        internal RecognitionResult(ResultEvent evt, IntPtr cmdList, IntPtr result)
        {
            _resultEvent = evt;
            SafeCommandListHandle handle = new SafeCommandListHandle(cmdList);
            handle._ownership = false;
            _list = new VoiceCommandList(handle);
            _result = Marshal.PtrToStringAnsi(result);
        }

        /// <summary>
        /// The result event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ResultEvent Result
        {
            get
            {
                return _resultEvent;
            }
        }

        /// <summary>
        /// The spoken text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ResultMessage
        {
            get
            {
                return _result;
            }
        }


        /// <summary>
        /// The recognized command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public VoiceCommandList CommandList
        {
            get
            {
                return _list;
            }
        }
    }
}
