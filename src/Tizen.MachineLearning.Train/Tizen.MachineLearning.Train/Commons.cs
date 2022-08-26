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
        /// Model summary weight information that layer has
        /// </summary>
        Tensor = 2
    }

    /// <summary>
    /// Enumeration of model formats for the neural network.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerModelFormat
    {
        /// <summary>
        /// Raw bin file stores model weights required for inference and training without any configurations
        /// </summary>
        Bin = 0,
        /// <summary>
        /// Ini format file stores model configurations
        /// </summary>
        Ini = 1,
        /// <summary>
        /// Ini with bin format file stores configurations with parameters required for inference and training
        /// </summary>
        IniWithBin = 2
    }

    /// <summary>
    /// Enumeration for the neural network layer type of NNTrainer.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerLayerType
    {
        /// <summary>
        /// Input Layer
        /// </summary>
        Input = 0,
        /// <summary>
        /// Fully Connected Layer
        /// </summary>
        FC = 1,
        /// <summary>
        /// Batch Normalization Layer
        /// </summary>
        BN = 2,
        /// <summary>
        /// Convolution 2D Layer
        /// </summary>
        Conv2D = 3,
        /// <summary>
        /// Pooling 2D Layer
        /// </summary>
        Pooling2D= 4,
        /// <summary>
        /// Flatten Layer
        /// </summary>
        Flatten = 5,
        /// <summary>
        /// Activation Layer
        /// </summary>
        Activation = 6,
        /// <summary>
        /// Addition Layer
        /// </summary>
        Addition = 7,
        /// <summary>
        /// Concat Layer
        /// </summary>
        Concat = 8,
        /// <summary>
        /// MultiOut Layer
        /// </summary>
        MultiOut = 9,
        /// <summary>
        /// Embedding Layer
        /// </summary>
        Embedding = 10,
        /// <summary>
        /// RNN Layer
        /// </summary>
        RNN = 11,
        /// <summary>
        /// LSTM Layer
        /// </summary>
        LSTM = 12,
        /// <summary>
        /// Split Layer
        /// </summary>
        Split = 13,
        /// <summary>
        /// GRU Layer
        /// </summary>
        GRU = 14,
        /// <summary>
        /// Permute Layer
        /// </summary>
        Permute = 15,
        /// <summary>
        /// Dropout Layer
        /// </summary>
        Dropout = 16,
        /// <summary>
        /// Backbone using NNStreamer
        /// </summary>
        BackboneNNStreamer = 17,
        /// <summary>
        /// Centroid KNN Layer
        /// </summary>
        CentroidKNN = 18,
        /// <summary>
        /// Convolution 1D Layer
        /// </summary>
        Conv1D = 19,
        /// <summary>
        /// LSTM Cell Layer 
        /// </summary>
        LSTMCell = 20,
        /// <summary>
        /// GRU Cell Layer 
        /// </summary>
        GRUCell = 21,
        /// <summary>
        /// RNN Cell Layer 
        /// </summary>
        RNNCell = 22,
        /// <summary>
        /// ZoneoutLSTM Cell Layer 
        /// </summary>
        ZoneoutLSTMCell = 23,
        /// <summary>
        /// Preprocess flip Layer 
        /// </summary>
        PreprocessFlip = 300,
        /// <summary>
        /// Preprocess translate Layer 
        /// </summary>
        PreprocessTranslate = 301,
        /// <summary>
        /// Preprocess L2Normalization Layer 
        /// </summary>
        PreprocessL2Norm = 302,
        /// <summary>
        /// Mean Squared Error Loss Layer
        /// </summary>
        LoseMSE = 500,
        /// <summary>
        /// Cross Entropy with Sigmoid Loss Layer
        /// </summary>
        LossCrossEntropySigmoid = 501, 
        /// <summary>
        /// Cross Entropy with Softmax Loss Layer
        /// </summary>                                            
        LossCrossEntropySoftmax = 502, 
        /// <summary>
        /// Unknown
        /// </summary>  
        Unknown = 999
    }

    /// <summary>
    /// Enumeration for the neural network optimizer type of NNTrainer.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerOptimizerType
    {
        /// <summary>
        /// Adam Optimizer
        /// </summary>
        Adam = 0,
        /// <summary>
        /// Stochastic Gradient Descent Optimizer
        /// </summary>
        SGD = 1,
        /// <summary>
        /// Unknown Optimizer
        /// </summary>
        Unknown = 999
    }

    /// <summary>
    /// Enumeration for the dataset data type of NNTrainer.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum NNTrainerDatasetMode
    {
        /// <summary>
        /// Data is used when training
        /// </summary>
        Train = 0,
        /// <summary>
        /// Data is used when validating
        /// </summary>
        Valid = 1,
        /// <summary>
        /// Data is used when testing
        /// </summary>
        Test = 2,
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
