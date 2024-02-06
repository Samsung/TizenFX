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
    /// Specifies the group keys for <see cref="MediaInfo"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaInfoColumnKey
    {
        /// <summary>
        /// Display name.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        DisplayName,

        /// <summary>
        /// Media type.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Type,

        /// <summary>
        /// Mime type.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        MimeType,

        /// <summary>
        /// File size.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Size,

        /// <summary>
        /// Date added.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        DateAdded,

        /// <summary>
        /// Date modified.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        DateModified,

        /// <summary>
        /// Content title.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Title,

        /// <summary>
        /// Artist.
        /// </summary>
        Artist,

        /// <summary>
        /// Album artist.
        /// </summary>
        AlbumArtist,

        /// <summary>
        /// Genre.
        /// </summary>
        Genre,

        /// <summary>
        /// Composer.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Composer = 10,

        /// <summary>
        /// Year.
        /// </summary>
        Year,

        /// <summary>
        /// Date recorded.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        DateRecorded,

        /// <summary>
        /// Copyright.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Copyright,

        /// <summary>
        /// Track number.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        TrackNumber,

        /// <summary>
        /// Description.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Description,

        /// <summary>
        /// Longitude.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Longitude,

        /// <summary>
        /// Latitude.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Latitude,

        /// <summary>
        /// Altitude.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Altitude,

        /// <summary>
        /// Rating.
        /// </summary>
        [Obsolete("Deprecated since API12; Will be removed in API14.")]
        Rating = 20,
    }
}
