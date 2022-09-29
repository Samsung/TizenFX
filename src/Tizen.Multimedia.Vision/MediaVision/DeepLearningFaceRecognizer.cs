/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using InteropFace = Interop.MediaVision.FaceRecognition;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to recognize face based on previously registered face data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class DeepLearningFaceRecognizer : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed;

        /// <summary>Initializes a new instance of the <see cref="DeepLearningFaceRecognizer"/> class.</summary>
        /// <remarks>
        /// This class is different from <see cref="FaceRecognizer"/> in aspect of using internal machine learning algorithm.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required features are not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 10 </since_tizen>
        public DeepLearningFaceRecognizer()
        {
            ValidationUtil.ValidateFeatureSupported(VisionFeatures.FaceRecognition);

            InteropFace.Create(out _handle).Validate("Failed to create face recognizer");

            try
            {
                InteropFace.Prepare(_handle).Validate("Failed to prepare face recognizer");
            }
            catch (Exception e)
            {
                Log.Error(MediaVisionLog.Tag, e.ToString());
                InteropFace.Destroy(_handle);
                throw e;
            }
        }

        /// <summary>
        /// Finalizes an instance of the DeepLearningFaceRecognizer class.
        /// </summary>
        ~DeepLearningFaceRecognizer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Registers face data to internal database.
        /// </summary>
        /// <param name="source">The face data to register.</param>
        /// <param name="label">The name of face data.</param>
        /// <exception cref="ObjectDisposedException">The DeepLearningFaceRecognizer already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="label"/> is null.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <since_tizen> 10 </since_tizen>
        public void RegisterFace(MediaVisionSource source, string label)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            InteropFace.Register(_handle, source.Handle, label).Validate("Failed to register face data");
        }

        /// <summary>
        /// Unregisters face data from internal database.
        /// </summary>
        /// <param name="label">The name of face data.</param>
        /// <exception cref="ObjectDisposedException">The DeepLearningFaceRecognizer already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="label"/> is null.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <since_tizen> 10 </since_tizen>
        public void UnregisterFace(string label)
        {
            ValidateNotDisposed();

            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            InteropFace.Unregister(_handle, label).Validate("Failed to register face data");
        }

        /// <summary>
        /// Recognizes a face in by finding the closest match among the registered faces and returns the label of the found face.
        /// </summary>
        /// <remarks>
        /// If there's no recognized face, <see cref="DeepLearningFaceRecognitionResult.Label"/> will be <see cref="String.Empty"/>.
        /// </remarks>
        /// <param name="source">The face data to recognize.</param>
        /// <returns>A label of recognized face.</returns>
        /// <exception cref="ObjectDisposedException">The DeepLearningFaceRecognizer already has been disposed.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <since_tizen> 10 </since_tizen>
        public DeepLearningFaceRecognitionResult Recognize(MediaVisionSource source)
        {
            ValidateNotDisposed();

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var ret = InteropFace.Inference(_handle, source.Handle);
            if (ret == MediaVisionError.NoData)
            {
                Log.Info(MediaVisionLog.Tag, "There's no recognized face. It's not error.");
                return new DeepLearningFaceRecognitionResult(String.Empty);
            }
            else
            {
                ret.Validate("failed to recognize face");
            }

            InteropFace.GetLabel(_handle, out IntPtr label).Validate("Failed to get label");

            return new DeepLearningFaceRecognitionResult(Marshal.PtrToStringAnsi(label));
        }

        /// <summary>
        /// Releases the unmanaged resources used by the DeepLearningFaceRecognizer.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 10 </since_tizen>
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
                    InteropFace.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the DeepLearningFaceRecognizer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(MediaVisionLog.Tag, "DeepLearningFaceRecognizer handle is disposed.");
                throw new ObjectDisposedException(nameof(DeepLearningFaceRecognizer));
            }
        }
    }
}