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
using static Interop.TtsEngine;


namespace Tizen.Uix.TtsEngine
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
                    exp = new InvalidOperationException("I/O Error Occured");
                    break;
                }

                case ErrorCode.InvalidParameter:
                {
                    exp = new ArgumentException("Invalid Parameters Provided");
                    break;
                }

                case ErrorCode.NetworkDown:
                {
                    exp = new InvalidOperationException("Network down(Out of network)");
                    break;
                }

                case ErrorCode.InvalidState:
                {
                    exp = new InvalidOperationException("Invalid state");
                    break;
                }

                case ErrorCode.InvalidVoice:
                {
                    exp = new InvalidOperationException("Invalid Voice");
                    break;
                }

                case ErrorCode.OperationFailed:
                {
                    exp = new InvalidOperationException("Operation Failed");
                    break;
                }

                case ErrorCode.NotSupportedFeature:
                {
                    exp = new InvalidOperationException("Not supported feature");
                    break;
                }

                case ErrorCode.NotSupported:
                {
                    exp = new NotSupportedException("Not supported");
                    break;
                }

                case ErrorCode.PermissionDenied:
                {
                    exp = new UnauthorizedAccessException("Permission Denied");
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
