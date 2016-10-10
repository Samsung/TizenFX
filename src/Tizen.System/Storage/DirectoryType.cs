// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.System
{
    /// <summary>
    /// Enumeration of the storage directory types.
    /// </summary>
    public enum DirectoryType
    {
        /// <summary>
        /// Image directory
        /// </summary>
        Images = Interop.Storage.DirectoryType.Images,
        /// <summary>
        /// Sounds directory
        /// </summary>
        Sounds = Interop.Storage.DirectoryType.Sounds,
        /// <summary>
        /// Videos directory
        /// </summary>
        Videos = Interop.Storage.DirectoryType.Videos,
        /// <summary>
        /// Camera directory
        /// </summary>
        Camera = Interop.Storage.DirectoryType.Camera,
        /// <summary>
        /// Downloads directory
        /// </summary>
        Downloads = Interop.Storage.DirectoryType.Downloads,
        /// <summary>
        /// Music directory
        /// </summary>
        Music = Interop.Storage.DirectoryType.Music,
        /// <summary>
        /// Documents directory
        /// </summary>
        Documents = Interop.Storage.DirectoryType.Documents,
        /// <summary>
        /// Others directory
        /// </summary>
        Others = Interop.Storage.DirectoryType.Others,
        /// <summary>
        /// System ringtones directory. Only available for internal storage.
        /// </summary>
        Ringtones = Interop.Storage.DirectoryType.Ringtones,
    }
}