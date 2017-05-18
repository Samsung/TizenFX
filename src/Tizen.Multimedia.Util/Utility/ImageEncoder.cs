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
using System.Threading.Tasks;
using Native = Interop;

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Image Encoder Utility
    /// </summary>
    public class ImageEncoder
    {
        public const ImageColorSpace DefaultColorspace = ImageColorSpace.Rgba8888;

        private ImageColorSpace _colorspace = DefaultColorspace;
        private Size _resolution;
        private ImageFormat _type;

        internal ImageEncoder(ImageFormat type)
        {
            _type = type;
        }

        /// <summary>
        /// Color-space format to encode into, default is <ref>ImageColorspace.Rgba8888</ref>
        /// </summary>
        public ImageColorSpace ColorSpace
        {
            get { return _colorspace; }
            set { _colorspace = value; }
        }

        /// <summary>
        /// Resolution of the encoded image
        /// </summary>
        public Size Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        /// <summary>
        /// Encode image
        /// </summary>
        /// <param name="inputBuffer">Input buffer from which to encode</param>
        /// <returns>Encoded image buffer</returns>
        public Task<byte[]> EncodeAsync(byte[] inputBuffer)
        {
            using (var handle = new Native.ImageEncoderHandle((Native.ImageType)_type))
            {
                handle.SetInputBuffer(inputBuffer).ThrowIfFailed("Failed to set input buffer for encoding");

                IntPtr nativeBuffer = IntPtr.Zero;
                handle.SetOutputBuffer(out nativeBuffer).ThrowIfFailed("Failed to set output buffer for encoding");

                Initialize(handle);

                TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
                Native.ImageEncoderHandle.EncodeCompletedCallback callback = (errorCode, userData, size) =>
                {
                    if (errorCode.IsSuccess())
                    {
                        tcs.TrySetResult(Native.ImageUtil.NativeToByteArray(nativeBuffer, (int)size));
                    }
                    else
                    {
                        tcs.TrySetException(errorCode.GetException("Image encoding failed."));
                    }
                };

                Native.ImageEncoderHandle.EncodeRunAsync(handle, callback, IntPtr.Zero).ThrowIfFailed("Failed to encode given image");
                return Native.PinnedTask(tcs);
            }
        }

        /// <summary>
        /// Encode image
        /// </summary>
        /// <param name="inputBuffer">Input buffer from which to encode</param>
        /// <param name="outputFilePath">Output path to which to encoded buffer will be written to</param>
        /// <returns>true if encoding is successful</returns>
        public Task EncodeAsync(byte[] inputBuffer, string outputFilePath)
        {
            using (var handle = new Native.ImageEncoderHandle((Native.ImageType)_type))
            {
                handle.SetInputBuffer(inputBuffer).ThrowIfFailed("Failed to set input buffer for encoding");
                handle.SetOutputPath(outputFilePath).ThrowIfFailed("Failed to set output file path for encoding");

                Initialize(handle);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                Native.ImageEncoderHandle.EncodeCompletedCallback callback = (errorCode, userData, size) =>
                {
                    if (errorCode.IsSuccess())
                    {
                        tcs.TrySetResult(true);
                    }
                    else
                    {
                        tcs.TrySetException(errorCode.GetException("Image encoding failed."));
                    }
                };

                Native.ImageEncoderHandle.EncodeRunAsync(handle, callback, IntPtr.Zero).ThrowIfFailed("Failed to encode given image");
                return Native.PinnedTask(tcs);
            }
        }

        internal virtual void Initialize(Native.ImageEncoderHandle handle)
        {
            if (_colorspace != DefaultColorspace)
            {
                handle.Colorspace = (Native.ImageColorSpace)_colorspace;
            }

            if (_resolution.Width != 0 && _resolution.Height != 0)
            {
                handle.SetResolution((uint)_resolution.Width, (uint)_resolution.Height);
            }
        }

        internal static void ValidateInputRange<T>(T actualValue, T min, T max, string paramName) where T : IComparable<T>
        {
            if (min.CompareTo(actualValue) == 1 || max.CompareTo(actualValue) == -1)
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, $"Valid Range [{min} - {max}]");
            }
        }

        internal static void ValidateInputRange<T>(T actualValue, Func<bool> verifier, string paramName, string message)
        {
            if (verifier() == false)
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, message);
            }
        }
    }

    /// <summary>
    /// BMP image encoder
    /// </summary>
    public class BmpEncoder : ImageEncoder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BmpEncoder() : base(ImageFormat.Bmp)
        {
        }
    }

    /// <summary>
    /// JPEG image encoder
    /// </summary>
    public class JpegEncoder : ImageEncoder
    {
        public const int DefaultQuality = 75;
        private int _quality = DefaultQuality;

        /// <summary>
        /// Constructor
        /// </summary>
        public JpegEncoder() : base(ImageFormat.Jpeg)
        {
        }

        /// <summary>
        /// Encoding quality from 1~100, default is 75
        /// </summary>
        public int Quality
        {
            get { return _quality; }
            set
            {
                ValidateInputRange<int>(value, 1, 100, "Quality");
                _quality = value;
            }
        }

        internal override void Initialize(Native.ImageEncoderHandle handle)
        {
            if (_quality != DefaultQuality)
            {
                base.Initialize(handle);
                handle.Quality = _quality;
            }
        }
    }

    /// <summary>
    /// PNG image encoder
    /// </summary>
    public class PngEncoder : ImageEncoder
    {
        public const PngCompression DefaultPngCompressionLevel = PngCompression.Level6;
        private PngCompression _pngCompressionLevel = DefaultPngCompressionLevel;

        /// <summary>
        /// Constructor
        /// </summary>
        public PngEncoder() : base(ImageFormat.Png)
        {
        }

        /// <summary>
        /// Compression value of PNG image encoding
        /// </summary>
        public PngCompression CompressionLevel
        {
            get { return _pngCompressionLevel; }
            set {_pngCompressionLevel = value; }
        }

        internal override void Initialize(Native.ImageEncoderHandle handle)
        {
            if (_pngCompressionLevel != DefaultPngCompressionLevel)
            {
                base.Initialize(handle);
                handle.PngCompression = (Native.PngCompression)_pngCompressionLevel;
            }
        }
    }

    /// <summary>
    /// GIF image encoder
    /// </summary>
    public class GifEncoder : ImageEncoder
    {
        public const int DefaultGifFrameDelay = 0;
        private ulong _gifFrameDelay = DefaultGifFrameDelay;

        /// <summary>
        /// Constructor
        /// </summary>
        public GifEncoder() : base(ImageFormat.Gif)
        {
        }

        /// <summary>
        /// Time delay between each frame in the encoded image, in 0.01sec units
        /// </summary>
        public ulong FrameDelay
        {
            get { return _gifFrameDelay; }
            set { _gifFrameDelay = value; }
        }

        internal override void Initialize(Native.ImageEncoderHandle handle)
        {
            if (_gifFrameDelay != DefaultGifFrameDelay)
            {
                base.Initialize(handle);
                handle.GifFrameDelay = _gifFrameDelay;
            }
        }
    }
}