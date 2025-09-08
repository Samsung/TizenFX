/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Network.Tethering;

internal static partial class Interop
{
    internal static partial class TetheringExtension
    {
        // Callback for event
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EnabledCallback(int result, bool isRequested, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DisabledCallback(int result, TetheringDisabledCause cause, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ConnectionStateChangedCallback(IntPtr client, bool opened, IntPtr userData);


        // Tethering Manager
        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_initialize")]
        internal static extern int Initialize(out IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_deinitialize")]
        internal static extern int Deinitialize(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_enabled_cb")]
        internal static extern int SetEnabledCallback(IntPtr tethering, EnabledCallback callback, IntPtr userData);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_unset_enabled_cb")]
        internal static extern int UnsetEnabledCallback(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_disabled_cb")]
        internal static extern int SetDisabledCallback(IntPtr tethering, DisabledCallback callback, IntPtr userData);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_unset_disabled_cb")]
        internal static extern int UnsetDisabledCallback(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(IntPtr tethering, ConnectionStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionStateChangedCallback(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_activate")]
        internal static extern int Activate(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_deactivate")]
        internal static extern int DeActivate(IntPtr tethering);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_is_enabled")]
        internal static extern int IsEnabled(IntPtr tethering, out bool enabled);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_ssid")]
        internal static extern int SetSSID(IntPtr tethering, string ssid);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_passphrase")]
        internal static extern int SetPassphrase(IntPtr tethering, string ssid);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_set_channel")]
        internal static extern int SetChannel(IntPtr tethering, int channel);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_get_tethering_info")]
        internal static extern int GetTetheringInfo(IntPtr tethering, IntPtr tethering_info);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_get_channel")]
        internal static extern int GetChannel(IntPtr tethering, out int channel);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_get_security")]
        internal static extern int GetSecurity(IntPtr tethering, out int security);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_get_visibility")]
        internal static extern int GetVisibility(IntPtr tethering, out int visibility);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_client_clone")]
        internal static extern int CloneClient(out IntPtr cloned, IntPtr original);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_client_get_name")]
        internal static extern int ClientGetName(IntPtr client, out string name);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_client_get_ip_address")]
        internal static extern int ClientGetIPAddr(IntPtr client, out string ipAddr);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_client_get_mac_address")]
        internal static extern int ClientGetMacAddr(IntPtr client, out string macAddr);

        [DllImport(Libraries.Tethering, EntryPoint = "tethering_ext_client_destroy")]
        internal static extern int ClientDestroy(IntPtr client);
    }
}

