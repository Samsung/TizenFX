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
using static Interop.VoiceControlWidget;

namespace Tizen.Uix.VoiceControlWidget
{
    public class ErrorOccurredEventArgs
    {
        internal ErrorOccurredEventArgs(ErrorCode error)
        {
            switch (error)
            {
                case ErrorCode.None:
                    {
                        ErrorValue = Error.None;
                        break;
                    }

                case ErrorCode.OutOfMemory:
                    {
                        ErrorValue = Error.OutOfMemory;
                        break;
                    }

                case ErrorCode.IoError:
                    {
                        ErrorValue = Error.IoError;
                        break;
                    }

                case ErrorCode.InvalidParameter:
                    {
                        ErrorValue = Error.InvalidParameter;
                        break;
                    }

                case ErrorCode.TimedOut:
                    {
                        ErrorValue = Error.TimedOut;
                        break;
                    }

                case ErrorCode.RecorderBusy:
                    {
                        ErrorValue = Error.RecorderBusy;
                        break;
                    }

                case ErrorCode.PermissionDenied:
                    {
                        ErrorValue = Error.PermissionDenied;
                        break;
                    }

                case ErrorCode.NotSupported:
                    {
                        ErrorValue = Error.NotSupported;
                        break;
                    }

                case ErrorCode.InvalidState:
                    {
                        ErrorValue = Error.InvalidState;
                        break;
                    }

                case ErrorCode.InvalidLanguage:
                    {
                        ErrorValue = Error.InvalidLanguage;
                        break;
                    }

                case ErrorCode.EngineNotFound:
                    {
                        ErrorValue = Error.EngineNotFound;
                        break;
                    }

                case ErrorCode.OperationFailed:
                    {
                        ErrorValue = Error.OperationFailed;
                        break;
                    }

                case ErrorCode.OperationRejected:
                    {
                        ErrorValue = Error.OperationRejected;
                        break;
                    }

                case ErrorCode.IterationEnd:
                    {
                        ErrorValue = Error.IterationEnd;
                        break;
                    }

                case ErrorCode.Empty:
                    {
                        ErrorValue = Error.Empty;
                        break;
                    }

                case ErrorCode.InProgressToReady:
                    {
                        ErrorValue = Error.InProgressToReady;
                        break;
                    }

                case ErrorCode.InProgressToRecording:
                    {
                        ErrorValue = Error.InProgressToRecording;
                        break;
                    }

                case ErrorCode.InProgressToProcessing:
                    {
                        ErrorValue = Error.InProgressToProcessing;
                        break;
                    }

                case ErrorCode.ServiceReset:
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
    }
}