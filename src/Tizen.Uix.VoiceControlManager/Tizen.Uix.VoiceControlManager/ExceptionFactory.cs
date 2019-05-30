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
            switch (err)
            {
                case ErrorCode.OutOfMemory:
                    return new InvalidOperationException("Out Of Memory");

                case ErrorCode.IoError:
                    return new InvalidOperationException("I/O Error Occurred");

                case ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid Parameters Provided");

                case ErrorCode.TimedOut:
                    return new TimeoutException("No answer from service");

                case ErrorCode.RecorderBusy:
                    return new InvalidOperationException("Recorder is Busy ");

                case ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied");

                case ErrorCode.NotSupported:
                    return new NotSupportedException("VC NOT supported");

                case ErrorCode.InvalidState:
                    return new InvalidOperationException("Invalid state");

                case ErrorCode.InvalidLanguage:
                    return new InvalidOperationException("Invalid language");

                case ErrorCode.EngineNotFound:
                    return new InvalidOperationException("No available engine");

                case ErrorCode.OperationFailed:
                    return new InvalidOperationException("Operation Failed");

                case ErrorCode.OperationRejected:
                    return new InvalidOperationException("Operation Rejected");

                case ErrorCode.IterationEnd:
                    return new InvalidOperationException("List Reached End");

                case ErrorCode.Empty:
                    return new InvalidOperationException("List Empty");

                case ErrorCode.InProgressToReady:
                    return new InvalidOperationException("Progress to ready is not finished");

                case ErrorCode.InProgressToRecording:
                    return new InvalidOperationException("Progress to recording is not finished");

                case ErrorCode.InProgressToProcessing:
                    return new InvalidOperationException("Progress to processing is not finished");

                case ErrorCode.ServiceReset:
                    return new InvalidOperationException("Service reset");
            }
            return new InvalidOperationException("Unknown error : {err.ToString()}");
        }
    }
}
