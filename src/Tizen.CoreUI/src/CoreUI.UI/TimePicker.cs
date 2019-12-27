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
    /// <summary>Timepicker widget
    /// 
    /// This is a widget which allows the user to pick a time using internal spinner. User can use the internal spinner to select hour, minute, AM/PM or user can input value using internal entry.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.TimePicker.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class TimePicker : CoreUI.UI.LayoutBase
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(TimePicker))
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
            efl_ui_timepicker_class_get();

        /// <summary>Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public TimePicker(CoreUI.Object parent, System.String style = null) : base(efl_ui_timepicker_class_get(), parent)
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
        protected TimePicker(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TimePicker"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal TimePicker(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TimePicker"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected TimePicker(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when time is changed</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler TimeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_TIMEPICKER_EVENT_TIME_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_TIMEPICKER_EVENT_TIME_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event TimeChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnTimeChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_TIMEPICKER_EVENT_TIME_CHANGED", IntPtr.Zero, null);
        }


        /// <summary>The current value of time
        /// 
        /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
        /// 
        /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
        /// <param name="hour">The hour value from 0 to 23.</param>
        /// <param name="min">The minute value from 0 to 59.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetTime(out int hour, out int min) {
            CoreUI.UI.TimePicker.NativeMethods.efl_ui_timepicker_time_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out hour, out min);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The current value of time
        /// 
        /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
        /// 
        /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
        /// <param name="hour">The hour value from 0 to 23.</param>
        /// <param name="min">The minute value from 0 to 59.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTime(int hour, int min) {
            CoreUI.UI.TimePicker.NativeMethods.efl_ui_timepicker_time_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hour, min);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
        /// <returns><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM label.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetIs24hour() {
            var _ret_var = CoreUI.UI.TimePicker.NativeMethods.efl_ui_timepicker_is_24hour_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
        /// <param name="is_24hour"><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM label.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetIs24hour(bool is_24hour) {
            CoreUI.UI.TimePicker.NativeMethods.efl_ui_timepicker_is_24hour_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), is_24hour);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The current value of time
        /// 
        /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
        /// 
        /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
        /// <value>The hour value from 0 to 23.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int) Time {
            get {
                int _out_hour = default(int);
                int _out_min = default(int);
                GetTime(out _out_hour, out _out_min);
                return (_out_hour, _out_min);
            }
            set { SetTime( value.Item1,  value.Item2); }
        }

        /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
        /// <value><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM label.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Is24hour {
            get { return GetIs24hour(); }
            set { SetIs24hour(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.TimePicker.efl_ui_timepicker_class_get();
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

                if (efl_ui_timepicker_time_get_static_delegate == null)
                {
                    efl_ui_timepicker_time_get_static_delegate = new efl_ui_timepicker_time_get_delegate(time_get);
                }

                if (methods.Contains("GetTime"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_get_static_delegate) });
                }

                if (efl_ui_timepicker_time_set_static_delegate == null)
                {
                    efl_ui_timepicker_time_set_static_delegate = new efl_ui_timepicker_time_set_delegate(time_set);
                }

                if (methods.Contains("SetTime"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_set_static_delegate) });
                }

                if (efl_ui_timepicker_is_24hour_get_static_delegate == null)
                {
                    efl_ui_timepicker_is_24hour_get_static_delegate = new efl_ui_timepicker_is_24hour_get_delegate(is_24hour_get);
                }

                if (methods.Contains("GetIs24hour"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_is_24hour_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_is_24hour_get_static_delegate) });
                }

                if (efl_ui_timepicker_is_24hour_set_static_delegate == null)
                {
                    efl_ui_timepicker_is_24hour_set_static_delegate = new efl_ui_timepicker_is_24hour_set_delegate(is_24hour_set);
                }

                if (methods.Contains("SetIs24hour"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_is_24hour_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_is_24hour_set_static_delegate) });
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
                return CoreUI.UI.TimePicker.efl_ui_timepicker_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_timepicker_time_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int hour,  out int min);

            
            internal delegate void efl_ui_timepicker_time_get_api_delegate(System.IntPtr obj,  out int hour,  out int min);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate> efl_ui_timepicker_time_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate>(Module, "efl_ui_timepicker_time_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void time_get(System.IntPtr obj, System.IntPtr pd, out int hour, out int min)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_timepicker_time_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    hour = default(int);min = default(int);
                    try
                    {
                        ((TimePicker)ws.Target).GetTime(out hour, out min);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_timepicker_time_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out hour, out min);
                }
            }

            private static efl_ui_timepicker_time_get_delegate efl_ui_timepicker_time_get_static_delegate;

            
            private delegate void efl_ui_timepicker_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  int hour,  int min);

            
            internal delegate void efl_ui_timepicker_time_set_api_delegate(System.IntPtr obj,  int hour,  int min);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate> efl_ui_timepicker_time_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate>(Module, "efl_ui_timepicker_time_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void time_set(System.IntPtr obj, System.IntPtr pd, int hour, int min)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_timepicker_time_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((TimePicker)ws.Target).SetTime(hour, min);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_timepicker_time_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hour, min);
                }
            }

            private static efl_ui_timepicker_time_set_delegate efl_ui_timepicker_time_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_timepicker_is_24hour_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_timepicker_is_24hour_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_is_24hour_get_api_delegate> efl_ui_timepicker_is_24hour_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_is_24hour_get_api_delegate>(Module, "efl_ui_timepicker_is_24hour_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool is_24hour_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_timepicker_is_24hour_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((TimePicker)ws.Target).GetIs24hour();
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
                    return efl_ui_timepicker_is_24hour_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_timepicker_is_24hour_get_delegate efl_ui_timepicker_is_24hour_get_static_delegate;

            
            private delegate void efl_ui_timepicker_is_24hour_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_24hour);

            
            internal delegate void efl_ui_timepicker_is_24hour_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_24hour);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_is_24hour_set_api_delegate> efl_ui_timepicker_is_24hour_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_timepicker_is_24hour_set_api_delegate>(Module, "efl_ui_timepicker_is_24hour_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void is_24hour_set(System.IntPtr obj, System.IntPtr pd, bool is_24hour)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_timepicker_is_24hour_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((TimePicker)ws.Target).SetIs24hour(is_24hour);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_timepicker_is_24hour_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), is_24hour);
                }
            }

            private static efl_ui_timepicker_is_24hour_set_delegate efl_ui_timepicker_is_24hour_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class TimePickerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Is24hour<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.TimePicker, T>magic = null) where T : CoreUI.UI.TimePicker {
            return new CoreUI.BindableProperty<bool>("is_24hour", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

