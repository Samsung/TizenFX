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
using System.Text;
using System.IO;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The SingleShot class loads a Machine Learning model and make inferences from input data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SingleShot : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Loads the neural network model and configures runtime environment
        /// </summary>
        /// <param name="modelAbsPath">Absolute path to the neural network model file.</param>
        /// <param name="inTensorsInfo">Input TensorsInfo object</param>
        /// <param name="outTensorsInfo">Output TensorsInfo object for inference result</param>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="IOException">Thrown when constructing the pipeline is failed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the parameter is not available.</exception>
        /// <since_tizen> 6 </since_tizen>
        public SingleShot(string modelAbsPath, TensorsInfo inTensorsInfo, TensorsInfo outTensorsInfo)
        {
            CreateSingleShot(modelAbsPath, inTensorsInfo, outTensorsInfo);
        }

        /// <summary>
        /// Destructor of the Single instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~SingleShot()
        {
            Dispose(false);
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
        /// Invokes the model with the given input data.
        /// </summary>
        /// <param name="inTensorsData">The input data to be inferred.</param>
        /// <returns>TensorsData instance which contains the inferred result.</returns>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="IOException">Thrown when failed to push an input data into source element.</exception>
        /// <exception cref="TimeoutException">Thrown when failed to get the result from sink element.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorsData Invoke(TensorsData inTensorsData)
        {
            TensorsData out_data;
            IntPtr out_ptr;
            NNStreamerError ret = NNStreamerError.None;

            ret = Interop.SingleShot.InvokeSingle(_handle, inTensorsData.Handle, out out_ptr);
            NNStreamer.CheckException(ret, "fail to invoke the single inference engine");

            out_data = TensorsData.CreateFromNativeHandle(out_ptr);
            return out_data;
        }

        private void CreateSingleShot(string modelAbsPath, TensorsInfo inTensorInfo, TensorsInfo outTensorInfo)
        {
            NNStreamerError ret = NNStreamerError.None;
            IntPtr input_info;
            IntPtr output_info;

            /* Check model path */
            if (string.IsNullOrEmpty(modelAbsPath))
                ret = NNStreamerError.InvalidParameter;
            NNStreamer.CheckException(ret, "model path is invalid: " + modelAbsPath);

            input_info = inTensorInfo.GetTensorsInfoHandle();
            output_info = outTensorInfo.GetTensorsInfoHandle();

            ret = Interop.SingleShot.OpenSingle(out _handle, modelAbsPath, input_info, output_info, NNFWType.Any, HWType.Any);
            NNStreamer.CheckException(ret, "fail to open the single inference engine");
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
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.SingleShot.CloseSingle(_handle);
                if (ret != NNStreamerError.None)
                {
                    Log.Error(NNStreamer.TAG, "failed to close inference engine");
                }
                _handle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
