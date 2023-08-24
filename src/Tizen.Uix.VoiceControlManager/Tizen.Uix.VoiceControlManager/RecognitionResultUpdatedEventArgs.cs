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
    public class RecognitionResultUpdatedEventArgs : IDisposable
    {
        private RecognizedResult _result;
        private IEnumerable<VoiceCommand> _command;
        private string _recognizedText;
        private bool _disposed = false;

        internal RecognitionResultUpdatedEventArgs(RecognizedResult result, IntPtr cmdList, IntPtr recognizedText)
        {
            _result = result;
            SafeCommandListHandle handle = new SafeCommandListHandle(cmdList);
            VoiceCommandsGroup _list = new VoiceCommandsGroup(handle);
            _command = _list.Commands;
            _recognizedText = Marshal.PtrToStringAnsi(recognizedText);
        }

        /// <summary>
        /// The destructor of the RecognitionResultEventArgs class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~RecognitionResultUpdatedEventArgs()
        {
            Dispose(false);
        }

        /// <summary>
        /// The result of recognizing a VoiceCommand.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public RecognizedResult Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The recognized text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string RecognizedText
        {
            get
            {
                return _recognizedText;
            }
        }

        /// <summary>
        /// The recognized command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<VoiceCommand> Commands
        {
            get
            {
                return _command;
            }
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">
        /// If true, disposes any disposable objects. If false, does not dispose disposable objects.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            _disposed = true;
        }
    }
}
