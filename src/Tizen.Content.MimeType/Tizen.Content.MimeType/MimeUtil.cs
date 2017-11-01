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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Tizen.Content.MimeType
{
    /// <summary>
    /// The MimeUtil API provides functions to map the MIME types to file extensions and vice versa.
    /// </summary>
    /// <remarks>
    /// Conversions are provided from the file extensions to MIME types and from the MIME types to file extensions.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public static class MimeUtil
    {
        /// <summary>
        /// Gets the MIME type for the given file extension.
        /// The MIME type is 'application/octet-stream' if the given file extension is not associated with specific file formats.
        /// </summary>
        /// <param name="fileExtension"> The file extension.</param>
        /// <example>
        /// <code>
        ///     string mimeType = MimeUtil.GetMimeType("png");
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static string GetMimeType(string fileExtension)
        {
            string mime;
            int res = Interop.Mime.GetMime(fileExtension, out mime);
            if (res != (int)MimeError.None)
            {
                throw MimeExceptionFactory.CreateException((MimeError)res);
            }
            return mime;
        }

        /// <summary>
        /// Gets the file extensions for the given MIME type.
        /// </summary>
        /// <returns>
        /// If successful, returns the list of file extension strings for the given MIME type.
        /// The array of file extension is without the leading dot ('.').
        /// </returns>
        /// <param name="mime"> The MIME type.</param>
        /// <example>
        /// <code>
        ///     var extColl = MimeUtil.GetFileExtension("video/mpeg");
        ///     foreach ( string obj in extColl )
        ///     {
        ///         Console.WriteLine(obj);
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<string> GetFileExtension(string mime)
        {
            IntPtr extensionArray = IntPtr.Zero;
            int length = -1;
            int res = Interop.Mime.GetFile(mime, out extensionArray, out length);
            if (res != (int)MimeError.None)
            {
                throw MimeExceptionFactory.CreateException((MimeError)res);
            }
            IntPtr[] extensionList = new IntPtr[length];
            Marshal.Copy(extensionArray, extensionList, 0, length);
            Collection<string> coll = new Collection<string>();
            foreach (IntPtr extension in extensionList)
            {
                coll.Add(Marshal.PtrToStringAnsi(extension));
                Interop.Libc.Free(extension);
            }
            Interop.Libc.Free(extensionArray);
            return coll;
        }

        internal enum MimeError : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        }
    }
}
