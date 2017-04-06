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
    /// Enumerations for defining set of conditions in media filer
    /// </summary>
    public enum MediaColumn
    {
        /// <summary>
        /// Media ID. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Id,
        /// <summary>
        /// Media file path. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        FilePath,
        /// <summary>
        /// Media base name. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        DisplayName,
        /// <summary>
        /// Media type (0-image, 1-video, 2-sound, 3-music, 4-other). You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Type,
        /// <summary>
        /// Media MIME type. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        MimeType,
        /// <summary>
        /// Media size. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Size,
        /// <summary>
        /// Media added time. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AddedTime,
        /// <summary>
        /// Media modified time. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ModifiedTime,
        /// <summary>
        /// Media timeline. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Timeline,
        /// <summary>
        /// Media thumbnail path. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ThumbnailPath,
        /// <summary>
        /// Media title get from tag or file name. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Title,
        /// <summary>
        /// Media album name. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Album,
        /// <summary>
        /// Media artist. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Artist,
        /// <summary>
        /// Media album artist. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AlbumArtist,
        /// <summary>
        /// Media genre. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Genre,
        /// <summary>
        /// Media composer. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Composer,
        /// <summary>
        /// Media year. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Year,
        /// <summary>
        /// Media recorded date. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        RecordedDate,
        /// <summary>
        /// Media copyright. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Copyright,
        /// <summary>
        /// Media track number. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        TrackNumber,
        /// <summary>
        /// Media description. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Description,
        /// <summary>
        /// Media bitrate. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Bitrate,
        /// <summary>
        /// Media bit per sample. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Bitpersample,
        /// <summary>
        /// Media samplerate. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Samplerate,
        /// <summary>
        /// Media channel. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Channel,
        /// <summary>
        /// Media duration. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Duration,
        /// <summary>
        /// Media longitude. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Longitude,
        /// <summary>
        /// Media latitude. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Laitude,
        /// <summary>
        /// Media altitude. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Altitude,
        /// <summary>
        /// Media width. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Width,
        /// <summary>
        /// Media height. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Height,
        /// <summary>
        /// Media datataken. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Datetaken,
        /// <summary>
        /// Media orientation. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Orientation,
        /// <summary>
        /// Media burst ID. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        BurstId,
        /// <summary>
        /// Media played count. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        PlayedCount,
        /// <summary>
        /// Media last played time. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        PlayedTime,
        /// <summary>
        /// Media last played position of file. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        PlayedPosition,
        /// <summary>
        /// Media rating. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Rating,
        /// <summary>
        /// Media favourite (0-not favourite, 1-favourite). You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Favourite,
        /// <summary>
        /// Media author. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Author,
        /// <summary>
        /// Media provider. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Provider,
        /// <summary>
        /// Media content name. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ContentName,
        /// <summary>
        /// Media category. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Category,
        /// <summary>
        /// Media location tag. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        LocationTag,
        /// <summary>
        /// Media age rating. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AgeRating,
        /// <summary>
        /// Media keyword. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Keyword,
        /// <summary>
        /// Media weather. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Weather,
        /// <summary>
        /// Is DRM (0-not drm, 1-drm). You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        IsDrm,
        /// <summary>
        /// Media storage type (0-internal storage, 1-external storage). You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        StorageType,
        /// <summary>
        /// Media exposure time. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ExposureTime,
        /// <summary>
        /// Media f-number. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Fnumber,
        /// <summary>
        /// Media ISO. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Iso,
        /// <summary>
        /// Media model. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        Model,
        /// <summary>
        /// Media file name pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        FileNamePinyin,
        /// <summary>
        /// Media title pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        TitlePinyin,
        /// <summary>
        /// Media album name pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AlbumPinyin,
        /// <summary>
        /// Media artist pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ArtistPinyin,
        /// <summary>
        /// Media album artist pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AlbumArtistPinyin,
        /// <summary>
        /// Media genre pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        GenrePinyin,
        /// <summary>
        /// Media composer pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ComposerPinyin,
        /// <summary>
        /// Media copyright pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        CopyrightPinyin,
        /// <summary>
        /// Media description pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        DescriptionPinyin,
        /// <summary>
        /// Media author pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AuthorPinyin,
        /// <summary>
        /// Media provider pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ProviderPinyin,
        /// <summary>
        /// Media content name pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        ContentNamePinyin,
        /// <summary>
        /// Media category pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        CategoryPinyin,
        /// <summary>
        /// Media location tag pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        LocationTagPinyin,
        /// <summary>
        /// Media age rating pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        AgeRatingPinyin,
        /// <summary>
        /// Media keyword pinyin. You can use above define to set the condition of media filter and order keyword.
        /// </summary>
        KeywordPinyin
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
    /// Enumerations for defining set of conditions in media filer for media folder
    /// </summary>
    public enum FolderColumn
    {
        /// <summary>
        /// Folder ID. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        Id,
        /// <summary>
        /// Folder path. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        Path,
        /// <summary>
        /// Folder base name. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        Name,
        /// <summary>
        /// Folder modified time. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        ModifiedTime,
        /// <summary>
        /// Folder storage type (0-internal storage, 1-external storage). You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        StorageType,
        /// <summary>
        /// Folder name pinyin. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        NamePinyin,
        /// <summary>
        /// Folder order info. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        Order,
        /// <summary>
        /// Parent folder ID. You can use above define to set the condition of folder filter and order keyword.
        /// </summary>
        ParentFolderId
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
        ExternalUSB = 2,
        /// <summary>
        /// The Cloud storage
        /// </summary>
        Cloud = 100
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
