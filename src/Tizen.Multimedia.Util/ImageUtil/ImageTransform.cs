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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop;
using NativeTransform = Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// A base class for image transformations.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class ImageTransform
    {
        internal ImageTransform()
        {
        }

        internal async Task<MediaPacket> RunAsync(TransformHandle handle, MediaPacket source)
        {
            Debug.Assert(source.Format is VideoMediaFormat);
            ValidateFormat(source.Format as VideoMediaFormat);

            var tcs = new TaskCompletionSource<MediaPacket>();

            using (var cbKeeper = ObjectKeeper.Get(GetCallback(tcs, source)))
            {
                var result = NativeTransform.Run(handle, source.GetHandle(), cbKeeper.Target);

                if (result == ImageUtilError.NotSupportedFormat)
                {
                    throw new NotSupportedException(
                        GenerateNotSupportedErrorMessage(source.Format as VideoMediaFormat));
                }
                result.ThrowIfFailed("Failed to transform given packet with " + GetType());

                return await tcs.Task;
            }
        }

        private NativeTransform.TransformCompletedCallback GetCallback(TaskCompletionSource<MediaPacket> tcs,
            MediaPacket source)
        {
            return (nativehandle, errorCode, _) =>
            {
                if (errorCode == ImageUtilError.None)
                {
                    try
                    {
                        tcs.TrySetResult(MediaPacket.From(Marshal.PtrToStructure<IntPtr>(nativehandle)));
                    }
                    catch (Exception e)
                    {
                        tcs.TrySetException(e);
                    }
                }
                else if (errorCode == ImageUtilError.NotSupportedFormat)
                {
                    tcs.TrySetException(new NotSupportedException(
                        GenerateNotSupportedErrorMessage(source.Format as VideoMediaFormat)));
                }
                else
                {
                    tcs.TrySetException(errorCode.ToException("Image transformation failed"));
                }
            };
        }

        internal static TransformHandle CreateHandle()
        {
            NativeTransform.Create(out var handle).ThrowIfFailed("Failed to run ImageTransformer");
            Debug.Assert(handle != null);
            return handle;
        }

        internal abstract string GenerateNotSupportedErrorMessage(VideoMediaFormat format);

        internal abstract void Configure(TransformHandle handle);

        internal virtual void ValidateFormat(VideoMediaFormat format)
        {
        }

        internal virtual async Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            using (TransformHandle handle = CreateHandle())
            {
                Configure(handle);

                return await RunAsync(handle, source);
            }
        }
    }
}
