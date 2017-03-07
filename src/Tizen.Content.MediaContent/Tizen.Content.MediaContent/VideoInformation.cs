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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// VideoContent class API gives the information related to the image media stored in the device</summary>
    public class VideoInformation : MediaInformation
    {
        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        public string MediaId
        {
            get
            {
                string mediaId = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetMediaId(_handle, out mediaId), "Failed to get value");

                if (mediaId == null)
                {
                    mediaId = "";
                }
                return mediaId;
            }
        }

        /// <summary>
        ///  Gets the album name.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Album
        {
            get
            {
                string album = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetAlbum(_handle, out album), "Failed to get value");

                if (album == null)
                {
                    album = "";
                }
                return album;
            }
        }

        /// <summary>
        ///  Gets the artist name.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Artist
        {
            get
            {
                string artist = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetArtist(_handle, out artist), "Failed to get value");

                if (artist == null)
                {
                    artist = "";
                }
                return artist;
            }
        }

        /// <summary>
        ///  Gets the album artist name.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string AlbumArtist
        {
            get
            {
                string albumArtist = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetAlbumArtist(_handle, out albumArtist), "Failed to get value");

                if (albumArtist == null)
                {
                    albumArtist = "";
                }
                return albumArtist;
            }
        }

        /// <summary>
        ///  Gets the genre name.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Genre
        {
            get
            {
                string genre = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetGenre(_handle, out genre), "Failed to get value");

                if (genre == null)
                {
                    genre = "";
                }
                return genre;
            }
        }

        /// <summary>
        ///  Gets the composer name.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Composer
        {
            get
            {
                string composer = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetComposer(_handle, out composer), "Failed to get value");

                if (composer == null)
                {
                    composer = "";
                }
                return composer;
            }
        }

        /// <summary>
        ///  Gets the year.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Year
        {
            get
            {
                string year = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetYear(_handle, out year), "Failed to get value");

                if (year == null)
                {
                    year = "";
                }
                return year;
            }
        }

        /// <summary>
        ///  Gets the recorded date.
        /// </summary>
        public string RecordedDate
        {
            get
            {
                string recordedDate = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetRecordedDate(_handle, out recordedDate), "Failed to get value");

                if (recordedDate == null)
                {
                    recordedDate = "";
                }
                return recordedDate;
            }
        }

        /// <summary>
        ///  Gets the copyright notice.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string Copyright
        {
            get
            {
                string copyright = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetCopyright(_handle, out copyright), "Failed to get value");

                if (copyright == null)
                {
                    copyright = "";
                }
                return copyright;
            }
        }

        /// <summary>
        ///  Gets the track number.
        ///  If the value is an empty string, the property returns "Unknown".
        /// </summary>
        public string TrackNumber
        {
            get
            {
                string trackNumber = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetTrackNum(_handle, out trackNumber), "Failed to get value");

                if (trackNumber == null)
                {
                    trackNumber = "";
                }
                return trackNumber;
            }
        }

        /// <summary>
        ///  Gets the bitrate in bit per second [bps].
        /// </summary>
        public int BitRate
        {
            get
            {
                int bitrate = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetBitRate(_handle, out bitrate), "Failed to get value");

                return bitrate;
            }
        }

        /// <summary>
        ///  Gets the track duration in Milliseconds.
        /// </summary>
        public int Duration
        {
            get
            {
                int duration = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetDuration(_handle, out duration), "Failed to get value");

                return duration;
            }
        }

        /// <summary>
        ///  Gets the video width in pixels.
        /// </summary>
        public int Width
        {
            get
            {
                int width = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetWidth(_handle, out width), "Failed to get value");

                return width;
            }
        }

        /// <summary>
        ///  Gets the video height in pixels.
        /// </summary>
        public int Height
        {
            get
            {
                int height = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.VideoInformation.GetHeight(_handle, out height), "Failed to get value");

                return height;
            }
        }

        /// <summary>
        /// Gets the number of bookmarks for the passed filter in the given media ID from the media database.
        /// </summary>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching Bookmarks</param>
        public int GetMediaBookmarkCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentRetValidator.ThrowIfError(
                Interop.MediaInformation.GetBookmarkCount(MediaId, handle, out count), "Failed to get count");

            return count;
        }

        /// <summary>
        /// Iterates through the media bookmark in the given media info from the media database.
        /// </summary>
        /// <returns>
        /// Task to get all the Bookmarks </returns>
        /// <param name="filter"> filter for the Tags</param>
        public Task<IEnumerable<MediaBookmark>> GetMediaBookmarksAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<MediaBookmark>>();

            Collection<MediaBookmark> coll = new Collection<MediaBookmark>();
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaBookmarkCallback bookmarksCallback = (IntPtr handle, IntPtr userData) =>
            {
                IntPtr newHandle;
                MediaContentRetValidator.ThrowIfError(
                    Interop.MediaBookmark.Clone(out newHandle, handle), "Failed to clone Tag");
                coll.Add(new MediaBookmark(newHandle));
                return true;
            };
            MediaContentRetValidator.ThrowIfError(
                Interop.MediaInformation.GetAllBookmarks(MediaId, filterHandle, bookmarksCallback, IntPtr.Zero), "Failed to get value");

            task.SetResult(coll);
            return task.Task;
        }

        /// <summary>
        /// Adds a bookmark to the video
        /// </summary>
        /// <param name="offset">Offset of the video in seconds</param>
        /// <param name="thumbnailPath">Thumbnail path for the bookmark</param>
        /// <returns></returns>
        public async Task<MediaBookmark> AddBookmark(uint offset, string thumbnailPath)
        {
            MediaBookmark result = null;
            ContentManager.Database.Insert(MediaId, offset, thumbnailPath);
            ContentFilter bookmarkfilter = new ContentFilter();
            bookmarkfilter.Condition = "BOOKMARK_MARKED_TIME = " + offset;
            IEnumerable<MediaBookmark> bookmarksList = null;
            bookmarksList = await GetMediaBookmarksAsync(bookmarkfilter);
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
