/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
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
        private IntPtr _storageHandle;
        internal IntPtr Handle
        {
            get
            {
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
                string id;
                MediaContentError res = (MediaContentError)Interop.Storage.GetId(_storageHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Id for the Storage");
                }
                return id;
            }
        }

        /// <summary>
        /// The storage path of the media storage
        /// </summary>
        public string StoragePath
        {
            get
            {
                string path;
                MediaContentError res = (MediaContentError)Interop.Storage.GetPath(_storageHandle, out path);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Path for the Storage");
                }
                return path;
            }
        }

        /// <summary>
        /// The storage name of the media storage
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                MediaContentError res = (MediaContentError)Interop.Storage.GetName(_storageHandle, out name);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Name for the Storage");
                }
                return name;
            }
        }

        /// <summary>
        /// The storage type of the media storage
        /// </summary>
        public ContentStorageType StorageType
        {
            get
            {
                int storageType;
                MediaContentError res = (MediaContentError)Interop.Storage.GetType(_storageHandle, out storageType);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get type for the Storage");
                }
                return (ContentStorageType)storageType;
            }
        }

        internal Storage(IntPtr _storageHandle)
        {
            this._storageHandle = _storageHandle;
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
            MediaContentError res = (MediaContentError)Interop.Storage.GetMediaCountFromDb(Id, handle, out mediaCount);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media count for the storage");
            }
            return mediaCount;
        }

        public override void Dispose()
        {
            MediaContentError res = (MediaContentError)Interop.Storage.Destroy(_storageHandle);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to dispose the storage");
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
            MediaContentError res;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.Storage.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                res = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to clone media");
                }
                MediaInformation info = new MediaInformation(newHandle);
                mediaContents.Add(info);
                return true;
            };
            res = (MediaContentError)Interop.Storage.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get media information for the storage");
            }
            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
