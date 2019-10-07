#define EFL_BETA
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
/// <since_tizen> 6 </since_tizen>
[Efl.Input.InterfaceConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IInterface : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Whether input events from a given seat are enabled. If the filter list is empty (no seat is disabled) this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is not in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    bool GetSeatEventFilter(Efl.Input.Device seat);

    /// <summary>Whether input events from a given seat are enabled. If the filter list is empty (no seat is disabled) this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is not in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="seat">The seat to act on.</param>
    /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
    void SetSeatEventFilter(Efl.Input.Device seat, bool enable);

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerMoveEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerMoveEventArgs> PointerMoveEvent;
    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerDownEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerDownEventArgs> PointerDownEvent;
    /// <summary>Main pointer button released (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerUpEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerUpEventArgs> PointerUpEvent;
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerCancelEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerCancelEventArgs> PointerCancelEvent;
    /// <summary>Pointer entered a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerInEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerInEventArgs> PointerInEvent;
    /// <summary>Pointer left a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerOutEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerOutEventArgs> PointerOutEvent;
    /// <summary>Mouse wheel event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerWheelEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerWheelEventArgs> PointerWheelEvent;
    /// <summary>Pen or other axis event update.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerAxisEventArgs"/></value>
    event EventHandler<Efl.Input.InterfacePointerAxisEventArgs> PointerAxisEvent;
    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerMoveEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent;
    /// <summary>Finger pressed (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerDownEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceFingerDownEventArgs> FingerDownEvent;
    /// <summary>Finger released (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerUpEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceFingerUpEventArgs> FingerUpEvent;
    /// <summary>Keyboard key press.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceKeyDownEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceKeyDownEventArgs> KeyDownEvent;
    /// <summary>Keyboard key release.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceKeyUpEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceKeyUpEventArgs> KeyUpEvent;
    /// <summary>All input events are on hold or resumed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceHoldEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceHoldEventArgs> HoldEvent;
    /// <summary>A focus in event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFocusInEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceFocusInEventArgs> FocusInEvent;
    /// <summary>A focus out event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFocusOutEventArgs"/></value>
    event EventHandler<Efl.Input.InterfaceFocusOutEventArgs> FocusOutEvent;
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerMoveEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer move (current and previous positions are known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerDownEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button pressed (button id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerUpEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button released (button id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerCancelEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerCancelEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerInEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerInEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer entered a window or a widget.</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerOutEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerOutEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer left a window or a widget.</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerWheelEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerWheelEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Mouse wheel event.</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerAxisEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfacePointerAxisEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pen or other axis event update.</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerMoveEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceFingerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger moved (current and previous positions are known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerDownEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceFingerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger pressed (finger id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerUpEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceFingerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger released (finger id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyDownEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceKeyDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key press.</value>
    public Efl.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyUpEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceKeyUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key release.</value>
    public Efl.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.HoldEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceHoldEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>All input events are on hold or resumed.</value>
    public Efl.Input.Hold arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusInEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceFocusInEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A focus in event.</value>
    public Efl.Input.Focus arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusOutEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class InterfaceFocusOutEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A focus out event.</value>
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
/// <since_tizen> 6 </since_tizen>
public sealed class InterfaceConcrete :
    Efl.Eo.EoWrapper
    , IInterface
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(InterfaceConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private InterfaceConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IInterface"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private InterfaceConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerMoveEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerMoveEventArgs> PointerMoveEvent
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
                        Efl.Input.InterfacePointerMoveEventArgs args = new Efl.Input.InterfacePointerMoveEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerMoveEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerMoveEvent(Efl.Input.InterfacePointerMoveEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerDownEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerDownEventArgs> PointerDownEvent
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
                        Efl.Input.InterfacePointerDownEventArgs args = new Efl.Input.InterfacePointerDownEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerDownEvent(Efl.Input.InterfacePointerDownEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerUpEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerUpEventArgs> PointerUpEvent
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
                        Efl.Input.InterfacePointerUpEventArgs args = new Efl.Input.InterfacePointerUpEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerUpEvent(Efl.Input.InterfacePointerUpEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerCancelEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerCancelEventArgs> PointerCancelEvent
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
                        Efl.Input.InterfacePointerCancelEventArgs args = new Efl.Input.InterfacePointerCancelEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerCancelEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerCancelEvent(Efl.Input.InterfacePointerCancelEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerInEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerInEventArgs> PointerInEvent
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
                        Efl.Input.InterfacePointerInEventArgs args = new Efl.Input.InterfacePointerInEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerInEvent(Efl.Input.InterfacePointerInEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerOutEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerOutEventArgs> PointerOutEvent
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
                        Efl.Input.InterfacePointerOutEventArgs args = new Efl.Input.InterfacePointerOutEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerOutEvent(Efl.Input.InterfacePointerOutEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerWheelEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerWheelEventArgs> PointerWheelEvent
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
                        Efl.Input.InterfacePointerWheelEventArgs args = new Efl.Input.InterfacePointerWheelEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerWheelEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerWheelEvent(Efl.Input.InterfacePointerWheelEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfacePointerAxisEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfacePointerAxisEventArgs> PointerAxisEvent
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
                        Efl.Input.InterfacePointerAxisEventArgs args = new Efl.Input.InterfacePointerAxisEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_AXIS";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event PointerAxisEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerAxisEvent(Efl.Input.InterfacePointerAxisEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerMoveEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent
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
                        Efl.Input.InterfaceFingerMoveEventArgs args = new Efl.Input.InterfaceFingerMoveEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event FingerMoveEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerMoveEvent(Efl.Input.InterfaceFingerMoveEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerDownEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceFingerDownEventArgs> FingerDownEvent
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
                        Efl.Input.InterfaceFingerDownEventArgs args = new Efl.Input.InterfaceFingerDownEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event FingerDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerDownEvent(Efl.Input.InterfaceFingerDownEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFingerUpEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceFingerUpEventArgs> FingerUpEvent
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
                        Efl.Input.InterfaceFingerUpEventArgs args = new Efl.Input.InterfaceFingerUpEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event FingerUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerUpEvent(Efl.Input.InterfaceFingerUpEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceKeyDownEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceKeyDownEventArgs> KeyDownEvent
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
                        Efl.Input.InterfaceKeyDownEventArgs args = new Efl.Input.InterfaceKeyDownEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_KEY_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event KeyDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnKeyDownEvent(Efl.Input.InterfaceKeyDownEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceKeyUpEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceKeyUpEventArgs> KeyUpEvent
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
                        Efl.Input.InterfaceKeyUpEventArgs args = new Efl.Input.InterfaceKeyUpEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_KEY_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event KeyUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnKeyUpEvent(Efl.Input.InterfaceKeyUpEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceHoldEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceHoldEventArgs> HoldEvent
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
                        Efl.Input.InterfaceHoldEventArgs args = new Efl.Input.InterfaceHoldEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_HOLD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event HoldEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnHoldEvent(Efl.Input.InterfaceHoldEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFocusInEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceFocusInEventArgs> FocusInEvent
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
                        Efl.Input.InterfaceFocusInEventArgs args = new Efl.Input.InterfaceFocusInEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event FocusInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusInEvent(Efl.Input.InterfaceFocusInEventArgs e)
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
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Input.InterfaceFocusOutEventArgs"/></value>
    public event EventHandler<Efl.Input.InterfaceFocusOutEventArgs> FocusOutEvent
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
                        Efl.Input.InterfaceFocusOutEventArgs args = new Efl.Input.InterfaceFocusOutEventArgs();
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event FocusOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusOutEvent(Efl.Input.InterfaceFocusOutEventArgs e)
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


#pragma warning disable CS0628
    /// <summary>Whether input events from a given seat are enabled. If the filter list is empty (no seat is disabled) this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is not in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    public bool GetSeatEventFilter(Efl.Input.Device seat) {
        var _ret_var = Efl.Input.InterfaceConcrete.NativeMethods.efl_input_seat_event_filter_get_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether input events from a given seat are enabled. If the filter list is empty (no seat is disabled) this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is not in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="seat">The seat to act on.</param>
    /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
    public void SetSeatEventFilter(Efl.Input.Device seat, bool enable) {
        Efl.Input.InterfaceConcrete.NativeMethods.efl_input_seat_event_filter_set_ptr.Value.Delegate(this.NativeHandle,seat, enable);
        Eina.Error.RaiseIfUnhandledException();
        
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.InterfaceConcrete.efl_input_interface_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Input.InterfaceConcrete.efl_input_interface_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_seat_event_filter_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate> efl_input_seat_event_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate>(Module, "efl_input_seat_event_filter_get");

        private static bool seat_event_filter_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_seat_event_filter_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IInterface)ws.Target).GetSeatEventFilter(seat);
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
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IInterface)ws.Target).SetSeatEventFilter(seat, enable);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_InputInterfaceConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
