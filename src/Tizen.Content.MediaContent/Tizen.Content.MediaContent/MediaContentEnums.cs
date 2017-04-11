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
    public enum ContentOrder
    {
        /// <summary>
        /// Ascending order
        /// </summary>
        Asc,
        /// <summary>
        /// Descending order
        /// </summary>
        Desc
    }

    /// <summary>
    /// Enumeration for collations.
    /// </summary>
    public enum ContentCollation
    {
        /// <summary>
        /// Default collation BINARY
        /// </summary>
        Default,
        /// <summary>
        /// Collation NOCASE, not case sensitive
        /// </summary>
        Nocase,
        /// <summary>
        /// Collation RTRIM, trailing space characters are ignored
        /// </summary>
        Rtim,
        /// <summary>
        /// Collation LOCALIZATION, NOCASE also applied
        /// </summary>
        Localized
    }

    /// <summary>
    /// Enumeration for a media group.
    /// </summary>
    public enum MediaGroupType
    {
        /// <summary>
        /// Media group ID for display name
        /// </summary>
        DisplayName,
        /// <summary>
        /// Media group ID for a media type
        /// </summary>
        Type,
        /// <summary>
        /// Media group ID for a mime type
        /// </summary>
        MimeType,
        /// <summary>
        /// Media group ID for content size
        /// </summary>
        Size,
        /// <summary>
        /// Media group ID for the added time
        /// </summary>
        AddedTime,
        /// <summary>
        /// Media group ID for the modified time
        /// </summary>
        ModifiedTime,
        /// <summary>
        /// Media group ID for a content title
        /// </summary>
        Title,
        /// <summary>
        /// Media group ID for an artist
        /// </summary>
        Artist,
        /// <summary>
        /// Media group ID for an album artist
        /// </summary>
        AlbumArtist,
        /// <summary>
        /// Media group ID for a genre
        /// </summary>
        Genre,
        /// <summary>
        /// Media group ID for a composer
        /// </summary>
        Composer,
        /// <summary>
        /// Media group ID for a year
        /// </summary>
        Year,
        /// <summary>
        /// Media group ID for the recorded date
        /// </summary>
        RecordedDate,
        /// <summary>
        /// Media group ID for the copyright
        /// </summary>
        Copyright,
        /// <summary>
        /// Media group ID for a track number
        /// </summary>
        Tracknum,
        /// <summary>
        /// Media group ID for a description
        /// </summary>
        Description,
        /// <summary>
        /// Media group ID for the longitude
        /// </summary>
        Longitude,
        /// <summary>
        /// Media group ID for the latitude
        /// </summary>
        Latitude,
        /// <summary>
        /// Media group ID for the altitude
        /// </summary>
        Altitude,
        /// <summary>
        /// Media group ID for the burst shot
        /// </summary>
        BurstImage,
        /// <summary>
        /// Media group ID for a rating
        /// </summary>
        Rating,
        /// <summary>
        /// Media group ID for an author
        /// </summary>
        Author,
        /// <summary>
        /// Media group ID for a provide
        /// </summary>
        Provider,
        /// <summary>
        /// Media group ID for the content name
        /// </summary>
        ContentName,
        /// <summary>
        /// Media group ID for a category
        /// </summary>
        Category,
        /// <summary>
        /// Media group ID for a location tag
        /// </summary>
        LocationTag,
        /// <summary>
        /// Media group ID for an age rating
        /// </summary>
        AgeRating,
        /// <summary>
        /// Media group ID for a keyword
        /// </summary>
        Keyword,
        /// <summary>
        /// Media group ID for the weather
        /// </summary>
        Weather,
        /// <summary>
        /// Invalid media group ID
        /// </summary>
        Max
    }

    /// <summary>
    /// Enum to give the type of storage.</summary>
    public enum ContentStorageType : int
    {
        /// <summary>
        /// The device's internal storage
        /// </summary>
        Internal = 0,
        /// <summary>
        /// The device's external storage like sd card
        /// </summary>
        External = 1,
        /// <summary>
        /// The external USB storage
        /// </summary>
        ExternalUSB = 2
    };

    /// <summary>
    /// Enums for media database update type
    /// </summary>
    public enum MediaContentDBUpdateType
    {
        /// <summary>
        ///
        /// </summary>
        Insert,
        /// <summary>
        ///
        /// </summary>
        Delete,
        /// <summary>
        ///
        /// </summary>
        Update
    }

    /// <summary>
    /// Enums for the type of item updated in media database
    /// </summary>
    public enum MediaContentUpdateItemType
    {
        /// <summary>
        ///
        /// </summary>
        File,
        /// <summary>
        ///
        /// </summary>
        Directory
    }

    /// <summary>
    /// Enums for content collection types
    /// </summary>
    public enum ContentCollectionType
    {
        /// <summary>
        ///Content Collection type folder
        /// </summary>
        Folder,
        /// <summary>
        ///Content Collection type storage
        /// </summary>
        Storage,
        /// <summary>
        /// Content Collection type album
        /// </summary>
        Album,
        /// <summary>
        ///Content Collection type playlist
        /// </summary>
        PlayList,
        /// <summary>
        ///Content Collection type tag
        /// </summary>
        Tag,
        /// <summary>
        ///Content Collection type group
        /// </summary>
        Group
    }
    /// <summary>
    /// Enum to give the type of media information.</summary>
    public enum MediaContentType : int
    {
        /// <summary>
        /// The type of an image.
        /// </summary>
        Image = 0,
        /// <summary>
        /// The type of a video.
        /// </summary>
        Video = 1,
        /// <summary>
        /// The type of sound.
        /// </summary>
        Sound = 2,
        /// <summary>
        /// The type of music.
        /// </summary>
        Music = 3,
        /// <summary>
        /// The type of other.
        /// </summary>
        Others = 4
    };

    /// <summary>
    /// Enum to give the orientation type of the media.</summary>
    public enum MediaContentOrientation : int
    {
        /// <summary>
        /// Not available.
        /// </summary>
        NotAvailable = 0,
        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Flip horizontal.
        /// </summary>
        HFlip = 2,
        /// <summary>
        /// Rotate 180 degrees.
        /// </summary>
        Rot180 = 3,
        /// <summary>
        /// Flip vertical.
        /// </summary>
        VFlip = 4,
        /// <summary>
        /// Transpose.
        /// </summary>
        Transpose = 5,
        /// <summary>
        /// Rotate 90 degrees.
        /// </summary>
        Rot90 = 6,
        /// <summary>
        /// Transverse.
        /// </summary>
        Transverse = 7,
        /// <summary>
        /// Rotate 270 degrees.
        /// </summary>
        Rot270 = 8
    };
}
