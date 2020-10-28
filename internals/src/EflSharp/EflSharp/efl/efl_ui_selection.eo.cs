#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Selection class</summary>
[ISelectionNativeInherit]
public interface ISelection : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Set the selection data to the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data">Selection data</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>Future for tracking when the selection is lost</returns>
 Eina.Future SetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);
    /// <summary>Get the data from the object that has selection</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data_func">Data ready function pointer</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
void GetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,  uint seat);
    /// <summary>Clear the selection data from the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
void ClearSelection( Efl.Ui.SelectionType type,  uint seat);
    /// <summary>Determine whether the selection data has owner</summary>
/// <param name="type">Selection type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
bool HasOwner( Efl.Ui.SelectionType type,  uint seat);
        System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
                /// <summary>Called when display server&apos;s selection has changed</summary>
    event EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> WmSelectionChangedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ISelection.WmSelectionChangedEvt"/>.</summary>
public class ISelectionWmSelectionChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.SelectionChanged arg { get; set; }
}
/// <summary>Efl Ui Selection class</summary>
sealed public class ISelectionConcrete : 

ISelection
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ISelectionConcrete))
                return Efl.Ui.ISelectionNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private EventHandlerList eventHandlers = new EventHandlerList();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_selection_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private ISelectionConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~ISelectionConcrete()
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
    private readonly object eventLock = new object();
    private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be called on event raising.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool AddNativeEventHandler(string lib, string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 0) {
            IntPtr desc = Efl.EventDescription.GetNative(lib, key);
            if (desc == IntPtr.Zero) {
                Eina.Log.Error($"Failed to get native event {key}");
                return false;
            }
             bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
            if (!result) {
                Eina.Log.Error($"Failed to add event proxy for event {key}");
                return false;
            }
            Eina.Error.RaiseIfUnhandledException();
        } 
        event_cb_count[key]++;
        return true;
    }
    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evt_delegate">The delegate to be removed.</param>
    ///<returns>True if the delegate was successfully registered.</returns>
    private bool RemoveNativeEventHandler(string key, Efl.EventCb evt_delegate) {
        int event_count = 0;
        if (!event_cb_count.TryGetValue(key, out event_count))
            event_cb_count[key] = event_count;
        if (event_count == 1) {
            IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
            if (desc == IntPtr.Zero) {
                Eina.Log.Error($"Failed to get native event {key}");
                return false;
            }
            bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
            if (!result) {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return false;
            }
            Eina.Error.RaiseIfUnhandledException();
        } else if (event_count == 0) {
            Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
            return false;
        } 
        event_cb_count[key]--;
        return true;
    }
private static object WmSelectionChangedEvtKey = new object();
    /// <summary>Called when display server&apos;s selection has changed</summary>
    public event EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> WmSelectionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WmSelectionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(WmSelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_WmSelectionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WmSelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WmSelectionChangedEvt.</summary>
    public void On_WmSelectionChangedEvt(Efl.Ui.ISelectionWmSelectionChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args>)eventHandlers[WmSelectionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WmSelectionChangedEvt_delegate;
    private void on_WmSelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ISelectionWmSelectionChangedEvt_Args args = new Efl.Ui.ISelectionWmSelectionChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_WmSelectionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_WmSelectionChangedEvt_delegate = new Efl.EventCb(on_WmSelectionChangedEvt_NativeCallback);
    }
    /// <summary>Set the selection data to the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>Future for tracking when the selection is lost</returns>
    public  Eina.Future SetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat) {
                                                                                                         var _ret_var = Efl.Ui.ISelectionNativeInherit.efl_ui_selection_set_ptr.Value.Delegate(this.NativeHandle, type,  format,  data,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Get the data from the object that has selection</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data_func">Data ready function pointer</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    public void GetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,  uint seat) {
                                                                                         GCHandle data_func_handle = GCHandle.Alloc(data_func);
                Efl.Ui.ISelectionNativeInherit.efl_ui_selection_get_ptr.Value.Delegate(this.NativeHandle, type,  format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Clear the selection data from the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns></returns>
    public void ClearSelection( Efl.Ui.SelectionType type,  uint seat) {
                                                         Efl.Ui.ISelectionNativeInherit.efl_ui_selection_clear_ptr.Value.Delegate(this.NativeHandle, type,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Determine whether the selection data has owner</summary>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
    public bool HasOwner( Efl.Ui.SelectionType type,  uint seat) {
                                                         var _ret_var = Efl.Ui.ISelectionNativeInherit.efl_ui_selection_has_owner_ptr.Value.Delegate(this.NativeHandle, type,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetSelection(  type,  format,  data,  seat);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectionConcrete.efl_ui_selection_mixin_get();
    }
}
public class ISelectionNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_selection_set_static_delegate == null)
            efl_ui_selection_set_static_delegate = new efl_ui_selection_set_delegate(selection_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_set_static_delegate)});
        if (efl_ui_selection_get_static_delegate == null)
            efl_ui_selection_get_static_delegate = new efl_ui_selection_get_delegate(selection_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_get_static_delegate)});
        if (efl_ui_selection_clear_static_delegate == null)
            efl_ui_selection_clear_static_delegate = new efl_ui_selection_clear_delegate(selection_clear);
        if (methods.FirstOrDefault(m => m.Name == "ClearSelection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_clear_static_delegate)});
        if (efl_ui_selection_has_owner_static_delegate == null)
            efl_ui_selection_has_owner_static_delegate = new efl_ui_selection_has_owner_delegate(has_owner);
        if (methods.FirstOrDefault(m => m.Name == "HasOwner") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_has_owner_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.ISelectionConcrete.efl_ui_selection_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectionConcrete.efl_ui_selection_mixin_get();
    }


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   uint seat);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] public delegate  Eina.Future efl_ui_selection_set_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate> efl_ui_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate>(_Module, "efl_ui_selection_set");
     private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                         Eina.Future _ret_var = default( Eina.Future);
            try {
                _ret_var = ((ISelectionConcrete)wrapper).SetSelection( type,  format,  data,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                        return _ret_var;
        } else {
            return efl_ui_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format,  data,  seat);
        }
    }
    private static efl_ui_selection_set_delegate efl_ui_selection_set_static_delegate;


     private delegate void efl_ui_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat);


     public delegate void efl_ui_selection_get_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate> efl_ui_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate>(_Module, "efl_ui_selection_get");
     private static void selection_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                        Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
                    
            try {
                ((ISelectionConcrete)wrapper).GetSelection( type,  format,  data_func_wrapper.ManagedCb,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_ui_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format, data_func_data, data_func, data_func_free_cb,  seat);
        }
    }
    private static efl_ui_selection_get_delegate efl_ui_selection_get_static_delegate;


     private delegate void efl_ui_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   uint seat);


     public delegate void efl_ui_selection_clear_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionType type,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate> efl_ui_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate>(_Module, "efl_ui_selection_clear");
     private static void selection_clear(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_clear was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ISelectionConcrete)wrapper).ClearSelection( type,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
        }
    }
    private static efl_ui_selection_clear_delegate efl_ui_selection_clear_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   uint seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_selection_has_owner_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionType type,   uint seat);
     public static Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate> efl_ui_selection_has_owner_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate>(_Module, "efl_ui_selection_has_owner");
     private static bool has_owner(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat)
    {
        Eina.Log.Debug("function efl_ui_selection_has_owner was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ISelectionConcrete)wrapper).HasOwner( type,  seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_ui_selection_has_owner_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
        }
    }
    private static efl_ui_selection_has_owner_delegate efl_ui_selection_has_owner_static_delegate;
}
} } 
