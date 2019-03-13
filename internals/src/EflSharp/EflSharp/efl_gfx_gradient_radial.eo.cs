#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics gradient radial interface</summary>
[GradientRadialNativeInherit]
public interface GradientRadial : 
   Efl.Gfx.Gradient ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the center of this radial gradient.</summary>
/// <param name="x">X co-ordinate of center point</param>
/// <param name="y">Y co-ordinate of center point</param>
/// <returns></returns>
 void GetCenter( out double x,  out double y);
   /// <summary>Sets the center of this radial gradient.</summary>
/// <param name="x">X co-ordinate of center point</param>
/// <param name="y">Y co-ordinate of center point</param>
/// <returns></returns>
 void SetCenter( double x,  double y);
   /// <summary>Gets the center radius of this radial gradient.</summary>
/// <returns>Center radius</returns>
double GetRadius();
   /// <summary>Sets the center radius of this radial gradient.</summary>
/// <param name="r">Center radius</param>
/// <returns></returns>
 void SetRadius( double r);
   /// <summary>Gets the focal point of this radial gradient.</summary>
/// <param name="x">X co-ordinate of focal point</param>
/// <param name="y">Y co-ordinate of focal point</param>
/// <returns></returns>
 void GetFocal( out double x,  out double y);
   /// <summary>Sets the focal point of this radial gradient.</summary>
/// <param name="x">X co-ordinate of focal point</param>
/// <param name="y">Y co-ordinate of focal point</param>
/// <returns></returns>
 void SetFocal( double x,  double y);
                     /// <summary>Gets the center radius of this radial gradient.</summary>
/// <value>Center radius</value>
   double Radius {
      get ;
      set ;
   }
}
/// <summary>Efl graphics gradient radial interface</summary>
sealed public class GradientRadialConcrete : 

GradientRadial
   , Efl.Gfx.Gradient
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (GradientRadialConcrete))
            return Efl.Gfx.GradientRadialNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_gradient_radial_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public GradientRadialConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~GradientRadialConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static GradientRadialConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new GradientRadialConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }
   /// <summary>Gets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   public  void GetCenter( out double x,  out double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_center_get_ptr.Value.Delegate(this.NativeHandle, out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   public  void SetCenter( double x,  double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_center_set_ptr.Value.Delegate(this.NativeHandle, x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Gets the center radius of this radial gradient.</summary>
   /// <returns>Center radius</returns>
   public double GetRadius() {
       var _ret_var = Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Sets the center radius of this radial gradient.</summary>
   /// <param name="r">Center radius</param>
   /// <returns></returns>
   public  void SetRadius( double r) {
                         Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate(this.NativeHandle, r);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   public  void GetFocal( out double x,  out double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate(this.NativeHandle, out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Sets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   public  void SetFocal( double x,  double y) {
                                           Efl.Gfx.GradientRadialNativeInherit.efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate(this.NativeHandle, x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get the list of color stops.</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   public  void GetStop( out Efl.Gfx.GradientStop colors,  out  uint length) {
                   var _out_colors = new  System.IntPtr();
                        Efl.Gfx.GradientNativeInherit.efl_gfx_gradient_stop_get_ptr.Value.Delegate(this.NativeHandle, out _out_colors,  out length);
      Eina.Error.RaiseIfUnhandledException();
      colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                         }
   /// <summary>Set the list of color stops for the gradient</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   public  void SetStop( ref Efl.Gfx.GradientStop colors,   uint length) {
       var _in_colors = Efl.Gfx.GradientStop_StructConversion.ToInternal(colors);
                                    Efl.Gfx.GradientNativeInherit.efl_gfx_gradient_stop_set_ptr.Value.Delegate(this.NativeHandle, ref _in_colors,  length);
      Eina.Error.RaiseIfUnhandledException();
                  colors = Efl.Gfx.GradientStop_StructConversion.ToManaged(_in_colors);
             }
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
   /// <returns>Spread type to be used</returns>
   public Efl.Gfx.GradientSpread GetSpread() {
       var _ret_var = Efl.Gfx.GradientNativeInherit.efl_gfx_gradient_spread_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Specifies the spread method that should be used for this gradient.</summary>
   /// <param name="s">Spread type to be used</param>
   /// <returns></returns>
   public  void SetSpread( Efl.Gfx.GradientSpread s) {
                         Efl.Gfx.GradientNativeInherit.efl_gfx_gradient_spread_set_ptr.Value.Delegate(this.NativeHandle, s);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the center radius of this radial gradient.</summary>
/// <value>Center radius</value>
   public double Radius {
      get { return GetRadius(); }
      set { SetRadius( value); }
   }
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
/// <value>Spread type to be used</value>
   public Efl.Gfx.GradientSpread Spread {
      get { return GetSpread(); }
      set { SetSpread( value); }
   }
}
public class GradientRadialNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_gfx_gradient_radial_center_get_static_delegate == null)
      efl_gfx_gradient_radial_center_get_static_delegate = new efl_gfx_gradient_radial_center_get_delegate(center_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_center_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_get_static_delegate)});
      if (efl_gfx_gradient_radial_center_set_static_delegate == null)
      efl_gfx_gradient_radial_center_set_static_delegate = new efl_gfx_gradient_radial_center_set_delegate(center_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_center_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_set_static_delegate)});
      if (efl_gfx_gradient_radial_radius_get_static_delegate == null)
      efl_gfx_gradient_radial_radius_get_static_delegate = new efl_gfx_gradient_radial_radius_get_delegate(radius_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_get_static_delegate)});
      if (efl_gfx_gradient_radial_radius_set_static_delegate == null)
      efl_gfx_gradient_radial_radius_set_static_delegate = new efl_gfx_gradient_radial_radius_set_delegate(radius_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_set_static_delegate)});
      if (efl_gfx_gradient_radial_focal_get_static_delegate == null)
      efl_gfx_gradient_radial_focal_get_static_delegate = new efl_gfx_gradient_radial_focal_get_delegate(focal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_focal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_get_static_delegate)});
      if (efl_gfx_gradient_radial_focal_set_static_delegate == null)
      efl_gfx_gradient_radial_focal_set_static_delegate = new efl_gfx_gradient_radial_focal_set_delegate(focal_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_radial_focal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_set_static_delegate)});
      if (efl_gfx_gradient_stop_get_static_delegate == null)
      efl_gfx_gradient_stop_get_static_delegate = new efl_gfx_gradient_stop_get_delegate(stop_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_stop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_get_static_delegate)});
      if (efl_gfx_gradient_stop_set_static_delegate == null)
      efl_gfx_gradient_stop_set_static_delegate = new efl_gfx_gradient_stop_set_delegate(stop_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_stop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_set_static_delegate)});
      if (efl_gfx_gradient_spread_get_static_delegate == null)
      efl_gfx_gradient_spread_get_static_delegate = new efl_gfx_gradient_spread_get_delegate(spread_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_spread_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_get_static_delegate)});
      if (efl_gfx_gradient_spread_set_static_delegate == null)
      efl_gfx_gradient_spread_set_static_delegate = new efl_gfx_gradient_spread_set_delegate(spread_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_spread_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get();
   }


    private delegate  void efl_gfx_gradient_radial_center_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_gradient_radial_center_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate> efl_gfx_gradient_radial_center_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_get_api_delegate>(_Module, "efl_gfx_gradient_radial_center_get");
    private static  void center_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_center_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientRadial)wrapper).GetCenter( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_center_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_gradient_radial_center_get_delegate efl_gfx_gradient_radial_center_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_center_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_gradient_radial_center_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate> efl_gfx_gradient_radial_center_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_center_set_api_delegate>(_Module, "efl_gfx_gradient_radial_center_set");
    private static  void center_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_center_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientRadial)wrapper).SetCenter( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_center_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_gradient_radial_center_set_delegate efl_gfx_gradient_radial_center_set_static_delegate;


    private delegate double efl_gfx_gradient_radial_radius_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_gfx_gradient_radial_radius_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate> efl_gfx_gradient_radial_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_get_api_delegate>(_Module, "efl_gfx_gradient_radial_radius_get");
    private static double radius_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_radius_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((GradientRadial)wrapper).GetRadius();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_gradient_radial_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_gradient_radial_radius_get_delegate efl_gfx_gradient_radial_radius_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,   double r);


    public delegate  void efl_gfx_gradient_radial_radius_set_api_delegate(System.IntPtr obj,   double r);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate> efl_gfx_gradient_radial_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_radius_set_api_delegate>(_Module, "efl_gfx_gradient_radial_radius_set");
    private static  void radius_set(System.IntPtr obj, System.IntPtr pd,  double r)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_radius_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((GradientRadial)wrapper).SetRadius( r);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_gradient_radial_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r);
      }
   }
   private static efl_gfx_gradient_radial_radius_set_delegate efl_gfx_gradient_radial_radius_set_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_gfx_gradient_radial_focal_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate> efl_gfx_gradient_radial_focal_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_get_api_delegate>(_Module, "efl_gfx_gradient_radial_focal_get");
    private static  void focal_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_focal_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((GradientRadial)wrapper).GetFocal( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_focal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_gfx_gradient_radial_focal_get_delegate efl_gfx_gradient_radial_focal_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_gfx_gradient_radial_focal_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate> efl_gfx_gradient_radial_focal_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_radial_focal_set_api_delegate>(_Module, "efl_gfx_gradient_radial_focal_set");
    private static  void focal_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_gradient_radial_focal_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((GradientRadial)wrapper).SetFocal( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_gradient_radial_focal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_gfx_gradient_radial_focal_set_delegate efl_gfx_gradient_radial_focal_set_static_delegate;


    private delegate  void efl_gfx_gradient_stop_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr colors,   out  uint length);


    public delegate  void efl_gfx_gradient_stop_get_api_delegate(System.IntPtr obj,   out  System.IntPtr colors,   out  uint length);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate> efl_gfx_gradient_stop_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate>(_Module, "efl_gfx_gradient_stop_get");
    private static  void stop_get(System.IntPtr obj, System.IntPtr pd,  out  System.IntPtr colors,  out  uint length)
   {
      Eina.Log.Debug("function efl_gfx_gradient_stop_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
      length = default( uint);                     
         try {
            ((GradientRadial)wrapper).GetStop( out _out_colors,  out length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      colors = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_colors);
                              } else {
         efl_gfx_gradient_stop_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out colors,  out length);
      }
   }
   private static efl_gfx_gradient_stop_get_delegate efl_gfx_gradient_stop_get_static_delegate;


    private delegate  void efl_gfx_gradient_stop_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);


    public delegate  void efl_gfx_gradient_stop_set_api_delegate(System.IntPtr obj,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate> efl_gfx_gradient_stop_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate>(_Module, "efl_gfx_gradient_stop_set");
    private static  void stop_set(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.GradientStop_StructInternal colors,   uint length)
   {
      Eina.Log.Debug("function efl_gfx_gradient_stop_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_colors = Efl.Gfx.GradientStop_StructConversion.ToManaged(colors);
                                       
         try {
            ((GradientRadial)wrapper).SetStop( ref _in_colors,  length);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  colors = Efl.Gfx.GradientStop_StructConversion.ToInternal(_in_colors);
                  } else {
         efl_gfx_gradient_stop_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref colors,  length);
      }
   }
   private static efl_gfx_gradient_stop_set_delegate efl_gfx_gradient_stop_set_static_delegate;


    private delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate> efl_gfx_gradient_spread_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate>(_Module, "efl_gfx_gradient_spread_get");
    private static Efl.Gfx.GradientSpread spread_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_gradient_spread_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.GradientSpread _ret_var = default(Efl.Gfx.GradientSpread);
         try {
            _ret_var = ((GradientRadial)wrapper).GetSpread();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_gradient_spread_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_gradient_spread_get_delegate efl_gfx_gradient_spread_get_static_delegate;


    private delegate  void efl_gfx_gradient_spread_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.GradientSpread s);


    public delegate  void efl_gfx_gradient_spread_set_api_delegate(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
    public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate> efl_gfx_gradient_spread_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate>(_Module, "efl_gfx_gradient_spread_set");
    private static  void spread_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.GradientSpread s)
   {
      Eina.Log.Debug("function efl_gfx_gradient_spread_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((GradientRadial)wrapper).SetSpread( s);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_gradient_spread_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
      }
   }
   private static efl_gfx_gradient_spread_set_delegate efl_gfx_gradient_spread_set_static_delegate;
}
} } 
