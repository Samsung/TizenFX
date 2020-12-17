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
    namespace ContactsViews
    {
        /// <summary>
        /// This namespace provides information about the views with properties.
        /// </summary>
        /// <remarks>
        ///  Views are provided to access and handle entities. A view is a structure, which has property elements.
        ///  A view is almost the same as a database "VIEW", which limits access and guarantees performance.
        ///  A "record" represents a single row of the views.
        ///  A record can have basic properties of five types: integer, string, boolean, long, and double.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>

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
        /// Enumeration for the contact change states.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum ChangeType
        {
            /// <summary>
            /// Inserted.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Inserted,
            /// <summary>
            /// Updated.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Updated,
            /// <summary>
            /// Deleted.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Deleted,
        }

        /// <summary>
        /// Describes the properties of an address book record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class AddressBook
        {
            /// <summary>
            /// Identifier of this contacts address book view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.addressbook";
            /// <summary>
            /// Integer, read only, database record ID of the address book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.AddressBookId;
            /// <summary>
            /// Integer, read/write once, account ID that the address book belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AccountId = (uint)Property.Id.AddressBookAccountId;
            /// <summary>
            /// String, read/write, it cannot be null. Duplicate names are not allowed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// Integer, read/write, AddressBook mode, refer to the ModeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Mode = (uint)Property.Id.AddressBookMode;

            /// <summary>
            /// Enumeration for the address book modes.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum ModeValue
            {
                /// <summary>
                /// All modules can read and write the contacts of this address_book.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                None,
                /// <summary>
                /// All modules can only read the contacts of this address_book.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                ReadOnly,
            }
        }

        /// <summary>
        /// Describes the properties of a Group record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Group
        {
            /// <summary>
            /// Identifier of this contacts group view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.group";
            /// <summary>
            /// Database record ID of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.GroupId;
            /// <summary>
            /// AddressBook ID that the group belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.GroupAddressBookId;
            /// <summary>
            /// Group name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.GroupName;
            /// <summary>
            /// Ringtone path of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.GroupRingtone;
            /// <summary>
            /// Image path of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ImagePath = (uint)Property.Id.GroupImage;
            /// <summary>
            /// Vibration path of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.GroupVibration;
            /// <summary>
            /// Extra data for the default group name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData = (uint)Property.Id.GroupExtraData;
            /// <summary>
            /// The group is read-only or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsReadOnly = (uint)Property.Id.GroupIsReadOnly;
            /// <summary>
            /// Message alert path of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.GroupMessageAlert;
        }

        /// <summary>
        /// Describes the properties of a Person record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Person
        {
            /// <summary>
            /// Identifier of this contacts person view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of the social account.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The priority of the favorite contacts. It can be used as a sorting key.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint FavoritePriority = (uint)Property.Id.PersonFavoritePriority;
            /// <summary>
            /// Link count of the contact records (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Keyword matched data type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        }

        /// <summary>
        /// Describes the properties of a Contact record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Contact
        {
            /// <summary>
            /// Identifier of this contacts view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.contact";
            /// <summary>
            /// Database record ID of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of the display name, refer to the DisplayNameSourceType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the contact belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Ringtone path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// The contact is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.ContactIsFavorite;
            /// <summary>
            /// The contact has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.ContactHasPhoneNumber;
            /// <summary>
            /// The contact has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to. If set when inserting, a contact will be linked to the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint UId = (uint)Property.Id.ContactUId;
            /// <summary>
            /// Vibration path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.ContactVibration;
            /// <summary>
            /// Message alert path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ChangedTime = (uint)Property.Id.ContactChangedTime;
            /// <summary>
            /// The link mode, refer to the LinkModeValue. If the person_id was set, this value will be ignored.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkMode = (uint)Property.Id.ContactLinkMode;
            /// <summary>
            /// Name child record (single).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.ContactName;
            /// <summary>
            /// Company child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Company = (uint)Property.Id.ContactCompany;
            /// <summary>
            /// Note child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Note = (uint)Property.Id.ContactNote;
            /// <summary>
            /// Number child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number = (uint)Property.Id.ContactNumber;
            /// <summary>
            /// Email child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Email = (uint)Property.Id.ContactEmail;
            /// <summary>
            /// Event child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Event = (uint)Property.Id.ContactEvent;
            /// <summary>
            /// Messenger child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Messenger = (uint)Property.Id.ContactMessenger;
            /// <summary>
            /// Address child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.ContactAddress;
            /// <summary>
            /// URL child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint URL = (uint)Property.Id.ContactURL;
            /// <summary>
            /// Nickname child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Nickname = (uint)Property.Id.ContactNickname;
            /// <summary>
            /// Profile child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Profile = (uint)Property.Id.ContactProfile;
            /// <summary>
            /// Relationship child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Relationship = (uint)Property.Id.ContactRelationship;
            /// <summary>
            /// Image child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Image = (uint)Property.Id.ContactImage;
            /// <summary>
            /// GroupRelation child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupRelation = (uint)Property.Id.ContactGroupRelation;
            /// <summary>
            /// Extension child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Extension = (uint)Property.Id.ContactExtension;
            /// <summary>
            /// SIP child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sip = (uint)Property.Id.ContactSip;

            /// <summary>
            /// Enumeration for the link modes when inserting the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum LinkModeValue
            {
                /// <summary>
                /// Auto link immediately.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Auto,
                /// <summary>
                /// Do not auto link when the contact is inserted.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                None
            }

            /// <summary>
            /// Enumeration for the Contact display name source types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum DisplayNameSourceType
            {
                /// <summary>
                /// Invalid source of the display name.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Invalid,
                /// <summary>
                /// Produced display name from the email record.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Email,
                /// <summary>
                /// Produced display name from the number record.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Number,
                /// <summary>
                /// Produced display name from the nickname record.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Nickname,
                /// <summary>
                /// Produced display name from the company record.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Company,
                /// <summary>
                /// Produced display name from the name record.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Name,
            }

            /// <summary>
            /// Enumeration for the contacts data types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum DataType
            {
                /// <summary>
                /// None.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                None,
                /// <summary>
                /// Name.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Name = 1,
                /// <summary>
                /// Address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Address = 2,
                /// <summary>
                /// Messenger.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Messenger = 3,
                /// <summary>
                /// URL.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                URL = 4,
                /// <summary>
                /// Event.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Event = 5,
                /// <summary>
                /// Company.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Company = 6,
                /// <summary>
                /// Nickname.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Nickname = 7,
                /// <summary>
                /// Number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Number = 8,
                /// <summary>
                /// Email.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Email = 9,
                /// <summary>
                /// Profile.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Profile = 10,
                /// <summary>
                /// Relationship.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Relationship = 11,
                /// <summary>
                /// Note.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Note = 12,
                /// <summary>
                /// Image.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Image = 13,
                /// <summary>
                /// SIP.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Sip = 14,
                /// <summary>
                /// Extension.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Extension = 100
            }
        }

        /// <summary>
        /// Describes the properties of a Simple contact record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class SimpleContact
        {
            /// <summary>
            /// Identifier of this simple contact view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.simple_contact";
            /// <summary>
            /// Database record ID of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of the display name, refer to the Contact.DisplayNameSourceType
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook that the contact belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Ringtone path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// The contact is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.ContactIsFavorite;
            /// <summary>
            /// The contact has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.ContactHasPhoneNumber;
            /// <summary>
            /// The contact has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint UId = (uint)Property.Id.ContactUId;
            /// <summary>
            /// Vibration path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.ContactVibration;
            /// <summary>
            /// Message alert path of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ChangedTime = (uint)Property.Id.ContactChangedTime;
        }

        /// <summary>
        /// Describes the properties of My profile record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class MyProfile
        {
            /// <summary>
            /// Identifier of this my profile view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.my_profile";
            /// <summary>
            /// Database record ID of the my profile.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.MyProfileId;
            /// <summary>
            /// Display name of the profile.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.MyProfileDisplayName;
            /// <summary>
            /// AddressBook ID that the profile belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.MyProfileAddressBookId;
            /// <summary>
            /// Image thumbnail path of the profile.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.MyProfileThumbnail;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint UId = (uint)Property.Id.MyProfileUId;
            /// <summary>
            /// Last changed profile time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ChangedTime = (uint)Property.Id.MyProfileChangedTime;
            /// <summary>
            /// Name child record (single).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.MyProfileName;
            /// <summary>
            /// Company child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Company = (uint)Property.Id.MyProfileCompany;
            /// <summary>
            /// Note child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Note = (uint)Property.Id.MyProfileNote;
            /// <summary>
            /// Number child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number = (uint)Property.Id.MyProfileNumber;
            /// <summary>
            /// Email child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Email = (uint)Property.Id.MyProfileEmail;
            /// <summary>
            /// Event child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Event = (uint)Property.Id.MyProfileEvent;
            /// <summary>
            /// Messenger child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Messenger = (uint)Property.Id.MyProfileMessenger;
            /// <summary>
            /// Address child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.MyProfileAddress;
            /// <summary>
            /// URL child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint URL = (uint)Property.Id.MyProfileURL;
            /// <summary>
            /// Nickname child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Nickname = (uint)Property.Id.MyProfileNickname;
            /// <summary>
            /// Profile child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Profile = (uint)Property.Id.MyProfileProfile;
            /// <summary>
            /// Relationship child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Relationship = (uint)Property.Id.MyProfileRelationship;
            /// <summary>
            /// Image child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Image = (uint)Property.Id.MyProfileImage;
            /// <summary>
            /// Extension child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Extension = (uint)Property.Id.MyProfileExtension;
            /// <summary>
            /// SIP child record (multiple).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sip = (uint)Property.Id.MyProfileSip;
        }

        /// <summary>
        /// Describes the properties of a Name record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Name
        {
            /// <summary>
            /// Identifier of this contacts name view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.name";
            /// <summary>
            /// Database record ID of the name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.NameId;
            /// <summary>
            /// Contacts ID that the name record belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.NameContactId;
            /// <summary>
            /// First name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint First = (uint)Property.Id.NameFirst;
            /// <summary>
            /// Last name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Last = (uint)Property.Id.NameLast;
            /// <summary>
            /// Middle name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Addition = (uint)Property.Id.NameAddition;
            /// <summary>
            /// Suffix.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Suffix = (uint)Property.Id.NameSuffix;
            /// <summary>
            /// Prefix.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Prefix = (uint)Property.Id.NamePrefix;
            /// <summary>
            /// Pronounce the first name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PhoneticFirst = (uint)Property.Id.NamePhoneticFirst;
            /// <summary>
            /// Pronounce the middle name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PhoneticMiddle = (uint)Property.Id.NamePhoneticMiddle;
            /// <summary>
            /// Pronounce the last name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PhoneticLast = (uint)Property.Id.NamePhoneticLast;
        }

        /// <summary>
        /// Describes the properties of a Number record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Number
        {
            /// <summary>
            /// Identifier of this contacts number view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.number";
            /// <summary>
            /// Database record ID of the number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.NumberId;
            /// <summary>
            /// Contact ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.NumberContactId;
            /// <summary>
            /// Number type, refer to the Types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Types.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is the default number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.NumberIsDefault;
            /// <summary>
            /// Number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberData = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;

            /// <summary>
            /// Enumeration for the number types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other number type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other = 0,
                /// <summary>
                /// Custom number type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom = 1 << 0,
                /// <summary>
                /// A telephone number associated with a residence.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Home = 1 << 1,
                /// <summary>
                /// A telephone number associated with a place of work.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work = 1 << 2,
                /// <summary>
                /// A voice telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Voice = 1 << 3,
                /// <summary>
                /// A facsimile telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Fax = 1 << 4,
                /// <summary>
                /// The telephone number has voice messaging support.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Message = 1 << 5,
                /// <summary>
                /// A cellular telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Cell = 1 << 6,
                /// <summary>
                /// A paging device telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Pager = 1 << 7,
                /// <summary>
                /// A bulletin board system telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                BBS = 1 << 8,
                /// <summary>
                /// A modem connected telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Modem = 1 << 9,
                /// <summary>
                /// A car-phone telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Car = 1 << 10,
                /// <summary>
                /// An ISDN service telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                ISDN = 1 << 11,
                /// <summary>
                /// A video conferencing telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Video = 1 << 12,
                /// <summary>
                /// A personal communication services telephone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                PCS = 1 << 13,
                /// <summary>
                /// A company main number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Company = 1 << 14,
                /// <summary>
                /// A radio phone number.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Radio = 1 << 15,
                /// <summary>
                /// An additional type for the main.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Main = 1 << 29,
                /// <summary>
                /// An additional type for the assistant.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Assistant = 1 << 30,
            }
        }

        /// <summary>
        /// Describes the properties of an Email record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Email
        {
            /// <summary>
            /// Identifier of this contacts email view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.email";
            /// <summary>
            /// Database record ID of the email.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.EmailId;
            /// <summary>
            /// Contact ID that the email belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.EmailContactId;
            /// <summary>
            /// Email type, refer to the Types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Types.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// The email is default email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.EmailIsDefault;
            /// <summary>
            /// Email address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.EmailEmail;

            /// <summary>
            /// Enumeration for the contact email types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other email type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other = 0,
                /// <summary>
                /// Custom email type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom = 1 << 0,
                /// <summary>
                /// An email address associated with a residence.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Home = 1 << 1,
                /// <summary>
                /// An email address associated with a place of work.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work = 1 << 2,
                /// <summary>
                /// A mobile email address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Mobile = 1 << 3,
            }
        }

        /// <summary>
        /// Describes the properties of an Address record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Address
        {
            /// <summary>
            /// Identifier of this contacts address view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.address";
            /// <summary>
            /// Database record ID of the address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.AddressId;
            /// <summary>
            /// Contact ID that the address belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.AddressContactId;
            /// <summary>
            /// Address type, refer to the Types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.AddressType;
            /// <summary>
            /// Address type label, when the address type is Types.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.AddressLabel;
            /// <summary>
            /// Post office box.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Postbox = (uint)Property.Id.AddressPostbox;
            /// <summary>
            /// Postal code.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PostalCode = (uint)Property.Id.AddressPostalCode;
            /// <summary>
            /// Region.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Region = (uint)Property.Id.AddressRegion;
            /// <summary>
            /// Locality.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Locality = (uint)Property.Id.AddressLocality;
            /// <summary>
            /// Street.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Street = (uint)Property.Id.AddressStreet;
            /// <summary>
            /// Country.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Country = (uint)Property.Id.AddressCountry;
            /// <summary>
            /// Extended address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Extended = (uint)Property.Id.AddressExtended;
            /// <summary>
            /// The address is the default or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.AddressIsDefault;

            /// <summary>
            /// Enumeration for the contact address types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Flags]
            public enum Types
            {
                /// <summary>
                /// Other address type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other = 0,
                /// <summary>
                /// Custom address type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom = 1 << 0,
                /// <summary>
                /// A delivery address for a residence.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Home = 1 << 1,
                /// <summary>
                /// A delivery address for a place of work.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work = 1 << 2,
                /// <summary>
                /// A domestic delivery address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Domestic = 1 << 3,
                /// <summary>
                /// An international delivery address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                International = 1 << 4,
                /// <summary>
                /// A postal delivery address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Postal = 1 << 5,
                /// <summary>
                /// A parcel delivery address.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Parcel = 1 << 6,
            }
        }

        /// <summary>
        /// Describes the properties of a Note record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Note
        {
            /// <summary>
            /// Identifier of this contacts note view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.note";
            /// <summary>
            /// Database record ID of the note.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.NoteId;
            /// <summary>
            /// Contact ID that the note belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.NoteContactId;
            /// <summary>
            /// Note contents.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Contents = (uint)Property.Id.NoteNote;
        }

        /// <summary>
        /// Describes the properties of a URL record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class URL
        {
            /// <summary>
            /// Identifier of this contacts URL view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.url";
            /// <summary>
            /// Database record ID of the URL.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.URLId;
            /// <summary>
            /// Contact ID that the URL belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.URLContactId;
            /// <summary>
            /// URL type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.URLType;
            /// <summary>
            /// Custom URL type label, when the URL type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.URLLabel;
            /// <summary>
            /// URL.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint URLData = (uint)Property.Id.URLData;

            /// <summary>
            /// Enumeration for the Contact URL types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other URL type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Custom URL type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
                /// <summary>
                /// Home URL type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Home,
                /// <summary>
                /// Work URL type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work,
            }
        }

        /// <summary>
        /// Describes the properties of an Event record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        public static class Event
        {
            /// <summary>
            /// Identifier of this contacts event view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.event";
            /// <summary>
            /// Database record ID of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.EventId;
            /// <summary>
            /// Contact ID that the event belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.EventContactId;
            /// <summary>
            /// Event type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.EventType;
            /// <summary>
            /// Custom event type label, when the event type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.EventLabel;
            /// <summary>
            /// Event date(YYYYMMDD). For example, 2014/1/1 : 20140101. Even if the calendar_type is set as CONTACTS_EVENT_CALENDAR_TYPE_CHINESE, you should set the Gregorian date.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Date = (uint)Property.Id.EventDate;
            /// <summary>
            /// Calendar type, refer to the CalendarType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsLeapMonth = (uint)Property.Id.EventIsLeapMonth;

            /// <summary>
            /// Enumeration for the Contact event types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other event type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Custom event type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
                /// <summary>
                /// Birthday event type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Birthday,
                /// <summary>
                /// Anniversary event type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Anniversary
            }

            /// <summary>
            /// Enumeration for the Contact event calendar types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum CalendarType
            {
                /// <summary>
                /// Gregorian calendar.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Gregorian,
                /// <summary>
                /// Chinese calendar.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Chinese
            }
        }

        /// <summary>
        /// Describes the properties of a Relationship record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Relationship
        {
            /// <summary>
            /// Identifier of this relationship view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.relationship";
            /// <summary>
            /// Database record ID of the relationship.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.RelationshipId;
            /// <summary>
            /// Contact ID that the relationship belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.RelationshipContactId;
            /// <summary>
            /// Relationship type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.RelationshipType;
            /// <summary>
            /// Custom relationship type label, when the relationship type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.RelationshipLabel;
            /// <summary>
            /// Selected contact name that the relationship belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.RelationshipName;

            /// <summary>
            /// Enumeration for the contact relationship types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other relationship type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Assistant type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Assistant,
                /// <summary>
                /// Brother type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Brother,
                /// <summary>
                /// Child type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Child,
                /// <summary>
                /// Domestic Partner type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                DomesticPartner,
                /// <summary>
                /// Father type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Father,
                /// <summary>
                /// Friend type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Friend,
                /// <summary>
                /// Manager type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Manager,
                /// <summary>
                /// Mother type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Mother,
                /// <summary>
                /// Parent type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Parent,
                /// <summary>
                /// Partner type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Partner,
                /// <summary>
                /// Referred by type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                ReferredBy,
                /// <summary>
                /// Relative type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Relative,
                /// <summary>
                /// Sister type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Sister,
                /// <summary>
                /// Spouse type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Spouse,
                /// <summary>
                /// Custom type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
            }
        }

        /// <summary>
        /// Describes the properties of an Image record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Image
        {
            /// <summary>
            /// Identifier of this contacts image view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.image";
            /// <summary>
            /// Database record ID of the image.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.ImageId;
            /// <summary>
            /// Contact ID that the image belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ImageContactId;
            /// <summary>
            /// Image type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.ImageType;
            /// <summary>
            /// Custom image type label, when the image type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.ImageLabel;
            /// <summary>
            /// Image thumbnail path.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Path = (uint)Property.Id.ImagePath;
            /// <summary>
            /// The image is the default or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.ImageIsDefault;

            /// <summary>
            /// Enumeration for the contact image types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Custom type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
            }
        }

        /// <summary>
        /// Describes the properties of a Company record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Company
        {
            /// <summary>
            /// Identifier of this contacts company view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.company";
            /// <summary>
            /// Database record ID of the company.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.CompanyId;
            /// <summary>
            /// Contact ID that the company belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.CompanyContactId;
            /// <summary>
            /// Company type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.CompanyType;
            /// <summary>
            /// Custom company type label, when the company type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.CompanyLabel;
            /// <summary>
            /// Company name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.CompanyName;
            /// <summary>
            /// Department.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Department = (uint)Property.Id.CompanyDepartment;
            /// <summary>
            /// Job title.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint JobTitle = (uint)Property.Id.CompanyJobTitle;
            /// <summary>
            /// Assistant name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AssistantName = (uint)Property.Id.CompanyAssistantName;
            /// <summary>
            /// Role.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Role = (uint)Property.Id.CompanyRole;
            /// <summary>
            /// Company logo image file path.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Logo = (uint)Property.Id.CompanyLogo;
            /// <summary>
            /// Company location.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location = (uint)Property.Id.CompanyLocation;
            /// <summary>
            /// Description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description = (uint)Property.Id.CompanyDescription;
            /// <summary>
            /// Pronounce the company name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PhoneticName = (uint)Property.Id.CompanyPhoneticName;

            /// <summary>
            /// Enumeration for the contact company types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other = 0,
                /// <summary>
                /// Custom type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom = 1 << 0,
                /// <summary>
                /// Work type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work = 1 << 1,
            }
        }

        /// <summary>
        /// Describes the properties of a Nickname record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Nickname
        {
            /// <summary>
            /// Identifier of this contacts nickname view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.nickname";
            /// <summary>
            /// Database record ID of the nickname.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.NicknameId;
            /// <summary>
            /// Contact ID that the nickname belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.NicknameContactId;
            /// <summary>
            /// Nickname.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.NicknameName;
        }

        /// <summary>
        /// Describes the properties of a Messenger record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Messenger
        {
            /// <summary>
            /// Identifier of this contacts messenger view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.messenger";
            /// <summary>
            /// Database record ID of the messenger.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.MessengerId;
            /// <summary>
            /// Contact ID that the messenger belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.MessengerContactId;
            /// <summary>
            /// Messenger type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.MessengerType;
            /// <summary>
            /// Custom messenger type label, when the messenger type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.MessengerLabel;
            /// <summary>
            /// Messenger ID (email address, email ID, and so on).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IMId = (uint)Property.Id.MessengerIMId;

            /// <summary>
            /// Enumeration for the contact messenger types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Custom messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
                /// <summary>
                /// Google messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Google,
                /// <summary>
                /// Windows Live messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                WindowsLive,
                /// <summary>
                /// Yahoo messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Yahoo,
                /// <summary>
                /// Facebook messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Facebook,
                /// <summary>
                /// ICQ type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                ICQ,
                /// <summary>
                /// AOL instance messenger type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                AOL,
                /// <summary>
                /// QQ type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                QQ,
                /// <summary>
                /// Jabber type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Jabber,
                /// <summary>
                /// Skype type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Skype,
                /// <summary>
                /// IRC type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                IRC,
            }
        }

        /// <summary>
        /// Describes the properties of a Profile record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
        public static class Profile
        {
            /// <summary>
            /// Identifier of this contacts profile view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.profile";
            /// <summary>
            /// Database record ID of the profile.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.ProfileId;
            /// <summary>
            /// Contacts ID that the profile belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ProfileContactId;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint UId = (uint)Property.Id.ProfileUId;
            /// <summary>
            /// Profile contents.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Text = (uint)Property.Id.ProfileText;
            /// <summary>
            /// Priority to display the profile.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Order = (uint)Property.Id.ProfileOrder;
            /// <summary>
            /// Data for app_control_set_operation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ServiceOperation = (uint)Property.Id.ProfileServiceOperation;
            /// <summary>
            /// Data for app_control_set_mime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Mime = (uint)Property.Id.ProfileMIME;
            /// <summary>
            /// Data for app_control_set_app_id.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AppId = (uint)Property.Id.ProfileAppId;
            /// <summary>
            /// Data for app_control_set_uri.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ProfileUri = (uint)Property.Id.ProfileUri;
            /// <summary>
            /// Data for app_control_set_category.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Category = (uint)Property.Id.ProfileCategory;
            /// <summary>
            /// It includes "key:value,key:value," pairs. You should parse it. And you must base64 encode each key and value.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData = (uint)Property.Id.ProfileExtraData;
        }

        /// <summary>
        /// Describes the properties of a SIP record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Sip
        {
            /// <summary>
            /// Identifier of this contacts SIP view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.sip";
            /// <summary>
            /// Database record ID of the SIP.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.SipId;
            /// <summary>
            /// Contact ID that the SIP belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.SipContactId;
            /// <summary>
            /// SIP address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.SipAddress;
            /// <summary>
            /// SIP type, refer to the TypeValue.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.SipType;
            /// <summary>
            /// Custom SIP type label, when the SIP type is TypeValue.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.SipLabel;

            /// <summary>
            /// Enumeration for the contact SIP types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum TypeValue
            {
                /// <summary>
                /// Other SIP type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Other,
                /// <summary>
                /// Custom SIP type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Custom,
                /// <summary>
                /// Home SIP type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Home,
                /// <summary>
                /// Work SIP type.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                Work,
            }
        }

        /// <summary>
        /// Describes the properties of an Extension record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Extension
        {
            /// <summary>
            /// Identifier of this contacts extension view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.extension";
            /// <summary>
            /// Database record ID of the contact extension.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.ExtensionId;
            /// <summary>
            /// Contact ID that the contact extension belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ExtensionContactId;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data1 = (uint)Property.Id.ExtensionData1;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data2 = (uint)Property.Id.ExtensionData2;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data3 = (uint)Property.Id.ExtensionData3;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data4 = (uint)Property.Id.ExtensionData4;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data5 = (uint)Property.Id.ExtensionData5;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data6 = (uint)Property.Id.ExtensionData6;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data7 = (uint)Property.Id.ExtensionData7;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data8 = (uint)Property.Id.ExtensionData8;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data9 = (uint)Property.Id.ExtensionData9;
            /// <summary>
            /// The extra child record format for the non-provided from thecontacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data10 = (uint)Property.Id.ExtensionData10;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data11 = (uint)Property.Id.ExtensionData11;
            /// <summary>
            /// The extra child record format for the non-provided from the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Data12 = (uint)Property.Id.ExtensionData12;
        }

        /// <summary>
        /// Describes the properties of a Group relation record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupRelation
        {
            /// <summary>
            /// Identifier of this relationship view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.group_relation";
            /// <summary>
            /// Database record ID of the group relation (cannot be used as a filter).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.GroupRelationId;
            /// <summary>
            /// Database record ID of the group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Database record ID of the contact.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// Group name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name = (uint)Property.Id.GroupRelationGroupName;
        }

        /// <summary>
        /// Describes the properties of a Speed dial record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class SpeedDial
        {
            /// <summary>
            /// Identifier of this contacts speed dial view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.speeddial";
            /// <summary>
            /// Stored speed dial number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SpeedDialNumber = (uint)Property.Id.SpeedDialDialNumber;
            /// <summary>
            /// Number ID that the speed dial belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberId = (uint)Property.Id.SpeedDialNumberId;
            /// <summary>
            /// Contact number of the specified speed dial.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number = (uint)Property.Id.SpeedDialNumber;
            /// <summary>
            /// Contact number label of the specified speed dial, when the number type is Number.Types.Custom.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberLabel = (uint)Property.Id.SpeedDialNumberLabel;
            /// <summary>
            /// Contact number type, refer to the Number.Types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberType = (uint)Property.Id.SpeedDialNumberType;
            /// <summary>
            ///	Person ID that the speed dial belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.SpeedDialPersonId;
            /// <summary>
            /// Display name that the speed dial belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.SpeedDialDisplayName;
            /// <summary>
            /// Image thumbnail path that the speed dial belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.SpeedDialThumbnail;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedNumber = (uint)Property.Id.SpeedDialNormalizedNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedNumber = (uint)Property.Id.SpeedDialCleanedNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberFilter = (uint)Property.Id.SpeedDialNumberFilter;
        }

        /// <summary>
        /// Describes the properties of a Phone log record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class PhoneLog
        {
            /// <summary>
            /// Identifier of this phone log view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.phonelog";
            /// <summary>
            /// Database record ID of phone log.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id = (uint)Property.Id.PhonelogId;
            /// <summary>
            /// Person ID that the phone log belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PhonelogPersonId;
            /// <summary>
            /// Number or email that the phone log displays.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.PhonelogAddress;
            /// <summary>
            /// Call end time. The value means the number of seconds since 1970-01-01 00:00:00 (UTC).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogTime = (uint)Property.Id.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the Type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogType = (uint)Property.Id.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (For example, message_id, email_id, or duration (seconds) of the call).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData1 = (uint)Property.Id.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (For example, short message, subject).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData2 = (uint)Property.Id.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedAddress = (uint)Property.Id.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedAddress = (uint)Property.Id.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressFilter = (uint)Property.Id.PhonelogAddressFilter;
            /// <summary>
            /// You can set the related SIM slot number. SimSlotNo 0 means the first SIM card, SimSlotNo 1 means the second SIM.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogSimSlotNo;

            /// <summary>
            /// Enumeration for the phone log types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum Type
            {
                /// <summary>
                /// None.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                None,
                /// <summary>
                /// Incoming call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceIncoming = 1,
                /// <summary>
                /// Outgoing call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceOutgoing = 2,
                /// <summary>
                /// Incoming video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoIncoming = 3,
                /// <summary>
                /// Outgoing video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoOutgoing = 4,
                /// <summary>
                /// Not confirmed missed call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceMissedUnseen = 5,
                /// <summary>
                /// Confirmed missed call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceMissedSeen = 6,
                /// <summary>
                /// Not confirmed missed video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoMissedUnseen = 7,
                /// <summary>
                /// Confirmed missed video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoMissedSeen = 8,
                /// <summary>
                /// Rejected call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceRejected = 9,
                /// <summary>
                /// Rejected video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoRejected = 10,
                /// <summary>
                /// Blocked call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VoiceBlocked = 11,
                /// <summary>
                /// Blocked video call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                VideoBlocked = 12,
                /// <summary>
                /// Incoming MMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                MMSIncoming = 101,
                /// <summary>
                /// Outgoing MMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                MMSOutgoing = 102,
                /// <summary>
                /// Incoming SMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                SMSIncoming = 103,
                /// <summary>
                /// Outgoing SMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                SMSOutgoing = 104,
                /// <summary>
                /// Blocked SMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                SMSBlocked = 105,
                /// <summary>
                /// Blocked MMS.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                MMSBlocked = 106,
                /// <summary>
                /// Received email.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                EmailReceived = 201,
                /// <summary>
                /// Sent email.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                EmailSent = 202,

            }
        }

        /// <summary>
        /// Describes the properties of a Contact updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactUpdatedInfo
        {
            /// <summary>
            /// Identifier of this contacts updated information view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.contacts_updated_info";
            /// <summary>
            /// Updated contact ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// AddressBook ID that the updated contact belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Contact change type, refer to the ContactsViews.ChangeType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
            /// <summary>
            /// Contact image is changed or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ImageChanged = (uint)Property.Id.UpdateInfoImageChanged;
        }

        /// <summary>
        /// Describes the properties of a My profile updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class MyProfileUpdatedInfo
        {
            /// <summary>
            /// Identifier of this my profile updated information view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.my_profile_updated_info";
            /// <summary>
            /// Address book ID that the updated my profile belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// MyProfile change type, refer to the ContactsViews.ChangeType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastChangedType = (uint)Property.Id.UpdateInfoLastChangedType;
            /// <summary>
            /// Updated version.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes the properties of a Group updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupUpdatedInfo
        {
            /// <summary>
            /// Identifier of this groups updated information view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.groups_updated_info";
            /// <summary>
            /// Updated group ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Group change type, refer to the ContactsViews.ChangeType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes the properties of a Group Member updated information record.
        /// </summary>
        /// <remarks>Read-only view.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupMemberUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group members updated information view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.groups_member_updated_info";
            /// <summary>
            /// Updated group ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.UpdateInfoAddressBookId;
            /// <summary>
            /// Updated version.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes the properties of a Relation updated information record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class GroupRelationUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group relations updated information view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.group_relations_updated_info";
            /// <summary>
            /// Group ID of the group relation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.GroupId;
            /// <summary>
            /// Contact ID of the updated group relation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Address book ID of the contacts updated group relation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.AddressBookId;
            /// <summary>
            /// Group relation change type, refer to the ContactsViews.ChangeType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Updated version.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes the properties of a PersonContact record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonContact
        {
            /// <summary>
            /// Identifier of this person's contact view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of the social account (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// Link count of the contact records (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// Contact ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// AddressBook ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            ///	AddressBook name that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookName = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// Keyword matched data type, refer to the Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonNumber record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonNumber
        {
            /// <summary>
            /// Identifier of this person's number view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/number";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Number ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberId = (uint)Property.Id.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is the default number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsPrimaryDefault = (uint)Property.Id.DataIsPrimaryDefault;
            /// <summary>
            /// Number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as the minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
            /// <summary>
            /// Keyword matched data type, refer to they Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonEmail record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonEmail
        {
            /// <summary>
            /// Identifier of this person's email view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/email";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Email ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EmailId = (uint)Property.Id.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// The email is the default email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsPrimaryDefault = (uint)Property.Id.DataIsPrimaryDefault;
            /// <summary>
            /// Email address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Email = (uint)Property.Id.EmailEmail;
            /// <summary>
            /// Keyword matched data type, refer to they Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonGroupRelation record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupRelation
        {
            /// <summary>
            /// Identifier of this person's group relation view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of the contact records (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook name that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookName = (uint)Property.Id.AddressBookName;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Group ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// Keyword matched data type, refer to they Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonGroupAssigned record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupAssigned
        {
            /// <summary>
            /// Identifier of this person's group assigned view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_assigned";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of the social account (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of the contact records (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the linked person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Group ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.GroupRelationContactId;
            /// <summary>
            /// Keyword matched data type, refer to they Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonGroupNotAssigned record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonGroupNotAssigned
        {
            /// <summary>
            /// Identifier of this person's group not assigned view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_not_assigned";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// Status of the social account (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status = (uint)Property.Id.PersonStatus;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Link count of the contact records (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount = (uint)Property.Id.PersonLinkCount;
            /// <summary>
            /// AddressBook IDs that the linked person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookIds = (uint)Property.Id.PersonAddressBookIds;
            /// <summary>
            /// AddressBook ID that the person belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// AddressBook mode, refer to the AddressBook.Mode.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookMode = (uint)Property.Id.AddressBookMode;
            /// <summary>
            /// Contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Keyword matched data type, refer to they Contact.DataType.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetType = (uint)Property.Id.PersonSnippetType;
            /// <summary>
            /// Keyword matched data string.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SnippetString = (uint)Property.Id.PersonSnippetString;
        };

        /// <summary>
        /// Describes the properties of a PersonPhoneLog record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonPhoneLog
        {
            /// <summary>
            /// Identifier of this phone log view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/simple_contact/phonelog";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Database record ID of phone log.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogId = (uint)Property.Id.PhonelogId;
            /// <summary>
            /// Number or email that the phone log displays.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Address = (uint)Property.Id.PhonelogAddress;
            /// <summary>
            /// Number or email type (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressType = (uint)Property.Id.DataData1;
            /// <summary>
            /// Call end time. The value means the number of seconds since 1970-01-01 00:00:00 (UTC).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogTime = (uint)Property.Id.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the PhoneLog.Types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogType = (uint)Property.Id.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (For exmaple, message_id, email_id, or duration (seconds) of the call) (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData1 = (uint)Property.Id.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (For example, short message, subject) (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ExtraData2 = (uint)Property.Id.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedAddress = (uint)Property.Id.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedAddress = (uint)Property.Id.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressFilter = (uint)Property.Id.PhonelogAddressFilter;
            /// <summary>
            /// It is related to the Sim SIM number. SimSlotNo 0 means the first SIM card, SimSlotNo 1 means the second SIM.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogSimSlotNo;
        };

        /// <summary>
        /// Describes the properties of a Person Usage record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PersonUsage
        {
            /// <summary>
            /// Identifier of this person's usage view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.person/usag";
            /// <summary>
            /// Database record ID of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.PersonId;
            /// <summary>
            /// Display name of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.PersonDisplayName;
            /// <summary>
            /// The first character of the first string for grouping. This is normalized using ICU (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayNameIndex = (uint)Property.Id.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayContactId = (uint)Property.Id.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Vibration = (uint)Property.Id.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MessageAlert = (uint)Property.Id.PersonMessageAlert;
            /// <summary>
            /// The person is a favorite or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsFavorite = (uint)Property.Id.PersonIsFavorite;
            /// <summary>
            /// The person has a phone number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasPhoneNumber = (uint)Property.Id.PersonHasPhoneNumber;
            /// <summary>
            /// The person has an email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasEmail = (uint)Property.Id.PersonHasEmail;
            /// <summary>
            /// Usage type, refer to the Type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint UsageType = (uint)Property.Id.PersonUsageType;
            /// <summary>
            /// Usage number of the person.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint TimesUsed = (uint)Property.Id.PersonTimesUsed;

            /// <summary>
            /// Enumeration for the person usage types.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public enum Type
            {
                /// <summary>
                /// None.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                None,
                /// <summary>
                /// Outgoing call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                OutgoingCall,
                /// <summary>
                /// Outgoing message.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                OutgoingMessage,
                /// <summary>
                /// Outgoing email.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                OutgoingEmail,
                /// <summary>
                /// Incoming call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                IncomingCall,
                /// <summary>
                /// Incoming message.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                IncomingMessage,
                /// <summary>
                /// Incoming email.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                IncomingEmail,
                /// <summary>
                /// Missed call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                MissedCall,
                /// <summary>
                /// Rejected call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                RejectedCall,
                /// <summary>
                /// Blocked call.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                BlockedCall,
                /// <summary>
                /// Blocked message.
                /// </summary>
                /// <since_tizen> 4 </since_tizen>
                BlockedMessage
            }
        };

        /// <summary>
        /// Describes the properties of a ContactNumber record.
        /// </summary>
        /// <remarks>Read-only view.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactNumber
        {
            /// <summary>
            /// Identifier of this contacts number view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.simple_contact/number";
            /// <summary>
            /// Contact ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of the display name, refer to the Contact.DisplayNameSourceType (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// Database record ID of the number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberId = (uint)Property.Id.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.NumberLabel;
            /// <summary>
            /// The number is the default number or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.NumberIsDefault;
            /// <summary>
            /// Number.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number = (uint)Property.Id.NumberNumber;
            /// <summary>
            /// If you add a filter with this property, the string will be normalized as the minimal match length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NumberFilter = (uint)Property.Id.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint NormalizedNumber = (uint)Property.Id.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for the search filter.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CleanedNumber = (uint)Property.Id.NumberCleanedNumber;
        };

        /// <summary>
        /// Describes the properties of a ContactEmail record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactEmail
        {
            /// <summary>
            /// Identifier of this contacts email view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.simple_contact/email";
            /// <summary>
            /// Contact ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of the display name, refer to the Contact.DisplayNameSourceType (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// Database record ID of the email.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EmailId = (uint)Property.Id.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type = (uint)Property.Id.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Label = (uint)Property.Id.EmailLabel;
            /// <summary>
            /// The email is the default email or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDefault = (uint)Property.Id.EmailIsDefault;
            /// <summary>
            /// Email address.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Email = (uint)Property.Id.EmailEmail;
        };

        /// <summary>
        /// Describes the properties of a ContactGroupRelation record.
        /// </summary>
        /// <remarks>Read only view</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class ContactGroupRelation
        {
            /// <summary>
            /// Identifier of this contacts group relation view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.simple_contact/group";
            /// <summary>
            /// Contact ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId = (uint)Property.Id.ContactId;
            /// <summary>
            /// Display name of the contact that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplayName = (uint)Property.Id.ContactDisplayName;
            /// <summary>
            /// The source type of the display name, refer to the Contact.DisplayNameSourceType (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DisplaySourceType = (uint)Property.Id.ContactDisplaySourceDataId;
            /// <summary>
            /// AddressBook ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AddressBookId = (uint)Property.Id.ContactAddressBookId;
            /// <summary>
            /// Person ID that the number belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint PersonId = (uint)Property.Id.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RingtonePath = (uint)Property.Id.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ThumbnailPath = (uint)Property.Id.ContactThumbnail;
            /// <summary>
            /// Database record ID of the group relation.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupId = (uint)Property.Id.GroupRelationGroupId;
            /// <summary>
            /// Group name (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint GroupName = (uint)Property.Id.GroupRelationGroupName;
        };

        /// <summary>
        /// Describes the properties of a Phone Log Statistics record.
        /// </summary>
        /// <remarks>Read-only view.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static class PhoneLogStatistics
        {
            /// <summary>
            /// Identifier of this log statistics view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.contacts_view.phonelog_stat";
            /// <summary>
            /// Log count (projection).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogCount = (uint)Property.Id.PhonelogStatLogCount;
            /// <summary>
            /// Log type, see the contacts_phone_log_type_e.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LogType = (uint)Property.Id.PhonelogStatLogType;
            /// <summary>
            /// It is related to the SIM slot number. sim_slot_no 0 means the first SIM card, sim_slot_no 1 means the second SIM. It is same with the handle index of the telephony handle list. Refer to the telephony_init().
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SimSlotNo = (uint)Property.Id.PhonelogStatSimSlotNo;
        };
    }
}
