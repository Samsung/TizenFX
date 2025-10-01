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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The EmotionAnimator class extends SerialAnimator and provides functionality to play animations based on emotions.
    /// It manages emotion configurations, generates expression data animations, and loads necessary resources.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EmotionAnimator : SerialAnimator
    {

        private EmotionConfig EmotionConfigData;
        private Dictionary<string, List<MotionData>> expressionDataByCategory;
        private Dictionary<string, List<uint>> expressionIdByCategory;

        /// <summary>
        /// Plays a random animation from the specified emotion category.
        /// If the emotion is not found, plays a random animation from the "normal" category.
        /// </summary>
        /// <param name="emotion">The emotion category to play.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play(string emotion)
        {
            if (expressionIdByCategory.TryGetValue(emotion.ToLowerInvariant(), out List<uint> expressionList))
            {
                int randomIndex = new Random().Next(0, expressionList.Count);
                base.Play(expressionList[randomIndex]);
            }
            else if (expressionIdByCategory.TryGetValue("normal", out List<uint> normalList))
            {
                int randomIndex = new Random().Next(0, normalList.Count);
                base.Play(normalList[randomIndex]);
            }
        }

        /// <summary>
        /// Generates expression data animations for the given model.
        /// Throws exceptions if the model is null or its resources are not ready.
        /// </summary>
        /// <param name="model">The model to generate animations for.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GenerateExpressionDataAnimation(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!model.IsResourceReady())
            {
                throw new InvalidOperationException("The model resource is not ready.");
            }

            expressionIdByCategory = new Dictionary<string, List<uint>>();

            foreach (var category in expressionDataByCategory)
            {
                int categoryCount = 0;

                if (!expressionIdByCategory.ContainsKey(category.Key))
                {
                    expressionIdByCategory[category.Key] = new List<uint>();
                }

                foreach (var motionData in category.Value)
                {
                    var animation = model.GenerateMotionDataAnimation(motionData);
                    string key = $"{category.Key}_{categoryCount}";
                    uint animationId = (uint)Add(animation, key);
                    expressionIdByCategory[category.Key].Add(animationId);
                    categoryCount++;
                }
            }
        }

        /// <summary>
        /// Loads the emotion configuration data from the specified JSON file and expression data from the given resource path.
        /// Throws exceptions if there are errors reading the files or if the paths are invalid.
        /// </summary>
        /// <param name="configPath">The path to the emotion configuration JSON file.</param>
        /// <param name="expressionResourcePath">The path to the directory containing expression resource files.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadEmotionConfig(in string configPath, in string expressionResourcePath)
        {
            try
            {
                string json = File.ReadAllText(configPath);
                EmotionConfigData = JsonSerializer.Deserialize<EmotionConfig>(json);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error loading Emotion Config data from {configPath}: {ex}");
            }

            LoadExpressionData(expressionResourcePath);

        }

        /// <summary>
        /// Loads expression data from the specified resource path.
        /// Throws exceptions if the resource path is null or empty, or if any expression files are missing.
        /// </summary>
        /// <param name="expressionResourcePath">The path to the directory containing expression resource files.</param>
        private void LoadExpressionData(string expressionResourcePath)
        {

            if (string.IsNullOrEmpty(expressionResourcePath))
            {
                throw new ArgumentException("expressionResourcePath cannot be null or empty.", nameof(expressionResourcePath));
            }


            expressionDataByCategory = new Dictionary<string, List<MotionData>>();

            foreach (Expression expression in EmotionConfigData.expressions)
            {
                if (!expressionDataByCategory.ContainsKey(expression.name))
                {
                    expressionDataByCategory[expression.name] = new List<MotionData>();
                }

                foreach (string filename in expression.filename)
                {
                    string expressionFile = global::System.IO.Path.Combine(expressionResourcePath, filename);

                    if (!File.Exists(expressionFile))
                    {
                        throw new FileNotFoundException($"Expression file not found: {expressionFile}", expressionFile);
                    }

                    string expressionJson = File.ReadAllText(expressionFile);

                    FaceAnimationData expressionFaceAnimationData = JsonSerializer.Deserialize<FaceAnimationData>(expressionJson);
                    MotionData expressionFaceMotionData = AnimationLoader.Instance.CreateFacialMotionData(expressionFaceAnimationData, EmotionConfigData.ignoreBlendShapes);
                    expressionDataByCategory[expression.name].Add(expressionFaceMotionData);
                }

            }
        }
    }
}
