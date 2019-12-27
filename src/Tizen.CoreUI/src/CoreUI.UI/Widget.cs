/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>Base class for all CoreUI.UI.* widgets
    /// 
    /// The class here is designed in a way that widgets can be expressed as a tree. The parent relation in the tree can be fetched via <see cref="CoreUI.UI.Widget.WidgetParent"/> . The parent relation should never be modified directly, instead you should use the APIs of the widgets (Typically <see cref="CoreUI.IPackLinear"/>, <see cref="CoreUI.IPackTable"/> or <see cref="CoreUI.IContent"/>).
    /// 
    /// Properties implemented here should be treated with extra care, some are defined for the sub-tree, others are defined for the widget itself, additional information for this can be fetched from the documentation in the implements section.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Widget.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Widget : CoreUI.Canvas.Group, CoreUI.IPart, CoreUI.UI.IPropertyBind, CoreUI.UI.IView
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Widget))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_widget_class_get();

        /// <summary>Initializes a new instance of the <see cref="Widget"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Widget(CoreUI.Object parent, System.String style = null) : base(efl_ui_widget_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Widget(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Widget"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Widget(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class WidgetRealized : Widget
        {
            private WidgetRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Widget"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Widget(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when widget was focused</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Focused
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIDGET_EVENT_FOCUSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIDGET_EVENT_FOCUSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Focused.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFocused()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIDGET_EVENT_FOCUSED", IntPtr.Zero, null);
        }

        /// <summary>Called when widget was unfocused</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Unfocused
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIDGET_EVENT_UNFOCUSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIDGET_EVENT_UNFOCUSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Unfocused.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnUnfocused()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIDGET_EVENT_UNFOCUSED", IntPtr.Zero, null);
        }

        public event EventHandler AtspiHighlighted
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event AtspiHighlighted.
        /// </summary>
        protected virtual void OnAtspiHighlighted()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED", IntPtr.Zero, null);
        }

        public event EventHandler AtspiUnhighlighted
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event AtspiUnhighlighted.
        /// </summary>
        protected virtual void OnAtspiUnhighlighted()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED", IntPtr.Zero, null);
        }


        /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertiesChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertiesChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertiesChanged(CoreUI.UI.PropertyBindPropertiesChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBound
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertyBoundEventArgs{ Arg = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(info) });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertyBound.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertyBound(CoreUI.UI.PropertyBindPropertyBoundEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND", info, (p) => CoreUI.DataTypes.MemoryNative.Free(p));
        }

        /// <summary>Event dispatched when a new model is set.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ViewModelChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ViewModelChangedEventArgs> ModelChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ViewModelChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ModelChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnModelChanged(CoreUI.UI.ViewModelChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_VIEW_EVENT_MODEL_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Background of the widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.WidgetPartBg BackgroundPart
        {
            get
            {
                return GetPart("background") as CoreUI.UI.WidgetPartBg;
            }
        }
        /// <summary>Drop-shadow or glow effect around the widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.WidgetPartShadow ShadowPart
        {
            get
            {
                return GetPart("shadow") as CoreUI.UI.WidgetPartShadow;
            }
        }
        /// <summary>This is the internal canvas object managed by a widget.
        /// 
        /// This property is protected as it is meant for widget implementations only, to set and access the internal canvas object. Do use this function unless you&apos;re implementing a widget.</summary>
        /// <param name="sobj">A canvas object (often a <span class="text-muted">CoreUI.Canvas.Layout (object still in beta stage)</span> object).</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void SetResizeObject(CoreUI.Canvas.Object sobj) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_resize_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether the widget is enabled (accepts and reacts to user inputs).
        /// 
        /// Each widget may handle the disabled state differently, but overall disabled widgets shall not respond to any input events. This is <c>false</c> by default, meaning the widget is enabled.
        /// 
        /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
        /// 
        /// This will return <c>true</c> if any widget in the parent hierarchy is disabled. Re-enabling that parent may in turn change the disabled state of this widget.</summary>
        /// <returns><c>true</c> if the widget is disabled.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetDisabled() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether the widget is enabled (accepts and reacts to user inputs).
        /// 
        /// Each widget may handle the disabled state differently, but overall disabled widgets shall not respond to any input events. This is <c>false</c> by default, meaning the widget is enabled.
        /// 
        /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
        /// 
        /// This will return <c>true</c> if any widget in the parent hierarchy is disabled. Re-enabling that parent may in turn change the disabled state of this widget.</summary>
        /// <param name="disabled"><c>true</c> if the widget is disabled.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDisabled(bool disabled) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), disabled);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The widget style to use.
        /// 
        /// Styles define different look and feel for widgets, and may provide different parts for layout-based widgets. Styles vary from widget to widget and may be defined by other themes by means of extensions and overlays.
        /// 
        /// The style can only be set before <see cref="CoreUI.Object.FinalizeAdd"/>, which means at construction time of the object (inside <c>efl_add</c> in C).</summary>
        /// <returns>Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetStyle() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The widget style to use.
        /// 
        /// Styles define different look and feel for widgets, and may provide different parts for layout-based widgets. Styles vary from widget to widget and may be defined by other themes by means of extensions and overlays.
        /// 
        /// The style can only be set before <see cref="CoreUI.Object.FinalizeAdd"/>, which means at construction time of the object (inside <c>efl_add</c> in C).</summary>
        /// <param name="style">Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</param>
        /// <returns>Whether the style was successfully applied or not, see the CoreUI.UI.Theme.Apply_Error subset of <see cref="CoreUI.DataTypes.Error"/> for more information.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetStyle(System.String style) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), style);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The ability for a widget to be focused.
        /// 
        /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
        /// 
        /// <b>NOTE: </b>Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
        /// 
        /// This property&apos;s default value depends on the widget (e.g. a box is not focusable, but a button is).</summary>
        /// <returns>Whether the object is focusable.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFocusAllow() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_allow_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The ability for a widget to be focused.
        /// 
        /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
        /// 
        /// <b>NOTE: </b>Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
        /// 
        /// This property&apos;s default value depends on the widget (e.g. a box is not focusable, but a button is).</summary>
        /// <param name="can_focus">Whether the object is focusable.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFocusAllow(bool can_focus) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_allow_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), can_focus);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The internal parent of this widget.
        /// 
        /// <see cref="CoreUI.UI.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="CoreUI.Object"/> or <see cref="CoreUI.Canvas.Object"/> hierarchy. This is meant for internal handling.</summary>
        /// <returns>Widget parent object</returns>
        /// <since_tizen> 6 </since_tizen>
        protected virtual CoreUI.UI.Widget GetWidgetParent() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The internal parent of this widget.
        /// 
        /// <see cref="CoreUI.UI.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="CoreUI.Object"/> or <see cref="CoreUI.Canvas.Object"/> hierarchy. This is meant for internal handling.</summary>
        /// <param name="parent">Widget parent object</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void SetWidgetParent(CoreUI.UI.Widget parent) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), parent);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
        /// 
        /// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
        /// 
        /// <b>NOTE: </b>The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.</summary>
        /// <returns>The relative region to show. If width or height is &lt;= 0 it will be ignored, and no action will be taken.</returns>
        /// <since_tizen> 6 </since_tizen>
        protected virtual CoreUI.DataTypes.Rect GetInterestRegion() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_interest_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The rectangle region to be highlighted on focus.
        /// 
        /// This is a rectangle region where the focus highlight should be displayed.</summary>
        /// <returns>The rectangle area.</returns>
        /// <since_tizen> 6 </since_tizen>
        protected virtual CoreUI.DataTypes.Rect GetFocusHighlightGeometry() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_highlight_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Set/unset focus to a given object.</summary>
        /// <returns><c>true</c> Set focus to a given object, <c>false</c> Unset focus to a given object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetWidgetFocus() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Set/unset focus to a given object.</summary>
        /// <param name="focus"><c>true</c> Set focus to a given object, <c>false</c> Unset focus to a given object.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetWidgetFocus(bool focus) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), focus);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Current focused object in object tree.</summary>
        /// <returns>Current focused or <c>null</c>, if there is no focused object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetFocusedObject() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focused_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The widget&apos;s focus move policy.</summary>
        /// <returns>Focus move policy</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.Focus.MovePolicy GetFocusMovePolicy() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_move_policy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The widget&apos;s focus move policy.</summary>
        /// <param name="policy">Focus move policy</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFocusMovePolicy(CoreUI.UI.Focus.MovePolicy policy) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_move_policy_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), policy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The duration factor for widget transit animation customize. zero(0) value can disable widget transition.</summary>
        /// <returns>duration factor for transit animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetTransitionDurationFactor() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_transition_duration_factor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The duration factor for widget transit animation customize. zero(0) value can disable widget transition.</summary>
        /// <param name="duration">duration factor for transit animation.</param>
        /// <returns><c>true</c> if successful.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetTransitionDurationFactor(double duration) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_transition_duration_factor_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), duration);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>&apos;Virtual&apos; function on the widget being set screen reader.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ScreenReader(bool is_screen_reader) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_screen_reader_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), is_screen_reader);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>&apos;Virtual&apos; function on the widget being set atspi.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Atspi(bool is_atspi) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_atspi_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), is_atspi);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Virtual function customizing sub objects being added.
        /// 
        /// When a widget is added as a sub-object of another widget (like list elements inside a list container, for example) some of its properties are automatically adapted to the parent&apos;s current values (like focus, access, theme, scale, mirror, scrollable child get, translate, display mode set, tree dump). Override this method if you want to customize differently sub-objects being added to this object.
        /// 
        /// Sub objects can be any canvas object, not necessarily widgets.
        /// 
        /// See also <see cref="CoreUI.UI.Widget.WidgetParent"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sub_obj">Sub object to be added. Not necessarily a widget itself.</param>
        /// <returns>Indicates if the operation succeeded.</returns>
        protected virtual bool AddWidgetSubObject(CoreUI.Canvas.Object sub_obj) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_sub_object_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sub_obj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Virtual function customizing sub objects being removed.
        /// 
        /// When a widget is removed as a sub-object from another widget (<see cref="CoreUI.IPack.Unpack"/>, <see cref="CoreUI.IContent.UnsetContent"/>, for example) some of its properties are automatically adjusted.(like focus, access, tree dump) Override this method if you want to customize differently sub-objects being removed to this object.
        /// 
        /// Sub objects can be any canvas object, not necessarily widgets.
        /// 
        /// See also <see cref="CoreUI.UI.Widget.WidgetParent"/> and <see cref="CoreUI.UI.Widget.AddWidgetSubObject"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sub_obj">Sub object to be removed. Should be a child of this widget.</param>
        /// <returns>Indicates if the operation succeeded.</returns>
        protected virtual bool DelWidgetSubObject(CoreUI.Canvas.Object sub_obj) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_sub_object_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sub_obj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Virtual function called when the widget needs to re-apply its theme.
        /// 
        /// This may be called when the object is first created, or whenever the widget is modified in any way that may require a reload of the theme. This may include but is not limited to scale, theme, or mirrored mode changes.
        /// 
        /// <b>NOTE: </b>even widgets not based on layouts may override this method to handle widget updates (scale, mirrored mode, etc...).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Indicates success, and if the current theme or default theme was used.</returns>
        protected virtual CoreUI.DataTypes.Error ApplyTheme() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_theme_apply_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get the access object of given part of the widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="part">The object&apos;s part name to get access object</param>
        public virtual CoreUI.Canvas.Object GetPartAccessObject(System.String part) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_part_access_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), part);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get newest focus in order</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="newest_focus_order">Newest focus order</param>
        /// <param name="can_focus_only"><c>true</c> only us widgets which can focus, <c>false</c> otherweise</param>
        /// <returns>Handle to focused widget</returns>
        public virtual CoreUI.Canvas.Object GetNewestFocusOrder(out uint newest_focus_order, bool can_focus_only) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_newest_focus_order_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out newest_focus_order, can_focus_only);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Set the next object with specific focus direction.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="next">Focus next object</param>
        /// <param name="dir">Focus direction</param>
        public virtual void SetFocusNextObject(CoreUI.Canvas.Object next, CoreUI.UI.Focus.Direction dir) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_next_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), next, dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get the next object with specific focus direction.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dir">Focus direction</param>
        /// <returns>Focus next object</returns>
        public virtual CoreUI.Canvas.Object GetFocusNextObject(CoreUI.UI.Focus.Direction dir) {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_next_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Handle focus tree unfocusable</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void FocusTreeUnfocusableHandle() {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_tree_unfocusable_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Give focus to next object with specific focus direction in object tree.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dir">Direction to move the focus.</param>
        public virtual void FocusCycle(CoreUI.UI.Focus.Direction dir) {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_cycle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Handle focus mouse up</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void FocusMouseUpHandle() {
            CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_mouse_up_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Virtual function which checks if this widget can handle passing focus to sub-object, in a given direction.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
        protected virtual bool IsFocusDirectionManager() {
            var _ret_var = CoreUI.UI.Widget.NativeMethods.efl_ui_widget_focus_direction_manager_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get a proxy object referring to a part of an object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="name">The part name.</param>
        /// <returns>A (proxy) object, valid for a single call.</returns>
        public virtual CoreUI.Object GetPart(System.String name) {
            var _ret_var = CoreUI.IPartNativeMethods.efl_part_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">key string for bind model property data</param>
        /// <param name="property">Model property name</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        public virtual CoreUI.DataTypes.Error BindProperty(System.String key, System.String property) {
            var _ret_var = CoreUI.UI.IPropertyBindNativeMethods.efl_ui_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key, property);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Model that is/will be</summary>
        /// <returns>CoreUI model</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.IModel GetModel() {
            var _ret_var = CoreUI.UI.IViewNativeMethods.efl_ui_view_model_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Model that is/will be</summary>
        /// <param name="model">CoreUI model</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetModel(CoreUI.IModel model) {
            CoreUI.UI.IViewNativeMethods.efl_ui_view_model_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), model);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether the widget is enabled (accepts and reacts to user inputs).
        /// 
        /// Each widget may handle the disabled state differently, but overall disabled widgets shall not respond to any input events. This is <c>false</c> by default, meaning the widget is enabled.
        /// 
        /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
        /// 
        /// This will return <c>true</c> if any widget in the parent hierarchy is disabled. Re-enabling that parent may in turn change the disabled state of this widget.</summary>
        /// <value><c>true</c> if the widget is disabled.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Disabled {
            get { return GetDisabled(); }
            set { SetDisabled(value); }
        }

        /// <summary>The widget style to use.
        /// 
        /// Styles define different look and feel for widgets, and may provide different parts for layout-based widgets. Styles vary from widget to widget and may be defined by other themes by means of extensions and overlays.
        /// 
        /// The style can only be set before <see cref="CoreUI.Object.FinalizeAdd"/>, which means at construction time of the object (inside <c>efl_add</c> in C).</summary>
        /// <value>Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Style {
            get { return GetStyle(); }
            set { SetStyle(value); }
        }

        /// <summary>The ability for a widget to be focused.
        /// 
        /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
        /// 
        /// <b>NOTE: </b>Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
        /// 
        /// This property&apos;s default value depends on the widget (e.g. a box is not focusable, but a button is).</summary>
        /// <value>Whether the object is focusable.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool FocusAllow {
            get { return GetFocusAllow(); }
            set { SetFocusAllow(value); }
        }

        /// <summary>The internal parent of this widget.
        /// 
        /// <see cref="CoreUI.UI.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="CoreUI.Object"/> or <see cref="CoreUI.Canvas.Object"/> hierarchy. This is meant for internal handling.</summary>
        /// <value>Widget parent object</value>
        /// <since_tizen> 6 </since_tizen>
        protected CoreUI.UI.Widget WidgetParent {
            get { return GetWidgetParent(); }
            set { SetWidgetParent(value); }
        }

        /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
        /// 
        /// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
        /// 
        /// <b>NOTE: </b>The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.</summary>
        /// <value>The relative region to show. If width or height is &lt;= 0 it will be ignored, and no action will be taken.</value>
        /// <since_tizen> 6 </since_tizen>
        protected CoreUI.DataTypes.Rect InterestRegion {
            get { return GetInterestRegion(); }
        }

        /// <summary>The rectangle region to be highlighted on focus.
        /// 
        /// This is a rectangle region where the focus highlight should be displayed.</summary>
        /// <value>The rectangle area.</value>
        /// <since_tizen> 6 </since_tizen>
        protected CoreUI.DataTypes.Rect FocusHighlightGeometry {
            get { return GetFocusHighlightGeometry(); }
        }

        /// <summary>Set/unset focus to a given object.</summary>
        /// <value><c>true</c> Set focus to a given object, <c>false</c> Unset focus to a given object.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Focus {
            get { return GetWidgetFocus(); }
            set { SetWidgetFocus(value); }
        }

        /// <summary>Current focused object in object tree.</summary>
        /// <value>Current focused or <c>null</c>, if there is no focused object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object FocusedObject {
            get { return GetFocusedObject(); }
        }

        /// <summary>The widget&apos;s focus move policy.</summary>
        /// <value>Focus move policy</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.Focus.MovePolicy FocusMovePolicy {
            get { return GetFocusMovePolicy(); }
            set { SetFocusMovePolicy(value); }
        }

        /// <summary>The duration factor for widget transit animation customize. zero(0) value can disable widget transition.</summary>
        /// <value>duration factor for transit animation.</value>
        /// <since_tizen> 6 </since_tizen>
        public double TransitionDurationFactor {
            get { return GetTransitionDurationFactor(); }
            set { SetTransitionDurationFactor(value); }
        }

        /// <summary>Model that is/will be</summary>
        /// <value>CoreUI model</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IModel Model {
            get { return GetModel(); }
            set { SetModel(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Widget.efl_ui_widget_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Canvas.Group.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_widget_resize_object_set_static_delegate == null)
                {
                    efl_ui_widget_resize_object_set_static_delegate = new efl_ui_widget_resize_object_set_delegate(resize_object_set);
                }

                if (methods.Contains("SetResizeObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_resize_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_resize_object_set_static_delegate) });
                }

                if (efl_ui_widget_disabled_get_static_delegate == null)
                {
                    efl_ui_widget_disabled_get_static_delegate = new efl_ui_widget_disabled_get_delegate(disabled_get);
                }

                if (methods.Contains("GetDisabled"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_get_static_delegate) });
                }

                if (efl_ui_widget_disabled_set_static_delegate == null)
                {
                    efl_ui_widget_disabled_set_static_delegate = new efl_ui_widget_disabled_set_delegate(disabled_set);
                }

                if (methods.Contains("SetDisabled"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_set_static_delegate) });
                }

                if (efl_ui_widget_style_get_static_delegate == null)
                {
                    efl_ui_widget_style_get_static_delegate = new efl_ui_widget_style_get_delegate(style_get);
                }

                if (methods.Contains("GetStyle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_get_static_delegate) });
                }

                if (efl_ui_widget_style_set_static_delegate == null)
                {
                    efl_ui_widget_style_set_static_delegate = new efl_ui_widget_style_set_delegate(style_set);
                }

                if (methods.Contains("SetStyle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_set_static_delegate) });
                }

                if (efl_ui_widget_focus_allow_get_static_delegate == null)
                {
                    efl_ui_widget_focus_allow_get_static_delegate = new efl_ui_widget_focus_allow_get_delegate(focus_allow_get);
                }

                if (methods.Contains("GetFocusAllow"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_get_static_delegate) });
                }

                if (efl_ui_widget_focus_allow_set_static_delegate == null)
                {
                    efl_ui_widget_focus_allow_set_static_delegate = new efl_ui_widget_focus_allow_set_delegate(focus_allow_set);
                }

                if (methods.Contains("SetFocusAllow"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_set_static_delegate) });
                }

                if (efl_ui_widget_parent_get_static_delegate == null)
                {
                    efl_ui_widget_parent_get_static_delegate = new efl_ui_widget_parent_get_delegate(widget_parent_get);
                }

                if (methods.Contains("GetWidgetParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_get_static_delegate) });
                }

                if (efl_ui_widget_parent_set_static_delegate == null)
                {
                    efl_ui_widget_parent_set_static_delegate = new efl_ui_widget_parent_set_delegate(widget_parent_set);
                }

                if (methods.Contains("SetWidgetParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_set_static_delegate) });
                }

                if (efl_ui_widget_interest_region_get_static_delegate == null)
                {
                    efl_ui_widget_interest_region_get_static_delegate = new efl_ui_widget_interest_region_get_delegate(interest_region_get);
                }

                if (methods.Contains("GetInterestRegion"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_interest_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_interest_region_get_static_delegate) });
                }

                if (efl_ui_widget_focus_highlight_geometry_get_static_delegate == null)
                {
                    efl_ui_widget_focus_highlight_geometry_get_static_delegate = new efl_ui_widget_focus_highlight_geometry_get_delegate(focus_highlight_geometry_get);
                }

                if (methods.Contains("GetFocusHighlightGeometry"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_highlight_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_geometry_get_static_delegate) });
                }

                if (efl_ui_widget_focus_get_static_delegate == null)
                {
                    efl_ui_widget_focus_get_static_delegate = new efl_ui_widget_focus_get_delegate(widget_focus_get);
                }

                if (methods.Contains("GetWidgetFocus"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_get_static_delegate) });
                }

                if (efl_ui_widget_focus_set_static_delegate == null)
                {
                    efl_ui_widget_focus_set_static_delegate = new efl_ui_widget_focus_set_delegate(widget_focus_set);
                }

                if (methods.Contains("SetWidgetFocus"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_set_static_delegate) });
                }

                if (efl_ui_widget_focused_object_get_static_delegate == null)
                {
                    efl_ui_widget_focused_object_get_static_delegate = new efl_ui_widget_focused_object_get_delegate(focused_object_get);
                }

                if (methods.Contains("GetFocusedObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focused_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_object_get_static_delegate) });
                }

                if (efl_ui_widget_focus_move_policy_get_static_delegate == null)
                {
                    efl_ui_widget_focus_move_policy_get_static_delegate = new efl_ui_widget_focus_move_policy_get_delegate(focus_move_policy_get);
                }

                if (methods.Contains("GetFocusMovePolicy"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_get_static_delegate) });
                }

                if (efl_ui_widget_focus_move_policy_set_static_delegate == null)
                {
                    efl_ui_widget_focus_move_policy_set_static_delegate = new efl_ui_widget_focus_move_policy_set_delegate(focus_move_policy_set);
                }

                if (methods.Contains("SetFocusMovePolicy"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_set_static_delegate) });
                }

                if (efl_ui_widget_transition_duration_factor_get_static_delegate == null)
                {
                    efl_ui_widget_transition_duration_factor_get_static_delegate = new efl_ui_widget_transition_duration_factor_get_delegate(transition_duration_factor_get);
                }

                if (methods.Contains("GetTransitionDurationFactor"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_transition_duration_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_transition_duration_factor_get_static_delegate) });
                }

                if (efl_ui_widget_transition_duration_factor_set_static_delegate == null)
                {
                    efl_ui_widget_transition_duration_factor_set_static_delegate = new efl_ui_widget_transition_duration_factor_set_delegate(transition_duration_factor_set);
                }

                if (methods.Contains("SetTransitionDurationFactor"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_transition_duration_factor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_transition_duration_factor_set_static_delegate) });
                }

                if (efl_ui_widget_screen_reader_static_delegate == null)
                {
                    efl_ui_widget_screen_reader_static_delegate = new efl_ui_widget_screen_reader_delegate(screen_reader);
                }

                if (methods.Contains("ScreenReader"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_screen_reader"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_screen_reader_static_delegate) });
                }

                if (efl_ui_widget_atspi_static_delegate == null)
                {
                    efl_ui_widget_atspi_static_delegate = new efl_ui_widget_atspi_delegate(atspi);
                }

                if (methods.Contains("Atspi"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_atspi"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_atspi_static_delegate) });
                }

                if (efl_ui_widget_sub_object_add_static_delegate == null)
                {
                    efl_ui_widget_sub_object_add_static_delegate = new efl_ui_widget_sub_object_add_delegate(widget_sub_object_add);
                }

                if (methods.Contains("AddWidgetSubObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_sub_object_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_add_static_delegate) });
                }

                if (efl_ui_widget_sub_object_del_static_delegate == null)
                {
                    efl_ui_widget_sub_object_del_static_delegate = new efl_ui_widget_sub_object_del_delegate(widget_sub_object_del);
                }

                if (methods.Contains("DelWidgetSubObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_sub_object_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_del_static_delegate) });
                }

                if (efl_ui_widget_theme_apply_static_delegate == null)
                {
                    efl_ui_widget_theme_apply_static_delegate = new efl_ui_widget_theme_apply_delegate(theme_apply);
                }

                if (methods.Contains("ApplyTheme"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_theme_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_theme_apply_static_delegate) });
                }

                if (efl_ui_widget_part_access_object_get_static_delegate == null)
                {
                    efl_ui_widget_part_access_object_get_static_delegate = new efl_ui_widget_part_access_object_get_delegate(part_access_object_get);
                }

                if (methods.Contains("GetPartAccessObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_part_access_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_part_access_object_get_static_delegate) });
                }

                if (efl_ui_widget_newest_focus_order_get_static_delegate == null)
                {
                    efl_ui_widget_newest_focus_order_get_static_delegate = new efl_ui_widget_newest_focus_order_get_delegate(newest_focus_order_get);
                }

                if (methods.Contains("GetNewestFocusOrder"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_newest_focus_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_newest_focus_order_get_static_delegate) });
                }

                if (efl_ui_widget_focus_next_object_set_static_delegate == null)
                {
                    efl_ui_widget_focus_next_object_set_static_delegate = new efl_ui_widget_focus_next_object_set_delegate(focus_next_object_set);
                }

                if (methods.Contains("SetFocusNextObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_set_static_delegate) });
                }

                if (efl_ui_widget_focus_next_object_get_static_delegate == null)
                {
                    efl_ui_widget_focus_next_object_get_static_delegate = new efl_ui_widget_focus_next_object_get_delegate(focus_next_object_get);
                }

                if (methods.Contains("GetFocusNextObject"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_get_static_delegate) });
                }

                if (efl_ui_widget_focus_tree_unfocusable_handle_static_delegate == null)
                {
                    efl_ui_widget_focus_tree_unfocusable_handle_static_delegate = new efl_ui_widget_focus_tree_unfocusable_handle_delegate(focus_tree_unfocusable_handle);
                }

                if (methods.Contains("FocusTreeUnfocusableHandle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_tree_unfocusable_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_tree_unfocusable_handle_static_delegate) });
                }

                if (efl_ui_widget_focus_cycle_static_delegate == null)
                {
                    efl_ui_widget_focus_cycle_static_delegate = new efl_ui_widget_focus_cycle_delegate(focus_cycle);
                }

                if (methods.Contains("FocusCycle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_cycle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_cycle_static_delegate) });
                }

                if (efl_ui_widget_focus_mouse_up_handle_static_delegate == null)
                {
                    efl_ui_widget_focus_mouse_up_handle_static_delegate = new efl_ui_widget_focus_mouse_up_handle_delegate(focus_mouse_up_handle);
                }

                if (methods.Contains("FocusMouseUpHandle"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_mouse_up_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_mouse_up_handle_static_delegate) });
                }

                if (efl_ui_widget_focus_direction_manager_is_static_delegate == null)
                {
                    efl_ui_widget_focus_direction_manager_is_static_delegate = new efl_ui_widget_focus_direction_manager_is_delegate(focus_direction_manager_is);
                }

                if (methods.Contains("IsFocusDirectionManager"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_direction_manager_is"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_manager_is_static_delegate) });
                }

                if (efl_part_get_static_delegate == null)
                {
                    efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
                }

                if (methods.Contains("GetPart"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Widget.efl_ui_widget_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_widget_resize_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sobj);

            
            internal delegate void efl_ui_widget_resize_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sobj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_resize_object_set_api_delegate> efl_ui_widget_resize_object_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_resize_object_set_api_delegate>(Module, "efl_ui_widget_resize_object_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void resize_object_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sobj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_resize_object_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetResizeObject(sobj);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_resize_object_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sobj);
                }
            }

            private static efl_ui_widget_resize_object_set_delegate efl_ui_widget_resize_object_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_disabled_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_disabled_get_api_delegate> efl_ui_widget_disabled_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_disabled_get_api_delegate>(Module, "efl_ui_widget_disabled_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool disabled_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_disabled_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetDisabled();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_disabled_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_disabled_get_delegate efl_ui_widget_disabled_get_static_delegate;

            
            private delegate void efl_ui_widget_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool disabled);

            
            internal delegate void efl_ui_widget_disabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool disabled);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_disabled_set_api_delegate> efl_ui_widget_disabled_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_disabled_set_api_delegate>(Module, "efl_ui_widget_disabled_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void disabled_set(System.IntPtr obj, System.IntPtr pd, bool disabled)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_disabled_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetDisabled(disabled);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_disabled_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), disabled);
                }
            }

            private static efl_ui_widget_disabled_set_delegate efl_ui_widget_disabled_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_ui_widget_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_ui_widget_style_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_style_get_api_delegate> efl_ui_widget_style_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_style_get_api_delegate>(Module, "efl_ui_widget_style_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String style_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_style_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetStyle();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_style_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_style_get_delegate efl_ui_widget_style_get_static_delegate;

            
            private delegate CoreUI.DataTypes.Error efl_ui_widget_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            
            internal delegate CoreUI.DataTypes.Error efl_ui_widget_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_style_set_api_delegate> efl_ui_widget_style_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_style_set_api_delegate>(Module, "efl_ui_widget_style_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Error style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_style_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).SetStyle(style);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_style_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), style);
                }
            }

            private static efl_ui_widget_style_set_delegate efl_ui_widget_style_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_focus_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_focus_allow_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_allow_get_api_delegate> efl_ui_widget_focus_allow_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_allow_get_api_delegate>(Module, "efl_ui_widget_focus_allow_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool focus_allow_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_allow_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetFocusAllow();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_allow_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_allow_get_delegate efl_ui_widget_focus_allow_get_static_delegate;

            
            private delegate void efl_ui_widget_focus_allow_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_focus);

            
            internal delegate void efl_ui_widget_focus_allow_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_focus);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_allow_set_api_delegate> efl_ui_widget_focus_allow_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_allow_set_api_delegate>(Module, "efl_ui_widget_focus_allow_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_allow_set(System.IntPtr obj, System.IntPtr pd, bool can_focus)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_allow_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetFocusAllow(can_focus);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_allow_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), can_focus);
                }
            }

            private static efl_ui_widget_focus_allow_set_delegate efl_ui_widget_focus_allow_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.UI.Widget efl_ui_widget_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.UI.Widget efl_ui_widget_parent_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_parent_get_api_delegate> efl_ui_widget_parent_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_parent_get_api_delegate>(Module, "efl_ui_widget_parent_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.Widget widget_parent_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_parent_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.Widget _ret_var = default(CoreUI.UI.Widget);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetWidgetParent();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_parent_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_parent_get_delegate efl_ui_widget_parent_get_static_delegate;

            
            private delegate void efl_ui_widget_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget parent);

            
            internal delegate void efl_ui_widget_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Widget parent);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_parent_set_api_delegate> efl_ui_widget_parent_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_parent_set_api_delegate>(Module, "efl_ui_widget_parent_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void widget_parent_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Widget parent)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_parent_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetWidgetParent(parent);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_parent_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), parent);
                }
            }

            private static efl_ui_widget_parent_set_delegate efl_ui_widget_parent_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Rect efl_ui_widget_interest_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Rect efl_ui_widget_interest_region_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_interest_region_get_api_delegate> efl_ui_widget_interest_region_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_interest_region_get_api_delegate>(Module, "efl_ui_widget_interest_region_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Rect interest_region_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_interest_region_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetInterestRegion();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_interest_region_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_interest_region_get_delegate efl_ui_widget_interest_region_get_static_delegate;

            
            private delegate CoreUI.DataTypes.Rect efl_ui_widget_focus_highlight_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Rect efl_ui_widget_focus_highlight_geometry_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_highlight_geometry_get_api_delegate> efl_ui_widget_focus_highlight_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_highlight_geometry_get_api_delegate>(Module, "efl_ui_widget_focus_highlight_geometry_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Rect focus_highlight_geometry_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_highlight_geometry_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetFocusHighlightGeometry();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_highlight_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_highlight_geometry_get_delegate efl_ui_widget_focus_highlight_geometry_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_focus_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_get_api_delegate> efl_ui_widget_focus_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_get_api_delegate>(Module, "efl_ui_widget_focus_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool widget_focus_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetWidgetFocus();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_get_delegate efl_ui_widget_focus_get_static_delegate;

            
            private delegate void efl_ui_widget_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool focus);

            
            internal delegate void efl_ui_widget_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool focus);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_set_api_delegate> efl_ui_widget_focus_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_set_api_delegate>(Module, "efl_ui_widget_focus_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void widget_focus_set(System.IntPtr obj, System.IntPtr pd, bool focus)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetWidgetFocus(focus);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), focus);
                }
            }

            private static efl_ui_widget_focus_set_delegate efl_ui_widget_focus_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_widget_focused_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_widget_focused_object_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focused_object_get_api_delegate> efl_ui_widget_focused_object_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focused_object_get_api_delegate>(Module, "efl_ui_widget_focused_object_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object focused_object_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focused_object_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetFocusedObject();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focused_object_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focused_object_get_delegate efl_ui_widget_focused_object_get_static_delegate;

            
            private delegate CoreUI.UI.Focus.MovePolicy efl_ui_widget_focus_move_policy_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.UI.Focus.MovePolicy efl_ui_widget_focus_move_policy_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_move_policy_get_api_delegate> efl_ui_widget_focus_move_policy_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_move_policy_get_api_delegate>(Module, "efl_ui_widget_focus_move_policy_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.Focus.MovePolicy focus_move_policy_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_move_policy_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.Focus.MovePolicy _ret_var = default(CoreUI.UI.Focus.MovePolicy);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetFocusMovePolicy();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_move_policy_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_move_policy_get_delegate efl_ui_widget_focus_move_policy_get_static_delegate;

            
            private delegate void efl_ui_widget_focus_move_policy_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.Focus.MovePolicy policy);

            
            internal delegate void efl_ui_widget_focus_move_policy_set_api_delegate(System.IntPtr obj,  CoreUI.UI.Focus.MovePolicy policy);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_move_policy_set_api_delegate> efl_ui_widget_focus_move_policy_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_move_policy_set_api_delegate>(Module, "efl_ui_widget_focus_move_policy_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_move_policy_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Focus.MovePolicy policy)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_move_policy_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetFocusMovePolicy(policy);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_move_policy_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), policy);
                }
            }

            private static efl_ui_widget_focus_move_policy_set_delegate efl_ui_widget_focus_move_policy_set_static_delegate;

            
            private delegate double efl_ui_widget_transition_duration_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_ui_widget_transition_duration_factor_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_transition_duration_factor_get_api_delegate> efl_ui_widget_transition_duration_factor_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_transition_duration_factor_get_api_delegate>(Module, "efl_ui_widget_transition_duration_factor_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double transition_duration_factor_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_transition_duration_factor_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetTransitionDurationFactor();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_transition_duration_factor_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_transition_duration_factor_get_delegate efl_ui_widget_transition_duration_factor_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_transition_duration_factor_set_delegate(System.IntPtr obj, System.IntPtr pd,  double duration);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_transition_duration_factor_set_api_delegate(System.IntPtr obj,  double duration);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_transition_duration_factor_set_api_delegate> efl_ui_widget_transition_duration_factor_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_transition_duration_factor_set_api_delegate>(Module, "efl_ui_widget_transition_duration_factor_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool transition_duration_factor_set(System.IntPtr obj, System.IntPtr pd, double duration)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_transition_duration_factor_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).SetTransitionDurationFactor(duration);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_transition_duration_factor_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), duration);
                }
            }

            private static efl_ui_widget_transition_duration_factor_set_delegate efl_ui_widget_transition_duration_factor_set_static_delegate;

            
            private delegate void efl_ui_widget_screen_reader_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_screen_reader);

            
            internal delegate void efl_ui_widget_screen_reader_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_screen_reader);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_screen_reader_api_delegate> efl_ui_widget_screen_reader_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_screen_reader_api_delegate>(Module, "efl_ui_widget_screen_reader");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void screen_reader(System.IntPtr obj, System.IntPtr pd, bool is_screen_reader)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_screen_reader was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).ScreenReader(is_screen_reader);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_screen_reader_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), is_screen_reader);
                }
            }

            private static efl_ui_widget_screen_reader_delegate efl_ui_widget_screen_reader_static_delegate;

            
            private delegate void efl_ui_widget_atspi_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_atspi);

            
            internal delegate void efl_ui_widget_atspi_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_atspi);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_atspi_api_delegate> efl_ui_widget_atspi_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_atspi_api_delegate>(Module, "efl_ui_widget_atspi");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void atspi(System.IntPtr obj, System.IntPtr pd, bool is_atspi)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_atspi was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).Atspi(is_atspi);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_atspi_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), is_atspi);
                }
            }

            private static efl_ui_widget_atspi_delegate efl_ui_widget_atspi_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_sub_object_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_sub_object_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_sub_object_add_api_delegate> efl_ui_widget_sub_object_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_sub_object_add_api_delegate>(Module, "efl_ui_widget_sub_object_add");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool widget_sub_object_add(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sub_obj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_sub_object_add was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).AddWidgetSubObject(sub_obj);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_sub_object_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sub_obj);
                }
            }

            private static efl_ui_widget_sub_object_add_delegate efl_ui_widget_sub_object_add_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_sub_object_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_sub_object_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_sub_object_del_api_delegate> efl_ui_widget_sub_object_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_sub_object_del_api_delegate>(Module, "efl_ui_widget_sub_object_del");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool widget_sub_object_del(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sub_obj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_sub_object_del was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).DelWidgetSubObject(sub_obj);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_sub_object_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sub_obj);
                }
            }

            private static efl_ui_widget_sub_object_del_delegate efl_ui_widget_sub_object_del_static_delegate;

            
            private delegate CoreUI.DataTypes.Error efl_ui_widget_theme_apply_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Error efl_ui_widget_theme_apply_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_theme_apply_api_delegate> efl_ui_widget_theme_apply_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_theme_apply_api_delegate>(Module, "efl_ui_widget_theme_apply");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Error theme_apply(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_theme_apply was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).ApplyTheme();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_theme_apply_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_theme_apply_delegate efl_ui_widget_theme_apply_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_widget_part_access_object_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String part);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_widget_part_access_object_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String part);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_part_access_object_get_api_delegate> efl_ui_widget_part_access_object_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_part_access_object_get_api_delegate>(Module, "efl_ui_widget_part_access_object_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object part_access_object_get(System.IntPtr obj, System.IntPtr pd, System.String part)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_part_access_object_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetPartAccessObject(part);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_part_access_object_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), part);
                }
            }

            private static efl_ui_widget_part_access_object_get_delegate efl_ui_widget_part_access_object_get_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_widget_newest_focus_order_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint newest_focus_order, [MarshalAs(UnmanagedType.U1)] bool can_focus_only);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_widget_newest_focus_order_get_api_delegate(System.IntPtr obj,  out uint newest_focus_order, [MarshalAs(UnmanagedType.U1)] bool can_focus_only);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_newest_focus_order_get_api_delegate> efl_ui_widget_newest_focus_order_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_newest_focus_order_get_api_delegate>(Module, "efl_ui_widget_newest_focus_order_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object newest_focus_order_get(System.IntPtr obj, System.IntPtr pd, out uint newest_focus_order, bool can_focus_only)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_newest_focus_order_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    newest_focus_order = default(uint);CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetNewestFocusOrder(out newest_focus_order, can_focus_only);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_newest_focus_order_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out newest_focus_order, can_focus_only);
                }
            }

            private static efl_ui_widget_newest_focus_order_get_delegate efl_ui_widget_newest_focus_order_get_static_delegate;

            
            private delegate void efl_ui_widget_focus_next_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object next,  CoreUI.UI.Focus.Direction dir);

            
            internal delegate void efl_ui_widget_focus_next_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object next,  CoreUI.UI.Focus.Direction dir);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_next_object_set_api_delegate> efl_ui_widget_focus_next_object_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_next_object_set_api_delegate>(Module, "efl_ui_widget_focus_next_object_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_next_object_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object next, CoreUI.UI.Focus.Direction dir)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_next_object_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).SetFocusNextObject(next, dir);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_next_object_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), next, dir);
                }
            }

            private static efl_ui_widget_focus_next_object_set_delegate efl_ui_widget_focus_next_object_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_ui_widget_focus_next_object_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.Focus.Direction dir);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_ui_widget_focus_next_object_get_api_delegate(System.IntPtr obj,  CoreUI.UI.Focus.Direction dir);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_next_object_get_api_delegate> efl_ui_widget_focus_next_object_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_next_object_get_api_delegate>(Module, "efl_ui_widget_focus_next_object_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object focus_next_object_get(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Focus.Direction dir)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_next_object_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetFocusNextObject(dir);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_next_object_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dir);
                }
            }

            private static efl_ui_widget_focus_next_object_get_delegate efl_ui_widget_focus_next_object_get_static_delegate;

            
            private delegate void efl_ui_widget_focus_tree_unfocusable_handle_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_ui_widget_focus_tree_unfocusable_handle_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_tree_unfocusable_handle_api_delegate> efl_ui_widget_focus_tree_unfocusable_handle_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_tree_unfocusable_handle_api_delegate>(Module, "efl_ui_widget_focus_tree_unfocusable_handle");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_tree_unfocusable_handle(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_tree_unfocusable_handle was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).FocusTreeUnfocusableHandle();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_tree_unfocusable_handle_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_tree_unfocusable_handle_delegate efl_ui_widget_focus_tree_unfocusable_handle_static_delegate;

            
            private delegate void efl_ui_widget_focus_cycle_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.Focus.Direction dir);

            
            internal delegate void efl_ui_widget_focus_cycle_api_delegate(System.IntPtr obj,  CoreUI.UI.Focus.Direction dir);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_cycle_api_delegate> efl_ui_widget_focus_cycle_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_cycle_api_delegate>(Module, "efl_ui_widget_focus_cycle");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_cycle(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Focus.Direction dir)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_cycle was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).FocusCycle(dir);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_cycle_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dir);
                }
            }

            private static efl_ui_widget_focus_cycle_delegate efl_ui_widget_focus_cycle_static_delegate;

            
            private delegate void efl_ui_widget_focus_mouse_up_handle_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_ui_widget_focus_mouse_up_handle_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_mouse_up_handle_api_delegate> efl_ui_widget_focus_mouse_up_handle_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_mouse_up_handle_api_delegate>(Module, "efl_ui_widget_focus_mouse_up_handle");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void focus_mouse_up_handle(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_mouse_up_handle was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Widget)ws.Target).FocusMouseUpHandle();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_widget_focus_mouse_up_handle_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_mouse_up_handle_delegate efl_ui_widget_focus_mouse_up_handle_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_widget_focus_direction_manager_is_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_widget_focus_direction_manager_is_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_direction_manager_is_api_delegate> efl_ui_widget_focus_direction_manager_is_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_widget_focus_direction_manager_is_api_delegate>(Module, "efl_ui_widget_focus_direction_manager_is");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool focus_direction_manager_is(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_widget_focus_direction_manager_is was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).IsFocusDirectionManager();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_widget_focus_direction_manager_is_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_widget_focus_direction_manager_is_delegate efl_ui_widget_focus_direction_manager_is_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_part_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_part_get_api_delegate>(Module, "efl_part_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object part_get(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_part_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((Widget)ws.Target).GetPart(name);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_part_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_part_get_delegate efl_part_get_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class WidgetExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> ResizeObject<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("resize_object", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Disabled<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<bool>("disabled", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Style<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<System.String>("style", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> FocusAllow<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<bool>("focus_allow", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.Widget> WidgetParent<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<CoreUI.UI.Widget>("widget_parent", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Focus<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<bool>("widget_focus", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.Focus.MovePolicy> FocusMovePolicy<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<CoreUI.UI.Focus.MovePolicy>("focus_move_policy", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TransitionDurationFactor<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<double>("transition_duration_factor", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.IModel> Model<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T>magic = null) where T : CoreUI.UI.Widget {
            return new CoreUI.BindableProperty<CoreUI.IModel>("model", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindablePart<CoreUI.UI.WidgetPartBg> BackgroundPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T> x=null) where T : CoreUI.UI.Widget
        {
            return new CoreUI.BindablePart<CoreUI.UI.WidgetPartBg>("background", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindablePart<CoreUI.UI.WidgetPartShadow> ShadowPart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Widget, T> x=null) where T : CoreUI.UI.Widget
        {
            return new CoreUI.BindablePart<CoreUI.UI.WidgetPartShadow>("shadow", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

