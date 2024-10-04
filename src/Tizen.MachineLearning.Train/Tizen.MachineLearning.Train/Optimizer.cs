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
    /// Creates a neural network optimizer.
    /// </summary>
    /// <remarks>
    /// Use this class to create neural network optimizer. If not set to
    /// model, optimizer should be released using Dispose().
    /// If set to a model, optimizer is available until model is released.
    /// </remarks>
    /// <feature>http://tizen.org/feature/machine_learning.training</feature>
    /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
    /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the method failed due to the wrong pipeline description or internal error.</exception>
    /// <since_tizen> 10 </since_tizen>
    public class Optimizer: IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// if false, model will be destroy optimizer handle
        private bool hasOwnership = true;

        /// <summary>
        /// Creates a neural network optimizer.
        /// </summary>
        /// <param name="type">The nntrainer optimizer type.</param>
        /// <since_tizen> 10 </since_tizen>
        public Optimizer(NNTrainerOptimizerType type)
        {
            NNTrainerError ret = Interop.Optimizer.Create(out handle, type);
            if (ret != NNTrainerError.None) {
                handle = IntPtr.Zero;
            }
            NNTrainer.CheckException(ret, "Failed to create optimizer instance");
            Log.Info(NNTrainer.Tag, $"Create optimizer with type:{type}");
        }
        /// <summary>
        /// Frees the neural network optimizer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <remarks>
        /// Use this method to destroy neural network optimizer. Fails if layer is owned by a model.
        /// </remarks>
        ~Optimizer()
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
                Log.Info(NNTrainer.Tag, "Cannot destroy optimizer already added in a Model. Model will destroy this optimizer");
                return;
            }

            // release unmanaged object
            if (handle != IntPtr.Zero)
            {
                // Destroy optimizer.
                NNTrainerError ret = Interop.Optimizer.Destroy(handle);
                if (ret != NNTrainerError.None)
                    Log.Error(NNTrainer.Tag, "Failed to destroy Optimizer instance");

                handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Sets the neural network optimizer property
        /// </summary>
        /// <remarks>
        /// Use this method to set neural network optimizer property.
        /// The input format of property must be 'key = value' format.
        /// </remarks>
        /// <param name="property">property for optimizer.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SetProperty(params string[] property)
        {
            string propertyParams = null;

            if (property.Length > 0) {
                propertyParams = string.Join("|", property);
                Log.Info(NNTrainer.Tag, "Set property:"+ propertyParams);
            }

            NNTrainerError ret = Interop.Optimizer.SetProperty(handle, propertyParams);
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
