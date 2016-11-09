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
using System.Diagnostics;

namespace ElmSharp
{
    public abstract class EvasObject
    {
        internal IntPtr Handle { get; set; }
        internal EvasObject Parent { get; set; }

        EvasObjectEvent _deleted;
        EvasObjectEvent<EvasKeyEventArgs> _keyup;
        EvasObjectEvent<EvasKeyEventArgs> _keydown;
        EvasObjectEvent _moved;
        EvasObjectEvent _resized;
        EvasObjectEvent _renderPost;

        readonly HashSet<IInvalidatable> _eventStore = new HashSet<IInvalidatable>();

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
                _deleted = new EvasObjectEvent(this, EvasObjectCallbackType.Del);
                _keydown = new EvasObjectEvent<EvasKeyEventArgs>(this, EvasObjectCallbackType.KeyDown, EvasKeyEventArgs.Create);
                _keyup = new EvasObjectEvent<EvasKeyEventArgs>(this, EvasObjectCallbackType.KeyUp, EvasKeyEventArgs.Create);
                _moved = new EvasObjectEvent(this, EvasObjectCallbackType.Move);
                _resized = new EvasObjectEvent(this, EvasObjectCallbackType.Resize);
                _renderPost = new EvasObjectEvent(this, Interop.Evas.evas_object_evas_get(Handle), EvasObjectCallbackType.RenderPost);

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

                DisposeEvent();

                (Parent as Window)?.RemoveChild(this);

                Interop.Evas.evas_object_del(toBeDeleted);
                Parent = null;
            }
        }

        private void MakeInvalidate()
        {
            Deleted?.Invoke(this, EventArgs.Empty);
            OnInvalidate();
            Handle = IntPtr.Zero;

            MakeInvalidateEvent();

            (Parent as Window)?.RemoveChild(this);
            Parent = null;
            _deleted = null;
        }

        private void DisposeEvent()
        {
            foreach (var evt in _eventStore)
            {
                evt.Dispose();
            }
            _eventStore.Clear();
        }
        private void MakeInvalidateEvent()
        {
            foreach (var evt in _eventStore)
            {
                evt.MakeInvalidate();
            }
            _eventStore.Clear();
        }

        internal void AddToEventLifeTracker(IInvalidatable item)
        {
            _eventStore.Add(item);
        }

    }
}
