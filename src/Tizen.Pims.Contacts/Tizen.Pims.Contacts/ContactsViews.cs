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
using System.Collections.Generic;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// This class provides information about views with properties. 
    /// </summary>
    /// <remarks>
    ///  A view is a class which describes properties of a record. A record can have basic properties of five types: integer, string, boolean, long, double.
    /// </remarks>
    public static class ContactsViews
    {
        private const uint PropertyAddressbook = 0x00100000;
        private const uint PropertyGroup = 0x00200000;
        private const uint PropertyPerson = 0x00300000;
        private const uint PropertyData = 0x00600000;
        private const uint PropertySpeedDial =  0x00700000;
        private const uint PropertyPhonelog = 0x00800000;
        private const uint PropertyUpdateInfo = 0x00900000;
        private const uint PropertyPhonelogStat = 0x00B00000;

        private const uint PropertyContact = 0x01000000;
        private const uint PropertyName = 0x01100000;
        private const uint PropertyNumber = 0x01200000;
        private const uint PropertyEmail = 0x01300000;
        private const uint PropertyAddress = 0x01400000;
        private const uint PropertyUrl = 0x01500000;
        private const uint PropertyEvent = 0x01600000;
        private const uint PropertyGroupRelation = 0x01700000;
        private const uint PropertyRelationship = 0x01800000;
        private const uint PropertyCompany = 0x01900000;
        private const uint PropertyNickname = 0x01A00000;
        private const uint PropertyMessenger = 0x01B00000;
        private const uint PropertyNote = 0x01C00000;
        private const uint PropertyProfile = 0x01D00000;
        private const uint PropertyImage = 0x01E00000;
        private const uint PropertyExtension = 0x01F00000;
        private const uint PropertyMyProfile = 0x02000000;
        private const uint PropertyActivityPhoto = 0x02100000;
        private const uint PropertySip = 0x02200000;

	/* data_type mask 0x000FF000 */
        private const uint DataTypeBool = 0x00010000;
        private const uint DataTypeInt = 0x00020000;
        private const uint DataTypeLong = 0x00030000;
        private const uint DataTypeString = 0x00040000;
        private const uint DataTypeDouble = 0x00050000;
        private const uint DataTypeRecord = 0x00060000;

        private const uint ReadOnly = 0x00001000;

        private enum PropertyIds : uint
        {
            /* addressbook */
            AddressbookId = (PropertyAddressbook | DataTypeInt | ReadOnly),
            AddressbookAccountId = (PropertyAddressbook | DataTypeInt) + 1,
            AddressbookName = (PropertyAddressbook | DataTypeString) + 2,
            AddressbookMode = (PropertyAddressbook | DataTypeInt) + 3,

            /* group */
            GroupId = (PropertyGroup | DataTypeInt | ReadOnly),
            GroupAddressbookId = (PropertyGroup | DataTypeInt) + 1,
            GroupName = (PropertyGroup | DataTypeString) + 2,
            GroupRingtone = (PropertyGroup | DataTypeString) + 3,
            GroupImage = (PropertyGroup | DataTypeString) + 4,
            GroupVibration = (PropertyGroup | DataTypeString) + 5,
            GroupExtraData = (PropertyGroup | DataTypeString) + 6,
            GroupIsReadOnly = (PropertyGroup | DataTypeBool) + 7,
            GroupMessageAlert = (PropertyGroup | DataTypeString) + 8,

            /* person */
            PersonId = (PropertyPerson | DataTypeInt | ReadOnly),
            PersonDisplayName = (PropertyPerson | DataTypeString | ReadOnly) + 1,
            PersonDisplayContactId = (PropertyPerson | DataTypeInt) + 2,
            PersonRingtone = (PropertyPerson | DataTypeString) + 3,
            PersonThumbnail = (PropertyPerson | DataTypeString | ReadOnly) + 4,
            PersonVibration = (PropertyPerson | DataTypeString) + 5,
            PersonIsFavorite = (PropertyPerson | DataTypeBool) + 6,
            PersonFavoritePriority = (PropertyPerson | DataTypeDouble | ReadOnly) + 7,
            PersonLinkCount = (PropertyPerson | DataTypeInt | ReadOnly) + 8,
            PersonAddressbookIds = (PropertyPerson | DataTypeString | ReadOnly) + 9,
            PersonHasPhonenumber = (PropertyPerson | DataTypeBool | ReadOnly) + 10,
            PersonHasEmail = (PropertyPerson | DataTypeBool | ReadOnly) + 11,
            PersonDisplayNameIndex = (PropertyPerson | DataTypeString | ReadOnly) + 12,
            PersonStatus = (PropertyPerson | DataTypeString | ReadOnly) + 13,
            PersonMessageAlert = (PropertyPerson | DataTypeString) + 14,
            PersonSnippetType = (PropertyPerson | DataTypeInt | ReadOnly) + 15,
            PersonSnippetString = (PropertyPerson | DataTypeString | ReadOnly) + 16,

            /* person-stat */
            PersonUsageType = (PropertyPerson | DataTypeInt) + 100,
            PersonTimesUsed = (PropertyPerson | DataTypeInt) + 101,

            /* simple contact : read only */
            /* contact */
            ContactId = (PropertyContact | DataTypeInt | ReadOnly),
            ContactDisplayName = (PropertyContact | DataTypeString | ReadOnly) + 1,
            ContactDisplaySourceDataId = (PropertyContact | DataTypeInt | ReadOnly) + 2,
            ContactAddressbookId = (PropertyContact | DataTypeInt) + 3,
            ContactRingtone = (PropertyContact | DataTypeString) + 4,
            ContactImage = (PropertyContact | DataTypeRecord) + 5,
            ContactThumbnail = (PropertyContact | DataTypeString | ReadOnly) + 6,
            ContactIsFavorite = (PropertyContact | DataTypeBool) + 7,
            ContactHasPhonenumber = (PropertyContact | DataTypeBool | ReadOnly) + 8,
            ContactHasEmail = (PropertyContact | DataTypeBool | ReadOnly) + 9,
            ContactPersonId = (PropertyContact | DataTypeInt) + 10,
            ContactUid = (PropertyContact | DataTypeString) + 11,
            ContactVibration = (PropertyContact | DataTypeString) + 12,
            ContactChangedTime = (PropertyContact | DataTypeInt | ReadOnly) + 13,
            ContactName = (PropertyContact | DataTypeRecord) + 14,
            ContactCompany = (PropertyContact | DataTypeRecord) + 15,
            ContactNote = (PropertyContact | DataTypeRecord) + 16,
            ContactNumber = (PropertyContact | DataTypeRecord) + 17,
            ContactEmail = (PropertyContact | DataTypeRecord) + 18,
            ContactEvent = (PropertyContact | DataTypeRecord) + 19,
            ContactMessenger = (PropertyContact | DataTypeRecord) + 20,
            ContactAddress = (PropertyContact | DataTypeRecord) + 21,
            ContactUrl = (PropertyContact | DataTypeRecord) + 22,
            ContactNickname = (PropertyContact | DataTypeRecord) + 23,
            ContactProfile = (PropertyContact | DataTypeRecord) + 24,
            ContactRelationship = (PropertyContact | DataTypeRecord) + 25,
            ContactGroupRelation = (PropertyContact | DataTypeRecord) + 26,
            ContactExtension = (PropertyContact | DataTypeRecord) + 27,
            ContactLinkMode = (PropertyContact | DataTypeInt) + 28,
            ContactMessageAlert = (PropertyContact | DataTypeString) + 29,
            ContactSip = (PropertyContact | DataTypeRecord) + 30,

            /* my_profile */
            MyProfileId = (PropertyMyProfile | DataTypeInt | ReadOnly),
            MyProfileDisplayName = (PropertyMyProfile | DataTypeString | ReadOnly) + 1,
            MyProfileAddressbookId = (PropertyMyProfile | DataTypeInt) + 2,
            MyProfileImage = (PropertyMyProfile | DataTypeRecord) + 3,
            MyProfileThumbnail = (PropertyMyProfile | DataTypeString | ReadOnly) + 4,
            MyProfileUid = (PropertyMyProfile | DataTypeString) + 5,
            MyProfileChangedTime = (PropertyMyProfile | DataTypeInt) + 6,
            MyProfileName = (PropertyMyProfile | DataTypeRecord) + 7,
            MyProfileCompany = (PropertyMyProfile | DataTypeRecord) + 8,
            MyProfileNote = (PropertyMyProfile | DataTypeRecord) + 9,
            MyProfileNumber = (PropertyMyProfile | DataTypeRecord) + 10,
            MyProfileEmail = (PropertyMyProfile | DataTypeRecord) + 11,
            MyProfileEvent = (PropertyMyProfile | DataTypeRecord) + 12,
            MyProfileMessenger = (PropertyMyProfile | DataTypeRecord) + 13,
            MyProfileAddress = (PropertyMyProfile | DataTypeRecord) + 14,
            MyProfileUrl = (PropertyMyProfile | DataTypeRecord) + 15,
            MyProfileNickname = (PropertyMyProfile | DataTypeRecord) + 16,
            MyProfileProfile = (PropertyMyProfile | DataTypeRecord) + 17,
            MyProfileRelationship = (PropertyMyProfile | DataTypeRecord) + 18,
            MyProfileExtension = (PropertyMyProfile | DataTypeRecord) + 19,
            MyProfileSip = (PropertyMyProfile | DataTypeRecord) + 20,

            /* data */
            DataId = (PropertyData | DataTypeInt),
            DataContactId = (PropertyData | DataTypeInt) + 1,
            DataType = (PropertyData | DataTypeInt) + 2,
            DataIsPrimaryDefault = (PropertyData | DataTypeBool) + 3,
            DataIsDefault = (PropertyData | DataTypeBool) + 4,
            DataData1 = (PropertyData | DataTypeInt) + 5,
            DataData2 = (PropertyData | DataTypeString) + 6,
            DataData3 = (PropertyData | DataTypeString) + 7,
            DataData4 = (PropertyData | DataTypeString) + 8,
            DataData5 = (PropertyData | DataTypeString) + 9,
            DataData6 = (PropertyData | DataTypeString) + 10,
            DataData7 = (PropertyData | DataTypeString) + 11,
            DataData8 = (PropertyData | DataTypeString) + 12,
            DataData9 = (PropertyData | DataTypeString) + 13,
            DataData10 = (PropertyData | DataTypeString) + 14,

            /* contact_name */
            NameId = (PropertyName | DataTypeInt | ReadOnly),
            NameContactId = (PropertyName | DataTypeInt) + 1,
            NameFirst = (PropertyName | DataTypeString) + 2,
            NameLast = (PropertyName | DataTypeString) + 3,
            NameAddition = (PropertyName | DataTypeString) + 4,
            NameSuffix = (PropertyName | DataTypeString) + 5,
            NamePrefix = (PropertyName | DataTypeString) + 6,
            NamePhoneticFirst = (PropertyName | DataTypeString) + 7,
            NamePhoneticMiddle = (PropertyName | DataTypeString) + 8,
            NamePhoneticLast = (PropertyName | DataTypeString) + 9,

            /* contact_number */
            NumberId = (PropertyNumber | DataTypeInt | ReadOnly),
            NumberContactId = (PropertyNumber | DataTypeInt) + 1,
            NumberType = (PropertyNumber | DataTypeInt) + 2,
            NumberLabel = (PropertyNumber | DataTypeString) + 3,
            NumberIsDefault = (PropertyNumber | DataTypeBool) + 4,
            NumberNumber = (PropertyNumber | DataTypeString) + 5,
            NumberNumberFilter = (PropertyNumber | DataTypeString) + 6,
            NumberNormalizedNumber = (PropertyNumber | DataTypeString | ReadOnly) + 7,
            NumberCleanedNumber = (PropertyNumber | DataTypeString | ReadOnly) + 8,

            /* contact_email */
            EmailId = (PropertyEmail | DataTypeInt | ReadOnly),
            EmailContactId = (PropertyEmail | DataTypeInt) + 1,
            EmailType = (PropertyEmail | DataTypeInt) + 2,
            EmailLabel = (PropertyEmail | DataTypeString) + 3,
            EmailIsDefault = (PropertyEmail | DataTypeBool) + 4,
            EmailEmail = (PropertyEmail | DataTypeString) + 5,

            /* contact_address */
            AddressId = (PropertyAddress | DataTypeInt | ReadOnly),
            AddressContactId = (PropertyAddress | DataTypeInt) + 1,
            AddressType = (PropertyAddress | DataTypeInt) + 2,
            AddressLabel = (PropertyAddress | DataTypeString) + 3,
            AddressPostbox = (PropertyAddress | DataTypeString) + 4,
            AddressPostalCode = (PropertyAddress | DataTypeString) + 5,
            AddressRegion = (PropertyAddress | DataTypeString) + 6,
            AddressLocality = (PropertyAddress | DataTypeString) + 7,
            AddressStreet = (PropertyAddress | DataTypeString) + 8,
            AddressCountry = (PropertyAddress | DataTypeString) + 9,
            AddressExtended = (PropertyAddress | DataTypeString) + 10,
            AddressIsDefault = (PropertyAddress | DataTypeBool) + 11,

            /* contact_url */
            UrlId = (PropertyUrl | DataTypeInt | ReadOnly),
            UrlContactId = (PropertyUrl | DataTypeInt) + 1,
            UrlType = (PropertyUrl | DataTypeInt) + 2,
            UrlLabel = (PropertyUrl | DataTypeString) + 3,
            UrlUrl = (PropertyUrl | DataTypeString) + 4,

            /* contact_event */
            EventId = (PropertyEvent | DataTypeInt | ReadOnly),
            EventContactId = (PropertyEvent | DataTypeInt) + 1,
            EventType = (PropertyEvent | DataTypeInt) + 2,
            EventLabel = (PropertyEvent | DataTypeString) + 3,
            EventDate = (PropertyEvent | DataTypeInt) + 4,
            EventCalendarType = (PropertyEvent | DataTypeInt) + 5,
            EventIsLeapMonth = (PropertyEvent | DataTypeBool) + 6,

            /* contact_grouprelation */
            GroupRelationId = (PropertyGroupRelation | DataTypeInt | ReadOnly),
            GroupRelationGroupId = (PropertyGroupRelation | DataTypeInt) + 1,
            GroupRelationContactId = (PropertyGroupRelation | DataTypeInt) + 2,
            GroupRelationGroupName = (PropertyGroupRelation | DataTypeString) + 3,

            /* contact_relationship */
            RelationshipId = (PropertyRelationship | DataTypeInt | ReadOnly),
            RelationshipContactId = (PropertyRelationship | DataTypeInt) + 1,
            RelationshipType = (PropertyRelationship | DataTypeInt) + 2,
            RelationshipLabel = (PropertyRelationship | DataTypeString) + 3,
            RelationshipName = (PropertyRelationship | DataTypeString) + 4,

            /* contact_image */
            ImageId = (PropertyImage | DataTypeInt | ReadOnly),
            ImageContactId = (PropertyImage | DataTypeInt) + 1,
            ImageType = (PropertyImage | DataTypeInt) + 2,
            ImageLabel = (PropertyImage | DataTypeString) + 3,
            ImagePath = (PropertyImage | DataTypeString) + 4,
            ImageIsDefault = (PropertyImage | DataTypeBool) + 5,

            /* contact_company */
            CompanyId = (PropertyCompany | DataTypeInt | ReadOnly),
            CompanyContactId = (PropertyCompany | DataTypeInt) + 1,
            CompanyType = (PropertyCompany | DataTypeInt) + 2,
            CompanyLabel = (PropertyCompany | DataTypeString) + 3,
            CompanyName = (PropertyCompany | DataTypeString) + 4,
            CompanyDepartment = (PropertyCompany | DataTypeString) + 5,
            CompanyJobTitle = (PropertyCompany | DataTypeString) + 6,
            CompanyRole = (PropertyCompany | DataTypeString) + 7,
            CompanyAssistantName = (PropertyCompany | DataTypeString) + 8,
            CompanyLogo = (PropertyCompany | DataTypeString) + 9,
            CompanyLocation = (PropertyCompany | DataTypeString) + 10,
            CompanyDescription = (PropertyCompany | DataTypeString) + 11,
            CompanyPhoneticName = (PropertyCompany | DataTypeString) + 12,

            /* contact_nickname */
            NicknameId = (PropertyNickname | DataTypeInt | ReadOnly),
            NicknameContactId = (PropertyNickname | DataTypeInt) + 1,
            NicknameName = (PropertyNickname | DataTypeString) + 2,

            /* contact_messenger */
            MessengerId = (PropertyMessenger | DataTypeInt | ReadOnly),
            MessengerContactId = (PropertyMessenger | DataTypeInt) + 1,
            MessengerType = (PropertyMessenger | DataTypeInt) + 2,
            MessengerLabel = (PropertyMessenger | DataTypeString) + 3,
            MessengerIMId = (PropertyMessenger | DataTypeString) + 4,

            /* contact_note */
            NoteId = (PropertyNote | DataTypeInt | ReadOnly),
            NoteContactId = (PropertyNote | DataTypeInt) + 1,
            NoteNote = (PropertyNote | DataTypeString) + 2,

            /* contact sip */
            SipId = (PropertySip | DataTypeInt | ReadOnly),
            SipContactId = (PropertySip | DataTypeInt) + 1,
            SipAddress = (PropertySip | DataTypeString) + 2,
            SipType = (PropertySip | DataTypeInt) + 3,
            SipLabel = (PropertySip | DataTypeString) + 4,

            /* contact_profile */
            ProfileId = (PropertyProfile | DataTypeInt | ReadOnly),
            ProfileContactId = (PropertyProfile | DataTypeInt) + 1,
            ProfileUid = (PropertyProfile | DataTypeString) + 2,
            ProfileText = (PropertyProfile | DataTypeString) + 3,
            ProfileOrder = (PropertyProfile | DataTypeInt) + 4,
            ProfileServiceOperation = (PropertyProfile | DataTypeString) + 5,
            ProfileMIME = (PropertyProfile | DataTypeString) + 6,
            ProfileAppId = (PropertyProfile | DataTypeString) + 7,
            ProfileUri = (PropertyProfile | DataTypeString) + 8,
            ProfileCategory = (PropertyProfile | DataTypeString) + 9,
            ProfileExtraData = (PropertyProfile | DataTypeString) + 10,

            ExtensionId = (PropertyExtension | DataTypeInt | ReadOnly),
            ExtensionContactId = (PropertyExtension | DataTypeInt) +1,
            ExtensionData1 = (PropertyExtension | DataTypeInt) +2,
            ExtensionData2 = (PropertyExtension | DataTypeString) +3,
            ExtensionData3 = (PropertyExtension | DataTypeString) +4,
            ExtensionData4 = (PropertyExtension | DataTypeString) +5,
            ExtensionData5 = (PropertyExtension | DataTypeString) +6,
            ExtensionData6 = (PropertyExtension | DataTypeString) +7,
            ExtensionData7 = (PropertyExtension | DataTypeString) +8,
            ExtensionData8 = (PropertyExtension | DataTypeString) +9,
            ExtensionData9 = (PropertyExtension | DataTypeString) +10,
            ExtensionData10 = (PropertyExtension | DataTypeString) +11,
            ExtensionData11 = (PropertyExtension | DataTypeString) +12,
            ExtensionData12 = (PropertyExtension | DataTypeString) +13,

            /* speeddial */
            SpeedDialDialNumber = (PropertySpeedDial | DataTypeInt),
            SpeedDialNumberId = (PropertySpeedDial | DataTypeInt) +1,
            SpeedDialNumber = (PropertySpeedDial | DataTypeString | ReadOnly) +2,
            SpeedDialNumberLabel = (PropertySpeedDial | DataTypeString | ReadOnly) +3,
            SpeedDialNumberType = (PropertySpeedDial | DataTypeInt | ReadOnly) +4,
            SpeedDialPersonId = (PropertySpeedDial | DataTypeInt | ReadOnly) +5,
            SpeedDialDisplayName = (PropertySpeedDial | DataTypeString | ReadOnly) +6,
            SpeedDialThumbnail = (PropertySpeedDial | DataTypeString | ReadOnly) +7,
            SpeedDialNormalizedNumber = (PropertySpeedDial | DataTypeString | ReadOnly) +8,
            SpeedDialCleanedNumber = (PropertySpeedDial | DataTypeString | ReadOnly) +9,
            SpeedDialNumberFilter = (PropertySpeedDial | DataTypeString | ReadOnly) +10,

            /* phonelog */
            PhonelogId = (PropertyPhonelog | DataTypeInt | ReadOnly),
            PhonelogPersonId = (PropertyPhonelog | DataTypeInt) + 1,
            PhonelogAddress = (PropertyPhonelog | DataTypeString) + 2,
            PhonelogLogTime = (PropertyPhonelog | DataTypeInt) + 3,
            PhonelogLogType = (PropertyPhonelog | DataTypeInt) + 4,
            PhonelogExtraData1 = (PropertyPhonelog | DataTypeInt) + 5,   /* duration, message_id, email_id */
            PhonelogExtraData2 = (PropertyPhonelog | DataTypeString) + 6,   /* short message, subject */
            PhonelogNormalizedAddress = (PropertyPhonelog | DataTypeString | ReadOnly) + 7,   /* for search by calllog number */
            PhonelogCleanedAddress = (PropertyPhonelog | DataTypeString | ReadOnly) + 8,   /* for search by calllog number */
            PhonelogAddressFilter = (PropertyPhonelog | DataTypeString | ReadOnly) + 9,   /* for search by calllog number */
            PhonelogSIMSlotNo = (PropertyPhonelog | DataTypeInt) + 10,

            /* phonelog_stat */
            PhonelogStatLogCount = (PropertyPhonelogStat | DataTypeInt | ReadOnly),
            PhonelogStatLogType = (PropertyPhonelogStat | DataTypeInt | ReadOnly) + 1,
            PhonelogStatSIMSlotNo = (PropertyPhonelogStat | DataTypeInt | ReadOnly) + 2,

            /* updated_info : read only */
            UpdateInfoId = (PropertyUpdateInfo | DataTypeInt),
            UpdateInfoAddressbookId = (PropertyUpdateInfo | DataTypeInt) +1,
            UpdateInfoType = (PropertyUpdateInfo | DataTypeInt) +2,
            UpdateInfoVersion = (PropertyUpdateInfo | DataTypeInt) +3,
            UpdateInfoImageChanged = (PropertyUpdateInfo | DataTypeBool) +4,
            UpdateInfoLastChangedType = (PropertyUpdateInfo | DataTypeInt)+5,   /* now, it is used for _contacts_my_profile_updated_info */
        }

        /// <summary>
        /// Enumeration for contact change state.
        /// </summary>
        public enum ChangeTypes
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

        public static class Addressbook
        {
            /// <summary>
            /// Identifier of this contacts addressbook view
            /// </summary>
            public const string Uri = "tizen.contacts_view.addressbook";
            /// <summary>
            /// integer, read only,  DB record ID of the addressbook
            /// </summary>
            public const uint Id = (uint)PropertyIds.AddressbookId;
            /// <summary>
            /// integer, read/write once, Account ID that the addressbook belongs to
            /// </summary>
            public const uint AccountId = (uint)PropertyIds.AddressbookAccountId;
            /// <summary>
            /// string, read/write, It cannot be NULL. Duplicate names are not allowed.
            /// </summary>
            public const uint Name = (uint)PropertyIds.AddressbookName;
            /// <summary>
            /// integer, read/write, Addressbook mode, refer to the Modes
            /// </summary>
            public const uint Mode = (uint)PropertyIds.AddressbookMode;

            /// <summary>
            /// Enumeration for Address book mode.
            /// </summary>
            public enum Modes
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

        public static class Group
        {
            /// <summary>
            /// Identifier of this contacts group view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group";
            /// <summary>
            /// DB record ID of the group
            /// </summary>
            public const uint Id = (uint)PropertyIds.GroupId;
            /// <summary>
            /// Addressbook ID that the group belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.GroupAddressbookId;
            /// <summary>
            /// Group name
            /// </summary>
            public const uint Name = (uint)PropertyIds.GroupName;
            /// <summary>
            /// Ringtone path of the group
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.GroupRingtone;
            /// <summary>
            /// Image path of the group
            /// </summary>
            public const uint ImagePath = (uint)PropertyIds.GroupImage;
            /// <summary>
            /// Vibration path of the group
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.GroupVibration;
            /// <summary>
            /// Extra data for default group name
            /// </summary>
            public const uint ExtraData = (uint)PropertyIds.GroupExtraData;
            /// <summary>
            /// The group is read only or not
            /// </summary>
            public const uint IsReadOnly = (uint)PropertyIds.GroupIsReadOnly;
            /// <summary>
            /// Message alert path of the group
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.GroupMessageAlert;
        }

        public static class Person
        {
            /// <summary>
            /// Identifier of this contacts person view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint Id = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// Status of social account
            /// </summary>
            public const uint Status = (uint)PropertyIds.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The priority of favorite contacts. it can be used as sorting key
            /// </summary>
            public const uint FavoritePriority = (uint)PropertyIds.PersonFavoritePriority;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)PropertyIds.PersonLinkCount;
            /// <summary>
            /// Addressbook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressbookIds = (uint)PropertyIds.PersonAddressbookIds;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// kerword matched data type
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        }

        public static class Contact
        {
            /// <summary>
            /// Identifier of this contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.contact";
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint Id = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Display name of the contact
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the DisplayNameSourceTypes
            /// </summary>
            public const uint DisplaySourceType = (uint)PropertyIds.ContactDisplaySourceDataId;
            /// <summary>
            /// Addressbook ID that the contact belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Ringtone path of the contact
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.ContactThumbnail;
            /// <summary>
            /// The contact is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.ContactIsFavorite;
            /// <summary>
            /// The contact has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.ContactHasPhonenumber;
            /// <summary>
            /// The contact has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to. If set when inserting, a contact will be linked to person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.ContactPersonId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid = (uint)PropertyIds.ContactUid;
            /// <summary>
            /// Vibration path of the contact
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.ContactVibration;
            /// <summary>
            /// Message alert path of the contact
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time
            /// </summary>
            public const uint ChangedTime = (uint)PropertyIds.ContactChangedTime;
            /// <summary>
            /// The link mode, refer to the LinkModes. If the person_id was set, this value will be ignored
            /// </summary>
            public const uint LinkMode = (uint)PropertyIds.ContactLinkMode;
            /// <summary>
            /// Name child record (single)
            /// </summary>
            public const uint Name = (uint)PropertyIds.ContactName;
            /// <summary>
            /// Company child record (multiple)
            /// </summary>
            public const uint Company = (uint)PropertyIds.ContactCompany;
            /// <summary>
            /// Note child record (multiple)
            /// </summary>
            public const uint Note = (uint)PropertyIds.ContactNote;
            /// <summary>
            /// Number child record (multiple)
            /// </summary>
            public const uint Number = (uint)PropertyIds.ContactNumber;
            /// <summary>
            /// Email child record (multiple)
            /// </summary>
            public const uint Email = (uint)PropertyIds.ContactEmail;
            /// <summary>
            /// Event child record (multiple)
            /// </summary>
            public const uint Event = (uint)PropertyIds.ContactEvent;
            /// <summary>
            /// Messenger child record (multiple)
            /// </summary>
            public const uint Messenger = (uint)PropertyIds.ContactMessenger;
            /// <summary>
            /// Address child record (multiple)
            /// </summary>
            public const uint Address = (uint)PropertyIds.ContactAddress;
            /// <summary>
            /// Url child record (multiple)
            /// </summary>
            public const uint Url = (uint)PropertyIds.ContactUrl;
            /// <summary>
            /// Nickname child record (multiple)
            /// </summary>
            public const uint Nickname = (uint)PropertyIds.ContactNickname;
            /// <summary>
            /// Profile child record (multiple)
            /// </summary>
            public const uint Profile = (uint)PropertyIds.ContactProfile;
            /// <summary>
            /// Relationship child record (multiple)
            /// </summary>
            public const uint Relationship = (uint)PropertyIds.ContactRelationship;
            /// <summary>
            /// Image child record (multiple)
            /// </summary>
            public const uint Image = (uint)PropertyIds.ContactImage;
            /// <summary>
            /// GroupRelation child record (multiple)
            /// </summary>
            public const uint GroupRelation = (uint)PropertyIds.ContactGroupRelation;
            /// <summary>
            /// Extension child record (multiple)
            /// </summary>
            public const uint Extension = (uint)PropertyIds.ContactExtension;
            /// <summary>
            /// Sip child record (multiple)
            /// </summary>
            public const uint Sip = (uint)PropertyIds.ContactSip;

            /// <summary>
            /// Enumeration for link mode when inserting contact.
            /// </summary>
            public enum LinkModes
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
            public enum DisplayNameSourceTypes
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
            public enum DataTypes
            {
                Name = 1,
                Address = 2,
                Messenger = 3,
                Url = 4,
                Event = 5,
                Company = 6,
                Nickname = 7,
                Number = 8,
                Email = 9,
                Profile = 10,
                Relationsip = 11,
                Note = 12,
                Image = 13,
                Sip = 14,
                Extension = 100
            }
        }

        public static class SimpleContact
        {
            /// <summary>
            /// Identifier of this simple contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact";
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint Id = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Display name of the contact
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceTypes
            /// </summary>
            public const uint DisplaySourceType = (uint)PropertyIds.ContactDisplaySourceDataId;
            /// <summary>
            /// Addressbook that the contact belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Ringtone path of the contact
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.ContactRingtone;
            /// <summary>
            /// Image thumbnail path of the contact
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.ContactThumbnail;
            /// <summary>
            /// The contact is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.ContactIsFavorite;
            /// <summary>
            /// The contact has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.ContactHasPhonenumber;
            /// <summary>
            /// The contact has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.ContactHasEmail;
            /// <summary>
            /// Person ID that the contact belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.ContactPersonId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid = (uint)PropertyIds.ContactUid;
            /// <summary>
            /// Vibration path of the contact
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.ContactVibration;
            /// <summary>
            /// Message alert path of the contact
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.ContactMessageAlert;
            /// <summary>
            /// Last changed contact time
            /// </summary>
            public const uint ChangedTime = (uint)PropertyIds.ContactChangedTime;
        }

        public static class MyProfile
        {
            /// <summary>
            /// Identifier of this my profile view
            /// </summary>
            public const string Uri = "tizen.contacts_view.my_profile";
            /// <summary>
            /// DB record ID of the my profile
            /// </summary>
            public const uint Id = (uint)PropertyIds.MyProfileId;
            /// <summary>
            /// Display name of the profile
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.MyProfileDisplayName;
            /// <summary>
            /// Addressbook ID that the profile belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.MyProfileAddressbookId;
            /// <summary>
            /// Image thumbnail path of the profile
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.MyProfileThumbnail;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid = (uint)PropertyIds.MyProfileUid;
            /// <summary>
            /// Last changed profile time
            /// </summary>
            public const uint ChangedTime = (uint)PropertyIds.MyProfileChangedTime;
            /// <summary>
            /// Name child record (single)
            /// </summary>
            public const uint Name = (uint)PropertyIds.MyProfileName;
            /// <summary>
            /// Company child record (multiple)
            /// </summary>
            public const uint Company = (uint)PropertyIds.MyProfileCompany;
            /// <summary>
            /// Note child record (multiple)
            /// </summary>
            public const uint Note = (uint)PropertyIds.MyProfileNote;
            /// <summary>
            /// Number child record (multiple)
            /// </summary>
            public const uint Number = (uint)PropertyIds.MyProfileNumber;
            /// <summary>
            /// Email child record (multiple)
            /// </summary>
            public const uint Email = (uint)PropertyIds.MyProfileEmail;
            /// <summary>
            /// Event child record (multiple)
            /// </summary>
            public const uint Event = (uint)PropertyIds.MyProfileEvent;
            /// <summary>
            /// Messenger child record (multiple)
            /// </summary>
            public const uint Messenger = (uint)PropertyIds.MyProfileMessenger;
            /// <summary>
            /// Address child record (multiple)
            /// </summary>
            public const uint Address = (uint)PropertyIds.MyProfileAddress;
            /// <summary>
            /// Url child record (multiple)
            /// </summary>
            public const uint Url = (uint)PropertyIds.MyProfileUrl;
            /// <summary>
            /// Nickname child record (multiple)
            /// </summary>
            public const uint Nickname = (uint)PropertyIds.MyProfileNickname;
            /// <summary>
            /// Profile child record (multiple)
            /// </summary>
            public const uint Profile = (uint)PropertyIds.MyProfileProfile;
            /// <summary>
            /// Relationship child record (multiple)
            /// </summary>
            public const uint Relationship = (uint)PropertyIds.MyProfileRelationship;
            /// <summary>
            /// Image child record (multiple)
            /// </summary>
            public const uint Image = (uint)PropertyIds.MyProfileImage;
            /// <summary>
            /// Extension child record (multiple)
            /// </summary>
            public const uint Extension = (uint)PropertyIds.MyProfileExtension;
            /// <summary>
            /// Sip child record (multiple)
            /// </summary>
            public const uint Sip = (uint)PropertyIds.MyProfileSip;
        }

        public static class Name
        {
            /// <summary>
            /// Identifier of this contacts name view
            /// </summary>
            public const string Uri = "tizen.contacts_view.name";
            /// <summary>
            /// DB record ID of the name
            /// </summary>
            public const uint Id = (uint)PropertyIds.NameId;
            /// <summary>
            /// Contacts ID that the name record belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.NameContactId;
            /// <summary>
            /// First name
            /// </summary>
            public const uint First = (uint)PropertyIds.NameFirst;
            /// <summary>
            /// Last name
            /// </summary>
            public const uint Last = (uint)PropertyIds.NameLast;
            /// <summary>
            /// Middle name
            /// </summary>
            public const uint Addition = (uint)PropertyIds.NameAddition;
            /// <summary>
            /// Suffix
            /// </summary>
            public const uint Suffix = (uint)PropertyIds.NameSuffix;
            /// <summary>
            /// Prefix
            /// </summary>
            public const uint Prefix = (uint)PropertyIds.NamePrefix;
            /// <summary>
            /// Pronounce the first name
            /// </summary>
            public const uint PhoneticFirst = (uint)PropertyIds.NamePhoneticFirst;
            /// <summary>
            /// Pronounce the middle name
            /// </summary>
            public const uint PhoneticMiddle = (uint)PropertyIds.NamePhoneticMiddle;
            /// <summary>
            /// Pronounce the last name
            /// </summary>
            public const uint PhoneticLast = (uint)PropertyIds.NamePhoneticLast;
        }

        public static class Number
        {
            /// <summary>
            /// Identifier of this contacts number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.number";
            /// <summary>
            /// DB record ID of the number
            /// </summary>
            public const uint Id = (uint)PropertyIds.NumberId;
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.NumberContactId;
            /// <summary>
            /// Number type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.NumberIsDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint NumberData = (uint)PropertyIds.NumberNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint NormalizedNumber = (uint)PropertyIds.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint CleanedNumber = (uint)PropertyIds.NumberCleanedNumber;
            /// <summary>
            /// You can only use this property for search filter.
            /// </summary>
            public const uint NumberFilter = (uint)PropertyIds.NumberNumberFilter;

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

        public static class Email
        {
            /// <summary>
            /// Identifier of this contacts email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.email";
            /// <summary>
            /// DB record ID of the email
            /// </summary>
            public const uint Id = (uint)PropertyIds.EmailId;
            /// <summary>
            /// Contact ID that the email belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.EmailContactId;
            /// <summary>
            /// Email type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.EmailLabel;
            /// <summary>
            /// The email is default email or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.EmailIsDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Address = (uint)PropertyIds.EmailEmail;

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

        public static class Address
        {
            /// <summary>
            /// Identifier of this contacts address view
            /// </summary>
            public const string Uri = "tizen.contacts_view.address";
            /// <summary>
            /// DB record ID of the address
            /// </summary>
            public const uint Id = (uint)PropertyIds.AddressId;
            /// <summary>
            /// Contact ID that the address belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.AddressContactId;
            /// <summary>
            /// Address type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.AddressType;
            /// <summary>
            /// Address type label, when the address type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.AddressLabel;
            /// <summary>
            /// Post office box
            /// </summary>
            public const uint Postbox = (uint)PropertyIds.AddressPostbox;
            /// <summary>
            /// Postal code
            /// </summary>
            public const uint PostalCode = (uint)PropertyIds.AddressPostalCode;
            /// <summary>
            /// Region
            /// </summary>
            public const uint Region = (uint)PropertyIds.AddressRegion;
            /// <summary>
            /// Locality
            /// </summary>
            public const uint Locality = (uint)PropertyIds.AddressLocality;
            /// <summary>
            /// Street
            /// </summary>
            public const uint Street = (uint)PropertyIds.AddressStreet;
            /// <summary>
            /// Country
            /// </summary>
            public const uint Country = (uint)PropertyIds.AddressCountry;
            /// <summary>
            /// Extended address
            /// </summary>
            public const uint Extended = (uint)PropertyIds.AddressExtended;
            /// <summary>
            /// The address is default or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.AddressIsDefault;

            /// <summary>
            /// Enumeration for Contact address type.
            /// </summary>
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

        public static class Note
        {
            /// <summary>
            /// Identifier of this contacts note view
            /// </summary>
            public const string Uri = "tizen.contacts_view.note";
            /// <summary>
            /// DB record ID of the note
            /// </summary>
            public const uint Id = (uint)PropertyIds.NoteId;
            /// <summary>
            /// Contact ID that the note belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.NoteContactId;
            /// <summary>
            /// Note contents
            /// </summary>
            public const uint Contents = (uint)PropertyIds.NoteNote;
        }

        public static class Url
        {
            /// <summary>
            /// Identifier of this contacts URL view
            /// </summary>
            public const string Uri = "tizen.contacts_view.url";
            /// <summary>
            /// DB record ID of the URL
            /// </summary>
            public const uint Id = (uint)PropertyIds.UrlId;
            /// <summary>
            /// Contact ID that the URL belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.UrlContactId;
            /// <summary>
            /// URL type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.UrlType;
            /// <summary>
            /// Custom URL type label, when the URL type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.UrlLabel;
            /// <summary>
            /// URL
            /// </summary>
            public const uint UrlData = (uint)PropertyIds.UrlUrl;

            /// <summary>
            /// Enumeration for Contact URL type.
            /// </summary>
            public enum Types
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

        public static class Event
        {
            /// <summary>
            /// Identifier of this contacts event view
            /// </summary>
            public const string Uri = "tizen.contacts_view.event";
            /// <summary>
            /// DB record ID of the event
            /// </summary>
            public const uint Id = (uint)PropertyIds.EventId;
            /// <summary>
            /// Contact ID that the event belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.EventContactId;
            /// <summary>
            /// Event type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.EventType;
            /// <summary>
            /// Custom event type label, when the event type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.EventLabel;
            /// <summary>
            /// Event date(YYYYMMDD). e.g. 2014/1/1 : 20140101. Even if the calendar_type is set as CONTACTS_EVENT_CALENDAR_TYPE_CHINESE, you SHOULD set Gregorian date
            /// </summary>
            public const uint Date = (uint)PropertyIds.EventDate;
            /// <summary>
            /// Calendar type, refer to the CalendarTypes
            /// </summary>
            public const uint IsLeapMonth = (uint)PropertyIds.EventIsLeapMonth;

            /// <summary>
            /// Enumeration for Contact event type.
            /// </summary>
            public enum Types
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
            public enum CalendarTypes
            {
                /// <summary>
                /// Gregorian calendar
                /// </summary>
                Gregorian,
                /// <summary>
                /// Chinese calenadr
                /// </summary>
                Chinese
            }
        }

        public static class Relationship
        {
            /// <summary>
            /// Identifier of this relationship view
            /// </summary>
            public const string Uri = "tizen.contacts_view.relationship";
            /// <summary>
            /// DB record ID of the relationship
            /// </summary>
            public const uint Id = (uint)PropertyIds.RelationshipId;
            /// <summary>
            /// Contact ID that the relationship belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.RelationshipContactId;
            /// <summary>
            /// Relationship type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.RelationshipType;
            /// <summary>
            /// Custom relationship type label, when the relationship type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.RelationshipLabel;
            /// <summary>
            /// Selected contact name that the relationship belongs to
            /// </summary>
            public const uint Name = (uint)PropertyIds.RelationshipName;

            /// <summary>
            /// Enumeration for Contact relationship type.
            /// </summary>
            public enum Types
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

        public static class Image
        {
            /// <summary>
            /// Identifier of this contacts image view
            /// </summary>
            public const string Uri = "tizen.contacts_view.image";
            /// <summary>
            /// DB record ID of the image
            /// </summary>
            public const uint Id = (uint)PropertyIds.ImageId;
            /// <summary>
            /// Contact ID that the image belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ImageContactId;
            /// <summary>
            /// Image type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.ImageType;
            /// <summary>
            /// Custom image type label, when the image type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.ImageLabel;
            /// <summary>
            /// Image thumbnail path
            /// </summary>
            public const uint Path = (uint)PropertyIds.ImagePath;
            /// <summary>
            /// The Image is default or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.ImageIsDefault;

            /// <summary>
            /// Enumeration for Contact image type.
            /// </summary>
            public enum Types
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

        public static class Company
        {
            /// <summary>
            /// Identifier of this contacts company view
            /// </summary>
            public const string Uri = "tizen.contacts_view.company";
            /// <summary>
            /// DB record ID of the company
            /// </summary>
            public const uint Id = (uint)PropertyIds.CompanyId;
            /// <summary>
            /// Contact ID that the company belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.CompanyContactId;
            /// <summary>
            /// Company type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.CompanyType;
            /// <summary>
            /// Custom company type label, when the company type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.CompanyLabel;
            /// <summary>
            /// Company name
            /// </summary>
            public const uint Name = (uint)PropertyIds.CompanyName;
            /// <summary>
            /// Department
            /// </summary>
            public const uint Department = (uint)PropertyIds.CompanyDepartment;
            /// <summary>
            /// Job title
            /// </summary>
            public const uint JobTitle = (uint)PropertyIds.CompanyJobTitle;
            /// <summary>
            /// Assistant name
            /// </summary>
            public const uint AssistantName = (uint)PropertyIds.CompanyAssistantName;
            /// <summary>
            /// Role
            /// </summary>
            public const uint Role = (uint)PropertyIds.CompanyRole;
            /// <summary>
            /// Company logo image file path
            /// </summary>
            public const uint Logo = (uint)PropertyIds.CompanyLogo;
            /// <summary>
            /// Company location
            /// </summary>
            public const uint Location = (uint)PropertyIds.CompanyLocation;
            /// <summary>
            /// Description
            /// </summary>
            public const uint Description = (uint)PropertyIds.CompanyDescription;
            /// <summary>
            /// Pronounce the company name
            /// </summary>
            public const uint PhoneticName = (uint)PropertyIds.CompanyPhoneticName;

            /// <summary>
            /// Enumeration for Contact company type.
            /// </summary>
            public enum Types
            {
                Other = 0, /**< Other company type */
                Custom = 1 << 0, /**< Custom company type */
                Work = 1 << 1, /**< Work company type */
            }
        }

        public static class Nickname
        {
            /// <summary>
            /// Identifier of this contacts nickname view
            /// </summary>
            public const string Uri = "tizen.contacts_view.nickname";
            /// <summary>
            /// DB record ID of the nickname
            /// </summary>
            public const uint Id = (uint)PropertyIds.NicknameId;
            /// <summary>
            /// Contact ID that the nickname belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.NicknameContactId;
            /// <summary>
            /// Nickname
            /// </summary>
            public const uint Name = (uint)PropertyIds.NicknameName;
        }

        public static class Messenger
        {
            /// <summary>
            /// Identifier of this contacts messenger view
            /// </summary>
            public const string Uri = "tizen.contacts_view.messenger";
            /// <summary>
            /// DB record ID of the messenger
            /// </summary>
            public const uint Id = (uint)PropertyIds.MessengerId;
            /// <summary>
            /// Contact ID that the messenger belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.MessengerContactId;
            /// <summary>
            /// Messenger type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.MessengerType;
            /// <summary>
            /// Custom messenger type label, when the messenger type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.MessengerLabel;
            /// <summary>
            /// Messenger ID (email address or email ID...)
            /// </summary>
            public const uint IMId = (uint)PropertyIds.MessengerIMId;

            /// <summary>
            /// Enumeration for Contact messenger type.
            /// </summary>
            public enum Types
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

        public static class Profile
        {
            /// <summary>
            /// Identifier of this contacts profile view
            /// </summary>
            public const string Uri = "tizen.contacts_view.profile";
            /// <summary>
            /// DB record ID of profile
            /// </summary>
            public const uint Id = (uint)PropertyIds.ProfileId;
            /// <summary>
            /// Contacts ID that the profile belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ProfileContactId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid = (uint)PropertyIds.ProfileUid;
            /// <summary>
            /// Profile contents
            /// </summary>
            public const uint Text = (uint)PropertyIds.ProfileText;
            /// <summary>
            /// Priority to display the profile
            /// </summary>
            public const uint Order = (uint)PropertyIds.ProfileOrder;
            /// <summary>
            /// Data for app_control_set_operation
            /// </summary>
            public const uint ServiceOperation = (uint)PropertyIds.ProfileServiceOperation;
            /// <summary>
            /// Data for app_control_set_mime
            /// </summary>
            public const uint Mime = (uint)PropertyIds.ProfileMIME;
            /// <summary>
            /// Data for app_control_set_app_id
            /// </summary>
            public const uint AppId = (uint)PropertyIds.ProfileAppId;
            /// <summary>
            /// Data for app_control_set_uri
            /// </summary>
            public const uint ProfileUri = (uint)PropertyIds.ProfileUri;
            /// <summary>
            /// Data for app_control_set_category
            /// </summary>
            public const uint Category = (uint)PropertyIds.ProfileCategory;
            /// <summary>
            /// It includes "key:value,key:value," pairs. You should parse it. And you must base64 encode each key and value
            /// </summary>
            public const uint ExtraData = (uint)PropertyIds.ProfileExtraData;
        }

        public static class Sip
        {
            /// <summary>
            /// Identifier of this contacts sip view
            /// </summary>
            public const string Uri = "tizen.contacts_view.sip";
            /// <summary>
            /// DB record ID of the sip
            /// </summary>
            public const uint Id = (uint)PropertyIds.SipId;
            /// <summary>
            /// Contact ID that the sip belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.SipContactId;
            /// <summary>
            /// SIP address
            /// </summary>
            public const uint Address = (uint)PropertyIds.SipAddress;
            /// <summary>
            /// sip type, refer to the Types
            /// </summary>
            public const uint Type = (uint)PropertyIds.SipType;
            /// <summary>
            /// Custom sip type label, when the sip type is Types.Custom
            /// </summary>
            public const uint Label = (uint)PropertyIds.SipLabel;

            public enum Types
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

        public static class Extension
        {
            /// <summary>
            /// Identifier of this contacts extension view
            /// </summary>
            public const string Uri = "tizen.contacts_view.extension";
            /// <summary>
            /// DB record ID of the contact extension
            /// </summary>
            public const uint Id = (uint)PropertyIds.ExtensionId;
            /// <summary>
            /// Contact ID that the contact extension belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ExtensionContactId;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data1 = (uint)PropertyIds.ExtensionData1;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data2 = (uint)PropertyIds.ExtensionData2;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data3 = (uint)PropertyIds.ExtensionData3;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data4 = (uint)PropertyIds.ExtensionData4;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data5 = (uint)PropertyIds.ExtensionData5;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data6 = (uint)PropertyIds.ExtensionData6;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data7 = (uint)PropertyIds.ExtensionData7;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data8 = (uint)PropertyIds.ExtensionData8;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data9 = (uint)PropertyIds.ExtensionData9;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data10 = (uint)PropertyIds.ExtensionData10;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data11 = (uint)PropertyIds.ExtensionData11;
            /// <summary>
            /// The extra child record format for non-provided from contacts-service
            /// </summary>
            public const uint Data12 = (uint)PropertyIds.ExtensionData12;
        }

        public static class GroupRelation
        {
            /// <summary>
            /// Identifier of this relationship view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group_relation";
            /// <summary>
            /// DB record ID of the group relation (can not be used as filter)
            /// </summary>
            public const uint Id = (uint)PropertyIds.GroupRelationId;
            /// <summary>
            /// DB record ID of the group
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.GroupRelationGroupId;
            /// <summary>
            /// DB record ID of the contact
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.GroupRelationContactId;
            /// <summary>
            /// Group name
            /// </summary>
            public const uint Name = (uint)PropertyIds.GroupRelationGroupName;
        }

        public static class SpeedDial
        {
            /// <summary>
            /// Identifier of this contact speed dial view
            /// </summary>
            public const string Uri = "tizen.contacts_view.speeddial";
            /// <summary>
            /// Stored speed dial number
            /// </summary>
            public const uint SpeedDialNumber = (uint)PropertyIds.SpeedDialDialNumber;
            /// <summary>
            /// Number ID that the speed dial belongs to
            /// </summary>
            public const uint NumberId = (uint)PropertyIds.SpeedDialNumberId;
            /// <summary>
            /// Contact number of specified speed dial
            /// </summary>
            public const uint Number = (uint)PropertyIds.SpeedDialNumber;
            /// <summary>
            /// Contact number label of specified speed dial, when the number type is Number.Types.Custom
            /// </summary>
            public const uint NumberLabel = (uint)PropertyIds.SpeedDialNumberLabel;
            /// <summary>
            /// Contact number type, refer to the Number.Types
            /// </summary>
            public const uint NumberType = (uint)PropertyIds.SpeedDialNumberType;
            /// <summary>
            ///	Person ID that the speed dial belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.SpeedDialPersonId;
            /// <summary>
            /// Display name that the speed dial belongs to
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.SpeedDialDisplayName;
            /// <summary>
            /// Image thumbnail path that the speed dial belongs to
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.SpeedDialThumbnail;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)PropertyIds.SpeedDialNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)PropertyIds.SpeedDialCleanedNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minmatch length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly
            /// </summary>
            public const uint NumberFilter = (uint)PropertyIds.SpeedDialNumberFilter;
        }

        public static class PhoneLog
        {
            /// <summary>
            /// Identifier of this phone log view
            /// </summary>
            public const string Uri = "tizen.contacts_view.phonelog";
            /// <summary>
            /// DB record ID of phone log
            /// </summary>
            public const uint Id = (uint)PropertyIds.PhonelogId;
            /// <summary>
            /// Person ID that the phone log belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PhonelogPersonId;
            /// <summary>
            /// Number or Email that the phone log displays
            /// </summary>
            public const uint Address = (uint)PropertyIds.PhonelogAddress;
            /// <summary>
            /// Call end time. The value means number of seconds since 1970-01-01 00:00:00 (UTC)
            /// </summary>
            public const uint LogTime = (uint)PropertyIds.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the Types
            /// </summary>
            public const uint LogType = (uint)PropertyIds.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (e.g. message_id, email_id or duration(seconds) of call)
            /// </summary>
            public const uint ExtraData1 = (uint)PropertyIds.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (e.g. short message, subject)
            /// </summary>
            public const uint ExtraData2 = (uint)PropertyIds.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedAddress = (uint)PropertyIds.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedAddress = (uint)PropertyIds.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint AddressFilter = (uint)PropertyIds.PhonelogAddressFilter;
            /// <summary>
            /// You can set the related SIM slot number. sim_slot_no 0 means first SIM card, sim_slot_no 1 means second SIM. It is same with handle index of telephony handle list. Refer to the telephony_init()
            /// </summary>
            public const uint SimSlotNo = (uint)PropertyIds.PhonelogSIMSlotNo;

            public enum Types
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
                VidoeMissedSeen = 8,
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
                MmsIncoming = 101,
                /// <summary>
                /// Outgoing MMS
                /// </summary>
                MmsOutgoing = 102,
                /// <summary>
                /// Incoming SMS
                /// </summary>
                SmsIncoming = 103,
                /// <summary>
                /// Outgoing SMS
                /// </summary>
                SmsOutgoing = 104,
                /// <summary>
                /// Blocked SMS
                /// </summary>
                SmsBlocked = 105,
                /// <summary>
                /// Blocked MMS
                /// </summary>
                MmsBlocked = 106,
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
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class ContactUpdatedInfo
        {
            /// <summary>
            /// Identifier of this contact updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.contacts_updated_info";
            /// <summary>
            /// Updated contact ID
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.UpdateInfoId;
            /// <summary>
            /// Addressbook ID that the updated contact belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.UpdateInfoAddressbookId;
            /// <summary>
            /// Contact updated type, refer to the ContactsViews.ChangeTypes
            /// </summary>
            public const uint Type = (uint)PropertyIds.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)PropertyIds.UpdateInfoVersion;
            /// <summary>
            /// Contact image is changed or not
            /// </summary>
            public const uint ImageChanged = (uint)PropertyIds.UpdateInfoImageChanged;
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class MyProfileUpdatedInfo
        {
            /// <summary>
            /// Identifier of this my profile updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.my_profile_updated_info";
            /// <summary>
            /// Address book ID that the updated my profile belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.UpdateInfoAddressbookId;
            /// <summary>
            /// Changed update type, refer to the ContactsViews.ChangeTypes
            /// </summary>
            public const uint LastChangedType = (uint)PropertyIds.UpdateInfoLastChangedType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)PropertyIds.UpdateInfoVersion;
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class GroupUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.groups_updated_info";
            /// <summary>
            /// Updated group ID
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.UpdateInfoAddressbookId;
            /// <summary>
            /// Changed update type, refer to the ContactsViews.ChangeTypes
            /// </summary>
            public const uint Type = (uint)PropertyIds.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)PropertyIds.UpdateInfoVersion;
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class GroupMemberUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group member updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.groups_member_updated_info";
            /// <summary>
            /// Updated group ID
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.UpdateInfoId;
            /// <summary>
            /// Address book ID that the updated group belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.UpdateInfoAddressbookId;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)PropertyIds.UpdateInfoVersion;
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class GroupRelationUpdatedInfo
        {
            /// <summary>
            /// Identifier of this group relation updated info view
            /// </summary>
            public const string Uri = "tizen.contacts_view.group_relations_updated_info";
            /// <summary>
            /// Group ID of group relation
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.GroupId;
            /// <summary>
            /// Contact ID of the updated group relation
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Address book ID of contact that the updated group relation
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.AddressbookId;
            /// <summary>
            /// Changed update type, refer to the ContactsViews.ChangeTypes
            /// </summary>
            public const uint Type = (uint)PropertyIds.UpdateInfoType;
            /// <summary>
            /// Updated version
            /// </summary>
            public const uint Version = (uint)PropertyIds.UpdateInfoVersion;
        }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonContact
        {
            /// <summary>
            /// Identifier of this person contact view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)PropertyIds.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)PropertyIds.PersonLinkCount;
            /// <summary>
            /// Contact ID that the person belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Addressbook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressbookIds = (uint)PropertyIds.PersonAddressbookIds;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Addressbook ID that the person belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Addressbook mode, refer to the Addressbook.Modes
            /// </summary>
            public const uint AddressbookMode = (uint)PropertyIds.AddressbookMode;
            /// <summary>
            ///	Addressbook name that the person belongs to
            /// </summary>
            public const uint AddressbookName = (uint)PropertyIds.AddressbookName;
            /// <summary>
            /// kerword matched data type, refer to the Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonNumber
        {
            /// <summary>
            /// Identifier of this person number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/number";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Number ID that the person belongs to
            /// </summary>
            public const uint NumberId = (uint)PropertyIds.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection)
            /// </summary>
            public const uint Type = (uint)PropertyIds.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)PropertyIds.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsPrimaryDefault = (uint)PropertyIds.DataIsPrimaryDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint Number = (uint)PropertyIds.NumberNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minmatch length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly.
            /// </summary>
            public const uint NumberFilter = (uint)PropertyIds.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)PropertyIds.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)PropertyIds.NumberCleanedNumber;
            /// <summary>
            /// kerword matched data type, refer to they Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonEmail
        {
            /// <summary>
            /// Identifier of this person email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/email";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Email ID that the person belongs to
            /// </summary>
            public const uint EmailId = (uint)PropertyIds.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection)
            /// </summary>
            public const uint Type = (uint)PropertyIds.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)PropertyIds.EmailLabel;
            /// <summary>
            /// The email is default email or not
            /// </summary>
            public const uint IsPrimaryDefault = (uint)PropertyIds.DataIsPrimaryDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Email = (uint)PropertyIds.EmailEmail;
            /// <summary>
            /// kerword matched data type, refer to they Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonGroupRelation
        {
            /// <summary>
            /// Identifier of this person group relation view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)PropertyIds.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Link count of contat records (projection)
            /// </summary>
            public const uint LinkCount = (uint)PropertyIds.PersonLinkCount;
            /// <summary>
            /// Addressbook IDs that the person belongs to (projection)
            /// </summary>
            public const uint AddressbookIds = (uint)PropertyIds.PersonAddressbookIds;
            /// <summary>
            /// Addressbook ID that the person belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Addressbook name that the person belongs to
            /// </summary>
            public const uint AddressbookName = (uint)PropertyIds.AddressbookName;
            /// <summary>
            /// Addressbook mode, refer to the Addressbook.Modes
            /// </summary>
            public const uint AddressbookMode = (uint)PropertyIds.AddressbookMode;
            /// <summary>
            /// Group ID that the person belongs to
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.GroupRelationContactId;
            /// <summary>
            /// kerword matched data type, refer to they Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonGroupAssigned
        {
            /// <summary>
            /// Identifier of this person group assigned view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_assigned";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)PropertyIds.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)PropertyIds.PersonLinkCount;
            /// <summary>
            /// Addressbook IDs that the linked person belongs to (projection)
            /// </summary>
            public const uint AddressbookIds = (uint)PropertyIds.PersonAddressbookIds;
            /// <summary>
            /// Addressbook ID that the person belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Addressbook mode, refer to the Addressbook.Modes
            /// </summary>
            public const uint AddressbookMode = (uint)PropertyIds.AddressbookMode;
            /// <summary>
            /// Group ID that the person belongs to
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.GroupRelationGroupId;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.GroupRelationContactId;
            /// <summary>
            /// kerword matched data type, refer to they Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonGroupNotAssigned
        {
            /// <summary>
            /// Identifier of this person group not assigned view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/group_not_assigned";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// Status of social account (projection)
            /// </summary>
            public const uint Status = (uint)PropertyIds.PersonStatus;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Link count of contact records (projection)
            /// </summary>
            public const uint LinkCount = (uint)PropertyIds.PersonLinkCount;
            /// <summary>
            /// Addressbook IDs that the linked person belongs to (projection)
            /// </summary>
            public const uint AddressbookIds = (uint)PropertyIds.PersonAddressbookIds;
            /// <summary>
            /// Addressbook ID that the person belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Addressbook mode, refer to the Addressbook.Modes
            /// </summary>
            public const uint AddressbookMode = (uint)PropertyIds.AddressbookMode;
            /// <summary>
            /// Contact ID that the person belongs to (projection)
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// kerword matched data type, refer to they Contact.DataTypes
            /// </summary>
            public const uint SnippetType = (uint)PropertyIds.PersonSnippetType;
            /// <summary>
            /// keyword matched data string
            /// </summary>
            public const uint SnippetString = (uint)PropertyIds.PersonSnippetString;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonPhonelog
        {
            /// <summary>
            /// Identifier of this phone log view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/simple_contact/phonelog";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// DB record ID of phone log
            /// </summary>
            public const uint LogId = (uint)PropertyIds.PhonelogId;
            /// <summary>
            /// Number or Email that the phone log displays
            /// </summary>
            public const uint Address = (uint)PropertyIds.PhonelogAddress;
            /// <summary>
            /// Number or Email type (projection)
            /// </summary>
            public const uint AddressType = (uint)PropertyIds.DataData1;
            /// <summary>
            /// Call end time. The value means number of seconds since 1970-01-01 00:00:00 (UTC)
            /// </summary>
            public const uint LogTime = (uint)PropertyIds.PhonelogLogTime;
            /// <summary>
            /// Log type, refer to the PhoneLog.Types
            /// </summary>
            public const uint LogType = (uint)PropertyIds.PhonelogLogType;
            /// <summary>
            /// You can set the related integer data (e.g. message_id, email_id or duration(seconds) of call) (projection)
            /// </summary>
            public const uint ExtraData1 = (uint)PropertyIds.PhonelogExtraData1;
            /// <summary>
            /// You can set the related string data (e.g. short message, subject) (projection)
            /// </summary>
            public const uint ExtraData2 = (uint)PropertyIds.PhonelogExtraData2;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedAddress = (uint)PropertyIds.PhonelogNormalizedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedAddress = (uint)PropertyIds.PhonelogCleanedAddress;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint AddressFilter = (uint)PropertyIds.PhonelogAddressFilter;
            /// <summary>
            /// It is related to the SIM slot number. sim_slot_no 0 means first SIM card, sim_slot_no 1 means second SIM. It is same with handle index of telephony handle list. Refer to the telephony_init()
            /// </summary>
            public const uint SIMSlotNo = (uint)PropertyIds.PhonelogSIMSlotNo;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PersonUsage
        {
            /// <summary>
            /// Identifier of this person usage view
            /// </summary>
            public const string Uri = "tizen.contacts_view.person/usag";
            /// <summary>
            /// DB record ID of the person
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.PersonId;
            /// <summary>
            /// Display name of the person
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.PersonDisplayName;
            /// <summary>
            /// The first character of first string for grouping. This is normalized using icu (projection)
            /// </summary>
            public const uint DisplayNameIndex = (uint)PropertyIds.PersonDisplayNameIndex;
            /// <summary>
            /// Display contact ID that the person belongs to (projection)
            /// </summary>
            public const uint DisplayContactId = (uint)PropertyIds.PersonDisplayContactId;
            /// <summary>
            /// Ringtone path of the person (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.PersonRingtone;
            /// <summary>
            /// Image thumbnail path of the person (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.PersonThumbnail;
            /// <summary>
            /// Vibration path of the person (projection)
            /// </summary>
            public const uint Vibration = (uint)PropertyIds.PersonVibration;
            /// <summary>
            /// Message alert path of the person (projection)
            /// </summary>
            public const uint MessageAlert = (uint)PropertyIds.PersonMessageAlert;
            /// <summary>
            /// The person is favorite or not
            /// </summary>
            public const uint IsFavorite = (uint)PropertyIds.PersonIsFavorite;
            /// <summary>
            /// The person has phone number or not
            /// </summary>
            public const uint HasPhonenumber = (uint)PropertyIds.PersonHasPhonenumber;
            /// <summary>
            /// The person has email or not
            /// </summary>
            public const uint HasEmail = (uint)PropertyIds.PersonHasEmail;
            /// <summary>
            /// Usage type, refer to the UsageTypes
            /// </summary>
            public const uint UsageType = (uint)PropertyIds.PersonUsageType;
            /// <summary>
            /// Usage number of person
            /// </summary>
            public const uint TimesUsed = (uint)PropertyIds.PersonTimesUsed;

            public enum Types
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
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class ContactNumber
        {
            /// <summary>
            /// Identifier of this contacts number view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/number";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceTypes (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)PropertyIds.ContactDisplaySourceDataId;
            /// <summary>
            /// Addressbook ID that the number belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.ContactThumbnail;
            /// <summary>
            /// DB record ID of the number
            /// </summary>
            public const uint NumberId = (uint)PropertyIds.NumberId;
            /// <summary>
            /// Number type, refer to the Number.Types (projection)
            /// </summary>
            public const uint Type = (uint)PropertyIds.NumberType;
            /// <summary>
            /// Custom number type label, when the number type is Number.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)PropertyIds.NumberLabel;
            /// <summary>
            /// The number is default number or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.NumberIsDefault;
            /// <summary>
            /// Number
            /// </summary>
            public const uint Number = (uint)PropertyIds.NumberNumber;
            /// <summary>
            /// If you add filter with this property, the string will be normalized as minmatch length internally and the match rule will be applied ContactsFilter.StringMatchType.Exactly
            /// </summary>
            public const uint NumberFilter = (uint)PropertyIds.NumberNumberFilter;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint NormalizedNumber = (uint)PropertyIds.NumberNormalizedNumber;
            /// <summary>
            /// You can only use this property for search filter
            /// </summary>
            public const uint CleanedNumber = (uint)PropertyIds.NumberCleanedNumber;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class ContactEmail
        {
            /// <summary>
            /// Identifier of this contacts email view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/email";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceTypes (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)PropertyIds.ContactDisplaySourceDataId;
            /// <summary>
            /// Addressbook ID that the number belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.ContactThumbnail;
            /// <summary>
            /// DB record ID of the email
            /// </summary>
            public const uint EmailId = (uint)PropertyIds.EmailId;
            /// <summary>
            /// Email type, refer to the Email.Types (projection)
            /// </summary>
            public const uint Type = (uint)PropertyIds.EmailType;
            /// <summary>
            /// Custom mail type label, when the email type is Email.Types.Custom (projection)
            /// </summary>
            public const uint Label = (uint)PropertyIds.EmailLabel;
            /// <summary>
            /// Email is default email or not
            /// </summary>
            public const uint IsDefault = (uint)PropertyIds.EmailIsDefault;
            /// <summary>
            /// Email address
            /// </summary>
            public const uint Email = (uint)PropertyIds.EmailEmail;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class ContactGroupRelation
        {
            /// <summary>
            /// Identifier of this contact grouprel view
            /// </summary>
            public const string Uri = "tizen.contacts_view.simple_contact/group";
            /// <summary>
            /// Contact ID that the number belongs to
            /// </summary>
            public const uint ContactId = (uint)PropertyIds.ContactId;
            /// <summary>
            /// Display name of contact that the number belongs to
            /// </summary>
            public const uint DisplayName = (uint)PropertyIds.ContactDisplayName;
            /// <summary>
            /// The source type of display name, refer to the Contact.DisplayNameSourceTypes (projection)
            /// </summary>
            public const uint DisplaySourceType = (uint)PropertyIds.ContactDisplaySourceDataId;
            /// <summary>
            /// Addressbook ID that the number belongs to
            /// </summary>
            public const uint AddressbookId = (uint)PropertyIds.ContactAddressbookId;
            /// <summary>
            /// Person ID that the number belongs to
            /// </summary>
            public const uint PersonId = (uint)PropertyIds.ContactPersonId;
            /// <summary>
            /// Ringtone path that the number belongs to (projection)
            /// </summary>
            public const uint RingtonePath = (uint)PropertyIds.ContactRingtone;
            /// <summary>
            /// Image thumbnail path that the number belongs to (projection)
            /// </summary>
            public const uint ThumbnailPath = (uint)PropertyIds.ContactThumbnail;
            /// <summary>
            /// DB record ID of the group relation
            /// </summary>
            public const uint GroupId = (uint)PropertyIds.GroupRelationGroupId;
            /// <summary>
            /// Group name (projection)
            /// </summary>
            public const uint GroupName = (uint)PropertyIds.GroupRelationGroupName;
        };

        /// <summary>
        ///
        /// </summary>
        /// <remarks>Read only view</remarks>
        public static class PhonelogStatistics
        {
            /// <summary>
            /// Identifier of this log statistics view
            /// </summary>
            public const string Uri = "tizen.contacts_view.phonelog_stat";
            /// <summary>
            /// Log count (projection)
            /// </summary>
            public const uint LogCount = (uint)PropertyIds.PhonelogStatLogCount;
            /// <summary>
            /// Log type, see the contacts_phone_log_type_e
            /// </summary>
            public const uint LogType = (uint)PropertyIds.PhonelogStatLogType;
            /// <summary>
            /// It is related to the SIM slot number. sim_slot_no 0 means first SIM card, sim_slot_no 1 means second SIM. It is same with handle index of telephony handle list. Refer to the telephony_init()
            /// </summary>
            public const uint SIMSlotNo = (uint)PropertyIds.PhonelogStatSIMSlotNo;
        };
    }
}
