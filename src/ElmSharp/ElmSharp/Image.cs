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
using System.Threading;
using System.Threading.Tasks;

namespace ElmSharp
{
    /// <summary>
    /// The Image is a widget that allows one to load and display an image file on it,
    /// be it from a disk file or from a memory region.
    /// Inherits Widget.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Image : Widget
    {
        bool _canScaleUp = true;
        bool _canScaleDown = true;
        SmartEvent _clicked;
        Color _color = Color.Default;

        EvasImage _imageObject = null;

        /// <summary>
        /// Creates and initializes a new instance of the Image class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the image as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public Image(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Clicked will be triggered when the image is clicked.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Clicked;

        /// <summary>
        /// LoadingCompleted will be triggered when the image is loaded completely.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler LoadingCompleted;

        /// <summary>
        /// Clicked will be triggered when the image fails to load.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler LoadingFailed;

        /// <summary>
        /// Gets the file that is used as an image.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string File
        {
            get
            {
                return Interop.Elementary.elm_image_file_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets the smooth effect for an image.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsSmooth
        {
            get
            {
                return Interop.Elementary.elm_image_smooth_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_smooth_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether scaling is disabled on the object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsScaling
        {
            get
            {
                return !Interop.Elementary.elm_image_no_scale_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_no_scale_set(RealHandle, !value);
            }
        }

        /// <summary>
        /// Sets or gets whether the object is down resizable.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool CanScaleDown
        {
            get
            {
                return _canScaleDown;
            }
            set
            {
                _canScaleDown = value;
                Interop.Elementary.elm_image_resizable_set(RealHandle, _canScaleUp, _canScaleDown);
            }
        }

        /// <summary>
        /// Sets or gets whether the object is up resizable.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool CanScaleUp
        {
            get
            {
                return _canScaleUp;
            }
            set
            {
                _canScaleUp = value;
                Interop.Elementary.elm_image_resizable_set(RealHandle, _canScaleUp, _canScaleDown);
            }
        }

        /// <summary>
        /// Sets or gets whether the image fills the entire object area, when keeping the aspect ratio.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool CanFillOutside
        {
            get
            {
                return Interop.Elementary.elm_image_fill_outside_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_fill_outside_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the prescale size for the image.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int PrescaleSize
        {
            get
            {
                return Interop.Elementary.elm_image_prescale_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_prescale_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the original aspect ratio of the image should be kept on resize.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsFixedAspect
        {
            get
            {
                return Interop.Elementary.elm_image_aspect_fixed_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_aspect_fixed_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether an image object (which supports animation) is to animate itself.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsAnimated
        {
            get
            {
                return Interop.Elementary.elm_image_animated_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_animated_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets whether an image object supports animation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsAnimatedAvailable
        {
            get
            {
                return Interop.Elementary.elm_image_animated_available_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets whether an image object is under animation.
        /// </summary>
        /// <remarks>
        /// An image object, even if it supports animation, will be displayed by default without animation.
        /// To actually start playing any image object's animation, <see cref="IsAnimated"/> should be TRUE before setting this property true.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool IsAnimationPlaying
        {
            get
            {
                return Interop.Elementary.elm_image_animated_play_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_animated_play_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the image is 'editable'.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_image_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the current size of the image.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size ObjectSize
        {
            get
            {
                Interop.Elementary.elm_image_object_size_get(RealHandle, out int w, out int h);
                return new Size(w, h);
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
                if (ImageObject != null)
                {
                    return ImageObject.IsOpaque;
                }
                return false;
            }
            set
            {
                if (ImageObject != null)
                {
                    ImageObject.IsOpaque = value;
                }
            }
        }

        /// <summary>
        /// Sets or gets the image orientation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ImageOrientation Orientation
        {
            get
            {
                return (ImageOrientation)Interop.Elementary.elm_image_orient_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_image_orient_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the image color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (ImageObject != null)
                {
                    if (value.IsDefault)
                    {
                        ImageObject.Color = Color.FromRgba(255, 255, 255, 255);
                    }
                    else
                    {
                        ImageObject.Color = value;
                    }
                }
                _color = value;
            }
        }

        /// <summary>
        /// Sets the background color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color BackgroundColor
        {
            set
            {
                if (value.IsDefault)
                {
                    SetPartColor("bg", Color.Transparent);
                }
                else
                {
                    SetPartColor("bg", value);
                }
                _backgroundColor = value;
            }
        }

        /// <summary>
        /// Gets the inlined image object of the image widget.
        /// This property allows one to get the underlying EvasObject of type Image from this elementary widget. It can be useful to do things like save the image to a file, etc.
        /// </summary>
        /// <remarks>Be careful not to manipulate it, as it is under the control of the widget.</remarks>
        /// <since_tizen> preview </since_tizen>
        public EvasImage ImageObject
        {
            get
            {
                if (_imageObject == null)
                {
                    IntPtr evasObj = Interop.Elementary.elm_image_object_get(RealHandle);
                    if (evasObj != IntPtr.Zero)
                    {
                        _imageObject = new EvasImage(this, evasObj);
                        _imageObject.Deleted += (s, e) => _imageObject = null;
                    }
                }
                return _imageObject;
            }
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
            ImageObject?.SetBorder(left, right, top, bottom);
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
                if (ImageObject != null)
                {
                    return ImageObject.BorderCenterFillMode;
                }
                else
                {
                    return default(ImageBorderFillMode);
                }

            }
            set
            {
                if (ImageObject != null)
                {
                    ImageObject.BorderCenterFillMode = value;
                }
            }
        }

        /// <summary>
        /// Sets the file that is used as the image's source.
        /// </summary>
        /// <param name="file">The path to the file that is used as an image source.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public bool Load(string file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            Interop.Elementary.elm_image_async_open_set(RealHandle, false);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, true);
            return Interop.Elementary.elm_image_file_set(RealHandle, file, null);
        }

        /// <summary>
        /// Sets the URI that is used as the image's source.
        /// </summary>
        /// <param name="uri">The URI to the file that is used as an image source.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public bool Load(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            return Load(uri.IsFile ? uri.LocalPath : uri.AbsoluteUri);
        }

        /// <summary>
        /// Sets a location in the memory to be used as an image object's source bitmap.
        /// </summary>
        /// <remarks>
        /// This function is handy when the contents of an image file are mapped into the memory, for example,
        /// the format string should be something like "png", "jpg", "tga", "tiff", "bmp" etc, when provided (null, on the contrary).
        /// This improves the loader performance as it tries the "correct" loader first, before trying a range of other possible loaders until one succeeds.
        /// </remarks>
        /// <param name="img">The binary data that is used as an image source.</param>
        /// <param name="size">The size of the binary data blob img.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("This method will be removed. Use Load(Stream stream) instead.")]
        public unsafe bool Load(byte* img, long size)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            Interop.Elementary.elm_image_async_open_set(RealHandle, false);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, true);
            return Interop.Elementary.elm_image_memfile_set(RealHandle, img, size, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Sets the stream that is used as the image's source.
        /// </summary>
        /// <param name="stream">The stream that is used as an image source.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public bool Load(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            Interop.Elementary.elm_image_async_open_set(RealHandle, false);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, true);
            MemoryStream memstream = new MemoryStream();
            stream.CopyTo(memstream);
            unsafe
            {
                byte[] dataArr = memstream.ToArray();
                fixed (byte* data = &dataArr[0])
                {
                    return Interop.Elementary.elm_image_memfile_set(RealHandle, data, dataArr.Length, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// Sets the file that is used as the image's source with async.
        /// </summary>
        /// <param name="file">The path to the file that is used as an image source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public Task<bool> LoadAsync(string file, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (file == null)
                throw new ArgumentNullException("file");

            Interop.Elementary.elm_image_async_open_set(RealHandle, true);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, false);

            var tcs = new TaskCompletionSource<bool>();

            cancellationToken.Register(() =>
            {
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetCanceled();
                }
            });

            SmartEvent loadReady = new SmartEvent(this, RealHandle, "load,ready");
            loadReady.On += (s, e) =>
            {
                loadReady.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(true);
                }
            };

            SmartEvent loadError = new SmartEvent(this, RealHandle, "load,error");
            loadError.On += (s, e) =>
            {
                loadError.Dispose();
                LoadingFailed?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(false);
                }
            };

            bool ret = Interop.Elementary.elm_image_file_set(RealHandle, file, null);
            if (!ret)
            {
                throw new InvalidOperationException("Failed to set file to Image");
            }

            return tcs.Task;
        }

        /// <summary>
        /// Sets the URI that is used as the image's source with async.
        /// </summary>
        /// <param name="uri">The URI to the file that is used as an image source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public Task<bool> LoadAsync(Uri uri, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            return LoadAsync(uri.IsFile ? uri.LocalPath : uri.AbsoluteUri, cancellationToken);
        }

        /// <summary>
        /// Sets the stream that is used as the image's source with async.
        /// </summary>
        /// <param name="stream">The stream that is used as an image source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>(true = success, false = error)</returns>
        /// <since_tizen> preview </since_tizen>
        public async Task<bool> LoadAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            Interop.Elementary.elm_image_async_open_set(RealHandle, true);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, false);

            var tcs = new TaskCompletionSource<bool>();

            cancellationToken.Register(() =>
            {
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetCanceled();
                }
            });

            SmartEvent loadReady = new SmartEvent(this, RealHandle, "load,ready");
            loadReady.On += (s, e) =>
            {
                loadReady.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(true);
                }
            };

            SmartEvent loadError = new SmartEvent(this, RealHandle, "load,error");
            loadError.On += (s, e) =>
            {
                loadError.Dispose();
                LoadingFailed?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(false);
                }
            };

            using (MemoryStream memstream = new MemoryStream())
            {
                await stream.CopyToAsync(memstream);

                unsafe
                {
                    byte[] dataArr = memstream.ToArray();
                    fixed (byte* data = &dataArr[0])
                    {
                        bool ret = Interop.Elementary.elm_image_memfile_set(RealHandle, data, dataArr.Length, IntPtr.Zero, IntPtr.Zero);
                        if (!ret)
                        {
                            return false;
                        }
                    }
                }
            }

            return await tcs.Task;
        }

        /// <summary>
        /// Sets the color of the Color class for a given widget.
        /// </summary>
        /// <param name="part">The name of the Color class.</param>
        /// <param name="color">The struct of the Color class.</param>
        /// <since_tizen> preview </since_tizen>
        public override void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        /// <summary>
        /// Gets the color of the Color class for a given widget.
        /// </summary>
        /// <param name="part">The name of the Color class.</param>
        /// <returns>The color object.</returns>
        /// <since_tizen> preview </since_tizen>
        public override Color GetPartColor(string part)
        {
            Interop.Elementary.elm_object_color_class_color_get(Handle, part, out int r, out int g, out int b, out int a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        /// <summary>
        /// Sets the content at a part of a given container widget.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the image as a child. It's <see cref="EvasObject"/> type.</param>
        /// <returns>The new object, otherwise null if it cannot be created.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_image_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }

    /// <summary>
    /// Enumeration for the fill mode of the image border.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ImageBorderFillMode
    {
        /// <summary>
        /// None mode of the image border.
        /// </summary>
        None,

        /// <summary>
        /// Default mode of the image border.
        /// </summary>
        Default,

        /// <summary>
        /// Solid mode of the image border.
        /// </summary>
        Solid,
    }

    /// <summary>
    /// Enumeration for the possible orientation options.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ImageOrientation : int
    {
        /// <summary>
        /// No orientation change.
        /// </summary>
        None = 0,

        /// <summary>
        /// Rotate 90 degrees clockwise.
        /// </summary>
        Rotate90,

        /// <summary>
        /// Rotate 180 degrees clockwise.
        /// </summary>
        Rotate180,

        /// <summary>
        /// Rotate 90 degrees counter-clockwise (i.e., 270 degrees clockwise).
        /// </summary>
        Rotate270,

        /// <summary>
        /// Flip the image horizontally.
        /// </summary>
        FlipHorizontal,

        /// <summary>
        /// Flip the image vertically.
        /// </summary>
        FlipVertical,

        /// <summary>
        /// Flip the image along the Y = (width - X) line (bottom-left to top-right).
        /// </summary>
        FlipTranspose,

        /// <summary>
        /// Flip the image along the Y = X line (top-left to bottom-right).
        /// </summary>
        FlipTransverse
    }
}