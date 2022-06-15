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
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// Constructs the neural network model.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Model()
        {
            NNTrainerError ret = Interop.Model.Construct(out handle);
            NNTrainer.CheckException(ret, "Failed to create model instance");
            Log.Info(NNTrainer.Tag, "Created Model");
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

            NNTrainerError ret = Interop.Model.ConstructWithConf(modelConf, out handle);
            NNTrainer.CheckException(ret, "Failed to create model instance with modelConf");
            Log.Info(NNTrainer.Tag, "Created Model with Conf path: "+ modelConf);
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
            if (disposed)
                return;
            if (disposing)
            {
                // release managed object
            }
            // release unmanaged object
            if (handle != IntPtr.Zero)
            {
                // Destroy the neural network model.
                NNTrainerError ret = Interop.Model.Destroy(handle);
                NNTrainer.CheckException(ret, "Failed to destroy model instance");

                handle = IntPtr.Zero;
            }
            disposed = true;
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
            string compileParams = null;

            if (hyperparameter.Length > 0) {
                compileParams = string.Join("|", hyperparameter);
                Log.Info(NNTrainer.Tag, "Compile hyperparameter:"+ compileParams);
            }

            NNTrainerError ret = Interop.Model.Compile(handle, compileParams);
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
            string runParams = null;

            if (hyperparameter.Length > 0) {
                runParams = string.Join("|", hyperparameter);
                Log.Info(NNTrainer.Tag, "Run hyperparameter:"+ runParams);
            }

            NNTrainerError ret = Interop.Model.Run(handle, runParams);
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
        public void GetSummary(NNTrainerSummaryType verbosity, out string retSummary)
        {
            NNTrainerError ret = Interop.Model.GetSummary(handle, verbosity, out string summary);
            NNTrainer.CheckException(ret, "Failed to get summary");

            retSummary = summary;

        }

        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <remarks>
        /// Use this function to save the current model. format
        /// describes various formats in which various selections of the
        /// parameters of the models can be saved. Some formats may save
        /// parameters required for training. Some other formats may save model
        /// configurations. Unless stated otherwise, Compile() has to
        /// be called upon the a model before calling this function.
        /// Saved ini, if any, is not guaranteed to be identical to the original
        /// ini that maybe used to load the model.
        /// If you want to access only internal storage by using this function,
        /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
        /// want to access only external storage by using this function, you should add
        /// privilege %http://tizen.org/privilege/externalstorage. If you want to access
        /// both storage, you must add all the privileges.
        /// </remarks>
        /// <param name="filePath">File path to save the file.</param>
        /// <param name="format">Format flag to determine which format should be used to save.</param>
        /// <since_tizen> 10 </since_tizen>
        public void Save(string filePath, NNTrainerModelFormat format)
        {
            if (string.IsNullOrEmpty(filePath))
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "File path is null");
            Log.Info(NNTrainer.Tag, "File path: "+ filePath);
            NNTrainerError ret = Interop.Model.Save(handle, filePath, format);
            NNTrainer.CheckException(ret, "Failed to save model to path");
        }

        /// <summary>
        /// Loads the model.
        /// </summary>
        /// <remarks>
        /// Use this function to load the current model. format
        /// describes various formats in which various selections of the
        /// parameters of the models can be loaded. Some formats may load
        /// parameters required for training. Some other formats may load model
        /// configurations. Unless stated otherwise, loading model configuration requires
        /// a freshly constructed model with new model() without Compile(),
        /// loading model parameter requires Compile() to be called upon the model
        /// before calling this function.
        /// If you want to access only internal storage by using this function,
        /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
        /// want to access only external storage by using this function, you should add
        /// privilege %http://tizen.org/privilege/externalstorage. If you want to access
        /// both storage, you must add all the privileges.
        /// </remarks>
        /// <param name="filePath">File path to load the file.</param>
        /// <param name="format">Format flag to determine which format should be used to load.</param>
        /// <since_tizen> 10 </since_tizen>
        public void Load(string filePath, NNTrainerModelFormat format)
        {
            if (string.IsNullOrEmpty(filePath))
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "File path is null");
            Log.Info(NNTrainer.Tag, "File Path: "+ filePath);
            NNTrainerError ret = Interop.Model.Load(handle, filePath, format);
            NNTrainer.CheckException(ret, "Failed to load model to path");
        }

        /// <summary>
        /// Adds layer in neural network model.
        /// </summary>
        /// <remarks>
        /// Use this function to add a layer to the model. The layer is added to
        /// the end of the existing layers in the model. This transfers the
        /// ownership of the layer to the network. No need to destroy the layer once it
        /// is added to a model.
        /// </remarks>
        /// <param name="layer"> The instance of Layer class </param>
        /// <since_tizen> 10 </since_tizen>
        public void AddLayer(Layer layer)
        {
            if (layer == null)
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "layer instance is null");
            NNTrainerError ret = Interop.Model.AddLayer(handle, layer.GetHandle());
            NNTrainer.CheckException(ret, "Failed to compile model");
        }
    } 
}
