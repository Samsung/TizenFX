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
    /// Image decoder utility
    /// </summary>
    public class ImageDecoder : IDisposable
    {
        public const ImageColorSpace DefaultColorspace = ImageColorSpace.Rgba8888;
        public const JpegDownscale DefaultJpegDownscale = JpegDownscale.NoDownscale;

        internal Native.ImageDecoderHandle _handle;
        private ImageColorSpace _colorspace = DefaultColorspace;
        private JpegDownscale _jpegDownscale = DefaultJpegDownscale;

        internal ImageDecoder()
        {
            _handle = new Native.ImageDecoderHandle();
        }

        /// <summary>
        /// Color-space format to decode into, default is <ref>ImageColorspace.Rgba8888</ref>
        /// </summary>
        public ImageColorSpace ColorSpace
        {
            get { return _colorspace; }
            set
            {
                ValidateObjectNotDisposed();
                _handle.Colorspace = (Native.ImageColorSpace)value;
                _colorspace = value;
            }
        }

        /// <summary>
        /// Downscale value at which JPEG image should be decoded.
        /// </summary>
        public JpegDownscale Downscale
        {
            get { return _jpegDownscale; }
            set { _jpegDownscale = value; }
        }

        /// <summary>
        /// Decode image
        /// </summary>
        /// <param name="inputFilePath">Input file path from which to decode</param>
        /// <returns>Decoded image data</returns>
        public Task<ImageData> DecodeAsync(string inputFilePath)
        {
            ValidateObjectNotDisposed();
            if (inputFilePath == null) throw new ArgumentNullException("inputFilePath");

            _handle.SetInputPath(inputFilePath).ThrowIfFailed("Failed to set input file path for decoding");
            return DecodeAsync();
        }

        /// <summary>
        /// Decode image
        /// </summary>
        /// <param name="inputBuffer">Input buffer from which to decode</param>
        /// <returns>Decoded image data</returns>
        public Task<ImageData> DecodeAsync(byte[] inputBuffer)
        {
            ValidateObjectNotDisposed();
            if (inputBuffer == null) throw new ArgumentNullException("inputBuffer");

            _handle.SetInputBuffer(inputBuffer, (ulong)inputBuffer.Length).ThrowIfFailed("Failed to set input buffer for decoding");
            return DecodeAsync();
        }

        internal virtual void Initialize()
        {
            if (_colorspace != DefaultColorspace)
            {
                _handle.Colorspace = (Native.ImageColorSpace)_colorspace;
            }

            if (_jpegDownscale != DefaultJpegDownscale)
            {
                _handle.SetJpegDownscale((Native.JpegDownscale)_jpegDownscale).ThrowIfFailed("Failed to set JPEG Downscale for decoding");
            }
        }

        internal Task<ImageData> DecodeAsync()
        {
            IntPtr nativeBuffer = IntPtr.Zero;
            _handle.SetOutputBuffer(out nativeBuffer).ThrowIfFailed("Failed to set output buffer for decoding");

            Initialize();

            TaskCompletionSource<ImageData> tcs = new TaskCompletionSource<ImageData>();
            Native.ImageDecoderHandle.DecodeCompletedCallback callback = (errorCode, userData, width, height, size) =>
            {
                if (errorCode.IsSuccess())
                {
                    var decodedImage = new ImageData(nativeBuffer, width, height, (int)size);
                    tcs.TrySetResult(decodedImage);
                }
                else
                {
                    tcs.TrySetException(errorCode.GetException("Image decoding failed."));
                }
            };

            Native.ImageDecoderHandle.DecodeRunAsync(_handle, callback, IntPtr.Zero).ThrowIfFailed("Failed to decode given image");
            return Native.PinnedTask(tcs);
        }

        private void ValidateObjectNotDisposed()
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _handle.Dispose();
                _disposedValue = true;
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
}