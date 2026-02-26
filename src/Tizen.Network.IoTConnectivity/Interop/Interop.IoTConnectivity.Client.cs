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
using System.Runtime.InteropServices.Marshalling;

internal static partial class Interop
{
    // Deprecated since API13
    internal static partial class IoTConnectivity
    {
        internal static partial class Client
        {
            internal static partial class DeviceInformation
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool DeviceInformationCallback(IntPtr deviceInfoHandle, int result, IntPtr userData);

                internal enum Property
                {
                    Name = 0,
                    SpecVersion,
                    Id,
                    DataModelVersion,
                }

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_find_device_info", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Find(string hostAddress, int connectivityType, IntPtr query, DeviceInformationCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_device_info_get_property", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetProperty(IntPtr deviceInfoHandle, int property, out IntPtr value);
            }

            internal static partial class PlatformInformation
            {
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool PlatformInformationCallback(IntPtr platformInfoHandle, int result, IntPtr userData);

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

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_find_platform_info", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Find(string hostAddress, int connectivityType, IntPtr query, PlatformInformationCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_platform_info_get_property", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetProperty(IntPtr platformInfoHandle, int property, out IntPtr value);
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

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_create", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Create(string hostAddress, int connectivityType, string uriPath, int properties, IntPtr resourceTypes, IntPtr resourceInterfaces, out IntPtr remoteResource);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_destroy", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial void Destroy(IntPtr resource);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_clone", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Clone(IntPtr src, out IntPtr dest);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_observe_register", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int RegisterObserve(IntPtr resource, int observePolicy, IntPtr query, ObserveCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_observe_deregister", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int DeregisterObserve(IntPtr resource);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Get(IntPtr resource, IntPtr query, ResponseCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_put", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Put(IntPtr resource, IntPtr repr, IntPtr query, ResponseCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_post", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Post(IntPtr resource, IntPtr repr, IntPtr query, ResponseCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_delete", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Delete(IntPtr resource, ResponseCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_start_caching", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StartCaching(IntPtr resource, CachedRepresentationChangedCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_stop_caching", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StopCaching(IntPtr resource);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_start_monitoring", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StartMonitoring(IntPtr resource, StateChangedCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_stop_monitoring", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StopMonitoring(IntPtr resource);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_uri_path", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetUriPath(IntPtr resource, out IntPtr uriPath);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_connectivity_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetConnectivityType(IntPtr resource, out int connectivityType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_host_address", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetHostAddress(IntPtr resource, out IntPtr hostAddress);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_device_id", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetDeviceId(IntPtr resource, out IntPtr deviceId);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_types", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetTypes(IntPtr resource, out IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_interfaces", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetInterfaces(IntPtr resource, out IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_policies", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetPolicies(IntPtr resource, out int properties);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_options", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetOptions(IntPtr resource, out IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_set_options", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetOptions(IntPtr resource, IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_cached_representation", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetCachedRepresentation(IntPtr resource, out IntPtr representation);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_get_checking_interval", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetTimeInterval(IntPtr resource, out int timeInterval);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remote_resource_set_checking_interval", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetTimeInterval(IntPtr resource, int timeInterval);
            }

            internal static partial class IoTCon
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_initialize", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Initialize(string filePath);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_deinitialize", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial void Deinitialize();

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_get_timeout", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetTimeout(out int timeoutSeconds);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_set_timeout", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetTimeout(int timeoutSeconds);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_get_interval", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetPollingInterval(out int interval);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_set_interval", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetPollingInterval(int interval);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_polling_invoke", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int InvokePolling();
            }

            internal static partial class ResourceFinder
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.U1)] internal delegate bool FoundResourceCallback(IntPtr remoteResourceHandle, int result, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_find_resource", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddResourceFoundCb(string hostAddress, int connectivityType, IntPtr query, FoundResourceCallback cb, IntPtr userData);
            }

            internal static partial class Presence
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void PresenceCallback(IntPtr presenceResponseHandle, int err, IntPtr response, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_add_presence_cb", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int AddPresenceCb(string hostAddress, int connectivityType, string resourceType, PresenceCallback cb, IntPtr userData, out IntPtr presenceHandle);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_remove_presence_cb", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int RemovePresenceCb(IntPtr presenceHandle);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_host_address", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetHostAddress(IntPtr presence, out IntPtr hostAddress);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_connectivity_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetConnectivityType(IntPtr presence, out int connectivityType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_get_resource_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetResourceType(IntPtr presence, out IntPtr resourceType);
            }

            internal static partial class PresenceResponse
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_result", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetResult(IntPtr response, out int result);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_trigger", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetTrigger(IntPtr response, out int trigger);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_host_address", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetHostAddress(IntPtr response, out IntPtr hostAddress);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_connectivity_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetConnectivityType(IntPtr response, out int connectivityType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_presence_response_get_resource_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetResourceType(IntPtr response, out IntPtr resourceType);
            }
        }
    }
}




