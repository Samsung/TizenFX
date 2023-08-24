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

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The SingleShot class loads a Machine Learning model and make inferences from input data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SingleShot : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _dynamicMode = false;
        private bool _disposed = false;

        private TensorsInfo _inInfo = null;
        private TensorsInfo _outInfo = null;

        /// <summary>
        /// Loads the neural network model and configures runtime environment
        /// </summary>
        /// <param name="modelAbsPath">Absolute path to the neural network model file.</param>
        /// <param name="inTensorsInfo">Input TensorsInfo object</param>
        /// <param name="outTensorsInfo">Output TensorsInfo object for inference result</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public SingleShot(string modelAbsPath, TensorsInfo inTensorsInfo, TensorsInfo outTensorsInfo)
        {
            NNStreamer.CheckNNStreamerSupport();

            if (inTensorsInfo == null || outTensorsInfo == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "TensorsInfo is null");

            CreateSingleShot(modelAbsPath, inTensorsInfo, outTensorsInfo, NNFWType.Any, HWType.Any, false);
        }

        /// <summary>
        /// Loads the neural network model and configures runtime environment with Neural Network Framework and HW information
        /// </summary>
        /// <param name="modelAbsPath">Absolute path to the neural network model file.</param>
        /// <param name="inTensorsInfo">Input TensorsInfo object</param>
        /// <param name="outTensorsInfo">Output TensorsInfo object for inference result</param>
        /// <param name="fwType">Types of Neural Network Framework</param>
        /// <param name="hwType">Types of hardware resources to be used for NNFWs</param>
        /// <param name="isDynamicMode">Support Dynamic Mode</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public SingleShot(string modelAbsPath,
            TensorsInfo inTensorsInfo, TensorsInfo outTensorsInfo, NNFWType fwType, HWType hwType, bool isDynamicMode)
        {
            NNStreamer.CheckNNStreamerSupport();

            if (inTensorsInfo == null || outTensorsInfo == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "TensorsInfo is null");

            CreateSingleShot(modelAbsPath, inTensorsInfo, outTensorsInfo, fwType, hwType, isDynamicMode);
        }

        /// <summary>
        /// Loads the neural network model and configures runtime environment without TensorsInfo
        /// </summary>
        /// <param name="modelAbsPath">Absolute path to the neural network model file.</param>
        /// <param name="fwType">Types of Neural Network Framework (Default:NNFWType.Any)</param>
        /// <param name="hwType">Types of hardware resources to be used for NNFWs (Default: HWType.Any)</param>
        /// <param name="isDynamicMode">Support Dynamic Mode (Default: false)</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public SingleShot(string modelAbsPath, NNFWType fwType = NNFWType.Any, HWType hwType = HWType.Any, bool isDynamicMode = false)
        {
            NNStreamer.CheckNNStreamerSupport();

            CreateSingleShot(modelAbsPath, null, null, fwType, hwType, isDynamicMode);
        }

        /// <summary>
        /// The information (tensor dimension, type, name and so on) of required input data for the given model.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public TensorsInfo Input
        {
            get
            {
                NNStreamer.CheckNNStreamerSupport();

                IntPtr inHandle;
                NNStreamerError ret = NNStreamerError.None;

                if (_inInfo != null)
                    return _inInfo;

                ret = Interop.SingleShot.GetInputTensorsInfo(_handle, out inHandle);
                NNStreamer.CheckException(ret, "fail to get Input TensorsInfo handle");

                TensorsInfo retInfo = TensorsInfo.ConvertTensorsInfoFromHandle(inHandle);

                _inInfo = retInfo;
                return retInfo;
            }
            set
            {
                NNStreamer.CheckNNStreamerSupport();
                NNStreamerError ret = NNStreamerError.None;

                if (value == null)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "TensorsInfo is null");

                ret = Interop.SingleShot.SetInputInfo(_handle, value.GetTensorsInfoHandle());
                NNStreamer.CheckException(ret, "fail to set Input TensorsInfo");

                _inInfo = value;
            }
        }

        /// <summary>
        /// The information (tensor dimension, type, name and so on) of output data for the given model.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 8 </since_tizen>
        public TensorsInfo Output
        {
            get
            {
                NNStreamer.CheckNNStreamerSupport();

                IntPtr outHandle;
                NNStreamerError ret = NNStreamerError.None;

                if (_outInfo != null)
                    return _outInfo;

                ret = Interop.SingleShot.GetOutputTensorsInfo(_handle, out outHandle);
                NNStreamer.CheckException(ret, "fail to get Output TensorsInfo handle");

                TensorsInfo retInfo = TensorsInfo.ConvertTensorsInfoFromHandle(outHandle);

                _outInfo = retInfo;
                return retInfo;
            }
        }

        /// <summary>
        /// Sets the maximum amount of time to wait for an output, in milliseconds.
        /// </summary>
        /// <param name="ms">The time to wait for an output (milliseconds)</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetTimeout(int ms)
        {
            NNStreamer.CheckNNStreamerSupport();
            NNStreamerError ret = NNStreamerError.None;

            if (ms <= 0)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Invalid timeout: " + ms.ToString());

            ret = Interop.SingleShot.SetTimeout(_handle, ms);
            NNStreamer.CheckException(ret, "fail to set the timeout!");
        }

        /// <summary> Sets the property value for the given model.
        /// <para>A model/framework may support changing the model information, such as tensor dimension and data layout, after opening the model.</para>
        /// <para>If tries to change unavailable property or the model does not allow changing the information, this will raise an exception.</para>
        /// <para>For the details about the properties, see 'tensor_filter' plugin definition in <a href="https://github.com/nnstreamer/nnstreamer">NNStreamer</a>.</para>
        /// </summary>
        /// <param name="name">The property name</param>
        /// <param name="value">The property value</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported, or given property is not available.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void SetValue(string name, string value)
        {
            NNStreamerError ret = NNStreamerError.None;

            NNStreamer.CheckNNStreamerSupport();

            /* Check the argument */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property name is invalid");

            if (string.IsNullOrEmpty(value))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property value is invalid");

            ret = Interop.SingleShot.SetValue(_handle, name, value);
            if (ret != NNStreamerError.None)
            {
                if (ret == NNStreamerError.NotSupported)
                    NNStreamer.CheckException(ret, "Failed to to set the property, the property name is not available.");
                else
                    NNStreamer.CheckException(ret, "Failed to to set the property, the property value is invalid.");
            }
        }

        /// <summary>
        /// Gets the property value for the given model.
        /// </summary>
        /// <param name="name">The property name</param>
        /// <returns>The property value</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported, or given property is not available.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public string GetValue(string name)
        {
            NNStreamerError ret = NNStreamerError.None;
            IntPtr val = IntPtr.Zero;

            NNStreamer.CheckNNStreamerSupport();

            /* Check the argument */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property name is invalid");

            ret = Interop.SingleShot.GetValue(_handle, name, out val);
            if (ret != NNStreamerError.None)
            {
                if (ret == NNStreamerError.NotSupported)
                    NNStreamer.CheckException(ret, "Failed to to get the property, the property name is not available.");
                else
                    NNStreamer.CheckException(ret, "Failed to to get the property, the property value is invalid.");
            }

            return Interop.Util.IntPtrToString(val);
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
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="TimeoutException">Thrown when failed to get the result from sink element.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public TensorsData Invoke(TensorsData inTensorsData)
        {
            TensorsData out_data = null;
            TensorsInfo inInfo = null;
            IntPtr outDataPtr = IntPtr.Zero;
            NNStreamerError ret = NNStreamerError.None;

            NNStreamer.CheckNNStreamerSupport();

            if (inTensorsData == null)
            {
                string msg = "TensorsData is null";
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
            }

            if (inTensorsData.TensorsInfo == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "TensorsInfo is null");

            inInfo = inTensorsData.TensorsInfo;
            if (_dynamicMode)
            {
                /* Apply all data */
                inTensorsData.PrepareInvoke();

                IntPtr outInfoPtr = IntPtr.Zero;
                ret = Interop.SingleShot.InvokeSingleDynamic(_handle, inTensorsData.GetHandle(), inInfo.GetTensorsInfoHandle(), out outDataPtr, out outInfoPtr);
                NNStreamer.CheckException(ret, "fail to invoke the single dynamic inference");

                out_data = TensorsData.CreateFromNativeHandle(outDataPtr, outInfoPtr, true);
            }
            else
            {
                if (!inInfo.Equals(_inInfo))
                {
                    string msg = "The TensorsInfo of Input TensorsData is different from that of SingleShot object";
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, msg);
                }

                /* Apply all data */
                inTensorsData.PrepareInvoke();

                ret = Interop.SingleShot.InvokeSingle(_handle, inTensorsData.GetHandle(), out outDataPtr);
                NNStreamer.CheckException(ret, "fail to invoke the single inference");

                out_data = TensorsData.CreateFromNativeHandle(outDataPtr, inInfo.GetTensorsInfoHandle(), true);
            }
            return out_data;
        }

        private void CreateSingleShot(string modelAbsPath,
            TensorsInfo inTensorInfo, TensorsInfo outTensorInfo,
            NNFWType FWType, HWType HWType, bool IsDynamicMode)
        {
            NNStreamerError ret = NNStreamerError.None;
            IntPtr input_info = IntPtr.Zero;
            IntPtr output_info = IntPtr.Zero;

            /* Check model path */
            if (string.IsNullOrEmpty(modelAbsPath))
                ret = NNStreamerError.InvalidParameter;
            NNStreamer.CheckException(ret, "model path is invalid: " + modelAbsPath);

            /* Set Dynamic Mode */
            _dynamicMode = IsDynamicMode;

            if (inTensorInfo != null)
            {
                input_info = inTensorInfo.GetTensorsInfoHandle();
                _inInfo = inTensorInfo;
            }

            if (outTensorInfo != null)
            {
                output_info = outTensorInfo.GetTensorsInfoHandle();
                _outInfo = outTensorInfo;
            }

            ret = Interop.SingleShot.OpenSingle(out _handle, modelAbsPath, input_info, output_info, FWType, HWType);
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
