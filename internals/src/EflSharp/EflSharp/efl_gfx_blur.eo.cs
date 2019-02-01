#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.Filter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.Color.GetColor"/>.</summary>
[BlurConcreteNativeInherit]
public interface Blur : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The blur radius in pixels.</summary>
/// <param name="rx">The horizontal blur radius.</param>
/// <param name="ry">The vertical blur radius.</param>
/// <returns></returns>
 void GetRadius( out double rx,  out double ry);
   /// <summary>The blur radius in pixels.</summary>
/// <param name="rx">The horizontal blur radius.</param>
/// <param name="ry">The vertical blur radius.</param>
/// <returns></returns>
 void SetRadius( double rx,  double ry);
   /// <summary>An offset relative to the original pixels.
/// This property allows for drop shadow effects.</summary>
/// <param name="ox">Horizontal offset in pixels.</param>
/// <param name="oy">Vertical offset in pixels.</param>
/// <returns></returns>
 void GetOffset( out double ox,  out double oy);
   /// <summary>An offset relative to the original pixels.
/// This property allows for drop shadow effects.</summary>
/// <param name="ox">Horizontal offset in pixels.</param>
/// <param name="oy">Vertical offset in pixels.</param>
/// <returns></returns>
 void SetOffset( double ox,  double oy);
   /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <returns>How much to grow the original pixel data.</returns>
double GetGrow();
   /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <param name="radius">How much to grow the original pixel data.</param>
/// <returns></returns>
 void SetGrow( double radius);
                     /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
   double Grow {
      get ;
      set ;
   }
}
/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.Filter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.Color.GetColor"/>.</summary>
sealed public class BlurConcrete : 

Blur
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (BlurConcrete))
            return Efl.Gfx.BlurConcreteNativeInherit.GetEflClassStatic();
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
      efl_gfx_blur_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public BlurConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~BlurConcrete()
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
   public static BlurConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new BlurConcrete(obj.NativeHandle);
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
    private static extern  void efl_gfx_blur_radius_get(System.IntPtr obj,   out double rx,   out double ry);
   /// <summary>The blur radius in pixels.</summary>
   /// <param name="rx">The horizontal blur radius.</param>
   /// <param name="ry">The vertical blur radius.</param>
   /// <returns></returns>
   public  void GetRadius( out double rx,  out double ry) {
                                           efl_gfx_blur_radius_get(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get(),  out rx,  out ry);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_blur_radius_set(System.IntPtr obj,   double rx,   double ry);
   /// <summary>The blur radius in pixels.</summary>
   /// <param name="rx">The horizontal blur radius.</param>
   /// <param name="ry">The vertical blur radius.</param>
   /// <returns></returns>
   public  void SetRadius( double rx,  double ry) {
                                           efl_gfx_blur_radius_set(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get(),  rx,  ry);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_blur_offset_get(System.IntPtr obj,   out double ox,   out double oy);
   /// <summary>An offset relative to the original pixels.
   /// This property allows for drop shadow effects.</summary>
   /// <param name="ox">Horizontal offset in pixels.</param>
   /// <param name="oy">Vertical offset in pixels.</param>
   /// <returns></returns>
   public  void GetOffset( out double ox,  out double oy) {
                                           efl_gfx_blur_offset_get(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get(),  out ox,  out oy);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_blur_offset_set(System.IntPtr obj,   double ox,   double oy);
   /// <summary>An offset relative to the original pixels.
   /// This property allows for drop shadow effects.</summary>
   /// <param name="ox">Horizontal offset in pixels.</param>
   /// <param name="oy">Vertical offset in pixels.</param>
   /// <returns></returns>
   public  void SetOffset( double ox,  double oy) {
                                           efl_gfx_blur_offset_set(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get(),  ox,  oy);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_gfx_blur_grow_get(System.IntPtr obj);
   /// <summary>How much the original image should be &quot;grown&quot; before blurring.
   /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
   /// 
   /// This is can be used efficiently to create glow effects.</summary>
   /// <returns>How much to grow the original pixel data.</returns>
   public double GetGrow() {
       var _ret_var = efl_gfx_blur_grow_get(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_gfx_blur_grow_set(System.IntPtr obj,   double radius);
   /// <summary>How much the original image should be &quot;grown&quot; before blurring.
   /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
   /// 
   /// This is can be used efficiently to create glow effects.</summary>
   /// <param name="radius">How much to grow the original pixel data.</param>
   /// <returns></returns>
   public  void SetGrow( double radius) {
                         efl_gfx_blur_grow_set(Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get(),  radius);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
   public double Grow {
      get { return GetGrow(); }
      set { SetGrow( value); }
   }
}
public class BlurConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_blur_radius_get_static_delegate = new efl_gfx_blur_radius_get_delegate(radius_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_get_static_delegate)});
      efl_gfx_blur_radius_set_static_delegate = new efl_gfx_blur_radius_set_delegate(radius_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_set_static_delegate)});
      efl_gfx_blur_offset_get_static_delegate = new efl_gfx_blur_offset_get_delegate(offset_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_get_static_delegate)});
      efl_gfx_blur_offset_set_static_delegate = new efl_gfx_blur_offset_set_delegate(offset_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_set_static_delegate)});
      efl_gfx_blur_grow_get_static_delegate = new efl_gfx_blur_grow_get_delegate(grow_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_grow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_get_static_delegate)});
      efl_gfx_blur_grow_set_static_delegate = new efl_gfx_blur_grow_set_delegate(grow_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_blur_grow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get();
   }


    private delegate  void efl_gfx_blur_radius_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double rx,   out double ry);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_blur_radius_get(System.IntPtr obj,   out double rx,   out double ry);
    private static  void radius_get(System.IntPtr obj, System.IntPtr pd,  out double rx,  out double ry)
   {
      Eina.Log.Debug("function efl_gfx_blur_radius_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           rx = default(double);      ry = default(double);                     
         try {
            ((Blur)wrapper).GetRadius( out rx,  out ry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_blur_radius_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out rx,  out ry);
      }
   }
   private efl_gfx_blur_radius_get_delegate efl_gfx_blur_radius_get_static_delegate;


    private delegate  void efl_gfx_blur_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,   double rx,   double ry);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_blur_radius_set(System.IntPtr obj,   double rx,   double ry);
    private static  void radius_set(System.IntPtr obj, System.IntPtr pd,  double rx,  double ry)
   {
      Eina.Log.Debug("function efl_gfx_blur_radius_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Blur)wrapper).SetRadius( rx,  ry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_blur_radius_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rx,  ry);
      }
   }
   private efl_gfx_blur_radius_set_delegate efl_gfx_blur_radius_set_static_delegate;


    private delegate  void efl_gfx_blur_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double ox,   out double oy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_blur_offset_get(System.IntPtr obj,   out double ox,   out double oy);
    private static  void offset_get(System.IntPtr obj, System.IntPtr pd,  out double ox,  out double oy)
   {
      Eina.Log.Debug("function efl_gfx_blur_offset_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           ox = default(double);      oy = default(double);                     
         try {
            ((Blur)wrapper).GetOffset( out ox,  out oy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_blur_offset_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out ox,  out oy);
      }
   }
   private efl_gfx_blur_offset_get_delegate efl_gfx_blur_offset_get_static_delegate;


    private delegate  void efl_gfx_blur_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ox,   double oy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_blur_offset_set(System.IntPtr obj,   double ox,   double oy);
    private static  void offset_set(System.IntPtr obj, System.IntPtr pd,  double ox,  double oy)
   {
      Eina.Log.Debug("function efl_gfx_blur_offset_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Blur)wrapper).SetOffset( ox,  oy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_blur_offset_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ox,  oy);
      }
   }
   private efl_gfx_blur_offset_set_delegate efl_gfx_blur_offset_set_static_delegate;


    private delegate double efl_gfx_blur_grow_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_blur_grow_get(System.IntPtr obj);
    private static double grow_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_blur_grow_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Blur)wrapper).GetGrow();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_blur_grow_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_blur_grow_get_delegate efl_gfx_blur_grow_get_static_delegate;


    private delegate  void efl_gfx_blur_grow_set_delegate(System.IntPtr obj, System.IntPtr pd,   double radius);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_blur_grow_set(System.IntPtr obj,   double radius);
    private static  void grow_set(System.IntPtr obj, System.IntPtr pd,  double radius)
   {
      Eina.Log.Debug("function efl_gfx_blur_grow_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Blur)wrapper).SetGrow( radius);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_blur_grow_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  radius);
      }
   }
   private efl_gfx_blur_grow_set_delegate efl_gfx_blur_grow_set_static_delegate;
}
} } 
