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
using System.IO;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides a means to edit the metadata of MP3 and MP4 files.
    /// Since 6.0, WAV, FLAC, OGG files are supported as well.
    /// </summary>
    /// <privilege>
    /// If you want to access only an internal storage,
    /// you should add privilege http://tizen.org/privilege/mediastorage.<br/>
    /// Or if you want to access only an external storage,
    /// you should add privilege http://tizen.org/privilege/externalstorage.
    /// </privilege>
    /// <since_tizen> 3 </since_tizen>
    public class MetadataEditor : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _handle = IntPtr.Zero;
        private bool _isFileReadOnly;

        private IntPtr Handle
        {
            get
            {
                if (_handle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(MetadataEditor));
                }

                return _handle;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataEditor"/> class with the specified path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="path">The path of the media file to edit the metadata.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="FileFormatException">The file is not supported.</exception>
        /// <exception cref="FileNotFoundException">The file does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege to access the file.</exception>
        public MetadataEditor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"{nameof(path)} is a zero-length string.", nameof(path));
            }

            Interop.MetadataEditor.Create(out _handle).ThrowIfError("Failed to create metadata");

            try
            {
                Interop.MetadataEditor.SetPath(Handle, path).ThrowIfError("Failed to set path");

                _isFileReadOnly = File.GetAttributes(path).HasFlag(FileAttributes.ReadOnly);
            }
            catch (Exception)
            {
                Dispose(false);
                throw;
            }
        }

        private string GetParam(MetadataEditorAttr attr)
        {
            IntPtr val = IntPtr.Zero;

            try
            {
                Interop.MetadataEditor.GetMetadata(Handle, attr, out val)
                    .ThrowIfError("Failed to get metadata");

                return Marshal.PtrToStringAnsi(val);
            }
            finally
            {
                Interop.Libc.Free(val);
            }
        }

        private void SetParam(MetadataEditorAttr attr, string value)
        {
            if (_isFileReadOnly)
            {
                throw new InvalidOperationException("The media file is read-only.");
            }

            Interop.MetadataEditor.SetMetadata(Handle, attr, value).ThrowIfError("Failed to set value");
        }

        /// <summary>
        /// Gets or sets the artist of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Artist
        {
            get
            {
                return GetParam(MetadataEditorAttr.Artist);
            }

            set
            {
                SetParam(MetadataEditorAttr.Artist, value);
            }
        }

        /// <summary>
        /// Gets or sets the title of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Title
        {
            get
            {
                return GetParam(MetadataEditorAttr.Title);
            }

            set
            {
                SetParam(MetadataEditorAttr.Title, value);
            }
        }

        /// <summary>
        /// Gets or sets the album name of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Album
        {
            get
            {
                return GetParam(MetadataEditorAttr.Album);
            }

            set
            {
                SetParam(MetadataEditorAttr.Album, value);
            }
        }

        /// <summary>
        /// Gets or sets the genre of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Genre
        {
            get
            {
                return GetParam(MetadataEditorAttr.Genre);
            }

            set
            {
                SetParam(MetadataEditorAttr.Genre, value);
            }
        }

        /// <summary>
        /// Gets or sets the author of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Author
        {
            get
            {
                return GetParam(MetadataEditorAttr.Author);
            }

            set
            {
                SetParam(MetadataEditorAttr.Author, value);
            }
        }

        /// <summary>
        /// Gets or sets the copyright of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Copyright
        {
            get
            {
                return GetParam(MetadataEditorAttr.Copyright);
            }

            set
            {
                SetParam(MetadataEditorAttr.Copyright, value);
            }
        }

        /// <summary>
        /// Gets or sets the date of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the media contains the ID3 tag, this refers to the recorded date.
        /// If the media is a mp4 format, this refers to the year, and the value to set will be converted into integer.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Date
        {
            get
            {
                return GetParam(MetadataEditorAttr.Date);
            }

            set
            {
                SetParam(MetadataEditorAttr.Date, value);
            }
        }

        /// <summary>
        /// Gets or sets the description of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Description
        {
            get
            {
                return GetParam(MetadataEditorAttr.Description);
            }

            set
            {
                SetParam(MetadataEditorAttr.Description, value);
            }
        }

        /// <summary>
        /// Gets or sets the comment of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Comment
        {
            get
            {
                return GetParam(MetadataEditorAttr.Comment);
            }

            set
            {
                SetParam(MetadataEditorAttr.Comment, value);
            }
        }

        /// <summary>
        /// Gets or sets the track number of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string TrackNumber
        {
            get
            {
                return GetParam(MetadataEditorAttr.TrackNumber);
            }

            set
            {
                SetParam(MetadataEditorAttr.TrackNumber, value);
            }
        }

        /// <summary>
        /// Gets the count of album arts of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public int PictureCount
        {
            get => int.TryParse(GetParam(MetadataEditorAttr.PictureCount), out var value) ? value : 0;
        }

        /// <summary>
        /// Gets or sets the conductor of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string Conductor
        {
            get
            {
                return GetParam(MetadataEditorAttr.Conductor);
            }

            set
            {
                SetParam(MetadataEditorAttr.Conductor, value);
            }
        }

        /// <summary>
        /// Gets or sets the unsynchronized lyrics of media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public string UnsyncLyrics
        {
            get
            {
                return GetParam(MetadataEditorAttr.UnsyncLyrics);
            }

            set
            {
                SetParam(MetadataEditorAttr.UnsyncLyrics, value);
            }
        }

        /// <summary>
        /// Writes the modified metadata to the media file.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// Internal error.<br/>
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Commit()
        {
            if (_isFileReadOnly)
            {
                throw new InvalidOperationException("The media file is read-only.");
            }

            Interop.MetadataEditor.UpdateMetadata(Handle).ThrowIfError("Failed to update file");
        }

        /// <summary>
        /// Gets the artwork image in the media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="index">The index of the picture to import.</param>
        /// <returns>The artwork included in the media file.</returns>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="index"/> is greater than or equal to <see cref="PictureCount"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public Artwork GetPicture(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index,
                    "Index should not be less than zero.");
            }

            if (index >= PictureCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index,
                    "Index should not be greater thor or equal to PictureCount.");
            }

            IntPtr data = IntPtr.Zero;
            IntPtr mimeType = IntPtr.Zero;

            try
            {
                Interop.MetadataEditor.GetPicture(Handle, index, out data, out var size, out mimeType).
                    ThrowIfError("Failed to get the value");

                if (size > 0)
                {
                    byte[] tmpBuf = new byte[size];
                    Marshal.Copy(data, tmpBuf, 0, size);

                    return new Artwork(tmpBuf, Marshal.PtrToStringAnsi(mimeType));
                }

                return null;
            }
            finally
            {
                if (data != IntPtr.Zero)
                {
                    Interop.Libc.Free(data);
                }

                if (mimeType != IntPtr.Zero)
                {
                    Interop.Libc.Free(mimeType);
                }
            }
        }

        /// <summary>
        /// Appends the picture to the media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="path">The path of the picture for adding to the metadata.</param>
        /// <exception cref="InvalidOperationException">
        /// The file is read-only.<br/>
        /// -or-<br/>
        /// The malformed file which cannot be updatable.<br/>
        /// -or-<br/>
        /// Internal error.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException">The file does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege to access the file.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        public void AddPicture(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exist.", path);
            }

            if (_isFileReadOnly)
            {
                throw new InvalidOperationException("The media file is read-only.");
            }

            Interop.MetadataEditor.AddPicture(Handle, path).
                ThrowIfError("Failed to append picture");
        }

        /// <summary>
        /// Removes the picture from the media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="index">The index of the picture to remove.</param>
        /// <exception cref="InvalidOperationException">
        ///     An internal error occurs.<br/>
        ///     -or-<br/>
        ///     The media file is read-only.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="index"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="index"/> is greater than or equal to <see cref="PictureCount"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataEditor"/> has already been disposed of.</exception>
        public void RemovePicture(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index should be larger than 0 [" + index + "]");
            }

            if (index >= PictureCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index,
                    "Index should not be greater thor or equal to PictureCount.");
            }

            if (_isFileReadOnly)
            {
                throw new InvalidOperationException("The media file is read-only.");
            }

            Interop.MetadataEditor.RemovePicture(Handle, index).ThrowIfError("Failed to remove picture");
        }

        /// <summary>
        /// Finalizes an instance of the MetadataEditor class.
        /// </summary>
        ~MetadataEditor()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="MetadataEditor"/> object.
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
                    Interop.MetadataEditor.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="MetadataEditor"/> object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
