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

namespace Tizen.Multimedia.Utility
{
    public static class ImageTransformer
    {
        public static Task<MediaPacket> ConvertColorspaceAsync(this MediaPacket packet, ImageColorSpace colorspace, bool useHardwareAcceleration)
        {
            using (var handle = new Interop.ImageTransformHandle())
            {
                handle.Colorspace = (Interop.ImageColorSpace)colorspace;
                return TransformAsync(handle, packet, useHardwareAcceleration);
            }
        }

        public static Task<MediaPacket> ConvertColorspaceAsync(this MediaPacket packet, ImageColorSpace colorspace)
        {
            return ConvertColorspaceAsync(packet, colorspace, false);
        }

        public static Task<MediaPacket> ResizeAsync(this MediaPacket packet, Size resolution, bool useHardwareAcceleration)
        {
            using (var handle = new Interop.ImageTransformHandle())
            {
                handle.SetResolution((uint)resolution.Width, (uint)resolution.Height)
                      .ThrowIfFailed("Failed to set image resolution for transformation");
                return TransformAsync(handle, packet, useHardwareAcceleration);
            }
        }

        public static Task<MediaPacket> ResizeAsync(this MediaPacket packet, Size resolution)
        {
            return ResizeAsync(packet, resolution, false);
        }

        public static Task<MediaPacket> RotateAsync(this MediaPacket packet, ImageRotation rotation, bool useHardwareAcceleration)
        {
            using (var handle = new Interop.ImageTransformHandle())
            {
                handle.Rotation = (Interop.ImageRotation)rotation;
                return TransformAsync(handle, packet, useHardwareAcceleration);
            }
        }

        public static Task<MediaPacket> RotateAsync(this MediaPacket packet, ImageRotation rotation)
        {
            return RotateAsync(packet, rotation, false);
        }

        public static Task<MediaPacket> CropAsync(this MediaPacket packet, Rectangle cropArea, bool useHardwareAcceleration)
        {
            using (var handle = new Interop.ImageTransformHandle())
            {
                handle.SetCropArea(cropArea.X, cropArea.Y, cropArea.X + cropArea.Width, cropArea.Y + cropArea.Height)
                      .ThrowIfFailed("Failed to set crop area for transformation");
                return TransformAsync(handle, packet, useHardwareAcceleration);
            }
        }

        public static Task<MediaPacket> CropAsync(this MediaPacket packet, Rectangle cropArea)
        {
            return CropAsync(packet, cropArea, false);
        }

        private static Task<MediaPacket> TransformAsync(Interop.ImageTransformHandle handle, MediaPacket packet, bool useHardwareAcceleration)
        {
            if (useHardwareAcceleration)
            {
                handle.HardwareAccelerationEnabled = true;
            }

            TaskCompletionSource<MediaPacket> tcs = new TaskCompletionSource<MediaPacket>();
            Interop.ImageTransformHandle.TransformCompletedCallback callback = (nativehandle, errorCode, userData) =>
            {
                if (errorCode.IsSuccess())
                {
                    tcs.TrySetResult(MediaPacket.From(nativehandle));
                }
                else
                {
                    tcs.TrySetException(errorCode.GetException("Image transformation failed."));
                }
            };

            Interop.ImageTransformHandle.Transform(handle, packet.GetHandle(), callback, IntPtr.Zero)
                   .ThrowIfFailed("Failed to transform given packet");
            return Interop.PinnedTask(tcs);
        }
    }
}