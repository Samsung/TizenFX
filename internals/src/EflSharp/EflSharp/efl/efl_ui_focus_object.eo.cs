#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>Functions of focusable objects.
/// (Since EFL 1.22)</summary>
[IObjectNativeInherit]
public interface IObject : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
/// (Since EFL 1.22)</summary>
/// <returns>The geometry to use.</returns>
Eina.Rect GetFocusGeometry();
    /// <summary>Returns whether the widget is currently focused or not.
/// (Since EFL 1.22)</summary>
/// <returns>The focused state of the object.</returns>
bool GetFocus();
    /// <summary>This is called by the manager and should never be called by anyone else.
/// The function emits the focus state events, if focus is different to the previous state.
/// (Since EFL 1.22)</summary>
/// <param name="focus">The focused state of the object.</param>
/// <returns></returns>
void SetFocus( bool focus);
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
/// (Since EFL 1.22)</summary>
/// <returns>The manager object</returns>
Efl.Ui.Focus.IManager GetFocusManager();
    /// <summary>Describes which logical parent is used by this object.
/// (Since EFL 1.22)</summary>
/// <returns>The focus parent.</returns>
Efl.Ui.Focus.IObject GetFocusParent();
    /// <summary>Indicates if a child of this object has focus set to true.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if a child has focus.</returns>
bool GetChildFocus();
    /// <summary>Indicates if a child of this object has focus set to true.
/// (Since EFL 1.22)</summary>
/// <param name="child_focus"><c>true</c> if a child has focus.</param>
/// <returns></returns>
void SetChildFocus( bool child_focus);
    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.
/// (Since EFL 1.22)</summary>
/// <returns></returns>
void SetupOrder();
    /// <summary>This is called when <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> will not call this function again.
/// (Since EFL 1.22)</summary>
/// <returns></returns>
void SetupOrderNonRecursive();
    /// <summary>Virtual function handling focus in/out events on the widget
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise</returns>
bool UpdateOnFocus();
                                            /// <summary>Emitted if the focus state has changed.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args> FocusChangedEvt;
    /// <summary>Emitted when a new manager is the parent for this object.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args> FocusManagerChangedEvt;
    /// <summary>Emitted when a new logical parent should be used.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args> FocusParentChangedEvt;
    /// <summary>Emitted if child_focus has changed.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args> ChildFocusChangedEvt;
    /// <summary>Emitted if focus geometry of this object has changed.
    /// (Since EFL 1.22)</summary>
    event EventHandler<Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args> FocusGeometryChangedEvt;
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
/// (Since EFL 1.22)</summary>
/// <value>The geometry to use.</value>
    Eina.Rect FocusGeometry {
        get ;
    }
    /// <summary>Returns whether the widget is currently focused or not.
/// (Since EFL 1.22)</summary>
/// <value>The focused state of the object.</value>
    bool Focus {
        get ;
        set ;
    }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
/// (Since EFL 1.22)</summary>
/// <value>The manager object</value>
    Efl.Ui.Focus.IManager FocusManager {
        get ;
    }
    /// <summary>Describes which logical parent is used by this object.
/// (Since EFL 1.22)</summary>
/// <value>The focus parent.</value>
    Efl.Ui.Focus.IObject FocusParent {
        get ;
    }
    /// <summary>Indicates if a child of this object has focus set to true.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if a child has focus.</value>
    bool ChildFocus {
        get ;
        set ;
    }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusChangedEvt"/>.</summary>
public class IObjectFocusChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusManagerChangedEvt"/>.</summary>
public class IObjectFocusManagerChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.Focus.IManager arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusParentChangedEvt"/>.</summary>
public class IObjectFocusParentChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.Focus.IObject arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.ChildFocusChangedEvt"/>.</summary>
public class IObjectChildFocusChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusGeometryChangedEvt"/>.</summary>
public class IObjectFocusGeometryChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Eina.Rect arg { get; set; }
}
/// <summary>Functions of focusable objects.
/// (Since EFL 1.22)</summary>
sealed public class IObjectConcrete : 

IObject
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IObjectConcrete))
                return Efl.Ui.Focus.IObjectNativeInherit.GetEflClassStatic();
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
        efl_ui_focus_object_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IObjectConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IObjectConcrete()
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
private static object FocusChangedEvtKey = new object();
    /// <summary>Emitted if the focus state has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args> FocusChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_FocusChangedEvt_delegate)) {
                    eventHandlers.AddHandler(FocusChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_FocusChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusChangedEvt.</summary>
    public void On_FocusChangedEvt(Efl.Ui.Focus.IObjectFocusChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args>)eventHandlers[FocusChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusChangedEvt_delegate;
    private void on_FocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.Focus.IObjectFocusChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_FocusChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FocusManagerChangedEvtKey = new object();
    /// <summary>Emitted when a new manager is the parent for this object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args> FocusManagerChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_FocusManagerChangedEvt_delegate)) {
                    eventHandlers.AddHandler(FocusManagerChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_FocusManagerChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusManagerChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusManagerChangedEvt.</summary>
    public void On_FocusManagerChangedEvt(Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args>)eventHandlers[FocusManagerChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusManagerChangedEvt_delegate;
    private void on_FocusManagerChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.IManagerConcrete);
        try {
            On_FocusManagerChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FocusParentChangedEvtKey = new object();
    /// <summary>Emitted when a new logical parent should be used.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args> FocusParentChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_FocusParentChangedEvt_delegate)) {
                    eventHandlers.AddHandler(FocusParentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_FocusParentChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusParentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusParentChangedEvt.</summary>
    public void On_FocusParentChangedEvt(Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args>)eventHandlers[FocusParentChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusParentChangedEvt_delegate;
    private void on_FocusParentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.IObjectConcrete);
        try {
            On_FocusParentChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ChildFocusChangedEvtKey = new object();
    /// <summary>Emitted if child_focus has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args> ChildFocusChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ChildFocusChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ChildFocusChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_ChildFocusChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ChildFocusChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ChildFocusChangedEvt.</summary>
    public void On_ChildFocusChangedEvt(Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args>)eventHandlers[ChildFocusChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ChildFocusChangedEvt_delegate;
    private void on_ChildFocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args args = new Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_ChildFocusChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FocusGeometryChangedEvtKey = new object();
    /// <summary>Emitted if focus geometry of this object has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args> FocusGeometryChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_FocusGeometryChangedEvt_delegate)) {
                    eventHandlers.AddHandler(FocusGeometryChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_FocusGeometryChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusGeometryChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusGeometryChangedEvt.</summary>
    public void On_FocusGeometryChangedEvt(Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args e)
    {
        EventHandler<Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args>)eventHandlers[FocusGeometryChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusGeometryChangedEvt_delegate;
    private void on_FocusGeometryChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_FocusGeometryChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_FocusChangedEvt_delegate = new Efl.EventCb(on_FocusChangedEvt_NativeCallback);
        evt_FocusManagerChangedEvt_delegate = new Efl.EventCb(on_FocusManagerChangedEvt_NativeCallback);
        evt_FocusParentChangedEvt_delegate = new Efl.EventCb(on_FocusParentChangedEvt_NativeCallback);
        evt_ChildFocusChangedEvt_delegate = new Efl.EventCb(on_ChildFocusChangedEvt_NativeCallback);
        evt_FocusGeometryChangedEvt_delegate = new Efl.EventCb(on_FocusGeometryChangedEvt_NativeCallback);
    }
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>The geometry to use.</returns>
    public Eina.Rect GetFocusGeometry() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns whether the widget is currently focused or not.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focused state of the object.</returns>
    public bool GetFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is called by the manager and should never be called by anyone else.
    /// The function emits the focus state events, if focus is different to the previous state.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">The focused state of the object.</param>
    /// <returns></returns>
    public void SetFocus( bool focus) {
                                 Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_focus_set_ptr.Value.Delegate(this.NativeHandle, focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
    /// (Since EFL 1.22)</summary>
    /// <returns>The manager object</returns>
    public Efl.Ui.Focus.IManager GetFocusManager() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Describes which logical parent is used by this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focus parent.</returns>
    public Efl.Ui.Focus.IObject GetFocusParent() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if a child has focus.</returns>
    public bool GetChildFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_child_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <param name="child_focus"><c>true</c> if a child has focus.</param>
    /// <returns></returns>
    public void SetChildFocus( bool child_focus) {
                                 Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_child_focus_set_ptr.Value.Delegate(this.NativeHandle, child_focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    public void SetupOrder() {
         Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_setup_order_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This is called when <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> will not call this function again.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    public void SetupOrderNonRecursive() {
         Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Virtual function handling focus in/out events on the widget
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise</returns>
    public bool UpdateOnFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectNativeInherit.efl_ui_focus_object_on_focus_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
/// (Since EFL 1.22)</summary>
/// <value>The geometry to use.</value>
    public Eina.Rect FocusGeometry {
        get { return GetFocusGeometry(); }
    }
    /// <summary>Returns whether the widget is currently focused or not.
/// (Since EFL 1.22)</summary>
/// <value>The focused state of the object.</value>
    public bool Focus {
        get { return GetFocus(); }
        set { SetFocus( value); }
    }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
/// (Since EFL 1.22)</summary>
/// <value>The manager object</value>
    public Efl.Ui.Focus.IManager FocusManager {
        get { return GetFocusManager(); }
    }
    /// <summary>Describes which logical parent is used by this object.
/// (Since EFL 1.22)</summary>
/// <value>The focus parent.</value>
    public Efl.Ui.Focus.IObject FocusParent {
        get { return GetFocusParent(); }
    }
    /// <summary>Indicates if a child of this object has focus set to true.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if a child has focus.</value>
    public bool ChildFocus {
        get { return GetChildFocus(); }
        set { SetChildFocus( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IObjectConcrete.efl_ui_focus_object_mixin_get();
    }
}
public class IObjectNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_focus_object_focus_geometry_get_static_delegate == null)
            efl_ui_focus_object_focus_geometry_get_static_delegate = new efl_ui_focus_object_focus_geometry_get_delegate(focus_geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFocusGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_geometry_get_static_delegate)});
        if (efl_ui_focus_object_focus_get_static_delegate == null)
            efl_ui_focus_object_focus_get_static_delegate = new efl_ui_focus_object_focus_get_delegate(focus_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFocus") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_get_static_delegate)});
        if (efl_ui_focus_object_focus_set_static_delegate == null)
            efl_ui_focus_object_focus_set_static_delegate = new efl_ui_focus_object_focus_set_delegate(focus_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFocus") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_set_static_delegate)});
        if (efl_ui_focus_object_focus_manager_get_static_delegate == null)
            efl_ui_focus_object_focus_manager_get_static_delegate = new efl_ui_focus_object_focus_manager_get_delegate(focus_manager_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFocusManager") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_manager_get_static_delegate)});
        if (efl_ui_focus_object_focus_parent_get_static_delegate == null)
            efl_ui_focus_object_focus_parent_get_static_delegate = new efl_ui_focus_object_focus_parent_get_delegate(focus_parent_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFocusParent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_focus_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_parent_get_static_delegate)});
        if (efl_ui_focus_object_child_focus_get_static_delegate == null)
            efl_ui_focus_object_child_focus_get_static_delegate = new efl_ui_focus_object_child_focus_get_delegate(child_focus_get);
        if (methods.FirstOrDefault(m => m.Name == "GetChildFocus") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_child_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_get_static_delegate)});
        if (efl_ui_focus_object_child_focus_set_static_delegate == null)
            efl_ui_focus_object_child_focus_set_static_delegate = new efl_ui_focus_object_child_focus_set_delegate(child_focus_set);
        if (methods.FirstOrDefault(m => m.Name == "SetChildFocus") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_child_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_set_static_delegate)});
        if (efl_ui_focus_object_setup_order_static_delegate == null)
            efl_ui_focus_object_setup_order_static_delegate = new efl_ui_focus_object_setup_order_delegate(setup_order);
        if (methods.FirstOrDefault(m => m.Name == "SetupOrder") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_setup_order"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_static_delegate)});
        if (efl_ui_focus_object_setup_order_non_recursive_static_delegate == null)
            efl_ui_focus_object_setup_order_non_recursive_static_delegate = new efl_ui_focus_object_setup_order_non_recursive_delegate(setup_order_non_recursive);
        if (methods.FirstOrDefault(m => m.Name == "SetupOrderNonRecursive") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_setup_order_non_recursive"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_non_recursive_static_delegate)});
        if (efl_ui_focus_object_on_focus_update_static_delegate == null)
            efl_ui_focus_object_on_focus_update_static_delegate = new efl_ui_focus_object_on_focus_update_delegate(on_focus_update);
        if (methods.FirstOrDefault(m => m.Name == "UpdateOnFocus") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_object_on_focus_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_on_focus_update_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Focus.IObjectConcrete.efl_ui_focus_object_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IObjectConcrete.efl_ui_focus_object_mixin_get();
    }


     private delegate Eina.Rect.NativeStruct efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_ui_focus_object_focus_geometry_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate> efl_ui_focus_object_focus_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate>(_Module, "efl_ui_focus_object_focus_geometry_get");
     private static Eina.Rect.NativeStruct focus_geometry_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_focus_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((IObjectConcrete)wrapper).GetFocusGeometry();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_focus_geometry_get_delegate efl_ui_focus_object_focus_geometry_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_focus_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate> efl_ui_focus_object_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate>(_Module, "efl_ui_focus_object_focus_get");
     private static bool focus_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_focus_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IObjectConcrete)wrapper).GetFocus();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_focus_get_delegate efl_ui_focus_object_focus_get_static_delegate;


     private delegate void efl_ui_focus_object_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);


     public delegate void efl_ui_focus_object_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate> efl_ui_focus_object_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate>(_Module, "efl_ui_focus_object_focus_set");
     private static void focus_set(System.IntPtr obj, System.IntPtr pd,  bool focus)
    {
        Eina.Log.Debug("function efl_ui_focus_object_focus_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IObjectConcrete)wrapper).SetFocus( focus);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_focus_object_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
        }
    }
    private static efl_ui_focus_object_focus_set_delegate efl_ui_focus_object_focus_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.IManager efl_ui_focus_object_focus_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IManagerConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.IManager efl_ui_focus_object_focus_manager_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate> efl_ui_focus_object_focus_manager_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate>(_Module, "efl_ui_focus_object_focus_manager_get");
     private static Efl.Ui.Focus.IManager focus_manager_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_focus_manager_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
            try {
                _ret_var = ((IObjectConcrete)wrapper).GetFocusManager();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_focus_manager_get_delegate efl_ui_focus_object_focus_manager_get_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.IObject efl_ui_focus_object_focus_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.IObject efl_ui_focus_object_focus_parent_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate> efl_ui_focus_object_focus_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate>(_Module, "efl_ui_focus_object_focus_parent_get");
     private static Efl.Ui.Focus.IObject focus_parent_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_focus_parent_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
            try {
                _ret_var = ((IObjectConcrete)wrapper).GetFocusParent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_focus_parent_get_delegate efl_ui_focus_object_focus_parent_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_child_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_child_focus_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate> efl_ui_focus_object_child_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate>(_Module, "efl_ui_focus_object_child_focus_get");
     private static bool child_focus_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_child_focus_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IObjectConcrete)wrapper).GetChildFocus();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_child_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_child_focus_get_delegate efl_ui_focus_object_child_focus_get_static_delegate;


     private delegate void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);


     public delegate void efl_ui_focus_object_child_focus_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate> efl_ui_focus_object_child_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate>(_Module, "efl_ui_focus_object_child_focus_set");
     private static void child_focus_set(System.IntPtr obj, System.IntPtr pd,  bool child_focus)
    {
        Eina.Log.Debug("function efl_ui_focus_object_child_focus_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IObjectConcrete)wrapper).SetChildFocus( child_focus);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_focus_object_child_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_focus);
        }
    }
    private static efl_ui_focus_object_child_focus_set_delegate efl_ui_focus_object_child_focus_set_static_delegate;


     private delegate void efl_ui_focus_object_setup_order_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_focus_object_setup_order_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate> efl_ui_focus_object_setup_order_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate>(_Module, "efl_ui_focus_object_setup_order");
     private static void setup_order(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_setup_order was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((IObjectConcrete)wrapper).SetupOrder();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_focus_object_setup_order_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_setup_order_delegate efl_ui_focus_object_setup_order_static_delegate;


     private delegate void efl_ui_focus_object_setup_order_non_recursive_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_focus_object_setup_order_non_recursive_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate> efl_ui_focus_object_setup_order_non_recursive_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate>(_Module, "efl_ui_focus_object_setup_order_non_recursive");
     private static void setup_order_non_recursive(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_setup_order_non_recursive was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((IObjectConcrete)wrapper).SetupOrderNonRecursive();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_setup_order_non_recursive_delegate efl_ui_focus_object_setup_order_non_recursive_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_object_on_focus_update_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate> efl_ui_focus_object_on_focus_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate>(_Module, "efl_ui_focus_object_on_focus_update");
     private static bool on_focus_update(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_focus_object_on_focus_update was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IObjectConcrete)wrapper).UpdateOnFocus();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_focus_object_on_focus_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_focus_object_on_focus_update_delegate efl_ui_focus_object_on_focus_update_static_delegate;
}
} } } 
