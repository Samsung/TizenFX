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
    /// <summary>Interface providing interpolation capabilities.
    /// 
    /// In the context of EFL, interpolation is defined as the mapping of values in the <c>0, 1</c> range to another range (typically close).
    /// 
    /// This is used for example in animations, where the timer moves linearly from <c>0.0</c> to <c>1.0</c> but the property being animated can accelerate, decelerate, bounce or even move slightly out-of-bounds and come back.
    /// 
    /// For example implementations see <see cref="CoreUI.AccelerateInterpolator"/>, <see cref="CoreUI.DecelerateInterpolator"/> or <see cref="CoreUI.BounceInterpolator"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IInterpolatorNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IInterpolator : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Performs the mapping operation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="progress">Input value between <c>0.0</c> and <c>1.0</c>. Values outside this range might yield unpredictable results.</param>
        /// <returns>Output mapped value. Its range is unrestricted. In particular, it might be outside the input <c>0, 1</c> range.</returns>
        double Interpolate(double progress);

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IInterpolatorNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_interpolator_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_interpolator_interpolate_static_delegate == null)
            {
                efl_interpolator_interpolate_static_delegate = new efl_interpolator_interpolate_delegate(interpolate);
            }

            if (methods.Contains("Interpolate"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_interpolator_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_interpolator_interpolate_static_delegate) });
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
            return efl_interpolator_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,  double progress);

        
        internal delegate double efl_interpolator_interpolate_api_delegate(System.IntPtr obj,  double progress);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_interpolator_interpolate_api_delegate> efl_interpolator_interpolate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_interpolator_interpolate_api_delegate>(Module, "efl_interpolator_interpolate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double interpolate(System.IntPtr obj, System.IntPtr pd, double progress)
        {
            CoreUI.DataTypes.Log.Debug("function efl_interpolator_interpolate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IInterpolator)ws.Target).Interpolate(progress);
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
                return efl_interpolator_interpolate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), progress);
            }
        }

        private static efl_interpolator_interpolate_delegate efl_interpolator_interpolate_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

