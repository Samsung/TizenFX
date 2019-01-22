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
using static Interop.VoiceControlManager;

namespace Tizen.Uix.VoiceControlManager
{
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(ErrorCode err)
        {
            Tizen.Log.Error(LogTag, "Error " + err);
            Exception exp;
            switch (err)
            {
                case ErrorCode.OutOfMemory:
                    {
                        exp = new OutOfMemoryException("Out Of Memory");
                        break;
                    }

                case ErrorCode.IoError:
                    {
                        exp = new InvalidOperationException("I/O Error Occurred");
                        break;
                    }

                case ErrorCode.InvalidParameter:
                    {
                        exp = new ArgumentException("Invalid Parameters Provided");
                        break;
                    }

                case ErrorCode.TimedOut:
                    {
                        exp = new TimeoutException("No answer from service");
                        break;
                    }

                case ErrorCode.RecorderBusy:
                    {
                        exp = new InvalidOperationException("Recorder is Busy ");
                        break;
                    }

                case ErrorCode.PermissionDenied:
                    {
                        exp = new UnauthorizedAccessException("Permission Denied");
                        break;
                    }

                case ErrorCode.NotSupported:
                    {
                        exp = new NotSupportedException("VC NOT supported");
                        break;
                    }

                case ErrorCode.InvalidState:
                    {
                        exp = new InvalidOperationException("Invalid state");
                        break;
                    }

                case ErrorCode.InvalidLanguage:
                    {
                        exp = new InvalidOperationException("Invalid language");
                        break;
                    }

                case ErrorCode.EngineNotFound:
                    {
                        exp = new InvalidOperationException("No available engine");
                        break;
                    }

                case ErrorCode.OperationFailed:
                    {
                        exp = new InvalidOperationException("Operation Failed");
                        break;
                    }

                case ErrorCode.OperationRejected:
                    {
                        exp = new InvalidOperationException("Operation Rejected");
                        break;
                    }

                case ErrorCode.IterationEnd:
                    {
                        exp = new InvalidOperationException("List Reached End");
                        break;
                    }

                case ErrorCode.Empty:
                    {
                        exp = new InvalidOperationException("List Empty");
                        break;
                    }

                case ErrorCode.InProgressToReady:
                    {
                        exp = new InvalidOperationException("Progress to ready is not finished");
                        break;
                    }

                case ErrorCode.InProgressToRecording:
                    {
                        exp = new InvalidOperationException("Progress to recording is not finished");
                        break;
                    }

                case ErrorCode.InProgressToProcessing:
                    {
                        exp = new InvalidOperationException("Progress to processing is not finished");
                        break;
                    }

                case ErrorCode.ServiceReset:
                    {
                        exp = new InvalidOperationException("Service reset");
                        break;
                    }

                default:
                    {
                        exp = new Exception("");
                        break;
                    }
            }

            return exp;
        }
    }
}
