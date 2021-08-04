/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents the book information for the media.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class BookInfo : MediaInfo
    {
        internal BookInfo(Interop.MediaInfoHandle handle) : base(handle)
        {
            IntPtr bookHandle = IntPtr.Zero;

            try
            {
                Interop.MediaInfo.GetBook(handle, out bookHandle).ThrowIfError("Failed to retrieve data");

                Debug.Assert(bookHandle != IntPtr.Zero);

                Subject = InteropHelper.GetString(bookHandle, Interop.BookInfo.GetSubject);
                Author = InteropHelper.GetString(bookHandle, Interop.BookInfo.GetAuthor);
                DatePublished = InteropHelper.GetString(bookHandle, Interop.BookInfo.GetDate);
                Publisher = InteropHelper.GetString(bookHandle, Interop.BookInfo.GetPublisher);
            }
            finally
            {
                Interop.BookInfo.Destroy(bookHandle).ThrowIfError("Failed to destroy book handle");
            }
        }

        /// <summary>
        /// Gets the subject of book.
        /// </summary>
        /// <value>The subject.</value>
        /// <since_tizen> 9 </since_tizen>
        public string Subject { get; }

        /// <summary>
        /// Gets the author of book.
        /// </summary>
        /// <value>The author.</value>
        /// <since_tizen> 9 </since_tizen>
        public string Author { get; }

        /// <summary>
        /// Gets the published date as a formatted string.
        /// </summary>
        /// <value>The published date.</value>
        /// <since_tizen> 9 </since_tizen>
        public string DatePublished { get; }

        /// <summary>
        /// Gets the publisher of book.
        /// </summary>
        /// <value>The publisher.</value>
        /// <since_tizen> 9 </since_tizen>
        public string Publisher { get; }
    }
}
