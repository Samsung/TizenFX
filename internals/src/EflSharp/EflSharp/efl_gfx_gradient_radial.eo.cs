#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics gradient radial interface</summary>
[GradientRadialConcreteNativeInherit]
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
            return Efl.Gfx.GradientRadialConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_gfx_gradient_radial_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_radial_center_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Gets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   public  void GetCenter( out double x,  out double y) {
                                           efl_gfx_gradient_radial_center_get(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_radial_center_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Sets the center of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of center point</param>
   /// <param name="y">Y co-ordinate of center point</param>
   /// <returns></returns>
   public  void SetCenter( double x,  double y) {
                                           efl_gfx_gradient_radial_center_set(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_gfx_gradient_radial_radius_get(System.IntPtr obj);
   /// <summary>Gets the center radius of this radial gradient.</summary>
   /// <returns>Center radius</returns>
   public double GetRadius() {
       var _ret_var = efl_gfx_gradient_radial_radius_get(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_radial_radius_set(System.IntPtr obj,   double r);
   /// <summary>Sets the center radius of this radial gradient.</summary>
   /// <param name="r">Center radius</param>
   /// <returns></returns>
   public  void SetRadius( double r) {
                         efl_gfx_gradient_radial_radius_set(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get(),  r);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_radial_focal_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Gets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   public  void GetFocal( out double x,  out double y) {
                                           efl_gfx_gradient_radial_focal_get(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get(),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_radial_focal_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Sets the focal point of this radial gradient.</summary>
   /// <param name="x">X co-ordinate of focal point</param>
   /// <param name="y">Y co-ordinate of focal point</param>
   /// <returns></returns>
   public  void SetFocal( double x,  double y) {
                                           efl_gfx_gradient_radial_focal_set(Efl.Gfx.GradientRadialConcrete.efl_gfx_gradient_radial_interface_get(),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_stop_get(System.IntPtr obj,   out  System.IntPtr colors,   out  uint length);
   /// <summary>Get the list of color stops.</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   public  void GetStop( out Efl.Gfx.GradientStop colors,  out  uint length) {
                   var _out_colors = new  System.IntPtr();
                        efl_gfx_gradient_stop_get(Efl.Gfx.GradientConcrete.efl_gfx_gradient_interface_get(),  out _out_colors,  out length);
      Eina.Error.RaiseIfUnhandledException();
      colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                         }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_stop_set(System.IntPtr obj,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
   /// <summary>Set the list of color stops for the gradient</summary>
   /// <param name="colors">Color stops list</param>
   /// <param name="length">Length of the list</param>
   /// <returns></returns>
   public  void SetStop( ref Efl.Gfx.GradientStop colors,   uint length) {
       var _in_colors = Efl.Gfx.GradientStop_StructConversion.ToInternal(colors);
                                    efl_gfx_gradient_stop_set(Efl.Gfx.GradientConcrete.efl_gfx_gradient_interface_get(),  ref _in_colors,  length);
      Eina.Error.RaiseIfUnhandledException();
                  colors = Efl.Gfx.GradientStop_StructConversion.ToManaged(_in_colors);
             }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get(System.IntPtr obj);
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
   /// <returns>Spread type to be used</returns>
   public Efl.Gfx.GradientSpread GetSpread() {
       var _ret_var = efl_gfx_gradient_spread_get(Efl.Gfx.GradientConcrete.efl_gfx_gradient_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_gradient_spread_set(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
   /// <summary>Specifies the spread method that should be used for this gradient.</summary>
   /// <param name="s">Spread type to be used</param>
   /// <returns></returns>
   public  void SetSpread( Efl.Gfx.GradientSpread s) {
                         efl_gfx_gradient_spread_set(Efl.Gfx.GradientConcrete.efl_gfx_gradient_interface_get(),  s);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Gets the center radius of this radial gradient.</summary>
   public double Radius {
      get { return GetRadius(); }
      set { SetRadius( value); }
   }
   /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
   public Efl.Gfx.GradientSpread Spread {
      get { return GetSpread(); }
      set { SetSpread( value); }
   }
}
public class GradientRadialConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_gradient_radial_center_get_static_delegate = new efl_gfx_gradient_radial_center_get_delegate(center_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_center_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_get_static_delegate)});
      efl_gfx_gradient_radial_center_set_static_delegate = new efl_gfx_gradient_radial_center_set_delegate(center_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_center_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_center_set_static_delegate)});
      efl_gfx_gradient_radial_radius_get_static_delegate = new efl_gfx_gradient_radial_radius_get_delegate(radius_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_get_static_delegate)});
      efl_gfx_gradient_radial_radius_set_static_delegate = new efl_gfx_gradient_radial_radius_set_delegate(radius_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_radius_set_static_delegate)});
      efl_gfx_gradient_radial_focal_get_static_delegate = new efl_gfx_gradient_radial_focal_get_delegate(focal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_focal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_get_static_delegate)});
      efl_gfx_gradient_radial_focal_set_static_delegate = new efl_gfx_gradient_radial_focal_set_delegate(focal_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_radial_focal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_radial_focal_set_static_delegate)});
      efl_gfx_gradient_stop_get_static_delegate = new efl_gfx_gradient_stop_get_delegate(stop_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_stop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_get_static_delegate)});
      efl_gfx_gradient_stop_set_static_delegate = new efl_gfx_gradient_stop_set_delegate(stop_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_stop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_set_static_delegate)});
      efl_gfx_gradient_spread_get_static_delegate = new efl_gfx_gradient_spread_get_delegate(spread_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_spread_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_get_static_delegate)});
      efl_gfx_gradient_spread_set_static_delegate = new efl_gfx_gradient_spread_set_delegate(spread_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_gradient_spread_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_set_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_radial_center_get(System.IntPtr obj,   out double x,   out double y);
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
         efl_gfx_gradient_radial_center_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_gradient_radial_center_get_delegate efl_gfx_gradient_radial_center_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_center_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_radial_center_set(System.IntPtr obj,   double x,   double y);
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
         efl_gfx_gradient_radial_center_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_gradient_radial_center_set_delegate efl_gfx_gradient_radial_center_set_static_delegate;


    private delegate double efl_gfx_gradient_radial_radius_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_gradient_radial_radius_get(System.IntPtr obj);
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
         return efl_gfx_gradient_radial_radius_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_gradient_radial_radius_get_delegate efl_gfx_gradient_radial_radius_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,   double r);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_radial_radius_set(System.IntPtr obj,   double r);
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
         efl_gfx_gradient_radial_radius_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r);
      }
   }
   private efl_gfx_gradient_radial_radius_set_delegate efl_gfx_gradient_radial_radius_set_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_radial_focal_get(System.IntPtr obj,   out double x,   out double y);
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
         efl_gfx_gradient_radial_focal_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_gradient_radial_focal_get_delegate efl_gfx_gradient_radial_focal_get_static_delegate;


    private delegate  void efl_gfx_gradient_radial_focal_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_radial_focal_set(System.IntPtr obj,   double x,   double y);
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
         efl_gfx_gradient_radial_focal_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_gradient_radial_focal_set_delegate efl_gfx_gradient_radial_focal_set_static_delegate;


    private delegate  void efl_gfx_gradient_stop_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  System.IntPtr colors,   out  uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_stop_get(System.IntPtr obj,   out  System.IntPtr colors,   out  uint length);
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
         efl_gfx_gradient_stop_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out colors,  out length);
      }
   }
   private efl_gfx_gradient_stop_get_delegate efl_gfx_gradient_stop_get_static_delegate;


    private delegate  void efl_gfx_gradient_stop_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_stop_set(System.IntPtr obj,   ref Efl.Gfx.GradientStop_StructInternal colors,    uint length);
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
         efl_gfx_gradient_stop_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref colors,  length);
      }
   }
   private efl_gfx_gradient_stop_set_delegate efl_gfx_gradient_stop_set_static_delegate;


    private delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get(System.IntPtr obj);
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
         return efl_gfx_gradient_spread_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_gradient_spread_get_delegate efl_gfx_gradient_spread_get_static_delegate;


    private delegate  void efl_gfx_gradient_spread_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.GradientSpread s);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_gradient_spread_set(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
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
         efl_gfx_gradient_spread_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
      }
   }
   private efl_gfx_gradient_spread_set_delegate efl_gfx_gradient_spread_set_static_delegate;
}
} } 
