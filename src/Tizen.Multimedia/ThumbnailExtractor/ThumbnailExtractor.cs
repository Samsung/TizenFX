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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    static internal class ThumbnailExtractorLog
    {
        internal const string LogTag = "Tizen.Multimedia.ThumbnailExtractor";
    }
    /// <summary>
    /// The Thumbnail extractor class provides a set of functions to extract the thumbnail data of the input media file
    /// </summary>
    public class ThumbnailExtractor : IDisposable
    {
        private bool _disposed = false;
        internal IntPtr _handle = IntPtr.Zero;
        /// <summary>
        /// Thumbnail extractor constructor
        /// </summary>
        /// <remarks>
        /// If you need a thumbnail of a specified size, use ThumbnailExtractor(path, width, height).
        /// </remarks>
        /// <param name="path"> The path of the media file to extract the thumbnail data </param>
        public ThumbnailExtractor(string path)
        {
            ThumbnailExtractorError ret = ThumbnailExtractorError.None;

            if (path == null)
            {
                Log.Error(ThumbnailExtractorLog.LogTag, "Path is NULL");
                throw new ArgumentNullException(nameof(path));
            }
            else
            {
                ret = Interop.ThumbnailExtractor.Create(out _handle);
                if (ret != ThumbnailExtractorError.None)
                {
                    Log.Error(ThumbnailExtractorLog.LogTag, "Failed to create constructor" + ret);
                    ThumbnailExtractorErrorFactory.ThrowException(ret, "Failed to create constructor");
                }
                ret = Interop.ThumbnailExtractor.SetPath(_handle, path);
                if (ret != ThumbnailExtractorError.None)
                {
                    Log.Error(ThumbnailExtractorLog.LogTag, "Failed to set path" + ret);
                    Interop.ThumbnailExtractor.Destroy(_handle);
                    _handle = IntPtr.Zero;
                    ThumbnailExtractorErrorFactory.ThrowException(ret, "Failed to set path");
                }
            }
        }
        /// <summary>
        /// Thumbnail extractor constructor
        /// </summary>
        /// <remarks>
        /// If you need default size thumbnail, use ThumbnailExtractor(path). Default size is 320x240.
        /// If the set width is not a multiple of 8, it can be changed by inner process.
        /// The width will be a multiple of 8 greater than the set value.
        /// </remarks>
        /// <param name="path"> The path of the media file to extract the thumbnail data </param>
        /// <param name="width"> The width of the thumbnail </param>
        /// <param name="height"> The height of the thumbnail </param>
        public ThumbnailExtractor(string path, int width, int height)
        {
            ThumbnailExtractorError ret = ThumbnailExtractorError.None;

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path), "Path is NULL");
            }
            else if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Wrong width [" + width + "]");
            }
            else if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Wrong width [" + height + "]");
            }

            ret = Interop.ThumbnailExtractor.Create(out _handle);
            if (ret != ThumbnailExtractorError.None)
            {
                Log.Error(ThumbnailExtractorLog.LogTag, "Failed to create constructor" + ret);
                ThumbnailExtractorErrorFactory.ThrowException(ret, "Failed to create constructor");
            }

            try
            {
                ret = Interop.ThumbnailExtractor.SetPath(_handle, path);
                if (ret != ThumbnailExtractorError.None)
                {
                    Log.Error(ThumbnailExtractorLog.LogTag, "Failed to set path" + ret);
                    ThumbnailExtractorErrorFactory.ThrowException(ret, "Failed to set path");
                }
                ret = Interop.ThumbnailExtractor.SetSize(_handle, width, height);
                if (ret != ThumbnailExtractorError.None)
                {
                    Log.Error(ThumbnailExtractorLog.LogTag, "Failed to set size" + ret);
                    ThumbnailExtractorErrorFactory.ThrowException(ret, "Failed to set size");
                }
            }
            catch (Exception)
            {
                Interop.ThumbnailExtractor.Destroy(_handle);
                _handle = IntPtr.Zero;
            }
        }

        private Task<ThumbnailData> ExtractRequest()
        {
            if (_handle == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(ThumbnailExtractor), "Failed to extract thumbnail");
            }

            IntPtr id = IntPtr.Zero;
            var task = new TaskCompletionSource<ThumbnailData>();

            Interop.ThumbnailExtractor.ThumbnailExtractCallback extractCallback = (ThumbnailExtractorError error,
                                                                                string requestId,
                                                                                int thumbWidth,
                                                                                int thumbHeight,
                                                                                IntPtr thumbData,
                                                                                int thumbSize,
                                                                                IntPtr userData) =>
            {
                if (error == ThumbnailExtractorError.None)
                {
                    byte[] tmpBuf = new byte[thumbSize];
                    Marshal.Copy(thumbData, tmpBuf, 0, thumbSize);
                    Interop.Libc.Free(thumbData);
                    task.TrySetResult(new ThumbnailData(tmpBuf, thumbWidth, thumbHeight));
                }
                else
                {
                    Log.Error(ThumbnailExtractorLog.LogTag, "Failed to extract thumbnail" + error);
                    task.SetException(new InvalidOperationException("["+ error +"] Fail to create thumbnail"));
                }
            };
            ThumbnailExtractorError res = Interop.ThumbnailExtractor.Extract(_handle, extractCallback, IntPtr.Zero, out id);
            if (id != IntPtr.Zero)
            {
                Interop.Libc.Free(id);
                id = IntPtr.Zero;
            }
            if (res != ThumbnailExtractorError.None)
            {
                Log.Error(ThumbnailExtractorLog.LogTag, "Failed to extract thumbnail" + res);
                ThumbnailExtractorErrorFactory.ThrowException(res, "Failed to extract thumbnail");
            }

            return task.Task;
        }
        /// <summary>
        /// Extract thumbnail
        /// </summary>
        /// <value> ThumbData object </value>
        public async Task<ThumbnailData> Extract()
        {
            return await ExtractRequest();
        }

        /// <summary>
        /// Thumbnail Utility destructor
        /// </summary>
        ~ThumbnailExtractor()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // To be used if there are any other disposable objects
                }
                if (_handle != IntPtr.Zero)
                {
                    Interop.ThumbnailExtractor.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
