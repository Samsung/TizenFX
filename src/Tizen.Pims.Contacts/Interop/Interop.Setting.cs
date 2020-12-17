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
using Tizen.Pims.Contacts;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    internal static class Setting
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_get_name_display_order")]
        internal static extern int GetNameDisplayOrder(out ContactDisplayOrder nameDisplayOrder);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_set_name_display_order")]
        internal static extern int SetNameDisplayOrder(ContactDisplayOrder nameDisplayOrder);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_get_name_sorting_order")]
        internal static extern int GetNameSortingOrder(out ContactSortingOrder nameSortingOrder);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_set_name_sorting_order")]
        internal static extern int SetNameSortingOrder(ContactSortingOrder nameSortingOrder);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_add_name_display_order_changed_cb")]
        internal static extern int AddNameDisplayOrderChangedCB(DisplayOrderChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_remove_name_display_order_changed_cb")]
        internal static extern int RemoveNameDisplayOrderChangedCB(DisplayOrderChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_add_name_sorting_order_changed_cb")]
        internal static extern int AddNameSortingOrderChangedCB(SortingOrderChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_setting_remove_name_sorting_order_changed_cb")]
        internal static extern int RemoveNameSortingOrderChangedCB(SortingOrderChangedCallback callback, IntPtr userData);


        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void DisplayOrderChangedCallback(ContactDisplayOrder nameDisplayOrder, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void SortingOrderChangedCallback(ContactSortingOrder nameSortingOrder, IntPtr userData);
    }
}
