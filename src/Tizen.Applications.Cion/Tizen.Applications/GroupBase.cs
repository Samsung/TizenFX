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
    /// An abstract class to represent cion group.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class GroupBase : IDisposable
    {
        private readonly string LogTag = "Tizen.Cion";
        private readonly GroupSafeHandle _handle;

        private Interop.CionGroup.CionGroupPayloadReceivedCb _payloadReceivedCb;
        private Interop.CionGroup.CionGroupLeftCb _leftCb;
        private Interop.CionGroup.CionGroupJoinedCb _joinedCb;

        /// <summary>
        /// Gets the topic of current cion group.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Topic { get; }

        /// <summary>
        /// The constructor of GroupBase class.
        /// </summary>
        /// <param name="topicName">The topic of group.</param>
        /// <remarks>The maximum length of topic name is 512.</remarks>
        /// <exception cref="ArgumentException">Thrown when the given topic name is too long.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public GroupBase(string topicName) : this(topicName, null) { }

        /// <summary>
        /// The constructor of GroupBase class.
        /// </summary>
        /// <param name="topicName">The topic of group.</param>
        /// <param name="security">The security configuration.</param>
        /// <remarks>The maximum length of topic name is 512.</remarks>
        /// <exception cref="ArgumentException">Thrown when the given topic name is too long.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public GroupBase(string topicName, Cion.SecurityInfo security)
        {
            Topic = topicName;

            Cion.SecuritySafeHandle handle = security?._handle;
            Interop.Cion.ErrorCode ret = Interop.CionGroup.CionGroupCreate(out _handle, topicName, handle?.DangerousGetHandle() ?? IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to create group.");
            }

            _payloadReceivedCb = new Interop.CionGroup.CionGroupPayloadReceivedCb(
                (IntPtr group, IntPtr peerInfo, IntPtr payload, IntPtr userData) =>
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
                            throw new ArgumentException("Invalid payload type received.");
                    }
                    OnPayloadReceived(receivedPayload, new PeerInfo(new PeerInfoSafeHandle(peerInfo, false)));
                });
            ret = Interop.CionGroup.CionGroupAddPayloadReceivedCb(_handle, _payloadReceivedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add payload received callback.");
            }

            _joinedCb = new Interop.CionGroup.CionGroupJoinedCb(
                (string name, IntPtr peerInfo, IntPtr userData) =>
                {
                    Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                    if (clone_ret != Interop.Cion.ErrorCode.None)
                    {
                        return;
                    }
                    OnJoined(new PeerInfo(clone));
                });
            ret = Interop.CionGroup.CionGroupAddJoinedCb(_handle, _joinedCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add joined callback.");
            }

            _leftCb = new Interop.CionGroup.CionGroupLeftCb(
                (string name, IntPtr peerInfo, IntPtr userData) =>
                {
                    Interop.Cion.ErrorCode clone_ret = Interop.CionPeerInfo.CionPeerInfoClone(peerInfo, out PeerInfoSafeHandle clone);
                    if (clone_ret != Interop.Cion.ErrorCode.None)
                    {
                        return;
                    }
                    OnLeft(new PeerInfo(clone));
                });
            ret = Interop.CionGroup.CionGroupAddLeftCb(_handle, _leftCb, IntPtr.Zero);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                _handle.Dispose();
                throw CionErrorFactory.GetException(ret, "Failed to add joined callback.");
            }
        }

        /// <summary>
        /// Subscribes the topic.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/d2d.datasharing</privilege>
        /// <exception cref="InvalidOperationException">Thrown when failed to subscribe.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Subscribe()
        {
            Interop.Cion.ErrorCode ret = Interop.CionGroup.CionGroupSubscribe(_handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to subscribe.");
            }
        }

        /// <summary>
        /// Unsubscribes the topic.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Unsubscribe()
        {
            Interop.Cion.ErrorCode ret = Interop.CionGroup.CionGroupUnsubscribe(_handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                Log.Error(LogTag, string.Format("Failed to unsubscribe: {0}", ret));
            }
        }

        /// <summary>
        /// Publishes payload to current group.
        /// </summary>
        /// <param name="payload">The payload to publish.</param>
        /// <exception cref="ArgumentException">Thrown when the payload is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to publish.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Publish(Payload payload)
        {
            Interop.Cion.ErrorCode ret = Interop.CionGroup.CionGroupPublish(_handle, payload?._handle);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to publish payload.");
            }
        }

        /// <summary>
        /// The callback invoked when payload received.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnPayloadReceived(Payload payload, PeerInfo peer);

        /// <summary>
        /// The callback invoked when another peer joined in the current group.
        /// </summary>
        /// <param name="peerInfo">The peer info of joined in the current group.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnJoined(PeerInfo peerInfo);

        /// <summary>
        /// The callback invoked when another peer left from the current group.
        /// </summary>
        /// <param name="peerInfo">The peer info of left from the current group.</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnLeft(PeerInfo peerInfo);

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
        /// Releases all resources used by the GroupBase class.
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
