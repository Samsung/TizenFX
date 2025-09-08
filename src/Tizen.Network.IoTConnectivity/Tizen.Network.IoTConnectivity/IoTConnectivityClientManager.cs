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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// IoT connectivity client manager consists of client side APIs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
    public static class IoTConnectivityClientManager
    {
        /// <summary>
        /// The IP Address for multicast.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public const string MulticastAddress = null;

        private static int s_presenceListenerId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.Presence.PresenceCallback> s_presenceCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.Presence.PresenceCallback>();
        private static Dictionary<IntPtr, IntPtr> s_presenceHandlesMap = new Dictionary<IntPtr, IntPtr>();

        private static int s_requestId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.ResourceFinder.FoundResourceCallback> s_resourceFoundCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.ResourceFinder.FoundResourceCallback>();
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.DeviceInformation.DeviceInformationCallback> s_deviceInformationCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.DeviceInformation.DeviceInformationCallback>();
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.PlatformInformation.PlatformInformationCallback> s_platformInformationCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.PlatformInformation.PlatformInformationCallback>();

        /// <summary>
        /// PresenceReceived event. This event occurs when server starts sending presence of a resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public static event EventHandler<PresenceReceivedEventArgs> PresenceReceived;

        /// <summary>
        /// ResourceFound event. This event occurs when a resource is found from the remote server
        /// after sending request using API StartFindingResource().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public static event EventHandler<ResourceFoundEventArgs> ResourceFound;

        /// <summary>
        /// PlatformInformationFound event. This event occurs when platform information is found
        /// after sending request using API StartFindingPlatformInformation().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public static event EventHandler<PlatformInformationFoundEventArgs> PlatformInformationFound;

        /// <summary>
        /// DeviceInformationFound event. This event occurs when device information is found
        /// after sending request using API StartFindingDeviceInformation().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public static event EventHandler<DeviceInformationFoundEventArgs> DeviceInformationFound;

        /// <summary>
        /// FindingError event. This event occurs when an error is found.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 13")]
        public static event EventHandler<FindingErrorOccurredEventArgs> FindingErrorOccurred;

        /// <summary>
        /// Timeout in seconds.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// <para>Value to be set must be in range from 1 to 3600. Default timeout interval value is 30.</para>
        /// <para>Sets/gets the timeout of StartFindingResource(), StartFindingDeviceInformation(), StartFindingPlatformInformation(),
        /// RemoteResource.GetAsync(), RemoteResource.PutAsync(), RemoteResource.PostAsync() and RemoteResource.DeleteAsync() APIs.</para>
        /// <para>Setter can throw exception.</para>
        /// </value>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <example><code>
        /// IoTConnectivityClientManager.Initialize();
        /// IoTConnectivityClientManager.TimeOut = 120;
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int TimeOut
        {
            get
            {
                int timeout;
                int ret = Interop.IoTConnectivity.Client.IoTCon.GetTimeout(out timeout);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Warn(IoTConnectivityErrorFactory.LogTag, "Failed to get timeout");
                    return 0;
                }
                return timeout;
            }
            set
            {
                int ret = Interop.IoTConnectivity.Client.IoTCon.SetTimeout(value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set timeout");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Polling interval of IoTConnectivity.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Sets/Gets the polling inerval(milliseconds) of IoTCon. Default value is 100 milliseconds.
        /// Value to be set must be in range from 1 to 999. The closer to 0, the faster it operates.
        /// Setter is invoked immediately for changing the interval.
        /// If you want the faster operation, we recommend you set 10 milliseconds for polling interval.
        /// Setter can throw exception.
        /// </value>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <example><code>
        /// IoTConnectivityClientManager.Initialize();
        /// IoTConnectivityClientManager.PollingInterval = 100;
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int PollingInterval
        {
            get
            {
                int interval;
                int ret = Interop.IoTConnectivity.Client.IoTCon.GetPollingInterval(out interval);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Warn(IoTConnectivityErrorFactory.LogTag, "Failed to get polling interval");
                    return 0;
                }
                return interval;
            }
            set
            {
                int ret = Interop.IoTConnectivity.Client.IoTCon.SetPollingInterval(value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set polling interval");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Initializes IoTCon.
        /// Call this function to start IoTCon.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <paramref name="filePath"/> points to a file for handling secure virtual resources.
        /// The file that is CBOR(Concise Binary Object Representation)-format must already exist
        /// in <paramref name="filePath" />. We recommend to use application-local file for <paramref name="filePath" />.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="filePath">The file path pointing to storage for handling secure virtual resources.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <post>
        /// You must call Deinitialize() if IoTCon API is no longer needed.
        /// </post>
        /// <seealso cref="Deinitialize()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code>
        /// string filePath = "../../res/iotcon-test-svr-db-client.dat";
        /// IoTConnectivityClientManager.Initialize(filePath);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void Initialize(string filePath)
        {
            int ret = Interop.IoTConnectivity.Client.IoTCon.Initialize(filePath);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to initialize");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Deinitializes IoTCon.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This API must be called if IoTCon API is no longer needed.
        /// </remarks>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Initialize(string)"/>
        /// <example><code>
        /// IoTConnectivityClientManager.Deinitialize();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void Deinitialize()
        {
            s_presenceListenerId = 1;
            s_presenceCallbacksMap.Clear();
            s_presenceHandlesMap.Clear();

            s_requestId = 1;
            s_resourceFoundCallbacksMap.Clear();
            s_deviceInformationCallbacksMap.Clear();
            s_platformInformationCallbacksMap.Clear();

            PresenceReceived = delegate{};
            ResourceFound = delegate{};
            PlatformInformationFound = delegate{};
            DeviceInformationFound = delegate{};
            FindingErrorOccurred = delegate{};

            Interop.IoTConnectivity.Client.IoTCon.Deinitialize();
        }

        /// <summary>
        /// Invokes a next message from a queue for receiving messages from others, immediately.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This API invokes a next message from a queue for receiving messages from others, immediately.
        /// After calling the API, it continues the polling with existing interval.
        /// </remarks>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <example><code>
        /// IoTConnectivityClientManager.InvokePolling();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void InvokePolling()
        {
            int ret = Interop.IoTConnectivity.Client.IoTCon.InvokePolling();
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to invoke polling");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Starts receiving presence events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Sends request to receive presence to an interested server's resource with resourceType.
        /// If succeeded, <see cref="PresenceReceived"/> event handler will be triggered when the server sends presence.
        /// A server sends presence events when adds / removes / alters a resource or start / stop presence.</para>
        /// <para><paramref name="hostAddress" /> could be <see cref="MulticastAddress"/> for IPv4 multicast.
        /// The length of <paramref name="resourceType" /> should be less than or equal to 61.
        /// The <paramref name="resourceType" /> must start with a lowercase alphabetic character, followed by a sequence
        /// of lowercase alphabetic, numeric, ".", or "-" characters, and contains no white space.</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="hostAddress">The address or addressable name of the server.</param>
        /// <param name="resourceType">A resource type that a client is interested in.</param>
        /// <returns>PresenceId - An identifier for this request.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>Initialize() should be called to initialize.</pre>
        /// <post>
        /// When the resource receive presence, <see cref="PresenceReceived"/> event handler will be invoked.<br/>
        /// You must destroy presence by calling StopReceivingPresence() if presence event is no longer needed.
        /// </post>
        /// <seealso cref="IoTConnectivityServerManager.StartSendingPresence(uint)"/>
        /// <seealso cref="IoTConnectivityServerManager.StopSendingPresence()"/>
        /// <seealso cref="StopReceivingPresence(int)"/>
        /// <seealso cref="PresenceReceived"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// EventHandler<PresenceReceivedEventArgs> handler = (sender, e) => {
        ///     Console.Log("PresenceReceived, presence id :" + e.PresenceId);
        /// }
        /// EventHandler<FindingErrorOccurredEventArgs> errorHandler = (sender, e) => {
        ///     Console.Log("Found error :" + e.Error.Message);
        /// }
        /// IoTConnectivityClientManager.PresenceReceived += handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred += errorHandler;
        /// // Do not forget to remove these event handlers when they are not required any more.
        /// int id = IoTConnectivityClientManager.StartReceivingPresence(IoTConnectivityClientManager.MulticastAddress, "oic.iot.door");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int StartReceivingPresence(string hostAddress, string resourceType)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ip;

            if (resourceType != null && !ResourceTypes.IsValid(resourceType))
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid type");
                throw new ArgumentException("Invalid type");
            }

            IntPtr id = IntPtr.Zero;
            lock (s_presenceCallbacksMap)
            {
                id = (IntPtr)s_presenceListenerId++;
            }
            s_presenceCallbacksMap[id] = (IntPtr presence, int result, IntPtr presenceResponseHandle, IntPtr userData) =>
            {
                int presenceId = (int)userData;
                if (result == (int)IoTConnectivityError.None)
                {
                    if (presenceResponseHandle != IntPtr.Zero)
                    {
                        PresenceReceivedEventArgs e = GetPresenceReceivedEventArgs(presenceId, presenceResponseHandle);
                        if (e == null)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't get PresenceReceivedEventArgs");
                            return;
                        }
                        PresenceReceived?.Invoke(null, e);
                    }
                    else
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Handle is null");
                        return;
                    }
                }
                else
                {
                    FindingErrorOccurredEventArgs e = GetFindingErrorOccurredEventArgs(presenceId, result);
                    FindingErrorOccurred?.Invoke(null, e);
                }
            };

            IntPtr presenceHandle;
            int errorCode = Interop.IoTConnectivity.Client.Presence.AddPresenceCb(hostAddress, (int)connectivityType, resourceType, s_presenceCallbacksMap[id], id, out presenceHandle);
            if (errorCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to register presence event handler");
                lock (s_presenceCallbacksMap)
                {
                    s_presenceCallbacksMap.Remove(id);
                }
                throw IoTConnectivityErrorFactory.GetException(errorCode);
            }

            lock (s_presenceHandlesMap)
            {
                s_presenceHandlesMap[id] = presenceHandle;
            }
            return (int)id;
        }

        /// <summary>
        /// Stops receiving presence events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Sends request to not to receive server's presence any more.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="presenceId">The start presence request identifier.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="IoTConnectivityServerManager.StartSendingPresence(uint)"/>
        /// <seealso cref="IoTConnectivityServerManager.StopSendingPresence()"/>
        /// <seealso cref="StartReceivingPresence(string, string)"/>
        /// <seealso cref="PresenceReceived"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// EventHandler<PresenceReceivedEventArgs> handler = (sender, e) => {
        ///     Console.Log("PresenceReceived, presence id :" + e.PresenceId);
        /// }
        /// EventHandler<FindingErrorOccurredEventArgs> errorHandler = (sender, e) => {
        ///     Console.Log("Found error :" + e.Error.Message);
        /// }
        /// IoTConnectivityClientManager.PresenceReceived += handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred += errorHandler;
        /// int id = IoTConnectivityClientManager.StartReceivingPresence(IoTConnectivityClientManager.MulticastAddress, "oic.iot.door");
        /// await Task.Delay(5000); // Do other things here
        /// // Call StopReceivingPresence() when receiving presence is not required any more
        /// IoTConnectivityClientManager.PresenceReceived -= handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred -= errorHandler;
        /// IoTConnectivityClientManager.StopReceivingPresence(id);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void StopReceivingPresence(int presenceId)
        {
            if (!s_presenceHandlesMap.ContainsKey((IntPtr)presenceId))
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "this presenceId does not exist");
                throw new ArgumentException("this presenceId does not exist");
            }

            if (s_presenceHandlesMap.ContainsKey((IntPtr)presenceId))
            {
                IntPtr presenceHandle = s_presenceHandlesMap[(IntPtr)presenceId];
                int ret = Interop.IoTConnectivity.Client.Presence.RemovePresenceCb(presenceHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to deregister presence event handler");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }

                lock (s_presenceHandlesMap)
                {
                    s_presenceHandlesMap.Remove((IntPtr)presenceId);
                }
            }

            if (s_presenceCallbacksMap.ContainsKey((IntPtr)presenceId))
            {
                lock (s_presenceCallbacksMap)
                {
                    s_presenceCallbacksMap.Remove((IntPtr)presenceId);
                }
            }
        }

        /// <summary>
        /// Starts finding resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Sends request to find a resource of <paramref name="hostAddress" /> server with <paramref name="query" />.
        /// If succeeded, <see cref="ResourceFound"/> event handler will be triggered with information of the resource.</para>
        /// <para><paramref name="hostAddress" /> could be <see cref="MulticastAddress"/> for the IPv4 multicast.</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="hostAddress">The address or addressable name of the server. The address includes a protocol like coaps://.</param>
        /// <param name="query">The query specified as a filter for founding resources.</param>
        /// <returns>RequestId - An identifier for this request.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>Initialize() should be called to initialize.</pre>
        /// <post>
        /// When the resource is found, <see cref="ResourceFound"/> event handler will be invoked.
        /// </post>
        /// <seealso cref="ResourceFound"/>
        /// <seealso cref="ResourceFoundEventArgs"/>
        /// <seealso cref="TimeOut"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// EventHandler<ResourceFoundEventArgs> handler = (sender, e) => {
        ///     Console.Log("Found resource at host address :" + e.Resource.HostAddress + ", uri :" + e.Resource.UriPath);
        /// }
        /// EventHandler<FindingErrorOccurredEventArgs> errorHandler = (sender, e) => {
        ///     Console.Log("Found error :" + e.Error.Message);
        /// }
        /// IoTConnectivityClientManager.ResourceFound += handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred += errorHandler;
        /// ResourceQuery query = new ResourceQuery();
        /// query.Type = "oic.iot.door";
        /// // Do not forget to remove these event handlers when they are not required any more.
        /// int id = IoTConnectivityClientManager.StartFindingResource(null, query);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int StartFindingResource(string hostAddress, ResourceQuery query = null)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ip;

            IntPtr id = IntPtr.Zero;
            lock (s_resourceFoundCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_resourceFoundCallbacksMap[id] = (IntPtr remoteResourceHandle, int result, IntPtr userData) =>
            {
                if (ResourceFound == null)
                    return false;

                int requestId = (int)userData;
                if (result == (int)IoTConnectivityError.None)
                {
                    if (remoteResourceHandle != IntPtr.Zero)
                    {
                        RemoteResource resource = null;
                        try
                        {
                            resource = new RemoteResource(remoteResourceHandle);
                        }
                        catch (Exception exp)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't clone RemoteResource's handle: " + exp.Message);
                            return true;
                        }
                        ResourceFoundEventArgs e = new ResourceFoundEventArgs()
                        {
                            RequestId = requestId,
                            EventContinue = true,
                            Resource = resource
                        };
                        ResourceFound?.Invoke(null, e);
                        Log.Info(IoTConnectivityErrorFactory.LogTag, "e.EventContinue : " + e.EventContinue);
                        return e.EventContinue;
                    }
                    else
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Handle is null");
                    }
                }
                else
                {
                    FindingErrorOccurredEventArgs e = GetFindingErrorOccurredEventArgs(requestId, result);
                    FindingErrorOccurred?.Invoke(null, e);

                    lock (s_resourceFoundCallbacksMap)
                    {
                        s_resourceFoundCallbacksMap.Remove(id);
                    }
                }
                return true;
            };
            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errorCode = Interop.IoTConnectivity.Client.ResourceFinder.AddResourceFoundCb(hostAddress, (int)connectivityType, queryHandle, s_resourceFoundCallbacksMap[id], id);
            if (errorCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to register resource found event handler");
                lock (s_resourceFoundCallbacksMap)
                {
                    s_resourceFoundCallbacksMap.Remove(id);
                }
                throw IoTConnectivityErrorFactory.GetException(errorCode);
            }
            return (int)id;
        }

        /// <summary>
        /// Starts finding the device information of remote server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Requests server for device information.
        /// If succeeded, <see cref="DeviceInformationFound"/> event handler will be triggered with information of the device.</para>
        /// <para><paramref name="hostAddress" /> could be <see cref="MulticastAddress"/> for the IPv4 multicast.</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="hostAddress">The host address of the remote server.</param>
        /// <param name="query">The query specified as a filter for founding resources.</param>
        /// <returns>RequestId - An identifier for this request.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>Initialize() should be called to initialize.</pre>
        /// <post>
        /// <see cref="DeviceInformationFound" /> event handler will be invoked.
        /// </post>
        /// <seealso cref="IoTConnectivityServerManager.SetDeviceName(string)"/>
        /// <seealso cref="DeviceInformationFound"/>
        /// <seealso cref="DeviceInformationFoundEventArgs"/>
        /// <seealso cref="TimeOut"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// EventHandler<DeviceInformationFoundEventArgs> handler = (sender, e) => {
        ///     Console.Log("Device information found, id : " + e.RequestId + ", name : " + e.Name);
        /// }
        /// EventHandler<FindingErrorOccurredEventArgs> errorHandler = (sender, e) => {
        ///     Console.Log("Found error :" + e.Error.Message);
        /// }
        /// IoTConnectivityClientManager.DeviceInformationFound += handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred += errorHandler;
        /// // Do not forget to remove these event handlers when they are not required any more.
        /// int id = IoTConnectivityClientManager.StartFindingDeviceInformation(IoTConnectivityClientManager.MulticastAddress);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int StartFindingDeviceInformation(string hostAddress, ResourceQuery query = null)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ip;

            IntPtr id = IntPtr.Zero;
            lock (s_deviceInformationCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_deviceInformationCallbacksMap[id] = (IntPtr deviceInfoHandle, int result, IntPtr userData) =>
            {
                if (DeviceInformationFound == null)
                    return false;

                int requestId = (int)userData;
                if (result == (int)IoTConnectivityError.None)
                {
                    if (deviceInfoHandle != IntPtr.Zero)
                    {
                        DeviceInformationFoundEventArgs e = GetDeviceInformationFoundEventArgs(requestId, deviceInfoHandle);
                        if (e == null)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't get DeviceInformationFoundEventArgs");
                            return true;
                        }
                        DeviceInformationFound?.Invoke(null, e);
                        Log.Info(IoTConnectivityErrorFactory.LogTag, "e.EventContinue : " + e.EventContinue);
                        return e.EventContinue;
                    }
                    else
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Handle is null");
                    }
                }
                else
                {
                    FindingErrorOccurredEventArgs e = GetFindingErrorOccurredEventArgs(requestId, result);
                    FindingErrorOccurred?.Invoke(null, e);

                    lock (s_deviceInformationCallbacksMap)
                    {
                        s_deviceInformationCallbacksMap.Remove(id);
                    }
                }
                return true;
            };

            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errorCode = Interop.IoTConnectivity.Client.DeviceInformation.Find(hostAddress, (int)connectivityType, queryHandle, s_deviceInformationCallbacksMap[id], id);
            if (errorCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get device information");
                lock (s_deviceInformationCallbacksMap)
                {
                    s_deviceInformationCallbacksMap.Remove(id);
                }
                throw IoTConnectivityErrorFactory.GetException(errorCode);
            }

            return (int)id;
        }

        /// <summary>
        /// Starts finding the platform information of remote server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Requests server for platform information.
        /// If succeeded, <see cref="PlatformInformationFound" /> event handler will be triggered with information of the platform.</para>
        /// <para><paramref name="hostAddress" /> could be <see cref="MulticastAddress"/> for IPv4 multicast.</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="hostAddress">The host address of remote server.</param>
        /// <param name="query">The query specified as a filter for founding resources.</param>
        /// <returns>RequestId - An identifier for this request.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>Initialize() should be called to initialize.</pre>
        /// <post>
        /// <see cref="PlatformInformationFound" /> event handler will be invoked.
        /// </post>
        /// <seealso cref="PlatformInformationFound"/>
        /// <seealso cref="PlatformInformationFoundEventArgs"/>
        /// <seealso cref="TimeOut"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// EventHandler<PlatformInformationFoundEventArgs> handler = (sender, e) => {
        ///     Console.Log("PlatformInformationFound :" + e.RequestId);
        /// }
        /// EventHandler<FindingErrorOccurredEventArgs> errorHandler = (sender, e) => {
        ///     Console.Log("Found error :" + e.Error.Message);
        /// }
        /// IoTConnectivityClientManager.PlatformInformationFound += handler;
        /// IoTConnectivityClientManager.FindingErrorOccurred += errorHandler;
        /// // Do not forget to remove these event handlers when they are not required any more.
        /// int id = IoTConnectivityClientManager.StartFindingPlatformInformation(IoTConnectivityClientManager.MulticastAddress);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static int StartFindingPlatformInformation(string hostAddress, ResourceQuery query = null)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ip;

            IntPtr id = IntPtr.Zero;
            lock (s_platformInformationCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_platformInformationCallbacksMap[id] = (IntPtr platformInfoHandle, int result, IntPtr userData) =>
            {
                if (PlatformInformationFound == null)
                    return false;

                int requestId = (int)userData;
                if (result == (int)IoTConnectivityError.None)
                {
                    if (platformInfoHandle != IntPtr.Zero)
                    {
                        PlatformInformationFoundEventArgs e = GetPlatformInformationFoundEventArgs(requestId, platformInfoHandle);
                        if (e == null)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't get PlatformInformationFoundEventArgs");
                            return true;
                        }
                        PlatformInformationFound?.Invoke(null, e);
                        Log.Info(IoTConnectivityErrorFactory.LogTag, "e.EventContinue : " + e.EventContinue);
                        return e.EventContinue;
                    }
                    else
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Handle is null");
                    }
                }
                else
                {
                    FindingErrorOccurredEventArgs e = GetFindingErrorOccurredEventArgs(requestId, result);
                    FindingErrorOccurred?.Invoke(null, e);

                    lock (s_platformInformationCallbacksMap)
                    {
                        s_platformInformationCallbacksMap.Remove(id);
                    }
                }
                return true;
            };

            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errorCode = Interop.IoTConnectivity.Client.PlatformInformation.Find(hostAddress, (int)connectivityType, queryHandle, s_platformInformationCallbacksMap[id], id);
            if (errorCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get platform information");
                lock (s_platformInformationCallbacksMap)
                {
                    s_platformInformationCallbacksMap.Remove(id);
                }
                throw IoTConnectivityErrorFactory.GetException(errorCode);
            }

            return (int)id;
        }

        // Private methods
        private static PresenceReceivedEventArgs GetPresenceReceivedEventArgs(int presenceId, IntPtr presenceResponseHandle)
        {
            int trigger;
            IntPtr host, type;

            int ret = Interop.IoTConnectivity.Client.PresenceResponse.GetHostAddress(presenceResponseHandle, out host);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get host address");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PresenceResponse.GetResourceType(presenceResponseHandle, out type);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get resource type");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PresenceResponse.GetTrigger(presenceResponseHandle, out trigger);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get event type");
                return null;
            }

            PresenceReceivedEventArgs e = new PresenceReceivedEventArgs()
            {
                PresenceId = presenceId,
                HostAddress = (host != IntPtr.Zero) ? Marshal.PtrToStringAnsi(host) : string.Empty,
                Type = (type != IntPtr.Zero) ? Marshal.PtrToStringAnsi(type) : string.Empty,
                EventType = (PresenceEventType)trigger
            };

            return e;
        }

        private static DeviceInformationFoundEventArgs GetDeviceInformationFoundEventArgs(int requestId, IntPtr deviceInfoHandle)
        {
            IntPtr name, specVersion, deviceId, dataModelVersion;

            int ret = Interop.IoTConnectivity.Client.DeviceInformation.GetProperty(deviceInfoHandle, (int)Interop.IoTConnectivity.Client.DeviceInformation.Property.Name, out name);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get name");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.DeviceInformation.GetProperty(deviceInfoHandle, (int)Interop.IoTConnectivity.Client.DeviceInformation.Property.SpecVersion, out specVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get spec version");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.DeviceInformation.GetProperty(deviceInfoHandle, (int)Interop.IoTConnectivity.Client.DeviceInformation.Property.Id, out deviceId);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get device id");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.DeviceInformation.GetProperty(deviceInfoHandle, (int)Interop.IoTConnectivity.Client.DeviceInformation.Property.DataModelVersion, out dataModelVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get data model version");
                return null;
            }

            DeviceInformationFoundEventArgs e = new DeviceInformationFoundEventArgs()
            {
                RequestId = requestId,
                EventContinue = true,
                Name = (name != IntPtr.Zero) ? Marshal.PtrToStringAnsi(name) : string.Empty,
                SpecVersion = (specVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(specVersion) : string.Empty,
                DeviceId = (deviceId != IntPtr.Zero) ? Marshal.PtrToStringAnsi(deviceId) : string.Empty,
                DataModelVersion = (dataModelVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(dataModelVersion) : string.Empty
            };

            return e;
        }

        private static PlatformInformationFoundEventArgs GetPlatformInformationFoundEventArgs(int requestId, IntPtr platformInfoHandle)
        {
            IntPtr platformId, manufacturerName, manufacturerUrl, modelNumber, dateOfManufacture, platformVersion, osVersion, hardwareVersion, firmwareVersion, supportUrl, systemTime;

            int ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.Id, out platformId);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get platform id");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.MfgName, out manufacturerName);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get manufacturer name");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.MfgUrl, out manufacturerUrl);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get manufacturer url");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.ModelNumber, out modelNumber);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get model number");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.DateOfMfg, out dateOfManufacture);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get date of manufacture");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.PlatformVer, out platformVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get platform version");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.OsVer, out osVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to os version");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.HardwareVer, out hardwareVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to hardware version");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.FirmwareVer, out firmwareVersion);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get firmware version");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.SupportUrl, out supportUrl);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get support url");
                return null;
            }

            ret = Interop.IoTConnectivity.Client.PlatformInformation.GetProperty(platformInfoHandle, (int)Interop.IoTConnectivity.Client.PlatformInformation.Propery.SystemTime, out systemTime);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get system time");
                return null;
            }

            PlatformInformationFoundEventArgs e = new PlatformInformationFoundEventArgs()
            {
                RequestId = requestId,
                EventContinue = true,
                PlatformId = (platformId != IntPtr.Zero) ? Marshal.PtrToStringAnsi(platformId) : string.Empty,
                ManufacturerName = (manufacturerName != IntPtr.Zero) ? Marshal.PtrToStringAnsi(manufacturerName) : string.Empty,
                ManufacturerURL = (manufacturerUrl != IntPtr.Zero) ? Marshal.PtrToStringAnsi(manufacturerUrl) : string.Empty,
                DateOfManufacture = (dateOfManufacture != IntPtr.Zero) ? Marshal.PtrToStringAnsi(dateOfManufacture) : string.Empty,
                ModelNumber = (modelNumber != IntPtr.Zero) ? Marshal.PtrToStringAnsi(modelNumber) : string.Empty,
                PlatformVersion = (platformVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(platformVersion) : string.Empty,
                OsVersion = (osVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(osVersion) : string.Empty,
                HardwareVersion = (hardwareVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(hardwareVersion) : string.Empty,
                FirmwareVersion = (firmwareVersion != IntPtr.Zero) ? Marshal.PtrToStringAnsi(firmwareVersion) : string.Empty,
                SupportUrl = (supportUrl != IntPtr.Zero) ? Marshal.PtrToStringAnsi(supportUrl) : string.Empty,
                SystemTime = (systemTime != IntPtr.Zero) ? Marshal.PtrToStringAnsi(systemTime) : string.Empty
            };

            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.RequestId is " + e.RequestId);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.PlatformId is " + e.PlatformId);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.ManufacturerName is " + e.ManufacturerName);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.ManufacturerURL is " + e.ManufacturerURL);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.DateOfManufacture is " + e.DateOfManufacture);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.ModelNumber is " + e.ModelNumber);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.PlatformVersion is " + e.PlatformVersion);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.OsVersion is " + e.OsVersion);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.HardwareVersion is " + e.HardwareVersion);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.FirmwareVersion is " + e.FirmwareVersion);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.SupportUrl is " + e.SupportUrl);
            Log.Info(IoTConnectivityErrorFactory.LogTag, "e.SystemTime is " + e.SystemTime);

            return e;
        }

        private static FindingErrorOccurredEventArgs GetFindingErrorOccurredEventArgs(int requestId, int err)
        {
            FindingErrorOccurredEventArgs e = new FindingErrorOccurredEventArgs()
            {
                RequestId = requestId,
                Error = IoTConnectivityErrorFactory.GetException(err)
            };
            return e;
        }
    }
}
