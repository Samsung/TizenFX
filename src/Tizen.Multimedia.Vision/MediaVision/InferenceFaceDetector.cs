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
using InteropFD = Interop.MediaVision.InferenceFaceDetection;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to detect face.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.inference</feature>
    /// <feature>http://tizen.org/feature/vision.inference.face</feature>
    /// <since_tizen> 12 </since_tizen>
    public class InferenceFaceDetector : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>Initializes a new instance of the <see cref="InferenceFaceDetector"/> class.</summary>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFaceDetector()
        {
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.Inference);
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.InferenceFace);

            InteropFD.Create(out _handle).Validate("Failed to create inference face detector.");

            try
            {
                InteropFD.Configure(_handle).Validate("Failed to configure inference face detector.");
                InteropFD.Prepare(_handle).Validate("Failed to prepare inference face detector.");
            }
            catch (Exception e)
            {
                Log.Error(MediaVisionLog.Tag, e.ToString());
                InteropFD.Destroy(_handle);
                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the InferenceFaceDetector class.
        /// </summary>
        ~InferenceFaceDetector()
        {
            Dispose(false);
        }

        /// <summary>
        /// Detects face on the source image synchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected face, <see cref="InferenceFaceDetectorResult.BoundBox"/> will be empty.
        /// </remarks>
        /// <param name="source">The image data to detect face.</param>
        /// <returns>A label of detected face.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFaceDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFaceDetectorResult Inference(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFD.Inference(_handle, source.Handle).Validate("Failed to inference face detection.");

            return new InferenceFaceDetectorResult(_handle);
        }

        /// <summary>
        /// Detects face on the source image asynchronously.
        /// </summary>
        /// <remarks>
        /// If there's no detected face, <see cref="InferenceFaceDetectorResult.BoundBox"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceFaceDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect face.</param>
        /// <exception cref="ObjectDisposedException">The InferenceFaceDetector already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <since_tizen> 12 </since_tizen>
        public async Task<InferenceFaceDetectorResult> InferenceAsync(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InteropFD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference face detection.");

            return await Task.Factory.StartNew(() => new InferenceFaceDetectorResult(_handle),
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Requests to detect face on the given source image.<br/>
        /// </summary>
        /// <remarks>
        /// This API is not guranteed that inference is done when this method returns. The user can get the result by using <see cref="GetBoundBox"/>.<br/>
        /// And the user call this API again before the previous one is finished internally, API call will be ignored until the previous one is finished.<br/>
        /// If there's no detected face, <see cref="InferenceFaceDetectorResult.BoundBox"/> will be empty.<br/>
        /// Note that this API could use about twice as much memory as <see cref="InferenceFaceDetector.Inference"/>.
        /// </remarks>
        /// <param name="source">The image data to detect face.</param>
        /// <exception cref="ObjectDisposedException">The InferenceFaceDetector already has been disposed.</exception>
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

            InteropFD.InferenceAsync(_handle, source.Handle).Validate("Failed to inference face detection.");
        }

        /// <summary>
        /// Gets the bound box as a result of <see cref="RequestInference"/>.
        /// </summary>
        /// <remarks>
        /// If there's no detected face, <see cref="InferenceFaceDetectorResult.BoundBox"/> will be empty.<br/>
        /// This API uses about twice as much memory as <see cref="InferenceFaceDetector.Inference"/>.
        /// </remarks>
        /// <returns>A bound box of detected face.</returns>
        /// <exception cref="ObjectDisposedException">The InferenceFaceDetector already has been disposed.</exception>
        /// <seealso cref="RequestInference"/>
        /// <since_tizen> 12 </since_tizen>
        public InferenceFaceDetectorResult GetBoundBox()
        {
            return new InferenceFaceDetectorResult(_handle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the InferenceFaceDetector.
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
                    InteropFD.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the InferenceFaceDetector.
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
                Log.Error(MediaVisionLog.Tag, "InferenceFaceDetector handle is disposed.");
                throw new ObjectDisposedException(nameof(InferenceFaceDetector));
            }
        }
    }
}