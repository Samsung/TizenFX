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
    internal static partial class Vcard
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_parse_to_contact_foreach")]
        internal static extern int ContactsVcardParseToContactForeach(string vcardFilePath, ContactsVcardParseCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_parse_to_contacts")]
        internal static extern int ContactsVcardParseToContacts(string vcardStream, out IntPtr contactsList);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_make_from_contact")]
        internal static extern int ContactsVcardMakeFromContact(IntPtr contact, out string vcardStream);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_make_from_my_profile")]
        internal static extern int ContactsVcardMakeFromMyProfile(IntPtr myProfile, out string vcardStream);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_make_from_person")]
        internal static extern int ContactsVcardMakeFromPerson(IntPtr person, out string vcardStream);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_get_entity_count")]
        internal static extern int ContactsVcardGetEntityCount(string vcardFilePath, out int count);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_get_limit_size_of_photo")]
        internal static extern int ContactsVcardGetLimitSizeOfPhoto(out uint limitSize);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_vcard_set_limit_size_of_photo")]
        internal static extern int ContactsVcardSetLimitSizeOfPhoto(uint limitSize);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool ContactsVcardParseCallback(IntPtr recordHandle, IntPtr /* void */ userData);
    }
}
