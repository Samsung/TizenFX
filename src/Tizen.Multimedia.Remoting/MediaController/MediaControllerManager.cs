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
using System.Threading;
using Native = Interop.MediaControllerClient;
using NativeHandle = Interop.MediaControllerClientHandle;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to retrieve active controllers and observe controllers added and removed.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class MediaControllerManager : IDisposable
    {
        private NativeHandle _handle;

        private Dictionary<string, MediaController> _activated = new Dictionary<string, MediaController>();

        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        internal NativeHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(MediaControllerManager));
                }

                return _handle;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControllerManager"/> class.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/mediacontroller.client</privilege>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaControllerManager()
        {
            Native.Create(out _handle).ThrowIfError("Failed to create media controller client.");

            InitializeEvents();

            LoadActivatedServers();
        }

        private bool _disposed;

        /// <summary>
        /// Releases all resources used by the <see cref="MediaControllerManager"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="MediaControllerManager"/>.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // To be used if there are any other disposable objects
                }
                _handle.Dispose();

                _disposed = true;
            }
        }

        /// <summary>
        /// Gets the active controllers.
        /// </summary>
        /// <returns>An array of <see cref="MediaController"/>.</returns>
        /// <since_tizen> 4 </since_tizen>
        public MediaController[] GetActiveControllers()
        {
            if (_disposed)
            {
                return new MediaController[0];
            }

            try
            {
                _lock.EnterReadLock();
                return _activated.Values.ToArray();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        #region Controllers-related operations

        #region Unlocking operations

        private MediaController HandleActivation(string serverName)
        {
            if (_activated.ContainsKey(serverName))
            {
                return null;
            }

            var controller = new MediaController(this, serverName);
            _activated.Add(serverName, controller);

            return controller;
        }

        private MediaController HandleDeactivation(string serverName)
        {
            if (_activated.TryGetValue(serverName, out var controller))
            {
                _activated.Remove(serverName);
            }

            return controller;
        }
        #endregion

        #region Locking operations

        private MediaController HandleServerUpdated(string serverName, MediaControllerNativeServerState state)
        {
            try
            {
                _lock.EnterWriteLock();

                if (state == MediaControllerNativeServerState.Activated)
                {
                    return HandleActivation(serverName);
                }

                return HandleDeactivation(serverName);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        private MediaController GetController(string serverName)
        {
            try
            {
                _lock.EnterReadLock();

                _activated.TryGetValue(serverName, out var value);
                return value;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        private void LoadActivatedServers()
        {
            try
            {
                _lock.EnterWriteLock();

                Native.ActivatedServerCallback serverCallback = (serverName, _) =>
                {
                    _activated.Add(serverName, new MediaController(this, serverName));
                    return true;
                };

                Native.ForeachActivatedServer(Handle, serverCallback, IntPtr.Zero).
                    ThrowIfError("Failed to get activated servers.");
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        #endregion

        #endregion
    }
}