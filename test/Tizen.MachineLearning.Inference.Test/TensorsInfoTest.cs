/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.IO;
using Tizen.MachineLearning.Inference;

namespace Tizen.MachineLearning.Inference.Test
{
    public static class TensorsInfoTest
    {
        const string TAG = "Nnstreamer";

        public static bool BasicTensorTest_Success00()
        {
            int[] in_dim = new int[4] { 3, 224, 224, 1 };

            TensorsInfo tensorsInfo = new TensorsInfo();
            tensorsInfo.AddTensorInfo(TensorType.UInt8, in_dim);

            /* Check */
            if (tensorsInfo.GetTensorType(0) != TensorType.UInt8)
                return false;

            int[] in_res = tensorsInfo.GetDimension(0);
            for (int i = 0; i < 4; ++i)
            {
                if (in_dim[i] != in_res[i])
                    return false;
            }
            return true;
        }
        public static bool BasicTensorTest_Success01()
        {
            TensorsInfo tensorsInfo;
            TensorsData tensorsData;
            int[] in_dim = new int[4] { 10, 1, 1, 1 };
            byte[] buffer_in = new byte[] { 17, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            byte[] buffer_out;

            tensorsInfo = new TensorsInfo();
            tensorsInfo.AddTensorInfo(TensorType.UInt8, in_dim);
            Log.Info(TAG, "Current Count: " + tensorsInfo.Count);

            tensorsData = tensorsInfo.GetTensorsData();
            tensorsData.SetTensorData(0, buffer_in);

            buffer_out = tensorsData.GetTensorData(0);

            if (buffer_in.Length != buffer_out.Length)
            {
                Log.Error(TAG, "The size of buffers is different");
                return false;
            }

            for (int i = 0; i < buffer_in.Length; ++i)
            {
                if (buffer_in[i] != buffer_out[i])
                {
                    Log.Error(TAG, "The value of " + i.ToString() + " th element is different");
                    return false;
                }
            }

            return true;
        }

        public static bool BasicTensorTest_Success02()
        {
            TensorsInfo tensorsInfo;
            TensorsData tensorsData;
            int[] in_dim = new int[4] { 10, 1, 1, 1 };
            byte[] buffer_in = new byte[] { 17, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            byte[] buffer_out;

            tensorsInfo = new TensorsInfo();
            tensorsInfo.AddTensorInfo(TensorType.UInt8, in_dim);

            tensorsData = tensorsInfo.GetTensorsData();
            tensorsData.SetTensorData(0, buffer_in);
            buffer_out = tensorsData.GetTensorData(0);

            if (buffer_in.Length != buffer_out.Length)
            {
                Log.Error(TAG, "The size of buffers is different");
                return false;
            }

            for (int i = 0; i < buffer_in.Length; ++i)
            {
                if (buffer_in[i] != buffer_out[i])
                {
                    Log.Error(TAG, "The value of " + i.ToString() + " th element is different");
                    return false;
                }
            }
            tensorsData.Dispose();

            /* Add new tensor */
            int[] in2_dim = new int[4] { 5, 1, 1, 1 };
            byte[] buffer_in2 = new byte[] { 10, 20, 30, 40, 50 };
            byte[] buffer_out2;


            tensorsInfo.AddTensorInfo(TensorType.UInt8, in2_dim);

            tensorsData = tensorsInfo.GetTensorsData();
            tensorsData.SetTensorData(0, buffer_in);
            buffer_out = tensorsData.GetTensorData(0);
            tensorsData.SetTensorData(1, buffer_in2);
            buffer_out2 = tensorsData.GetTensorData(1);

            if (buffer_in2.Length != buffer_out2.Length)
            {
                Log.Error(TAG, "The size of buffers is different");
                return false;
            }

            for (int i = 0; i < buffer_in2.Length; ++i)
            {
                if (buffer_in2[i] != buffer_out2[i])
                {
                    Log.Error(TAG, "The value of " + i.ToString() + " th element is different");
                    return false;
                }
            }

            return true;
        }
    }
}
