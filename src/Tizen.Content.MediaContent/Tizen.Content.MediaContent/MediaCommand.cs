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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// The <see cref="MediaCommand"/> is a base class for command classes.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed.</exception>
        /// <since_tizen> 4 </since_tizen>
        protected MediaCommand(MediaDatabase database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));

            if (database.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(database));
            }
        }

        internal void ValidateDatabase()
        {
            Database.ValidateState();
        }

        /// <summary>
        /// Gets the <see cref="MediaDatabase"/>.
        /// </summary>
        /// <value>The <see cref="MediaDatabase"/> which commands execute on.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaDatabase Database { get; }
    }

    /// <summary>
    /// Provides a means of reading results obtained by executing a query.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public interface IMediaDataReader
    {
        /// <summary>
        /// Advances to the next record.
        /// </summary>
        /// <returns>true if there are more rows; otherwise false.</returns>
        /// <since_tizen> 4 </since_tizen>
        bool Read();

        /// <summary>
        /// Gets the current record.
        /// </summary>
        /// <value>The current record object.</value>
        /// <since_tizen> 4 </since_tizen>
        object Current { get; }
    }

    /// <summary>
    /// Provides a means of reading results obtained by executing a query.
    /// </summary>
    /// <typeparam name="TRecord"></typeparam>
    /// <since_tizen> 4 </since_tizen>
    public class MediaDataReader<TRecord> : IMediaDataReader, IDisposable
    {
        private readonly IEnumerator<TRecord> _enumerator;

        internal MediaDataReader(IEnumerable<TRecord> items)
        {
            _enumerator = items.GetEnumerator();
        }

        /// <summary>
        /// Gets the current record.
        /// </summary>
        /// <value>The current record if the position is valid; otherwise null.</value>
        /// <since_tizen> 4 </since_tizen>
        public TRecord Current
        {
            get
            {
                ValidateNotDisposed();
                return _enumerator.Current;
            }
        }

        /// <summary>
        /// Advances to the next record.
        /// </summary>
        /// <returns>true if there are more rows; otherwise false.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool Read()
        {
            ValidateNotDisposed();
            return _enumerator.MoveNext();
        }

        object IMediaDataReader.Current => Current;

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the MediaDataReader.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion
    }
}
