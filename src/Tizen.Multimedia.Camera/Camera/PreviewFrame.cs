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
using static Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing the preview image data.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PreviewFrame
    {
        internal PreviewFrame(IntPtr ptr)
        {
            var unmanagedStruct = Marshal.PtrToStructure<CameraPreviewDataStruct>(ptr);

            Format = unmanagedStruct.Format;
            Resolution = new Size(unmanagedStruct.Width, unmanagedStruct.Height);
            TimeStamp = unmanagedStruct.TimeStamp;
            PlaneType = GetPlaneType(unmanagedStruct);
            Plane = ConvertPlane(unmanagedStruct);
        }

        private static PlaneType GetPlaneType(CameraPreviewDataStruct unmanagedStruct)
        {
            if (unmanagedStruct.NumOfPlanes == 1)
            {
                switch (unmanagedStruct.Format)
                {
                    case CameraPixelFormat.H264:
                    case CameraPixelFormat.Jpeg:
                    case CameraPixelFormat.Mjpeg:
                    case CameraPixelFormat.Vp8:
                    case CameraPixelFormat.Vp9:
                        return PlaneType.EncodedPlane;
                    case CameraPixelFormat.Invz:
                        return PlaneType.DepthPlane;
                    case CameraPixelFormat.Rgba:
                    case CameraPixelFormat.Argb:
                        return PlaneType.RgbPlane;
                    default:
                        return PlaneType.SinglePlane;
                }
            }
            else if (unmanagedStruct.NumOfPlanes == 2)
            {
                return PlaneType.DoublePlane;
            }

            return PlaneType.TriplePlane;
        }

        private IPreviewPlane ConvertPlane(CameraPreviewDataStruct unmanagedStruct)
        {
            switch (PlaneType)
            {
                case PlaneType.SinglePlane:
                    return new SinglePlane(unmanagedStruct.Plane.SinglePlane);
                case PlaneType.DoublePlane:
                    var size = Resolution.Width * Resolution.Height;
                    unmanagedStruct.Plane.DoublePlane.YLength = (uint)size;
                    unmanagedStruct.Plane.DoublePlane.UVLength = (uint)size / 2;
                    return new DoublePlane(unmanagedStruct.Plane.DoublePlane);
                case PlaneType.TriplePlane:
                    return new TriplePlane(unmanagedStruct.Plane.TriplePlane);
                case PlaneType.EncodedPlane:
                    return new EncodedPlane(unmanagedStruct.Plane.EncodedPlane);
                case PlaneType.DepthPlane:
                    return new DepthPlane(unmanagedStruct.Plane.DepthPlane);
                case PlaneType.RgbPlane:
                    return new RgbPlane(unmanagedStruct.Plane.RgbPlane);
            }

            Debug.Fail("Unknown preview data!");
            return null;
        }

        /// <summary>
        /// The pixel format of the image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraPixelFormat Format { get; }

        /// <summary>
        /// The resolution of the preview image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Size Resolution { get; }

        /// <summary>
        /// The time stamp of the preview frame.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public uint TimeStamp { get; }

        /// <summary>
        /// The type of the preview plane. <see cref="Tizen.Multimedia.PlaneType"/>
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PlaneType PlaneType { get; }

        /// <summary>
        /// The buffer including the preview frame.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public IPreviewPlane Plane { get; }
    }
}
