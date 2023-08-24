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
    /// A class to represent result of payload.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PayloadAsyncResult : IDisposable
    {
        private PayloadAsyncResult(PayloadAsyncResultCode result, PeerInfo peer, string payloadId)
        {
            Result = result;
            PeerInfo = peer;
            PayloadId = payloadId;
        }

        internal static PayloadAsyncResult CreateFromHandle(IntPtr handle)
        {
            Interop.Cion.ErrorCode ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetResult(handle, out int code);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Fail to get result code from the AsyncResult");
            }

            ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetPayloadID(handle, out string payloadId);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Fail to get payload id from the AsyncResult");
            }

            ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultGetPeerInfo(handle, out IntPtr peer);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Fail to get peerinfo from the AsyncResult");
            }
            ret = Interop.CionPeerInfo.CionPeerInfoClone(peer, out PeerInfoSafeHandle clone);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to clone peer info.");
            }

            return new PayloadAsyncResult((PayloadAsyncResultCode)code, new PeerInfo(clone), payloadId);
        }

        /// <summary>
        /// Gets the result of payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public PayloadAsyncResultCode Result { get; }

        /// <summary>
        /// Gets the peer info of payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public PeerInfo PeerInfo { get; }

        /// <summary>
        /// Gets the payload id.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string PayloadId { get; }

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
                    PeerInfo?.Dispose();
                }
                disposedValue = true;
            }
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
