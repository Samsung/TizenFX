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
using Tizen.Network.Nsd;

/// <summary>
/// Interop class for NSD.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// NSD native APIs.
    /// </summary>
    internal static partial class Nsd
    {
        internal static partial class Dnssd
        {
            //Callback for event
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceRegisteredCallback(DnssdError result, uint service, IntPtr userData);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceFoundCallback(DnssdServiceState state, uint service, IntPtr userData);

            //Dns-sd
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_initialize")]
            internal static partial int Initialize();
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_deinitialize")]
            internal static partial int Deinitialize();
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_create_local_service", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int CreateService(string type, out uint service);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_destroy_local_service")]
            internal static partial int DestroyService(uint service);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_name", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetName(uint service, string name);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_port")]
            internal static partial int SetPort(uint service, int port);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_add_txt_record", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int AddTxtRecord(uint service, string key, ushort length, byte[] value);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_remove_txt_record", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int RemoveTxtRecord(uint service, string key);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_record")]
            internal static partial int SetRecord(uint service, ushort type, ushort length, byte[] data);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_unset_record")]
            internal static partial int UnsetRecord(uint service, ushort type);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_register_local_service")]
            internal static partial int RegisterService(uint service, ServiceRegisteredCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_deregister_local_service")]
            internal static partial int DeregisterService(uint service);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_start_browsing_service", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int StartBrowsing(string type, out uint browser, ServiceFoundCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_stop_browsing_service")]
            internal static partial int StopBrowsing(uint browser);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetType(uint service, out string type);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_name", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetName(uint service, out string name);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_ip", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetIP(uint service, out string ipV4, out string ipV6);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_port")]
            internal static partial int GetPort(uint service, out int port);
            [LibraryImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_all_txt_record")]
            internal static partial int GetAllTxtRecord(uint service, out ushort length, out IntPtr value);
        }

        // Deprecated since API13
        // ssdp
        internal static partial class Ssdp
        {
            //Callback for event
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceRegisteredCallback(SsdpError result, uint service, IntPtr userData);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceFoundCallback(SsdpServiceState state, uint service, IntPtr userData);

            //Ssdp
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_initialize")]
            internal static partial int Initialize();
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_deinitialize")]
            internal static partial int Deinitialize();
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_create_local_service", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int CreateService(string target, out uint service);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_destroy_local_service")]
            internal static partial int DestroyService(uint service);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_service_set_usn", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetUsn(uint service, string usn);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_service_set_url", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetUrl(uint service, string url);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_target", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetTarget(uint service, out string target);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_usn", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetUsn(uint service, out string usn);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_url", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetUrl(uint service, out string url);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_register_local_service")]
            internal static partial int RegisterService(uint service, ServiceRegisteredCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_deregister_local_service")]
            internal static partial int DeregisterService(uint service);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_start_browsing_service", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int StartBrowsing(string target, out uint browser, ServiceFoundCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Ssdp, EntryPoint = "ssdp_stop_browsing_service")]
            internal static partial int StopBrowsing(uint browser);
        }
    }
    internal static partial class Libc
    {
        [LibraryImport(Libraries.Libc, EntryPoint = "free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void Free(IntPtr userData);
    }

    internal static partial class Glib
    {
        [LibraryImport(Libraries.Glib, EntryPoint = "g_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void Free(IntPtr userData);
    }
}



