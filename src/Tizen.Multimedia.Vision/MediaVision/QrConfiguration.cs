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
    /// <since_tizen> 3 </since_tizen>
    public class QrConfiguration
    {
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public QrMode Mode { get; }

        /// <summary>
        /// Gets the error correction level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ErrorCorrectionLevel ErrorCorrectionLevel { get; }

        /// <summary>
        /// Gets the QR code version.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Version { get; }
    }
}
