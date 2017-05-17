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
using System.Collections;
using System.Collections.Generic;

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// This class provides information about views with properties.
    /// </summary>
    /// <remarks>
    ///  A view is a class which describes properties of a record.
    ///  A record can have basic properties of five types: integer, string, long, double, CalendarTime.
    /// </remarks>
    public static class CalendarViews
    {
        /// data type mask 0x0FF00000
        private const uint ViewMask                          = 0xFF000000;
        private const uint ViewBook                          = 0x01000000;
        private const uint ViewEvent                         = 0x02000000;
        private const uint ViewTodo                          = 0x03000000;
        private const uint ViewTimezone                      = 0x04000000;
        private const uint ViewAttendee                      = 0x05000000;
        private const uint ViewAlarm                         = 0x06000000;
        private const uint ViewInstanceUtimeBook             = 0x07000000;
        private const uint ViewInstanceLocaltimeBook         = 0x08000000;
        private const uint ViewUpdateInfo                    = 0x09000000;
        private const uint ViewExtended                      = 0x0A000000;
        private const uint ViewInstanceUtimeBookExtended     = 0x0B000000;
        private const uint ViewInstanceLocaltimeBookExtended = 0x0C000000;

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

        private enum PropertyIds : uint
        {
            /// book
            BookId          = (ViewBook|DataTypeInteger|PropertyReadOnly),
            BookUid         = (ViewBook|DataTypeString) + 1,
            BookName        = (ViewBook|DataTypeString) + 2,
            BookDescription = (ViewBook|DataTypeString) + 3,
            BookColor       = (ViewBook|DataTypeString) + 4,
            BookLocation    = (ViewBook|DataTypeString) + 5,
            BookVisibility  = (ViewBook|DataTypeInteger) + 6,
            BookSyncEvent   = (ViewBook|DataTypeInteger) + 7,
            BookAccountId   = (ViewBook|DataTypeInteger) + 8,
            BookStoreType   = (ViewBook|DataTypeInteger) + 9,
            BookSyncData1   = (ViewBook|DataTypeString) + 10,
            BookSyncData2   = (ViewBook|DataTypeString) + 11,
            BookSyncData3   = (ViewBook|DataTypeString) + 12,
            BookSyncData4   = (ViewBook|DataTypeString) + 13,
            BookMode        = (ViewBook|DataTypeInteger) + 14,

            /// Event
            EventId                 = (ViewEvent|DataTypeInteger|PropertyReadOnly),
            EventBookId             = (ViewEvent|DataTypeInteger) + 1,
            EventSummary            = (ViewEvent|DataTypeString) + 2,
            EventDescription        = (ViewEvent|DataTypeString) + 3,
            EventLocation           = (ViewEvent|DataTypeString) + 4,
            EventCategories         = (ViewEvent|DataTypeString) + 5,
            EventExdate             = (ViewEvent|DataTypeString) + 6,
            EventEventStatus        = (ViewEvent|DataTypeInteger) + 7,
            EventPriority           = (ViewEvent|DataTypeInteger) + 8,
            EventTimezone           = (ViewEvent|DataTypeInteger) + 9,
            EventContactId          = (ViewEvent|DataTypeInteger) + 10,
            EventBusyStatus         = (ViewEvent|DataTypeInteger) + 11,
            EventSensitivity        = (ViewEvent|DataTypeInteger) + 12,
            EventUid                = (ViewEvent|DataTypeString) + 13,
            EventOrganizerName      = (ViewEvent|DataTypeString) + 14,
            EventOrganizerEmail     = (ViewEvent|DataTypeString) + 15,
            EventMeetingStatus      = (ViewEvent|DataTypeInteger) + 16,
            EventOriginalEventId    = (ViewEvent|DataTypeInteger) + 17,
            EventLatitude           = (ViewEvent|DataTypeDouble) + 18,
            EventLongitude          = (ViewEvent|DataTypeDouble) + 19,
            EventEmailId            = (ViewEvent|DataTypeInteger) + 20,
            EventCreatedTime        = (ViewEvent|DataTypeLong) + 21,
            EventLastModifiedTime   = (ViewEvent|DataTypeLong|PropertyReadOnly) + 22,
            EventIsDeleted          = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 23,
            EventFreq               = (ViewEvent|DataTypeInteger) + 24,
            EventRangeType          = (ViewEvent|DataTypeInteger) + 25,
            EventUntil              = (ViewEvent|DataTypeCaltime) + 26,
            EventCount              = (ViewEvent|DataTypeInteger) + 27,
            EventInterval           = (ViewEvent|DataTypeInteger) + 28,
            EventBysecond           = (ViewEvent|DataTypeString) + 29,
            EventByminute           = (ViewEvent|DataTypeString) + 30,
            EventByhour             = (ViewEvent|DataTypeString) + 31,
            EventByday              = (ViewEvent|DataTypeString) + 32,
            EventBymonthday         = (ViewEvent|DataTypeString) + 33,
            EventByyearday          = (ViewEvent|DataTypeString) + 34,
            EventByweekno           = (ViewEvent|DataTypeString) + 35,
            EventBymonth            = (ViewEvent|DataTypeString) + 36,
            EventBysetpos           = (ViewEvent|DataTypeString) + 37,
            EventWkst               = (ViewEvent|DataTypeInteger) + 38,
            EventRecurrenceId       = (ViewEvent|DataTypeString) + 39,
            EventRdate              = (ViewEvent|DataTypeString) + 40,
            EventHasAttendee        = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 41,
            EventHasAlarm           = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 42,
            EventSyncData1          = (ViewEvent|DataTypeString) + 43,
            EventSyncData2          = (ViewEvent|DataTypeString) + 44,
            EventSyncData3          = (ViewEvent|DataTypeString) + 45,
            EventSyncData4          = (ViewEvent|DataTypeString) + 46,
            EventStart              = (ViewEvent|DataTypeCaltime) + 47,
            EventEnd                = (ViewEvent|DataTypeCaltime) + 48,
            EventAlarm              = (ViewEvent|DataTypeRecord) + 49,
            EventAttendee           = (ViewEvent|DataTypeRecord) + 50,
            EventCalendarSystemType = (ViewEvent|DataTypeInteger) + 51,
            EventStartTzid          = (ViewEvent|DataTypeString) + 52,
            EventEndTzid            = (ViewEvent|DataTypeString) + 53,
            EventException          = (ViewEvent|DataTypeRecord) + 54,
            EventExtended           = (ViewEvent|DataTypeRecord) + 55,
            EventIsAllday           = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 56,
            EventLinkCount          = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 57,
            EventLinkBaseId         = (ViewEvent|DataTypeInteger|PropertyReadOnly) + 58,

            /// Todo
            TodoId                   = (ViewTodo|DataTypeInteger|PropertyReadOnly),
            TodoBookId               = (ViewTodo|DataTypeInteger) + 1,
            TodoSummary              = (ViewTodo|DataTypeString) + 2,
            TodoDescription          = (ViewTodo|DataTypeString) + 3,
            TodoLocation             = (ViewTodo|DataTypeString) + 4,
            TodoCategories           = (ViewTodo|DataTypeString) + 5,
            TodoStatus               = (ViewTodo|DataTypeInteger) + 6,
            TodoPriority             = (ViewTodo|DataTypeInteger) + 7,
            TodoSensitivity          = (ViewTodo|DataTypeInteger) + 8,
            TodoUid                  = (ViewTodo|DataTypeString) + 9,
            TodoLatitude             = (ViewTodo|DataTypeDouble) + 10,
            TodoLongitude            = (ViewTodo|DataTypeDouble) + 11,
            TodoProgress             = (ViewTodo|DataTypeInteger) + 12,
            TodoCreatedTime          = (ViewTodo|DataTypeLong) + 13,
            TodoLastModifiedTime     = (ViewTodo|DataTypeLong|PropertyReadOnly) + 14,
            TodoCompletedTime        = (ViewTodo|DataTypeLong) + 15,
            TodoIsDeleted            = (ViewTodo|DataTypeInteger|PropertyReadOnly) + 16,
            TodoFreq                 = (ViewTodo|DataTypeInteger) + 17,
            TodoRangeType            = (ViewTodo|DataTypeInteger) + 18,
            TodoUntil                = (ViewTodo|DataTypeCaltime) + 19,
            TodoCount                = (ViewTodo|DataTypeInteger) + 20,
            TodoIntegererval         = (ViewTodo|DataTypeInteger) + 21,
            TodoBysecond             = (ViewTodo|DataTypeString) + 22,
            TodoByminute             = (ViewTodo|DataTypeString) + 23,
            TodoByhour               = (ViewTodo|DataTypeString) + 24,
            TodoByday                = (ViewTodo|DataTypeString) + 25,
            TodoBymonthday           = (ViewTodo|DataTypeString) + 26,
            TodoByyearday            = (ViewTodo|DataTypeString) + 27,
            TodoByweekno             = (ViewTodo|DataTypeString) + 28,
            TodoBymonth              = (ViewTodo|DataTypeString) + 29,
            TodoBysetpos             = (ViewTodo|DataTypeString) + 30,
            TodoWkst                 = (ViewTodo|DataTypeInteger) + 31,
            TodoHasAlarm             = (ViewTodo|DataTypeInteger|PropertyReadOnly) + 32,
            TodoSyncData1            = (ViewTodo|DataTypeString) + 33,
            TodoSyncData2            = (ViewTodo|DataTypeString) + 34,
            TodoSyncData3            = (ViewTodo|DataTypeString) + 35,
            TodoSyncData4            = (ViewTodo|DataTypeString) + 36,
            TodoStart                = (ViewTodo|DataTypeCaltime) + 37,
            TodoDue                  = (ViewTodo|DataTypeCaltime) + 38,
            TodoAlarm                = (ViewTodo|DataTypeRecord) + 39,
            TodoStartTzid            = (ViewTodo|DataTypeString) + 40,
            TodoDueTzid              = (ViewTodo|DataTypeString) + 41,
            TodoOrganizerName        = (ViewTodo|DataTypeString) + 42,
            TodoOrganizerEmail       = (ViewTodo|DataTypeString) + 43,
            TodoHasAttendee          = (ViewTodo|DataTypeInteger|PropertyReadOnly) + 44,
            TodoAttendee             = (ViewTodo|DataTypeRecord) + 45,
            TodoExtended             = (ViewTodo|DataTypeRecord) + 46,
            TodoIsAllday             = (ViewTodo|DataTypeInteger|PropertyReadOnly) + 47,

            /// Timezone
            TimezoneId                          = (ViewTimezone|DataTypeInteger|PropertyReadOnly),
            TimezoneTzOffsetFromGmt             = (ViewTimezone|DataTypeInteger) + 1,
            TimezoneStandardName                = (ViewTimezone|DataTypeString) + 2,
            TimezoneStdStartMonth               = (ViewTimezone|DataTypeInteger) + 3,
            TimezoneStdStartPositionOfWeek      = (ViewTimezone|DataTypeInteger) + 4,
            TimezoneStdStartDay                 = (ViewTimezone|DataTypeInteger) + 5,
            TimezoneStdStartHour                = (ViewTimezone|DataTypeInteger) + 6,
            TimezoneStandardBias                = (ViewTimezone|DataTypeInteger) + 7,
            TimezoneDayLightName                = (ViewTimezone|DataTypeString) + 8,
            TimezoneDayLightStartMonth          = (ViewTimezone|DataTypeInteger) + 9,
            TimezoneDayLightStartPositionOfWeek = (ViewTimezone|DataTypeInteger) + 10,
            TimezoneDayLightStartDay            = (ViewTimezone|DataTypeInteger) + 11,
            TimezoneDayLightStartHour           = (ViewTimezone|DataTypeInteger) + 12,
            TimezoneDayLightBias                = (ViewTimezone|DataTypeInteger) + 13,
            TimezoneCalendarId                  = (ViewTimezone|DataTypeInteger) + 14,

            AttendeeNumber       = (ViewAttendee|DataTypeString),
            AttendeeCutype       = (ViewAttendee|DataTypeInteger) + 1,
            AttendeeCtIndex      = (ViewAttendee|DataTypeInteger) + 2,
            AttendeeUid          = (ViewAttendee|DataTypeString) + 3,
            AttendeeGroup        = (ViewAttendee|DataTypeString) + 4,
            AttendeeEmail        = (ViewAttendee|DataTypeString) + 5,
            AttendeeRole         = (ViewAttendee|DataTypeInteger) + 6,
            AttendeeStatus       = (ViewAttendee|DataTypeInteger) + 7,
            AttendeeRsvp         = (ViewAttendee|DataTypeInteger) + 8,
            AttendeeDelegateeUri = (ViewAttendee|DataTypeString) + 9,
            AttendeeDelegatorUri = (ViewAttendee|DataTypeString) + 10,
            AttendeeName         = (ViewAttendee|DataTypeString) + 11,
            AttendeeMember       = (ViewAttendee|DataTypeString) + 12,
            AttendeeParentId     = (ViewAttendee|DataTypeInteger|PropertyReadOnly) + 13,

            AlarmTick            = (ViewAlarm|DataTypeInteger),
            AlarmTickUnit        = (ViewAlarm|DataTypeInteger) + 1,
            AlarmDescription     = (ViewAlarm|DataTypeString) + 2,
            AlarmParentId        = (ViewAlarm|DataTypeInteger|PropertyReadOnly) + 3,
            AlarmSummary         = (ViewAlarm|DataTypeString) + 4,
            AlarmAction          = (ViewAlarm|DataTypeInteger) + 5,
            AlarmAttach          = (ViewAlarm|DataTypeString) + 6,
            AlarmAlarm           = (ViewAlarm|DataTypeCaltime) + 7,

            InstanceUtimeBookEventId          = (ViewInstanceUtimeBook|DataTypeInteger),
            InstanceUtimeBookStart            = (ViewInstanceUtimeBook|DataTypeCaltime) + 1,
            InstanceUtimeBookEnd              = (ViewInstanceUtimeBook|DataTypeCaltime) + 2,
            InstanceUtimeBookSummary          = (ViewInstanceUtimeBook|DataTypeString) + 3,
            InstanceUtimeBookLocation         = (ViewInstanceUtimeBook|DataTypeString) + 4,
            InstanceUtimeBookBookId           = (ViewInstanceUtimeBook|DataTypeInteger) + 5,
            InstanceUtimeBookDescription      = (ViewInstanceUtimeBook|DataTypeString) + 6,
            InstanceUtimeBookBusyStatus       = (ViewInstanceUtimeBook|DataTypeInteger) + 7,
            InstanceUtimeBookEventStatus      = (ViewInstanceUtimeBook|DataTypeInteger) + 8,
            InstanceUtimeBookPriority         = (ViewInstanceUtimeBook|DataTypeInteger) + 9,
            InstanceUtimeBookSensitivity      = (ViewInstanceUtimeBook|DataTypeInteger) + 10,
            InstanceUtimeBookHasRrule         = (ViewInstanceUtimeBook|DataTypeInteger) + 11,
            InstanceUtimeBookLatitude         = (ViewInstanceUtimeBook|DataTypeDouble) + 12,
            InstanceUtimeBookLongitude        = (ViewInstanceUtimeBook|DataTypeDouble) + 13,
            InstanceUtimeBookHasAlarm         = (ViewInstanceUtimeBook|DataTypeInteger) + 14,
            InstanceUtimeBookOriginalEventId  = (ViewInstanceUtimeBook|DataTypeInteger) + 15,
            InstanceUtimeBookLastModifiedtime = (ViewInstanceUtimeBook|DataTypeLong) + 16,
            InstanceUtimeBookSyncData1        = (ViewInstanceUtimeBook|DataTypeString) + 17,

            InstanceLocaltimeBookEventId          = (ViewInstanceLocaltimeBook|DataTypeInteger),
            InstanceLocaltimeBookStart            = (ViewInstanceLocaltimeBook|DataTypeCaltime) + 1,
            InstanceLocaltimeBookEnd              = (ViewInstanceLocaltimeBook|DataTypeCaltime) + 2,
            InstanceLocaltimeBookSummary          = (ViewInstanceLocaltimeBook|DataTypeString) + 3,
            InstanceLocaltimeBookLocation         = (ViewInstanceLocaltimeBook|DataTypeString) + 4,
            InstanceLocaltimeBookBookId           = (ViewInstanceLocaltimeBook|DataTypeInteger) + 5,
            InstanceLocaltimeBookDescription      = (ViewInstanceLocaltimeBook|DataTypeString) + 6,
            InstanceLocaltimeBookBusyStatus       = (ViewInstanceLocaltimeBook|DataTypeInteger) + 7,
            InstanceLocaltimeBookEventStatus      = (ViewInstanceLocaltimeBook|DataTypeInteger) + 8,
            InstanceLocaltimeBookPriority         = (ViewInstanceLocaltimeBook|DataTypeInteger) + 9,
            InstanceLocaltimeBookSensitivity      = (ViewInstanceLocaltimeBook|DataTypeInteger) + 10,
            InstanceLocaltimeBookHasRrule         = (ViewInstanceLocaltimeBook|DataTypeInteger) + 11,
            InstanceLocaltimeBookLatitude         = (ViewInstanceLocaltimeBook|DataTypeDouble) + 12,
            InstanceLocaltimeBookLongitude        = (ViewInstanceLocaltimeBook|DataTypeDouble) + 13,
            InstanceLocaltimeBookHasAlarm         = (ViewInstanceLocaltimeBook|DataTypeInteger) + 14,
            InstanceLocaltimeBookOriginalEventId  = (ViewInstanceLocaltimeBook|DataTypeInteger) + 15,
            InstanceLocaltimeBookLastModifiedTime = (ViewInstanceLocaltimeBook|DataTypeLong) + 16,
            InstanceLocaltimeBookSyncData1        = (ViewInstanceLocaltimeBook|DataTypeString) + 17,
            InstanceLocaltimeBookIsAllday         = (ViewInstanceLocaltimeBook|DataTypeInteger|PropertyReadOnly) + 18,

            InstanceUtimeBookExtendedEventId          = (ViewInstanceUtimeBookExtended|DataTypeInteger),
            InstanceUtimeBookExtendedStart            = (ViewInstanceUtimeBookExtended|DataTypeCaltime) + 1,
            InstanceUtimeBookExtendedEnd              = (ViewInstanceUtimeBookExtended|DataTypeCaltime) + 2,
            InstanceUtimeBookExtendedSummary          = (ViewInstanceUtimeBookExtended|DataTypeString) + 3,
            InstanceUtimeBookExtendedLocation         = (ViewInstanceUtimeBookExtended|DataTypeString) + 4,
            InstanceUtimeBookExtendedBookId           = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 5,
            InstanceUtimeBookExtendedDescription      = (ViewInstanceUtimeBookExtended|DataTypeString) + 6,
            InstanceUtimeBookExtendedBusyStatus       = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 7,
            InstanceUtimeBookExtendedEventStatus      = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 8,
            InstanceUtimeBookExtendedPriority         = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 9,
            InstanceUtimeBookExtendedSensitivity      = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 10,
            InstanceUtimeBookExtendedHasRrule         = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 11,
            InstanceUtimeBookExtendedLatitude         = (ViewInstanceUtimeBookExtended|DataTypeDouble) + 12,
            InstanceUtimeBookExtendedLongitude        = (ViewInstanceUtimeBookExtended|DataTypeDouble) + 13,
            InstanceUtimeBookExtendedHasAlarm         = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 14,
            InstanceUtimeBookExtendedOriginalEventId  = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 15,
            InstanceUtimeBookExtendedLastModifiedTime = (ViewInstanceUtimeBookExtended|DataTypeLong) + 16,
            InstanceUtimeBookExtendedSyncData1        = (ViewInstanceUtimeBookExtended|DataTypeString) + 17,
            InstanceUtimeBookExtendedOrganizerName    = (ViewInstanceUtimeBookExtended|DataTypeString) + 18,
            InstanceUtimeBookExtendedCategories       = (ViewInstanceUtimeBookExtended|DataTypeString) + 19,
            InstanceUtimeBookExtendedHasAttendee      = (ViewInstanceUtimeBookExtended|DataTypeInteger) + 20,
            InstanceUtimeBookExtendedSyncData2        = (ViewInstanceUtimeBookExtended|DataTypeString) + 21,
            InstanceUtimeBookExtendedSyncData3        = (ViewInstanceUtimeBookExtended|DataTypeString) + 22,
            InstanceUtimeBookExtendedSyncData4        = (ViewInstanceUtimeBookExtended|DataTypeString) + 23,

            InstanceLocaltimeBookExtendedEventId          = (ViewInstanceLocaltimeBookExtended|DataTypeInteger),
            InstanceLocaltimeBookExtendedStart            = (ViewInstanceLocaltimeBookExtended|DataTypeCaltime) + 1,
            InstanceLocaltimeBookExtendedEnd              = (ViewInstanceLocaltimeBookExtended|DataTypeCaltime) + 2,
            InstanceLocaltimeBookExtendedSummary          = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 3,
            InstanceLocaltimeBookExtendedLocation         = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 4,
            InstanceLocaltimeBookExtendedBookId           = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 5,
            InstanceLocaltimeBookExtendedDescription      = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 6,
            InstanceLocaltimeBookExtendedBusyStatus       = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 7,
            InstanceLocaltimeBookExtendedEventStatus      = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 8,
            InstanceLocaltimeBookExtendedPriority         = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 9,
            InstanceLocaltimeBookExtendedSensitivity      = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 10,
            InstanceLocaltimeBookExtendedHasRrule         = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 11,
            InstanceLocaltimeBookExtendedLatitude         = (ViewInstanceLocaltimeBookExtended|DataTypeDouble) + 12,
            InstanceLocaltimeBookExtendedLongitude        = (ViewInstanceLocaltimeBookExtended|DataTypeDouble) + 13,
            InstanceLocaltimeBookExtendedHasAlarm         = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 14,
            InstanceLocaltimeBookExtendedOriginalEventId  = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 15,
            InstanceLocaltimeBookExtendedLastModifiedTime = (ViewInstanceLocaltimeBookExtended|DataTypeLong) + 16,
            InstanceLocaltimeBookExtendedSyncData1        = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 17,
            InstanceLocaltimeBookExtendedOrganizerName    = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 18,
            InstanceLocaltimeBookExtendedCategories       = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 19,
            InstanceLocaltimeBookExtendedHasAttendee      = (ViewInstanceLocaltimeBookExtended|DataTypeInteger) + 20,
            InstanceLocaltimeBookExtendedSyncData2        = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 21,
            InstanceLocaltimeBookExtendedSyncData3        = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 22,
            InstanceLocaltimeBookExtendedSyncData4        = (ViewInstanceLocaltimeBookExtended|DataTypeString) + 23,
            InstanceLocaltimeBookExtendedIsAllday         = (ViewInstanceLocaltimeBookExtended|DataTypeInteger|PropertyReadOnly) + 24,

            UpdateInfoId         = (ViewUpdateInfo|DataTypeInteger),
            UpdateInfoCalendarId = (ViewUpdateInfo|DataTypeInteger) + 1,
            UpdateInfoType       = (ViewUpdateInfo|DataTypeInteger) + 2,
            UpdateInfoVersion    = (ViewUpdateInfo|DataTypeInteger) + 3,

            ExtendedId           = (ViewExtended|DataTypeInteger|PropertyReadOnly),
            ExtendedRecordId     = (ViewExtended|DataTypeInteger) + 1,
            ExtendedRecordType   = (ViewExtended|DataTypeInteger) + 2,
            ExtendedKey          = (ViewExtended|DataTypeString) + 3,
            ExtendedValue        = (ViewExtended|DataTypeString) + 4,
        }

        ///average size
        internal const uint AverageSizeOfRecord = 56;

        public static class Book
        {
            /// <summary>
            /// Identifier of this calendar book view
            /// </summary>
            public const string Uri = "tizen.calendar_view.book";
            /// <summary>
            /// DB record ID of the calendar book
            /// </summary>
            public const uint Id          = (uint)PropertyIds.BookId;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid         = (uint)PropertyIds.BookUid;
            /// <summary>
            /// Calendar book name
            /// </summary>
            public const uint Name        = (uint)PropertyIds.BookName;
            /// <summary>
            /// Calendar book description
            /// </summary>
            public const uint Description = (uint)PropertyIds.BookDescription;
            /// <summary>
            /// Calendar book color for UX
            /// </summary>
            public const uint Color       = (uint)PropertyIds.BookColor;
            /// <summary>
            /// Location of the event
            /// </summary>
            public const uint Location    = (uint)PropertyIds.BookLocation;
            /// <summary>
            /// Visibility of the calendar book for UX
            /// </summary>
            public const uint Visibility  = (uint)PropertyIds.BookVisibility;
            /// <summary>
            /// Currently NOT Used
            /// </summary>
            public const uint SyncEvent   = (uint)PropertyIds.BookSyncEvent;
            /// <summary>
            /// Account for this calendar
            /// </summary>
            public const uint AccountId   = (uint)PropertyIds.BookAccountId;
            /// <summary>
            /// Type of calendar contents(refer to the CalendarTypes.StoreType)
            /// </summary>
            public const uint StoreType   = (uint)PropertyIds.BookStoreType;
            /// <summary>
            /// Generic data for use by syncing
            /// </summary>
            public const uint SyncData1   = (uint)PropertyIds.BookSyncData1;
            /// <summary>
            /// Generic data for use by syncing
            /// </summary>
            public const uint SyncData2   = (uint)PropertyIds.BookSyncData2;
            /// <summary>
            /// Generic data for use by syncing
            /// </summary>
            public const uint SyncData3   = (uint)PropertyIds.BookSyncData3;
            /// <summary>
            /// Generic data for use by syncing
            /// </summary>
            public const uint SyncData4   = (uint)PropertyIds.BookSyncData4;
            /// <summary>
            /// Calendar book mode(refer to the CalendarTypes.BookMode)
            /// </summary>
            public const uint Mode        = (uint)PropertyIds.BookMode;
        }

        public static class Event
        {
            /// <summary>
            /// Identifier of this event view
            /// </summary>
            public const string Uri = "tizen.calendar_view.event";
            /// <summary>
            /// DB record ID of the event
            /// </summary>
            public const uint Id                 = (uint)PropertyIds.EventId;
            /// <summary>
            /// ID of the calendar book to which the event belongs
            /// </summary>
            public const uint BookId             = (uint)PropertyIds.EventBookId;
            /// <summary>
            /// The short description of the event
            /// </summary>
            public const uint Summary            = (uint)PropertyIds.EventSummary;
            /// <summary>
            /// The description of the event
            /// </summary>
            public const uint Description        = (uint)PropertyIds.EventDescription;
            /// <summary>
            /// The location of the event
            /// </summary>
            public const uint Location           = (uint)PropertyIds.EventLocation;
            /// <summary>
            /// The category of the event. For example APPOINTMENT, BIRTHDAY
            /// </summary>
            public const uint Categories         = (uint)PropertyIds.EventCategories;
            /// <summary>
            /// The exception list of the event. If this event has a recurrence rule, the instance of the exdate is removed. Format is "YYYYMMDD"(allday event) or "YYYYMMDDTHHMMSS". Multiple exceptions can be included with a comma
            /// </summary>
            public const uint Exdate             = (uint)PropertyIds.EventExdate;
            /// <summary>
            /// The status of event(refer to the CalendarTypes.EventStatus).
            /// </summary>
            public const uint EventStatus        = (uint)PropertyIds.EventEventStatus;
            /// <summary>
            /// The priority of event(refer to the CalendarTypes.Priority).
            /// </summary>
            public const uint Priority           = (uint)PropertyIds.EventPriority;
            /// <summary>
            /// The timezone_id of the event if it exists.
            /// </summary>
            public const uint Timezone           = (uint)PropertyIds.EventTimezone;
            /// <summary>
            /// The person_id of the event if the event is a birthday. Refer to the contacts-service
            /// </summary>
            public const uint ContactId          = (uint)PropertyIds.EventContactId;
            /// <summary>
            /// The busy status of event(refer to the CalendarTypes.BusyStatus).
            /// </summary>
            public const uint BusyStatus         = (uint)PropertyIds.EventBusyStatus;
            /// <summary>
            /// The Sensitivity of event(refer to the CalendarTypes.Sensitivity).
            /// </summary>
            public const uint Sensitivity        = (uint)PropertyIds.EventSensitivity;
            /// <summary>
            /// The unique ID of the event
            /// </summary>
            public const uint Uid                = (uint)PropertyIds.EventUid;
            /// <summary>
            /// The name of organizer of the event
            /// </summary>
            public const uint OrganizerName      = (uint)PropertyIds.EventOrganizerName;
            /// <summary>
            /// The email address of the organizer of the event
            /// </summary>
            public const uint OrganizerEmail     = (uint)PropertyIds.EventOrganizerEmail;
            /// <summary>
            /// The meeting status of event(refer to the CalendarTypes.MeetingStatus).
            /// </summary>
            public const uint MeetingStatus      = (uint)PropertyIds.EventMeetingStatus;
            /// <summary>
            /// The ID of the original event if the event is an exception.
            /// </summary>
            public const uint OriginalEventId    = (uint)PropertyIds.EventOriginalEventId;
            /// <summary>
            /// The latitude of the location of the event
            /// </summary>
            public const uint Latitude           = (uint)PropertyIds.EventLatitude;
            /// <summary>
            /// The longitude of the location of the event
            /// </summary>
            public const uint Longitude          = (uint)PropertyIds.EventLongitude;
            /// <summary>
            /// ID of the email_id. Refer to the email-service.
            /// </summary>
            public const uint EmailId            = (uint)PropertyIds.EventEmailId;
            /// <summary>
            /// The time when the event is created
            /// </summary>
            public const uint CreatedTime        = (uint)PropertyIds.EventCreatedTime;
            /// <summary>
            /// The time when the event is updated
            /// </summary>
            public const uint LastModifiedTime   = (uint)PropertyIds.EventLastModifiedTime;
            /// <summary>
            ///  Whether or not the event is deleted
            /// </summary>
            public const uint IsDeleted          = (uint)PropertyIds.EventIsDeleted;
            /// <summary>
            /// The frequent type of event recurrence(refer to the CalendarTypes.Recurrence).
            /// </summary>
            public const uint Freq               = (uint)PropertyIds.EventFreq;
            /// <summary>
            /// The range type of event recurrence(refer to the CalendarTypes.RangeType).
            /// </summary>
            public const uint RangeType          = (uint)PropertyIds.EventRangeType;
            /// <summary>
            /// The end time of the event recurrence. Only if this is used with RangeType.Until.
            /// </summary>
            public const uint Until              = (uint)PropertyIds.EventUntil;
            /// <summary>
            /// The count of the event recurrence. Only if this is used with RangeType.Count.
            /// </summary>
            public const uint Count              = (uint)PropertyIds.EventCount;
            /// <summary>
            /// The interval of the event recurrence
            /// </summary>
            public const uint Interval           = (uint)PropertyIds.EventInterval;
            /// <summary>
            /// The second list of the event recurrence. The value can be from 0 to 59. The list is separated by comma
            /// </summary>
            public const uint Bysecond           = (uint)PropertyIds.EventBysecond;
            /// <summary>
            /// The minute list of the event recurrence. The value can be from 0 to 59. The list is separated by commas
            /// </summary>
            public const uint Byminute           = (uint)PropertyIds.EventByminute;
            /// <summary>
            /// The hour list of the event recurrence. The value can be from 0 to 23. The list is separated by commas
            /// </summary>
            public const uint Byhour             = (uint)PropertyIds.EventByhour;
            /// <summary>
            /// The day list of the event recurrence. The value can be SU, MO, TU, WE, TH, FR, SA. The list is separated by commas.
            /// </summary>
            public const uint Byday              = (uint)PropertyIds.EventByday;
            /// <summary>
            /// The month day list of the event recurrence. The value can be from 1 to 31 and from -31 to -1. The list is separated by commas.
            /// </summary>
            public const uint Bymonthday         = (uint)PropertyIds.EventBymonthday;
            /// <summary>
            /// The year day list of the event recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas
            /// </summary>
            public const uint Byyearday          = (uint)PropertyIds.EventByyearday;
            /// <summary>
            /// The week number list of the event recurrence. The value can be from 1 to 53 and from -53 to -1. The list is separated by commas
            /// </summary>
            public const uint Byweekno           = (uint)PropertyIds.EventByweekno;
            /// <summary>
            /// The month list of the event recurrence. The value can be from 1 to 12. The list is separated by commas
            /// </summary>
            public const uint Bymonth            = (uint)PropertyIds.EventBymonth;
            /// <summary>
            /// The position list of the event recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas
            /// </summary>
            public const uint Bysetpos           = (uint)PropertyIds.EventBysetpos;
            /// <summary>
            /// The start day of the week(refer to the CalendarTypes.WeekDay).
            /// </summary>
            public const uint Wkst               = (uint)PropertyIds.EventWkst;
            /// <summary>
            /// RECURRENCE-ID of RFC #2445
            /// </summary>
            public const uint RecurrenceId       = (uint)PropertyIds.EventRecurrenceId;
            /// <summary>
            /// RDATE of RFC #2445
            /// </summary>
            public const uint Rdate              = (uint)PropertyIds.EventRdate;
            /// <summary>
            /// Whether or not the event has an attendee list
            /// </summary>
            public const uint HasAttendee        = (uint)PropertyIds.EventHasAttendee;
            /// <summary>
            /// Whether or not the event has an alarm list
            /// </summary>
            public const uint HasAlarm           = (uint)PropertyIds.EventHasAlarm;
            /// <summary>
            /// The sync data of the event. If developer need to save some information related to the event, they can use this property
            /// </summary>
            public const uint SyncData1          = (uint)PropertyIds.EventSyncData1;
            /// <summary>
            /// The sync data of the event. If developer need to save some information related to the event, they can use this property
            /// </summary>
            public const uint SyncData2          = (uint)PropertyIds.EventSyncData2;
            /// <summary>
            /// The sync data of the event. If developer need to save some information related to the event, they can use this property
            /// </summary>
            public const uint SyncData3          = (uint)PropertyIds.EventSyncData3;
            /// <summary>
            /// The sync data of the event. If developer need to save some information related to the event, they can use this property
            /// </summary>
            public const uint SyncData4          = (uint)PropertyIds.EventSyncData4;
            /// <summary>
            /// The start time of the event
            /// </summary>
            public const uint Start              = (uint)PropertyIds.EventStart;
            /// <summary>
            /// The end time of the event
            /// </summary>
            public const uint End                = (uint)PropertyIds.EventEnd;
            /// <summary>
            /// The alarm list of the event.
            /// </summary>
            public const uint Alarm              = (uint)PropertyIds.EventAlarm;
            /// <summary>
            /// The attendee list of the event.
            /// </summary>
            public const uint Attendee           = (uint)PropertyIds.EventAttendee;
            /// <summary>
            /// The Calendar system type(refer to the CalendarTypes.SystemType).
            /// </summary>
            public const uint CalendarSystemType = (uint)PropertyIds.EventCalendarSystemType;
            /// <summary>
            /// The timezone of the start_time
            /// </summary>
            public const uint StartTzid          = (uint)PropertyIds.EventStartTzid;
            /// <summary>
            /// The timezone of the end_time
            /// </summary>
            public const uint EndTzid            = (uint)PropertyIds.EventEndTzid;
            /// <summary>
            /// The exception mod event list of the event
            /// </summary>
            public const uint Exception          = (uint)PropertyIds.EventException;
            /// <summary>
            /// The extended property list of the event.
            /// </summary>
            public const uint Extended           = (uint)PropertyIds.EventExtended;
            /// <summary>
            /// The event is an allday event or not
            /// </summary>
            public const uint IsAllday           = (uint)PropertyIds.EventIsAllday;
            /// <summary>
            /// The linked event count
            /// </summary>
            public const uint LinkCount          = (uint)PropertyIds.EventLinkCount;
            /// <summary>
            /// The event is an base linked event
            /// </summary>
            public const uint LinkBaseId         = (uint)PropertyIds.EventLinkBaseId;
        }

        public static class Todo
        {
            /// <summary>
            /// Identifier of this todo view
            /// </summary>
            public const string Uri = "tizen.calendar_view.todo";
            /// <summary>
            /// DB record ID of the todo
            /// </summary>
            public const uint Id                = (uint)PropertyIds.TodoId;
            /// <summary>
            /// ID of the calendar book to which the todo belongs
            /// </summary>
            public const uint BookId            = (uint)PropertyIds.TodoBookId;
            /// <summary>
            /// The short description of the todo
            /// </summary>
            public const uint Summary           = (uint)PropertyIds.TodoSummary;
            /// <summary>
            /// The description of the todo
            /// </summary>
            public const uint Description       = (uint)PropertyIds.TodoDescription;
            /// <summary>
            /// The location of the todo
            /// </summary>
            public const uint Location          = (uint)PropertyIds.TodoLocation;
            /// <summary>
            /// The category of the todo. i.g. APPOINTMENT, BIRTHDAY
            /// </summary>
            public const uint Categories        = (uint)PropertyIds.TodoCategories;
            /// <summary>
            /// The status of todo(refer to the CalendarTypes.TodoStatus).
            /// </summary>
            public const uint TodoStatus        = (uint)PropertyIds.TodoStatus;
            /// <summary>
            /// The Priority of todo(refer to the CalendarTypes.Priority).
            /// </summary>
            public const uint Priority          = (uint)PropertyIds.TodoPriority;
            /// <summary>
            /// The Sensitivity of todo(refer to the CalendarTypes.Sensitivity).
            /// </summary>
            public const uint Sensitivity       = (uint)PropertyIds.TodoSensitivity;
            /// <summary>
            /// The unique ID of the todo
            /// </summary>
            public const uint Uid               = (uint)PropertyIds.TodoUid;
            /// <summary>
            /// The latitude of the location of the todo
            /// </summary>
            public const uint Latitude          = (uint)PropertyIds.TodoLatitude;
            /// <summary>
            /// The longitude of the location of the todo
            /// </summary>
            public const uint Longitude         = (uint)PropertyIds.TodoLongitude;
            /// <summary>
            /// The progression of the todo. The value can be from 0 to 100
            /// </summary>
            public const uint Progress          = (uint)PropertyIds.TodoProgress;
            /// <summary>
            /// The time when the todo is create
            /// </summary>
            public const uint CreatedTime       = (uint)PropertyIds.TodoCreatedTime;
            /// <summary>
            /// The time when the todo is updated
            /// </summary>
            public const uint LastModifiedTime  = (uint)PropertyIds.TodoLastModifiedTime;
            /// <summary>
            /// The time when the todo is completed
            /// </summary>
            public const uint CompletedTime     = (uint)PropertyIds.TodoCompletedTime;
            /// <summary>
            ///  Whether or not the todo is deleted
            /// </summary>
            public const uint IsDeleted         = (uint)PropertyIds.TodoIsDeleted;
            /// <summary>
            /// The frequent type of todo recurrence(refer to the CalendarTypes.Recurrence).
            /// </summary>
            public const uint Freq              = (uint)PropertyIds.TodoFreq;
            /// <summary>
            /// The range type of todo recurrence(refer to the CalendarTypes.RangeType).
            /// </summary>
            public const uint RangeType         = (uint)PropertyIds.TodoRangeType;
            /// <summary>
            /// The end time of the todo recurrence. Only if this is used with RangeType.Until.
            /// </summary>
            public const uint Until             = (uint)PropertyIds.TodoUntil;
            /// <summary>
            /// The count of the todo recurrence. Only if this is used with RangeType.Count.
            /// </summary>
            public const uint Count             = (uint)PropertyIds.TodoCount;
            /// <summary>
            /// The interval of the todo recurrence
            /// </summary>
            public const uint Integererval      = (uint)PropertyIds.TodoIntegererval;
            /// <summary>
            /// The second list of the todo recurrence. The value can be from 0 to 59. The list is separated by commas
            /// </summary>
            public const uint Bysecond          = (uint)PropertyIds.TodoBysecond;
            /// <summary>
            /// The minute list of the todo recurrence. The value can be from 0 to 59. The list is separated by commas
            /// </summary>
            public const uint Byminute          = (uint)PropertyIds.TodoByminute;
            /// <summary>
            /// The hour list of the todo recurrence. The value can be from 0 to 23. The list is separated by commas
            /// </summary>
            public const uint Byhour            = (uint)PropertyIds.TodoByhour;
            /// <summary>
            /// The day list of the todo recurrence. The value can be SU, MO, TU, WE, TH, FR, SA. The list is separated by commas
            /// </summary>
            public const uint Byday             = (uint)PropertyIds.TodoByday;
            /// <summary>
            /// The month day list of the todo recurrence. The value can be from 1 to 31 and from -31 to -1. The list is separated by commas
            /// </summary>
            public const uint Bymonthday        = (uint)PropertyIds.TodoBymonthday;
            /// <summary>
            /// The year day list of the todo recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas
            /// </summary>
            public const uint Byyearday         = (uint)PropertyIds.TodoByyearday;
            /// <summary>
            /// The week number list of the todo recurrence. The value can be from 1 to 53 and from -53 to -1. The list is separated by commas
            /// </summary>
            public const uint Byweekno          = (uint)PropertyIds.TodoByweekno;
            /// <summary>
            /// The month list of the todo recurrence. The value can be from 1 to 12. The list is separated by commas
            /// </summary>
            public const uint Bymonth           = (uint)PropertyIds.TodoBymonth;
            /// <summary>
            /// The position list of the todo recurrence. The value can be from 1 to 366 and from -366 to -1. The list is separated by commas
            /// </summary>
            public const uint Bysetpos          = (uint)PropertyIds.TodoBysetpos;
            /// <summary>
            /// The start day of the week(refer to the CalendarTypes.WeekDay).
            /// </summary>
            public const uint Wkst              = (uint)PropertyIds.TodoWkst;
            /// <summary>
            /// Whether or not the todo has an alarm list
            /// </summary>
            public const uint HasAlarm          = (uint)PropertyIds.TodoHasAlarm;
            /// <summary>
            /// The sync data of the todo. If developers need to save some information related to the todo, they can use this property
            /// </summary>
            public const uint SyncData1         = (uint)PropertyIds.TodoSyncData1;
            /// <summary>
            /// The sync data of the todo. If developers need to save some information related to the todo, they can use this property
            /// </summary>
            public const uint SyncData2         = (uint)PropertyIds.TodoSyncData2;
            /// <summary>
            /// The sync data of the todo. If developers need to save some information related to the todo, they can use this property
            /// </summary>
            public const uint SyncData3         = (uint)PropertyIds.TodoSyncData3;
            /// <summary>
            /// The sync data of the todo. If developers need to save some information related to the todo, they can use this property
            /// </summary>
            public const uint SyncData4         = (uint)PropertyIds.TodoSyncData4;
            /// <summary>
            /// The start time of the todo
            /// </summary>
            public const uint Start             = (uint)PropertyIds.TodoStart;
            /// <summary>
            /// The due time of the todo
            /// </summary>
            public const uint Due               = (uint)PropertyIds.TodoDue;
            /// <summary>
            /// The alarm list of the todo.
            /// </summary>
            public const uint Alarm             = (uint)PropertyIds.TodoAlarm;
            /// <summary>
            /// The timezone of the start_time
            /// </summary>
            public const uint StartTzid         = (uint)PropertyIds.TodoStartTzid;
            /// <summary>
            /// The timezone of the due_time
            /// </summary>
            public const uint DueTzid           = (uint)PropertyIds.TodoDueTzid;
            /// <summary>
            /// The name of the organizer of the event
            /// </summary>
            public const uint OrganizerName     = (uint)PropertyIds.TodoOrganizerName;
            /// <summary>
            /// The email address of the organizer of the todo
            /// </summary>
            public const uint OrganizerEmail    = (uint)PropertyIds.TodoOrganizerEmail;
            /// <summary>
            /// Whether or not the todo has an attendee list
            /// </summary>
            public const uint HasAttendee       = (uint)PropertyIds.TodoHasAttendee;
            /// <summary>
            /// The attendee list of the todo.
            /// </summary>
            public const uint Attendee          = (uint)PropertyIds.TodoAttendee;
            /// <summary>
            /// The extended property list of the todo.
            /// </summary>
            public const uint Extended          = (uint)PropertyIds.TodoExtended;
            /// <summary>
            /// The todo is an allday event or not
            /// </summary>
            public const uint IsAllday          = (uint)PropertyIds.TodoIsAllday;
        }

        public static class Timezone
        {
            /// <summary>
            /// Identifier of this timezone view
            /// </summary>
            public const string Uri = "tizen.calendar_view.timezone";
            /// <summary>
            /// DB record ID of the timezone
            /// </summary>
            public const uint Id                          = (uint)PropertyIds.TimezoneId;
            /// <summary>
            /// UTC offset which is in use when the onset of this time zone observance begins. Valid values are -720(-12:00) to 840(+14:00)
            /// </summary>
            public const uint TzOffsetFromGmt             = (uint)PropertyIds.TimezoneTzOffsetFromGmt;
            /// <summary>
            /// Name of the Standard Time
            /// </summary>
            public const uint StandardName                = (uint)PropertyIds.TimezoneStandardName;
            /// <summary>
            /// Starting month of the Standard Time. Month is 0-based. eg, 0 for January
            /// </summary>
            public const uint StdStartMonth               = (uint)PropertyIds.TimezoneStdStartMonth;
            /// <summary>
            /// Starting day-of-week-in-month of the Standard Time. Day is 1-based
            /// </summary>
            public const uint StdStartPositionOfWeek      = (uint)PropertyIds.TimezoneStdStartPositionOfWeek;
            /// <summary>
            /// Starting day-of-week of the Standard Time. Valid values are 1(SUNDAY) to 7(SATURDAY)
            /// </summary>
            public const uint StdStartDay                 = (uint)PropertyIds.TimezoneStdStartDay;
            /// <summary>
            /// Starting hour of the Standard Time. Valid values are 0 to 23
            /// </summary>
            public const uint StdStartHour                = (uint)PropertyIds.TimezoneStdStartHour;
            /// <summary>
            /// The number of minutes added during the Standard Time
            /// </summary>
            public const uint StandardBias                = (uint)PropertyIds.TimezoneStandardBias;
            /// <summary>
            /// Name of Daylight
            /// </summary>
            public const uint DayLightName                = (uint)PropertyIds.TimezoneDayLightName;
            /// <summary>
            /// Starting month of Daylight. Month is 0-based. eg, 0 for January
            /// </summary>
            public const uint DayLightStartMonth          = (uint)PropertyIds.TimezoneDayLightStartMonth;
            /// <summary>
            /// Starting day-of-week-in-month of Daylight. Day is 1-based
            /// </summary>
            public const uint DayLightStartPositionOfWeek = (uint)PropertyIds.TimezoneDayLightStartPositionOfWeek;
            /// <summary>
            /// Starting day-of-week of Daylight. Valid values are 1(SUNDAY) to 7(SATURDAY)
            /// </summary>
            public const uint DayLightStartDay            = (uint)PropertyIds.TimezoneDayLightStartDay;
            /// <summary>
            /// Starting hour of Daylight. Valid values are 0 to 23
            /// </summary>
            public const uint DayLightStartHour           = (uint)PropertyIds.TimezoneDayLightStartHour;
            /// <summary>
            /// The number of minutes added during Daylight Time
            /// </summary>
            public const uint DayLightBias                = (uint)PropertyIds.TimezoneDayLightBias;
            /// <summary>
            /// DB record ID of a related calendar book
            /// </summary>
            public const uint CalendarId                  = (uint)PropertyIds.TimezoneCalendarId;
        }

        public static class Attendee
        {
            /// <summary>
            /// Identifier of this calendar attendee view
            /// </summary>
            public const string Uri = "tizen.calendar_view.attendee";
            /// <summary>
            /// The number of the attendee
            /// </summary>
            public const uint Number       = (uint)PropertyIds.AttendeeNumber;
            /// <summary>
            /// The type of attendee(refer to the CalendarTypes.Cutype).
            /// </summary>
            public const uint Cutype       = (uint)PropertyIds.AttendeeCutype;
            /// <summary>
            ///
            /// </summary>
            public const uint CtIndex      = (uint)PropertyIds.AttendeeCtIndex;
            /// <summary>
            /// Unique identifier
            /// </summary>
            public const uint Uid          = (uint)PropertyIds.AttendeeUid;
            /// <summary>
            ///
            /// </summary>
            public const uint Group        = (uint)PropertyIds.AttendeeGroup;
            /// <summary>
            /// The email address of the attendee
            /// </summary>
            public const uint Email        = (uint)PropertyIds.AttendeeEmail;
            /// <summary>
            /// Attendee role(refer to the CalendarTypes.AttendeeRole).
            /// </summary>
            public const uint Role         = (uint)PropertyIds.AttendeeRole;
            /// <summary>
            /// Attendee status(refer to the CalendarTypes.AttendeeStatus).
            /// </summary>
            public const uint Status       = (uint)PropertyIds.AttendeeStatus;
            /// <summary>
            /// RSVP invitation reply (one of true, false)
            /// </summary>
            public const uint Rsvp         = (uint)PropertyIds.AttendeeRsvp;
            /// <summary>
            /// Delegatee (DELEGATED-TO)
            /// </summary>
            public const uint DelegateeUri = (uint)PropertyIds.AttendeeDelegateeUri;
            /// <summary>
            /// Delegator (DELEGATED-FROM)
            /// </summary>
            public const uint DelegatorUri = (uint)PropertyIds.AttendeeDelegatorUri;
            /// <summary>
            /// Attendee name
            /// </summary>
            public const uint Name         = (uint)PropertyIds.AttendeeName;
            /// <summary>
            /// Group that the attendee belongs to
            /// </summary>
            public const uint Member       = (uint)PropertyIds.AttendeeMember;
            /// <summary>
            /// Event/TODO that the attendee belongs to
            /// </summary>
            public const uint ParentId     = (uint)PropertyIds.AttendeeParentId;
        }

        public static class Alarm
        {
            /// <summary>
            /// Identifier of this calendar alarm view
            /// </summary>
            public const string Uri = "tizen.calendar_view.alarm";
            /// <summary>
            /// The number of unit before start time. This MUST be used with one of TickUnit.
            /// </summary>
            public const uint Tick        = (uint)PropertyIds.AlarmTick;
            /// <summary>
            /// Reminder tick time unit(refer to the CalendarTypes.TickUnit).
            /// </summary>
            public const uint TickUnit    = (uint)PropertyIds.AlarmTickUnit;
            /// <summary>
            /// Alarm description
            /// </summary>
            public const uint Description = (uint)PropertyIds.AlarmDescription;
            /// <summary>
            /// Event that the alarm belongs to
            /// </summary>
            public const uint ParentId    = (uint)PropertyIds.AlarmParentId;
            /// <summary>
            /// Alarm summary
            /// </summary>
            public const uint Summary     = (uint)PropertyIds.AlarmSummary;
            /// <summary>
            /// Action of alarm(refer to the CalendarTypes.Action).
            /// </summary>
            public const uint Action      = (uint)PropertyIds.AlarmAction;
            /// <summary>
            /// Alarm tone path
            /// </summary>
            public const uint Attach      = (uint)PropertyIds.AlarmAttach;
            /// <summary>
            /// The alarm time
            /// </summary>
            public const uint AlarmTime   = (uint)PropertyIds.AlarmAlarm;
        }

        public static class InstanceUtimeBook
        {
            /// <summary>
            /// Identifier of this instance utime book
            /// </summary>
            public const string Uri = "tizen.calendar_view.instance_utime/book";
            /// <summary>
            /// Event id
            /// </summary>
            public const uint EventId          = (uint)PropertyIds.InstanceUtimeBookEventId;
            /// <summary>
            /// Start time
            /// </summary>
            public const uint Start            = (uint)PropertyIds.InstanceUtimeBookStart;
            /// <summary>
            /// End time
            /// </summary>
            public const uint End              = (uint)PropertyIds.InstanceUtimeBookEnd;
            /// <summary>
            /// Summary
            /// </summary>
            public const uint Summary          = (uint)PropertyIds.InstanceUtimeBookSummary;
            /// <summary>
            /// Location
            /// </summary>
            public const uint Location         = (uint)PropertyIds.InstanceUtimeBookLocation;
            /// <summary>
            /// Book id
            /// </summary>
            public const uint BookId           = (uint)PropertyIds.InstanceUtimeBookBookId;
            /// <summary>
            /// Description
            /// </summary>
            public const uint Description      = (uint)PropertyIds.InstanceUtimeBookDescription;
            /// <summary>
            /// BusyStatus
            /// </summary>
            public const uint BusyStatus       = (uint)PropertyIds.InstanceUtimeBookBusyStatus;
            /// <summary>
            /// EventStatus
            /// </summary>
            public const uint EventStatus      = (uint)PropertyIds.InstanceUtimeBookEventStatus;
            /// <summary>
            /// Priority
            /// </summary>
            public const uint Priority         = (uint)PropertyIds.InstanceUtimeBookPriority;
            /// <summary>
            /// Sensitivity
            /// </summary>
            public const uint Sensitivity      = (uint)PropertyIds.InstanceUtimeBookSensitivity;
            /// <summary>
            /// HasRrule
            /// </summary>
            public const uint HasRrule         = (uint)PropertyIds.InstanceUtimeBookHasRrule;
            /// <summary>
            /// Latitude
            /// </summary>
            public const uint Latitude         = (uint)PropertyIds.InstanceUtimeBookLatitude;
            /// <summary>
            /// Longitude
            /// </summary>
            public const uint Longitude        = (uint)PropertyIds.InstanceUtimeBookLongitude;
            /// <summary>
            /// HasAlarm
            /// </summary>
            public const uint HasAlarm         = (uint)PropertyIds.InstanceUtimeBookHasAlarm;
            /// <summary>
            /// OriginalEventId
            /// </summary>
            public const uint OriginalEventId  = (uint)PropertyIds.InstanceUtimeBookOriginalEventId;
            /// <summary>
            /// LastModifiedtime
            /// </summary>
            public const uint LastModifiedtime = (uint)PropertyIds.InstanceUtimeBookLastModifiedtime;
            /// <summary>
            /// SyncData1
            /// </summary>
            public const uint SyncData1        = (uint)PropertyIds.InstanceUtimeBookSyncData1;
        }

        public static class InstanceLocaltimeBook
        {
            /// <summary>
            /// Uri
            /// </summary>
            public const string Uri = "tizen.calendar_view.instance_localtime/book";
            /// <summary>
            /// EventId
            /// </summary>
            public const uint EventId          = (uint)PropertyIds.InstanceLocaltimeBookEventId;
            /// <summary>
            /// Start
            /// </summary>
            public const uint Start            = (uint)PropertyIds.InstanceLocaltimeBookStart;
            /// <summary>
            /// End
            /// </summary>
            public const uint End              = (uint)PropertyIds.InstanceLocaltimeBookEnd;
            /// <summary>
            /// Summary
            /// </summary>
            public const uint Summary          = (uint)PropertyIds.InstanceLocaltimeBookSummary;
            /// <summary>
            /// Location
            /// </summary>
            public const uint Location         = (uint)PropertyIds.InstanceLocaltimeBookLocation;
            /// <summary>
            /// BookId
            /// </summary>
            public const uint BookId           = (uint)PropertyIds.InstanceLocaltimeBookBookId;
            /// <summary>
            /// Description
            /// </summary>
            public const uint Description      = (uint)PropertyIds.InstanceLocaltimeBookDescription;
            /// <summary>
            /// BusyStatus
            /// </summary>
            public const uint BusyStatus       = (uint)PropertyIds.InstanceLocaltimeBookBusyStatus;
            /// <summary>
            /// EventStatus
            /// </summary>
            public const uint EventStatus      = (uint)PropertyIds.InstanceLocaltimeBookEventStatus;
            /// <summary>
            /// Priority
            /// </summary>
            public const uint Priority         = (uint)PropertyIds.InstanceLocaltimeBookPriority;
            /// <summary>
            /// Sensitivity
            /// </summary>
            public const uint Sensitivity      = (uint)PropertyIds.InstanceLocaltimeBookSensitivity;
            /// <summary>
            /// HasRrule
            /// </summary>
            public const uint HasRrule         = (uint)PropertyIds.InstanceLocaltimeBookHasRrule;
            /// <summary>
            /// Latitude
            /// </summary>
            public const uint Latitude         = (uint)PropertyIds.InstanceLocaltimeBookLatitude;
            /// <summary>
            /// Longitude
            /// </summary>
            public const uint Longitude        = (uint)PropertyIds.InstanceLocaltimeBookLongitude;
            /// <summary>
            /// HasAlarm
            /// </summary>
            public const uint HasAlarm         = (uint)PropertyIds.InstanceLocaltimeBookHasAlarm;
            /// <summary>
            /// OriginalEventId
            /// </summary>
            public const uint OriginalEventId  = (uint)PropertyIds.InstanceLocaltimeBookOriginalEventId;
            /// <summary>
            /// LastModifiedTime
            /// </summary>
            public const uint LastModifiedTime = (uint)PropertyIds.InstanceLocaltimeBookLastModifiedTime;
            /// <summary>
            /// SyncData1
            /// </summary>
            public const uint SyncData1        = (uint)PropertyIds.InstanceLocaltimeBookSyncData1;
            /// <summary>
            /// IsAllday
            /// </summary>
            public const uint IsAllday         = (uint)PropertyIds.InstanceLocaltimeBookIsAllday;
        }

        public static class InstanceUtimeBookExtended
        {
            /// <summary>
            /// Uri
            /// </summary>
            public const string Uri = "tizen.calendar_view.extended/instance_utime/book";
            /// <summary>
            /// EventId
            /// </summary>
            public const uint EventId           = (uint)PropertyIds.InstanceUtimeBookExtendedEventId;
            /// <summary>
            /// Start
            /// </summary>
            public const uint Start             = (uint)PropertyIds.InstanceUtimeBookExtendedStart;
            /// <summary>
            /// End
            /// </summary>
            public const uint End               = (uint)PropertyIds.InstanceUtimeBookExtendedEnd;
            /// <summary>
            /// Summary
            /// </summary>
            public const uint Summary           = (uint)PropertyIds.InstanceUtimeBookExtendedSummary;
            /// <summary>
            /// Location
            /// </summary>
            public const uint Location          = (uint)PropertyIds.InstanceUtimeBookExtendedLocation;
            /// <summary>
            /// BookId
            /// </summary>
            public const uint BookId            = (uint)PropertyIds.InstanceUtimeBookExtendedBookId;
            /// <summary>
            /// Description
            /// </summary>
            public const uint Description       = (uint)PropertyIds.InstanceUtimeBookExtendedDescription;
            /// <summary>
            /// BusyStatus
            /// </summary>
            public const uint BusyStatus        = (uint)PropertyIds.InstanceUtimeBookExtendedBusyStatus;
            /// <summary>
            /// EventStatus
            /// </summary>
            public const uint EventStatus       = (uint)PropertyIds.InstanceUtimeBookExtendedEventStatus;
            /// <summary>
            /// Priority
            /// </summary>
            public const uint Priority          = (uint)PropertyIds.InstanceUtimeBookExtendedPriority;
            /// <summary>
            /// Sensitivity
            /// </summary>
            public const uint Sensitivity       = (uint)PropertyIds.InstanceUtimeBookExtendedSensitivity;
            /// <summary>
            /// HasRrule
            /// </summary>
            public const uint HasRrule          = (uint)PropertyIds.InstanceUtimeBookExtendedHasRrule;
            /// <summary>
            /// Latitude
            /// </summary>
            public const uint Latitude          = (uint)PropertyIds.InstanceUtimeBookExtendedLatitude;
            /// <summary>
            /// Longitude
            /// </summary>
            public const uint Longitude         = (uint)PropertyIds.InstanceUtimeBookExtendedLongitude;
            /// <summary>
            /// HasAlarm
            /// </summary>
            public const uint HasAlarm          = (uint)PropertyIds.InstanceUtimeBookExtendedHasAlarm;
            /// <summary>
            /// OriginalEventId
            /// </summary>
            public const uint OriginalEventId   = (uint)PropertyIds.InstanceUtimeBookExtendedOriginalEventId;
            /// <summary>
            /// LastModifiedTime
            /// </summary>
            public const uint LastModifiedTime  = (uint)PropertyIds.InstanceUtimeBookExtendedLastModifiedTime;
            /// <summary>
            /// SyncData1
            /// </summary>
            public const uint SyncData1         = (uint)PropertyIds.InstanceUtimeBookExtendedSyncData1;
            /// <summary>
            /// OrganizerName
            /// </summary>
            public const uint OrganizerName     = (uint)PropertyIds.InstanceUtimeBookExtendedOrganizerName;
            /// <summary>
            /// Categories
            /// </summary>
            public const uint Categories        = (uint)PropertyIds.InstanceUtimeBookExtendedCategories;
            /// <summary>
            /// HasAttendee
            /// </summary>
            public const uint HasAttendee       = (uint)PropertyIds.InstanceUtimeBookExtendedHasAttendee;
            /// <summary>
            /// SyncData2
            /// </summary>
            public const uint SyncData2         = (uint)PropertyIds.InstanceUtimeBookExtendedSyncData2;
            /// <summary>
            /// SyncData3
            /// </summary>
            public const uint SyncData3         = (uint)PropertyIds.InstanceUtimeBookExtendedSyncData3;
            /// <summary>
            /// SyncData4
            /// </summary>
            public const uint SyncData4         = (uint)PropertyIds.InstanceUtimeBookExtendedSyncData4;
        }

        public static class InstanceLocaltimeBookExtended
        {
            /// <summary>
            /// Uri
            /// </summary>
            public const string Uri = "tizen.calendar_view.extended/instance_localtime/book";
            /// <summary>
            /// EventId
            /// </summary>
            public const uint EventId          = (uint)PropertyIds.InstanceLocaltimeBookExtendedEventId;
            /// <summary>
            /// Start
            /// </summary>
            public const uint Start            = (uint)PropertyIds.InstanceLocaltimeBookExtendedStart;
            /// <summary>
            /// End
            /// </summary>
            public const uint End              = (uint)PropertyIds.InstanceLocaltimeBookExtendedEnd;
            /// <summary>
            /// Summary
            /// </summary>
            public const uint Summary          = (uint)PropertyIds.InstanceLocaltimeBookExtendedSummary;
            /// <summary>
            /// Location
            /// </summary>
            public const uint Location         = (uint)PropertyIds.InstanceLocaltimeBookExtendedLocation;
            /// <summary>
            /// BookId
            /// </summary>
            public const uint BookId           = (uint)PropertyIds.InstanceLocaltimeBookExtendedBookId;
            /// <summary>
            /// </summary>
            public const uint Description      = (uint)PropertyIds.InstanceLocaltimeBookExtendedDescription;
            /// <summary>
            /// </summary>
            public const uint BusyStatus       = (uint)PropertyIds.InstanceLocaltimeBookExtendedBusyStatus;
            /// <summary>
            /// EventStatus
            /// </summary>
            public const uint EventStatus      = (uint)PropertyIds.InstanceLocaltimeBookExtendedEventStatus;
            /// <summary>
            /// Priority
            /// </summary>
            public const uint Priority         = (uint)PropertyIds.InstanceLocaltimeBookExtendedPriority;
            /// <summary>
            /// Sensitivity
            /// </summary>
            public const uint Sensitivity      = (uint)PropertyIds.InstanceLocaltimeBookExtendedSensitivity;
            /// <summary>
            /// HasRrule
            /// </summary>
            public const uint HasRrule         = (uint)PropertyIds.InstanceLocaltimeBookExtendedHasRrule;
            /// <summary>
            /// Latitude
            /// </summary>
            public const uint Latitude         = (uint)PropertyIds.InstanceLocaltimeBookExtendedLatitude;
            /// <summary>
            /// Longitude
            /// </summary>
            public const uint Longitude        = (uint)PropertyIds.InstanceLocaltimeBookExtendedLongitude;
            /// <summary>
            /// HasAlarm
            /// </summary>
            public const uint HasAlarm         = (uint)PropertyIds.InstanceLocaltimeBookExtendedHasAlarm;
            /// <summary>
            /// OriginalEventId
            /// </summary>
            public const uint OriginalEventId  = (uint)PropertyIds.InstanceLocaltimeBookExtendedOriginalEventId;
            /// <summary>
            /// LastModifiedTime
            /// </summary>
            public const uint LastModifiedTime = (uint)PropertyIds.InstanceLocaltimeBookExtendedLastModifiedTime;
            /// <summary>
            /// SyncData1
            /// </summary>
            public const uint SyncData1        = (uint)PropertyIds.InstanceLocaltimeBookExtendedSyncData1;
            /// <summary>
            /// OrganizerName
            /// </summary>
            public const uint OrganizerName    = (uint)PropertyIds.InstanceLocaltimeBookExtendedOrganizerName;
            /// <summary>
            /// Categories
            /// </summary>
            public const uint Categories       = (uint)PropertyIds.InstanceLocaltimeBookExtendedCategories;
            /// <summary>
            /// HasAttendee
            /// </summary>
            public const uint HasAttendee      = (uint)PropertyIds.InstanceLocaltimeBookExtendedHasAttendee;
            /// <summary>
            /// SyncData2
            /// </summary>
            public const uint SyncData2        = (uint)PropertyIds.InstanceLocaltimeBookExtendedSyncData2;
            /// <summary>
            /// SyncData3
            /// </summary>
            public const uint SyncData3        = (uint)PropertyIds.InstanceLocaltimeBookExtendedSyncData3;
            /// <summary>
            /// SyncData4
            /// </summary>
            public const uint SyncData4        = (uint)PropertyIds.InstanceLocaltimeBookExtendedSyncData4;
            /// <summary>
            /// IsAllday
            /// </summary>
            public const uint IsAllday         = (uint)PropertyIds.InstanceLocaltimeBookExtendedIsAllday;
        }

        public static class UpdatedInfo
        {
            /// <summary>
            /// Identifier of this updatedInfo view
            /// </summary>
            public const string Uri = "tizen.calendar_view.updated_info";
            /// <summary>
            /// Modified event(or todo) record ID
            /// </summary>
            public const uint Id         = (uint)PropertyIds.UpdateInfoId;
            /// <summary>
            /// Calendar book ID of the modified event(or todo) record
            /// </summary>
            public const uint CalendarId = (uint)PropertyIds.UpdateInfoCalendarId;
            /// <summary>
            /// Enumeration value of the modified status.
            /// </summary>
            public const uint Type       = (uint)PropertyIds.UpdateInfoType;
            /// <summary>
            /// Version after change
            /// </summary>
            public const uint Version    = (uint)PropertyIds.UpdateInfoVersion;
        }

        public static class Extended
        {
            /// <summary>
            /// Identifier of this extended_property view
            /// </summary>
            public const string Uri = "tizen.calendar_view.extended_property";
            /// <summary>
            /// DB record ID of the extended_property
            /// </summary>
            public const uint Id         = (uint)PropertyIds.ExtendedId;
            /// <summary>
            /// Related record ID
            /// </summary>
            public const uint RecordId   = (uint)PropertyIds.ExtendedRecordId;
            /// <summary>
            /// Enumeration value of the record type.
            /// </summary>
            public const uint RecordType = (uint)PropertyIds.ExtendedRecordType;
            /// <summary>
            /// The key of the property
            /// </summary>
            public const uint Key        = (uint)PropertyIds.ExtendedKey;
            /// <summary>
            /// The value of the property
            /// </summary>
            public const uint Value      = (uint)PropertyIds.ExtendedValue;
        }
    }
}

