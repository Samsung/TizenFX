/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    public static class IoTConnectivityClientManager
    {
        public const string MulticastAddress = null;

        private static int s_presenceListenerId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.Presence.PresenceCallback> s_presenceCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.Presence.PresenceCallback>();
        private static Dictionary<IntPtr, IntPtr> s_presenceHandlesMap = new Dictionary<IntPtr, IntPtr>();

        private static int s_requestId = 1;
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.ResourceFinder.FoundResourceCallback> s_resourceFoundCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.ResourceFinder.FoundResourceCallback>();
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.DeviceInformation.DeviceInformationCallback> s_deviceInformationCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.DeviceInformation.DeviceInformationCallback>();
        private static Dictionary<IntPtr, Interop.IoTConnectivity.Client.PlatformInformation.PlatformInformationCallback> s_platformInformationCallbacksMap = new Dictionary<IntPtr, Interop.IoTConnectivity.Client.PlatformInformation.PlatformInformationCallback>();

        /// <summary>
        /// presence event on the resource
        /// </summary>
        public static event EventHandler<PresenceReceivedEventArgs> PresenceReceived;

        /// <summary>
        /// Resource found event handler
        /// </summary>
        public static event EventHandler<ResourceFoundEventArgs> ResourceFound;

        /// <summary>
        /// PlatformInformationFound event handler
        /// </summary>
        public static event EventHandler<PlatformInformationFoundEventArgs> PlatformInformationFound;

        /// <summary>
        /// DeviceInformationFound event handler
        /// </summary>
        public static event EventHandler<DeviceInformationFoundEventArgs> DeviceInformationFound;

        /// <summary>
        /// FoundError event handler
        /// </summary>
        public static event EventHandler<FindingErrorOccurredEventArgs> FindingErrorOccurred;

        /// <summary>
        /// Timeout property
        /// </summary>
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
        /// Timeout property
        /// </summary>
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
        /// Connects to the iotcon service
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
        /// Initializes IoTCon with secure mode.
        /// </summary>
        public static void SecureInitialize(string filePath)
        {
            int ret = Interop.IoTConnectivity.Client.IoTCon.SecureInitialize(filePath);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to initialize securely");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Disconnects from the iotcon service
        /// </summary>
        public static void Deinitialize()
        {
            Interop.IoTConnectivity.Client.IoTCon.Deinitialize();
        }

        /// <summary>
        /// Invokes a next message from a queue for receiving messages from others, immediately.
        /// </summary>
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
        /// Starts receiving presence events
        /// </summary>
        /// <returns>
        /// PresenceId
        /// </returns>
        public static int StartReceivingPresence(string hostAddress, string resourceType)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = RemoteResource.GetConnectivityType(hostAddress);
            if (connectivityType == Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Unable to parse host address");
                throw new ArgumentException("Unable to parse host address");
            }

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
                if (presenceResponseHandle != IntPtr.Zero)
                {
                    int presenceId = (int)userData;
                    if (result == 0)
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
                        FindingErrorOccurredEventArgs e = GetFindingErrorOccurredEventArgs(presenceId, result);
                        FindingErrorOccurred?.Invoke(null, e);
                    }
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
        /// Stops receiving presence events
        /// </summary>
        public static void StopReceivingPresence(int presenceId)
        {
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
        /// Starts finding resource events
        /// </summary>
        /// <returns>
        /// RequestId
        /// </returns>
        public static int StartFindingResource(string hostAddress, string resourceType, bool isSecure = false)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = RemoteResource.GetConnectivityType(hostAddress);
            if (connectivityType == Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Unable to parse host address");
                throw new ArgumentException("Unable to parse host address");
            }

            if (resourceType != null && !ResourceTypes.IsValid(resourceType))
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid type");
                throw new ArgumentException("Invalid type");
            }
            IntPtr id = IntPtr.Zero;
            lock (s_resourceFoundCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_resourceFoundCallbacksMap[id] = (IntPtr remoteResourceHandle, int result, IntPtr userData) =>
            {
                if (remoteResourceHandle != IntPtr.Zero)
                {
                    int requestId = (int)userData;
                    if (result == (int)IoTConnectivityError.None)
                    {
                        RemoteResource resource = null;
                        try
                        {
                            resource = new RemoteResource(remoteResourceHandle);
                        }
                        catch (Exception exp)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't clone RemoteResource's handle: " + exp.Message);
                            return;
                        }
                        ResourceFoundEventArgs e = new ResourceFoundEventArgs()
                        {
                            RequestId = requestId,
                            Resource = resource
                        };
                        ResourceFound?.Invoke(null, e);
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
                }
            };
            int errorCode = Interop.IoTConnectivity.Client.ResourceFinder.AddResourceFoundCb(hostAddress, (int)connectivityType, resourceType, isSecure, s_resourceFoundCallbacksMap[id], id);
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
        /// Starts finding device information events
        /// </summary>
        /// <returns>
        /// RequestId
        /// </returns>
        public static int StartFindingDeviceInformation(string hostAddress)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = RemoteResource.GetConnectivityType(hostAddress);
            if (connectivityType == Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Unable to parse host address");
                throw new ArgumentException("Unable to parse host address");
            }

            IntPtr id = IntPtr.Zero;
            lock (s_deviceInformationCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_deviceInformationCallbacksMap[id] = (IntPtr deviceInfoHandle, int result, IntPtr userData) =>
            {
                if (deviceInfoHandle != IntPtr.Zero)
                {
                    int requestId = (int)userData;
                    if (result == 0)
                    {
                        DeviceInformationFoundEventArgs e = GetDeviceInformationFoundEventArgs(requestId, deviceInfoHandle);
                        if (e == null)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't get DeviceInformationFoundEventArgs");
                            return;
                        }
                        DeviceInformationFound?.Invoke(null, e);
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
                }
            };

            int errorCode = Interop.IoTConnectivity.Client.DeviceInformation.Find(hostAddress, (int)connectivityType, s_deviceInformationCallbacksMap[id], id);
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
        /// Starts finding platform information events
        /// </summary>
        /// <returns>
        /// RequestId
        /// </returns>
        public static int StartFindingPlatformInformation(string hostAddress)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = RemoteResource.GetConnectivityType(hostAddress);
            if (connectivityType == Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Unable to parse host address");
                throw new ArgumentException("Unable to parse host address");
            }

            IntPtr id = IntPtr.Zero;
            lock (s_platformInformationCallbacksMap)
            {
                id = (IntPtr)s_requestId++;
            }
            s_platformInformationCallbacksMap[id] = (IntPtr platformInfoHandle, int result, IntPtr userData) =>
            {
                if (platformInfoHandle != IntPtr.Zero)
                {
                    int requestId = (int)userData;
                    if (result == 0)
                    {
                        PlatformInformationFoundEventArgs e = GetPlatformInformationFoundEventArgs(requestId, platformInfoHandle);
                        if (e == null)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Can't get PlatformInformationFoundEventArgs");
                            return;
                        }
                        PlatformInformationFound?.Invoke(null, e);
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
                }
            };

            int errorCode = Interop.IoTConnectivity.Client.PlatformInformation.Find(hostAddress, (int)connectivityType, s_platformInformationCallbacksMap[id], id);
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
                HostAddress = Marshal.PtrToStringAuto(host),
                Type = Marshal.PtrToStringAuto(type),
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
                Name = Marshal.PtrToStringAuto(name),
                SpecVersion = Marshal.PtrToStringAuto(specVersion),
                DeviceId = Marshal.PtrToStringAuto(deviceId),
                DataModelVersion = Marshal.PtrToStringAuto(dataModelVersion)
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
                PlatformId = Marshal.PtrToStringAuto(platformId),
                ManufacturerName = Marshal.PtrToStringAuto(manufacturerName),
                ManufacturerURL = Marshal.PtrToStringAuto(manufacturerUrl),
                DateOfManufacture = Marshal.PtrToStringAuto(dateOfManufacture),
                ModelNumber = Marshal.PtrToStringAuto(modelNumber),
                PlatformVersion = Marshal.PtrToStringAuto(platformVersion),
                OsVersion = Marshal.PtrToStringAuto(osVersion),
                HardwareVersion = Marshal.PtrToStringAuto(hardwareVersion),
                FirmwareVersion = Marshal.PtrToStringAuto(firmwareVersion),
                SupportUrl = Marshal.PtrToStringAuto(supportUrl),
                SystemTime = Marshal.PtrToStringAuto(systemTime)
            };

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
