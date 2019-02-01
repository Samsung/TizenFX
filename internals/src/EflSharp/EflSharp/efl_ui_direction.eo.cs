#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>EFL UI object direction interface</summary>
[DirectionConcreteNativeInherit]
public interface Direction : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <returns>Direction of the widget.</returns>
Efl.Ui.Dir GetDirection();
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <param name="dir">Direction of the widget.</param>
/// <returns></returns>
 void SetDirection( Efl.Ui.Dir dir);
         /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   Efl.Ui.Dir Direction {
      get ;
      set ;
   }
}
/// <summary>EFL UI object direction interface</summary>
sealed public class DirectionConcrete : 

Direction
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (DirectionConcrete))
            return Efl.Ui.DirectionConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_direction_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public DirectionConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~DirectionConcrete()
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
   public static DirectionConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new DirectionConcrete(obj.NativeHandle);
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
    private static extern Efl.Ui.Dir efl_ui_direction_get(System.IntPtr obj);
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <returns>Direction of the widget.</returns>
   public Efl.Ui.Dir GetDirection() {
       var _ret_var = efl_ui_direction_get(Efl.Ui.DirectionConcrete.efl_ui_direction_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_ui_direction_set(System.IntPtr obj,   Efl.Ui.Dir dir);
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <param name="dir">Direction of the widget.</param>
   /// <returns></returns>
   public  void SetDirection( Efl.Ui.Dir dir) {
                         efl_ui_direction_set(Efl.Ui.DirectionConcrete.efl_ui_direction_interface_get(),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   public Efl.Ui.Dir Direction {
      get { return GetDirection(); }
      set { SetDirection( value); }
   }
}
public class DirectionConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
      efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.DirectionConcrete.efl_ui_direction_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.DirectionConcrete.efl_ui_direction_interface_get();
   }


    private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Ui.Dir efl_ui_direction_get(System.IntPtr obj);
    private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
         try {
            _ret_var = ((Direction)wrapper).GetDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


    private delegate  void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_direction_set(System.IntPtr obj,   Efl.Ui.Dir dir);
    private static  void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Direction)wrapper).SetDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_direction_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Direction for UI objects and layouts.
/// Not to be confused with <see cref="Efl.Orient"/> which is for images and canvases. This enum is used to define how widgets should expand and orient themselves, not to rotate images.
/// 
/// See also <see cref="Efl.Ui.Direction"/>.</summary>
public enum Dir
{
/// <summary>Default direction. Each widget may have a different default.</summary>
Default = 0,
/// <summary>Horizontal direction, along the X axis. Usually left-to-right, but may be inverted to right-to-left if mirroring is on.</summary>
Horizontal = 1,
/// <summary>Vertical direction, along the Y axis. Usually downwards.</summary>
Vertical = 2,
/// <summary>Horizontal, left-to-right direction.</summary>
Ltr = 3,
/// <summary>Horizontal, right-to-left direction.</summary>
Rtl = 4,
/// <summary>Vertical, top-to-bottom direction.</summary>
Down = 5,
/// <summary>Vertical, bottom-to-top direction.</summary>
Up = 6,
/// <summary>Right is an alias for LTR.</summary>
Right = 3,
/// <summary>Left is an alias for RTL.</summary>
Left = 4,
}
} } 
