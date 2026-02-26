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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class AudioInfo
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_destroy")]
        internal static extern MediaContentError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album")]
        internal static extern MediaContentError GetAlbum(IntPtr handle, out IntPtr albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_artist")]
        internal static extern MediaContentError GetArtist(IntPtr handle, out IntPtr artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album_artist")]
        internal static extern MediaContentError GetAlbumArtist(IntPtr handle, out IntPtr albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_genre")]
        internal static extern MediaContentError GetGenre(IntPtr handle, out IntPtr genreName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_composer")]
        internal static extern MediaContentError GetComposer(IntPtr handle, out IntPtr composerName); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_year")]
        internal static extern MediaContentError GetYear(IntPtr handle, out IntPtr year);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_recorded_date")]
        internal static extern MediaContentError GetRecordedDate(IntPtr handle, out IntPtr recordedDate); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_copyright")]
        internal static extern MediaContentError GetCopyright(IntPtr handle, out IntPtr copyright); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_track_num")]
        internal static extern MediaContentError GetTrackNum(IntPtr handle, out IntPtr trackNum);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bit_rate")]
        internal static extern MediaContentError GetBitRate(IntPtr handle, out int bitRate); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bitpersample")]
        internal static extern MediaContentError GetBitPerSample(IntPtr handle, out int bitPerSample); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_sample_rate")]
        internal static extern MediaContentError GetSampleRate(IntPtr handle, out int sampleRate); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_channel")]
        internal static extern MediaContentError GetChannel(IntPtr handle, out int channel); // Deprecated since API12

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_duration")]
        internal static extern MediaContentError GetDuration(IntPtr handle, out int duration); // Deprecated since API12
    }
}




