#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Efl graphics gradient radial interface</summary>
[Efl.Gfx.IGradientRadialConcrete.NativeMethods]
public interface IGradientRadial : 
    Efl.Gfx.IGradient ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets the center of this radial gradient.</summary>
/// <param name="x">X co-ordinate of center point</param>
/// <param name="y">Y co-ordinate of center point</param>
void GetCenter(out double x, out double y);
    /// <summary>Sets the center of this radial gradient.</summary>
/// <param name="x">X co-ordinate of center point</param>
/// <param name="y">Y co-ordinate of center point</param>
void SetCenter(double x, double y);
    /// <summary>Gets the center radius of this radial gradient.</summary>
/// <returns>Center radius</returns>
double GetRadius();
    /// <summary>Sets the center radius of this radial gradient.</summary>
/// <param name="r">Center radius</param>
void SetRadius(double r);
    /// <summary>Gets the focal point of this radial gradient.</summary>
/// <param name="x">X co-ordinate of focal point</param>
/// <param name="y">Y co-ordinate of focal point</param>
void GetFocal(out double x, out double y);
    /// <summary>Sets the focal point of this radial gradient.</summary>
/// <param name="x">X co-ordinate of focal point</param>
/// <param name="y">Y co-ordinate of focal point</param>
void SetFocal(double x, double y);
                            /// <summary>Gets the center radius of this radial gradient.</summary>
    /// <value>Center radius</value>
    double Radius {
        get ;
        set ;
    }
}
/// <summary>Efl graphics gradient radial interface</summary>
sealed public class IGradientRadialConcrete :
    Efl.Eo.EoWrapper
    , IGradientRadial
    , Efl.Gfx.IGradient
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IGradientRadialConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_gradient_radial_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IGradientRadial"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IGradientRadialConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Gets the center of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of center point</param>
    /// <param name="y">Y co-ordinate of center point</param>
    public void GetCenter(out double x, out double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_center_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the center of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of center point</param>
    /// <param name="y">Y co-ordinate of center point</param>
    public void SetCenter(double x, double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_center_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets the center radius of this radial gradient.</summary>
    /// <returns>Center radius</returns>
    public double GetRadius() {
         var _ret_var = Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the center radius of this radial gradient.</summary>
    /// <param name="r">Center radius</param>
    public void SetRadius(double r) {
                                 Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate(this.NativeHandle,r);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the focal point of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of focal point</param>
    /// <param name="y">Y co-ordinate of focal point</param>
    public void GetFocal(out double x, out double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate(this.NativeHandle,out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the focal point of this radial gradient.</summary>
    /// <param name="x">X co-ordinate of focal point</param>
    /// <param name="y">Y co-ordinate of focal point</param>
    public void SetFocal(double x, double y) {
                                                         Efl.Gfx.IGradientRadialConcrete.NativeMethods.efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the list of color stops.</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public void GetStop(out Efl.Gfx.GradientStop colors, out uint length) {
                         var _out_colors = new System.IntPtr();
                                Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_stop_get_ptr.Value.Delegate(this.NativeHandle,out _out_colors, out length);
        Eina.Error.RaiseIfUnhandledException();
        colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                                 }
    /// <summary>Set the list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    public void SetStop(ref Efl.Gfx.GradientStop colors, uint length) {
         Efl.Gfx.GradientStop.NativeStruct _in_colors = colors;
                                                Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_stop_set_ptr.Value.Delegate(this.NativeHandle,ref _in_colors, length);
        Eina.Error.RaiseIfUnhandledException();
                        colors = _in_colors;
                 }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
    /// <returns>Spread type to be used</returns>
    public Efl.Gfx.GradientSpread GetSpread() {
         var _ret_var = Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_spread_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the spread method that should be used for this gradient.</summary>
    /// <param name="s">Spread type to be used</param>
    public void SetSpread(Efl.Gfx.GradientSpread s) {
                                 Efl.Gfx.IGradientConcrete.NativeMethods.efl_gfx_gradient_spread_set_ptr.Value.Delegate(this.NativeHandle,s);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the center radius of this radial gradient.</summary>
    /// <value>Center radius</value>
    public double Radius {
        get { return GetRadius(); }
        set { SetRadius(value); }
    }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
    /// <value>Spread type to be used</value>
    public Efl.Gfx.GradientSpread Spread {
        get { return GetSpread(); }
        set { SetSpread(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IGradientRadialConcrete.efl_gfx_gradient_radial_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.IGradientRadialConcrete.efl_gfx_gradient_radial_interface_get();
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
                    ((IGradientRadial)ws.Target).GetCenter(out x, out y);
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
                    ((IGradientRadial)ws.Target).SetCenter(x, y);
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
                    _ret_var = ((IGradientRadial)ws.Target).GetRadius();
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
                    ((IGradientRadial)ws.Target).SetRadius(r);
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
                    ((IGradientRadial)ws.Target).GetFocal(out x, out y);
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
                    ((IGradientRadial)ws.Target).SetFocal(x, y);
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
                    ((IGradientRadial)ws.Target).GetStop(out _out_colors, out length);
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
                    ((IGradientRadial)ws.Target).SetStop(ref _in_colors, length);
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
                    _ret_var = ((IGradientRadial)ws.Target).GetSpread();
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
                    ((IGradientRadial)ws.Target).SetSpread(s);
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

