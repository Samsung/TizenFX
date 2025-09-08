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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// IoT connectivity server manager consists of server side APIs.
    /// </summary>

    [Obsolete("Deprecated since API level 13")]
    public static class IoTConnectivityServerManager
    {
        private static int s_requestId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Server.Resource.RequestHandlerCallback> s_RequestHandlerCallbackMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Server.Resource.RequestHandlerCallback>();

        /// <summary>
        /// Initializes IoTCon. Calls this API to start IoTCon.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <paramref name="filePath" /> points to a file for handling secure virtual resources.
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
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access</exception>
        /// <example><code>
        /// string filePath = "../../res/iotcon-test-svr-db-server.dat";
        /// IoTConnectivityServerManager.Initialize(filePath);
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
        /// IoTConnectivityServerManager.Deinitialize();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void Deinitialize()
        {
            _resources.Clear();
            s_requestId = 1;
            s_RequestHandlerCallbackMap.Clear();

            Interop.IoTConnectivity.Client.IoTCon.Deinitialize();
        }

        /// <summary>
        /// Registers a resource in IoTCon server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="resource">The resource to register.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Resource"/>
        /// <seealso cref="LiteResource"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code><![CDATA[
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "org.tizen.light" });
        /// Attributes attributes = new Attributes { { "state", "ON" }};
        /// Resource res = new LiteResource("/room/1", types, ResourcePolicy.Discoverable, attributes);
        /// try {
        ///     IoTConnectivityServerManager.RegisterResource(res);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void RegisterResource(Resource resource)
        {
            Log.Info(IoTConnectivityErrorFactory.LogTag, "...");

            IntPtr id = IntPtr.Zero;
            lock (s_RequestHandlerCallbackMap)
            {
                id = (IntPtr)s_requestId++;
            }

            s_RequestHandlerCallbackMap[id] = (IntPtr r_resource, IntPtr request, IntPtr userData) =>
            {
                int requestId = (int)userData;

                Log.Info(IoTConnectivityErrorFactory.LogTag, "Received s_RequestHandlerCallbackMap : " + requestId);

                if (request == IntPtr.Zero)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "request is IntPtr.Zero");
                    return;
                }
                resource.OnRequest(r_resource, request, userData);
            };

            IntPtr handle = IntPtr.Zero;
            int errorCode = Interop.IoTConnectivity.Server.Resource.Create(resource.UriPath, resource.Types._resourceTypeHandle, resource.Interfaces.ResourceInterfacesHandle, (int)resource.Policy, s_RequestHandlerCallbackMap[id], id, out handle);
            if (errorCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed create resource");
                lock (s_RequestHandlerCallbackMap)
                {
                    s_RequestHandlerCallbackMap.Remove(id);
                }
                throw IoTConnectivityErrorFactory.GetException(errorCode);
            }
            else
            {
                resource.ResourceHandle = handle;
            }
            _resources.Add(resource);
        }

        /// <summary>
        /// Unregisters a resource in IoTCon server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="resource">The resource to unregister.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Resource"/>
        /// <seealso cref="LiteResource"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code><![CDATA[
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "org.tizen.light" });
        /// Attributes attributes = new Attributes { { "state", "ON" }};
        /// Resource res = new LiteResource("/room/1", types, ResourcePolicy.Discoverable, attributes);
        /// IoTConnectivityServerManager.RegisterResource(res);
        /// try {
        ///     IoTConnectivityServerManager.UnregisterResource(res);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void UnregisterResource(Resource resource)
        {
            if (resource != null)
            {
                if (resource.ResourceHandle != IntPtr.Zero)
                {
                    Interop.IoTConnectivity.Server.Resource.Destroy(resource.ResourceHandle);
                    resource.ResourceHandle = IntPtr.Zero;
                }

                _resources.Remove(resource);
            }
        }

        /// <summary>
        /// Starts presence of a server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Use this API to send server's announcements to clients.
        /// Server can call this API when online for the first time or come back from offline to online.</para>
        /// <para>If <paramref name="time" /> is 0, server will set default value as 60 seconds.</para>
        /// <para>If <paramref name="time" /> is very big, server will set maximum value as (60 * 60 * 24) seconds, (24 hours).</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="time">The interval of announcing presence in seconds.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="IoTConnectivityClientManager.StartReceivingPresence(string, string)"/>
        /// <seealso cref="IoTConnectivityClientManager.StopReceivingPresence(int)"/>
        /// <seealso cref="IoTConnectivityClientManager.PresenceReceived"/>
        /// <seealso cref="StopSendingPresence()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code>
        /// try {
        ///     IoTConnectivityServerManager.StartSendingPresence(120);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void StartSendingPresence(uint time)
        {
            int ret = Interop.IoTConnectivity.Server.IoTCon.StartPresence(time);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to start presence");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Stops presence of a server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Use this API to stop sending server's announcements to clients.
        /// Server can call this API when terminating, entering to offline or out of network.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="IoTConnectivityClientManager.StartReceivingPresence(string, string)"/>
        /// <seealso cref="IoTConnectivityClientManager.StopReceivingPresence(int)"/>
        /// <seealso cref="IoTConnectivityClientManager.PresenceReceived"/>
        /// <seealso cref="StartSendingPresence(uint)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code>
        /// IoTConnectivityServerManager.StopSendingPresence();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void StopSendingPresence()
        {
            int ret = Interop.IoTConnectivity.Server.IoTCon.StopPresence();
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed cancel presence");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Sets the device name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>This API sets the name of the local device (the device calling the API).</para>
        /// <para>If the device name is set, clients can get the name using <see cref="IoTConnectivityClientManager.StartFindingDeviceInformation(string, ResourceQuery)"/>.</para>
        /// </remarks>
        /// <param name="deviceName">The device name.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="IoTConnectivityClientManager.DeviceInformationFound"/>
        /// <seealso cref="IoTConnectivityClientManager.StartFindingDeviceInformation(string, ResourceQuery)"/>
        /// <seealso cref="DeviceInformationFoundEventArgs"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <example><code>
        /// IoTConnectivityServerManager.SetDeviceName("my-tizen");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public static void SetDeviceName(string deviceName)
        {
            int ret = Interop.IoTConnectivity.Server.IoTCon.SetDeviceName(deviceName);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed set device name");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }
        private static List<Resource> _resources = new List<Resource>();
    }
}
