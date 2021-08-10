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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Tizen.System;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides commands to manage the media information and query related items in the database.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaInfoCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaInfoCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of the bookmarks added to the media.
        /// </summary>
        /// <param name="mediaId">The media ID to count the bookmarks added to the media.</param>
        /// <returns>The number of the bookmarks.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountBookmark(string mediaId)
        {
            return CountBookmark(mediaId, null);
        }

        /// <summary>
        /// Retrieves the number of the bookmarks added to the media with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="mediaId">The media ID to count the bookmarks added to the media.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of the bookmarks.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountBookmark(string mediaId, CountArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.Count(Interop.MediaInfo.GetBookmarkCount, mediaId, arguments);
        }

        /// <summary>
        /// Retrieves the bookmarks added to the media.
        /// </summary>
        /// <param name="mediaId">The media ID to select the bookmarks added to the media.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Bookmark> SelectBookmark(string mediaId)
        {
            return SelectBookmark(mediaId, null);
        }

        /// <summary>
        /// Retrieves the bookmarks added to the media with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="mediaId">The media ID to select the bookmarks added to the media.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Bookmark> SelectBookmark(string mediaId, SelectArguments filter)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.SelectMembers(mediaId, filter, Interop.MediaInfo.ForeachBookmarks,
                Bookmark.FromHandle);
        }

        /// <summary>
        /// Retrieves the number of the face information added to or detected from the media.
        /// </summary>
        /// <param name="mediaId">The media ID to count face information added to the media.</param>
        /// <returns>The number of the face information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountFaceInfo(string mediaId)
        {
            return CountFaceInfo(mediaId, null);
        }

        /// <summary>
        /// Retrieves the number of the face information added to or detected from the media with filter.
        /// </summary>
        /// <param name="mediaId">The media ID to count the face information added to the media.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of the face information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountFaceInfo(string mediaId, CountArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.Count(Interop.MediaInfo.GetFaceCount, mediaId, arguments);
        }

        /// <summary>
        /// Retrieves the face information added to or detected from the media.
        /// </summary>
        /// <param name="mediaId">The media ID to select face information added to the media.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<FaceInfo> SelectFaceInfo(string mediaId)
        {
            return SelectFaceInfo(mediaId, null);
        }

        /// <summary>
        /// Retrieves the face information added to or detected from the media with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="mediaId">The media ID to select the face information added to the media.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<FaceInfo> SelectFaceInfo(string mediaId, SelectArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.SelectMembers(mediaId, arguments, Interop.MediaInfo.ForeachFaces,
                FaceInfo.FromHandle);
        }

        /// <summary>
        /// Retrieves the number of tags that the media has.
        /// </summary>
        /// <returns>The number of tags.</returns>
        /// <param name="mediaId">The media ID to count tags added to the media.</param>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountTag(string mediaId)
        {
            return CountTag(mediaId, null);
        }

        /// <summary>
        /// Retrieves the number of tags that the media has with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="mediaId">The media ID to count tags added to the media.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of tags.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountTag(string mediaId, CountArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.Count(Interop.MediaInfo.GetTagCount, mediaId, arguments);
        }

        /// <summary>
        /// Retrieves the tags that the media has.
        /// </summary>
        /// <param name="mediaId">The media ID to select tags added to the media.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Tag> SelectTag(string mediaId)
        {
            return SelectTag(mediaId, null);
        }

        /// <summary>
        /// Retrieves the tags that the media has with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="mediaId">The media ID to select tags added to the media.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Tag> SelectTag(string mediaId, SelectArguments filter)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return CommandHelper.SelectMembers(mediaId, filter, Interop.MediaInfo.ForeachTags,
                Tag.FromHandle);
        }

        /// <summary>
        /// Retrieves the number of the media information.
        /// </summary>
        /// <returns>The number of the media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia()
        {
            return CountMedia(null);
        }

        /// <summary>
        /// Retrieves the number of the media information with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.MediaInfo.GetMediaCount, arguments);
        }

        /// <summary>
        /// Retrieves the media.
        /// </summary>
        /// <param name="mediaId">The media ID to retrieve.</param>
        /// <returns>The <see cref="MediaInfo"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaInfo SelectMedia(string mediaId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).Ignore(MediaContentError.InvalidParameter).
                ThrowIfError("Failed to query");

            try
            {
                return MediaInfo.FromHandle(handle);
            }
            finally
            {
                handle.Dispose();
            }
        }

        /// <summary>
        /// Retrieves the number of values grouped by the specified column with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="columnKey">The column key.</param>
        /// <returns>The number of groups.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnKey"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountGroupBy(MediaInfoColumnKey columnKey)
        {
            return CountGroupBy(columnKey, null);
        }

        /// <summary>
        /// Retrieves the number of values grouped by the specified column with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="columnKey">The column key.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of groups.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnKey"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountGroupBy(MediaInfoColumnKey columnKey, CountArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateEnum(typeof(MediaInfoColumnKey), columnKey, nameof(columnKey));

            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                Interop.Group.GetGroupCount(filter, columnKey, out var count).ThrowIfError("Failed to query count");
                return count;
            }
        }

        /// <summary>
        /// Retrieves the group values of the specified column.
        /// </summary>
        /// <param name="columnKey">The column key.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnKey"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<string> SelectGroupBy(MediaInfoColumnKey columnKey)
        {
            return SelectGroupBy(columnKey, null);
        }

        /// <summary>
        /// Retrieves the group values of the specified column with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="columnKey">The column key.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnKey"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<string> SelectGroupBy(MediaInfoColumnKey columnKey, SelectArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateEnum(typeof(MediaInfoColumnKey), columnKey, nameof(columnKey));

            List<string> list = new List<string>();

            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                Interop.Group.ForeachGroup(filter, columnKey, (name, _) =>
                {
                    list.Add(name);

                    return true;
                }).ThrowIfError("Failed to query");

                return new MediaDataReader<string>(list);
            }
        }

        /// <summary>
        /// Retrieves all the media.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia()
        {
            return SelectMedia(arguments: null);
        }

        /// <summary>
        /// Retrieves the media with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia(SelectArguments arguments)
        {
            ValidateDatabase();

            return new MediaDataReader<MediaInfo>(QueryMedia(arguments));
        }

        private static List<MediaInfo> QueryMedia(SelectArguments arguments)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                List<MediaInfo> list = new List<MediaInfo>();

                Exception caught = null;

                Interop.MediaInfo.ForeachMedia(filter, (handle, _) =>
                {
                    try
                    {
                        list.Add(MediaInfo.FromHandle(handle));
                        return true;
                    }
                    catch (Exception e)
                    {
                        caught = e;
                        return false;
                    }
                });

                if (caught != null)
                {
                    throw caught;
                }

                return list;
            }
        }

        /// <summary>
        /// Retrieves all matched ebook path with given <paramref name="keyword"/>.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="keyword"></param>
        /// <returns>A list of ebook path which contain <paramref name="keyword"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyword"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 9 </since_tizen>
        public MediaDataReader<string> SelectEbookPath(string keyword)
        {
            ValidateDatabase();

            IntPtr path = IntPtr.Zero;
            uint length = 0;

            ValidationUtil.ValidateNotNullOrEmpty(keyword, nameof(keyword));

            try
            {
                Interop.BookInfo.GetPathByKeyword(keyword, out path, out length).
                    ThrowIfError("Failed to get path by keyword");

                var list = new List<string>();
                var current = path;
                for (int i = 0; i < length; i++)
                {
                    list.Add(Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(current)));
                    current = (IntPtr)((long)current + Marshal.SizeOf(typeof(IntPtr)));
                }

                return new MediaDataReader<string>(list);
            }
            finally
            {
                var current = path;
                for (int i = 0; i < length; i++)
                {
                    Tizen.Multimedia.LibcSupport.Free(Marshal.ReadIntPtr(current));
                    current = (IntPtr)((long)current + Marshal.SizeOf(typeof(IntPtr)));
                }
            }
        }

        /// <summary>
        /// Deletes the media from the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to delete.</param>
        /// <returns>true if the matched record was found and deleted, otherwise false.</returns>
        /// <remarks>
        /// The <see cref="MediaDatabase.ScanFile(string)"/> or the <see cref="MediaDatabase.ScanFolderAsync(string)"/> can be used instead.<br/>
        /// Since API level 6, if the file related with the <paramref name="mediaId"/> in DB still exists in file system before calling this method,
        /// <see cref="InvalidOperationException"/> will be thrown to keep consistency in DB.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="MediaDatabase"/> is disconnected.<br/>
        ///     -or-<br/>
        ///     The file related with the <paramref name="mediaId"/> in DB still exists in file system. (Since API level 6)
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Delete(string mediaId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            if (CommandHelper.Count(
                Interop.MediaInfo.GetMediaCount, $"{MediaInfoColumns.Id}='{mediaId}'") == 0)
            {
                return false;
            }

            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).
                ThrowIfError("Failed to delete MediaInfo.");

            var path = InteropHelper.GetString(handle, Interop.MediaInfo.GetFilePath);

            // If we don't check file existence before calling `ScanFile` method,
            // The inconsistency between DB and file system could be occurred.
            if (File.Exists(path))
            {
                throw new InvalidOperationException("File still exists in file system. Remove it first.");
            }

            // Native 'delete' function was deprecated, so we need to use 'scan file' function instead of it.
            Database.ScanFile(path);

            return true;
        }

        /// <summary>
        /// Adds the media to the database.
        /// </summary>
        /// <param name="path">The file path to add.</param>
        /// <returns>The <see cref="MediaInfo"/> instance that contains the record information in the database.</returns>
        /// <remarks>
        ///     If the media already exists in the database, it returns the existing information.<br/>
        ///     <br/>
        ///     The <see cref="MediaDatabase.ScanFile(string)"/> or the <see cref="MediaDatabase.ScanFolderAsync(string)"/> can be used instead.<br/>
        ///     <br/>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.<br/>
        ///     <br/>
        ///     If http://tizen.org/feature/content.scanning.others feature is not supported and the specified file is other-type,
        ///     <see cref="NotSupportedException"/> will be thrown.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="path"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> contains a directory containing the ".scan_ignore" file.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exists.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaInfo Add(string path)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(path, nameof(path));

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("destination is not valid path.", path);
            }

            if (File.GetAttributes(path).HasFlag(FileAttributes.Hidden))
            {
                throw new ArgumentException($"{nameof(path)} contains a hidden path.", nameof(path));
            }

            Interop.MediaInfoHandle handle = null;

            try
            {
                Interop.MediaInfo.Insert(path, out handle).ThrowIfError("Failed to insert");

                return MediaInfo.FromHandle(handle);
            }
            finally
            {
                if (handle != null)
                {
                    handle.Dispose();
                }
            }
        }

        private static void ValidatePaths(IEnumerable<string> paths)
        {
            if (paths == null)
            {
                throw new ArgumentNullException(nameof(paths));
            }

            if (paths.Count() > 300)
            {
                throw new ArgumentException("Too many paths to add.");
            }

            foreach (var path in paths)
            {
                if (path == null)
                {
                    throw new ArgumentException($"{nameof(paths)} contains null.", nameof(paths));
                }

                if (File.Exists(path) == false)
                {
                    throw new FileNotFoundException($"{nameof(paths)} contains a path that does not exist. Path={path}.", path);
                }
            }

        }

        /// <summary>
        /// Adds media files into the media database.
        /// </summary>
        /// <remarks>
        ///     The paths that already exist in the database will be ignored.<br/>
        ///     At most 300 items can be added at once.<br/>
        ///     <br/>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.<br/>
        ///     <br/>
        ///     If http://tizen.org/feature/content.scanning.others feature is not supported and the specified file is other-type,
        ///     <see cref="NotSupportedException"/> will be thrown.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="paths">The paths of the media files to add.</param>
        /// <returns>A task that represents the asynchronous add operation.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="paths"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="paths"/> contains null.<br/>
        ///     -or-<br/>
        ///     <paramref name="paths"/> contains the invalid path.<br/>
        ///     -or-<br/>
        ///     The number of <paramref name="paths"/> is 300 or more items.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="paths"/> contains a path that does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public async Task AddAsync(IEnumerable<string> paths)
        {
            ValidateDatabase();

            ValidatePaths(paths);

            var pathArray = paths.ToArray();
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            Interop.MediaInfo.InsertCompletedCallback callback = (error, _) =>
            {
                if (error == MediaContentError.None)
                {
                    tcs.TrySetResult(true);
                }
                else
                {
                    tcs.TrySetException(error.AsException("Failed to add"));
                }
            };

            using (ObjectKeeper.Get(callback))
            {
                Interop.MediaInfo.BatchInsert(pathArray, pathArray.Length, callback).ThrowIfError("Failed to add");

                await tcs.Task;
            }
        }

        /// <summary>
        /// Updates the media with the favorite value.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to update.</param>
        /// <param name="value">The value indicating whether the media is favorite.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool UpdateFavorite(string mediaId, bool value)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            if (CommandHelper.Count(
                Interop.MediaInfo.GetMediaCount, $"{MediaInfoColumns.Id}='{mediaId}'") == 0)
            {
                return false;
            }

            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).ThrowIfError("Failed to update");

            if (handle.IsInvalid)
            {
                return false;
            }

            try
            {
                Interop.MediaInfo.SetFavorite(handle, value).ThrowIfError("Failed to update");

                Interop.MediaInfo.UpdateToDB(handle).ThrowIfError("Failed to update");
                return true;
            }
            finally
            {
                handle.Dispose();
            }
        }

        /// <summary>
        /// Updates the path of the media to the specified destination path in the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="mediaId">The media ID to move.</param>
        /// <param name="newPath">The path that the media has been moved to.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>
        ///     Usually, it is used after the media file is moved to the another path.<br/>
        ///     <br/>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="mediaId"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="newPath"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="newPath"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="newPath"/> contains a hidden directory that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="newPath"/> contains a directory containing the ".scan_ignore" file.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="newPath"/> does not exists.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Move(string mediaId, string newPath)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            ValidationUtil.ValidateNotNullOrEmpty(newPath, nameof(newPath));

            if (File.Exists(newPath) == false)
            {
                throw new FileNotFoundException("destination is not valid path.", newPath);
            }

            if (File.GetAttributes(newPath).HasFlag(FileAttributes.Hidden))
            {
                throw new ArgumentException($"{nameof(newPath)} contains a hidden path.", nameof(newPath));
            }

            //TODO can be improved if MoveToDB supports result value.
            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).
                Ignore(MediaContentError.InvalidParameter).ThrowIfError("Failed to move");

            if (handle.IsInvalid)
            {
                return false;
            }

            try
            {
                Interop.MediaInfo.MoveToDB(handle, newPath).ThrowIfError("Failed to move");
            }
            finally
            {
                handle.Dispose();
            }

            return true;
        }

        #region CreateThumbnailAsync
        /// <summary>
        /// Creates the thumbnail image for the given media.
        /// If the thumbnail already exists for the given media, the existing path will be returned.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to create the thumbnail.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the thumbnail path.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="MediaDatabase"/> is disconnected.<br/>
        ///     -or-<br/>
        ///     An internal error occurred while executing.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="RecordNotFoundException"><paramref name="mediaId"/> does not exist in the database.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="FileNotFoundException">The file of the media does not exists; moved or deleted.</exception>
        /// <exception cref="UnsupportedContentException">
        ///     The thumbnail is not available for the given media.<br/>
        ///     -or-<br/>
        ///     The media is in the external USB storage (<see cref="MediaInfo.StorageType"/> is <see cref="StorageType.ExternalUsb"/>).
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<string> CreateThumbnailAsync(string mediaId)
        {
            return CreateThumbnailAsync(mediaId, CancellationToken.None);
        }

        /// <summary>
        /// Creates the thumbnail image for the given media.
        /// If the thumbnail already exists for the given media, the existing path will be returned.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to create the thumbnail.</param>
        /// <param name="cancellationToken">The token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the thumbnail path.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="MediaDatabase"/> is disconnected.<br/>
        ///     -or-<br/>
        ///     An internal error occurred while executing.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="RecordNotFoundException"><paramref name="mediaId"/> does not exist in the database.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="FileNotFoundException">The file of the media does not exists; moved or deleted.</exception>
        /// <exception cref="UnsupportedContentException">
        ///     The thumbnail is not available for the given media.<br/>
        ///     -or-<br/>
        ///     The media is in the external USB storage (<see cref="MediaInfo.StorageType"/> is <see cref="StorageType.ExternalUsb"/>).
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<string> CreateThumbnailAsync(string mediaId, CancellationToken cancellationToken)
        {
            ValidateDatabase();

            return cancellationToken.IsCancellationRequested ? Task.FromCanceled<string>(cancellationToken) :
                CreateThumbnailAsyncCore(mediaId, cancellationToken);
        }

        private async Task<string> CreateThumbnailAsyncCore(string mediaId, CancellationToken cancellationToken)
        {
            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            var tcs = new TaskCompletionSource<string>();

            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).ThrowIfError("Failed to create thumbnail");

            if (handle.IsInvalid)
            {
                throw new RecordNotFoundException("Media does not exist.");
            }

            using (handle)
            {
                var path = InteropHelper.GetString(handle, Interop.MediaInfo.GetFilePath);

                foreach (var extendedInternal in StorageManager.Storages.Where(s => s.StorageType == StorageArea.ExtendedInternal))
                {
                    if (path.Contains(extendedInternal.RootDirectory))
                    {
                        throw new UnsupportedContentException("The media is in external usb storage.");
                    }
                }

                if (File.Exists(path) == false)
                {
                    throw new FileNotFoundException($"The media file does not exist. Path={path}.", path);
                }

                using (RegisterCancelThumbnail(cancellationToken, tcs, handle))
                using (var cbKeeper = ObjectKeeper.Get(GetCreateThumbnailCallback(tcs)))
                {
                    Interop.MediaInfo.CreateThumbnail(handle, cbKeeper.Target).ThrowIfError("Failed to create thumbnail");

                    return await tcs.Task;
                }
            }
        }

        private static Interop.MediaInfo.ThumbnailCompletedCallback GetCreateThumbnailCallback(
            TaskCompletionSource<string> tcs)
        {
            return (error, path, _) =>
            {
                if (error != MediaContentError.None)
                {
                    tcs.TrySetException(error.AsException("Failed to create thumbnail"));
                }
                else
                {
                    tcs.TrySetResult(path);
                }
            };
        }

        private static IDisposable RegisterCancelThumbnail(CancellationToken cancellationToken,
            TaskCompletionSource<string> tcs, Interop.MediaInfoHandle handle)
        {
            if (cancellationToken.CanBeCanceled == false)
            {
                return null;
            }

            return cancellationToken.Register(() =>
            {
                if (tcs.Task.IsCompleted)
                {
                    return;
                }

                Interop.MediaInfo.CancelThumbnail(handle).ThrowIfError("Failed to cancel");
                tcs.TrySetCanceled();
            });
        }
        #endregion

        #region DetectFaceAsync
        /// <summary>
        /// Detects faces from the given media.
        /// If the thumbnail already exists for the given media, the existing path will be returned.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <param name="mediaId">The media ID to create the thumbnail.</param>
        /// <returns>A task that represents the asynchronous add operation. The task result contains the number of faces detected.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="MediaDatabase"/> is disconnected.<br/>
        ///     -or-<br/>
        ///     An internal error occurred while executing.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="RecordNotFoundException"><paramref name="mediaId"/> does not exist in the database.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="FileNotFoundException">The file of the media does not exists; moved or deleted.</exception>
        /// <exception cref="UnsupportedContentException">Face detection is not available for the given media.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<int> DetectFaceAsync(string mediaId)
        {
            return DetectFaceAsync(mediaId, CancellationToken.None);
        }

        /// <summary>
        /// Creates the thumbnail image for the given media.
        /// If the thumbnail already exists for the given media, the existing path will be returned.
        /// </summary>
        /// <remarks>
        ///     Media in the external storage is not supported, with the exception of MMC.
        ///     Only JPEG, PNG, BMP images are supported.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <param name="mediaId">The media ID to create the thumbnail.</param>
        /// <param name="cancellationToken">The token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of faces detected.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="MediaDatabase"/> is disconnected.<br/>
        ///     -or-<br/>
        ///     An internal error occurred while executing.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="RecordNotFoundException"><paramref name="mediaId"/> does not exist in the database.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="FileNotFoundException">The file of the media does not exists; moved or deleted.</exception>
        /// <exception cref="UnsupportedContentException">
        ///     Face detection is not available for the given media.<br/>
        ///     -or-<br/>
        ///     The media is in the external USB storage (<see cref="MediaInfo.StorageType"/> is <see cref="StorageType.ExternalUsb"/>).
        /// </exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<int> DetectFaceAsync(string mediaId, CancellationToken cancellationToken)
        {
            if (Features.IsSupported(Features.FaceRecognition) == false)
            {
                throw new NotSupportedException($"The feature({Features.FaceRecognition}) is not supported.");
            }

            ValidateDatabase();

            return cancellationToken.IsCancellationRequested ? Task.FromCanceled<int>(cancellationToken) :
                DetectFaceAsyncCore(mediaId, cancellationToken);
        }

        private static async Task<int> DetectFaceAsyncCore(string mediaId, CancellationToken cancellationToken)
        {
            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            var tcs = new TaskCompletionSource<int>();

            Interop.MediaInfo.GetMediaFromDB(mediaId, out var handle).ThrowIfError("Failed to detect faces");

            if (handle.IsInvalid)
            {
                throw new RecordNotFoundException("Media does not exist.");
            }

            using (handle)
            {
                if (InteropHelper.GetValue<StorageType>(handle, Interop.MediaInfo.GetStorageType) == StorageType.ExternalUsb)
                {
                    throw new UnsupportedContentException("The media is in external usb storage.");
                }

                if (InteropHelper.GetValue<MediaType>(handle, Interop.MediaInfo.GetMediaType) != MediaType.Image)
                {
                    throw new UnsupportedContentException("Only image is supported.");
                }

                // Native P/Invoke function also check below case, but it returns invalid operation error.
                // So we check it here to throw more proper exception.
                string mimeType = InteropHelper.GetString(handle, Interop.MediaInfo.GetMimeType);
                if (!mimeType.Equals("image/jpeg") && !mimeType.Equals("image/png") && !mimeType.Equals("image/bmp"))
                {
                    throw new UnsupportedContentException($"{mimeType} is not supported. Only JPEG, PNG, BMP is supported.");
                }

                var path = InteropHelper.GetString(handle, Interop.MediaInfo.GetFilePath);

                if (File.Exists(path) == false)
                {
                    throw new FileNotFoundException($"The media file does not exist. Path={path}.", path);
                }

                using (RegisterCancelFaceDetection(cancellationToken, tcs, handle))
                using (var cbKeeper = ObjectKeeper.Get(GetFaceDetectionCallback(tcs)))
                {
                    Interop.MediaInfo.StartFaceDetection(handle, cbKeeper.Target).ThrowIfError("Failed to detect faces");

                    return await tcs.Task;
                }
            }
        }

        private static Interop.MediaInfo.FaceDetectionCompletedCallback GetFaceDetectionCallback(
            TaskCompletionSource<int> tcs)
        {
            return (error, count, _) =>
            {
                if (error != MediaContentError.None)
                {
                    tcs.TrySetException(error.AsException("Failed to detect faces"));
                }
                else
                {
                    tcs.TrySetResult(count);
                }
            };
        }

        private static IDisposable RegisterCancelFaceDetection(CancellationToken cancellationToken,
            TaskCompletionSource<int> tcs, Interop.MediaInfoHandle handle)
        {
            if (cancellationToken.CanBeCanceled == false)
            {
                return null;
            }

            return cancellationToken.Register(() =>
            {
                if (tcs.Task.IsCompleted)
                {
                    return;
                }

                Interop.MediaInfo.CancelFaceDetection(handle).ThrowIfError("Failed to cancel");
                tcs.TrySetCanceled();
            });
        }
        #endregion
    }
}
