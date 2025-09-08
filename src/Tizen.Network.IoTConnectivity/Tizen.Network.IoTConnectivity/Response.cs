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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents response from a resource.
    /// It provides APIs to manage response.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class Response : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Constructor of Response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <example><code>
        /// Response response = new Response();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public Response() { }

        /// <summary>
        /// Destructor of the Response class.
        /// </summary>
        ~Response()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets the result from/into the response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The result from/into the response.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResponseCode Result { get; set; }

        /// <summary>
        /// Gets or sets the representation from/into the response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The representation from/into the response.</value>
        [Obsolete("Deprecated since API level 13")]
        public Representation Representation { get; set; }

        /// <summary>
        /// Gets or sets the options from/into the response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The options from/into the response.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourceOptions Options { get; set; }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
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

            if (Options != null)
            {
                ret = Interop.IoTConnectivity.Server.Response.SetOptions(responseHandle, Options._resourceOptionsHandle);
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

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        [Obsolete("Deprecated since API level 13")]
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
