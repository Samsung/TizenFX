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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// An album is a logical collection or grouping of related audio files. It is also used for filtering media items.
    /// The Media Album API allows to manage media albums which contains all video and audio items from the same album.
    /// </summary>
    public class Album : ContentCollection
    {
        private IntPtr _albumHandle = IntPtr.Zero;

        private IntPtr Handle
        {
            get
            {
                if (_albumHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(Album));
                }

                return _albumHandle;
            }
        }

        /// <summary>
        /// The media album ID
        /// </summary>
        public int Id
        {
            get
            {
                int id = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.Group.MediaAlbumGetAlbumId(Handle, out id), "Failed to get value");

                return id;
            }
        }

        /// <summary>
        /// The name of the media artist
        /// If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Artist
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Group.MediaAlbumGetArtist(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The path of the media album art
        /// </summary>
        public string Art
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Group.MediaAlbumGetAlbumArt(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The name of the media album
        /// If the media content has no album info, the property returns empty string.
        /// </summary>
        public string Name
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Group.MediaAlbumGetName(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        internal Album(IntPtr handle)
        {
            _albumHandle = handle;
        }

        /// <summary>
        /// Gets the number of MediaInformation Items for the given album present in the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;

            MediaContentValidator.ThrowIfError(
                Interop.Group.MediaAlbumGetMediaCountFromDb(Id, handle, out mediaCount), "Failed to get count");

            return mediaCount;
        }

        public override void Dispose()
        {
            if (_albumHandle != IntPtr.Zero)
            {
                Interop.Group.MediaAlbumDestroy(_albumHandle);
                _albumHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Iterates through the media files with a filter in the given media album from the media database.
        /// This function gets all media files associated with the given media album and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();

            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.Group.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone");

                MediaContentType type;
                Interop.MediaInformation.GetMediaType(newHandle, out type);
                if (type == MediaContentType.Image)
                {
                    Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetImage(mediaHandle, out imageInfo), "Failed to get image information");

                    mediaContents.Add(new ImageInformation(imageInfo, newHandle));
                }
                else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
                {
                    Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetAudio(mediaHandle, out audioInfo), "Failed to get audio information");

                    mediaContents.Add(new AudioInformation(audioInfo, newHandle));
                }
                else if (type == MediaContentType.Video)
                {
                    Interop.VideoInformation.SafeVideoInformationHandle videoInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetVideo(mediaHandle, out videoInfo), "Failed to get video information");

                    mediaContents.Add(new VideoInformation(videoInfo, newHandle));
                }
                else if (type == MediaContentType.Others)
                {
                    mediaContents.Add(new MediaInformation(newHandle));
                }

                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Group.MediaAlbumForeachMediaFromDb(Id, handle, callback, IntPtr.Zero), "Failed to get information");

            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
