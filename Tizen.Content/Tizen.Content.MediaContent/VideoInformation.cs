/// This File contains the Api's related to the VideoContent class
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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// VideoContent class API gives the information related to the image media stored in the device</summary>
    public class VideoInformation : MediaInformation
    {
        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        /// <value> string tag ID</value>
        public override string MediaId
        {
            get
            {
                string mediaId = "";
                int result = Interop.VideoInformation.GetMediaId(_handle, out mediaId);
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
                int result = Interop.VideoInformation.GetAlbum(_handle, out album);
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
                int result = Interop.VideoInformation.GetArtist(_handle, out artist);
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
                int result = Interop.VideoInformation.GetAlbumArtist(_handle, out albumArtist);
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
                int result = Interop.VideoInformation.GetGenre(_handle, out genre);
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
                int result = Interop.VideoInformation.GetComposer(_handle, out composer);
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
                int result = Interop.VideoInformation.GetYear(_handle, out year);
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
                int result = Interop.VideoInformation.GetRecordedDate(_handle, out recordedDate);
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
                int result = Interop.VideoInformation.GetCopyright(_handle, out copyright);
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
                int result = Interop.VideoInformation.GetTrackNum(_handle, out trackNumber);
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
                int result = Interop.VideoInformation.GetBitRate(_handle, out bitrate);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return bitrate;
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
        /// <value> int video width value</value>
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
        /// <value> int video height value</value>
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
        /// Number which represents how many times given vidoe has been played.
        /// </summary>
        /// <value> bool value </value>
        public new int PlayedCount
        {
            get
            {
                int playedCount = 0;
                int result = Interop.VideoInformation.GetPlayedCount(_handle, out playedCount);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return playedCount;
            }
            set
            {
                int result = Interop.VideoInformation.SetPlayedCount(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result,"Failed to set played count");
                }
            }
        }

        /// <summary>
        ///  Video's played time parameter.
        /// </summary>
        /// <value> DateTime</value>
        public new DateTime PlayedAt
        {
            get
            {
                DateTime playedAt;
                int time;
                int result = Interop.VideoInformation.GetPlayedTime(_handle, out time);
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
                int result = Interop.VideoInformation.SetPlayedTime(_handle, (int)value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result,"failed to set played time");
                }
            }
        }

        /// <summary>
        ///  Video's played position parameter.
        /// </summary>
        /// <value> DateTime</value>
        public int PlayedPosition
        {
            get
            {
                int playedCount = 0;
                int result = Interop.VideoInformation.GetPlayedPosition(_handle, out playedCount);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                }
                return playedCount;
            }
            set
            {
                int result = Interop.VideoInformation.SetPlayedPosition(_handle, value);
                if ((MediaContentError)result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException((MediaContentError)result,"failed to set played position");
                }
            }
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
