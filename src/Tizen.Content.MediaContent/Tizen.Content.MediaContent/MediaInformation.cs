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
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// MediaContent class API gives the information related to the media stored in the device</summary>
    /// <remarks>
    /// The API's provide the functionlity to insert, clone, delete, get the number and content of files from DB.
    /// You can get and set properties and parameters such as storage type, provider, and category of media info,
    /// handling with thumbnail and updating media info to DB.</remarks>
    public class MediaInformation
    {
        private readonly Interop.MediaInformation.SafeMediaInformationHandle _handle;

        /// <summary>
        /// Gets the count of media tags for the passed filter in the given mediaId from the media database.
        /// </summary>
        /// <returns>
        /// int count</returns>
        /// <param name="filter">The Filter for matching Tags</param>
        public int GetTagCount(ContentFilter filter)
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetTagCount(MediaId, handle, out count), "Failed to get count");

            return count;
        }

        /// <summary>
        /// Moves the media info to the given destination path in the media database.
        /// </summary>
        /// <returns>
        /// void </returns>
        /// <param name="destination">The Destination path</param>
        public void Move(string destination)
        {
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.MoveToDB(_handle, destination), "Failed to move");
        }

        /// <summary>
        /// Refreshes the media metadata to the media database.
        /// </summary>
        /// <returns>
        /// void </returns>
        public void Refresh()
        {
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.RefreshMetadataToDB(MediaId), "Failed to refresh");
        }

        /// <summary>
        /// Creates a thumbnail image for the given media, asynchronously
        /// If a thumbnail already exists for the given media, then the path of thumbnail will be returned.
        /// </summary>
        /// <returns>
        /// Task for creation of Thumbnail </returns>
        public async Task<string> CreateThumbnailAsync()
        {
            var task = new TaskCompletionSource<string>();
            Interop.MediaInformation.MediaThumbnailCompletedCallback thumbnailResult = (MediaContentError createResult, string path, IntPtr userData) =>
            {
                MediaContentValidator.ThrowIfError(createResult, "Failed to create thumbnail");
                task.SetResult(path);
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.CreateThumbnail(_handle, thumbnailResult, IntPtr.Zero), "Failed to create thumbnail");

            return await task.Task;
        }

        /// <summary>
        /// Creates a thumbnail image for the given media, asynchronously
        /// which can be cancelled
        /// If a thumbnail already exists for the given media, then the path of thumbnail will be returned.
        /// </summary>
        /// <returns>
        /// Task for creation of Thumbnail </returns>
        public async Task<string> CreateThumbnailAsync(CancellationToken cancellationToken)
        {
            var task = new TaskCompletionSource<string>();
            cancellationToken.Register(() => {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.CancelThumbnail(_handle), "Failed to cancel");
                task.SetCanceled();
            });
            Interop.MediaInformation.MediaThumbnailCompletedCallback thumbnailResult = (MediaContentError createResult, string path, IntPtr userData) =>
            {
                MediaContentValidator.ThrowIfError(createResult, "Failed to create thumbnail");
                task.SetResult(path);
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.CreateThumbnail(_handle, thumbnailResult, IntPtr.Zero), "Failed to create thumbnail");

            return await task.Task;
        }

        /// <summary>
        /// Iterates through the media tag in the given media info from the media database.
        /// </summary>
        /// <returns>
        /// Task to get all the Tags </returns>
        /// <param name="filter"> The filter for the Tags</param>
        public Task<IEnumerable<Tag>> GetTagsAsync(ContentFilter filter)
        {
            var task = new TaskCompletionSource<IEnumerable<Tag>>();
            Collection<Tag> coll = new Collection<Tag>();

            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.MediaInformation.MediaTagCallback tagsCallback = (IntPtr tagHandle, IntPtr userData) =>
            {
                IntPtr newHandle;
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.Clone(out newHandle, tagHandle), "Failed to clone");
                coll.Add(new Tag(newHandle));

                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetAllTags(MediaId, handle, tagsCallback, IntPtr.Zero), "Failed to get information");

            task.SetResult(coll);
            return task.Task;
        }

        /// <summary>
        ///  Gets the tag ID for the media.
        /// </summary>
        public virtual string MediaId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetMediaId(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the path to the media.
        /// </summary>
        public string FilePath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetFilePath(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Name of the media.
        /// </summary>
        public string DisplayName
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetDisplayName(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetDisplayName(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        ///  Gets the content type of the media.
        /// </summary>
        public MediaContentType MediaType
        {
            get
            {
                MediaContentType contentType = MediaContentType.Others;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetMediaType(_handle, out contentType), "Failed to get value");

                return contentType;
            }
        }

        /// <summary>
        ///  Gets the MIME type from the media.
        /// </summary>
        public string MimeType
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetMimeType(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Gets the media file size in bytes.
        /// </summary>
        public long Size
        {
            get
            {
                long size;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetSize(_handle, out size), "Failed to get value");

                return size;
            }
        }

        /// <summary>
        ///  Addition time of the media.
        /// </summary>
        public DateTime AddedAt
        {
            get
            {
                int time;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetAddedTime(_handle, out time), "Failed to get value");

                DateTime utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);

                return utc.ToLocalTime();
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetAddedTime(_handle, (int)value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds), "failed to set time");
            }
        }

        /// <summary>
        ///  Gets the date of modification of media.
        /// </summary>
        public DateTime ModifiedAt
        {
            get
            {
                int time;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetModifiedTime(_handle, out time), "Failed to get value");

                DateTime utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);

                return utc.ToLocalTime();
            }
        }

        /// <summary>
        ///  Gets the timeline of media.
        /// </summary>
        public DateTime TimeLine
        {
            get
            {
                int time;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetTimeline(_handle, out time), "Failed to get value");

                DateTime utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);

                return utc.ToLocalTime();
            }
        }

        /// <summary>
        ///  Gets the thumbnail of media.
        /// </summary>
        public string ThumbnailPath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetThumbnailPath(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        ///  Description of media.
        ///  If the media info has no description, the property returns empty string.
        /// </summary>
        public string Description
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetDescription(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetDescription(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Longitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Longitude
        {
            get
            {
                double longitude = 0.0;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetLongitude(_handle, out longitude), "Failed to get value");

                return longitude;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetLongitude(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Latitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Latitude
        {
            get
            {
                double latitude = 0.0;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetLatitude(_handle, out latitude), "Failed to get value");

                return latitude;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetLatitude(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Altitude of media.
        /// Default Value is 0.0.
        /// </summary>
        public double Altitude
        {
            get
            {
                double altitude = 0.0;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetAltitude(_handle, out altitude), "Failed to get value");

                return altitude;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetAltitude(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Weather of media.
        /// Dafault is empty string.
        /// </summary>
        public string Weather
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetWeather(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetWeather(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Rating of media.
        /// </summary>
        public int Rating
        {
            get
            {
                int rating = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetRating(_handle, out rating), "Failed to get value");
                return rating;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetRating(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Favorite status of media.
        /// true if media info is set as favorite, otherwise false if media info is not set as favorite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                bool isFavourtite = false;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetFavorite(_handle, out isFavourtite), "Failed to get value");

                return isFavourtite;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetFavorite(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Author of media.
        /// </summary>
        public string Author
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetAuthor(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetAuthor(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Provider of media.
        /// </summary>
        public string Provider
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetProvider(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetProvider(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Content name of media.
        /// </summary>
        public string ContentName
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetContentName(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetContentName(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Gets the title of media.
        /// </summary>
        public string Title
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetTitle(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Category of media.
        /// </summary>
        public string Category
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetCategory(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetCategory(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// location tag of media.
        /// </summary>
        public string LocationTag
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetLocationTag(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetLocationTag(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Age Rating of media.
        /// </summary>
        public string AgeRating
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetAgeRating(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetAgeRating(_handle, value), "Failed to set value");
            }
        }

        /// <summary>
        /// Keyword of media.
        /// </summary>
        public string Keyword
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetKeyword(_handle, out val), "Failed to get value");

                    return MediaContentValidator.CheckString(Marshal.PtrToStringAnsi(val));
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetKeyword(_handle, value), "failed to set value");
            }
        }

        /// <summary>
        /// Gets the storage id of media.
        /// </summary>
        public string StorageId
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetStorageId(_handle, out val), "Failed to get value");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }
        }

        /// <summary>
        /// Checks whether the media is protected via DRM.
        /// </summary>
        public bool IsDrm
        {
            get
            {
                bool isDRM = false;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.IsDrm(_handle, out isDRM), "Failed to get value");

                return isDRM;
            }
        }

        /// <summary>
        /// Gets the storage type of media.
        /// </summary>
        public ContentStorageType StorageType
        {
            get
            {
                ContentStorageType storageType = ContentStorageType.Internal;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetStorageType(_handle, out storageType), "Failed to get value");

                return storageType;
            }
        }

        /// <summary>
        /// Number which represents how many times given content has been played.
        /// While Setting the played count, it will only be incremented by 1, the value provided will be ignored.
        /// </summary>
        public int PlayedCount
        {
            get
            {
                int playedCount = 0;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetPlayedCount(_handle, out playedCount), "Failed to get value");

                return playedCount;
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.IncreasePlayedCount(_handle), "failed to set value");
            }
        }

        /// <summary>
        ///  Content's latest played(opened) time of the media file.
        ///  for set the current time is automatically taken from the system, the value provided will be ignored.
        /// </summary>
        public DateTime PlayedAt
        {
            get
            {
                int time;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetPlayedAt(_handle, out time), "Failed to get value");

                DateTime utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);

                return utc.ToLocalTime();
            }
            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.SetPlayedAt(_handle), "failed to set value");
            }
        }

        internal IntPtr MediaHandle
        {
            get
            {
                return _handle.DangerousGetHandle();
            }
        }

        internal MediaInformation(Interop.MediaInformation.SafeMediaInformationHandle handle)
        {
            _handle = handle;
        }
    }
}
