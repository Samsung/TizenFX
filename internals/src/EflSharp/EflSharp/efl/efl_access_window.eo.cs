#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Access { 
/// <summary>Elementary accessible window interface</summary>
[IWindowNativeInherit]
public interface IWindow : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Called when new window has been created.</summary>
    event EventHandler WindowCreatedEvt;
    /// <summary>Called when window has been destroyed.</summary>
    event EventHandler WindowDestroyedEvt;
    /// <summary>Called when window has been activated. (focused)</summary>
    event EventHandler WindowActivatedEvt;
    /// <summary>Called when window has been deactivated (unfocused).</summary>
    event EventHandler WindowDeactivatedEvt;
    /// <summary>Called when window has been maximized</summary>
    event EventHandler WindowMaximizedEvt;
    /// <summary>Called when window has been minimized</summary>
    event EventHandler WindowMinimizedEvt;
    /// <summary>Called when window has been restored</summary>
    event EventHandler WindowRestoredEvt;
}
/// <summary>Elementary accessible window interface</summary>
sealed public class IWindowConcrete : 

IWindow
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IWindowConcrete))
                return Efl.Access.IWindowNativeInherit.GetEflClassStatic();
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
        efl_access_window_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IWindowConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IWindowConcrete()
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
private static object WindowCreatedEvtKey = new object();
    /// <summary>Called when new window has been created.</summary>
    public event EventHandler WindowCreatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_CREATED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowCreatedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowCreatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_CREATED";
                if (RemoveNativeEventHandler(key, this.evt_WindowCreatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowCreatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowCreatedEvt.</summary>
    public void On_WindowCreatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowCreatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowCreatedEvt_delegate;
    private void on_WindowCreatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowCreatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowDestroyedEvtKey = new object();
    /// <summary>Called when window has been destroyed.</summary>
    public event EventHandler WindowDestroyedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DESTROYED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowDestroyedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowDestroyedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DESTROYED";
                if (RemoveNativeEventHandler(key, this.evt_WindowDestroyedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowDestroyedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowDestroyedEvt.</summary>
    public void On_WindowDestroyedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowDestroyedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowDestroyedEvt_delegate;
    private void on_WindowDestroyedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowDestroyedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowActivatedEvtKey = new object();
    /// <summary>Called when window has been activated. (focused)</summary>
    public event EventHandler WindowActivatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_ACTIVATED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowActivatedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowActivatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_ACTIVATED";
                if (RemoveNativeEventHandler(key, this.evt_WindowActivatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowActivatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowActivatedEvt.</summary>
    public void On_WindowActivatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowActivatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowActivatedEvt_delegate;
    private void on_WindowActivatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowActivatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowDeactivatedEvtKey = new object();
    /// <summary>Called when window has been deactivated (unfocused).</summary>
    public event EventHandler WindowDeactivatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DEACTIVATED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowDeactivatedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowDeactivatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DEACTIVATED";
                if (RemoveNativeEventHandler(key, this.evt_WindowDeactivatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowDeactivatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowDeactivatedEvt.</summary>
    public void On_WindowDeactivatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowDeactivatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowDeactivatedEvt_delegate;
    private void on_WindowDeactivatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowDeactivatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowMaximizedEvtKey = new object();
    /// <summary>Called when window has been maximized</summary>
    public event EventHandler WindowMaximizedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MAXIMIZED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowMaximizedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowMaximizedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MAXIMIZED";
                if (RemoveNativeEventHandler(key, this.evt_WindowMaximizedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowMaximizedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowMaximizedEvt.</summary>
    public void On_WindowMaximizedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowMaximizedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowMaximizedEvt_delegate;
    private void on_WindowMaximizedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowMaximizedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowMinimizedEvtKey = new object();
    /// <summary>Called when window has been minimized</summary>
    public event EventHandler WindowMinimizedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MINIMIZED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowMinimizedEvt_delegate)) {
                    eventHandlers.AddHandler(WindowMinimizedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MINIMIZED";
                if (RemoveNativeEventHandler(key, this.evt_WindowMinimizedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowMinimizedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowMinimizedEvt.</summary>
    public void On_WindowMinimizedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowMinimizedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowMinimizedEvt_delegate;
    private void on_WindowMinimizedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowMinimizedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object WindowRestoredEvtKey = new object();
    /// <summary>Called when window has been restored</summary>
    public event EventHandler WindowRestoredEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_RESTORED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_WindowRestoredEvt_delegate)) {
                    eventHandlers.AddHandler(WindowRestoredEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_RESTORED";
                if (RemoveNativeEventHandler(key, this.evt_WindowRestoredEvt_delegate)) { 
                    eventHandlers.RemoveHandler(WindowRestoredEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event WindowRestoredEvt.</summary>
    public void On_WindowRestoredEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[WindowRestoredEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_WindowRestoredEvt_delegate;
    private void on_WindowRestoredEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_WindowRestoredEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_WindowCreatedEvt_delegate = new Efl.EventCb(on_WindowCreatedEvt_NativeCallback);
        evt_WindowDestroyedEvt_delegate = new Efl.EventCb(on_WindowDestroyedEvt_NativeCallback);
        evt_WindowActivatedEvt_delegate = new Efl.EventCb(on_WindowActivatedEvt_NativeCallback);
        evt_WindowDeactivatedEvt_delegate = new Efl.EventCb(on_WindowDeactivatedEvt_NativeCallback);
        evt_WindowMaximizedEvt_delegate = new Efl.EventCb(on_WindowMaximizedEvt_NativeCallback);
        evt_WindowMinimizedEvt_delegate = new Efl.EventCb(on_WindowMinimizedEvt_NativeCallback);
        evt_WindowRestoredEvt_delegate = new Efl.EventCb(on_WindowRestoredEvt_NativeCallback);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Access.IWindowConcrete.efl_access_window_interface_get();
    }
}
public class IWindowNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Access.IWindowConcrete.efl_access_window_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Access.IWindowConcrete.efl_access_window_interface_get();
    }
}
} } 
