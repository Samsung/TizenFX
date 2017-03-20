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
    public static class IoTConnectivityServerManager
    {

        private static int s_requestId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Server.Resource.RequestHandlerCallback> s_RequestHandlerCallbackMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Server.Resource.RequestHandlerCallback>();

        /// <summary>
        /// Initializes IoTCon. Call this API to start IoTCon.
        /// </summary>
        /// <remarks>
        /// @a filePath point to a file for handling secure virtual resources.
        /// The file that is CBOR(Concise Binary Object Representation)-format must already exist
        /// in @a filePath. We recommend to use application-local file for @a filePath.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/network.get \n
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <param name="filePath">The file path to point to storage for handling secure virtual resources.</param>
        /// <post>
        /// You must call Deinitialize() if IoTCon API is no longer needed.
        /// </post>
        /// <seealso cref="Deinitialize()"/>
        /// <code>
        /// string filePath = "../../res/iotcon-test-svr-db-server.dat";
        /// IoTConnectivityServerManager.Initialize(filePath);
        /// </code>
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
        /// <remarks>
        /// This API must be called if IoTCon API is no longer needed.
        /// </remarks>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Initialize()"/>
        /// <code>
        /// IoTConnectivityServerManager.Deinitialize();
        /// </code>
        public static void Deinitialize()
        {
            _resources.Clear();
            s_requestId = 1;
            s_RequestHandlerCallbackMap.Clear();

            Interop.IoTConnectivity.Client.IoTCon.Deinitialize();
        }

        /// <summary>
        /// Registers a resource in IoTCon server
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <param name="resource">The resource to register</param>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Resource"/>
        /// <seealso cref="LiteResource"/>
        /// <code>
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "org.tizen.light" });
        /// Attributes attributes = new Attributes { { "state", "ON" }};
        /// Resource res = new LiteResource("/room/1", types, ResourcePolicy.Discoverable, attributes);
        /// try {
        ///     IoTConnectivityServerManager.RegisterResource(res);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// </code>
        public static void RegisterResource(Resource resource)
        {
            Log.Error(IoTConnectivityErrorFactory.LogTag, "...");

            IntPtr id = IntPtr.Zero;
            lock (s_RequestHandlerCallbackMap)
            {
                id = (IntPtr)s_requestId++;
            }

            s_RequestHandlerCallbackMap[id] = (IntPtr r_resource, IntPtr request, IntPtr userData) =>
            {
                int requestId = (int)userData;

                Log.Info(IoTConnectivityErrorFactory.LogTag, "Received s_RequestHandlerCallbackMap : " + requestId);

                if (request == null)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "request is null");
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
        /// Unregisters a resource in IoTCon server
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <param name="resource">The resource to unregister</param>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Resource"/>
        /// <seealso cref="LiteResource"/>
        /// <code>
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "org.tizen.light" });
        /// Attributes attributes = new Attributes { { "state", "ON" }};
        /// Resource res = new LiteResource("/room/1", types, ResourcePolicy.Discoverable, attributes);
        /// IoTConnectivityServerManager.RegisterResource(res);
        /// try {
        ///     IoTConnectivityServerManager.UnregisterResource(res);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// </code>
        public static void UnregisterResource(Resource resource)
        {
            if (resource != null)
            {
                if (resource.ResourceHandle != IntPtr.Zero)
                {
                    Interop.IoTConnectivity.Server.Resource.Destroy(resource.ResourceHandle);
                }

                _resources.Remove(resource);
            }
        }

        /// <summary>
        /// Starts presence of a server
        /// </summary>
        /// <remarks>
        /// Use this API to send server's announcements to clients.
        /// Server can call this API when online for the first time or come back from offline to online.\n
        /// If @a time is 0, server will set default value as 60 seconds.\n
        /// If @a time is very big, server will set maximum value as (60 * 60 * 24) seconds, (24 hours).
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <param name="time">The interval of announcing presence in seconds.</param>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="IoTConnectivityClientManager.StartReceivingPresence()"/>
        /// <seealso cref="IoTConnectivityClientManager.StopReceivingPresence()"/>
        /// <seealso cref="IoTConnectivityClientManager.PresenceReceived"/>
        /// <seealso cref="StopSendingPresence()"/>
        /// <code>
        /// try {
        ///     IoTConnectivityServerManager.StartSendingPresence(120);
        /// } catch(Exception ex) {
        ///     Console.Log("Exception caught : " + ex.Message);
        /// }
        /// </code>
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
        /// <remarks>
        /// Use this API to stop sending server's announcements to clients.
        /// Server can call this API when terminating, entering to offline or out of network.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <pre>
        /// Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="IoTConnectivityClientManager.StartReceivingPresence()"/>
        /// <seealso cref="IoTConnectivityClientManager.StopReceivingPresence()"/>
        /// <seealso cref="IoTConnectivityClientManager.PresenceReceived"/>
        /// <seealso cref="StartSendingPresence()"/>
        /// <code>
        /// IoTConnectivityServerManager.StopSendingPresence();
        /// </code>
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
        /// Sets the device name
        /// </summary>
        /// <remarks>
        /// This API sets the name of the local device (the device calling the API).\n
        /// If the device name is set, clients can get the name using <see cref="IoTConnectivityClientManager.StartFindingDeviceInformation()"/>.
        /// Clients can also get the name using <see cref="RemoteResource.DeviceName"/> property.
        /// </remarks>
        /// <param name="deviceName">The device name</param>
        /// <seealso cref="IoTConnectivityClientManager.DeviceInformationFound"/>
        /// <seealso cref="IoTConnectivityClientManager.StartFindingDeviceInformation()"/>
        /// <seealso cref="DeviceInformationFoundEventArgs"/>
        /// <seealso cref="RemoteResource.DeviceName"/>
        /// <code>
        /// IoTConnectivityServerManager.SetDeviceName("my-tizen");
        /// </code>
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
