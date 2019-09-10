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
    /// Provides commands to manage albums in the database.
    /// </summary>
    /// <seealso cref="Album"/>
    /// <since_tizen> 4 </since_tizen>
    public class AlbumCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        public AlbumCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of albums.
        /// </summary>
        /// <returns>The number of albums.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count()
        {
            return Count(null);
        }

        /// <summary>
        /// Retrieves the number of albums with <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of albums.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Album.GetAlbumCountFromDb, arguments);
        }

        /// <summary>
        /// Retrieves all the albums.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Album> Select()
        {
            return Select(null);
        }

        /// <summary>
        /// Retrieves the albums with <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Album> Select(SelectArguments filter)
        {
            ValidateDatabase();

            return CommandHelper.Select(filter, Interop.Album.ForeachAlbumFromDb, Album.FromHandle);
        }

        /// <summary>
        /// Retrieves an album with the album ID.
        /// </summary>
        /// <param name="albumId">The ID of the album to query with.</param>
        /// <returns>The <see cref="Album"/> if <paramref name="albumId"/> exists, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="albumId"/> is equal to or less than zero.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Album Select(int albumId)
        {
            ValidateDatabase();

            if (albumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(albumId), albumId,
                    "The album id can't be equal to or less than zero.");
            }

            IntPtr handle = IntPtr.Zero;
            try
            {
                Interop.Album.GetAlbumFromDb(albumId, out handle).ThrowIfError("Failed to query");

                return handle == IntPtr.Zero ? null : new Album(handle);
            }
            finally
            {
                Interop.Album.Destroy(handle);
            }
        }

        /// <summary>
        /// Retrieves the number of media information that belongs to the album.
        /// </summary>
        /// <param name="albumId">The ID of the album to query with.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="albumId"/> is equal to or less than zero.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMember(int albumId)
        {
            return CountMember(albumId, null);
        }

        /// <summary>
        /// Retrieves the number of media information that belongs to the album with <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="albumId">The ID of the album to count media.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="albumId"/> is equal to or less than zero.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMember(int albumId, CountArguments arguments)
        {
            ValidateDatabase();

            if (albumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(albumId), albumId,
                    "The album id can't be equal to or less than zero.");
            }

            return CommandHelper.Count(Interop.Album.GetMediaCountFromDb, albumId, arguments);
        }

        /// <summary>
        /// Retrieves the media information of the album.
        /// </summary>
        /// <param name="albumId">The ID of the album to select media.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMember(int albumId)
        {
            return SelectMember(albumId, null);
        }

        /// <summary>
        /// Retrieves the media information of the album with <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="albumId">The ID of the album to query with.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMember(int albumId, SelectArguments filter)
        {
            ValidateDatabase();

            if (albumId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(albumId), albumId,
                    "The album id can't be equal to or less than zero.");
            }

            return CommandHelper.SelectMedia(Interop.Album.ForeachMediaFromDb, albumId, filter);
        }
    }
}
