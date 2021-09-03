/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.Cion
{
    /// <summary>
    /// A class to represent security info.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class SecurityInfo : IDisposable
    {
        private readonly string LogTag = "Tizen.Cion";
        internal SecuritySafeHandle _handle = null;

        /// <summary>
        /// The constructor of SecurityInfo class.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception> 
        /// <since_tizen> 9 </since_tizen>
        public SecurityInfo()
        {
            Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecurityCreate(out _handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to create security info.");
            }
        }

        /// <summary>
        /// Gets the CA cert path.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the CA path is invalid.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string CaPath
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecurityGetCaPath(_handle, out string caPath);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get CA path.");
                    return "";
                }
                return caPath;
            }

            set
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecuritySetCaPath(_handle, value);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    throw CionErrorFactory.GetException(ret, "Failed to set CA path.");
                }
            }
        }

        /// <summary>
        /// Gets the cert path.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the cert path is invalid.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string CertPath
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecurityGetCertPath(_handle, out string certPath);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get cert path.");
                    return "";
                }
                return certPath;
            }

            set
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecuritySetCertPath(_handle, value);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    throw CionErrorFactory.GetException(ret, "Failed to set cert path.");
                }
            }
        }

        /// <summary>
        /// Gets the private key path.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the private key path is invalid.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string PrivateKeyPath
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecurityGetPrivateKeyPath(_handle, out string privateKeyPath);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get private key path.");
                    return "";
                }
                return privateKeyPath;
            }

            set
            {
                Interop.Cion.ErrorCode ret = Interop.CionSecurity.CionSecuritySetPrivateKeyPath(_handle, value);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    throw CionErrorFactory.GetException(ret, "Failed to set private key path.");
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                _handle.Dispose();
                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the SecurityInfo class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        ~SecurityInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the SecurityInfo class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
