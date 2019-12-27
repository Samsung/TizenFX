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
    /// <summary>Interface for autorepeating clicks.
    /// 
    /// This interface abstracts functions for enabling / disabling this feature. When enabled, keeping a button pressed will continuously emit the <c>repeated</c> event until the button is released. The time it takes until it starts emitting the event is given by <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IAutoRepeatNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IAutoRepeat : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <returns>Timeout in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetAutorepeatInitialTimeout();

        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <param name="t">Timeout in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAutorepeatInitialTimeout(double t);

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <returns>Time interval in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetAutorepeatGapTimeout();

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <param name="t">Time interval in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAutorepeatGapTimeout(double t);

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <returns>A bool to turn on/off the repeat event generation.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetAutorepeatEnabled();

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <param name="on">A bool to turn on/off the repeat event generation.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAutorepeatEnabled(bool on);

        /// <summary>Called when a repeated event is emitted</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler Repeated;
        /// <summary>The initial timeout before the autorepeat event is generated.
        /// 
        /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatEnabled"/> and <see cref="CoreUI.UI.IAutoRepeat.AutorepeatGapTimeout"/>.</summary>
        /// <value>Timeout in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        double AutorepeatInitialTimeout {
            get;
            set;
        }

        /// <summary>The interval between each generated autorepeat event.
        /// 
        /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
        /// 
        /// See also <see cref="CoreUI.UI.IAutoRepeat.AutorepeatInitialTimeout"/>.</summary>
        /// <value>Time interval in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        double AutorepeatGapTimeout {
            get;
            set;
        }

        /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
        /// 
        /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
        /// <value>A bool to turn on/off the repeat event generation.</value>
        /// <since_tizen> 6 </since_tizen>
        bool AutorepeatEnabled {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IAutoRepeatNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_autorepeat_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_autorepeat_initial_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_get_static_delegate = new efl_ui_autorepeat_initial_timeout_get_delegate(autorepeat_initial_timeout_get);
            }

            if (methods.Contains("GetAutorepeatInitialTimeout"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_initial_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_set_static_delegate = new efl_ui_autorepeat_initial_timeout_set_delegate(autorepeat_initial_timeout_set);
            }

            if (methods.Contains("SetAutorepeatInitialTimeout"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_get_static_delegate = new efl_ui_autorepeat_gap_timeout_get_delegate(autorepeat_gap_timeout_get);
            }

            if (methods.Contains("GetAutorepeatGapTimeout"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_set_static_delegate = new efl_ui_autorepeat_gap_timeout_set_delegate(autorepeat_gap_timeout_set);
            }

            if (methods.Contains("SetAutorepeatGapTimeout"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_get_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_get_static_delegate = new efl_ui_autorepeat_enabled_get_delegate(autorepeat_enabled_get);
            }

            if (methods.Contains("GetAutorepeatEnabled"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_get_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_set_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_set_static_delegate = new efl_ui_autorepeat_enabled_set_delegate(autorepeat_enabled_set);
            }

            if (methods.Contains("SetAutorepeatEnabled"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_set_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_ui_autorepeat_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_autorepeat_initial_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_ui_autorepeat_initial_timeout_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate> efl_ui_autorepeat_initial_timeout_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double autorepeat_initial_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_initial_timeout_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IAutoRepeat)ws.Target).GetAutorepeatInitialTimeout();
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
                return efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_autorepeat_initial_timeout_get_delegate efl_ui_autorepeat_initial_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_initial_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        internal delegate void efl_ui_autorepeat_initial_timeout_set_api_delegate(System.IntPtr obj,  double t);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate> efl_ui_autorepeat_initial_timeout_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void autorepeat_initial_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_initial_timeout_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IAutoRepeat)ws.Target).SetAutorepeatInitialTimeout(t);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), t);
            }
        }

        private static efl_ui_autorepeat_initial_timeout_set_delegate efl_ui_autorepeat_initial_timeout_set_static_delegate;

        
        private delegate double efl_ui_autorepeat_gap_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_ui_autorepeat_gap_timeout_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate> efl_ui_autorepeat_gap_timeout_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double autorepeat_gap_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_gap_timeout_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IAutoRepeat)ws.Target).GetAutorepeatGapTimeout();
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
                return efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_autorepeat_gap_timeout_get_delegate efl_ui_autorepeat_gap_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_gap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        internal delegate void efl_ui_autorepeat_gap_timeout_set_api_delegate(System.IntPtr obj,  double t);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate> efl_ui_autorepeat_gap_timeout_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void autorepeat_gap_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_gap_timeout_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IAutoRepeat)ws.Target).SetAutorepeatGapTimeout(t);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), t);
            }
        }

        private static efl_ui_autorepeat_gap_timeout_set_delegate efl_ui_autorepeat_gap_timeout_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_autorepeat_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_autorepeat_enabled_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate> efl_ui_autorepeat_enabled_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate>(Module, "efl_ui_autorepeat_enabled_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool autorepeat_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_enabled_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IAutoRepeat)ws.Target).GetAutorepeatEnabled();
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
                return efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_autorepeat_enabled_get_delegate efl_ui_autorepeat_enabled_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool on);

        
        internal delegate void efl_ui_autorepeat_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool on);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate> efl_ui_autorepeat_enabled_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate>(Module, "efl_ui_autorepeat_enabled_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void autorepeat_enabled_set(System.IntPtr obj, System.IntPtr pd, bool on)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_autorepeat_enabled_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IAutoRepeat)ws.Target).SetAutorepeatEnabled(on);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), on);
            }
        }

        private static efl_ui_autorepeat_enabled_set_delegate efl_ui_autorepeat_enabled_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class AutoRepeatExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> AutorepeatInitialTimeout<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IAutoRepeat, T>magic = null) where T : CoreUI.UI.IAutoRepeat {
            return new CoreUI.BindableProperty<double>("autorepeat_initial_timeout", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> AutorepeatGapTimeout<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IAutoRepeat, T>magic = null) where T : CoreUI.UI.IAutoRepeat {
            return new CoreUI.BindableProperty<double>("autorepeat_gap_timeout", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AutorepeatEnabled<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IAutoRepeat, T>magic = null) where T : CoreUI.UI.IAutoRepeat {
            return new CoreUI.BindableProperty<bool>("autorepeat_enabled", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

