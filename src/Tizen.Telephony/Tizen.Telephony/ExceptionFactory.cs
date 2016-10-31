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

namespace Tizen.Telephony
{
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(Interop.Telephony.TelephonyError err)
        {
            Tizen.Log.Error(Interop.Telephony.LogTag, "Error " + err);
            Exception exp;
            switch (err)
            {
                case Interop.Telephony.TelephonyError.InvalidParameter:
                    {
                        exp = new ArgumentException("Invalid Parameters Provided");
                        break;
                    }

                case Interop.Telephony.TelephonyError.NotSupported:
                    {
                        exp = new InvalidOperationException("Not Supported");
                        break;
                    }

                case Interop.Telephony.TelephonyError.OperationFailed:
                    {
                        exp = new InvalidOperationException("Operation Failed");
                        break;
                    }

                case Interop.Telephony.TelephonyError.OutOfMemory:
                    {
                        exp = new InvalidOperationException("Out Of Memory");
                        break;
                    }

                case Interop.Telephony.TelephonyError.PermissionDenied:
                    {
                        exp = new InvalidOperationException("Permission Denied");
                        break;
                    }

                case Interop.Telephony.TelephonyError.SIMNotAvailable:
                    {
                        exp = new InvalidOperationException("SIM is Not Available");
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
