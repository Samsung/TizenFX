#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[Efl.Ui.IDndConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IDnd : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
/// <param name="format">The data format</param>
/// <param name="data">The drag data</param>
/// <param name="action">Action when data is transferred</param>
/// <param name="icon_func">Function pointer to create icon</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void DragStart(Efl.Ui.SelectionFormat format, Eina.Slice data, Efl.Ui.SelectionAction action, Efl.Dnd.DragIconCreate icon_func, uint seat);
    /// <summary>Set the action for the drag</summary>
/// <param name="action">Drag action</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void SetDragAction(Efl.Ui.SelectionAction action, uint seat);
    /// <summary>Cancel the on-going drag</summary>
/// <param name="seat">Specified seat for multiple seats case.</param>
void DragCancel(uint seat);
    /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
/// <param name="format">Accepted data format</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void AddDropTarget(Efl.Ui.SelectionFormat format, uint seat);
    /// <summary>Delete the dropable status from object</summary>
/// <param name="format">Accepted data format</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
void DelDropTarget(Efl.Ui.SelectionFormat format, uint seat);
                        /// <summary>accept drag data</summary>
    event EventHandler<Efl.Ui.IDndDragAcceptEvt_Args> DragAcceptEvt;
    /// <summary>drag is done (mouse up)</summary>
    event EventHandler DragDoneEvt;
    /// <summary>called when the drag object enters this object</summary>
    event EventHandler DragEnterEvt;
    /// <summary>called when the drag object leaves this object</summary>
    event EventHandler DragLeaveEvt;
    /// <summary>called when the drag object changes drag position</summary>
    event EventHandler<Efl.Ui.IDndDragPosEvt_Args> DragPosEvt;
    /// <summary>called when the drag object dropped on this object</summary>
    event EventHandler<Efl.Ui.IDndDragDropEvt_Args> DragDropEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDnd.DragAcceptEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IDndDragAcceptEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDnd.DragPosEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IDndDragPosEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Dnd.DragPos arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDnd.DragDropEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IDndDragDropEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.SelectionData arg { get; set; }
}
sealed public class IDndConcrete :
    Efl.Eo.EoWrapper
    , IDnd
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IDndConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IDndConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_dnd_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IDnd"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IDndConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>accept drag data</summary>
    public event EventHandler<Efl.Ui.IDndDragAcceptEvt_Args> DragAcceptEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDndDragAcceptEvt_Args args = new Efl.Ui.IDndDragAcceptEvt_Args();
                        args.arg = (bool)Marshal.PtrToStructure(evt.Info, typeof(bool));
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragAcceptEvt.</summary>
    public void OnDragAcceptEvt(Efl.Ui.IDndDragAcceptEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>drag is done (mouse up)</summary>
    public event EventHandler DragDoneEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragDoneEvt.</summary>
    public void OnDragDoneEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object enters this object</summary>
    public event EventHandler DragEnterEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragEnterEvt.</summary>
    public void OnDragEnterEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object leaves this object</summary>
    public event EventHandler DragLeaveEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragLeaveEvt.</summary>
    public void OnDragLeaveEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object changes drag position</summary>
    public event EventHandler<Efl.Ui.IDndDragPosEvt_Args> DragPosEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDndDragPosEvt_Args args = new Efl.Ui.IDndDragPosEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_POS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_POS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragPosEvt.</summary>
    public void OnDragPosEvt(Efl.Ui.IDndDragPosEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_POS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>called when the drag object dropped on this object</summary>
    public event EventHandler<Efl.Ui.IDndDragDropEvt_Args> DragDropEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDndDragDropEvt_Args args = new Efl.Ui.IDndDragDropEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragDropEvt.</summary>
    public void OnDragDropEvt(Efl.Ui.IDndDragDropEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_DROP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
    /// <param name="format">The data format</param>
    /// <param name="data">The drag data</param>
    /// <param name="action">Action when data is transferred</param>
    /// <param name="icon_func">Function pointer to create icon</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void DragStart(Efl.Ui.SelectionFormat format, Eina.Slice data, Efl.Ui.SelectionAction action, Efl.Dnd.DragIconCreate icon_func, uint seat) {
                                                                                                                 GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
                Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_start_ptr.Value.Delegate(this.NativeHandle,format, data, action, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the action for the drag</summary>
    /// <param name="action">Drag action</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void SetDragAction(Efl.Ui.SelectionAction action, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_action_set_ptr.Value.Delegate(this.NativeHandle,action, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Cancel the on-going drag</summary>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void DragCancel(uint seat) {
                                 Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_cancel_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void AddDropTarget(Efl.Ui.SelectionFormat format, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drop_target_add_ptr.Value.Delegate(this.NativeHandle,format, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Delete the dropable status from object</summary>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    public void DelDropTarget(Efl.Ui.SelectionFormat format, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drop_target_del_ptr.Value.Delegate(this.NativeHandle,format, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDndConcrete.efl_ui_dnd_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_dnd_drag_start_static_delegate == null)
            {
                efl_ui_dnd_drag_start_static_delegate = new efl_ui_dnd_drag_start_delegate(drag_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "DragStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_start_static_delegate) });
            }

            if (efl_ui_dnd_drag_action_set_static_delegate == null)
            {
                efl_ui_dnd_drag_action_set_static_delegate = new efl_ui_dnd_drag_action_set_delegate(drag_action_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDragAction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_action_set_static_delegate) });
            }

            if (efl_ui_dnd_drag_cancel_static_delegate == null)
            {
                efl_ui_dnd_drag_cancel_static_delegate = new efl_ui_dnd_drag_cancel_delegate(drag_cancel);
            }

            if (methods.FirstOrDefault(m => m.Name == "DragCancel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_cancel_static_delegate) });
            }

            if (efl_ui_dnd_drop_target_add_static_delegate == null)
            {
                efl_ui_dnd_drop_target_add_static_delegate = new efl_ui_dnd_drop_target_add_delegate(drop_target_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddDropTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drop_target_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_add_static_delegate) });
            }

            if (efl_ui_dnd_drop_target_del_static_delegate == null)
            {
                efl_ui_dnd_drop_target_del_static_delegate = new efl_ui_dnd_drop_target_del_delegate(drop_target_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelDropTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drop_target_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_del_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IDndConcrete.efl_ui_dnd_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_dnd_drag_start_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  uint seat);

        
        public delegate void efl_ui_dnd_drag_start_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate> efl_ui_dnd_drag_start_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate>(Module, "efl_ui_dnd_drag_start");

        private static void drag_start(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, Eina.Slice data, Efl.Ui.SelectionAction action, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                    Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
                    
                try
                {
                    ((IDnd)ws.Target).DragStart(format, data, action, icon_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_dnd_drag_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, data, action, icon_func_data, icon_func, icon_func_free_cb, seat);
            }
        }

        private static efl_ui_dnd_drag_start_delegate efl_ui_dnd_drag_start_static_delegate;

        
        private delegate void efl_ui_dnd_drag_action_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionAction action,  uint seat);

        
        public delegate void efl_ui_dnd_drag_action_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionAction action,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate> efl_ui_dnd_drag_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate>(Module, "efl_ui_dnd_drag_action_set");

        private static void drag_action_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionAction action, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_action_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IDnd)ws.Target).SetDragAction(action, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drag_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), action, seat);
            }
        }

        private static efl_ui_dnd_drag_action_set_delegate efl_ui_dnd_drag_action_set_static_delegate;

        
        private delegate void efl_ui_dnd_drag_cancel_delegate(System.IntPtr obj, System.IntPtr pd,  uint seat);

        
        public delegate void efl_ui_dnd_drag_cancel_api_delegate(System.IntPtr obj,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate> efl_ui_dnd_drag_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate>(Module, "efl_ui_dnd_drag_cancel");

        private static void drag_cancel(System.IntPtr obj, System.IntPtr pd, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_cancel was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IDnd)ws.Target).DragCancel(seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_dnd_drag_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_ui_dnd_drag_cancel_delegate efl_ui_dnd_drag_cancel_static_delegate;

        
        private delegate void efl_ui_dnd_drop_target_add_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  uint seat);

        
        public delegate void efl_ui_dnd_drop_target_add_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate> efl_ui_dnd_drop_target_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate>(Module, "efl_ui_dnd_drop_target_add");

        private static void drop_target_add(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drop_target_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IDnd)ws.Target).AddDropTarget(format, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drop_target_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, seat);
            }
        }

        private static efl_ui_dnd_drop_target_add_delegate efl_ui_dnd_drop_target_add_static_delegate;

        
        private delegate void efl_ui_dnd_drop_target_del_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  uint seat);

        
        public delegate void efl_ui_dnd_drop_target_del_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate> efl_ui_dnd_drop_target_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate>(Module, "efl_ui_dnd_drop_target_del");

        private static void drop_target_del(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drop_target_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IDnd)ws.Target).DelDropTarget(format, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drop_target_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, seat);
            }
        }

        private static efl_ui_dnd_drop_target_del_delegate efl_ui_dnd_drop_target_del_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

