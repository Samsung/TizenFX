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
    /// Provides a means to get the metadata from a media file.
    /// </summary>
    public class MetadataExtractor : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _handle = IntPtr.Zero;
        private IntPtr _buffer = IntPtr.Zero;

        private void Create(Func<MetadataExtractorError> initFunc)
        {
            MetadataExtractorRetValidator.ThrowIfError(
                Interop.MetadataExtractor.Create(out _handle), "Failed to create metadata");

            try
            {
                MetadataExtractorRetValidator.ThrowIfError(initFunc(), "Failed to init");

                _metadata = new Lazy<Metadata>(() => new Metadata(this));
            }
            catch
            {
                Release();
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the MetadataExtractor class with the specified path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="path">The path for the file to extract the metadata.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        public MetadataExtractor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Create(() => Interop.MetadataExtractor.SetPath(_handle, path));
        }

        /// <summary>
        /// Initializes a new instance of the MetadataExtractor class with the specified buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="buffer">The buffer to extract the metadata.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentException">The length of <paramref name="buffer"/> is zero.</exception>
        public MetadataExtractor(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer.Length == 0)
            {
                throw new ArgumentException("buffer length is zero.", nameof(buffer));
            }

            _buffer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, _buffer, buffer.Length);

            try
            {
                Create(() => Interop.MetadataExtractor.SetBuffer(_handle, _buffer, buffer.Length));
            }
            catch (Exception)
            {
                Marshal.FreeHGlobal(_buffer);
                throw;
            }
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(MetadataExtractor));
                }

                return _handle;
            }
        }

        private Lazy<Metadata> _metadata;

        /// <summary>
        /// Retrieves the <see cref="Metadata"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The <see cref="Metadata"/> for the given source.</returns>
        /// <exception cref="InvalidOperationException">An internal process error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataExtractor"/> has been already disposed of.</exception>
        public Metadata GetMetadata()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(MetadataExtractor));
            }

            return _metadata.Value;
        }

        /// <summary>
        /// Gets the artwork image in the source.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The <see cref="Artwork"/> if it exists, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">An internal process error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataExtractor"/> has been already disposed of.</exception>
        public Artwork GetArtwork()
        {
            IntPtr data = IntPtr.Zero;
            IntPtr mimeType = IntPtr.Zero;

            try
            {
                int size = 0;

                var ret = Interop.MetadataExtractor.GetArtwork(Handle, out data, out size, out mimeType);
                MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get value");

                if (size > 0)
                {
                    var buf = new byte[size];
                    Marshal.Copy(data, buf, 0, size);

                    return new Artwork(buf, Marshal.PtrToStringAnsi(mimeType));
                }

                return null;
            }
            finally
            {
                Interop.Libc.Free(data);
                Interop.Libc.Free(mimeType);
            }
        }

        /// <summary>
        /// Gets the sync lyrics of the source.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="index">The index of lyrics to retrieve.</param>
        /// <returns>The <see cref="SyncLyrics"/> object if <paramref name="index"/> is valid, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">An internal process error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataExtractor"/> has been already disposed of.</exception>
        public SyncLyrics GetSyncLyrics(int index)
        {
            IntPtr lyrics = IntPtr.Zero;

            try
            {
                uint timestamp = 0;

                var ret = Interop.MetadataExtractor.GetSynclyrics(Handle, index, out timestamp, out lyrics);
                MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get sync lyrics");

                if (lyrics == IntPtr.Zero)
                {
                    return null;
                }

                return new SyncLyrics(Marshal.PtrToStringAnsi(lyrics), timestamp);
            }
            finally
            {
                Interop.Libc.Free(lyrics);
            }
        }

        /// <summary>
        /// Gets the frame of a video media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The raw thumbnail data in RGB888 if it exists, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">An internal process error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataExtractor"/> has been already disposed of.</exception>
        public byte[] GetVideoThumbnail()
        {
            IntPtr data = IntPtr.Zero;

            try
            {
                int size = 0;

                var ret = Interop.MetadataExtractor.GetFrame(Handle, out data, out size);
                MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get value");

                if (size == 0)
                {
                    return null;
                }

                var buf = new byte[size];
                Marshal.Copy(data, buf, 0, size);

                return buf;
            }
            finally
            {
                Interop.Libc.Free(data);
            }
        }

        /// <summary>
        /// Gets the frame of a video media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="timeStamp">The timestamp in milliseconds.</param>
        /// <param name="accurate">true to get an accurate frame for the given timestamp,
        ///     otherwise false to get the nearest i-frame of the video rapidly.</param>
        /// <returns>The raw frame data in RGB888 if a frame at specified time exists, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MetadataExtractor"/> has been already disposed of.</exception>
        public byte[] GetFrameAt(uint timeStamp, bool accurate)
        {
            IntPtr data = IntPtr.Zero;

            try
            {
                int size = 0;

                var ret = Interop.MetadataExtractor.GetFrameAtTime(Handle, timeStamp, accurate, out data, out size);
                MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get value");

                if (size == 0)
                {
                    return null;
                }

                var buf = new byte[size];
                Marshal.Copy(data, buf, 0, size);

                return buf;
            }
            finally
            {
                Interop.Libc.Free(data);
            }
        }

        /// <summary>
        /// Finalizes an instance of the MetadataExtractor class.
        /// </summary>
        ~MetadataExtractor()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="MetadataExtractor"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Release();
                _disposed = true;
            }
        }

        private void Release()
        {
            if (_buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_buffer);
                _buffer = IntPtr.Zero;
            }

            if (_handle != IntPtr.Zero)
            {
                var ret = Interop.MetadataExtractor.Destroy(_handle);
                if (ret != MetadataExtractorError.None)
                {
                    Log.Error(typeof(MetadataExtractor).FullName, $"DestroyHandle failed : {ret}.");
                }

                _handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="MetadataExtractor"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
