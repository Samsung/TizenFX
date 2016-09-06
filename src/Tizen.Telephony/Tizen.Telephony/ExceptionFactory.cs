/// Copyright 2016 by Samsung Electronics, Inc.
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.
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
