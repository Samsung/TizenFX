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
		/// The title of media
		/// </summary>
		public string Title;

		/// <summary>
		/// The artist of media
		/// </summary>
		public string Artist;

		/// <summary>
		/// The album of media
		/// </summary>
		public string Album;

		/// <summary>
		/// The author of media
		/// </summary>
		public string Author;

		/// <summary>
		/// The genre of media
		/// </summary>
		public string Genre;

		/// <summary>
		/// The duration of media
		/// </summary>
		public string Duration;

		/// <summary>
		/// The date of media
		/// </summary>
		public string Date;

		/// <summary>
		/// The copyright of media
		/// </summary>
		public string Copyright;

		/// <summary>
		/// The description of media
		/// </summary>
		public string Description;

		/// <summary>
		/// The track number of media
		/// </summary>
		public string TrackNumber;

		/// <summary>
		/// The picture of media
		/// </summary>
		public string Picture;

        public MediaControllerMetadata()
        {

        }

        internal MediaControllerMetadata(IntPtr _metadataHandle) {
			MediaControllerError res = MediaControllerError.None;

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Title, out Title);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Artist, out Artist);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Album, out Album);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Author, out Author);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Genre, out Genre);
            if (res != MediaControllerError.None)
            {
                Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
                MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
            }

            res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Duration, out Duration);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Date, out Date);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Copyright, out Copyright);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Description, out Description);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.TrackNumber, out TrackNumber);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)MediaControllerAttributes.Picture, out Picture);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}
		}
	}
}

