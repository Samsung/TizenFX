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
    /// Use this function to create neural network layer.
    /// If the function succeeds, layer must be released using Destroy(), if not added to a model.
    /// If added to a model, layer is available until the model is released.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
    public class Layer: IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// Creates a neural network layer.
        /// </summary>
        /// <param name="type">The nntrainer layer type.</param>
        /// <since_tizen> 10 </since_tizen>
        public Layer(NNTrainerLayerType type)
        {
            NNTrainerError ret = Interop.Layer.Create(out handle, type);
            NNTrainer.CheckException(ret, "Failed to create model instance");
        }
        /// <summary>
        /// Frees the neural network layer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <remarks>
        /// Use this function to destroy neural network layer. Fails if layer is owned by a model.
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
            // release unmanaged object
            if (handle != IntPtr.Zero)
            {
                // Destroy the neural network layer.
                NNTrainerError ret = Interop.Layer.Destroy(handle);
                NNTrainer.CheckException(ret, "Failed to destroy layer instance");

                handle = IntPtr.Zero;
            }
            disposed = true;
        }
    } 
}
