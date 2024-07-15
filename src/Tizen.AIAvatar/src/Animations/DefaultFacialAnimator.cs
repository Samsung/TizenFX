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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using Tizen.NUI;
using Tizen.NUI.Scene3D;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class FaceAnimBlendShape
    {
        public string name { get; set; }
        public string fullName { get; set; }
        public string blendShapeVersion { get; set; }
        public int morphtarget { get; set; }
        public List<string> morphname { get; set; }
        public List<List<float>> key { get; set; }
    }

    internal class FaceAnimationData
    {
        public string name { get; set; }
        public string version { get; set; }
        public List<FaceAnimBlendShape> blendShapes { get; set; }
        public int shapesAmount { get; set; }
        public List<int> time { get; set; }
        public int frames { get; set; }
    }

    internal class Expression
    {
        public string name { get; set; }
        public List<string> filename { get; set; }
    }

    internal class IgnoreBlendShape
    {
        public string name { get; set; }
        public List<string> morphname { get; set; }
    }

    internal class EmotionConfig
    {
        public List<Expression> expressions { get; set; }
        public List<IgnoreBlendShape> ignoreBlendShapes { get; set; }
    }


    internal class DefaultFacialAnimator
    {
        protected Animation FaceAnimation;
        protected EmotionConfig EmotionConfigData;
        protected List<FaceAnimationData> faceAnimationDataList;
        protected Dictionary<string, List<MotionData>> faceAnimationDataByCategory;


        private void LoadExpressionData(in string faceMotionResourcePath)
        {
            faceAnimationDataByCategory = new Dictionary<string, List<MotionData>>();

            foreach (Expression expression in EmotionConfigData.expressions)
            {
                if (!faceAnimationDataByCategory.ContainsKey(expression.name))
                {
                    faceAnimationDataByCategory[expression.name] = new List<MotionData>();
                }

                foreach (string filename in expression.filename)
                {
                    Log.Debug(LogTag, faceMotionResourcePath + "/" + filename);
                    string expressionFile = File.ReadAllText(faceMotionResourcePath + "/" + filename);
                    FaceAnimationData expressionFaceAnimationData = JsonConvert.DeserializeObject<FaceAnimationData>(expressionFile);
                    MotionData expressionFaceMotionData = CreateFacialMotionData(expressionFaceAnimationData);
                    faceAnimationDataByCategory[expression.name].Add(expressionFaceMotionData);
                }

            }
        }

        public void LoadEmotionConfig(in string faceMotionResourcePath, in string filePath)
        {
            try
            {
                string json = File.ReadAllText(faceMotionResourcePath + filePath);
                EmotionConfigData = JsonConvert.DeserializeObject<EmotionConfig>(json);

                LoadExpressionData(faceMotionResourcePath);

            }
            catch (JsonException ex)
            {
                Log.Error(LogTag, $"Error loading Emotion Config data from {filePath}: {ex}");
                throw new Exception($"Error loading Emotion Config data from {filePath}: {ex}");
            }
        }
                
        public int LoadMotionAnimations(in string faceMotionResourcePath)
        {            
            try
            {
                faceAnimationDataList = new List<FaceAnimationData>();
                var faceMotionAnimations = Directory.GetFiles(faceMotionResourcePath, "*.json");

                foreach (var path in faceMotionAnimations)
                {
                    try
                    {
                        string json = File.ReadAllText(path);
                        var faceAnimationData = JsonConvert.DeserializeObject<FaceAnimationData>(json);
                        faceAnimationDataList.Add(faceAnimationData);
                    }
                    catch (JsonException ex)
                    {
                        Log.Error(LogTag, $"Error loading face animation data from {path}: {ex}");
                        throw new Exception($"Error loading face animation data from {path}: {ex}");
                    }
                }

                return faceAnimationDataList.Count;
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

        public MotionData GetFacialMotionData(string emotion)
        {
            if (faceAnimationDataByCategory.TryGetValue(emotion.ToLower(), out List<MotionData> faceAnimationDataList))
            {
                int randomIndex = new Random().Next(0, faceAnimationDataList.Count);
                return faceAnimationDataList[randomIndex];
            }
            else
            {
                return null;
            }
        }

        public MotionData GetFacialMotionData(int index)
        {
            if (index < 0 || index >= faceAnimationDataList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            var faceAnimationData = faceAnimationDataList[index];
            MotionData facialMotionData = CreateFacialMotionData(faceAnimationData);

            return facialMotionData;
        }

        public void Start(Animation faceAnimation, bool looping = true, int loopCount = 0, float blendPoint = 0.1f)
        {
            if (faceAnimation == null)
            {
                throw new ArgumentNullException(nameof(faceAnimation), "FaceAnimation cannot be null.");
            }

            FaceAnimation = faceAnimation;

            FaceAnimation.Looping = looping;
            FaceAnimation.LoopCount = loopCount;
            FaceAnimation.BlendPoint = blendPoint;
            FaceAnimation?.Play();
        }

        public void Stop()
        {
            FaceAnimation?.Stop();
        }

        protected IgnoreBlendShape FindIgnoreBlendShapeByName(EmotionConfig emotionConfig, string name)
        {
            if (emotionConfig == null || emotionConfig.ignoreBlendShapes == null) return null;
            return emotionConfig.ignoreBlendShapes.FirstOrDefault(x => x.name == name);
        }

        protected bool ContainsMorphName(IgnoreBlendShape ignoreBlendShape, string morphName)
        {
            if (ignoreBlendShape == null || ignoreBlendShape.morphname == null) return false;
            return ignoreBlendShape.morphname.Contains(morphName);
        }

        protected MotionData CreateFacialMotionData(FaceAnimationData facialAnimation)
        {
            int frames = facialAnimation.frames;

            if (frames == 0) return null;

            int endTime = facialAnimation.time[frames - 1] + 200;
            MotionData motionData = new MotionData((int)(endTime * 1.5));

            foreach (var blendshape in facialAnimation.blendShapes)
            {
                //Log.Debug(LogTag, blendshape.name);

                PropertyKey modelNodeId = new PropertyKey(blendshape.name);
                IgnoreBlendShape ignoreBS = FindIgnoreBlendShapeByName(EmotionConfigData, blendshape.name);

                for (int target = 0; target < blendshape.morphtarget; target++)
                {

                    if (ContainsMorphName(ignoreBS, blendshape.morphname[target])) continue;                        

                    var keyFrames = new KeyFrames();
                    var blendshapeIndex = new BlendShapeIndex(modelNodeId, new PropertyKey(blendshape.morphname[target]));
                                        
                    for (int frame = 0; frame < frames; frame++)
                    {
                        keyFrames.Add((float)facialAnimation.time[frame] / endTime, blendshape.key[frame][target]);
                    }
                    
                    keyFrames.Add((float)(facialAnimation.time[frames - 1] + 200) / endTime, 0.0f);

                    motionData.Add(blendshapeIndex, new MotionValue(keyFrames));
                }
            }

            return motionData;
        }
    }
}
