#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gesture {

[Efl.Gesture.IEventsConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IEvents : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Event for tap gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureTapEvt_Args> GestureTapEvt;
    /// <summary>Event for double tap gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureDoubleTapEvt_Args> GestureDoubleTapEvt;
    /// <summary>Event for triple tap gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureTripleTapEvt_Args> GestureTripleTapEvt;
    /// <summary>Event for long tap gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureLongTapEvt_Args> GestureLongTapEvt;
    /// <summary>Event for momentum gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureMomentumEvt_Args> GestureMomentumEvt;
    /// <summary>Event for flick gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureFlickEvt_Args> GestureFlickEvt;
    /// <summary>Event for zoom gesture</summary>
    event EventHandler<Efl.Gesture.IEventsGestureZoomEvt_Args> GestureZoomEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureTapEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureTap arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureDoubleTapEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureDoubleTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureDoubleTap arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureTripleTapEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureTripleTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureTripleTap arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureLongTapEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureLongTapEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureLongTap arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureMomentumEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureMomentumEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureMomentum arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureFlickEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureFlickEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureFlick arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Gesture.IEvents.GestureZoomEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEventsGestureZoomEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Canvas.GestureZoom arg { get; set; }
}
sealed public class IEventsConcrete :
    Efl.Eo.EoWrapper
    , IEvents
    
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IEventsConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IEventsConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_gesture_events_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IEvents"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IEventsConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Event for tap gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureTapEvt_Args> GestureTapEvt
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
                        Efl.Gesture.IEventsGestureTapEvt_Args args = new Efl.Gesture.IEventsGestureTapEvt_Args();
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
    ///<summary>Method to raise event GestureTapEvt.</summary>
    public void OnGestureTapEvt(Efl.Gesture.IEventsGestureTapEvt_Args e)
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
    /// <summary>Event for double tap gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureDoubleTapEvt_Args> GestureDoubleTapEvt
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
                        Efl.Gesture.IEventsGestureDoubleTapEvt_Args args = new Efl.Gesture.IEventsGestureDoubleTapEvt_Args();
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
    ///<summary>Method to raise event GestureDoubleTapEvt.</summary>
    public void OnGestureDoubleTapEvt(Efl.Gesture.IEventsGestureDoubleTapEvt_Args e)
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
    /// <summary>Event for triple tap gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureTripleTapEvt_Args> GestureTripleTapEvt
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
                        Efl.Gesture.IEventsGestureTripleTapEvt_Args args = new Efl.Gesture.IEventsGestureTripleTapEvt_Args();
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
    ///<summary>Method to raise event GestureTripleTapEvt.</summary>
    public void OnGestureTripleTapEvt(Efl.Gesture.IEventsGestureTripleTapEvt_Args e)
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
    /// <summary>Event for long tap gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureLongTapEvt_Args> GestureLongTapEvt
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
                        Efl.Gesture.IEventsGestureLongTapEvt_Args args = new Efl.Gesture.IEventsGestureLongTapEvt_Args();
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
    ///<summary>Method to raise event GestureLongTapEvt.</summary>
    public void OnGestureLongTapEvt(Efl.Gesture.IEventsGestureLongTapEvt_Args e)
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
    /// <summary>Event for momentum gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureMomentumEvt_Args> GestureMomentumEvt
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
                        Efl.Gesture.IEventsGestureMomentumEvt_Args args = new Efl.Gesture.IEventsGestureMomentumEvt_Args();
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
    ///<summary>Method to raise event GestureMomentumEvt.</summary>
    public void OnGestureMomentumEvt(Efl.Gesture.IEventsGestureMomentumEvt_Args e)
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
    /// <summary>Event for flick gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureFlickEvt_Args> GestureFlickEvt
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
                        Efl.Gesture.IEventsGestureFlickEvt_Args args = new Efl.Gesture.IEventsGestureFlickEvt_Args();
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
    ///<summary>Method to raise event GestureFlickEvt.</summary>
    public void OnGestureFlickEvt(Efl.Gesture.IEventsGestureFlickEvt_Args e)
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
    /// <summary>Event for zoom gesture</summary>
    public event EventHandler<Efl.Gesture.IEventsGestureZoomEvt_Args> GestureZoomEvt
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
                        Efl.Gesture.IEventsGestureZoomEvt_Args args = new Efl.Gesture.IEventsGestureZoomEvt_Args();
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
    ///<summary>Method to raise event GestureZoomEvt.</summary>
    public void OnGestureZoomEvt(Efl.Gesture.IEventsGestureZoomEvt_Args e)
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gesture.IEventsConcrete.efl_gesture_events_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gesture.IEventsConcrete.efl_gesture_events_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

