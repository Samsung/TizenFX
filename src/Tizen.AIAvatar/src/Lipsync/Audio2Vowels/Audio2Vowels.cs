/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.AIAvatar
{
    /// <summary>
    /// The Audio2Vowels class is responsible for predicting vowels from audio data using a pre-trained TensorFlow model.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Audio2Vowels
    {
        /// <summary>
        /// The sample rate of the audio data.
        /// </summary>
        private int sampleRate;

        /// <summary>
        /// The pre-trained TensorFlow model used for vowel prediction.
        /// </summary>
        private TFVowel6 model;

        /// <summary>
        /// A dictionary containing vowel classifiers indexed by their respective sample rates.
        /// </summary>
        private Dictionary<int, VowelClassifier> classifiers;

        /// <summary>
        /// Initializes a new instance of the Audio2Vowels class with the specified TensorFlow model file path.
        /// </summary>
        /// <param name="tensorflowFilePath">The path to the pre-trained TensorFlow model file.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Audio2Vowels(string tensorflowFilePath)
        {
            classifiers = new Dictionary<int, VowelClassifier>();
            model = new TFVowel6(new int[4] { 12, 1, 1, 1 }, new int[4] { 7, 1, 1, 1 }, tensorflowFilePath);
        }

        /// <summary>
        /// Predicts the vowels present in the given audio data.
        /// </summary>
        /// <param name="audioData">The audio data to analyze.</param>
        /// <returns>An array of predicted vowels.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] PredictVowels(byte[] audioData)
        {
            VowelClassifier classifier = GetVowelClassifier(sampleRate);
            return classifier.Inference(audioData, model);
        }

        /// <summary>
        /// Sets the sample rate of the audio data.
        /// </summary>
        /// <param name="rate">The sample rate to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSampleRate(int rate)
        {
            sampleRate = rate;
        }

        /// <summary>
        /// Gets the current sample rate of the audio data.
        /// </summary>
        /// <returns>The current sample rate.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetSampleRate()
        {
            return sampleRate;
        }

        /// <summary>
        /// Retrieves the vowel classifier corresponding to the specified sample rate.
        /// If no classifier exists for the given sample rate, a new one is created.
        /// </summary>
        /// <param name="rate">The sample rate for which to retrieve the classifier.</param>
        /// <returns>A VowelClassifier object.</returns>
        private VowelClassifier GetVowelClassifier(int rate)
        {
            if (classifiers.ContainsKey(rate))
            {
                return classifiers[rate];
            }
            else
            {
                VowelClassifier classifier = new VowelClassifier(rate);
                classifiers[rate] = classifier;
                return classifier;
            }
        }
    }
}
