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
    /// Enumeration for the Tooltip orientation.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum TooltipOrientation
    {
        /// <summary>
        /// Default value. Tooltip moves with a mouse pointer.
        /// </summary>
        None,

        /// <summary>
        /// Tooltip should appear to the top left of the parent.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Tooltip should appear to the left of the parent.
        /// </summary>
        Top,

        /// <summary>
        /// Tooltip should appear to the top right of the parent.
        /// </summary>
        TopRight,

        /// <summary>
        /// Tooltip should appear to the left of the parent.
        /// </summary>
        Left,

        /// <summary>
        /// Tooltip should appear to the center of the parent.
        /// </summary>
        Center,

        /// <summary>
        /// Tooltip should appear to the right of the parent.
        /// </summary>
        Right,

        /// <summary>
        /// Tooltip should appear to the bottom left of the parent.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Tooltip should appear to the bottom of the parent.
        /// </summary>
        Bottom,

        /// <summary>
        /// Tooltip should appear to the bottom right of the parent.
        /// </summary>
        BottomRight,
    }

    /// <summary>
    /// Enumeration for the aspect control.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum AspectControl
    {
        /// <summary>
        /// Preference on the scaling unset.
        /// </summary>
        None = 0,

        /// <summary>
        /// Same effect as the unset preference on the scaling.
        /// </summary>
        Neither = 1,

        /// <summary>
        /// Use all horizontal container space to place an object using the given aspect.
        /// </summary>
        Horizontal = 2,

        /// <summary>
        /// Use all vertical container space to place an object using the given aspect.
        /// </summary>
        Vertical = 3,

        /// <summary>
        /// Use all horizontal @b and vertical container spaces to place an object (never growing it out of those bounds), using the given aspect.
        /// </summary>
        Both = 4
    }

    /// <summary>
    /// How the object should be rendered to output.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum RenderOp
    {
        /// <summary>
        /// default op: d = d * (1 - sa) + s
        /// </summary>
        Blend = 0,

        /// <summary>
        /// d = d*(1 - sa) + s*da
        /// </summary>
        BlendRel = 1,

        /// <summary>
        /// d = s
        /// </summary>
        Copy = 2,

        /// <summary>
        /// d = s*da
        /// </summary>
        CopyRel = 3,

        /// <summary>
        /// d = d + s
        /// </summary>
        Add = 4,

        /// <summary>
        /// d = d + s*da
        /// </summary>
        AddRel = 5,

        /// <summary>
        /// d = d - s
        /// </summary>
        Sub = 6,

        /// <summary>
        /// d = d - s*da
        /// </summary>
        SubRel = 7,

        /// <summary>
        /// d = d*s + d*(1 - sa) + s*(1 - da)
        /// </summary>
        Tint = 8,

        /// <summary>
        /// d = d*(1 - sa + s)
        /// </summary>
        TintRel = 9,

        /// <summary>
        /// d = d*sa
        /// </summary>
        Mask = 10,

        /// <summary>
        /// d = d*s
        /// </summary>
        Mul = 11
    }

    /// <summary>
    /// The EvasObject is a base class for other widget classes.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class EvasObject
    {
        private IntPtr _realHandle = IntPtr.Zero;
        private EvasCanvas _evasCanvas;

        private event EventHandler _backButtonPressed;

        private event EventHandler _moreButtonPressed;

        private Interop.Eext.EextEventCallback _backButtonHandler;
        private Interop.Eext.EextEventCallback _moreButtonHandler;

        private static Dictionary<IntPtr, EvasObject> s_handleTable = new Dictionary<IntPtr, EvasObject>();

        /// <summary>
        /// Sets or gets the handle for EvasObject.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IntPtr Handle { get; protected set; }

        /// <summary>
        /// Gets the parent object for EvasObject.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasObject Parent { get; private set; }

        /// <summary>
        /// Sets or gets the real handle for EvasObject.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IntPtr RealHandle
        {
            get
            {
                return _realHandle == IntPtr.Zero ? Handle : _realHandle;
            }
            protected set
            {
                _realHandle = value;
                Interop.Evas.evas_object_show(_realHandle);
            }
        }

        EvasObjectEvent _deleted;
        EvasObjectEvent<EvasKeyEventArgs> _keyup;
        EvasObjectEvent<EvasKeyEventArgs> _keydown;
        EvasObjectEvent _moved;
        EvasObjectEvent _resized;
        EventHandler _renderPost;
        Interop.Evas.EvasCallback _renderPostCallback = null;
        Interop.Elementary.Elm_Tooltip_Content_Cb _tooltipContentCallback = null;

        GetTooltipContentDelegate _tooltipContentDelegate = null;

        readonly HashSet<IInvalidatable> _eventStore = new HashSet<IInvalidatable>();

        /// <summary>
        /// Creates and initializes a new instance of the EvasObject class with the parent EvasObject class parameter.
        /// </summary>
        /// <param name="parent">Parent EvasObject class.</param>
        /// <since_tizen> preview </since_tizen>
        protected EvasObject(EvasObject parent) : this()
        {
            Debug.Assert(parent == null || parent.IsRealized);
            Realize(parent);
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasObject class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected EvasObject()
        {
            _backButtonHandler = new Interop.Eext.EextEventCallback((d, o, i) => { _backButtonPressed?.Invoke(this, EventArgs.Empty); });
            _moreButtonHandler = new Interop.Eext.EextEventCallback((d, o, i) => { _moreButtonPressed?.Invoke(this, EventArgs.Empty); });

            OnInstantiated();

            _tooltipContentCallback = (d, o, t) =>
            {
                return _tooltipContentDelegate?.Invoke();
            };
        }

        // C# Finalizer was called on GC thread
        // So, We can't access to EFL object
        // And When Finalizer was called, Field can be already released.
        //~EvasObject()
        //{
        //    Unrealize();
        //}

        /// <summary>
        /// Deleted will be triggered when the widght is deleted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Deleted;

        /// <summary>
        /// KeyUp will be triggered when the key is loose.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<EvasKeyEventArgs> KeyUp
        {
            add { _keyup.On += value; }
            remove { _keyup.On -= value; }
        }

        /// <summary>
        /// KeyDown will be triggered when the key is pressed down.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<EvasKeyEventArgs> KeyDown
        {
            add { _keydown.On += value; }
            remove { _keydown.On -= value; }
        }

        /// <summary>
        /// BackButtonPressed will be triggered when the Back button is pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler BackButtonPressed
        {
            add
            {
                if (_backButtonPressed == null)
                {
                    Interop.Eext.eext_object_event_callback_add(RealHandle, Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK, _backButtonHandler, IntPtr.Zero);
                }
                _backButtonPressed += value;
            }
            remove
            {
                _backButtonPressed -= value;
                if (_backButtonPressed == null)
                {
                    Interop.Eext.eext_object_event_callback_del(RealHandle, Interop.Eext.EextCallbackType.EEXT_CALLBACK_BACK, _backButtonHandler);
                }
            }
        }

        /// <summary>
        /// MoreButtonPressed will be triggered when the More button is pressed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler MoreButtonPressed
        {
            add
            {
                if (_moreButtonPressed == null)
                {
                    Interop.Eext.eext_object_event_callback_add(RealHandle, Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE, _moreButtonHandler, IntPtr.Zero);
                }
                _moreButtonPressed += value;
            }
            remove
            {
                _moreButtonPressed -= value;
                if (_moreButtonPressed == null)
                {
                    Interop.Eext.eext_object_event_callback_del(RealHandle, Interop.Eext.EextCallbackType.EEXT_CALLBACK_MORE, _moreButtonHandler);
                }
            }
        }

        /// <summary>
        /// Moved will be triggered when the widght is moved.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Moved
        {
            add { _moved.On += value; }
            remove { _moved.On -= value; }
        }

        /// <summary>
        /// Resized Event Handler of the current widget's size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Resized
        {
            add { _resized.On += value; }
            remove { _resized.On -= value; }
        }

        /// <summary>
        /// RenderPost Event Handler of the current widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler RenderPost
        {
            add
            {
                _renderPost += value;
                if (_renderPostCallback == null)
                {
                    _renderPostCallback = new Interop.Evas.EvasCallback((o, e, d) => _renderPost?.Invoke(this, EventArgs.Empty));
                    Interop.Evas.evas_event_callback_add(Interop.Evas.evas_object_evas_get(RealHandle), Interop.Evas.ObjectCallbackType.RenderPost, _renderPostCallback, IntPtr.Zero);
                }
            }
            remove
            {
                _renderPost -= value;
                if (_renderPost == null)
                {
                    Interop.Evas.evas_event_callback_del(Interop.Evas.evas_object_evas_get(RealHandle), Interop.Evas.ObjectCallbackType.RenderPost, _renderPostCallback);
                    _renderPostCallback = null;
                }
            }
        }

        /// <summary>
        /// Called when a widget's tooltip is activated and needs content.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public delegate EvasObject GetTooltipContentDelegate();

        /// <summary>
        /// Gets a widget's status of realized or not.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsRealized { get { return Handle != IntPtr.Zero; } }

        /// <summary>
        /// Gets EvasCanvas.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasCanvas EvasCanvas
        {
            get
            {
                if (_evasCanvas == null)
                    _evasCanvas = new EvasCanvas(Handle);
                return _evasCanvas;
            }
        }

        /// <summary>
        /// Gets the current class's Name.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string ClassName
        {
            get
            {
                return Interop.Eo.efl_class_name_get(Interop.Eo.efl_class_get(RealHandle));
            }
        }

        /// <summary>
        /// Sets or gets the horizontal pointer hints for an object's weight.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the width hints for an object's minimum size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the height hints for an object's minimum size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Sets or gets the current object's transformation map.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
        public bool RepeatEvents
        {
            get
            {
                var result = Interop.Evas.evas_object_repeat_events_get(Handle);
                Debug.Assert(Handle == RealHandle || result == Interop.Evas.evas_object_repeat_events_get(RealHandle));
                return result;
            }
            set
            {
                if (Handle != RealHandle)
                {
                    Interop.Evas.evas_object_repeat_events_set(RealHandle, value);
                }
                Interop.Evas.evas_object_repeat_events_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether events on a smart object's member should get propagated up to its parent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool PropagateEvents
        {
            get
            {
                var result = Interop.Evas.evas_object_propagate_events_get(Handle);
                Debug.Assert(Handle == RealHandle || result == Interop.Evas.evas_object_propagate_events_get(RealHandle));
                return result;
            }
            set
            {
                if (Handle != RealHandle)
                {
                    Interop.Evas.evas_object_propagate_events_set(RealHandle, value);
                }
                Interop.Evas.evas_object_propagate_events_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether an object is set to pass (ignore) events.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool PassEvents
        {
            get
            {
                var result = Interop.Evas.evas_object_pass_events_get(Handle);
                Debug.Assert(Handle == RealHandle || result == Interop.Evas.evas_object_pass_events_get(RealHandle));
                return result;
            }
            set
            {
                if (Handle != RealHandle)
                {
                    Interop.Evas.evas_object_pass_events_set(RealHandle, value);
                }
                Interop.Evas.evas_object_pass_events_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the style for this object tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string TooltipStyle
        {
            get
            {
                return Interop.Elementary.elm_object_tooltip_style_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_tooltip_style_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the orientation of tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public TooltipOrientation TooltipOrientation
        {
            get
            {
                return (TooltipOrientation)Interop.Elementary.elm_object_tooltip_orient_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_tooltip_orient_set(RealHandle, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets size restriction state of an object's tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool TooltipWindowMode
        {
            get
            {
                return Interop.Elementary.elm_object_tooltip_window_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_object_tooltip_window_mode_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets the content to be shown in the tooltip object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GetTooltipContentDelegate TooltipContentDelegate
        {
            get
            {
                return _tooltipContentDelegate;
            }
            set
            {
                _tooltipContentDelegate = value;
                if (value != null)
                {
                    Interop.Elementary.elm_object_tooltip_content_cb_set(RealHandle, _tooltipContentCallback, IntPtr.Zero, null);
                }
                else
                {
                    Interop.Elementary.elm_object_tooltip_content_cb_set(RealHandle, null, IntPtr.Zero, null);
                }
            }
        }

        /// <summary>
        /// Gets the movement freeze by 1.
        /// This gets the movement freeze count by one.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int TooltipMoveFreezeCount
        {
            get
            {
                return Interop.Elementary.elm_object_tooltip_move_freeze_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets whether an Evas object is to freeze (discard) events.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AllEventsFrozen
        {
            get
            {
                var result = Interop.Evas.evas_object_freeze_events_get(Handle);
                Debug.Assert(Handle == RealHandle || result == Interop.Evas.evas_object_freeze_events_get(RealHandle));
                return result;
            }
            set
            {
                if (Handle != RealHandle)
                {
                    Interop.Evas.evas_object_freeze_events_set(RealHandle, value);
                }
                Interop.Evas.evas_object_freeze_events_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the layer of its canvas that the given object will be part of.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public virtual int Layer
        {
            get
            {
                return Interop.Evas.evas_object_layer_get(Handle);
            }
            set
            {
                Interop.Evas.evas_object_layer_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the render operation to be used for rendering the Evas object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public RenderOp RenderOperation
        {
            get
            {
                return (RenderOp)Interop.Evas.evas_object_render_op_get(RealHandle);
            }
            set
            {
                Interop.Evas.evas_object_render_op_set(RealHandle, (Interop.Evas.RenderOp)value);
            }
        }


        /// <summary>
        /// Clips one object to another.
        /// </summary>
        /// <param name="clip">The object to clip object by.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetClip(EvasObject clip)
        {
            Interop.Evas.evas_object_clip_set(Handle, clip);
        }

        /// <summary>
        /// Sets the hints for an object's alignment.
        /// </summary>
        /// <param name="x">The horizontal alignment hint as double value ranging from 0.0 to 1.0. The default alignment hint value is 0.5.</param>
        /// <param name="y">The vertical alignment hint as double value ranging from 0.0 to 1.0. The default alignment hint value is 0.5.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetAlignment(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_align_set(Handle, x, y);
        }

        /// <summary>
        /// Sets the hints for an object's weight.
        /// </summary>
        /// <param name="x">The non-negative double value to be used as horizontal weight hint.</param>
        /// <param name="y">The non-negative double value to be used as vertical weight hint.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetWeight(double x, double y)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, x, y);
        }

        /// <summary>
        /// Sets the text for an object's tooltip.
        /// </summary>
        /// <param name="text">The text value to display inside the tooltip.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetTooltipText(string text)
        {
            Interop.Elementary.elm_object_tooltip_text_set(RealHandle, text);
        }

        /// <summary>
        /// Unsets an object's tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void UnsetTooltip()
        {
            Interop.Elementary.elm_object_tooltip_unset(RealHandle);
        }

        /// <summary>
        /// This increments the tooltip movement freeze count by one.
        /// If the count is more than 0, the tooltip position will be fixed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PushTooltipMoveFreeze()
        {
            Interop.Elementary.elm_object_tooltip_move_freeze_push(RealHandle);
        }

        /// <summary>
        /// This decrements the tooltip freeze count by one.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PopTooltipMoveFreeze()
        {
            Interop.Elementary.elm_object_tooltip_move_freeze_pop(RealHandle);
        }

        /// <summary>
        /// Force hide the tooltip of the object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void HideTooltip()
        {
            Interop.Elementary.elm_object_tooltip_hide(RealHandle);
        }

        /// <summary>
        /// Force show the tooltip of the object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void ShowTooltip()
        {
            Interop.Elementary.elm_object_tooltip_show(RealHandle);
        }

        /// <summary>
        /// Makes the current object visible.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Show()
        {
            Interop.Evas.evas_object_show(Handle);
        }

        /// <summary>
        /// Makes the current object invisible.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Hide()
        {
            Interop.Evas.evas_object_hide(Handle);
        }

        /// <summary>
        /// Changes the size of the current object.
        /// </summary>
        /// <param name="w">The new width.</param>
        /// <param name="h">The new height.</param>
        /// <since_tizen> preview </since_tizen>
        public void Resize(int w, int h)
        {
            Interop.Evas.evas_object_resize(Handle, w, h);
        }

        /// <summary>
        /// Moves the current object to the given location.
        /// </summary>
        /// <param name="x">The X position to move the object.</param>
        /// <param name="y">The Y position to move the object.</param>
        /// <since_tizen> preview </since_tizen>
        public void Move(int x, int y)
        {
            Interop.Evas.evas_object_move(Handle, x, y);
        }

        /// <summary>
        /// Lowers the object to the bottom of its layer.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Lower()
        {
            Interop.Evas.evas_object_lower(Handle);
        }

        /// <summary>
        /// Define the IntPtr operator.
        /// </summary>
        /// <param name="obj">Parent object.</param>
        /// <since_tizen> preview </since_tizen>
        public static implicit operator IntPtr(EvasObject obj)
        {
            if (obj == null)
                return IntPtr.Zero;
            return obj.Handle;
        }

	/// <summary>
        /// Define cast to EvasObject operator from IntPtr
        /// </summary>
        /// <param name="handle">Native handle to EvasObject</param>
        /// <since_tizen> preview </since_tizen>
        public static explicit operator EvasObject(IntPtr handle) => EvasObject.s_handleTable.TryGetValue(handle, out EvasObject obj) ? obj : null;

        /// <summary>
        /// Requests the keyname key events to be directed to the current object.
        /// </summary>
        /// <param name="keyname">The key to request events for.</param>
        /// <param name="exclusive">Set TRUE to request that the obj is the only object receiving the keyname events, otherwise set to FALSE.</param>
        /// <returns>If the call succeeds then true, otherwise false.</returns>
        /// <since_tizen> preview </since_tizen>
        public bool KeyGrab(string keyname, bool exclusive)
        {
            return Interop.Evas.evas_object_key_grab(Handle, keyname, 0, 0, exclusive);
        }

        /// <summary>
        /// Removes the grab on the keyname key events.
        /// </summary>
        /// <param name="keyname">The key the grab is set for.</param>
        /// <since_tizen> preview </since_tizen>
        public void KeyUngrab(string keyname)
        {
            Interop.Evas.evas_object_key_ungrab(Handle, keyname, 0, 0);
        }

        /// <summary>
        /// Marks the smart object as changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void MarkChanged()
        {
            Interop.Evas.evas_object_smart_changed(RealHandle);
        }

        /// <summary>
        /// Calls the calculate smart function immediately.
        /// This will force immediate calculations needed for renderization of this object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Calculate()
        {
            Interop.Evas.evas_object_smart_calculate(RealHandle);
        }

        /// <summary>
        /// Sets the hints for an object's aspect ratio.
        /// </summary>
        /// <param name="aspect">The policy or type of aspect ratio to apply to an object.</param>
        /// <param name="w">The integer to be used as aspect width ratio term.</param>
        /// <param name="h">The integer to be used as aspect height ratio term.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetSizeHintAspect(AspectControl aspect, int w, int h)
        {
            Interop.Evas.evas_object_size_hint_aspect_set(Handle, (int)aspect, w, h);
        }

        /// <summary>
        /// Gets the hints for an object's aspect ratio.
        /// </summary>
        /// <param name="aspect">The policy or type of aspect ratio to apply to an object.</param>
        /// <param name="w">The integer to be used as aspect width ratio term.</param>
        /// <param name="h">The integer to be used as aspect height ratio term.</param>
        /// <since_tizen> preview </since_tizen>
        public void GetSizeHintAspect(out AspectControl aspect, out int w, out int h)
        {
            int aspectRatio;
            Interop.Evas.evas_object_size_hint_aspect_get(Handle, out aspectRatio, out w, out h);
            aspect = (AspectControl)aspectRatio;
        }

        /// <summary>
        /// Stacks immediately below anchor.
        /// </summary>
        /// <param name="anchor">The object below which to stack.</param>
        /// <since_tizen> preview </since_tizen>
        public void StackBelow(EvasObject anchor)
        {
            Interop.Evas.evas_object_stack_below(Handle, anchor);
        }

        /// <summary>
        /// Stacks immediately above anchor.
        /// </summary>
        /// <param name="anchor">The object above which to stack.</param>
        /// <since_tizen> preview </since_tizen>
        public void StackAbove(EvasObject anchor)
        {
            Interop.Evas.evas_object_stack_above(Handle, anchor);
        }

        /// <summary>
        /// Raises to the top of its layer.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void RaiseTop()
        {
            Interop.Evas.evas_object_raise(Handle);
        }

        /// <summary>
        /// Gets the geometry of a line number.
        /// </summary>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="x">x coordinate of the line.</param>
        /// <param name="y">y coordinate of the line.</param>
        /// <param name="w">w coordinate of the line.</param>
        /// <param name="h">h coordinate of the line.</param>
        /// <returns>True on success, or False on error.</returns>
        /// <since_tizen> preview </since_tizen>
        [Obsolete("GetTextBlockGeometryByLineNumber is obsolete as of version 5.0.0.14299 and is no longer supported.")]
        public bool GetTextBlockGeometryByLineNumber(int lineNumber, out int x, out int y, out int w, out int h)
        {
            x = -1; y = -1; w = -1; h = -1;

            IntPtr _edjeHandle = Interop.Elementary.elm_layout_edje_get(RealHandle);
            if (_edjeHandle == IntPtr.Zero)
            {
                return false;
            }

            IntPtr _textblock = Interop.Elementary.edje_object_part_object_get(_edjeHandle, "elm.text");
            if (_textblock == IntPtr.Zero)
            {
                return false;
            }

            return Interop.Evas.evas_object_textblock_line_number_geometry_get(_textblock, lineNumber, out x, out y, out w, out h);
        }

        internal IntPtr GetData(string key)
        {
            return Interop.Evas.evas_object_data_get(RealHandle, key);
        }

        internal void SetData(string key, IntPtr data)
        {
            Interop.Evas.evas_object_data_set(RealHandle, key, data);
        }

        internal IntPtr DeleteData(string key)
        {
            return Interop.Evas.evas_object_data_del(RealHandle, key);
        }

        /// <summary>
        /// The callback of the Invalidate Event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected virtual void OnInvalidate()
        {
        }

        /// <summary>
        /// The callback of the Instantiated Event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected virtual void OnInstantiated()
        {
        }

        /// <summary>
        /// The callback of the Realized Event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected virtual void OnRealized()
        {
        }

        /// <summary>
        /// The callback of the Unrealize Event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected virtual void OnUnrealize()
        {
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected abstract IntPtr CreateHandle(EvasObject parent);

        /// <summary>
        /// For this object bind Parent object.Init handle and all kinds of EvasObjectEvent.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <since_tizen> preview </since_tizen>
        public void Realize(EvasObject parent)
        {
            if (!IsRealized)
            {
                Parent = parent;
                Handle = CreateHandle(parent);
                Debug.Assert(Handle != IntPtr.Zero);

                s_handleTable[Handle] = this;

                (parent as Window)?.AddChild(this);

                OnRealized();
                _deleted = new EvasObjectEvent(this, EvasObjectCallbackType.Del);
                _keydown = new EvasObjectEvent<EvasKeyEventArgs>(this, RealHandle, EvasObjectCallbackType.KeyDown, EvasKeyEventArgs.Create);
                _keyup = new EvasObjectEvent<EvasKeyEventArgs>(this, RealHandle, EvasObjectCallbackType.KeyUp, EvasKeyEventArgs.Create);
                _moved = new EvasObjectEvent(this, EvasObjectCallbackType.Move);
                _resized = new EvasObjectEvent(this, EvasObjectCallbackType.Resize);

                _deleted.On += (s, e) => MakeInvalidate();
            }
        }

        /// <summary>
        /// Removes the current object relationship with others.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Unrealize()
        {
            if (IsRealized)
            {
                if (_renderPostCallback != null)
                {
                    Interop.Evas.evas_event_callback_del(Interop.Evas.evas_object_evas_get(Handle), Interop.Evas.ObjectCallbackType.RenderPost, _renderPostCallback);
                    _renderPostCallback = null;
                }

                OnUnrealize();
                IntPtr toBeDeleted = Handle;
                Handle = IntPtr.Zero;

                DisposeEvent();

                (Parent as Window)?.RemoveChild(this);

                Interop.Evas.evas_object_del(toBeDeleted);
                Deleted?.Invoke(this, EventArgs.Empty);
                Parent = null;
                s_handleTable.Remove(toBeDeleted);
            }
        }

        private void MakeInvalidate()
        {
            Deleted?.Invoke(this, EventArgs.Empty);
            OnInvalidate();
            IntPtr toBeDeleted = Handle;
            Handle = IntPtr.Zero;

            MakeInvalidateEvent();

            (Parent as Window)?.RemoveChild(this);
            Parent = null;
            _deleted = null;

            s_handleTable.Remove(toBeDeleted);
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
