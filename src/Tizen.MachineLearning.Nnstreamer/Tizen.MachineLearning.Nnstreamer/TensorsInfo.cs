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
using System.Collections.Generic;
using Log = Tizen.Log;

namespace Tizen.MachineLearning.Nnstreamer
{
    public class TensorsInfo
    {
        private List<TensorInfo> _infoList;

        public TensorsInfo()
        {
            Log.Info(NNStreamer.TAG, "TensorsInfo()");
            _infoList = new List<TensorInfo>();
        }

        public void AddTensorInfo(TensorType type, int[] dimension)
        {
            AddTensorInfo(null, type, dimension);
        }

        public void AddTensorInfo(string name, TensorType type, int[] dimension)
        {
            int idx = _infoList.Count;
            if (idx >= Tensor.SizeLimit) {
                throw new IndexOutOfRangeException("Max size of the tensors is " + Tensor.SizeLimit);
            }
            _infoList.Add(new TensorInfo(name, type, dimension));
        }

        public void SetTensorName(int idx, string name)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].Name = name;
        }

        public string GetTensorName(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Name;
        }

        public void SetType(int idx, TensorType type)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].Type = type;
        }

        public TensorType GetType(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Type;
        }

        public void SetDimension(int idx, int[] dimension)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].SetDimension(dimension);
        }

        public int[] GetDimension(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Dimension;
        }

        public TensorsData GetTensorsData()
        {
            IntPtr tensorInfo_h;
            IntPtr tensorsData_h;
            TensorsData retTensorData;
            NNStreamerError ret = NNStreamerError.None;

            /* Create TensorsInfo object */
            ret = Interop.Util.CreateTensorsInfo(out tensorInfo_h);
            if (ret != NNStreamerError.None)
            {
                Log.Error(NNStreamer.TAG, "unable to create the TensorsInfo");
                throw NNStreamerExceptionFactory.CreateException(ret, "unable to create the TensorsInfo");
            }

            /* Set the number of tensors */
            ret = Interop.Util.SetTensorsCount(tensorInfo_h, _infoList.Count);
            NNStreamer.CheckException(ret, "unable to set the number of tensors");
            
            int idx = 0;
            foreach (TensorInfo t in _infoList)
            {
                /* Set the type of tensor */
                ret = Interop.Util.SetTensorsType(tensorInfo_h, idx, t.Type);
                NNStreamer.CheckException(ret, "unable to set the type of tensors: " + idx.ToString());

                ret = Interop.Util.SetTensorsDimension(tensorInfo_h, idx, t.Dimension);
                NNStreamer.CheckException(ret, "unable to set the dimension of tensors: " + idx.ToString());

                idx += 1;
            }

            /* Create TensorsData object */
            ret = Interop.Util.CreateTensorsData(tensorInfo_h, out tensorsData_h);
            NNStreamer.CheckException(ret, "unable to create the tensorsData object");
            retTensorData = new TensorsData(tensorsData_h);

            /* Destroy TensorsInfo object */
            ret = Interop.Util.DestroyTensorsInfo(tensorInfo_h);
            if (ret != NNStreamerError.None)
            {
                Log.Error(NNStreamer.TAG, "unable to destroy the TensorsInfo");
                throw NNStreamerExceptionFactory.CreateException(ret, "unable to destroy the TensorsInfo");
            }

            return retTensorData;
        }

        private void CheckIndexBoundary(int idx)
        {
            if (idx < 0 || idx >= _infoList.Count) {
                throw new IndexOutOfRangeException("Invalid index [" + idx + "] of the tensors");
            }
        }

        private class TensorInfo
        {
            public TensorInfo(TensorType type, int[] dimension)
            {
                Type = type;
                SetDimension(dimension);
            }

            public TensorInfo(string name, TensorType type, int[] dimension)
            {
                Name = name;
                Type = type;
                SetDimension(dimension);
            }

            public void SetDimension(int[] dimension)
            {
                if (dimension == null) {
                    throw new ArgumentException("Max size of the tensor rank is" + Tensor.RankLimit);
                }

                if (dimension.Length > Tensor.RankLimit) {
                    throw new ArgumentException("Max size of the tensor rank is" + Tensor.RankLimit);
                }
                Dimension = (int[])dimension.Clone();
            }

            public string Name { get; set; } = null;

            public TensorType Type { get; set; } = TensorType.Unknown;

            public int[] Dimension { get; private set; } = new int[Tensor.RankLimit];
        }
    }
}
