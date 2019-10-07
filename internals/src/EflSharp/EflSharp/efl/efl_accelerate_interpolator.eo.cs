#define EFL_BETA
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
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.AccelerateInterpolator.NativeMethods]
[Efl.Eo.BindingEntity]
public class AccelerateInterpolator : Efl.Object, Efl.IInterpolator
{
    /// <summary>Pointer to the native class description.</summary>
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
            ) : base(efl_accelerate_interpolator_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected AccelerateInterpolator(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AccelerateInterpolator"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AccelerateInterpolator(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AccelerateInterpolator"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AccelerateInterpolator(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Factor property</summary>
    /// <returns>Factor of the interpolation function.</returns>
    public virtual double GetFactor() {
        var _ret_var = Efl.AccelerateInterpolator.NativeMethods.efl_accelerate_interpolator_factor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Factor property</summary>
    /// <param name="factor">Factor of the interpolation function.</param>
    public virtual void SetFactor(double factor) {
        Efl.AccelerateInterpolator.NativeMethods.efl_accelerate_interpolator_factor_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),factor);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Interpolate the given value.</summary>
    /// <param name="progress">Input value mapped from 0.0 to 1.0.</param>
    /// <returns>Output value calculated by interpolating the input value.</returns>
    public virtual double Interpolate(double progress) {
        var _ret_var = Efl.InterpolatorConcrete.NativeMethods.efl_interpolator_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),progress);
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
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.AccelerateInterpolator.efl_accelerate_interpolator_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_accelerate_interpolator_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_accelerate_interpolator_factor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_get_api_delegate> efl_accelerate_interpolator_factor_get_ptr = new Efl.Eo.FunctionWrapper<efl_accelerate_interpolator_factor_get_api_delegate>(Module, "efl_accelerate_interpolator_factor_get");

        private static double factor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_accelerate_interpolator_factor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((AccelerateInterpolator)ws.Target).GetFactor();
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((AccelerateInterpolator)ws.Target).SetFactor(factor);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflAccelerateInterpolator_ExtensionMethods {
    public static Efl.BindableProperty<double> Factor<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.AccelerateInterpolator, T>magic = null) where T : Efl.AccelerateInterpolator {
        return new Efl.BindableProperty<double>("factor", fac);
    }

}
#pragma warning restore CS1591
#endif
