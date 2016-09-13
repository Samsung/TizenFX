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
        Interop.SmartEvent _clicked;

        public Image(EvasObject parent) : base(parent)
        {
            _clicked = new Interop.SmartEvent(this, Handle, "clicked");
            _clicked.On += (s, e) =>
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler Clicked;
        public event EventHandler LoadingCompleted;
        public event EventHandler LoadingFailed;

        public string File
        {
            get
            {
                return Interop.Elementary.elm_image_file_get(Handle);
            }
        }

        public bool IsSmooth
        {
            get
            {
                return Interop.Elementary.elm_image_smooth_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_smooth_set(Handle, value);
            }
        }

        public bool IsScaling
        {
            get
            {
                return !Interop.Elementary.elm_image_no_scale_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_no_scale_set(Handle, !value);
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
                Interop.Elementary.elm_image_resizable_set(Handle, _canScaleUp, _canScaleDown);
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
                Interop.Elementary.elm_image_resizable_set(Handle, _canScaleUp, _canScaleDown);
            }
        }

        public bool CanFillOutside
        {
            get
            {
                return Interop.Elementary.elm_image_fill_outside_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_fill_outside_set(Handle, value);
            }
        }

        public int PrescaleSize
        {
            get
            {
                return Interop.Elementary.elm_image_prescale_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_prescale_set(Handle, value);
            }
        }

        public bool IsFixedAspect
        {
            get
            {
                return Interop.Elementary.elm_image_aspect_fixed_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_aspect_fixed_set(Handle, value);
            }
        }

        public bool IsAnimated
        {
            get
            {
                return Interop.Elementary.elm_image_animated_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_animated_set(Handle, value);
            }
        }

        public bool IsAnimatedAvailable
        {
            get
            {
                return Interop.Elementary.elm_image_animated_available_get(Handle);
            }
        }

        public bool IsAnimationPlaying
        {
            get
            {
                return Interop.Elementary.elm_image_animated_play_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_animated_play_set(Handle, value);
            }
        }

        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_image_editable_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_editable_set(Handle, value);
            }
        }

        public Size ObjectSize
        {
            get
            {
                int w, h;
                Interop.Elementary.elm_image_object_size_get(Handle, out w, out h);
                return new Size(w, h);
            }
        }

        public bool IsOpaque
        {
            get
            {
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(Handle);
                if (evasObj != IntPtr.Zero)
                {
                    return !Interop.Evas.evas_object_image_alpha_get(evasObj);
                }
                return false;
            }
            set
            {
                IntPtr evasObj = Interop.Elementary.elm_image_object_get(Handle);
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
                return (ImageOrientation)Interop.Elementary.elm_image_orient_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_image_orient_set(Handle, (int)value);
            }
        }

        public void Load(string file)
        {
            Interop.Elementary.elm_image_preload_disabled_set(Handle, true);
            bool ret = Interop.Elementary.elm_image_file_set(Handle, file, null);
            if (!ret)
            {
                throw new InvalidOperationException("Failed to set file to Image");
            }

            LoadingCompleted?.Invoke(this, EventArgs.Empty);
        }
       
        public unsafe void Load(byte* img, long size)
        {
            bool ret = Interop.Elementary.elm_image_memfile_set(Handle, img, size, IntPtr.Zero, IntPtr.Zero);
            if (!ret)
            {
                throw new InvalidOperationException("Failed to set memory buffer to Image");
            }

            LoadingCompleted?.Invoke(this, EventArgs.Empty);
        }

        public void LoadAsync(Uri uri)
        {
            if (uri.IsFile)
                LoadFromFileAsync(uri.LocalPath);
            else
                LoadFromUriAsync(uri.AbsoluteUri);
        }

        public async Task<bool> LoadAsync(Stream stream, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();

            Interop.Elementary.elm_image_preload_disabled_set(Handle, false);

            cancellationToken.Register(() =>
            {
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetCanceled();
                }
            });

            MemoryStream memstream = new MemoryStream();
            await stream.CopyToAsync(memstream);

            unsafe
            {
                byte[] dataArr = memstream.ToArray();
                fixed (byte* data = &dataArr[0])
                {
                    bool ret = Interop.Elementary.elm_image_memfile_set(Handle, data, dataArr.Length, IntPtr.Zero, IntPtr.Zero);
                    if (!ret)
                    {
                        return false;
                    }
                }
            }

            var evasObj = Interop.Elementary.elm_image_object_get(Handle);
            Interop.EvasObjectEvent preloadedCallback = new Interop.EvasObjectEvent(this, evasObj, Interop.Evas.ObjectCallbackType.ImagePreloaded);
            preloadedCallback.On += (s, e) =>
            {
                preloadedCallback.Dispose();
                if (tcs != null && !tcs.Task.IsCompleted)
                {
                    tcs.SetResult(true);
                }
            };

            return await tcs.Task;
        }


        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_image_add(parent.Handle);
        }

        void LoadFromFileAsync(string file)
        {
            Interop.Elementary.elm_image_preload_disabled_set(Handle, false);
            bool ret = Interop.Elementary.elm_image_file_set(Handle, file, null);
            if (!ret)
            {
                throw new InvalidOperationException("Failed to set file to Image");
            }

            // FIXME: Due to the bug of EFL, the preload callback should be set after elm_image_file_set().
            var evasObj = Interop.Elementary.elm_image_object_get(Handle);
            var preloadedCallback = new Interop.EvasObjectEvent(this, evasObj, Interop.Evas.ObjectCallbackType.ImagePreloaded);
            preloadedCallback.On += (s, e) =>
            {
                preloadedCallback.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        void LoadFromUriAsync(string path)
        {
            Interop.Elementary.elm_image_preload_disabled_set(Handle, true);
            Interop.SmartEvent downloadDone = new Interop.SmartEvent(this, Handle, "download,done");
            downloadDone.On += (s, e) =>
            {
                downloadDone.Dispose();
                LoadingCompleted?.Invoke(this, EventArgs.Empty);
            };
            Interop.SmartEvent downloadError = new Interop.SmartEvent(this, Handle, "download,error");
            downloadError.On += (s, e) =>
            {
                downloadError.Dispose();
                LoadingFailed?.Invoke(this, EventArgs.Empty);
            };

            bool ret = Interop.Elementary.elm_image_file_set(Handle, path, null);
            if (!ret)
            {
                throw new InvalidOperationException("Failed to set file to Image");
            }
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
