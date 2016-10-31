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
                int result = Interop.VideoInformation.GetMediaId(_handle, out mediaId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetAlbum(_handle, out album);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetArtist(_handle, out artist);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetAlbumArtist(_handle, out albumArtist);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetGenre(_handle, out genre);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetComposer(_handle, out composer);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetYear(_handle, out year);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetRecordedDate(_handle, out recordedDate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetCopyright(_handle, out copyright);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetTrackNum(_handle, out trackNumber);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetBitRate(_handle, out bitrate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetDuration(_handle, out duration);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetWidth(_handle, out width);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.VideoInformation.GetHeight(_handle, out height);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return height;
            }
        }

        /// <summary>
        /// Gets the number of bookmarks for the passed filter in the given media ID from the media database.
        /// </summary>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching BookMarks</param>
        public int GetMediaBookMarkCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError result = (MediaContentError)Interop.MediaInformation.GetBookmarkCount(MediaId, handle, out count);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Error Occured with error code: ");
            }
            return count;
        }

        /// <summary>
        /// Iterates through the media bookmark in the given media info from the media database.
        /// </summary>
        /// <returns>
        /// Task to get all the BookMarks </returns>
        /// <param name="filter"> filter for the Tags</param>
        public Task<IEnumerable<MediaBookmark>> GetMediaBookmarksAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<MediaBookmark>>();
            MediaContentError result;
            Collection<MediaBookmark> coll = new Collection<MediaBookmark>();
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaBookMarkCallback bookmarksCallback = (IntPtr handle, IntPtr userData) =>
            {
                IntPtr newHandle;
                result = (MediaContentError)Interop.MediaBookmark.Clone(out newHandle, handle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to clone Tag");
                }
                MediaBookmark bookmark = new MediaBookmark(newHandle);
                coll.Add(bookmark);
                return true;
            };
            result = (MediaContentError)Interop.MediaInformation.GetAllBookmarks(MediaId, filterHandle, bookmarksCallback, IntPtr.Zero);
            if (result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
            }
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
