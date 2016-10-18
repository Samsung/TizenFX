using System;
using System.Diagnostics;

namespace ElmSharp
{
    public abstract class EvasObject
    {
        internal IntPtr Handle { get; set; }
        internal EvasObject Parent { get; set; }

        Interop.EvasObjectEvent _deleted;
        Interop.EvasObjectEvent<EvasKeyEventArgs> _keyup;
        Interop.EvasObjectEvent<EvasKeyEventArgs> _keydown;
        Interop.EvasObjectEvent _moved;
        Interop.EvasObjectEvent _resized;
        Interop.EvasObjectEvent _renderPost;

        protected EvasObject(EvasObject parent) : this()
        {
            Debug.Assert(parent == null || parent.IsRealized);
            Realize(parent);
        }

        protected EvasObject()
        {
            OnInstantiated();
        }

        // C# Finalizer was called on GC thread
        // So, We can't access to EFL object
        // And When Finalizer was called, Field can be already released.
        //~EvasObject()
        //{
        //    Unrealize();
        //}

        public event EventHandler Deleted;
        public event EventHandler<EvasKeyEventArgs> KeyUp;
        public event EventHandler<EvasKeyEventArgs> KeyDown;
        public event EventHandler Moved
        {
            add { _moved.On += value; }
            remove { _moved.On -= value; }
        }
        public event EventHandler Resized
        {
            add { _resized.On += value; }
            remove { _resized.On -= value; }
        }

        public event EventHandler RenderPost
        {
            add { _renderPost.On += value; }
            remove { _renderPost.On -= value; }
        }


        public bool IsRealized { get { return Handle != IntPtr.Zero; } }

        public string ClassName
        {
            get
            {
                return Interop.Eo.eo_class_name_get(Interop.Eo.eo_class_get(Handle));
            }
        }

        public double WeightX
        {
            get
            {
                return Interop.Evas.GetWeightX(Handle);
            }
            set
            {
                Interop.Evas.SetWeightX(Handle, value);
            }
        }

        public double WeightY
        {
            get
            {
                return Interop.Evas.GetWeightY(Handle);
            }
            set
            {
                Interop.Evas.SetWeightY(Handle, value);
            }
        }

        public virtual double AlignmentX
        {
            get
            {
                return Interop.Evas.GetAlignX(Handle);
            }
            set
            {
                Interop.Evas.SetAlignX(Handle, value);
            }
        }

        public virtual double AlignmentY
        {
            get
            {
                return Interop.Evas.GetAlignY(Handle);
            }
            set
            {
                Interop.Evas.SetAlignY(Handle, value);
            }
        }

        public int MinimumWidth
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_size_hint_min_get(Handle, out w, out h);
                return w;
            }
            set
            {
                int h = MinimumHeight;
                Interop.Evas.evas_object_size_hint_min_set(Handle, value, h);
            }
        }

        public int MinimumHeight
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_size_hint_min_get(Handle, out w, out h);
                return h;
            }
            set
            {
                int w = MinimumWidth;
                Interop.Evas.evas_object_size_hint_min_set(Handle, w, value);
            }
        }

        public bool IsVisible
        {
            get
            {
                return Interop.Evas.evas_object_visible_get(Handle);
            }
        }

        public Rect Geometry
        {
            get
            {
                int x, y, w, h;
                Interop.Evas.evas_object_geometry_get(Handle, out x, out y, out w, out h);
                Rect rect = new Rect(x, y, w, h);
                return rect;
            }
            set
            {
                Interop.Evas.evas_object_geometry_set(Handle, value.X, value.Y, value.Width, value.Height);
            }
        }

        public virtual Color Color
        {
            get
            {
                int r, g, b, a;
                Interop.Evas.evas_object_color_get(Handle, out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Evas.SetPremultipliedColor(Handle, value.R, value.G, value.B, value.A);
            }
        }

        public bool IsMapEnabled
        {
            get
            {
                return Interop.Evas.evas_object_map_enable_get(Handle);
            }
            set
            {
                Interop.Evas.evas_object_map_enable_set(Handle, value);
            }
        }

        public EvasMap EvasMap
        {
            get
            {
                IntPtr evasMap = Interop.Evas.evas_object_map_get(Handle);
                return new EvasMap(evasMap);
            }
            set
            {
                Interop.Evas.evas_object_map_set(Handle, value.Handle);
            }
        }

        public void SetClip(EvasObject clip)
        {
            Interop.Evas.evas_object_clip_set(Handle, clip);
        }

        public void SetAlignment(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_align_set(Handle, x, y);
        }

        public void SetWeight(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, x, y);
        }

        public void Show()
        {
            Interop.Evas.evas_object_show(Handle);
        }

        public void Hide()
        {
            Interop.Evas.evas_object_hide(Handle);
        }

        public void Resize(int w, int h)
        {
            Interop.Evas.evas_object_resize(Handle, w, h);
        }

        public void Move(int x, int y)
        {
            Interop.Evas.evas_object_move(Handle, x, y);
        }

        public void Lower()
        {
            Interop.Evas.evas_object_lower(Handle);
        }

        public void MakeInvalidate()
        {
            Deleted?.Invoke(this, EventArgs.Empty);
            OnInvalidate();
            Handle = IntPtr.Zero;

            (Parent as Window)?.RemoveChild(this);
            Parent = null;
            _deleted = null;
        }

        public static implicit operator IntPtr(EvasObject obj)
        {
            if (obj == null)
                return IntPtr.Zero;
            return obj.Handle;
        }

        public bool KeyGrab(string keyname, bool exclusive)
        {
            return Interop.Evas.evas_object_key_grab(Handle, keyname, 0, 0, exclusive);
        }

        public void KeyUngrab(string keyname)
        {
            Interop.Evas.evas_object_key_ungrab(Handle, keyname, 0, 0);
        }

        public void MarkChanged()
        {
            Interop.Evas.evas_object_smart_changed(Handle);
        }

        protected virtual void OnInvalidate()
        {
        }

        protected virtual void OnInstantiated()
        {
        }

        protected virtual void OnRealized()
        {
        }

        protected virtual void OnUnrealize()
        {
        }

        protected abstract IntPtr CreateHandle(EvasObject parent);

        public void Realize(EvasObject parent)
        {
            if(!IsRealized)
            {
                Parent = parent;
                Handle = CreateHandle(parent);
                Debug.Assert(Handle != IntPtr.Zero);

                (parent as Window)?.AddChild(this);

                OnRealized();
                _deleted = new Interop.EvasObjectEvent(this, Handle, Interop.Evas.ObjectCallbackType.Del);
                _keydown = new Interop.EvasObjectEvent<EvasKeyEventArgs>(this, Handle, Interop.Evas.ObjectCallbackType.KeyDown, EvasKeyEventArgs.Create);
                _keyup = new Interop.EvasObjectEvent<EvasKeyEventArgs>(this, Handle, Interop.Evas.ObjectCallbackType.KeyUp, EvasKeyEventArgs.Create);
                _moved = new Interop.EvasObjectEvent(this, Handle, Interop.Evas.ObjectCallbackType.Move);
                _resized = new Interop.EvasObjectEvent(this, Handle, Interop.Evas.ObjectCallbackType.Resize);
                _renderPost = new Interop.EvasObjectEvent(this, Interop.Evas.evas_object_evas_get(Handle), Interop.Evas.ObjectCallbackType.RenderPost);

                _deleted.On += (s, e) => MakeInvalidate();
                _keydown.On += (s, e) => KeyDown?.Invoke(this, e);
                _keyup.On += (s, e) => KeyUp?.Invoke(this, e);

            }
        }

        public void Unrealize()
        {
            if (IsRealized)
            {
                OnUnrealize();
                IntPtr toBeDeleted = Handle;
                Handle = IntPtr.Zero;
                _deleted?.Dispose();
                _deleted = null;
                _keydown?.Dispose();
                _keydown = null;
                _keyup?.Dispose();
                _keyup = null;
                _moved?.Dispose();
                _moved = null;
                _resized?.Dispose();
                _resized = null;
                _renderPost?.Dispose();
                _renderPost = null;

                (Parent as Window)?.RemoveChild(this);

                Interop.Evas.evas_object_del(toBeDeleted);
                Parent = null;
            }
        }
    }
}
