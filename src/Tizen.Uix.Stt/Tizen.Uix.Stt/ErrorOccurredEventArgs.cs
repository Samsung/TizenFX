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
using static Interop.Stt;

namespace Tizen.Uix.Stt
{
    /// <summary>
    /// This class holds information related to the STT ErrorOccurred event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ErrorOccurredEventArgs
    {
        private IntPtr _handle;

        internal ErrorOccurredEventArgs(IntPtr handle, Interop.Stt.SttError error)
        {
            this._handle = handle;
            switch (error)
            {
                case Interop.Stt.SttError.None:
                    {
                        ErrorValue = Error.None;
                        break;
                    }

                case Interop.Stt.SttError.OutOfMemory:
                    {
                        ErrorValue = Error.OutOfMemory;
                        break;
                    }

                case Interop.Stt.SttError.IoError:
                    {
                        ErrorValue = Error.IoError;
                        break;
                    }

                case Interop.Stt.SttError.InvalidParameter:
                    {
                        ErrorValue = Error.InvalidParameter;
                        break;
                    }

                case Interop.Stt.SttError.TimedOut:
                    {
                        ErrorValue = Error.TimedOut;
                        break;
                    }

                case Interop.Stt.SttError.RecorderBusy:
                    {
                        ErrorValue = Error.RecorderBusy;
                        break;
                    }

                case Interop.Stt.SttError.OutOfNetwork:
                    {
                        ErrorValue = Error.OutOfNetwork;
                        break;
                    }

                case Interop.Stt.SttError.PermissionDenied:
                    {
                        ErrorValue = Error.PermissionDenied;
                        break;
                    }

                case Interop.Stt.SttError.NotSupported:
                    {
                        ErrorValue = Error.NotSupported;
                        break;
                    }

                case Interop.Stt.SttError.InvalidState:
                    {
                        ErrorValue = Error.InvalidState;
                        break;
                    }

                case Interop.Stt.SttError.InvalidLanguage:
                    {
                        ErrorValue = Error.InvalidLanguage;
                        break;
                    }

                case Interop.Stt.SttError.EngineNotFound:
                    {
                        ErrorValue = Error.EngineNotFound;
                        break;
                    }

                case Interop.Stt.SttError.OperationFailed:
                    {
                        ErrorValue = Error.OperationFailed;
                        break;
                    }

                case Interop.Stt.SttError.NotSupportedFeature:
                    {
                        ErrorValue = Error.NotSupportedFeature;
                        break;
                    }

                case Interop.Stt.SttError.RecordingTimedOut:
                    {
                        ErrorValue = Error.RecordingTimedOut;
                        break;
                    }

                case Interop.Stt.SttError.NoSpeech:
                    {
                        ErrorValue = Error.NoSpeech;
                        break;
                    }

                case Interop.Stt.SttError.InProgressToReady:
                    {
                        ErrorValue = Error.InProgressToReady;
                        break;
                    }

                case Interop.Stt.SttError.InProgressToRecording:
                    {
                        ErrorValue = Error.InProgressToRecording;
                        break;
                    }

                case Interop.Stt.SttError.InProgressToProcessing:
                    {
                        ErrorValue = Error.InProgressToProcessing;
                        break;
                    }

                case Interop.Stt.SttError.ServiceReset:
                    {
                        ErrorValue = Error.ServiceReset;
                        break;
                    }

            }
        }

        /// <summary>
        /// The error value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Error ErrorValue
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the current error message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// String error message.
        /// </returns>
        public string ErrorMessage
        {
            get
            {
                string errorMesage = "";
                SttError error = SttGetErrorMessage(_handle, out errorMesage);
                if (error != SttError.None)
                {
                    Log.Error(LogTag, "GetErrorMessage Failed with error " + error);
                    return "";
                }

                return errorMesage;
            }

        }
    }
}
