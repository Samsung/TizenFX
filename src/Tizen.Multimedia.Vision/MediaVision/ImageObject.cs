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
using InteropImage = Interop.MediaVision.Image;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents an image object.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.image_recognition</feature>
    /// <since_tizen> 4 </since_tizen>
    public class ImageObject : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageObject"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public ImageObject()
        {
            InteropImage.Create(out _handle).Validate("Failed to create image object");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageObject"/> class from the specified file.
        /// </summary>
        /// <remarks>
        /// ImageObject has been saved by <see cref="Save(string)"/> can be loaded.
        /// </remarks>
        /// <param name="path">Path to the image object to load.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">
        ///     The feature is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="path"/> is not supported file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">No permission to access the specified file.</exception>
        /// <seealso cref="Save(string)"/>
        /// <since_tizen> 4 </since_tizen>
        public ImageObject(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            InteropImage.Load(path, out _handle).Validate("Failed to load image object from file");
        }

        /// <summary>
        /// Finalizes an instance of the ImageObject class.
        /// </summary>
        ~ImageObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets a value that determines how well an image object can be recognized.
        /// </summary>
        /// <remarks>
        /// If recognition rate is too low, try to use another image or change some configuration parameters
        /// and fill the image object again.
        /// </remarks>
        /// <value>
        /// Recognition rate determines how well an image object can be recognized. This value can be from 0 to 1.
        /// If the recognition rate is 0 object can not be recognized and the bigger it is the more likely to recognize the object.
        /// </value>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageObject"/> has already been disposed of.</exception>
        /// <seealso cref="ImageFillConfiguration"/>
        /// <seealso cref="Fill(MediaVisionSource)"/>
        /// <seealso cref="Fill(MediaVisionSource, ImageFillConfiguration)"/>
        /// <seealso cref="Fill(MediaVisionSource, Rectangle)"/>
        /// <seealso cref="Fill(MediaVisionSource, ImageFillConfiguration, Rectangle)"/>
        /// <since_tizen> 4 </since_tizen>
        public double RecognitionRate
        {
            get
            {
                InteropImage.GetRecognitionRate(Handle, out var rate).Validate("Failed to get recognition rate");
                return rate;
            }
        }

        #region Methods
        /// <summary>
        /// Gets the label for the image object.
        /// </summary>
        /// <returns>
        /// The label value if the <see cref="ImageObject"/> has label, otherwise null.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageObject"/> has already been disposed of.</exception>
        /// <seealso cref="SetLabel(int)"/>
        /// <since_tizen> 4 </since_tizen>
        public int? GetLabel()
        {
            var ret = InteropImage.GetLabel(Handle, out var label);

            if (ret == MediaVisionError.NoData)
            {
                return null;
            }

            ret.Validate("Failed to get label");
            return label;
        }

        /// <summary>
        /// Sets the label for the <see cref="ImageObject"/>.
        /// </summary>
        /// <param name="label">The label which will be assigned to the image object.</param>
        /// <seealso cref="GetLabel"/>
        /// <since_tizen> 4 </since_tizen>
        public void SetLabel(int label)
        {
            InteropImage.SetLabel(Handle, label).Validate("Failed to set label");
        }

        /// <summary>
        /// Fills the image object.<br/>
        /// Extracts data from source image which will be needed for recognition of depicted object.
        /// </summary>
        /// <param name="source">The source image where image object is depicted.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="ImageObject"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="source"/> has already been disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Fill(MediaVisionSource source)
        {
            InvokeFill(source, null, null);
        }

        /// <summary>
        /// Fills the image object.<br/>
        /// Extracts data from source image which will be needed for recognition of depicted object.
        /// </summary>
        /// <param name="source">The source image where image object is depicted.</param>
        /// <param name="config">The configuration used for extract recognition data from source. This value can be null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="ImageObject"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Fill(MediaVisionSource source, ImageFillConfiguration config)
        {
            InvokeFill(source, config, null);
        }

        /// <summary>
        /// Fills the image object.<br/>
        /// Extracts data from source image which will be needed for recognition of depicted object
        /// in location.
        /// </summary>
        /// <param name="source">The source image where image object is depicted.</param>
        /// <param name="rect">Rectangular bound of the image object on the source image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="ImageObject"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="source"/> has already been disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Fill(MediaVisionSource source, Rectangle rect)
        {
            InvokeFill(source, null, rect);
        }

        /// <summary>
        /// Fills the image object.<br/>
        /// Extracts data from source image which will be needed for recognition of depicted object
        /// in location.
        /// </summary>
        /// <param name="source">The source image where image object is depicted.</param>
        /// <param name="config">The configuration used for extract recognition data from source. This value can be null.</param>
        /// <param name="rect">Rectangular bound of the image object on the source image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="ImageObject"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void Fill(MediaVisionSource source, ImageFillConfiguration config, Rectangle rect)
        {
            InvokeFill(source, config, rect);
        }

        private MediaVisionError InvokeFill(IntPtr source, IntPtr config, Rectangle? area)
        {
            if (area == null)
            {
                return InteropImage.Fill(Handle, config, source, IntPtr.Zero);
            }

            var rect = area.Value.ToMarshalable();

            return InteropImage.Fill(Handle, config, source, ref rect);
        }

        private void InvokeFill(MediaVisionSource source, ImageFillConfiguration config, Rectangle? area)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            InvokeFill(source.Handle, EngineConfiguration.GetHandle(config), area).
                Validate("Failed to fill the image object");
        }

        /// <summary>
        /// Saves the image object.
        /// </summary>
        /// <param name="path">Path to the file to save the model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="UnauthorizedAccessException">No permission to write to the specified path.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageObject"/> has already been disposed of.</exception>
        /// <exception cref="DirectoryNotFoundException">The directory for <paramref name="path"/> does not exist.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Save(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var ret = InteropImage.Save(path, Handle);

            if (ret == MediaVisionError.InvalidPath)
            {
                throw new DirectoryNotFoundException($"The directory for the path({path}) does not exist.");
            }

            ret.Validate("Failed to save the image object");
        }
        #endregion

        #region IDisposable-support

        /// <summary>
        /// Releases all the resources used by the <see cref="ImageObject"/> object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="ImageObject"/> object.
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

            InteropImage.Destroy(_handle);
            _disposed = true;
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(ImageObject));
                }
                return _handle;
            }
        }
        #endregion
    }
}
