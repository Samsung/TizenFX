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
    /// <summary>Elementary slider class
    /// 
    /// This lets the UI user select a numerical value inside the <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> limits. The current value can be retrieved using the <see cref="CoreUI.UI.IRangeInteractive"/> interface. Events monitoring its changes are also available in that interface. The visual representation of min and max can be swapped using <see cref="CoreUI.UI.ILayoutOrientable.Orientation"/>. Normally the minimum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> is shown on the left side, the max on the right side.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Slider.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Slider : CoreUI.UI.LayoutBase, CoreUI.UI.ILayoutOrientable, CoreUI.UI.IRangeDisplay, CoreUI.UI.IRangeInteractive
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Slider))
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
            efl_ui_slider_class_get();

        /// <summary>Initializes a new instance of the <see cref="Slider"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Slider(CoreUI.Object parent, System.String style = null) : base(efl_ui_slider_class_get(), parent)
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
        protected Slider(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Slider"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Slider(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Slider"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Slider(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when a slider drag operation has started. This means a <c>press</c> event has been received on the slider thumb but not the <c>unpress</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SliderDragStart
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_START";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_START";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SliderDragStart.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSliderDragStart()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_START", IntPtr.Zero, null);
        }

        /// <summary>Called when a slider drag operation has finished. This means an <c>unpress</c> event has been received on the slider thumb.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SliderDragStop
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_STOP";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_STOP";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SliderDragStop.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSliderDragStop()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SLIDER_EVENT_SLIDER_DRAG_STOP", IntPtr.Zero, null);
        }


        /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> is getting changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Changed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RANGE_EVENT_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Emitted when the <see cref="CoreUI.UI.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler MinReached
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event MinReached.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMinReached()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RANGE_EVENT_MIN_REACHED", IntPtr.Zero, null);
        }

        /// <summary>Emitted when the <c>range_value</c> has reached the maximum of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler MaxReached
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event MaxReached.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMaxReached()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RANGE_EVENT_MAX_REACHED", IntPtr.Zero, null);
        }

        /// <summary>Called when the widget&apos;s value has changed and has remained unchanged for 0.2s. This allows filtering out unwanted &quot;noise&quot; from the widget if you are only interested in its final position. Use this event instead of <see cref="CoreUI.UI.IRangeDisplay.Changed"/> if you are going to perform a costly operation on its handler.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Steady
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_RANGE_EVENT_STEADY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RANGE_EVENT_STEADY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Steady.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSteady()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RANGE_EVENT_STEADY", IntPtr.Zero, null);
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetOrientation() {
            var _ret_var = CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOrientation(CoreUI.UI.LayoutOrientation dir) {
            CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the value (position) of the widget within its valid range.
        /// 
        /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
        /// <returns>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRangeValue() {
            var _ret_var = CoreUI.UI.IRangeDisplayNativeMethods.efl_ui_range_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the value (position) of the widget within its valid range.
        /// 
        /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
        /// <param name="val">The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRangeValue(double val) {
            CoreUI.UI.IRangeDisplayNativeMethods.efl_ui_range_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Set the minimum and maximum values for given range widget.
        /// 
        /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
        /// 
        /// The default minimum and maximum values may be different for each class.
        /// 
        /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRangeLimits(out double min, out double max) {
            CoreUI.UI.IRangeDisplayNativeMethods.efl_ui_range_limits_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out min, out max);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Set the minimum and maximum values for given range widget.
        /// 
        /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
        /// 
        /// The default minimum and maximum values may be different for each class.
        /// 
        /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRangeLimits(double min, double max) {
            CoreUI.UI.IRangeDisplayNativeMethods.efl_ui_range_limits_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), min, max);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <returns>The step value.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRangeStep() {
            var _ret_var = CoreUI.UI.IRangeInteractiveNativeMethods.efl_ui_range_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <param name="step">The step value.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRangeStep(double step) {
            CoreUI.UI.IRangeInteractiveNativeMethods.efl_ui_range_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), step);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Orientation {
            get { return GetOrientation(); }
            set { SetOrientation(value); }
        }

        /// <summary>Control the value (position) of the widget within its valid range.
        /// 
        /// Values outside the limits defined in <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/> are ignored and an error is printed.</summary>
        /// <value>The range value (must be within the bounds of <see cref="CoreUI.UI.IRangeDisplay.RangeLimits"/>).</value>
        /// <since_tizen> 6 </since_tizen>
        public double RangeValue {
            get { return GetRangeValue(); }
            set { SetRangeValue(value); }
        }

        /// <summary>Set the minimum and maximum values for given range widget.
        /// 
        /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="CoreUI.UI.IRangeDisplay.GetRangeValue"/>.
        /// 
        /// The default minimum and maximum values may be different for each class.
        /// 
        /// <b>NOTE: </b>maximum must be greater than minimum, otherwise behavior is undefined.</summary>
        /// <value>The minimum value.</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double) RangeLimits {
            get {
                double _out_min = default(double);
                double _out_max = default(double);
                GetRangeLimits(out _out_min, out _out_max);
                return (_out_min, _out_max);
            }
            set { SetRangeLimits( value.Item1,  value.Item2); }
        }

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <value>The step value.</value>
        /// <since_tizen> 6 </since_tizen>
        public double RangeStep {
            get { return GetRangeStep(); }
            set { SetRangeStep(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Slider.efl_ui_slider_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                return CoreUI.UI.Slider.efl_ui_slider_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SliderExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Slider, T>magic = null) where T : CoreUI.UI.Slider {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeValue<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Slider, T>magic = null) where T : CoreUI.UI.Slider {
            return new CoreUI.BindableProperty<double>("range_value", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeStep<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Slider, T>magic = null) where T : CoreUI.UI.Slider {
            return new CoreUI.BindableProperty<double>("range_step", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

