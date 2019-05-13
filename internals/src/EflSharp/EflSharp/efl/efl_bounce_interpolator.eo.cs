#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl bounce interpolator class</summary>
[Efl.BounceInterpolator.NativeMethods]
public class BounceInterpolator : Efl.Object, Efl.Eo.IWrapper,Efl.IInterpolator
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(BounceInterpolator))
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
        efl_bounce_interpolator_class_get();
    /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public BounceInterpolator(Efl.Object parent= null
            ) : base(efl_bounce_interpolator_class_get(), typeof(BounceInterpolator), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected BounceInterpolator(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="BounceInterpolator"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected BounceInterpolator(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Factors property</summary>
    /// <param name="factor1">First factor of the interpolation function.</param>
    /// <param name="factor2">Second factor of the interpolation function.</param>
    virtual public void GetFactors(out double factor1, out double factor2) {
                                                         Efl.BounceInterpolator.NativeMethods.efl_bounce_interpolator_factors_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out factor1, out factor2);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Factors property</summary>
    /// <param name="factor1">First factor of the interpolation function.</param>
    /// <param name="factor2">Second factor of the interpolation function.</param>
    virtual public void SetFactors(double factor1, double factor2) {
                                                         Efl.BounceInterpolator.NativeMethods.efl_bounce_interpolator_factors_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),factor1, factor2);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Interpolate the given value.</summary>
    /// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
    /// <returns>Output value calculated by interpolating the input value.</returns>
    virtual public double Interpolate(double progress) {
                                 var _ret_var = Efl.IInterpolatorConcrete.NativeMethods.efl_interpolator_interpolate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),progress);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.BounceInterpolator.efl_bounce_interpolator_class_get();
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

            if (efl_bounce_interpolator_factors_get_static_delegate == null)
            {
                efl_bounce_interpolator_factors_get_static_delegate = new efl_bounce_interpolator_factors_get_delegate(factors_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFactors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_factors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_factors_get_static_delegate) });
            }

            if (efl_bounce_interpolator_factors_set_static_delegate == null)
            {
                efl_bounce_interpolator_factors_set_static_delegate = new efl_bounce_interpolator_factors_set_delegate(factors_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFactors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_bounce_interpolator_factors_set"), func = Marshal.GetFunctionPointerForDelegate(efl_bounce_interpolator_factors_set_static_delegate) });
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
            return Efl.BounceInterpolator.efl_bounce_interpolator_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_bounce_interpolator_factors_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double factor1,  out double factor2);

        
        public delegate void efl_bounce_interpolator_factors_get_api_delegate(System.IntPtr obj,  out double factor1,  out double factor2);

        public static Efl.Eo.FunctionWrapper<efl_bounce_interpolator_factors_get_api_delegate> efl_bounce_interpolator_factors_get_ptr = new Efl.Eo.FunctionWrapper<efl_bounce_interpolator_factors_get_api_delegate>(Module, "efl_bounce_interpolator_factors_get");

        private static void factors_get(System.IntPtr obj, System.IntPtr pd, out double factor1, out double factor2)
        {
            Eina.Log.Debug("function efl_bounce_interpolator_factors_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        factor1 = default(double);        factor2 = default(double);                            
                try
                {
                    ((BounceInterpolator)wrapper).GetFactors(out factor1, out factor2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_bounce_interpolator_factors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out factor1, out factor2);
            }
        }

        private static efl_bounce_interpolator_factors_get_delegate efl_bounce_interpolator_factors_get_static_delegate;

        
        private delegate void efl_bounce_interpolator_factors_set_delegate(System.IntPtr obj, System.IntPtr pd,  double factor1,  double factor2);

        
        public delegate void efl_bounce_interpolator_factors_set_api_delegate(System.IntPtr obj,  double factor1,  double factor2);

        public static Efl.Eo.FunctionWrapper<efl_bounce_interpolator_factors_set_api_delegate> efl_bounce_interpolator_factors_set_ptr = new Efl.Eo.FunctionWrapper<efl_bounce_interpolator_factors_set_api_delegate>(Module, "efl_bounce_interpolator_factors_set");

        private static void factors_set(System.IntPtr obj, System.IntPtr pd, double factor1, double factor2)
        {
            Eina.Log.Debug("function efl_bounce_interpolator_factors_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((BounceInterpolator)wrapper).SetFactors(factor1, factor2);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_bounce_interpolator_factors_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), factor1, factor2);
            }
        }

        private static efl_bounce_interpolator_factors_set_delegate efl_bounce_interpolator_factors_set_static_delegate;

        
        private delegate double efl_interpolator_interpolate_delegate(System.IntPtr obj, System.IntPtr pd,  double progress);

        
        public delegate double efl_interpolator_interpolate_api_delegate(System.IntPtr obj,  double progress);

        public static Efl.Eo.FunctionWrapper<efl_interpolator_interpolate_api_delegate> efl_interpolator_interpolate_ptr = new Efl.Eo.FunctionWrapper<efl_interpolator_interpolate_api_delegate>(Module, "efl_interpolator_interpolate");

        private static double interpolate(System.IntPtr obj, System.IntPtr pd, double progress)
        {
            Eina.Log.Debug("function efl_interpolator_interpolate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    double _ret_var = default(double);
                try
                {
                    _ret_var = ((BounceInterpolator)wrapper).Interpolate(progress);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

