/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using NativePlaylist = Interop.MediaControllerPlaylist;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents playlist for media control.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class MediaControlPlaylist : IDisposable
    {
        private IntPtr _handle;
        private Dictionary<string, MediaControlMetadata> _metadata = new Dictionary<string, MediaControlMetadata>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlPlaylist"/> class.
        /// </summary>
        /// <param name="name">The name of this playlist.</param>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaylist(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            NativePlaylist.CreatePlaylist(name, out IntPtr handle).ThrowIfError("Failed to create playlist");

            Name = name;
            _handle = handle;

            MediaControlServer.SavePlaylist(handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlPlaylist"/> class.
        /// </summary>
        /// <param name="name">The name of this playlist.</param>
        /// <param name="metadata">The metadata of this playlist.</param>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaylist(string name, Dictionary<string, MediaControlMetadata> metadata)
            : this(name)
        {
            AddMetadata(metadata);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlPlaylist"/> class with the playlist handle that created already.
        /// </summary>
        /// <param name="handle">The handle of playlist.</param>
        internal MediaControlPlaylist(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            // handle will be destroyed in Native FW side.
            Name = NativePlaylist.GetPlaylistName(handle);

            UpdateMetadata(handle);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MediaControlPlaylist"/> class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ~MediaControlPlaylist()
        {
            Dispose(false);
        }

        internal IntPtr Handle
        {
            get
            {
                if (_handle == IntPtr.Zero)
                {
                    _handle = MediaControlServer.GetPlaylistHandle(Name);
                }
                return _handle;
            }
            set
            {
                _handle = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of playlist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the total number of media in this playlist.
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _metadata != null ? _metadata.Count : 0;
            }
        }

        private void UpdateMetadata(IntPtr handle)
        {
            NativePlaylist.PlaylistItemCallback playlistItemCallback = (index, metadataHandle, _) =>
            {
                _metadata.Add(index, new MediaControlMetadata(metadataHandle));
                return true;
            };
            NativePlaylist.ForeachPlaylistItem(handle, playlistItemCallback, IntPtr.Zero).
                ThrowIfError("Failed to retrieve playlist item.");
        }

        /// <summary>
        /// Gets the playlist index and metadata pair.
        /// </summary>
        /// <returns>The dictionary set of index and <see cref="MediaControlMetadata"/> pair.</returns>
        public Dictionary<string, MediaControlMetadata> GetMetadata()
        {
            if (_metadata == null)
            {
                UpdateMetadata(Handle);
            }

            return _metadata;
        }

        /// <summary>
        /// Gets the metadata by index.
        /// </summary>
        /// <param name="index">The index of media in the playlist.</param>
        /// <returns>A <see cref="MediaControlMetadata"/> instance.</returns>
        public MediaControlMetadata GetMetadata(string index)
        {
            if (_metadata == null)
            {
                UpdateMetadata(Handle);
            }

            if (_metadata.TryGetValue(index, out MediaControlMetadata metadata))
            {
                return metadata;
            }

            return null;
        }

        /// <summary>
        /// Sets the metadata to the playlist.
        /// </summary>
        /// <param name="metadata">The metadata of media.</param>
        /// <since_tizen> 5 </since_tizen>
        public void AddMetadata(Dictionary<string, MediaControlMetadata> metadata)
        {
            foreach (var data in metadata)
            {
                AddMetadata(data.Key, data.Value);
            }

            MediaControlServer.SavePlaylist(Handle);
        }

        /// <summary>
        /// Sets the metadata to the playlist.
        /// </summary>
        /// <param name="index">The index of media in the playlist.</param>
        /// <param name="metadata">The metadata of media.</param>
        /// <since_tizen> 5 </since_tizen>
        public void AddMetadata(string index, MediaControlMetadata metadata)
        {
            AddItemToPlaylist(index, metadata);
            _metadata.Add(index, metadata);

            MediaControlServer.SavePlaylist(Handle);
        }

        private void AddItemToPlaylist(string index, MediaControlMetadata metadata)
        {
            void AddMetadataToNative(string idx, MediaControllerNativeAttribute attribute, string value)
            {
                // This API doesn't save playlist to the storage. So we need to call MediaControlServer.SavePlaylist()
                // after all items are updated.
                NativePlaylist.UpdatePlaylist(Handle, idx, attribute, value)
                    .ThrowIfError("Failed to update playlist");
            }

            AddMetadataToNative(index, MediaControllerNativeAttribute.Album, metadata.Album);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Artist, metadata.Artist);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Author, metadata.Author);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Copyright, metadata.Copyright);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Date, metadata.Date);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Description, metadata.Description);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Duration, metadata.Duration);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Genre, metadata.Genre);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Picture, metadata.AlbumArtPath);
            AddMetadataToNative(index, MediaControllerNativeAttribute.Title, metadata.Title);
            AddMetadataToNative(index, MediaControllerNativeAttribute.TrackNumber, metadata.TrackNumber);
        }

        /// <summary>
        /// Update the playlist by lastest info.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Update()
        {
            // Update the name of playlist.
            Name = NativePlaylist.GetPlaylistName(Handle);

            // Update metadata.
            UpdateMetadata(Handle);
        }

        internal void Destroy()
        {
            NativePlaylist.DestroyPlaylist(Handle).ThrowIfError("Failed to delete playlist");
        }

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases the unmanaged resources used by the MediaControlPlaylist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the Recorder.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    Destroy();
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }
        #endregion Dispose support
    }
}
