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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides means to set values used for the update command.
    /// </summary>
    /// <remarks>
    /// The values only set in the object will be affected to the update command.
    /// </remarks>
    /// <seealso cref="MediaInfoCommand.Update(string, MediaInfoUpdateValues)"/>
    public class MediaInfoUpdateValues
    {
        /// <summary>
        /// Gets or sets the weather information for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for weather; the field will not be updated if null.</value>
        public string Weather { get; set; }

        /// <summary>
        /// Gets or sets the favorite status for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A value indicating whether the media is favorite; the field will not be updated if null.</value>
        public bool? IsFavorite { get; set; }

        /// <summary>
        /// Gets or sets the provider information for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for provider; the field will not be updated if null.</value>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the category information for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for category; the field will not be updated if null.</value>
        public string Category { get; set; }


        /// <summary>
        /// Gets or sets the location tag for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for location tag; the field will not be updated if null.</value>
        public string LocationTag { get; set; }

        /// <summary>
        /// Gets or sets the age rating information for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for age rating; the field will not be updated if null.</value>
        public string AgeRating { get; set; }
    }
}
