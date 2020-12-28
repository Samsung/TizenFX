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
    /// Provides the commands to manage external storages in the database.
    /// </summary>
    /// <remarks>
    /// The internal storage is not managed.
    /// </remarks>
    /// <seealso cref="Storage"/>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Please do not use! this will be deprecated in level 6")]
    public class StorageCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public StorageCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of storages.
        /// </summary>
        /// <returns>The number of storages.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public int Count() => Count(arguments: null);

        /// <summary>
        /// Retrieves the number of storages with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of storages filtered.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Storage.GetStorageCountFromDb, arguments);
        }

        /// <summary>
        /// Retrieves the storage with the specified ID.
        /// </summary>
        /// <param name="storageId">The storage ID to select.</param>
        /// <returns>The <see cref="Storage"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public Storage Select(string storageId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(storageId, nameof(storageId));

            IntPtr handle = IntPtr.Zero;

            try
            {
                Interop.Storage.GetStorageInfoFromDb(storageId, out handle).ThrowIfError("Failed to query");

                return new Storage(handle);
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
                    Interop.Storage.Destroy(handle);
                }
            }
        }

        /// <summary>
        /// Retrieves all the storages.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public MediaDataReader<Storage> Select() => Select(arguments: null);

        /// <summary>
        /// Retrieves the storages with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
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
        /// Retrieves the number of media information of the storage.
        /// </summary>
        /// <param name="storageId">The storage ID.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public int CountMedia(string storageId) => CountMedia(storageId, null);

        /// <summary>
        /// Retrieves the number of media information of the storage with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="storageId">The storage ID to query with.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public int CountMedia(string storageId, CountArguments arguments)
        {
            if (Exists(storageId) == false)
            {
                return 0;
            }

            return CommandHelper.Count(Interop.Storage.GetMediaCountFromDb, storageId, arguments);
        }

        /// <summary>
        /// Retrieves the media information of the storage.
        /// </summary>
        /// <param name="storageId">The storage ID.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public MediaDataReader<MediaInfo> SelectMedia(string storageId) => SelectMedia(storageId, null);

        /// <summary>
        /// Retrieves the media information of the storage with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="storageId">The storage ID.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="storageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="storageId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
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
