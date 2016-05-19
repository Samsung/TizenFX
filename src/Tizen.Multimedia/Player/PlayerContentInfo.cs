/// PlayerContentInfo
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// PlayerContentInfo
    /// </summary>
    /// <remarks>
    /// This class provides properties for metadata information of media file.
    /// </remarks>

    public class PlayerContentInfo
    {
		enum ContentInfoKey
		{
			Album,
			Artist,
			Author,
			Genre,
			Title,
			Year
		}

        /// <summary>
        /// Metadata - Album
        /// </summary>
        /// <value> album string </value>
        public string Album
        {
            get
            {
				string album;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Album, out album);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get album info" + (PlayerError)ret);
				}
                return album;
            }
        }

        /// <summary>
        /// Metadata - Artist
        /// </summary>
        /// <value> artist string </value>
        public string Artist
        {
            get
            {
				string artist;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Artist, out artist);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get artist info" + (PlayerError)ret);
				}

				return artist;
            }
        }

        /// <summary>
        /// Metadata - Author
        /// </summary>
        /// <value> Author string </value>
        public string Author
        {
            get
            {
				string author;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Author, out author);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get author info" + (PlayerError)ret);
				}
				return author;
            }
        }

        /// <summary>
        /// Metadata - Genre
        /// </summary>
        /// <value> genre string </value>
        public string Genre
        {
            get
            {
				string genre;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Genre, out genre);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get genre info" + (PlayerError)ret);
				}

				return genre;
            }
        }

        /// <summary>
        /// Metadata - Title
        /// </summary>
        /// <value> title string </value>
        public string Title
        {
            get
            {
				string title;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Title, out title);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get title info" + (PlayerError)ret);
				}
				return title;
            }
        }

        /// <summary>
        /// Metadata - Year
        /// </summary>
        /// <value> year string </value>
        public string Year
        {
            get
            {
				string year;
				int ret = Interop.Player.GetContentInfo (_playerHandle, (int)ContentInfoKey.Year, out year);
				if (ret != (int)PlayerError.None) 
				{
					Log.Error (PlayerLog.LogTag, "Failed to get title info" + (PlayerError)ret);
				}
				return year;
            }
        }

		internal IntPtr _playerHandle;
    }
}
