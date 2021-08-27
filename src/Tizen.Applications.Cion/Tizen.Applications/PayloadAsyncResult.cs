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

namespace Tizen.Applications
{
    /// <summary>
    /// A class to represent result of payload.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PayloadAsyncResult : IDisposable
    {
        private readonly string LogTag = "Tizen.Cion";
        internal PayloadAsyncResultSafeHandle _handle;

        internal PayloadAsyncResult(PayloadAsyncResultSafeHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the result of payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public PayloadAsyncResultCode Result
        {
            get
            {
                int code;
                Interop.Cion.ErrorCode ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetResult(_handle, out code);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    return PayloadAsyncResultCode.Error;
                }
                return (PayloadAsyncResultCode)code;
            }
        }

        /// <summary>
        /// Gets the peer info of payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public PeerInfo PeerInfo
        {
            get
            {
                IntPtr peer;
                Interop.Cion.ErrorCode ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetPeerInfo(_handle, out peer);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Fail to get peerinfo from the AsyncResult");
                    return null;
                }
                return new PeerInfo(new PeerInfoSafeHandle(peer, true));
            }
        }

        /// <summary>
        /// Gets the payload id.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string PayloadId
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetPayloadID(_handle, out string payloadId);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Fail to get payload Id : " + ret);
                    return "";
                }
                return payloadId;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
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
        /// Finalizer of the PayloadAsyncResult class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        ~PayloadAsyncResult()
        {
           Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the PayloadAsyncResult class.
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
