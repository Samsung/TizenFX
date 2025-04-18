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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides the ability to connect to and manage the database.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MediaDatabase : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaDatabase"/> class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public MediaDatabase()
        {
        }

        private object _lock = new object();

        /// <summary>
        /// Connects to the database.
        /// </summary>
        /// <exception cref="InvalidOperationException">The database is already connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while connecting.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Connect()
        {
            ValidateNotDisposed();

            lock (_lock)
            {
                if (IsConnected)
                {
                    throw new InvalidOperationException("The database is already connected.");
                }

                Interop.Content.Connect().ThrowIfError("Failed to connect");

                IsConnected = true;
            }
        }

        /// <summary>
        /// Disconnects from the media database.
        /// </summary>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while connecting.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Disconnect()
        {
            ValidateNotDisposed();

            lock (_lock)
            {
                if (!IsConnected)
                {
                    throw new InvalidOperationException("The database is not connected.");
                }

                Interop.Content.Disconnect().ThrowIfError("Failed to disconnect");

                IsConnected = false;
            }
        }

        private static readonly Interop.Content.MediaContentDBUpdatedCallback _mediaInfoUpdatedCb = (
            MediaContentError error, int pid, ItemType updateItem, OperationType updateType,
            MediaType mediaType, string uuid, string filePath, string mimeType, IntPtr _) =>
        {
            if (updateItem == ItemType.Directory)
            {
                return;
            }

            _mediaInfoUpdated?.Invoke(
                null, new MediaInfoUpdatedEventArgs(pid, updateType, mediaType, uuid, filePath, mimeType));
        };

        private static IntPtr _mediaInfoUpdatedHandle = IntPtr.Zero;
        private static event EventHandler<MediaInfoUpdatedEventArgs> _mediaInfoUpdated;
        private static readonly object _mediaInfoUpdatedLock = new object();

        /// <summary>
        /// Occurs when there is a change for media in the database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<MediaInfoUpdatedEventArgs> MediaInfoUpdated
        {
            add
            {
                lock (_mediaInfoUpdatedLock)
                {
                    if (_mediaInfoUpdated == null)
                    {
                        Interop.Content.AddDbUpdatedCb(_mediaInfoUpdatedCb, IntPtr.Zero,
                            out _mediaInfoUpdatedHandle).ThrowIfError("Failed to register an event handler");
                    }

                    _mediaInfoUpdated += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_mediaInfoUpdatedLock)
                {
                    if (_mediaInfoUpdated == value)
                    {
                        Interop.Content.RemoveDbUpdatedCb(_mediaInfoUpdatedHandle).ThrowIfError("Failed to unregister");
                    }

                    _mediaInfoUpdated -= value;
                }
            }
        }

        private static readonly Interop.Content.MediaContentDBUpdatedCallback _folderUpdatedCb = (
            MediaContentError error, int pid, ItemType updateItem, OperationType updateType,
            MediaType mediaType, string uuid, string filePath, string mimeType, IntPtr _) =>
        {
            if (updateItem == ItemType.File)
            {
                return;
            }

            _folderUpdated?.Invoke(null, new FolderUpdatedEventArgs(updateType, uuid, filePath));
        };

        private static IntPtr _folderUpdatedHandle = IntPtr.Zero;
        private static event EventHandler<FolderUpdatedEventArgs> _folderUpdated;
        private static readonly object _folderUpdatedLock = new object();

        /// <summary>
        /// Occurs when there is a change for the folder in the database.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<FolderUpdatedEventArgs> FolderUpdated
        {
            add
            {
                lock (_folderUpdatedLock)
                {
                    if (_folderUpdated == null)
                    {
                        Interop.Content.AddDbUpdatedCb(_folderUpdatedCb, IntPtr.Zero,
                            out _folderUpdatedHandle).ThrowIfError("Failed to register an event handler");
                    }

                    _folderUpdated += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_folderUpdatedLock)
                {
                    if (_folderUpdated == value)
                    {
                        Interop.Content.RemoveDbUpdatedCb(_folderUpdatedHandle).ThrowIfError("Failed to unregister");
                    }

                    _folderUpdated -= value;
                }
            }
        }

        /// <summary>
        /// Requests to scan a media file.
        /// </summary>
        /// <param name="path">The path of the media to be scanned.</param>
        /// <remarks>
        /// It requests to scan a media file to the media server.<br/>
        /// If the specified file is not registered to the database yet,
        /// the media file information will be added to the database.<br/>
        /// If it is already registered to the database, the media information is refreshed.<br/>
        /// If the specified file does not exist,
        /// the record of the media file will be deleted from the database.<br/>
        /// <br/>
        /// If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        /// If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.<br/>
        /// <br/>
        /// If http://tizen.org/feature/content.scanning.others feature is not supported and the specified file is other-type,
        /// <see cref="NotSupportedException"/> will be thrown.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="path"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> contains a directory containing the ".scan_ignore" file.(up to API Level 12)
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void ScanFile(string path)
        {
            ValidateState();

            ValidationUtil.ValidateNotNullOrEmpty(path, nameof(path));

            Interop.Content.ScanFile(path).Ignore(MediaContentError.InvalidParameter).ThrowIfError("Failed to scan");
        }

        /// <summary>
        /// Requests to scan a folder recursively.
        /// </summary>
        /// <remarks>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="folderPath">The path to scan.</param>
        /// <remarks>Folders that contains a file named ".scan_ignore" will not be scanned.(up to API Level 12)</remarks>
        /// <returns>A task that represents the asynchronous scan operation.</returns>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderPath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="folderPath"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a directory containing the ".scan_ignore" file.(up to API Level 12)
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task ScanFolderAsync(string folderPath)
        {
            return ScanFolderAsync(folderPath, true);
        }

        /// <summary>
        /// Requests to scan a folder.
        /// </summary>
        /// <remarks>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="folderPath">The path to scan.</param>
        /// <param name="recursive">The value indicating if the folder is to be recursively scanned.</param>
        /// <remarks>Folders that contains a file named ".scan_ignore" will not be scanned.(up to API Level 12)</remarks>
        /// <returns>A task that represents the asynchronous scan operation.</returns>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderPath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="folderPath"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a directory containing the ".scan_ignore" file.(up to API Level 12)
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task ScanFolderAsync(string folderPath, bool recursive)
        {
            return ScanFolderAsync(folderPath, recursive, CancellationToken.None);
        }

        /// <summary>
        /// Requests to scan a folder recursively.
        /// </summary>
        /// <remarks>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="folderPath">The path to scan.</param>
        /// <param name="cancellationToken">The token to stop scanning.</param>
        /// <remarks>Folders that contains a file named ".scan_ignore" will not be scanned.(up to API Level 12)</remarks>
        /// <returns>A task that represents the asynchronous scan operation.</returns>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderPath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="folderPath"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a directory containing the ".scan_ignore" file.(up to API Level 12)
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task ScanFolderAsync(string folderPath, CancellationToken cancellationToken)
        {
            return ScanFolderAsync(folderPath, true, cancellationToken);
        }

        /// <summary>
        /// Requests to scan a folder.
        /// </summary>
        /// <remarks>
        ///     If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage.<br/>
        ///     If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="folderPath">The path to scan.</param>
        /// <param name="recursive">The value indicating if the folder is to be recursively scanned.</param>
        /// <param name="cancellationToken">The token to stop scanning.</param>
        /// <remarks>Folders that contains a file named ".scan_ignore" will not be scanned.(up to API Level 12)</remarks>
        /// <returns>A task that represents the asynchronous scan operation.</returns>
        /// <exception cref="InvalidOperationException">The database is not connected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="folderPath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="folderPath"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a hidden path that starts with '.'.<br/>
        ///     -or-<br/>
        ///     <paramref name="folderPath"/> contains a directory containing the ".scan_ignore" file.(up to API Level 12)
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Task ScanFolderAsync(string folderPath, bool recursive, CancellationToken cancellationToken)
        {
            ValidateState();

            ValidationUtil.ValidateNotNullOrEmpty(folderPath, nameof(folderPath));

            return cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) :
                ScanFolderAsyncCore(folderPath, recursive, cancellationToken);
        }

        private async Task ScanFolderAsyncCore(string folderPath, bool recursive, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            using (var cbKeeper = ObjectKeeper.Get(GetScanCompletedCallback(tcs, cancellationToken)))
            using (RegisterCancellationAction(tcs, folderPath, cancellationToken))
            {
                Interop.Content.ScanFolder(folderPath, recursive, cbKeeper.Target)
                    .ThrowIfError("Failed to scan");

                await tcs.Task;
            }
        }

        private static Interop.Content.MediaScanCompletedCallback GetScanCompletedCallback(TaskCompletionSource<bool> tcs,
            CancellationToken cancellationToken)
        {
            return (scanResult, _) =>
            {
                if (scanResult == MediaContentError.None)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        tcs.TrySetCanceled();
                    }
                    else
                    {
                        tcs.TrySetResult(true);
                    }
                }
                else
                {
                    tcs.TrySetException(scanResult.AsException("Failed to scan"));
                }
            };
        }

        private static IDisposable RegisterCancellationAction(TaskCompletionSource<bool> tcs,
            string folderPath, CancellationToken cancellationToken)
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

                Interop.Content.CancelScanFolder(folderPath).ThrowIfError("Failed to cancel scanning");
            });
        }

        internal bool IsConnected { get; set; }

        internal void ValidateState()
        {
            ValidateNotDisposed();

            if (IsConnected == false)
            {
                throw new InvalidOperationException("Database is not connected.");
            }
        }

        private void ValidateNotDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(nameof(MediaDatabase));
            }
        }

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the MediaDatabase.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (IsConnected)
                {
                    var disconnectResult = Interop.Content.Disconnect();

                    if (disconnectResult != MediaContentError.None)
                    {
                        Log.Warn(nameof(MediaDatabase), $"Failed to disconnect {disconnectResult.ToString()}.");
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all the resources.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Gets the value indicating whether the database has been disposed.
        /// </summary>
        /// <value>true if the database has been disposed; otherwise, false.</value>
        /// <since_tizen> 4 </since_tizen>
        public bool IsDisposed => _disposed;
        #endregion

    }
}
