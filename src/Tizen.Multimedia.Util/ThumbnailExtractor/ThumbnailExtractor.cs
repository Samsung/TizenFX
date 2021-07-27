/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
                        tcs.TrySetResult(new ThumbnailExtractionResult(thumbData, thumbWidth, thumbHeight, dataSize));
                    }
                    catch (Exception e)
                    {
                        tcs.TrySetException(new InvalidOperationException("[" + error + "] Failed to create ThumbnailExtractionResult instance.", e));
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

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// The generated thumbnail will be returned in <see cref="ThumbnailExtractionResult"/>.
        /// </summary>
        /// <remarks>
        /// The size of generated thumbnail will be 320x240.<br/>
        /// If the size of <paramref name="path"/> has different ratio from 320x240 (approximately 1.33:1),<br/>
        /// thumbnail is generated in a way to keep the ratio of <paramref name="path"/>, which is based on short axis of <paramref name="path"/>.<br/>
        /// For example, if the size of <paramref name="path"/> is 900x500 (1.8:1), the size of generated thumbnail is 432x240(1.8:1).<br/>
        /// To set the size different from 320x240, please use <see cref="Extract(string, Size)"/>.<br/>
        /// <br/>
        /// If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage. <br/>
        /// If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <returns>The result of extracting operation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static ThumbnailExtractionResult Extract(string path)
        {
            return Extract(path, new Size(320, 240));
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// The generated thumbnail will be returned in <see cref="ThumbnailExtractionResult"/>.
        /// </summary>
        /// <remarks>
        /// The size of generated thumbnail will be <paramref name="size"/>.<br/>
        /// But, if the size of <paramref name="path"/> has different ratio with <paramref name="size"/>,<br/>
        /// thumbnail will be generated in a way to keep the ratio of <paramref name="path"/>, which based on short axis of <paramref name="path"/>.<br/>
        /// For example, if the size of <paramref name="path"/> is 900x500 (1.8:1)) and <paramref name="size"/> is 320x240,<br/>
        /// the size of generated thumbnail is 432x240(1.8:1).<br/>
        /// <br/>
        /// If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage. <br/>
        /// If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="size">The size of the thumbnail.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <returns>The result of extracting operation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static ThumbnailExtractionResult Extract(string path, Size size)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exists.", path);
            }

            if (size.Width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Width,
                    "The width must be greater than zero.");
            }

            if (size.Height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Height,
                    "The height must be greater than zero.");
            }

            Native.ExtractToBuffer(path, (uint)size.Width, (uint)size.Height, out IntPtr thumbData,
                out int dataSize, out uint thumbWidth, out uint thumbHeight).
                ThrowIfError("Failed to extract thumbnail to buffer");

            try
            {
                return new ThumbnailExtractionResult(thumbData, (int)thumbWidth, (int)thumbHeight,
                    dataSize);
            }
            finally
            {
                if (thumbData != IntPtr.Zero)
                {
                    LibcSupport.Free(thumbData);
                }
            }
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// The generated thumbnail will be saved in <paramref name="resultThumbnailPath"/>.
        /// </summary>
        /// <remarks>
        /// The size of <paramref name="resultThumbnailPath"/> image will be 320x240.<br/>
        /// If the size of <paramref name="path"/> has different ratio with 320x240 (approximately 1.33:1),<br/>
        /// thumbnail is generated in a way to keep the ratio of <paramref name="path"/>, which is based on short axis of <paramref name="path"/>.<br/>
        /// For example, if the size of <paramref name="path"/> is 900x500 (1.8:1), the size of <paramref name="resultThumbnailPath"/> is 432x240(1.8:1).<br/>
        /// To set the size different from 320x240, please use <see cref="Extract(string, Size, string)"/>.<br/>
        /// <br/>
        /// If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage. <br/>
        /// If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="resultThumbnailPath">The path to save the generated thumbnail.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> or <paramref name="resultThumbnailPath"/> is invalid.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="resultThumbnailPath"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void Extract(string path, string resultThumbnailPath)
        {
            Extract(path, new Size(320, 240), resultThumbnailPath);
        }

        /// <summary>
        /// Extracts the thumbnail for the given media with the specified path and size.
        /// The generated thumbnail will be saved in <paramref name="resultThumbnailPath"/>.
        /// </summary>
        /// <remarks>
        /// The size of <paramref name="resultThumbnailPath"/> image will be <paramref name="size"/>.<br/>
        /// But, if the size of <paramref name="path"/> has different ratio with <paramref name="size"/>,<br/>
        /// thumbnail will be generated in a way to keep the ratio of <paramref name="path"/>, which based on short axis of <paramref name="path"/>.<br/>
        /// For example, if the size of <paramref name="path"/> is 900x500 (1.8:1) and <paramref name="size"/> is 320x240,<br/>
        /// the size of <paramref name="resultThumbnailPath"/> is 432x240(1.8:1).<br/>
        /// <br/>
        /// If you want to access internal storage, you should add privilege http://tizen.org/privilege/mediastorage. <br/>
        /// If you want to access external storage, you should add privilege http://tizen.org/privilege/externalstorage.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="path">The path of the media file to extract the thumbnail.</param>
        /// <param name="size">The size of the thumbnail.</param>
        /// <param name="resultThumbnailPath">The path to save the generated thumbnail.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> or <paramref name="resultThumbnailPath"/> is invalid.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="resultThumbnailPath"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exist.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width or the height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        /// <exception cref="FileFormatException">The specified file is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void Extract(string path, Size size, string resultThumbnailPath)
        {
            ValidationUtil.ValidateIsNullOrEmpty(path, nameof(path));
            ValidationUtil.ValidateIsNullOrEmpty(resultThumbnailPath, nameof(resultThumbnailPath));

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exists.", path);
            }

            if (size.Width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Width,
                    "The width must be greater than zero.");
            }

            if (size.Height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size.Height,
                    "The height must be greater than zero.");
            }

            Native.ExtractToFile(path, (uint)size.Width, (uint)size.Height, resultThumbnailPath).
                ThrowIfError("Failed to extract thumbnail to file.");
        }
    }
}
