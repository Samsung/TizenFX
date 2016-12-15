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
            Tizen.Log.Error(LogTag, "Error " + err);
            Exception exp;
            switch (err)
            {
                case SttError.OutOfMemory:
                    {
                        exp = new InvalidOperationException("Out Of Memory");
                        break;
                    }

                case SttError.IoError:
                    {
                        exp = new InvalidOperationException("I/O Error Occured");
                        break;
                    }

                case SttError.InvalidParameter:
                    {
                        exp = new ArgumentException("Invalid Parameters Provided");
                        break;
                    }

                case SttError.TimedOut:
                    {
                        exp = new InvalidOperationException("No answer from the STT service");
                        break;
                    }

                case SttError.OutOfNetwork:
                    {
                        exp = new InvalidOperationException("Network is down");
                        break;
                    }

                case SttError.PermissionDenied:
                    {
                        exp = new InvalidOperationException("Permission Denied");
                        break;
                    }

                case SttError.NotSupported:
                    {
                        exp = new InvalidOperationException("STT NOT supported");
                        break;
                    }

                case SttError.InvalidState:
                    {
                        exp = new InvalidOperationException("Invalid state");
                        break;
                    }

                case SttError.InvalidLanguage:
                    {
                        exp = new InvalidOperationException("Invalid language");
                        break;
                    }

                case SttError.EngineNotFound:
                    {
                        exp = new InvalidOperationException("No available engine");
                        break;
                    }

                case SttError.OperationFailed:
                    {
                        exp = new InvalidOperationException("Operation Failed");
                        break;
                    }

                case SttError.NotSupportedFeature:
                    {
                        exp = new InvalidOperationException("Not supported feature of current engine");
                        break;
                    }

                case SttError.RecordingTimedOut:
                    {
                        exp = new InvalidOperationException("Recording timed out");
                        break;
                    }

                case SttError.NoSpeech:
                    {
                        exp = new InvalidOperationException("No speech while recording");
                        break;
                    }

                case SttError.InProgressToReady:
                    {
                        exp = new InvalidOperationException("Progress to ready is not finished");
                        break;
                    }

                case SttError.InProgressToRecording:
                    {
                        exp = new InvalidOperationException("Progress to recording is not finished");
                        break;
                    }

                case SttError.InProgressToProcessing:
                    {
                        exp = new InvalidOperationException("Progress to processing is not finished");
                        break;
                    }

                case SttError.ServiceReset:
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
