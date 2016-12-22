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

namespace Tizen.Multimedia.MediaController
{
    /// <summary>
    /// Metadata represents a metadata of media for server application to play
    /// </summary>
    public class MediaControllerMetadata
    {
        private string _title;
        private string _artist;
        private string _album;
        private string _author;
        private string _genre;
        private string _duration;
        private string _date;
        private string _copyright;
        private string _description;
        private string _track_number;
        private string _picture;

        /// <summary>
        /// The constructor of MediaControllerMetadata class.
        /// </summary>
        public MediaControllerMetadata()
        {
            _title = null;
            _artist = null;
            _album = null;
            _author = null;
            _genre = null;
            _duration = null;
            _date = null;
            _copyright = null;
            _description = null;
            _track_number = null;
            _picture = null;
        }

        internal MediaControllerMetadata(IntPtr _metadataHandle) {
            MediaControllerError res = MediaControllerError.None;

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Title, out _title);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Artist, out _artist);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Album, out _album);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Author, out _author);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Genre, out _genre);
            if (res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Duration, out _duration);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Date, out _date);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Copyright, out _copyright);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Description, out _description);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.TrackNumber, out _track_number);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Picture, out _picture);
            if(res != MediaControllerError.None)
            {
            Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
            MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }
        }

        /// <summary>
        /// Set/Get the Title of media
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set {
                _title = value;
            }
        }

        /// <summary>
        /// Set/Get the Artist of media
        /// </summary>
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
            }
        }

        /// <summary>
        /// Set/Get the Album of media
        /// </summary>
        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
            }
        }

        /// <summary>
        /// Set/Get the Author of media
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        /// <summary>
        /// Set/Get the Genre of media
        /// </summary>
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }

        /// <summary>
        /// Set/Get the Duration of media
        /// </summary>
        public string Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        /// <summary>
        /// Set/Get the Date of media
        /// </summary>
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        /// <summary>
        /// Set/Get the Copyright of media
        /// </summary>
        public string Copyright
        {
            get
            {
                return _copyright;
            }
            set
            {
                _copyright = value;
            }
        }

        /// <summary>
        /// Set/Get the Description of media
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Set/Get the Track Number of media
        /// </summary>
        public string TrackNumber
        {
            get
            {
                return _track_number;
            }
            set
            {
                _track_number = value;
            }
        }

        /// <summary>
        /// Set/Get the Picture of media
        /// </summary>
        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }
    }
}

