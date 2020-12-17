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

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    internal static class Sim
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_sim_import_all_contacts_by_sim_slot_no")]
        internal static extern int ImportAllContactsBySimSlotNo(int sim_slot_no, ContactsSimImportProgressCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_sim_get_initialization_status_by_sim_slot_no")]
        internal static extern int GetInitializatOnStatusBySimSlotNo(int sim_slot_no, out bool completed);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void ContactsSimImportProgressCallback(string uri, IntPtr userData);
    }
}
