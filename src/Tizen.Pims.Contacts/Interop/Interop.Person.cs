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
    internal enum ContactsPersonProperty
    {
        NameContact, // Default contacts record
        Number, // Default number record
        Email, // Default Email record
        Image // Default image record
    };

    internal enum  ContactsUsageType
    {
        None,
        OutgoingCall,
        OutgoingMsg,
        OutgoingEmail,
        IncomingCall,
        IncomingMsg,
        IncomingEmail,
        MissedCall,
        RejectedCall,
        BlockedCall,
        BlockedMsg
    };

    internal static partial class Person
    {
        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_link_person")]
        internal static extern int ContactsPersonLinkPerson(int basePersonId, int personId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_unlink_contact")]
        internal static extern int ContactsPersonUnlinkContact(int personId, int contactId, out int unlinkedPersonId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_reset_usage")]
        internal static extern int ContactsPersonResetUsage(int personId, ContactsUsageType type);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_set_favorite_order")]
        internal static extern int ContactsPersonSetFavoriteOrder(int personId, int previousPersonId, int nextPersonId);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_set_default_property")]
        internal static extern int ContactsPersonSetDefaultProperty(ContactsPersonProperty property, int personId, int id);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_get_default_property")]
        internal static extern int ContactsPersonGetDefaultProperty(ContactsPersonProperty property, int personId, out int id);

        [DllImport(Libraries.Contacts, EntryPoint = "contacts_person_get_aggregation_suggestions")]
        internal static extern int ContactsPersonGetAggregationSuggestions(int personId, int limit, out IntPtr listHandle);


    }
}
