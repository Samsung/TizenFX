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
    /// <seealso cref="FolderCommand.Count(CountArguments)"/>
    /// <seealso cref="FolderCommand.CountMedia(string, CountArguments)"/>
    /// <seealso cref="FolderCommand.Select(SelectArguments)"/>
    /// <seealso cref="FolderCommand.SelectMedia(string, SelectArguments)"/>
    /// <seealso cref="MediaInfoCommand.CountMedia(CountArguments)"/>
    /// <seealso cref="MediaInfoCommand.SelectMedia(SelectArguments)"/>
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
        /// <since_tizen> 4 </since_tizen>
        public static string Genre => "MEDIA_GENRE";

        /// <summary>
        /// Gets the column name for the year of media.
        /// </summary>
        /// <value>The column name for the year of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.Year"/>
        /// <since_tizen> 4 </since_tizen>
        public static string Year => "MEDIA_YEAR";

        /// <summary>
        /// Gets the column name for the track number of media.
        /// </summary>
        /// <value>The column name for the track number of media.</value>
        /// <remarks>
        /// The value type is string.
        /// </remarks>
        /// <seealso cref="AudioInfo.TrackNumber"/>
        /// <since_tizen> 4 </since_tizen>
        public static string TrackNumber => "MEDIA_TRACK_NUM";

        /// <summary>
        /// Gets the column name for the width of media.
        /// </summary>
        /// <value>The column name for the width of media.</value>
        /// <remarks>
        /// The value type is integer.
        /// </remarks>
        /// <seealso cref="ImageInfo.Width"/>
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
}
