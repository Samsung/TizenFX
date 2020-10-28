#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[SelectionManagerNativeInherit]
public class SelectionManager : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (SelectionManager))
                return Efl.Ui.SelectionManagerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selection_manager_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public SelectionManager(Efl.Object parent= null
            ) :
        base(efl_ui_selection_manager_class_get(), typeof(SelectionManager), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected SelectionManager(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected SelectionManager(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Set selection</summary>
    /// <param name="owner">Seleciton owner</param>
    /// <param name="type">Selection type</param>
    /// <param name="format">Selection format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>Future for tracking when the selection is lost</returns>
    virtual public  Eina.Future SetSelection( Efl.Object owner,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat) {
                                                                                                                                 var _ret_var = Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_selection_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), owner,  type,  format,  data,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Get selection</summary>
    /// <param name="request">Seleciton owner</param>
    /// <param name="type">Selection type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data_func">Data ready function pointer</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void GetSelection( Efl.Object request,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,  uint seat) {
                                                                                                                 GCHandle data_func_handle = GCHandle.Alloc(data_func);
                Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_selection_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), request,  type,  format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary></summary>
    /// <param name="owner">Seleciton owner</param>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void ClearSelection( Efl.Object owner,  Efl.Ui.SelectionType type,  uint seat) {
                                                                                 Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_selection_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), owner,  type,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Check if the request object has selection or not</summary>
    /// <param name="request">Request object</param>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>EINA_TRUE if the request object has selection, otherwise, EINA_FALSE</returns>
    virtual public bool SelectionHasOwner( Efl.Object request,  Efl.Ui.SelectionType type,  uint seat) {
                                                                                 var _ret_var = Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_selection_has_owner_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), request,  type,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>This starts a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
    /// <param name="drag_obj">Drag object</param>
    /// <param name="format">Data format</param>
    /// <param name="data">Data to transfer</param>
    /// <param name="action">Action when data is transferred</param>
    /// <param name="icon_func">Function pointer to create icon</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void DragStart( Efl.Object drag_obj,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  Efl.Dnd.DragIconCreate icon_func,  uint seat) {
                                                                                                                                         GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
                Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_drag_start_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), drag_obj,  format,  data,  action, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>This sets the action for the drag</summary>
    /// <param name="drag_obj">Drag object</param>
    /// <param name="action">Drag action</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void SetDragAction( Efl.Object drag_obj,  Efl.Ui.SelectionAction action,  uint seat) {
                                                                                 Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_drag_action_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), drag_obj,  action,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This cancels the on-going drag</summary>
    /// <param name="drag_obj">Drag object</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void DragCancel( Efl.Object drag_obj,  uint seat) {
                                                         Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_drag_cancel_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), drag_obj,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This registers a drag for items in a container. Many items can be dragged at a time. During dragging, there are three events emitted: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE.</summary>
    /// <param name="cont">Container object</param>
    /// <param name="time_to_drag">Time since mouse down happens to drag starts</param>
    /// <param name="anim_duration">animation duration</param>
    /// <param name="data_func">Data and its format</param>
    /// <param name="item_func">Item to determine drag start</param>
    /// <param name="icon_func">Icon used during drag</param>
    /// <param name="icon_list_func">Icons used for animations</param>
    /// <param name="seat">Specified seat for multiple seats case</param>
    /// <returns></returns>
    virtual public void AddContainerDragItem( Efl.Object cont,  double time_to_drag,  double anim_duration,  Efl.Dnd.DragDataGet data_func,  Efl.Dnd.ItemGet item_func,  Efl.Dnd.DragIconCreate icon_func,  Efl.Dnd.DragIconListCreate icon_list_func,  uint seat) {
                                                                                                                                                                 GCHandle data_func_handle = GCHandle.Alloc(data_func);
        GCHandle item_func_handle = GCHandle.Alloc(item_func);
        GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
        GCHandle icon_list_func_handle = GCHandle.Alloc(icon_list_func);
                Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_container_drag_item_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cont,  time_to_drag,  anim_duration, GCHandle.ToIntPtr(data_func_handle), Efl.Dnd.DragDataGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(icon_list_func_handle), Efl.Dnd.DragIconListCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                         }
    /// <summary>Remove drag function of items in the container object.</summary>
    /// <param name="cont">Container object</param>
    /// <param name="seat">Specified seat for multiple seats case</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool DelContainerDragItem( Efl.Object cont,  uint seat) {
                                                         var _ret_var = Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_container_drag_item_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cont,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Add a dropable target. There are four events emitted: - EFL_UI_DND_DROP_DRAG_ENTER - EFL_UI_DND_DROP_DRAG_LEAVE - EFL_UI_DND_DROP_DRAG_POS - EFL_UI_DND_DROP_DRAG_DROP.</summary>
    /// <param name="target_obj">Drop target</param>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool AddDropTarget( Efl.Object target_obj,  Efl.Ui.SelectionFormat format,  uint seat) {
                                                                                 var _ret_var = Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_drop_target_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), target_obj,  format,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Remove a dropable target</summary>
    /// <param name="target_obj">Drop target</param>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void DelDropTarget( Efl.Object target_obj,  Efl.Ui.SelectionFormat format,  uint seat) {
                                                                                 Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_drop_target_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), target_obj,  format,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Add dropable target for a container in which items can drop to it</summary>
    /// <param name="cont">Container object</param>
    /// <param name="format">Accepted data formats</param>
    /// <param name="item_func">Get item at specific position</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    virtual public void AddContainerDropItem( Efl.Object cont,  Efl.Ui.SelectionFormat format,  Efl.Dnd.ItemGet item_func,  uint seat) {
                                                                                         GCHandle item_func_handle = GCHandle.Alloc(item_func);
                Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_container_drop_item_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cont,  format, GCHandle.ToIntPtr(item_func_handle), Efl.Dnd.ItemGetWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Remove dropable target for the container</summary>
    /// <param name="cont">Container object</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool DelContainerDropItem( Efl.Object cont,  uint seat) {
                                                         var _ret_var = Efl.Ui.SelectionManagerNativeInherit.efl_ui_selection_manager_container_drop_item_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cont,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Object owner, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetSelection(  owner,  type,  format,  data,  seat);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SelectionManager.efl_ui_selection_manager_class_get();
    }
}
public class SelectionManagerNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_selection_manager_selection_set_static_delegate == null)
            efl_ui_selection_manager_selection_set_static_delegate = new efl_ui_selection_manager_selection_set_delegate(selection_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_selection_set_static_delegate)});
        if (efl_ui_selection_manager_selection_get_static_delegate == null)
            efl_ui_selection_manager_selection_get_static_delegate = new efl_ui_selection_manager_selection_get_delegate(selection_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_selection_get_static_delegate)});
        if (efl_ui_selection_manager_selection_clear_static_delegate == null)
            efl_ui_selection_manager_selection_clear_static_delegate = new efl_ui_selection_manager_selection_clear_delegate(selection_clear);
        if (methods.FirstOrDefault(m => m.Name == "ClearSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_selection_clear_static_delegate)});
        if (efl_ui_selection_manager_selection_has_owner_static_delegate == null)
            efl_ui_selection_manager_selection_has_owner_static_delegate = new efl_ui_selection_manager_selection_has_owner_delegate(selection_has_owner);
        if (methods.FirstOrDefault(m => m.Name == "SelectionHasOwner") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_selection_has_owner_static_delegate)});
        if (efl_ui_selection_manager_drag_start_static_delegate == null)
            efl_ui_selection_manager_drag_start_static_delegate = new efl_ui_selection_manager_drag_start_delegate(drag_start);
        if (methods.FirstOrDefault(m => m.Name == "DragStart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_drag_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_drag_start_static_delegate)});
        if (efl_ui_selection_manager_drag_action_set_static_delegate == null)
            efl_ui_selection_manager_drag_action_set_static_delegate = new efl_ui_selection_manager_drag_action_set_delegate(drag_action_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragAction") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_drag_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_drag_action_set_static_delegate)});
        if (efl_ui_selection_manager_drag_cancel_static_delegate == null)
            efl_ui_selection_manager_drag_cancel_static_delegate = new efl_ui_selection_manager_drag_cancel_delegate(drag_cancel);
        if (methods.FirstOrDefault(m => m.Name == "DragCancel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_drag_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_drag_cancel_static_delegate)});
        if (efl_ui_selection_manager_container_drag_item_add_static_delegate == null)
            efl_ui_selection_manager_container_drag_item_add_static_delegate = new efl_ui_selection_manager_container_drag_item_add_delegate(container_drag_item_add);
        if (methods.FirstOrDefault(m => m.Name == "AddContainerDragItem") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_container_drag_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_container_drag_item_add_static_delegate)});
        if (efl_ui_selection_manager_container_drag_item_del_static_delegate == null)
            efl_ui_selection_manager_container_drag_item_del_static_delegate = new efl_ui_selection_manager_container_drag_item_del_delegate(container_drag_item_del);
        if (methods.FirstOrDefault(m => m.Name == "DelContainerDragItem") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_container_drag_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_container_drag_item_del_static_delegate)});
        if (efl_ui_selection_manager_drop_target_add_static_delegate == null)
            efl_ui_selection_manager_drop_target_add_static_delegate = new efl_ui_selection_manager_drop_target_add_delegate(drop_target_add);
        if (methods.FirstOrDefault(m => m.Name == "AddDropTarget") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_drop_target_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_drop_target_add_static_delegate)});
        if (efl_ui_selection_manager_drop_target_del_static_delegate == null)
            efl_ui_selection_manager_drop_target_del_static_delegate = new efl_ui_selection_manager_drop_target_del_delegate(drop_target_del);
        if (methods.FirstOrDefault(m => m.Name == "DelDropTarget") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_drop_target_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_drop_target_del_static_delegate)});
        if (efl_ui_selection_manager_container_drop_item_add_static_delegate == null)
            efl_ui_selection_manager_container_drop_item_add_static_delegate = new efl_ui_selection_manager_container_drop_item_add_delegate(container_drop_item_add);
        if (methods.FirstOrDefault(m => m.Name == "AddContainerDropItem") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_container_drop_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_container_drop_item_add_static_delegate)});
        if (efl_ui_selection_manager_container_drop_item_del_static_delegate == null)
            efl_ui_selection_manager_container_drop_item_del_static_delegate = new efl_ui_selection_manager_container_drop_item_del_delegate(container_drop_item_del);
        if (methods.FirstOrDefault(m => m.Name == "DelContainerDropItem") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_manager_container_drop_item_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_manager_container_drop_item_del_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.SelectionManager.efl_ui_selection_manager_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SelectionManager.efl_ui_selection_manager_class_get();
    }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_selection_manager_selection_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object owner,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   uint seat);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_ui_selection_manager_selection_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object owner,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_set_api_delegate> efl_ui_selection_manager_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_set_api_delegate>(_Module, "efl_ui_selection_manager_selection_set");
     private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object owner,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_selection_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                 Eina.Future _ret_var = default( Eina.Future);
            try {
                _ret_var = ((SelectionManager)wrapper).SetSelection( owner,  type,  format,  data,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                        return _ret_var;
        } else {
            return efl_ui_selection_manager_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  owner,  type,  format,  data,  seat);
        }
    }
    private static efl_ui_selection_manager_selection_set_delegate efl_ui_selection_manager_selection_set_static_delegate;


     private delegate void efl_ui_selection_manager_selection_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object request,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat);


     public delegate void efl_ui_selection_manager_selection_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object request,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_get_api_delegate> efl_ui_selection_manager_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_get_api_delegate>(_Module, "efl_ui_selection_manager_selection_get");
     private static void selection_get(System.IntPtr obj, System.IntPtr pd,  Efl.Object request,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_selection_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
                    
            try {
                ((SelectionManager)wrapper).GetSelection( request,  type,  format,  data_func_wrapper.ManagedCb,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                } else {
            efl_ui_selection_manager_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  request,  type,  format, data_func_data, data_func, data_func_free_cb,  seat);
        }
    }
    private static efl_ui_selection_manager_selection_get_delegate efl_ui_selection_manager_selection_get_static_delegate;


     private delegate void efl_ui_selection_manager_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object owner,   Efl.Ui.SelectionType type,   uint seat);


     public delegate void efl_ui_selection_manager_selection_clear_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object owner,   Efl.Ui.SelectionType type,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_clear_api_delegate> efl_ui_selection_manager_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_clear_api_delegate>(_Module, "efl_ui_selection_manager_selection_clear");
     private static void selection_clear(System.IntPtr obj, System.IntPtr pd,  Efl.Object owner,  Efl.Ui.SelectionType type,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_selection_clear was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((SelectionManager)wrapper).ClearSelection( owner,  type,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_selection_manager_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  owner,  type,  seat);
        }
    }
    private static efl_ui_selection_manager_selection_clear_delegate efl_ui_selection_manager_selection_clear_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_manager_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object request,   Efl.Ui.SelectionType type,   uint seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_selection_manager_selection_has_owner_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object request,   Efl.Ui.SelectionType type,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_has_owner_api_delegate> efl_ui_selection_manager_selection_has_owner_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_selection_has_owner_api_delegate>(_Module, "efl_ui_selection_manager_selection_has_owner");
     private static bool selection_has_owner(System.IntPtr obj, System.IntPtr pd,  Efl.Object request,  Efl.Ui.SelectionType type,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_selection_has_owner was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((SelectionManager)wrapper).SelectionHasOwner( request,  type,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_ui_selection_manager_selection_has_owner_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  request,  type,  seat);
        }
    }
    private static efl_ui_selection_manager_selection_has_owner_delegate efl_ui_selection_manager_selection_has_owner_static_delegate;


     private delegate void efl_ui_selection_manager_drag_start_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,   uint seat);


     public delegate void efl_ui_selection_manager_drag_start_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_start_api_delegate> efl_ui_selection_manager_drag_start_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_start_api_delegate>(_Module, "efl_ui_selection_manager_drag_start");
     private static void drag_start(System.IntPtr obj, System.IntPtr pd,  Efl.Object drag_obj,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_drag_start was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                        Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
                    
            try {
                ((SelectionManager)wrapper).DragStart( drag_obj,  format,  data,  action,  icon_func_wrapper.ManagedCb,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                } else {
            efl_ui_selection_manager_drag_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  drag_obj,  format,  data,  action, icon_func_data, icon_func, icon_func_free_cb,  seat);
        }
    }
    private static efl_ui_selection_manager_drag_start_delegate efl_ui_selection_manager_drag_start_static_delegate;


     private delegate void efl_ui_selection_manager_drag_action_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   Efl.Ui.SelectionAction action,   uint seat);


     public delegate void efl_ui_selection_manager_drag_action_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   Efl.Ui.SelectionAction action,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_action_set_api_delegate> efl_ui_selection_manager_drag_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_action_set_api_delegate>(_Module, "efl_ui_selection_manager_drag_action_set");
     private static void drag_action_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object drag_obj,  Efl.Ui.SelectionAction action,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_drag_action_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((SelectionManager)wrapper).SetDragAction( drag_obj,  action,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_selection_manager_drag_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  drag_obj,  action,  seat);
        }
    }
    private static efl_ui_selection_manager_drag_action_set_delegate efl_ui_selection_manager_drag_action_set_static_delegate;


     private delegate void efl_ui_selection_manager_drag_cancel_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   uint seat);


     public delegate void efl_ui_selection_manager_drag_cancel_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object drag_obj,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_cancel_api_delegate> efl_ui_selection_manager_drag_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drag_cancel_api_delegate>(_Module, "efl_ui_selection_manager_drag_cancel");
     private static void drag_cancel(System.IntPtr obj, System.IntPtr pd,  Efl.Object drag_obj,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_drag_cancel was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((SelectionManager)wrapper).DragCancel( drag_obj,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_selection_manager_drag_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  drag_obj,  seat);
        }
    }
    private static efl_ui_selection_manager_drag_cancel_delegate efl_ui_selection_manager_drag_cancel_static_delegate;


     private delegate void efl_ui_selection_manager_container_drag_item_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   double time_to_drag,   double anim_duration,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,   uint seat);


     public delegate void efl_ui_selection_manager_container_drag_item_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   double time_to_drag,   double anim_duration,  IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drag_item_add_api_delegate> efl_ui_selection_manager_container_drag_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drag_item_add_api_delegate>(_Module, "efl_ui_selection_manager_container_drag_item_add");
     private static void container_drag_item_add(System.IntPtr obj, System.IntPtr pd,  Efl.Object cont,  double time_to_drag,  double anim_duration, IntPtr data_func_data, Efl.Dnd.DragDataGetInternal data_func, EinaFreeCb data_func_free_cb, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb, IntPtr icon_list_func_data, Efl.Dnd.DragIconListCreateInternal icon_list_func, EinaFreeCb icon_list_func_free_cb,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_container_drag_item_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                                                Efl.Dnd.DragDataGetWrapper data_func_wrapper = new Efl.Dnd.DragDataGetWrapper(data_func, data_func_data, data_func_free_cb);
            Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
            Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
            Efl.Dnd.DragIconListCreateWrapper icon_list_func_wrapper = new Efl.Dnd.DragIconListCreateWrapper(icon_list_func, icon_list_func_data, icon_list_func_free_cb);
                    
            try {
                ((SelectionManager)wrapper).AddContainerDragItem( cont,  time_to_drag,  anim_duration,  data_func_wrapper.ManagedCb,  item_func_wrapper.ManagedCb,  icon_func_wrapper.ManagedCb,  icon_list_func_wrapper.ManagedCb,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                                                } else {
            efl_ui_selection_manager_container_drag_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cont,  time_to_drag,  anim_duration, data_func_data, data_func, data_func_free_cb, item_func_data, item_func, item_func_free_cb, icon_func_data, icon_func, icon_func_free_cb, icon_list_func_data, icon_list_func, icon_list_func_free_cb,  seat);
        }
    }
    private static efl_ui_selection_manager_container_drag_item_add_delegate efl_ui_selection_manager_container_drag_item_add_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_manager_container_drag_item_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   uint seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_selection_manager_container_drag_item_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drag_item_del_api_delegate> efl_ui_selection_manager_container_drag_item_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drag_item_del_api_delegate>(_Module, "efl_ui_selection_manager_container_drag_item_del");
     private static bool container_drag_item_del(System.IntPtr obj, System.IntPtr pd,  Efl.Object cont,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_container_drag_item_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((SelectionManager)wrapper).DelContainerDragItem( cont,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_ui_selection_manager_container_drag_item_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cont,  seat);
        }
    }
    private static efl_ui_selection_manager_container_drag_item_del_delegate efl_ui_selection_manager_container_drag_item_del_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_manager_drop_target_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object target_obj,   Efl.Ui.SelectionFormat format,   uint seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_selection_manager_drop_target_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object target_obj,   Efl.Ui.SelectionFormat format,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drop_target_add_api_delegate> efl_ui_selection_manager_drop_target_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drop_target_add_api_delegate>(_Module, "efl_ui_selection_manager_drop_target_add");
     private static bool drop_target_add(System.IntPtr obj, System.IntPtr pd,  Efl.Object target_obj,  Efl.Ui.SelectionFormat format,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_drop_target_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((SelectionManager)wrapper).AddDropTarget( target_obj,  format,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_ui_selection_manager_drop_target_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  target_obj,  format,  seat);
        }
    }
    private static efl_ui_selection_manager_drop_target_add_delegate efl_ui_selection_manager_drop_target_add_static_delegate;


     private delegate void efl_ui_selection_manager_drop_target_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object target_obj,   Efl.Ui.SelectionFormat format,   uint seat);


     public delegate void efl_ui_selection_manager_drop_target_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object target_obj,   Efl.Ui.SelectionFormat format,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drop_target_del_api_delegate> efl_ui_selection_manager_drop_target_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_drop_target_del_api_delegate>(_Module, "efl_ui_selection_manager_drop_target_del");
     private static void drop_target_del(System.IntPtr obj, System.IntPtr pd,  Efl.Object target_obj,  Efl.Ui.SelectionFormat format,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_drop_target_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((SelectionManager)wrapper).DelDropTarget( target_obj,  format,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_selection_manager_drop_target_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  target_obj,  format,  seat);
        }
    }
    private static efl_ui_selection_manager_drop_target_del_delegate efl_ui_selection_manager_drop_target_del_static_delegate;


     private delegate void efl_ui_selection_manager_container_drop_item_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,   uint seat);


     public delegate void efl_ui_selection_manager_container_drop_item_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   Efl.Ui.SelectionFormat format,  IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drop_item_add_api_delegate> efl_ui_selection_manager_container_drop_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drop_item_add_api_delegate>(_Module, "efl_ui_selection_manager_container_drop_item_add");
     private static void container_drop_item_add(System.IntPtr obj, System.IntPtr pd,  Efl.Object cont,  Efl.Ui.SelectionFormat format, IntPtr item_func_data, Efl.Dnd.ItemGetInternal item_func, EinaFreeCb item_func_free_cb,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_container_drop_item_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                        Efl.Dnd.ItemGetWrapper item_func_wrapper = new Efl.Dnd.ItemGetWrapper(item_func, item_func_data, item_func_free_cb);
                    
            try {
                ((SelectionManager)wrapper).AddContainerDropItem( cont,  format,  item_func_wrapper.ManagedCb,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_ui_selection_manager_container_drop_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cont,  format, item_func_data, item_func, item_func_free_cb,  seat);
        }
    }
    private static efl_ui_selection_manager_container_drop_item_add_delegate efl_ui_selection_manager_container_drop_item_add_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_manager_container_drop_item_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   uint seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_selection_manager_container_drop_item_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object cont,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drop_item_del_api_delegate> efl_ui_selection_manager_container_drop_item_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_manager_container_drop_item_del_api_delegate>(_Module, "efl_ui_selection_manager_container_drop_item_del");
     private static bool container_drop_item_del(System.IntPtr obj, System.IntPtr pd,  Efl.Object cont,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_manager_container_drop_item_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((SelectionManager)wrapper).DelContainerDropItem( cont,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_ui_selection_manager_container_drop_item_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cont,  seat);
        }
    }
    private static efl_ui_selection_manager_container_drop_item_del_delegate efl_ui_selection_manager_container_drop_item_del_static_delegate;
}
} } 
