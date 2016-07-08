using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Messaging.Push
{
    class PushExceptionFactory
    {
        internal static Exception CreateResponseException(Interop.Push.ServiceError result)
        {
            Exception exp;
            switch (result)
            {
                case Interop.Push.ServiceError.OutOfMemory:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.OutOfMemory");
                    exp = new InvalidOperationException("Memory Not Sufficient for the current operation");
                    break;
                }
                case Interop.Push.ServiceError.InvalidParameter:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.InvalidParameter");
                    exp = new InvalidOperationException("The Parameter Passed was Invalid or Invalid Operation Intented");
                    break;
                }
                case Interop.Push.ServiceError.NotConnected:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.NotConnected");
                    exp = new InvalidOperationException("Not Connected to Server");
                    break;
                }
                case Interop.Push.ServiceError.NoData:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.NoData");
                    exp = new InvalidOperationException("No Data");
                    break;
                }
                case Interop.Push.ServiceError.OpearationFailed:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.OpearationFailed");
                    exp = new InvalidOperationException("Operation Failed");
                    break;
                }
                case Interop.Push.ServiceError.PermissionDenied:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.PermissionDenied");
                    exp = new InvalidOperationException("Permission Denied");
                    break;
                }
                case Interop.Push.ServiceError.NotSupported:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Interop.Push.ServiceError.NotSupported");
                    exp = new InvalidOperationException("Not Supported");
                    break;
                }
                default:
                {
                    Tizen.Log.Error(Interop.Push.LogTag, "Creating Exception for Default case for error code " + result);
                    exp = new Exception();
                    break;
                }
            }
            return exp;
        }
    }
}
