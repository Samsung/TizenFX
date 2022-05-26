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
using static Interop;
using System;
using System.IO;

namespace Tizen.MachineLearning.Train
{
    /// <summary>
    /// Constructs the neural network model
    /// </summary>
    /// <remarks>
    /// Use this function to create neural network model.
    /// The Model class provides interfaces to construct, complle, run, adding layer
    /// and etc with neural networks.
    /// If you want to access only internal storage by using this function,
    /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
    /// want to access only external storage by using this function, you should add
    /// privilege %http://tizen.org/privilege/externalstorage. If you want to access
    /// both storage, you must add all the privileges.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
    public class Model: IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Constructs the neural network model.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Model()
        {
            NNTrainerError ret = Interop.Model.Construct(out _handle);
            NNTrainer.CheckException(ret, "Failed to create model instance");
        }

        /// <summary>
        /// Constructs the neural network model with the given configuration file.
        /// </summary>
        /// <param name="modelConf">The nntrainer model configuration file.</param>
        /// <since_tizen> 10 </since_tizen>
        public Model(string modelConf)
        {
            if (string.IsNullOrEmpty(modelConf))
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "modelConf is null");
            Log.Info(NNTrainer.Tag, "Conf path: "+ modelConf);
            NNTrainerError ret = Interop.Model.ConstructWithConf(modelConf, out _handle);
            NNTrainer.CheckException(ret, "Failed to create model instance with modelConf");
        }
        /// <summary>
        /// Destructor of Model
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ~Model()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object including opened handle.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // release managed object
            }
            // release unmanaged object
            if (_handle != IntPtr.Zero)
            {
                // Destroy the neural network model.
                NNTrainerError ret = Interop.Model.Destroy(_handle);
                NNTrainer.CheckException(ret, "Failed to destroy model instance");

                _handle = IntPtr.Zero;
            }
            _disposed = true;
        }

        /// <summary>
        /// Compiles and finalizes the neural network model with the hyperparameter.
        /// </summary>
        /// <remarks>
        /// Use this function to initialize neural network model.Various
        /// hyperparameter before compile the model can be set. Once compiled,
        /// any modification to the properties of model or layers/dataset/optimizer in
        /// the model will be restricted. Further, addition of layers or changing the
        /// optimizer/dataset of the model will not be permitted.
        /// <param name="hyperparameter">Hyperparameters for train complie.</param>
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public void Compile(params string[] hyperparameter)
        {
            string compile_params = null;

            if (hyperparameter != null) {
                compile_params = string.Join("|", hyperparameter);
                Log.Info(NNTrainer.Tag, "Compile hyperparameter:"+ compile_params);
            }

            NNTrainerError ret = Interop.Model.Compile(_handle, compile_params);
            NNTrainer.CheckException(ret, "Failed to compile model");
        }

        /// <summary>
        /// Trains the neural network model with the hyperparameter.
        /// </summary>
        /// <remarks>
        /// Use this function to train the compiled neural network model with
        /// the passed training hyperparameters. This function will return once the
        /// training, along with requested validation and testing, is completed.
        /// </remarks>
        /// <param name="hyperparameter">Hyperparameters for train model.</param>
        /// <since_tizen> 10 </since_tizen>
        public void Run(params string[] hyperparameter)
        {
            string run_params = null;

            if (hyperparameter != null) {
                run_params = string.Join("|", hyperparameter);
                Log.Info(NNTrainer.Tag, "Run hyperparameter:"+ run_params);
            }

            NNTrainerError ret = Interop.Model.Run(_handle, run_params);
            NNTrainer.CheckException(ret, "Failed to run model");
        }

        /// <summary>
        /// Gets the summary of the neural network model.
        /// </summary>
        /// <remarks>
        /// Use this function to get the summary of the neural network model.
        /// </remarks>
        /// <param name="verbosity">Verbose level of the summary.</param>
        /// <param name="retSummary">On return, a string value. The summary of the current model. Avoid logic to parse and exploit summary if possible.</param>
        /// <since_tizen> 10 </since_tizen>
        public void GetSummaryUtil(NNTrainerSummaryType verbosity, out string retSummary)
        {
            NNTrainerError ret = Interop.Model.GetSummaryUtil(_handle, verbosity, out string summary);
            NNTrainer.CheckException(ret, "Failed to get summary");

            retSummary = summary;

        }
    } 
}
