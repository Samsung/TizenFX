/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents response from a resource.
    /// </summary>
    public class Response : IDisposable
    {
        private bool _disposed = false;

        ~Response()
        {
            Dispose(false);
        }

        /// <summary>
        /// Result corresponding to a request
        /// </summary>
        public ResponseCode Result { get; set; }

        /// <summary>
        /// Representation of the resource
        /// </summary>
        public Representation Representation { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal bool Send(IntPtr requestHandle)
        {
            IntPtr responseHandle = IntPtr.Zero;
            int ret = Interop.IoTConnectivity.Server.Response.Create(requestHandle, out responseHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send response");
                return false;
            }

            ret = Interop.IoTConnectivity.Server.Response.SetResult(responseHandle, (int)Result);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send response");
                Interop.IoTConnectivity.Server.Response.Destroy(responseHandle);
                return false;
            }

            if (Representation != null)
            {
                ret = Interop.IoTConnectivity.Server.Response.SetRepresentation(responseHandle, Representation._representationHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send response");
                    Interop.IoTConnectivity.Server.Response.Destroy(responseHandle);
                    return false;
                }
            }

            ret = Interop.IoTConnectivity.Server.Response.Send(responseHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send response");
                Interop.IoTConnectivity.Server.Response.Destroy(responseHandle);
                return false;
            }

            Interop.IoTConnectivity.Server.Response.Destroy(responseHandle);
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
            }

            _disposed = true;
        }
    }
}
