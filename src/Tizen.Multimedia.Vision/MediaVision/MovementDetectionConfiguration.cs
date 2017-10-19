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
    /// Represents a configuration of <see cref="MovementDetector"/>.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MovementDetectionConfiguration : SurveillanceEngineConfiguration
    {
        private const string KeyThreshold = "MV_SURVEILLANCE_MOVEMENT_DETECTION_THRESHOLD";

        /// <summary>
        /// A read-only field that represents the default value of <see cref="Threshold"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DefaultThreshold = 10;


        /// <summary>
        /// Initializes a new instance of the <see cref="MovementDetectionConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public MovementDetectionConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets movement detection threshold.<br/>
        /// This value might be set before subscription on <see cref="MovementDetector.Detected"/> event
        /// to specify the sensitivity of the movement detector.
        /// </summary>
        /// <value>
        /// The value indicating the sensitivity of <see cref="MovementDetector"/> from 0 to 255 inclusive,
        /// where 255 means that no movements will be detected and 0 means that all frame changes
        /// will be interpreted as movements.<br/>
        /// The default is 10.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="MovementDetectionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="value"/> is greater than 255.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public int Threshold
        {
            get
            {
                return GetInt(KeyThreshold);
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(Threshold), value,
                        $"Valid {nameof(Threshold)} range is 0 to 255 inclusive");
                }

                Set(KeyThreshold, value);
            }
        }
    }
}
