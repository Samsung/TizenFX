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
using System.Diagnostics;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents an audio media information.
    /// </summary>
    public class AudioInfo : MediaInfo
    {
        internal AudioInfo(Interop.MediaInfoHandle handle) : base(handle)
        {
            IntPtr audioHandle = IntPtr.Zero;

            try
            {
                Interop.MediaInfo.GetAudio(handle, out audioHandle).ThrowIfError("Failed to retrieve data");

                Debug.Assert(audioHandle != IntPtr.Zero);

                Album = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetAlbum);
                Artist = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetArtist);
                AlbumArtist = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetAlbumArtist);
                Genre = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetGenre);
                Composer = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetComposer);
                Year = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetYear);
                DateRecorded = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetRecordedDate);
                Copyright = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetCopyright);
                TrackNumber = InteropHelper.GetString(audioHandle, Interop.AudioInfo.GetTrackNum);

                BitRate = InteropHelper.GetValue<int>(audioHandle, Interop.AudioInfo.GetBitRate);
                BitPerSample = InteropHelper.GetValue<int>(audioHandle, Interop.AudioInfo.GetBitPerSample);
                SampleRate = InteropHelper.GetValue<int>(audioHandle, Interop.AudioInfo.GetSampleRate);
                Channels = InteropHelper.GetValue<int>(audioHandle, Interop.AudioInfo.GetChannel);

                Duration = InteropHelper.GetValue<int>(audioHandle, Interop.AudioInfo.GetDuration);
            }
            finally
            {
                Interop.AudioInfo.Destroy(audioHandle);
            }
        }

        /// <summary>
        /// Gets the album name.
        /// </summary>
        /// <value>The album from the metadata.</value>
        public string Album { get; }

        /// <summary>
        /// Gets the artist name.
        /// </summary>
        /// <value>The artist from the metadata.</value>
        public string Artist { get; }

        /// <summary>
        /// Gets the album artist name.
        /// </summary>
        /// <value>The album artist from the metadata.</value>
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the genre.
        /// </summary>
        /// <value>The genre from the metadata.</value>
        public string Genre { get; }

        /// <summary>
        /// Gets the composer.
        /// </summary>
        /// <value>The composer from the metadata.</value>
        public string Composer { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year from the metadata.</value>
        public string Year { get; }

        /// <summary>
        /// Gets the recorded date.
        /// </summary>
        /// <value>The recorded date from the metadata.</value>
        public string DateRecorded { get; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <value>The copyright from the metadata.</value>
        public string Copyright { get; }

        /// <summary>
        /// Gets the track number.
        /// </summary>
        /// <value>The track number from the metadata.</value>
        public string TrackNumber { get; }

        /// <summary>
        /// Gets the bit rate in bit per second.
        /// </summary>
        /// <value>The bit rate in bit per second.</value>
        public int BitRate { get; }

        /// <summary>
        /// Gets the bit per sample.
        /// </summary>
        /// <value>The bit per sample.</value>
        public int BitPerSample { get; }

        /// <summary>
        /// Gets the sample rate in hertz.
        /// </summary>
        /// <value>The sample rate in hertz.</value>
        public int SampleRate { get; }

        /// <summary>
        /// Gets the number of channels.
        /// </summary>
        /// <value>The number of channels.</value>
        public int Channels { get; }

        /// <summary>
        /// Gets the track duration in milliseconds.
        /// </summary>
        /// <value>The track duration in milliseconds.</value>
        public int Duration { get; }
    }
}
