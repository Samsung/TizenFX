#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Efl UI draggable interface</summary>
[Efl.Ui.IDraggableConcrete.NativeMethods]
public interface IDraggable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
/// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
/// <returns>Turn on or off drop_target. Default is <c>false</c>.</returns>
bool GetDragTarget();
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
/// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
/// <param name="set">Turn on or off drop_target. Default is <c>false</c>.</param>
void SetDragTarget(bool set);
            /// <summary>Called when drag operation starts</summary>
    event EventHandler<Efl.Ui.IDraggableDragEvt_Args> DragEvt;
    /// <summary>Called when drag started</summary>
    event EventHandler DragStartEvt;
    /// <summary>Called when drag stopped</summary>
    event EventHandler<Efl.Ui.IDraggableDragStopEvt_Args> DragStopEvt;
    /// <summary>Called when drag operation ends</summary>
    event EventHandler DragEndEvt;
    /// <summary>Called when drag starts into up direction</summary>
    event EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args> DragStartUpEvt;
    /// <summary>Called when drag starts into down direction</summary>
    event EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args> DragStartDownEvt;
    /// <summary>Called when drag starts into right direction</summary>
    event EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args> DragStartRightEvt;
    /// <summary>Called when drag starts into left direction</summary>
    event EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args> DragStartLeftEvt;
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <value>Turn on or off drop_target. Default is <c>false</c>.</value>
    bool DragTarget {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragEvt"/>.</summary>
public class IDraggableDragEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragStopEvt"/>.</summary>
public class IDraggableDragStopEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragStartUpEvt"/>.</summary>
public class IDraggableDragStartUpEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragStartDownEvt"/>.</summary>
public class IDraggableDragStartDownEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragStartRightEvt"/>.</summary>
public class IDraggableDragStartRightEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IDraggable.DragStartLeftEvt"/>.</summary>
public class IDraggableDragStartLeftEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
/// <summary>Efl UI draggable interface</summary>
sealed public class IDraggableConcrete :
    Efl.Eo.EoWrapper
    , IDraggable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IDraggableConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_draggable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IDraggable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IDraggableConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Called when drag operation starts</summary>
    public event EventHandler<Efl.Ui.IDraggableDragEvt_Args> DragEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragEvt_Args args = new Efl.Ui.IDraggableDragEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragEvt.</summary>
    public void OnDragEvt(Efl.Ui.IDraggableDragEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag started</summary>
    public event EventHandler DragStartEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_DRAG_START";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStartEvt.</summary>
    public void OnDragStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when drag stopped</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStopEvt_Args> DragStopEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragStopEvt_Args args = new Efl.Ui.IDraggableDragStopEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG_STOP";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_STOP";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStopEvt.</summary>
    public void OnDragStopEvt(Efl.Ui.IDraggableDragStopEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag operation ends</summary>
    public event EventHandler DragEndEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_DRAG_END";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_END";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragEndEvt.</summary>
    public void OnDragEndEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_DRAG_END";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when drag starts into up direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args> DragStartUpEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragStartUpEvt_Args args = new Efl.Ui.IDraggableDragStartUpEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStartUpEvt.</summary>
    public void OnDragStartUpEvt(Efl.Ui.IDraggableDragStartUpEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into down direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args> DragStartDownEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragStartDownEvt_Args args = new Efl.Ui.IDraggableDragStartDownEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStartDownEvt.</summary>
    public void OnDragStartDownEvt(Efl.Ui.IDraggableDragStartDownEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into right direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args> DragStartRightEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragStartRightEvt_Args args = new Efl.Ui.IDraggableDragStartRightEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStartRightEvt.</summary>
    public void OnDragStartRightEvt(Efl.Ui.IDraggableDragStartRightEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into left direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args> DragStartLeftEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IDraggableDragStartLeftEvt_Args args = new Efl.Ui.IDraggableDragStartLeftEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragStartLeftEvt.</summary>
    public void OnDragStartLeftEvt(Efl.Ui.IDraggableDragStartLeftEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <returns>Turn on or off drop_target. Default is <c>false</c>.</returns>
    public bool GetDragTarget() {
         var _ret_var = Efl.Ui.IDraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <param name="set">Turn on or off drop_target. Default is <c>false</c>.</param>
    public void SetDragTarget(bool set) {
                                 Efl.Ui.IDraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_set_ptr.Value.Delegate(this.NativeHandle,set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <value>Turn on or off drop_target. Default is <c>false</c>.</value>
    public bool DragTarget {
        get { return GetDragTarget(); }
        set { SetDragTarget(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDraggableConcrete.efl_ui_draggable_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_draggable_drag_target_get_static_delegate == null)
            {
                efl_ui_draggable_drag_target_get_static_delegate = new efl_ui_draggable_drag_target_get_delegate(drag_target_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDragTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_draggable_drag_target_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_get_static_delegate) });
            }

            if (efl_ui_draggable_drag_target_set_static_delegate == null)
            {
                efl_ui_draggable_drag_target_set_static_delegate = new efl_ui_draggable_drag_target_set_delegate(drag_target_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDragTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_draggable_drag_target_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IDraggableConcrete.efl_ui_draggable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_draggable_drag_target_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_draggable_drag_target_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate> efl_ui_draggable_drag_target_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate>(Module, "efl_ui_draggable_drag_target_get");

        private static bool drag_target_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_draggable_drag_target_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IDraggable)ws.Target).GetDragTarget();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_draggable_drag_target_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_draggable_drag_target_get_delegate efl_ui_draggable_drag_target_get_static_delegate;

        
        private delegate void efl_ui_draggable_drag_target_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool set);

        
        public delegate void efl_ui_draggable_drag_target_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool set);

        public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate> efl_ui_draggable_drag_target_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate>(Module, "efl_ui_draggable_drag_target_set");

        private static void drag_target_set(System.IntPtr obj, System.IntPtr pd, bool set)
        {
            Eina.Log.Debug("function efl_ui_draggable_drag_target_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IDraggable)ws.Target).SetDragTarget(set);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_draggable_drag_target_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), set);
            }
        }

        private static efl_ui_draggable_drag_target_set_delegate efl_ui_draggable_drag_target_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

