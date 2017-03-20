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
    /// <summary>
    /// The EcasObject is a base class for other widget class
    /// </summary>
    public abstract class EvasObject
    {
        private IntPtr _realHandle = IntPtr.Zero;
        internal IntPtr Handle { get; set; }
        internal EvasObject Parent { get; set; }
        internal IntPtr RealHandle
        {
            get
            {
                return _realHandle == IntPtr.Zero ? Handle : _realHandle;
            }
            set
            {
                _realHandle = value;
            }
        }

        EvasObjectEvent _deleted;
        EvasObjectEvent<EvasKeyEventArgs> _keyup;
        EvasObjectEvent<EvasKeyEventArgs> _keydown;
        EvasObjectEvent _moved;
        EvasObjectEvent _resized;
        EvasObjectEvent _renderPost;

        readonly HashSet<IInvalidatable> _eventStore = new HashSet<IInvalidatable>();

        /// <summary>
        /// Creates and initializes a new instance of the EvasObject class with parent EvasObject class parameter.
        /// </summary>
        /// <param name="parent">Parent EvasObject class </param>
        protected EvasObject(EvasObject parent) : this()
        {
            Debug.Assert(parent == null || parent.IsRealized);
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasObject class.
        /// </summary>
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

        /// <summary>
        /// Deleted will be triggered when widght is deleted
        /// </summary>
        public event EventHandler Deleted;
        /// <summary>
        /// KeyUp will be triggered when key is loose
        /// </summary>
        public event EventHandler<EvasKeyEventArgs> KeyUp;
        /// <summary>
        /// KeyDown will be triggered when key is preesd down
        /// </summary>
        public event EventHandler<EvasKeyEventArgs> KeyDown;
        /// <summary>
        /// Moved will be triggered when widght is moved
        /// </summary>
        public event EventHandler Moved
        {
            add { _moved.On += value; }
            remove { _moved.On -= value; }
        }
        /// <summary>
        /// Current widget's size Resized Event Handler
        /// </summary>
        public event EventHandler Resized
        {
            add { _resized.On += value; }
            remove { _resized.On -= value; }
        }
        /// <summary>
        /// Current widget RenderPost Event Handler
        /// </summary>
        public event EventHandler RenderPost
        {
            add { _renderPost.On += value; }
            remove { _renderPost.On -= value; }
        }

        /// <summary>
        /// Get widget's status of Realized or not.
        /// </summary>
        public bool IsRealized { get { return Handle != IntPtr.Zero; } }

        /// <summary>
        /// Gets the current class's Name.
        /// </summary>
        public string ClassName
        {
            get
            {
                return Interop.Eo.eo_class_name_get(Interop.Eo.eo_class_get(RealHandle));
            }
        }

        /// <summary>
        /// Sets or gets the horizontal pointer hints for an object's weight.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the vertical pointer hints for an object's weight.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the horizontal alignment hint of an object's alignment.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the vertical alignment hint of an object's alignment.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the Width hints for an object's minimum size.
        /// </summary>
        public int MinimumWidth
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_size_hint_min_get(RealHandle, out w, out h);
                return w;
            }
            set
            {
                int h = MinimumHeight;
                Interop.Evas.evas_object_size_hint_min_set(RealHandle, value, h);
            }
        }

        /// <summary>
        /// Sets or gets the Height hints for an object's minimum size.
        /// </summary>
        public int MinimumHeight
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_size_hint_min_get(RealHandle, out w, out h);
                return h;
            }
            set
            {
                int w = MinimumWidth;
                Interop.Evas.evas_object_size_hint_min_set(RealHandle, w, value);
            }
        }

        /// <summary>
        /// Gets the visible state of the given Evas object.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return Interop.Evas.evas_object_visible_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets the position and (rectangular) size of the given Evas object.
        /// </summary>
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

        /// <summary>
        /// Sets or gets the general or main color of the given Evas object.
        /// </summary>
        public virtual Color Color
        {
            get
            {
                int r, g, b, a;
                Interop.Evas.evas_object_color_get(RealHandle, out r, out g, out b, out a);
                return Color.FromRgba(r, g, b, a);
            }
            set
            {
                Interop.Evas.SetPremultipliedColor(RealHandle, value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets the map enabled state.
        /// </summary>
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

        /// <summary>
        /// Sets or gets current object transformation map.
        /// </summary>
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

        /// <summary>
        /// Sets or gets whether an object is to repeat events.
        /// </summary>
        public bool RepeatEvents
        {
            get
            {
                return Interop.Evas.evas_object_repeat_events_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_repeat_events_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether events on a smart object's member should get propagated up to its parent.
        /// </summary>
        public bool PropagateEvents
        {
            get
            {
                return Interop.Evas.evas_object_propagate_events_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_propagate_events_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether an object is set to pass (ignore) events.
        /// </summary>
        public bool PassEvents
        {
            get
            {
                return Interop.Evas.evas_object_pass_events_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_pass_events_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Clips one object to another.
        /// </summary>
        /// <param name="clip">The object to clip object by</param>
        public void SetClip(EvasObject clip)
        {
            Interop.Evas.evas_object_clip_set(Handle, clip);
        }

        /// <summary>
        /// Sets the hints for an object's alignment.
        /// </summary>
        /// <param name="x">The horizontal alignment hint as double value ranging from 0.0 to 1.0,The default alignment hint value is 0.5 </param>
        /// <param name="y">The vertical alignment hint as double value ranging from 0.0 to 1.0,The default alignment hint value is 0.5 </param>
        public void SetAlignment(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_align_set(Handle, x, y);
        }

        /// <summary>
        /// Sets the hints for an object's weight.
        /// </summary>
        /// <param name="x">The non-negative double value to use as horizontal weight hint</param>
        /// <param name="y">The non-negative double value to use as vertical weight hint</param>
        public void SetWeight(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, x, y);
        }

        /// <summary>
        /// Makes the current object visible.
        /// </summary>
        public void Show()
        {
            Interop.Evas.evas_object_show(Handle);
        }

        /// <summary>
        /// Makes the current object invisible.
        /// </summary>
        public void Hide()
        {
            Interop.Evas.evas_object_hide(Handle);
        }

        /// <summary>
        /// Changes the size of the current object.
        /// </summary>
        /// <param name="w">The new width</param>
        /// <param name="h">The new height</param>
        public void Resize(int w, int h)
        {
            Interop.Evas.evas_object_resize(Handle, w, h);
        }

        /// <summary>
        /// Moves the current object to the given location.
        /// </summary>
        /// <param name="x">The X position to move the object to.</param>
        /// <param name="y">The Y position to move the object to.</param>
        public void Move(int x, int y)
        {
            Interop.Evas.evas_object_move(Handle, x, y);
        }

        /// <summary>
        /// Lowers obj to the bottom of its layer.
        /// </summary>
        public void Lower()
        {
            Interop.Evas.evas_object_lower(Handle);
        }

        /// <summary>
        /// Define IntPtr operator
        /// </summary>
        /// <param name="obj">Parent object</param>
        public static implicit operator IntPtr(EvasObject obj)
        {
            if (obj == null)
                return IntPtr.Zero;
            return obj.Handle;
        }

        /// <summary>
        /// Requests keyname key events be directed to current obj.
        /// </summary>
        /// <param name="keyname">The key to request events for</param>
        /// <param name="exclusive">Set TRUE to request that the obj is the only object receiving the keyname events,otherwise set FALSE</param>
        /// <returns>If the call succeeded is true,otherwise is false</returns>
        public bool KeyGrab(string keyname, bool exclusive)
        {
            return Interop.Evas.evas_object_key_grab(Handle, keyname, 0, 0, exclusive);
        }

        /// <summary>
        /// Removes the grab on keyname key events.
        /// </summary>
        /// <param name="keyname">The key the grab is set for</param>
        public void KeyUngrab(string keyname)
        {
            Interop.Evas.evas_object_key_ungrab(Handle, keyname, 0, 0);
        }

        /// <summary>
        /// Mark smart object as changed.
        /// </summary>
        public void MarkChanged()
        {
            Interop.Evas.evas_object_smart_changed(RealHandle);
        }

        /// <summary>
        /// The callback of Invalidate Event
        /// </summary>
        protected virtual void OnInvalidate()
        {
        }

        /// <summary>
        /// The callback of Instantiated Event
        /// </summary>
        protected virtual void OnInstantiated()
        {
        }
        /// <summary>
        /// The callback of Realized Event
        /// </summary>
        protected virtual void OnRealized()
        {
        }
        /// <summary>
        /// The callback of Unrealize Event
        /// </summary>
        protected virtual void OnUnrealize()
        {
        }
        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected abstract IntPtr CreateHandle(EvasObject parent);

        /// <summary>
        /// For this object bind Parent object.Init handle and all kinds of EvasObjectEvent.
        /// </summary>
        /// <param name="parent">Parent object</param>
        public void Realize(EvasObject parent)
        {
            if (!IsRealized)
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

        /// <summary>
        /// Removes current object relationship with others.
        /// </summary>
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
