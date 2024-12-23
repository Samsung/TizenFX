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

namespace Tizen.NUI.AIAvatar
{

    internal class LipSyncTransformer
    {
        private LipData lipData;
        private VisemeData visemeData;
        private Dictionary<string, BlendShapeValue[]> visemeMap;

        private bool isInitialized;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipSyncTransformer() { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Initialize(string visemeDefinitionPath)
        {
            try
            {
                using (StreamReader v = new StreamReader(visemeDefinitionPath))
                {
                    var jsonString = v.ReadToEnd();

                    try
                    {
                        visemeData = JsonSerializer.Deserialize<VisemeData>(jsonString);
                        visemeMap = visemeData.GetVisemeMap();
                    }catch (JsonException e)
                    {
                        Log.Error("Tizen.AIAvatar", e.Message);
                    }
                }

                var nodeNames = visemeData.visemeParameters.nodeNames;
                var blendShapeCounts = visemeData.visemeParameters.blendShapeCount;
                var blendShapeKeyFormat = visemeData.visemeParameters.keyFormat;

                lipData = new LipData(nodeNames.ToArray(),
                                         blendShapeCounts.ToArray(),
                                         blendShapeKeyFormat);
                isInitialized = true;
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException($"File not found: {visemeDefinitionPath}", e);
            }
            catch (IOException e)
            {
                throw new IOException($"IO error occurred while reading file: {visemeDefinitionPath}", e);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LipData TransformVowelsToLipData(string[] vowels, float stepTime, bool isStreaming)
        {
            if (!isInitialized) throw new InvalidOperationException("LipSyncer is not initialized");

            lipData.Clear();
            VowelsToAnimationKeyFrame(vowels, stepTime, isStreaming);

            return lipData;
        }



        private void VowelsToAnimationKeyFrame(in string[] visemes, float stepTime, bool isStreaming)
        {
            int numVisemes = visemes.Length;
            float animationTime = 0f;

            if (isStreaming)
            {
                animationTime = (numVisemes-1) * stepTime;
            }
            else
            {
                animationTime = numVisemes * stepTime;
            }
                       

            lipData.SetDuration(animationTime);

            for (int i = 0; i < numVisemes; i++)
            {
                float timeStamp = GetTimeStamp(i, stepTime) / animationTime;

                foreach (var blendshape in visemeMap[visemes[i]])
                {
                    lipData.AddKeyFrame(blendshape.nodeName,
                                             blendshape.id,
                                              timeStamp,
                                              blendshape.value);
                }
            }
        }


        private float GetTimeStamp(int idx, float stepTime)
        {
            if (idx > 0)
                return (idx * stepTime) - (stepTime / 8.0f);
            else
               return (stepTime / 8.0f);
        }
    }
}