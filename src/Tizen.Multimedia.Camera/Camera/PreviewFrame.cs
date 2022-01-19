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
        private byte[] _y, _u, _v;

        internal PreviewFrame(IntPtr ptr, ref PreviewBuffer<byte> buffers)
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

        internal void CreatePlane(CameraPreviewDataStruct unmanagedStruct, ref PreviewBuffer<byte> buffers)
        {
            Log.Info(CameraLog.Tag, "Enter");
            switch (PlaneType)
            {
                case PlaneType.SinglePlane:
                    Log.Info(CameraLog.Tag, "SinglePlane - START");
                    var singlePlane = unmanagedStruct.Plane.SinglePlane;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "SinglePlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(singlePlane.DataLength);
                    }
                    Log.Info(CameraLog.Tag, "SinglePlane - Marshal copy");
                    Marshal.Copy(singlePlane.Data, buffers[0], 0, (int)singlePlane.DataLength);

                    Log.Info(CameraLog.Tag, "SinglePlane - Create SinglePlane instance");
                    Plane = new SinglePlane(buffers[0]);
                    Log.Info(CameraLog.Tag, "SinglePlane - DONE");
                    break;
                case PlaneType.DoublePlane:
                    Log.Info(CameraLog.Tag, "DoublePlane - START");
                    var doublePlane = unmanagedStruct.Plane.DoublePlane;

                    doublePlane.YLength = (uint)(Resolution.Width * Resolution.Height);
                    doublePlane.UVLength = (uint)(Resolution.Width * Resolution.Height) / 2;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "DoublePlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(doublePlane.YLength, doublePlane.UVLength);
                    }

                    Log.Info(CameraLog.Tag, $"DoublePlane - Marshal copy");
                    Marshal.Copy(doublePlane.Y, buffers[0], 0, (int)doublePlane.YLength);
                    Marshal.Copy(doublePlane.UV, buffers[1], 0, (int)doublePlane.UVLength);

                    Log.Info(CameraLog.Tag, "DoublePlane - Create DoublePlane instance");
                    Plane =  new DoublePlane(buffers[0], buffers[1]);
                    Log.Info(CameraLog.Tag, "DoublePlane - DONE");
                    break;
                case PlaneType.TriplePlane:
                    Log.Info(CameraLog.Tag, "TriplePlane - START");
                    var triplePlane = unmanagedStruct.Plane.TriplePlane;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "TriplePlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(triplePlane.YLength, triplePlane.ULength, triplePlane.VLength);
                    }
                    Log.Info(CameraLog.Tag, "TriplePlane - Marshal copy");
                    Marshal.Copy(triplePlane.Y, buffers[0], 0, (int)triplePlane.YLength);
                    Marshal.Copy(triplePlane.U, buffers[1], 0, (int)triplePlane.ULength);
                    Marshal.Copy(triplePlane.V, buffers[2], 0, (int)triplePlane.VLength);

                    Log.Info(CameraLog.Tag, "TriplePlane - Create TriplePlane instance");
                    Plane =  new TriplePlane(buffers[0], buffers[1], buffers[2]);
                    Log.Info(CameraLog.Tag, "TriplePlane - DONE");
                    break;
                case PlaneType.EncodedPlane:
                    Log.Info(CameraLog.Tag, "EncodedPlane - START");
                    var encodedPlane = unmanagedStruct.Plane.EncodedPlane;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "EncodedPlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(encodedPlane.DataLength * 2);
                    }
                    Log.Info(CameraLog.Tag, "EncodedPlane - Marshal copy");
                    Marshal.Copy(encodedPlane.Data, buffers[0], 0, (int)encodedPlane.DataLength);

                    Log.Info(CameraLog.Tag, "EncodedPlane - Create EncodedPlane instance");
                    Plane = new EncodedPlane(buffers[0], encodedPlane.IsDeltaFrame);
                    Log.Info(CameraLog.Tag, "EncodedPlane - DONE");
                    break;
                case PlaneType.DepthPlane:
                    Log.Info(CameraLog.Tag, "DepthPlane - START");
                    var depthPlane = unmanagedStruct.Plane.DepthPlane;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "DepthPlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(depthPlane.DataLength);
                    }
                    Log.Info(CameraLog.Tag, "DepthPlane - Marshal copy");
                    Marshal.Copy(depthPlane.Data, buffers[0], 0, (int)depthPlane.DataLength);

                    Log.Info(CameraLog.Tag, "DepthPlane - Create DepthPlane instance");
                    Plane = new DepthPlane(buffers[0]);
                    Log.Info(CameraLog.Tag, "DepthPlane - DONE");
                    break;
                case PlaneType.RgbPlane:
                    var rgbPlane = unmanagedStruct.Plane.RgbPlane;

                    if (buffers == null)
                    {
                        Log.Info(CameraLog.Tag, "RgbPlane - Alloc buffer");
                        buffers = new PreviewBuffer<byte>(rgbPlane.DataLength);
                    }
                    Marshal.Copy(rgbPlane.Data, buffers[0], 0, (int)rgbPlane.DataLength);

                    Plane = new RgbPlane(buffers[0]);
                    break;
                default:
                    Debug.Fail("Unknown preview data!");
                    break;
            }
            Log.Info(CameraLog.Tag, "Leave");
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
                    Log.Info(CameraLog.Tag, $"Size : {size}");
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
