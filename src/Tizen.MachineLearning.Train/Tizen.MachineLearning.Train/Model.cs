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
    } 
}
