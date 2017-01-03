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

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class contains the Media Vision barcode generate API.\n
    /// These APIs can be used for generating the barcodes and QR codes.
    /// Different encoding types <see cref="QrMode"/> , error correction codes <see cref="ErrorCorrectionLevel"/>  and code versions are supported for QRCodes.
    /// </summary>
    public static class BarcodeGenerator
    {
        /// <summary>
        /// Generates <see cref="MediaVisionSource"/> with barcode image.
        /// </summary>
        /// <remarks>
        /// If the text attribute of engine configuration is set to <see cref="TextAttribute.Visible"/> , InvalidOperationException will be thrown when type is <see cref="BarcodeType.QR"/>
        /// </remarks>
        /// <param name="config">The configuration of the bar code generator engine</param>
        /// <param name="message">The message to be encoded in the barcode</param>
        /// <param name="type">Type of the barcode to be generated</param>
        /// <param name="qrConfig">The QrConfig object - required for QR codes only</param>
        /// <returns>
        /// <param name="source">The media vision source object which will be used to fill by the buffer with generated image</param>
        /// </returns>
        /// <code>
        /// 
        /// </code>
        public static MediaVisionSource GenerateSource(BarcodeGeneratorEngineConfiguration config, string message, BarcodeType type, QrConfiguration qrConfig = null)
        {
            if (string.IsNullOrEmpty(message) ||
                type == BarcodeType.Undefined ||
                (type == BarcodeType.QR &&
                (qrConfig == null ||
                qrConfig.ErrorCorrectionLevel == ErrorCorrectionLevel.Unavailable ||
                qrConfig.Mode == QrMode.Unavailable ||
                qrConfig.Version < 1 ||
                qrConfig.Version > 40)))
            {
                throw new ArgumentException("Invalid parameter");
            }

            MediaVisionSource source = new MediaVisionSource();
            int ret = (type == BarcodeType.QR) ?
                        Interop.MediaVision.BarCodeGenerator.GenerateSource(config._engineHandle, message, type, qrConfig.Mode, qrConfig.ErrorCorrectionLevel, qrConfig.Version, source._sourceHandle) :
                        Interop.MediaVision.BarCodeGenerator.GenerateSource(config._engineHandle, message, type, QrMode.Unavailable, ErrorCorrectionLevel.Unavailable, 0, source._sourceHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to generate source");
            return source;
        }

        /// <summary>
        /// Generates image file with barcode.
        /// </summary>
        /// <remarks>
        /// If the text attribute of engine configuration is set to <see cref="TextAttribute.Visible"/> ,
        /// InvalidOperationException will be thrown when type is <see cref="BarcodeType.QR"/>\n
        /// </remarks>
        /// <param name="config">The configuration of the bar code generator engine</param>
        /// <param name="message">The message to be encoded in the barcode</param>
        /// <param name="type">Type of the barcode to be generated</param>
        /// <param name="imageConfig">The BarcodeImageConfig object that contains information about the file to be generated</param>
        /// <param name="qrConfig">The QrConfig object - required for QR codes only</param>
        /// <code>
        /// 
        /// </code>
        public static void GenerateImage(BarcodeGeneratorEngineConfiguration config, string message, BarcodeType type, BarcodeImageConfiguration imageConfig, QrConfiguration qrConfig = null)
        {
            if (string.IsNullOrEmpty(message) ||
                imageConfig == null ||
                string.IsNullOrEmpty(imageConfig.Path) ||
                type == BarcodeType.Undefined ||
                (type == BarcodeType.QR &&
                (qrConfig == null ||
                qrConfig.ErrorCorrectionLevel == ErrorCorrectionLevel.Unavailable ||
                qrConfig.Mode == QrMode.Unavailable ||
                qrConfig.Version < 1 ||
                qrConfig.Version > 40)))
            {
                throw new ArgumentException("Invalid parameter");
            }

            int ret = (type == BarcodeType.QR) ?
                        Interop.MediaVision.BarCodeGenerator.GenerateImage(config._engineHandle,
                                                                            message,
                                                                            imageConfig.Width,
                                                                            imageConfig.Height,
                                                                            type,
                                                                            qrConfig.Mode,
                                                                            qrConfig.ErrorCorrectionLevel,
                                                                            qrConfig.Version,
                                                                            imageConfig.Path,
                                                                            imageConfig.Format) :
                        Interop.MediaVision.BarCodeGenerator.GenerateImage(config._engineHandle,
                                                                            message,
                                                                            imageConfig.Width,
                                                                            imageConfig.Height,
                                                                            type,
                                                                            QrMode.Unavailable,
                                                                            ErrorCorrectionLevel.Unavailable,
                                                                            0,
                                                                            imageConfig.Path,
                                                                            imageConfig.Format);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to generate image");
        }
    }
}
