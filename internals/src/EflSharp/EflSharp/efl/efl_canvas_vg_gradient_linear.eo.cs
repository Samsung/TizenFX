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

/// <summary>Efl vector graphics gradient linear class</summary>
[Efl.Canvas.Vg.GradientLinear.NativeMethods]
public class GradientLinear : Efl.Canvas.Vg.Gradient, Efl.Gfx.IGradientLinear
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GradientLinear))
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
        efl_canvas_vg_gradient_linear_class_get();
    /// <summary>Initializes a new instance of the <see cref="GradientLinear"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GradientLinear(Efl.Object parent= null
            ) : base(efl_canvas_vg_gradient_linear_class_get(), typeof(GradientLinear), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="GradientLinear"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected GradientLinear(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GradientLinear"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GradientLinear(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Gets the start point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of start point</param>
    /// <param name="y">Y co-ordinate of start point</param>
    virtual public void GetStart(out double x, out double y) {
                                                         Efl.Gfx.IGradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_start_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the start point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of start point</param>
    /// <param name="y">Y co-ordinate of start point</param>
    virtual public void SetStart(double x, double y) {
                                                         Efl.Gfx.IGradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_start_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets the end point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of end point</param>
    /// <param name="y">Y co-ordinate of end point</param>
    virtual public void GetEnd(out double x, out double y) {
                                                         Efl.Gfx.IGradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_end_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the end point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of end point</param>
    /// <param name="y">Y co-ordinate of end point</param>
    virtual public void SetEnd(double x, double y) {
                                                         Efl.Gfx.IGradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_end_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.GradientLinear.efl_canvas_vg_gradient_linear_class_get();
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

            if (efl_gfx_gradient_linear_start_get_static_delegate == null)
            {
                efl_gfx_gradient_linear_start_get_static_delegate = new efl_gfx_gradient_linear_start_get_delegate(start_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_linear_start_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_start_get_static_delegate) });
            }

            if (efl_gfx_gradient_linear_start_set_static_delegate == null)
            {
                efl_gfx_gradient_linear_start_set_static_delegate = new efl_gfx_gradient_linear_start_set_delegate(start_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_linear_start_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_start_set_static_delegate) });
            }

            if (efl_gfx_gradient_linear_end_get_static_delegate == null)
            {
                efl_gfx_gradient_linear_end_get_static_delegate = new efl_gfx_gradient_linear_end_get_delegate(end_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_linear_end_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_end_get_static_delegate) });
            }

            if (efl_gfx_gradient_linear_end_set_static_delegate == null)
            {
                efl_gfx_gradient_linear_end_set_static_delegate = new efl_gfx_gradient_linear_end_set_delegate(end_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_gradient_linear_end_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_linear_end_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Vg.GradientLinear.efl_canvas_vg_gradient_linear_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_gradient_linear_start_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_gradient_linear_start_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_start_get_api_delegate> efl_gfx_gradient_linear_start_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_start_get_api_delegate>(Module, "efl_gfx_gradient_linear_start_get");

        private static void start_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_linear_start_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((GradientLinear)ws.Target).GetStart(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_linear_start_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_gradient_linear_start_get_delegate efl_gfx_gradient_linear_start_get_static_delegate;

        
        private delegate void efl_gfx_gradient_linear_start_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_gradient_linear_start_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_start_set_api_delegate> efl_gfx_gradient_linear_start_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_start_set_api_delegate>(Module, "efl_gfx_gradient_linear_start_set");

        private static void start_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_linear_start_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((GradientLinear)ws.Target).SetStart(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_linear_start_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_gradient_linear_start_set_delegate efl_gfx_gradient_linear_start_set_static_delegate;

        
        private delegate void efl_gfx_gradient_linear_end_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_gradient_linear_end_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_end_get_api_delegate> efl_gfx_gradient_linear_end_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_end_get_api_delegate>(Module, "efl_gfx_gradient_linear_end_get");

        private static void end_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_linear_end_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((GradientLinear)ws.Target).GetEnd(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_linear_end_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_gradient_linear_end_get_delegate efl_gfx_gradient_linear_end_get_static_delegate;

        
        private delegate void efl_gfx_gradient_linear_end_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_gradient_linear_end_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_end_set_api_delegate> efl_gfx_gradient_linear_end_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_linear_end_set_api_delegate>(Module, "efl_gfx_gradient_linear_end_set");

        private static void end_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_gradient_linear_end_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((GradientLinear)ws.Target).SetEnd(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_gradient_linear_end_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_gradient_linear_end_set_delegate efl_gfx_gradient_linear_end_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

