#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl accelerate interpolator class
/// output = 1 - sin(Pi / 2 + input * Pi / 2);</summary>
[Efl.AccelerateInterpolator.NativeMethods]
public class AccelerateInterpolator : Efl.Object, Efl.Eo.IWrapper,Efl.IInterpolator
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AccelerateInterpolator))
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
        efl_accelerate_interpolator_class_get();
    /// <summary>Initializes a new instance of the <see cref="AccelerateInterpolator"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public AccelerateInterpolator(Efl.Object parent= null
            ) : base(efl_accelerate_interpolator_class_get(), typeof(AccelerateInterpolator), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="AccelerateInterpolator"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected AccelerateInterpolator(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="AccelerateInterpolator"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AccelerateInterpolator(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Factor property</summary>
    /// <returns>Factor of the interpolation function.</returns>
    virtual public double GetFactor() {
         var _ret_var = Efl.AccelerateInterpolator.NativeMethods.efl_accelerate_interpolator_factor_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Factor property</summary>
    /// <param name="factor">Factor of the interpolation function.</param>
    virtual public void SetFactor(double factor) {
                                 Efl.AccelerateInterpolator.NativeMethods.efl_accelerate_interpolator_factor_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),factor);
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
    /// <summary>Factor property</summary>
/// <value>Factor of the interpolation function.</value>
    public double Factor {
        get { return GetFactor(); }
        set { SetFactor(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.AccelerateInterpolator.efl_accelerate_interpolator_class_get();
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

            if (efl_accelerate_interpolator_factor_get_static_delegate == null)
            {
                efl_accelerate_interpolator_factor_get_static_delegate = new efl_accelerate_interpolator_factor_get_delegate(factor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFactor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_accelerate_interpolator_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_accelerate_interpolator_factor_get_static_delegate) });
            }

            if (efl_accelerate_interpolator_factor_set_static_delegate == null)
            {
                efl_accelerate_interpolator_factor_set_static_delegate = new efl_accelerate_interpolator_factor_set_delegate(factor_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFactor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_accelerate_interpolator_factor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_accelerate_interpolator_factor_set_static_delegate) });
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
            return Efl.AccelerateInterpolator.efl_accelerate_interpolator_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate double efl_accelerate_interpolator_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_accelerate_interpolator_factor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_get_api_delegate> efl_accelerate_interpolator_factor_get_ptr = new Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_get_api_delegate>(Module, "efl_accelerate_interpolator_factor_get");

        private static double factor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_accelerate_interpolator_factor_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AccelerateInterpolator)wrapper).GetFactor();
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
                return efl_accelerate_interpolator_factor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_accelerate_interpolator_factor_get_delegate efl_accelerate_interpolator_factor_get_static_delegate;

        
        private delegate void efl_accelerate_interpolator_factor_set_delegate(System.IntPtr obj, System.IntPtr pd,  double factor);

        
        public delegate void efl_accelerate_interpolator_factor_set_api_delegate(System.IntPtr obj,  double factor);

        public static Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_set_api_delegate> efl_accelerate_interpolator_factor_set_ptr = new Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_set_api_delegate>(Module, "efl_accelerate_interpolator_factor_set");

        private static void factor_set(System.IntPtr obj, System.IntPtr pd, double factor)
        {
            Eina.Log.Debug("function efl_accelerate_interpolator_factor_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((AccelerateInterpolator)wrapper).SetFactor(factor);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_accelerate_interpolator_factor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), factor);
            }
        }

        private static efl_accelerate_interpolator_factor_set_delegate efl_accelerate_interpolator_factor_set_static_delegate;

        
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
                    _ret_var = ((AccelerateInterpolator)wrapper).Interpolate(progress);
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

