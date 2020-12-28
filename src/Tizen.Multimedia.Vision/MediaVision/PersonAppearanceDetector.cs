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
    /// Provides the ability to detect person appearance changes on image sources.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <seealso cref="PersonAppearanceDetectionConfiguration"/>
    /// <since_tizen> 4 </since_tizen>
    public class PersonAppearanceDetector : SurveillanceEngine
    {
        private const string KeyAppearedNumber = "NUMBER_OF_APPEARED_PERSONS";
        private const string KeyDisappearedNumber = "NUMBER_OF_DISAPPEARED_PERSONS";
        private const string KeyTrackedNumber = "NUMBER_OF_TRACKED_PERSONS";
        private const string KeyAppearedLocations = "APPEARED_PERSONS_LOCATIONS";
        private const string KeyDisappearedLocations = "DISAPPEARED_PERSONS_LOCATIONS";
        private const string KeyTrackedLocations = "TRACKED_PERSONS_LOCATIONS";

        private const string PersonAppearanceEventType = "MV_SURVEILLANCE_EVENT_PERSON_APPEARED_DISAPEARED";

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonAppearanceDetector"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PersonAppearanceDetector() : base(PersonAppearanceEventType)
        {
        }

        /// <summary>
        /// Occurs when the any appearance changes detected.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PersonAppearanceDetectedEventArgs> Detected;

        private void RegisterEvent()
        {
            _eventDetectedCallback = (IntPtr trigger, IntPtr source, int streamId, IntPtr result, IntPtr _) =>
            {
                Detected?.Invoke(this, CreatePersonAppearanceChangedEventArgs(result));
            };
        }


        private PersonAppearanceDetectedEventArgs CreatePersonAppearanceChangedEventArgs(IntPtr result)
        {
            return new PersonAppearanceDetectedEventArgs(
                GetResultAreas(result, KeyAppearedNumber, KeyAppearedLocations),
                GetResultAreas(result, KeyDisappearedNumber, KeyDisappearedLocations),
                GetResultAreas(result, KeyTrackedNumber, KeyTrackedLocations)
                );
        }

        private static Rectangle[] GetResultAreas(IntPtr result, string countKey, string regionsKey)
        {
            int count = 0;
            GetResultValue(result, countKey, out count).Validate("Failed to get result");

            var rects = new global::Interop.MediaVision.Rectangle[count];
            if (count > 0)
            {
                GetResultValue(result, regionsKey, rects).Validate("Failed to get result");
            }

            return global::Interop.ToApiStruct(rects);
        }

        /// <summary>
        /// Adds <see cref="SurveillanceSource"/>.
        /// </summary>
        /// <param name="source">The source used for recognition.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="PersonAppearanceDetector"/> has already been disposed of.</exception>
        /// <see cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public void AddSource(SurveillanceSource source)
        {
            AddSource(source, null);
        }

        /// <summary>
        /// Adds <see cref="SurveillanceSource"/> with the provided <see cref="PersonAppearanceDetectionConfiguration"/>.
        /// </summary>
        /// <param name="source">The source used for recognition.</param>
        /// <param name="config">The config for the <paramref name="source"/>. This value can be null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="PersonAppearanceDetector"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <see cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public void AddSource(SurveillanceSource source, PersonAppearanceDetectionConfiguration config)
        {
            RegisterEvent();
            InvokeAddSource(source, config);
        }
    }
}
