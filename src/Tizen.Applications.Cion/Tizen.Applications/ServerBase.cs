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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// An abstract class to represent cion server.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class ServerBase : IDisposable
    {
        private const string LogTag = "Tizen.Cion";

        private readonly ServerSafeHandle _handle;
        private Interop.CionServer.CionServerConnectionRequestCb _connectionRequestCb;
        private Interop.CionServer.CionServerConnectionResultCb _connectionResultCb;
        private Interop.CionServer.CionServerDataReceivedCb _dataReceivedCb;
        private Interop.CionServer.CionServerPayloadRecievedCb _payloadRecievedCb;
        private Interop.CionServer.CionServerDisconnectedCb _disconnectedCb;
        private Interop.CionServer.CionServerPayloadAsyncResultCb _payloadAsyncResultCb;
        private Dictionary<Tuple<string, string>, TaskCompletionSource<PayloadAsyncResult>> _tcsDictionary = new Dictionary<Tuple<string, string>, TaskCompletionSource<PayloadAsyncResult>>();

        /// <summary>
        /// Gets the service name of current cion server.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ServiceName { get; }

        /// <summary>
        /// Gets the display name of current cion server.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string DisplayName { get; }

        /// <summary>
        /// The constructor of ServerBase class.
        /// </summary>
        /// <param name="serviceName">The name of service.</param>
        /// <param name="displayName">The display name of service.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception> 
        /// <since_tizen> 9 </since_tizen>
        public ServerBase(string serviceName, string displayName) : this(serviceName, displayName, null) { }

        /// <summary>
        /// The constructor of ServerBase class.
        /// </summary>
        /// <param name="serviceName">The name of service.</param>
        /// <param name="displayName">The display name of service.</param>
        /// <param name="security">The security configuration.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public ServerBase(string serviceName, string displayName, Cion.SecurityInfo security)
        {
            ServiceName = serviceName;
            DisplayName = displayName;

            Cion.SecuritySafeHandle handle = security?._handle;
            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerCreate(out _handle, serviceName, displayName, handle?.DangerousGetHandle() ?? IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to create server handle.");
            }

            _connectionResultCb = new Interop.CionServer.CionServerConnectionResultCb(
                (string service, IntPtr peerInfo, IntPtr result, IntPtr userData) =>
                {
                    Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                    if (clone_ret != Interop.Cion.ErrorCode.None)
                    {
                        Log.Error(LogTag, "Failed to clone peer info.");
                        return;
                    }
                    OnConnectionResult(new PeerInfo(clone), new ConnectionResult(result));
                });
            ret = Interop.CionServer.CionServerAddConnectionResultCb(_handle, _connectionResultCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add connection status changed callback.");
            }

            _dataReceivedCb = new Interop.CionServer.CionServerDataReceivedCb(
                (string service, IntPtr peerInfo, byte[] data, int dataSize, out byte[] returnData, out int returnDataSize, IntPtr userData) =>
                {
                    returnData = OnDataReceived(data, new PeerInfo(new PeerInfoSafeHandle(peerInfo, false)));
                    returnDataSize = returnData.Length;
                });
            ret = Interop.CionServer.CionServerSetDataReceivedCb(_handle, _dataReceivedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to set data received callback.");
            }     

            _payloadRecievedCb = new Interop.CionServer.CionServerPayloadRecievedCb(
                (string service, IntPtr peerInfo, IntPtr payload, int status, IntPtr userData) =>
                {
                    Payload receivedPayload;
                    Interop.CionPayload.CionPayloadGetType(payload, out Interop.CionPayload.PayloadType type);
                    switch (type)
                    {
                        case Interop.CionPayload.PayloadType.Data:
                            receivedPayload = new DataPayload(new PayloadSafeHandle(payload, false));
                            break;
                        case Interop.CionPayload.PayloadType.File:
                            receivedPayload = new FilePayload(new PayloadSafeHandle(payload, false));
                            break;
                        default:
                            Log.Error(LogTag, "Invalid payload type received.");
                            return;
                    }
                    OnPayloadReceived(receivedPayload, new PeerInfo(new PeerInfoSafeHandle(peerInfo, false)), (PayloadTransferStatus)status);
                });
            ret = Interop.CionServer.CionServerAddPayloadReceivedCb(_handle, _payloadRecievedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add payload received callback.");
            }

            _disconnectedCb = new Interop.CionServer.CionServerDisconnectedCb(
                (string service, IntPtr peerInfo, IntPtr userData) =>
                {
                    OnDisconnected(new PeerInfo(new PeerInfoSafeHandle(peerInfo, false)));
                });
            ret = Interop.CionServer.CionServerAddDisconnectedCb(_handle, _disconnectedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add disconnected callback.");
            }
        }

        /// <summary>
        /// Starts server and listens for requests from cion clients.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the listen operation is already in progress.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Listen()
        {
            if (_connectionRequestCb == null)
            {
                Interop.CionServer.CionServerConnectionRequestCb cb = new Interop.CionServer.CionServerConnectionRequestCb(
                    (serviceName, peerInfo, userData) =>
                    {
                        Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                        if (clone_ret != Interop.Cion.ErrorCode.None)
                        {
                            Log.Error(LogTag, "Failed to clone peer info");
                            return;
                        }
                        OnConnentionRequest(new PeerInfo(clone));
                    });
                _connectionRequestCb = cb;
            }

            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerListen(_handle, _connectionRequestCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to listen server.");
            }
        }

        /// <summary>
        /// Stops the listen operation.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the server is not listening.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Stop()
        {
            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerStop(_handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to stop server.");
            }
        }

        /// <summary>
        /// Disconnects with the peer.
        /// </summary>
        /// <param name="peerInfo">The peer to disconnect.</param>
        /// <exception cref="ArgumentException">Thrown when the given peer info is invalid.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Disconnect(PeerInfo peerInfo)
        {
            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerDisconnect(_handle, peerInfo?._handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to stop server.");
            }
        }

        /// <summary>
        /// Sends the payload to a peer asynchronously.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        /// <param name="peerInfo">The peer to send payload.</param>
        /// <exception cref="ArgumentException">Thrown when the payload is not valid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is no such connected cion client.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Task<PayloadAsyncResult> SendPayloadAsync(Payload payload, PeerInfo peerInfo)
        {
            if (payload?.Id.Length == 0 || peerInfo?.UUID.Length == 0)
            {
                throw new ArgumentException("Payload or peerinfo is invalid.");
            }

            TaskCompletionSource<PayloadAsyncResult> tcs = new TaskCompletionSource<PayloadAsyncResult>();
            _tcsDictionary[Tuple.Create(payload.Id, peerInfo.UUID)] = tcs;

            if (_payloadAsyncResultCb == null)
            {
                Interop.CionServer.CionServerPayloadAsyncResultCb cb = new Interop.CionServer.CionServerPayloadAsyncResultCb(
                    (IntPtr result, IntPtr userData) =>
                    {
                        PayloadAsyncResult resultPayload = new PayloadAsyncResult(new PayloadAsyncResultSafeHandle(result, false));
                        TaskCompletionSource<PayloadAsyncResult> tcsToReturn = _tcsDictionary[Tuple.Create(resultPayload.PayloadId, resultPayload.PeerInfo.UUID)];
                        _tcsDictionary.Remove(Tuple.Create(resultPayload.PayloadId, resultPayload.PeerInfo.UUID));
                        Interop.Cion.ErrorCode clone_ret = Interop.CionPayloadAsyncResult.CionPayloadAsyncResultClone(result, out PayloadAsyncResultSafeHandle clone);
                        if (clone_ret != Interop.Cion.ErrorCode.None)
                        {
                            Log.Error(LogTag, "Failed to clone result.");
                            tcsToReturn.SetResult(new PayloadAsyncResult());
                            return;
                        }
                        tcsToReturn.SetResult(new PayloadAsyncResult(clone));
                    });
                _payloadAsyncResultCb = cb;
            }

            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerSendPayloadAsync(_handle, peerInfo?._handle, payload?._handle, _payloadAsyncResultCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to send payload.");
            }

            return tcs.Task;
        }

        /// <summary>
        /// Sends the payload to all of connected peer asynchronously.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        /// <since_tizen> 9 </since_tizen>
        public void SendPayloadAsync(Payload payload)
        {
            var peerList = GetConnectedPeerList();
            foreach (var peer in peerList)
            {
                SendPayloadAsync(payload, peer);
            }
        }

        /// <summary>
        /// Accepts the connection request from the peer.
        /// </summary>
        /// <param name="peerInfo">The peer to accept the connection request.</param>
        /// <since_tizen> 9 </since_tizen>
        public void Accept(PeerInfo peerInfo)
        {
            Interop.CionServer.CionServerAccept(_handle, peerInfo?._handle);
        }

        /// <summary>
        /// Rejects the connection request from the peer.
        /// </summary>
        /// <param name="peerInfo">The peer to reject the connection request.</param>
        /// <param name="reason">The reason why reject the connection request.</param>
        /// <since_tizen> 9 </since_tizen>
        public void Reject(PeerInfo peerInfo, string reason)
        {
            Interop.CionServer.CionServerReject(_handle, peerInfo?._handle, reason);
        }

        /// <summary>
        /// Gets connected peers.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception> 
        IEnumerable<PeerInfo> GetConnectedPeerList()
        {
            List<PeerInfo> peerInfoList = new List<PeerInfo>();
            Interop.Cion.ErrorCode ret = Interop.CionServer.CionServerForeachConnectedPeerInfo(_handle, (peer, userData) =>
            {
                Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peer, out PeerInfoSafeHandle clone);
                if (clone_ret != Interop.Cion.ErrorCode.None)
                {
                    throw CionErrorFactory.GetException(clone_ret, "Failed to clone peer info.");
                }
                peerInfoList.Add(new PeerInfo(clone));
            }, IntPtr.Zero);
            return peerInfoList;
        }

        /// <summary>
        /// The result callback of connection request.
        /// </summary>
        /// <param name="peerInfo">The peer info of the cion client.</param>
        /// <param name="result">The result of the connection.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnConnectionResult(PeerInfo peerInfo, ConnectionResult result);

        /// <summary>
        /// The callback invoked when received data.
        /// </summary>
        /// <param name="data">The received data.</param>
        /// <param name="peerInfo">The peer info of the cion client.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract byte[] OnDataReceived(byte[] data, PeerInfo peerInfo);

        /// <summary>
        /// The callback invoked when received payload.
        /// </summary>
        /// <param name="data">The received data.</param>
        /// <param name="peerInfo">The peer info of the cion client.</param>
        /// <param name="status">The status of payload transfer.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnPayloadReceived(Payload data, PeerInfo peerInfo, PayloadTransferStatus status);

        /// <summary>
        /// The callback invoked when connection requested from the cion client.
        /// </summary>
        /// <param name="peerInfo">The peer info of the cion client.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnConnentionRequest(PeerInfo peerInfo);

        /// <summary>
        /// The callback invoked when disconnected with cion client.
        /// </summary>
        /// <param name="peerInfo">The peer info of the cion client.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnDisconnected(PeerInfo peerInfo);

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
                    _handle.Dispose();
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ServerBase class.
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
