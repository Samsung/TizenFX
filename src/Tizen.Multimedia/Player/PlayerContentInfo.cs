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
using System.Runtime.InteropServices;

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
        internal IntPtr _playerHandle;

        internal PlayerContentInfo()
        {
        }

        private string GetContentInfo(ContentInfoKey key)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                int ret = Interop.Player.GetContentInfo(_playerHandle, (int)key, out ptr);
                if (ret != (int)PlayerError.None)
                {
                    Log.Error(PlayerLog.LogTag, "Failed to get album info" + (PlayerError)ret);
                    return "";
                }

                return Marshal.PtrToStringAnsi(ptr);
            }
            finally
            {
                Interop.Libc.Free(ptr);
            }
        }

        /// <summary>
        /// Metadata - Album
        /// </summary>
        /// <value> album string </value>
        public string Album
        {
            get
            {
                return GetContentInfo(ContentInfoKey.Album);
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
                return GetContentInfo(ContentInfoKey.Artist);
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
                return GetContentInfo(ContentInfoKey.Author);
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
                return GetContentInfo(ContentInfoKey.Genre);
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
                return GetContentInfo(ContentInfoKey.Title);
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
                return GetContentInfo(ContentInfoKey.Year);
            }
        }

    }
}
