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
    /// Represents the media bookmark that allows you to mark an interesting moment
    /// in media (video and audio) to enable fast searching.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class Bookmark
    {
        internal Bookmark(IntPtr handle)
        {
            Id = InteropHelper.GetValue<int>(handle, Interop.Bookmark.GetId);
            ThumbnailPath = InteropHelper.GetString(handle, Interop.Bookmark.GetThumbnailPath);
            Offset = InteropHelper.GetValue<int>(handle, Interop.Bookmark.GetMarkedTime);
            Name = InteropHelper.GetString(handle, Interop.Bookmark.GetName);
        }

        /// <summary>
        /// Gets the ID of the bookmark.
        /// </summary>
        /// <value>The ID of the bookmark.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Id { get; }

        /// <summary>
        /// Gets the thumbnail path of the bookmark.
        /// </summary>
        /// <value>The thumbnail path of the bookmark.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ThumbnailPath { get; }

        /// <summary>
        /// Gets the offset in milliseconds.
        /// </summary>
        /// <value>The offset of the bookmark in media in milliseconds.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Offset { get; }

        /// <summary>
        /// Gets the name of the bookmark.
        /// </summary>
        /// <value>The name of the bookmark.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Name { get; }

        internal static Bookmark FromHandle(IntPtr handle) => new Bookmark(handle);

        /// <summary>
        /// Returns a string representation of the bookmark.
        /// </summary>
        /// <returns>A string representation of the current bookmark.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override string ToString() =>
            $"Id={Id}, Name={Name}, ThumbnailPath={ThumbnailPath}, Offset={Offset}";
    }
}
