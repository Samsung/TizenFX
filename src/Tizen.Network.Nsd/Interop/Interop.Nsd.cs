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
        internal static class Dnssd
        {
            //Callback for event
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceRegisteredCallback(DnssdError result, uint service, IntPtr userData);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceFoundCallback(DnssdServiceState state, uint service, IntPtr userData);

            //Dns-sd
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_initialize")]
            internal static extern int Initialize();
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_deinitialize")]
            internal static extern int Deinitialize();
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_create_local_service")]
            internal static extern int CreateService(string type, out uint service);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_destroy_local_service")]
            internal static extern int DestroyService(uint service);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_name")]
            internal static extern int SetName(uint service, string name);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_port")]
            internal static extern int SetPort(uint service, int port);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_add_txt_record")]
            internal static extern int AddTxtRecord(uint service, string key, ushort length, byte[] value);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_remove_txt_record")]
            internal static extern int RemoveTxtRecord(uint service, string key);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_set_record")]
            internal static extern int SetRecord(uint service, ushort type, ushort length, byte[] data);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_unset_record")]
            internal static extern int UnsetRecord(uint service, ushort type);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_register_local_service")]
            internal static extern int RegisterService(uint service, ServiceRegisteredCallback callback, IntPtr userData);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_deregister_local_service")]
            internal static extern int DeregisterService(uint service);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_start_browsing_service")]
            internal static extern int StartBrowsing(string type, out uint browser, ServiceFoundCallback callback, IntPtr userData);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_stop_browsing_service")]
            internal static extern int StopBrowsing(uint browser);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_type")]
            internal static extern int GetType(uint service, out string type);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_name")]
            internal static extern int GetName(uint service, out string name);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_ip")]
            internal static extern int GetIP(uint service, out string ipV4, out string ipV6);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_port")]
            internal static extern int GetPort(uint service, out int port);
            [DllImport(Libraries.Dnssd, EntryPoint = "dnssd_service_get_all_txt_record")]
            internal static extern int GetAllTxtRecord(uint service, out ushort length, out IntPtr value);
        }

        internal static class Ssdp
        {
            //Callback for event
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceRegisteredCallback(SsdpError result, uint service, IntPtr userData);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ServiceFoundCallback(SsdpServiceState state, uint service, IntPtr userData);

            //Ssdp
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_initialize")]
            internal static extern int Initialize();
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_deinitialize")]
            internal static extern int Deinitialize();
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_create_local_service")]
            internal static extern int CreateService(string target, out uint service);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_destroy_local_service")]
            internal static extern int DestroyService(uint service);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_service_set_usn")]
            internal static extern int SetUsn(uint service, string usn);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_service_set_url")]
            internal static extern int SetUrl(uint service, string url);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_target")]
            internal static extern int GetTarget(uint service, out string target);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_usn")]
            internal static extern int GetUsn(uint service, out string usn);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_service_get_url")]
            internal static extern int GetUrl(uint service, out string url);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_register_local_service")]
            internal static extern int RegisterService(uint service, ServiceRegisteredCallback callback, IntPtr userData);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_deregister_local_service")]
            internal static extern int DeregisterService(uint service);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_start_browsing_service")]
            internal static extern int StartBrowsing(string target, out uint browser, ServiceFoundCallback callback, IntPtr userData);
            [DllImport(Libraries.Ssdp, EntryPoint = "ssdp_stop_browsing_service")]
            internal static extern int StopBrowsing(uint browser);
        }
    }
    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free")]
        public static extern void Free(IntPtr userData);
    }
}
