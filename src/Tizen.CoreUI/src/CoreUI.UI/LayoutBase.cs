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
    /// <summary>EFL layout widget abstract.
    /// 
    /// A &quot;layout&quot; in the context of EFL is an object which interfaces with the internal layout engine. Layouts are created using the EDC language, and any widget which implements this abstract must have a corresponding theme group to load in order to graphically display anything.
    /// 
    /// Theme groups for EFL widgets must be versioned. This means having a &quot;version&quot; <c>data.item</c> key in the theme group for the widget. If the loaded theme group for a widget has version info which is lower than the currently-running EFL version, a warning will be printed to notify the user that new features may be available. If the loaded theme group for a widget has no version info, an error will be generated. If the loaded theme group for a widget has a version that is newer than the currently-running EFL version, a critical error will be printed to notify the user that the theme may not be compatible.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.LayoutBase.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class LayoutBase : CoreUI.UI.Widget, CoreUI.IContainer, CoreUI.Layout.ICalc, CoreUI.Layout.IGroup, CoreUI.Layout.ISignal, CoreUI.UI.IFactoryBind
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(LayoutBase))
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
            efl_ui_layout_base_class_get();

        /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public LayoutBase(CoreUI.Object parent, System.String style = null) : base(efl_ui_layout_base_class_get(), parent)
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
        protected LayoutBase(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal LayoutBase(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class LayoutBaseRealized : LayoutBase
        {
            private LayoutBaseRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="LayoutBase"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected LayoutBase(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when theme changed</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ThemeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ThemeChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnThemeChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_LAYOUT_EVENT_THEME_CHANGED", IntPtr.Zero, null);
        }


        /// <summary>Sent after a new sub-object was added.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
        public event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAdded
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentAddedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentAdded.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentAdded(CoreUI.ContainerContentAddedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTAINER_EVENT_CONTENT_ADDED", info, null);
        }

        /// <summary>Sent after a sub-object was removed, before unref.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
        public event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemoved
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentRemovedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentRemoved.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentRemoved(CoreUI.ContainerContentRemovedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTAINER_EVENT_CONTENT_REMOVED", info, null);
        }

        /// <summary>The layout was recalculated.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Recalc
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Recalc.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnRecalc()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_LAYOUT_EVENT_RECALC", IntPtr.Zero, null);
        }

        /// <summary>A circular dependency between parts of the object was found.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Layout.CalcCircularDependencyEventArgs"/></value>
        public event EventHandler<CoreUI.Layout.CalcCircularDependencyEventArgs> CircularDependency
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Layout.CalcCircularDependencyEventArgs{ Arg = CoreUI.Wrapper.Globals.NativeArrayToIList<System.String>(info) });
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event CircularDependency.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnCircularDependency(CoreUI.Layout.CalcCircularDependencyEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.Wrapper.Globals.IListToNativeArray(e.Arg, false);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY", info, null);
        }

        /// <summary>Set a multiplier for applying finger size to the layout.
        /// 
        /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
        /// 
        /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
        /// <param name="multiplier_x">Multiplier for X axis.</param>
        /// <param name="multiplier_y">Multiplier for Y axis.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetFingerSizeMultiplier(out uint multiplier_x, out uint multiplier_y) {
            CoreUI.UI.LayoutBase.NativeMethods.efl_ui_layout_finger_size_multiplier_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out multiplier_x, out multiplier_y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Set a multiplier for applying finger size to the layout.
        /// 
        /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
        /// 
        /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
        /// <param name="multiplier_x">Multiplier for X axis.</param>
        /// <param name="multiplier_y">Multiplier for Y axis.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFingerSizeMultiplier(uint multiplier_x, uint multiplier_y) {
            CoreUI.UI.LayoutBase.NativeMethods.efl_ui_layout_finger_size_multiplier_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), multiplier_x, multiplier_y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The theme of this widget, defines which edje group will be used.
        /// 
        /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
        /// 
        /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="CoreUI.UI.Layout"/> object.
        /// 
        /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="CoreUI.UI.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
        /// 
        /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
        /// <param name="klass">The class of the group, eg. &quot;button&quot;.</param>
        /// <param name="group">The group, eg. &quot;base&quot;.<br/>The default value is <c>&quot;base&quot;</c>.</param>
        /// <param name="style">The style to use, eg &quot;default&quot;.<br/>The default value is <c>&quot;default&quot;</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetTheme(out System.String klass, out System.String group, out System.String style) {
            CoreUI.UI.LayoutBase.NativeMethods.efl_ui_layout_theme_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out klass, out group, out style);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The theme of this widget, defines which edje group will be used.
        /// 
        /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
        /// 
        /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="CoreUI.UI.Layout"/> object.
        /// 
        /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="CoreUI.UI.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
        /// 
        /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
        /// <param name="klass">The class of the group, eg. &quot;button&quot;.</param>
        /// <param name="group">The group, eg. &quot;base&quot;.<br/>The default value is <c>&quot;base&quot;</c>.</param>
        /// <param name="style">The style to use, eg &quot;default&quot;.<br/>The default value is <c>&quot;default&quot;</c>.</param>
        /// <returns>Whether the theme was successfully applied or not, see the CoreUI.UI.Theme.Apply_Error subset of <see cref="CoreUI.DataTypes.Error"/> for more information.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetTheme(System.String klass, System.String group, System.String style) {
            var _ret_var = CoreUI.UI.LayoutBase.NativeMethods.efl_ui_layout_theme_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass, group, style);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The version a theme does offer
        /// 
        /// A theme might offer older theme versions, with this property you can detect which version is running. The theme version is bound to the efl-version, the oldest version you will get here is 123. The newest of released EFL.
        /// 
        /// This property is only valid after <see cref="CoreUI.UI.Widget.ApplyTheme"/> has been called.
        /// 
        /// In case there is no version specified, 0 is returned.</summary>
        /// <returns>Theme version of this objec, for a EFL version called 1.23, this property will return 123.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetThemeVersion() {
            var _ret_var = CoreUI.UI.LayoutBase.NativeMethods.efl_ui_layout_theme_version_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Begin iterating over this object&apos;s contents.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Iterator on object&apos;s content.</returns>
        public virtual IEnumerable<CoreUI.Gfx.IEntity> IterateContent() {
            var _ret_var = CoreUI.IContainerNativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
        }

        /// <summary>Returns the number of contained sub-objects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Number of sub-objects.</returns>
        public virtual int ContentCount() {
            var _ret_var = CoreUI.IContainerNativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <returns>Whether or not update the size hints.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCalcAutoUpdateHints() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <param name="update">Whether or not update the size hints.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCalcAutoUpdateHints(bool update) {
            CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), update);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Calculates the minimum required size for a given layout object.
        /// 
        /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
        /// 
        /// <b>NOTE: </b>At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
        /// 
        /// <b>WARNING: </b>Be advised that invisible parts in the object will be taken into account in this calculation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
        /// <returns>The minimum required size.</returns>
        public virtual CoreUI.DataTypes.Size2D CalcSizeMin(CoreUI.DataTypes.Size2D restricted) {
            CoreUI.DataTypes.Size2D _in_restricted = restricted;
var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_restricted);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
        /// 
        /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
        /// 
        /// <b>NOTE: </b>On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The calculated region.</returns>
        public virtual CoreUI.DataTypes.Rect CalcPartsExtends() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Freezes the layout object.
        /// 
        /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.ThawCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 on error</returns>
        public virtual int FreezeCalc() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Thaws the layout object.
        /// 
        /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
        /// 
        /// <b>NOTE: </b>If successive freezes were done, an equal number of thaws will be required.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.FreezeCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
        public virtual int ThawCalc() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Forces a Size/Geometry calculation.
        /// 
        /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.FreezeCalc"/> and <see cref="CoreUI.Layout.ICalc.ThawCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void CalcForce() {
            CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_force_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <returns>The minimum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetGroupSizeMin() {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <returns>The maximum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetGroupSizeMax() {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
        /// 
        /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
        /// 
        /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
        /// 
        /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
        /// 
        /// <b>WARNING: </b>Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.</summary>
        /// <param name="key">The data field&apos;s key string</param>
        /// <returns>The data&apos;s value string.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetGroupData(System.String key) {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether the given part exists in this group.
        /// 
        /// This is mostly equivalent to verifying the part type on the object as would be done in C as follows: (efl_canvas_layout_part_type_get(efl_part(obj, &quot;partname&quot;)) != EFL_CANVAS_LAYOUT_PART_TYPE_NONE)
        /// 
        /// The differences are that will silently return <c>false</c> if the part does not exist, and this will return <c>true</c> if the part is of type <c>SPACER</c> in the EDC file (<c>SPACER</c> parts have type <c>NONE</c>).
        /// 
        /// See also <span class="text-muted">CoreUI.Canvas.LayoutPart.GetPartType (object still in beta stage)</span>.</summary>
        /// <param name="part">The part name to check.</param>
        /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPartExist(System.String part) {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), part);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sends an (Edje) message to a given Edje object
        /// 
        /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
        /// 
        /// Messages can go both ways, from code to theme, or theme to code.
        /// 
        /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="id">A identification number for the message to be sent</param>
        /// <param name="msg">The message&apos;s payload</param>
        public virtual void SendMessage(int id, CoreUI.DataTypes.Value msg) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), id, msg);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
        /// 
        /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
        /// 
        /// Signals can go both ways, from code to theme, or theme to code.
        /// 
        /// Though there are those common uses for the two strings, one is free to use them however they like.
        /// 
        /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[" set of <c>fnmatch</c>() operators can be used, both for emission and source.
        /// 
        /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
        /// 
        /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="CoreUI.Layout.ISignal.DelSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        public virtual bool AddSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func) {
            GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source, GCHandle.ToIntPtr(func_handle), CoreUILayoutSignalCbWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes a signal-triggered callback from an object.
        /// 
        /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        public virtual bool DelSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func) {
            GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source, GCHandle.ToIntPtr(func_handle), CoreUILayoutSignalCbWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sends/emits an Edje signal to this layout.
        /// 
        /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        public virtual void EmitSignal(System.String emission, System.String source) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_emit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Processes an object&apos;s messages and signals queue.
        /// 
        /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
        /// 
        /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="recurse">Whether to process messages on children objects.</param>
        public virtual void ProcessSignal(bool recurse) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_process_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), recurse);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="CoreUI.UI.IFactory"/> need to be <see cref="CoreUI.UI.IPropertyBind.BindProperty"/> at least once.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">Key string for bind model property data</param>
        /// <param name="factory"><see cref="CoreUI.UI.IFactory"/> for create and bind model property data</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        public virtual CoreUI.DataTypes.Error BindFactory(System.String key, CoreUI.UI.IFactory factory) {
            var _ret_var = CoreUI.UI.IFactoryBindNativeMethods.efl_ui_factory_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key, factory);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Set a multiplier for applying finger size to the layout.
        /// 
        /// By default, any widget which inherits from this class will apply the finger_size global config value with a 1:1 width:height ratio during sizing calculations. This will cause the widget to scale its size based on the finger_size config value.
        /// 
        /// To disable finger_size in a layout&apos;s sizing calculations, set the multipliers for both axes to 0.</summary>
        /// <value>Multiplier for X axis.</value>
        /// <since_tizen> 6 </since_tizen>
        public (uint, uint) FingerSizeMultiplier {
            get {
                uint _out_multiplier_x = default(uint);
                uint _out_multiplier_y = default(uint);
                GetFingerSizeMultiplier(out _out_multiplier_x, out _out_multiplier_y);
                return (_out_multiplier_x, _out_multiplier_y);
            }
            set { SetFingerSizeMultiplier( value.Item1,  value.Item2); }
        }

        /// <summary>The theme of this widget, defines which edje group will be used.
        /// 
        /// Based on the type of widget (<c>klass</c>), a given <c>group</c> and a <c>style</c> (usually &quot;default&quot;), the edje group name will be formed for this object.
        /// 
        /// Widgets that inherit from this class will call this function automatically so it should not be called by applications, unless you are dealing directly with a <see cref="CoreUI.UI.Layout"/> object.
        /// 
        /// Note that <c>style</c> will be the new style of this object, as retrieved by <see cref="CoreUI.UI.Widget.Style"/>. As a consequence this function can only be called during construction of the object, before finalize.
        /// 
        /// If this returns <c>false</c> the widget is very likely to become non-functioning.</summary>
        /// <value>The class of the group, eg. &quot;button&quot;.</value>
        /// <since_tizen> 6 </since_tizen>
        public (System.String, System.String, System.String) Theme {
            get {
                System.String _out_klass = default(System.String);
                System.String _out_group = default(System.String);
                System.String _out_style = default(System.String);
                GetTheme(out _out_klass, out _out_group, out _out_style);
                return (_out_klass, _out_group, _out_style);
            }
            set { SetTheme( value.Item1,  value.Item2,  value.Item3); }
        }

        /// <summary>The version a theme does offer
        /// 
        /// A theme might offer older theme versions, with this property you can detect which version is running. The theme version is bound to the efl-version, the oldest version you will get here is 123. The newest of released EFL.
        /// 
        /// This property is only valid after <see cref="CoreUI.UI.Widget.ApplyTheme"/> has been called.
        /// 
        /// In case there is no version specified, 0 is returned.</summary>
        /// <value>Theme version of this objec, for a EFL version called 1.23, this property will return 123.</value>
        /// <since_tizen> 6 </since_tizen>
        public int ThemeVersion {
            get { return GetThemeVersion(); }
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <value>Whether or not update the size hints.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CalcAutoUpdateHints {
            get { return GetCalcAutoUpdateHints(); }
            set { SetCalcAutoUpdateHints(value); }
        }

        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <value>The minimum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D GroupSizeMin {
            get { return GetGroupSizeMin(); }
        }

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <value>The maximum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D GroupSizeMax {
            get { return GetGroupSizeMax(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.LayoutBase.efl_ui_layout_base_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Widget.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_layout_finger_size_multiplier_get_static_delegate == null)
                {
                    efl_ui_layout_finger_size_multiplier_get_static_delegate = new efl_ui_layout_finger_size_multiplier_get_delegate(finger_size_multiplier_get);
                }

                if (methods.Contains("GetFingerSizeMultiplier"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_finger_size_multiplier_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_finger_size_multiplier_get_static_delegate) });
                }

                if (efl_ui_layout_finger_size_multiplier_set_static_delegate == null)
                {
                    efl_ui_layout_finger_size_multiplier_set_static_delegate = new efl_ui_layout_finger_size_multiplier_set_delegate(finger_size_multiplier_set);
                }

                if (methods.Contains("SetFingerSizeMultiplier"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_finger_size_multiplier_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_finger_size_multiplier_set_static_delegate) });
                }

                if (efl_ui_layout_theme_get_static_delegate == null)
                {
                    efl_ui_layout_theme_get_static_delegate = new efl_ui_layout_theme_get_delegate(theme_get);
                }

                if (methods.Contains("GetTheme"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_get_static_delegate) });
                }

                if (efl_ui_layout_theme_set_static_delegate == null)
                {
                    efl_ui_layout_theme_set_static_delegate = new efl_ui_layout_theme_set_delegate(theme_set);
                }

                if (methods.Contains("SetTheme"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_set_static_delegate) });
                }

                if (efl_ui_layout_theme_version_get_static_delegate == null)
                {
                    efl_ui_layout_theme_version_get_static_delegate = new efl_ui_layout_theme_version_get_delegate(theme_version_get);
                }

                if (methods.Contains("GetThemeVersion"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_theme_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_theme_version_get_static_delegate) });
                }

                if (efl_layout_calc_force_static_delegate == null)
                {
                    efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
                }

                if (methods.Contains("CalcForce"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
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
                return CoreUI.UI.LayoutBase.efl_ui_layout_base_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_layout_finger_size_multiplier_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint multiplier_x,  out uint multiplier_y);

            
            internal delegate void efl_ui_layout_finger_size_multiplier_get_api_delegate(System.IntPtr obj,  out uint multiplier_x,  out uint multiplier_y);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_finger_size_multiplier_get_api_delegate> efl_ui_layout_finger_size_multiplier_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_finger_size_multiplier_get_api_delegate>(Module, "efl_ui_layout_finger_size_multiplier_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void finger_size_multiplier_get(System.IntPtr obj, System.IntPtr pd, out uint multiplier_x, out uint multiplier_y)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_layout_finger_size_multiplier_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    multiplier_x = default(uint);multiplier_y = default(uint);
                    try
                    {
                        ((LayoutBase)ws.Target).GetFingerSizeMultiplier(out multiplier_x, out multiplier_y);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_layout_finger_size_multiplier_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out multiplier_x, out multiplier_y);
                }
            }

            private static efl_ui_layout_finger_size_multiplier_get_delegate efl_ui_layout_finger_size_multiplier_get_static_delegate;

            
            private delegate void efl_ui_layout_finger_size_multiplier_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint multiplier_x,  uint multiplier_y);

            
            internal delegate void efl_ui_layout_finger_size_multiplier_set_api_delegate(System.IntPtr obj,  uint multiplier_x,  uint multiplier_y);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_finger_size_multiplier_set_api_delegate> efl_ui_layout_finger_size_multiplier_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_finger_size_multiplier_set_api_delegate>(Module, "efl_ui_layout_finger_size_multiplier_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void finger_size_multiplier_set(System.IntPtr obj, System.IntPtr pd, uint multiplier_x, uint multiplier_y)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_layout_finger_size_multiplier_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LayoutBase)ws.Target).SetFingerSizeMultiplier(multiplier_x, multiplier_y);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_layout_finger_size_multiplier_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), multiplier_x, multiplier_y);
                }
            }

            private static efl_ui_layout_finger_size_multiplier_set_delegate efl_ui_layout_finger_size_multiplier_set_static_delegate;

            
            private delegate void efl_ui_layout_theme_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String style);

            
            internal delegate void efl_ui_layout_theme_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] out System.String style);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_get_api_delegate> efl_ui_layout_theme_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_get_api_delegate>(Module, "efl_ui_layout_theme_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void theme_get(System.IntPtr obj, System.IntPtr pd, out System.String klass, out System.String group, out System.String style)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_layout_theme_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _out_klass = default(System.String);
System.String _out_group = default(System.String);
System.String _out_style = default(System.String);

                    try
                    {
                        ((LayoutBase)ws.Target).GetTheme(out _out_klass, out _out_group, out _out_style);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            klass = _out_klass;
group = _out_group;
style = _out_style;
        
                }
                else
                {
                    efl_ui_layout_theme_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out klass, out group, out style);
                }
            }

            private static efl_ui_layout_theme_get_delegate efl_ui_layout_theme_get_static_delegate;

            
            private delegate CoreUI.DataTypes.Error efl_ui_layout_theme_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            
            internal delegate CoreUI.DataTypes.Error efl_ui_layout_theme_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String klass, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String group, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String style);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_set_api_delegate> efl_ui_layout_theme_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_set_api_delegate>(Module, "efl_ui_layout_theme_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Error theme_set(System.IntPtr obj, System.IntPtr pd, System.String klass, System.String group, System.String style)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_layout_theme_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                    try
                    {
                        _ret_var = ((LayoutBase)ws.Target).SetTheme(klass, group, style);
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
                    return efl_ui_layout_theme_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass, group, style);
                }
            }

            private static efl_ui_layout_theme_set_delegate efl_ui_layout_theme_set_static_delegate;

            
            private delegate int efl_ui_layout_theme_version_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_ui_layout_theme_version_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_version_get_api_delegate> efl_ui_layout_theme_version_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_layout_theme_version_get_api_delegate>(Module, "efl_ui_layout_theme_version_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int theme_version_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_layout_theme_version_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((LayoutBase)ws.Target).GetThemeVersion();
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
                    return efl_ui_layout_theme_version_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_layout_theme_version_get_delegate efl_ui_layout_theme_version_get_static_delegate;

            
            private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void calc_force(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_layout_calc_force was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LayoutBase)ws.Target).CalcForce();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_layout_calc_force_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class LayoutBaseExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CalcAutoUpdateHints<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.LayoutBase, T>magic = null) where T : CoreUI.UI.LayoutBase {
            return new CoreUI.BindableProperty<bool>("calc_auto_update_hints", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

