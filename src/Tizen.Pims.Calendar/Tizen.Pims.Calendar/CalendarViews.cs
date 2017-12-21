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

using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Calendar
{
    namespace CalendarViews
    {
        internal static class Property
        {
            /// data type mask 0x0FF00000
            private const uint Mask                          = 0xFF000000;
            private const uint Book                          = 0x01000000;
            private const uint Event                         = 0x02000000;
            private const uint Todo                          = 0x03000000;
            private const uint Timezone                      = 0x04000000;
            private const uint Attendee                      = 0x05000000;
            private const uint Alarm                         = 0x06000000;
            private const uint InstanceUtimeBook             = 0x07000000;
            private const uint InstanceLocaltimeBook         = 0x08000000;
            private const uint UpdateInfo                    = 0x09000000;
            private const uint Extended                      = 0x0A000000;
            private const uint InstanceUtimeBookExtended     = 0x0B000000;
            private const uint InstanceLocaltimeBookExtended = 0x0C000000;

            private const uint DataTypeMask    = 0x000FF000;
            private const uint DataTypeInteger = 0x00001000;
            private const uint DataTypeString  = 0x00002000;
            private const uint DataTypeDouble  = 0x00003000;
            private const uint DataTypeLong    = 0x00004000;
            private const uint DataTypeCaltime = 0x00005000;
            private const uint DataTypeRecord  = 0x00006000;

            /// property : mask 0x0000F000
            private const uint PropertyMask       = 0x00F00000;
            private const uint PropertyFilter     = 0x00100000;
            private const uint PropertyProjection = 0x00200000;
            private const uint PropertyReadOnly   = 0x00300000;

            internal enum Id : uint
            {
                None,

                /// book
                BookId          = (Book|DataTypeInteger|PropertyReadOnly),
                BookUid         = (Book|DataTypeString) + 1,
                BookName        = (Book|DataTypeString) + 2,
                BookDescription = (Book|DataTypeString) + 3,
                BookColor       = (Book|DataTypeString) + 4,
                BookLocation    = (Book|DataTypeString) + 5,
                BookVisibility  = (Book|DataTypeInteger) + 6,
                BookSyncEvent   = (Book|DataTypeInteger) + 7,
                BookAccountId   = (Book|DataTypeInteger) + 8,
                BookStoreType   = (Book|DataTypeInteger) + 9,
                BookSyncData1   = (Book|DataTypeString) + 10,
                BookSyncData2   = (Book|DataTypeString) + 11,
                BookSyncData3   = (Book|DataTypeString) + 12,
                BookSyncData4   = (Book|DataTypeString) + 13,
                BookMode        = (Book|DataTypeInteger) + 14,

                /// Event
                EventId                 = (Event|DataTypeInteger|PropertyReadOnly),
                EventBookId             = (Event|DataTypeInteger) + 1,
                EventSummary            = (Event|DataTypeString) + 2,
                EventDescription        = (Event|DataTypeString) + 3,
                EventLocation           = (Event|DataTypeString) + 4,
                EventCategories         = (Event|DataTypeString) + 5,
                EventExdate             = (Event|DataTypeString) + 6,
                EventEventStatus        = (Event|DataTypeInteger) + 7,
                EventPriority           = (Event|DataTypeInteger) + 8,
                EventTimezone           = (Event|DataTypeInteger) + 9,
                EventContactId          = (Event|DataTypeInteger) + 10,
                EventBusyStatus         = (Event|DataTypeInteger) + 11,
                EventSensitivity        = (Event|DataTypeInteger) + 12,
                EventUid                = (Event|DataTypeString) + 13,
                EventOrganizerName      = (Event|DataTypeString) + 14,
                EventOrganizerEmail     = (Event|DataTypeString) + 15,
                EventMeetingStatus      = (Event|DataTypeInteger) + 16,
                EventOriginalEventId    = (Event|DataTypeInteger) + 17,
                EventLatitude           = (Event|DataTypeDouble) + 18,
                EventLongitude          = (Event|DataTypeDouble) + 19,
                EventEmailId            = (Event|DataTypeInteger) + 20,
                EventCreatedTime        = (Event|DataTypeLong) + 21,
                EventLastModifiedTime   = (Event|DataTypeLong|PropertyReadOnly) + 22,
                EventIsDeleted          = (Event|DataTypeInteger|PropertyReadOnly) + 23,
                EventFreq               = (Event|DataTypeInteger) + 24,
                EventRangeType          = (Event|DataTypeInteger) + 25,
                EventUntil              = (Event|DataTypeCaltime) + 26,
                EventCount              = (Event|DataTypeInteger) + 27,
                EventInterval           = (Event|DataTypeInteger) + 28,
                EventBysecond           = (Event|DataTypeString) + 29,
                EventByminute           = (Event|DataTypeString) + 30,
                EventByhour             = (Event|DataTypeString) + 31,
                EventByday              = (Event|DataTypeString) + 32,
                EventBymonthday         = (Event|DataTypeString) + 33,
                EventByyearday          = (Event|DataTypeString) + 34,
                EventByweekno           = (Event|DataTypeString) + 35,
                EventBymonth            = (Event|DataTypeString) + 36,
                EventBysetpos           = (Event|DataTypeString) + 37,
                EventWkst               = (Event|DataTypeInteger) + 38,
                EventRecurrenceId       = (Event|DataTypeString) + 39,
                EventRdate              = (Event|DataTypeString) + 40,
                EventHasAttendee        = (Event|DataTypeInteger|PropertyReadOnly) + 41,
                EventHasAlarm           = (Event|DataTypeInteger|PropertyReadOnly) + 42,
                EventSyncData1          = (Event|DataTypeString) + 43,
                EventSyncData2          = (Event|DataTypeString) + 44,
                EventSyncData3          = (Event|DataTypeString) + 45,
                EventSyncData4          = (Event|DataTypeString) + 46,
                EventStart              = (Event|DataTypeCaltime) + 47,
                EventEnd                = (Event|DataTypeCaltime) + 48,
                EventAlarm              = (Event|DataTypeRecord) + 49,
                EventAttendee           = (Event|DataTypeRecord) + 50,
                EventCalendarSystemType = (Event|DataTypeInteger) + 51,
                EventStartTzid          = (Event|DataTypeString) + 52,
                EventEndTzid            = (Event|DataTypeString) + 53,
                EventException          = (Event|DataTypeRecord) + 54,
                EventExtended           = (Event|DataTypeRecord) + 55,
                EventIsAllday           = (Event|DataTypeInteger|PropertyReadOnly) + 56,
                EventLinkCount          = (Event|DataTypeInteger|PropertyReadOnly) + 57,
                EventLinkBaseId         = (Event|DataTypeInteger|PropertyReadOnly) + 58,

                /// Todo
                TodoId                   = (Todo|DataTypeInteger|PropertyReadOnly),
                TodoBookId               = (Todo|DataTypeInteger) + 1,
                TodoSummary              = (Todo|DataTypeString) + 2,
                TodoDescription          = (Todo|DataTypeString) + 3,
                TodoLocation             = (Todo|DataTypeString) + 4,
                TodoCategories           = (Todo|DataTypeString) + 5,
                TodoStatus               = (Todo|DataTypeInteger) + 6,
                TodoPriority             = (Todo|DataTypeInteger) + 7,
                TodoSensitivity          = (Todo|DataTypeInteger) + 8,
                TodoUid                  = (Todo|DataTypeString) + 9,
                TodoLatitude             = (Todo|DataTypeDouble) + 10,
                TodoLongitude            = (Todo|DataTypeDouble) + 11,
                TodoProgress             = (Todo|DataTypeInteger) + 12,
                TodoCreatedTime          = (Todo|DataTypeLong) + 13,
                TodoLastModifiedTime     = (Todo|DataTypeLong|PropertyReadOnly) + 14,
                TodoCompletedTime        = (Todo|DataTypeLong) + 15,
                TodoIsDeleted            = (Todo|DataTypeInteger|PropertyReadOnly) + 16,
                TodoFreq                 = (Todo|DataTypeInteger) + 17,
                TodoRangeType            = (Todo|DataTypeInteger) + 18,
                TodoUntil                = (Todo|DataTypeCaltime) + 19,
                TodoCount                = (Todo|DataTypeInteger) + 20,
                TodoInterval         = (Todo|DataTypeInteger) + 21,
                TodoBysecond             = (Todo|DataTypeString) + 22,
                TodoByminute             = (Todo|DataTypeString) + 23,
                TodoByhour               = (Todo|DataTypeString) + 24,
                TodoByday                = (Todo|DataTypeString) + 25,
                TodoBymonthday           = (Todo|DataTypeString) + 26,
                TodoByyearday            = (Todo|DataTypeString) + 27,
                TodoByweekno             = (Todo|DataTypeString) + 28,
                TodoBymonth              = (Todo|DataTypeString) + 29,
                TodoBysetpos             = (Todo|DataTypeString) + 30,
                TodoWkst                 = (Todo|DataTypeInteger) + 31,
                TodoHasAlarm             = (Todo|DataTypeInteger|PropertyReadOnly) + 32,
                TodoSyncData1            = (Todo|DataTypeString) + 33,
                TodoSyncData2            = (Todo|DataTypeString) + 34,
                TodoSyncData3            = (Todo|DataTypeString) + 35,
                TodoSyncData4            = (Todo|DataTypeString) + 36,
                TodoStart                = (Todo|DataTypeCaltime) + 37,
                TodoDue                  = (Todo|DataTypeCaltime) + 38,
                TodoAlarm                = (Todo|DataTypeRecord) + 39,
                TodoStartTzid            = (Todo|DataTypeString) + 40,
                TodoDueTzid              = (Todo|DataTypeString) + 41,
                TodoOrganizerName        = (Todo|DataTypeString) + 42,
                TodoOrganizerEmail       = (Todo|DataTypeString) + 43,
                TodoHasAttendee          = (Todo|DataTypeInteger|PropertyReadOnly) + 44,
                TodoAttendee             = (Todo|DataTypeRecord) + 45,
                TodoExtended             = (Todo|DataTypeRecord) + 46,
                TodoIsAllday             = (Todo|DataTypeInteger|PropertyReadOnly) + 47,

                /// Timezone
                TimezoneId                          = (Timezone|DataTypeInteger|PropertyReadOnly),
                TimezoneTzOffsetFromGmt             = (Timezone|DataTypeInteger) + 1,
                TimezoneStandardName                = (Timezone|DataTypeString) + 2,
                TimezoneStdStartMonth               = (Timezone|DataTypeInteger) + 3,
                TimezoneStdStartPositionOfWeek      = (Timezone|DataTypeInteger) + 4,
                TimezoneStdStartDay                 = (Timezone|DataTypeInteger) + 5,
                TimezoneStdStartHour                = (Timezone|DataTypeInteger) + 6,
                TimezoneStandardBias                = (Timezone|DataTypeInteger) + 7,
                TimezoneDayLightName                = (Timezone|DataTypeString) + 8,
                TimezoneDayLightStartMonth          = (Timezone|DataTypeInteger) + 9,
                TimezoneDayLightStartPositionOfWeek = (Timezone|DataTypeInteger) + 10,
                TimezoneDayLightStartDay            = (Timezone|DataTypeInteger) + 11,
                TimezoneDayLightStartHour           = (Timezone|DataTypeInteger) + 12,
                TimezoneDayLightBias                = (Timezone|DataTypeInteger) + 13,
                TimezoneCalendarId                  = (Timezone|DataTypeInteger) + 14,

                AttendeeNumber       = (Attendee|DataTypeString),
                AttendeeCutype       = (Attendee|DataTypeInteger) + 1,
                AttendeeCtIndex      = (Attendee|DataTypeInteger) + 2,
                AttendeeUid          = (Attendee|DataTypeString) + 3,
                AttendeeGroup        = (Attendee|DataTypeString) + 4,
                AttendeeEmail        = (Attendee|DataTypeString) + 5,
                AttendeeRole         = (Attendee|DataTypeInteger) + 6,
                AttendeeStatus       = (Attendee|DataTypeInteger) + 7,
                AttendeeRsvp         = (Attendee|DataTypeInteger) + 8,
                AttendeeDelegateeUri = (Attendee|DataTypeString) + 9,
                AttendeeDelegatorUri = (Attendee|DataTypeString) + 10,
                AttendeeName         = (Attendee|DataTypeString) + 11,
                AttendeeMember       = (Attendee|DataTypeString) + 12,
                AttendeeParentId     = (Attendee|DataTypeInteger|PropertyReadOnly) + 13,

                AlarmTick            = (Alarm|DataTypeInteger),
                AlarmTickUnit        = (Alarm|DataTypeInteger) + 1,
                AlarmDescription     = (Alarm|DataTypeString) + 2,
                AlarmParentId        = (Alarm|DataTypeInteger|PropertyReadOnly) + 3,
                AlarmSummary         = (Alarm|DataTypeString) + 4,
                AlarmAction          = (Alarm|DataTypeInteger) + 5,
                AlarmAttach          = (Alarm|DataTypeString) + 6,
                AlarmAlarm           = (Alarm|DataTypeCaltime) + 7,

                InstanceUtimeBookEventId          = (InstanceUtimeBook|DataTypeInteger),
                InstanceUtimeBookStart            = (InstanceUtimeBook|DataTypeCaltime) + 1,
                InstanceUtimeBookEnd              = (InstanceUtimeBook|DataTypeCaltime) + 2,
                InstanceUtimeBookSummary          = (InstanceUtimeBook|DataTypeString) + 3,
                InstanceUtimeBookLocation         = (InstanceUtimeBook|DataTypeString) + 4,
                InstanceUtimeBookBookId           = (InstanceUtimeBook|DataTypeInteger) + 5,
                InstanceUtimeBookDescription      = (InstanceUtimeBook|DataTypeString) + 6,
                InstanceUtimeBookBusyStatus       = (InstanceUtimeBook|DataTypeInteger) + 7,
                InstanceUtimeBookEventStatus      = (InstanceUtimeBook|DataTypeInteger) + 8,
                InstanceUtimeBookPriority         = (InstanceUtimeBook|DataTypeInteger) + 9,
                InstanceUtimeBookSensitivity      = (InstanceUtimeBook|DataTypeInteger) + 10,
                InstanceUtimeBookHasRrule         = (InstanceUtimeBook|DataTypeInteger) + 11,
                InstanceUtimeBookLatitude         = (InstanceUtimeBook|DataTypeDouble) + 12,
                InstanceUtimeBookLongitude        = (InstanceUtimeBook|DataTypeDouble) + 13,
                InstanceUtimeBookHasAlarm         = (InstanceUtimeBook|DataTypeInteger) + 14,
                InstanceUtimeBookOriginalEventId  = (InstanceUtimeBook|DataTypeInteger) + 15,
                InstanceUtimeBookLastModifiedTime = (InstanceUtimeBook|DataTypeLong) + 16,
                InstanceUtimeBookSyncData1        = (InstanceUtimeBook|DataTypeString) + 17,

                InstanceLocaltimeBookEventId          = (InstanceLocaltimeBook|DataTypeInteger),
                InstanceLocaltimeBookStart            = (InstanceLocaltimeBook|DataTypeCaltime) + 1,
                InstanceLocaltimeBookEnd              = (InstanceLocaltimeBook|DataTypeCaltime) + 2,
                InstanceLocaltimeBookSummary          = (InstanceLocaltimeBook|DataTypeString) + 3,
                InstanceLocaltimeBookLocation         = (InstanceLocaltimeBook|DataTypeString) + 4,
                InstanceLocaltimeBookBookId           = (InstanceLocaltimeBook|DataTypeInteger) + 5,
                InstanceLocaltimeBookDescription      = (InstanceLocaltimeBook|DataTypeString) + 6,
                InstanceLocaltimeBookBusyStatus       = (InstanceLocaltimeBook|DataTypeInteger) + 7,
                InstanceLocaltimeBookEventStatus      = (InstanceLocaltimeBook|DataTypeInteger) + 8,
                InstanceLocaltimeBookPriority         = (InstanceLocaltimeBook|DataTypeInteger) + 9,
                InstanceLocaltimeBookSensitivity      = (InstanceLocaltimeBook|DataTypeInteger) + 10,
                InstanceLocaltimeBookHasRrule         = (InstanceLocaltimeBook|DataTypeInteger) + 11,
                InstanceLocaltimeBookLatitude         = (InstanceLocaltimeBook|DataTypeDouble) + 12,
                InstanceLocaltimeBookLongitude        = (InstanceLocaltimeBook|DataTypeDouble) + 13,
                InstanceLocaltimeBookHasAlarm         = (InstanceLocaltimeBook|DataTypeInteger) + 14,
                InstanceLocaltimeBookOriginalEventId  = (InstanceLocaltimeBook|DataTypeInteger) + 15,
                InstanceLocaltimeBookLastModifiedTime = (InstanceLocaltimeBook|DataTypeLong) + 16,
                InstanceLocaltimeBookSyncData1        = (InstanceLocaltimeBook|DataTypeString) + 17,
                InstanceLocaltimeBookIsAllday         = (InstanceLocaltimeBook|DataTypeInteger|PropertyReadOnly) + 18,

                InstanceUtimeBookExtendedEventId          = (InstanceUtimeBookExtended|DataTypeInteger),
                InstanceUtimeBookExtendedStart            = (InstanceUtimeBookExtended|DataTypeCaltime) + 1,
                InstanceUtimeBookExtendedEnd              = (InstanceUtimeBookExtended|DataTypeCaltime) + 2,
                InstanceUtimeBookExtendedSummary          = (InstanceUtimeBookExtended|DataTypeString) + 3,
                InstanceUtimeBookExtendedLocation         = (InstanceUtimeBookExtended|DataTypeString) + 4,
                InstanceUtimeBookExtendedBookId           = (InstanceUtimeBookExtended|DataTypeInteger) + 5,
                InstanceUtimeBookExtendedDescription      = (InstanceUtimeBookExtended|DataTypeString) + 6,
                InstanceUtimeBookExtendedBusyStatus       = (InstanceUtimeBookExtended|DataTypeInteger) + 7,
                InstanceUtimeBookExtendedEventStatus      = (InstanceUtimeBookExtended|DataTypeInteger) + 8,
                InstanceUtimeBookExtendedPriority         = (InstanceUtimeBookExtended|DataTypeInteger) + 9,
                InstanceUtimeBookExtendedSensitivity      = (InstanceUtimeBookExtended|DataTypeInteger) + 10,
                InstanceUtimeBookExtendedHasRrule         = (InstanceUtimeBookExtended|DataTypeInteger) + 11,
                InstanceUtimeBookExtendedLatitude         = (InstanceUtimeBookExtended|DataTypeDouble) + 12,
                InstanceUtimeBookExtendedLongitude        = (InstanceUtimeBookExtended|DataTypeDouble) + 13,
                InstanceUtimeBookExtendedHasAlarm         = (InstanceUtimeBookExtended|DataTypeInteger) + 14,
                InstanceUtimeBookExtendedOriginalEventId  = (InstanceUtimeBookExtended|DataTypeInteger) + 15,
                InstanceUtimeBookExtendedLastModifiedTime = (InstanceUtimeBookExtended|DataTypeLong) + 16,
                InstanceUtimeBookExtendedSyncData1        = (InstanceUtimeBookExtended|DataTypeString) + 17,
                InstanceUtimeBookExtendedOrganizerName    = (InstanceUtimeBookExtended|DataTypeString) + 18,
                InstanceUtimeBookExtendedCategories       = (InstanceUtimeBookExtended|DataTypeString) + 19,
                InstanceUtimeBookExtendedHasAttendee      = (InstanceUtimeBookExtended|DataTypeInteger) + 20,
                InstanceUtimeBookExtendedSyncData2        = (InstanceUtimeBookExtended|DataTypeString) + 21,
                InstanceUtimeBookExtendedSyncData3        = (InstanceUtimeBookExtended|DataTypeString) + 22,
                InstanceUtimeBookExtendedSyncData4        = (InstanceUtimeBookExtended|DataTypeString) + 23,

                InstanceLocaltimeBookExtendedEventId          = (InstanceLocaltimeBookExtended|DataTypeInteger),
                InstanceLocaltimeBookExtendedStart            = (InstanceLocaltimeBookExtended|DataTypeCaltime) + 1,
                InstanceLocaltimeBookExtendedEnd              = (InstanceLocaltimeBookExtended|DataTypeCaltime) + 2,
                InstanceLocaltimeBookExtendedSummary          = (InstanceLocaltimeBookExtended|DataTypeString) + 3,
                InstanceLocaltimeBookExtendedLocation         = (InstanceLocaltimeBookExtended|DataTypeString) + 4,
                InstanceLocaltimeBookExtendedBookId           = (InstanceLocaltimeBookExtended|DataTypeInteger) + 5,
                InstanceLocaltimeBookExtendedDescription      = (InstanceLocaltimeBookExtended|DataTypeString) + 6,
                InstanceLocaltimeBookExtendedBusyStatus       = (InstanceLocaltimeBookExtended|DataTypeInteger) + 7,
                InstanceLocaltimeBookExtendedEventStatus      = (InstanceLocaltimeBookExtended|DataTypeInteger) + 8,
                InstanceLocaltimeBookExtendedPriority         = (InstanceLocaltimeBookExtended|DataTypeInteger) + 9,
                InstanceLocaltimeBookExtendedSensitivity      = (InstanceLocaltimeBookExtended|DataTypeInteger) + 10,
                InstanceLocaltimeBookExtendedHasRrule         = (InstanceLocaltimeBookExtended|DataTypeInteger) + 11,
                InstanceLocaltimeBookExtendedLatitude         = (InstanceLocaltimeBookExtended|DataTypeDouble) + 12,
                InstanceLocaltimeBookExtendedLongitude        = (InstanceLocaltimeBookExtended|DataTypeDouble) + 13,
                InstanceLocaltimeBookExtendedHasAlarm         = (InstanceLocaltimeBookExtended|DataTypeInteger) + 14,
                InstanceLocaltimeBookExtendedOriginalEventId  = (InstanceLocaltimeBookExtended|DataTypeInteger) + 15,
                InstanceLocaltimeBookExtendedLastModifiedTime = (InstanceLocaltimeBookExtended|DataTypeLong) + 16,
                InstanceLocaltimeBookExtendedSyncData1        = (InstanceLocaltimeBookExtended|DataTypeString) + 17,
                InstanceLocaltimeBookExtendedOrganizerName    = (InstanceLocaltimeBookExtended|DataTypeString) + 18,
                InstanceLocaltimeBookExtendedCategories       = (InstanceLocaltimeBookExtended|DataTypeString) + 19,
                InstanceLocaltimeBookExtendedHasAttendee      = (InstanceLocaltimeBookExtended|DataTypeInteger) + 20,
                InstanceLocaltimeBookExtendedSyncData2        = (InstanceLocaltimeBookExtended|DataTypeString) + 21,
                InstanceLocaltimeBookExtendedSyncData3        = (InstanceLocaltimeBookExtended|DataTypeString) + 22,
                InstanceLocaltimeBookExtendedSyncData4        = (InstanceLocaltimeBookExtended|DataTypeString) + 23,
                InstanceLocaltimeBookExtendedIsAllday         = (InstanceLocaltimeBookExtended|DataTypeInteger|PropertyReadOnly) + 24,

                UpdateInfoId         = (UpdateInfo|DataTypeInteger),
                UpdateInfoCalendarId = (UpdateInfo|DataTypeInteger) + 1,
                UpdateInfoType       = (UpdateInfo|DataTypeInteger) + 2,
                UpdateInfoVersion    = (UpdateInfo|DataTypeInteger) + 3,

                ExtendedId           = (Extended|DataTypeInteger|PropertyReadOnly),
                ExtendedRecordId     = (Extended|DataTypeInteger) + 1,
                ExtendedRecordType   = (Extended|DataTypeInteger) + 2,
                ExtendedKey          = (Extended|DataTypeString) + 3,
                ExtendedValue        = (Extended|DataTypeString) + 4,
            }
        }

        internal static class Record
        {
            ///average size
            internal const uint AverageSize = 56;
        }

        /// <summary>
        /// Describes the properties of a Book record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Book
        {
            /// <summary>
            /// Identifier of this calendar book view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.book";
            /// <summary>
            /// Database record ID of the calendar book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id          = (uint)Property.Id.BookId;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Uid         = (uint)Property.Id.BookUid;
            /// <summary>
            /// Calendar book name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name        = (uint)Property.Id.BookName;
            /// <summary>
            /// Calendar book description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description = (uint)Property.Id.BookDescription;
            /// <summary>
            /// Calendar book color for UX.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Color       = (uint)Property.Id.BookColor;
            /// <summary>
            /// Location of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location    = (uint)Property.Id.BookLocation;
            /// <summary>
            /// Visibility of the calendar book for UX.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Visibility  = (uint)Property.Id.BookVisibility;
            /// <summary>
            /// Currently not used.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncEvent   = (uint)Property.Id.BookSyncEvent;
            /// <summary>
            /// Account for this calendar.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AccountId   = (uint)Property.Id.BookAccountId;
            /// <summary>
            /// Type of calendar contents (refer to the CalendarTypes.StoreType).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StoreType   = (uint)Property.Id.BookStoreType;
            /// <summary>
            /// Generic data for use by syncing.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1   = (uint)Property.Id.BookSyncData1;
            /// <summary>
            /// Generic data for use by syncing.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData2   = (uint)Property.Id.BookSyncData2;
            /// <summary>
            /// Generic data for use by syncing.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData3   = (uint)Property.Id.BookSyncData3;
            /// <summary>
            /// Generic data for use by syncing.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData4   = (uint)Property.Id.BookSyncData4;
            /// <summary>
            /// Calendar book mode (refer to the CalendarTypes.BookMode).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Mode        = (uint)Property.Id.BookMode;
        }

        /// <summary>
        /// Describes the properties of a Event record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        public static class Event
        {
            /// <summary>
            /// Identifier of this event view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.event";
            /// <summary>
            /// Database record ID of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id                 = (uint)Property.Id.EventId;
            /// <summary>
            /// ID of the calendar book to which the event belongs.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId             = (uint)Property.Id.EventBookId;
            /// <summary>
            /// The short description of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary            = (uint)Property.Id.EventSummary;
            /// <summary>
            /// The description of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description        = (uint)Property.Id.EventDescription;
            /// <summary>
            /// The location of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location           = (uint)Property.Id.EventLocation;
            /// <summary>
            /// The category of the event. For example, appointment, birthday.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Categories         = (uint)Property.Id.EventCategories;
            /// <summary>
            /// The exception list of the event. If this event has a recurrence rule, the instance of the exdate is removed. Format is "YYYYMMDD"(allday event) or "YYYYMMDDTHHMMSS". Multiple exceptions can be included with a comma.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Exdate             = (uint)Property.Id.EventExdate;
            /// <summary>
            /// The status of event (refer to the CalendarTypes.EventStatus).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventStatus        = (uint)Property.Id.EventEventStatus;
            /// <summary>
            /// The priority of event (refer to the CalendarTypes.Priority).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority           = (uint)Property.Id.EventPriority;
            /// <summary>
            /// The timezone_id of the event, if it exists.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Timezone           = (uint)Property.Id.EventTimezone;
            /// <summary>
            /// The person_id of the event if the event is a birthday. Refer to the contacts-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ContactId          = (uint)Property.Id.EventContactId;
            /// <summary>
            /// The busy status of event (refer to the CalendarTypes.BusyStatus).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BusyStatus         = (uint)Property.Id.EventBusyStatus;
            /// <summary>
            /// The sensitivity of event (refer to the CalendarTypes.Sensitivity).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity        = (uint)Property.Id.EventSensitivity;
            /// <summary>
            /// The unique ID of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Uid                = (uint)Property.Id.EventUid;
            /// <summary>
            /// The name of organizer of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerName      = (uint)Property.Id.EventOrganizerName;
            /// <summary>
            /// The email address of the organizer of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerEmail     = (uint)Property.Id.EventOrganizerEmail;
            /// <summary>
            /// The meeting status of event (refer to the CalendarTypes.MeetingStatus).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint MeetingStatus      = (uint)Property.Id.EventMeetingStatus;
            /// <summary>
            /// The ID of the original event, if the event is an exception.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OriginalEventId    = (uint)Property.Id.EventOriginalEventId;
            /// <summary>
            /// The latitude of the location of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude           = (uint)Property.Id.EventLatitude;
            /// <summary>
            /// The longitude of the location of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude          = (uint)Property.Id.EventLongitude;
            /// <summary>
            /// ID of the email_id. Refer to the email-service.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EmailId            = (uint)Property.Id.EventEmailId;
            /// <summary>
            /// The time when the event is created.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CreatedTime        = (uint)Property.Id.EventCreatedTime;
            /// <summary>
            /// The time when the event is updated.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedTime   = (uint)Property.Id.EventLastModifiedTime;
            /// <summary>
            ///  Whether or not the event is deleted.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDeleted          = (uint)Property.Id.EventIsDeleted;
            /// <summary>
            /// The frequent type of event recurrence (refer to the CalendarTypes.Recurrence).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Freq               = (uint)Property.Id.EventFreq;
            /// <summary>
            /// The range type of event recurrence (refer to the CalendarTypes.RangeType).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RangeType          = (uint)Property.Id.EventRangeType;
            /// <summary>
            /// The end time of the event recurrence. Only if this is used with RangeType.Until.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Until              = (uint)Property.Id.EventUntil;
            /// <summary>
            /// The count of the event recurrence. Only if this is used with RangeType.Count.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Count              = (uint)Property.Id.EventCount;
            /// <summary>
            /// The interval of the event recurrence.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Interval           = (uint)Property.Id.EventInterval;
            /// <summary>
            /// The second list of the event recurrence. The value can be from 0 to 59. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bysecond           = (uint)Property.Id.EventBysecond;
            /// <summary>
            /// The minute list of the event recurrence. The value can be from 0 to 59. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byminute           = (uint)Property.Id.EventByminute;
            /// <summary>
            /// The hour list of the event recurrence. The value can be from 0 to 23. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byhour             = (uint)Property.Id.EventByhour;
            /// <summary>
            /// The day list of the event recurrence. The value can be SU, MO, TU, WE, TH, FR, SA. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byday              = (uint)Property.Id.EventByday;
            /// <summary>
            /// The month day list of the event recurrence. The value can be from 1 to 31 and from -31 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bymonthday         = (uint)Property.Id.EventBymonthday;
            /// <summary>
            /// The year day list of the event recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byyearday          = (uint)Property.Id.EventByyearday;
            /// <summary>
            /// The week number list of the event recurrence. The value can be from 1 to 53 and from -53 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byweekno           = (uint)Property.Id.EventByweekno;
            /// <summary>
            /// The month list of the event recurrence. The value can be from 1 to 12. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bymonth            = (uint)Property.Id.EventBymonth;
            /// <summary>
            /// The position list of the event recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bysetpos           = (uint)Property.Id.EventBysetpos;
            /// <summary>
            /// The start day of the week (refer to the CalendarTypes.WeekDay).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Wkst               = (uint)Property.Id.EventWkst;
            /// <summary>
            /// RECURRENCE-ID of RFC #2445.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RecurrenceId       = (uint)Property.Id.EventRecurrenceId;
            /// <summary>
            /// RDATE of RFC #2445.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Rdate              = (uint)Property.Id.EventRdate;
            /// <summary>
            /// Whether or not the event has an attendee list.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAttendee        = (uint)Property.Id.EventHasAttendee;
            /// <summary>
            /// Whether or not the event has an alarm list.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm           = (uint)Property.Id.EventHasAlarm;
            /// <summary>
            /// The sync data of the event. If the developers need to save some information related to the event, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1          = (uint)Property.Id.EventSyncData1;
            /// <summary>
            /// The sync data of the event. If the developers need to save some information related to the event, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData2          = (uint)Property.Id.EventSyncData2;
            /// <summary>
            /// The sync data of the event. If the developers need to save some information related to the event, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData3          = (uint)Property.Id.EventSyncData3;
            /// <summary>
            /// The sync data of the event. If the developers need to save some information related to the event, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData4          = (uint)Property.Id.EventSyncData4;
            /// <summary>
            /// The start time of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start              = (uint)Property.Id.EventStart;
            /// <summary>
            /// The end time of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint End                = (uint)Property.Id.EventEnd;
            /// <summary>
            /// The alarm list of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Alarm              = (uint)Property.Id.EventAlarm;
            /// <summary>
            /// The attendee list of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Attendee           = (uint)Property.Id.EventAttendee;
            /// <summary>
            /// The calendar system type (refer to the CalendarTypes.SystemType).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CalendarSystemType = (uint)Property.Id.EventCalendarSystemType;
            /// <summary>
            /// The timezone of the start_time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StartTzid          = (uint)Property.Id.EventStartTzid;
            /// <summary>
            /// The timezone of the end_time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EndTzid            = (uint)Property.Id.EventEndTzid;
            /// <summary>
            /// The exception mod event list of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Exception          = (uint)Property.Id.EventException;
            /// <summary>
            /// The extended property list of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Extended           = (uint)Property.Id.EventExtended;
            /// <summary>
            /// The event is an allday event or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsAllday           = (uint)Property.Id.EventIsAllday;
            /// <summary>
            /// The linked event count.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkCount          = (uint)Property.Id.EventLinkCount;
            /// <summary>
            /// The event is an base linked event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LinkBaseId         = (uint)Property.Id.EventLinkBaseId;
        }

        /// <summary>
        /// Describes the properties of a Todo record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Todo
        {
            /// <summary>
            /// Identifier of this todo view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.todo";
            /// <summary>
            /// Database record ID of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id                = (uint)Property.Id.TodoId;
            /// <summary>
            /// ID of the calendar book to which the todo belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId            = (uint)Property.Id.TodoBookId;
            /// <summary>
            /// The short description of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary           = (uint)Property.Id.TodoSummary;
            /// <summary>
            /// The description of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description       = (uint)Property.Id.TodoDescription;
            /// <summary>
            /// The location of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location          = (uint)Property.Id.TodoLocation;
            /// <summary>
            /// The category of the todo. For example, APPOINTMENT, BIRTHDAY.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Categories        = (uint)Property.Id.TodoCategories;
            /// <summary>
            /// The status of the todo (refer to the CalendarTypes.TodoStatus).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint TodoStatus        = (uint)Property.Id.TodoStatus;
            /// <summary>
            /// The priority of the todo (refer to the CalendarTypes.Priority).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority          = (uint)Property.Id.TodoPriority;
            /// <summary>
            /// The sensitivity of the todo (refer to the CalendarTypes.Sensitivity).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity       = (uint)Property.Id.TodoSensitivity;
            /// <summary>
            /// The unique ID of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Uid               = (uint)Property.Id.TodoUid;
            /// <summary>
            /// The latitude of the location of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude          = (uint)Property.Id.TodoLatitude;
            /// <summary>
            /// The longitude of the location of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude         = (uint)Property.Id.TodoLongitude;
            /// <summary>
            /// The progression of the todo. The value can be from 0 to 100.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Progress          = (uint)Property.Id.TodoProgress;
            /// <summary>
            /// The time when the todo is created.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CreatedTime       = (uint)Property.Id.TodoCreatedTime;
            /// <summary>
            /// The time when the todo is updated.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedTime  = (uint)Property.Id.TodoLastModifiedTime;
            /// <summary>
            /// The time when the todo is completed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CompletedTime     = (uint)Property.Id.TodoCompletedTime;
            /// <summary>
            ///  Whether or not the todo is deleted.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsDeleted         = (uint)Property.Id.TodoIsDeleted;
            /// <summary>
            /// The frequent type of the todo recurrence (refer to the CalendarTypes.Recurrence).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Freq              = (uint)Property.Id.TodoFreq;
            /// <summary>
            /// The range type of the todo recurrence (refer to the CalendarTypes.RangeType).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RangeType         = (uint)Property.Id.TodoRangeType;
            /// <summary>
            /// The end time of the todo recurrence. Only if this is used with RangeType.Until..
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Until             = (uint)Property.Id.TodoUntil;
            /// <summary>
            /// The count of the todo recurrence. Only if this is used with RangeType.Count.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Count             = (uint)Property.Id.TodoCount;
            /// <summary>
            /// The interval of the todo recurrence.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Interval      = (uint)Property.Id.TodoInterval;
            /// <summary>
            /// The second list of the todo recurrence. The value can be from 0 to 59. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bysecond          = (uint)Property.Id.TodoBysecond;
            /// <summary>
            /// The minute list of the todo recurrence. The value can be from 0 to 59. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byminute          = (uint)Property.Id.TodoByminute;
            /// <summary>
            /// The hour list of the todo recurrence. The value can be from 0 to 23. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byhour            = (uint)Property.Id.TodoByhour;
            /// <summary>
            /// The day list of the todo recurrence. The value can be SU, MO, TU, WE, TH, FR, SA. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byday             = (uint)Property.Id.TodoByday;
            /// <summary>
            /// The month day list of the todo recurrence. The value can be from 1 to 31 and from -31 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bymonthday        = (uint)Property.Id.TodoBymonthday;
            /// <summary>
            /// The year day list of the todo recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byyearday         = (uint)Property.Id.TodoByyearday;
            /// <summary>
            /// The week number list of the todo recurrence. The value can be from 1 to 53 and from -53 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Byweekno          = (uint)Property.Id.TodoByweekno;
            /// <summary>
            /// The month list of the todo recurrence. The value can be from 1 to 12. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bymonth           = (uint)Property.Id.TodoBymonth;
            /// <summary>
            /// The position list of the todo recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Bysetpos          = (uint)Property.Id.TodoBysetpos;
            /// <summary>
            /// The start day of the week (refer to the CalendarTypes.WeekDay).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Wkst              = (uint)Property.Id.TodoWkst;
            /// <summary>
            /// Whether or not the todo has an alarm list.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm          = (uint)Property.Id.TodoHasAlarm;
            /// <summary>
            /// The sync data of the todo. If the developers need to save some information related to the todo, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1         = (uint)Property.Id.TodoSyncData1;
            /// <summary>
            /// The sync data of the todo. If the developers need to save some information related to the todo, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData2         = (uint)Property.Id.TodoSyncData2;
            /// <summary>
            /// The sync data of the todo. If the developers need to save some information related to the todo, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData3         = (uint)Property.Id.TodoSyncData3;
            /// <summary>
            /// The sync data of the todo. If the developers need to save some information related to the todo, they can use this property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData4         = (uint)Property.Id.TodoSyncData4;
            /// <summary>
            /// The start time of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start             = (uint)Property.Id.TodoStart;
            /// <summary>
            /// The due time of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Due               = (uint)Property.Id.TodoDue;
            /// <summary>
            /// The alarm list of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Alarm             = (uint)Property.Id.TodoAlarm;
            /// <summary>
            /// The timezone of the start_time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StartTzid         = (uint)Property.Id.TodoStartTzid;
            /// <summary>
            /// The timezone of the due_time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DueTzid           = (uint)Property.Id.TodoDueTzid;
            /// <summary>
            /// The name of the organizer of the event.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerName     = (uint)Property.Id.TodoOrganizerName;
            /// <summary>
            /// The email address of the organizer of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerEmail    = (uint)Property.Id.TodoOrganizerEmail;
            /// <summary>
            /// Whether or not the todo has an attendee list.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAttendee       = (uint)Property.Id.TodoHasAttendee;
            /// <summary>
            /// The attendee list of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Attendee          = (uint)Property.Id.TodoAttendee;
            /// <summary>
            /// The extended property list of the todo.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Extended          = (uint)Property.Id.TodoExtended;
            /// <summary>
            /// The todo is an allday event or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsAllday          = (uint)Property.Id.TodoIsAllday;
        }

        /// <summary>
        /// Describes the properties of a timezone record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Timezone
        {
            /// <summary>
            /// Identifier of this timezone view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.timezone";
            /// <summary>
            /// Database record ID of the timezone.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id                          = (uint)Property.Id.TimezoneId;
            /// <summary>
            /// UTC offset, which is in use when the onset of this time zone observance begins. Valid values are -720(-12:00) to 840(+14:00).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint TzOffsetFromGmt             = (uint)Property.Id.TimezoneTzOffsetFromGmt;
            /// <summary>
            /// Name of the standard time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StandardName                = (uint)Property.Id.TimezoneStandardName;
            /// <summary>
            /// Starting month of the standard time. Month is 0-based. For example, 0 for January.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StdStartMonth               = (uint)Property.Id.TimezoneStdStartMonth;
            /// <summary>
            /// Starting day-of-week-in-month of the standard time. Day is 1-based.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StdStartPositionOfWeek      = (uint)Property.Id.TimezoneStdStartPositionOfWeek;
            /// <summary>
            /// Starting day-of-week of the standard time. Valid values are 1 (SUNDAY) to 7 (SATURDAY).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StdStartDay                 = (uint)Property.Id.TimezoneStdStartDay;
            /// <summary>
            /// Starting hour of the standard time. Valid values are 0 to 23.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StdStartHour                = (uint)Property.Id.TimezoneStdStartHour;
            /// <summary>
            /// The number of minutes added during the standard time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint StandardBias                = (uint)Property.Id.TimezoneStandardBias;
            /// <summary>
            /// Name of the Daylight.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightName                = (uint)Property.Id.TimezoneDayLightName;
            /// <summary>
            /// Starting month of the Daylight. Month is 0-based. For example, 0 for January.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightStartMonth          = (uint)Property.Id.TimezoneDayLightStartMonth;
            /// <summary>
            /// Starting day-of-week-in-month of the Daylight. Day is 1-based.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightStartPositionOfWeek = (uint)Property.Id.TimezoneDayLightStartPositionOfWeek;
            /// <summary>
            /// Starting day-of-week of the Daylight. Valid values are 1 (SUNDAY) to 7 (SATURDAY).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightStartDay            = (uint)Property.Id.TimezoneDayLightStartDay;
            /// <summary>
            /// Starting hour of the Daylight. Valid values are 0 to 23.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightStartHour           = (uint)Property.Id.TimezoneDayLightStartHour;
            /// <summary>
            /// The number of minutes added during the Daylight time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DayLightBias                = (uint)Property.Id.TimezoneDayLightBias;
            /// <summary>
            /// Database record ID of a related calendar book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CalendarId                  = (uint)Property.Id.TimezoneCalendarId;
        }

        /// <summary>
        /// Describes the properties of an Attendee record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Attendee
        {
            /// <summary>
            /// Identifier of this calendar attendee view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.attendee";
            /// <summary>
            /// The number of the attendee.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Number       = (uint)Property.Id.AttendeeNumber;
            /// <summary>
            /// The type of attendee (refer to the CalendarTypes.Cutype).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Cutype       = (uint)Property.Id.AttendeeCutype;
            /// <summary>
            /// CtIndex.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CtIndex      = (uint)Property.Id.AttendeeCtIndex;
            /// <summary>
            /// Unique identifier.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Uid          = (uint)Property.Id.AttendeeUid;
            /// <summary>
            /// Group.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Group        = (uint)Property.Id.AttendeeGroup;
            /// <summary>
            /// The email address of the attendee.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Email        = (uint)Property.Id.AttendeeEmail;
            /// <summary>
            /// Attendee role (refer to the CalendarTypes.AttendeeRole).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Role         = (uint)Property.Id.AttendeeRole;
            /// <summary>
            /// Attendee status (refer to the CalendarTypes.AttendeeStatus).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Status       = (uint)Property.Id.AttendeeStatus;
            /// <summary>
            /// RSVP invitation reply (one of true, false).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Rsvp         = (uint)Property.Id.AttendeeRsvp;
            /// <summary>
            /// Delegatee (DELEGATED-TO).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DelegateeUri = (uint)Property.Id.AttendeeDelegateeUri;
            /// <summary>
            /// Delegator (DELEGATED-FROM).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint DelegatorUri = (uint)Property.Id.AttendeeDelegatorUri;
            /// <summary>
            /// Attendee name.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Name         = (uint)Property.Id.AttendeeName;
            /// <summary>
            /// Group that the attendee belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Member       = (uint)Property.Id.AttendeeMember;
            /// <summary>
            /// Event/TODO that the attendee belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ParentId     = (uint)Property.Id.AttendeeParentId;
        }

        /// <summary>
        /// Describes the properties of an Alarm record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Alarm
        {
            /// <summary>
            /// Identifier of this calendar alarm view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.alarm";
            /// <summary>
            /// The number of unit before start time. This must be used with one of TickUnit.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Tick        = (uint)Property.Id.AlarmTick;
            /// <summary>
            /// Reminder tick time unit (refer to the CalendarTypes.TickUnit).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint TickUnit    = (uint)Property.Id.AlarmTickUnit;
            /// <summary>
            /// Alarm description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description = (uint)Property.Id.AlarmDescription;
            /// <summary>
            /// Event that the alarm belongs to.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint ParentId    = (uint)Property.Id.AlarmParentId;
            /// <summary>
            /// Alarm summary.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary     = (uint)Property.Id.AlarmSummary;
            /// <summary>
            /// Action of alarm (refer to the CalendarTypes.Action).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Action      = (uint)Property.Id.AlarmAction;
            /// <summary>
            /// Alarm tone path.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Attach      = (uint)Property.Id.AlarmAttach;
            /// <summary>
            /// The alarm time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint AlarmTime   = (uint)Property.Id.AlarmAlarm;
        }

        /// <summary>
        /// Describes the properties of an InstanceUtimeBook record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>Read only view.</remarks>
        public static class InstanceUtimeBook
        {
            /// <summary>
            /// Identifier of this instance utime book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.instance_utime/book";
            /// <summary>
            /// Event ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventId          = (uint)Property.Id.InstanceUtimeBookEventId;
            /// <summary>
            /// Start time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start            = (uint)Property.Id.InstanceUtimeBookStart;
            /// <summary>
            /// End time.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint End              = (uint)Property.Id.InstanceUtimeBookEnd;
            /// <summary>
            /// Summary.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary          = (uint)Property.Id.InstanceUtimeBookSummary;
            /// <summary>
            /// Location.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location         = (uint)Property.Id.InstanceUtimeBookLocation;
            /// <summary>
            /// Book ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId           = (uint)Property.Id.InstanceUtimeBookBookId;
            /// <summary>
            /// Description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description      = (uint)Property.Id.InstanceUtimeBookDescription;
            /// <summary>
            /// BusyStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BusyStatus       = (uint)Property.Id.InstanceUtimeBookBusyStatus;
            /// <summary>
            /// EventStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventStatus      = (uint)Property.Id.InstanceUtimeBookEventStatus;
            /// <summary>
            /// Priority.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority         = (uint)Property.Id.InstanceUtimeBookPriority;
            /// <summary>
            /// Sensitivity.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity      = (uint)Property.Id.InstanceUtimeBookSensitivity;
            /// <summary>
            /// HasRrule.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasRrule         = (uint)Property.Id.InstanceUtimeBookHasRrule;
            /// <summary>
            /// Latitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude         = (uint)Property.Id.InstanceUtimeBookLatitude;
            /// <summary>
            /// Longitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude        = (uint)Property.Id.InstanceUtimeBookLongitude;
            /// <summary>
            /// HasAlarm.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm         = (uint)Property.Id.InstanceUtimeBookHasAlarm;
            /// <summary>
            /// OriginalEventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OriginalEventId  = (uint)Property.Id.InstanceUtimeBookOriginalEventId;
            /// <summary>
            /// LastModifiedtime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedtime = (uint)Property.Id.InstanceUtimeBookLastModifiedTime;
            /// <summary>
            /// SyncData1.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1        = (uint)Property.Id.InstanceUtimeBookSyncData1;
        }

        /// <summary>
        /// Describes the properties of an InstanceLocaltimeBook record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>Read only view.</remarks>
        public static class InstanceLocaltimeBook
        {
            /// <summary>
            /// URI.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.instance_localtime/book";
            /// <summary>
            /// EventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventId          = (uint)Property.Id.InstanceLocaltimeBookEventId;
            /// <summary>
            /// Start.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start            = (uint)Property.Id.InstanceLocaltimeBookStart;
            /// <summary>
            /// End.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint End              = (uint)Property.Id.InstanceLocaltimeBookEnd;
            /// <summary>
            /// Summary.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary          = (uint)Property.Id.InstanceLocaltimeBookSummary;
            /// <summary>
            /// Location.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location         = (uint)Property.Id.InstanceLocaltimeBookLocation;
            /// <summary>
            /// BookId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId           = (uint)Property.Id.InstanceLocaltimeBookBookId;
            /// <summary>
            /// Description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description      = (uint)Property.Id.InstanceLocaltimeBookDescription;
            /// <summary>
            /// BusyStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BusyStatus       = (uint)Property.Id.InstanceLocaltimeBookBusyStatus;
            /// <summary>
            /// EventStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventStatus      = (uint)Property.Id.InstanceLocaltimeBookEventStatus;
            /// <summary>
            /// Priority.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority         = (uint)Property.Id.InstanceLocaltimeBookPriority;
            /// <summary>
            /// Sensitivity.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity      = (uint)Property.Id.InstanceLocaltimeBookSensitivity;
            /// <summary>
            /// HasRrule.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasRrule         = (uint)Property.Id.InstanceLocaltimeBookHasRrule;
            /// <summary>
            /// Latitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude         = (uint)Property.Id.InstanceLocaltimeBookLatitude;
            /// <summary>
            /// Longitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude        = (uint)Property.Id.InstanceLocaltimeBookLongitude;
            /// <summary>
            /// HasAlarm.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm         = (uint)Property.Id.InstanceLocaltimeBookHasAlarm;
            /// <summary>
            /// OriginalEventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OriginalEventId  = (uint)Property.Id.InstanceLocaltimeBookOriginalEventId;
            /// <summary>
            /// LastModifiedTime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedTime = (uint)Property.Id.InstanceLocaltimeBookLastModifiedTime;
            /// <summary>
            /// SyncData1.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1        = (uint)Property.Id.InstanceLocaltimeBookSyncData1;
            /// <summary>
            /// IsAllday.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsAllday         = (uint)Property.Id.InstanceLocaltimeBookIsAllday;
        }

        /// <summary>
        /// Describes the properties of an InstanceUtimeBookExtended record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>Read only view.</remarks>
        public static class InstanceUtimeBookExtended
        {
            /// <summary>
            /// URI.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.extended/instance_utime/book";
            /// <summary>
            /// EventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventId           = (uint)Property.Id.InstanceUtimeBookExtendedEventId;
            /// <summary>
            /// Start.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start             = (uint)Property.Id.InstanceUtimeBookExtendedStart;
            /// <summary>
            /// End.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint End               = (uint)Property.Id.InstanceUtimeBookExtendedEnd;
            /// <summary>
            /// Summary.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary           = (uint)Property.Id.InstanceUtimeBookExtendedSummary;
            /// <summary>
            /// Location.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location          = (uint)Property.Id.InstanceUtimeBookExtendedLocation;
            /// <summary>
            /// BookId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId            = (uint)Property.Id.InstanceUtimeBookExtendedBookId;
            /// <summary>
            /// Description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description       = (uint)Property.Id.InstanceUtimeBookExtendedDescription;
            /// <summary>
            /// BusyStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BusyStatus        = (uint)Property.Id.InstanceUtimeBookExtendedBusyStatus;
            /// <summary>
            /// EventStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventStatus       = (uint)Property.Id.InstanceUtimeBookExtendedEventStatus;
            /// <summary>
            /// Priority.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority          = (uint)Property.Id.InstanceUtimeBookExtendedPriority;
            /// <summary>
            /// Sensitivity.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity       = (uint)Property.Id.InstanceUtimeBookExtendedSensitivity;
            /// <summary>
            /// HasRrule.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasRrule          = (uint)Property.Id.InstanceUtimeBookExtendedHasRrule;
            /// <summary>
            /// Latitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude          = (uint)Property.Id.InstanceUtimeBookExtendedLatitude;
            /// <summary>
            /// Longitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude         = (uint)Property.Id.InstanceUtimeBookExtendedLongitude;
            /// <summary>
            /// HasAlarm.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm          = (uint)Property.Id.InstanceUtimeBookExtendedHasAlarm;
            /// <summary>
            /// OriginalEventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OriginalEventId   = (uint)Property.Id.InstanceUtimeBookExtendedOriginalEventId;
            /// <summary>
            /// LastModifiedTime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedTime  = (uint)Property.Id.InstanceUtimeBookExtendedLastModifiedTime;
            /// <summary>
            /// SyncData1.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1         = (uint)Property.Id.InstanceUtimeBookExtendedSyncData1;
            /// <summary>
            /// OrganizerName.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerName     = (uint)Property.Id.InstanceUtimeBookExtendedOrganizerName;
            /// <summary>
            /// Categories.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Categories        = (uint)Property.Id.InstanceUtimeBookExtendedCategories;
            /// <summary>
            /// HasAttendee.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAttendee       = (uint)Property.Id.InstanceUtimeBookExtendedHasAttendee;
            /// <summary>
            /// SyncData2.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData2         = (uint)Property.Id.InstanceUtimeBookExtendedSyncData2;
            /// <summary>
            /// SyncData3.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData3         = (uint)Property.Id.InstanceUtimeBookExtendedSyncData3;
            /// <summary>
            /// SyncData4.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData4         = (uint)Property.Id.InstanceUtimeBookExtendedSyncData4;
        }

        /// <summary>
        /// Describes the properties of an InstanceLocaltimeBookExtended record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>Read only view.</remarks>
        public static class InstanceLocaltimeBookExtended
        {
            /// <summary>
            /// URI.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.extended/instance_localtime/book";
            /// <summary>
            /// EventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventId          = (uint)Property.Id.InstanceLocaltimeBookExtendedEventId;
            /// <summary>
            /// Start.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Start            = (uint)Property.Id.InstanceLocaltimeBookExtendedStart;
            /// <summary>
            /// End.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint End              = (uint)Property.Id.InstanceLocaltimeBookExtendedEnd;
            /// <summary>
            /// Summary.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Summary          = (uint)Property.Id.InstanceLocaltimeBookExtendedSummary;
            /// <summary>
            /// Location.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Location         = (uint)Property.Id.InstanceLocaltimeBookExtendedLocation;
            /// <summary>
            /// BookId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BookId           = (uint)Property.Id.InstanceLocaltimeBookExtendedBookId;
            /// <summary>
            /// Description.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Description      = (uint)Property.Id.InstanceLocaltimeBookExtendedDescription;
            /// <summary>
            /// BusyStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint BusyStatus       = (uint)Property.Id.InstanceLocaltimeBookExtendedBusyStatus;
            /// <summary>
            /// EventStatus.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint EventStatus      = (uint)Property.Id.InstanceLocaltimeBookExtendedEventStatus;
            /// <summary>
            /// Priority.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Priority         = (uint)Property.Id.InstanceLocaltimeBookExtendedPriority;
            /// <summary>
            /// Sensitivity.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Sensitivity      = (uint)Property.Id.InstanceLocaltimeBookExtendedSensitivity;
            /// <summary>
            /// HasRrule.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasRrule         = (uint)Property.Id.InstanceLocaltimeBookExtendedHasRrule;
            /// <summary>
            /// Latitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Latitude         = (uint)Property.Id.InstanceLocaltimeBookExtendedLatitude;
            /// <summary>
            /// Longitude.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Longitude        = (uint)Property.Id.InstanceLocaltimeBookExtendedLongitude;
            /// <summary>
            /// HasAlarm.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAlarm         = (uint)Property.Id.InstanceLocaltimeBookExtendedHasAlarm;
            /// <summary>
            /// OriginalEventId.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OriginalEventId  = (uint)Property.Id.InstanceLocaltimeBookExtendedOriginalEventId;
            /// <summary>
            /// LastModifiedTime.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint LastModifiedTime = (uint)Property.Id.InstanceLocaltimeBookExtendedLastModifiedTime;
            /// <summary>
            /// SyncData1.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData1        = (uint)Property.Id.InstanceLocaltimeBookExtendedSyncData1;
            /// <summary>
            /// OrganizerName.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint OrganizerName    = (uint)Property.Id.InstanceLocaltimeBookExtendedOrganizerName;
            /// <summary>
            /// Categories.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Categories       = (uint)Property.Id.InstanceLocaltimeBookExtendedCategories;
            /// <summary>
            /// HasAttendee.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint HasAttendee      = (uint)Property.Id.InstanceLocaltimeBookExtendedHasAttendee;
            /// <summary>
            /// SyncData2.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData2        = (uint)Property.Id.InstanceLocaltimeBookExtendedSyncData2;
            /// <summary>
            /// SyncData3.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData3        = (uint)Property.Id.InstanceLocaltimeBookExtendedSyncData3;
            /// <summary>
            /// SyncData4.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint SyncData4        = (uint)Property.Id.InstanceLocaltimeBookExtendedSyncData4;
            /// <summary>
            /// IsAllday.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint IsAllday         = (uint)Property.Id.InstanceLocaltimeBookExtendedIsAllday;
        }

        /// <summary>
        /// Describes the properties of an UpdatedInfo record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>Read only view.</remarks>
        public static class UpdatedInfo
        {
            /// <summary>
            /// Identifier of this UpdatedInfo view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.updated_info";
            /// <summary>
            /// Modified event (or todo) record ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id         = (uint)Property.Id.UpdateInfoId;
            /// <summary>
            /// Calendar book ID of the modified event (or todo) record.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint CalendarId = (uint)Property.Id.UpdateInfoCalendarId;
            /// <summary>
            /// Enumeration value of the modified status.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Type       = (uint)Property.Id.UpdateInfoType;
            /// <summary>
            /// Version after change.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Version    = (uint)Property.Id.UpdateInfoVersion;
        }

        /// <summary>
        /// Describes the properties of an Extended record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static class Extended
        {
            /// <summary>
            /// Identifier of this extended_property view.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const string Uri = "tizen.calendar_view.extended_property";
            /// <summary>
            /// Database record ID of the extended_property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Id         = (uint)Property.Id.ExtendedId;
            /// <summary>
            /// Related record ID.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RecordId   = (uint)Property.Id.ExtendedRecordId;
            /// <summary>
            /// Enumeration value of the record type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint RecordType = (uint)Property.Id.ExtendedRecordType;
            /// <summary>
            /// The key of the property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Key        = (uint)Property.Id.ExtendedKey;
            /// <summary>
            /// The value of the property.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public const uint Value      = (uint)Property.Id.ExtendedValue;
        }
    }
}

