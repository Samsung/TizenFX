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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tizen.Internals;
using Tizen.Multimedia.Vision;

/// <summary>
/// Interop APIs.
/// </summary>
internal static partial class Interop
{
    internal static Tizen.Multimedia.Point ToApiStruct(this MediaVision.Point pt)
    {
        return new Tizen.Multimedia.Point(pt.x, pt.y);
    }

    internal static MediaVision.Point ToMarshalable(this Tizen.Multimedia.Point pt)
    {
        return new MediaVision.Point() { x = pt.X, y = pt.Y };
    }

    internal static MediaVision.Point[] ToMarshalable(Tizen.Multimedia.Point[] pts)
    {
        var result = new MediaVision.Point[pts.Length];
        for (int i = 0; i < pts.Length; ++i)
        {
            result[i] = pts[i].ToMarshalable();
        }
        return result;
    }


    internal static Quadrangle ToApiStruct(this MediaVision.Quadrangle quadrangle)
    {
        Tizen.Multimedia.Point[] points = new Tizen.Multimedia.Point[4];
        for (int i = 0; i < 4; ++i)
        {
            points[i] = quadrangle.points[i].ToApiStruct();
        }
        return new Quadrangle(points);
    }

    internal static MediaVision.Quadrangle ToMarshalable(this Quadrangle quadrangle)
    {
        MediaVision.Point[] points = new MediaVision.Point[4];
        for (int i = 0; i < 4; ++i)
        {
            points[i] = quadrangle.Points[i].ToMarshalable();
        }
        return new MediaVision.Quadrangle() { points = points };
    }

    internal static Tizen.Multimedia.Rectangle ToApiStruct(this MediaVision.Rectangle rectangle)
    {
        return new Tizen.Multimedia.Rectangle(rectangle.x, rectangle.y, rectangle.width, rectangle.height);
    }

    internal static MediaVision.Rectangle ToMarshalable(this Tizen.Multimedia.Rectangle rectangle)
    {
        return new MediaVision.Rectangle()
        {
            x = rectangle.X,
            y = rectangle.Y,
            width = rectangle.Width,
            height = rectangle.Height
        };
    }

    internal static Tizen.Multimedia.Rectangle[] ToApiStruct(this MediaVision.Rectangle[] rects)
    {
        var result = new Tizen.Multimedia.Rectangle[rects.Length];

        for (int i = 0; i < rects.Length; i++)
        {
            result[i] = rects[i].ToApiStruct();
        }
        return result;
    }

    internal static MediaVision.Rectangle[] ToMarShalable(this Tizen.Multimedia.Rectangle[] rects)
    {
        var result = new MediaVision.Rectangle[rects.Length];

        for (int i = 0; i < rects.Length; i++)
        {
            result[i] = rects[i].ToMarshalable();
        }
        return result;
    }

    /// <summary>
    /// Interop for Media Vision APIs.
    /// </summary>
    internal static partial class MediaVision
    {
        [NativeStruct("mv_point_s", Include="mv_common.h", PkgConfig="capi-media-vision")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct Point
        {
            internal int x;
            internal int y;
        }

        [NativeStruct("mv_rectangle_s", Include="mv_common.h", PkgConfig="capi-media-vision")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct Rectangle
        {
            internal int x;
            internal int y;
            internal int width;
            internal int height;
        }

        [NativeStruct("mv_quadrangle_s", Include="mv_common.h", PkgConfig="capi-media-vision")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct Quadrangle
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            internal Point[] points;
        }

        /// <summary>
        /// Interop for Media Vision Source APIs.
        /// </summary>
        internal static partial class MediaSource
        {
            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_create_source")]
            internal static partial MediaVisionError Create(out IntPtr source);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_destroy_source")]
            internal static partial int Destroy(IntPtr /* mv_source_h */ source);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_fill_by_media_packet")]
            internal static partial MediaVisionError FillMediaPacket(IntPtr source, IntPtr mediaPacket);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_fill_by_buffer")]
            internal static partial MediaVisionError FillBuffer(IntPtr source, byte[] buffer,
                int bufferSize, uint imageWidth, uint imageHeight, VisionColorSpace colorspace);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_clear")]
            internal static partial int Clear(IntPtr /* mv_source_h */ source);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_get_buffer")]
            internal static partial MediaVisionError GetBuffer(IntPtr source, out IntPtr buffer, out int bufferSize);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_get_height")]
            internal static partial int GetHeight(IntPtr source, out uint imageHeight);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_get_width")]
            internal static partial int GetWidth(IntPtr source, out uint imageWidth);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_get_colorspace")]
            internal static partial int GetColorspace(IntPtr /* mv_source_h */ source, out VisionColorSpace colorspace);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_set_timestamp")]
            internal static partial int SetTimestamp(IntPtr source, ulong timestamp);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_source_get_timestamp")]
            internal static partial int GetTimestamp(IntPtr source, out ulong timestamp);
        }

        /// <summary>
        /// Interop for Engine Configuration APIs.
        /// </summary>
        internal static partial class EngineConfig
        {
            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_create_engine_config")]
            internal static partial MediaVisionError Create(out IntPtr handle);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_destroy_engine_config")]
            internal static partial int Destroy(IntPtr handle);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_set_double_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError SetDouble(IntPtr handle, string name, double value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_set_int_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError SetInt(IntPtr handle, string name, int value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_set_bool_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError SetBool(IntPtr handle, string name, [MarshalAs(UnmanagedType.U1)] bool value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_set_string_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError SetString(IntPtr handle, string name, string value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_set_array_string_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError SetStringArray(IntPtr handle, string name,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] string[] value, int size);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_get_double_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetDouble(IntPtr handle, string name, out double value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_get_int_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetInt(IntPtr handle, string name, out int value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_get_bool_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetBool(IntPtr handle, string name, [MarshalAs(UnmanagedType.U1)] out bool value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_get_string_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetString(IntPtr handle, string name, out IntPtr value);

            [LibraryImport(Libraries.MediaVisionCommon, EntryPoint = "mv_engine_config_get_array_string_attribute", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetStringArray(IntPtr handle, string name,
                out IntPtr value, out int size);
        }
    }
}

