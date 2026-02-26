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
using Tizen.Multimedia.Vision;

/// <summary>
/// Interop APIs.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Media Vision APIs.
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for Barcode Detector APIs.
        /// </summary>
        internal static partial class BarcodeDetector
        {
            [LibraryImport(Libraries.MediaVisionBarcodeDetector, EntryPoint = "mv_barcode_detect", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Detect(IntPtr source, IntPtr engineCfg, Rectangle roi,
                DetectedCallback detectCb, IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DetectedCallback(
                IntPtr source,
                IntPtr engineCfg,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
                Quadrangle[] locations,
                [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 5)]
                string[] messages,
                BarcodeType[] types,
                int numberOfBarcodes,
                IntPtr userData);
        }

        /// <summary>
        /// Interop for Barcode Generator APIs.
        /// </summary>
        internal static partial class BarcodeGenerator
        {
            [LibraryImport(Libraries.MediaVisionBarcodeGenerator, EntryPoint = "mv_barcode_generate_source", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GenerateSource(IntPtr engineCfg, string message,
                BarcodeType type, int qrEncMode, int qrEcc, int qrVersion, IntPtr source);

            [LibraryImport(Libraries.MediaVisionBarcodeGenerator, EntryPoint = "mv_barcode_generate_image", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GenerateImage(IntPtr engineCfg,
                string message, int imageWidth, int imageHeight, BarcodeType type,
                int qrEncMode, int qrEcc, int qrVersion, string imagePath, BarcodeImageFormat imageFormat);
        }
    }
}
