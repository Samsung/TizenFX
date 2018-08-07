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
    /// Provides the ability to detect movement on image sources.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <seealso cref="MovementDetectionConfiguration"/>
    /// <since_tizen> 4 </since_tizen>
    public class MovementDetector : SurveillanceEngine
    {
        private const string KeyNumberOfRegions = "NUMBER_OF_MOVEMENT_REGIONS";
        private const string KeyRegions = "MOVEMENT_REGIONS";

        private const string MovementDetectedEventType = "MV_SURVEILLANCE_EVENT_MOVEMENT_DETECTED";

        /// <summary>
        /// Initializes a new instance of the <see cref="MovementDetector"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MovementDetector() : base(MovementDetectedEventType)
        {
        }

        /// <summary>
        /// Occurs when the movement detected.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<MovementDetectedEventArgs> Detected;

        private void RegisterEvent()
        {
            _eventDetectedCallback = (IntPtr trigger, IntPtr source, int streamId, IntPtr result, IntPtr _) =>
            {
                Detected?.Invoke(this, CreateMovementDetectedEventArgs(result));
            };
        }

        private static Rectangle[] RetrieveAreas(IntPtr result)
        {
            int count = 0;
            GetResultValue(result, KeyNumberOfRegions, out count).Validate("Failed to get result count");

            if (count == 0)
            {
                return new Rectangle[0];
            }

            var rects = new global::Interop.MediaVision.Rectangle[count];

            GetResultValue(result, KeyRegions, rects).Validate("Failed to get regions");

            return global::Interop.ToApiStruct(rects);
        }

        private static MovementDetectedEventArgs CreateMovementDetectedEventArgs(IntPtr result)
        {
            return new MovementDetectedEventArgs(RetrieveAreas(result));
        }


        /// <summary>
        /// Adds <see cref="SurveillanceSource"/>.
        /// </summary>
        /// <param name="source">The source used for recognition.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MovementDetector"/> has already been disposed of.</exception>
        /// <see cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public void AddSource(SurveillanceSource source)
        {
            AddSource(source, null);
        }

        /// <summary>
        /// Adds <see cref="SurveillanceSource"/> with the provided <see cref="MovementDetectionConfiguration"/>.
        /// </summary>
        /// <param name="source">The source used for recognition.</param>
        /// <param name="config">The config for the <paramref name="source"/>. This value can be null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="MovementDetector"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <see cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public void AddSource(SurveillanceSource source, MovementDetectionConfiguration config)
        {
            RegisterEvent();
            InvokeAddSource(source, config);
        }

    }
}
