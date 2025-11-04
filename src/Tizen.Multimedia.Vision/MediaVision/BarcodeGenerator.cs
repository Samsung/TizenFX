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
using InteropBarcode = Interop.MediaVision.BarcodeGenerator;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to generate barcodes and QR codes.
    /// Different encoding types <see cref="QrMode"/>, error correction codes <see cref="ErrorCorrectionLevel"/>,
    /// and code versions are supported for QRCodes.
    /// </summary>
    /// <seealso cref="BarcodeGenerationConfiguration"/>
    /// <since_tizen> 4 </since_tizen>
    public static class BarcodeGenerator
    {
        private const int NoneErrorCorrection = (int)ErrorCorrectionLevel.High + 1;
        private const int NoneQrMode = (int)QrMode.Utf8 + 1;

        private static void SetDesignQrOptions(QrConfiguration qrConfig, BarcodeGenerationConfiguration config)
        {
            if (config != null && qrConfig != null)
            {
                if (qrConfig.EmbedImagePath != null)
                {
                    config.EmbedImagePath = qrConfig.EmbedImagePath;
                }

                config.DataShape = qrConfig.DataShape;
                config.FinderShape = qrConfig.FinderShape;
            }
        }

        private static MediaVisionSource GenerateSource(BarcodeGenerationConfiguration config,
            string message, BarcodeType type, int qrMode, int qrEcc, int qrVersion)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            ValidationUtil.ValidateEnum(typeof(BarcodeType), type, nameof(type));

            MediaVisionSource source = new MediaVisionSource();
            try
            {
                InteropBarcode.GenerateSource(EngineConfiguration.GetHandle(config),
                    message, type, qrMode, qrEcc, qrVersion, source.Handle).
                    Validate("Failed to generate source");
                GC.KeepAlive(config);
            }
            catch (Exception)
            {
                source.Dispose();
                throw;
            }
            return source;
        }

        /// <summary>
        /// Generates a QR image with the specified message.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="qrConfig">The <see cref="QrConfiguration"/> instance.</param>
        /// <returns><see cref="MediaVisionSource"/> containing the generated QR image.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="qrConfig"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains characters which are illegal by the <see cref="QrMode"/>.
        ///     </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <seealso cref="QrMode"/>
        /// <since_tizen> 4 </since_tizen>
        public static MediaVisionSource GenerateSource(string message, QrConfiguration qrConfig)
        {
            return GenerateSource(message, qrConfig, null);
        }

        /// <summary>
        /// Generates a QR image with the specified message with <see cref="BarcodeGenerationConfiguration"/>.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="qrConfig">The <see cref="QrConfiguration"/> instance.</param>
        /// <param name="config">The configuration of the barcode generator. This value can be null.</param>
        /// <returns><see cref="MediaVisionSource"/> containing the generated QR image.</returns>
        /// <remarks>
        ///     <see cref="BarcodeGenerationConfiguration.TextVisibility"/> must be <see cref="Visibility.Invisible"/>,
        ///     because the text visibility is not supported in the QR code.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="qrConfig"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains characters which are illegal by the <see cref="QrMode"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.<br/>
        ///     -or-<br/>
        ///     <see cref="BarcodeGenerationConfiguration.TextVisibility"/> is the <see cref="Visibility.Visible"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException"><paramref name="config"/> already has been disposed of.</exception>
        /// <seealso cref="QrMode"/>
        /// <since_tizen> 4 </since_tizen>
        public static MediaVisionSource GenerateSource(string message, QrConfiguration qrConfig,
            BarcodeGenerationConfiguration config)
        {
            BarcodeGenerationConfiguration config_ = null;

            if (qrConfig == null)
            {
                throw new ArgumentNullException(nameof(qrConfig));
            }

            if (config != null)
            {
                if (config.TextVisibility == Visibility.Visible)
                {
                    throw new NotSupportedException("Text can't be visible in QR.");
                }
            }
            else
            {
                if (qrConfig.DataShape != QrShape.Rectangular || qrConfig.FinderShape != QrShape.Rectangular ||
                    qrConfig.EmbedImagePath != null)
                {
                    // Design QR case. The config_ for legacy QR will be null.
                    config_ = new BarcodeGenerationConfiguration();
                }
            }

            SetDesignQrOptions(qrConfig, config ?? config_);

            var mediaVisionSource = GenerateSource(config ?? config_, message, BarcodeType.QR, (int)qrConfig.Mode,
                (int)qrConfig.ErrorCorrectionLevel, qrConfig.Version);
            config_?.Dispose();

            return mediaVisionSource;
        }

        /// <summary>
        /// Generates a barcode image with the specified message.
        /// </summary>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="type">Type of the barcode to be generated.</param>
        /// <returns><see cref="MediaVisionSource"/> containing the generated barcode image.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is <see cref="BarcodeType.QR"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains illegal characters.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static MediaVisionSource GenerateSource(string message, BarcodeType type)
        {
            return GenerateSource(message, type, null);
        }

        /// <summary>
        /// Generates a barcode image with the specified message and <see cref="BarcodeGenerationConfiguration"/>.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="type">Type of the barcode to be generated.</param>
        /// <param name="config">The configuration of the barcode generator. This value can be null.</param>
        /// <returns><see cref="MediaVisionSource"/> containing the generated barcode image.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is <see cref="BarcodeType.QR"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains illegal characters.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="config"/> already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static MediaVisionSource GenerateSource(string message, BarcodeType type,
            BarcodeGenerationConfiguration config)
        {
            if (type == BarcodeType.QR)
            {
                throw new ArgumentException($"Invalid barcode type : {type}.");
            }

            return GenerateSource(config, message, type, NoneQrMode, NoneErrorCorrection, 0);
        }

        private static void GenerateImage(BarcodeGenerationConfiguration config,
            string message, BarcodeType type, BarcodeImageConfiguration imageConfig,
            int qrMode, int qrEcc, int qrVersion)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (imageConfig == null)
            {
                throw new ArgumentNullException(nameof(imageConfig));
            }

            ValidationUtil.ValidateEnum(typeof(BarcodeType), type, nameof(type));

            try
            {
                InteropBarcode.GenerateImage(EngineConfiguration.GetHandle(config), message,
                    imageConfig.Width, imageConfig.Height, type, qrMode, qrEcc, qrVersion,
                    imageConfig.Path, imageConfig.Format).
                    Validate("Failed to generate image");
                GC.KeepAlive(config)
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Generates a QR image file with the specified message.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <remarks>
        ///     <see cref="BarcodeGenerationConfiguration.TextVisibility"/> must be <see cref="Visibility.Invisible"/>,
        ///     because the text visibility is not supported in the QR code.
        /// </remarks>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="qrConfig">The <see cref="QrConfiguration"/> instance.</param>
        /// <param name="imageConfig">The <see cref="BarcodeImageConfiguration"/> that contains information about the file to be generated.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="message"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="qrConfig"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="imageConfig"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains characters which are illegal by the <see cref="QrMode"/>.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access a file.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <seealso cref="QrMode"/>
        /// <since_tizen> 4 </since_tizen>
        public static void GenerateImage(string message, QrConfiguration qrConfig,
            BarcodeImageConfiguration imageConfig)
        {
            GenerateImage(message, qrConfig, imageConfig, null);
        }

        /// <summary>
        /// Generates a QR image file with the specified message and <see cref="BarcodeGenerationConfiguration"/>.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <remarks>
        ///     <see cref="BarcodeGenerationConfiguration.TextVisibility"/> must be <see cref="Visibility.Invisible"/>,
        ///     because the text visibility is not supported in the QR code.
        /// </remarks>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="qrConfig">The <see cref="QrConfiguration"/> instance.</param>
        /// <param name="imageConfig">The <see cref="BarcodeImageConfiguration"/> that contains
        ///     information about the file to be generated.</param>
        /// <param name="config">The configuration of the barcode generator. This value can be null.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="message"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="qrConfig"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="imageConfig"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains characters which are illegal by the <see cref="QrMode"/>.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access a file.</exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.<br/>
        ///     -or-<br/>
        ///     <see cref="BarcodeGenerationConfiguration.TextVisibility"/> is the <see cref="Visibility.Visible"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException"><paramref name="config"/> already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void GenerateImage(string message, QrConfiguration qrConfig,
            BarcodeImageConfiguration imageConfig, BarcodeGenerationConfiguration config)
        {
            BarcodeGenerationConfiguration config_ = null;

            if (qrConfig == null)
            {
                throw new ArgumentNullException(nameof(qrConfig));
            }

            if (config != null)
            {
                if (config.TextVisibility == Visibility.Visible)
                {
                    throw new NotSupportedException("Text can't be visible in QR.");
                }
            }
            else
            {
                if (qrConfig.DataShape != QrShape.Rectangular || qrConfig.FinderShape != QrShape.Rectangular ||
                    qrConfig.EmbedImagePath != null)
                {
                    // Design QR case. The config_ for legacy QR will be null.
                    config_ = new BarcodeGenerationConfiguration();
                }
            }

            SetDesignQrOptions(qrConfig, config ?? config_);

            GenerateImage(config ?? config_, message, BarcodeType.QR, imageConfig, (int)qrConfig.Mode,
                (int)qrConfig.ErrorCorrectionLevel, qrConfig.Version);
            config_?.Dispose();
        }

        /// <summary>
        /// Generates a barcode image file with the specified message.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="type">Type of the barcode to be generated.</param>
        /// <param name="imageConfig">The <see cref="BarcodeImageConfiguration"/> that contains
        ///     information about the file to be generated.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="message"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="imageConfig"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is <see cref="BarcodeType.QR"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains illegal characters.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access a file.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void GenerateImage(string message, BarcodeType type, BarcodeImageConfiguration imageConfig)
        {
            GenerateImage(message, type, imageConfig, null);
        }

        /// <summary>
        /// Generates a barcode image file with the specified message and <see cref="BarcodeGenerationConfiguration"/>.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.barcode_generation</feature>
        /// <param name="message">The message to be encoded in the barcode.</param>
        /// <param name="type">Type of the barcode to be generated.</param>
        /// <param name="imageConfig">The <see cref="BarcodeImageConfiguration"/> that contains
        ///     information about the file to be generated.</param>
        /// <param name="config">The configuration of the barcode generator. This value can be null.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="message"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="imageConfig"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="message"/> is too long.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is <see cref="BarcodeType.QR"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="type"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="message"/> contains illegal characters.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access a file.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="config"/> already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void GenerateImage(string message,
            BarcodeType type, BarcodeImageConfiguration imageConfig, BarcodeGenerationConfiguration config)
        {
            if (type == BarcodeType.QR)
            {
                throw new ArgumentException($"Invalid barcode type : {type}.");
            }
            GenerateImage(config, message, type, imageConfig, NoneQrMode, NoneErrorCorrection, 0);
        }
    }
}
