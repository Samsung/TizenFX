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
using InteropFLD = Interop.MediaVision.InferenceFacialLandmarkDetection;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect facial landmark.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.inference</feature>
    /// <feature>http://tizen.org/feature/vision.inference.face</feature>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceFacialLandmarkDetector : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>Initializes a new instance of the <see cref="InferenceFacialLandmarkDetector"/> class.</summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFacialLandmarkDetector()
        {
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.Inference);
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceFace);

            InteropFLD.Create(out _handle).Validate("Failed to create inference facial landmark detector.");

            try
            {
                InteropFLD.Configure(_handle).Validate("Failed to configure inference facial landmark detector.");
                InteropFLD.Prepare(_handle).Validate("Failed to prepare inference facial landmark detector.");
            }
            catch (Exception e)
            {
                Log.Error(MediaVisionLog.Tag, e.ToString());
                InteropFLD.Destroy(_handle);
                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the InferenceFacialLandmarkDetector class.
        /// </summary>
        ~InferenceFacialLandmarkDetector()
        {
            Dispose(false);
        }

        /// <summary>
        /// Detects facial landmark on the source image synchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected facial landmark, <see cref="InferenceFacialLandmarkDetectorResult.Position"/> will be empty.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmark.</param>
        /// <returns>A label of detected facial landmark.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFacialLandmarkDetectorResult Inference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFLD.Inference(_handle, source.Handle).Validate("Failed to inference facial landmark detection.");

            return new InferenceFacialLandmarkDetectorResult(_handle);
        }

        /// <summary>
        /// Detects facial landmark on the source image asynchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected facial landmark, <see cref="InferenceFacialLandmarkDetectorResult.Position"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmark.</param>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public async Task<InferenceFacialLandmarkDetectorResult> InferenceAsync(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFLD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference facial landmark detection.");

            return await Task.Factory.StartNew(() => new InferenceFacialLandmarkDetectorResult(_handle),
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Requests to detect facial landmark on the given source image.<br/>
        /// </summary>
        /// <remarks>
        /// This API is not guranteed that inference is done when this method returns. The user can get the result by using <see cref="GetPosition"/>.<br/>
        /// And the user call this API again before the previous one is finished internally, API call will be ignored until the previous one is finished.<br/>
        /// If there's no detected facial landmark, <see cref="InferenceFacialLandmarkDetectorResult.Position"/> will be empty.<br/>
        /// Note that this API could use about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmark.</param>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <seealso cref="GetPosition"/>
        /// <since_tizen> 12 </since_tizen>
        public void RequestInference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFLD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference facial landmark detection.");
        }

        /// <summary>
        /// Gets the position as a result of <see cref="RequestInference"/>.
        /// </summary>
        /// <remarks>
        /// If there's no detected facial landmark, <see cref="InferenceFacialLandmarkDetectorResult.Position"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <returns>A position of detected facial landmark.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <seealso cref="RequestInference"/>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFacialLandmarkDetectorResult GetPosition()
        {
            return new InferenceFacialLandmarkDetectorResult(_handle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the InferenceFacialLandmarkDetector.
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
                    InteropFLD.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the InferenceFacialLandmarkDetector.
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
                Log.Error(MediaVisionLog.Tag, "InferenceFacialLandmarkDetector handle is disposed.");
                throw new ObjectDisposedException(nameof(InferenceFacialLandmarkDetector));
            }
        }
    }
}