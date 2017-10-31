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
    /// Represents a special piece of information that may be associated with media.
    /// Tagging allows a user to organize large number of items into logical groups providing
    /// a simplified and faster way of accessing media items.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Tag
    {
        internal Tag(IntPtr handle)
        {
            Name = InteropHelper.GetString(handle, Interop.Tag.GetName);
            Id = InteropHelper.GetValue<int>(handle, Interop.Tag.GetId);
        }

        /// <summary>
        /// Gets the ID of the tag.
        /// </summary>
        /// <value>The unique ID of the tag.</value>
        /// <since_tizen> 3 </since_tizen>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        /// <value>The name of the tag.</value>
        /// <since_tizen> 3 </since_tizen>
        public string Name { get; }

        internal static Tag FromHandle(IntPtr handle) => new Tag(handle);

        /// <summary>
        /// Returns a string representation of the tag.
        /// </summary>
        /// <returns>A string representation of the current tag.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override string ToString() => $"Id={Id}, Name={Name}";

    }
}
