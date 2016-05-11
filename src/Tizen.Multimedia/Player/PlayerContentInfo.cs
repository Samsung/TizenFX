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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Album, out album) != 0) {
					// throw Exception;
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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Artist, out artist) != 0) {
					// throw Exception;
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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Author, out author) != 0) {
					// throw Exception;
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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Genre, out genre) != 0) {
					// throw Exception;
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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Title, out title) != 0) {
					// throw Exception;
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
				if (Interop.PlayerInterop.GetContentInfo (_playerHandle, (int)ContentInfoKey.Year, out year) != 0) {
					// throw Exception;
				}
				return year;
            }
        }

		internal IntPtr _playerHandle;
    }
}
