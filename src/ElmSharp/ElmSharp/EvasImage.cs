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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ElmSharp
{
    /// <summary>
    /// This group provides the functions for image objects.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EvasImage : EvasObject
    {
        EvasObject _source = null;
        EventHandler _pixelsGet;
        Interop.Evas.EvasImagePixelsGetCallback _pixelsGetCallback = null;
        IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Creates and initializes a new instance of the EvasImage class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by EvasImage as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public EvasImage(EvasObject parent) : base(parent)
        {
        }

        internal EvasImage(EvasObject parent, IntPtr handle) : base()
        {
            _handle = handle;
            Realize(parent);
        }

        /// <summary>
        /// PixelsGet will be triggered when the image object will ready to get pixels.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler PixelsGet
        {
            add
            {
                _pixelsGet += value;
                if (_pixelsGetCallback == null)
                {
                    _pixelsGetCallback = new Interop.Evas.EvasImagePixelsGetCallback((o, d) => _pixelsGet?.Invoke(this, EventArgs.Empty));
                    Interop.Evas.evas_object_image_pixels_get_callback_set(RealHandle, _pixelsGetCallback, IntPtr.Zero);
                }
            }
            remove
            {
                _pixelsGet -= value;
                if (_pixelsGet == null)
                {
                    Interop.Evas.evas_object_image_pixels_get_callback_set(RealHandle, null, IntPtr.Zero);
                    _pixelsGetCallback = null;
                }
            }
        }

        /// <summary>
        /// Sets or gets the source file from where an image object must fetch the real image data.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string File
        {
            get
            {
                string file, key;
                Interop.Evas.evas_object_image_file_get(RealHandle, out file, out key);
                return file;
            }
            set
            {
                Interop.Evas.evas_object_image_file_set(RealHandle, value, null);
            }
        }

        /// <summary>
        /// Sets or gets the source object to be visible.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsSourceVisible
        {
            get
            {
                return Interop.Evas.evas_object_image_source_visible_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_source_visible_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether an object is clipped by the source object's clipper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsSourceClipped
        {
            get
            {
                return Interop.Evas.evas_object_image_source_clip_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_source_clip_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets if the center part of the given image object (not the border) should be drawn.
        /// </summary>
        /// <remarks>
        /// When rendering, the image may be scaled to fit the size of the image object.
        /// This function sets if the center part of the scaled image is to be drawn or left completely blank, or forced to be solid.
        /// Very useful for frames and decorations.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ImageBorderFillMode BorderCenterFillMode
        {
            get
            {
                return (ImageBorderFillMode)Interop.Evas.evas_object_image_border_center_fill_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_border_center_fill_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets whether the image object's fill property should track the object's size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsFilled
        {
            get
            {
                return Interop.Evas.evas_object_image_filled_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_filled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the scaling factor (multiplier) for the borders of the image object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double BorderScale
        {
            get
            {
                return Interop.Evas.evas_object_image_border_scale_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_border_scale_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the size of the given image object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size Size
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_image_size_get(RealHandle, out w, out h);
                return new Size(w, h);
            }
            set
            {
                Interop.Evas.evas_object_image_size_set(RealHandle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Gets the row stride of the given image object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Stride
        {
            get
            {
                return Interop.Evas.evas_object_image_stride_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets whether the alpha channel data is being used on the given image object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsOpaque
        {
            get
            {
                return !Interop.Evas.evas_object_image_alpha_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_alpha_set(RealHandle, !value);
            }
        }

        /// <summary>
        /// Sets or gets whether to use a high-quality image scaling algorithm on the given image object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsSmoothScaled
        {
            get
            {
                return Interop.Evas.evas_object_image_smooth_scale_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_smooth_scale_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the colorspace of a given image of the canvas.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Colorspace Colorspace
        {
            get
            {
                return (Colorspace)Interop.Evas.evas_object_image_colorspace_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_image_colorspace_set(RealHandle, (Interop.Evas.ColorspaceType)value);
            }
        }

        /// <summary>
        /// Sets or gets the raw image data of the given image object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public IntPtr Data
        {
            get
            {
                return Interop.Evas.evas_object_image_data_get(RealHandle, true);
            }
            set
            {
                Interop.Evas.evas_object_image_data_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Mark whether the given image object is dirty and needs to request its pixels.
        /// </summary>
        /// <param name="geometry">The rectangle of the given image object that the image will be redrawn.</param>
        /// <since_tizen> 5 </since_tizen>
        public void UpdateData(Rect geometry)
        {
            Interop.Evas.evas_object_image_data_update_add(RealHandle, geometry.X, geometry.Y, geometry.Width, geometry.Height);
        }

        /// <summary>
        /// Mark a sub-region of the given image object to be redrawn.
        /// </summary>
        /// <param name="dirty">Whether the image is dirty. (needs to be redrawn)</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetPixelsDirty(bool dirty)
        {
            Interop.Evas.evas_object_image_pixels_dirty_set(RealHandle, dirty);
        }

        /// <summary>
        /// Sets how to fill an image object's drawing rectangle given the (real) image bound to it.
        /// </summary>
        /// <param name="geometry">The rectangle of the given image object that the image will be drawn to.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFill(Rect geometry)
        {
            Interop.Evas.evas_object_image_fill_set(RealHandle, geometry.X, geometry.Y, geometry.Width, geometry.Height);
        }

        /// <summary>
        /// Sets the source file from where an image object must fetch the real image data (it may be an Eet file, besides pure image ones).
        /// </summary>
        /// <param name="file">The image file path.</param>
        /// <param name="key">The image key in file (if its an Eet one), otherwise set null.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFile(string file, string key)
        {
            Interop.Evas.evas_object_image_file_set(RealHandle, file, key);
        }

        /// <summary>
        /// Sets the data for an image from the memory to be loaded.
        /// </summary>
        /// <param name="stream">memory stream</param>
        /// <since_tizen> preview </since_tizen>
        public void SetStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            MemoryStream memstream = new MemoryStream();
            stream.CopyTo(memstream);
            unsafe
            {
                byte[] dataArr = memstream.ToArray();
                fixed (byte* data = &dataArr[0])
                {
                    Interop.Evas.evas_object_image_memfile_set(RealHandle, data, dataArr.Length, IntPtr.Zero, IntPtr.Zero);
                }
            }
            memstream.Dispose();
        }

        /// <summary>
        /// Sets the source object on an image object to be used as a proxy.
        /// </summary>
        /// <param name="source">The proxy (image) object.</param>
        /// <returns>true if the source object is set successfully, otherwise false on error.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool SetSource(EvasObject source)
        {
            bool result = false;
            _source = source;
            result = Interop.Evas.evas_object_image_source_set(RealHandle, IntPtr.Zero);
            if (source != null)
                result = result && Interop.Evas.evas_object_image_source_set(RealHandle, source.Handle);
            return result;
        }

        /// <summary>
        /// Set the native surface of a given image of the canvas.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetNativeSurface(IntPtr surface)
        {
            Interop.Evas.evas_object_image_native_surface_set(RealHandle, surface);
        }

        /// <summary>
        /// Sets the dimensions for an image object's border, a region which is not scaled together with its center ever.
        /// </summary>
        /// <param name="left">The border's left width.</param>
        /// <param name="right">The border's right width.</param>
        /// <param name="top">The border's top width.</param>
        /// <param name="bottom">The border's bottom width.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetBorder(int left, int right, int top, int bottom)
        {
            Interop.Evas.evas_object_image_border_set(RealHandle, left, right, top, bottom);
        }

        /// <summary>
        /// Sets the content at a part of a given container widget.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the image as a child. It's <see cref="EvasObject"/> type.</param>
        /// <returns>The new object, otherwise null if it cannot be created.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return _handle != IntPtr.Zero ? _handle : Interop.Evas.evas_object_image_add(Interop.Evas.evas_object_evas_get(parent.Handle));
        }

        /// <summary>
        /// Delete callback.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected override void OnUnrealize()
        {
            if (_pixelsGetCallback != null)
            {
                Interop.Evas.evas_object_image_pixels_get_callback_set(RealHandle, null, IntPtr.Zero);
                _pixelsGetCallback = null;
            }
            base.OnUnrealize();
        }
    }
}