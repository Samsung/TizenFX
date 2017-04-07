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
using static Tizen.Pims.Contacts.ContactsFilter;

internal static partial class Interop
{
    internal static partial class Filter
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_create")]
        internal static extern int ContactsFilterCreate(string uri, out IntPtr filterHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_destroy")]
        internal static extern int ContactsFilterDestroy(IntPtr filterHandle);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_str")]
        internal static extern int ContactsFilterAddStr(IntPtr filterHandle, uint propertyId, StringMatchType match, string matchValue);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_int")]
        internal static extern int ContactsFilterAddInt(IntPtr filterHandle, uint propertyId, IntegerMatchType match, int matchValue);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_lli")]
        internal static extern int ContactsFilterAddLli(IntPtr filterHandle, uint propertyId, IntegerMatchType match, long matchValue);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_double")]
        internal static extern int ContactsFilterAddDouble(IntPtr filterHandle, uint propertyId, IntegerMatchType match, double matchValue);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_bool")]
        internal static extern int ContactsFilterAddBool(IntPtr filterHandle, uint propertyId, bool matchValue);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_operator")]
        internal static extern int ContactsFilterAddOperator(IntPtr filterHandle, LogicalOperator operatorType);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_filter_add_filter")]
        internal static extern int ContactsFilterAddFilter(IntPtr parentFilter, IntPtr childFilter);


    }
}
