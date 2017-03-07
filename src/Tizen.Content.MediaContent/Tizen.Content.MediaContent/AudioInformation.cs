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
    /// AudioContent class API gives the information related to the audio media stored in the device
    /// Its purpose is threefold:
    ///     - to provide information about audio content
    ///     - to organize audio content logically(grouping)
    /// </summary>
    public class AudioInformation : MediaInformation
    {
        private readonly Interop.AudioInformation.SafeAudioInformationHandle _handle;

        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        public string MediaId
        {
            get
            {
                string mediaId = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetMediaId(_handle, out mediaId), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Album
        {
            get
            {
                string album = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetAlbum(_handle, out album), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Artist
        {
            get
            {
                string artist = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetArtist(_handle, out artist), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string AlbumArtist
        {
            get
            {
                string albumArtist = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetAlbumArtist(_handle, out albumArtist), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Genre
        {
            get
            {
                string genre = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetGenre(_handle, out genre), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Composer
        {
            get
            {
                string composer = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetComposer(_handle, out composer), "Failed to get value");

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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Year
        {
            get
            {
                string year = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetYear(_handle, out year), "Failed to get value");

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
                    Interop.AudioInformation.GetRecordedDate(_handle, out recordedDate), "Failed to get value");

                if (recordedDate == null)
                {
                    recordedDate = "";
                }
                return recordedDate;
            }
        }

        /// <summary>
        ///  Gets the copyright notice.
        ///  If the media content has no copyright info, the property returns empty string.
        /// </summary>
        public string Copyright
        {
            get
            {
                string copyright = "";
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetCopyright(_handle, out copyright), "Failed to get value");

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
                    Interop.AudioInformation.GetTrackNum(_handle, out trackNumber), "Failed to get value");

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
                    Interop.AudioInformation.GetBitRate(_handle, out bitrate), "Failed to get value");

                return bitrate;
            }
        }

        /// <summary>
        ///  Gets bit per sample.
        /// </summary>
        public int BitPerSample
        {
            get
            {
                int bitPerSample = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetBitPerSample(_handle, out bitPerSample), "Failed to get value");

                return bitPerSample;
            }
        }

        /// <summary>
        ///  Gets the sample rate in hz.
        /// </summary>
        public int SampleRate
        {
            get
            {
                int sampleRate = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetSampleRate(_handle, out sampleRate), "Failed to get value");

                return sampleRate;
            }
        }

        /// <summary>
        ///  Gets the channel.
        /// </summary>
        public int Channel
        {
            get
            {
                int channel = 0;
                MediaContentRetValidator.ThrowIfError(
                    Interop.AudioInformation.GetChannel(_handle, out channel), "Failed to get value");

                return channel;
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
                    Interop.AudioInformation.GetDuration(_handle, out duration), "Failed to get value");

                return duration;
            }
        }

        /// <summary>
        /// Gets the number of MediaBookmark for the passed filter in the given media ID from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
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
        /// Returns the MediaBookmarks for the given media info from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <returns>
        /// Task to get all the Bookmarks
        /// </returns>
        /// <param name="filter"> filter for the Tags</param>
        public Task<IEnumerable<MediaBookmark>> GetMediaBookmarksAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<MediaBookmark>>();

            Collection<MediaBookmark> coll = new Collection<MediaBookmark>();
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaBookmarkCallback callback = (IntPtr handle, IntPtr userData) =>
            {
                IntPtr newHandle;
                MediaContentRetValidator.ThrowIfError(
                    Interop.MediaBookmark.Clone(out newHandle, handle), "Failed to clone");

                coll.Add(new MediaBookmark(newHandle));
                return true;
            };
            MediaContentRetValidator.ThrowIfError(
                Interop.MediaInformation.GetAllBookmarks(MediaId, filterHandle, callback, IntPtr.Zero), "Failed to get value");

            task.SetResult(coll);
            return task.Task;
        }

        /// <summary>
        /// Adds a MediaBookmark to the audio
        /// </summary>
        /// <param name="offset">Offset of the audio in seconds</param>
        /// <returns>
        /// Task with newly added MediaBookmark instance.
        /// </returns>
        public async Task<MediaBookmark> AddBookmark(uint offset)
        {
            MediaBookmark result = null;
            ContentManager.Database.Insert(MediaId, offset, null);
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
        /// Deletes a MediaBookmark item from the media database.
        /// </summary>
        /// <param name="bookmark">The MediaBookmark instance to be deleted</param>
        public void DeleteBookmark(MediaBookmark bookmark)
        {
            ContentManager.Database.Delete(bookmark);
        }

        internal IntPtr AudioHandle
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        internal AudioInformation(Interop.AudioInformation.SafeAudioInformationHandle handle, Interop.MediaInformation.SafeMediaInformationHandle mediaInformationHandle)
            : base(mediaInformationHandle)
        {
            _handle = handle;
        }
    }
}
