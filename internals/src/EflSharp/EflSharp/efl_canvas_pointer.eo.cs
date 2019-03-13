#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl Canvas Pointer interface</summary>
[PointerNativeInherit]
public interface Pointer : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Returns whether the mouse pointer is logically inside the canvas.
/// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
/// 
/// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
/// 
/// A canvas begins with the mouse being assumed outside (<c>false</c>).</summary>
/// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
/// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
bool GetPointerInside( Efl.Input.Device seat);
   }
/// <summary>Efl Canvas Pointer interface</summary>
sealed public class PointerConcrete : 

Pointer
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PointerConcrete))
            return Efl.Canvas.PointerNativeInherit.GetEflClassStatic();
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
      efl_canvas_pointer_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PointerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PointerConcrete()
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
   public static PointerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PointerConcrete(obj.NativeHandle);
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
   /// <summary>Returns whether the mouse pointer is logically inside the canvas.
   /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
   /// 
   /// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
   /// 
   /// A canvas begins with the mouse being assumed outside (<c>false</c>).</summary>
   /// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
   /// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
   public bool GetPointerInside( Efl.Input.Device seat) {
                         var _ret_var = Efl.Canvas.PointerNativeInherit.efl_canvas_pointer_inside_get_ptr.Value.Delegate(this.NativeHandle, seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
}
public class PointerNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_canvas_pointer_inside_get_static_delegate == null)
      efl_canvas_pointer_inside_get_static_delegate = new efl_canvas_pointer_inside_get_delegate(pointer_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_canvas_pointer_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_pointer_inside_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.PointerConcrete.efl_canvas_pointer_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.PointerConcrete.efl_canvas_pointer_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_pointer_inside_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_canvas_pointer_inside_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate> efl_canvas_pointer_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate>(_Module, "efl_canvas_pointer_inside_get");
    private static bool pointer_inside_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_canvas_pointer_inside_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetPointerInside( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_pointer_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_canvas_pointer_inside_get_delegate efl_canvas_pointer_inside_get_static_delegate;
}
} } 
