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
using System.Threading;
using System.Threading.Tasks;
using Handle = Interop.ThumbnailExtractorHandle;
using Native = Interop.ThumbnailExtractor;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Provides the ability to extract the thumbnail from media files.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class ThumbnailExtractor
    {
        private static Handle CreateHandle()
        {
            Native.Create(out var handle).ThrowIfError("Failed to extract.");

            return handle;
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>A task that represents the asynchronous extracting operation.</returns>
        /// <remarks>The size of the thumbnail will be the default size (320x240).</remarks>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege for accessing the <paramref name="path"/>.</exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        public static Task<ThumbnailExtractionResult> ExtractAsync(string path)
        {
            return RunExtractAsync(path, null, CancellationToken.None);
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path.
        /// </summary>
        /// <returns>A task that represents the asynchronous extracting operation.</returns>
        /// <remarks>The size of the thumbnail will be the default size(320x240).</remarks>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="cancellationToken">The token to stop the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege for accessing the <paramref name="path"/>.</exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static Task<ThumbnailExtractionResult> ExtractAsync(string path, CancellationToken cancellationToken)
        {
            return RunExtractAsync(path, null, cancellationToken);
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>A task that represents the asynchronous extracting operation.</returns>
        /// <remarks>
        /// If the width is not a multiple of 8, it can be changed by the inner process.<br/>
        /// The width will be a multiple of 8 greater than the set value.
        /// </remarks>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="size">The size of the thumbnail.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege for accessing the <paramref name="path"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        public static Task<ThumbnailExtractionResult> ExtractAsync(string path, Size size)
        {
            return RunExtractAsync(path, size, CancellationToken.None);
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>A task that represents the asynchronous extracting operation.</returns>
        /// <remarks>
        /// If the width is not a multiple of 8, it can be changed by the inner process.<br/>
        /// The width will be a multiple of 8 greater than the set value.
        /// </remarks>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="size">The size of the thumbnail.</param>
        /// <param name="cancellationToken">The token to stop the operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege for accessing the <paramref name="path"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        public static Task<ThumbnailExtractionResult> ExtractAsync(string path, Size size,
            CancellationToken cancellationToken)
        {
            return RunExtractAsync(path, size, cancellationToken);
        }

        private static Task<ThumbnailExtractionResult> RunExtractAsync(string path, Size? size,
            CancellationToken cancellationToken)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exists.", path);
            }

            if (size.HasValue)
            {
                if (size.Value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(size), size.Value.Width,
                        "The width must be greater than zero.");
                }

                if (size.Value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(size), size.Value.Height,
                        "The height must be greater than zero.");
                }
            }

            return cancellationToken.IsCancellationRequested ?
                Task.FromCanceled<ThumbnailExtractionResult>(cancellationToken) :
                ExtractAsyncCore(path, size, cancellationToken);
        }


        private static async Task<ThumbnailExtractionResult> ExtractAsyncCore(string path, Size? size,
            CancellationToken cancellationToken)
        {
            using (var handle = CreateHandle())
            {
                Native.SetPath(handle, path).ThrowIfError("Failed to extract; failed to set the path.");

                if (size.HasValue)
                {
                    Native.SetSize(handle, size.Value.Width, size.Value.Height).
                        ThrowIfError("Failed to extract; failed to set the size");
                }

                var tcs = new TaskCompletionSource<ThumbnailExtractionResult>();

                IntPtr id = IntPtr.Zero;

                try
                {
                    var cb = GetCallback(tcs);
                    using (var cbKeeper = ObjectKeeper.Get(cb))
                    {
                        Native.Extract(handle, cb, IntPtr.Zero, out id)
                            .ThrowIfError("Failed to extract.");

                        using (RegisterCancellationToken(tcs, cancellationToken, handle, Marshal.PtrToStringAnsi(id)))
                        {
                            return await tcs.Task;
                        }
                    }
                }
                finally
                {
                    LibcSupport.Free(id);
                }
            }
        }

        private static Native.ThumbnailExtractCallback GetCallback(TaskCompletionSource<ThumbnailExtractionResult> tcs)
        {
            return (error, requestId, thumbWidth, thumbHeight, thumbData, dataSize, _) =>
            {
                if (error == ThumbnailExtractorError.None)
                {
                    try
                    {
                        byte[] tmpBuf = new byte[dataSize];
                        Marshal.Copy(thumbData, tmpBuf, 0, dataSize);

                        tcs.TrySetResult(new ThumbnailExtractionResult(tmpBuf, thumbWidth, thumbHeight));
                    }
                    catch (Exception e)
                    {
                        tcs.TrySetException(new InvalidOperationException("[" + error + "] Failed to copy data.", e));
                    }
                    finally
                    {
                        LibcSupport.Free(thumbData);
                    }
                }
                else
                {
                    tcs.TrySetException(error.ToException("Failed to extract."));
                }
            };
        }

        private static IDisposable RegisterCancellationToken(TaskCompletionSource<ThumbnailExtractionResult> tcs,
            CancellationToken cancellationToken, Handle handle, string id)
        {
            if (cancellationToken.CanBeCanceled == false)
            {
                return null;
            }

            return cancellationToken.Register(() =>
            {
                if (tcs.Task.IsCompleted)
                {
                    return;
                }

                Native.Cancel(handle, id).ThrowIfError("Failed to cancel.");
                tcs.TrySetCanceled();
            });
        }
    }
}
