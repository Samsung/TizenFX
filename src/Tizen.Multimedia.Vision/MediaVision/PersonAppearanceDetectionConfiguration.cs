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
    /// Represents a configuration of <see cref="PersonAppearanceDetector"/> instances.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <since_tizen> 4 </since_tizen>
    public class PersonAppearanceDetectionConfiguration : SurveillanceEngineConfiguration
    {
        private const string KeySkipFramesCount = "MV_SURVEILLANCE_SKIP_FRAMES_COUNT";

        /// <summary>
        /// A read-only field that represents the default value of <see cref="SkipFramesCount"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int DefaultSkipFramesCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAppearanceDetectionConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PersonAppearanceDetectionConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets how many frames will be skipped during push source.<br/>
        /// </summary>
        /// <value>
        /// The value to specify the number of <see cref="MediaVisionSource"/> calls will be ignored by subscription
        /// of the event trigger.<br/>
        ///
        /// The default is 0. It means that no frames will be skipped and all <see cref="MediaVisionSource"/> will
        /// be processed.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="PersonAppearanceDetectionConfiguration"/> already has been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <seealso cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public int SkipFramesCount
        {
            get
            {
                return GetInt(KeySkipFramesCount);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(SkipFramesCount), value,
                        $"{nameof(SkipFramesCount)} can't be less than zero.");
                }
                Set(KeySkipFramesCount, value);
            }
        }
    }
}
