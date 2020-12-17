/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.IO;
using InteropModel = Interop.MediaVision.FaceTrackingModel;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents the face tracking model.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
    /// <since_tizen> 4 </since_tizen>
    public class FaceTrackingModel : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceTrackingModel"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FaceTrackingModel()
        {
            InteropModel.Create(out _handle).Validate("Failed to create FaceTrackingModel.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceTrackingModel"/> class with the specified path.
        /// </summary>
        /// <remarks>
        /// Models saved by <see cref="Save(string)"/> can be loaded.
        /// </remarks>
        /// <param name="modelPath">Path to the model to load.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelPath"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="modelPath"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="modelPath"/> is not supported format.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access the specified file.</exception>
        /// <seealso cref="Save(string)"/>
        /// <since_tizen> 4 </since_tizen>
        public FaceTrackingModel(string modelPath)
        {
            if (modelPath == null)
            {
                throw new ArgumentNullException(nameof(modelPath));
            }
            InteropModel.Load(modelPath, out _handle).Validate("Failed to load FaceTrackingModel from file.");
        }

        /// <summary>
        /// Finalizes an instance of the FaceTrackingModel class.
        /// </summary>
        ~FaceTrackingModel()
        {
            Dispose(false);
        }

        private MediaVisionError InvokePrepare(MediaVisionSource source, Quadrangle region)
        {
            if (region != null)
            {
                var quad = region.ToMarshalable();
                return InteropModel.Prepare(Handle, IntPtr.Zero, source.Handle, ref quad);
            }

            return InteropModel.Prepare(Handle, IntPtr.Zero, source.Handle, IntPtr.Zero);
        }

        /// <summary>
        /// Initializes the tracking model by the location of the face to be tracked.
        ///
        /// It is usually called once after the tracking model is created, and each time before tracking
        /// is started for the new sequence of sources, which is not the direct continuation of
        /// the sequence for which tracking has been performed before. But, it is allowed to call it
        /// between tracking sessions to allow Media Vision start to track more accurately.
        /// </summary>
        /// <remarks>
        /// <paramref name="region"/> needs to be the position of the face to be tracked when called first time for the tracking model.
        /// <paramref name="region"/> is fitted to the valid region of <paramref name="source"/> if <paramref name="region"/> has invalid points.
        /// </remarks>
        /// <param name="source">The source where face location is specified.
        ///     Usually it is the first frame of the video or the first image in the continuous
        ///     image sequence planned to be used for tracking.</param>
        /// <param name="region">The region determining position of the face to be tracked on the source.
        ///     If null, then tracking model will try to find previously tracked face by itself.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="FaceTrackingModel"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="source"/> has already bean disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Prepare(MediaVisionSource source, Quadrangle region)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InvokePrepare(source, region).Validate("Failed to prepare tracking model.");
        }

        /// <summary>
        /// Saves the tracking model to the file.
        /// </summary>
        /// <param name="path">Path to the file to save the model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="UnauthorizedAccessException">No permission to write to the specified path.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="FaceTrackingModel"/> has already been disposed of.</exception>
        /// <exception cref="DirectoryNotFoundException">The directory for <paramref name="path"/> does not exist.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Save(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var ret = InteropModel.Save(path, Handle);

            if (ret == MediaVisionError.InvalidPath)
            {
                throw new DirectoryNotFoundException($"The directory for the path({path}) does not exist.");
            }

            ret.Validate("Failed to save tracking model to file");
        }

        /// <summary>
        /// Releases all the resources used by the <see cref="FaceTrackingModel"/> object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="FaceTrackingModel"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; otherwise false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            InteropModel.Destroy(_handle);
            _disposed = true;
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(FaceTrackingModel));
                }
                return _handle;
            }
        }
    }
}
