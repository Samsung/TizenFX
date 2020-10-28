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
using System.Linq;
using System.Collections.Generic;
using InteropSource = Interop.MediaVision.MediaSource;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the media vision source to keep information on the image or video frame data as raw buffer.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.barcode_detection</feature>
    /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <since_tizen> 4 </since_tizen>
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
            catch (Exception)
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
        /// <exception cref="NotSupportedException">None of the related features are not supported.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaPacket"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="mediaPacket"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaVisionSource(MediaPacket mediaPacket)
            : this(handle => FillMediaPacket(handle, mediaPacket))
        {
        }

        private static void FillBuffer(IntPtr handle, byte[] buffer, uint width, uint height, ColorSpace colorSpace)
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

            ValidationUtil.ValidateEnum(typeof(ColorSpace), colorSpace, nameof(colorSpace));

            InteropSource.FillBuffer(handle, buffer, buffer.Length, width, height, colorSpace.ToVisionColorSpace()).
                Validate("Failed to fill buffer");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVisionSource"/> class based on the buffer and <see cref="ColorSpace"/>.
        /// </summary>
        /// <param name="buffer">The buffer of image data.</param>
        /// <param name="width">The width of image.</param>
        /// <param name="height">The height of image.</param>
        /// <param name="colorSpace">The image <see cref="ColorSpace"/>.</param>
        /// <exception cref="NotSupportedException">
        ///     None of the related features are not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="colorSpace"/> is not supported.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="buffer"/> has no element.(The length is zero.)<br/>
        ///     -or-<br/>
        ///     <paramref name="colorSpace"/> is invalid.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaVisionSource(byte[] buffer, uint width, uint height, ColorSpace colorSpace)
            : this(handle => FillBuffer(handle, buffer, width, height, colorSpace))
        {
        }

        /// <summary>
        /// Finalizes an instance of the MediaVisionSource class.
        /// </summary>
        ~MediaVisionSource()
        {
            Dispose(false);
        }

        private IMediaBuffer _buffer;

        /// <summary>
        /// Gets the buffer of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets MediaVision's supported ColorSpace state.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static bool IsSupportedColorSpace(ColorSpace colorSpace)
        {
            return SupportedColorSpaces.Contains(colorSpace);
        }

        /// <summary>
        /// Gets the height of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the width of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets <see cref="ColorSpace"/> of the media source.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaVisionSource"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public ColorSpace Colorspace
        {
            get
            {
                VisionColorSpace visionColorSpace;

                var ret = InteropSource.GetColorspace(Handle, out visionColorSpace);
                MultimediaDebug.AssertNoError(ret);
                return visionColorSpace.ToCommonColorSpace();
            }
        }

        /// <summary>
        /// Gets the supported colorspaces for <see cref="MediaVisionSource"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<ColorSpace> SupportedColorSpaces
        {
            get
            {
                foreach (VisionColorSpace value in Enum.GetValues(typeof(VisionColorSpace)))
                {
                    yield return value.ToCommonColorSpace();
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="MediaVisionSource"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; otherwise false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
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
