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
    /// Enumeration for ordering
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ContentOrder
    {
        /// <summary>
        /// Ascending order
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Asc,
        /// <summary>
        /// Descending order
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Desc
    }

    /// <summary>
    /// Enumeration for collations.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ContentCollation
    {
        /// <summary>
        /// Default collation BINARY
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Default,
        /// <summary>
        /// Collation NOCASE, not case sensitive
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Nocase,
        /// <summary>
        /// Collation RTRIM, trailing space characters are ignored
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rtim,
        /// <summary>
        /// Collation LOCALIZATION, NOCASE also applied
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Localized
    }

    /// <summary>
    /// Enumeration for a media group.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaGroupType
    {
        /// <summary>
        /// Media group ID for display name
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DisplayName,
        /// <summary>
        /// Media group ID for a media type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Type,
        /// <summary>
        /// Media group ID for a mime type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        MimeType,
        /// <summary>
        /// Media group ID for content size
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Size,
        /// <summary>
        /// Media group ID for the added time
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AddedTime,
        /// <summary>
        /// Media group ID for the modified time
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ModifiedTime,
        /// <summary>
        /// Media group ID for a content title
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Title,
        /// <summary>
        /// Media group ID for an artist
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Artist,
        /// <summary>
        /// Media group ID for an album artist
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AlbumArtist,
        /// <summary>
        /// Media group ID for a genre
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Genre,
        /// <summary>
        /// Media group ID for a composer
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Composer,
        /// <summary>
        /// Media group ID for a year
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Year,
        /// <summary>
        /// Media group ID for the recorded date
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RecordedDate,
        /// <summary>
        /// Media group ID for the copyright
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Copyright,
        /// <summary>
        /// Media group ID for a track number
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tracknum,
        /// <summary>
        /// Media group ID for a description
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Description,
        /// <summary>
        /// Media group ID for the longitude
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Longitude,
        /// <summary>
        /// Media group ID for the latitude
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Latitude,
        /// <summary>
        /// Media group ID for the altitude
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Altitude,
        /// <summary>
        /// Media group ID for the burst shot
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BurstImage,
        /// <summary>
        /// Media group ID for a rating
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rating,
        /// <summary>
        /// Media group ID for an author
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Author,
        /// <summary>
        /// Media group ID for a provide
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Provider,
        /// <summary>
        /// Media group ID for the content name
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ContentName,
        /// <summary>
        /// Media group ID for a category
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Category,
        /// <summary>
        /// Media group ID for a location tag
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LocationTag,
        /// <summary>
        /// Media group ID for an age rating
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        AgeRating,
        /// <summary>
        /// Media group ID for a keyword
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Keyword,
        /// <summary>
        /// Media group ID for the weather
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Weather,
        /// <summary>
        /// Invalid media group ID
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Max
    }

    /// <summary>
    /// Enum to give the type of storage.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ContentStorageType : int
    {
        /// <summary>
        /// The device's internal storage
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Internal = 0,
        /// <summary>
        /// The device's external storage like sd card
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        External = 1,
        /// <summary>
        /// The external USB storage
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ExternalUSB = 2
    };

    /// <summary>
    /// Enums for media database update type
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaContentDBUpdateType
    {
        /// <summary>
        /// Updating the database with inserts.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Insert,
        /// <summary>
        /// Updating the database with removes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Delete,
        /// <summary>
        /// Updating the database with updates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Update
    }

    /// <summary>
    /// Enums for the type of item updated in media database
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaContentUpdateItemType
    {
        /// <summary>
        /// The file information is updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        File,
        /// <summary>
        /// The folder information and the file information included in the folder are updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Directory
    }

    /// <summary>
    /// Enums for content collection types
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ContentCollectionType
    {
        /// <summary>
        ///Content Collection type folder
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Folder,
        /// <summary>
        ///Content Collection type storage
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Storage,
        /// <summary>
        /// Content Collection type album
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Album,
        /// <summary>
        ///Content Collection type playlist
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PlayList,
        /// <summary>
        ///Content Collection type tag
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tag,
        /// <summary>
        ///Content Collection type group
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Group
    }
    /// <summary>
    /// Enum to give the type of media information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaContentType : int
    {
        /// <summary>
        /// The type of an image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Image = 0,
        /// <summary>
        /// The type of a video.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Video = 1,
        /// <summary>
        /// The type of sound.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sound = 2,
        /// <summary>
        /// The type of music.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Music = 3,
        /// <summary>
        /// The type of other.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Others = 4
    };

    /// <summary>
    /// Enum to give the orientation type of the media.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaContentOrientation : int
    {
        /// <summary>
        /// Not available.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotAvailable = 0,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Normal = 1,
        /// <summary>
        /// Flip horizontal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        HFlip = 2,
        /// <summary>
        /// Rotate 180 degrees.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rot180 = 3,
        /// <summary>
        /// Flip vertical.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        VFlip = 4,
        /// <summary>
        /// Transpose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Transpose = 5,
        /// <summary>
        /// Rotate 90 degrees.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rot90 = 6,
        /// <summary>
        /// Transverse.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Transverse = 7,
        /// <summary>
        /// Rotate 270 degrees.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Rot270 = 8
    };
}
