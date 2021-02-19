/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd. All Rights Reserved.
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
using System.Linq;
using System.Collections.Generic;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The TensorsInfo class manages each Tensor information such as Name, Type and Dimension.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TensorsInfo : IDisposable, IEquatable<TensorsInfo>
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
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorsInfo()
        {
            NNStreamer.CheckNNStreamerSupport();

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
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="IndexOutOfRangeException">Thrown when the number of Tensor already exceeds the size limits (i.e. Tensor.SizeLimit)</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void AddTensorInfo(TensorType type, int[] dimension)
        {
            NNStreamer.CheckNNStreamerSupport();

            AddTensorInfo(null, type, dimension);
        }

        /// <summary>
        /// Add a Tensor information to the TensorsInfo instance. Note that we support up to 16 tensors in TensorsInfo.
        /// </summary>
        /// <param name="name">Name of Tensor.</param>
        /// <param name="type">Data element type of Tensor.</param>
        /// <param name="dimension">Dimension of Tensor. Note that we support up to 4th ranks.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="IndexOutOfRangeException">Thrown when the number of Tensor already exceeds the size limits (i.e. Tensor.SizeLimit)</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void AddTensorInfo(string name, TensorType type, int[] dimension)
        {
            NNStreamer.CheckNNStreamerSupport();

            int idx = _infoList.Count;
            if (idx >= Tensor.SizeLimit) {
                throw new IndexOutOfRangeException("Max size of the tensors is " + Tensor.SizeLimit);
            }
            _infoList.Add(new TensorInfo(name, type, dimension));

            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;

                ret = Interop.Util.SetTensorsCount(_handle, _infoList.Count);
                NNStreamer.CheckException(ret, "Failed to set the number of tensors");

                UpdateInfoHandle(_handle, idx, name, type, dimension);
            }
        }

        /// <summary>
        /// Sets the tensor name with given index.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="name">The tensor name to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorName(int idx, string name)
        {
            NNStreamer.CheckNNStreamerSupport();

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
        /// <returns>The tensor name</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string GetTensorName(int idx)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndexBoundary(idx);
            return _infoList[idx].Name;
        }

        /// <summary>
        /// Sets the tensor type with given index and its type.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="type">The tensor type to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorType(int idx, TensorType type)
        {
            NNStreamer.CheckNNStreamerSupport();

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
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorType GetTensorType(int idx)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndexBoundary(idx);
            return _infoList[idx].Type;
        }

        /// <summary>
        /// Sets the tensor dimension with given index and dimension.
        /// </summary>
        /// <param name="idx">The index of the tensor to be updated.</param>
        /// <param name="dimension">The tensor dimension to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetDimension(int idx, int[] dimension)
        {
            NNStreamer.CheckNNStreamerSupport();

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
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public int[] GetDimension(int idx)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndexBoundary(idx);
            return _infoList[idx].Dimension;
        }

        /// <summary>
        /// Creates a TensorsData instance based on informations of TensorsInfo
        /// </summary>
        /// <returns>TensorsData instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to TensorsInfo's information is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorsData GetTensorsData()
        {
            IntPtr tensorsData_h = IntPtr.Zero;
            TensorsData retTensorData;
            NNStreamerError ret = NNStreamerError.None;

            NNStreamer.CheckNNStreamerSupport();

            if (_handle == IntPtr.Zero)
            {
                Log.Info(NNStreamer.TAG, "_handle is IntPtr.Zero\n" + "  GetTensorsInfoHandle() is called");
                GetTensorsInfoHandle();
            }

            ret = Interop.Util.CreateTensorsData(_handle, out tensorsData_h);
            NNStreamer.CheckException(ret, "Failed to create the TensorsData object");

            retTensorData = TensorsData.CreateFromNativeHandle(tensorsData_h, _handle, false);

            return retTensorData;
        }

        /// <summary>
        /// Calculates the byte size of tensor data.
        /// </summary>
        /// <param name="idx">The index of the tensor information in the list</param>
        /// <returns>The byte size of tensor</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public int GetTensorSize(int idx)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndexBoundary(idx);
            return _infoList[idx].Size;
        }

        /// <summary>
        /// Gets the the hash code of this TensorsInfo object
        /// </summary>
        /// <returns>The hash code</returns>
        /// <since_tizen> 8 </since_tizen>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (var info in _infoList)
                {
                    hash = hash * 31 + info.GetHashCode();
                }
                return hash;
            }
        }

        /// <summary>
        /// Compare TensorsInfo, which is its contents are the same or not.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if the given object is the same object or its contents are the same</returns>
        /// <since_tizen> 8 </since_tizen>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            TensorsInfo cInfo = obj as TensorsInfo;
            return this.Equals(cInfo);
        }

        /// <summary>
        /// Compare TensorsInfo, which is its contents are the same or not.
        /// </summary>
        /// <param name="other">TensorsInfo instance to compare</param>
        /// <returns>True if the given object is the same object or its contents are the same</returns>
        /// <since_tizen> 8 </since_tizen>
        public bool Equals(TensorsInfo other)
        {
            if (other == null)
                return false;

            if (this.Count != other.Count)
                return false;

            for (int i = 0; i < this.Count; ++i)
            {
                // Type
                if (this.GetTensorType(i) != other.GetTensorType(i))
                    return false;

                // Dimension
                if (!this.GetDimension(i).SequenceEqual(other.GetDimension(i)))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Create a new TensorsInfo object cloned from the current tensors information.
        /// </summary>
        /// <returns>Hard-copied TensorsInfo object</returns>
        /// <since_tizen> 9 </since_tizen>
        internal TensorsInfo Clone()
        {
            TensorsInfo retInfo = null;
            retInfo = new TensorsInfo();

            foreach (TensorInfo t in _infoList) {
                retInfo.AddTensorInfo(t.Name, t.Type, t.Dimension);
            }

            return retInfo;
        }

        /// <summary>
        /// Make TensorsInfo object from Native handle
        /// </summary>
        /// <param name="handle">Handle of TensorsInfo object</param>
        /// <returns>TensorsInfo object</returns>
        internal static TensorsInfo ConvertTensorsInfoFromHandle(IntPtr handle)
        {
            TensorsInfo retInfo = null;
            NNStreamerError ret = NNStreamerError.None;

            int count;
            ret = Interop.Util.GetTensorsCount(handle, out count);
            NNStreamer.CheckException(ret, "Fail to get Tensors' count");

            retInfo = new TensorsInfo();

            for (int i = 0; i < count; ++i)
            {
                string name;
                TensorType type;
                uint[] dim = new uint[Tensor.RankLimit];

                ret = Interop.Util.GetTensorName(handle, i, out name);
                NNStreamer.CheckException(ret, "Fail to get Tensor's name");

                ret = Interop.Util.GetTensorType(handle, i, out type);
                NNStreamer.CheckException(ret, "Fail to get Tensor's type");

                ret = Interop.Util.GetTensorDimension(handle, i, dim);
                NNStreamer.CheckException(ret, "Fail to get Tensor's dimension");

                retInfo.AddTensorInfo(name, type, (int[])(object)dim);
            }
            return retInfo;
        }

        /// <summary>
        /// Return TensorsInfo handle
        /// </summary>
        /// <returns>IntPtr TensorsInfo handle</returns>
        internal IntPtr GetTensorsInfoHandle()
        {
            NNStreamerError ret = NNStreamerError.None;
            IntPtr ret_handle = IntPtr.Zero;
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
                UpdateInfoHandle(ret_handle, idx, t.Name, t.Type, t.Dimension);
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
                NNStreamerError ret = Interop.Util.DestroyTensorsInfo(_handle);

                if (ret != NNStreamerError.None)
                {
                    Log.Error(NNStreamer.TAG, "failed to destroy TensorsInfo object");
                }
            }
            _disposed = true;
        }

        private void UpdateInfoHandle(IntPtr handle, int idx, string name, TensorType type, int[] dimension)
        {
            if (handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.None;

                ret = Interop.Util.SetTensorName(handle, idx, name);
                NNStreamer.CheckException(ret, "Failed to set the name of tensor at index " + idx.ToString());

                ret = Interop.Util.SetTensorType(handle, idx, type);
                NNStreamer.CheckException(ret, "Failed to set the type of tensor at index " + idx.ToString());

                ret = Interop.Util.SetTensorDimension(handle, idx, dimension);
                NNStreamer.CheckException(ret, "Failed to set the dimension of tensor at index " + idx.ToString());
            }
        }

        private void CheckIndexBoundary(int idx)
        {
            if (idx < 0 || idx >= _infoList.Count)
            {
                string msg = "Invalid index [" + idx + "] of the tensors";
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
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

            private int GetSize()
            {
                int size = 0;

                switch (Type) {
                    case TensorType.Int32:
                    case TensorType.UInt32:
                    case TensorType.Float32:
                        size = 4;
                        break;

                    case TensorType.Int16:
                    case TensorType.UInt16:
                        size = 2;
                        break;

                    case TensorType.Int8:
                    case TensorType.UInt8:
                        size = 1;
                        break;

                    case TensorType.Float64:
                    case TensorType.Int64:
                    case TensorType.UInt64:
                        size = 8;
                        break;

                    default:
                        /* Unknown Type */
                        break;
                }
                for (int i = 0; i < Tensor.RankLimit; ++i)
                {
                    size *= Dimension[i];
                }
                return size;
            }

            public int Size
            {
                get {
                    return GetSize();
                }
            }

            public string Name { get; set; } = string.Empty;

            public TensorType Type { get; set; } = TensorType.Int32;

            public int[] Dimension { get; private set; } = new int[Tensor.RankLimit];
        }
    }
}
