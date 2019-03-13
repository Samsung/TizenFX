#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl orientation interface</summary>
[OrientationNativeInherit]
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
/// <value>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</value>
   Efl.Orient Orientation {
      get ;
      set ;
   }
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
/// <value>Flip method</value>
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
            return Efl.OrientationNativeInherit.GetEflClassStatic();
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
      efl_orientation_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
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
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <returns>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</returns>
   public Efl.Orient GetOrientation() {
       var _ret_var = Efl.OrientationNativeInherit.efl_orientation_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the orientation of a given object.
   /// This can be used to set the rotation on an image or a window, for instance.</summary>
   /// <param name="dir">The rotation angle (CCW), see <see cref="Efl.Orient"/>.</param>
   /// <returns></returns>
   public  void SetOrientation( Efl.Orient dir) {
                         Efl.OrientationNativeInherit.efl_orientation_set_ptr.Value.Delegate(this.NativeHandle, dir);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <returns>Flip method</returns>
   public Efl.Flip GetFlip() {
       var _ret_var = Efl.OrientationNativeInherit.efl_orientation_flip_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the flip of the given image
   /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
   /// <param name="flip">Flip method</param>
   /// <returns></returns>
   public  void SetFlip( Efl.Flip flip) {
                         Efl.OrientationNativeInherit.efl_orientation_flip_set_ptr.Value.Delegate(this.NativeHandle, flip);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
/// <value>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</value>
   public Efl.Orient Orientation {
      get { return GetOrientation(); }
      set { SetOrientation( value); }
   }
   /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
/// <value>Flip method</value>
   public Efl.Flip Flip {
      get { return GetFlip(); }
      set { SetFlip( value); }
   }
}
public class OrientationNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_orientation_get_static_delegate == null)
      efl_orientation_get_static_delegate = new efl_orientation_get_delegate(orientation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_get_static_delegate)});
      if (efl_orientation_set_static_delegate == null)
      efl_orientation_set_static_delegate = new efl_orientation_set_delegate(orientation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_set_static_delegate)});
      if (efl_orientation_flip_get_static_delegate == null)
      efl_orientation_flip_get_static_delegate = new efl_orientation_flip_get_delegate(flip_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_flip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_get_static_delegate)});
      if (efl_orientation_flip_set_static_delegate == null)
      efl_orientation_flip_set_static_delegate = new efl_orientation_flip_set_delegate(flip_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_flip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_set_static_delegate)});
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


    public delegate Efl.Orient efl_orientation_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_orientation_get_api_delegate> efl_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_get_api_delegate>(_Module, "efl_orientation_get");
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
         return efl_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_orientation_get_delegate efl_orientation_get_static_delegate;


    private delegate  void efl_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Orient dir);


    public delegate  void efl_orientation_set_api_delegate(System.IntPtr obj,   Efl.Orient dir);
    public static Efl.Eo.FunctionWrapper<efl_orientation_set_api_delegate> efl_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_set_api_delegate>(_Module, "efl_orientation_set");
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
         efl_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static efl_orientation_set_delegate efl_orientation_set_static_delegate;


    private delegate Efl.Flip efl_orientation_flip_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Flip efl_orientation_flip_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_orientation_flip_get_api_delegate> efl_orientation_flip_get_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_flip_get_api_delegate>(_Module, "efl_orientation_flip_get");
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
         return efl_orientation_flip_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_orientation_flip_get_delegate efl_orientation_flip_get_static_delegate;


    private delegate  void efl_orientation_flip_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Flip flip);


    public delegate  void efl_orientation_flip_set_api_delegate(System.IntPtr obj,   Efl.Flip flip);
    public static Efl.Eo.FunctionWrapper<efl_orientation_flip_set_api_delegate> efl_orientation_flip_set_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_flip_set_api_delegate>(_Module, "efl_orientation_flip_set");
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
         efl_orientation_flip_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flip);
      }
   }
   private static efl_orientation_flip_set_delegate efl_orientation_flip_set_static_delegate;
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
