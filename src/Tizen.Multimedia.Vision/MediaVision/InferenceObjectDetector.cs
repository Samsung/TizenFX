/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading;
using System.Threading.Tasks;
using InteropOD = Interop.MediaVision.InferenceObjectDetection;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect object.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.inference</feature>
    /// <feature>http://tizen.org/feature/vision.inference.image</feature>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceObjectDetector : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>Initializes a new instance of the <see cref="InferenceObjectDetector"/> class.</summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceObjectDetector()
        {
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.Inference);
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceImage);

            InteropOD.Create(out _handle).Validate("Failed to create inference object detector.");

            try
            {
                InteropOD.Configure(_handle).Validate("Failed to configure inference object detector.");
                InteropOD.Prepare(_handle).Validate("Failed to prepare inference object detector.");
            }
            catch (Exception e)
            {
                Log.Error(MediaVisionLog.Tag, e.ToString());
                InteropOD.Destroy(_handle);
                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the InferenceObjectDetector class.
        /// </summary>
        ~InferenceObjectDetector()
        {
            Dispose(false);
        }

        /// <summary>
        /// Detects object on the source image synchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected object, <see cref="InferenceObjectDetectorResult.BoundBox"/> will be empty.
        /// </remarks>
        /// <param name="source">The image data to detect object.</param>
        /// <returns>A label of detected object.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceObjectDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceObjectDetectorResult Inference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropOD.Inference(_handle, source.Handle).Validate("Failed to inference object detection.");

            return new InferenceObjectDetectorResult(_handle);
        }

        /// <summary>
        /// Detects object on the source image asynchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected object, <see cref="InferenceObjectDetectorResult.BoundBox"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceObjectDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect object.</param>
        /// <exception cref="ObjectDisposedException">The InferenceObjectDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public async Task<InferenceObjectDetectorResult> InferenceAsync(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropOD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference object detection.");

            return await Task.Factory.StartNew(() => new InferenceObjectDetectorResult(_handle),
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Requests to detect object on the given source image.<br/>
        /// </summary>
        /// <remarks>
        /// This API is not guranteed that inference is done when this method returns. The user can get the result by using <see cref="GetBoundBox"/>.<br/>
        /// And the user call this API again before the previous one is finished internally, API call will be ignored until the previous one is finished.<br/>
        /// If there's no detected object, <see cref="InferenceObjectDetectorResult.BoundBox"/> will be empty.<br/>
        /// Note that this API could use about twice as much memory as <see cref="InferenceObjectDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect object.</param>
        /// <exception cref="ObjectDisposedException">The InferenceObjectDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <seealso cref="GetBoundBox"/>
        /// <since_tizen> 12 </since_tizen>
        public void RequestInference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropOD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference object detection.");
        }

        /// <summary>
        /// Gets the bound box as a result of <see cref="RequestInference"/>.
        /// </summary>
        /// <remarks>
        /// If there's no detected object, <see cref="InferenceObjectDetectorResult.BoundBox"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceObjectDetector.Inference"/>.
        /// </remarks>
        /// <returns>A bound box of detected object.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceObjectDetector already has been disposed.</exception>
        /// <seealso cref="RequestInference"/>
        /// <since_tizen> 12 </since_tizen>
        public InferenceObjectDetectorResult GetBoundBox()
        {
            return new InferenceObjectDetectorResult(_handle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the InferenceObjectDetector.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }

                if (_handle != IntPtr.Zero)
                {
                    InteropOD.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the InferenceObjectDetector.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(MediaVisionLog.Tag, "InferenceObjectDetector handle is disposed.");
                throw new ObjectDisposedException(nameof(InferenceObjectDetector));
            }
        }
    }
}