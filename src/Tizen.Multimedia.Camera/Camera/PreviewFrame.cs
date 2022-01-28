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
        internal PreviewFrame(IntPtr ptr, ref PinnedPreviewBuffer<byte> buffers)
        {
            var unmanagedStruct = Marshal.PtrToStructure<CameraPreviewDataStruct>(ptr);

            Format = unmanagedStruct.Format;
            Resolution = new Size(unmanagedStruct.Width, unmanagedStruct.Height);
            TimeStamp = unmanagedStruct.TimeStamp;
            PlaneType = GetPlaneType(unmanagedStruct);
            CreatePlane(unmanagedStruct, ref buffers);
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

        internal void CreatePlane(CameraPreviewDataStruct unmanagedStruct, ref PinnedPreviewBuffer<byte> buffers)
        {
            switch (PlaneType)
            {
                case PlaneType.SinglePlane:
                    var singlePlane = unmanagedStruct.Plane.SinglePlane;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(singlePlane.DataLength);
                    }

                    Marshal.Copy(singlePlane.Data, buffers[0], 0, (int)singlePlane.DataLength);
                    Plane = new SinglePlane(buffers[0]);

                    break;
                case PlaneType.DoublePlane:
                    var doublePlane = unmanagedStruct.Plane.DoublePlane;

                    doublePlane.YLength = (uint)(Resolution.Width * Resolution.Height);
                    doublePlane.UVLength = (uint)(Resolution.Width * Resolution.Height) / 2;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(doublePlane.YLength, doublePlane.UVLength);
                    }

                    Marshal.Copy(doublePlane.Y, buffers[0], 0, (int)doublePlane.YLength);
                    Marshal.Copy(doublePlane.UV, buffers[1], 0, (int)doublePlane.UVLength);
                    Plane =  new DoublePlane(buffers[0], buffers[1]);

                    break;
                case PlaneType.TriplePlane:
                    var triplePlane = unmanagedStruct.Plane.TriplePlane;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(triplePlane.YLength, triplePlane.ULength, triplePlane.VLength);
                    }

                    Marshal.Copy(triplePlane.Y, buffers[0], 0, (int)triplePlane.YLength);
                    Marshal.Copy(triplePlane.U, buffers[1], 0, (int)triplePlane.ULength);
                    Marshal.Copy(triplePlane.V, buffers[2], 0, (int)triplePlane.VLength);
                    Plane =  new TriplePlane(buffers[0], buffers[1], buffers[2]);

                    break;
                case PlaneType.EncodedPlane:
                    var encodedPlane = unmanagedStruct.Plane.EncodedPlane;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(encodedPlane.DataLength * 2);
                    }

                    Marshal.Copy(encodedPlane.Data, buffers[0], 0, (int)encodedPlane.DataLength);
                    Plane = new EncodedPlane(buffers[0], encodedPlane.IsDeltaFrame);

                    break;
                case PlaneType.DepthPlane:
                    var depthPlane = unmanagedStruct.Plane.DepthPlane;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(depthPlane.DataLength);
                    }

                    Marshal.Copy(depthPlane.Data, buffers[0], 0, (int)depthPlane.DataLength);
                    Plane = new DepthPlane(buffers[0]);

                    break;
                case PlaneType.RgbPlane:
                    var rgbPlane = unmanagedStruct.Plane.RgbPlane;

                    if (buffers == null)
                    {
                        buffers = new PinnedPreviewBuffer<byte>(rgbPlane.DataLength);
                    }
                    Marshal.Copy(rgbPlane.Data, buffers[0], 0, (int)rgbPlane.DataLength);

                    Plane = new RgbPlane(buffers[0]);
                    break;
                default:
                    Debug.Fail("Unknown preview data!");
                    break;
            }
        }

        internal static uint GetMaxPreviewPlaneSize(IntPtr ptr)
        {
            uint size = 0;
            var unmanagedStruct = Marshal.PtrToStructure<CameraPreviewDataStruct>(ptr);

            switch (GetPlaneType(unmanagedStruct))
            {
                case PlaneType.SinglePlane:
                    size = unmanagedStruct.Plane.SinglePlane.DataLength;
                    break;
                case PlaneType.DoublePlane:
                    size = unmanagedStruct.Plane.DoublePlane.UVLength;
                    break;
                case PlaneType.TriplePlane:
                    size = unmanagedStruct.Plane.TriplePlane.YLength;
                    break;
                case PlaneType.EncodedPlane:
                    size = unmanagedStruct.Plane.EncodedPlane.DataLength;
                    break;
                case PlaneType.DepthPlane:
                    size = unmanagedStruct.Plane.DepthPlane.DataLength;
                    break;
                case PlaneType.RgbPlane:
                    size = unmanagedStruct.Plane.RgbPlane.DataLength;
                    break;
                default:
                    Debug.Fail("Unknown preview data!");
                    break;
            }

            return size;
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
        public IPreviewPlane Plane { get; private set;}
    }
}
