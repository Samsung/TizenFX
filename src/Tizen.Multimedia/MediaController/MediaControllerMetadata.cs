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
        /// <summary>
        /// The constructor of MediaControllerMetadata class.
        /// </summary>
        public MediaControllerMetadata()
        {
            // Do nothing
        }

        internal MediaControllerMetadata(IntPtr _handle) {
            string _title;
            string _artist;
            string _album;
            string _author;
            string _genre;
            string _duration;
            string _date;
            string _copyright;
            string _description;
            string _track_number;
            string _picture;

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Title, out _title),
                    "Get Title failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Artist, out _artist),
                    "Get Artist failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Album, out _album),
                    "Get Album failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Author, out _author),
                    "Get Author failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Genre, out _genre),
                    "Get Genre failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Duration, out _duration),
                    "Get Duration failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Date, out _date),
                    "Get Date failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Copyright, out _copyright),
                    "Get Copyright failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Description, out _description),
                    "Get Description failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.TrackNumber, out _track_number),
                    "Get TrackNumber failed");

            MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetMetadata(_handle, MediaControllerAttributes.Picture, out _picture),
                    "Get Picture failed");

            Title = _title;
            Artist = _artist;
            Album = _album;
            Author = _author;
            Genre = _genre;
            Duration = _duration;
            Date = _date;
            Copyright = _copyright;
            Description = _description;
            TrackNumber = _track_number;
            Picture = _picture;
        }

        /// <summary>
        /// Set/Get the Title of media
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Set/Get the Artist of media
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Set/Get the Album of media
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Set/Get the Author of media
        /// </summary>
        public string Author { get; set; }
 
        /// <summary>
        /// Set/Get the Genre of media
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Set/Get the Duration of media
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Set/Get the Date of media
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Set/Get the Copyright of media
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Set/Get the Description of media
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set/Get the Track Number of media
        /// </summary>
        public string TrackNumber { get; set; }

        /// <summary>
        /// Set/Get the Picture of media
        /// </summary>
        public string Picture { get; set; }
    }
}

