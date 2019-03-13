#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Common interface for draggable objects and parts.
/// 1.20</summary>
[DragNativeInherit]
public interface Drag : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Gets the draggable object location.
/// 1.20</summary>
/// <param name="dx">The x relative position, from 0 to 1.
/// 1.20</param>
/// <param name="dy">The y relative position, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool GetDragValue( out double dx,  out double dy);
   /// <summary>Sets the draggable object location.
/// This places the draggable object at the given location.
/// 1.20</summary>
/// <param name="dx">The x relative position, from 0 to 1.
/// 1.20</param>
/// <param name="dy">The y relative position, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool SetDragValue( double dx,  double dy);
   /// <summary>Gets the size of the dradgable object.
/// 1.20</summary>
/// <param name="dw">The drag relative width, from 0 to 1.
/// 1.20</param>
/// <param name="dh">The drag relative height, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool GetDragSize( out double dw,  out double dh);
   /// <summary>Sets the size of the draggable object.
/// 1.20</summary>
/// <param name="dw">The drag relative width, from 0 to 1.
/// 1.20</param>
/// <param name="dh">The drag relative height, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool SetDragSize( double dw,  double dh);
   /// <summary>Gets the draggable direction.
/// 1.20</summary>
/// <returns>The direction(s) premitted for drag.
/// 1.20</returns>
Efl.Ui.DragDir GetDragDir();
   /// <summary>Gets the x and y step increments for the draggable object.
/// 1.20</summary>
/// <param name="dx">The x step relative amount, from 0 to 1.
/// 1.20</param>
/// <param name="dy">The y step relative amount, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool GetDragStep( out double dx,  out double dy);
   /// <summary>Sets the x,y step increments for a draggable object.
/// 1.20</summary>
/// <param name="dx">The x step relative amount, from 0 to 1.
/// 1.20</param>
/// <param name="dy">The y step relative amount, from 0 to 1.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool SetDragStep( double dx,  double dy);
   /// <summary>Gets the x,y page step increments for the draggable object.
/// 1.20</summary>
/// <param name="dx">The x page step increment
/// 1.20</param>
/// <param name="dy">The y page step increment
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool GetDragPage( out double dx,  out double dy);
   /// <summary>Sets the x,y page step increment values.
/// 1.20</summary>
/// <param name="dx">The x page step increment
/// 1.20</param>
/// <param name="dy">The y page step increment
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool SetDragPage( double dx,  double dy);
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
/// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.Drag.GetDragStep"/>.
/// 
/// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
/// 1.20</summary>
/// <param name="dx">The number of steps horizontally.
/// 1.20</param>
/// <param name="dy">The number of steps vertically.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool MoveDragStep( double dx,  double dy);
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
/// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.Drag.GetDragPage"/>.
/// 
/// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
/// 
/// Warning: Paging is bugged!
/// 1.20</summary>
/// <param name="dx">The number of pages horizontally.
/// 1.20</param>
/// <param name="dy">The number of pages vertically.
/// 1.20</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise
/// 1.20</returns>
bool MoveDragPage( double dx,  double dy);
                                    /// <summary>Determines the draggable directions (read-only).
/// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.
/// 1.20</summary>
/// <value>The direction(s) premitted for drag.
/// 1.20</value>
   Efl.Ui.DragDir DragDir {
      get ;
   }
}
/// <summary>Common interface for draggable objects and parts.
/// 1.20</summary>
sealed public class DragConcrete : 

Drag
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (DragConcrete))
            return Efl.Ui.DragNativeInherit.GetEflClassStatic();
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
      efl_ui_drag_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public DragConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~DragConcrete()
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
   public static DragConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new DragConcrete(obj.NativeHandle);
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
   /// <summary>Gets the draggable object location.
   /// 1.20</summary>
   /// <param name="dx">The x relative position, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y relative position, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetDragValue( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_value_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the draggable object location.
   /// This places the draggable object at the given location.
   /// 1.20</summary>
   /// <param name="dx">The x relative position, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y relative position, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool SetDragValue( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_value_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the size of the dradgable object.
   /// 1.20</summary>
   /// <param name="dw">The drag relative width, from 0 to 1.
   /// 1.20</param>
   /// <param name="dh">The drag relative height, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetDragSize( out double dw,  out double dh) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_size_get_ptr.Value.Delegate(this.NativeHandle, out dw,  out dh);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the size of the draggable object.
   /// 1.20</summary>
   /// <param name="dw">The drag relative width, from 0 to 1.
   /// 1.20</param>
   /// <param name="dh">The drag relative height, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool SetDragSize( double dw,  double dh) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_size_set_ptr.Value.Delegate(this.NativeHandle, dw,  dh);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the draggable direction.
   /// 1.20</summary>
   /// <returns>The direction(s) premitted for drag.
   /// 1.20</returns>
   public Efl.Ui.DragDir GetDragDir() {
       var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_dir_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Gets the x and y step increments for the draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetDragStep( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the x,y step increments for a draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <param name="dy">The y step relative amount, from 0 to 1.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool SetDragStep( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Gets the x,y page step increments for the draggable object.
   /// 1.20</summary>
   /// <param name="dx">The x page step increment
   /// 1.20</param>
   /// <param name="dy">The y page step increment
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool GetDragPage( out double dx,  out double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Sets the x,y page step increment values.
   /// 1.20</summary>
   /// <param name="dx">The x page step increment
   /// 1.20</param>
   /// <param name="dy">The y page step increment
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool SetDragPage( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
   /// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.Drag.GetDragStep"/>.
   /// 
   /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
   /// 1.20</summary>
   /// <param name="dx">The number of steps horizontally.
   /// 1.20</param>
   /// <param name="dy">The number of steps vertically.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool MoveDragStep( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_step_move_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
   /// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.Drag.GetDragPage"/>.
   /// 
   /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
   /// 
   /// Warning: Paging is bugged!
   /// 1.20</summary>
   /// <param name="dx">The number of pages horizontally.
   /// 1.20</param>
   /// <param name="dy">The number of pages vertically.
   /// 1.20</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise
   /// 1.20</returns>
   public bool MoveDragPage( double dx,  double dy) {
                                           var _ret_var = Efl.Ui.DragNativeInherit.efl_ui_drag_page_move_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Determines the draggable directions (read-only).
/// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.
/// 1.20</summary>
/// <value>The direction(s) premitted for drag.
/// 1.20</value>
   public Efl.Ui.DragDir DragDir {
      get { return GetDragDir(); }
   }
}
public class DragNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_drag_value_get_static_delegate == null)
      efl_ui_drag_value_get_static_delegate = new efl_ui_drag_value_get_delegate(drag_value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_get_static_delegate)});
      if (efl_ui_drag_value_set_static_delegate == null)
      efl_ui_drag_value_set_static_delegate = new efl_ui_drag_value_set_delegate(drag_value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_set_static_delegate)});
      if (efl_ui_drag_size_get_static_delegate == null)
      efl_ui_drag_size_get_static_delegate = new efl_ui_drag_size_get_delegate(drag_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_get_static_delegate)});
      if (efl_ui_drag_size_set_static_delegate == null)
      efl_ui_drag_size_set_static_delegate = new efl_ui_drag_size_set_delegate(drag_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_set_static_delegate)});
      if (efl_ui_drag_dir_get_static_delegate == null)
      efl_ui_drag_dir_get_static_delegate = new efl_ui_drag_dir_get_delegate(drag_dir_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_dir_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_dir_get_static_delegate)});
      if (efl_ui_drag_step_get_static_delegate == null)
      efl_ui_drag_step_get_static_delegate = new efl_ui_drag_step_get_delegate(drag_step_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_get_static_delegate)});
      if (efl_ui_drag_step_set_static_delegate == null)
      efl_ui_drag_step_set_static_delegate = new efl_ui_drag_step_set_delegate(drag_step_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_set_static_delegate)});
      if (efl_ui_drag_page_get_static_delegate == null)
      efl_ui_drag_page_get_static_delegate = new efl_ui_drag_page_get_delegate(drag_page_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_get_static_delegate)});
      if (efl_ui_drag_page_set_static_delegate == null)
      efl_ui_drag_page_set_static_delegate = new efl_ui_drag_page_set_delegate(drag_page_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_set_static_delegate)});
      if (efl_ui_drag_step_move_static_delegate == null)
      efl_ui_drag_step_move_static_delegate = new efl_ui_drag_step_move_delegate(drag_step_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_move_static_delegate)});
      if (efl_ui_drag_page_move_static_delegate == null)
      efl_ui_drag_page_move_static_delegate = new efl_ui_drag_page_move_delegate(drag_page_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_move_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.DragConcrete.efl_ui_drag_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.DragConcrete.efl_ui_drag_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_value_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate> efl_ui_drag_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate>(_Module, "efl_ui_drag_value_get");
    private static bool drag_value_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).GetDragValue( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_value_get_delegate efl_ui_drag_value_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_value_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_value_set_api_delegate> efl_ui_drag_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_value_set_api_delegate>(_Module, "efl_ui_drag_value_set");
    private static bool drag_value_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).SetDragValue( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_value_set_delegate efl_ui_drag_value_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dw,   out double dh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_size_get_api_delegate(System.IntPtr obj,   out double dw,   out double dh);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_size_get_api_delegate> efl_ui_drag_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_size_get_api_delegate>(_Module, "efl_ui_drag_size_get");
    private static bool drag_size_get(System.IntPtr obj, System.IntPtr pd,  out double dw,  out double dh)
   {
      Eina.Log.Debug("function efl_ui_drag_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dw = default(double);      dh = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).GetDragSize( out dw,  out dh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dw,  out dh);
      }
   }
   private static efl_ui_drag_size_get_delegate efl_ui_drag_size_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dw,   double dh);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_size_set_api_delegate(System.IntPtr obj,   double dw,   double dh);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_size_set_api_delegate> efl_ui_drag_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_size_set_api_delegate>(_Module, "efl_ui_drag_size_set");
    private static bool drag_size_set(System.IntPtr obj, System.IntPtr pd,  double dw,  double dh)
   {
      Eina.Log.Debug("function efl_ui_drag_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).SetDragSize( dw,  dh);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dw,  dh);
      }
   }
   private static efl_ui_drag_size_set_delegate efl_ui_drag_size_set_static_delegate;


    private delegate Efl.Ui.DragDir efl_ui_drag_dir_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.DragDir efl_ui_drag_dir_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_dir_get_api_delegate> efl_ui_drag_dir_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_dir_get_api_delegate>(_Module, "efl_ui_drag_dir_get");
    private static Efl.Ui.DragDir drag_dir_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_drag_dir_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.DragDir _ret_var = default(Efl.Ui.DragDir);
         try {
            _ret_var = ((Drag)wrapper).GetDragDir();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_drag_dir_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_drag_dir_get_delegate efl_ui_drag_dir_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_get_api_delegate> efl_ui_drag_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_get_api_delegate>(_Module, "efl_ui_drag_step_get");
    private static bool drag_step_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).GetDragStep( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_step_get_delegate efl_ui_drag_step_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_set_api_delegate> efl_ui_drag_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_set_api_delegate>(_Module, "efl_ui_drag_step_set");
    private static bool drag_step_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).SetDragStep( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_step_set_delegate efl_ui_drag_step_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_get_api_delegate> efl_ui_drag_page_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_get_api_delegate>(_Module, "efl_ui_drag_page_get");
    private static bool drag_page_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           dx = default(double);      dy = default(double);                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).GetDragPage( out dx,  out dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out dx,  out dy);
      }
   }
   private static efl_ui_drag_page_get_delegate efl_ui_drag_page_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_set_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_set_api_delegate> efl_ui_drag_page_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_set_api_delegate>(_Module, "efl_ui_drag_page_set");
    private static bool drag_page_set(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).SetDragPage( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_page_set_delegate efl_ui_drag_page_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_step_move_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_step_move_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_step_move_api_delegate> efl_ui_drag_step_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_step_move_api_delegate>(_Module, "efl_ui_drag_step_move");
    private static bool drag_step_move(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_step_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).MoveDragStep( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_step_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_step_move_delegate efl_ui_drag_step_move_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_page_move_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_page_move_api_delegate(System.IntPtr obj,   double dx,   double dy);
    public static Efl.Eo.FunctionWrapper<efl_ui_drag_page_move_api_delegate> efl_ui_drag_page_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_page_move_api_delegate>(_Module, "efl_ui_drag_page_move");
    private static bool drag_page_move(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy)
   {
      Eina.Log.Debug("function efl_ui_drag_page_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Drag)wrapper).MoveDragPage( dx,  dy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_drag_page_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy);
      }
   }
   private static efl_ui_drag_page_move_delegate efl_ui_drag_page_move_static_delegate;
}
} } 
