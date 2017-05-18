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
using System.Diagnostics;
using InteropSource = Interop.MediaVision.MediaSource;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents the media vision source to keep information on image or video frame data as raw buffer.
    /// </summary>
    public class MediaVisionSource : IBufferOwner, IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        internal MediaVisionSource()
        {
            InteropSource.Create(out _handle).Validate("Failed to create media vision source");
        }

        private MediaVisionSource(Action<IntPtr> fillAction)
            : this()
        {
            try
            {
                fillAction(_handle);
            }
            catch(Exception)
            {
                InteropSource.Destroy(_handle);
                _disposed = true;
                throw;
            }
        }

        private static void FillMediaPacket(IntPtr handle, MediaPacket mediaPacket)
        {
            Debug.Assert(handle != IntPtr.Zero);

            if (mediaPacket == null)
            {
                throw new ArgumentNullException(nameof(mediaPacket));
            }

            InteropSource.FillMediaPacket(handle, mediaPacket.GetHandle()).
                Validate("Failed to fill media packet");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVisionSource"/> class based on the <see cref="MediaPacket"/>.
        /// </summary>
        /// <param name="mediaPacket">The <see cref="MediaPacket"/> from which the source will be filled.</param>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaPacket"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="mediaPacket"/> has already been disposed of.</exception>
        public MediaVisionSource(MediaPacket mediaPacket)
            : this(handle => FillMediaPacket(handle, mediaPacket))
        {
        }

        private static void FillBuffer(IntPtr handle, byte[] buffer, uint width, uint height, Colorspace colorspace)
        {
            Debug.Assert(handle != IntPtr.Zero);

            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer.Length == 0)
            {
                throw new ArgumentException("Buffer.Length is zero.", nameof(buffer));
            }

            if (colorspace == Colorspace.Invalid)
            {
                throw new ArgumentException($"color space must not be {Colorspace.Invalid}.", nameof(colorspace));
            }

            ValidationUtil.ValidateEnum(typeof(Colorspace), colorspace, nameof(colorspace));

            InteropSource.FillBuffer(handle, buffer, buffer.Length, width, height, colorspace).
                Validate("Failed to fill buffer");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVisionSource"/> class based on the buffer and <see cref="Colorspace"/>.
        /// </summary>
        /// <param name="buffer">The buffer of image data.</param>
        /// <param name="width">The width of image.</param>
        /// <param name="height">The height of image.</param>
        /// <param name="colorspace">The image <see cref="Colorspace"/>.</param>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="buffer"/> has no element.(The length is zero.)\n
        ///     - or -\n
        ///     <paramref name="colorspace"/> is invalid.
        /// </exception>
        public MediaVisionSource(byte[] buffer, uint width, uint height, Colorspace colorspace)
            : this(handle => FillBuffer(handle, buffer, width, height, colorspace))
        {
        }

        ~MediaVisionSource()
        {
            Dispose(false);
        }

        private IMediaBuffer _buffer;

        /// <summary>
        /// Gets the buffer of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        public IMediaBuffer Buffer
        {
            get
            {
                if (_buffer == null)
                {
                    IntPtr bufferHandle = IntPtr.Zero;
                    int bufferSize = 0;

                    InteropSource.GetBuffer(Handle, out bufferHandle, out bufferSize).
                        Validate("Failed to get buffer");

                    _buffer = new DependentMediaBuffer(this, bufferHandle, bufferSize);
                }
                return _buffer;
            }
        }

        /// <summary>
        /// Gets height of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        public uint Height
        {
            get
            {
                uint height = 0;
                var ret = InteropSource.GetHeight(Handle, out height);
                MultimediaDebug.AssertNoError(ret);
                return height;
            }
        }

        /// <summary>
        /// Gets width of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        public uint Width
        {
            get
            {
                uint width = 0;
                var ret = InteropSource.GetWidth(Handle, out width);
                MultimediaDebug.AssertNoError(ret);
                return width;
            }
        }

        /// <summary>
        /// Gets <see cref="Colorspace"/> of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        public Colorspace Colorspace
        {
            get
            {
                Colorspace colorspace = Colorspace.Invalid;
                var ret = InteropSource.GetColorspace(Handle, out colorspace);
                MultimediaDebug.AssertNoError(ret);
                return colorspace;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            InteropSource.Destroy(_handle);
            _disposed = true;
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(MediaVisionSource));
                }
                return _handle;
            }
        }

        bool IBufferOwner.IsBufferAccessible(object buffer, MediaBufferAccessMode accessMode)
        {
            return true;
        }

        bool IBufferOwner.IsDisposed
        {
            get { return _disposed; }
        }
    }
}
