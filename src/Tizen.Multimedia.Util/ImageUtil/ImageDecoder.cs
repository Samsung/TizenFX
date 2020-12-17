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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using static Interop;
using NativeUtil = Interop.ImageUtil;
using NativeDecoder = Interop.ImageUtil.Decode;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// This is a base class for image decoders.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class ImageDecoder : IDisposable
    {
        private ImageDecoderHandle _handle;

        private ColorSpace? _colorSpace;

        internal ImageDecoder(ImageFormat format)
        {
            NativeDecoder.Create(out _handle).ThrowIfFailed("Failed to create ImageDecoder");

            Debug.Assert(_handle != null);

            InputFormat = format;
        }

        /// <summary>
        /// Gets the image format of this decoder.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ImageFormat InputFormat { get; }

        private ImageDecoderHandle Handle
        {
            get
            {
                if (_handle.IsInvalid)
                {
                    throw new ObjectDisposedException(nameof(ImageDecoder));
                }
                return _handle;
            }
        }

        /// <summary>
        /// Sets the color-space to decode into. The default is <see cref="ColorSpace.Rgba8888"/>.
        /// </summary>
        /// <param name="colorSpace">The value indicating color-space to decode into.</param>
        /// <exception cref="ArgumentException"><paramref name="colorSpace"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="colorSpace"/> is not supported by the decoder.</exception>
        /// <seealso cref="ImageUtil.GetSupportedColorSpaces(ImageFormat)"/>
        /// <since_tizen> 4 </since_tizen>
        public void SetColorSpace(ColorSpace colorSpace)
        {
            ValidationUtil.ValidateEnum(typeof(ColorSpace), colorSpace, nameof(ColorSpace));

            if (ImageUtil.GetSupportedColorSpaces(InputFormat).Contains(colorSpace) == false)
            {
                throw new NotSupportedException($"{colorSpace.ToString()} is not supported for {InputFormat}.");
            }

            _colorSpace = colorSpace;
        }

        /// <summary>
        /// Decodes an image from the specified file.
        /// </summary>
        /// <param name="inputFilePath">The input file path from which to decode.</param>
        /// <returns>A task that represents the asynchronous decoding operation.</returns>
        /// <remarks>
        ///     Only Graphics Interchange Format(GIF) codec returns more than one frame.<br/>
        ///     <br/>
        ///     http://tizen.org/privilege/mediastorage is needed if <paramref name="inputFilePath"/> is relevant to the media storage.<br/>
        ///     http://tizen.org/privilege/externalstorage is needed if <paramref name="inputFilePath"/> is relevant to the external storage.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="inputFilePath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="inputFilePath"/> is an empty string.<br/>
        ///     -or-<br/>
        ///     <paramref name="inputFilePath"/> is not a image file.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="inputFilePath"/> does not exists.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required permission to access the path.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="inputFilePath"/> is not <see cref="InputFormat"/>.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageDecoder"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public async Task<IEnumerable<BitmapFrame>> DecodeAsync(string inputFilePath)
        {
            if (inputFilePath == null)
            {
                throw new ArgumentNullException(nameof(inputFilePath));
            }

            if (inputFilePath.Length == 0)
            {
                throw new ArgumentException("path is empty.", nameof(inputFilePath));
            }

            if (CheckHeader(inputFilePath) == false)
            {
                throw new FileFormatException("The file has an invalid header.");
            }

            var pathPtr = Marshal.StringToHGlobalAnsi(inputFilePath);
            try
            {
                NativeDecoder.SetInputPath(Handle, pathPtr).ThrowIfFailed("Failed to set input file path for decoding");

                return await DecodeAsync();
            }
            finally
            {
                Marshal.FreeHGlobal(pathPtr);
            }
        }

        /// <summary>
        /// Decodes an image from the buffer.
        /// </summary>
        /// <param name="inputBuffer">The image buffer from which to decode.</param>
        /// <returns>A task that represents the asynchronous decoding operation.</returns>
        /// <remarks>Only Graphics Interchange Format(GIF) codec returns more than one frame.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="inputBuffer"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="inputBuffer"/> is an empty array.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="inputBuffer"/> is not <see cref="InputFormat"/>.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageDecoder"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<IEnumerable<BitmapFrame>> DecodeAsync(byte[] inputBuffer)
        {
            if (inputBuffer == null)
            {
                throw new ArgumentNullException(nameof(inputBuffer));
            }

            if (inputBuffer.Length == 0)
            {
                throw new ArgumentException("buffer is empty.", nameof(inputBuffer));
            }

            if (CheckHeader(inputBuffer) == false)
            {
                throw new FileFormatException("buffer has an invalid header.");
            }

            NativeDecoder.SetInputBuffer(Handle, inputBuffer, (ulong)inputBuffer.Length).
                ThrowIfFailed("Failed to set input buffer for decoding");

            return DecodeAsync();
        }

        private bool CheckHeader(byte[] input)
        {
            if (input.Length < Header.Length)
            {
                return false;
            }

            for (int i = 0; i < Header.Length; ++i)
            {
                if (input[i] != Header[i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckHeader(string inputFile)
        {
            using (var fs = File.OpenRead(inputFile))
            {
                byte[] fileHeader = new byte[Header.Length];

                if (fs.Read(fileHeader, 0, fileHeader.Length) < Header.Length)
                {
                    return false;
                }
                return CheckHeader(fileHeader);
            }
        }

        private IEnumerable<BitmapFrame> RunDecoding()
        {
            IntPtr imageHandle = IntPtr.Zero;
            IntPtr outBuffer = IntPtr.Zero;

            try
            {
                NativeDecoder.DecodeRun(Handle, out imageHandle).ThrowIfFailed("Failed to decode");

                NativeUtil.GetImage(imageHandle, out int width, out int height, out ImageColorSpace colorspace,
                    out outBuffer, out int size).ThrowIfFailed("Failed to get decoded image.");

                yield return new BitmapFrame(outBuffer, width, height, size);
            }
            finally
            {
                if (outBuffer != IntPtr.Zero)
                {
                    LibcSupport.Free(outBuffer);
                }

                if (imageHandle != IntPtr.Zero)
                {
                    NativeUtil.Destroy(imageHandle).ThrowIfFailed("Failed to destroy handle");
                }
            }
        }

        internal Task<IEnumerable<BitmapFrame>> DecodeAsync()
        {
            Initialize(Handle);

            return Task.Factory.StartNew(RunDecoding, CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        internal virtual void Initialize(ImageDecoderHandle handle)
        {
            if (_colorSpace.HasValue)
            {
                NativeDecoder.SetColorspace(Handle, _colorSpace.Value.ToImageColorSpace()).ThrowIfFailed("Failed to set color space");
            }
        }

        internal abstract byte[] Header { get; }

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Releases the unmanaged resources used by the ImageDecoder.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != null)
                {
                    _handle.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ImageDecoder.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }

    /// <summary>
    /// Provides the ability to decode Bitmap (BMP) encoded images.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class BmpDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { (byte)'B', (byte)'M' };

        /// <summary>
        /// Initializes a new instance of the <see cref="BmpDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Bmp"/>.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public BmpDecoder() : base(ImageFormat.Bmp)
        {
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode the Portable Network Graphics (PNG) encoded images.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PngDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { 0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a };

        /// <summary>
        /// Initializes a new instance of the <see cref="PngDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Png"/>.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public PngDecoder() : base(ImageFormat.Png)
        {
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode the Joint Photographic Experts Group (JPEG) encoded images.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class JpegDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { 0xFF, 0xD8 };

        /// <summary>
        /// A read-only field that represents the default value of <see cref="Downscale"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly JpegDownscale DefaultJpegDownscale = JpegDownscale.None;

        private JpegDownscale _jpegDownscale = DefaultJpegDownscale;

        /// <summary>
        /// Initializes a new instance of the <see cref="JpegDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Jpeg"/>.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public JpegDecoder() : base(ImageFormat.Jpeg)
        {
        }

        /// <summary>
        /// Gets or sets the downscale at which the jpeg image should be decoded.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public JpegDownscale Downscale
        {
            get
            {
                return _jpegDownscale;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(JpegDownscale), value, nameof(Downscale));

                _jpegDownscale = value;
            }
        }

        internal override void Initialize(ImageDecoderHandle handle)
        {
            base.Initialize(handle);

            NativeDecoder.SetJpegDownscale(handle, Downscale).ThrowIfFailed("Failed to set downscale for decoding");
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode the Graphics Interchange Format (GIF) encoded images.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class GifDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { (byte)'G', (byte)'I', (byte)'F' };

        /// <summary>
        /// Initializes a new instance of the <see cref="GifDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Gif"/>.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public GifDecoder() : base(ImageFormat.Gif)
        {
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode the WebP (Lossless and lossy compression for images on the web) encoded images.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class WebPDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { 0x57, 0x45, 0x42, 0x50 };

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.WebP"/>.</remarks>
        /// <since_tizen> 8 </since_tizen>
        public WebPDecoder() : base(ImageFormat.WebP)
        {
        }

        internal override byte[] Header => _header;
    }
}
