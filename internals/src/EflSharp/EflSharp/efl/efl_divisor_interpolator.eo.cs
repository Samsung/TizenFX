#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl divisor interpolator class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.DivisorInterpolator.NativeMethods]
[Efl.Eo.BindingEntity]
public class DivisorInterpolator : Efl.Object, Efl.IInterpolator
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(DivisorInterpolator))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_divisor_interpolator_class_get();
    /// <summary>Initializes a new instance of the <see cref="DivisorInterpolator"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public DivisorInterpolator(Efl.Object parent= null
            ) : base(efl_divisor_interpolator_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected DivisorInterpolator(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="DivisorInterpolator"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected DivisorInterpolator(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="DivisorInterpolator"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected DivisorInterpolator(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Factors property</summary>
    /// <param name="factor1">First factor of the interpolation function.</param>
    /// <param name="factor2">Second factor of the interpolation function.</param>
    virtual public void GetFactors(out double factor1, out double factor2) {
                                                         Efl.DivisorInterpolator.NativeMethods.efl_divisor_interpolator_factors_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out factor1, out factor2);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Factors property</summary>
    /// <param name="factor1">First factor of the interpolation function.</param>
    /// <param name="factor2">Second factor of the interpolation function.</param>
    virtual public void SetFactors(double factor1, double factor2) {
                                                         Efl.DivisorInterpolator.NativeMethods.efl_divisor_interpolator_factors_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),factor1, factor2);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Interpolate the given value.</summary>
    /// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
    /// <returns>Output value calculated by interpolating the input value.</returns>
    virtual public double Interpolate(double progress) {
                                 var _ret_var = Efl.IInterpolatorConcrete.NativeMethods.efl_interpolator_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),progress);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Factors property</summary>
    /// <value>First factor of the interpolation function.</value>
    public (double, double) Factors {
        get {
            double _out_factor1 = default(double);
            double _out_factor2 = default(double);
            GetFactors(out _out_factor1,out _out_factor2);
            return (_out_factor1,_out_factor2);
        }
        set { SetFactors( value.Item1,  value.Item2); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.DivisorInterpolator.efl_divisor_interpolator_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_divisor_interpolator_factors_get_static_delegate == null)
            {
                efl_divisor_interpolator_factors_get_static_delegate = new efl_divisor_interpolator_factors_get_delegate(factors_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFactors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_divisor_interpolator_factors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_divisor_interpolator_factors_get_static_delegate) });
            }

            if (efl_divisor_interpolator_factors_set_static_delegate == null)
            {
                efl_divisor_interpolator_factors_set_static_delegate = new efl_divisor_interpolator_factors_set_delegate(factors_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFactors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_divisor_interpolator_factors_set"), func = Marshal.GetFunctionPointerForDelegate(efl_divisor_interpolator_factors_set_static_delegate) });
            }

            if (efl_interpolator_interpolate_static_delegate == null)
            {
                efl_interpolator_interpolate_static_delegate = new efl_interpolator_interpolate_delegate(interpolate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Interpolate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_interpolator_interpolate"), func = Marshal.GetFunctionPointerForDelegate(efl_interpolator_interpolate_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.DivisorInterpolator.efl_divisor_interpolator_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_divisor_interpolator_factors_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double factor1,  out double factor2);

        
        public delegate void efl_divisor_interpolator_factors_get_api_delegate(System.IntPtr obj,  out double factor1,  out double factor2);

        public static Efl.Eo.FunctionWrapper<efl_divisor_interpolator_factors_get_api_delegate> efl_divisor_interpolator_factors_get_ptr = new Efl.Eo.FunctionWrapper<efl_divisor_interpolator_factors_get_api_delegate>(Module, "efl_divisor_interpolator_factors_get");

        private static void factors_get(System.IntPtr obj, System.IntPtr pd, out double factor1, out double factor2)
        {
            Eina.Log.Debug("function efl_divisor_interpolator_factors_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        factor1 = default(double);        factor2 = default(double);                            
                try
                {
                    ((DivisorInterpolator)ws.Target).GetFactors(out factor1, out factor2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_divisor_interpolator_factors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out factor1, out factor2);
            }
        }

        private static efl_divisor_interpolator_factors_get_delegate efl_divisor_interpolator_factors_get_static_delegate;

        
        private delegate void efl_divisor_interpolator_factors_set_delegate(System.IntPtr obj, System.IntPtr pd,  double factor1,  double factor2);

        
        public delegate void efl_divisor_interpolator_factors_set_api_delegate(System.IntPtr obj,  double factor1,  double factor2);

        public static Efl.Eo.FunctionWrapper<efl_divisor_interpolator_factors_set_api_delegate> efl_divisor_interpolator_factors_set_ptr = new Efl.Eo.FunctionWrapper<efl_divisor_interpolator_factors_set_api_delegate>(Module, "efl_divisor_interpolator_factors_set");

        private static void factors_set(System.IntPtr obj, System.IntPtr pd, double factor1, double factor2)
        {
            Eina.Log.Debug("function efl_divisor_interpolator_factors_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((DivisorInterpolator)ws.Target).SetFactors(factor1, factor2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_divisor_interpolator_factors_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), factor1, factor2);
            }
        }

        private static efl_divisor_interpolator_factors_set_delegate efl_divisor_interpolator_factors_set_static_delegate;

        
        private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,  double progress);

        
        public delegate double efl_interpolator_interpolate_api_delegate(System.IntPtr obj,  double progress);

        public static Efl.Eo.FunctionWrapper<efl_interpolator_interpolate_api_delegate> efl_interpolator_interpolate_ptr = new Efl.Eo.FunctionWrapper<efl_interpolator_interpolate_api_delegate>(Module, "efl_interpolator_interpolate");

        private static double interpolate(System.IntPtr obj, System.IntPtr pd, double progress)
        {
            Eina.Log.Debug("function efl_interpolator_interpolate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    double _ret_var = default(double);
                try
                {
                    _ret_var = ((DivisorInterpolator)ws.Target).Interpolate(progress);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_interpolator_interpolate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), progress);
            }
        }

        private static efl_interpolator_interpolate_delegate efl_interpolator_interpolate_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflDivisorInterpolator_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
