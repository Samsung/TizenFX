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

using System.Runtime.InteropServices;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Contacts Interop Class
    /// </summary>
    internal static class Service
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_connect")]
        internal static extern int Connect();

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_disconnect")]
        internal static extern int Disconnect();

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_connect_on_thread")]
        internal static extern int OnThreadConnect();

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_disconnect_on_thread")]
        internal static extern int OnThreadDisconnect();

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_connect_with_flags")]
        internal static extern int DisconnectWithFlags(uint flags);
    }
}
