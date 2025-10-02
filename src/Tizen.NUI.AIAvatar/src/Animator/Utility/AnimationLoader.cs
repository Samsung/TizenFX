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
 */

using System.Collections.Generic;
using System.IO;
using System.Security;
using System;
using Tizen.NUI.Scene3D;
using Tizen.NUI;
using System.Text.Json;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The AnimationLoader class provides methods to load and manage body and face motion data from specified resources.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimationLoader
    {
        /// <summary>
        /// A singleton instance of the AnimationLoader class.
        /// </summary>
        private static readonly Lazy<AnimationLoader> instance = new Lazy<AnimationLoader>(() => new AnimationLoader());

        /// <summary>
        /// Gets the singleton instance of the AnimationLoader class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AnimationLoader Instance => instance.Value;


        /// <summary>
        /// Loads a single body motion from the specified resource path.
        /// </summary>
        /// <param name="resourcePath">The path to the body motion resource file.</param>
        /// <param name="useRootTranslationOnly">A boolean indicating whether to use only root translation.</param>
        /// <param name="scale">The scale factor to apply to the motion data.</param>
        /// <param name="synchronousLoad">A boolean indicating whether to load the data synchronously.</param>
        /// <returns>A MotionInfo object containing the loaded body motion data.</returns>
        /// <exception cref="Exception">Thrown if there is an error loading the body motion data.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionInfo LoadBodyMotion(in string resourcePath, bool useRootTranslationOnly, Vector3 scale = null, bool synchronousLoad = false)
        {
            try
            {
                string fileName = global::System.IO.Path.GetFileNameWithoutExtension(resourcePath);
                var bodyMotionData = new MotionData();
                bodyMotionData.LoadMotionCaptureAnimation(resourcePath, useRootTranslationOnly, scale, synchronousLoad);
                return new MotionInfo(bodyMotionData, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading body motion data from {resourcePath}: {ex}");
            }
        }

        /// <summary>
        /// Loads multiple body motions from the specified directory path.
        /// </summary>
        /// <param name="bodyMotionDirectoryPath">The path to the directory containing body motion resource files.</param>
        /// <param name="useRootTranslationOnly">A boolean indicating whether to use only root translation.</param>
        /// <param name="scale">The scale factor to apply to the motion data.</param>
        /// <param name="synchronousLoad">A boolean indicating whether to load the data synchronously.</param>
        /// <returns>A list of MotionInfo objects containing the loaded body motion data.</returns>
        /// <exception cref="Exception">Thrown if there is an error reading the body motion resource directory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<MotionInfo> LoadBodyMotions(in string bodyMotionDirectoryPath, bool useRootTranslationOnly, Vector3 scale = null, bool synchronousLoad = false)
        {
            try
            {
                var motionInfoList = new List<MotionInfo>();
                var bodyMotionAnimations = Directory.GetFiles(bodyMotionDirectoryPath, "*.bvh");

                foreach (var path in bodyMotionAnimations)
                {
                        motionInfoList.Add(LoadBodyMotion(path, useRootTranslationOnly, scale, synchronousLoad));
                }
                return motionInfoList;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"Body motion resource directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                throw new Exception($"Error reading body motion resource directory: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                throw new Exception($"Security error reading body motion resource directory: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads a single face motion from the specified resource path.
        /// </summary>
        /// <param name="resourcePath">The path to the face motion resource file.</param>
        /// <returns>A MotionInfo object containing the loaded face motion data.</returns>
        /// <exception cref="Exception">Thrown if there is an error loading the face animation data.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionInfo LoadFaceMotion(in string resourcePath)
        {
            try
            {
                string fileName = global::System.IO.Path.GetFileNameWithoutExtension(resourcePath);
                string json = File.ReadAllText(resourcePath);
                var faceAnimationData = JsonSerializer.Deserialize<FaceAnimationData>(json);
                var motionData = CreateFacialMotionData(faceAnimationData);
                return new MotionInfo(motionData, fileName);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error loading face animation data from {resourcePath}: {ex}");
            }
        }

        /// <summary>
        /// Loads multiple face motions from the specified directory path.
        /// </summary>
        /// <param name="faceMotionDirectoryPath">The path to the directory containing face motion resource files.</param>
        /// <returns>A list of MotionInfo objects containing the loaded face motion data.</returns>
        /// <exception cref="Exception">Thrown if there is an error reading the face motion resource directory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<MotionInfo> LoadFaceMotions(in string faceMotionDirectoryPath)
        {
            try
            {
                var motionInfoList = new List<MotionInfo>();
                var faceMotionAnimations = Directory.GetFiles(faceMotionDirectoryPath, "*.json");

                foreach (var path in faceMotionAnimations)
                {
                    motionInfoList.Add(LoadFaceMotion(path));
                }
                return motionInfoList;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"Face motion resource directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                throw new Exception($"Error reading face motion resource directory: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                throw new Exception($"Security error reading face motion resource directory: {ex.Message}");
            }
        }


        internal MotionData CreateFacialMotionData(FaceAnimationData facialAnimation, List<IgnoreBlendShape> ignoreBlendShapes = null)
        {

            int frames = facialAnimation.frames;

            if (frames == 0) return null;

            int endTime = facialAnimation.time[frames - 1] + 200;
            MotionData motionData = new MotionData((int)(endTime * 1.5));


            foreach (var blendshape in facialAnimation.blendShapes)
            {
                using var modelNodeID = new PropertyKey(blendshape.name);
                IgnoreBlendShape ignoreBS = ignoreBlendShapes?.FirstOrDefault(x => x.name == blendshape.name);


                for (int target = 0; target < blendshape.morphtarget; target++)
                {
                    if (ignoreBS != null && ignoreBS.morphname.Contains(blendshape.morphname[target])) continue;

                    using var keyFrames = new KeyFrames();
                    using var blendShapeID = new PropertyKey(blendshape.morphname[target]);
                    using var blendshapeIndex = new BlendShapeIndex(modelNodeID, blendShapeID);

                    for (int frame = 0; frame < frames; frame++)
                    {
                        keyFrames.Add((float)facialAnimation.time[frame] / endTime, blendshape.key[frame][target]);
                    }
                    keyFrames.Add((float)(facialAnimation.time[frames - 1] + 200) / endTime, 0.0f);

                    using var motionValue = new MotionValue(keyFrames);

                    motionData.Add(blendshapeIndex, motionValue);
                }
            }

            return motionData;
        }
    }
}
