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
namespace CoreUI {
    /// <summary>Timers are objects that will call a given callback at some point in the future and repeat that tick at a given interval.
    /// 
    /// Timers require the ecore main loop to be running and functioning properly. They do not guarantee exact timing but try to work on a &quot;best effort&quot; basis.
    /// 
    /// The <see cref="CoreUI.Object.FreezeEvent"/> and <see cref="CoreUI.Object.ThawEvent"/> calls are used to pause and unpause the timer.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.LoopTimer.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class LoopTimer : CoreUI.LoopConsumer
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(LoopTimer))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_loop_timer_class_get();

        /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="timerInterval">Interval the timer ticks on. See <see cref="CoreUI.LoopTimer.SetTimerInterval" /></param>
        public LoopTimer(CoreUI.Object parent, double timerInterval) : base(efl_loop_timer_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(timerInterval))
            {
                SetTimerInterval(CoreUI.Wrapper.Globals.GetParamHelper(timerInterval));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected LoopTimer(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal LoopTimer(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="LoopTimer"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected LoopTimer(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Event triggered when the specified time as passed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler TimerTick
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LOOP_TIMER_EVENT_TIMER_TICK";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event TimerTick.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnTimerTick()
        {
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_LOOP_TIMER_EVENT_TIMER_TICK", IntPtr.Zero, null);
        }


        /// <summary>Interval the timer ticks on.<br/>
        /// <b>Note:</b> Gets the interval the timer ticks on.</summary>
        /// <returns>The new interval in seconds</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetTimerInterval() {
            var _ret_var = CoreUI.LoopTimer.NativeMethods.efl_loop_timer_interval_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Interval the timer ticks on.<br/>
        /// <b>Note:</b> Changes the interval the timer ticks off. If set during a timer call this will affect the next interval.</summary>
        /// <param name="kw_in">The new interval in seconds<br/>The default value is <c>+1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTimerInterval(double kw_in) {
            CoreUI.LoopTimer.NativeMethods.efl_loop_timer_interval_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), kw_in);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Pending time regarding a timer.<br/>
        /// <b>Note:</b> Gets the pending time regarding a timer.</summary>
        /// <returns>Pending time</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetTimePending() {
            var _ret_var = CoreUI.LoopTimer.NativeMethods.efl_loop_timer_time_pending_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Resets a timer to its full interval. This effectively makes the timer start ticking off from zero now.
        /// 
        /// This is equal to delaying the timer by the already passed time, since the timer started ticking</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ResetTimer() {
            CoreUI.LoopTimer.NativeMethods.efl_loop_timer_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This effectively resets a timer but based on the time when this iteration of the main loop started.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ResetTimerLoop() {
            CoreUI.LoopTimer.NativeMethods.efl_loop_timer_loop_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Adds a delay to the next occurrence of a timer. This doesn&apos;t affect the timer interval.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="add">The amount of time by which to delay the timer in seconds</param>
        public virtual void TimerDelay(double add) {
            CoreUI.LoopTimer.NativeMethods.efl_loop_timer_delay_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), add);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Interval the timer ticks on.<br/>
        /// <b>Note on writing:</b> Changes the interval the timer ticks off. If set during a timer call this will affect the next interval.<br/>
        /// <b>Note on reading:</b> Gets the interval the timer ticks on.</summary>
        /// <value>The new interval in seconds</value>
        /// <since_tizen> 6 </since_tizen>
        public double TimerInterval {
            get { return GetTimerInterval(); }
            set { SetTimerInterval(value); }
        }

        /// <summary>Pending time regarding a timer.<br/>
        /// <b>Note on reading:</b> Gets the pending time regarding a timer.</summary>
        /// <value>Pending time</value>
        /// <since_tizen> 6 </since_tizen>
        public double TimePending {
            get { return GetTimePending(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.LoopTimer.efl_loop_timer_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopConsumer.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_loop_timer_interval_get_static_delegate == null)
                {
                    efl_loop_timer_interval_get_static_delegate = new efl_loop_timer_interval_get_delegate(timer_interval_get);
                }

                if (methods.Contains("GetTimerInterval"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_interval_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_get_static_delegate) });
                }

                if (efl_loop_timer_interval_set_static_delegate == null)
                {
                    efl_loop_timer_interval_set_static_delegate = new efl_loop_timer_interval_set_delegate(timer_interval_set);
                }

                if (methods.Contains("SetTimerInterval"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_interval_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_interval_set_static_delegate) });
                }

                if (efl_loop_timer_time_pending_get_static_delegate == null)
                {
                    efl_loop_timer_time_pending_get_static_delegate = new efl_loop_timer_time_pending_get_delegate(time_pending_get);
                }

                if (methods.Contains("GetTimePending"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_time_pending_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_time_pending_get_static_delegate) });
                }

                if (efl_loop_timer_reset_static_delegate == null)
                {
                    efl_loop_timer_reset_static_delegate = new efl_loop_timer_reset_delegate(timer_reset);
                }

                if (methods.Contains("ResetTimer"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_reset_static_delegate) });
                }

                if (efl_loop_timer_loop_reset_static_delegate == null)
                {
                    efl_loop_timer_loop_reset_static_delegate = new efl_loop_timer_loop_reset_delegate(timer_loop_reset);
                }

                if (methods.Contains("ResetTimerLoop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_loop_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_loop_reset_static_delegate) });
                }

                if (efl_loop_timer_delay_static_delegate == null)
                {
                    efl_loop_timer_delay_static_delegate = new efl_loop_timer_delay_delegate(timer_delay);
                }

                if (methods.Contains("TimerDelay"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_timer_delay"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_timer_delay_static_delegate) });
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
                return CoreUI.LoopTimer.efl_loop_timer_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate double efl_loop_timer_interval_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_loop_timer_interval_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_interval_get_api_delegate> efl_loop_timer_interval_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_interval_get_api_delegate>(Module, "efl_loop_timer_interval_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double timer_interval_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_interval_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((LoopTimer)ws.Target).GetTimerInterval();
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
                    return efl_loop_timer_interval_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_timer_interval_get_delegate efl_loop_timer_interval_get_static_delegate;

            
            private delegate void efl_loop_timer_interval_set_delegate(System.IntPtr obj, System.IntPtr pd,  double kw_in);

            
            internal delegate void efl_loop_timer_interval_set_api_delegate(System.IntPtr obj,  double kw_in);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_interval_set_api_delegate> efl_loop_timer_interval_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_interval_set_api_delegate>(Module, "efl_loop_timer_interval_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void timer_interval_set(System.IntPtr obj, System.IntPtr pd, double kw_in)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_interval_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LoopTimer)ws.Target).SetTimerInterval(kw_in);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_timer_interval_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), kw_in);
                }
            }

            private static efl_loop_timer_interval_set_delegate efl_loop_timer_interval_set_static_delegate;

            
            private delegate double efl_loop_timer_time_pending_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_loop_timer_time_pending_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate> efl_loop_timer_time_pending_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_time_pending_get_api_delegate>(Module, "efl_loop_timer_time_pending_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double time_pending_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_time_pending_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((LoopTimer)ws.Target).GetTimePending();
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
                    return efl_loop_timer_time_pending_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_timer_time_pending_get_delegate efl_loop_timer_time_pending_get_static_delegate;

            
            private delegate void efl_loop_timer_reset_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_loop_timer_reset_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_reset_api_delegate> efl_loop_timer_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_reset_api_delegate>(Module, "efl_loop_timer_reset");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void timer_reset(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_reset was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LoopTimer)ws.Target).ResetTimer();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_timer_reset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_timer_reset_delegate efl_loop_timer_reset_static_delegate;

            
            private delegate void efl_loop_timer_loop_reset_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_loop_timer_loop_reset_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate> efl_loop_timer_loop_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_loop_reset_api_delegate>(Module, "efl_loop_timer_loop_reset");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void timer_loop_reset(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_loop_reset was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LoopTimer)ws.Target).ResetTimerLoop();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_timer_loop_reset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_timer_loop_reset_delegate efl_loop_timer_loop_reset_static_delegate;

            
            private delegate void efl_loop_timer_delay_delegate(System.IntPtr obj, System.IntPtr pd,  double add);

            
            internal delegate void efl_loop_timer_delay_api_delegate(System.IntPtr obj,  double add);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_delay_api_delegate> efl_loop_timer_delay_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_timer_delay_api_delegate>(Module, "efl_loop_timer_delay");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void timer_delay(System.IntPtr obj, System.IntPtr pd, double add)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_timer_delay was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((LoopTimer)ws.Target).TimerDelay(add);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_loop_timer_delay_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), add);
                }
            }

            private static efl_loop_timer_delay_delegate efl_loop_timer_delay_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class LoopTimerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> TimerInterval<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.LoopTimer, T>magic = null) where T : CoreUI.LoopTimer {
            return new CoreUI.BindableProperty<double>("timer_interval", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

