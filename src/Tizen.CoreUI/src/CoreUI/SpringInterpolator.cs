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
    /// <summary>Spring interpolator. The value quickly reaches <c>1.0</c> and then oscillates around it a number of times before stopping (as if linked with a spring).
    /// 
    /// The number of oscillations and how quickly it stops can be customized.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.SpringInterpolator.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class SpringInterpolator : CoreUI.Object, CoreUI.IInterpolator
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(SpringInterpolator))
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
            efl_spring_interpolator_class_get();

        /// <summary>Initializes a new instance of the <see cref="SpringInterpolator"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public SpringInterpolator(CoreUI.Object parent= null) : base(efl_spring_interpolator_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected SpringInterpolator(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SpringInterpolator"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal SpringInterpolator(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SpringInterpolator"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected SpringInterpolator(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Customize the decay factor.</summary>
        /// <returns>How quickly energy is lost. Higher numbers result in smaller oscillations.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetDecay() {
            var _ret_var = CoreUI.SpringInterpolator.NativeMethods.efl_spring_interpolator_decay_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize the decay factor.</summary>
        /// <param name="decay">How quickly energy is lost. Higher numbers result in smaller oscillations.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDecay(double decay) {
            CoreUI.SpringInterpolator.NativeMethods.efl_spring_interpolator_decay_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), decay);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Customize number of oscillations.</summary>
        /// <returns>Number of oscillations before stopping.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetOscillations() {
            var _ret_var = CoreUI.SpringInterpolator.NativeMethods.efl_spring_interpolator_oscillations_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize number of oscillations.</summary>
        /// <param name="oscillations">Number of oscillations before stopping.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOscillations(int oscillations) {
            CoreUI.SpringInterpolator.NativeMethods.efl_spring_interpolator_oscillations_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), oscillations);
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

        /// <summary>Customize the decay factor.</summary>
        /// <value>How quickly energy is lost. Higher numbers result in smaller oscillations.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Decay {
            get { return GetDecay(); }
            set { SetDecay(value); }
        }

        /// <summary>Customize number of oscillations.</summary>
        /// <value>Number of oscillations before stopping.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Oscillations {
            get { return GetOscillations(); }
            set { SetOscillations(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.SpringInterpolator.efl_spring_interpolator_class_get();
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

                if (efl_spring_interpolator_decay_get_static_delegate == null)
                {
                    efl_spring_interpolator_decay_get_static_delegate = new efl_spring_interpolator_decay_get_delegate(decay_get);
                }

                if (methods.Contains("GetDecay"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_spring_interpolator_decay_get"), func = Marshal.GetFunctionPointerForDelegate(efl_spring_interpolator_decay_get_static_delegate) });
                }

                if (efl_spring_interpolator_decay_set_static_delegate == null)
                {
                    efl_spring_interpolator_decay_set_static_delegate = new efl_spring_interpolator_decay_set_delegate(decay_set);
                }

                if (methods.Contains("SetDecay"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_spring_interpolator_decay_set"), func = Marshal.GetFunctionPointerForDelegate(efl_spring_interpolator_decay_set_static_delegate) });
                }

                if (efl_spring_interpolator_oscillations_get_static_delegate == null)
                {
                    efl_spring_interpolator_oscillations_get_static_delegate = new efl_spring_interpolator_oscillations_get_delegate(oscillations_get);
                }

                if (methods.Contains("GetOscillations"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_spring_interpolator_oscillations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_spring_interpolator_oscillations_get_static_delegate) });
                }

                if (efl_spring_interpolator_oscillations_set_static_delegate == null)
                {
                    efl_spring_interpolator_oscillations_set_static_delegate = new efl_spring_interpolator_oscillations_set_delegate(oscillations_set);
                }

                if (methods.Contains("SetOscillations"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_spring_interpolator_oscillations_set"), func = Marshal.GetFunctionPointerForDelegate(efl_spring_interpolator_oscillations_set_static_delegate) });
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
                return CoreUI.SpringInterpolator.efl_spring_interpolator_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate double efl_spring_interpolator_decay_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_spring_interpolator_decay_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_decay_get_api_delegate> efl_spring_interpolator_decay_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_decay_get_api_delegate>(Module, "efl_spring_interpolator_decay_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double decay_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_spring_interpolator_decay_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((SpringInterpolator)ws.Target).GetDecay();
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
                    return efl_spring_interpolator_decay_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_spring_interpolator_decay_get_delegate efl_spring_interpolator_decay_get_static_delegate;

            
            private delegate void efl_spring_interpolator_decay_set_delegate(System.IntPtr obj, System.IntPtr pd,  double decay);

            
            internal delegate void efl_spring_interpolator_decay_set_api_delegate(System.IntPtr obj,  double decay);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_decay_set_api_delegate> efl_spring_interpolator_decay_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_decay_set_api_delegate>(Module, "efl_spring_interpolator_decay_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void decay_set(System.IntPtr obj, System.IntPtr pd, double decay)
            {
                CoreUI.DataTypes.Log.Debug("function efl_spring_interpolator_decay_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((SpringInterpolator)ws.Target).SetDecay(decay);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_spring_interpolator_decay_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), decay);
                }
            }

            private static efl_spring_interpolator_decay_set_delegate efl_spring_interpolator_decay_set_static_delegate;

            
            private delegate int efl_spring_interpolator_oscillations_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_spring_interpolator_oscillations_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_oscillations_get_api_delegate> efl_spring_interpolator_oscillations_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_oscillations_get_api_delegate>(Module, "efl_spring_interpolator_oscillations_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int oscillations_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_spring_interpolator_oscillations_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((SpringInterpolator)ws.Target).GetOscillations();
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
                    return efl_spring_interpolator_oscillations_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_spring_interpolator_oscillations_get_delegate efl_spring_interpolator_oscillations_get_static_delegate;

            
            private delegate void efl_spring_interpolator_oscillations_set_delegate(System.IntPtr obj, System.IntPtr pd,  int oscillations);

            
            internal delegate void efl_spring_interpolator_oscillations_set_api_delegate(System.IntPtr obj,  int oscillations);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_oscillations_set_api_delegate> efl_spring_interpolator_oscillations_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_spring_interpolator_oscillations_set_api_delegate>(Module, "efl_spring_interpolator_oscillations_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void oscillations_set(System.IntPtr obj, System.IntPtr pd, int oscillations)
            {
                CoreUI.DataTypes.Log.Debug("function efl_spring_interpolator_oscillations_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((SpringInterpolator)ws.Target).SetOscillations(oscillations);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_spring_interpolator_oscillations_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), oscillations);
                }
            }

            private static efl_spring_interpolator_oscillations_set_delegate efl_spring_interpolator_oscillations_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class SpringInterpolatorExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Decay<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.SpringInterpolator, T>magic = null) where T : CoreUI.SpringInterpolator {
            return new CoreUI.BindableProperty<double>("decay", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> Oscillations<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.SpringInterpolator, T>magic = null) where T : CoreUI.SpringInterpolator {
            return new CoreUI.BindableProperty<int>("oscillations", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

