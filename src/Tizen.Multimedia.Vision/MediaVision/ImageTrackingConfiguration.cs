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
    /// Represents a configuration of <see cref="ImageTracker"/>.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <since_tizen> 3 </since_tizen>
    public class ImageTrackingConfiguration : ImageRecognitionConfiguration
    {
        private const string KeyHistoryAmount = "MV_IMAGE_TRACKING_HISTORY_AMOUNT";
        private const string KeyExpectedOffset = "MV_IMAGE_TRACKING_EXPECTED_OFFSET";
        private const string KeyUseStabilization = "MV_IMAGE_TRACKING_USE_STABLIZATION";
        private const string KeyStabilizationTolerantShift = "MV_IMAGE_TRACKING_STABLIZATION_TOLERANT_SHIFT";
        private const string KeyStabilizationSpeed = "MV_IMAGE_TRACKING_STABLIZATION_SPEED";
        private const string KeyStabilizationAcceleration = "MV_IMAGE_TRACKING_STABLIZATION_ACCELERATION";

        /// <summary>
        /// A read-only field that represents the default value of <see cref="HistoryAmount"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DefaultHistoryAmount = 3;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="ExpectedOffset"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultExpectedOffset = 0;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="IsStabilizationEnabled"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly bool DefaultStabilizationEnabled = true;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="StabilizationTolerantShift"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultStabilizationTolerantShift = 0.00006;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="StabilizationSpeed"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultStabilizationSpeed = 0.3;

        /// <summary>
        /// A read-only field that represents the default value of <see cref="StabilizationAcceleration"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly double DefaultStabilizationAcceleration = 0.1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTrackingConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public ImageTrackingConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the number of recognition results in the tracking history.
        /// </summary>
        /// <value>
        /// The number of previous recognition results, which will influence the stabilization.<br/>
        /// The default is 3.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int HistoryAmount
        {
            get
            {
                return GetInt(KeyHistoryAmount);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(HistoryAmount), value,
                        $"{nameof(HistoryAmount)} can't be less than zero.");
                }
                Set(KeyHistoryAmount, value);
            }
        }

        /// <summary>
        /// Gets or sets the expected tracking offset.
        /// </summary>
        /// <value>
        /// Relative offset value for which the object offset is expected (relative to the object size in the current frame).<br/>
        /// The default is 0.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public double ExpectedOffset
        {
            get
            {
                return GetDouble(KeyExpectedOffset);
            }
            set
            {
                Set(KeyExpectedOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the acceleration of the tracking stabilization.
        /// </summary>
        /// <value>
        /// Acceleration will be used for image stabilization (relative to the distance from current location to stabilized location);
        /// from 0 to 1, inclusive.<br/>
        /// The default is 0.1.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="value"/> is greater than one.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public double StabilizationAcceleration
        {
            get
            {
                return GetDouble(KeyStabilizationAcceleration);
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Valid range is 0 to 1 inclusive.");
                }

                Set(KeyStabilizationAcceleration, value);
            }
        }

        /// <summary>
        /// Gets or sets the speed of the tracking stabilization.
        /// </summary>
        /// <value>
        /// The start speed value used for image stabilization.<br/>
        /// The default is 0.3.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public double StabilizationSpeed
        {
            get
            {
                return GetDouble(KeyStabilizationSpeed);
            }
            set
            {
                Set(KeyStabilizationSpeed, value);
            }
        }

        /// <summary>
        /// Gets or sets the relative tolerant shift for the tracking stabilization.
        /// </summary>
        /// <value>
        /// It is component of tolerant shift which will be ignored by stabilization process.
        /// (this value is relative to the object size in the current frame).
        /// Tolerant shift will be computed like R * S + C, where R is the value set to <see cref="StabilizationTolerantShift"/>,
        /// S is the area of object location on frame, C is a constant value 1.3.<br/>
        /// <br/>
        /// The default is 0.00006.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public double StabilizationTolerantShift
        {
            get
            {
                return GetDouble(KeyStabilizationTolerantShift);
            }
            set
            {
                Set(KeyStabilizationTolerantShift, value);
            }
        }

        /// <summary>
        /// Gets or sets the state of the contour stabilization during tracking process.
        /// </summary>
        /// <value>
        /// true if the contour stabilization is enabled; otherwise false.<br/>
        /// The default is true.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingConfiguration"/> already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IsStabilizationEnabled
        {
            get
            {
                return GetBool(KeyUseStabilization);
            }
            set
            {
                Set(KeyUseStabilization, value);
            }
        }
    }
}
