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
using Tizen.Multimedia;

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
        /// <summary>
        /// Interop for barcode detector APIs
        /// </summary>
        internal static partial class BarCodeDetector
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_barcode_detect")]
            internal static extern int Detect(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, Rectangle roi, MvBarcodeDetectedCallback detectCb, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvBarcodeDetectedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr barcodeLocations, IntPtr messages, IntPtr /* mv_barcode_type_e */ types, int numberOfBarcodes, IntPtr /* void */ userData);
        }

        /// <summary>
        /// Interop for barcode generator APIs
        /// </summary>
        internal static partial class BarCodeGenerator
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_barcode_generate_source")]
            internal static extern int GenerateSource(IntPtr /* mv_engine_config_h */ engineCfg, string message, BarcodeType /* mv_barcode_type_e */ type, QrMode /* mv_barcode_qr_mode_e */ qrEncMode, ErrorCorrectionLevel /* mv_barcode_qr_ecc_e */ qrEcc, int qrVersion, IntPtr /* mv_source_h */ image);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_barcode_generate_image")]
            internal static extern int GenerateImage(IntPtr /* mv_engine_config_h */ engineCfg, string message, int imageWidth, int imageHeight, BarcodeType /* mv_barcode_type_e */ type, QrMode /* mv_barcode_qr_mode_e */ qrEncMode, ErrorCorrectionLevel /* mv_barcode_qr_ecc_e */ qrEcc, int qrVersion, string imagePath, BarcodeImageFormat /* mv_barcode_image_format_e */ imageFormat);
        }
    }
}
