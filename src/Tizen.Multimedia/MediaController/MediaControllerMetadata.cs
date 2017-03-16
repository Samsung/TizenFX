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

        internal MediaControllerMetadata(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("MediaControllerMetadata is not valid.");
            }

            Title = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Title);
            Artist = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Artist);
            Album = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Album);
            Author = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Author);
            Genre = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Genre);
            Duration = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Duration);
            Date = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Date);
            Copyright = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Copyright);
            Description = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Description);
            TrackNumber = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.TrackNumber);
            Picture = Interop.MediaControllerClient.GetMetadata(handle, MediaControllerAttributes.Picture);
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

