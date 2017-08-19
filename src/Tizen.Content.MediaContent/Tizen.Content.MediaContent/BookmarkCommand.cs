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
    /// Provides commands to manage bookmarks in database.
    /// </summary>
    /// <seealso cref="Bookmark"/>
    public class BookmarkCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookmarkCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">A <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed of.</exception>
        public BookmarkCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of bookmarks.
        /// </summary>
        /// <returns>The number of bookmarks.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public int Count()
        {
            return Count(null);
        }

        /// <summary>
        /// Retrieves the number of bookmarks with <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of bookmarks.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Bookmark.GetCount, arguments);
        }

        /// <summary>
        /// Inserts new bookmark into the database with the specified media and offset.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media id to be associated with.</param>
        /// <param name="offset">The time offset in milliseconds.</param>
        /// <returns>The <see cref="Bookmark"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        public Bookmark Insert(string mediaId, int offset)
        {
            return Insert(mediaId, offset, null);
        }

        /// <summary>
        /// Inserts new bookmark into the database with the specified media id, offset and name.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media id to be associated with.</param>
        /// <param name="offset">The time offset in milliseconds.</param>
        /// <param name="name">The name of the bookmark. This value can be null.</param>
        /// <returns>The <see cref="Bookmark"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        public Bookmark Insert(string mediaId, int offset, string name)
        {
            return Insert(mediaId, offset, name, null);
        }

        /// <summary>
        /// Inserts new bookmark into the database with the specified media id, offset, name and thumbnail path.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <remarks>
        /// Thumbnail may be useful only when the media is video.
        /// </remarks>
        /// <param name="mediaId">The media id to be associated with.</param>
        /// <param name="offset">The time offset in milliseconds.</param>
        /// <param name="name">The name of the bookmark. This value can be null.</param>
        /// <param name="thumbnailPath">The thumbnail path of the bookmark. This value can be null.</param>
        /// <returns>The <see cref="Bookmark"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        public Bookmark Insert(string mediaId, int offset, string name, string thumbnailPath)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            Interop.Bookmark.Create(mediaId, offset, out var handle).ThrowIfError("Failed to insert new bookmark");

            try
            {
                Interop.Bookmark.SetName(handle, name).ThrowIfError("Failed to insert new bookmark");

                if (thumbnailPath != null)
                {
                    Interop.Bookmark.SetThumbnailPath(handle, thumbnailPath).
                        ThrowIfError("Failed to insert new bookmark");
                }

                Interop.Bookmark.Insert(handle).ThrowIfError("Failed to insert new bookmark");

                return new Bookmark(handle);
            }
            finally
            {
                Interop.Bookmark.Destroy(handle);
            }
        }

        /// <summary>
        /// Deletes a bookmark from the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="bookmarkId">The bookmark id to delete.</param>
        /// <returns>true if the matched record was found and deleted, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bookmarkId"/> is less than zero.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        public bool Delete(int bookmarkId)
        {
            ValidateDatabase();

            if (bookmarkId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bookmarkId), bookmarkId,
                    "Bookmark id shouldn't be negative.");
            }

            if (CommandHelper.Count(Interop.Bookmark.GetCount, $"{BookmarkColumns.Id}={bookmarkId}") == 0)
            {
                return false;
            }

            CommandHelper.Delete(Interop.Bookmark.Delete, bookmarkId);

            return true;
        }


        /// <summary>
        /// Retrieves the bookmarks.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public MediaDataReader<Bookmark> Select()
        {
            return Select(null);
        }

        /// <summary>
        /// Retrieves the bookmarks with <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public MediaDataReader<Bookmark> Select(SelectArguments filter)
        {
            ValidateDatabase();

            return CommandHelper.Select(filter, Interop.Bookmark.ForeachFromDb, Bookmark.FromHandle);
        }

    }

}
