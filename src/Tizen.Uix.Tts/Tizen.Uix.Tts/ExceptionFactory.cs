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
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(TtsError err)
        {
            Tizen.Log.Error(LogTag, "Error " + err);
            Exception exp;
            switch (err)
            {
                case TtsError.OutOfMemory:
                    {
                        exp = new OutOfMemoryException("Out Of Memory");
                        break;
                    }

                case TtsError.IoError:
                    {
                        exp = new InvalidOperationException("I/O Error Occurred");
                        break;
                    }

                case TtsError.InvalidParameter:
                    {
                        exp = new ArgumentException("Invalid Parameters Provided");
                        break;
                    }

                case TtsError.TimedOut:
                    {
                        exp = new TimeoutException("No answer from the TTS service");
                        break;
                    }

                case TtsError.OutOfNetwork:
                    {
                        exp = new InvalidOperationException("Network is down");
                        break;
                    }

                case TtsError.PermissionDenied:
                    {
                        exp = new UnauthorizedAccessException("Permission Denied");
                        break;
                    }

                case TtsError.NotSupported:
                    {
                        exp = new NotSupportedException("TTS NOT supported");
                        break;
                    }

                case TtsError.InvalidState:
                    {
                        exp = new InvalidOperationException("Invalid state");
                        break;
                    }

                case TtsError.InvalidVoice:
                    {
                        exp = new InvalidOperationException("Invalid Voice");
                        break;
                    }

                case TtsError.EngineNotFound:
                    {
                        exp = new InvalidOperationException("No available engine");
                        break;
                    }

                case TtsError.OperationFailed:
                    {
                        exp = new InvalidOperationException("Operation Failed");
                        break;
                    }

                case TtsError.AudioPolicyBlocked:
                    {
                        exp = new InvalidOperationException("AudioPolicyBlocked");
                        break;
                    }

                case TtsError.NotSupportedFeature:
                    {
                        exp = new InvalidOperationException("Feature NotSupported");
                        break;
                    }

                case TtsError.ServiceReset:
                    {
                        exp = new InvalidOperationException("Service Reset");
                        break;
                    }

                case TtsError.ScreenReaderOff:
                    {
                        exp = new InvalidOperationException("Screen reader off");
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
