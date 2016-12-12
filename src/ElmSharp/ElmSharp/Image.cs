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
    public class Image : Widget
    {
        bool _canScaleUp = true;
        bool _canScaleDown = true;
        SmartEvent _clicked;

        public Image(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Clicked;
        public event EventHandler LoadingCompleted;
        public event EventHandler LoadingFailed;

        public string File
        {
            get
            {
                return Interop.Elementary.elm_image_file_get(RealHandle);
            }
        }

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

        public bool IsAnimatedAvailable
        {
            get
            {
                return Interop.Elementary.elm_image_animated_available_get(RealHandle);
            }
        }

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

        public Size ObjectSize
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_image_object_size_get(RealHandle, out w, out h);
                return new Size(w, h);
            }
        }

        public bool IsOpaque
        {
            get
            {
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(RealHandle);
                if (evasObj != IntPtr.Zero)
                {
                    return !Interop.Evas.evas_object_image_alpha_get(evasObj);
                }
                return false;
            }
            set
            {
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(RealHandle);
                if (evasObj != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_image_alpha_set(evasObj, !value);
                }
            }
        }

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

        public override Color Color
        {
            get
            {
                int r = 255, g = 255, b = 255, a = 255;
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(RealHandle);
                if (evasObj != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_color_get(evasObj, out r, out g, out b, out a);
                }
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(RealHandle);
                if (evasObj != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_color_set(evasObj, value.R, value.G, value.B, value.A);
                }
            }
        }

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

        public bool Load(string file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            Interop.Elementary.elm_image_async_open_set(RealHandle, false);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, true);
            return Interop.Elementary.elm_image_file_set(RealHandle, file, null);
        }

        public bool Load(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            return Load(uri.IsFile ? uri.LocalPath : uri.AbsoluteUri);
        }

        [CLSCompliant(false)]
        [Obsolete("This method will be removed. Use Load(Stream stream) instead.")]
        public unsafe bool Load(byte* img, long size)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            Interop.Elementary.elm_image_async_open_set(RealHandle, false);
            Interop.Elementary.elm_image_preload_disabled_set(RealHandle, true);
            return Interop.Elementary.elm_image_memfile_set(RealHandle, img, size, IntPtr.Zero, IntPtr.Zero);
        }

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

            SmartEvent loadReady = new SmartEvent(this, Handle, "load,ready");
            loadReady.On += (s, e) =>
            {
                loadReady.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(true);
                }
            };

            SmartEvent loadError = new SmartEvent(this, Handle, "load,error");
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

        public Task<bool> LoadAsync(Uri uri, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            return LoadAsync(uri.IsFile ? uri.LocalPath : uri.AbsoluteUri, cancellationToken);
        }

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

            SmartEvent loadReady = new SmartEvent(this, Handle, "load,ready");
            loadReady.On += (s, e) =>
            {
                loadReady.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(true);
                }
            };

            SmartEvent loadError = new SmartEvent(this, Handle, "load,error");
            loadError.On += (s, e) =>
            {
                loadError.Dispose();
                LoadingFailed?.Invoke(this, EventArgs.Empty);
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(false);
                }
            };

            MemoryStream memstream = new MemoryStream();
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

            return await tcs.Task;
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_image_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }

    public enum ImageOrientation : int
    {
        None = 0,
        Rotate90,
        Rotate180,
        Rotate270,
        FlipHorizontal,
        FlipVertical,
        FlipTranspose,
        FlipTransverse
    }
}
