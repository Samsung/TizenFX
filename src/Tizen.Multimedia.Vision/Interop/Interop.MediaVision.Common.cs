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

    internal static Tizen.Multimedia.Rectangle[] ToApiStruct(MediaVision.Rectangle[] rects)
    {
        var result = new Tizen.Multimedia.Rectangle[rects.Length];

        for (int i = 0; i < rects.Length; i++)
        {
            result[i] = rects[i].ToApiStruct();
        }
        return result;
    }

    /// <summary>
    /// Interop for Media Vision APIs.
    /// </summary>
    internal static partial class MediaVision
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Point
        {
            internal int x;
            internal int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Rectangle
        {
            internal int x;
            internal int y;
            internal int width;
            internal int height;
        }

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
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_create_source")]
            internal static extern MediaVisionError Create(out IntPtr source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_destroy_source")]
            internal static extern int Destroy(IntPtr /* mv_source_h */ source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_fill_by_media_packet")]
            internal static extern MediaVisionError FillMediaPacket(IntPtr source, IntPtr mediaPacket);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_fill_by_buffer")]
            internal static extern MediaVisionError FillBuffer(IntPtr source, byte[] buffer,
                int bufferSize, uint imageWidth, uint imageHeight, VisionColorSpace colorspace);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_clear")]
            internal static extern int Clear(IntPtr /* mv_source_h */ source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_buffer")]
            internal static extern MediaVisionError GetBuffer(IntPtr source, out IntPtr buffer, out int bufferSize);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_height")]
            internal static extern int GetHeight(IntPtr source, out uint imageHeight);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_width")]
            internal static extern int GetWidth(IntPtr source, out uint imageWidth);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_colorspace")]
            internal static extern int GetColorspace(IntPtr /* mv_source_h */ source, out VisionColorSpace colorspace);
        }

        /// <summary>
        /// Interop for Engine Configuration APIs.
        /// </summary>
        internal static partial class EngineConfig
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_create_engine_config")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_destroy_engine_config")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_double_attribute")]
            internal static extern MediaVisionError SetDouble(IntPtr handle, string name, double value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_int_attribute")]
            internal static extern MediaVisionError SetInt(IntPtr handle, string name, int value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_bool_attribute")]
            internal static extern MediaVisionError SetBool(IntPtr handle, string name, bool value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_string_attribute")]
            internal static extern MediaVisionError SetString(IntPtr handle, string name, string value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_array_string_attribute")]
            internal static extern MediaVisionError SetStringArray(IntPtr handle, string name,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] string[] value, int size);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_double_attribute")]
            internal static extern MediaVisionError GetDouble(IntPtr handle, string name, out double value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_int_attribute")]
            internal static extern MediaVisionError GetInt(IntPtr handle, string name, out int value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_bool_attribute")]
            internal static extern MediaVisionError GetBool(IntPtr handle, string name, out bool value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_string_attribute")]
            internal static extern MediaVisionError GetString(IntPtr handle, string name, out IntPtr value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_array_string_attribute")]
            internal static extern MediaVisionError GetStringArray(IntPtr handle, string name,
                out IntPtr value, out int size);
        }
    }
}
