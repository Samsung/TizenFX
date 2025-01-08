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
using Tizen.MachineLearning.Inference;
namespace Tizen.MachineLearning.Train
{
    /// <summary>
    /// Constructs the neural network model
    /// </summary>
    /// <remarks>
    /// Use this class to create neural network model.
    /// The Model class provides interfaces to construct, complle, run, adding layer
    /// and etc with neural networks.
    /// If you want to access only internal storage by using this method,
    /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
    /// want to access only external storage by using this method, you should add
    /// privilege %http://tizen.org/privilege/externalstorage. If you want to access
    /// both storage, you must add all the privileges.
    /// </remarks>
    /// <feature>http://tizen.org/feature/machine_learning.training</feature>
    /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
    /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have the required privilege.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the method failed due to the wrong pipeline description or internal error.</exception>
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
            if (ret != NNTrainerError.None) {
                handle = IntPtr.Zero;
            }
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
                if (ret != NNTrainerError.None)
                    Log.Error(NNTrainer.Tag, "Failed to destroy Model instance");
                handle = IntPtr.Zero;
            }
            disposed = true;
        }

        /// <summary>
        /// Compiles and finalizes the neural network model with the hyperparameter.
        /// </summary>
        /// <remarks>
        /// Use this method to initialize neural network model.Various
        /// hyperparameter can be set before compile the model. Once compiled,
        /// any modification to the properties of model or layers/dataset/optimizer in
        /// the model will be restricted. Further, addition of layers or changing the
        /// optimizer/dataset of the model will not be permitted.
        /// The input format of hyperparameter must be 'key = value' format.
        /// <param name="hyperparameter">Hyperparameter for train complie.</param>
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
        /// Use this method to train the compiled neural network model with
        /// the passed training hyperparameters. This method will return once the
        /// training, along with requested validation and testing, is completed.
        /// The input format of hyperparameter must be 'key = value' format.
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
        /// <param name="verbosity">Verbose level of the summary.</param>
        /// <returns>On return, a string value. The summary of the current model. Avoid logic to parse and exploit summary if possible.</returns>
        /// <since_tizen> 10 </since_tizen>
        public string GetSummary(NNTrainerSummaryType verbosity)
        {
            string retSummary;
            NNTrainerError ret = Interop.Model.GetSummary(handle, verbosity, out string summary);
            NNTrainer.CheckException(ret, "Failed to get summary");

            retSummary = summary;
            return retSummary;
        }

        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <remarks>
        /// Use this method to save the current model. Format
        /// describes various formats in which various selections of the
        /// parameters of the models can be saved. Some formats may save
        /// parameters required for training. Some other formats may save model
        /// configurations. Unless stated otherwise, <see cref="Compile"/> has to
        /// be called upon the a model before calling this method.
        /// Saved ini, if any, is not guaranteed to be identical to the original
        /// ini that might have been used to load the model.
        /// If you want to access only internal storage by using this method,
        /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
        /// want to access only external storage by using this method, you should add
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
        /// Use this method to load the current model. Format
        /// describes various formats in which various selections of the
        /// parameters of the models can be loaded. Some formats may load
        /// parameters required for training. Some other formats may load model
        /// configurations. Unless stated otherwise, loading model configuration requires
        /// a freshly constructed model with new Model() without <see cref="Compile"/>,
        /// loading model parameter requires Compile() to be called upon the model
        /// before calling this method.
        /// If you want to access only internal storage by using this method,
        /// you should add privilege %http://tizen.org/privilege/mediastorage. Or, if you
        /// want to access only external storage by using this method, you should add
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
        /// Use this method to add a layer to the model. The layer is added to
        /// the end of the existing layers in the model. This transfers the
        /// ownership of the layer to the network. No need to destroy the layer once it
        /// is added to a model. Layer is available until the model is released, so
        /// Dispose() must never be used.
        /// </remarks>
        /// <param name="layer"> The instance of Layer class </param>
        /// <since_tizen> 10 </since_tizen>
        public void AddLayer(Layer layer)
        {
            if (layer == null) {
                Log.Error(NNTrainer.Tag, "layer instance is null");
                throw new ArgumentNullException(nameof(layer));
            }

            //Model has ownership of layer;
            NNTrainerError ret = Interop.Model.AddLayer(handle, layer.GetHandle());
            NNTrainer.CheckException(ret, "Failed to add layer");
            layer.RemoveOwnership();

            Log.Info(NNTrainer.Tag, $"AddLayer:\n{layer.GetHandle()}");
        }

        /// <summary>
        /// Gets neural network layer from the model with the given name.
        /// </summary>
        /// <remarks>
        /// Use this method to get already created Neural Network Layer.
        /// The returned layer must not be deleted as it is owned by the model.
        /// layerName can be set by SetProperty method of Layer.
        /// Returned layer instance is different with same layerName, but internally the
        /// native layer handle is same.
        /// </remarks>
        /// <param name="layerName"> Name of the already created layer.</param>
        /// <returns>layer instance</returns>
        /// <since_tizen> 10 </since_tizen>
        public Layer GetLayer(string layerName)
        {
            IntPtr layerHandle = IntPtr.Zero;
            if (string.IsNullOrEmpty(layerName))
                NNTrainer.CheckException(NNTrainerError.InvalidParameter, "layerName is null");

            NNTrainerError ret = Interop.Model.GetLayer(handle, layerName, out layerHandle);
            NNTrainer.CheckException(ret, "Failed to get layer");

            Layer layer = new Layer(layerHandle, false);
    
            return layer;
        }

        /// <summary>
        /// Sets the optimizer for the neural network model.
        /// </summary>
        /// <remarks>
        /// Use this method to set neural network optimizer. This transfers
        /// the ownership of the optimizer to the network. No need to destroy the
        /// optimizer if it is added to a model.
        /// </remarks>
        /// <param name="optimizer"> The instance of Optimizer class </param>
        /// <since_tizen> 10 </since_tizen>
        public void SetOptimizer(Optimizer optimizer)
        {
            if (optimizer == null) {
                Log.Error(NNTrainer.Tag, "optimizer instance is null");
                throw new ArgumentNullException(nameof(optimizer));
            }

            NNTrainerError ret = Interop.Model.SetOptimizer(handle, optimizer.GetHandle());
            NNTrainer.CheckException(ret, "Failed to set optimizer");
            optimizer.RemoveOwnership();
        }

        /// <summary>
        /// Sets the dataset (data provider) for the neural network model.
        /// </summary>
        /// <remarks>
        /// Use this method to set dataset for running the model. The dataset
        /// will provide training, validation and test data for the model. This transfers
        /// the ownership of the dataset to the network. No need to destroy the dataset
        /// once it is set to a model.
        /// Unsets the previously set dataset, if any. The previously set
        /// dataset must be freed using Dispose().
        /// </remarks>
        /// <param name="dataset"> The instance of Dataset class </param>
        /// <since_tizen> 10 </since_tizen>
        public void SetDataset(Dataset dataset)
        {
            if (dataset == null) {
                Log.Error(NNTrainer.Tag, "dataset instance is null");
                throw new ArgumentNullException(nameof(dataset));
            }

            NNTrainerError ret = Interop.Model.SetDataset(handle, dataset.GetHandle());
            NNTrainer.CheckException(ret, "Failed to set dataset");
            dataset.RemoveOwnership();
        }

        internal static TensorsInfo CreateTensorsInfoFormHandle(IntPtr handle)
        {
            const int RankLimit = 16;
            NNTrainerError ret = NNTrainerError.None;
            int count;

            ret = Interop.Model.GetTensorsCount(handle, out count);
            NNTrainer.CheckException(ret, "Failed to get count of Tensors");

            TensorsInfo retInfo = new TensorsInfo();
            for (int i = 0; i <count; ++i)
            {
                string name;
                TensorType type;
                uint[] dim = new uint[RankLimit];

                ret = Interop.Model.GetTensorName(handle, i, out name);
                NNTrainer.CheckException(ret, "Failed to get name of Tensors");

                ret = Interop.Model.GetTensorType(handle, i, out type);
                NNTrainer.CheckException(ret, "Failed to get type of Tensors");

                ret = Interop.Model.GetTensorDimension(handle, i, dim);
                NNTrainer.CheckException(ret, "Failed to get dimensionpe of Tensors");

                Log.Error("MLT", $"count:{count} name:{name} type:{type}");
                retInfo.AddTensorInfo(name, type, (int[])(object)dim);
            }
            return retInfo;
        }

        /// <summary>
        /// Gets output tensors information of the model.
        /// </summary>
        /// <remarks>
        /// Use this method to get output tensors information of the model.
        /// Model must be compiled before calling this method.
        /// </remarks>
        /// <returns>TensorsInfo instance</returns>
        /// <since_tizen> 10 </since_tizen>
        public TensorsInfo GetOutputTensorsInfo()
        {
            IntPtr tensorsInfoHandle = IntPtr.Zero;

            NNTrainerError ret = Interop.Model.GetOutputTensorsInfo(handle, out tensorsInfoHandle);
            NNTrainer.CheckException(ret, "Failed to get output tensors info");

            return CreateTensorsInfoFormHandle(tensorsInfoHandle);
        }

        /// <summary>
        /// Gets input tensors information of the model.
        /// </summary>
        /// <remarks>
        /// Use this method to get input tensors information of the model.
        /// Model must be compiled before calling this method.
        /// </remarks>
        /// <returns>TensorsInfo instance</returns>
        /// <since_tizen> 10 </since_tizen>
        public TensorsInfo GetInputTensorsInfo()
        {
            IntPtr tensorsInfoHandle = IntPtr.Zero;

            NNTrainerError ret = Interop.Model.GetInputTensorsInfo(handle, out tensorsInfoHandle);
            NNTrainer.CheckException(ret, "Failed to get input tensors info");

            return CreateTensorsInfoFormHandle(tensorsInfoHandle);
        }
    } 
}
