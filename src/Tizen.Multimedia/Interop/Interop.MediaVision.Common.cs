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

/// <summary>
/// Interop APIs
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for media vision APIs
    /// </summary>
    internal static partial class MediaVision
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Point
        {
            internal int x;
            internal int y;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct Rectangle
        {
            internal int x;
            internal int y;
            internal int width;
            internal int height;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct Quadrangle
        {
            internal int x1, y1;
            internal int x2, y2;
            internal int x3, y3;
            internal int x4, y4;
        };

        /// <summary>
        /// Interop for media vision source APIs
        /// </summary>
        internal static partial class MediaSource
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_create_source")]
            internal static extern int Create(out IntPtr /* mv_source_h */ source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_destroy_source")]
            internal static extern int Destroy(IntPtr /* mv_source_h */ source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_fill_by_media_packet")]
            internal static extern int FillMediaPacket(IntPtr /* mv_source_h */ source, IntPtr /* media_packet_h */ mediaPacket);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_fill_by_buffer")]
            internal static extern int FillBuffer(IntPtr /* mv_source_h */ source, byte[] buffer, int bufferSize, uint imageWidth, uint imageHeight, Tizen.Multimedia.Colorspace colorspace);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_clear")]
            internal static extern int Clear(IntPtr /* mv_source_h */ source);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_buffer")]
            internal static extern int GetBuffer(IntPtr /* mv_source_h */ source, out IntPtr buffer, out int bufferSize);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_height")]
            internal static extern int GetHeight(IntPtr /* mv_source_h */ source, out uint imageHeight);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_width")]
            internal static extern int GetWidth(IntPtr /* mv_source_h */ source, out uint imageWidth);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_source_get_colorspace")]
            internal static extern int GetColorspace(IntPtr /* mv_source_h */ source, out Tizen.Multimedia.Colorspace colorspace);
        }

        /// <summary>
        /// Interop for engine configuration APIs
        /// </summary>
        internal static partial class EngineConfig
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_create_engine_config")]
            internal static extern int Create(out IntPtr /* mv_engine_config_h */ engineConfig);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_destroy_engine_config")]
            internal static extern int Destroy(IntPtr /* mv_engine_config_h */ engineConfig);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_double_attribute")]
            internal static extern int SetDouble(IntPtr /* mv_engine_config_h */ source, string name, double value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_int_attribute")]
            internal static extern int SetInt(IntPtr /* mv_engine_config_h */ source, string name, int value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_bool_attribute")]
            internal static extern int SetBool(IntPtr /* mv_engine_config_h */ source, string name, bool value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_set_string_attribute")]
            internal static extern int SetString(IntPtr /* mv_engine_config_h */ source, string name, string value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_double_attribute")]
            internal static extern int GetDouble(IntPtr /* mv_engine_config_h */ source, string name, out double value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_int_attribute")]
            internal static extern int GetInt(IntPtr /* mv_engine_config_h */ source, string name, out int value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_bool_attribute")]
            internal static extern int GetBool(IntPtr /* mv_engine_config_h */ source, string name, out bool value);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_engine_config_get_string_attribute")]
            internal static extern int GetString(IntPtr /* mv_engine_config_h */ source, string name, out string value);
        }
    }
}
