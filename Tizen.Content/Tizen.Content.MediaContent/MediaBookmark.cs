/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


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
        private IntPtr _bookmarkHandle;
        private bool _disposedValue = false;
        internal readonly uint _timeStamp;
        internal readonly String _thumbnailPath;
        internal readonly String _mediaId;
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
                string path;
                MediaContentError res = (MediaContentError)Interop.MediaBookmark.GetThumbnailPath(_bookmarkHandle, out path);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get bookmark thumbnail path");
                }
                return path;
            }
        }

        /// <summary>
        /// The bookmark time offset (in milliseconds)
        /// </summary>
        public uint TimeStamp
        {
            get
            {
                uint time;
                MediaContentError res = (MediaContentError)Interop.MediaBookmark.GetMarkedTime(_bookmarkHandle, out time);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get marked time for the bookmark");
                }
                return time;
            }
        }

        /// <summary>
        /// Inserts a new bookmark in media on the specified time offset to the media database.
        /// </summary>
        /// <param name="timeStamp">The bookmark time offset (in seconds)</param>
        /// <param name="thumbnailPath">The thumbnail path of video bookmark. If the media type is audio, then thumbnail is null.</param>
        public MediaBookmark(MediaInformation content, uint time, string thumbnailPath)
        {
            _mediaId = content.MediaId;
            _timeStamp = time;
            if(thumbnailPath != null)
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
