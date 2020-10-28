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
using System.Linq;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides the commands to manage tags in the database.
    /// </summary>
    /// <seealso cref="Tag"/>
    /// <since_tizen> 4 </since_tizen>
    public class TagCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        public TagCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of tags.
        /// </summary>
        /// <returns>The number of tags.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count()
        {
            return Count(arguments: null);
        }

        /// <summary>
        /// Retrieves the number of tags with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of tags filtered.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Tag.GetTagCount, arguments);
        }


        /// <summary>
        /// Deletes a tag from the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="tagId">The tag ID to delete.</param>
        /// <returns>true if the matched record was found and deleted, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Delete(int tagId)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            if (CommandHelper.Count(Interop.Tag.GetTagCount, $"{TagColumns.Id}={tagId}") == 0)
            {
                return false;
            }

            CommandHelper.Delete(Interop.Tag.Delete, tagId);
            return true;
        }


        /// <summary>
        /// Inserts a tag into the database with the specified name.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="name">The name of tag.</param>
        /// <returns>The <see cref="Tag"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Tag Insert(string name)
        {
            ValidateDatabase();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Tag name can't be an empty string.");
            }

            Interop.Tag.Insert(name, out var handle).ThrowIfError("Failed to insert a new tag");

            try
            {
                return new Tag(handle);
            }
            finally
            {
                Interop.Tag.Destroy(handle);
            }
        }

        /// <summary>
        /// Updates a tag with the specified name.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="tagId">The tag ID to update.</param>
        /// <param name="name">The new name.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool UpdateName(int tagId, string name)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (CommandHelper.Count(Interop.Tag.GetTagCount, $"{TagColumns.Id}={tagId}") == 0)
            {
                return false;
            }

            Interop.Tag.Create(out var handle).ThrowIfError("Failed to update");

            try
            {
                Interop.Tag.SetName(handle, name).ThrowIfError("Failed to update");
                Interop.Tag.Update(tagId, handle).ThrowIfError("Failed to update");

                return true;
            }
            finally
            {
                Interop.Tag.Destroy(handle);
            }
        }

        /// <summary>
        /// Retrieves the tag with the specified ID.
        /// </summary>
        /// <param name="tagId">The tag ID to select.</param>
        /// <returns>The <see cref="Tag"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Tag Select(int tagId)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            IntPtr handle = IntPtr.Zero;

            try
            {
                Interop.Tag.GetTagFromDb(tagId, out handle).ThrowIfError("Failed to query");

                return new Tag(handle);
            }
            catch (ArgumentException)
            {
                // Native FW returns ArgumentException when there's no matched record.
                return null;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Tag.Destroy(handle);
                }
            }

        }

        /// <summary>
        /// Retrieves all the tags.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Tag> Select()
        {
            return Select(arguments: null);
        }

        /// <summary>
        /// Retrieves the tags with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Tag> Select(SelectArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Select(arguments, Interop.Tag.ForeachTagFromDb, Tag.FromHandle);
        }

        /// <summary>
        /// Retrieves the number of media info of the tag.
        /// </summary>
        /// <param name="tagId">The tag ID.</param>
        /// <returns>The number of the media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia(int tagId)
        {
            return CountMedia(tagId, null);
        }

        /// <summary>
        /// Retrieves the number of the media information of the tag with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="tagId">The tag ID to query with.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of the media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia(int tagId, CountArguments arguments)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            return CommandHelper.Count(Interop.Tag.GetMediaCount, tagId, arguments);
        }

        /// <summary>
        /// Retrieves the media information of the tag.
        /// </summary>
        /// <param name="tagId">The tag ID.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia(int tagId)
        {
            return SelectMedia(tagId, null);
        }

        /// <summary>
        /// Retrieves the media information of the tag with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="tagId">The tag ID.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia(int tagId, SelectArguments filter)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            return CommandHelper.SelectMedia(Interop.Tag.ForeachMediaFromDb, tagId, filter);
        }

        private bool UpdateMember(int tagId, IEnumerable<string> mediaIds,
            Func<IntPtr, string, MediaContentError> func)
        {
            ValidateDatabase();

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tagId), tagId,
                    "Tag id can't be less than or equal to zero.");
            }

            if (mediaIds == null)
            {
                throw new ArgumentNullException(nameof(mediaIds));
            }

            if (mediaIds.Count() == 0)
            {
                throw new ArgumentException("mediaIds has no element.", nameof(mediaIds));
            }

            if (CommandHelper.Count(Interop.Tag.GetTagCount, $"{TagColumns.Id}={tagId}") == 0)
            {
                return false;
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Tag.Create(out handle).ThrowIfError("Failed to initialize update member operation");

            try
            {
                foreach (var mediaId in mediaIds)
                {
                    if (mediaId == null)
                    {
                        throw new ArgumentException("Media id should not be null.", nameof(mediaIds));
                    }

                    if (string.IsNullOrWhiteSpace(mediaId))
                    {
                        throw new ArgumentException("Media id should not be a zero-length string.", nameof(mediaId));
                    }

                    func(handle, mediaId).ThrowIfError("Failed to update member");
                }

                Interop.Tag.Update(tagId, handle).ThrowIfError("Failed to run member update");
                return true;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Tag.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Adds the media to a tag.
        /// </summary>
        /// <param name="tagId">The tag ID that the media will be added to.</param>
        /// <param name="mediaId">The media ID to add to the tag.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid media ID will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool AddMedia(int tagId, string mediaId)
        {
            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return AddMedia(tagId, new string[] { mediaId });
        }

        /// <summary>
        /// Adds the media set to a tag.
        /// </summary>
        /// <param name="tagId">The tag ID that the media will be added to.</param>
        /// <param name="mediaIds">The media ID to add to the tag.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid media IDs will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaIds"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaIds"/> has no element.<br/>
        ///     -or-<br/>
        ///     <paramref name="mediaIds"/> contains null value.<br/>
        ///     -or-<br/>
        ///     <paramref name="mediaIds"/> contains a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool AddMedia(int tagId, IEnumerable<string> mediaIds)
        {
            return UpdateMember(tagId, mediaIds, Interop.Tag.AddMedia);
        }

        /// <summary>
        /// Removes the media from a tag.
        /// </summary>
        /// <param name="tagId">The tag ID.</param>
        /// <param name="mediaId">The media ID to remove from the tag.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid media ID will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool RemoveMedia(int tagId, string mediaId)
        {
            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return RemoveMedia(tagId, new string[] { mediaId });
        }

        /// <summary>
        /// Removes the media set from a tag.
        /// </summary>
        /// <param name="tagId">The tag ID.</param>
        /// <param name="mediaIds">The collection of media ID to remove from the tag.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid IDs will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaIds"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaIds"/> has no element.<br/>
        ///     -or-<br/>
        ///     <paramref name="mediaIds"/> contains null value.<br/>
        ///     -or-<br/>
        ///     <paramref name="mediaIds"/> contains a zero-length string or white space.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="tagId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool RemoveMedia(int tagId, IEnumerable<string> mediaIds)
        {
            return UpdateMember(tagId, mediaIds, Interop.Tag.RemoveMedia);
        }
    }
}
