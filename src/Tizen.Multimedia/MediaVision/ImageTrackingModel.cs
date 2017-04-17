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
using InteropModel = Tizen.Multimedia.Interop.MediaVision.ImageTrackingModel;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents the image tracking model interface.
    /// </summary>
    public class ImageTrackingModel : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTrackingModel"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        public ImageTrackingModel()
        {
            InteropModel.Create(out _handle).Validate("Failed to create FaceTrackingModel");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTrackingModel"/> class with the specified path.
        /// </summary>
        /// <remarks>
        /// Model have been saved by <see cref="Save()"/> can be loaded.
        /// </remarks>
        /// <param name="modelPath">Path to the model to load.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelPath"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="modelPath"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.\n
        ///     - or -\n
        ///     <paramref name="modelPath"/> is not supported format.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access the specified file.</exception>
        /// <seealso cref="Save()"/>
        public ImageTrackingModel(string modelPath)
        {
            if (modelPath == null)
            {
                throw new ArgumentNullException(nameof(modelPath));
            }
            InteropModel.Load(modelPath, out _handle).Validate("Failed to load ImageTrackingModel from file");
        }

        ~ImageTrackingModel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sets target of image tracking model.\n
        /// Sets image object which will be tracked by using tracking functionality with this tracking model.
        /// </summary>
        /// <param name="imageObject">Image object which will be set as the target for tracking.</param>
        /// <exception cref="ArgumentNullException"><paramref name="imageObject"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="ImageTrackingModel"/> has already been disposed of.\n
        ///     - or -\n
        ///     <paramref name="imageObject"/> has already been disposed of.
        /// </exception>
        public void SetTarget(ImageObject imageObject)
        {
            if (imageObject == null)
            {
                throw new ArgumentNullException(nameof(imageObject));
            }

            InteropModel.SetTarget(imageObject.Handle, Handle).
                Validate("Failed to set target of image tracking model");
        }

        /// <summary>
        /// Refreshes the state of image tracking model.\n
        /// Clears moving history and change state to undetected. It is usually called each time before tracking is started
        /// for the new sequence of sources which is not the direct continuation of the sequence for which tracking has been performed before.
        /// Tracking algorithm will try to find image by itself.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingModel"/> has already been disposed of.</exception>
        public void Refresh()
        {
            InteropModel.Refresh(Handle, IntPtr.Zero).Validate("Failed to refresh state");
        }

        /// <summary>
        /// Saves tracking model to the file.
        /// </summary>
        /// <param name="path">Path to the file to save the model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="UnauthorizedAccessException">No permission to write to the specified path.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTrackingModel"/> has already been disposed of.</exception>
        /// <exception cref="DirectoryNotFoundException">The directory for <paramref name="path"/> does not exist.</exception>
        public void Save(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(path);
            }

            var ret = InteropModel.Save(path, Handle);

            if (ret == MediaVisionError.InvalidPath)
            {
                throw new DirectoryNotFoundException($"The directory for the path({path}) does not exist.");
            }

            ret.Validate("Failed to save tracking model to file");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                    throw new ObjectDisposedException(nameof(ImageTrackingModel));
                }
                return _handle;
            }
        }
    }
}
