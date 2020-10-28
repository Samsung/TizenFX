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
    /// Provides the ability to recognize person on image sources.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <seealso cref="PersonRecognitionConfiguration"/>
    /// <since_tizen> 4 </since_tizen>
    public class PersonRecognizer : SurveillanceEngine
    {
        private const string KeyCount = "NUMBER_OF_PERSONS";
        private const string KeyLocations = "PERSONS_LOCATIONS";
        private const string KeyLabels = "PERSONS_LABELS";
        private const string KeyConfidences = "PERSONS_CONFIDENCES";

        private const string PersonRecognizedEventType = "MV_SURVEILLANCE_EVENT_PERSON_RECOGNIZED";

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRecognizer"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public PersonRecognizer() : base(PersonRecognizedEventType)
        {

        }

        /// <summary>
        /// Occurs when a person recognized.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <seealso cref="PersonRecognitionConfiguration.FaceRecognitionModelPath"/>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PersonRecognizedEventArgs> Recognized;

        private void RegisterEvent()
        {
            _eventDetectedCallback = (IntPtr trigger, IntPtr source, int streamId, IntPtr result, IntPtr _) =>
            {
                Recognized?.Invoke(this, CreatePersonRecognizedEventArgs(result));
            };
        }

        private PersonRecognizedEventArgs CreatePersonRecognizedEventArgs(IntPtr result)
        {
            int count;

            GetResultValue(result, KeyCount, out count).Validate("Failed to get result count");

            var recognitionInfo = new PersonRecognitionInfo[count];

            if (count > 0)
            {
                var rects = new global::Interop.MediaVision.Rectangle[count];
                GetResultValue(result, KeyLocations, rects).Validate("Failed to get location");

                var labels = new int[count];
                GetResultValue(result, KeyLabels, labels).Validate("Failed to get label");

                var confidences = new double[count];
                GetResultValue(result, KeyConfidences, confidences).Validate("Failed to get confidence");

                for (int i = 0; i < count; i++)
                {
                    recognitionInfo[i] = new PersonRecognitionInfo(rects[i].ToApiStruct(),
                        labels[i], confidences[i]);
                }
            }

            return new PersonRecognizedEventArgs(recognitionInfo);
        }

        /// <summary>
        /// Adds <see cref="SurveillanceSource"/> with the provided <see cref="PersonRecognitionConfiguration"/>.
        /// </summary>
        /// <param name="source">The source used for recognition.</param>
        /// <param name="config">The config for the <paramref name="source"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> is null.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="PersonRecognizer"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <see cref="PersonRecognitionConfiguration.FaceRecognitionModelPath"/> of <paramref name="config"/> does not exists.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// No permission to access to the <see cref="PersonRecognitionConfiguration.FaceRecognitionModelPath"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">The model file is not supported format or file.</exception>
        /// <see cref="SurveillanceSource.Push(MediaVisionSource)"/>
        /// <since_tizen> 4 </since_tizen>
        public void AddSource(SurveillanceSource source, PersonRecognitionConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            RegisterEvent();
            InvokeAddSource(source, config);
        }
    }
}
