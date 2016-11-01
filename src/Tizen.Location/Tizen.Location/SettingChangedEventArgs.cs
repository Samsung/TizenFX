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

namespace Tizen.Location
{
    public class SettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for SettingChangedEventArgs class.
        /// </summary>
        /// <param name="method"> The positioing method used for Location information.</param>
        /// <param name="enable"> Status of the method.</param>
        public SettingChangedEventArgs(LocationType type, bool enable)
        {
            LocationType = type;
            IsEnabled = enable;
        }

        /// <summary>
        /// Gets the currently used location method.
        /// </summary>
        public LocationType LocationType { get; private set; }

        /// <summary>
        /// Method to get the setting value changed.
        /// </summary>
        public bool IsEnabled { get; private set; }
    }
}
