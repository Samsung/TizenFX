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

namespace ElmSharp
{
    /// <summary>
    /// It inherits System.EventArgs.
    /// The DateChanged event in the Calendar and the DateTimeChanged event in DateTimeSelector
    /// contain the DateChangedEventArgs as a parameter.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the OldDate property of the given DateChangedEventArgs.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DateTime OldDate { get; private set; }

        /// <summary>
        /// Gets the NewDate property of the given DateChangedEventArgs.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DateTime NewDate { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the DateChangedEventArgs class.
        /// </summary>
        /// <param name="oldDate">
        /// Old date when the DateChanged event or DateTimeChanged event triggered.
        /// </param>
        /// <param name="newDate">
        /// New date when the DateChanged event or DateTimeChanged event triggered.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public DateChangedEventArgs(DateTime oldDate, DateTime newDate)
        {
            this.OldDate = oldDate;
            this.NewDate = newDate;
        }
    }
}
