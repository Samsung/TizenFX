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
using System.ComponentModel;
using Tizen.MachineLearning.Inference;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class TFVowel6 : ISingleShotModel
    {
        private SingleShot singleShot;
        private TensorsInfo inputInfo;
        private TensorsInfo outputInfo;
        private TensorsData inputData;
        private TensorsData outputData;
                
        internal TFVowel6(int[] inputDimension, int[] outputDimension, string modelPath)
        {
            try
            {
                inputInfo = new TensorsInfo();
                inputInfo.AddTensorInfo(TensorType.Float32, inputDimension);

                outputInfo = new TensorsInfo();
                outputInfo.AddTensorInfo(TensorType.Float32, outputDimension);

                singleShot = new SingleShot(modelPath, inputInfo, outputInfo);
            }
            catch (Exception e)
            {
                if (e is NotSupportedException)
                {
                    Log.Info(LogTag, "NotSupportedException occurs");
                }
                else
                {
                    Log.Info(LogTag, e.Message);
                }
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTensorData(int index, byte[] buffer)
        {
            try
            {
                inputData = inputInfo.GetTensorsData();
                inputData.SetTensorData(index, buffer);
            }
            catch (Exception e)
            {
                Log.Info(LogTag, e.Message);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Invoke()
        {
            try
            {
                outputData = singleShot.Invoke(inputData);
            }
            catch (Exception e)
            {
                Log.Info(LogTag, e.Message);
            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] GetTensorData(int index)
        {
            return outputData.GetTensorData(index);
        }


    }
}
