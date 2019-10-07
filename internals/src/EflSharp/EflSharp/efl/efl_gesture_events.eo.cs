#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gesture {

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gesture.EventsConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IEvents : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Emitted when a Tap gesture has been detected. A Tap gesture consists of a touch of the screen (or click of the mouse) quickly followed by a release. If the release happens too late a <see cref="Efl.Gesture.IEvents.GestureLongTapEvent"/> event will be emitted instead.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureTapEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureTapEventArgs> GestureTapEvent;
    /// <summary>Emitted when a Double-tap gesture has been detected. A Double-tap gesture consists of two taps on the screen (or clicks of the mouse) in quick succession. If the second one is delayed for too long they will be detected as two independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> events.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureDoubleTapEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureDoubleTapEventArgs> GestureDoubleTapEvent;
    /// <summary>Emitted when a Triple-tap gesture has been detected. A Triple-tap gesture consists of three taps on the screen (or clicks of the mouse) in quick succession. If any of them is delayed for too long they will be detected as independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> or <see cref="Efl.Gesture.IEvents.GestureDoubleTapEvent"/> events.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureTripleTapEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureTripleTapEventArgs> GestureTripleTapEvent;
    /// <summary>Emitted when a Long-tap gesture has been detected. A Long-tap gesture consists of a touch of the screen (or click of the mouse) followed by a release after some time. If the release happens too quickly a <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> event will be emitted instead.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureLongTapEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureLongTapEventArgs> GestureLongTapEvent;
    /// <summary>Emitted when a Momentum gesture has been detected. A Momentum gesture consists of a quick displacement of the finger while touching the screen (or while holding down a mouse button).</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureMomentumEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureMomentumEventArgs> GestureMomentumEvent;
    /// <summary>Emitted when a Flick gesture has been detected.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureFlickEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureFlickEventArgs> GestureFlickEvent;
    /// <summary>Emitted when a Zoom gesture has been detected. A Zoom gesture consists of two fingers touching the screen and separating (&quot;zoom in&quot;) or getting closer (&quot;zoom out&quot; or &quot;pinch&quot;). This gesture cannot be performed with a mouse as it requires more than one pointer.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureZoomEventArgs"/></value>
    event EventHandler<Efl.Gesture.EventsGestureZoomEventArgs> GestureZoomEvent;
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureTapEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureTapEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Tap gesture has been detected. A Tap gesture consists of a touch of the screen (or click of the mouse) quickly followed by a release. If the release happens too late a <see cref="Efl.Gesture.IEvents.GestureLongTapEvent"/> event will be emitted instead.</value>
    public Efl.Canvas.GestureTap arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureDoubleTapEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureDoubleTapEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Double-tap gesture has been detected. A Double-tap gesture consists of two taps on the screen (or clicks of the mouse) in quick succession. If the second one is delayed for too long they will be detected as two independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> events.</value>
    public Efl.Canvas.GestureDoubleTap arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureTripleTapEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureTripleTapEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Triple-tap gesture has been detected. A Triple-tap gesture consists of three taps on the screen (or clicks of the mouse) in quick succession. If any of them is delayed for too long they will be detected as independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> or <see cref="Efl.Gesture.IEvents.GestureDoubleTapEvent"/> events.</value>
    public Efl.Canvas.GestureTripleTap arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureLongTapEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureLongTapEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Long-tap gesture has been detected. A Long-tap gesture consists of a touch of the screen (or click of the mouse) followed by a release after some time. If the release happens too quickly a <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> event will be emitted instead.</value>
    public Efl.Canvas.GestureLongTap arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureMomentumEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureMomentumEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Momentum gesture has been detected. A Momentum gesture consists of a quick displacement of the finger while touching the screen (or while holding down a mouse button).</value>
    public Efl.Canvas.GestureMomentum arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureFlickEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureFlickEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Flick gesture has been detected.</value>
    public Efl.Canvas.GestureFlick arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureZoomEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class EventsGestureZoomEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a Zoom gesture has been detected. A Zoom gesture consists of two fingers touching the screen and separating (&quot;zoom in&quot;) or getting closer (&quot;zoom out&quot; or &quot;pinch&quot;). This gesture cannot be performed with a mouse as it requires more than one pointer.</value>
    public Efl.Canvas.GestureZoom arg { get; set; }
}

/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class EventsConcrete :
    Efl.Eo.EoWrapper
    , IEvents
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(EventsConcrete))
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
    private EventsConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_gesture_events_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IEvents"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private EventsConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted when a Tap gesture has been detected. A Tap gesture consists of a touch of the screen (or click of the mouse) quickly followed by a release. If the release happens too late a <see cref="Efl.Gesture.IEvents.GestureLongTapEvent"/> event will be emitted instead.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureTapEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureTapEventArgs> GestureTapEvent
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
                        Efl.Gesture.EventsGestureTapEventArgs args = new Efl.Gesture.EventsGestureTapEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureTap);
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

                string key = "_EFL_EVENT_GESTURE_TAP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_TAP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureTapEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureTapEvent(Efl.Gesture.EventsGestureTapEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_TAP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Double-tap gesture has been detected. A Double-tap gesture consists of two taps on the screen (or clicks of the mouse) in quick succession. If the second one is delayed for too long they will be detected as two independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> events.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureDoubleTapEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureDoubleTapEventArgs> GestureDoubleTapEvent
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
                        Efl.Gesture.EventsGestureDoubleTapEventArgs args = new Efl.Gesture.EventsGestureDoubleTapEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureDoubleTap);
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

                string key = "_EFL_EVENT_GESTURE_DOUBLE_TAP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_DOUBLE_TAP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureDoubleTapEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureDoubleTapEvent(Efl.Gesture.EventsGestureDoubleTapEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_DOUBLE_TAP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Triple-tap gesture has been detected. A Triple-tap gesture consists of three taps on the screen (or clicks of the mouse) in quick succession. If any of them is delayed for too long they will be detected as independent <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> or <see cref="Efl.Gesture.IEvents.GestureDoubleTapEvent"/> events.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureTripleTapEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureTripleTapEventArgs> GestureTripleTapEvent
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
                        Efl.Gesture.EventsGestureTripleTapEventArgs args = new Efl.Gesture.EventsGestureTripleTapEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureTripleTap);
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

                string key = "_EFL_EVENT_GESTURE_TRIPLE_TAP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_TRIPLE_TAP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureTripleTapEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureTripleTapEvent(Efl.Gesture.EventsGestureTripleTapEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_TRIPLE_TAP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Long-tap gesture has been detected. A Long-tap gesture consists of a touch of the screen (or click of the mouse) followed by a release after some time. If the release happens too quickly a <see cref="Efl.Gesture.IEvents.GestureTapEvent"/> event will be emitted instead.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureLongTapEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureLongTapEventArgs> GestureLongTapEvent
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
                        Efl.Gesture.EventsGestureLongTapEventArgs args = new Efl.Gesture.EventsGestureLongTapEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureLongTap);
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

                string key = "_EFL_EVENT_GESTURE_LONG_TAP";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_LONG_TAP";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureLongTapEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureLongTapEvent(Efl.Gesture.EventsGestureLongTapEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_LONG_TAP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Momentum gesture has been detected. A Momentum gesture consists of a quick displacement of the finger while touching the screen (or while holding down a mouse button).</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureMomentumEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureMomentumEventArgs> GestureMomentumEvent
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
                        Efl.Gesture.EventsGestureMomentumEventArgs args = new Efl.Gesture.EventsGestureMomentumEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureMomentum);
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

                string key = "_EFL_EVENT_GESTURE_MOMENTUM";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_MOMENTUM";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureMomentumEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureMomentumEvent(Efl.Gesture.EventsGestureMomentumEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_MOMENTUM";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Flick gesture has been detected.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureFlickEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureFlickEventArgs> GestureFlickEvent
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
                        Efl.Gesture.EventsGestureFlickEventArgs args = new Efl.Gesture.EventsGestureFlickEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureFlick);
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

                string key = "_EFL_EVENT_GESTURE_FLICK";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_FLICK";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureFlickEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureFlickEvent(Efl.Gesture.EventsGestureFlickEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_FLICK";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <summary>Emitted when a Zoom gesture has been detected. A Zoom gesture consists of two fingers touching the screen and separating (&quot;zoom in&quot;) or getting closer (&quot;zoom out&quot; or &quot;pinch&quot;). This gesture cannot be performed with a mouse as it requires more than one pointer.</summary>
    /// <value><see cref="Efl.Gesture.EventsGestureZoomEventArgs"/></value>
    public event EventHandler<Efl.Gesture.EventsGestureZoomEventArgs> GestureZoomEvent
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
                        Efl.Gesture.EventsGestureZoomEventArgs args = new Efl.Gesture.EventsGestureZoomEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Canvas.GestureZoom);
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

                string key = "_EFL_EVENT_GESTURE_ZOOM";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_EVENT_GESTURE_ZOOM";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }

    /// <summary>Method to raise event GestureZoomEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnGestureZoomEvent(Efl.Gesture.EventsGestureZoomEventArgs e)
    {
        var key = "_EFL_EVENT_GESTURE_ZOOM";
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
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gesture.EventsConcrete.efl_gesture_events_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Gesture.EventsConcrete.efl_gesture_events_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GestureEventsConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
