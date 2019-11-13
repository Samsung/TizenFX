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
        private int _count = Tensor.InvalidCount;

        /// <summary>
        /// Creates a TensorsInfo instance with handle which is given by TensorsInfo.
        /// </summary>
        /// <param name="handle">The handle of tensors data.</param>
        /// <since_tizen> 6 </since_tizen>
        private TensorsData(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Destructor of the TensorsData instance
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~TensorsData()
        {
            Dispose(false);
        }

        internal static TensorsData CreateFromNativeHandle(IntPtr handle)
        {
            TensorsData retTensorsData = new TensorsData(handle);

            return retTensorsData;
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

                if (_count != Tensor.InvalidCount)
                    return _count;

                NNStreamerError ret = NNStreamerError.None;
                int count = 0;

                ret = Interop.Util.GetTensorsCount(_handle, out count);
                NNStreamer.CheckException(ret, "unable to get the count of TensorsData");

                _count = count;
                return _count;
            }
        }

        /// <summary>
        /// Sets a tensor data to given index.
        /// </summary>
        /// <param name="index">The index of the tensor.</param>
        /// <param name="buffer">Raw tensor data to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void SetTensorData(int index, byte[] buffer)
        {
            NNStreamerError ret = NNStreamerError.None;

            NNStreamer.CheckNNStreamerSupport();

            if (buffer == null)
            {
                string msg = "buffer is null";
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
            }

            ret = Interop.Util.SetTensorData(_handle, index, buffer, buffer.Length);
            NNStreamer.CheckException(ret, "unable to set the buffer of TensorsData: " + index.ToString());
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
            byte[] retBuffer = null;
            IntPtr raw_data;
            int size;
            NNStreamerError ret = NNStreamerError.None;

            NNStreamer.CheckNNStreamerSupport();

            ret = Interop.Util.GetTensorData(_handle, index, out raw_data, out size);
            NNStreamer.CheckException(ret, "unable to get the buffer of TensorsData: " + index.ToString());

            retBuffer = Interop.Util.IntPtrToByteArray(raw_data, size);

            return retBuffer;
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

        internal IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
