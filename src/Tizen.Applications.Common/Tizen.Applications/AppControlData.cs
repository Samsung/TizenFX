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
    public static class AppControlData
    {
        /// <summary>
        /// Subject.
        /// </summary>
        public const string Subject = "http://tizen.org/appcontrol/data/subject";

        /// <summary>
        /// Recipients.
        /// </summary>
        public const string To = "http://tizen.org/appcontrol/data/to";

        /// <summary>
        /// E-mail addresses that should be carbon copied.
        /// </summary>
        public const string Cc = "http://tizen.org/appcontrol/data/cc";

        /// <summary>
        /// E-mail addresses that should be blind carbon copied.
        /// </summary>
        public const string Bcc = "http://tizen.org/appcontrol/data/bcc";

        /// <summary>
        /// Text.
        /// </summary>
        public const string Text = "http://tizen.org/appcontrol/data/text";

        /// <summary>
        /// Title.
        /// </summary>
        public const string Title = "http://tizen.org/appcontrol/data/title";

        /// <summary>
        /// Selected items.
        /// </summary>
        public const string Selected = "http://tizen.org/appcontrol/data/selected";

        /// <summary>
        /// Paths of items.
        /// </summary>
        public const string Path = "http://tizen.org/appcontrol/data/path";

        /// <summary>
        /// Selection mode ("single" or "multiple").
        /// </summary>
        public const string SectionMode = "http://tizen.org/appcontrol/data/selection_mode";

        /// <summary>
        /// All-day mode of the event ("true" or "false").
        /// </summary>
        public const string AllDay = "http://tizen.org/appcontrol/data/calendar/all_day";

        /// <summary>
        /// Start time of the event (format: YYYY-MM-DD HH:MM:SS).
        /// </summary>
        public const string StartTime = "http://tizen.org/appcontrol/data/calendar/start_time";

        /// <summary>
        /// End time of the event (format: YYYY-MM-DD HH:MM:SS).
        /// </summary>
        public const string Endtime = "http://tizen.org/appcontrol/data/calendar/end_time";

        /// <summary>
        /// E-mail addressed.
        /// </summary>
        public const string Email = "http://tizen.org/appcontrol/data/email";

        /// <summary>
        /// Phone numbers.
        /// </summary>
        public const string Phone = "http://tizen.org/appcontrol/data/phone";

        /// <summary>
        /// URLs.
        /// </summary>
        public const string Url = "http://tizen.org/appcontrol/data/url";

        /// <summary>
        /// IDs.
        /// </summary>
        public const string Ids = "http://tizen.org/appcontrol/data/id";

        /// <summary>
        /// Type.
        /// </summary>
        public const string Type = "http://tizen.org/appcontrol/data/type";

        /// <summary>
        /// Total count.
        /// </summary>
        public const string TotalCount = "http://tizen.org/appcontrol/data/total_count";

        /// <summary>
        /// Total size (unit : bytes).
        /// </summary>
        public const string TotalSize = "http://tizen.org/appcontrol/data/total_size";

        /// <summary>
        /// Name.
        /// </summary>
        public const string Name = "http://tizen.org/appcontrol/data/name";

        /// <summary>
        /// Location.
        /// </summary>
        public const string Location = "http://tizen.org/appcontrol/data/location";

        /// <summary>
        /// Select the type of input method.
        /// </summary>
        public const string InputType = "http://tizen.org/appcontrol/data/input_type";

        /// <summary>
        /// Send the pre inputted text, such as "http://" in web.
        /// </summary>
        public const string InputDefaultText = "http://tizen.org/appcontrol/data/input_default_text";

        /// <summary>
        /// Send guide text to show to the user, such as "Input user name".
        /// </summary>
        public const string InputGuideText = "http://tizen.org/appcontrol/data/input_guide_text";

        /// <summary>
        /// Send text to receive answer result from smart reply.
        /// </summary>
        public const string InputPredictionHint = "http://tizen.org/appcontrol/data/input_prediction_hint";
    }
}
