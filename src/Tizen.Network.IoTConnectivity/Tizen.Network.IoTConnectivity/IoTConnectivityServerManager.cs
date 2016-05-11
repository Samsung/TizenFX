/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// IoT connectivity server manager.
    /// </summary>
    public static class IoTConnectivityServerManager
    {
        /// <summary>
        /// Initializes connection with IoTCon service
        /// </summary>
        public static void Initialize()
        {
            int ret = Interop.IoTConnectivity.Client.IoTCon.Initialize();
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to initialize");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Disconnects with IoTCon service
        /// </summary>
        public static void Deinitialize()
        {
            Interop.IoTConnectivity.Client.IoTCon.Deinitialize();
        }

        /// <summary>
        /// Registers a resource to be available from IoTCon server
        /// </summary>
        /// <param name="resource">The resource to register</param>
        public static void RegisterResource(Resource resource)
        {
            IntPtr handle = IntPtr.Zero;
            int ret = Interop.IoTConnectivity.Server.Resource.Create(resource.UriPath, resource.Types._resourceTypeHandle, resource.Interfaces.ResourceInterfacesHandle, (int)resource.Policy, resource.OnRequest, IntPtr.Zero, out handle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed create resource");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            else
            {
                resource.ResourceHandle = handle;
            }
        }

        /// <summary>
        /// Starts presence of a server
        /// </summary>
        /// <param name="time">The interval of announcing presence in seconds.</param>
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
        public static void StopSendingPresence()
        {
            int ret = Interop.IoTConnectivity.Server.IoTCon.StopPresence();
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed cancel presence");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }
    }
}
