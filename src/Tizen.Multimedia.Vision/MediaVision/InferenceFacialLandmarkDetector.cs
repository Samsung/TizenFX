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
    /// Provides the ability to detect facial landmarks.
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
        /// Detects facial landmarks on the source image synchronously.
        /// </summary>
        /// <remarks>
        /// <see cref="InferenceFacialLandmarkDetectorResult.Points"/> can be empty, if there's no detected facial landmark.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmarks.</param>
        /// <returns>The coordinates of detected facial landmarks.</returns>
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
        /// Detects facial landmarks on the source image asynchronously.
        /// </summary>
        /// <remarks>
        /// <see cref="InferenceFacialLandmarkDetectorResult.Points"/> can be empty, if there's no detected facial landmark.<br/>
        /// This method uses about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmarks.</param>
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

        private ulong _requestId = 1;
        /// <summary>
        /// Requests detecting facial landmarks to get their points asynchronously.
        /// </summary>
        /// <remarks>
        /// This function does not guarantee that inference is done when this method returns. The user can get the result by using <see cref="GetRequestResults"/>.<br/>
        /// If the user calls this method again before the previous one is finished internally, the call will be ignored.<br/>
        /// <see cref="InferenceFacialLandmarkDetectorResult.Points"/> can be empty, if there's no detected facial landmark.<br/>
        /// Note that this method could use about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect facial landmarks.</param>
        /// <returns>The request ID that indicates the order of requests.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <seealso cref="GetRequestResults"/>
        /// <since_tizen> 12 </since_tizen>
        public ulong RequestInference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFLD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference facial landmark detection.");
            return _requestId++;
        }

        /// <summary>
        /// Gets the points as a result of <see cref="RequestInference"/>.
        /// </summary>
        /// <remarks>
        /// If there's no detected facial landmark, <see cref="InferenceFacialLandmarkDetectorResult.Points"/> will be empty.<br/>
        /// This method uses about twice as much memory as <see cref="InferenceFacialLandmarkDetector.Inference"/>.
        /// </remarks>
        /// <returns>The points of detected facial landmarks.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFacialLandmarkDetector already has been disposed.</exception>
        /// <seealso cref="RequestInference"/>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFacialLandmarkDetectorResult GetRequestResults()
        {
            ValidateNotDisposed();

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