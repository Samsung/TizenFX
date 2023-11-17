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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a QR configuration of <see cref="BarcodeGenerator"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class QrConfiguration
    {
        private string _embedImagePath;
        private QrShape _dataShape = QrShape.Rectangular;
        private QrShape _finderShape = QrShape.Rectangular;

        /// <summary>
        /// Initializes a new instance of the <see cref="QrConfiguration"/> class.
        /// </summary>
        /// <param name="qrMode">Encoding mode for the message.</param>
        /// <param name="ecc">Error correction level.</param>
        /// <param name="version">QR code version. From 1 to 40 inclusive.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="version"/> is less than 1.<br/>
        ///     -or-<br/>
        ///     <paramref name="version"/> is greater than 40.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="qrMode"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="ecc"/> is invalid.
        /// </exception>
        /// <example>
        /// <code>
        /// var qrConfig = new QrConfiguration(QrMode.Numeric, ErrorCorrectionLevel.Medium, 30);
        /// </code>
        /// </example>
        /// <since_tizen> 4 </since_tizen>
        public QrConfiguration(QrMode qrMode, ErrorCorrectionLevel ecc, int version)
        {
            if (version < 1 || version > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(version), version,
                    "Valid version range is 1 to 40 inclusive.");
            }
            ValidationUtil.ValidateEnum(typeof(QrMode), qrMode, nameof(qrMode));
            ValidationUtil.ValidateEnum(typeof(ErrorCorrectionLevel), ecc, nameof(ecc));

            Mode = qrMode;
            ErrorCorrectionLevel = ecc;
            Version = version;
        }

        /// <summary>
        /// Gets the encoding mode for the message.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public QrMode Mode { get; }

        /// <summary>
        /// Gets the error correction level.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ErrorCorrectionLevel ErrorCorrectionLevel { get; }

        /// <summary>
        /// Gets the QR code version.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Version { get; }

        /// <summary>
        /// Gets or sets the embed image absolute path of the Design QR code.
        /// </summary>
        /// <remarks>
        /// The mediastorage privilege (http://tizen.org/privilege/mediastorage) is needed if the image path is relevant to media storage.<br/>
        /// The externalstorage privilege (http://tizen.org/privilege/externalstorage) is needed if the image path is relevant to external storage.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is zero-length string.</exception>
        /// <since_tizen> 11 </since_tizen>
        public string EmbedImagePath
        {
            get
            {
                return _embedImagePath;
            }
            set
            {
                ValidationUtil.ValidateIsNullOrEmpty(value, nameof(value));

                _embedImagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the data shape of the Design QR code.
        /// </summary>
        /// <remarks>The default value is <see cref="QrShape.Rectangular"/>.</remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 11 </since_tizen>
        public QrShape DataShape
        {
            get
            {
                return _dataShape;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(QrShape), value, nameof(value));

                _dataShape = value;
            }
        }

        /// <summary>
        /// Gets or sets the finder shape of the Design QR code.
        /// </summary>
        /// <remarks>The default value is <see cref="QrShape.Rectangular"/>.</remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 11 </since_tizen>
        public QrShape FinderShape
        {
            get
            {
                return _finderShape;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(QrShape), value, nameof(value));

                _finderShape = value;
            }
        }
    }
}
