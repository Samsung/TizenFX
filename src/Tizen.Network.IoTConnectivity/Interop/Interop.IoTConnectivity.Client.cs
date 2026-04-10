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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    // Deprecated since API13
    internal static partial class IoTConnectivity
    {
        internal static partial class Client
        {
            internal static partial class DeviceInformation
            {
                internal delegate bool DeviceInformationCallback(IntPtr deviceInfoHandle, int result, IntPtr userData);

                internal enum Property
                {
                    Name = 0,
                    SpecVersion,
                    Id,
                    DataModelVersion,
                }

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_find_device_info")]
                internal static extern int Find(string hostAddress, int connectivityType, IntPtr query, DeviceInformationCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_device_info_get_property")]
                internal static extern int GetProperty(IntPtr deviceInfoHandle, int property, out IntPtr value);
            }

            internal static partial class PlatformInformation
            {
                internal delegate bool PlatformInformationCallback(IntPtr platformInfoHandle, int result, IntPtr userData);

                internal enum Propery
                {
                    Id = 0,
                    MfgName,
                    MfgUrl,
                    ModelNumber,
                    DateOfMfg,
                    PlatformVer,
                    OsVer,
                    HardwareVer,
                    FirmwareVer,
                    SupportUrl,
                    SystemTime
                }

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_find_platform_info")]
                internal static extern int Find(string hostAddress, int connectivityType, IntPtr query, PlatformInformationCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_platform_info_get_property")]
                internal static extern int GetProperty(IntPtr platformInfoHandle, int property, out IntPtr value);
            }

            internal static partial class RemoteResource
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void ResponseCallback(IntPtr resource, int err, int requestType, IntPtr response, IntPtr userData);

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void ObserveCallback(IntPtr resource, int err, int sequenceNumber, IntPtr response, IntPtr userData);

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void CachedRepresentationChangedCallback(IntPtr resource, IntPtr representation, IntPtr userData);

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void StateChangedCallback(IntPtr resource, int state, IntPtr userData);

                internal enum ConnectivityType
                {
                    None = -1,
                    All,
                    Ip,
                    Ipv4,
                    Ipv6
                }

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_create")]
                internal static extern int Create(string hostAddress, int connectivityType, string uriPath, int properties, IntPtr resourceTypes, IntPtr resourceInterfaces, out IntPtr remoteResource);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_destroy")]
                internal static extern void Destroy(IntPtr resource);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_clone")]
                internal static extern int Clone(IntPtr src, out IntPtr dest);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_observe_register")]
                internal static extern int RegisterObserve(IntPtr resource, int observePolicy, IntPtr query, ObserveCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_observe_deregister")]
                internal static extern int DeregisterObserve(IntPtr resource);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get")]
                internal static extern int Get(IntPtr resource, IntPtr query, ResponseCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_put")]
                internal static extern int Put(IntPtr resource, IntPtr repr, IntPtr query, ResponseCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_post")]
                internal static extern int Post(IntPtr resource, IntPtr repr, IntPtr query, ResponseCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_delete")]
                internal static extern int Delete(IntPtr resource, ResponseCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_start_caching")]
                internal static extern int StartCaching(IntPtr resource, CachedRepresentationChangedCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_stop_caching")]
                internal static extern int StopCaching(IntPtr resource);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_start_monitoring")]
                internal static extern int StartMonitoring(IntPtr resource, StateChangedCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_stop_monitoring")]
                internal static extern int StopMonitoring(IntPtr resource);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_uri_path")]
                internal static extern int GetUriPath(IntPtr resource, out IntPtr uriPath);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_connectivity_type")]
                internal static extern int GetConnectivityType(IntPtr resource, out int connectivityType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_host_address")]
                internal static extern int GetHostAddress(IntPtr resource, out IntPtr hostAddress);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_device_id")]
                internal static extern int GetDeviceId(IntPtr resource, out IntPtr deviceId);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_types")]
                internal static extern int GetTypes(IntPtr resource, out IntPtr types);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_interfaces")]
                internal static extern int GetInterfaces(IntPtr resource, out IntPtr ifaces);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_policies")]
                internal static extern int GetPolicies(IntPtr resource, out int properties);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_options")]
                internal static extern int GetOptions(IntPtr resource, out IntPtr options);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_set_options")]
                internal static extern int SetOptions(IntPtr resource, IntPtr options);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_cached_representation")]
                internal static extern int GetCachedRepresentation(IntPtr resource, out IntPtr representation);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_checking_interval")]
                internal static extern int GetTimeInterval(IntPtr resource, out int timeInterval);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_set_checking_interval")]
                internal static extern int SetTimeInterval(IntPtr resource, int timeInterval);
            }

            internal static partial class IoTCon
            {
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_initialize")]
                internal static extern int Initialize(string filePath);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_deinitialize")]
                internal static extern void Deinitialize();

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_get_timeout")]
                internal static extern int GetTimeout(out int timeoutSeconds);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_set_timeout")]
                internal static extern int SetTimeout(int timeoutSeconds);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_get_interval")]
                internal static extern int GetPollingInterval(out int interval);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_set_interval")]
                internal static extern int SetPollingInterval(int interval);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_invoke")]
                internal static extern int InvokePolling();
            }

            internal static partial class ResourceFinder
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate bool FoundResourceCallback(IntPtr remoteResourceHandle, int result, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_find_resource")]
                internal static extern int AddResourceFoundCb(string hostAddress, int connectivityType, IntPtr query, FoundResourceCallback cb, IntPtr userData);
            }

            internal static partial class Presence
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void PresenceCallback(IntPtr presenceResponseHandle, int err, IntPtr response, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_add_presence_cb")]
                internal static extern int AddPresenceCb(string hostAddress, int connectivityType, string resourceType, PresenceCallback cb, IntPtr userData, out IntPtr presenceHandle);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_remove_presence_cb")]
                internal static extern int RemovePresenceCb(IntPtr presenceHandle);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_host_address")]
                internal static extern int GetHostAddress(IntPtr presence, out IntPtr hostAddress);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_connectivity_type")]
                internal static extern int GetConnectivityType(IntPtr presence, out int connectivityType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_resource_type")]
                internal static extern int GetResourceType(IntPtr presence, out IntPtr resourceType);
            }

            internal static partial class PresenceResponse
            {
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_result")]
                internal static extern int GetResult(IntPtr response, out int result);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_trigger")]
                internal static extern int GetTrigger(IntPtr response, out int trigger);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_host_address")]
                internal static extern int GetHostAddress(IntPtr response, out IntPtr hostAddress);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_connectivity_type")]
                internal static extern int GetConnectivityType(IntPtr response, out int connectivityType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_resource_type")]
                internal static extern int GetResourceType(IntPtr response, out IntPtr resourceType);
            }
        }
    }
}
