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
[Efl.Input.IInterfaceConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IInterface : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Check if input events from a given seat is enabled.
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="seat">The seat to act on.</param>
/// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
bool GetSeatEventFilter(Efl.Input.Device seat);
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
/// 
/// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
/// <param name="seat">The seat to act on.</param>
/// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
void SetSeatEventFilter(Efl.Input.Device seat, bool enable);
            /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerMoveEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> PointerMoveEvt;
    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerDownEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> PointerDownEvt;
    /// <summary>Main pointer button released (button id is known).</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerUpEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> PointerUpEvt;
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerCancelEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> PointerCancelEvt;
    /// <summary>Pointer entered a window or a widget.</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerInEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerInEvt_Args> PointerInEvt;
    /// <summary>Pointer left a window or a widget.</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerOutEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> PointerOutEvt;
    /// <summary>Mouse wheel event.</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerWheelEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> PointerWheelEvt;
    /// <summary>Pen or other axis event update.</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerAxisEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> PointerAxisEvt;
    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <value><see cref="Efl.Input.IInterfaceFingerMoveEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> FingerMoveEvt;
    /// <summary>Finger pressed (finger id is known).</summary>
    /// <value><see cref="Efl.Input.IInterfaceFingerDownEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> FingerDownEvt;
    /// <summary>Finger released (finger id is known).</summary>
    /// <value><see cref="Efl.Input.IInterfaceFingerUpEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> FingerUpEvt;
    /// <summary>Keyboard key press.</summary>
    /// <value><see cref="Efl.Input.IInterfaceKeyDownEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> KeyDownEvt;
    /// <summary>Keyboard key release.</summary>
    /// <value><see cref="Efl.Input.IInterfaceKeyUpEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> KeyUpEvt;
    /// <summary>All input events are on hold or resumed.</summary>
    /// <value><see cref="Efl.Input.IInterfaceHoldEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceHoldEvt_Args> HoldEvt;
    /// <summary>A focus in event.</summary>
    /// <value><see cref="Efl.Input.IInterfaceFocusInEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> FocusInEvt;
    /// <summary>A focus out event.</summary>
    /// <value><see cref="Efl.Input.IInterfaceFocusOutEvt_Args"/></value>
    event EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> FocusOutEvt;
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerMoveEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerMoveEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer move (current and previous positions are known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerDownEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerDownEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button pressed (button id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerUpEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerUpEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button released (button id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerCancelEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerCancelEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerInEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerInEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer entered a window or a widget.</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerOutEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerOutEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer left a window or a widget.</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerWheelEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerWheelEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Mouse wheel event.</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.PointerAxisEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfacePointerAxisEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pen or other axis event update.</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerMoveEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceFingerMoveEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger moved (current and previous positions are known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerDownEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceFingerDownEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger pressed (finger id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FingerUpEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceFingerUpEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger released (finger id is known).</value>
    public Efl.Input.Pointer arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyDownEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceKeyDownEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key press.</value>
    public Efl.Input.Key arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.KeyUpEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceKeyUpEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key release.</value>
    public Efl.Input.Key arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.HoldEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceHoldEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>All input events are on hold or resumed.</value>
    public Efl.Input.Hold arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusInEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceFocusInEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A focus in event.</value>
    public Efl.Input.Focus arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Input.IInterface.FocusOutEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IInterfaceFocusOutEvt_Args : EventArgs {
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
sealed public  class IInterfaceConcrete :
    Efl.Eo.EoWrapper
    , IInterface
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
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

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IInterfaceConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IInterface"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IInterfaceConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <value><see cref="Efl.Input.IInterfacePointerMoveEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerMoveEvt_Args> PointerMoveEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerMoveEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerDownEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerDownEvt_Args> PointerDownEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerDownEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerUpEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerUpEvt_Args> PointerUpEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerUpEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerCancelEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerCancelEvt_Args> PointerCancelEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerCancelEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerInEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerInEvt_Args> PointerInEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerInEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerOutEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerOutEvt_Args> PointerOutEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerOutEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerWheelEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerWheelEvt_Args> PointerWheelEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerWheelEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfacePointerAxisEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfacePointerAxisEvt_Args> PointerAxisEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_POINTER_AXIS";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PointerAxisEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceFingerMoveEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceFingerMoveEvt_Args> FingerMoveEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_MOVE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event FingerMoveEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceFingerDownEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceFingerDownEvt_Args> FingerDownEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event FingerDownEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceFingerUpEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceFingerUpEvt_Args> FingerUpEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FINGER_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event FingerUpEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceKeyDownEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceKeyDownEvt_Args> KeyDownEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_KEY_DOWN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event KeyDownEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceKeyUpEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceKeyUpEvt_Args> KeyUpEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_KEY_UP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event KeyUpEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceHoldEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceHoldEvt_Args> HoldEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_HOLD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event HoldEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceFocusInEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceFocusInEvt_Args> FocusInEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event FocusInEvt.</summary>
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
    /// <value><see cref="Efl.Input.IInterfaceFocusOutEvt_Args"/></value>
    public event EventHandler<Efl.Input.IInterfaceFocusOutEvt_Args> FocusOutEvt
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
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event FocusOutEvt.</summary>
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
    /// <summary>Check if input events from a given seat is enabled.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    public bool GetSeatEventFilter(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Input.IInterfaceConcrete.NativeMethods.efl_input_seat_event_filter_get_ptr.Value.Delegate(this.NativeHandle,seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
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
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
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
public static class Efl_InputIInterfaceConcrete_ExtensionMethods {
    
}
#pragma warning restore CS1591
#endif
