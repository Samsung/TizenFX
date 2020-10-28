#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

namespace Vg {

/// <summary>Efl vectopr graphics gradient abstract class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Gradient.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Gradient : Efl.Canvas.Vg.Node, Efl.Gfx.IGradient
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Gradient))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_vg_gradient_class_get();
    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Gradient(Efl.Object parent= null
            ) : base(efl_canvas_vg_gradient_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Gradient(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Gradient(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class GradientRealized : Gradient
    {
        private GradientRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Gradient"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Gradient(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Get the list of color stops.</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    virtual public void GetStop(out Efl.Gfx.GradientStop colors, out uint length) {
                         var _out_colors = new System.IntPtr();
                                Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_stop_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_colors, out length);
        Eina.Error.RaiseIfUnhandledException();
        colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                                 }
    /// <summary>Set the list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    virtual public void SetStop(ref Efl.Gfx.GradientStop colors, uint length) {
         Efl.Gfx.GradientStop.NativeStruct _in_colors = colors;
                                                Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_stop_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_colors, length);
        Eina.Error.RaiseIfUnhandledException();
                        colors = _in_colors;
                 }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
    /// <returns>Spread type to be used</returns>
    virtual public Efl.Gfx.GradientSpread GetSpread() {
         var _ret_var = Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_spread_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the spread method that should be used for this gradient.</summary>
    /// <param name="s">Spread type to be used</param>
    virtual public void SetSpread(Efl.Gfx.GradientSpread s) {
                                 Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_spread_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),s);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the list of color stops.</summary>
    /// <value>Color stops list</value>
    public (Efl.Gfx.GradientStop, uint) Stop {
        get {
            Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
            uint _out_length = default(uint);
            GetStop(out _out_colors,out _out_length);
            return (_out_colors,_out_length);
        }
        set { SetStop(ref  value.Item1,  value.Item2); }
    }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
    /// <value>Spread type to be used</value>
    public Efl.Gfx.GradientSpread Spread {
        get { return GetSpread(); }
        set { SetSpread(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Vg.Node.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_gradient_stop_get_static_delegate == null)
            {
                efl_gfx_gradient_stop_get_static_delegate = new efl_gfx_gradient_stop_get_delegate(stop_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_stop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_get_static_delegate) });
            }

            if (efl_gfx_gradient_stop_set_static_delegate == null)
            {
                efl_gfx_gradient_stop_set_static_delegate = new efl_gfx_gradient_stop_set_delegate(stop_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_stop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_set_static_delegate) });
            }

            if (efl_gfx_gradient_spread_get_static_delegate == null)
            {
                efl_gfx_gradient_spread_get_static_delegate = new efl_gfx_gradient_spread_get_delegate(spread_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSpread") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_spread_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_get_static_delegate) });
            }

            if (efl_gfx_gradient_spread_set_static_delegate == null)
            {
                efl_gfx_gradient_spread_set_static_delegate = new efl_gfx_gradient_spread_set_delegate(spread_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSpread") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_spread_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Vg.Gradient.efl_canvas_vg_gradient_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_gradient_stop_get_delegate(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr colors,  out uint length);

        
        public delegate void efl_gfx_gradient_stop_get_api_delegate(System.IntPtr obj,  out System.IntPtr colors,  out uint length);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate> efl_gfx_gradient_stop_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate>(Module, "efl_gfx_gradient_stop_get");

        private static void stop_get(System.IntPtr obj, System.IntPtr pd, out System.IntPtr colors, out uint length)
        {
            Eina.Log.Debug("function efl_gfx_gradient_stop_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
        length = default(uint);                            
                try
                {
                    ((Gradient)ws.Target).GetStop(out _out_colors, out length);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        colors = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_colors);
                                
            }
            else
            {
                efl_gfx_gradient_stop_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out colors, out length);
            }
        }

        private static efl_gfx_gradient_stop_get_delegate efl_gfx_gradient_stop_get_static_delegate;

        
        private delegate void efl_gfx_gradient_stop_set_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.GradientStop.NativeStruct colors,  uint length);

        
        public delegate void efl_gfx_gradient_stop_set_api_delegate(System.IntPtr obj,  ref Efl.Gfx.GradientStop.NativeStruct colors,  uint length);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate> efl_gfx_gradient_stop_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate>(Module, "efl_gfx_gradient_stop_set");

        private static void stop_set(System.IntPtr obj, System.IntPtr pd, ref Efl.Gfx.GradientStop.NativeStruct colors, uint length)
        {
            Eina.Log.Debug("function efl_gfx_gradient_stop_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Gfx.GradientStop _in_colors = colors;
                                                    
                try
                {
                    ((Gradient)ws.Target).SetStop(ref _in_colors, length);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        colors = _in_colors;
                
            }
            else
            {
                efl_gfx_gradient_stop_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref colors, length);
            }
        }

        private static efl_gfx_gradient_stop_set_delegate efl_gfx_gradient_stop_set_static_delegate;

        
        private delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate> efl_gfx_gradient_spread_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate>(Module, "efl_gfx_gradient_spread_get");

        private static Efl.Gfx.GradientSpread spread_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_gradient_spread_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.GradientSpread _ret_var = default(Efl.Gfx.GradientSpread);
                try
                {
                    _ret_var = ((Gradient)ws.Target).GetSpread();
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
                return efl_gfx_gradient_spread_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_gradient_spread_get_delegate efl_gfx_gradient_spread_get_static_delegate;

        
        private delegate void efl_gfx_gradient_spread_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.GradientSpread s);

        
        public delegate void efl_gfx_gradient_spread_set_api_delegate(System.IntPtr obj,  Efl.Gfx.GradientSpread s);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate> efl_gfx_gradient_spread_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate>(Module, "efl_gfx_gradient_spread_set");

        private static void spread_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.GradientSpread s)
        {
            Eina.Log.Debug("function efl_gfx_gradient_spread_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Gradient)ws.Target).SetSpread(s);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_gradient_spread_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), s);
            }
        }

        private static efl_gfx_gradient_spread_set_delegate efl_gfx_gradient_spread_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgGradient_ExtensionMethods {
    
    public static Efl.BindableProperty<Efl.Gfx.GradientSpread> Spread<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Gradient, T>magic = null) where T : Efl.Canvas.Vg.Gradient {
        return new Efl.BindableProperty<Efl.Gfx.GradientSpread>("spread", fac);
    }

}
#pragma warning restore CS1591
#endif
