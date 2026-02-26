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
        internal static partial class Server
        {
            internal enum RequestType
            {
                Unknown = 0,
                Get = 1,
                Put = 2,
                Post = 3,
                Delete = 4,
            }

            internal static partial class IoTCon
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_start_presence", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StartPresence(uint time);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_stop_presence", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int StopPresence();

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_set_device_name", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetDeviceName(string deviceName);
            }

            internal static partial class Resource
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void RequestHandlerCallback(IntPtr resource, IntPtr request, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_create", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Create(string uriPath, IntPtr resTypes, IntPtr ifaces, int properties, RequestHandlerCallback cb, IntPtr userData, out IntPtr resourceHandle);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_destroy", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Destroy(IntPtr resourceHandle);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_interface", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int BindInterface(IntPtr resource, string iface);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int BindType(IntPtr resourceHandle, string resourceType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_set_request_handler", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetRequestHandler(IntPtr resource, RequestHandlerCallback cb, IntPtr userData);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_child_resource", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int BindChildResource(IntPtr parent, IntPtr child);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_unbind_child_resource", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int UnbindChildResource(IntPtr parent, IntPtr child);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_notify", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Notify(IntPtr resource, IntPtr repr, IntPtr observers, int qos);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_number_of_children", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetNumberOfChildren(IntPtr resource, out int number);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_nth_child", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetNthChild(IntPtr parent, int index, out IntPtr child);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_uri_path", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetUriPath(IntPtr resource, out IntPtr uriPath);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_types", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetTypes(IntPtr resource, out IntPtr types);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_interfaces", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetInterfaces(IntPtr resource, out IntPtr ifaces);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_properties", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetProperties(IntPtr resource, out int properties);
            }

            internal static partial class Request
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_host_address", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetHostAddress(IntPtr request, out IntPtr hostAddress);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_connectivity_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetConnectivityType(IntPtr request, out int connectivityType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_representation", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetRepresentation(IntPtr request, out IntPtr repr);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_request_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetRequestType(IntPtr request, out int type);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_options", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetOptions(IntPtr request, out IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_query", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetQuery(IntPtr request, out IntPtr query);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_observe_type", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetObserveType(IntPtr request, out int observeType);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_observe_id", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetObserveId(IntPtr request, out int observeId);
            }

            internal static partial class Response
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_create", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Create(IntPtr request, out IntPtr response);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_destroy", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial void Destroy(IntPtr resp);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_options", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetOptions(IntPtr resp, out IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_representation", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetRepresentation(IntPtr resp, out IntPtr repr);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_result", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int GetResult(IntPtr resp, out int result);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_result", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetResult(IntPtr resp, int result);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_representation", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetRepresentation(IntPtr resp, IntPtr repr);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_options", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int SetOptions(IntPtr resp, IntPtr options);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_response_send", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Send(IntPtr resp);
            }

            internal static partial class Observers
            {
                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_create", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Create(out IntPtr observers);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_destroy", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial void Destroy(IntPtr observers);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_add", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Add(IntPtr observers, int observeId);

                [LibraryImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_remove", StringMarshalling = StringMarshalling.Utf8)]
                internal static partial int Remove(IntPtr observers, int observeId);
            }
        }
    }
}



