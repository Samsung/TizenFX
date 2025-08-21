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
    /// Class respresenting request to a resource.
    /// It provides APIs to manage client's request.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class Request : IDisposable
    {
        private bool _disposed = false;

        internal Request()
        {
        }

        /// <summary>
        /// Destructor of the Request class.
        /// </summary>
        ~Request()
        {
            Dispose(false);
        }

        /// <summary>
        /// The host address of the request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The host address of the request.</value>
        [Obsolete("Deprecated since API level 13")]
        public string HostAddress { get; internal set; }

        /// <summary>
        /// The representation of the request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The representation of the request.</value>
        [Obsolete("Deprecated since API level 13")]
        public Representation Representation { get; internal set; }

        /// <summary>
        /// The query of the request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The query of the request.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourceQuery Query { get; internal set; }

        /// <summary>
        /// The options related to the request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The options related to the request.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourceOptions Options { get; internal set; }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
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
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Representation?.Dispose();
                Query?.Dispose();
                Options?.Dispose();
            }

            _disposed = true;
        }
    }
}
