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
    /// Provides the column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="AlbumCommand.Count(CountArguments)"/>
    /// <seealso cref="AlbumCommand.CountMember(int, CountArguments)"/>
    /// <seealso cref="AlbumCommand.Select(SelectArguments)"/>
    /// <seealso cref="AlbumCommand.SelectMember(int, SelectArguments)"/>
    /// <seealso cref="BookmarkCommand.Count(CountArguments)"/>
    /// <seealso cref="BookmarkCommand.Select(SelectArguments)"/>
    /// <seealso cref="FaceInfoCommand.Select(SelectArguments)"/>
    /// <seealso cref="FolderCommand.Count(CountArguments)"/>
    /// <seealso cref="FolderCommand.CountMedia(string, CountArguments)"/>
    /// <seealso cref="FolderCommand.Select(SelectArguments)"/>
    /// <seealso cref="FolderCommand.SelectMedia(string, SelectArguments)"/>
    /// <seealso cref="MediaInfoCommand.CountMedia(CountArguments)"/>
    /// <seealso cref="MediaInfoCommand.SelectMedia(SelectArguments)"/>
    /// <seealso cref="PlaylistCommand.Count(CountArguments)"/>
    /// <seealso cref="PlaylistCommand.Select(SelectArguments)"/>
    /// <seealso cref="PlaylistCommand.CountMember(int, CountArguments)"/>
    /// <seealso cref="PlaylistCommand.SelectMember(int, SelectArguments)"/>
    /// <seealso cref="TagCommand.Count(CountArguments)"/>
    /// <seealso cref="TagCommand.CountMedia(int, CountArguments)"/>
    /// <seealso cref="TagCommand.Select(SelectArguments)"/>
    /// <seealso cref="TagCommand.SelectMedia(int, SelectArguments)"/>
    public static class MediaInfoColumns
    {
        /// <summary>
        /// Gets the column name for the ID of media.
        /// </summary>
        /// <value>The column name for the ID of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.Id"/>
        public static string Id => "MEDIA_ID";

        /// <summary>
        /// Gets the column name for the path of media.
        /// </summary>
        /// <value>The column name for the file path of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.Path"/>
        public static string Path => "MEDIA_PATH";

        /// <summary>
        /// Gets the column name for the display name of media.
        /// </summary>
        /// <value>The column name for the display name of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.DisplayName"/>
        public static string DisplayName => "MEDIA_DISPLAY_NAME";

        /// <summary>
        /// Gets the column name for the type of media.
        /// </summary>
        /// <value>The column name for the type of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// The value should be an integer that is one of the <see cref="MediaContent.MediaType"/> values.
        /// </remarks>
        /// <seealso cref="MediaInfo.MediaType"/>
        public static string MediaType => "MEDIA_TYPE";

        /// <summary>
        /// Gets the column name for the mime type of media.
        /// </summary>
        /// <value>The column name for the mime type of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.MimeType"/>
        public static string MimeType => "MEDIA_MIME_TYPE";

        /// <summary>
        /// Gets the column name for the file size of media.
        /// </summary>
        /// <value>The column name for the file size of media.</value>
        /// <remarks>The value type is integer.</remarks>
        /// <seealso cref="MediaInfo.FileSize"/>
        public static string FileSize => "MEDIA_SIZE";

        /// <summary>
        /// Gets the column name for the date added of media.
        /// </summary>
        /// <value>The column name for the date added of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// <see cref="DateTimeOffset"/> needs to be converted into the unix time.
        /// </remarks>
        /// <seealso cref="MediaInfo.DateAdded"/>
        /// <seealso cref="DateTimeOffset.ToUnixTimeSeconds"/>
        public static string DateAdded => "MEDIA_ADDED_TIME";

        /// <summary>
        /// Gets the column name for the date modified of media.
        /// </summary>
        /// <value>The column name for the date modified of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// <see cref="DateTimeOffset"/> needs to be converted into the unix time.
        /// </remarks>
        /// <seealso cref="MediaInfo.DateModified"/>
        /// <seealso cref="DateTimeOffset.ToUnixTimeSeconds"/>
        public static string DateModified => "MEDIA_MODIFIED_TIME";

        /// <summary>
        /// Gets the column name for the timeline of media.
        /// </summary>
        /// <value>The column name for the timeline of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// <see cref="DateTimeOffset"/> needs to be converted into the unix time.
        /// </remarks>
        /// <seealso cref="MediaInfo.Timeline"/>
        /// <seealso cref="DateTimeOffset.ToUnixTimeSeconds"/>
        public static string Timeline => "MEDIA_TIMELINE";

        /// <summary>
        /// Gets the column name for the thumbnail path of media.
        /// </summary>
        /// <value>The column name for the thumbnail path of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="MediaInfo.ThumbnailPath"/>
        public static string ThumbnailPath => "MEDIA_THUMBNAIL_PATH";

        /// <summary>
        /// Gets the column name for the title of media.
        /// </summary>
        /// <value>The column name for the title of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="MediaInfo.Title"/>
        public static string Title => "MEDIA_TITLE";

        /// <summary>
        /// Gets the column name for the album of media.
        /// </summary>
        /// <value>The column name for the album of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Album"/>
        public static string Album => "MEDIA_ALBUM";

        /// <summary>
        /// Gets the column name for the artist of media.
        /// </summary>
        /// <value>The column name for the artist of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Artist"/>
        /// <seealso cref="VideoInfo.Artist"/>
        public static string Artist => "MEDIA_ARTIST";

        /// <summary>
        /// Gets the column name for the album artist of media.
        /// </summary>
        /// <value>The column name for the album artist of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.AlbumArtist"/>
        /// <seealso cref="VideoInfo.AlbumArtist"/>
        public static string AlbumArtist => "MEDIA_ALBUM_ARTIST";

        /// <summary>
        /// Gets the column name for the genre of media.
        /// </summary>
        /// <value>The column name for the genre of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Genre"/>
        /// <seealso cref="VideoInfo.Genre"/>
        public static string Genre => "MEDIA_GENRE";

        /// <summary>
        /// Gets the column name for the composer of media.
        /// </summary>
        /// <value>The column name for the composer of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Composer"/>
        /// <seealso cref="VideoInfo.Composer"/>
        public static string Composer => "MEDIA_COMPOSER";

        /// <summary>
        /// Gets the column name for the year of media.
        /// </summary>
        /// <value>The column name for the year of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Year"/>
        /// <seealso cref="VideoInfo.Year"/>
        public static string Year => "MEDIA_YEAR";

        /// <summary>
        /// Gets the column name for the date recorded of media.
        /// </summary>
        /// <value>The column name for the date recorded of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.DateRecorded"/>
        /// <seealso cref="VideoInfo.DateRecorded"/>
        public static string DateRecorded => "MEDIA_RECORDED_DATE";

        /// <summary>
        /// Gets the column name for the copyright of media.
        /// </summary>
        /// <value>The column name for the copyright of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Copyright"/>
        /// <seealso cref="VideoInfo.Copyright"/>
        public static string Copyright => "MEDIA_COPYRIGHT";

        /// <summary>
        /// Gets the column name for the track number of media.
        /// </summary>
        /// <value>The column name for the track number of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.TrackNumber"/>
        /// <seealso cref="VideoInfo.TrackNumber"/>
        public static string TrackNumber => "MEDIA_TRACK_NUM";

        /// <summary>
        /// Gets the column name for the description of media.
        /// </summary>
        /// <value>The column name for the description of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="MediaInfo.Description"/>
        public static string Description => "MEDIA_DESCRIPTION";

        /// <summary>
        /// Gets the column name for the bit rate of media.
        /// </summary>
        /// <value>The column name for the bit rate of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.BitRate"/>
        /// <seealso cref="VideoInfo.BitRate"/>
        public static string BitRate => "MEDIA_BITRATE";

        /// <summary>
        /// Gets the column name for the bit per sample of media.
        /// </summary>
        /// <value>The column name for the bit per sample of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.BitPerSample"/>
        public static string BitPerSample => "MEDIA_BITPERSAMPLE";

        /// <summary>
        /// Gets the column name for the sample rate of media.
        /// </summary>
        /// <value>The column name for the sample rate of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.SampleRate"/>
        public static string SampleRate => "MEDIA_SAMPLERATE";

        /// <summary>
        /// Gets the column name for the channels of media.
        /// </summary>
        /// <value>The column name for the channels of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.Channels"/>
        public static string Channels => "MEDIA_CHANNEL";

        /// <summary>
        /// Gets the column name for the duration of media.
        /// </summary>
        /// <value>The column name for the duration of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.Duration"/>
        /// <seealso cref="VideoInfo.Duration"/>
        public static string Duration => "MEDIA_DURATION";

        /// <summary>
        /// Gets the column name for the longitude of media.
        /// </summary>
        /// <value>The column name for the longitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Longitude"/>
        public static string Longitude => "MEDIA_LONGITUDE";

        /// <summary>
        /// Gets the column name for the latitude of media.
        /// </summary>
        /// <value>The column name for the latitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Latitude"/>
        public static string Latitude => "MEDIA_LATITUDE";

        /// <summary>
        /// Gets the column name for the altitude of media.
        /// </summary>
        /// <value>The column name for the altitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Altitude"/>
        public static string Altitude => "MEDIA_ALTITUDE";

        /// <summary>
        /// Gets the column name for the width of media.
        /// </summary>
        /// <value>The column name for the width of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.Width"/>
        /// <seealso cref="VideoInfo.Width"/>
        public static string Width => "MEDIA_WIDTH";

        /// <summary>
        /// Gets the column name for the height of media.
        /// </summary>
        /// <value>The column name for the height of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.Height"/>
        /// <seealso cref="VideoInfo.Height"/>
        public static string Height => "MEDIA_HEIGHT";

        /// <summary>
        /// Gets the column name for the date taken of media.
        /// </summary>
        /// <value>The column name for the date taken of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.DateTaken"/>
        public static string DateTaken => "MEDIA_DATETAKEN";

        /// <summary>
        /// Gets the column name for the orientation of media.
        /// </summary>
        /// <value>The column name for the orientation of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// The value should be an integer that is one of the <see cref="MediaContent.Orientation"/> values.
        /// </remarks>
        /// <seealso cref="MediaContent.Orientation"/>
        /// <seealso cref="ImageInfo.Orientation"/>
        public static string Orientation => "MEDIA_ORIENTATION";

        /// <summary>
        /// Gets the column name for the rating of media.
        /// </summary>
        /// <value>The column name for the rating of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="MediaInfo.Rating"/>
        public static string Rating => "MEDIA_RATING";

        /// <summary>
        /// Gets the column name for the favorite status of media.
        /// </summary>
        /// <value>The column name for the favorite status of media.</value>
        /// <remarks>
        /// The value type is integer (1 : true, 0 : false).
        /// </remarks>
        /// <seealso cref="MediaInfo.IsFavorite"/>
        public static string Favorite => "MEDIA_FAVOURITE";

        /// <summary>
        /// Gets the column name for the drm of media.
        /// </summary>
        /// <value>The column name for the drm of media.</value>
        /// <remarks>
        /// The value type is integer (1 : true, 0 : false).
        /// </remarks>
        /// <seealso cref="MediaInfo.IsDrm"/>
        public static string IsDrm => "MEDIA_IS_DRM";

        /// <summary>
        /// Gets the column name for the storage type of media.
        /// </summary>
        /// <value>The column name for the storage type of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// The value should be an integer that is one of the <see cref="MediaContent.StorageType"/> values.
        /// </remarks>
        /// <seealso cref="MediaInfo.StorageType"/>
        public static string StorageType => "MEDIA_STORAGE_TYPE";

        /// <summary>
        /// Gets the column name for the exposure time of media.
        /// </summary>
        /// <value>The column name for the exposure time of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.ExposureTime"/>
        public static string ExposureTime => "MEDIA_EXPOSURE_TIME";

        /// <summary>
        /// Gets the column name for the FNumber of media.
        /// </summary>
        /// <value>The column name for the FNumber of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.FNumber"/>
        public static string FNumber => "MEDIA_FNUMBER";

        /// <summary>
        /// Gets the column name for the ISO of media.
        /// </summary>
        /// <value>The column name for the ISO of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.Iso"/>
        public static string Iso => "MEDIA_ISO";

        /// <summary>
        /// Gets the column name for the model of media.
        /// </summary>
        /// <value>The column name for the model of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="ImageInfo.Model"/>
        public static string Model => "MEDIA_MODEL";
    }

    /// <summary>
    /// Provides the folder column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="AlbumCommand.Count(CountArguments)"/>
    /// <seealso cref="AlbumCommand.Select(SelectArguments)"/>
    public static class AlbumColumns
    {
        /// <summary>
        /// Gets the column name for the name of album.
        /// </summary>
        /// <value>The column name for the name of album.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Album.Name"/>
        public static string Name => "MEDIA_ALBUM";

        /// <summary>
        /// Gets the column name for the artist of album.
        /// </summary>
        /// <value>The column name for the artist of album.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Album.Artist"/>
        public static string Artist => "MEDIA_ARTIST";
    }

    /// <summary>
    /// Provides the folder column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="FolderCommand.Count(CountArguments)"/>
    /// <seealso cref="FolderCommand.Select(SelectArguments)"/>
    public static class FolderColumns
    {
        /// <summary>
        /// Gets the column name for the ID of folder.
        /// </summary>
        /// <value>The column name for the ID of folder.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Folder.Id"/>
        public static string Id => "FOLDER_ID";

        /// <summary>
        /// Gets the column name for the path of folder.
        /// </summary>
        /// <value>The column name for the path of folder.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Folder.Path"/>
        public static string Path => "FOLDER_PATH";

        /// <summary>
        /// Gets the column name for the name of folder.
        /// </summary>
        /// <value>The column name for the name of folder.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Folder.Name"/>
        public static string Name => "FOLDER_NAME";

        /// <summary>
        /// Gets the column name for the storage type of folder.
        /// </summary>
        /// <value>The column name for the storage type of folder.</value>
        /// <remarks>
        /// The value type is integer.
        /// The value should be an integer that is one of the <see cref="MediaContent.StorageType"/> values.
        /// </remarks>
        /// <seealso cref="Folder.StorageType"/>
        public static string StorageType => "FOLDER_STORAGE_TYPE";
    }

    /// <summary>
    /// Provides the playlist column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="PlaylistCommand.Count(CountArguments)"/>
    /// <seealso cref="PlaylistCommand.Select(SelectArguments)"/>
    public static class PlaylistColumns
    {
        /// <summary>
        /// Gets the column name for the name of playlist.
        /// </summary>
        /// <value>The column name for the name of playlist.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Playlist.Name"/>
        public static string Name => "PLAYLIST_NAME";

        /// <summary>
        /// Gets the column name for the ID of playlist.
        /// </summary>
        /// <value>The column name for the ID of playlist.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Playlist.Id"/>
        public static string Id => "PLAYLIST_ID";

        /// <summary>
        /// Gets the column name for the member order of playlist.
        /// </summary>
        /// <value>The column name for the member order of playlist.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="PlaylistCommand.UpdatePlayOrder(int, PlayOrder)"/>
        public static string MemberOrder => "PLAYLIST_MEMBER_ORDER";

        /// <summary>
        /// Gets the column name for the number of members of playlist.
        /// </summary>
        /// <value>The column name for the number of members of playlist.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="PlaylistCommand.AddMember(int, string)"/>
        /// <seealso cref="PlaylistCommand.RemoveMember(int, int)"/>
        public static string Count => "PLAYLIST_MEDIA_COUNT";
    }

    /// <summary>
    /// Provides the tag column names that can be used for the <see cref="SelectArguments"/>.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="MediaInfoCommand.CountTag(string, CountArguments)"/>
    /// <seealso cref="MediaInfoCommand.SelectTag(string, SelectArguments)"/>
    /// <seealso cref="TagCommand.Count(CountArguments)"/>
    /// <seealso cref="TagCommand.CountMedia(int, CountArguments)"/>
    /// <seealso cref="TagCommand.Select(SelectArguments)"/>
    /// <seealso cref="TagCommand.SelectMedia(int, SelectArguments)"/>
    public static class TagColumns
    {
        /// <summary>
        /// Gets the column name for the name of tag.
        /// </summary>
        /// <value>The column name for the name of tag.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Tag.Name"/>
        public static string Name => "TAG_NAME";

        /// <summary>
        /// Gets the column name for the number of media of tag.
        /// </summary>
        /// <value>The column name for the number of media of tag.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="TagCommand.AddMedia(int, string)"/>
        /// <seealso cref="TagCommand.RemoveMedia(int, string)"/>
        public static string Count => "TAG_MEDIA_COUNT";

        /// <summary>
        /// Gets the column name for the ID of tag.
        /// </summary>
        /// <value>The column name for the ID of tag.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Tag.Id"/>
        public static string Id => "TAG_ID";
    }

    /// <summary>
    /// Provides the bookmark column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="BookmarkCommand.Count(CountArguments)"/>
    /// <seealso cref="BookmarkCommand.Select(SelectArguments)"/>
    /// <seealso cref="MediaInfoCommand.CountBookmark(string, CountArguments)"/>
    /// <seealso cref="MediaInfoCommand.SelectBookmark(string, SelectArguments)"/>
    public static class BookmarkColumns
    {
        /// <summary>
        /// Gets the column name for the offset of the bookmark.
        /// </summary>
        /// <value>The column name for the offset of the bookmark.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Bookmark.Offset"/>
        public static string Offset => "BOOKMARK_MARKED_TIME";

        /// <summary>
        /// Gets the column name for the ID of the bookmark.
        /// </summary>
        /// <value>The column name for the ID of the bookmark.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Bookmark.Id"/>
        public static string Id => "BOOKMARK_ID";

        /// <summary>
        /// Gets the column name for the name of the bookmark.
        /// </summary>
        /// <value>The column name for the name of the bookmark.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Bookmark.Name"/>
        public static string Name => "BOOKMARK_NAME";
    }

    /// <summary>
    /// Provides the face info column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="FaceInfoCommand.Select(SelectArguments)"/>
    /// <seealso cref="MediaInfoCommand.CountFaceInfo(string, CountArguments)"/>
    /// <seealso cref="MediaInfoCommand.SelectFaceInfo(string, SelectArguments)"/>
    public static class FaceInfoColumns
    {
        /// <summary>
        /// Gets the column name for the tag of face information.
        /// </summary>
        /// <value>The column name for the tag of face information.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="FaceInfo.Tag"/>
        public static string Tag => "MEDIA_FACE_TAG";

        /// <summary>
        /// Gets the column name for the ID of face information.
        /// </summary>
        /// <value>The column name for the ID of face information.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="FaceInfo.Id"/>
        public static string Id => "MEDIA_FACE_ID";
    }

    /// <summary>
    /// Provides the storage column names that can be used for Select and Count commands.
    /// </summary>
    /// <seealso cref="SelectArguments"/>
    /// <seealso cref="CountArguments"/>
    /// <seealso cref="QueryArguments.FilterExpression"/>
    /// <seealso cref="SelectArguments.SortOrder"/>
    /// <seealso cref="StorageCommand.Count(CountArguments)"/>
    /// <seealso cref="StorageCommand.Select(SelectArguments)"/>
    public static class StorageColumns
    {
        /// <summary>
        /// Gets the column name for the ID of storage.
        /// </summary>
        /// <value>The column name for the ID of storage.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Storage.Id"/>
        public static string Id => "STORAGE_ID";

        /// <summary>
        /// Gets the column name for the path of storage.
        /// </summary>
        /// <value>The column name for the path of storage.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Storage.Path"/>
        public static string Path => "STORAGE_PATH";

        /// <summary>
        /// Gets the column name for the type of storage.
        /// </summary>
        /// <value>The column name for the type of storage.</value>
        /// <remarks>
        /// The value type is integer.
        /// The value should be an integer that is one of the <see cref="MediaContent.StorageType"/> values.
        /// </remarks>
        /// <seealso cref="Storage.Type"/>
        public static string Type => "MEDIA_STORAGE_TYPE";
    }
}
