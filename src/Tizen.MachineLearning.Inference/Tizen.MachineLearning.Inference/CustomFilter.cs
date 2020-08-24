/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd. All Rights Reserved.
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
using System.Collections.Generic;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The CustomFilter class provides interfaces to create a custom-filter in the pipeline.
    /// </summary>
    /// <remarks>
    /// Because of data translation (i.e. marshaling and unmarshaling ) between Native and .Net Layer, CustomFilter class shows lower performance than native implementation.
    /// </remarks>
    /// <since_tizen> 8 </since_tizen>
    public class CustomFilter : IDisposable
    {
        private Interop.Pipeline.CustomEasyInvokeCallback _nativeCallback;
        private Func<TensorsData, TensorsData> _filter;

        private TensorsInfo _InInfo;
        private TensorsInfo _OutInfo;
        private bool _disposed = false;

        /// <summary>
        /// Internally gets and sets the the native handle of custom filter.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        internal IntPtr Handle { get; set; }

        /// <summary>
        /// Gets or internally sets the name of the CustomFilter
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Creates new custom-filter with input and output tensors information.
        /// </summary>
        /// <param name="name">The name of custom-filter</param>
        /// <param name="inInfo">The input tensors information</param>
        /// <param name="outInfo">The output tensors information</param>
        /// <param name="filter">Delegate to be called while processing the pipeline</param>
        /// <returns>CustomFiter instance</returns>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static CustomFilter Create(string name,
            TensorsInfo inInfo, TensorsInfo outInfo, Func<TensorsData, TensorsData> filter)
        {
            NNStreamer.CheckNNStreamerSupport();

            return new CustomFilter(name, inInfo, outInfo, filter);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object including opened handle.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 8 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // release managed objects
            }

            // release unmanaged objects
            if (Handle != IntPtr.Zero)
            {
                NNStreamerError ret = Interop.Pipeline.UnregisterCustomFilter(Handle);
                if (ret != NNStreamerError.None)
                    Log.Error(NNStreamer.TAG, "failed to destroy CustomFilter object");

                Handle = IntPtr.Zero;
            }
            _disposed = true;
        }

        private CustomFilter(string name, TensorsInfo inInfo, TensorsInfo outInfo, Func<TensorsData, TensorsData> filter)
        {
            /* Parameger check */
            if (name == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Given name is null");

            if (inInfo == null || outInfo == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Given TensorsInfo is null");

            if (filter == null)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Given Callback interface is null");

            _nativeCallback = (in_data_handle, out_data_handle, _) =>
            {
                TensorsData inData = TensorsData.CreateFromNativeHandle(in_data_handle, IntPtr.Zero, true, false);
                TensorsData outData = _filter(inData);
                out_data_handle = outData.GetHandle();
            };

            IntPtr handle = IntPtr.Zero;

            /* Create custom filter callback */
            NNStreamerError ret = Interop.Pipeline.RegisterCustomFilter(name,
                inInfo.GetTensorsInfoHandle(), outInfo.GetTensorsInfoHandle(), _nativeCallback, IntPtr.Zero, out handle);
            NNStreamer.CheckException(ret, "Failed to create custom filter function: " + name);

            /* Set internal member */
            _InInfo = inInfo;
            _OutInfo = outInfo;
            _filter = filter;

            Name = name;
            Handle = handle;
        }
    }
}
