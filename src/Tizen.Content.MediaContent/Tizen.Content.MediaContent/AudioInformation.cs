/// This File contains the Api's related to the AudioContent class
///
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
                int result = Interop.AudioInformation.GetMediaId(_handle, out mediaId);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Album
        {
            get
            {
                string album = "";
                int result = Interop.AudioInformation.GetAlbum(_handle, out album);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Artist
        {
            get
            {
                string artist = "";
                int result = Interop.AudioInformation.GetArtist(_handle, out artist);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string AlbumArtist
        {
            get
            {
                string albumArtist = "";
                int result = Interop.AudioInformation.GetAlbumArtist(_handle, out albumArtist);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Genre
        {
            get
            {
                string genre = "";
                int result = Interop.AudioInformation.GetGenre(_handle, out genre);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Composer
        {
            get
            {
                string composer = "";
                int result = Interop.AudioInformation.GetComposer(_handle, out composer);
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
        ///  If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Year
        {
            get
            {
                string year = "";
                int result = Interop.AudioInformation.GetYear(_handle, out year);
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
                int result = Interop.AudioInformation.GetRecordedDate(_handle, out recordedDate);
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
        ///  If the media content has no copyright info, the property returns empty string.
        /// </summary>
        public string Copyright
        {
            get
            {
                string copyright = "";
                int result = Interop.AudioInformation.GetCopyright(_handle, out copyright);
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
                int result = Interop.AudioInformation.GetTrackNum(_handle, out trackNumber);
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
                int result = Interop.AudioInformation.GetBitRate(_handle, out bitrate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.AudioInformation.GetBitPerSample(_handle, out bitPerSample);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.AudioInformation.GetSampleRate(_handle, out sampleRate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.AudioInformation.GetChannel(_handle, out channel);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
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
                int result = Interop.AudioInformation.GetDuration(_handle, out duration);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return duration;
            }
        }

        /// <summary>
        /// Gets the number of MediaBookMark for the passed filter in the given media ID from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
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
        /// Returns the MediaBookmarks for the given media info from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <returns>
        /// Task to get all the BookMarks
        /// </returns>
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
        /// Adds a MediaBookMark to the audio
        /// </summary>
        /// <param name="offset">Offset of the audio in seconds</param>
        /// <returns>
        /// Task with newly added MediaBookMark instance.
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
        /// Deletes a MediaBookMark item from the media database.
        /// </summary>
        /// <param name="bookmark">The MediaBookMark instance to be deleted</param>
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
