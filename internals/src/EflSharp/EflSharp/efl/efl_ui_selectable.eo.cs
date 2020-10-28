#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI selectable interface</summary>
[ISelectableNativeInherit]
public interface ISelectable : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Called when selected</summary>
    event EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> ItemSelectedEvt;
    /// <summary>Called when no longer selected</summary>
    event EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> ItemUnselectedEvt;
    /// <summary>Called when selection is pasted</summary>
    event EventHandler SelectionPasteEvt;
    /// <summary>Called when selection is copied</summary>
    event EventHandler SelectionCopyEvt;
    /// <summary>Called when selection is cut</summary>
    event EventHandler SelectionCutEvt;
    /// <summary>Called at selection start</summary>
    event EventHandler SelectionStartEvt;
    /// <summary>Called when selection is changed</summary>
    event EventHandler SelectionChangedEvt;
    /// <summary>Called when selection is cleared</summary>
    event EventHandler SelectionClearedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ISelectable.ItemSelectedEvt"/>.</summary>
public class ISelectableItemSelectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ISelectable.ItemUnselectedEvt"/>.</summary>
public class ISelectableItemUnselectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Object arg { get; set; }
}
/// <summary>Efl UI selectable interface</summary>
sealed public class ISelectableConcrete : 

ISelectable
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ISelectableConcrete))
                return Efl.Ui.ISelectableNativeInherit.GetEflClassStatic();
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
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_selectable_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private ISelectableConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~ISelectableConcrete()
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
            IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
private static object ItemSelectedEvtKey = new object();
    /// <summary>Called when selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> ItemSelectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ItemSelectedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemSelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                if (RemoveNativeEventHandler(key, this.evt_ItemSelectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ItemSelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ItemSelectedEvt.</summary>
    public void On_ItemSelectedEvt(Efl.Ui.ISelectableItemSelectedEvt_Args e)
    {
        EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args>)eventHandlers[ItemSelectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ItemSelectedEvt_delegate;
    private void on_ItemSelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ISelectableItemSelectedEvt_Args args = new Efl.Ui.ISelectableItemSelectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ItemSelectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ItemUnselectedEvtKey = new object();
    /// <summary>Called when no longer selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> ItemUnselectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ItemUnselectedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemUnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                if (RemoveNativeEventHandler(key, this.evt_ItemUnselectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ItemUnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ItemUnselectedEvt.</summary>
    public void On_ItemUnselectedEvt(Efl.Ui.ISelectableItemUnselectedEvt_Args e)
    {
        EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args>)eventHandlers[ItemUnselectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ItemUnselectedEvt_delegate;
    private void on_ItemUnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ISelectableItemUnselectedEvt_Args args = new Efl.Ui.ISelectableItemUnselectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ItemUnselectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionPasteEvtKey = new object();
    /// <summary>Called when selection is pasted</summary>
    public event EventHandler SelectionPasteEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionPasteEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionPasteEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                if (RemoveNativeEventHandler(key, this.evt_SelectionPasteEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionPasteEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionPasteEvt.</summary>
    public void On_SelectionPasteEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionPasteEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionPasteEvt_delegate;
    private void on_SelectionPasteEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionPasteEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionCopyEvtKey = new object();
    /// <summary>Called when selection is copied</summary>
    public event EventHandler SelectionCopyEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionCopyEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionCopyEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                if (RemoveNativeEventHandler(key, this.evt_SelectionCopyEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionCopyEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionCopyEvt.</summary>
    public void On_SelectionCopyEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionCopyEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionCopyEvt_delegate;
    private void on_SelectionCopyEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionCopyEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionCutEvtKey = new object();
    /// <summary>Called when selection is cut</summary>
    public event EventHandler SelectionCutEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionCutEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionCutEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                if (RemoveNativeEventHandler(key, this.evt_SelectionCutEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionCutEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionCutEvt.</summary>
    public void On_SelectionCutEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionCutEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionCutEvt_delegate;
    private void on_SelectionCutEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionCutEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionStartEvtKey = new object();
    /// <summary>Called at selection start</summary>
    public event EventHandler SelectionStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionStartEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                if (RemoveNativeEventHandler(key, this.evt_SelectionStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionStartEvt.</summary>
    public void On_SelectionStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionStartEvt_delegate;
    private void on_SelectionStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionChangedEvtKey = new object();
    /// <summary>Called when selection is changed</summary>
    public event EventHandler SelectionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SelectionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionChangedEvt.</summary>
    public void On_SelectionChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionChangedEvt_delegate;
    private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionClearedEvtKey = new object();
    /// <summary>Called when selection is cleared</summary>
    public event EventHandler SelectionClearedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionClearedEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionClearedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                if (RemoveNativeEventHandler(key, this.evt_SelectionClearedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionClearedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionClearedEvt.</summary>
    public void On_SelectionClearedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionClearedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionClearedEvt_delegate;
    private void on_SelectionClearedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionClearedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_ItemSelectedEvt_delegate = new Efl.EventCb(on_ItemSelectedEvt_NativeCallback);
        evt_ItemUnselectedEvt_delegate = new Efl.EventCb(on_ItemUnselectedEvt_NativeCallback);
        evt_SelectionPasteEvt_delegate = new Efl.EventCb(on_SelectionPasteEvt_NativeCallback);
        evt_SelectionCopyEvt_delegate = new Efl.EventCb(on_SelectionCopyEvt_NativeCallback);
        evt_SelectionCutEvt_delegate = new Efl.EventCb(on_SelectionCutEvt_NativeCallback);
        evt_SelectionStartEvt_delegate = new Efl.EventCb(on_SelectionStartEvt_NativeCallback);
        evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
        evt_SelectionClearedEvt_delegate = new Efl.EventCb(on_SelectionClearedEvt_NativeCallback);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectableConcrete.efl_ui_selectable_interface_get();
    }
}
public class ISelectableNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.ISelectableConcrete.efl_ui_selectable_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ISelectableConcrete.efl_ui_selectable_interface_get();
    }
}
} } 
