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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications.Cion
{
    /// <summary>
    /// An abstract class to represent cion client.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class ClientBase : IDisposable
    {
        private readonly string LogTag = "Tizen.Cion";
        private readonly ClientSafeHandle _handle;

        private PeerInfo _peer;

        private Interop.CionClient.CionClientDiscoveredCb _discoveredCb;
        private Interop.CionClient.CionClientConnectionResultCb _connectionResultCb;
        private Interop.CionClient.CionClientPayloadRecievedCb _payloadRecievedCb;
        private Interop.CionClient.CionClientDisconnectedCb _disconnectedCb;
        private Interop.CionClient.CionClientPayloadAsyncResultCb _payloadAsyncResultCb;
        private Dictionary<string, TaskCompletionSource<PayloadAsyncResult>> _tcsDictionary = new Dictionary<string, TaskCompletionSource<PayloadAsyncResult>>();

        /// <summary>
        /// Gets the service name of current cion client.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ServiceName { get; }

        /// <summary>
        /// Gets peer info of connected cion server.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public PeerInfo PeerInfo
        {
            get
            {
                return _peer;
            }
        }

        /// <summary>
        /// The constructor of ClientBase class.
        /// </summary>
        /// <param name="serviceName">The name of service.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception> 
        /// <since_tizen> 9 </since_tizen>
        public ClientBase(string serviceName) : this(serviceName, null) { }

        /// <summary>
        /// The constructor of ClientBase class.
        /// </summary>
        /// <param name="serviceName">The name of service.</param>
        /// <param name="security">The security configuration.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception> 
        /// <since_tizen> 9 </since_tizen>
        public ClientBase(string serviceName, Cion.SecurityInfo security)
        {
            ServiceName = serviceName;

            SecuritySafeHandle handle = security?._handle;
            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientCreate(out _handle, serviceName, handle?.DangerousGetHandle() ?? IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to create client.");
            }

            _connectionResultCb = new Interop.CionClient.CionClientConnectionResultCb(
                (string service, IntPtr peerInfo, IntPtr result, IntPtr userData) =>
                {
                    Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                    if (clone_ret != Interop.Cion.ErrorCode.None)
                    {
                        Log.Error(LogTag, string.Format("Failed to clone peer info."));
                        return;
                    }

                    PeerInfo peer = new PeerInfo(clone);
                    ConnectionResult connectionResult = new ConnectionResult(result);
                    if (connectionResult.Status == ConnectionStatus.OK)
                    {
                        _peer = peer;
                    }

                    OnConnectionResult(peer, connectionResult);
                });
            ret = Interop.CionClient.CionClientAddConnectionResultCb(_handle, _connectionResultCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add connection status changed callback.");
            }

            _payloadRecievedCb = new Interop.CionClient.CionClientPayloadRecievedCb(
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
                    OnPayloadReceived(receivedPayload, (PayloadTransferStatus)status);
                });
            ret = Interop.CionClient.CionClientAddPayloadReceivedCb(_handle, _payloadRecievedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add payload received callback.");
            }

            _disconnectedCb = new Interop.CionClient.CionClientDisconnectedCb(
                (string service, IntPtr peerInfo, IntPtr userData) =>
                {
                    Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                    if (clone_ret != Interop.Cion.ErrorCode.None)
                    {
                        Log.Error(LogTag, string.Format("Failed to clone peer info."));
                        return;
                    }
                    OnDisconnected(new PeerInfo(clone));
                });
            ret = Interop.CionClient.CionClientAddDisconnectedCb(_handle, _disconnectedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add disconnected callback.");
            }
        }

        /// <summary>
        /// Starts discovering cion servers.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the discovery operation is already in progress.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <privilege>http://tizen.org/privilege/d2d.datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <since_tizen> 9 </since_tizen>
        public void TryDiscovery()
        {
            Log.Error(LogTag, string.Format("Try discovery start"));

            if (_discoveredCb == null)
            {
                Interop.CionClient.CionClientDiscoveredCb cb = new Interop.CionClient.CionClientDiscoveredCb(
                    (string serviceName, IntPtr peerInfo, IntPtr userData) =>
                    {
                        Log.Error(LogTag, string.Format("callback called !!"));

                        Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                        if (clone_ret != Interop.Cion.ErrorCode.None)
                        {
                            Log.Error(LogTag, "Failed to clone peer info.");
                            return;
                        }
                        OnDiscovered(new PeerInfo(clone));
                    });
                _discoveredCb = cb;
            }

            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientTryDiscovery(_handle, _discoveredCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to try discovery.");
            }
        }

        /// <summary>
        /// Stops discovering.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the client is not discovering.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void StopDiscovery()
        {
            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientStopDiscovery(_handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to stop discovery.");
            }
        }

        /// <summary>
        /// Connects with the cion server.
        /// </summary>
        /// <param name="peer">The peer to connect.</param>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <privilege>http://tizen.org/privilege/d2d.datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <since_tizen> 9 </since_tizen>
        public void Connect(PeerInfo peer)
        {
            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientConnect(_handle, peer?._handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to connect.");
            }
        }

        /// <summary>
        /// Disconnects from the cion server.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Disconnect()
        {
            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientDisconnect(_handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to disconnect.");
            }
            _peer = null;
        }

        /// <summary>
        /// Sends data synchronously to the connected cion server.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="timeout">The timeout of sending operation.</param>
        /// <exception cref="ArgumentException">Thrown when the given data is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is no connected cion server.</exception>
        /// <since_tizen> 9 </since_tizen>
        public byte[] SendData(byte[] data, int timeout)
        {
            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientSendData(_handle, data, data?.Length ?? -1, timeout, out IntPtr returnDataPtr, out int returnDataSize);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to send data.");
            }
            byte[] returnData = new byte[returnDataSize];
            Marshal.Copy(returnDataPtr, returnData, 0, returnDataSize);
            Log.Info(LogTag, string.Format("Returned data size: {0}", returnDataSize));

            return returnData;
        }

        /// <summary>
        /// Sends payload asynchronously to the connected cion server.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        /// <exception cref="ArgumentException">Thrown when the payload is not valid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is no connected cion server.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Task<PayloadAsyncResult> SendPayloadAsync(Payload payload)
        {
            if (payload == null || payload.Id.Length == 0)
            {
                throw new ArgumentException("Payload is invalid.");
            }

            TaskCompletionSource<PayloadAsyncResult> tcs = new TaskCompletionSource<PayloadAsyncResult>();
            _tcsDictionary[payload.Id] = tcs;

            if (_payloadAsyncResultCb == null)
            {
                Interop.CionClient.CionClientPayloadAsyncResultCb cb = new Interop.CionClient.CionClientPayloadAsyncResultCb(
                    (IntPtr result, IntPtr userData) =>
                    {
                        TaskCompletionSource<PayloadAsyncResult> tcsToReturn = _tcsDictionary[payload.Id];
                        PayloadAsyncResult resultPayload = null;
                        try
                        {
                            resultPayload = PayloadAsyncResult.CreateFromHandle(result);
                        }
                        catch (Exception e)
                        {
                            Log.Error(LogTag, string.Format("Failed to create PayloadAsyncResult from result handle: {0}.", e.Message));
                            tcsToReturn.SetException(e);
                            return;
                        }
                        tcsToReturn.SetResult(resultPayload);
                        _tcsDictionary.Remove(resultPayload.PayloadId);
                    });
                _payloadAsyncResultCb = cb;
            }

            Interop.Cion.ErrorCode ret = Interop.CionClient.CionClientSendPayloadAsync(_handle, payload?._handle, _payloadAsyncResultCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to send payload.");
            }

            return tcs.Task;
        }

        /// <summary>
        /// The result callback of connection request.
        /// </summary>
        /// <param name="peerInfo">The peer info of the cion server.</param>
        /// <param name="result">The result of the connection.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnConnectionResult(PeerInfo peerInfo, ConnectionResult result);

        /// <summary>
        /// The callback invoked when received payload.
        /// </summary>
        /// <param name="payload">The received payload.</param>
        /// <param name="status">The status of sent payload.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnPayloadReceived(Payload payload, PayloadTransferStatus status);

        /// <summary>
        /// The callback invoked when the cion server discovered.
        /// </summary>
        /// <param name="peerInfo">The peer info of discovered cion server.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnDiscovered(PeerInfo peerInfo);

        /// <summary>
        /// The callback invoked when disconnected with cion client.
        /// </summary>
        /// <param name="peerInfo">The peer info of the cion server.</param>
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
        /// Releases all resources used by the ClientBase class.
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
