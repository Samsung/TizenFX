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
using static Interop.Tts;

namespace Tizen.Uix.Tts
{
    /// <summary>
    /// This class holds information related to the TTS ErrorOccurred event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ErrorOccurredEventArgs
    {
        private IntPtr _handle;

        internal ErrorOccurredEventArgs(IntPtr handle, int utteranceId, Interop.Tts.TtsError error)
        {
            this._handle = handle;
            this.UtteranceId = utteranceId;
            switch (error)
            {
                case Interop.Tts.TtsError.None:
                    {
                        ErrorValue = Error.None;
                        break;
                    }

                case Interop.Tts.TtsError.OutOfMemory:
                    {
                        ErrorValue = Error.OutOfMemory;
                        break;
                    }

                case Interop.Tts.TtsError.IoError:
                    {
                        ErrorValue = Error.IoError;
                        break;
                    }

                case Interop.Tts.TtsError.InvalidParameter:
                    {
                        ErrorValue = Error.InvalidParameter;
                        break;
                    }

                case Interop.Tts.TtsError.TimedOut:
                    {
                        ErrorValue = Error.TimedOut;
                        break;
                    }

                case Interop.Tts.TtsError.OutOfNetwork:
                    {
                        ErrorValue = Error.OutOfNetwork;
                        break;
                    }

                case Interop.Tts.TtsError.PermissionDenied:
                    {
                        ErrorValue = Error.PermissionDenied;
                        break;
                    }

                case Interop.Tts.TtsError.NotSupported:
                    {
                        ErrorValue = Error.NotSupported;
                        break;
                    }

                case Interop.Tts.TtsError.InvalidState:
                    {
                        ErrorValue = Error.InvalidState;
                        break;
                    }

                case Interop.Tts.TtsError.InvalidVoice:
                    {
                        ErrorValue = Error.InvalidVoice;
                        break;
                    }

                case Interop.Tts.TtsError.EngineNotFound:
                    {
                        ErrorValue = Error.EngineNotFound;
                        break;
                    }

                case Interop.Tts.TtsError.OperationFailed:
                    {
                        ErrorValue = Error.OperationFailed;
                        break;
                    }

                case Interop.Tts.TtsError.AudioPolicyBlocked:
                    {
                        ErrorValue = Error.AudioPolicyBlocked;
                        break;
                    }

                case Interop.Tts.TtsError.NotSupportedFeature:
                    {
                        ErrorValue = Error.NotSupportedFeature;
                        break;
                    }

                case Interop.Tts.TtsError.ServiceReset:
                    {
                        ErrorValue = Error.ServiceReset;
                        break;
                    }

                case Interop.Tts.TtsError.ScreenReaderOff:
                    {
                        ErrorValue = Error.ScreenReaderOff;
                        break;
                    }
            }
        }

        /// <summary>
        /// The utterance ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int UtteranceId
        {
            get;
            internal set;
        }

        /// <summary>
        /// The error value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Error ErrorValue
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the current error message.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>
        /// String error message.
        /// </returns>
        public string ErrorMessage
        {
            get
            {
                string errorMesage = "";
                TtsError error = TtsGetErrorMessage(_handle, out errorMesage);
                if (error != TtsError.None)
                {
                    Log.Error(LogTag, "GetErrorMessage Failed with error " + error);
                    return "";
                }

                return errorMesage;
            }

        }
    }
}
