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
using System.Threading.Tasks;
using static Interop;
using static Interop.Decode;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// This is a base class for image decoders.
    /// </summary>
    public abstract class ImageDecoder : IDisposable
    {
        private ImageDecoderHandle _handle;

        private ColorSpace? _colorSpace;

        internal ImageDecoder(ImageFormat format)
        {
            Create(out _handle).ThrowIfFailed("Failed to create ImageDecoder");

            Debug.Assert(_handle != null);

            InputFormat = format;
        }

        /// <summary>
        /// Gets the image format of this decoder.
        /// </summary>
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
        /// <exception cref="ArgumentException"><paramref name="colorSpace"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="colorSpace"/> is not supported by the decoder.</exception>
        /// <seealso cref="ImageUtil.GetSupportedColorspace(ImageFormat)"/>
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
        /// <param name="inputFilePath">Input file path from which to decode.</param>
        /// <returns>A task that represents the asynchronous decoding operation.</returns>
        /// <remarks>
        ///     Only Graphics Interchange Format(GIF) codec returns more than one frame.\n
        ///     \n
        ///     http://tizen.org/privilege/mediastorage is needed if <paramref name="inputFilePath"/> is relevant to media storage.\n
        ///     http://tizen.org/privilege/externalstorage is needed if <paramref name="inputFilePath"/> is relevant to external storage.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="inputFilePath"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="inputFilePath"/> is an empty string.\n
        ///     - or -\n
        ///     <paramref name="inputFilePath"/> is not a image file.\n
        ///     - or -\n
        ///     The format of <paramref name="inputFilePath"/> is not <see cref="InputFormat"/>.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="inputFilePath"/> does not exists.</exception>
        /// <exception cref="UnauthorizedAccessException">Caller does not have required permission to access the path.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="inputFilePath"/> is not <see cref="InputFormat"/>.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageDecoder"/> has already been disposed of.</exception>
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

                SetInputPath(Handle, pathPtr).ThrowIfFailed("Failed to set input file path for decoding");
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
        /// <remarks>
        ///     Only Graphics Interchange Format(GIF) codec returns more than one frame.\n
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="inputBuffer"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="inputBuffer"/> is an empty array.\n
        ///     - or -\n
        ///     The format of <paramref name="inputBuffer"/> is not <see cref="InputFormat"/>.
        /// </exception>
        /// <exception cref="FileFormatException">The format of <paramref name="inputBuffer"/> is not <see cref="InputFormat"/>.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageDecoder"/> has already been disposed of.</exception>
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

            SetInputBuffer(Handle, inputBuffer, (ulong)inputBuffer.Length).
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

        internal Task<IEnumerable<BitmapFrame>> DecodeAsync()
        {
            Initialize(Handle);

            IntPtr outBuffer = IntPtr.Zero;
            SetOutputBuffer(Handle, out outBuffer).ThrowIfFailed("Failed to decode given image");

            var tcs = new TaskCompletionSource<IEnumerable<BitmapFrame>>();

            Task.Run(() =>
            {
                try
                {
                    int width, height;
                    ulong size;

                    DecodeRun(Handle, out width, out height, out size).ThrowIfFailed("Failed to decode");

                    tcs.SetResult(new[] { new BitmapFrame(outBuffer, width, height, (int)size) });
                }
                catch (Exception e)
                {
                    tcs.TrySetException(e);
                }
                finally
                {
                    LibcSupport.Free(outBuffer);
                }
            });

            return tcs.Task;
        }

        internal virtual void Initialize(ImageDecoderHandle handle)
        {
            if (_colorSpace.HasValue)
            {
                SetColorspace(Handle, _colorSpace.Value.ToImageColorSpace()).ThrowIfFailed("Failed to set color space");
            }
        }

        internal abstract byte[] Header { get; }

        #region IDisposable Support
        private bool _disposed = false;

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

        ~ImageDecoder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// Provides the ability to decode Bitmap (BMP) encoded images.
    /// </summary>
    public class BmpDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { (byte)'B', (byte)'M' };

        /// <summary>
        /// Initialize a new instance of the <see cref="BmpDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Bmp"/>.</remarks>
        public BmpDecoder() : base(ImageFormat.Bmp)
        {
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode Portable Network Graphics (PNG) encoded images.
    /// </summary>
    public class PngDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { 0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a };

        /// <summary>
        /// Initialize a new instance of the <see cref="PngDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Png"/>.</remarks>
        public PngDecoder() : base(ImageFormat.Png)
        {
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode Joint Photographic Experts Group (JPEG) encoded images.
    /// </summary>
    public class JpegDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { 0xFF, 0xD8 };

        /// <summary>
        /// A read-only field that represents the default value of <see cref="Downscale"/>.
        /// </summary>
        public static readonly JpegDownscale DefaultJpegDownscale = JpegDownscale.None;

        private JpegDownscale _jpegDownscale = DefaultJpegDownscale;

        /// <summary>
        /// Initialize a new instance of the <see cref="JpegDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Jpeg"/>.</remarks>
        public JpegDecoder() : base(ImageFormat.Jpeg)
        {
        }

        /// <summary>
        /// Gets or sets the downscale at which the jpeg image should be decoded.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
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

            SetJpegDownscale(handle, Downscale).ThrowIfFailed("Failed to set downscale for decoding");
        }

        internal override byte[] Header => _header;
    }

    /// <summary>
    /// Provides the ability to decode Graphics Interchange Format (GIF) encoded images.
    /// </summary>
    public class GifDecoder : ImageDecoder
    {
        private static readonly byte[] _header = { (byte)'G', (byte)'I', (byte)'F' };

        /// <summary>
        /// Initialize a new instance of the <see cref="GifDecoder"/> class.
        /// </summary>
        /// <remarks><see cref="ImageDecoder.InputFormat"/> will be the <see cref="ImageFormat.Gif"/>.</remarks>
        public GifDecoder() : base(ImageFormat.Gif)
        {
        }

        internal override byte[] Header => _header;
    }
}
