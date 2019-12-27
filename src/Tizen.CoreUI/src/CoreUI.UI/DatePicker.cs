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
    /// <summary>Datepicker widget
    /// 
    /// This is a widget which allows the user to pick a date using internal spinner. User can use the internal spinner to select year, month, day or user can input value using internal entry.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.DatePicker.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class DatePicker : CoreUI.UI.LayoutBase
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(DatePicker))
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
            efl_ui_datepicker_class_get();

        /// <summary>Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public DatePicker(CoreUI.Object parent, System.String style = null) : base(efl_ui_datepicker_class_get(), parent)
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
        protected DatePicker(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DatePicker"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal DatePicker(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DatePicker"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected DatePicker(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when date value is changed</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler DateChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event DateChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnDateChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED", IntPtr.Zero, null);
        }


        /// <summary>The lower boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetDateMin(out int year, out int month, out int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out year, out month, out day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The lower boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDateMin(int year, int month, int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), year, month, day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The upper boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetDateMax(out int year, out int month, out int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out year, out month, out day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The upper boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDateMax(int year, int month, int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), year, month, day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The current value of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 0 to 11.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetDate(out int year, out int month, out int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out year, out month, out day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The current value of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 0 to 11.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value from 1 to 12.</param>
        /// <param name="day">The day value from 1 to 31.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDate(int year, int month, int day) {
            CoreUI.UI.DatePicker.NativeMethods.efl_ui_datepicker_date_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), year, month, day);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The lower boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <value>The year value.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int) DateMin {
            get {
                int _out_year = default(int);
                int _out_month = default(int);
                int _out_day = default(int);
                GetDateMin(out _out_year, out _out_month, out _out_day);
                return (_out_year, _out_month, _out_day);
            }
            set { SetDateMin( value.Item1,  value.Item2,  value.Item3); }
        }

        /// <summary>The upper boundary of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 1 to 12.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <value>The year value.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int) DateMax {
            get {
                int _out_year = default(int);
                int _out_month = default(int);
                int _out_day = default(int);
                GetDateMax(out _out_year, out _out_month, out _out_day);
                return (_out_year, _out_month, _out_day);
            }
            set { SetDateMax( value.Item1,  value.Item2,  value.Item3); }
        }

        /// <summary>The current value of date.
        /// 
        /// <c>year</c>: Year. The year range is from 1900 to 2137.
        /// 
        /// <c>month</c>: Month. The month range is from 0 to 11.
        /// 
        /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
        /// <value>The year value.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int) Date {
            get {
                int _out_year = default(int);
                int _out_month = default(int);
                int _out_day = default(int);
                GetDate(out _out_year, out _out_month, out _out_day);
                return (_out_year, _out_month, _out_day);
            }
            set { SetDate( value.Item1,  value.Item2,  value.Item3); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.DatePicker.efl_ui_datepicker_class_get();
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

                if (efl_ui_datepicker_date_min_get_static_delegate == null)
                {
                    efl_ui_datepicker_date_min_get_static_delegate = new efl_ui_datepicker_date_min_get_delegate(date_min_get);
                }

                if (methods.Contains("GetDateMin"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_min_get_static_delegate) });
                }

                if (efl_ui_datepicker_date_min_set_static_delegate == null)
                {
                    efl_ui_datepicker_date_min_set_static_delegate = new efl_ui_datepicker_date_min_set_delegate(date_min_set);
                }

                if (methods.Contains("SetDateMin"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_min_set_static_delegate) });
                }

                if (efl_ui_datepicker_date_max_get_static_delegate == null)
                {
                    efl_ui_datepicker_date_max_get_static_delegate = new efl_ui_datepicker_date_max_get_delegate(date_max_get);
                }

                if (methods.Contains("GetDateMax"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_max_get_static_delegate) });
                }

                if (efl_ui_datepicker_date_max_set_static_delegate == null)
                {
                    efl_ui_datepicker_date_max_set_static_delegate = new efl_ui_datepicker_date_max_set_delegate(date_max_set);
                }

                if (methods.Contains("SetDateMax"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_max_set_static_delegate) });
                }

                if (efl_ui_datepicker_date_get_static_delegate == null)
                {
                    efl_ui_datepicker_date_get_static_delegate = new efl_ui_datepicker_date_get_delegate(date_get);
                }

                if (methods.Contains("GetDate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_get_static_delegate) });
                }

                if (efl_ui_datepicker_date_set_static_delegate == null)
                {
                    efl_ui_datepicker_date_set_static_delegate = new efl_ui_datepicker_date_set_delegate(date_set);
                }

                if (methods.Contains("SetDate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_set_static_delegate) });
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
                return CoreUI.UI.DatePicker.efl_ui_datepicker_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_datepicker_date_min_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

            
            internal delegate void efl_ui_datepicker_date_min_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_min_get_api_delegate> efl_ui_datepicker_date_min_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_min_get_api_delegate>(Module, "efl_ui_datepicker_date_min_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_min_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_min_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    year = default(int);month = default(int);day = default(int);
                    try
                    {
                        ((DatePicker)ws.Target).GetDateMin(out year, out month, out day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_min_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out year, out month, out day);
                }
            }

            private static efl_ui_datepicker_date_min_get_delegate efl_ui_datepicker_date_min_get_static_delegate;

            
            private delegate void efl_ui_datepicker_date_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

            
            internal delegate void efl_ui_datepicker_date_min_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_min_set_api_delegate> efl_ui_datepicker_date_min_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_min_set_api_delegate>(Module, "efl_ui_datepicker_date_min_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_min_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_min_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((DatePicker)ws.Target).SetDateMin(year, month, day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_min_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), year, month, day);
                }
            }

            private static efl_ui_datepicker_date_min_set_delegate efl_ui_datepicker_date_min_set_static_delegate;

            
            private delegate void efl_ui_datepicker_date_max_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

            
            internal delegate void efl_ui_datepicker_date_max_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_max_get_api_delegate> efl_ui_datepicker_date_max_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_max_get_api_delegate>(Module, "efl_ui_datepicker_date_max_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_max_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_max_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    year = default(int);month = default(int);day = default(int);
                    try
                    {
                        ((DatePicker)ws.Target).GetDateMax(out year, out month, out day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_max_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out year, out month, out day);
                }
            }

            private static efl_ui_datepicker_date_max_get_delegate efl_ui_datepicker_date_max_get_static_delegate;

            
            private delegate void efl_ui_datepicker_date_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

            
            internal delegate void efl_ui_datepicker_date_max_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_max_set_api_delegate> efl_ui_datepicker_date_max_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_max_set_api_delegate>(Module, "efl_ui_datepicker_date_max_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_max_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_max_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((DatePicker)ws.Target).SetDateMax(year, month, day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_max_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), year, month, day);
                }
            }

            private static efl_ui_datepicker_date_max_set_delegate efl_ui_datepicker_date_max_set_static_delegate;

            
            private delegate void efl_ui_datepicker_date_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

            
            internal delegate void efl_ui_datepicker_date_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate> efl_ui_datepicker_date_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate>(Module, "efl_ui_datepicker_date_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    year = default(int);month = default(int);day = default(int);
                    try
                    {
                        ((DatePicker)ws.Target).GetDate(out year, out month, out day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out year, out month, out day);
                }
            }

            private static efl_ui_datepicker_date_get_delegate efl_ui_datepicker_date_get_static_delegate;

            
            private delegate void efl_ui_datepicker_date_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

            
            internal delegate void efl_ui_datepicker_date_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_set_api_delegate> efl_ui_datepicker_date_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_datepicker_date_set_api_delegate>(Module, "efl_ui_datepicker_date_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void date_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_datepicker_date_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((DatePicker)ws.Target).SetDate(year, month, day);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_datepicker_date_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), year, month, day);
                }
            }

            private static efl_ui_datepicker_date_set_delegate efl_ui_datepicker_date_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

