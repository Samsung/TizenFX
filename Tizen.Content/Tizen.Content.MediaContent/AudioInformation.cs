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
    /// AudioContent class API gives the information related to the audio media stored in the device</summary>
    public class AudioInformation : MediaInformation
    {
        private readonly Interop.AudioInformation.SafeAudioInformationHandle _handle;

        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        /// <value> string tag ID</value>
        public override string MediaId
        {
            get
            {
                string mediaId = "";
                int result = Interop.AudioInformation.GetMediaId(_handle, out mediaId);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return mediaId;
            }
        }

        /// <summary>
        ///  Gets the album name.
        /// </summary>
        /// <value> string album name</value>
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
                return album;
            }
        }

        /// <summary>
        ///  Gets the artist name.
        /// </summary>
        /// <value> string artist name</value>
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
                return artist;
            }
        }

        /// <summary>
        ///  Gets the album artist name.
        /// </summary>
        /// <value> string album artist name</value>
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
                return albumArtist;
            }
        }

        /// <summary>
        ///  Gets the genre name.
        /// </summary>
        /// <value> string genre name</value>
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
                return genre;
            }
        }

        /// <summary>
        ///  Gets the composer name.
        /// </summary>
        /// <value> string composer name</value>
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
                return composer;
            }
        }

        /// <summary>
        ///  Gets the year.
        /// </summary>
        /// <value> string year</value>
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
                return year;
            }
        }

        /// <summary>
        ///  Gets the recorded date.
        /// </summary>
        /// <value> string recorded date</value>
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
                return recordedDate;
            }
        }

        /// <summary>
        ///  Gets the copyright notice.
        /// </summary>
        /// <value> string copyright notice</value>
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
                return copyright;
            }
        }

        /// <summary>
        ///  Gets the track number.
        /// </summary>
        /// <value> string track number</value>
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
                return trackNumber;
            }
        }

        /// <summary>
        ///  Gets the bitrate.
        /// </summary>
        /// <value> int bitrate</value>
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
        /// <value> int bit per sample value</value>
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
        ///  Gets the sample rate.
        /// </summary>
        /// <value> int sample rate value</value>
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
        /// <value> int channel value</value>
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
        ///  Gets the track duration.
        /// </summary>
        /// <value> int track duration value</value>
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
        /// Number which represents how many times given audio has been played.
        /// </summary>
        /// <value> bool value </value>
        public new int PlayedCount
        {
            get
            {
                int playedCount = 0;
                int result = Interop.AudioInformation.GetPlayedCount(_handle, out playedCount);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return playedCount;
            }
            set
            {
                int result = Interop.AudioInformation.SetPlayedCount(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "failed to set played count");
                }
            }
        }

        /// <summary>
        ///  Audio's played time parameter.
        /// </summary>
        /// <value> DateTime</value>
        public new DateTime PlayedAt
        {
            get
            {
                DateTime playedAt;
                int time;
                int result = Interop.AudioInformation.GetPlayedTime(_handle, out time);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                DateTime utc;
                if (time != 0)
                {
                    Tizen.Log.Info(Globals.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    playedAt = utc.ToLocalTime();
                }
                else
                {
                    Tizen.Log.Info(Globals.LogTag, "No Date received");
                    playedAt = DateTime.Now;
                }
                return playedAt;
            }

            set
            {
                int result = Interop.AudioInformation.SetPlayedTime(_handle, (int)value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "Failed to SetValue for AudioInfo");
                }
            }
        }

        /// <summary>
        ///  Audio's played position parameter.
        /// </summary>
        /// <value> DateTime</value>
        public int PlayedPosition
        {
            get
            {
                int playedCount = 0;
                int result = Interop.AudioInformation.GetPlayedPosition(_handle, out playedCount);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return playedCount;
            }
            set
            {
                int result = Interop.AudioInformation.SetPlayedPosition(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result, "Failed to set audio played position");
                }
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
        /// Adds a bookmark to the audio
        /// </summary>
        /// <param name="offset">Offset of the audio in seconds</param>
        /// <param name="thumbnailPath">Thumbnail path for the bookmark</param>
        /// <returns></returns>
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
