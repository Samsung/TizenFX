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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides the commands to manage playlists in the database.
    /// </summary>
    /// <seealso cref="Playlist"/>
    /// <since_tizen> 4 </since_tizen>
    public class PlaylistCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">A <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PlaylistCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of playlists.
        /// </summary>
        /// <returns>The number of playlists.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count()
        {
            return Count(null);
        }

        /// <summary>
        /// Retrieves the number of playlists with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of playlists.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Playlist.GetPlaylistCount, arguments);
        }

        /// <summary>
        /// Retrieves the play order of the member.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="memberId">The member ID of the playlist.</param>
        /// <returns>The order of the member in the playlist.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="playlistId"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="memberId"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public int GetPlayOrder(int playlistId, int memberId)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (memberId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(memberId), memberId,
                    "Member id can't be less than or equal to zero.");
            }

            Interop.Playlist.GetPlayOrder(playlistId, memberId, out var order).ThrowIfError("Failed to query");

            return order;
        }

        /// <summary>
        /// Deletes a playlist from the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="playlistId">The playlist ID to delete.</param>
        /// <returns>true if the matched record was found and deleted, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Delete(int playlistId)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (Select(playlistId) == null)
            {
                return false;
            }

            CommandHelper.Delete(Interop.Playlist.Delete, playlistId);
            return true;
        }

        /// <summary>
        /// Inserts the playlist into the database from the specified M3U file.
        /// </summary>
        /// <remarks>
        ///     If you want to access an internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access an external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="name">The name of the playlist.</param>
        /// <param name="path">The path to a M3U file to import.</param>
        /// <returns>The <see cref="Playlist"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="name"/> is a zero-length string.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> is a zero-length string, contains only white space.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exists.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Playlist InsertFromFile(string name, string path)
        {
            ValidateDatabase();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Playlist name can't be an empty string.");
            }

            ValidationUtil.ValidateNotNullOrEmpty(path, nameof(path));

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("The specified path does not exists.", path);
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Playlist.ImportFromFile(path, name, out handle).ThrowIfError("Failed to insert");

            try
            {
                return new Playlist(handle);
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }
        /// <summary>
        /// Exports the playlist to a M3U file.
        /// </summary>
        /// <remarks>
        ///     If the file already exists in the file system, then it will be overwritten.<br/>
        ///     <br/>
        ///     If you want to access an internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access an external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="playlistId">The playlist ID to export.</param>
        /// <param name="path">The path to a M3U file.</param>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <exception cref="RecordNotFoundException">No matching playlist exists.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void ExportToFile(int playlistId, string path)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(path, nameof(path));

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            IntPtr handle = IntPtr.Zero;
            try
            {
                Interop.Playlist.GetPlaylistFromDb(playlistId, out handle).ThrowIfError("Failed to query");

                Interop.Playlist.ExportToFile(handle, path).ThrowIfError("Failed to export");
            }
            catch (ArgumentException)
            {
                // Native FW returns ArgumentException when there's no matched record.
                throw new RecordNotFoundException("No matching playlist exists.");
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Inserts the playlist into the database with the specified name.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="name">The name of the playlist.</param>
        /// <returns>The <see cref="Playlist"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is a zero-length string.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Playlist Insert(string name)
        {
            return Insert(name, null);
        }

        /// <summary>
        /// Inserts the playlist into the database with the specified name and the thumbnail path.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="name">The name of the playlist.</param>
        /// <param name="thumbnailPath">The path of the thumbnail for the playlist. This value can be null.</param>
        /// <returns>The <see cref="Playlist"/> instance that contains the record information inserted.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is a zero-length string.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Playlist Insert(string name, string thumbnailPath)
        {
            ValidateDatabase();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Playlist name can't be an empty string.");
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Playlist.Create(out handle).ThrowIfError("Failed to insert");

            try
            {
                Interop.Playlist.SetName(handle, name).ThrowIfError("Failed to insert");

                if (thumbnailPath != null)
                {
                    Interop.Playlist.SetThumbnailPath(handle, thumbnailPath).ThrowIfError("Failed to insert");
                }

                Interop.Playlist.Insert(handle).ThrowIfError("Failed to insert");
                return new Playlist(handle);
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Retrieves the playlists.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Playlist> Select()
        {
            return Select(null);
        }

        /// <summary>
        /// Retrieves the playlists with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Playlist> Select(SelectArguments filter)
        {
            ValidateDatabase();

            return CommandHelper.Select(filter, Interop.Playlist.ForeachPlaylistFromDb,
                Playlist.FromHandle);
        }

        /// <summary>
        /// Retrieves the playlist with the specified playlist ID.
        /// </summary>
        /// <param name="playlistId">The playlist ID to select.</param>
        /// <returns>The <see cref="Playlist"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Playlist Select(int playlistId)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            IntPtr handle = IntPtr.Zero;

            try
            {
                Interop.Playlist.GetPlaylistFromDb(playlistId, out handle).ThrowIfError("Failed to query");

                return new Playlist(handle);
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
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Retrieves the number of media information of the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID to count media added to the playlist.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMember(int playlistId)
        {
            return CountMember(playlistId, null);
        }

        /// <summary>
        /// Retrieves the number of media information of the playlist with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="playlistId">The playlist ID to count the media added to the playlist.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMember(int playlistId, CountArguments arguments)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            return CommandHelper.Count(Interop.Playlist.GetMediaCountFromDb, playlistId, arguments);

        }

        private static List<PlaylistMember> GetMembers(int playlistId, SelectArguments arguments)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                Exception caught = null;
                List<PlaylistMember> list = new List<PlaylistMember>();

                Interop.Playlist.ForeachMediaFromDb(playlistId, filter, (memberId, mediaInfoHandle, _) =>
                {
                    try
                    {
                        list.Add(new PlaylistMember(memberId, MediaInfo.FromHandle(mediaInfoHandle)));

                        return true;
                    }
                    catch (Exception e)
                    {
                        caught = e;
                        return false;
                    }
                }).ThrowIfError("Failed to query");

                if (caught != null)
                {
                    throw caught;
                }

                return list;
            }
        }

        /// <summary>
        /// Retrieves the member ID of the media in the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="mediaId">The media ID.</param>
        /// <returns>The member ID if the member was found in the playlist, otherwise -1.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int GetMemberId(int playlistId, string mediaId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            var reader = SelectMember(playlistId, new SelectArguments()
            {
                FilterExpression = $"{MediaInfoColumns.Id}='{mediaId}'"
            });
            reader.Read();

            return reader.Current?.MemberId ?? -1;
        }

        /// <summary>
        /// Retrieves the media information of the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID to query with.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<PlaylistMember> SelectMember(int playlistId)
        {
            return SelectMember(playlistId, null);
        }

        /// <summary>
        /// Retrieves the media information of the playlist with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="playlistId">The playlist ID to query with.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<PlaylistMember> SelectMember(int playlistId, SelectArguments filter)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            return new MediaDataReader<PlaylistMember>(GetMembers(playlistId, filter));
        }

        /// <summary>
        /// Updates the playlist with the specified values.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="playlistId">The playlist ID to update.</param>
        /// <param name="values">The values for the update.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>Only values set in the <see cref="PlaylistUpdateValues"/> are updated.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Update(int playlistId, PlaylistUpdateValues values)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (CommandHelper.Count(
                Interop.Playlist.GetPlaylistCount, $"{PlaylistColumns.Id}={playlistId}") == 0)
            {
                return false;
            }

            Interop.Playlist.Create(out var handle).ThrowIfError("Failed to update");

            try
            {
                if (values.Name != null)
                {
                    Interop.Playlist.SetName(handle, values.Name).ThrowIfError("Failed to update");
                }

                if (values.ThumbnailPath != null)
                {
                    Interop.Playlist.SetThumbnailPath(handle, values.ThumbnailPath).ThrowIfError("Failed to update");
                }

                Interop.Playlist.Update(playlistId, handle).ThrowIfError("Failed to update");
                return true;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Adds the media to the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID that the media will be added to.</param>
        /// <param name="mediaId">The media ID to add to the playlist.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid media ID will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="mediaId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool AddMember(int playlistId, string mediaId)
        {
            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));

            return AddMembers(playlistId, new string[] { mediaId });
        }

        /// <summary>
        /// Adds the media set to the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID that the media will be added to.</param>
        /// <param name="mediaIds">The collection of media ID to add to the playlist.</param>
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
        ///     <paramref name="mediaIds"/> contains a zero-length string or white space.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool AddMembers(int playlistId, IEnumerable<string> mediaIds)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (mediaIds == null)
            {
                throw new ArgumentNullException(nameof(mediaIds));
            }

            if (mediaIds.Count() == 0)
            {
                throw new ArgumentException("mediaIds has no element.", nameof(mediaIds));
            }

            if (CommandHelper.Count(
                Interop.Playlist.GetPlaylistCount, $"{PlaylistColumns.Id}={playlistId}") == 0)
            {
                return false;
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Playlist.Create(out handle).ThrowIfError("Failed to add member");

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
                        throw new ArgumentException("Media id should not be empty.", nameof(mediaId));
                    }

                    Interop.Playlist.AddMedia(handle, mediaId).ThrowIfError("Failed to add member");
                }

                Interop.Playlist.Update(playlistId, handle).ThrowIfError("Failed to add member");
                return true;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Removes a member from the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="memberId">The member ID to be removed.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid ID will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="playlistId"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="memberId"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public bool RemoveMember(int playlistId, int memberId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(memberId), memberId,
                    "Member id can't be less than or equal to zero.");
            }

            return RemoveMembers(playlistId, new int[] { memberId });
        }

        /// <summary>
        /// Removes a media set from the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="memberIds">The collection of member ID to remove from to the playlist.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The invalid IDs will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="memberIds"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="memberIds"/> has no element.<br/>
        ///     -or-<br/>
        ///     <paramref name="memberIds"/> contains a value which is less than or equal to zero.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool RemoveMembers(int playlistId, IEnumerable<int> memberIds)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (memberIds == null)
            {
                throw new ArgumentNullException(nameof(memberIds));
            }

            if (memberIds.Count() == 0)
            {
                throw new ArgumentException("memberIds has no element.", nameof(memberIds));
            }

            if (CommandHelper.Count(
                Interop.Playlist.GetPlaylistCount, $"{PlaylistColumns.Id}={playlistId}") == 0)
            {
                return false;
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Playlist.Create(out handle).ThrowIfError("Failed to add member");

            try
            {
                foreach (var memberId in memberIds)
                {
                    if (memberId <= 0)
                    {
                        throw new ArgumentException(nameof(memberIds),
                            "Member id can't be less than or equal to zero.");
                    }

                    Interop.Playlist.RemoveMedia(handle, memberId).ThrowIfError("Failed to add member");
                }

                Interop.Playlist.Update(playlistId, handle).ThrowIfError("Failed to add member");
                return true;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Updates a play order of the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="playOrder">The <see cref="PlayOrder"/> to apply.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The <see cref="PlayOrder.MemberId"/> that is invalid will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="playOrder"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool UpdatePlayOrder(int playlistId, PlayOrder playOrder)
        {
            if (playOrder == null)
            {
                throw new ArgumentNullException(nameof(playOrder));
            }
            return UpdatePlayOrders(playlistId, new PlayOrder[] { playOrder });
        }

        /// <summary>
        /// Updates play orders of the playlist.
        /// </summary>
        /// <param name="playlistId">The playlist ID.</param>
        /// <param name="orders">The collection of the <see cref="PlayOrder"/> to apply.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <remarks>The <see cref="PlayOrder.MemberId"/> that is invalid will be ignored.</remarks>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="orders"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="orders"/> has no element.<br/>
        ///     -or-<br/>
        ///     <paramref name="orders"/> contains a null value.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="playlistId"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool UpdatePlayOrders(int playlistId, IEnumerable<PlayOrder> orders)
        {
            ValidateDatabase();

            if (playlistId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playlistId), playlistId,
                    "Playlist id can't be less than or equal to zero.");
            }

            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders));
            }

            if (orders.Count() == 0)
            {
                throw new ArgumentException("memberIds has no element.", nameof(orders));
            }

            if (CommandHelper.Count(
                Interop.Playlist.GetPlaylistCount, $"{PlaylistColumns.Id}={playlistId}") == 0)
            {
                return false;
            }

            IntPtr handle = IntPtr.Zero;
            Interop.Playlist.Create(out handle).ThrowIfError("Failed to add member");

            try
            {
                foreach (var order in orders)
                {
                    if (order == null)
                    {
                        throw new ArgumentException(nameof(orders),
                            "orders should not contain null value.");
                    }
                    Interop.Playlist.SetPlayOrder(handle, order.MemberId, order.Value).ThrowIfError("Failed to add member");
                }

                Interop.Playlist.Update(playlistId, handle).ThrowIfError("Failed to add member");
                return true;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Playlist.Destroy(handle);
                }
            }
        }
    }
}