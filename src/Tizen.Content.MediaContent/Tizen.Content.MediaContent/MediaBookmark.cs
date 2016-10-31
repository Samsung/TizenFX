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
using System.Linq;
using System.Text;

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
        internal readonly uint _offset;
        internal readonly String _thumbnailPath;
        internal MediaBookmark(IntPtr handle)
        {
            _bookmarkHandle = handle;
            MediaContentError res = (MediaContentError)Interop.MediaBookmark.GetMarkedTime(_bookmarkHandle, out _offset);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to Get Offset");
            }
            res = (MediaContentError)Interop.MediaBookmark.GetThumbnailPath(_bookmarkHandle, out _thumbnailPath);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to Get Thumbnail Path");
            }
        }

        ~MediaBookmark()
        {
            Dispose(false);
        }
        /// <summary>
        /// The media bookmark ID
        /// </summary>
        public int Id
        {
            get
            {
                int id;
                MediaContentError res = (MediaContentError)Interop.MediaBookmark.GetBookmarkId(_bookmarkHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get bookmark id");
                }
                return id;
            }
        }

        /// <summary>
        /// The thumbnail path of media bookmark
        /// </summary>
        public string ThumbnailPath
        {
            get
            {
                return _thumbnailPath;
            }
        }

        /// <summary>
        /// The bookmark time offset (in milliseconds)
        /// </summary>
        public uint Offset
        {
            get
            {
                return _offset;
            }
        }

        /// <summary>
        /// Inserts a new bookmark in media on the specified time offset to the media database.
        /// </summary>
        /// <param name="content">Media in which the bookmark is to be inserted</param>
        /// <param name="offset">The bookmark time offset (in seconds)</param>
        /// <param name="thumbnailPath">The thumbnail path of video bookmark. If the media type is audio, then thumbnail is null.</param>
        internal MediaBookmark(MediaInformation content, uint offset, string thumbnailPath)
        {
            _offset = offset;
            if (thumbnailPath != null)
                _thumbnailPath = thumbnailPath;
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
                    Interop.Face.Destroy(_bookmarkHandle);
                    _bookmarkHandle = IntPtr.Zero;
                }
                _disposedValue = true;
            }
        }
    }
}
