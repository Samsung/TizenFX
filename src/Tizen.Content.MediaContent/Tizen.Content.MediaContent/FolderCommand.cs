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
    /// Provides commands to manage folders and query related media items in the database.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class FolderCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FolderCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Retrieves the number of folders.
        /// </summary>
        /// <returns>The number of folders.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count()
        {
            return Count(null);
        }

        /// <summary>
        /// Retrieves the number of folders with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of folders.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int Count(CountArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Count(Interop.Folder.GetFolderCountFromDb, arguments);
        }

        /// <summary>
        /// Retrieves the folders.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Folder> Select()
        {
            return Select(arguments: null);
        }

        /// <summary>
        /// Retrieves the folders with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<Folder> Select(SelectArguments arguments)
        {
            ValidateDatabase();

            return CommandHelper.Select(arguments, Interop.Folder.ForeachFolderFromDb, Folder.FromHandle);
        }

        /// <summary>
        /// Retrieves the folder.
        /// </summary>
        /// <param name="folderId">The folder ID to query with.</param>
        /// <returns>The <see cref="Folder"/> instance if the matched record was found in the database, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="folderId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Folder Select(string folderId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(folderId, nameof(folderId));

            Interop.Folder.GetFolderFromDb(folderId, out var handle).ThrowIfError("Failed to query");

            if (handle == IntPtr.Zero)
            {
                return null;
            }

            try
            {
                return new Folder(handle);
            }
            finally
            {
                Interop.Folder.Destroy(handle);
            }
        }

        /// <summary>
        /// Retrieves the number of media information under the folder.
        /// </summary>
        /// <param name="folderId">The ID of the folder to count media in the folder.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="folderId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia(string folderId)
        {
            return CountMedia(folderId, null);
        }

        /// <summary>
        /// Retrieves the number of media information under the folder with the <see cref="CountArguments"/>.
        /// </summary>
        /// <param name="folderId">The ID of the folder to count media in the folder.</param>
        /// <param name="arguments">The criteria to use to filter. This value can be null.</param>
        /// <returns>The number of media information.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="folderId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int CountMedia(string folderId, CountArguments arguments)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(folderId, nameof(folderId));

            return CommandHelper.Count(Interop.Folder.GetMediaCountFromDb, folderId, arguments);
        }

        /// <summary>
        /// Retrieves the media information under the folder.
        /// </summary>
        /// <param name="folderId">The ID of the folder to select media in the folder.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="folderId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia(string folderId)
        {
            return SelectMedia(folderId, null);
        }

        /// <summary>
        /// Retrieves the media information under the folder with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="folderId">The ID of the folder to select media in the folder.</param>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="folderId"/> is a zero-length string, contains only white space.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<MediaInfo> SelectMedia(string folderId, SelectArguments filter)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(folderId, nameof(folderId));

            return CommandHelper.SelectMedia(Interop.Folder.ForeachMediaFromDb, folderId, filter);
        }
    }
}
