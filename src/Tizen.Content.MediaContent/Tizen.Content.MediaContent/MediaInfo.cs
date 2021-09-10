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

namespace Tizen.Content.MediaContent
{

    /// <summary>
    /// Represents the information related to the media stored.
    /// </summary>
    /// <seealso cref="MediaInfoCommand"/>
    /// <since_tizen> 4 </since_tizen>
    public class MediaInfo
    {
#pragma warning disable CS0618 // Type or member is obsolete
        internal MediaInfo(Interop.MediaInfoHandle handle)
        {
            Id = InteropHelper.GetString(handle, Interop.MediaInfo.GetMediaId);

            Path = InteropHelper.GetString(handle, Interop.MediaInfo.GetFilePath);
            DisplayName = InteropHelper.GetString(handle, Interop.MediaInfo.GetDisplayName);

            MediaType = InteropHelper.GetValue<MediaType>(handle, Interop.MediaInfo.GetMediaType);

            MimeType = InteropHelper.GetString(handle, Interop.MediaInfo.GetMimeType);

            FileSize = InteropHelper.GetValue<long>(handle, Interop.MediaInfo.GetSize);

            DateAdded = InteropHelper.GetDateTime(handle, Interop.MediaInfo.GetAddedTime);
            DateModified = InteropHelper.GetDateTime(handle, Interop.MediaInfo.GetModifiedTime);
            Timeline = InteropHelper.GetDateTime(handle, Interop.MediaInfo.GetTimeline);

            ThumbnailPath = InteropHelper.GetString(handle, Interop.MediaInfo.GetThumbnailPath, true);
            Description = InteropHelper.GetString(handle, Interop.MediaInfo.GetDescription);

            Longitude = InteropHelper.GetValue<double>(handle, Interop.MediaInfo.GetLongitude);
            Latitude = InteropHelper.GetValue<double>(handle, Interop.MediaInfo.GetLatitude);
            Altitude = InteropHelper.GetValue<double>(handle, Interop.MediaInfo.GetAltitude);

            Rating = InteropHelper.GetValue<int>(handle, Interop.MediaInfo.GetRating);
            IsFavorite = InteropHelper.GetValue<bool>(handle, Interop.MediaInfo.GetFavorite);
            Title = InteropHelper.GetString(handle, Interop.MediaInfo.GetTitle);
            StorageId = InteropHelper.GetString(handle, Interop.MediaInfo.GetStorageId);
            IsDrm = InteropHelper.GetValue<bool>(handle, Interop.MediaInfo.IsDrm);

            StorageType = InteropHelper.GetValue<StorageType>(handle, Interop.MediaInfo.GetStorageType);
        }
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// Gets the ID of media.
        /// </summary>
        /// <value>The unique ID of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Id { get; }

        /// <summary>
        /// Gets the path to media.
        /// </summary>
        /// <value>The full path of the media file.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Path { get; }

        /// <summary>
        /// Gets the name of media.
        /// </summary>
        /// <value>The base name of the media file.</value>
        /// <since_tizen> 4 </since_tizen>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the <see cref="MediaContent.MediaType"/> of media.
        /// </summary>
        /// <value>The <see cref="MediaContent.MediaType"/> of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaType MediaType { get; }

        /// <summary>
        /// Gets the mime type from media.
        /// </summary>
        /// <value>The mime type of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public string MimeType { get; }

        /// <summary>
        /// Gets the file size of media in bytes.
        /// </summary>
        /// <value>The file size of media in bytes.</value>
        /// <since_tizen> 4 </since_tizen>
        public long FileSize { get; }

        /// <summary>
        /// Gets the date of addition of media.
        /// </summary>
        /// <value>The date of addition of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public DateTimeOffset DateAdded { get; }

        /// <summary>
        /// Gets the date of modification of media.
        /// </summary>
        /// <value>The date of modification of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public DateTimeOffset DateModified { get; }

        /// <summary>
        /// Gets the timeline of media.
        /// </summary>
        /// <value>
        /// The creation date if the file has the creation information (like recorded date or image creation date),
        /// otherwise the modified date.
        /// </value>
        /// <since_tizen> 4 </since_tizen>
        public DateTimeOffset Timeline { get; }

        /// <summary>
        /// Gets the thumbnail of media.
        /// </summary>
        /// <value>The thumbnail path of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public string ThumbnailPath { get; }

        /// <summary>
        /// Gets the description of media.
        /// </summary>
        /// <value>The description from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Description { get; }

        /// <summary>
        /// Gets the longitude of media.
        /// </summary>
        /// <value>The longitude.</value>
        /// <since_tizen> 4 </since_tizen>
        public double Longitude { get; }

        /// <summary>
        /// Gets the latitude of media.
        /// </summary>
        /// <value>The latitude.</value>
        /// <since_tizen> 4 </since_tizen>
        public double Latitude { get; }

        /// <summary>
        /// Gets the altitude of media.
        /// </summary>
        /// <value>The altitude.</value>
        /// <since_tizen> 4 </since_tizen>
        public double Altitude { get; }

        /// <summary>
        /// Gets the rating of media.
        /// </summary>
        /// <value>The rating from the metadata.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Rating { get; }

        /// <summary>
        /// Gets the favorite status of media.
        /// </summary>
        /// <value>true if media is set as favorite, otherwise false.</value>
        /// <since_tizen> 4 </since_tizen>
        public bool IsFavorite { get; }

        /// <summary>
        /// Gets the title of media.
        /// </summary>
        /// <value>The title of media.</value>
        /// <since_tizen> 4 </since_tizen>
        public string Title { get; }

        /// <summary>
        /// Gets the storage ID of the storage that the media is stored on.
        /// </summary>
        /// <value>The storage ID of the storage that the media is stored on.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public string StorageId { get; }

        /// <summary>
        /// Gets the value indicating whether the media is DRM-protected.
        /// </summary>
        /// <value>A bool value indicating whether the media is DRM-protected.</value>
        /// <since_tizen> 4 </since_tizen>
        public bool IsDrm { get; }

        /// <summary>
        /// Gets the storage type of the storage that the media is stored on.
        /// </summary>
        /// <value>The storage type of the storage that the media is stored on.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public StorageType StorageType { get; }

        /// <summary>
        /// Returns a string representation of the media information.
        /// </summary>
        /// <returns>A string representation of the current media information.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override string ToString() => $"Id={Id}, Path={Path}, MediaType={MediaType}";

        internal static MediaInfo FromHandle(Interop.MediaInfoHandle handle)
        {
            if (handle == null || handle.IsInvalid)
            {
                return null;
            }

            var type = InteropHelper.GetValue<MediaType>(handle, Interop.MediaInfo.GetMediaType);

            switch (type)
            {
                case MediaType.Image:
                    return new ImageInfo(handle);

                case MediaType.Music:
                case MediaType.Sound:
                    return new AudioInfo(handle);

                case MediaType.Video:
                    return new VideoInfo(handle);

                case MediaType.Book:
                    return new BookInfo(handle);
            }

            return new MediaInfo(handle);
        }

        internal static MediaInfo FromHandle(IntPtr handle)
        {
            var safeHandle = new Interop.MediaInfoHandle(handle);
            try
            {
                return FromHandle(safeHandle);
            }
            finally
            {
                safeHandle.SetHandleAsInvalid();
            }
        }
    }
}
