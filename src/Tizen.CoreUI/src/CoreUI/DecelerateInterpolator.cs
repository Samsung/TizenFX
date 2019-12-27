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
    /// <summary>Decelerated interpolator. It starts fast and decelerates, stopping smoothly when it reaches <c>1.0</c>.
    /// 
    /// Internally it uses the second half of a sinus rise (from 0.5 to 1.0) and the steepness can be customized through the <see cref="CoreUI.DecelerateInterpolator.Slope"/> property.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.DecelerateInterpolator.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class DecelerateInterpolator : CoreUI.Object, CoreUI.IInterpolator
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(DecelerateInterpolator))
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
            efl_decelerate_interpolator_class_get();

        /// <summary>Initializes a new instance of the <see cref="DecelerateInterpolator"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public DecelerateInterpolator(CoreUI.Object parent= null) : base(efl_decelerate_interpolator_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected DecelerateInterpolator(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DecelerateInterpolator"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal DecelerateInterpolator(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DecelerateInterpolator"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected DecelerateInterpolator(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Customize the deceleration effect.</summary>
        /// <returns>How steep is the effect. <c>0</c> performs a linear interpolation, <c>1</c> corresponds to a sinus function and higher numbers produce an increasingly steep effect.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetSlope() {
            var _ret_var = CoreUI.DecelerateInterpolator.NativeMethods.efl_decelerate_interpolator_slope_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize the deceleration effect.</summary>
        /// <param name="slope">How steep is the effect. <c>0</c> performs a linear interpolation, <c>1</c> corresponds to a sinus function and higher numbers produce an increasingly steep effect.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSlope(double slope) {
            CoreUI.DecelerateInterpolator.NativeMethods.efl_decelerate_interpolator_slope_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), slope);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Performs the mapping operation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="progress">Input value between <c>0.0</c> and <c>1.0</c>. Values outside this range might yield unpredictable results.</param>
        /// <returns>Output mapped value. Its range is unrestricted. In particular, it might be outside the input <c>0, 1</c> range.</returns>
        public virtual double Interpolate(double progress) {
            var _ret_var = CoreUI.IInterpolatorNativeMethods.efl_interpolator_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), progress);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize the deceleration effect.</summary>
        /// <value>How steep is the effect. <c>0</c> performs a linear interpolation, <c>1</c> corresponds to a sinus function and higher numbers produce an increasingly steep effect.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Slope {
            get { return GetSlope(); }
            set { SetSlope(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.DecelerateInterpolator.efl_decelerate_interpolator_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_decelerate_interpolator_slope_get_static_delegate == null)
                {
                    efl_decelerate_interpolator_slope_get_static_delegate = new efl_decelerate_interpolator_slope_get_delegate(slope_get);
                }

                if (methods.Contains("GetSlope"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_decelerate_interpolator_slope_get"), func = Marshal.GetFunctionPointerForDelegate(efl_decelerate_interpolator_slope_get_static_delegate) });
                }

                if (efl_decelerate_interpolator_slope_set_static_delegate == null)
                {
                    efl_decelerate_interpolator_slope_set_static_delegate = new efl_decelerate_interpolator_slope_set_delegate(slope_set);
                }

                if (methods.Contains("SetSlope"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_decelerate_interpolator_slope_set"), func = Marshal.GetFunctionPointerForDelegate(efl_decelerate_interpolator_slope_set_static_delegate) });
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
                return CoreUI.DecelerateInterpolator.efl_decelerate_interpolator_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate double efl_decelerate_interpolator_slope_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_decelerate_interpolator_slope_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_decelerate_interpolator_slope_get_api_delegate> efl_decelerate_interpolator_slope_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_decelerate_interpolator_slope_get_api_delegate>(Module, "efl_decelerate_interpolator_slope_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double slope_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_decelerate_interpolator_slope_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((DecelerateInterpolator)ws.Target).GetSlope();
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
                    return efl_decelerate_interpolator_slope_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_decelerate_interpolator_slope_get_delegate efl_decelerate_interpolator_slope_get_static_delegate;

            
            private delegate void efl_decelerate_interpolator_slope_set_delegate(System.IntPtr obj, System.IntPtr pd,  double slope);

            
            internal delegate void efl_decelerate_interpolator_slope_set_api_delegate(System.IntPtr obj,  double slope);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_decelerate_interpolator_slope_set_api_delegate> efl_decelerate_interpolator_slope_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_decelerate_interpolator_slope_set_api_delegate>(Module, "efl_decelerate_interpolator_slope_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void slope_set(System.IntPtr obj, System.IntPtr pd, double slope)
            {
                CoreUI.DataTypes.Log.Debug("function efl_decelerate_interpolator_slope_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((DecelerateInterpolator)ws.Target).SetSlope(slope);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_decelerate_interpolator_slope_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), slope);
                }
            }

            private static efl_decelerate_interpolator_slope_set_delegate efl_decelerate_interpolator_slope_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class DecelerateInterpolatorExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Slope<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.DecelerateInterpolator, T>magic = null) where T : CoreUI.DecelerateInterpolator {
            return new CoreUI.BindableProperty<double>("slope", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

