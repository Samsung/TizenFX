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
    /// <since_tizen> 4 </since_tizen>
    /// <remarks>
    /// Most enumerations are based on vcalendar, icalendar(ver 2.0) specification.
    /// https://www.ietf.org/rfc/rfc2445.txt
    /// </remarks>
    public static class CalendarTypes
    {
        /// <summary>
        /// Enumeration for Default book
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum DefaultBook
        {
            /// <summary>
            /// Default event calendar book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Event,
            /// <summary>
            /// Default Todo calendar book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Todo,
            /// <summary>
            /// Default Birthday calendar book.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Birthday,
        }

        /// <summary>
        /// Enumeration for Store type
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum StoreType
        {
            /// <summary>
            /// Book type
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Book,
            /// <summary>
            /// Event type
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Event,
            /// <summary>
            /// Todo type
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Todo,
        }

        /// <summary>
        /// Enumeration for the book mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum BookMode
        {
            /// <summary>
            /// All modules can read and write records of this calendar_book
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Default,
            /// <summary>
            /// All modules can only read records of this calendar book
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            ReadOnly,
        }

        /// <summary>
        /// Enumeration for the event status.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum EventStatus
        {
            /// <summary>
            /// No status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None = 0x01,
            /// <summary>
            /// The event is tentative
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Tentative = 0x02,
            /// <summary>
            /// The event is confirmed
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Confirmed = 0x04,
            /// <summary>
            /// The event is cancelled
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Cancelled = 0x08,
        }

        /// <summary>
        /// Enumeration for for the status of a to-do.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum TodoStatus
        {
            /// <summary>
            /// No status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None = 0x0100,
            /// <summary>
            /// Needs action status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            NeedAction = 0x0200,
            /// <summary>
            /// Completed status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Completed = 0x0400,
            /// <summary>
            /// Work in process status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            InProcess = 0x0800,
            /// <summary>
            /// Cancelled status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Cancelled = 0x1000,
        }

        /// <summary>
        /// Enumeration for the busy status of an event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum BusyStatus
        {
            /// <summary>
            /// The free status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Free,
            /// <summary>
            /// The busy status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Busy,
            /// <summary>
            /// The unavailable status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Unavailable,
            /// <summary>
            /// The tentative status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Tentative,
        }

        /// <summary>
        /// Enumeration for the calendar sensitivity type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Sensitivity
        {
            /// <summary>
            /// Public Sensitivity
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Public,
            /// <summary>
            /// Private Sensitivity
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Private,
            /// <summary>
            /// Confidential Sensitivity
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Confidential,
        }

        /// <summary>
        /// Enumeration for the meeting status.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum MeetingStatus
        {
            /// <summary>
            /// No meeting
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            NoMeeting,
            /// <summary>
            /// Meeting exists
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Meeting,
            /// <summary>
            /// Meeting received
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Received,
            /// <summary>
            /// Meeting cancelled
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Cancelled,
        }

        /// <summary>
        /// Enumeration for the calendar event item's priority
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Priority
        {
            /// <summary>
            /// No priority
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None = 0x01,
            /// <summary>
            /// Low priority
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            High = 0x02,
            /// <summary>
            /// Normal priority
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Normal = 0x04,
            /// <summary>
            /// High priority
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Low = 0x08,
        }

        /// <summary>
        /// Enumeration for the frequency of an event's recurrence.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Recurrence
        {
            /// <summary>
            /// No recurrence event
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None,
            /// <summary>
            /// An event occurs every day
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Daily,
            /// <summary>
            /// An event occurs on the same day of every week. According to the week flag, the event will recur every day of the week
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Weekly,
            /// <summary>
            /// An event occurs on the same day of every month
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Monthly,
            /// <summary>
            /// An event occurs on the same day of every year
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Yearly,
        }

        /// <summary>
        /// Enumeration for the range type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum RangeType
        {
            /// <summary>
            /// Range until
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Until,
            /// <summary>
            /// Range count
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Count,
            /// <summary>
            /// No range
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None,
        }

        /// <summary>
        /// Enumeration for the system type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum SystemType
        {
            /// <summary>
            /// Locale's default calendar
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Default,
            /// <summary>
            /// Locale's default calendar
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Gregorian,
            /// <summary>
            /// East Asian lunisolar calendar
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Lunisolar,
        }

        /// <summary>
        /// Enumeration for the alarm time unit type of an event, such as minutes, hours, days, and so on.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum TickUnit
        {
            /// <summary>
            /// No reminder set
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None = -1,
            /// <summary>
            /// Specific in seconds
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Specific = 1,
            /// <summary>
            /// Alarm time unit in minutes
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Minute = 60,
            /// <summary>
            /// Alarm time unit in hours
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Hour = 3600,
            /// <summary>
            /// Alarm time unit in days
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Day = 86400,
            /// <summary>
            /// Alarm time unit in weeks
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Week = 604800,
        }

        /// <summary>
        /// Enumeration for weekdays.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum WeekDay
        {
            /// <summary>
            /// Sunday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Sunday = 1,
            /// <summary>
            /// Monday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Monday,
            /// <summary>
            /// Tuesday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Tuesday,
            /// <summary>
            /// Wednesday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Wednesday,
            /// <summary>
            /// Thursday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Thursday,
            /// <summary>
            /// Friday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Friday,
            /// <summary>
            /// Saturday
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Saturday,
        }

        /// <summary>
        /// Enumeration to specify the type of calendar user specified by the property.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Cutype
        {
            /// <summary>
            /// An individual
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Individual,
            /// <summary>
            /// A group of individuals
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Group,
            /// <summary>
            /// A physical resource
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Resource,
            /// <summary>
            /// A room resource
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Room,
            /// <summary>
            /// Otherwise not known
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Unknown,
        }

        /// <summary>
        /// Enumeration for the attendee role.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum AttendeeRole
        {
            /// <summary>
            /// Participation is required
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            ReqParticipant,
            /// <summary>
            /// Accepted status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            OptParticipant,
            /// <summary>
            /// Non-Participant
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            NonParticipant,
            /// <summary>
            /// Chairperson
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Chair,
        }

        /// <summary>
        /// Enumeration for the attendee status.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum AttendeeStatus
        {
            /// <summary>
            /// Pending status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Pending,
            /// <summary>
            /// Accepted status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Accepted,
            /// <summary>
            /// Declined status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Declined,
            /// <summary>
            /// Tentative status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Tentative,
            /// <summary>
            /// Delegated status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Delegated,
            /// <summary>
            /// Completed status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Completed,
            /// <summary>
            /// In process status
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            InProcess,
        }

        /// <summary>
        /// Enumeration for the alarm action.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum Action
        {
            /// <summary>
            /// Audio action
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Audio,
            /// <summary>
            /// Display action
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Display,
            /// <summary>
            /// Email action
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Email,
        }
    }
}

