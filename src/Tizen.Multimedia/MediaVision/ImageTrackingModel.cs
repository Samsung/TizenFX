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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents image tracking model interface
    /// </summary>
    public class ImageTrackingModel
    {
        internal IntPtr _trackingModelHandle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Construct of ImageTrackingModel class
        /// </summary>
        public ImageTrackingModel()
        {
            int ret = Interop.MediaVision.ImageTrackingModel.Create(out _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create FaceTrackingModel.");
        }

        /// <summary>
        /// Construct of ImageTrackingModel class which creates and loads tracking model from file.
        /// </summary>
        /// <remarks>
        /// ImageTrackingModel is loaded from the absolute path directory.\n
        /// Models has been saved by <see cref="Save()"/> function can be loaded with this function
        /// </remarks>
        /// <param name="fileName">Name of path/file to load the model</param>
        /// <seealso cref="Save()"/>
        /// <seealso cref="Prepare()"/>
        /// <code>
        /// 
        /// </code>
        public ImageTrackingModel(string fileName)
        {
            int ret = Interop.MediaVision.ImageTrackingModel.Load(fileName, out _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to load ImageTrackingModel from file.");
        }

        /// <summary>
        /// Destructor of the ImageTrackingModel class.
        /// </summary>
        ~ImageTrackingModel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sets target of image tracking model.\n
        /// Sets image object which will be tracked by using tracking functionality with this tracking model.
        /// </summary>
        /// <param name="imageObject">Image object which will be set as target for tracking</param>
        public void SetTarget(Image imageObject)
        {
            if (imageObject == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            int ret = Interop.MediaVision.ImageTrackingModel.SetTarget(imageObject._imageObjectHandle, _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to set target of image tracking model");
        }

        /// <summary>
        /// Refreshes the state of image tracking model.\n
        /// Clears moving history and change state to undetected. This function is usually called each time before tracking is started
        /// for the new sequence of sources which is not the direct continuation of the sequence for which tracking has been performed before.
        /// Tracking algorithm will try to find image by itself.
        /// </summary>
        /// <param name="config">Image engine configuration. If null, default configuration will be used</param>
        public void Refresh(ImageEngineConfiguration config = null)
        {
            int ret = Interop.MediaVision.ImageTrackingModel.Refresh(_trackingModelHandle, (config != null) ? config._engineHandle : IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to refresh state");
        }

        /// <summary>
        /// Calls this method to save tracking model to the file.
        /// </summary>
        /// <remarks>
        /// TrackingModel is saved to the absolute path directory.
        /// </remarks>
        /// <param name="fileName">Name of the path/file to save the model</param>
        public void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Invalid file name");
            }

            int ret = Interop.MediaVision.ImageTrackingModel.Save(fileName, _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to save tracking model to file");
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.ImageTrackingModel.Destroy(_trackingModelHandle);
            _disposed = true;
        }
    }
}
