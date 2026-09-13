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
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(SttError err)
        {
            Tizen.Log.Error(LogTag, $"Error {err}");
            return err switch
            {
                SttError.OutOfMemory => new OutOfMemoryException("Out Of Memory"),
                SttError.IoError => new InvalidOperationException("I/O Error Occurred"),
                SttError.InvalidParameter => new ArgumentException("Invalid Parameters Provided"),
                SttError.TimedOut => new TimeoutException("No answer from the STT service"),
                SttError.OutOfNetwork => new InvalidOperationException("Network is down"),
                SttError.PermissionDenied => new UnauthorizedAccessException("Permission Denied"),
                SttError.NotSupported => new NotSupportedException("STT NOT supported"),
                SttError.InvalidState => new InvalidOperationException("Invalid state"),
                SttError.InvalidLanguage => new InvalidOperationException("Invalid language"),
                SttError.EngineNotFound => new InvalidOperationException("No available engine"),
                SttError.OperationFailed => new InvalidOperationException("Operation Failed"),
                SttError.NotSupportedFeature => new InvalidOperationException("Not supported feature of current engine"),
                SttError.RecordingTimedOut => new InvalidOperationException("Recording timed out"),
                SttError.NoSpeech => new InvalidOperationException("No speech while recording"),
                SttError.InProgressToReady => new InvalidOperationException("Progress to ready is not finished"),
                SttError.InProgressToRecording => new InvalidOperationException("Progress to recording is not finished"),
                SttError.InProgressToProcessing => new InvalidOperationException("Progress to processing is not finished"),
                SttError.ServiceReset => new InvalidOperationException("Service reset"),
                _ => new Exception(""),
            };
        }
    }
}
