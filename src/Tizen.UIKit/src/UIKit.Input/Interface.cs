#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

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
[UIKit.Input.InterfaceConcrete.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public interface IInterface : 
    UIKit.Wrapper.IWrapper, IDisposable
{
    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerMoveEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerMoveEventArgs> PointerMoveEvent;
    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerDownEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerDownEventArgs> PointerDownEvent;
    /// <summary>Main pointer button released (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerUpEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerUpEventArgs> PointerUpEvent;
    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerCancelEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerCancelEventArgs> PointerCancelEvent;
    /// <summary>Pointer entered a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerInEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerInEventArgs> PointerInEvent;
    /// <summary>Pointer left a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerOutEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerOutEventArgs> PointerOutEvent;
    /// <summary>Mouse wheel event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerWheelEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerWheelEventArgs> PointerWheelEvent;
    /// <summary>Pen or other axis event update.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerAxisEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfacePointerAxisEventArgs> PointerAxisEvent;
    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerMoveEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent;
    /// <summary>Finger pressed (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerDownEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceFingerDownEventArgs> FingerDownEvent;
    /// <summary>Finger released (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerUpEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceFingerUpEventArgs> FingerUpEvent;
    /// <summary>Keyboard key press.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceKeyDownEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceKeyDownEventArgs> KeyDownEvent;
    /// <summary>Keyboard key release.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceKeyUpEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceKeyUpEventArgs> KeyUpEvent;
    /// <summary>All input events are on hold or resumed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceHoldEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceHoldEventArgs> HoldEvent;
    /// <summary>A focus in event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFocusInEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceFocusInEventArgs> FocusInEvent;
    /// <summary>A focus out event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFocusOutEventArgs"/></value>
    event EventHandler<UIKit.Input.InterfaceFocusOutEventArgs> FocusOutEvent;
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerMoveEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer move (current and previous positions are known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerDownEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button pressed (button id is known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerUpEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button released (button id is known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerCancelEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerCancelEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerInEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerInEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer entered a window or a widget.</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerOutEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerOutEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pointer left a window or a widget.</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerWheelEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerWheelEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Mouse wheel event.</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.PointerAxisEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfacePointerAxisEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Pen or other axis event update.</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.FingerMoveEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceFingerMoveEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger moved (current and previous positions are known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.FingerDownEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceFingerDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger pressed (finger id is known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.FingerUpEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceFingerUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Finger released (finger id is known).</value>
    public UIKit.Input.Pointer arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.KeyDownEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceKeyDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key press.</value>
    public UIKit.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.KeyUpEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceKeyUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Keyboard key release.</value>
    public UIKit.Input.Key arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.HoldEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceHoldEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>All input events are on hold or resumed.</value>
    public UIKit.Input.Hold arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.FocusInEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceFocusInEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A focus in event.</value>
    public UIKit.Input.Focus arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="UIKit.Input.IInterface.FocusOutEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class InterfaceFocusOutEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>A focus out event.</value>
    public UIKit.Input.Focus arg { get; set; }
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
    UIKit.Wrapper.ObjectWrapper
    , IInterface
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(InterfaceConcrete))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private InterfaceConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Evas)] internal static extern System.IntPtr
        efl_input_interface_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IInterface"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private InterfaceConcrete(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Main pointer move (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerMoveEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerMoveEventArgs> PointerMoveEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerMoveEventArgs args = new UIKit.Input.InterfacePointerMoveEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_MOVE";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_MOVE";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerMoveEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerMoveEvent(UIKit.Input.InterfacePointerMoveEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_MOVE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Main pointer button pressed (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerDownEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerDownEventArgs> PointerDownEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerDownEventArgs args = new UIKit.Input.InterfacePointerDownEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_DOWN";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_DOWN";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerDownEvent(UIKit.Input.InterfacePointerDownEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_DOWN";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Main pointer button released (button id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerUpEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerUpEventArgs> PointerUpEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerUpEventArgs args = new UIKit.Input.InterfacePointerUpEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_UP";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_UP";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerUpEvent(UIKit.Input.InterfacePointerUpEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_UP";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerCancelEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerCancelEventArgs> PointerCancelEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerCancelEventArgs args = new UIKit.Input.InterfacePointerCancelEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_CANCEL";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerCancelEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerCancelEvent(UIKit.Input.InterfacePointerCancelEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_CANCEL";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Pointer entered a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerInEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerInEventArgs> PointerInEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerInEventArgs args = new UIKit.Input.InterfacePointerInEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_IN";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_IN";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerInEvent(UIKit.Input.InterfacePointerInEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_IN";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Pointer left a window or a widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerOutEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerOutEventArgs> PointerOutEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerOutEventArgs args = new UIKit.Input.InterfacePointerOutEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_OUT";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_OUT";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerOutEvent(UIKit.Input.InterfacePointerOutEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_OUT";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Mouse wheel event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerWheelEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerWheelEventArgs> PointerWheelEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerWheelEventArgs args = new UIKit.Input.InterfacePointerWheelEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_WHEEL";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerWheelEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerWheelEvent(UIKit.Input.InterfacePointerWheelEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_WHEEL";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Pen or other axis event update.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfacePointerAxisEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfacePointerAxisEventArgs> PointerAxisEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfacePointerAxisEventArgs args = new UIKit.Input.InterfacePointerAxisEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_POINTER_AXIS";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_POINTER_AXIS";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PointerAxisEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPointerAxisEvent(UIKit.Input.InterfacePointerAxisEventArgs e)
    {
        var key = "_EFL_EVENT_POINTER_AXIS";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Finger moved (current and previous positions are known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerMoveEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceFingerMoveEventArgs> FingerMoveEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceFingerMoveEventArgs args = new UIKit.Input.InterfaceFingerMoveEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_FINGER_MOVE";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_MOVE";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerMoveEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerMoveEvent(UIKit.Input.InterfaceFingerMoveEventArgs e)
    {
        var key = "_EFL_EVENT_FINGER_MOVE";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Finger pressed (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerDownEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceFingerDownEventArgs> FingerDownEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceFingerDownEventArgs args = new UIKit.Input.InterfaceFingerDownEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_FINGER_DOWN";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_DOWN";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerDownEvent(UIKit.Input.InterfaceFingerDownEventArgs e)
    {
        var key = "_EFL_EVENT_FINGER_DOWN";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Finger released (finger id is known).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFingerUpEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceFingerUpEventArgs> FingerUpEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceFingerUpEventArgs args = new UIKit.Input.InterfaceFingerUpEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Pointer);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_FINGER_UP";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FINGER_UP";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FingerUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFingerUpEvent(UIKit.Input.InterfaceFingerUpEventArgs e)
    {
        var key = "_EFL_EVENT_FINGER_UP";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Keyboard key press.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceKeyDownEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceKeyDownEventArgs> KeyDownEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceKeyDownEventArgs args = new UIKit.Input.InterfaceKeyDownEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Key);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_KEY_DOWN";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_KEY_DOWN";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event KeyDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnKeyDownEvent(UIKit.Input.InterfaceKeyDownEventArgs e)
    {
        var key = "_EFL_EVENT_KEY_DOWN";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Keyboard key release.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceKeyUpEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceKeyUpEventArgs> KeyUpEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceKeyUpEventArgs args = new UIKit.Input.InterfaceKeyUpEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Key);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_KEY_UP";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_KEY_UP";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event KeyUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnKeyUpEvent(UIKit.Input.InterfaceKeyUpEventArgs e)
    {
        var key = "_EFL_EVENT_KEY_UP";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>All input events are on hold or resumed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceHoldEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceHoldEventArgs> HoldEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceHoldEventArgs args = new UIKit.Input.InterfaceHoldEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Hold);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_HOLD";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_HOLD";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event HoldEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnHoldEvent(UIKit.Input.InterfaceHoldEventArgs e)
    {
        var key = "_EFL_EVENT_HOLD";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>A focus in event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFocusInEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceFocusInEventArgs> FocusInEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceFocusInEventArgs args = new UIKit.Input.InterfaceFocusInEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Focus);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_FOCUS_IN";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FOCUS_IN";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FocusInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusInEvent(UIKit.Input.InterfaceFocusInEventArgs e)
    {
        var key = "_EFL_EVENT_FOCUS_IN";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>A focus out event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Input.InterfaceFocusOutEventArgs"/></value>
    public event EventHandler<UIKit.Input.InterfaceFocusOutEventArgs> FocusOutEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Input.InterfaceFocusOutEventArgs args = new UIKit.Input.InterfaceFocusOutEventArgs();
                        args.arg = (UIKit.Wrapper.Globals.CreateWrapperFor(evt.Info) as UIKit.Input.Focus);
                    try
                    {
                        value?.Invoke(obj, args);
                    }
                    catch (Exception e)
                    {
                        UIKit.DataTypes.Log.Error(e.ToString());
                        UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }
                }
            };

            string key = "_EFL_EVENT_FOCUS_OUT";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_EVENT_FOCUS_OUT";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event FocusOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusOutEvent(UIKit.Input.InterfaceFocusOutEventArgs e)
    {
        var key = "_EFL_EVENT_FOCUS_OUT";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }


#pragma warning disable CS0628
#pragma warning restore CS0628
    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Input.InterfaceConcrete.efl_input_interface_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Wrapper.ObjectWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.Input.InterfaceConcrete.efl_input_interface_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKit_InputInterfaceConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
