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
using System.Runtime.InteropServices;
using Tizen.Multimedia;
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents an interface for Image objects.
    /// </summary>
    public class Image : IDisposable
    {
        internal IntPtr _imageObjectHandle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Constructor of Image object class
        /// </summary>
        public Image()
        {
            int ret = Interop.MediaVision.Image.Create(out _imageObjectHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create image object");
        }

        /// <summary>
        /// Constructor of image object class
        /// </summary>
        /// <param name="fileName">Name of path/file to load the image object</param>
        public Image(string fileName)
        {
            int ret = Interop.MediaVision.Image.Load(fileName, out _imageObjectHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to load image object from file");
        }

        /// <summary>
        /// Destructor of ImageObject
        /// </summary>
        ~Image()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sets and gets a label for the image object
        /// </summary>
        public int Label
        {
            get
            {
                int label = 0;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.Image.GetLabel(_imageObjectHandle, out label);
                if (ret != MediaVisionError.None)
                {
                    Tizen.Log.Error(MediaVisionLog.Tag, "Failed to get label");
                }

                return label;
            }

            set
            {
                int ret = Interop.MediaVision.Image.SetLabel(_imageObjectHandle, value);
                MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to set label");
            }
        }

        /// <summary>
        /// Gets a value that determines how well an image object can be recognized.
        /// </summary>
        public double RecognitionRate
        {
            get
            {
                double rate = 0;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.Image.GetRecognitionRate(_imageObjectHandle, out rate);
                if (ret != MediaVisionError.None)
                {
                    Tizen.Log.Error(MediaVisionLog.Tag, "Failed to get recognition rate, error : " + ret);
                }

                return rate;
            }
        }

        /// <summary>
        /// Fills the image object.\n
        /// Extracts data from @a source image which will be needed for recognition of depicted object in @a location.
        /// </summary>
        /// <param name="source">The source image where image object is depicted</param>
        /// <param name="config">The configuration of engine which will be used for extract recognition data from source. If NULL, then default settings will be used.</param>
        /// <param name="location">Location of the image object on the source image, or NULL if the object is shown in full</param>
        public void Fill(MediaVisionSource source, ImageEngineConfiguration config = null, Rectangle location = null)
        {
            if (source == null)
            {
                throw new ArgumentException("Inalid source");
            }

            IntPtr locationPtr = IntPtr.Zero;
            if (location != null)
            {
                Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
                {
                    width = location.Width,
                    height = location.Height,
                    x = location.Point.X,
                    y = location.Point.Y
                };
                locationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(rectangle));
                Marshal.StructureToPtr(rectangle, locationPtr, false);
            }

            int ret = Interop.MediaVision.Image.Fill(_imageObjectHandle,
                                                    (config != null) ? config._engineHandle : IntPtr.Zero,
                                                    source._sourceHandle, locationPtr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to fill the image object");
        }

        /// <summary>
        /// Saves the image object.
        /// </summary>
        /// <param name="fileName">Name of the file to path/save the image object</param>
        public void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Inalid file name");
            }

            int ret = Interop.MediaVision.Image.Save(fileName, _imageObjectHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to save the image object");
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

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.Image.Destroy(_imageObjectHandle);
            _disposed = true;
        }
    }
}
