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

namespace Tizen.MachineLearning.Nnstreamer
{
    public enum PipelineState
    {
        Unknown = 0,
        Null = 1,
        Ready = 2,
        Pause = 3,
        Playing = 4,
    };

    public enum TensorType
    {
        Int32 = 0,
        UInt32,
        Int16,
        UInt16,
        Int8,
        UInt8,
        Float64,
        Float32,
        Int64,
        UInt64,
        Unknown,
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
    }

    public enum NNFWType
    {
        Any = 0,
        CustomFilter,
        TensorflowLite,
        Tensorflow,
        NNFW,
    }

    public enum HWType
    {
        Any = 0,
        Auto = 1,
        CPU = 0x1000,
        GPU = 0x2000,
        NPU = 0x3000,
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
    }

    internal static class NNStreamer
    {
        internal const string TAG = "Nnstreamer";

        internal static void CheckException(NNStreamerError error, string msg)
        {
            if (error != NNStreamerError.None)
            {
                Log.Error(NNStreamer.TAG, msg);
                throw NNStreamerExceptionFactory.CreateException(error, msg);
            }
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

                case NNStreamerError.StreamsPipe:
                case NNStreamerError.TryAgain:
                    exp = new IOException(msg);
                    break;

                default:
                    exp = new InvalidOperationException(msg);
                    break;
            }
            return exp;
        }
    }
}
