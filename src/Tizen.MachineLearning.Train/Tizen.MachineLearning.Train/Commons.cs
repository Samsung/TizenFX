/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd. All Rights Reserved.
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
using Tizen.Internals.Errors;

namespace Tizen.MachineLearning.Train
{
    internal enum NNTrainerError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        StreamsPipe = ErrorCode.StreamsPipe,
        TryAgain = ErrorCode.TryAgain,
        Unknown = ErrorCode.Unknown,
        TimedOut = ErrorCode.TimedOut,
        NotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation
    }


    /// <summary>
    /// Enumeration for the neural network summary verbosity of NNTrainer.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerSummaryType
    {
        /// <summary>
        /// Overview of model summary with one-line layer information
        /// </summary>
        Model = 0,
        /// <summary>
        /// Detailed model summary with layer properties
        /// </summary>
        Layer = 1,
        /// <summary>
        /// Model summary layer's including weight information
        /// </summary>
        Tensor = 2
    }

    /// <summary>
    /// Enumeration for the neural network.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerModelFormat
    {
        /// <summary>
        /// Raw bin file saves model weights required for inference and training without any configurations
        /// </summary>
        Bin = 0,
        /// <summary>
        /// Ini format file saves model configurations.
        /// </summary>
        Ini = 1,
        /// <summary>
        /// Ini with bin format file saves configurations with parameters required for inference and training.
        /// </summary>
        IniWithBin = 2
    }

    internal static class NNTrainer
    {
 
        internal const string Tag = "Tizen.MachineLearning.Train";

        internal static void CheckException(NNTrainerError error, string msg)
        {
            if (error != NNTrainerError.None)
            {
                Log.Error(NNTrainer.Tag, msg + ": " + error.ToString());
                throw NNTrainerExceptionFactory.CreateException(error, msg);
            }
        }

    }

    internal class NNTrainerExceptionFactory
    {
        internal static Exception CreateException(NNTrainerError err, string msg)
        {
            Exception e;

            switch (err)
            {
                case NNTrainerError.InvalidParameter:
                e = new ArgumentException(msg);
                break;

                case NNTrainerError.NotSupported:
                e = new NotSupportedException(msg);
                break;

                case NNTrainerError.PermissionDenied:
                e = new UnauthorizedAccessException(msg);
                break;

                case NNTrainerError.TryAgain:
                case NNTrainerError.Unknown:
                case NNTrainerError.OutOfMemory:
                e = new InvalidOperationException(msg);
                break;

                case NNTrainerError.TimedOut:
                e = new TimeoutException(msg);
                break;

                default:
                e = new InvalidOperationException(msg);
                break;
            }
            return e;
        }
    }
}
