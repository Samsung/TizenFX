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
    /// <since_tizen> 4 </since_tizen>
    public static class MediaInfoColumns
    {
        /// <summary>
        /// Gets the column name for the ID of media.
        /// </summary>
        /// <value>The column name for the ID of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.Id"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Id => "MEDIA_ID";

        /// <summary>
        /// Gets the column name for the path of media.
        /// </summary>
        /// <value>The column name for the file path of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.Path"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Path => "MEDIA_PATH";

        /// <summary>
        /// Gets the column name for the display name of media.
        /// </summary>
        /// <value>The column name for the display name of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.DisplayName"/>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static string MediaType => "MEDIA_TYPE";

        /// <summary>
        /// Gets the column name for the mime type of media.
        /// </summary>
        /// <value>The column name for the mime type of media.</value>
        /// <remarks>The value type is string.</remarks>
        /// <seealso cref="MediaInfo.MimeType"/>
        /// <since_tizen> 4 </since_tizen>
        public static string MimeType => "MEDIA_MIME_TYPE";

        /// <summary>
        /// Gets the column name for the file size of media.
        /// </summary>
        /// <value>The column name for the file size of media.</value>
        /// <remarks>The value type is integer.</remarks>
        /// <seealso cref="MediaInfo.FileSize"/>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Timeline => "MEDIA_TIMELINE";

        /// <summary>
        /// Gets the column name for the thumbnail path of media.
        /// </summary>
        /// <value>The column name for the thumbnail path of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="MediaInfo.ThumbnailPath"/>
        /// <since_tizen> 4 </since_tizen>
        public static string ThumbnailPath => "MEDIA_THUMBNAIL_PATH";

        /// <summary>
        /// Gets the column name for the title of media.
        /// </summary>
        /// <value>The column name for the title of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="MediaInfo.Title"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Title => "MEDIA_TITLE";

        /// <summary>
        /// Gets the column name for the album of media.
        /// </summary>
        /// <value>The column name for the album of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Album"/>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string DateRecorded => "MEDIA_RECORDED_DATE";

        /// <summary>
        /// Gets the column name for the track number of media.
        /// </summary>
        /// <value>The column name for the track number of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.TrackNumber"/>
        /// <seealso cref="VideoInfo.TrackNumber"/>
        /// <since_tizen> 4 </since_tizen>
        public static string TrackNumber => "MEDIA_TRACK_NUM";

        /// <summary>
        /// Gets the column name for the duration of media.
        /// </summary>
        /// <value>The column name for the duration of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="AudioInfo.Duration"/>
        /// <seealso cref="VideoInfo.Duration"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Duration => "MEDIA_DURATION";

        /// <summary>
        /// Gets the column name for the longitude of media.
        /// </summary>
        /// <value>The column name for the longitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Longitude"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Longitude => "MEDIA_LONGITUDE";

        /// <summary>
        /// Gets the column name for the latitude of media.
        /// </summary>
        /// <value>The column name for the latitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Latitude"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Latitude => "MEDIA_LATITUDE";

        /// <summary>
        /// Gets the column name for the altitude of media.
        /// </summary>
        /// <value>The column name for the altitude of media.</value>
        /// <remarks>
        /// The value type is real.
        /// </remarks>
        /// <seealso cref="MediaInfo.Altitude"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static string Height => "MEDIA_HEIGHT";

        /// <summary>
        /// Gets the column name for the date taken of media.
        /// </summary>
        /// <value>The column name for the date taken of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.DateTaken"/>
        /// <since_tizen> 4 </since_tizen>
        public static string DateTaken => "MEDIA_DATETAKEN";

        /// <summary>
        /// Gets the column name for the favorite status of media.
        /// </summary>
        /// <value>The column name for the favorite status of media.</value>
        /// <remarks>
        /// The value type is integer (1 : true, 0 : false).
        /// </remarks>
        /// <seealso cref="MediaInfo.IsFavorite"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Favorite => "MEDIA_FAVOURITE";

        /// <summary>
        /// Gets the column name for the drm of media.
        /// </summary>
        /// <value>The column name for the drm of media.</value>
        /// <remarks>
        /// The value type is integer (1 : true, 0 : false).
        /// </remarks>
        /// <seealso cref="MediaInfo.IsDrm"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string IsDrm => "MEDIA_IS_DRM";
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
    /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static string Name => "MEDIA_ALBUM";

        /// <summary>
        /// Gets the column name for the artist of album.
        /// </summary>
        /// <value>The column name for the artist of album.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Album.Artist"/>
        /// <since_tizen> 4 </since_tizen>
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
    /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static string Id => "FOLDER_ID";

        /// <summary>
        /// Gets the column name for the path of folder.
        /// </summary>
        /// <value>The column name for the path of folder.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Folder.Path"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Path => "FOLDER_PATH";

        /// <summary>
        /// Gets the column name for the name of folder.
        /// </summary>
        /// <value>The column name for the name of folder.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Folder.Name"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Name => "FOLDER_NAME";
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
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Name => "PLAYLIST_NAME";

        /// <summary>
        /// Gets the column name for the ID of playlist.
        /// </summary>
        /// <value>The column name for the ID of playlist.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Playlist.Id"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Id => "PLAYLIST_ID";

        /// <summary>
        /// Gets the column name for the member order of playlist.
        /// </summary>
        /// <value>The column name for the member order of playlist.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="PlaylistCommand.UpdatePlayOrder(int, PlayOrder)"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
    /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Count => "TAG_MEDIA_COUNT";

        /// <summary>
        /// Gets the column name for the ID of tag.
        /// </summary>
        /// <value>The column name for the ID of tag.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Tag.Id"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Offset => "BOOKMARK_MARKED_TIME";

        /// <summary>
        /// Gets the column name for the ID of the bookmark.
        /// </summary>
        /// <value>The column name for the ID of the bookmark.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="Bookmark.Id"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Id => "BOOKMARK_ID";

        /// <summary>
        /// Gets the column name for the name of the bookmark.
        /// </summary>
        /// <value>The column name for the name of the bookmark.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="Bookmark.Name"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static string Name => "BOOKMARK_NAME";
    }
}
