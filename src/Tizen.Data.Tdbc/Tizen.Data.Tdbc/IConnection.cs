/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// TDBC Interface for connecting with a database.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Opens the database.
        /// </summary>
        /// <param name="uri">The URI represents database to connect.</param>
        /// <remarks>
        /// If the driver uses database at filesystem, such as media storage or external storage,
        /// you need to declare a proper privilege such as http://tizen.org/privileges/mediastorage or http://tizen.org/privileges/externalstorage.
        /// </remarks>
        /// <exception cref="ArgumentException">The input URI is invalid.</exception>
        /// <exception cref="InvalidOperationException">The drvier open is failed.</exception>
        /// <exception cref="UnauthorizedAccessException">.The application doesn't have permission or privilege to access database.</exception>
        /// <since_tizen> 11 </since_tizen>
        void Open(Uri uri);

        /// <summary>
        /// Opens the database.
        /// </summary>
        /// <param name="openString">The URI represents database to connect.</param>
        /// <remarks>
        /// If the driver uses database at filesystem, such as media storage or external storage,
        /// you need to declare a proper privilege such as http://tizen.org/privileges/mediastorage or http://tizen.org/privileges/externalstorage.
        /// </remarks>
        /// <exception cref="ArgumentException">The input openString is invalid.</exception>
        /// <exception cref="InvalidOperationException">The drvier open is failed.</exception>
        /// <exception cref="UnauthorizedAccessException">.The application doesn't have permission or privilege to access database.</exception>
        /// <since_tizen> 11 </since_tizen>
        void Open(String openString);

        /// <summary>
        /// Closes the database.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        void Close();

        /// <summary>
        /// Returns that the database is opened or not.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        bool IsOpen();

        /// <summary>
        /// Creates a statement object associated with the connection.
        /// </summary>
        /// <exception cref="InvalidOperationException">The connection is not opened.</exception>
        /// <returns>The statement object.</returns>
        /// <since_tizen> 11 </since_tizen>
        IStatement CreateStatement();

        /// <summary>
        /// The event occurs when record changed.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        event EventHandler<RecordChangedEventArgs> RecordChanged;
    }
}
