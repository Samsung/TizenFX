#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Common interface for draggable objects and parts.</summary>
[IDragNativeInherit]
public interface IDrag : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Gets the draggable object location.</summary>
/// <param name="dx">The x relative position, from 0 to 1.</param>
/// <param name="dy">The y relative position, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetDragValue( out double dx,  out double dy);
    /// <summary>Sets the draggable object location.
/// This places the draggable object at the given location.</summary>
/// <param name="dx">The x relative position, from 0 to 1.</param>
/// <param name="dy">The y relative position, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetDragValue( double dx,  double dy);
    /// <summary>Gets the size of the dradgable object.</summary>
/// <param name="dw">The drag relative width, from 0 to 1.</param>
/// <param name="dh">The drag relative height, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetDragSize( out double dw,  out double dh);
    /// <summary>Sets the size of the draggable object.</summary>
/// <param name="dw">The drag relative width, from 0 to 1.</param>
/// <param name="dh">The drag relative height, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetDragSize( double dw,  double dh);
    /// <summary>Gets the draggable direction.</summary>
/// <returns>The direction(s) premitted for drag.</returns>
Efl.Ui.DragDir GetDragDir();
    /// <summary>Gets the x and y step increments for the draggable object.</summary>
/// <param name="dx">The x step relative amount, from 0 to 1.</param>
/// <param name="dy">The y step relative amount, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetDragStep( out double dx,  out double dy);
    /// <summary>Sets the x,y step increments for a draggable object.</summary>
/// <param name="dx">The x step relative amount, from 0 to 1.</param>
/// <param name="dy">The y step relative amount, from 0 to 1.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetDragStep( double dx,  double dy);
    /// <summary>Gets the x,y page step increments for the draggable object.</summary>
/// <param name="dx">The x page step increment</param>
/// <param name="dy">The y page step increment</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool GetDragPage( out double dx,  out double dy);
    /// <summary>Sets the x,y page step increment values.</summary>
/// <param name="dx">The x page step increment</param>
/// <param name="dy">The y page step increment</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool SetDragPage( double dx,  double dy);
    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
/// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.IDrag.GetDragStep"/>.
/// 
/// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.</summary>
/// <param name="dx">The number of steps horizontally.</param>
/// <param name="dy">The number of steps vertically.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool MoveDragStep( double dx,  double dy);
    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
/// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.IDrag.GetDragPage"/>.
/// 
/// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
/// 
/// Warning: Paging is bugged!</summary>
/// <param name="dx">The number of pages horizontally.</param>
/// <param name="dy">The number of pages vertically.</param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool MoveDragPage( double dx,  double dy);
                                                /// <summary>Determines the draggable directions (read-only).
/// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.</summary>
/// <value>The direction(s) premitted for drag.</value>
    Efl.Ui.DragDir DragDir {
        get ;
    }
}
/// <summary>Common interface for draggable objects and parts.</summary>
sealed public class IDragConcrete : 

IDrag
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IDragConcrete))
                return Efl.Ui.IDragNativeInherit.GetEflClassStatic();
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
    private IDragConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IDragConcrete()
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
    }
    /// <summary>Gets the draggable object location.</summary>
    /// <param name="dx">The x relative position, from 0 to 1.</param>
    /// <param name="dy">The y relative position, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool GetDragValue( out double dx,  out double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_value_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sets the draggable object location.
    /// This places the draggable object at the given location.</summary>
    /// <param name="dx">The x relative position, from 0 to 1.</param>
    /// <param name="dy">The y relative position, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetDragValue( double dx,  double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_value_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets the size of the dradgable object.</summary>
    /// <param name="dw">The drag relative width, from 0 to 1.</param>
    /// <param name="dh">The drag relative height, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool GetDragSize( out double dw,  out double dh) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_size_get_ptr.Value.Delegate(this.NativeHandle, out dw,  out dh);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sets the size of the draggable object.</summary>
    /// <param name="dw">The drag relative width, from 0 to 1.</param>
    /// <param name="dh">The drag relative height, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetDragSize( double dw,  double dh) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_size_set_ptr.Value.Delegate(this.NativeHandle, dw,  dh);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets the draggable direction.</summary>
    /// <returns>The direction(s) premitted for drag.</returns>
    public Efl.Ui.DragDir GetDragDir() {
         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_dir_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets the x and y step increments for the draggable object.</summary>
    /// <param name="dx">The x step relative amount, from 0 to 1.</param>
    /// <param name="dy">The y step relative amount, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool GetDragStep( out double dx,  out double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_step_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sets the x,y step increments for a draggable object.</summary>
    /// <param name="dx">The x step relative amount, from 0 to 1.</param>
    /// <param name="dy">The y step relative amount, from 0 to 1.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetDragStep( double dx,  double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_step_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets the x,y page step increments for the draggable object.</summary>
    /// <param name="dx">The x page step increment</param>
    /// <param name="dy">The y page step increment</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool GetDragPage( out double dx,  out double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_page_get_ptr.Value.Delegate(this.NativeHandle, out dx,  out dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sets the x,y page step increment values.</summary>
    /// <param name="dx">The x page step increment</param>
    /// <param name="dy">The y page step increment</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool SetDragPage( double dx,  double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_page_set_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> steps.
    /// This moves the draggable part by <c>dx</c>,<c>dy</c> steps where the step increment is the amount set by <see cref="Efl.Ui.IDrag.GetDragStep"/>.
    /// 
    /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.</summary>
    /// <param name="dx">The number of steps horizontally.</param>
    /// <param name="dy">The number of steps vertically.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool MoveDragStep( double dx,  double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_step_move_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Moves the draggable by <c>dx</c>,<c>dy</c> pages.
    /// This moves the draggable by <c>dx</c>,<c>dy</c> pages. The increment is defined by <see cref="Efl.Ui.IDrag.GetDragPage"/>.
    /// 
    /// <c>dx</c> and <c>dy</c> can be positive or negative numbers, integer values are recommended.
    /// 
    /// Warning: Paging is bugged!</summary>
    /// <param name="dx">The number of pages horizontally.</param>
    /// <param name="dy">The number of pages vertically.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool MoveDragPage( double dx,  double dy) {
                                                         var _ret_var = Efl.Ui.IDragNativeInherit.efl_ui_drag_page_move_ptr.Value.Delegate(this.NativeHandle, dx,  dy);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Determines the draggable directions (read-only).
/// The draggable directions are defined in the EDC file, inside the &quot;draggable&quot; section, by the attributes <c>x</c> and <c>y</c>. See the EDC reference documentation for more information.</summary>
/// <value>The direction(s) premitted for drag.</value>
    public Efl.Ui.DragDir DragDir {
        get { return GetDragDir(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDragConcrete.efl_ui_drag_interface_get();
    }
}
public class IDragNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_drag_value_get_static_delegate == null)
            efl_ui_drag_value_get_static_delegate = new efl_ui_drag_value_get_delegate(drag_value_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_get_static_delegate)});
        if (efl_ui_drag_value_set_static_delegate == null)
            efl_ui_drag_value_set_static_delegate = new efl_ui_drag_value_set_delegate(drag_value_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragValue") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_value_set_static_delegate)});
        if (efl_ui_drag_size_get_static_delegate == null)
            efl_ui_drag_size_get_static_delegate = new efl_ui_drag_size_get_delegate(drag_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_get_static_delegate)});
        if (efl_ui_drag_size_set_static_delegate == null)
            efl_ui_drag_size_set_static_delegate = new efl_ui_drag_size_set_delegate(drag_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_size_set_static_delegate)});
        if (efl_ui_drag_dir_get_static_delegate == null)
            efl_ui_drag_dir_get_static_delegate = new efl_ui_drag_dir_get_delegate(drag_dir_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragDir") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_dir_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_dir_get_static_delegate)});
        if (efl_ui_drag_step_get_static_delegate == null)
            efl_ui_drag_step_get_static_delegate = new efl_ui_drag_step_get_delegate(drag_step_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragStep") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_get_static_delegate)});
        if (efl_ui_drag_step_set_static_delegate == null)
            efl_ui_drag_step_set_static_delegate = new efl_ui_drag_step_set_delegate(drag_step_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragStep") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_set_static_delegate)});
        if (efl_ui_drag_page_get_static_delegate == null)
            efl_ui_drag_page_get_static_delegate = new efl_ui_drag_page_get_delegate(drag_page_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragPage") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_get_static_delegate)});
        if (efl_ui_drag_page_set_static_delegate == null)
            efl_ui_drag_page_set_static_delegate = new efl_ui_drag_page_set_delegate(drag_page_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragPage") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_set_static_delegate)});
        if (efl_ui_drag_step_move_static_delegate == null)
            efl_ui_drag_step_move_static_delegate = new efl_ui_drag_step_move_delegate(drag_step_move);
        if (methods.FirstOrDefault(m => m.Name == "MoveDragStep") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_step_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_step_move_static_delegate)});
        if (efl_ui_drag_page_move_static_delegate == null)
            efl_ui_drag_page_move_static_delegate = new efl_ui_drag_page_move_delegate(drag_page_move);
        if (methods.FirstOrDefault(m => m.Name == "MoveDragPage") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_drag_page_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_drag_page_move_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IDragConcrete.efl_ui_drag_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDragConcrete.efl_ui_drag_interface_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_drag_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double dx,   out double dy);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_drag_value_get_api_delegate(System.IntPtr obj,   out double dx,   out double dy);
     public static Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate> efl_ui_drag_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_drag_value_get_api_delegate>(_Module, "efl_ui_drag_value_get");
     private static bool drag_value_get(System.IntPtr obj, System.IntPtr pd,  out double dx,  out double dy)
    {
        Eina.Log.Debug("function efl_ui_drag_value_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    dx = default(double);        dy = default(double);                            bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).GetDragValue( out dx,  out dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).SetDragValue( dx,  dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    dw = default(double);        dh = default(double);                            bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).GetDragSize( out dw,  out dh);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).SetDragSize( dw,  dh);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.DragDir _ret_var = default(Efl.Ui.DragDir);
            try {
                _ret_var = ((IDrag)wrapper).GetDragDir();
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    dx = default(double);        dy = default(double);                            bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).GetDragStep( out dx,  out dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).SetDragStep( dx,  dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    dx = default(double);        dy = default(double);                            bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).GetDragPage( out dx,  out dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).SetDragPage( dx,  dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).MoveDragStep( dx,  dy);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IDrag)wrapper).MoveDragPage( dx,  dy);
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
