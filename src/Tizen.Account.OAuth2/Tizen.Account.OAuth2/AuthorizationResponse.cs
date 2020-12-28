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
using System.Runtime.InteropServices;

namespace Tizen.Account.OAuth2
{
    /// <summary>
    /// The response containing authroization code from the authorization server.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete]
    public class AuthorizationResponse : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _responseHandle;

        internal AuthorizationResponse(IntPtr handle)
        {
            _responseHandle = handle;
        }

        /// <summary>
        /// Destructor of the AuthorizationResponse class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~AuthorizationResponse()
        {
            Dispose(false);
        }


        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        [Obsolete]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.Response.Destroy(_responseHandle);
            _disposed = true;
        }
    }
}
