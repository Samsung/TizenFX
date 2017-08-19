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
    /// Provides commands to manage external storages in the database.
    /// </summary>
    /// <remarks>
    /// Internal storage is not managed.
    /// </remarks>
    /// <seealso cref="Storage"/>
    public class StorageCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">A <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed of.</exception>
        public StorageCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of storages.
        /// </summary>
        /// <returns>The number of storages.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public int Count() => Count(arguments: null);

        /// <summary>
        /// Retrieves the number of storages with <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of storages filtered.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Storage.GetStorageCountFromDb, arguments);
        }

        /// <summary>
        /// Retrieves the storage with the specified id.
        /// </summary>
        /// <param name="storageId">The storage id to select.</param>
        /// <returns>The <see cref="Storage"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        public Storage Select(string storageId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(storageId, nameof(storageId));

            IntPtr handle = IntPtr.Zero;

            try
            {
                Interop.Storage.GetStorageInfoFromDb(storageId, out handle).ThrowIfError("Failed to query");

                return handle == IntPtr.Zero ? null : new Storage(handle);
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Interop.Storage.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Retrieves all the storages.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public MediaDataReader<Storage> Select() => Select(arguments: null);

        /// <summary>
        /// Retrieves the storages with <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        public MediaDataReader<Storage> Select(SelectArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Select(arguments, Interop.Storage.ForeachStorageFromDb, Storage.FromHandle);
        }

        private bool Exists(string storageId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(storageId, nameof(storageId));

            return Count(new CountArguments { FilterExpression = $"{StorageColumns.Id}='{storageId}'" }) != 0;
        }

        /// <summary>
        /// Retrieves the number of media info of the storage.
        /// </summary>
        /// <param name="storageId">The storage id.</param>
        /// <returns>The number of media info.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        public int CountMedia(string storageId) => CountMedia(storageId, null);

        /// <summary>
        /// Retrieves the number of media info of the storage with <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="storageId">The storage id to query with.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media info.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        public int CountMedia(string storageId, CountArguments arguments)
        {
            if (Exists(storageId) == false)
            {
                return 0;
            }

            return CommandHelper.Count(Interop.Storage.GetMediaCountFromDb, storageId, arguments);
        }

        /// <summary>
        /// Retrieves the media info of the storage.
        /// </summary>
        /// <param name="storageId">The storage id.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        public MediaDataReader<MediaInfo> SelectMedia(string storageId) => SelectMedia(storageId, null);

        /// <summary>
        /// Retrieves the media info of the storage with <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="storageId">The storage id.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        public MediaDataReader<MediaInfo> SelectMedia(string storageId, SelectArguments filter)
        {
            if (Exists(storageId) == false)
            {
                return new MediaDataReader<MediaInfo>(new MediaInfo[0]);
            }

            return CommandHelper.SelectMedia(Interop.Storage.ForeachMediaFromDb, storageId, filter);
        }

    }
}
