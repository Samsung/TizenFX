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
    /// A Folder is used to organize media content files i.e. image, audio, video files, in the physical storage of the device.
    /// The Media Folder API provides functions to get basic information about existing folders e.g. folder name, path and storage type.
    /// It also provides functions to get information related to media items present in the folder.
    /// </summary>
    public class MediaFolder : ContentCollection
    {
        private IntPtr _folderHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        internal IntPtr Handle
        {
            get
            {
                if (_folderHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(MediaFolder));
                }

                return _folderHandle;
            }
        }
        /// <summary>
        /// The ID of the media folder. For each MediaFolder this id is unique.
        /// </summary>
        public string Id
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Folder.GetFolderId(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// ParentId of the MediaFolder that is the ID of the upper media folder (parent folder).
        /// </summary>
        public string ParentId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Folder.GetParentFolderId(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The path of the media folder
        /// </summary>
        public string FolderPath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Folder.GetPath(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The name of the media folder
        /// </summary>
        public string Name
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Folder.GetName(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.SetName(Handle, value), "Failed to set value");
            }
        }

        /// <summary>
        /// The storage type of the media folder.
        /// Storage types give information about the location of storage like Internal memory, USB or External Storage etc...
        /// </summary>
        public ContentStorageType StorageType
        {
            get
            {
                ContentStorageType type;
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.GetStorageType(Handle, out type), "Failed to get value");

                return type;
            }
        }

        /// <summary>
        /// The storage id of the media folder
        /// </summary>
        public string StorageId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Folder.GetStorageId(Handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// The modified date of the media folder
        /// </summary>
        public DateTime ModifiedTime
        {
            get
            {
                DateTime date;
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.GetModifiedTime(Handle, out date), "Failed to get value");

                return date;
            }
        }

        /// <summary>
        /// The folder order value. Get/Set the folder viewing order.
        /// Default Order value is zero.
        /// If you set the order value for each folder, you can sort in ascending or descending order as the set order values using the filter.
        /// </summary>
        public int Order
        {
            get
            {
                int order;
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.GetOrder(Handle, out order), "Failed to get value");

                return order;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.SetOrder(Handle, value), "Failed to set value");
            }
        }

        internal MediaFolder(IntPtr handle)
        {
            _folderHandle = handle;
        }

        /// <summary>
        /// Gets the count of media files for the passed filter in the given folder from the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from teh media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.Folder.GetMediaCountFromDb(Id, handle, out mediaCount), "Failed to get count");

            return mediaCount;
        }

        ~MediaFolder()
        {
            Dispose(false);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_folderHandle != IntPtr.Zero)
                {
                    Interop.Folder.Destroy(_folderHandle);
                    _folderHandle = IntPtr.Zero;
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Iterates through the media files with an filter in the given folder from the media database.
        /// This function gets all media files associated with the given folder and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;

            Interop.Folder.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
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
                Interop.Folder.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero), "Failed to get information");

            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
