#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl orientation interface</summary>
[OrientationConcreteNativeInherit]
public interface Orientation : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
/// <returns>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</returns>
Efl.Orient GetOrientation();
   /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
/// <param name="dir">The rotation angle (CCW), see <see cref="Efl.Orient"/>.</param>
/// <returns></returns>
 void SetOrientation( Efl.Orient dir);
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
/// <returns>Flip method</returns>
Efl.Flip GetFlip();
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
/// <param name="flip">Flip method</param>
/// <returns></returns>
 void SetFlip( Efl.Flip flip);
               /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
   Efl.Orient Orientation {
      get ;
      set ;
   }
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   Efl.Flip Flip {
      get ;
      set ;
   }
}
/// <summary>Efl orientation interface</summary>
sealed public class OrientationConcrete : 

Orientation
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (OrientationConcrete))
            return Efl.OrientationConcreteNativeInherit.GetEflClassStatic();
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
      efl_orientation_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public OrientationConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~OrientationConcrete()
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
   public static OrientationConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new OrientationConcrete(obj.NativeHandle);
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
    private static extern Efl.Orient efl_orientation_get(System.IntPtr obj);
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <returns>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</returns>
   public Efl.Orient GetOrientation() {
       var _ret_var = efl_orientation_get(Efl.OrientationConcrete.efl_orientation_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_orientation_set(System.IntPtr obj,   Efl.Orient dir);
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <param name="dir">The rotation angle (CCW), see <see cref="Efl.Orient"/>.</param>
   /// <returns></returns>
   public  void SetOrientation( Efl.Orient dir) {
                         efl_orientation_set(Efl.OrientationConcrete.efl_orientation_interface_get(),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern Efl.Flip efl_orientation_flip_get(System.IntPtr obj);
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <returns>Flip method</returns>
   public Efl.Flip GetFlip() {
       var _ret_var = efl_orientation_flip_get(Efl.OrientationConcrete.efl_orientation_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_orientation_flip_set(System.IntPtr obj,   Efl.Flip flip);
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <param name="flip">Flip method</param>
   /// <returns></returns>
   public  void SetFlip( Efl.Flip flip) {
                         efl_orientation_flip_set(Efl.OrientationConcrete.efl_orientation_interface_get(),  flip);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
   public Efl.Orient Orientation {
      get { return GetOrientation(); }
      set { SetOrientation( value); }
   }
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   public Efl.Flip Flip {
      get { return GetFlip(); }
      set { SetFlip( value); }
   }
}
public class OrientationConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_orientation_get_static_delegate = new efl_orientation_get_delegate(orientation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_get_static_delegate)});
      efl_orientation_set_static_delegate = new efl_orientation_set_delegate(orientation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_set_static_delegate)});
      efl_orientation_flip_get_static_delegate = new efl_orientation_flip_get_delegate(flip_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_flip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_get_static_delegate)});
      efl_orientation_flip_set_static_delegate = new efl_orientation_flip_set_delegate(flip_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_orientation_flip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.OrientationConcrete.efl_orientation_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.OrientationConcrete.efl_orientation_interface_get();
   }


    private delegate Efl.Orient efl_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Orient efl_orientation_get(System.IntPtr obj);
    private static Efl.Orient orientation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_orientation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Orient _ret_var = default(Efl.Orient);
         try {
            _ret_var = ((Orientation)wrapper).GetOrientation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_orientation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_orientation_get_delegate efl_orientation_get_static_delegate;


    private delegate  void efl_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Orient dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_orientation_set(System.IntPtr obj,   Efl.Orient dir);
    private static  void orientation_set(System.IntPtr obj, System.IntPtr pd,  Efl.Orient dir)
   {
      Eina.Log.Debug("function efl_orientation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Orientation)wrapper).SetOrientation( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_orientation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_orientation_set_delegate efl_orientation_set_static_delegate;


    private delegate Efl.Flip efl_orientation_flip_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Flip efl_orientation_flip_get(System.IntPtr obj);
    private static Efl.Flip flip_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_orientation_flip_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Flip _ret_var = default(Efl.Flip);
         try {
            _ret_var = ((Orientation)wrapper).GetFlip();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_orientation_flip_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_orientation_flip_get_delegate efl_orientation_flip_get_static_delegate;


    private delegate  void efl_orientation_flip_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Flip flip);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_orientation_flip_set(System.IntPtr obj,   Efl.Flip flip);
    private static  void flip_set(System.IntPtr obj, System.IntPtr pd,  Efl.Flip flip)
   {
      Eina.Log.Debug("function efl_orientation_flip_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Orientation)wrapper).SetFlip( flip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_orientation_flip_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flip);
      }
   }
   private efl_orientation_flip_set_delegate efl_orientation_flip_set_static_delegate;
}
} 
namespace Efl { 
/// <summary>An orientation type, to rotate visual objects.
/// Not to be confused with <see cref="Efl.Ui.Dir"/> which is meant for widgets, rather than images and canvases. This enum is used to rotate images, videos and the like.
/// 
/// See also <see cref="Efl.Orientation"/>.</summary>
public enum Orient
{
/// <summary>Default, same as up</summary>
None = 0,
/// <summary>Orient up, do not rotate.</summary>
Up = 0,
/// <summary>Orient right, rotate 90 degrees counter clock-wise.</summary>
Right = 90,
/// <summary>Orient down, rotate 180 degrees.</summary>
Down = 180,
/// <summary>Orient left, rotate 90 degrees clock-wise.</summary>
Left = 270,
}
} 
namespace Efl { 
/// <summary>A flip type, to flip visual objects.
/// See also <see cref="Efl.Orientation"/>.</summary>
public enum Flip
{
/// <summary>No flip</summary>
None = 0,
/// <summary>Flip image horizontally</summary>
Horizontal = 1,
/// <summary>Flip image vertically</summary>
Vertical = 2,
}
} 
