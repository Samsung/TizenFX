using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Tizen.Content.MimeType
{
    /// <summary>
    /// The MimeUtil API provides functions to map MIME types to file extensions and vice versa.</summary>
    /// <remarks>
    /// Conversions are provided from file extensions to MIME types and from MIME types to file extensions.</remarks>
    public static class MimeUtil
    {
        /// <summary>
        /// Gets the MIME type for the given file extension.
        /// The MIME type is 'application/octet-stream' if the given file extension is not associated with specific file formats
        /// </summary>
        /// <param name="fileExtension"> The file Extension</param>
        /// <example>
        /// <code>
        /// string mimeType = MimeUtil.GetMimeType("png");
        /// </code>
        /// </example>
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
        /// Gets file extensions for the given MIME type. </summary>
        /// <returns>
        /// If Successfull, return's the list of file extension strings for the given MIME type.
        /// The array of file extension are without the leading dot ('.')</returns>
        /// <param name="mime"> The mime type</param>
        /// <example>
        /// <code>
        /// IEnumerable<string> extColl = MimeUtil.GetFileExtension("video/mpeg");
        /// foreach ( string obj in extColl )
        /// {
        ///     Console.WriteLine(obj);
        /// }
        /// </code>
        /// </example>
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
            None = Tizen.Internals.Errors.ErrorCode.None, /**< Successful */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter, /**< Invalid parameter */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory, /**< Out of memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError, /**< Internal I/O error */
        }
    }
}
