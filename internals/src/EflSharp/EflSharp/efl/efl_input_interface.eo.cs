#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>An object implementing this interface can send pointer events.
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
[IInterfaceNativeInherit]
public interface IInterface : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Check if input events from a given seat is enabled.</summary>
/// <param name="seat">The seat to act on.</param>
/// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
bool GetSeatEventFilter( Efl.Input.Device seat);
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.</summary>
/// <param name="seat">The seat to act on.</param>
/// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
/// <returns></returns>
void SetSeatEventFilter( Efl.Input.Device seat,  bool enable);
            /// <summary>Main pointer move (current and previous positions are known).</summary>
    event EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> PointerMoveEvt;
    /// <summary>Main pointer button pressed (button id is known).</summary>
    event EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> PointerDownEvt;
    /// <summary>Main pointer button released (button id is known).</summary>
    event EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> PointerUpEvt;
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    event EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> PointerCancelEvt;
    /// <summary>Pointer entered a window or a widget.</summary>
    event EventHandler<Efl.Input.IInterfacePointerInEvt_Args> PointerInEvt;
    /// <summary>Pointer left a window or a widget.</summary>
    event EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> PointerOutEvt;
    /// <summary>Mouse wheel event.</summary>
    event EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> PointerWheelEvt;
    /// <summary>Pen or other axis event update.</summary>
    event EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> PointerAxisEvt;
    /// <summary>Finger moved (current and previous positions are known).</summary>
    event EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> FingerMoveEvt;
    /// <summary>Finger pressed (finger id is known).</summary>
    event EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> FingerDownEvt;
    /// <summary>Finger released (finger id is known).</summary>
    event EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> FingerUpEvt;
    /// <summary>Keyboard key press.</summary>
    event EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> KeyDownEvt;
    /// <summary>Keyboard key release.</summary>
    event EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> KeyUpEvt;
    /// <summary>All input events are on hold or resumed.</summary>
    event EventHandler<Efl.Input.IInterfaceHoldEvt_Args> HoldEvt;
    /// <summary>A focus in event.</summary>
    event EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> FocusInEvt;
    /// <summary>A focus out event.</summary>
    event EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> FocusOutEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerMoveEvt"/>.</summary>
public class IInterfacePointerMoveEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerDownEvt"/>.</summary>
public class IInterfacePointerDownEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerUpEvt"/>.</summary>
public class IInterfacePointerUpEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerCancelEvt"/>.</summary>
public class IInterfacePointerCancelEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerInEvt"/>.</summary>
public class IInterfacePointerInEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerOutEvt"/>.</summary>
public class IInterfacePointerOutEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerWheelEvt"/>.</summary>
public class IInterfacePointerWheelEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerAxisEvt"/>.</summary>
public class IInterfacePointerAxisEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerMoveEvt"/>.</summary>
public class IInterfaceFingerMoveEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerDownEvt"/>.</summary>
public class IInterfaceFingerDownEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerUpEvt"/>.</summary>
public class IInterfaceFingerUpEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyDownEvt"/>.</summary>
public class IInterfaceKeyDownEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Key arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyUpEvt"/>.</summary>
public class IInterfaceKeyUpEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Key arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.HoldEvt"/>.</summary>
public class IInterfaceHoldEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Hold arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusInEvt"/>.</summary>
public class IInterfaceFocusInEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusOutEvt"/>.</summary>
public class IInterfaceFocusOutEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Input.Focus arg { get; set; }
}
/// <summary>An object implementing this interface can send pointer events.
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
sealed public class IInterfaceConcrete : 

IInterface
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IInterfaceConcrete))
                return Efl.Input.IInterfaceNativeInherit.GetEflClassStatic();
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
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IInterfaceConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IInterfaceConcrete()
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
            IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
private static object PointerMoveEvtKey = new object();
    /// <summary>Main pointer move (current and previous positions are known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> PointerMoveEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_MOVE";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerMoveEvt_delegate)) {
                    eventHandlers.AddHandler(PointerMoveEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_MOVE";
                if (RemoveNativeEventHandler(key, this.evt_PointerMoveEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerMoveEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerMoveEvt.</summary>
    public void On_PointerMoveEvt(Efl.Input.IInterfacePointerMoveEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args>)eventHandlers[PointerMoveEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerMoveEvt_delegate;
    private void on_PointerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerMoveEvt_Args args = new Efl.Input.IInterfacePointerMoveEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerMoveEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerDownEvtKey = new object();
    /// <summary>Main pointer button pressed (button id is known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> PointerDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_DOWN";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerDownEvt_delegate)) {
                    eventHandlers.AddHandler(PointerDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_PointerDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerDownEvt.</summary>
    public void On_PointerDownEvt(Efl.Input.IInterfacePointerDownEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerDownEvt_Args>)eventHandlers[PointerDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerDownEvt_delegate;
    private void on_PointerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerDownEvt_Args args = new Efl.Input.IInterfacePointerDownEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerUpEvtKey = new object();
    /// <summary>Main pointer button released (button id is known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> PointerUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_UP";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerUpEvt_delegate)) {
                    eventHandlers.AddHandler(PointerUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_UP";
                if (RemoveNativeEventHandler(key, this.evt_PointerUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerUpEvt.</summary>
    public void On_PointerUpEvt(Efl.Input.IInterfacePointerUpEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerUpEvt_Args>)eventHandlers[PointerUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerUpEvt_delegate;
    private void on_PointerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerUpEvt_Args args = new Efl.Input.IInterfacePointerUpEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerCancelEvtKey = new object();
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> PointerCancelEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerCancelEvt_delegate)) {
                    eventHandlers.AddHandler(PointerCancelEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                if (RemoveNativeEventHandler(key, this.evt_PointerCancelEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerCancelEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerCancelEvt.</summary>
    public void On_PointerCancelEvt(Efl.Input.IInterfacePointerCancelEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args>)eventHandlers[PointerCancelEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerCancelEvt_delegate;
    private void on_PointerCancelEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerCancelEvt_Args args = new Efl.Input.IInterfacePointerCancelEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerCancelEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerInEvtKey = new object();
    /// <summary>Pointer entered a window or a widget.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerInEvt_Args> PointerInEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_IN";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerInEvt_delegate)) {
                    eventHandlers.AddHandler(PointerInEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_IN";
                if (RemoveNativeEventHandler(key, this.evt_PointerInEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerInEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerInEvt.</summary>
    public void On_PointerInEvt(Efl.Input.IInterfacePointerInEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerInEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerInEvt_Args>)eventHandlers[PointerInEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerInEvt_delegate;
    private void on_PointerInEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerInEvt_Args args = new Efl.Input.IInterfacePointerInEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerInEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerOutEvtKey = new object();
    /// <summary>Pointer left a window or a widget.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> PointerOutEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_OUT";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerOutEvt_delegate)) {
                    eventHandlers.AddHandler(PointerOutEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_OUT";
                if (RemoveNativeEventHandler(key, this.evt_PointerOutEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerOutEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerOutEvt.</summary>
    public void On_PointerOutEvt(Efl.Input.IInterfacePointerOutEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerOutEvt_Args>)eventHandlers[PointerOutEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerOutEvt_delegate;
    private void on_PointerOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerOutEvt_Args args = new Efl.Input.IInterfacePointerOutEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerOutEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerWheelEvtKey = new object();
    /// <summary>Mouse wheel event.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> PointerWheelEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerWheelEvt_delegate)) {
                    eventHandlers.AddHandler(PointerWheelEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                if (RemoveNativeEventHandler(key, this.evt_PointerWheelEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerWheelEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerWheelEvt.</summary>
    public void On_PointerWheelEvt(Efl.Input.IInterfacePointerWheelEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args>)eventHandlers[PointerWheelEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerWheelEvt_delegate;
    private void on_PointerWheelEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerWheelEvt_Args args = new Efl.Input.IInterfacePointerWheelEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerWheelEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PointerAxisEvtKey = new object();
    /// <summary>Pen or other axis event update.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> PointerAxisEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_AXIS";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_PointerAxisEvt_delegate)) {
                    eventHandlers.AddHandler(PointerAxisEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_POINTER_AXIS";
                if (RemoveNativeEventHandler(key, this.evt_PointerAxisEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PointerAxisEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PointerAxisEvt.</summary>
    public void On_PointerAxisEvt(Efl.Input.IInterfacePointerAxisEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args>)eventHandlers[PointerAxisEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PointerAxisEvt_delegate;
    private void on_PointerAxisEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfacePointerAxisEvt_Args args = new Efl.Input.IInterfacePointerAxisEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_PointerAxisEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FingerMoveEvtKey = new object();
    /// <summary>Finger moved (current and previous positions are known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> FingerMoveEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_MOVE";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_FingerMoveEvt_delegate)) {
                    eventHandlers.AddHandler(FingerMoveEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_MOVE";
                if (RemoveNativeEventHandler(key, this.evt_FingerMoveEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FingerMoveEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FingerMoveEvt.</summary>
    public void On_FingerMoveEvt(Efl.Input.IInterfaceFingerMoveEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args>)eventHandlers[FingerMoveEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FingerMoveEvt_delegate;
    private void on_FingerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceFingerMoveEvt_Args args = new Efl.Input.IInterfaceFingerMoveEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_FingerMoveEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FingerDownEvtKey = new object();
    /// <summary>Finger pressed (finger id is known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> FingerDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_DOWN";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_FingerDownEvt_delegate)) {
                    eventHandlers.AddHandler(FingerDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_FingerDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FingerDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FingerDownEvt.</summary>
    public void On_FingerDownEvt(Efl.Input.IInterfaceFingerDownEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args>)eventHandlers[FingerDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FingerDownEvt_delegate;
    private void on_FingerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceFingerDownEvt_Args args = new Efl.Input.IInterfaceFingerDownEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_FingerDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FingerUpEvtKey = new object();
    /// <summary>Finger released (finger id is known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> FingerUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_UP";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_FingerUpEvt_delegate)) {
                    eventHandlers.AddHandler(FingerUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_FINGER_UP";
                if (RemoveNativeEventHandler(key, this.evt_FingerUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FingerUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FingerUpEvt.</summary>
    public void On_FingerUpEvt(Efl.Input.IInterfaceFingerUpEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args>)eventHandlers[FingerUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FingerUpEvt_delegate;
    private void on_FingerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceFingerUpEvt_Args args = new Efl.Input.IInterfaceFingerUpEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
        try {
            On_FingerUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object KeyDownEvtKey = new object();
    /// <summary>Keyboard key press.</summary>
    public event EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> KeyDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_KEY_DOWN";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_KeyDownEvt_delegate)) {
                    eventHandlers.AddHandler(KeyDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_KEY_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_KeyDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(KeyDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event KeyDownEvt.</summary>
    public void On_KeyDownEvt(Efl.Input.IInterfaceKeyDownEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args>)eventHandlers[KeyDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_KeyDownEvt_delegate;
    private void on_KeyDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceKeyDownEvt_Args args = new Efl.Input.IInterfaceKeyDownEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Key);
        try {
            On_KeyDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object KeyUpEvtKey = new object();
    /// <summary>Keyboard key release.</summary>
    public event EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> KeyUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_KEY_UP";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_KeyUpEvt_delegate)) {
                    eventHandlers.AddHandler(KeyUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_KEY_UP";
                if (RemoveNativeEventHandler(key, this.evt_KeyUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(KeyUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event KeyUpEvt.</summary>
    public void On_KeyUpEvt(Efl.Input.IInterfaceKeyUpEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args>)eventHandlers[KeyUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_KeyUpEvt_delegate;
    private void on_KeyUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceKeyUpEvt_Args args = new Efl.Input.IInterfaceKeyUpEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Key);
        try {
            On_KeyUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object HoldEvtKey = new object();
    /// <summary>All input events are on hold or resumed.</summary>
    public event EventHandler<Efl.Input.IInterfaceHoldEvt_Args> HoldEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_HOLD";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_HoldEvt_delegate)) {
                    eventHandlers.AddHandler(HoldEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_HOLD";
                if (RemoveNativeEventHandler(key, this.evt_HoldEvt_delegate)) { 
                    eventHandlers.RemoveHandler(HoldEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event HoldEvt.</summary>
    public void On_HoldEvt(Efl.Input.IInterfaceHoldEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceHoldEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceHoldEvt_Args>)eventHandlers[HoldEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_HoldEvt_delegate;
    private void on_HoldEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceHoldEvt_Args args = new Efl.Input.IInterfaceHoldEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Hold);
        try {
            On_HoldEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FocusInEvtKey = new object();
    /// <summary>A focus in event.</summary>
    public event EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> FocusInEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_FOCUS_IN";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_FocusInEvt_delegate)) {
                    eventHandlers.AddHandler(FocusInEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_FOCUS_IN";
                if (RemoveNativeEventHandler(key, this.evt_FocusInEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusInEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusInEvt.</summary>
    public void On_FocusInEvt(Efl.Input.IInterfaceFocusInEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceFocusInEvt_Args>)eventHandlers[FocusInEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusInEvt_delegate;
    private void on_FocusInEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceFocusInEvt_Args args = new Efl.Input.IInterfaceFocusInEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
        try {
            On_FocusInEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object FocusOutEvtKey = new object();
    /// <summary>A focus out event.</summary>
    public event EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> FocusOutEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_EVENT_FOCUS_OUT";
                if (AddNativeEventHandler(efl.Libs.Evas, key, this.evt_FocusOutEvt_delegate)) {
                    eventHandlers.AddHandler(FocusOutEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_EVENT_FOCUS_OUT";
                if (RemoveNativeEventHandler(key, this.evt_FocusOutEvt_delegate)) { 
                    eventHandlers.RemoveHandler(FocusOutEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event FocusOutEvt.</summary>
    public void On_FocusOutEvt(Efl.Input.IInterfaceFocusOutEvt_Args e)
    {
        EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args>)eventHandlers[FocusOutEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_FocusOutEvt_delegate;
    private void on_FocusOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Input.IInterfaceFocusOutEvt_Args args = new Efl.Input.IInterfaceFocusOutEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
        try {
            On_FocusOutEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
        evt_PointerMoveEvt_delegate = new Efl.EventCb(on_PointerMoveEvt_NativeCallback);
        evt_PointerDownEvt_delegate = new Efl.EventCb(on_PointerDownEvt_NativeCallback);
        evt_PointerUpEvt_delegate = new Efl.EventCb(on_PointerUpEvt_NativeCallback);
        evt_PointerCancelEvt_delegate = new Efl.EventCb(on_PointerCancelEvt_NativeCallback);
        evt_PointerInEvt_delegate = new Efl.EventCb(on_PointerInEvt_NativeCallback);
        evt_PointerOutEvt_delegate = new Efl.EventCb(on_PointerOutEvt_NativeCallback);
        evt_PointerWheelEvt_delegate = new Efl.EventCb(on_PointerWheelEvt_NativeCallback);
        evt_PointerAxisEvt_delegate = new Efl.EventCb(on_PointerAxisEvt_NativeCallback);
        evt_FingerMoveEvt_delegate = new Efl.EventCb(on_FingerMoveEvt_NativeCallback);
        evt_FingerDownEvt_delegate = new Efl.EventCb(on_FingerDownEvt_NativeCallback);
        evt_FingerUpEvt_delegate = new Efl.EventCb(on_FingerUpEvt_NativeCallback);
        evt_KeyDownEvt_delegate = new Efl.EventCb(on_KeyDownEvt_NativeCallback);
        evt_KeyUpEvt_delegate = new Efl.EventCb(on_KeyUpEvt_NativeCallback);
        evt_HoldEvt_delegate = new Efl.EventCb(on_HoldEvt_NativeCallback);
        evt_FocusInEvt_delegate = new Efl.EventCb(on_FocusInEvt_NativeCallback);
        evt_FocusOutEvt_delegate = new Efl.EventCb(on_FocusOutEvt_NativeCallback);
    }
    /// <summary>Check if input events from a given seat is enabled.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    public bool GetSeatEventFilter( Efl.Input.Device seat) {
                                 var _ret_var = Efl.Input.IInterfaceNativeInherit.efl_input_seat_event_filter_get_ptr.Value.Delegate(this.NativeHandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
    /// <returns></returns>
    public void SetSeatEventFilter( Efl.Input.Device seat,  bool enable) {
                                                         Efl.Input.IInterfaceNativeInherit.efl_input_seat_event_filter_set_ptr.Value.Delegate(this.NativeHandle, seat,  enable);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.IInterfaceConcrete.efl_input_interface_interface_get();
    }
}
public class IInterfaceNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_input_seat_event_filter_get_static_delegate == null)
            efl_input_seat_event_filter_get_static_delegate = new efl_input_seat_event_filter_get_delegate(seat_event_filter_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSeatEventFilter") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_get_static_delegate)});
        if (efl_input_seat_event_filter_set_static_delegate == null)
            efl_input_seat_event_filter_set_static_delegate = new efl_input_seat_event_filter_set_delegate(seat_event_filter_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSeatEventFilter") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Input.IInterfaceConcrete.efl_input_interface_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Input.IInterfaceConcrete.efl_input_interface_interface_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_seat_event_filter_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
     public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate> efl_input_seat_event_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate>(_Module, "efl_input_seat_event_filter_get");
     private static bool seat_event_filter_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
    {
        Eina.Log.Debug("function efl_input_seat_event_filter_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((IInterface)wrapper).GetSeatEventFilter( seat);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_input_seat_event_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
        }
    }
    private static efl_input_seat_event_filter_get_delegate efl_input_seat_event_filter_get_static_delegate;


     private delegate void efl_input_seat_event_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);


     public delegate void efl_input_seat_event_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
     public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate> efl_input_seat_event_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate>(_Module, "efl_input_seat_event_filter_set");
     private static void seat_event_filter_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat,  bool enable)
    {
        Eina.Log.Debug("function efl_input_seat_event_filter_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((IInterface)wrapper).SetSeatEventFilter( seat,  enable);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_input_seat_event_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat,  enable);
        }
    }
    private static efl_input_seat_event_filter_set_delegate efl_input_seat_event_filter_set_static_delegate;
}
} } 
