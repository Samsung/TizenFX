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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// This namespace provides information about views with properties.
    /// </summary>
    /// <remarks>
    ///  Views are provided to access and handle entities. A view is a structure, which has property elements.
    ///  A view is almost the same as a database "VIEW", which limits access and guarantees performance.
    ///  A "record" represents a single row of the views.
    ///  A record can have basic properties of five types: integer, string, boolean, long, double.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    namespace ContactsViews
    {
        internal static class Property
        {
            private const uint AddressBook = 0x00100000;
            private const uint Group = 0x00200000;
            private const uint Person = 0x00300000;
            private const uint Data = 0x00600000;
            private const uint SpeedDial = 0x00700000;
            private const uint Phonelog = 0x00800000;
            private const uint UpdateInfo = 0x00900000;
            private const uint PhonelogStat = 0x00B00000;

            private const uint Contact = 0x01000000;
            private const uint Name = 0x01100000;
            private const uint Number = 0x01200000;
            private const uint Email = 0x01300000;
            private const uint Address = 0x01400000;
            private const uint URL = 0x01500000;
            private const uint Event = 0x01600000;
            private const uint GroupRelation = 0x01700000;
            private const uint Relationship = 0x01800000;
            private const uint Company = 0x01900000;
            private const uint Nickname = 0x01A00000;
            private const uint Messenger = 0x01B00000;
            private const uint Note = 0x01C00000;
            private const uint Profile = 0x01D00000;
            private const uint Image = 0x01E00000;
            private const uint Extension = 0x01F00000;
            private const uint MyProfile = 0x02000000;
            private const uint ActivityPhoto = 0x02100000;
            private const uint Sip = 0x02200000;

            /* data_type mask 0x000FF000 */
            private const uint DataTypeBool = 0x00010000;
            private const uint DataTypeInt = 0x00020000;
            private const uint DataTypeLong = 0x00030000;
            private const uint DataTypeString = 0x00040000;
            private const uint DataTypeDouble = 0x00050000;
            private const uint DataTypeRecord = 0x00060000;

            private const uint ReadOnly = 0x00001000;

            internal enum Id : uint
            {
                None,

                /* address book */
                AddressBookId = (AddressBook | DataTypeInt | ReadOnly),
                AddressBookAccountId = (AddressBook | DataTypeInt) + 1,
                AddressBookName = (AddressBook | DataTypeString) + 2,
                AddressBookMode = (AddressBook | DataTypeInt) + 3,

                /* group */
                GroupId = (Group | DataTypeInt | ReadOnly),
                GroupAddressBookId = (Group | DataTypeInt) + 1,
                GroupName = (Group | DataTypeString) + 2,
                GroupRingtone = (Group | DataTypeString) + 3,
                GroupImage = (Group | DataTypeString) + 4,
                GroupVibration = (Group | DataTypeString) + 5,
                GroupExtraData = (Group | DataTypeString) + 6,
                GroupIsReadOnly = (Group | DataTypeBool) + 7,
                GroupMessageAlert = (Group | DataTypeString) + 8,

                /* person */
                PersonId = (Person | DataTypeInt | ReadOnly),
                PersonDisplayName = (Person | DataTypeString | ReadOnly) + 1,
                PersonDisplayContactId = (Person | DataTypeInt) + 2,
                PersonRingtone = (Person | DataTypeString) + 3,
                PersonThumbnail = (Person | DataTypeString | ReadOnly) + 4,
                PersonVibration = (Person | DataTypeString) + 5,
                PersonIsFavorite = (Person | DataTypeBool) + 6,
                PersonFavoritePriority = (Person | DataTypeDouble | ReadOnly) + 7,
                PersonLinkCount = (Person | DataTypeInt | ReadOnly) + 8,
                PersonAddressBookIds = (Person | DataTypeString | ReadOnly) + 9,
                PersonHasPhoneNumber = (Person | DataTypeBool | ReadOnly) + 10,
                PersonHasEmail = (Person | DataTypeBool | ReadOnly) + 11,
                PersonDisplayNameIndex = (Person | DataTypeString | ReadOnly) + 12,
                PersonStatus = (Person | DataTypeString | ReadOnly) + 13,
                PersonMessageAlert = (Person | DataTypeString) + 14,
                PersonSnippetType = (Person | DataTypeInt | ReadOnly) + 15,
                PersonSnippetString = (Person | DataTypeString | ReadOnly) + 16,

                /* person-stat */
                PersonUsageType = (Person | DataTypeInt) + 100,
                PersonTimesUsed = (Person | DataTypeInt) + 101,

                /* simple contact : read only */
                /* contact */
                ContactId = (Contact | DataTypeInt | ReadOnly),
                ContactDisplayName = (Contact | DataTypeString | ReadOnly) + 1,
                ContactDisplaySourceDataId = (Contact | DataTypeInt | ReadOnly) + 2,
                ContactAddressBookId = (Contact | DataTypeInt) + 3,
                ContactRingtone = (Contact | DataTypeString) + 4,
                ContactImage = (Contact | DataTypeRecord) + 5,
                ContactThumbnail = (Contact | DataTypeString | ReadOnly) + 6,
                ContactIsFavorite = (Contact | DataTypeBool) + 7,
                ContactHasPhoneNumber = (Contact | DataTypeBool | ReadOnly) + 8,
                ContactHasEmail = (Contact | DataTypeBool | ReadOnly) + 9,
                ContactPersonId = (Contact | DataTypeInt) + 10,
                ContactUId = (Contact | DataTypeString) + 11,
                ContactVibration = (Contact | DataTypeString) + 12,
                ContactChangedTime = (Contact | DataTypeInt | ReadOnly) + 13,
                ContactName = (Contact | DataTypeRecord) + 14,
                ContactCompany = (Contact | DataTypeRecord) + 15,
                ContactNote = (Contact | DataTypeRecord) + 16,
                ContactNumber = (Contact | DataTypeRecord) + 17,
                ContactEmail = (Contact | DataTypeRecord) + 18,
                ContactEvent = (Contact | DataTypeRecord) + 19,
                ContactMessenger = (Contact | DataTypeRecord) + 20,
                ContactAddress = (Contact | DataTypeRecord) + 21,
                ContactURL = (Contact | DataTypeRecord) + 22,
                ContactNickname = (Contact | DataTypeRecord) + 23,
                ContactProfile = (Contact | DataTypeRecord) + 24,
                ContactRelationship = (Contact | DataTypeRecord) + 25,
                ContactGroupRelation = (Contact | DataTypeRecord) + 26,
                ContactExtension = (Contact | DataTypeRecord) + 27,
                ContactLinkMode = (Contact | DataTypeInt) + 28,
                ContactMessageAlert = (Contact | DataTypeString) + 29,
                ContactSip = (Contact | DataTypeRecord) + 30,

                /* my_profile */
                MyProfileId = (MyProfile | DataTypeInt | ReadOnly),
                MyProfileDisplayName = (MyProfile | DataTypeString | ReadOnly) + 1,
                MyProfileAddressBookId = (MyProfile | DataTypeInt) + 2,
                MyProfileImage = (MyProfile | DataTypeRecord) + 3,
                MyProfileThumbnail = (MyProfile | DataTypeString | ReadOnly) + 4,
                MyProfileUId = (MyProfile | DataTypeString) + 5,
                MyProfileChangedTime = (MyProfile | DataTypeInt) + 6,
                MyProfileName = (MyProfile | DataTypeRecord) + 7,
                MyProfileCompany = (MyProfile | DataTypeRecord) + 8,
                MyProfileNote = (MyProfile | DataTypeRecord) + 9,
                MyProfileNumber = (MyProfile | DataTypeRecord) + 10,
                MyProfileEmail = (MyProfile | DataTypeRecord) + 11,
                MyProfileEvent = (MyProfile | DataTypeRecord) + 12,
                MyProfileMessenger = (MyProfile | DataTypeRecord) + 13,
                MyProfileAddress = (MyProfile | DataTypeRecord) + 14,
                MyProfileURL = (MyProfile | DataTypeRecord) + 15,
                MyProfileNickname = (MyProfile | DataTypeRecord) + 16,
                MyProfileProfile = (MyProfile | DataTypeRecord) + 17,
                MyProfileRelationship = (MyProfile | DataTypeRecord) + 18,
                MyProfileExtension = (MyProfile | DataTypeRecord) + 19,
                MyProfileSip = (MyProfile | DataTypeRecord) + 20,

                /* data */
                DataId = (Data | DataTypeInt),
                DataContactId = (Data | DataTypeInt) + 1,
                DataType = (Data | DataTypeInt) + 2,
                DataIsPrimaryDefault = (Data | DataTypeBool) + 3,
                DataIsDefault = (Data | DataTypeBool) + 4,
                DataData1 = (Data | DataTypeInt) + 5,
                DataData2 = (Data | DataTypeString) + 6,
                DataData3 = (Data | DataTypeString) + 7,
                DataData4 = (Data | DataTypeString) + 8,
                DataData5 = (Data | DataTypeString) + 9,
                DataData6 = (Data | DataTypeString) + 10,
                DataData7 = (Data | DataTypeString) + 11,
                DataData8 = (Data | DataTypeString) + 12,
                DataData9 = (Data | DataTypeString) + 13,
                DataData10 = (Data | DataTypeString) + 14,

                /* contact_name */
                NameId = (Name | DataTypeInt | ReadOnly),
                NameContactId = (Name | DataTypeInt) + 1,
                NameFirst = (Name | DataTypeString) + 2,
                NameLast = (Name | DataTypeString) + 3,
                NameAddition = (Name | DataTypeString) + 4,
                NameSuffix = (Name | DataTypeString) + 5,
                NamePrefix = (Name | DataTypeString) + 6,
                NamePhoneticFirst = (Name | DataTypeString) + 7,
                NamePhoneticMiddle = (Name | DataTypeString) + 8,
                NamePhoneticLast = (Name | DataTypeString) + 9,

                /* contact_number */
                NumberId = (Number | DataTypeInt | ReadOnly),
                NumberContactId = (Number | DataTypeInt) + 1,
                NumberType = (Number | DataTypeInt) + 2,
                NumberLabel = (Number | DataTypeString) + 3,
                NumberIsDefault = (Number | DataTypeBool) + 4,
                NumberNumber = (Number | DataTypeString) + 5,
                NumberNumberFilter = (Number | DataTypeString) + 6,
                NumberNormalizedNumber = (Number | DataTypeString | ReadOnly) + 7,
                NumberCleanedNumber = (Number | DataTypeString | ReadOnly) + 8,

                /* contact_email */
                EmailId = (Email | DataTypeInt | ReadOnly),
                EmailContactId = (Email | DataTypeInt) + 1,
                EmailType = (Email | DataTypeInt) + 2,
                EmailLabel = (Email | DataTypeString) + 3,
                EmailIsDefault = (Email | DataTypeBool) + 4,
                EmailEmail = (Email | DataTypeString) + 5,

                /* contact_address */
                AddressId = (Address | DataTypeInt | ReadOnly),
                AddressContactId = (Address | DataTypeInt) + 1,
                AddressType = (Address | DataTypeInt) + 2,
                AddressLabel = (Address | DataTypeString) + 3,
                AddressPostbox = (Address | DataTypeString) + 4,
                AddressPostalCode = (Address | DataTypeString) + 5,
                AddressRegion = (Address | DataTypeString) + 6,
                AddressLocality = (Address | DataTypeString) + 7,
                AddressStreet = (Address | DataTypeString) + 8,
                AddressCountry = (Address | DataTypeString) + 9,
                AddressExtended = (Address | DataTypeString) + 10,
                AddressIsDefault = (Address | DataTypeBool) + 11,

                /* contact_url */
                URLId = (URL | DataTypeInt | ReadOnly),
                URLContactId = (URL | DataTypeInt) + 1,
                URLType = (URL | DataTypeInt) + 2,
                URLLabel = (URL | DataTypeString) + 3,
                URLData = (URL | DataTypeString) + 4,

                /* contact_event */
                EventId = (Event | DataTypeInt | ReadOnly),
                EventContactId = (Event | DataTypeInt) + 1,
                EventType = (Event | DataTypeInt) + 2,
                EventLabel = (Event | DataTypeString) + 3,
                EventDate = (Event | DataTypeInt) + 4,
                EventCalendarType = (Event | DataTypeInt) + 5,
                EventIsLeapMonth = (Event | DataTypeBool) + 6,

                /* contact_grouprelation */
                GroupRelationId = (GroupRelation | DataTypeInt | ReadOnly),
                GroupRelationGroupId = (GroupRelation | DataTypeInt) + 1,
                GroupRelationContactId = (GroupRelation | DataTypeInt) + 2,
                GroupRelationGroupName = (GroupRelation | DataTypeString) + 3,

                /* contact_relationship */
                RelationshipId = (Relationship | DataTypeInt | ReadOnly),
                RelationshipContactId = (Relationship | DataTypeInt) + 1,
                RelationshipType = (Relationship | DataTypeInt) + 2,
                RelationshipLabel = (Relationship | DataTypeString) + 3,
                RelationshipName = (Relationship | DataTypeString) + 4,

                /* contact_image */
                ImageId = (Image | DataTypeInt | ReadOnly),
                ImageContactId = (Image | DataTypeInt) + 1,
                ImageType = (Image | DataTypeInt) + 2,
                ImageLabel = (Image | DataTypeString) + 3,
                ImagePath = (Image | DataTypeString) + 4,
                ImageIsDefault = (Image | DataTypeBool) + 5,

                /* contact_company */
                CompanyId = (Company | DataTypeInt | ReadOnly),
                CompanyContactId = (Company | DataTypeInt) + 1,
                CompanyType = (Company | DataTypeInt) + 2,
                CompanyLabel = (Company | DataTypeString) + 3,
                CompanyName = (Company | DataTypeString) + 4,
                CompanyDepartment = (Company | DataTypeString) + 5,
                CompanyJobTitle = (Company | DataTypeString) + 6,
                CompanyRole = (Company | DataTypeString) + 7,
                CompanyAssistantName = (Company | DataTypeString) + 8,
                CompanyLogo = (Company | DataTypeString) + 9,
                CompanyLocation = (Company | DataTypeString) + 10,
                CompanyDescription = (Company | DataTypeString) + 11,
                CompanyPhoneticName = (Company | DataTypeString) + 12,

                /* contact_nickname */
                NicknameId = (Nickname | DataTypeInt | ReadOnly),
                NicknameContactId = (Nickname | DataTypeInt) + 1,
                NicknameName = (Nickname | DataTypeString) + 2,

                /* contact_messenger */
                MessengerId = (Messenger | DataTypeInt | ReadOnly),
                MessengerContactId = (Messenger | DataTypeInt) + 1,
                MessengerType = (Messenger | DataTypeInt) + 2,
                MessengerLabel = (Messenger | DataTypeString) + 3,
                MessengerIMId = (Messenger | DataTypeString) + 4,

                /* contact_note */
                NoteId = (Note | DataTypeInt | ReadOnly),
                NoteContactId = (Note | DataTypeInt) + 1,
                NoteNote = (Note | DataTypeString) + 2,

                /* contact sip */
                SipId = (Sip | DataTypeInt | ReadOnly),
                SipContactId = (Sip | DataTypeInt) + 1,
                SipAddress = (Sip | DataTypeString) + 2,
                SipType = (Sip | DataTypeInt) + 3,
                SipLabel = (Sip | DataTypeString) + 4,

                /* contact_profile */
                ProfileId = (Profile | DataTypeInt | ReadOnly),
                ProfileContactId = (Profile | DataTypeInt) + 1,
                ProfileUId = (Profile | DataTypeString) + 2,
                ProfileText = (Profile | DataTypeString) + 3,
                ProfileOrder = (Profile | DataTypeInt) + 4,
                ProfileServiceOperation = (Profile | DataTypeString) + 5,
                ProfileMIME = (Profile | DataTypeString) + 6,
                ProfileAppId = (Profile | DataTypeString) + 7,
                ProfileUri = (Profile | DataTypeString) + 8,
                ProfileCategory = (Profile | DataTypeString) + 9,
                ProfileExtraData = (Profile | DataTypeString) + 10,

                ExtensionId = (Extension | DataTypeInt | ReadOnly),
                ExtensionContactId = (Extension | DataTypeInt) + 1,
                ExtensionData1 = (Extension | DataTypeInt) + 2,
                ExtensionData2 = (Extension | DataTypeString) + 3,
                ExtensionData3 = (Extension | DataTypeString) + 4,
                ExtensionData4 = (Extension | DataTypeString) + 5,
                ExtensionData5 = (Extension | DataTypeString) + 6,
                ExtensionData6 = (Extension | DataTypeString) + 7,
                ExtensionData7 = (Extension | DataTypeString) + 8,
                ExtensionData8 = (Extension | DataTypeString) + 9,
                ExtensionData9 = (Extension | DataTypeString) + 10,
                ExtensionData10 = (Extension | DataTypeString) + 11,
                ExtensionData11 = (Extension | DataTypeString) + 12,
                ExtensionData12 = (Extension | DataTypeString) + 13,

                /* speeddial */
                SpeedDialDialNumber = (SpeedDial | DataTypeInt),
                SpeedDialNumberId = (SpeedDial | DataTypeInt) + 1,
                SpeedDialNumber = (SpeedDial | DataTypeString | ReadOnly) + 2,
                SpeedDialNumberLabel = (SpeedDial | DataTypeString | ReadOnly) + 3,
                SpeedDialNumberType = (SpeedDial | DataTypeInt | ReadOnly) + 4,
                SpeedDialPersonId = (SpeedDial | DataTypeInt | ReadOnly) + 5,
                SpeedDialDisplayName = (SpeedDial | DataTypeString | ReadOnly) + 6,
                SpeedDialThumbnail = (SpeedDial | DataTypeString | ReadOnly) + 7,
                SpeedDialNormalizedNumber = (SpeedDial | DataTypeString | ReadOnly) + 8,
                SpeedDialCleanedNumber = (SpeedDial | DataTypeString | ReadOnly) + 9,
                SpeedDialNumberFilter = (SpeedDial | DataTypeString | ReadOnly) + 10,

                /* phonelog */
                PhonelogId = (Phonelog | DataTypeInt | ReadOnly),
                PhonelogPersonId = (Phonelog | DataTypeInt) + 1,
                PhonelogAddress = (Phonelog | DataTypeString) + 2,
                PhonelogLogTime = (Phonelog | DataTypeInt) + 3,
                PhonelogLogType = (Phonelog | DataTypeInt) + 4,
                PhonelogExtraData1 = (Phonelog | DataTypeInt) + 5,
                PhonelogExtraData2 = (Phonelog | DataTypeString) + 6,
                PhonelogNormalizedAddress = (Phonelog | DataTypeString | ReadOnly) + 7,
                PhonelogCleanedAddress = (Phonelog | DataTypeString | ReadOnly) + 8,
                PhonelogAddressFilter = (Phonelog | DataTypeString | ReadOnly) + 9,
                PhonelogSimSlotNo = (Phonelog | DataTypeInt) + 10,

                /* phonelog_stat */
                PhonelogStatLogCount = (PhonelogStat | DataTypeInt | ReadOnly),
                PhonelogStatLogType = (PhonelogStat | DataTypeInt | ReadOnly) + 1,
                PhonelogStatSimSlotNo = (PhonelogStat | DataTypeInt | ReadOnly) + 2,

                /* updated_info : read only */
                UpdateInfoId = (UpdateInfo | DataTypeInt),
                UpdateInfoAddressBookId = (UpdateInfo | DataTypeInt) + 1,
                UpdateInfoType = (UpdateInfo | DataTypeInt) + 2,
                UpdateInfoVersion = (UpdateInfo | DataTypeInt) + 3,
                UpdateInfoImageChanged = (UpdateInfo | DataTypeBool) + 4,
                UpdateInfoLastChangedType = (UpdateInfo | DataTypeInt) + 5,
            }
        }

        internal static class Record
        {
            internal const uint AverageSize = 120;  /* average size of person record */
        }

        /// <summary>
        /// Enumeration for contact change state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum ChangeType
        {
            /// <summary>
            /// Inserted
            /// </summary>
            Inserted,
            /// <summary>
            /// Updated
            /// </summary>
            Updated,
            /// <summary>
            /// Deleted
            /// </summary>
            Deleted,
        }

        /// <summary>
        /// Describes properties of a Address book record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class AddressBook
        {
            /// <summary>
            /// Identifier of this contacts address book view
            /// </summary>
            public const string Uri = "tizen.contacts_view.addressbook";
            /// <summary>
            /// integer, read only,  DB record ID of the address book
            /// </summary>
            public const uint Id = (uint)Property.Id.AddressBookId;
            /// <summary>
            /// integer, read/write once, Account ID that the address book belongs to
            /// </summary>
            public const uint AccountId = (uint)Property.Id.AddressBookAccountId;
            /// <summary>
            /// string, read/write, It cannot be NULL. Duplicate names are not allowed.
            /// </summary>
            public const uint Name = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// integer, read/write, AddressBook mode, refer to the ModeValue
            /// </summary>
            public const uint Mode = (uint)Property.Id.AddressBookMode;

            /// <summary>
            /// Enumeration for Address book mode.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum ModeValue
            {
                /// <summary>
                /// All module can read and write contacts of this address_book
                /// </summary>
                None,
                /// <summary>
                /// All module can only read contacts of this address_book
                /// </summary>
                ReadOnly,
            }
        }

        /// <summary>
        /// Describes properties of a Group record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Group
        {
            /// <summary>
            /// Identifier of this contacts group view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group";
            /// <summary>
            /// DB record ID of the group
            /// </summary>
            public const uint Id = (uint)Property.Id.GroupId;
            /// <summary>
            /// AddressBook ID that the group belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.GroupAddressBookId;
            /// <summary>
            /// Group name
            /// </summary>
            public const uint Name = (uint)Property.Id.GroupName;
            /// <summary>
            /// Ringtone path of the group
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.GroupRingtone;
            /// <summary>
            /// Image path of the group
            /// </summary>
            public const uint ImagePath = (uint)Property.Id.GroupImage;
            /// <summary>
            /// Vibration path of the group
            /// </summary>
            public const uint Vibration = (uint)Property.Id.GroupVibration;
            /// <summary>
            /// Extra data for default group name
            /// </summary>
            public const uint ExtraData = (uint)Property.Id.GroupExtraData;
            /// <summary>
            /// The group is read only or not
            /// </summary>
            public const uint IsReadOnly = (uint)Property.Id.GroupIsReadOnly;
            /// <summary>
            /// Message alert path of the group
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.GroupMessageAlert;
        }

        /// <summary>
        /// Describes properties of a Person record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Person
        {
            /// <summary>
            /// Identifier of this contacts person view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint Id = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account
            /// </summary>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The priority of favorite contacts. it can be used as sorting key
            /// </summary>
            public const uint FavoritePriority = (uint)Property.Id.PersonFavoritePriority;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// keyword matched data type
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        }

        /// <summary>
        /// Describes properties of a Contact record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Contact
        {
            /// <summary>
            /// Identifier of this contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.contact";
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint Id = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the DisplayNameSourceType
            /// </summary>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the contact belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Ringtone path of the contact
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// The contact is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.ContactIsFavorite;
            /// <summary>
            /// The contact has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.ContactHasPhoneNumber;
            /// <summary>
            /// The contact has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to. If set when inserting, a contact will be linked to person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint UId = (uint)Property.Id.ContactUId;
            /// <summary>
            /// Vibration path of the contact
            /// </summary>
            public const uint Vibration = (uint)Property.Id.ContactVibration;
            /// <summary>
            /// Message alert path of the contact
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time
            /// </summary>
            public const uint ChangedTime = (uint)Property.Id.ContactChangedTime;
            /// <summary>
            /// The link mode, refer to the LinkModeValue. If the person_id was set, this value will be ignored
            /// </summary>
            public const uint LinkMode = (uint)Property.Id.ContactLinkMode;
            /// <summary>
            /// Name child record (single)
            /// </summary>
            public const uint Name = (uint)Property.Id.ContactName;
            /// <summary>
            /// Company child record (multiple)
            /// </summary>
            public const uint Company = (uint)Property.Id.ContactCompany;
            /// <summary>
            /// Note child record (multiple)
            /// </summary>
            public const uint Note = (uint)Property.Id.ContactNote;
            /// <summary>
            /// Number child record (multiple)
            /// </summary>
            public const uint Number = (uint)Property.Id.ContactNumber;
            /// <summary>
            /// Email child record (multiple)
            /// </summary>
            public const uint Email = (uint)Property.Id.ContactEmail;
            /// <summary>
            /// Event child record (multiple)
            /// </summary>
            public const uint Event = (uint)Property.Id.ContactEvent;
            /// <summary>
            /// Messenger child record (multiple)
            /// </summary>
            public const uint Messenger = (uint)Property.Id.ContactMessenger;
            /// <summary>
            /// Address child record (multiple)
            /// </summary>
            public const uint Address = (uint)Property.Id.ContactAddress;
            /// <summary>
            /// URL child record (multiple)
            /// </summary>
            public const uint URL = (uint)Property.Id.ContactURL;
            /// <summary>
            /// Nickname child record (multiple)
            /// </summary>
            public const uint Nickname = (uint)Property.Id.ContactNickname;
            /// <summary>
            /// Profile child record (multiple)
            /// </summary>
            public const uint Profile = (uint)Property.Id.ContactProfile;
            /// <summary>
            /// Relationship child record (multiple)
            /// </summary>
            public const uint Relationship = (uint)Property.Id.ContactRelationship;
            /// <summary>
            /// Image child record (multiple)
            /// </summary>
            public const uint Image = (uint)Property.Id.ContactImage;
            /// <summary>
            /// GroupRelation child record (multiple)
            /// </summary>
            public const uint GroupRelation = (uint)Property.Id.ContactGroupRelation;
            /// <summary>
            /// Extension child record (multiple)
            /// </summary>
            public const uint Extension = (uint)Property.Id.ContactExtension;
            /// <summary>
            /// Sip child record (multiple)
            /// </summary>
            public const uint Sip = (uint)Property.Id.ContactSip;

            /// <summary>
            /// Enumeration for link mode when inserting contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum LinkModeValue
            {
                /// <summary>
                /// Auto link immediately
                /// </summary>
                Auto,
                /// <summary>
                /// Do not auto link when the contact is inserted
                /// </summary>
                None
            }

            /// <summary>
            /// Enumeration for Contact display name source type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum DisplayNameSourceType
            {
                /// <summary>
                /// Invalid source of display name
                /// </summary>
                Invalid,
                /// <summary>
                /// Produced display name from email record
                /// </summary>
                Email,
                /// <summary>
                /// Produced display name from number record
                /// </summary>
                Number,
                /// <summary>
                /// Produced display name from nickname record
                /// </summary>
                Nickname,
                /// <summary>
                /// Produced display name from company record
                /// </summary>
                Company,
                /// <summary>
                /// Produced display name from name record
                /// </summary>
                Name,
            }

            /// <summary>
            /// Enumeration for contacts data type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum DataType
            {
                /// <summary>
                /// None
                /// </summary>
                None,
                /// <summary>
                /// Name
                /// </summary>
                Name = 1,
                /// <summary>
                /// Address
                /// </summary>
                Address = 2,
                /// <summary>
                /// Messenger
                /// </summary>
                Messenger = 3,
                /// <summary>
                /// URL
                /// </summary>
                URL = 4,
                /// <summary>
                /// Event
                /// </summary>
                Event = 5,
                /// <summary>
                /// Company
                /// </summary>
                Company = 6,
                /// <summary>
                /// Nickname
                /// </summary>
                Nickname = 7,
                /// <summary>
                /// Number
                /// </summary>
                Number = 8,
                /// <summary>
                /// Email
                /// </summary>
                Email = 9,
                /// <summary>
                /// Profile
                /// </summary>
                Profile = 10,
                /// <summary>
                /// Relationship
                /// </summary>
                Relationship = 11,
                /// <summary>
                /// Note
                /// </summary>
                Note = 12,
                /// <summary>
                /// Image
                /// </summary>
                Image = 13,
                /// <summary>
                /// SIP
                /// </summary>
                Sip = 14,
                /// <summary>
                /// Extension
                /// </summary>
                Extension = 100
            }
        }

        /// <summary>
        /// Describes properties of a Simple contact record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class SimpleContact
        {
            /// <summary>
            /// Identifier of this simple contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact";
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint Id = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceType
            /// </summary>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook that the contact belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Ringtone path of the contact
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// The contact is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.ContactIsFavorite;
            /// <summary>
            /// The contact has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.ContactHasPhoneNumber;
            /// <summary>
            /// The contact has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint UId = (uint)Property.Id.ContactUId;
            /// <summary>
            /// Vibration path of the contact
            /// </summary>
            public const uint Vibration = (uint)Property.Id.ContactVibration;
            /// <summary>
            /// Message alert path of the contact
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time
            /// </summary>
            public const uint ChangedTime = (uint)Property.Id.ContactChangedTime;
        }

        /// <summary>
        /// Describes properties of a My profile record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class MyProfile
        {
            /// <summary>
            /// Identifier of this my profile view
            /// </summary>
            public const string Uri = "tizen.contacts_view.my_profile";
            /// <summary>
            /// DB record ID of the my profile
            /// </summary>
            public const uint Id = (uint)Property.Id.MyProfileId;
            /// <summary>
            /// Display name of the profile
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.MyProfileDisplayName;
            /// <summary>
            /// AddressBook ID that the profile belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.MyProfileAddressBookId;
            /// <summary>
            /// Image thumbnail path of the profile
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.MyProfileThumbnail;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint UId = (uint)Property.Id.MyProfileUId;
            /// <summary>
            /// Last changed profile time
            /// </summary>
            public const uint ChangedTime = (uint)Property.Id.MyProfileChangedTime;
            /// <summary>
            /// Name child record (single)
            /// </summary>
            public const uint Name = (uint)Property.Id.MyProfileName;
            /// <summary>
            /// Company child record (multiple)
            /// </summary>
            public const uint Company = (uint)Property.Id.MyProfileCompany;
            /// <summary>
            /// Note child record (multiple)
            /// </summary>
            public const uint Note = (uint)Property.Id.MyProfileNote;
            /// <summary>
            /// Number child record (multiple)
            /// </summary>
            public const uint Number = (uint)Property.Id.MyProfileNumber;
            /// <summary>
            /// Email child record (multiple)
            /// </summary>
            public const uint Email = (uint)Property.Id.MyProfileEmail;
            /// <summary>
            /// Event child record (multiple)
            /// </summary>
            public const uint Event = (uint)Property.Id.MyProfileEvent;
            /// <summary>
            /// Messenger child record (multiple)
            /// </summary>
            public const uint Messenger = (uint)Property.Id.MyProfileMessenger;
            /// <summary>
            /// Address child record (multiple)
            /// </summary>
            public const uint Address = (uint)Property.Id.MyProfileAddress;
            /// <summary>
            /// URL child record (multiple)
            /// </summary>
            public const uint URL = (uint)Property.Id.MyProfileURL;
            /// <summary>
            /// Nickname child record (multiple)
            /// </summary>
            public const uint Nickname = (uint)Property.Id.MyProfileNickname;
            /// <summary>
            /// Profile child record (multiple)
            /// </summary>
            public const uint Profile = (uint)Property.Id.MyProfileProfile;
            /// <summary>
            /// Relationship child record (multiple)
            /// </summary>
            public const uint Relationship = (uint)Property.Id.MyProfileRelationship;
            /// <summary>
            /// Image child record (multiple)
            /// </summary>
            public const uint Image = (uint)Property.Id.MyProfileImage;
            /// <summary>
            /// Extension child record (multiple)
            /// </summary>
            public const uint Extension = (uint)Property.Id.MyProfileExtension;
            /// <summary>
            /// Sip child record (multiple)
            /// </summary>
            public const uint Sip = (uint)Property.Id.MyProfileSip;
        }

        /// <summary>
        /// Describes properties of a Name record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Name
        {
            /// <summary>
            /// Identifier of this contacts name view
            /// </summary>
            public const string Uri = "tizen.contacts_view.name";
            /// <summary>
            /// DB record ID of the name
            /// </summary>
            public const uint Id = (uint)Property.Id.NameId;
            /// <summary>
            /// Contacts ID that the name record belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.NameContactId;
            /// <summary>
            /// First name
            /// </summary>
            public const uint First = (uint)Property.Id.NameFirst;
            /// <summary>
            /// Last name
            /// </summary>
            public const uint Last = (uint)Property.Id.NameLast;
            /// <summary>
            /// Middle name
            /// </summary>
            public const uint Addition = (uint)Property.Id.NameAddition;
            /// <summary>
            /// Suffix
            /// </summary>
            public const uint Suffix = (uint)Property.Id.NameSuffix;
            /// <summary>
            /// Prefix
            /// </summary>
            public const uint Prefix = (uint)Property.Id.NamePrefix;
            /// <summary>
            /// Pronounce the first name
            /// </summary>
            public const uint PhoneticFirst = (uint)Property.Id.NamePhoneticFirst;
            /// <summary>
            /// Pronounce the middle name
            /// </summary>
            public const uint PhoneticMiddle = (uint)Property.Id.NamePhoneticMiddle;
            /// <summary>
            /// Pronounce the last name
            /// </summary>
            public const uint PhoneticLast = (uint)Property.Id.NamePhoneticLast;
        }

        /// <summary>
        /// Describes properties of a Number record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Number
        {
            /// <summary>
            /// Identifier of this contacts number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.number";
            /// <summary>
            /// DB record ID of the number
            /// </summary>
            public const uint Id = (uint)Property.Id.NumberId;
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.NumberContactId;
            /// <summary>
            /// Number type, refer to the Types
            /// </summary>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Types.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.NumberIsDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint NumberData = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;

            /// <summary>
            /// Enumeration for number type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other number type
                /// </summary>
                Other = 0,
                /// <summary>
                /// Custom number type
                /// </summary>
                Custom = 1 << 0,
                /// <summary>
                /// A telephone number associated with a residence
                /// </summary>
                Home = 1 << 1,
                /// <summary>
                /// A telephone number associated with a place of work
                /// </summary>
                Work = 1 << 2,
                /// <summary>
                /// A voice telephone number
                /// </summary>
                Voice = 1 << 3,
                /// <summary>
                /// A facsimile telephone number
                /// </summary>
                Fax = 1 << 4,
                /// <summary>
                /// The telephone number has voice messaging support
                /// </summary>
                Message = 1 << 5,
                /// <summary>
                /// A cellular telephone number
                /// </summary>
                Cell = 1 << 6,
                /// <summary>
                /// A paging device telephone number
                /// </summary>
                Pager = 1 << 7,
                /// <summary>
                /// A bulletin board system telephone number
                /// </summary>
                BBS = 1 << 8,
                /// <summary>
                /// A MODEM connected telephone number
                /// </summary>
                Modem = 1 << 9,
                /// <summary>
                /// A car-phone telephone number
                /// </summary>
                Car = 1 << 10,
                /// <summary>
                /// An ISDN service telephone number
                /// </summary>
                ISDN = 1 << 11,
                /// <summary>
                /// A video conferencing telephone number
                /// </summary>
                Video = 1 << 12,
                /// <summary>
                /// A personal communication services telephone number
                /// </summary>
                PCS = 1 << 13,
                /// <summary>
                /// A company main number
                /// </summary>
                Company = 1 << 14,
                /// <summary>
                /// A radio phone number
                /// </summary>
                Radio = 1 << 15,
                /// <summary>
                /// An additional type for main
                /// </summary>
                Main = 1 << 29,
                /// <summary>
                /// An additional type for assistant
                /// </summary>
                Assistant = 1 << 30,
            }
        }

        /// <summary>
        /// Describes properties of a Email record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Email
        {
            /// <summary>
            /// Identifier of this contacts email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.email";
            /// <summary>
            /// DB record ID of the email
            /// </summary>
            public const uint Id = (uint)Property.Id.EmailId;
            /// <summary>
            /// Contact ID that the email belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.EmailContactId;
            /// <summary>
            /// Email type, refer to the Types
            /// </summary>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Types.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// The email is default email or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.EmailIsDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Address = (uint)Property.Id.EmailEmail;

            /// <summary>
            /// Enumeration for Contact email type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other email type
                /// </summary>
                Other = 0,
                /// <summary>
                /// Custom email type
                /// </summary>
                Custom = 1 << 0,
                /// <summary>
                /// An email address associated with a residence
                /// </summary>
                Home = 1 << 1,
                /// <summary>
                /// An email address associated with a place of work
                /// </summary>
                Work = 1 << 2,
                /// <summary>
                /// A mobile email address
                /// </summary>
                Mobile = 1 << 3,
            }
        }

        /// <summary>
        /// Describes properties of a Address record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Address
        {
            /// <summary>
            /// Identifier of this contacts address view
            /// </summary>
            public const string Uri = "tizen.contacts_view.address";
            /// <summary>
            /// DB record ID of the address
            /// </summary>
            public const uint Id = (uint)Property.Id.AddressId;
            /// <summary>
            /// Contact ID that the address belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.AddressContactId;
            /// <summary>
            /// Address type, refer to the Types
            /// </summary>
            public const uint Type = (uint)Property.Id.AddressType;
            /// <summary>
            /// Address type label, when the address type is Types.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.AddressLabel;
            /// <summary>
            /// Post office box
            /// </summary>
            public const uint Postbox = (uint)Property.Id.AddressPostbox;
            /// <summary>
            /// Postal code
            /// </summary>
            public const uint PostalCode = (uint)Property.Id.AddressPostalCode;
            /// <summary>
            /// Region
            /// </summary>
            public const uint Region = (uint)Property.Id.AddressRegion;
            /// <summary>
            /// Locality
            /// </summary>
            public const uint Locality = (uint)Property.Id.AddressLocality;
            /// <summary>
            /// Street
            /// </summary>
            public const uint Street = (uint)Property.Id.AddressStreet;
            /// <summary>
            /// Country
            /// </summary>
            public const uint Country = (uint)Property.Id.AddressCountry;
            /// <summary>
            /// Extended address
            /// </summary>
            public const uint Extended = (uint)Property.Id.AddressExtended;
            /// <summary>
            /// The address is default or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.AddressIsDefault;

            /// <summary>
            /// Enumeration for Contact address type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other address type
                /// </summary>
                Other = 0,
                /// <summary>
                /// Custom address type
                /// </summary>
                Custom = 1 << 0,
                /// <summary>
                /// A delivery address for a residence
                /// </summary>
                Home = 1 << 1,
                /// <summary>
                /// A delivery address for a place of work
                /// </summary>
                Work = 1 << 2,
                /// <summary>
                /// A domestic delivery address
                /// </summary>
                Domestic = 1 << 3,
                /// <summary>
                /// An international delivery address
                /// </summary>
                International = 1 << 4,
                /// <summary>
                /// A postal delivery address
                /// </summary>
                Postal = 1 << 5,
                /// <summary>
                /// A parcel delivery address
                /// </summary>
                Parcel = 1 << 6,
            }
        }

        /// <summary>
        /// Describes properties of a Note record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Note
        {
            /// <summary>
            /// Identifier of this contacts note view
            /// </summary>
            public const string Uri = "tizen.contacts_view.note";
            /// <summary>
            /// DB record ID of the note
            /// </summary>
            public const uint Id = (uint)Property.Id.NoteId;
            /// <summary>
            /// Contact ID that the note belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.NoteContactId;
            /// <summary>
            /// Note contents
            /// </summary>
            public const uint Contents = (uint)Property.Id.NoteNote;
        }

        /// <summary>
        /// Describes properties of a URL record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class URL
        {
            /// <summary>
            /// Identifier of this contacts URL view
            /// </summary>
            public const string Uri = "tizen.contacts_view.url";
            /// <summary>
            /// DB record ID of the URL
            /// </summary>
            public const uint Id = (uint)Property.Id.URLId;
            /// <summary>
            /// Contact ID that the URL belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.URLContactId;
            /// <summary>
            /// URL type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.URLType;
            /// <summary>
            /// Custom URL type label, when the URL type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.URLLabel;
            /// <summary>
            /// URL
            /// </summary>
            public const uint URLData = (uint)Property.Id.URLData;

            /// <summary>
            /// Enumeration for Contact URL type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other URL type
                /// </summary>
                Other,
                /// <summary>
                /// Custom URL type
                /// </summary>
                Custom,
                /// <summary>
                /// Home URL type
                /// </summary>
                Home,
                /// <summary>
                /// Work URL type
                /// </summary>
                Work,
            }
        }

        /// <summary>
        /// Describes properties of a Event record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        public static class Event
        {
            /// <summary>
            /// Identifier of this contacts event view
            /// </summary>
            public const string Uri = "tizen.contacts_view.event";
            /// <summary>
            /// DB record ID of the event
            /// </summary>
            public const uint Id = (uint)Property.Id.EventId;
            /// <summary>
            /// Contact ID that the event belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.EventContactId;
            /// <summary>
            /// Event type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.EventType;
            /// <summary>
            /// Custom event type label, when the event type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.EventLabel;
            /// <summary>
            /// Event date(YYYYMMDD). e.g. 2014/1/1 : 20140101. Even if the calendar_type is set as CONTACTS_EVENT_CALENDAR_TYPE_CHINESE, you SHOULD set Gregorian date
            /// </summary>
            public const uint Date = (uint)Property.Id.EventDate;
            /// <summary>
            /// Calendar type, refer to the CalendarType
            /// </summary>
            public const uint IsLeapMonth = (uint)Property.Id.EventIsLeapMonth;

            /// <summary>
            /// Enumeration for Contact event type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other event type
                /// </summary>
                Other,
                /// <summary>
                /// Custom event type
                /// </summary>
                Custom,
                /// <summary>
                /// Birthday event type
                /// </summary>
                Birthday,
                /// <summary>
                /// Anniversary event type
                /// </summary>
                Anniversary
            }

            /// <summary>
            /// Enumeration for Contact event calendar type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum CalendarType
            {
                /// <summary>
                /// Gregorian calendar
                /// </summary>
                Gregorian,
                /// <summary>
                /// Chinese calendar
                /// </summary>
                Chinese
            }
        }

        /// <summary>
        /// Describes properties of a Relationship record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Relationship
        {
            /// <summary>
            /// Identifier of this relationship view
            /// </summary>
            public const string Uri = "tizen.contacts_view.relationship";
            /// <summary>
            /// DB record ID of the relationship
            /// </summary>
            public const uint Id = (uint)Property.Id.RelationshipId;
            /// <summary>
            /// Contact ID that the relationship belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.RelationshipContactId;
            /// <summary>
            /// Relationship type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.RelationshipType;
            /// <summary>
            /// Custom relationship type label, when the relationship type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.RelationshipLabel;
            /// <summary>
            /// Selected contact name that the relationship belongs to
            /// </summary>
            public const uint Name = (uint)Property.Id.RelationshipName;

            /// <summary>
            /// Enumeration for Contact relationship type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other relationship type
                /// </summary>
                Other,
                /// <summary>
                /// Assistant type
                /// </summary>
                Assistant,
                /// <summary>
                /// Brother type
                /// </summary>
                Brother,
                /// <summary>
                /// Child type
                /// </summary>
                Child,
                /// <summary>
                /// Domestic Partner type
                /// </summary>
                DomesticPartner,
                /// <summary>
                /// Father type
                /// </summary>
                Father,
                /// <summary>
                /// Friend type
                /// </summary>
                Friend,
                /// <summary>
                /// Manager type
                /// </summary>
                Manager,
                /// <summary>
                /// Mother type
                /// </summary>
                Mother,
                /// <summary>
                /// Parent type
                /// </summary>
                Parent,
                /// <summary>
                /// Partner type
                /// </summary>
                Partner,
                /// <summary>
                /// Referred by type
                /// </summary>
                ReferredBy,
                /// <summary>
                /// Relative type
                /// </summary>
                Relative,
                /// <summary>
                /// Sister type
                /// </summary>
                Sister,
                /// <summary>
                /// Spouse type
                /// </summary>
                Spouse,
                /// <summary>
                /// Custom type
                /// </summary>
                Custom,
            }
        }

        /// <summary>
        /// Describes properties of a Image record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Image
        {
            /// <summary>
            /// Identifier of this contacts image view
            /// </summary>
            public const string Uri = "tizen.contacts_view.image";
            /// <summary>
            /// DB record ID of the image
            /// </summary>
            public const uint Id = (uint)Property.Id.ImageId;
            /// <summary>
            /// Contact ID that the image belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ImageContactId;
            /// <summary>
            /// Image type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.ImageType;
            /// <summary>
            /// Custom image type label, when the image type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.ImageLabel;
            /// <summary>
            /// Image thumbnail path
            /// </summary>
            public const uint Path = (uint)Property.Id.ImagePath;
            /// <summary>
            /// The Image is default or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.ImageIsDefault;

            /// <summary>
            /// Enumeration for Contact image type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other type
                /// </summary>
                Other,
                /// <summary>
                /// Custom type
                /// </summary>
                Custom,
            }
        }

        /// <summary>
        /// Describes properties of a Company record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Company
        {
            /// <summary>
            /// Identifier of this contacts company view
            /// </summary>
            public const string Uri = "tizen.contacts_view.company";
            /// <summary>
            /// DB record ID of the company
            /// </summary>
            public const uint Id = (uint)Property.Id.CompanyId;
            /// <summary>
            /// Contact ID that the company belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.CompanyContactId;
            /// <summary>
            /// Company type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.CompanyType;
            /// <summary>
            /// Custom company type label, when the company type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.CompanyLabel;
            /// <summary>
            /// Company name
            /// </summary>
            public const uint Name = (uint)Property.Id.CompanyName;
            /// <summary>
            /// Department
            /// </summary>
            public const uint Department = (uint)Property.Id.CompanyDepartment;
            /// <summary>
            /// Job title
            /// </summary>
            public const uint JobTitle = (uint)Property.Id.CompanyJobTitle;
            /// <summary>
            /// Assistant name
            /// </summary>
            public const uint AssistantName = (uint)Property.Id.CompanyAssistantName;
            /// <summary>
            /// Role
            /// </summary>
            public const uint Role = (uint)Property.Id.CompanyRole;
            /// <summary>
            /// Company logo image file path
            /// </summary>
            public const uint Logo = (uint)Property.Id.CompanyLogo;
            /// <summary>
            /// Company location
            /// </summary>
            public const uint Location = (uint)Property.Id.CompanyLocation;
            /// <summary>
            /// Description
            /// </summary>
            public const uint Description = (uint)Property.Id.CompanyDescription;
            /// <summary>
            /// Pronounce the company name
            /// </summary>
            public const uint PhoneticName = (uint)Property.Id.CompanyPhoneticName;

            /// <summary>
            /// Enumeration for Contact company type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other type
                /// </summary>
                Other = 0,
                /// <summary>
                /// Custom type
                /// </summary>
                Custom = 1 << 0,
                /// <summary>
                /// Work type
                /// </summary>
                Work = 1 << 1,
            }
        }

        /// <summary>
        /// Describes properties of a Nickname record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Nickname
        {
            /// <summary>
            /// Identifier of this contacts nickname view
            /// </summary>
            public const string Uri = "tizen.contacts_view.nickname";
            /// <summary>
            /// DB record ID of the nickname
            /// </summary>
            public const uint Id = (uint)Property.Id.NicknameId;
            /// <summary>
            /// Contact ID that the nickname belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.NicknameContactId;
            /// <summary>
            /// Nickname
            /// </summary>
            public const uint Name = (uint)Property.Id.NicknameName;
        }

        /// <summary>
        /// Describes properties of a Messenger record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Messenger
        {
            /// <summary>
            /// Identifier of this contacts messenger view
            /// </summary>
            public const string Uri = "tizen.contacts_view.messenger";
            /// <summary>
            /// DB record ID of the messenger
            /// </summary>
            public const uint Id = (uint)Property.Id.MessengerId;
            /// <summary>
            /// Contact ID that the messenger belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.MessengerContactId;
            /// <summary>
            /// Messenger type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.MessengerType;
            /// <summary>
            /// Custom messenger type label, when the messenger type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.MessengerLabel;
            /// <summary>
            /// Messenger ID (email address or email ID...)
            /// </summary>
            public const uint IMId = (uint)Property.Id.MessengerIMId;

            /// <summary>
            /// Enumeration for Contact messenger type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other messenger type
                /// </summary>
                Other,
                /// <summary>
                /// Custom messenger type
                /// </summary>
                Custom,
                /// <summary>
                /// Google messenger type
                /// </summary>
                Google,
                /// <summary>
                /// Windows live messenger type
                /// </summary>
                WindowsLive,
                /// <summary>
                /// Yahoo messenger type
                /// </summary>
                Yahoo,
                /// <summary>
                /// Facebook messenger type
                /// </summary>
                Facebook,
                /// <summary>
                /// ICQ type
                /// </summary>
                ICQ,
                /// <summary>
                /// AOL instance messenger type
                /// </summary>
                AOL,
                /// <summary>
                /// QQ type
                /// </summary>
                QQ,
                /// <summary>
                /// Jabber type
                /// </summary>
                Jabber,
                /// <summary>
                /// Skype type
                /// </summary>
                Skype,
                /// <summary>
                /// IRC type
                /// </summary>
                IRC,
            }
        }

        /// <summary>
        /// Describes properties of a Profile record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
        public static class Profile
        {
            /// <summary>
            /// Identifier of this contacts profile view
            /// </summary>
            public const string Uri = "tizen.contacts_view.profile";
            /// <summary>
            /// DB record ID of profile
            /// </summary>
            public const uint Id = (uint)Property.Id.ProfileId;
            /// <summary>
            /// Contacts ID that the profile belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ProfileContactId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint UId = (uint)Property.Id.ProfileUId;
            /// <summary>
            /// Profile contents
            /// </summary>
            public const uint Text = (uint)Property.Id.ProfileText;
            /// <summary>
            /// Priority to display the profile
            /// </summary>
            public const uint Order = (uint)Property.Id.ProfileOrder;
            /// <summary>
            /// Data for app_control_set_operation
            /// </summary>
            public const uint ServiceOperation = (uint)Property.Id.ProfileServiceOperation;
            /// <summary>
            /// Data for app_control_set_mime
            /// </summary>
            public const uint Mime = (uint)Property.Id.ProfileMIME;
            /// <summary>
            /// Data for app_control_set_app_id
            /// </summary>
            public const uint AppId = (uint)Property.Id.ProfileAppId;
            /// <summary>
            /// Data for app_control_set_uri
            /// </summary>
            public const uint ProfileUri = (uint)Property.Id.ProfileUri;
            /// <summary>
            /// Data for app_control_set_category
            /// </summary>
            public const uint Category = (uint)Property.Id.ProfileCategory;
            /// <summary>
            /// It includes "key:value,key:value," pairs. You should parse it. And you must base64 encode each key and value
            /// </summary>
            public const uint ExtraData = (uint)Property.Id.ProfileExtraData;
        }

        /// <summary>
        /// Describes properties of a Sip record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Sip
        {
            /// <summary>
            /// Identifier of this contacts sip view
            /// </summary>
            public const string Uri = "tizen.contacts_view.sip";
            /// <summary>
            /// DB record ID of the sip
            /// </summary>
            public const uint Id = (uint)Property.Id.SipId;
            /// <summary>
            /// Contact ID that the sip belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.SipContactId;
            /// <summary>
            /// SIP address
            /// </summary>
            public const uint Address = (uint)Property.Id.SipAddress;
            /// <summary>
            /// sip type, refer to the TypeValue
            /// </summary>
            public const uint Type = (uint)Property.Id.SipType;
            /// <summary>
            /// Custom sip type label, when the sip type is TypeValue.Custom
            /// </summary>
            public const uint Label = (uint)Property.Id.SipLabel;

            /// <summary>
            /// Enumeration for Contact SIP type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other SIP type
                /// </summary>
                Other,
                /// <summary>
                /// Custom SIP type
                /// </summary>
                Custom,
                /// <summary>
                /// Home SIP type
                /// </summary>
                Home,
                /// <summary>
                /// Work SIP type
                /// </summary>
                Work,
            }
        }

        /// <summary>
        /// Describes properties of a Extension record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Extension
        {
            /// <summary>
            /// Identifier of this contacts extension view
            /// </summary>
            public const string Uri = "tizen.contacts_view.extension";
            /// <summary>
            /// DB record ID of the contact extension
            /// </summary>
            public const uint Id = (uint)Property.Id.ExtensionId;
            /// <summary>
            /// Contact ID that the contact extension belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ExtensionContactId;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data1 = (uint)Property.Id.ExtensionData1;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data2 = (uint)Property.Id.ExtensionData2;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data3 = (uint)Property.Id.ExtensionData3;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data4 = (uint)Property.Id.ExtensionData4;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data5 = (uint)Property.Id.ExtensionData5;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data6 = (uint)Property.Id.ExtensionData6;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data7 = (uint)Property.Id.ExtensionData7;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data8 = (uint)Property.Id.ExtensionData8;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data9 = (uint)Property.Id.ExtensionData9;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data10 = (uint)Property.Id.ExtensionData10;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data11 = (uint)Property.Id.ExtensionData11;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data12 = (uint)Property.Id.ExtensionData12;
        }

        /// <summary>
        /// Describes properties of a Group relation record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupRelation
        {
            /// <summary>
            /// Identifier of this relationship view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group_relation";
            /// <summary>
            /// DB record ID of the group relation (can not be used as filter)
            /// </summary>
            public const uint Id = (uint)Property.Id.GroupRelationId;
            /// <summary>
            /// DB record ID of the group
            /// </summary>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// Group name
            /// </summary>
            public const uint Name = (uint)Property.Id.GroupRelationGroupName;
        }

        /// <summary>
        /// Describes properties of a Speed dial record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class SpeedDial
        {
            /// <summary>
            /// Identifier of this contact speed dial view
            /// </summary>
            public const string Uri = "tizen.contacts_view.speeddial";
            /// <summary>
            /// Stored speed dial number
            /// </summary>
            public const uint SpeedDialNumber = (uint)Property.Id.SpeedDialDialNumber;
            /// <summary>
            /// Number ID that the speed dial belongs to
            /// </summary>
            public const uint NumberId = (uint)Property.Id.SpeedDialNumberId;
            /// <summary>
            /// Contact number of specified speed dial
            /// </summary>
            public const uint Number = (uint)Property.Id.SpeedDialNumber;
            /// <summary>
            /// Contact number label of specified speed dial, when the number type is Number.Types.Custom
            /// </summary>
            public const uint NumberLabel = (uint)Property.Id.SpeedDialNumberLabel;
            /// <summary>
            /// Contact number type, refer to the Number.Types
            /// </summary>
            public const uint NumberType = (uint)Property.Id.SpeedDialNumberType;
            /// <summary>
            ///	Person ID that the speed dial belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.SpeedDialPersonId;
            /// <summary>
            /// Display name that the speed dial belongs to
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.SpeedDialDisplayName;
            /// <summary>
            /// Image thumbnail path that the speed dial belongs to
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.SpeedDialThumbnail;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)Property.Id.SpeedDialNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)Property.Id.SpeedDialCleanedNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly
            /// </summary>
            public const uint NumberFilter = (uint)Property.Id.SpeedDialNumberFilter;
        }

        /// <summary>
        /// Describes properties of a Phone log record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class PhoneLog
        {
            /// <summary>
            /// Identifier of this phone log view
            /// </summary>
            public const string Uri = "tizen.contacts_view.phonelog";
            /// <summary>
            /// DB record ID of phone log
            /// </summary>
            public const uint Id = (uint)Property.Id.PhonelogId;
            /// <summary>
            /// Person ID that the phone log belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PhonelogPersonId;
            /// <summary>
            /// Number or Email that the phone log displays
            /// </summary>
            public const uint Address = (uint)Property.Id.PhonelogAddress;
            /// <summary>
            /// Call end time. The value means number of seconds since 1970-01-01 00:00:00 (UTC)
            /// </summary>
            public const uint LogTime = (uint)Property.Id.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the Type
            /// </summary>
            public const uint LogType = (uint)Property.Id.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (e.g. message_id, email_id or duration(seconds) of call)
            /// </summary>
            public const uint ExtraData1 = (uint)Property.Id.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (e.g. short message, subject)
            /// </summary>
            public const uint ExtraData2 = (uint)Property.Id.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedAddress = (uint)Property.Id.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedAddress = (uint)Property.Id.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint AddressFilter = (uint)Property.Id.PhonelogAddressFilter;
            /// <summary>
            /// You can set the related Sim slot number. SimSlotNo 0 means first Sim card, SimSlotNo 1 means second Sim.
            /// </summary>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogSimSlotNo;

            /// <summary>
            /// Enumeration for Phone log type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum Type
            {
                /// <summary>
                /// None
                /// </summary>
                None,
                /// <summary>
                /// Incoming call
                /// </summary>
                VoiceIncoming = 1,
                /// <summary>
                /// Outgoing call
                /// </summary>
                VoiceOutgoing = 2,
                /// <summary>
                /// Incoming video call
                /// </summary>
                VideoIncoming = 3,
                /// <summary>
                /// Outgoing video call
                /// </summary>
                VideoOutgoing = 4,
                /// <summary>
                /// Not confirmed missed call
                /// </summary>
                VoiceMissedUnseen = 5,
                /// <summary>
                /// Confirmed missed call
                /// </summary>
                VoiceMissedSeen = 6,
                /// <summary>
                /// Not confirmed missed video call
                /// </summary>
                VideoMissedUnseen = 7,
                /// <summary>
                /// Confirmed missed video call
                /// </summary>
                VideoMissedSeen = 8,
                /// <summary>
                /// Rejected call
                /// </summary>
                VoiceRejected = 9,
                /// <summary>
                /// Rejected video call
                /// </summary>
                VideoRejected = 10,
                /// <summary>
                /// Blocked call
                /// </summary>
                VoiceBlocked = 11,
                /// <summary>
                /// Blocked video call
                /// </summary>
                VideoBlocked = 12,
                /// <summary>
                /// Incoming MMS
                /// </summary>
                MMSIncoming = 101,
                /// <summary>
                /// Outgoing MMS
                /// </summary>
                MMSOutgoing = 102,
                /// <summary>
                /// Incoming SMS
                /// </summary>
                SMSIncoming = 103,
                /// <summary>
                /// Outgoing SMS
                /// </summary>
                SMSOutgoing = 104,
                /// <summary>
                /// Blocked SMS
                /// </summary>
                SMSBlocked = 105,
                /// <summary>
                /// Blocked MMS
                /// </summary>
                MMSBlocked = 106,
                /// <summary>
                /// Received email
                /// </summary>
                EmailReceived = 201,
                /// <summary>
                /// Sent email
                /// </summary>
                EmailSent = 202,

            }
        }

        /// <summary>
        /// Describes properties of a Contact updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactUpdatedInfo
        {
            /// <summary>
            /// Identifier of this contact updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.contacts_updated_info";
            /// <summary>
            /// Updated contact ID
            /// </summary>
            public const uint ContactId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// AddressBook ID that the updated contact belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Contact change type, refer to the ContactsViews.ChangeType
            /// </summary>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
            /// <summary>
            /// Contact image is changed or not
            /// </summary>
            public const uint ImageChanged = (uint)Property.Id.UpdateInfoImageChanged;
        }

        /// <summary>
        /// Describes properties of a My profile updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class MyProfileUpdatedInfo
        {
            /// <summary>
            /// Identifier of this my profile updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.my_profile_updated_info";
            /// <summary>
            /// Address book ID that the updated my profile belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// MyProfile change type, refer to the ContactsViews.ChangeType
            /// </summary>
            public const uint LastChangedType = (uint)Property.Id.UpdateInfoLastChangedType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes properties of a Group updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.groups_updated_info";
            /// <summary>
            /// Updated group ID
            /// </summary>
            public const uint GroupId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Group change type, refer to the ContactsViews.ChangeType
            /// </summary>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes properties of a Group Member updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupMemberUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group member updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.groups_member_updated_info";
            /// <summary>
            /// Updated group ID
            /// </summary>
            public const uint GroupId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes properties of a Relation updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupRelationUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group relation updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group_relations_updated_info";
            /// <summary>
            /// Group ID of group relation
            /// </summary>
            public const uint GroupId = (uint)Property.Id.GroupId;
            /// <summary>
            /// Contact ID of the updated group relation
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Address book ID of contact that the updated group relation
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.AddressBookId;
            /// <summary>
            /// Group relation change type, refer to the ContactsViews.ChangeType
            /// </summary>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes properties of a PersonContact record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonContact
        {
            /// <summary>
            /// Identifier of this person contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// Contact ID that the person belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// AddressBook ID that the person belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode
            /// </summary>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            ///	AddressBook name that the person belongs to
            /// </summary>
            public const uint AddressBookName = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// keyword matched data type, refer to the Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonNumber record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonNumber
        {
            /// <summary>
            /// Identifier of this person number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/number";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Number ID that the person belongs to
            /// </summary>
            public const uint NumberId = (uint)Property.Id.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection)
            /// </summary>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsPrimaryDefault = (uint)Property.Id.DataIsPrimaryDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint Number = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly.
            /// </summary>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
            /// <summary>
            /// keyword matched data type, refer to they Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonEmail record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonEmail
        {
            /// <summary>
            /// Identifier of this person email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/email";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Email ID that the person belongs to
            /// </summary>
            public const uint EmailId = (uint)Property.Id.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection)
            /// </summary>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// The email is default email or not
            /// </summary>
            public const uint IsPrimaryDefault = (uint)Property.Id.DataIsPrimaryDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Email = (uint)Property.Id.EmailEmail;
            /// <summary>
            /// keyword matched data type, refer to they Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonGroupRelation record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupRelation
        {
            /// <summary>
            /// Identifier of this person group relation view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook name that the person belongs to
            /// </summary>
            public const uint AddressBookName = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode
            /// </summary>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Group ID that the person belongs to
            /// </summary>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// keyword matched data type, refer to they Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonGroupAssigned record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupAssigned
        {
            /// <summary>
            /// Identifier of this person group assigned view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_assigned";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the linked person belongs to (projection)
            /// </summary>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode
            /// </summary>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Group ID that the person belongs to
            /// </summary>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// keyword matched data type, refer to they Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonGroupNotAssigned record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupNotAssigned
        {
            /// <summary>
            /// Identifier of this person group not assigned view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_not_assigned";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the linked person belongs to (projection)
            /// </summary>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode
            /// </summary>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// keyword matched data type, refer to they Contact.DataType
            /// </summary>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes properties of a PersonPhoneLog record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonPhoneLog
        {
            /// <summary>
            /// Identifier of this phone log view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/phonelog";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// DB record ID of phone log
            /// </summary>
            public const uint LogId = (uint)Property.Id.PhonelogId;
            /// <summary>
            /// Number or Email that the phone log displays
            /// </summary>
            public const uint Address = (uint)Property.Id.PhonelogAddress;
            /// <summary>
            /// Number or Email type (projection)
            /// </summary>
            public const uint AddressType = (uint)Property.Id.DataData1;
            /// <summary>
            /// Call end time. The value means number of seconds since 1970-01-01 00:00:00 (UTC)
            /// </summary>
            public const uint LogTime = (uint)Property.Id.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the PhoneLog.Types
            /// </summary>
            public const uint LogType = (uint)Property.Id.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (e.g. message_id, email_id or duration(seconds) of call) (projection)
            /// </summary>
            public const uint ExtraData1 = (uint)Property.Id.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (e.g. short message, subject) (projection)
            /// </summary>
            public const uint ExtraData2 = (uint)Property.Id.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedAddress = (uint)Property.Id.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedAddress = (uint)Property.Id.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint AddressFilter = (uint)Property.Id.PhonelogAddressFilter;
            /// <summary>
            /// It is related to the Sim slot number. SimSlotNo 0 means first Sim card, SimSlotNo 1 means second Sim.
            /// </summary>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogSimSlotNo;
        };

        /// <summary>
        /// Describes properties of a Person Usage record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonUsage
        {
            /// <summary>
            /// Identifier of this person usage view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/usag";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Usage type, refer to the Type
            /// </summary>
            public const uint UsageType = (uint)Property.Id.PersonUsageType;
            /// <summary>
            /// Usage number of person
            /// </summary>
            public const uint TimesUsed = (uint)Property.Id.PersonTimesUsed;

            /// <summary>
            /// Enumeration for Person usage type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum Type
            {
                /// <summary>
                /// None
                /// </summary>
                None,
                /// <summary>
                /// Outgoing call
                /// </summary>
                OutgoingCall,
                /// <summary>
                /// Outgoing message
                /// </summary>
                OutgoingMessage,
                /// <summary>
                /// Outgoing email
                /// </summary>
                OutgoingEmail,
                /// <summary>
                /// Incoming call
                /// </summary>
                IncomingCall,
                /// <summary>
                /// Incoming message
                /// </summary>
                IncomingMessage,
                /// <summary>
                /// Incoming email
                /// </summary>
                IncomingEmail,
                /// <summary>
                /// Missed call
                /// </summary>
                MissedCall,
                /// <summary>
                /// Rejected call
                /// </summary>
                RejectedCall,
                /// <summary>
                /// Blocked call
                /// </summary>
                BlockedCall,
                /// <summary>
                /// Blocked message
                /// </summary>
                BlockedMessage
            }
        };

        /// <summary>
        /// Describes properties of a ContactNumber record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactNumber
        {
            /// <summary>
            /// Identifier of this contacts number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/number";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceType (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// DB record ID of the number
            /// </summary>
            public const uint NumberId = (uint)Property.Id.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection)
            /// </summary>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.NumberIsDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint Number = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly
            /// </summary>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
        };

        /// <summary>
        /// Describes properties of a ContactEmail record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactEmail
        {
            /// <summary>
            /// Identifier of this contacts email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/email";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceType (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// DB record ID of the email
            /// </summary>
            public const uint EmailId = (uint)Property.Id.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection)
            /// </summary>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// Email is default email or not
            /// </summary>
            public const uint IsDefault = (uint)Property.Id.EmailIsDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Email = (uint)Property.Id.EmailEmail;
        };

        /// <summary>
        /// Describes properties of a ContactGroupRelation record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactGroupRelation
        {
            /// <summary>
            /// Identifier of this contact group relation view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/group";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceType (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to
            /// </summary>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// DB record ID of the group relation
            /// </summary>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Group name (projection)
            /// </summary>
            public const uint GroupName = (uint)Property.Id.GroupRelationGroupName;
        };

        /// <summary>
        /// Describes properties of a Phone Log Statistics record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PhoneLogStatistics
        {
            /// <summary>
            /// Identifier of this log statistics view
            /// </summary>
            public const string Uri = "tizen.contacts_view.phonelog_stat";
            /// <summary>
            /// Log count (projection)
            /// </summary>
            public const uint LogCount = (uint)Property.Id.PhonelogStatLogCount;
            /// <summary>
            /// Log type, see the contacts_phone_log_type_e
            /// </summary>
            public const uint LogType = (uint)Property.Id.PhonelogStatLogType;
            /// <summary>
            /// It is related to the Sim slot number. sim_slot_no 0 means first Sim card, sim_slot_no 1 means second Sim. It is same with handle index of telephony handle list. Refer to the telephony_init()
            /// </summary>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogStatSimSlotNo;
        };
    }
}
