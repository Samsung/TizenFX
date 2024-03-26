using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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

        private readonly string modelPath = ApplicationResourcePath + "audio2vowel_7.tflite";

        internal TFVowel6(int[] inputDimension, int[] outputDimension)
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
