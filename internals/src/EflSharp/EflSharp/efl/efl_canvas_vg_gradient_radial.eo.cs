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

/// <summary>Efl vector graphics gradient radial class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.GradientRadial.NativeMethods]
[Efl.Eo.BindingEntity]
public class GradientRadial : Efl.Canvas.Vg.Gradient, Efl.Gfx.IGradientRadial
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GradientRadial))
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
        efl_canvas_vg_gradient_radial_class_get();
    /// <summary>Initializes a new instance of the <see cref="GradientRadial"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GradientRadial(Efl.Object parent= null
            ) : base(efl_canvas_vg_gradient_radial_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected GradientRadial(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GradientRadial"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected GradientRadial(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GradientRadial"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GradientRadial(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Gets the center of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of center point</param>
    /// <param name="y">Y co-ordinate of center point</param>
    virtual public void GetCenter(out double x, out double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_center_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the center of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of center point</param>
    /// <param name="y">Y co-ordinate of center point</param>
    virtual public void SetCenter(double x, double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_center_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets the center radius of this radial gradient.</summary>
    /// <returns>Center radius</returns>
    virtual public double GetRadius() {
         var _ret_var = Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the center radius of this radial gradient.</summary>
    /// <param name="r">Center radius</param>
    virtual public void SetRadius(double r) {
                                 Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the focal point of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of focal point</param>
    /// <param name="y">Y co-ordinate of focal point</param>
    virtual public void GetFocal(out double x, out double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the focal point of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of focal point</param>
    /// <param name="y">Y co-ordinate of focal point</param>
    virtual public void SetFocal(double x, double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets the center of this radial gradient.</summary>
    /// <value>X co-ordinate of center point</value>
    public (double, double) Center {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetCenter(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetCenter( value.Item1,  value.Item2); }
    }
    /// <summary>Gets the center radius of this radial gradient.</summary>
    /// <value>Center radius</value>
    public double Radius {
        get { return GetRadius(); }
        set { SetRadius(value); }
    }
    /// <summary>Gets the focal point of this radial gradient.</summary>
    /// <value>X co-ordinate of focal point</value>
    public (double, double) Focal {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetFocal(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetFocal( value.Item1,  value.Item2); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.GradientRadial.efl_canvas_vg_gradient_radial_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Vg.Gradient.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_gradient_radial_center_get_static_delegate == null)
            {
                efl_gfx_gradient_radial_center_get_static_delegate = new efl_gfx_gradient_radial_center_get_delegate(center_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCenter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_center_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_get_static_delegate) });
            }

            if (efl_gfx_gradient_radial_center_set_static_delegate == null)
            {
                efl_gfx_gradient_radial_center_set_static_delegate = new efl_gfx_gradient_radial_center_set_delegate(center_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCenter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_center_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_set_static_delegate) });
            }

            if (efl_gfx_gradient_radial_radius_get_static_delegate == null)
            {
                efl_gfx_gradient_radial_radius_get_static_delegate = new efl_gfx_gradient_radial_radius_get_delegate(radius_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_get_static_delegate) });
            }

            if (efl_gfx_gradient_radial_radius_set_static_delegate == null)
            {
                efl_gfx_gradient_radial_radius_set_static_delegate = new efl_gfx_gradient_radial_radius_set_delegate(radius_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_set_static_delegate) });
            }

            if (efl_gfx_gradient_radial_focal_get_static_delegate == null)
            {
                efl_gfx_gradient_radial_focal_get_static_delegate = new efl_gfx_gradient_radial_focal_get_delegate(focal_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_focal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_get_static_delegate) });
            }

            if (efl_gfx_gradient_radial_focal_set_static_delegate == null)
            {
                efl_gfx_gradient_radial_focal_set_static_delegate = new efl_gfx_gradient_radial_focal_set_delegate(focal_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_radial_focal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Vg.GradientRadial.efl_canvas_vg_gradient_radial_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_gradient_radial_center_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_gradient_radial_center_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate> efl_gfx_gradient_radial_center_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate>(Module, "efl_gfx_gradient_radial_center_get");

        private static void center_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_center_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((GradientRadial)ws.Target).GetCenter(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_radial_center_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_gradient_radial_center_get_delegate efl_gfx_gradient_radial_center_get_static_delegate;

        
        private delegate void efl_gfx_gradient_radial_center_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_gradient_radial_center_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate> efl_gfx_gradient_radial_center_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate>(Module, "efl_gfx_gradient_radial_center_set");

        private static void center_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_center_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((GradientRadial)ws.Target).SetCenter(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_radial_center_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_gradient_radial_center_set_delegate efl_gfx_gradient_radial_center_set_static_delegate;

        
        private delegate double efl_gfx_gradient_radial_radius_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_gradient_radial_radius_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate> efl_gfx_gradient_radial_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate>(Module, "efl_gfx_gradient_radial_radius_get");

        private static double radius_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_radius_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((GradientRadial)ws.Target).GetRadius();
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
                return efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_gradient_radial_radius_get_delegate efl_gfx_gradient_radial_radius_get_static_delegate;

        
        private delegate void efl_gfx_gradient_radial_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,  double r);

        
        public delegate void efl_gfx_gradient_radial_radius_set_api_delegate(System.IntPtr obj,  double r);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate> efl_gfx_gradient_radial_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate>(Module, "efl_gfx_gradient_radial_radius_set");

        private static void radius_set(System.IntPtr obj, System.IntPtr pd, double r)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_radius_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((GradientRadial)ws.Target).SetRadius(r);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r);
            }
        }

        private static efl_gfx_gradient_radial_radius_set_delegate efl_gfx_gradient_radial_radius_set_static_delegate;

        
        private delegate void efl_gfx_gradient_radial_focal_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_gradient_radial_focal_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate> efl_gfx_gradient_radial_focal_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate>(Module, "efl_gfx_gradient_radial_focal_get");

        private static void focal_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_focal_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((GradientRadial)ws.Target).GetFocal(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_gradient_radial_focal_get_delegate efl_gfx_gradient_radial_focal_get_static_delegate;

        
        private delegate void efl_gfx_gradient_radial_focal_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_gradient_radial_focal_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate> efl_gfx_gradient_radial_focal_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate>(Module, "efl_gfx_gradient_radial_focal_set");

        private static void focal_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_radial_focal_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((GradientRadial)ws.Target).SetFocal(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_gradient_radial_focal_set_delegate efl_gfx_gradient_radial_focal_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgGradientRadial_ExtensionMethods {
    
    public static Efl.BindableProperty<double> Radius<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.GradientRadial, T>magic = null) where T : Efl.Canvas.Vg.GradientRadial {
        return new Efl.BindableProperty<double>("radius", fac);
    }

    
}
#pragma warning restore CS1591
#endif
