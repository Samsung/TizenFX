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
using System.Collections;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The TensorsData class sets and gets the buffer data for each Tensor.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TensorsData : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private TensorsInfo _tensorsInfo = null;
        private ArrayList _dataList = null;

        /// <summary>
        /// Creates a TensorsData instance with handle which is given by TensorsInfo.
        /// </summary>
        /// <param name="handle">The handle of tensors data.</param>
        /// <param name="info">The handle of tensors info.</param>
        /// <param name="isFetch">The boolean value for fetching the data (Default: false)</param>
        /// <param name="hasOwnership">The boolean value for automatic disposal (Default: true)</param>
        /// <since_tizen> 6 </since_tizen>
        private TensorsData(IntPtr handle, TensorsInfo info, bool isFetch = false, bool hasOwnership = true)
        {
            NNStreamer.CheckNNStreamerSupport();
            NNStreamerError ret = NNStreamerError.None;

            /* Set internal object */
            _handle = handle;
            /* Because developers can change the TensorsInfo object, it should be stored as a deep-copied instance. */
            _tensorsInfo = info.Clone();

            /* Set count */
            int count = 0;
            ret = Interop.Util.GetTensorsCount(_handle, out count);
            NNStreamer.CheckException(ret, "unable to get the count of TensorsData");

            _dataList = new ArrayList(count);

            if (isFetch)
            {
                for (int i = 0; i < count; ++i)
                {
                    IntPtr raw_data;
                    byte[] bufData = null;
                    int size;

                    ret = Interop.Util.GetTensorData(_handle, i, out raw_data, out size);
                    NNStreamer.CheckException(ret, "unable to get the buffer of TensorsData: " + i.ToString());

                    bufData = Interop.Util.IntPtrToByteArray(raw_data, size);
                    _dataList.Add(bufData);
                }
            }
            else
            {
                for (int i = 0; i < count; ++i)
                {
                    int size = info.GetTensorSize(i);
                    byte[] bufData = new byte[size];

                    _dataList.Add(bufData);
                }
            }

            /* If it created as DataReceivedEventArgs, do not dispose. */
            _disposed = !hasOwnership;
        }

        /// <summary>
        /// Destructor of the TensorsData instance
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~TensorsData()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the number of Tensor in TensorsData class
        /// </summary>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public int Count
        {
            get {
                NNStreamer.CheckNNStreamerSupport();

                return _dataList.Count;
            }
        }

        /// <summary>
        /// Gets the tensors information.
        /// </summary>
        /// <returns>The TensorsInfo instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public TensorsInfo TensorsInfo
        {
            get {
                NNStreamer.CheckNNStreamerSupport();

                return _tensorsInfo;
            }
        }

        /// <summary>
        /// Allocates a new TensorsData instance with the given tensors information.
        /// </summary>
        /// <param name="info">TensorsInfo object which has Tensor information</param>
        /// <returns>The TensorsInfo instance</returns>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static TensorsData Allocate(TensorsInfo info)
        {
            NNStreamer.CheckNNStreamerSupport();

            if (info == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "TensorsInfo is null");

            TensorsData retData = info.GetTensorsData();
            return retData;
        }

        /// <summary>
        /// Sets a tensor data to given index.
        /// </summary>
        /// <param name="index">The index of the tensor.</param>
        /// <param name="buffer">Raw tensor data to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the data is not valid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorData(int index, byte[] buffer)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndex(index);
            CheckDataBuffer(index, buffer);

            _dataList[index] = buffer;
        }

        /// <summary>
        /// Gets a tensor data to given index.
        /// </summary>
        /// <param name="index">The index of the tensor.</param>
        /// <returns>Raw tensor data</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public byte[] GetTensorData(int index)
        {
            NNStreamer.CheckNNStreamerSupport();

            CheckIndex(index);

            return (byte[])_dataList[index];
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
                // release managed object
                _tensorsInfo.Dispose();
                _tensorsInfo = null;
            }

            // release unmanaged objects
            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = Interop.Util.DestroyTensorsData(_handle);
                if (ret != NNStreamerError.None)
                {
                    Log.Error(NNStreamer.TAG, "failed to destroy TensorsData object");
                }
                _handle = IntPtr.Zero;
            }
            _disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _handle;
        }

        internal void PrepareInvoke()
        {
            NNStreamerError ret = NNStreamerError.None;
            int count = _dataList.Count;

            for (int i = 0; i < count; ++i)
            {
                byte[] data = (byte[])_dataList[i];
                ret = Interop.Util.SetTensorData(_handle, i, data, data.Length);
                NNStreamer.CheckException(ret, "unable to set the buffer of TensorsData: " + i.ToString());
            }
        }

        internal static TensorsData CreateFromNativeHandle(IntPtr dataHandle, IntPtr infoHandle, bool isFetch = false, bool hasOwnership = true)
        {
            TensorsInfo info = null;

            if (infoHandle != IntPtr.Zero)
            {
                info = TensorsInfo.ConvertTensorsInfoFromHandle(infoHandle);
            }

            return new TensorsData(dataHandle, info, isFetch, hasOwnership);
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _dataList.Count)
            {
                string msg = "Invalid index [" + index + "] of the tensors";
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
            }
        }

        private void CheckDataBuffer(int index, byte[] data)
        {
            if (data == null)
            {
                string msg = "data is not valid";
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
            }

            if (index >= Tensor.SizeLimit)
            {
                string msg = "Max size of the tensors is " + Tensor.SizeLimit;
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.QuotaExceeded, msg);
            }

            if (_tensorsInfo != null)
            {
                if (index >= _tensorsInfo.Count)
                {
                    string msg = "Current information has " + _tensorsInfo.Count + " tensors";
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.QuotaExceeded, msg);
                }

                int size = _tensorsInfo.GetTensorSize(index);
                if (data.Length != size)
                {
                    string msg = "Invalid buffer size, required size is " + size.ToString();
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
                }
            }
        }
    }
}
