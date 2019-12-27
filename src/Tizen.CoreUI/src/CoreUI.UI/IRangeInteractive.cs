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
    /// <summary>Interface that extends the normal displaying properties with usage properties.
    /// 
    /// The properties defined here are used to manipulate the way a user interacts with a displayed range.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IRangeInteractiveNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IRangeInteractive : 
    CoreUI.UI.IRangeDisplay,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <returns>The step value.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetRangeStep();

        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <param name="step">The step value.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetRangeStep(double step);

        /// <summary>Called when the widget&apos;s value has changed and has remained unchanged for 0.2s. This allows filtering out unwanted &quot;noise&quot; from the widget if you are only interested in its final position. Use this event instead of <see cref="CoreUI.UI.IRangeDisplay.Changed"/> if you are going to perform a costly operation on its handler.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler Steady;
        /// <summary>Control the step used to increment or decrement values for given widget.
        /// 
        /// This value will be incremented or decremented to the displayed value.
        /// 
        /// By default step value is equal to 1.
        /// 
        /// <b>WARNING: </b>The step value should be bigger than 0.</summary>
        /// <value>The step value.</value>
        /// <since_tizen> 6 </since_tizen>
        double RangeStep {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IRangeInteractiveNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_range_interactive_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_range_step_get_static_delegate == null)
            {
                efl_ui_range_step_get_static_delegate = new efl_ui_range_step_get_delegate(range_step_get);
            }

            if (methods.Contains("GetRangeStep"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_get_static_delegate) });
            }

            if (efl_ui_range_step_set_static_delegate == null)
            {
                efl_ui_range_step_set_static_delegate = new efl_ui_range_step_set_delegate(range_step_set);
            }

            if (methods.Contains("SetRangeStep"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_set_static_delegate) });
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
            return efl_ui_range_interactive_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_range_step_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_ui_range_step_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_step_get_api_delegate> efl_ui_range_step_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_step_get_api_delegate>(Module, "efl_ui_range_step_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double range_step_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_step_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IRangeInteractive)ws.Target).GetRangeStep();
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
                return efl_ui_range_step_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_range_step_get_delegate efl_ui_range_step_get_static_delegate;

        
        private delegate void efl_ui_range_step_set_delegate(System.IntPtr obj, System.IntPtr pd,  double step);

        
        internal delegate void efl_ui_range_step_set_api_delegate(System.IntPtr obj,  double step);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_range_step_set_api_delegate> efl_ui_range_step_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_range_step_set_api_delegate>(Module, "efl_ui_range_step_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void range_step_set(System.IntPtr obj, System.IntPtr pd, double step)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_range_step_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRangeInteractive)ws.Target).SetRangeStep(step);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_range_step_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), step);
            }
        }

        private static efl_ui_range_step_set_delegate efl_ui_range_step_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class RangeInteractiveExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeStep<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IRangeInteractive, T>magic = null) where T : CoreUI.UI.IRangeInteractive {
            return new CoreUI.BindableProperty<double>("range_step", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> RangeValue<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IRangeInteractive, T>magic = null) where T : CoreUI.UI.IRangeInteractive {
            return new CoreUI.BindableProperty<double>("range_value", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

