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
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_start_presence")]
                internal static extern int StartPresence(uint time);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_stop_presence")]
                internal static extern int StopPresence();

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_set_device_name")]
                internal static extern int SetDeviceName(string deviceName);
            }

            internal static partial class Resource
            {
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                internal delegate void RequestHandlerCallback(IntPtr resource, IntPtr request, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_create")]
                internal static extern int Create(string uriPath, IntPtr resTypes, IntPtr ifaces, int properties, RequestHandlerCallback cb, IntPtr userData, out IntPtr resourceHandle);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_destroy")]
                internal static extern int Destroy(IntPtr resourceHandle);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_interface")]
                internal static extern int BindInterface(IntPtr resource, string iface);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_type")]
                internal static extern int BindType(IntPtr resourceHandle, string resourceType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_set_request_handler")]
                internal static extern int SetRequestHandler(IntPtr resource, RequestHandlerCallback cb, IntPtr userData);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_bind_child_resource")]
                internal static extern int BindChildResource(IntPtr parent, IntPtr child);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_unbind_child_resource")]
                internal static extern int UnbindChildResource(IntPtr parent, IntPtr child);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_notify")]
                internal static extern int Notify(IntPtr resource, IntPtr repr, IntPtr observers, int qos);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_number_of_children")]
                internal static extern int GetNumberOfChildren(IntPtr resource, out int number);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_nth_child")]
                internal static extern int GetNthChild(IntPtr parent, int index, out IntPtr child);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_uri_path")]
                internal static extern int GetUriPath(IntPtr resource, out IntPtr uriPath);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_types")]
                internal static extern int GetTypes(IntPtr resource, out IntPtr types);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_interfaces")]
                internal static extern int GetInterfaces(IntPtr resource, out IntPtr ifaces);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_resource_get_properties")]
                internal static extern int GetProperties(IntPtr resource, out int properties);
            }

            internal static partial class Request
            {
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_host_address")]
                internal static extern int GetHostAddress(IntPtr request, out IntPtr hostAddress);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_connectivity_type")]
                internal static extern int GetConnectivityType(IntPtr request, out int connectivityType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_representation")]
                internal static extern int GetRepresentation(IntPtr request, out IntPtr repr);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_request_type")]
                internal static extern int GetRequestType(IntPtr request, out int type);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_options")]
                internal static extern int GetOptions(IntPtr request, out IntPtr options);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_query")]
                internal static extern int GetQuery(IntPtr request, out IntPtr query);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_observe_type")]
                internal static extern int GetObserveType(IntPtr request, out int observeType);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_request_get_observe_id")]
                internal static extern int GetObserveId(IntPtr request, out int observeId);
            }

            internal static partial class Response
            {
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_create")]
                internal static extern int Create(IntPtr request, out IntPtr response);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_destroy")]
                internal static extern void Destroy(IntPtr resp);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_options")]
                internal static extern int GetOptions(IntPtr resp, out IntPtr options);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_representation")]
                internal static extern int GetRepresentation(IntPtr resp, out IntPtr repr);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_get_result")]
                internal static extern int GetResult(IntPtr resp, out int result);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_result")]
                internal static extern int SetResult(IntPtr resp, int result);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_representation")]
                internal static extern int SetRepresentation(IntPtr resp, IntPtr repr);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_set_options")]
                internal static extern int SetOptions(IntPtr resp, IntPtr options);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_response_send")]
                internal static extern int Send(IntPtr resp);
            }

            internal static partial class Observers
            {
                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_create")]
                internal static extern int Create(out IntPtr observers);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_destroy")]
                internal static extern void Destroy(IntPtr observers);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_add")]
                internal static extern int Add(IntPtr observers, int observeId);

                [DllImport(Libraries.IoTCon, EntryPoint = "iotcon_observers_remove")]
                internal static extern int Remove(IntPtr observers, int observeId);
            }
        }
    }
}
