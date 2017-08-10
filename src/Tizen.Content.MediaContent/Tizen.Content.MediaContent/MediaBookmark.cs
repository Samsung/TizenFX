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
using System.Runtime.InteropServices;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// A MediaBookmark allows you to mark interesting moment in a media(video and audio) to enable fast searching.
    /// The MediaBookmark Information API provides functions to get information about bookmarks associated with video and audio items.
    /// </summary>
    public class MediaBookmark : IDisposable
    {
        private IntPtr _bookmarkHandle = IntPtr.Zero;
        private bool _disposedValue = false;

        private IntPtr Handle
        {
            get
            {
                if (_bookmarkHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(MediaBookmark));
                }

                return _bookmarkHandle;
            }
        }
        internal MediaBookmark(IntPtr handle)
        {
            _bookmarkHandle = handle;
        }

        ~MediaBookmark()
        {
            Dispose(false);
        }
        /// <summary>
        /// The media bookmark ID
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Id
        {
            get
            {
                int id;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaBookmark.GetBookmarkId(Handle, out id), "Failed to get bookmark id");

                return id;
            }
        }

        /// <summary>
        /// The thumbnail path of media bookmark
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ThumbnailPath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaBookmark.GetThumbnailPath(Handle, out val), "Failed to get bookmark thumbnail");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The bookmark time offset (in milliseconds)
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Offset
        {
            get
            {
                uint offset;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaBookmark.GetMarkedTime(Handle, out offset), "Failed to get bookmarked time");

                return offset;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_bookmarkHandle != IntPtr.Zero)
                {
                    Interop.MediaBookmark.Destroy(_bookmarkHandle);
                    _bookmarkHandle = IntPtr.Zero;
                }

                _disposedValue = true;
            }
        }
    }
}
