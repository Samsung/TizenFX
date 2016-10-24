/// Metadata
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;

namespace Tizen.Multimedia.MediaController
{
	/// <summary>
	/// Metadata represents a metadata of media for server application to play
	/// </summary>
	public class Metadata
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

		internal Metadata(IntPtr _metadataHandle) {
			MediaControllerError res = MediaControllerError.None;

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Title, out Title);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Artist, out Artist);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Album, out Album);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Author, out Author);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Duration, out Duration);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Date, out Date);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Copyright, out Copyright);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Description, out Description);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.TrackNumber, out TrackNumber);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.GetMetadata(_metadataHandle, (int)Attributes.Picture, out Picture);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Get Metadata failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Get Metadata failed");
			}

			res = (MediaControllerError)Interop.MediaControllerClient.DestroyMetadata(_metadataHandle);
			if(res != MediaControllerError.None)
			{
				Log.Error(MediaControllerLog.LogTag, "Destroy Metadata handle failed" + res);
				MediaControllerErrorFactory.ThrowException(res, "Destroy Metadata handle failed");
			}
		}
	}
}

