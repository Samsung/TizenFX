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
using System.IO;
using Tizen.System;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// Possible data element types of Tensor in NNStreamer.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum TensorType
    {
#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Integer 32bit
        /// </summary>
        Int32 = 0,
        /// <summary>
        /// Unsigned integer 32bit
        /// </summary>
        UInt32,
        /// <summary>
        /// Integer 16bit
        /// </summary>
        Int16,
        /// <summary>
        /// Unsigned integer 16bit
        /// </summary>
        UInt16,
        /// <summary>
        /// Integer 8bit
        /// </summary>
        Int8,
        /// <summary>
        /// Unsigned integer 8bit
        /// </summary>
        UInt8,
        /// <summary>
        /// Float 64bit
        /// </summary>
        Float64,
        /// <summary>
        /// Float 32bit
        /// </summary>
        Float32,
        /// <summary>
        /// Integer 64bit
        /// </summary>
        Int64,
        /// <summary>
        /// Unsigned integer 64bit
        /// </summary>
        UInt64,
#pragma warning restore CA1720 // Identifier contains type name
    }

    internal enum NNStreamerError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        StreamsPipe = Tizen.Internals.Errors.ErrorCode.StreamsPipe,
        TryAgain = Tizen.Internals.Errors.ErrorCode.TryAgain,
        Unknown = Tizen.Internals.Errors.ErrorCode.Unknown,
        TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        QuotaExceeded = Tizen.Internals.Errors.ErrorCode.QuotaExceeded,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
    }

    internal enum SwitchType
    {
        OutputSelector = 0,
        InputSelector = 1,
    }

    internal enum PipelineBufferPolicy
    {
        AutoFree = 0,
        NotFreed = 1,
    }

    /// <summary>
    /// States of NNStreamer pipeline.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum PipelineState
    {
        /// <summary>
        /// Initial state of the pipeline.
        /// </summary>
        Null = 1,
        /// <summary>
        /// The pipeline is ready to go to PAUSED.
        /// </summary>
        Ready = 2,
        /// <summary>
        /// The pipeline is stopped, ready to accept and process data.
        /// </summary>
        Paused = 3,
        /// <summary>
        /// The pipeline is started and the data is flowing.
        /// </summary>
        Playing = 4,
    }

    /// <summary>
    /// Types of Neural Network Framework.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum NNFWType
    {
        /// <summary>
        /// NNHW is not specified (Try to determine the NNFW with file extension).
        /// </summary>
        Any = 0,
        /// <summary>
        /// Custom filter (Independent shared object).
        /// </summary>
        CustomFilter = 1,
        /// <summary>
        /// Tensorflow-lite (.tflite).
        /// </summary>
        TensorflowLite = 2,
        /// <summary>
        /// Tensorflow (.pb).
        /// </summary>
        Tensorflow = 3,
        /// <summary>
        /// Neural Network Inference framework, which is developed by SR (Samsung Research).
        /// </summary>
        NNFW = 4,
        /// <summary>
        /// Intel Movidius Neural Compute SDK (libmvnc).
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        MVNC = 5,
        /// <summary>
        /// Intel OpenVINO.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        OpenVINO = 6,
        /// <summary>
        /// VeriSilicon's Vivante.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Vivante = 7,
        /// <summary>
        /// Google Coral Edge TPU (USB).
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        EdgeTPU = 8,
        /// <summary>
        /// Arm Neural Network framework (support for caffe and tensorflow-lite).
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        ArmNN = 9,
        /// <summary>
        /// Qualcomm SNPE (Snapdgragon Neural Processing Engine (.dlc)
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        SNPE = 10,
    }

    /// <summary>
    /// Types of hardware resources to be used for NNFWs. Note that if the affinity (nnn) is not supported by the driver or hardware, it is ignored.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum HWType
    {
        /// <summary>
        /// Hardware resource is not specified.
        /// </summary>
        Any = 0,
        /// <summary>
        /// Try to schedule and optimize if possible.
        /// </summary>
        Auto = 1,
        /// <summary>
        /// Any CPU if possible.
        /// </summary>
        CPU = 0x1000,
        /// <summary>
        /// SIMD in CPU if possible.
        /// <since_tizen> 8 </since_tizen>
        /// </summary>
        CPUSIMD = 0x1100,
        /// <summary>
        /// NEON in CPU.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        CPUNeon = CPUSIMD,
        /// <summary>
        /// Any GPU if possible.
        /// </summary>
        GPU = 0x2000,
        /// <summary>
        /// Any NPU if possible.
        /// </summary>
        NPU = 0x3000,
        /// <summary>
        /// Intel Movidius Stick.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        NPUMovidius = 0x3001,
        /// <summary>
        /// Google Coral Edge TPU (USB).
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        NPUEdgeTPU = 0x3002,
        /// <summary>
        /// VeriSilicon's Vivante.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        NPUVivante = 0x3003,
        /// <summary>
        /// Any SR (Samsung Research) made NPU.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        NPUSR = 0x13000,
    }

    internal static class Tensor
    {
        /// <summary>
        /// The maximum rank that NNStreamer supports with Tizen APIs.
        /// </summary>
        internal const int RankLimit = 4;

        /// <summary>
        /// The maximum number of other/tensor instances that other/tensors may have.
        /// </summary>
        internal const int SizeLimit = 16;

        /// <summary>
        /// Unknown Type of Tensor information. It is internally used for error check.
        /// </summary>
        internal const int UnknownType = 10;

        /// <summary>
        /// Invalid count of TensorsData. It is internally used for error check.
        /// </summary>
        internal const int InvalidCount = -1;
    }

    internal static class NNStreamer
    {
        internal const string TAG = "ML.Inference";

        internal const string FeatureKey = "http://tizen.org/feature/machine_learning.inference";

        private static int _alreadyChecked = -1;    /* -1: not yet, 0: Not Support, 1: Support */

        internal static void CheckException(NNStreamerError error, string msg)
        {
            if (error != NNStreamerError.None)
            {
                Log.Error(NNStreamer.TAG, msg + ": " + error.ToString());
                throw NNStreamerExceptionFactory.CreateException(error, msg);
            }
        }

        internal static void CheckNNStreamerSupport()
        {
            if (_alreadyChecked == 1)
                return;

            string msg = "Machine Learning Inference Feature is not supported.";
            if (_alreadyChecked == 0)
            {
                Log.Error(NNStreamer.TAG, msg);
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.NotSupported, msg);
            }

            /* Feature Key check */
            bool isSupported = false;
            bool error = Information.TryGetValue<bool>(FeatureKey, out isSupported);
            if (!error || !isSupported)
            {
                _alreadyChecked = 0;

                Log.Error(NNStreamer.TAG, msg);
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.NotSupported, msg);
            }

            /* Check required so files */
            try
            {
                Interop.Util.CheckNNFWAvailability(NNFWType.TensorflowLite, HWType.CPU, out isSupported);
            }
            catch (DllNotFoundException)
            {
                _alreadyChecked = 0;
                Log.Error(NNStreamer.TAG, msg);
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.NotSupported, msg);
            }

            _alreadyChecked = 1;
        }
    }

    internal class NNStreamerExceptionFactory
    {
        internal static Exception CreateException(NNStreamerError err, string msg)
        {
            Exception exp;

            switch (err)
            {
                case NNStreamerError.InvalidParameter:
                    exp = new ArgumentException(msg);
                    break;

                case NNStreamerError.NotSupported:
                    exp = new NotSupportedException(msg);
                    break;

                case NNStreamerError.PermissionDenied:
                    exp = new UnauthorizedAccessException(msg);
                    break;

                case NNStreamerError.StreamsPipe:
                case NNStreamerError.TryAgain:
                    exp = new InvalidOperationException(msg);
                    break;

                case NNStreamerError.TimedOut:
                    exp = new TimeoutException(msg);
                    break;

                case NNStreamerError.QuotaExceeded:
                    exp = new IndexOutOfRangeException(msg);
                    break;

                default:
                    exp = new InvalidOperationException(msg);
                    break;
            }
            return exp;
        }
    }
}
