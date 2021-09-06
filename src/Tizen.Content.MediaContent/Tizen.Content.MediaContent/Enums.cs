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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Specifies how the strings are compared.
    /// </summary>
    internal enum Collation
    {
        /// <summary>
        /// Default collation, binary.
        /// </summary>
        Default,
        /// <summary>
        /// Case-insensitive.
        /// </summary>
        NoCase,
        /// <summary>
        /// Trailing space characters are ignored.
        /// </summary>
        Rtrim,
        /// <summary>
        /// Localized, NoCase also applied.
        /// </summary>
        Localized
    }

    /// <summary>
    /// Specifies the storage types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum StorageType
    {
        /// <summary>
        /// The device's internal storage.
        /// </summary>
        Internal = 0,

        /// <summary>
        /// The device's external storage like SD card.
        /// </summary>
        External = 1,

        /// <summary>
        /// The external USB storage.
        /// </summary>
        ExternalUsb = 2
    }

    /// <summary>
    /// Specifies database operation types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum OperationType
    {
        /// <summary>
        /// Insert operation.
        /// </summary>
        Insert,

        /// <summary>
        /// Delete operation.
        /// </summary>
        Delete,

        /// <summary>
        /// Update operation.
        /// </summary>
        Update
    }

    internal enum ItemType
    {
        File,
        Directory
    }

    /// <summary>
    /// Specifies types of the <see cref="MediaInfo"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaType
    {
        /// <summary>
        /// The type of an image.
        /// </summary>
        /// <seealso cref="ImageInfo"/>
        Image = 0,

        /// <summary>
        /// The type of a video.
        /// </summary>
        /// <seealso cref="VideoInfo"/>
        Video = 1,

        /// <summary>
        /// The type of sound.
        /// </summary>
        /// <seealso cref="AudioInfo"/>
        Sound = 2,

        /// <summary>
        /// The type of music.
        /// </summary>
        /// <seealso cref="AudioInfo"/>
        Music = 3,

        /// <summary>
        /// The type of other.
        /// </summary>
        Other = 4,

        /// <summary>
        /// The type of book.
        /// </summary>
        /// <seealso cref="BookInfo"/>
        /// <since_tizen> 9 </since_tizen>
        Book = 5
    }

    /// <summary>
    /// Specifies orientation types of media.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum Orientation
    {
        /// <summary>
        /// None.
        /// </summary>
        Rotate0 = 0,
        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Rotate 90 degrees.
        /// </summary>
        Rotate90 = 6,
        /// <summary>
        /// Rotate 180 degrees.
        /// </summary>
        Rotate180 = 3,
        /// <summary>
        /// Rotate 270 degrees.
        /// </summary>
        Rotate270 = 8,
        /// <summary>
        /// Flip horizontal.
        /// </summary>
        FlipHorizontal = 2,
        /// <summary>
        /// Flip vertical.
        /// </summary>
        FlipVertical = 4,
        /// <summary>
        /// Transpose.
        /// </summary>
        Transpose = 5,
        /// <summary>
        /// Transverse.
        /// </summary>
        Transverse = 7,
    }
}
