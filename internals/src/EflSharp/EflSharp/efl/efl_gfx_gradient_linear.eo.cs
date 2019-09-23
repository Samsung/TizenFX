#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Efl graphics gradient linear interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.GradientLinearConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IGradientLinear : 
    Efl.Gfx.IGradient ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The start point of this linear gradient.</summary>
/// <param name="x">X co-ordinate of start point</param>
/// <param name="y">Y co-ordinate of start point</param>
void GetStart(out double x, out double y);
    /// <summary>The start point of this linear gradient.</summary>
/// <param name="x">X co-ordinate of start point</param>
/// <param name="y">Y co-ordinate of start point</param>
void SetStart(double x, double y);
    /// <summary>The end point of this linear gradient.</summary>
/// <param name="x">X co-ordinate of end point</param>
/// <param name="y">Y co-ordinate of end point</param>
void GetEnd(out double x, out double y);
    /// <summary>The end point of this linear gradient.</summary>
/// <param name="x">X co-ordinate of end point</param>
/// <param name="y">Y co-ordinate of end point</param>
void SetEnd(double x, double y);
                    /// <summary>The start point of this linear gradient.</summary>
    /// <value>X co-ordinate of start point</value>
    (double, double) Start {
        get;
        set;
    }
    /// <summary>The end point of this linear gradient.</summary>
    /// <value>X co-ordinate of end point</value>
    (double, double) End {
        get;
        set;
    }
}
/// <summary>Efl graphics gradient linear interface</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class GradientLinearConcrete :
    Efl.Eo.EoWrapper
    , IGradientLinear
    , Efl.Gfx.IGradient
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GradientLinearConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private GradientLinearConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_gradient_linear_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IGradientLinear"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private GradientLinearConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The start point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of start point</param>
    /// <param name="y">Y co-ordinate of start point</param>
    public void GetStart(out double x, out double y) {
                                                         Efl.Gfx.GradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_start_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The start point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of start point</param>
    /// <param name="y">Y co-ordinate of start point</param>
    public void SetStart(double x, double y) {
                                                         Efl.Gfx.GradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_start_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The end point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of end point</param>
    /// <param name="y">Y co-ordinate of end point</param>
    public void GetEnd(out double x, out double y) {
                                                         Efl.Gfx.GradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_end_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The end point of this linear gradient.</summary>
    /// <param name="x">X co-ordinate of end point</param>
    /// <param name="y">Y co-ordinate of end point</param>
    public void SetEnd(double x, double y) {
                                                         Efl.Gfx.GradientLinearConcrete.NativeMethods.efl_gfx_gradient_linear_end_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public void GetStop(out Efl.Gfx.GradientStop colors, out uint length) {
                         var _out_colors = new System.IntPtr();
                                Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_stop_get_ptr.Value.Delegate(this.NativeHandle,out _out_colors, out length);
        Eina.Error.RaiseIfUnhandledException();
        colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                                 }
    /// <summary>The list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public void SetStop(ref Efl.Gfx.GradientStop colors, uint length) {
         Efl.Gfx.GradientStop.NativeStruct _in_colors = colors;
                                                Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_stop_set_ptr.Value.Delegate(this.NativeHandle,ref _in_colors, length);
        Eina.Error.RaiseIfUnhandledException();
                        colors = _in_colors;
                 }
    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <returns>Spread type to be used.</returns>
    public Efl.Gfx.GradientSpread GetSpread() {
         var _ret_var = Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_spread_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <param name="s">Spread type to be used.</param>
    public void SetSpread(Efl.Gfx.GradientSpread s) {
                                 Efl.Gfx.GradientConcrete.NativeMethods.efl_gfx_gradient_spread_set_ptr.Value.Delegate(this.NativeHandle,s);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The start point of this linear gradient.</summary>
    /// <value>X co-ordinate of start point</value>
    public (double, double) Start {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetStart(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetStart( value.Item1,  value.Item2); }
    }
    /// <summary>The end point of this linear gradient.</summary>
    /// <value>X co-ordinate of end point</value>
    public (double, double) End {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetEnd(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetEnd( value.Item1,  value.Item2); }
    }
    /// <summary>The list of color stops for the gradient</summary>
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
    /// <summary>The spread method that should be used for this gradient. The default is <see cref="Efl.Gfx.GradientSpread.Pad"/>.</summary>
    /// <value>Spread type to be used.</value>
    public Efl.Gfx.GradientSpread Spread {
        get { return GetSpread(); }
        set { SetSpread(value); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.GradientLinearConcrete.efl_gfx_gradient_linear_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.GradientLinearConcrete.efl_gfx_gradient_linear_interface_get();
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
                    ((IGradientLinear)ws.Target).GetStart(out x, out y);
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
                    ((IGradientLinear)ws.Target).SetStart(x, y);
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
                    ((IGradientLinear)ws.Target).GetEnd(out x, out y);
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
                    ((IGradientLinear)ws.Target).SetEnd(x, y);
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

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxGradientLinearConcrete_ExtensionMethods {
    
    
    
    public static Efl.BindableProperty<Efl.Gfx.GradientSpread> Spread<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IGradientLinear, T>magic = null) where T : Efl.Gfx.IGradientLinear {
        return new Efl.BindableProperty<Efl.Gfx.GradientSpread>("spread", fac);
    }

}
#pragma warning restore CS1591
#endif
