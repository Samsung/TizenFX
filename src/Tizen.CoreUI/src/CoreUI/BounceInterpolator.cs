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
    /// <summary>Bouncing interpolator. The value quickly reaches <c>1.0</c> and then bounces back a number of times before stopping at <c>1.0</c>.
    /// 
    /// The number of bounces and how far it goes back on every bounce can be customized.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.BounceInterpolator.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class BounceInterpolator : CoreUI.Object, CoreUI.IInterpolator
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(BounceInterpolator))
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
            efl_bounce_interpolator_class_get();

        /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public BounceInterpolator(CoreUI.Object parent= null) : base(efl_bounce_interpolator_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected BounceInterpolator(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal BounceInterpolator(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected BounceInterpolator(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Customize the number of bounces.</summary>
        /// <returns>Number of bounces before stopping.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetBounces() {
            var _ret_var = CoreUI.BounceInterpolator.NativeMethods.efl_bounce_interpolator_bounces_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize the number of bounces.</summary>
        /// <param name="bounces">Number of bounces before stopping.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBounces(int bounces) {
            CoreUI.BounceInterpolator.NativeMethods.efl_bounce_interpolator_bounces_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), bounces);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Customize the rigidness.</summary>
        /// <returns>How much energy is lost on every bounce. Higher numbers result in smaller bounces (lesser bounciness).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRigidness() {
            var _ret_var = CoreUI.BounceInterpolator.NativeMethods.efl_bounce_interpolator_rigidness_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Customize the rigidness.</summary>
        /// <param name="rigidness">How much energy is lost on every bounce. Higher numbers result in smaller bounces (lesser bounciness).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRigidness(double rigidness) {
            CoreUI.BounceInterpolator.NativeMethods.efl_bounce_interpolator_rigidness_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), rigidness);
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

        /// <summary>Customize the number of bounces.</summary>
        /// <value>Number of bounces before stopping.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Bounces {
            get { return GetBounces(); }
            set { SetBounces(value); }
        }

        /// <summary>Customize the rigidness.</summary>
        /// <value>How much energy is lost on every bounce. Higher numbers result in smaller bounces (lesser bounciness).</value>
        /// <since_tizen> 6 </since_tizen>
        public double Rigidness {
            get { return GetRigidness(); }
            set { SetRigidness(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.BounceInterpolator.efl_bounce_interpolator_class_get();
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

                if (efl_bounce_interpolator_bounces_get_static_delegate == null)
                {
                    efl_bounce_interpolator_bounces_get_static_delegate = new efl_bounce_interpolator_bounces_get_delegate(bounces_get);
                }

                if (methods.Contains("GetBounces"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_bounces_get"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_bounces_get_static_delegate) });
                }

                if (efl_bounce_interpolator_bounces_set_static_delegate == null)
                {
                    efl_bounce_interpolator_bounces_set_static_delegate = new efl_bounce_interpolator_bounces_set_delegate(bounces_set);
                }

                if (methods.Contains("SetBounces"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_bounces_set"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_bounces_set_static_delegate) });
                }

                if (efl_bounce_interpolator_rigidness_get_static_delegate == null)
                {
                    efl_bounce_interpolator_rigidness_get_static_delegate = new efl_bounce_interpolator_rigidness_get_delegate(rigidness_get);
                }

                if (methods.Contains("GetRigidness"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_rigidness_get"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_rigidness_get_static_delegate) });
                }

                if (efl_bounce_interpolator_rigidness_set_static_delegate == null)
                {
                    efl_bounce_interpolator_rigidness_set_static_delegate = new efl_bounce_interpolator_rigidness_set_delegate(rigidness_set);
                }

                if (methods.Contains("SetRigidness"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_rigidness_set"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_rigidness_set_static_delegate) });
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
                return CoreUI.BounceInterpolator.efl_bounce_interpolator_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate int efl_bounce_interpolator_bounces_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_bounce_interpolator_bounces_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_bounces_get_api_delegate> efl_bounce_interpolator_bounces_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_bounces_get_api_delegate>(Module, "efl_bounce_interpolator_bounces_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int bounces_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_bounce_interpolator_bounces_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((BounceInterpolator)ws.Target).GetBounces();
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
                    return efl_bounce_interpolator_bounces_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_bounce_interpolator_bounces_get_delegate efl_bounce_interpolator_bounces_get_static_delegate;

            
            private delegate void efl_bounce_interpolator_bounces_set_delegate(System.IntPtr obj, System.IntPtr pd,  int bounces);

            
            internal delegate void efl_bounce_interpolator_bounces_set_api_delegate(System.IntPtr obj,  int bounces);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_bounces_set_api_delegate> efl_bounce_interpolator_bounces_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_bounces_set_api_delegate>(Module, "efl_bounce_interpolator_bounces_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void bounces_set(System.IntPtr obj, System.IntPtr pd, int bounces)
            {
                CoreUI.DataTypes.Log.Debug("function efl_bounce_interpolator_bounces_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((BounceInterpolator)ws.Target).SetBounces(bounces);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_bounce_interpolator_bounces_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), bounces);
                }
            }

            private static efl_bounce_interpolator_bounces_set_delegate efl_bounce_interpolator_bounces_set_static_delegate;

            
            private delegate double efl_bounce_interpolator_rigidness_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_bounce_interpolator_rigidness_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_rigidness_get_api_delegate> efl_bounce_interpolator_rigidness_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_rigidness_get_api_delegate>(Module, "efl_bounce_interpolator_rigidness_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double rigidness_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_bounce_interpolator_rigidness_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((BounceInterpolator)ws.Target).GetRigidness();
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
                    return efl_bounce_interpolator_rigidness_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_bounce_interpolator_rigidness_get_delegate efl_bounce_interpolator_rigidness_get_static_delegate;

            
            private delegate void efl_bounce_interpolator_rigidness_set_delegate(System.IntPtr obj, System.IntPtr pd,  double rigidness);

            
            internal delegate void efl_bounce_interpolator_rigidness_set_api_delegate(System.IntPtr obj,  double rigidness);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_rigidness_set_api_delegate> efl_bounce_interpolator_rigidness_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_bounce_interpolator_rigidness_set_api_delegate>(Module, "efl_bounce_interpolator_rigidness_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void rigidness_set(System.IntPtr obj, System.IntPtr pd, double rigidness)
            {
                CoreUI.DataTypes.Log.Debug("function efl_bounce_interpolator_rigidness_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((BounceInterpolator)ws.Target).SetRigidness(rigidness);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_bounce_interpolator_rigidness_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rigidness);
                }
            }

            private static efl_bounce_interpolator_rigidness_set_delegate efl_bounce_interpolator_rigidness_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class BounceInterpolatorExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> Bounces<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.BounceInterpolator, T>magic = null) where T : CoreUI.BounceInterpolator {
            return new CoreUI.BindableProperty<int>("bounces", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Rigidness<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.BounceInterpolator, T>magic = null) where T : CoreUI.BounceInterpolator {
            return new CoreUI.BindableProperty<double>("rigidness", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

