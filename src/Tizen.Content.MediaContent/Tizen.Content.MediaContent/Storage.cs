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
    /// A Storage allows you to manage external storage.
    /// The system generates the storage id when the external storage is added.And the system manages the media information in each of the storage by using storage id.
    /// So you can get the information from the storage that you want to view.
    /// </summary>
    public class Storage : ContentCollection
    {
        private IntPtr _storageHandle = IntPtr.Zero;
        private IntPtr Handle
        {
            get
            {
                if (_storageHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(Storage));
                }

                return _storageHandle;
            }
        }
        /// <summary>
        /// The storage id of the media storage
        /// </summary>
        public string Id
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Storage.GetId(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The storage path of the media storage
        /// </summary>
        public string StoragePath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Storage.GetPath(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The storage name of the media storage
        /// </summary>
        public string Name
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Storage.GetName(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The storage type of the media storage
        /// </summary>
        public ContentStorageType StorageType
        {
            get
            {
                ContentStorageType storageType;
                MediaContentValidator.ThrowIfError(
                    Interop.Storage.GetType(Handle, out storageType), "Failed to get value");

                return storageType;
            }
        }

        internal Storage(IntPtr handle)
        {
            _storageHandle = handle;
        }

        /// <summary>
        /// Gets the count of media files for the passed filter in the given storage from the media database.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.Storage.GetMediaCountFromDb(Id, handle, out mediaCount), "Failed to get count");

            return mediaCount;
        }

        public override void Dispose()
        {
            if (_storageHandle != IntPtr.Zero)
            {
                Interop.Storage.Destroy(_storageHandle);
                _storageHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Iterates through the media files with an optional filter in the given storage from the media database.
        /// This function gets all media files associated with the given storage and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();

            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.Storage.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone media");

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
                Interop.Storage.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero), "Failed to get information");

            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
