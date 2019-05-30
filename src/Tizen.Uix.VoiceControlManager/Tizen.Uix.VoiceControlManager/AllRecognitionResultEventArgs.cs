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
    /// This class contains the all recognition results from vc-daemon.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class AllRecognitionResultEventArgs : EventArgs
    {
        internal AllRecognitionResultEventArgs(RecognizedResult result, string recognizedText, string msg)
        {
            Result = result;
            RecognizedText = recognizedText;
            Message = msg;
        }

        /// <summary>
        /// The result of recognizing a VoiceCommand.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public RecognizedResult Result { get;  }

        /// <summary>
        /// The recognized text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string RecognizedText { get; }

        /// <summary>
        /// Engine message, it can be one of the below:
        /// 1. "vc.result.message.none"
        /// 2. "vc.result.message.asr.result.consumed"
        /// 3. "vc.result.message.error.too.loud"
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Message { get; }
    }
}
