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
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.OutOfMemory");
                    exp = new InvalidOperationException("Memory Not Sufficient for the current operation");
                    break;
                }
                case Interop.PushClient.ServiceError.InvalidParameter:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.InvalidParameter");
                    exp = new InvalidOperationException("The Parameter Passed was Invalid or Invalid Operation Intented");
                    break;
                }
                case Interop.PushClient.ServiceError.NotConnected:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.NotConnected");
                    exp = new InvalidOperationException("Not Connected to Server");
                    break;
                }
                case Interop.PushClient.ServiceError.NoData:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.NoData");
                    exp = new InvalidOperationException("No Data");
                    break;
                }
                case Interop.PushClient.ServiceError.OpearationFailed:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.OpearationFailed");
                    exp = new InvalidOperationException("Operation Failed");
                    break;
                }
                case Interop.PushClient.ServiceError.PermissionDenied:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.PermissionDenied");
                    exp = new InvalidOperationException("Permission Denied");
                    break;
                }
                case Interop.PushClient.ServiceError.NotSupported:
                {
                    Tizen.Log.Error(Interop.PushClient.LogTag, "Interop.Push.ServiceError.NotSupported");
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
