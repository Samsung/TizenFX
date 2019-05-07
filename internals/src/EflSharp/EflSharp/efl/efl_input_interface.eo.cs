#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Input {

/// <summary>An object implementing this interface can send pointer events.
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
[Efl.Input.IInterfaceConcrete.NativeMethods]
public interface IInterface : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Check if input events from a given seat is enabled.</summary>
/// <param name="seat">The seat to act on.</param>
/// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
bool GetSeatEventFilter(Efl.Input.Device seat);
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.</summary>
/// <param name="seat">The seat to act on.</param>
/// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
void SetSeatEventFilter(Efl.Input.Device seat, bool enable);
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
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IInterfaceConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    private readonly object eventLock = new object();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IInterface"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IInterfaceConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IInterfaceConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (eoEvents.Count != 0)
            {
                GCHandle gcHandle = GCHandle.Alloc(eoEvents);
                gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            }

            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtCaller">Delegate to be called by native code on event raising.</param>
    ///<param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    private void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
        }

        if (eoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, IntPtr.Zero))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        eoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtDelegate">The delegate to be removed.</param>
    private void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var evtPair = (desc, evtDelegate);
        if (eoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, IntPtr.Zero))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            eoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is nothing registered.");
        }
    }

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> PointerMoveEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerMoveEvt_Args args = new Efl.Input.IInterfacePointerMoveEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_MOVE";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerMoveEvt.</summary>
    public void OnPointerMoveEvt(Efl.Input.IInterfacePointerMoveEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_MOVE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Main pointer button pressed (button id is known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> PointerDownEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerDownEvt_Args args = new Efl.Input.IInterfacePointerDownEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_DOWN";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerDownEvt.</summary>
    public void OnPointerDownEvt(Efl.Input.IInterfacePointerDownEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Main pointer button released (button id is known).</summary>
    public event EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> PointerUpEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerUpEvt_Args args = new Efl.Input.IInterfacePointerUpEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_UP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerUpEvt.</summary>
    public void OnPointerUpEvt(Efl.Input.IInterfacePointerUpEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> PointerCancelEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerCancelEvt_Args args = new Efl.Input.IInterfacePointerCancelEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_CANCEL";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerCancelEvt.</summary>
    public void OnPointerCancelEvt(Efl.Input.IInterfacePointerCancelEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_CANCEL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Pointer entered a window or a widget.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerInEvt_Args> PointerInEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerInEvt_Args args = new Efl.Input.IInterfacePointerInEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_IN";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerInEvt.</summary>
    public void OnPointerInEvt(Efl.Input.IInterfacePointerInEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Pointer left a window or a widget.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> PointerOutEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerOutEvt_Args args = new Efl.Input.IInterfacePointerOutEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_OUT";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerOutEvt.</summary>
    public void OnPointerOutEvt(Efl.Input.IInterfacePointerOutEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Mouse wheel event.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> PointerWheelEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerWheelEvt_Args args = new Efl.Input.IInterfacePointerWheelEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_WHEEL";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerWheelEvt.</summary>
    public void OnPointerWheelEvt(Efl.Input.IInterfacePointerWheelEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_WHEEL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Pen or other axis event update.</summary>
    public event EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> PointerAxisEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfacePointerAxisEvt_Args args = new Efl.Input.IInterfacePointerAxisEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_POINTER_AXIS";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_POINTER_AXIS";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event PointerAxisEvt.</summary>
    public void OnPointerAxisEvt(Efl.Input.IInterfacePointerAxisEvt_Args e)
    {
        var key = "_EFL_EVENT_POINTER_AXIS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Finger moved (current and previous positions are known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> FingerMoveEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceFingerMoveEvt_Args args = new Efl.Input.IInterfaceFingerMoveEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_FINGER_MOVE";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_FINGER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event FingerMoveEvt.</summary>
    public void OnFingerMoveEvt(Efl.Input.IInterfaceFingerMoveEvt_Args e)
    {
        var key = "_EFL_EVENT_FINGER_MOVE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Finger pressed (finger id is known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> FingerDownEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceFingerDownEvt_Args args = new Efl.Input.IInterfaceFingerDownEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_FINGER_DOWN";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_FINGER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event FingerDownEvt.</summary>
    public void OnFingerDownEvt(Efl.Input.IInterfaceFingerDownEvt_Args e)
    {
        var key = "_EFL_EVENT_FINGER_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Finger released (finger id is known).</summary>
    public event EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> FingerUpEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceFingerUpEvt_Args args = new Efl.Input.IInterfaceFingerUpEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Pointer);
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

                string key = "_EFL_EVENT_FINGER_UP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_FINGER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event FingerUpEvt.</summary>
    public void OnFingerUpEvt(Efl.Input.IInterfaceFingerUpEvt_Args e)
    {
        var key = "_EFL_EVENT_FINGER_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Keyboard key press.</summary>
    public event EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> KeyDownEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceKeyDownEvt_Args args = new Efl.Input.IInterfaceKeyDownEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Key);
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

                string key = "_EFL_EVENT_KEY_DOWN";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_KEY_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event KeyDownEvt.</summary>
    public void OnKeyDownEvt(Efl.Input.IInterfaceKeyDownEvt_Args e)
    {
        var key = "_EFL_EVENT_KEY_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Keyboard key release.</summary>
    public event EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> KeyUpEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceKeyUpEvt_Args args = new Efl.Input.IInterfaceKeyUpEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Key);
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

                string key = "_EFL_EVENT_KEY_UP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_KEY_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event KeyUpEvt.</summary>
    public void OnKeyUpEvt(Efl.Input.IInterfaceKeyUpEvt_Args e)
    {
        var key = "_EFL_EVENT_KEY_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>All input events are on hold or resumed.</summary>
    public event EventHandler<Efl.Input.IInterfaceHoldEvt_Args> HoldEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceHoldEvt_Args args = new Efl.Input.IInterfaceHoldEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Hold);
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

                string key = "_EFL_EVENT_HOLD";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_HOLD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event HoldEvt.</summary>
    public void OnHoldEvt(Efl.Input.IInterfaceHoldEvt_Args e)
    {
        var key = "_EFL_EVENT_HOLD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>A focus in event.</summary>
    public event EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> FocusInEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceFocusInEvt_Args args = new Efl.Input.IInterfaceFocusInEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
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

                string key = "_EFL_EVENT_FOCUS_IN";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusInEvt.</summary>
    public void OnFocusInEvt(Efl.Input.IInterfaceFocusInEvt_Args e)
    {
        var key = "_EFL_EVENT_FOCUS_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>A focus out event.</summary>
    public event EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> FocusOutEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Input.IInterfaceFocusOutEvt_Args args = new Efl.Input.IInterfaceFocusOutEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Focus);
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

                string key = "_EFL_EVENT_FOCUS_OUT";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_EVENT_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusOutEvt.</summary>
    public void OnFocusOutEvt(Efl.Input.IInterfaceFocusOutEvt_Args e)
    {
        var key = "_EFL_EVENT_FOCUS_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Check if input events from a given seat is enabled.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    public bool GetSeatEventFilter(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Input.IInterfaceConcrete.NativeMethods.efl_input_seat_event_filter_get_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
    public void SetSeatEventFilter(Efl.Input.Device seat, bool enable) {
                                                         Efl.Input.IInterfaceConcrete.NativeMethods.efl_input_seat_event_filter_set_ptr.Value.Delegate(this.NativeHandle,seat, enable);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.IInterfaceConcrete.efl_input_interface_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_input_seat_event_filter_get_static_delegate == null)
            {
                efl_input_seat_event_filter_get_static_delegate = new efl_input_seat_event_filter_get_delegate(seat_event_filter_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeatEventFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_seat_event_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_get_static_delegate) });
            }

            if (efl_input_seat_event_filter_set_static_delegate == null)
            {
                efl_input_seat_event_filter_set_static_delegate = new efl_input_seat_event_filter_set_delegate(seat_event_filter_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSeatEventFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_seat_event_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Input.IInterfaceConcrete.efl_input_interface_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_seat_event_filter_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate> efl_input_seat_event_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate>(Module, "efl_input_seat_event_filter_get");

        private static bool seat_event_filter_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_seat_event_filter_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IInterface)wrapper).GetSeatEventFilter(seat);
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
                return efl_input_seat_event_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_input_seat_event_filter_get_delegate efl_input_seat_event_filter_get_static_delegate;

        
        private delegate void efl_input_seat_event_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_input_seat_event_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate> efl_input_seat_event_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate>(Module, "efl_input_seat_event_filter_set");

        private static void seat_event_filter_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat, bool enable)
        {
            Eina.Log.Debug("function efl_input_seat_event_filter_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((IInterface)wrapper).SetSeatEventFilter(seat, enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_input_seat_event_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat, enable);
            }
        }

        private static efl_input_seat_event_filter_set_delegate efl_input_seat_event_filter_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

