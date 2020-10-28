/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Network.Mtp
{
    /// <summary>
    /// Enumeration for Mtp storage type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MtpStorageType
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// fixed ROM
        /// </summary>
        FixedRom = 1,
        /// <summary>
        /// removable ROM
        /// </summary>
        RemovableRom = 2,
        /// <summary>
        /// fixed RAM
        /// </summary>
        FixedRam = 3,
        /// <summary>
        /// removable RAM
        /// </summary>
        RemovableRam = 4
    }

    /// <summary>
    /// Enumeration for Mtp file type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MtpFileType
    {
        /// <summary> 
        /// Folder
        /// </summary>
        Folder = 0,
        /// <summary>
        /// Wav
        /// </summary>
        Wav = 1,
        /// <summary>
        /// Mp3
        /// </summary>
        Mp3 = 2,
        /// <summary>
        /// Wma
        /// </summary>
        Wma = 3,
        /// <summary>
        /// Ogg
        /// </summary>
        Ogg = 4,
        /// <summary> 
        /// Audible
        /// </summary>
        Audible = 5,
        /// <summary>
        /// Mp4
        /// </summary>
        Mp4 = 6,
        /// <summary>
        /// UndefAudio
        /// </summary>
        UndefAudio = 7,
        /// <summary>
        /// Wmv
        /// </summary>
        Wmv = 8,
        /// <summary>
        /// Avi
        /// </summary>
        Avi = 9,
        /// <summary> 
        /// Mpeg
        /// </summary>
        Mpeg = 10,
        /// <summary>
        /// Asf
        /// </summary>
        Asf = 11,
        /// <summary>
        /// Qt
        /// </summary>
        Qt = 12,
        /// <summary>
        /// UndefVideo
        /// </summary>
        UndefVideo = 13,
        /// <summary>
        /// Jpeg
        /// </summary>
        Jpeg = 14,
        /// <summary> 
        /// Jfif
        /// </summary>
        Jfif = 15,
        /// <summary>
        /// Tiff
        /// </summary>
        Tiff = 16,
        /// <summary>
        /// Bmp
        /// </summary>
        Bmp = 17,
        /// <summary>
        /// Gif
        /// </summary>
        Gif = 18,
        /// <summary>
        /// Pict
        /// </summary>
        Pict = 19,
        /// <summary> 
        /// Png
        /// </summary>
        Png = 20,
        /// <summary>
        /// Vcalendar1
        /// </summary>
        Vcalendar1 = 21,
        /// <summary>
        /// Vcalendar2
        /// </summary>
        Vcalendar2 = 22,
        /// <summary>
        /// Vcard2
        /// </summary>
        Vcard2 = 23,
        /// <summary>
        /// Vcard3
        /// </summary>
        Vcard3 = 24,
        /// <summary> 
        /// WindowsImageFormat
        /// </summary>
        WindowsImageFormat = 25,
        /// <summary>
        /// WinExec
        /// </summary>
        WinExec = 26,
        /// <summary>
        /// Text
        /// </summary>
        Text = 27,
        /// <summary>
        /// Html
        /// </summary>
        Html = 28,
        /// <summary>
        /// Firmware
        /// </summary>
        Firmware = 29,
        /// <summary> 
        /// Aac
        /// </summary>
        Aac = 30,
        /// <summary>
        /// Mediacard
        /// </summary>
        Mediacard = 31,
        /// <summary>
        /// Flac
        /// </summary>
        Flac = 32,
        /// <summary>
        /// Mp2
        /// </summary>
        Mp2 = 33,
        /// <summary>
        /// M4a
        /// </summary>
        M4a = 34,
        /// <summary> 
        /// Doc
        /// </summary>
        Doc = 35,
        /// <summary>
        /// Xml
        /// </summary>
        Xml = 36,
        /// <summary>
        /// Xls
        /// </summary>
        Xls = 37,
        /// <summary>
        /// Ppt
        /// </summary>
        Ppt = 38,
        /// <summary>
        /// Mht
        /// </summary>
        Mht = 39,
        /// <summary> 
        /// Jp2
        /// </summary>
        Jp2 = 40,
        /// <summary>
        /// Jpx
        /// </summary>
        Jpx = 41,
        /// <summary>
        /// Album
        /// </summary>
        Album = 42,
        /// <summary>
        /// Playlist
        /// </summary>
        Playlist = 43,
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 44,
        /// <summary> 
        /// All (Helper type)
        /// </summary>
        All = 45,
        /// <summary>
        /// All Image (Helper type)
        /// </summary>
        AllImage = 46
    }

    /// <summary>
    /// Enumeration for Mtp Event type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MtpEventType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// Storage Added
        /// </summary>
        StorageAdded,
        /// <summary>
        /// Storage Removed
        /// </summary>
        StorageRemoved,
        /// <summary>
        /// Object Added
        /// </summary>
        ObjectAdded,
        /// <summary>
        /// Object Removed
        /// </summary>
        ObjectRemoved,
        /// <summary>
        /// Device Added
        /// </summary>
        DeviceAdded,
        /// <summary>
        /// Device Removed
        /// </summary>
        DeviceRemoved,
        /// <summary>
        /// Turned Off
        /// </summary>
        TurnedOff
    }
}
