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

namespace Tizen.Applications
{
    /// <summary>
    /// Data of the AppControl.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class AppControlData
    {
        /// <summary>
        /// Subject.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Subject = "http://tizen.org/appcontrol/data/subject";

        /// <summary>
        /// Recipients.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string To = "http://tizen.org/appcontrol/data/to";

        /// <summary>
        /// E-mail addresses that should be carbon copied.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Cc = "http://tizen.org/appcontrol/data/cc";

        /// <summary>
        /// E-mail addresses that should be blind carbon copied.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Bcc = "http://tizen.org/appcontrol/data/bcc";

        /// <summary>
        /// Text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Text = "http://tizen.org/appcontrol/data/text";

        /// <summary>
        /// Title.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Title = "http://tizen.org/appcontrol/data/title";

        /// <summary>
        /// Selected items.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Selected = "http://tizen.org/appcontrol/data/selected";

        /// <summary>
        /// Paths of items.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Path = "http://tizen.org/appcontrol/data/path";

        /// <summary>
        /// Selection mode ("single" or "multiple").
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SectionMode = "http://tizen.org/appcontrol/data/selection_mode";

        /// <summary>
        /// All-day mode of the event ("true" or "false").
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string AllDay = "http://tizen.org/appcontrol/data/calendar/all_day";

        /// <summary>
        /// Start time of the event (format: YYYY-MM-DD HH:MM:SS).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string StartTime = "http://tizen.org/appcontrol/data/calendar/start_time";

        /// <summary>
        /// End time of the event (format: YYYY-MM-DD HH:MM:SS).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Endtime = "http://tizen.org/appcontrol/data/calendar/end_time";

        /// <summary>
        /// E-mail addressed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Email = "http://tizen.org/appcontrol/data/email";

        /// <summary>
        /// Phone numbers.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Phone = "http://tizen.org/appcontrol/data/phone";

        /// <summary>
        /// URLs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Url = "http://tizen.org/appcontrol/data/url";

        /// <summary>
        /// IDs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Ids = "http://tizen.org/appcontrol/data/id";

        /// <summary>
        /// Type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Type = "http://tizen.org/appcontrol/data/type";

        /// <summary>
        /// Total count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string TotalCount = "http://tizen.org/appcontrol/data/total_count";

        /// <summary>
        /// Total size (unit : bytes).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string TotalSize = "http://tizen.org/appcontrol/data/total_size";

        /// <summary>
        /// Name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Name = "http://tizen.org/appcontrol/data/name";

        /// <summary>
        /// Location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Location = "http://tizen.org/appcontrol/data/location";

        /// <summary>
        /// Select the type of input method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string InputType = "http://tizen.org/appcontrol/data/input_type";

        /// <summary>
        /// Send the pre inputted text, such as "http://" in web.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string InputDefaultText = "http://tizen.org/appcontrol/data/input_default_text";

        /// <summary>
        /// Send guide text to show to the user, such as "Input user name".
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string InputGuideText = "http://tizen.org/appcontrol/data/input_guide_text";

        /// <summary>
        /// Send text to receive answer result from smart reply.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string InputPredictionHint = "http://tizen.org/appcontrol/data/input_prediction_hint";
    }
}
