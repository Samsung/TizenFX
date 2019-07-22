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

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The TensorsInfo class manages each Tensor information such as Name, Type and Dimension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TensorsInfo : IDisposable
    {
        private List<TensorInfo> _infoList;
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Get the number of Tensor information which is added.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Count => _infoList.Count;

        /// <summary>
        /// Creates a TensorsInfo instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public TensorsInfo()
        {
            Log.Info(NNStreamer.TAG, "TensorsInfo is created");
            _infoList = new List<TensorInfo>();
        }

        /// <summary>
        /// Destroys the TensorsInfo resource.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~TensorsInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Add a Tensor information to the TensorsInfo instance. Note that we support up to 16 tensors in TensorsInfo.
        /// </summary>
        /// <param name="type">Data element type of Tensor.</param>
        /// <param name="dimension">Dimension of Tensor. Note that we support up to 4th ranks.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the number of Tensor already exceeds the size limits (i.e. Tensor.SlzeLimit)</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void AddTensorInfo(TensorType type, int[] dimension)
        {
            AddTensorInfo(null, type, dimension);
        }

        /// <summary>
        /// Add a Tensor information to the TensorsInfo instance. Note that we support up to 16 tensors in TensorsInfo.
        /// </summary>
        /// <param name="name">Name of Tensor.</param>
        /// <param name="type">Data element type of Tensor.</param>
        /// <param name="dimension">Dimension of Tensor. Note that we support up to 4th ranks.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the number of Tensor already exceeds the size limits (i.e. Tensor.SlzeLimit)</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void AddTensorInfo(string name, TensorType type, int[] dimension)
        {
            int idx = _infoList.Count;
            if (idx >= Tensor.SizeLimit) {
                throw new IndexOutOfRangeException("Max size of the tensors is " + Tensor.SizeLimit);
            }
            _infoList.Add(new TensorInfo(name, type, dimension));

            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;

                /* Set the number of tensors */
                ret = Interop.Util.SetTensorsCount(_handle, _infoList.Count);
                NNStreamer.CheckException(ret, "unable to set the number of tensors");

                /* Set the type and dimension of Tensor */
                ret = Interop.Util.SetTensorType(_handle, idx, type);
                NNStreamer.CheckException(ret, "fail to set TensorsInfo type");

                ret = Interop.Util.SetTensorDimension(_handle, idx, dimension);
                NNStreamer.CheckException(ret, "fail to set TensorsInfo dimension");
            }
        }

        /// <summary>
        /// Sets the tensor name with given index.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="name">The tensor name to be set.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorName(int idx, string name)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].Name = name;

            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.Util.SetTensorName(_handle, idx, name);
                NNStreamer.CheckException(ret, "unable to set the name of tensor: " + idx.ToString());
            }
        }

        /// <summary>
        /// Gets the tensor name with given index.
        /// </summary>
        /// <param name="idx">The index of the tensor.</param>
        /// <returns>The tensor name.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string GetTensorName(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Name;
        }

        /// <summary>
        /// Sets the tensor type with given index and its type.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="type">The tensor type to be set.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorType(int idx, TensorType type)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].Type = type;

            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.Util.SetTensorType(_handle, idx, type);
                NNStreamer.CheckException(ret, "unable to set the type of tensor: " + idx.ToString());
            }
        }

        /// <summary>
        /// Gets the tensor type with given index.
        /// </summary>
        /// <param name="idx">The index of the tensor.</param>
        /// <returns>The tensor type</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorType GetTensorType(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Type;
        }

        /// <summary>
        /// Sets the tensor dimension with given index and dimension.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="dimension">The tensor dimension to be set.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetDimension(int idx, int[] dimension)
        {
            CheckIndexBoundary(idx);
            _infoList[idx].SetDimension(dimension);

            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.Util.SetTensorDimension(_handle, idx, dimension);
                NNStreamer.CheckException(ret, "unable to set the dimension of tensor: " + idx.ToString());
            }
        }

        /// <summary>
        /// Gets the tensor dimension with given index.
        /// </summary>
        /// <param name="idx">The index of the tensor.</param>
        /// <returns>The tensor dimension.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is greater than the number of Tensor.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 6 </since_tizen>
        public int[] GetDimension(int idx)
        {
            CheckIndexBoundary(idx);
            return _infoList[idx].Dimension;
        }

        /// <summary>
        /// Creates a TensorsData instance based on informations of TensorsInfo
        /// </summary>
        /// <returns>TensorsData instance</returns>
        /// <exception cref="ArgumentException">Thrown when the method failed due to TensorsInfo's information is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorsData GetTensorsData()
        {
            IntPtr tensorsData_h;
            TensorsData retTensorData;
            NNStreamerError ret = NNStreamerError.None;

            if (_handle == IntPtr.Zero)
            {
                Log.Info(NNStreamer.TAG, "_handle is IntPtr.Zero\n" + "  GetTensorsInfoHandle() is called");
                GetTensorsInfoHandle();
            }

            ret = Interop.Util.CreateTensorsData(_handle, out tensorsData_h);
            NNStreamer.CheckException(ret, "unable to create the tensorsData object");
            Log.Info(NNStreamer.TAG, "success to CreateTensorsData()\n");

            retTensorData = TensorsData.CreateFromNativeHandle(tensorsData_h);

            return retTensorData;
        }

        internal IntPtr GetTensorsInfoHandle()
        {
            NNStreamerError ret = NNStreamerError.None;
            IntPtr ret_handle;
            int idx;

            /* Already created */
            if (_handle != IntPtr.Zero)
                return _handle;

            /* Check required parameters */
            int num = _infoList.Count;
            if (num <= 0 || num > Tensor.SizeLimit)
                ret = NNStreamerError.InvalidParameter;
            NNStreamer.CheckException(ret, "number of Tensor in TensorsInfo is invalid: " + _infoList.Count);

            /* Create TensorsInfo object */
            ret = Interop.Util.CreateTensorsInfo(out ret_handle);
            NNStreamer.CheckException(ret, "fail to create TensorsInfo object");

            /* Set the number of tensors */
            ret = Interop.Util.SetTensorsCount(ret_handle, _infoList.Count);
            NNStreamer.CheckException(ret, "unable to set the number of tensors");

            /* Set each Tensor info */
            idx = 0;
            foreach (TensorInfo t in _infoList)
            {
                ret = Interop.Util.SetTensorType(ret_handle, idx, t.Type);
                NNStreamer.CheckException(ret, "fail to set the type of tensor" + idx.ToString());

                ret = Interop.Util.SetTensorDimension(ret_handle, idx, t.Dimension);
                NNStreamer.CheckException(ret, "fail to set the dimension of tensor: " + idx.ToString());

                idx += 1;
            }

            _handle = ret_handle;
            return ret_handle;
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // release managed objects
                _infoList.Clear();
            }

            // release unmanaged objects
            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.Util.DestroyTensorsInfo(_handle);
                if (ret != NNStreamerError.None)
                {
                    Log.Error(NNStreamer.TAG, "failed to destroy TensorsInfo object");
                }
            }
            _disposed = true;
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

            public TensorType Type { get; set; } = TensorType.Int32;

            public int[] Dimension { get; private set; } = new int[Tensor.RankLimit];
        }
    }
}
