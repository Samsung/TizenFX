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
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class AudioInfo
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbum(IntPtr handle, out IntPtr albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetArtist(IntPtr handle, out IntPtr artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbumArtist(IntPtr handle, out IntPtr albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_genre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetGenre(IntPtr handle, out IntPtr genreName);


        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_year", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetYear(IntPtr handle, out IntPtr year);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_track_num", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTrackNum(IntPtr handle, out IntPtr trackNum);
    }
}
