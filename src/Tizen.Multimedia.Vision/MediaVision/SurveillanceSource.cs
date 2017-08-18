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
using static Interop.MediaVision.Surveillance;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to push source to surveillance engines.
    /// </summary>
    /// <seealso cref="MovementDetector"/>
    /// <seealso cref="PersonAppearanceDetector"/>
    /// <seealso cref="PersonRecognizer"/>
    /// <since_tizen> 3</since_tizen>
    public class SurveillanceSource
    {
        private static int _nextStreamId = int.MinValue;

        private static int GetNextStreamId()
        {
            if (_nextStreamId == int.MaxValue)
            {
                return _nextStreamId = int.MinValue;
            }
            return _nextStreamId++;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveillanceSource"/> class.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public SurveillanceSource()
        {
            StreamId = GetNextStreamId();
        }

        /// <summary>
        /// Pushes source to the surveillance system to detect events.
        /// </summary>
        /// <param name="source">The media source used for surveillance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">This <see cref="SurveillanceSource"/> has not been added yet.</exception>
        /// <seealso cref="MovementDetector.AddSource(SurveillanceSource)"/>
        /// <seealso cref="MovementDetector.AddSource(SurveillanceSource, MovementDetectionConfiguration)"/>
        /// <seealso cref="PersonAppearanceDetector.AddSource(SurveillanceSource)"/>
        /// <seealso cref="PersonAppearanceDetector.AddSource(SurveillanceSource, PersonAppearanceDetectionConfiguration)"/>
        /// <seealso cref="PersonRecognizer.AddSource(SurveillanceSource, PersonRecognitionConfiguration)"/>
        /// <since_tizen> 3</since_tizen>
        public void Push(MediaVisionSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            PushSource(source.Handle, StreamId).Validate("Failed to push source");
        }

        internal int StreamId { get; }
    }
}
