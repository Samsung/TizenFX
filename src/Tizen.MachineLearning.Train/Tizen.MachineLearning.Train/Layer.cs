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
    /// Creates a neural network layer.
    /// </summary>
    /// <remarks>
    /// Use this class to create neural network layer.
    /// layer must be released using Dispose(), if not added to a model.
    /// If added to a model by AddLayer method of Model, layer is available until the model is released. so
    /// Dispose() must never be used.
    /// </remarks>
    /// <feature>http://tizen.org/feature/machine_learning.training</feature>
    /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
    /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the method failed due to the wrong pipeline description or internal error.</exception>
    /// <since_tizen> 10 </since_tizen>
    public class Layer: IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// if false, model will be destroy layer handle
        private bool hasOwnership = true;

        /// <summary>
        /// Creates a neural network layer.
        /// </summary>
        /// <param name="type">The nntrainer layer type.</param>
        /// <since_tizen> 10 </since_tizen>
        public Layer(NNTrainerLayerType type)
        {
            NNTrainerError ret = Interop.Layer.Create(out handle, type);
            if (ret != NNTrainerError.None) {
                handle = IntPtr.Zero;
            }
            NNTrainer.CheckException(ret, "Failed to create model instance");
            Log.Info(NNTrainer.Tag, $"Create layer with type:{type}");
        }

        internal Layer(IntPtr handle, bool hasOwnership)
        {
            this.handle = handle;
            this.hasOwnership = hasOwnership;
        }

        /// <summary>
        /// Frees the neural network layer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <remarks>
        /// Use this method to destroy neural network layer. Fails if layer is owned by a model.
        /// </remarks>
        ~Layer()
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

            disposed = true;

            if (!hasOwnership){
                Log.Info(NNTrainer.Tag, "Cannot destroy layer already added in a Model. Model will destroy this layer");
                return;
            }

            // release unmanaged object
            if (handle != IntPtr.Zero)
            {
                // Destroy the neural network layer.
                NNTrainerError ret = Interop.Layer.Destroy(handle);
                if (ret != NNTrainerError.None)
                    Log.Error(NNTrainer.Tag, "Failed to destroy Layer instance");

                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Sets the neural network layer Property.
        /// </summary>
        /// <remarks>
        /// Use this method to set neural network layer Property.
        /// The input format of property must be 'key = value' format.
        /// </remarks>
        /// <param name="property">property for layer.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SetProperty(params string[] property)
        {
            string propertyParams = null;

            if (property.Length > 0) {
                propertyParams = string.Join("|", property);
                Log.Info(NNTrainer.Tag, "Set property:"+ propertyParams);
            }

            NNTrainerError ret = Interop.Layer.SetProperty(handle, propertyParams);
            NNTrainer.CheckException(ret, "Failed to set property");
        }

        internal IntPtr GetHandle()
        {
            return handle;
        }

        internal void RemoveOwnership()
        {
            this.hasOwnership = false;
        }
    } 
}
