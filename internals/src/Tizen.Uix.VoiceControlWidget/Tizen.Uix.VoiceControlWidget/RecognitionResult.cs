/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.VoiceControlWidget;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlWidget
{
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

        public ResultEvent Result
        {
            get
            {
                return _resultEvent;
            }
        }

        public string ResultMessage
        {
            get
            {
                return _result;
            }
        }

        public VoiceCommandList CommandList
        {
            get
            {
                return _list;
            }
        }
    }
}
