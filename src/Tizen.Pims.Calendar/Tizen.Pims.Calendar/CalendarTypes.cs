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

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// This class provides enumerations about calendar information.
    /// </summary>
    /// <remarks>
    /// Most enumerations are based on vcalendar, icalendar(ver 2.0) specification.
    /// https://www.ietf.org/rfc/rfc2445.txt
    /// </remarks>
    public static class CalendarTypes
    {
        /// <summary>
        /// Enumeration for Default book
        /// </summary>
        public enum DefaultBook
        {
            /// <summary>
            /// Default event calendar book.
            /// </summary>
            Event,
            /// <summary>
            /// Default Todo calendar book.
            /// </summary>
            Todo,
            /// <summary>
            /// Default Birthday calendar book.
            /// </summary>
            Birthday,
        }

        /// <summary>
        /// Enumeration for Store type
        /// </summary>
        public enum StoreType
        {
            /// <summary>
            /// Book type
            /// </summary>
            Book,
            /// <summary>
            /// Event type
            /// </summary>
            Event,
            /// <summary>
            /// Todo type
            /// </summary>
            Todo,
        }

        /// <summary>
        /// Enumeration for the book mode.
        /// </summary>
        public enum BookMode
        {
            /// <summary>
            /// All modules can read and write records of this calendar_book
            /// </summary>
            Default,
            /// <summary>
            /// All modules can only read records of this calendar book
            /// </summary>
            ReadOnly,
        }

        /// <summary>
        /// Enumeration for the event status.
        /// </summary>
        public enum EventStatus
        {
            /// <summary>
            /// No status
            /// </summary>
            None = 0x01,
            /// <summary>
            /// The event is tentative
            /// </summary>
            Tentative = 0x02,
            /// <summary>
            /// The event is confirmed
            /// </summary>
            Confirmed = 0x04,
            /// <summary>
            /// The event is cancelled
            /// </summary>
            Cancelled = 0x08,
        }

        /// <summary>
        /// Enumeration for for the status of a to-do.
        /// </summary>
        public enum TodoStatus
        {
            /// <summary>
            /// No status
            /// </summary>
            None = 0x0100,
            /// <summary>
            /// Needs action status
            /// </summary>
            NeedAction = 0x0200,
            /// <summary>
            /// Completed status
            /// </summary>
            Completed = 0x0400,
            /// <summary>
            /// Work in process status
            /// </summary>
            InProcess = 0x0800,
            /// <summary>
            /// Cancelled status
            /// </summary>
            Cancelled = 0x1000,
        }

        /// <summary>
        /// Enumeration for the busy status of an event.
        /// </summary>
        public enum BusyStatus
        {
            /// <summary>
            /// The free status
            /// </summary>
            Free,
            /// <summary>
            /// The busy status
            /// </summary>
            Busy,
            /// <summary>
            /// The unavailable status
            /// </summary>
            Unavailable,
            /// <summary>
            /// The tentative status
            /// </summary>
            Tentative,
        }

        /// <summary>
        /// Enumeration for the calendar sensitivity type.
        /// </summary>
        public enum Sensitivity
        {
            /// <summary>
            /// Public Sensitivity
            /// </summary>
            Public,
            /// <summary>
            /// Private Sensitivity
            /// </summary>
            Private,
            /// <summary>
            /// Confidential Sensitivity
            /// </summary>
            Confidential,
        }

        /// <summary>
        /// Enumeration for the meeting status.
        /// </summary>
        public enum MeetingStatus
        {
            /// <summary>
            /// No meeting
            /// </summary>
            NoMeeting,
            /// <summary>
            /// Meeting exists
            /// </summary>
            Meeting,
            /// <summary>
            /// Meeting received
            /// </summary>
            Received,
            /// <summary>
            /// Meeting cancelled
            /// </summary>
            Cancelled,
        }

        /// <summary>
        /// Enumeration for the calendar event item's priority
        /// </summary>
        public enum Priority
        {
            /// <summary>
            /// No priority
            /// </summary>
            None = 0x01,
            /// <summary>
            /// Low priority
            /// </summary>
            High = 0x02,
            /// <summary>
            /// Normal priority
            /// </summary>
            Normal = 0x04,
            /// <summary>
            /// High priority
            /// </summary>
            Low = 0x08,
        }

        /// <summary>
        /// Enumeration for the frequency of an event's recurrence.
        /// </summary>
        public enum Recurrence
        {
            /// <summary>
            /// No recurrence event
            /// </summary>
            None,
            /// <summary>
            /// An event occurs every day
            /// </summary>
            Daily,
            /// <summary>
            /// An event occurs on the same day of every week. According to the week flag, the event will recur every day of the week
            /// </summary>
            Weekly,
            /// <summary>
            /// An event occurs on the same day of every month
            /// </summary>
            Monthly,
            /// <summary>
            /// An event occurs on the same day of every year
            /// </summary>
            Yearly,
        }

        /// <summary>
        /// Enumeration for the range type.
        /// </summary>
        public enum RangeType
        {
            /// <summary>
            /// Range until
            /// </summary>
            Until,
            /// <summary>
            /// Range count
            /// </summary>
            Count,
            /// <summary>
            /// No range
            /// </summary>
            None,
        }

        /// <summary>
        /// Enumeration for the system type.
        /// </summary>
        public enum SystemType
        {
            /// <summary>
            /// Locale's default calendar
            /// </summary>
            Default,
            /// <summary>
            /// Locale's default calendar
            /// </summary>
            Gregorian,
            /// <summary>
            /// East Asian lunisolar calendar
            /// </summary>
            Lunisolar,
        }

        /// <summary>
        /// Enumeration for the alarm time unit type of an event, such as minutes, hours, days, and so on.
        /// </summary>
        public enum TickUnit
        {
            /// <summary>
            /// No reminder set
            /// </summary>
            None = -1,
            /// <summary>
            /// Specific in seconds
            /// </summary>
            Specific = 1,
            /// <summary>
            /// Alarm time unit in minutes
            /// </summary>
            Minute = 60,
            /// <summary>
            /// Alarm time unit in hours
            /// </summary>
            Hour = 3600,
            /// <summary>
            /// Alarm time unit in days
            /// </summary>
            Day = 86400,
            /// <summary>
            /// Alarm time unit in weeks
            /// </summary>
            Week = 604800,
        }

        /// <summary>
        /// Enumeration for weekdays.
        /// </summary>
        public enum WeekDay
        {
            /// <summary>
            /// Sunday
            /// </summary>
            Sunday = 1,
            /// <summary>
            /// Monday
            /// </summary>
            Monday,
            /// <summary>
            /// Tuesday
            /// </summary>
            Tuesday,
            /// <summary>
            /// Wednesday
            /// </summary>
            Wednesday,
            /// <summary>
            /// Thursday
            /// </summary>
            Thursday,
            /// <summary>
            /// Friday
            /// </summary>
            Friday,
            /// <summary>
            /// Saturday
            /// </summary>
            Saturday,
        }

        /// <summary>
        /// Enumeration to specify the type of calendar user specified by the property.
        /// </summary>
        public enum Cutype
        {
            /// <summary>
            /// An individual
            /// </summary>
            Individual,
            /// <summary>
            /// A group of individuals
            /// </summary>
            Group,
            /// <summary>
            /// A physical resource
            /// </summary>
            Resource,
            /// <summary>
            /// A room resource
            /// </summary>
            Room,
            /// <summary>
            /// Otherwise not known
            /// </summary>
            Unknown,
        }

        /// <summary>
        /// Enumeration for the attendee role.
        /// </summary>
        public enum AttendeeRole
        {
            /// <summary>
            /// Participation is required
            /// </summary>
            ReqParticipant,
            /// <summary>
            /// Accepted status
            /// </summary>
            OptParticipant,
            /// <summary>
            /// Non-Participant
            /// </summary>
            NonParticipant,
            /// <summary>
            /// Chairperson
            /// </summary>
            Chair,
        }

        /// <summary>
        /// Enumeration for the attendee status.
        /// </summary>
        public enum AttendeeStatus
        {
            /// <summary>
            /// Pending status
            /// </summary>
            Pending,
            /// <summary>
            /// Accepted status
            /// </summary>
            Accepted,
            /// <summary>
            /// Declined status
            /// </summary>
            Declined,
            /// <summary>
            /// Tentative status
            /// </summary>
            Tentative,
            /// <summary>
            /// Delegated status
            /// </summary>
            Delegated,
            /// <summary>
            /// Completed status
            /// </summary>
            Completed,
            /// <summary>
            /// In process status
            /// </summary>
            InProcess,
        }

        /// <summary>
        /// Enumeration for the alarm action.
        /// </summary>
        public enum Action
        {
            /// <summary>
            /// Audio action
            /// </summary>
            Audio,
            /// <summary>
            /// Display action
            /// </summary>
            Display,
            /// <summary>
            /// Email action
            /// </summary>
            Email,
        }
    }
}

