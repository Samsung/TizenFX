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
using InteropPLD = Interop.MediaVision.InferencePoseLandmarkDetection;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect pose landmark.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.inference</feature>
    /// <feature>http://tizen.org/feature/vision.inference.face</feature>
    /// <since_tizen> 12 </since_tizen>
    public class InferencePoseLandmarkDetector : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>Initializes a new instance of the <see cref="InferencePoseLandmarkDetector"/> class.</summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferencePoseLandmarkDetector()
        {
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.Inference);
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceFace);

            InteropPLD.Create(out _handle).Validate("Failed to create inference pose landmark detector.");

            try
            {
                InteropPLD.Configure(_handle).Validate("Failed to configure inference pose landmark detector.");
                InteropPLD.Prepare(_handle).Validate("Failed to prepare inference pose landmark detector.");
            }
            catch (Exception e)
            {
                Log.Error(MediaVisionLog.Tag, e.ToString());
                InteropPLD.Destroy(_handle);
                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the InferencePoseLandmarkDetector class.
        /// </summary>
        ~InferencePoseLandmarkDetector()
        {
            Dispose(false);
        }

        /// <summary>
        /// Detects pose landmark on the source image synchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected pose landmark, <see cref="InferencePoseLandmarkDetectorResult.Point"/> will be empty.
        /// </remarks>
        /// <param name="source">The image data to detect pose landmark.</param>
        /// <returns>A label of detected pose landmark.</returns>
        /// <exception cref="ObjectDisposedException">The InferencePoseLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferencePoseLandmarkDetectorResult Inference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropPLD.Inference(_handle, source.Handle).Validate("Failed to inference pose landmark detection.");

            return new InferencePoseLandmarkDetectorResult(_handle);
        }

        /// <summary>
        /// Detects pose landmark on the source image asynchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected pose landmark, <see cref="InferencePoseLandmarkDetectorResult.Point"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferencePoseLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect pose landmark.</param>
        /// <exception cref="ObjectDisposedException">The InferencePoseLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public async Task<InferencePoseLandmarkDetectorResult> InferenceAsync(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropPLD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference pose landmark detection.");

            return await Task.Factory.StartNew(() => new InferencePoseLandmarkDetectorResult(_handle),
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Requests to detect pose landmark on the given source image.<br/>
        /// </summary>
        /// <remarks>
        /// This API is not guranteed that inference is done when this method returns. The user can get the result by using <see cref="GetPoint"/>.<br/>
        /// And the user call this API again before the previous one is finished internally, API call will be ignored until the previous one is finished.<br/>
        /// If there's no detected pose landmark, <see cref="InferencePoseLandmarkDetectorResult.Point"/> will be empty.<br/>
        /// Note that this API could use about twice as much memory as <see cref="InferencePoseLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect pose landmark.</param>
        /// <exception cref="ObjectDisposedException">The InferencePoseLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <seealso cref="GetPoint"/>
        /// <since_tizen> 12 </since_tizen>
        public void RequestInference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropPLD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference pose landmark detection.");
        }

        /// <summary>
        /// Gets the point as a result of <see cref="RequestInference"/>.
        /// </summary>
        /// <remarks>
        /// If there's no detected pose landmark, <see cref="InferencePoseLandmarkDetectorResult.Point"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferencePoseLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <returns>A point of detected pose landmark.</returns>
        /// <exception cref="ObjectDisposedException">The InferencePoseLandmarkDetector already has been disposed.</exception>
        /// <seealso cref="RequestInference"/>
        /// <since_tizen> 12 </since_tizen>
        public InferencePoseLandmarkDetectorResult GetPoint()
        {
            return new InferencePoseLandmarkDetectorResult(_handle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the InferencePoseLandmarkDetector.
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
                    InteropPLD.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the InferencePoseLandmarkDetector.
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
                Log.Error(MediaVisionLog.Tag, "InferencePoseLandmarkDetector handle is disposed.");
                throw new ObjectDisposedException(nameof(InferencePoseLandmarkDetector));
            }
        }
    }
}