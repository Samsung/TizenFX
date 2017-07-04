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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// VideoContent class API gives the information related to the image media stored in the device
    /// </summary>
    public class VideoInformation : MediaInformation
    {
        /// <summary>
        ///  Gets the ID of the media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MediaId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetMediaId(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the album name.
        ///  If the media content has no album information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Album
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetAlbum(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the artist name.
        ///  If the media content has no artist information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Artist
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetArtist(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the album artist name.
        ///  If the media content has no album artist information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string AlbumArtist
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetAlbumArtist(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the genre name.
        ///  If the media content has no genre information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Genre
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetGenre(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the composer name.
        ///  If the media content has no composer information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Composer
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetComposer(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the year.
        ///  If the media content has no year information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Year
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetYear(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the recorded date.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string RecordedDate
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetRecordedDate(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the copyright notice.
        ///  If the media content has no copyright information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Copyright
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetCopyright(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the track number.
        ///  If the media content has no track information, the property returns empty string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TrackNumber
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.VideoInformation.GetTrackNum(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the bitrate in bit per second [bps].
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int BitRate
        {
            get
            {
                int bitrate = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.VideoInformation.GetBitRate(_handle, out bitrate), "Failed to get value");

                return bitrate;
            }
        }

        /// <summary>
        ///  Gets the track duration in Milliseconds.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Duration
        {
            get
            {
                int duration = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.VideoInformation.GetDuration(_handle, out duration), "Failed to get value");

                return duration;
            }
        }

        /// <summary>
        ///  Gets the video width in pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Width
        {
            get
            {
                int width = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.VideoInformation.GetWidth(_handle, out width), "Failed to get value");

                return width;
            }
        }

        /// <summary>
        ///  Gets the video height in pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Height
        {
            get
            {
                int height = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.VideoInformation.GetHeight(_handle, out height), "Failed to get value");

                return height;
            }
        }

        /// <summary>
        /// Gets the number of bookmarks for the passed filter in the given media ID from the media database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching Bookmarks</param>
        public int GetMediaBookmarkCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetBookmarkCount(MediaId, handle, out count), "Failed to get count");

            return count;
        }

        /// <summary>
        /// Iterates through the media bookmark in the given media info from the media database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// Task to get all the Bookmarks </returns>
        /// <param name="filter"> filter for the Tags</param>
        public IEnumerable<MediaBookmark> GetMediaBookmarks(ContentFilter filter)
        {
            Collection<MediaBookmark> result = new Collection<MediaBookmark>();
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaBookmarkCallback callback = (IntPtr handle, IntPtr userData) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaBookmark.Clone(out newHandle, handle), "Failed to clone Tag");
                result.Add(new MediaBookmark(newHandle));
                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetAllBookmarks(MediaId, filterHandle, callback, IntPtr.Zero), "Failed to get value");

            return result;
        }

        /// <summary>
        /// Adds a bookmark to the video
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="offset">Offset of the video in seconds</param>
        /// <param name="thumbnailPath">Thumbnail path for the bookmark</param>
        /// <returns>Task with added MediaBookmark instance </returns>
        public MediaBookmark AddBookmark(uint offset, string thumbnailPath)
        {
            MediaBookmark result = null;
            ContentManager.Database.Insert(MediaId, offset, thumbnailPath);
            ContentFilter bookmarkfilter = new ContentFilter();
            bookmarkfilter.Condition = ContentColumns.Bookmark.Offset + " = " + offset;
            IEnumerable<MediaBookmark> bookmarksList = null;
            bookmarksList = GetMediaBookmarks(bookmarkfilter);
            foreach (MediaBookmark bookmark in bookmarksList)
            {
                if (bookmark.Offset == offset)
                {
                    result = bookmark;
                    break;
                }
            }

            bookmarkfilter.Dispose();
            return result;
        }

        /// <summary>
        /// Deletes a bookmark from the media database.
        /// For other types Unsupported exception is thrown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="bookmark">The bookmark to be deleted</param>
        public void DeleteBookmark(MediaBookmark bookmark)
        {
            ContentManager.Database.Delete(bookmark);
        }

        internal IntPtr VideoHandle
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        private readonly Interop.VideoInformation.SafeVideoInformationHandle _handle;

        internal VideoInformation(Interop.VideoInformation.SafeVideoInformationHandle handle, Interop.MediaInformation.SafeMediaInformationHandle mediaInformationHandle)
            : base(mediaInformationHandle)
        {
            _handle = handle;
        }
    }
}
