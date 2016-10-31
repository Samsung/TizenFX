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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Messaging.Push
{
    class PushExceptionFactory
    {
        internal static Exception CreateResponseException(Interop.PushClient.ServiceError result)
        {
            Exception exp;
            switch (result)
            {
                case Interop.PushClient.ServiceError.OutOfMemory:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.OutOfMemory");
                    exp = new InvalidOperationException("Memory Not Sufficient for the current operation");
                    break;
                }
                case Interop.PushClient.ServiceError.InvalidParameter:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.InvalidParameter");
                    exp = new InvalidOperationException("The Parameter Passed was Invalid or Invalid Operation Intented");
                    break;
                }
                case Interop.PushClient.ServiceError.NotConnected:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.NotConnected");
                    exp = new InvalidOperationException("Not Connected to Server");
                    break;
                }
                case Interop.PushClient.ServiceError.NoData:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.NoData");
                    exp = new InvalidOperationException("No Data");
                    break;
                }
                case Interop.PushClient.ServiceError.OpearationFailed:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.OpearationFailed");
                    exp = new InvalidOperationException("Operation Failed");
                    break;
                }
                case Interop.PushClient.ServiceError.PermissionDenied:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.PermissionDenied");
                    exp = new InvalidOperationException("Permission Denied");
                    break;
                }
                case Interop.PushClient.ServiceError.NotSupported:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.PushClient.ServiceError.NotSupported");
                    exp = new InvalidOperationException("Not Supported");
                    break;
                }
                default:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Creating Exception for Default case for error code " + result);
                    exp = new Exception();
                    break;
                }
            }
            return exp;
        }
    }
}
