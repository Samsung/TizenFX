#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl screen interface</summary>
[ScreenConcreteNativeInherit]
public interface Screen : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get screen geometry details for the screen that a window is on.
/// Note that on some display systems this information is not available (this could be the case Wayland for instance).</summary>
/// <returns>The screen size.</returns>
Eina.Size2D GetScreenSize();
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
/// <returns>The degree of the screen.</returns>
 int GetScreenRotation();
   /// <summary>Get screen dpi for the screen that a window is on.
/// 1.7</summary>
/// <param name="xdpi">Pointer to value to store return horizontal dpi. May be <c>null</c>.</param>
/// <param name="ydpi">Pointer to value to store return vertical dpi. May be <c>null</c>.</param>
/// <returns></returns>
 void GetScreenDpi( out  int xdpi,  out  int ydpi);
            /// <summary>Get screen geometry details for the screen that a window is on.
/// Note that on some display systems this information is not available (this could be the case Wayland for instance).</summary>
   Eina.Size2D ScreenSize {
      get ;
   }
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
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
            return Efl.ScreenConcreteNativeInherit.GetEflClassStatic();
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
      efl_screen_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Eina.Size2D_StructInternal efl_screen_size_get(System.IntPtr obj);
   /// <summary>Get screen geometry details for the screen that a window is on.
   /// Note that on some display systems this information is not available (this could be the case Wayland for instance).</summary>
   /// <returns>The screen size.</returns>
   public Eina.Size2D GetScreenSize() {
       var _ret_var = efl_screen_size_get(Efl.ScreenConcrete.efl_screen_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  int efl_screen_rotation_get(System.IntPtr obj);
   /// <summary>Get the rotation of the screen.
   /// Most engines only return multiples of 90.
   /// 1.19</summary>
   /// <returns>The degree of the screen.</returns>
   public  int GetScreenRotation() {
       var _ret_var = efl_screen_rotation_get(Efl.ScreenConcrete.efl_screen_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_screen_dpi_get(System.IntPtr obj,   out  int xdpi,   out  int ydpi);
   /// <summary>Get screen dpi for the screen that a window is on.
   /// 1.7</summary>
   /// <param name="xdpi">Pointer to value to store return horizontal dpi. May be <c>null</c>.</param>
   /// <param name="ydpi">Pointer to value to store return vertical dpi. May be <c>null</c>.</param>
   /// <returns></returns>
   public  void GetScreenDpi( out  int xdpi,  out  int ydpi) {
                                           efl_screen_dpi_get(Efl.ScreenConcrete.efl_screen_interface_get(),  out xdpi,  out ydpi);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Get screen geometry details for the screen that a window is on.
/// Note that on some display systems this information is not available (this could be the case Wayland for instance).</summary>
   public Eina.Size2D ScreenSize {
      get { return GetScreenSize(); }
   }
   /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// 1.19</summary>
   public  int ScreenRotation {
      get { return GetScreenRotation(); }
   }
}
public class ScreenConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_screen_size_get_static_delegate = new efl_screen_size_get_delegate(screen_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_screen_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_size_get_static_delegate)});
      efl_screen_rotation_get_static_delegate = new efl_screen_rotation_get_delegate(screen_rotation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_screen_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_rotation_get_static_delegate)});
      efl_screen_dpi_get_static_delegate = new efl_screen_dpi_get_delegate(screen_dpi_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_screen_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_dpi_get_static_delegate)});
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


    private delegate Eina.Size2D_StructInternal efl_screen_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_screen_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal screen_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_screen_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Screen)wrapper).GetScreenSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_screen_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_screen_size_get_delegate efl_screen_size_get_static_delegate;


    private delegate  int efl_screen_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  int efl_screen_rotation_get(System.IntPtr obj);
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
         return efl_screen_rotation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_screen_rotation_get_delegate efl_screen_rotation_get_static_delegate;


    private delegate  void efl_screen_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int xdpi,   out  int ydpi);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_screen_dpi_get(System.IntPtr obj,   out  int xdpi,   out  int ydpi);
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
         efl_screen_dpi_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out xdpi,  out ydpi);
      }
   }
   private efl_screen_dpi_get_delegate efl_screen_dpi_get_static_delegate;
}
} 
