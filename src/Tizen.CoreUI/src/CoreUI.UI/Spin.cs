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
    /// <summary>A Spin.
    /// 
    /// This is a widget which allows the user to increase or decrease a numeric value using arrow buttons. It&apos;s a basic type of widget for choosing and displaying values.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Spin.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Spin : CoreUI.UI.LayoutBase, CoreUI.UI.IFormat, CoreUI.UI.IRangeDisplay
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Spin))
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
            efl_ui_spin_class_get();

        /// <summary>Initializes a new instance of the <see cref="Spin"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Spin(CoreUI.Object parent, System.String style = null) : base(efl_ui_spin_class_get(), parent)
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
        protected Spin(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Spin"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Spin(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Spin"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Spin(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
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

        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <returns>User-provided formatting function.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.FormatFunc GetFormatFunc() {
            var _ret_var = CoreUI.UI.IFormatNativeMethods.efl_ui_format_func_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <param name="func">User-provided formatting function.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFormatFunc(CoreUI.UI.FormatFunc func) {
            GCHandle func_handle = GCHandle.Alloc(func);
CoreUI.UI.IFormatNativeMethods.efl_ui_format_func_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), GCHandle.ToIntPtr(func_handle), CoreUI.UI.FormatFuncWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual IEnumerable<CoreUI.UI.FormatValue> GetFormatValues() {
            var _ret_var = CoreUI.UI.IFormatNativeMethods.efl_ui_format_values_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.AccessorToIEnumerable<CoreUI.UI.FormatValue>(_ret_var);
        }

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFormatValues(IEnumerable<CoreUI.UI.FormatValue> values) {
            var _in_values = CoreUI.Wrapper.Globals.IEnumerableToAccessor(values, true);
CoreUI.UI.IFormatNativeMethods.efl_ui_format_values_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_values);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
        /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="CoreUI.UI.FormatStringType.Simple"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetFormatString(out System.String kw_string, out CoreUI.UI.FormatStringType type) {
            CoreUI.UI.IFormatNativeMethods.efl_ui_format_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out kw_string, out type);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
        /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be translated.<br/>The default value is <see cref="CoreUI.UI.FormatStringType.Simple"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFormatString(System.String kw_string, CoreUI.UI.FormatStringType type) {
            CoreUI.UI.IFormatNativeMethods.efl_ui_format_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), kw_string, type);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
        /// 
        /// CoreUI.UI.Format.formatted_value_get uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
        /// <param name="value">The <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> to convert to text.</param>
        protected virtual void GetFormattedValue(CoreUI.DataTypes.Strbuf str, CoreUI.DataTypes.Value value) {
            CoreUI.UI.IFormatNativeMethods.efl_ui_format_formatted_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), str, value);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="CoreUI.UI.IFormat.FormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
        /// 
        /// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
        protected virtual int GetDecimalPlaces() {
            var _ret_var = CoreUI.UI.IFormatNativeMethods.efl_ui_format_decimal_places_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Internal method to be implemented by widgets including this mixin.
        /// 
        /// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call CoreUI.UI.Format.formatted_value_get and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void ApplyFormattedValue() {
            CoreUI.UI.IFormatNativeMethods.efl_ui_format_apply_formatted_value_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
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

        /// <summary>User-provided function which takes care of converting an <span class="text-muted">CoreUI.DataTypes.Value (object still in beta stage)</span> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
        /// <value>User-provided formatting function.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.FormatFunc FormatFunc {
            get { return GetFormatFunc(); }
            set { SetFormatFunc(value); }
        }

        /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="CoreUI.UI.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
        /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from CoreUI.DataTypes.Array, CoreUI.DataTypes.List or even plain C arrays.</value>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<CoreUI.UI.FormatValue> FormatValues {
            get { return GetFormatValues(); }
            set { SetFormatValues(value); }
        }

        /// <summary>A user-provided, string used to format the numerical value.
        /// 
        /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
        /// 
        /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
        /// 
        /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="CoreUI.UI.FormatStringType.Simple"/> for simple numerical values and <see cref="CoreUI.UI.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
        /// 
        /// Pass <c>NULL</c> to disable this mechanism.</summary>
        /// <value>Formatting string containing regular characters and format specifiers.</value>
        /// <since_tizen> 6 </since_tizen>
        public (System.String, CoreUI.UI.FormatStringType) FormatString {
            get {
                System.String _out_kw_string = default(System.String);
                CoreUI.UI.FormatStringType _out_type = default(CoreUI.UI.FormatStringType);
                GetFormatString(out _out_kw_string, out _out_type);
                return (_out_kw_string, _out_type);
            }
            set { SetFormatString( value.Item1,  value.Item2); }
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

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Spin.efl_ui_spin_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_format_formatted_value_get_static_delegate == null)
                {
                    efl_ui_format_formatted_value_get_static_delegate = new efl_ui_format_formatted_value_get_delegate(formatted_value_get);
                }

                if (methods.Contains("GetFormattedValue"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_formatted_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_formatted_value_get_static_delegate) });
                }

                if (efl_ui_format_decimal_places_get_static_delegate == null)
                {
                    efl_ui_format_decimal_places_get_static_delegate = new efl_ui_format_decimal_places_get_delegate(decimal_places_get);
                }

                if (methods.Contains("GetDecimalPlaces"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_decimal_places_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_decimal_places_get_static_delegate) });
                }

                if (efl_ui_format_apply_formatted_value_static_delegate == null)
                {
                    efl_ui_format_apply_formatted_value_static_delegate = new efl_ui_format_apply_formatted_value_delegate(apply_formatted_value);
                }

                if (methods.Contains("ApplyFormattedValue"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_apply_formatted_value"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_apply_formatted_value_static_delegate) });
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
                return CoreUI.UI.Spin.efl_ui_spin_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_format_formatted_value_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value);

            
            internal delegate void efl_ui_format_formatted_value_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StrbufKeepOwnershipMarshaler))] CoreUI.DataTypes.Strbuf str,  CoreUI.DataTypes.ValueNative value);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate> efl_ui_format_formatted_value_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate>(Module, "efl_ui_format_formatted_value_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void formatted_value_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Strbuf str, CoreUI.DataTypes.ValueNative value)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_format_formatted_value_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Spin)ws.Target).GetFormattedValue(str, value);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_format_formatted_value_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), str, value);
                }
            }

            private static efl_ui_format_formatted_value_get_delegate efl_ui_format_formatted_value_get_static_delegate;

            
            private delegate int efl_ui_format_decimal_places_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_ui_format_decimal_places_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate> efl_ui_format_decimal_places_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate>(Module, "efl_ui_format_decimal_places_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int decimal_places_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_format_decimal_places_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Spin)ws.Target).GetDecimalPlaces();
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
                    return efl_ui_format_decimal_places_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_format_decimal_places_get_delegate efl_ui_format_decimal_places_get_static_delegate;

            
            private delegate void efl_ui_format_apply_formatted_value_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_ui_format_apply_formatted_value_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate> efl_ui_format_apply_formatted_value_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate>(Module, "efl_ui_format_apply_formatted_value");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void apply_formatted_value(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_format_apply_formatted_value was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Spin)ws.Target).ApplyFormattedValue();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_format_apply_formatted_value_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_format_apply_formatted_value_delegate efl_ui_format_apply_formatted_value_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SpinExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.FormatFunc> FormatFunc<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spin, T>magic = null) where T : CoreUI.UI.Spin {
            return new CoreUI.BindableProperty<CoreUI.UI.FormatFunc>("format_func", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<IEnumerable<CoreUI.UI.FormatValue>> FormatValues<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spin, T>magic = null) where T : CoreUI.UI.Spin {
            return new CoreUI.BindableProperty<IEnumerable<CoreUI.UI.FormatValue>>("format_values", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeValue<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Spin, T>magic = null) where T : CoreUI.UI.Spin {
            return new CoreUI.BindableProperty<double>("range_value", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

