#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl screen interface</summary>
[ScreenNativeInherit]
public interface Screen : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
/// <returns>The screen size in pixels.</returns>
Eina.Size2D GetScreenSizeInPixels();
   /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
/// <returns>The screen scaling factor.</returns>
float GetScreenScaleFactor();
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
/// <returns>Screen rotation in degrees.</returns>
 int GetScreenRotation();
   /// <summary>Get the pixel density in DPI (Dots Per Inch) for the screen that a window is on.
/// 1.7</summary>
/// <param name="xdpi">Horizontal DPI.</param>
/// <param name="ydpi">Vertical DPI.</param>
/// <returns></returns>
 void GetScreenDpi( out  int xdpi,  out  int ydpi);
               /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
/// <value>The screen size in pixels.</value>
   Eina.Size2D ScreenSizeInPixels {
      get ;
   }
   /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
/// <value>The screen scaling factor.</value>
   float ScreenScaleFactor {
      get ;
   }
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
/// <value>Screen rotation in degrees.</value>
    int ScreenRotation {
      get ;
   }
}
/// <summary>Efl screen interface</summary>
sealed public class ScreenConcrete : 

Screen
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ScreenConcrete))
            return Efl.ScreenNativeInherit.GetEflClassStatic();
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
      efl_screen_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ScreenConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ScreenConcrete()
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
   public static ScreenConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ScreenConcrete(obj.NativeHandle);
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
   /// <summary>Get screen size (in pixels) for the screen.
   /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
   /// <returns>The screen size in pixels.</returns>
   public Eina.Size2D GetScreenSizeInPixels() {
       var _ret_var = Efl.ScreenNativeInherit.efl_screen_size_in_pixels_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Get screen scaling factor.
   /// This is the factor by which window contents will be scaled on the screen.
   /// 
   /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
   /// <returns>The screen scaling factor.</returns>
   public float GetScreenScaleFactor() {
       var _ret_var = Efl.ScreenNativeInherit.efl_screen_scale_factor_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the rotation of the screen.
   /// Most engines only return multiples of 90.
   /// 1.19</summary>
   /// <returns>Screen rotation in degrees.</returns>
   public  int GetScreenRotation() {
       var _ret_var = Efl.ScreenNativeInherit.efl_screen_rotation_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the pixel density in DPI (Dots Per Inch) for the screen that a window is on.
   /// 1.7</summary>
   /// <param name="xdpi">Horizontal DPI.</param>
   /// <param name="ydpi">Vertical DPI.</param>
   /// <returns></returns>
   public  void GetScreenDpi( out  int xdpi,  out  int ydpi) {
                                           Efl.ScreenNativeInherit.efl_screen_dpi_get_ptr.Value.Delegate(this.NativeHandle, out xdpi,  out ydpi);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
/// <value>The screen size in pixels.</value>
   public Eina.Size2D ScreenSizeInPixels {
      get { return GetScreenSizeInPixels(); }
   }
   /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
/// <value>The screen scaling factor.</value>
   public float ScreenScaleFactor {
      get { return GetScreenScaleFactor(); }
   }
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
/// <value>Screen rotation in degrees.</value>
   public  int ScreenRotation {
      get { return GetScreenRotation(); }
   }
}
public class ScreenNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_screen_size_in_pixels_get_static_delegate == null)
      efl_screen_size_in_pixels_get_static_delegate = new efl_screen_size_in_pixels_get_delegate(screen_size_in_pixels_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_screen_size_in_pixels_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_size_in_pixels_get_static_delegate)});
      if (efl_screen_scale_factor_get_static_delegate == null)
      efl_screen_scale_factor_get_static_delegate = new efl_screen_scale_factor_get_delegate(screen_scale_factor_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_screen_scale_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_scale_factor_get_static_delegate)});
      if (efl_screen_rotation_get_static_delegate == null)
      efl_screen_rotation_get_static_delegate = new efl_screen_rotation_get_delegate(screen_rotation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_screen_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_rotation_get_static_delegate)});
      if (efl_screen_dpi_get_static_delegate == null)
      efl_screen_dpi_get_static_delegate = new efl_screen_dpi_get_delegate(screen_dpi_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_screen_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_dpi_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.ScreenConcrete.efl_screen_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.ScreenConcrete.efl_screen_interface_get();
   }


    private delegate Eina.Size2D_StructInternal efl_screen_size_in_pixels_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_screen_size_in_pixels_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate> efl_screen_size_in_pixels_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate>(_Module, "efl_screen_size_in_pixels_get");
    private static Eina.Size2D_StructInternal screen_size_in_pixels_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_screen_size_in_pixels_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Screen)wrapper).GetScreenSizeInPixels();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_screen_size_in_pixels_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_screen_size_in_pixels_get_delegate efl_screen_size_in_pixels_get_static_delegate;


    private delegate float efl_screen_scale_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate float efl_screen_scale_factor_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_screen_scale_factor_get_api_delegate> efl_screen_scale_factor_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_scale_factor_get_api_delegate>(_Module, "efl_screen_scale_factor_get");
    private static float screen_scale_factor_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_screen_scale_factor_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  float _ret_var = default(float);
         try {
            _ret_var = ((Screen)wrapper).GetScreenScaleFactor();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_screen_scale_factor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_screen_scale_factor_get_delegate efl_screen_scale_factor_get_static_delegate;


    private delegate  int efl_screen_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_screen_rotation_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_screen_rotation_get_api_delegate> efl_screen_rotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_rotation_get_api_delegate>(_Module, "efl_screen_rotation_get");
    private static  int screen_rotation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_screen_rotation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Screen)wrapper).GetScreenRotation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_screen_rotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_screen_rotation_get_delegate efl_screen_rotation_get_static_delegate;


    private delegate  void efl_screen_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int xdpi,   out  int ydpi);


    public delegate  void efl_screen_dpi_get_api_delegate(System.IntPtr obj,   out  int xdpi,   out  int ydpi);
    public static Efl.Eo.FunctionWrapper<efl_screen_dpi_get_api_delegate> efl_screen_dpi_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_dpi_get_api_delegate>(_Module, "efl_screen_dpi_get");
    private static  void screen_dpi_get(System.IntPtr obj, System.IntPtr pd,  out  int xdpi,  out  int ydpi)
   {
      Eina.Log.Debug("function efl_screen_dpi_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           xdpi = default( int);      ydpi = default( int);                     
         try {
            ((Screen)wrapper).GetScreenDpi( out xdpi,  out ydpi);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_screen_dpi_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out xdpi,  out ydpi);
      }
   }
   private static efl_screen_dpi_get_delegate efl_screen_dpi_get_static_delegate;
}
} 
