#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.Object.AnimatorTickEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectAnimatorTickEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Animator tick synchronized with screen vsync if possible.</value>
    public Efl.EventAnimatorTick arg { get; set; }
}
/// <summary>Efl canvas object abstract class
/// (Since EFL 1.22)</summary>
[Efl.Canvas.Object.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Object : Efl.LoopConsumer, Efl.Canvas.IPointer, Efl.Gesture.IEvents, Efl.Gfx.IColor, Efl.Gfx.IEntity, Efl.Gfx.IHint, Efl.Gfx.IMapping, Efl.Gfx.IStack, Efl.Input.IInterface
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Object))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_object_class_get();
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Object(Efl.Object parent= null
            ) : base(efl_canvas_object_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Object(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Object(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class ObjectRealized : Object
    {
        private ObjectRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Object(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Animator tick synchronized with screen vsync if possible.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.ObjectAnimatorTickEvt_Args"/></value>
    public event EventHandler<Efl.Canvas.ObjectAnimatorTickEvt_Args> AnimatorTickEvt
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
                        Efl.Canvas.ObjectAnimatorTickEvt_Args args = new Efl.Canvas.ObjectAnimatorTickEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event AnimatorTickEvt.</summary>
    public void OnAnimatorTickEvt(Efl.Canvas.ObjectAnimatorTickEvt_Args e)
    {
        var key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Event for tap gesture</summary>
    /// <value><see cref="Efl.Gesture.IEventsGestureTapEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureTapEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureDoubleTapEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureDoubleTapEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureTripleTapEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureTripleTapEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureLongTapEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureLongTapEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureMomentumEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureMomentumEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureFlickEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureFlickEvt.</summary>
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
    /// <value><see cref="Efl.Gesture.IEventsGestureZoomEvt_Args"/></value>
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
    /// <summary>Method to raise event GestureZoomEvt.</summary>
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
    /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Gfx.IEntityVisibilityChangedEvt_Args"/></value>
    public event EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> VisibilityChangedEvt
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
                        Efl.Gfx.IEntityVisibilityChangedEvt_Args args = new Efl.Gfx.IEntityVisibilityChangedEvt_Args();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event VisibilityChangedEvt.</summary>
    public void OnVisibilityChangedEvt(Efl.Gfx.IEntityVisibilityChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object was moved, its position during the event is the new one.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Gfx.IEntityPositionChangedEvt_Args"/></value>
    public event EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> PositionChangedEvt
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
                        Efl.Gfx.IEntityPositionChangedEvt_Args args = new Efl.Gfx.IEntityPositionChangedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event PositionChangedEvt.</summary>
    public void OnPositionChangedEvt(Efl.Gfx.IEntityPositionChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object was resized, its size during the event is the new one.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Gfx.IEntitySizeChangedEvt_Args"/></value>
    public event EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> SizeChangedEvt
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
                        Efl.Gfx.IEntitySizeChangedEvt_Args args = new Efl.Gfx.IEntitySizeChangedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event SizeChangedEvt.</summary>
    public void OnSizeChangedEvt(Efl.Gfx.IEntitySizeChangedEvt_Args e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Object hints changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler HintsChangedEvt
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
                        EventArgs args = EventArgs.Empty;
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

                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event HintsChangedEvt.</summary>
    public void OnHintsChangedEvt(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Object stacking was changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler StackingChangedEvt
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
                        EventArgs args = EventArgs.Empty;
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

                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event StackingChangedEvt.</summary>
    public void OnStackingChangedEvt(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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
    /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
    /// <returns>The pointer mode</returns>
    virtual public Efl.Input.ObjectPointerMode GetPointerModeByDevice(Efl.Input.Device dev) {
                                 var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_pointer_mode_by_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
    /// <param name="pointer_mode">The pointer mode</param>
    /// <returns><c>true</c> if pointer mode was set, <c>false</c> otherwise</returns>
    virtual public bool SetPointerModeByDevice(Efl.Input.Device dev, Efl.Input.ObjectPointerMode pointer_mode) {
                                                         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_pointer_mode_by_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev, pointer_mode);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Low-level pointer behaviour.
    /// This function has a direct effect on event callbacks related to pointers (mouse, ...).
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
    /// 
    /// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>Input pointer mode</returns>
    virtual public Efl.Input.ObjectPointerMode GetPointerMode() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_pointer_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Low-level pointer behaviour.
    /// This function has a direct effect on event callbacks related to pointers (mouse, ...).
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
    /// 
    /// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="pointer_mode">Input pointer mode</param>
    /// <returns><c>true</c> if pointer behaviour was set, <c>false</c> otherwise</returns>
    virtual public bool SetPointerMode(Efl.Input.ObjectPointerMode pointer_mode) {
                                 var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_pointer_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pointer_mode);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).
    /// (Since EFL 1.22)</summary>
    /// <returns>Blend or copy.</returns>
    virtual public Efl.Gfx.RenderOp GetRenderOp() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_render_op_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).
    /// (Since EFL 1.22)</summary>
    /// <param name="render_op">Blend or copy.</param>
    virtual public void SetRenderOp(Efl.Gfx.RenderOp render_op) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_render_op_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),render_op);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the object clipping <c>obj</c> (if any).
    /// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The object to clip <c>obj</c> by.</returns>
    virtual public Efl.Canvas.Object GetClipper() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clip one object to another.
    /// This function will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
    /// 
    /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
    /// 
    /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
    /// 
    /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
    /// 
    /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="Efl.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
    /// 
    /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
    /// 
    /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
    /// 
    /// Note: Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.
    /// (Since EFL 1.22)</summary>
    /// <param name="clipper">The object to clip <c>obj</c> by.</param>
    virtual public void SetClipper(Efl.Canvas.Object clipper) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_clipper_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),clipper);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A hint for an object that its size will not change.
    /// When this flag is set, various optimizations may be employed by the renderer based on the fixed size of the object.
    /// 
    /// It is a user error to change the size of an object while this flag is set.
    /// (Since EFL 1.23)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>Whether the object size is known to be static.</returns>
    virtual public bool GetHasFixedSize() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_has_fixed_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A hint for an object that its size will not change.
    /// When this flag is set, various optimizations may be employed by the renderer based on the fixed size of the object.
    /// 
    /// It is a user error to change the size of an object while this flag is set.
    /// (Since EFL 1.23)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="enable">Whether the object size is known to be static.</param>
    virtual public void SetHasFixedSize(bool enable) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_has_fixed_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Determine whether an object is set to repeat events.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</returns>
    virtual public bool GetRepeatEvents() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether an Evas object is to repeat events.
    /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="Efl.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.
    /// (Since EFL 1.22)</summary>
    /// <param name="repeat">Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</param>
    virtual public void SetRepeatEvents(bool repeat) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),repeat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> when set as focused or <c>false</c> otherwise.</returns>
    virtual public bool GetKeyFocus() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus"><c>true</c> when set as focused or <c>false</c> otherwise.</param>
    virtual public void SetKeyFocus(bool focus) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Check if this object is focused.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</returns>
    virtual public bool GetSeatFocus() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Determine whether an object is set to use precise point collision detection.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether to use precise point collision detection or not. The default value is false.</returns>
    virtual public bool GetPreciseIsInside() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether to use precise (usually expensive) point collision detection for a given Evas object.
    /// Use this function to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
    /// 
    /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.
    /// (Since EFL 1.22)</summary>
    /// <param name="precise">Whether to use precise point collision detection or not. The default value is false.</param>
    virtual public void SetPreciseIsInside(bool precise) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),precise);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve whether an Evas object is set to propagate events.
    /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether to propagate events (<c>true</c>) or not (<c>false</c>).</returns>
    virtual public bool GetPropagateEvents() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether events on a smart object&apos;s member should be propagated up to its parent.
    /// This function has no effect if <c>obj</c> is not a member of a smart object.
    /// 
    /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member. The default value is <c>true</c>.
    /// 
    /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPassEvents"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="propagate">Whether to propagate events (<c>true</c>) or not (<c>false</c>).</param>
    virtual public void SetPropagateEvents(bool propagate) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),propagate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Determine whether an object is set to pass (ignore) events.
    /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</returns>
    virtual public bool GetPassEvents() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether an Evas object is to pass (ignore) events.
    /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="Efl.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
    /// 
    /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPropagateEvents"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="pass">Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</param>
    virtual public void SetPassEvents(bool pass) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pass);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</returns>
    virtual public bool GetAntiAlias() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets whether or not the given Evas object is to be drawn anti-aliased.
    /// (Since EFL 1.22)</summary>
    /// <param name="anti_alias"><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</param>
    virtual public void SetAntiAlias(bool anti_alias) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),anti_alias);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Return a list of objects currently clipped by <c>obj</c>.
    /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
    /// 
    /// See also <see cref="Efl.Canvas.Object.Clipper"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the list of objects clipped by <c>obj</c>.</returns>
    virtual public Eina.Iterator<Efl.Canvas.Object> GetClippedObjects() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, false);
 }
    /// <summary>Gets the parent smart object of a given Evas object, if it has one.
    /// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
    /// (Since EFL 1.22)</summary>
    /// <returns>The parent smart object of <c>obj</c> or <c>null</c>.</returns>
    virtual protected Efl.Canvas.Object GetRenderParent() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_render_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Paragraph direction for the given object.</returns>
    virtual public Efl.TextBidirectionalType GetParagraphDirection() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="dir">Paragraph direction for the given object.</param>
    virtual public void SetParagraphDirection(Efl.TextBidirectionalType dir) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
    /// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
    /// (Since EFL 1.22)</summary>
    /// <returns>Enable &quot;no-render&quot; mode.</returns>
    virtual public bool GetNoRender() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_no_render_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Disable all rendering on the canvas.
    /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
    /// 
    /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.
    /// (Since EFL 1.22)</summary>
    /// <param name="enable">Enable &quot;no-render&quot; mode.</param>
    virtual public void SetNoRender(bool enable) {
                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_no_render_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns whether the coords are logically inside the object.
    /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on if the coords are inside the object&apos;s current geometry.
    /// 
    /// A return value of <c>true</c> indicates the position is logically inside the object, and <c>false</c> implies it is logically outside the object.
    /// 
    /// If <c>e</c> is not a valid object, the return value is undefined.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">The position in pixels.</param>
    /// <returns><c>true</c> if the coords are inside the object, <c>false</c> otherwise</returns>
    virtual public bool GetCoordsInside(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_coords_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Check if this object is focused by a given seat
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat to check if the object is focused. Use <c>null</c> for the default seat.</param>
    /// <returns><c>true</c> if focused or <c>false</c> otherwise.</returns>
    virtual public bool CheckSeatFocus(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_check_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add a seat to the focus list.
    /// Evas allows the Efl.Canvas.Object to be focused by multiple seats at the same time. This function adds a new seat to the focus list. In other words, after the seat is added to the list this object will now be also focused by this new seat.
    /// 
    /// Note: The old focus APIs still work, however they will only act on the default seat.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat that should be added to the focus list. Use <c>null</c> for the default seat.</param>
    /// <returns><c>true</c> if the focus has been set or <c>false</c> otherwise.</returns>
    virtual public bool AddSeatFocus(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove a seat from the focus list.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat that should be removed from the focus list. Use <c>null</c> for the default seat.</param>
    /// <returns><c>true</c> if the seat was removed from the focus list or <c>false</c> otherwise.</returns>
    virtual public bool DelSeatFocus(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the number of objects clipped by <c>obj</c>
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of objects clipped by <c>obj</c></returns>
    virtual public uint ClippedObjectsCount() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests <c>keyname</c> key events be directed to <c>obj</c>.
    /// Key grabs allow one or more objects to receive key events for specific key strokes even if other objects have focus. Whenever a key is grabbed, only the objects grabbing it will get the events for the given keys.
    /// 
    /// <c>keyname</c> is a platform dependent symbolic name for the key pressed.
    /// 
    /// <c>modifiers</c> and <c>not_modifiers</c> are bit masks of all the modifiers that must and mustn&apos;t, respectively, be pressed along with <c>keyname</c> key in order to trigger this new key grab. Modifiers can be things such as Shift and Ctrl as well as user defined types via ref evas_key_modifier_add. <c>exclusive</c> will make the given object the only one permitted to grab the given key. If given <c>true</c>, subsequent calls on this function with different <c>obj</c> arguments will fail, unless the key is ungrabbed again.
    /// 
    /// Warning: Providing impossible modifier sets creates undefined behavior.
    /// (Since EFL 1.22)</summary>
    /// <param name="keyname">The key to request events for.</param>
    /// <param name="modifiers">A combination of modifier keys that must be present to trigger the event.</param>
    /// <param name="not_modifiers">A combination of modifier keys that must not be present to trigger the event.</param>
    /// <param name="exclusive">Request that the <c>obj</c> is the only object receiving the <c>keyname</c> events.</param>
    /// <returns><c>true</c> if the call succeeded, <c>false</c> otherwise.</returns>
    virtual public bool GrabKey(System.String keyname, Efl.Input.Modifier modifiers, Efl.Input.Modifier not_modifiers, bool exclusive) {
                                                                                                         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_key_grab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),keyname, modifiers, not_modifiers, exclusive);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Removes the grab on <c>keyname</c> key events by <c>obj</c>.
    /// Removes a key grab on <c>obj</c> if <c>keyname</c>, <c>modifiers</c>, and <c>not_modifiers</c> match.
    /// 
    /// See also <see cref="Efl.Canvas.Object.GrabKey"/>, <see cref="Efl.Canvas.Object.GetKeyFocus"/>, <see cref="Efl.Canvas.Object.SetKeyFocus"/>, and the legacy API evas_focus_get.
    /// (Since EFL 1.22)</summary>
    /// <param name="keyname">The key the grab is set for.</param>
    /// <param name="modifiers">A mask of modifiers that must be present to trigger the event.</param>
    /// <param name="not_modifiers">A mask of modifiers that must not not be present to trigger the event.</param>
    virtual public void UngrabKey(System.String keyname, Efl.Input.Modifier modifiers, Efl.Input.Modifier not_modifiers) {
                                                                                 Efl.Canvas.Object.NativeMethods.efl_canvas_object_key_ungrab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),keyname, modifiers, not_modifiers);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Returns current canvas&apos;s gesture manager
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>The gesture manager</returns>
    virtual public Efl.Canvas.GestureManager GetGestureManager() {
         var _ret_var = Efl.Canvas.Object.NativeMethods.efl_canvas_object_gesture_manager_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns whether the mouse pointer is logically inside the canvas.
    /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
    /// 
    /// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
    /// 
    /// A canvas begins with the mouse being assumed outside (<c>false</c>).
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
    /// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
    virtual public bool GetPointerInside(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Canvas.IPointerConcrete.NativeMethods.efl_canvas_pointer_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieves the general/main color of the given Evas object.
    /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    virtual public void GetColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets the general/main color of the given Evas object to the given one.
    /// See also <see cref="Efl.Gfx.IColor.GetColor"/> (for an example)
    /// 
    /// These color values are expected to be premultiplied by alpha.
    /// (Since EFL 1.22)</summary>
    virtual public void SetColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    virtual public System.String GetColorCode() {
         var _ret_var = Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    virtual public void SetColorCode(System.String colorcode) {
                                 Efl.Gfx.IColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),colorcode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the position of the given canvas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D coordinate in pixel units.</returns>
    virtual public Eina.Position2D GetPosition() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    virtual public void SetPosition(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D size in pixel units.</returns>
    virtual public Eina.Size2D GetSize() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
    /// (Since EFL 1.22)</summary>
    /// <param name="size">A 2D size in pixel units.</param>
    virtual public void SetSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    virtual public Eina.Rect GetGeometry() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    virtual public void SetGeometry(Eina.Rect rect) {
         Eina.Rect.NativeStruct _in_rect = rect;
                        Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given canvas object is visible.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    virtual public bool GetVisible() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Shows or hides this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    virtual public void SetVisible(bool v) {
                                 Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an object&apos;s scaling factor.
    /// (Since EFL 1.22)</summary>
    /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
    virtual public double GetScale() {
         var _ret_var = Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the scaling factor of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
    virtual public void SetScale(double scale) {
                                 Efl.Gfx.IEntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    virtual public void GetHintAspect(out Efl.Gfx.HintAspect mode, out Eina.Size2D sz) {
                                 var _out_sz = new Eina.Size2D.NativeStruct();
                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_aspect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out mode, out _out_sz);
        Eina.Error.RaiseIfUnhandledException();
                sz = _out_sz;
                         }
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    virtual public void SetHintAspect(Efl.Gfx.HintAspect mode, Eina.Size2D sz) {
                 Eina.Size2D.NativeStruct _in_sz = sz;
                                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_aspect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode, _in_sz);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
    virtual public Eina.Size2D GetHintSizeMax() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
    virtual public void SetHintSizeMax(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the &quot;intrinsic&quot; maximum size of this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels.</returns>
    virtual public Eina.Size2D GetHintSizeRestrictedMax() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Maximum size (hint) in pixels.</param>
    virtual public void SetHintSizeRestrictedMax(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
    /// (Since EFL 1.22)</summary>
    /// <returns>Maximum size (hint) in pixels.</returns>
    virtual public Eina.Size2D GetHintSizeCombinedMax() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    virtual public Eina.Size2D GetHintSizeMin() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    virtual public void SetHintSizeMin(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    virtual public Eina.Size2D GetHintSizeRestrictedMin() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    virtual public void SetHintSizeRestrictedMin(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
    /// (Since EFL 1.22)</summary>
    /// <returns>Minimum size (hint) in pixels.</returns>
    virtual public Eina.Size2D GetHintSizeCombinedMin() {
         var _ret_var = Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    virtual public void GetHintMargin(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_margin_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    virtual public void SetHintMargin(int l, int r, int t, int b) {
                                                                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_margin_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l, r, t, b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    virtual public void GetHintWeight(out double x, out double y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    virtual public void SetHintWeight(double x, double y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
    virtual public void GetHintAlign(out double x, out double y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
    virtual public void SetHintAlign(double x, double y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    virtual public void GetHintFill(out bool x, out bool y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    virtual public void SetHintFill(bool x, bool y) {
                                                         Efl.Gfx.IHintConcrete.NativeMethods.efl_gfx_hint_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of points of map</returns>
    virtual public int GetMappingPointCount() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_point_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
    /// (Since EFL 1.22)</summary>
    /// <param name="count">The number of points of map</param>
    virtual public void SetMappingPointCount(int count) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_point_count_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),count);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clockwise state of a map (read-only).
    /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
    virtual public bool GetMappingClockwise() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_clockwise_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> by default.</returns>
    virtual public bool GetMappingSmooth() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_smooth_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
    /// (Since EFL 1.22)</summary>
    /// <param name="smooth"><c>true</c> by default.</param>
    virtual public void SetMappingSmooth(bool smooth) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_smooth_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),smooth);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> by default.</returns>
    virtual public bool GetMappingAlpha() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
    /// (Since EFL 1.22)</summary>
    /// <param name="alpha"><c>true</c> by default.</param>
    virtual public void SetMappingAlpha(bool alpha) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),alpha);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    virtual public void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out x, out y, out z);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    virtual public void SetMappingCoordAbsolute(int idx, double x, double y, double z) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, x, y, z);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    virtual public void GetMappingUv(int idx, out double u, out double v) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_uv_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out u, out v);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    virtual public void SetMappingUv(int idx, double u, double v) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_uv_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, u, v);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    virtual public void GetMappingColor(int idx, out int r, out int g, out int b, out int a) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    virtual public void SetMappingColor(int idx, int r, int g, int b, int a) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Read-only property indicating whether an object is mapped.
    /// This will be <c>true</c> if any transformation is applied to this object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is mapped.</returns>
    virtual public bool HasMapping() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_has_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the map transformation to its default state.
    /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.IMapping.MappingSmooth"/> or <see cref="Efl.Gfx.IMapping.MappingAlpha"/>.
    /// (Since EFL 1.22)</summary>
    virtual public void ResetMapping() {
         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Apply a translation to the object using map.
    /// This does not change the real geometry of the object but will affect its visible position.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Distance in pixels along the X axis.</param>
    /// <param name="dy">Distance in pixels along the Y axis.</param>
    /// <param name="dz">Distance in pixels along the Z axis.</param>
    virtual public void Translate(double dx, double dy, double dz) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_translate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Apply a rotation to the object.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
    /// (Since EFL 1.22)</summary>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    virtual public void Rotate(double degrees, Efl.Gfx.IEntity pivot, double cx, double cy) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),degrees, pivot, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Rotate the object around 3 axes in 3D.
    /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    virtual public void Rotate3d(double dx, double dy, double dz, Efl.Gfx.IEntity pivot, double cx, double cy, double cz) {
                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz, pivot, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Rotate the object in 3D using a unit quaternion.
    /// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
    /// (Since EFL 1.22)</summary>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    virtual public void RotateQuat(double qx, double qy, double qz, double qw, Efl.Gfx.IEntity pivot, double cx, double cy, double cz) {
                                                                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),qx, qy, qz, qw, pivot, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                         }
    /// <summary>Apply a zoom to the object.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
    /// (Since EFL 1.22)</summary>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    virtual public void Zoom(double zoomx, double zoomy, Efl.Gfx.IEntity pivot, double cx, double cy) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_zoom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),zoomx, zoomy, pivot, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Apply a lighting effect on the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
    /// (Since EFL 1.22)</summary>
    /// <param name="pivot">A pivot object for the light point, can be <c>null</c>.</param>
    /// <param name="lx">X relative coordinate in space of light point.</param>
    /// <param name="ly">Y relative coordinate in space of light point.</param>
    /// <param name="lz">Z absolute coordinate in space of light point.</param>
    /// <param name="lr">Light red value (0 - 255).</param>
    /// <param name="lg">Light green value (0 - 255).</param>
    /// <param name="lb">Light blue value (0 - 255).</param>
    /// <param name="ar">Ambient color red value (0 - 255).</param>
    /// <param name="ag">Ambient color green value (0 - 255).</param>
    /// <param name="ab">Ambient color blue value (0 - 255).</param>
    virtual public void Lighting3d(Efl.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
                                                                                                                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                         }
    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
    /// (Since EFL 1.22)</summary>
    /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    virtual public void Perspective3d(Efl.Gfx.IEntity pivot, double px, double py, double z0, double foc) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pivot, px, py, z0, foc);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Apply a rotation to the object, using absolute coordinates.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.IMapping.Rotate"/> for a relative coordinate version.
    /// (Since EFL 1.22)</summary>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    virtual public void RotateAbsolute(double degrees, double cx, double cy) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),degrees, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
    /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    virtual public void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz) {
                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
    /// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.
    /// (Since EFL 1.22)</summary>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    virtual public void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz) {
                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),qx, qy, qz, qw, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Apply a zoom to the object, using absolute coordinates.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Zoom"/> for a pivot-based zoom.
    /// (Since EFL 1.22)</summary>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    virtual public void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),zoomx, zoomy, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Apply a lighting effect to the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.
    /// (Since EFL 1.22)</summary>
    /// <param name="lx">X absolute coordinate in pixels of the light point.</param>
    /// <param name="ly">y absolute coordinate in pixels of the light point.</param>
    /// <param name="lz">Z absolute coordinate in space of light point.</param>
    /// <param name="lr">Light red value (0 - 255).</param>
    /// <param name="lg">Light green value (0 - 255).</param>
    /// <param name="lb">Light blue value (0 - 255).</param>
    /// <param name="ar">Ambient color red value (0 - 255).</param>
    /// <param name="ag">Ambient color green value (0 - 255).</param>
    /// <param name="ab">Ambient color blue value (0 - 255).</param>
    virtual public void Lighting3dAbsolute(double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
                                                                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lx, ly, lz, lr, lg, lb, ar, ag, ab);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                         }
    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.
    /// (Since EFL 1.22)</summary>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    virtual public void Perspective3dAbsolute(double px, double py, double z0, double foc) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),px, py, z0, foc);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
    /// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</returns>
    virtual public short GetLayer() {
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_layer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this function, you&apos;ll be dealing with an unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="l">The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</param>
    virtual public void SetLayer(short l) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_layer_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    virtual public Efl.Gfx.IStack GetBelow() {
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_below_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the Evas object stacked right above <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    virtual public Efl.Gfx.IStack GetAbove() {
         var _ret_var = Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_above_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stack <c>obj</c> immediately <c>below</c>
    /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
    /// 
    /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
    /// 
    /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>below</c> must also be a member of the same smart object.
    /// 
    /// Similarly, if <c>obj</c> is not a member of a smart object, <c>below</c> must not be either.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="below">The object below which to stack</param>
    virtual public void StackBelow(Efl.Gfx.IStack below) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_below_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),below);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Raise <c>obj</c> to the top of its layer.
    /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.LowerToBottom"/>
    /// (Since EFL 1.22)</summary>
    virtual public void RaiseToTop() {
         Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_raise_to_top_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stack <c>obj</c> immediately <c>above</c>
    /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
    /// 
    /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
    /// 
    /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>above</c> must also be a member of the same smart object.
    /// 
    /// Similarly, if <c>obj</c> is not a member of a smart object, <c>above</c> must not be either.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.StackBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <param name="above">The object above which to stack</param>
    virtual public void StackAbove(Efl.Gfx.IStack above) {
                                 Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_above_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),above);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Lower <c>obj</c> to the bottom of its layer.
    /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.StackAbove"/>, <see cref="Efl.Gfx.IStack.StackBelow"/> and <see cref="Efl.Gfx.IStack.RaiseToTop"/>
    /// (Since EFL 1.22)</summary>
    virtual public void LowerToBottom() {
         Efl.Gfx.IStackConcrete.NativeMethods.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Check if input events from a given seat is enabled.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.</returns>
    virtual public bool GetSeatEventFilter(Efl.Input.Device seat) {
                                 var _ret_var = Efl.Input.IInterfaceConcrete.NativeMethods.efl_input_seat_event_filter_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat to act on.</param>
    /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.</param>
    virtual public void SetSeatEventFilter(Efl.Input.Device seat, bool enable) {
                                                         Efl.Input.IInterfaceConcrete.NativeMethods.efl_input_seat_event_filter_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat, enable);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Low-level pointer behaviour.
    /// This function has a direct effect on event callbacks related to pointers (mouse, ...).
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
    /// 
    /// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
    /// 
    /// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <value>Input pointer mode</value>
    public Efl.Input.ObjectPointerMode PointerMode {
        get { return GetPointerMode(); }
        set { SetPointerMode(value); }
    }
    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).
    /// (Since EFL 1.22)</summary>
    /// <value>Blend or copy.</value>
    public Efl.Gfx.RenderOp RenderOp {
        get { return GetRenderOp(); }
        set { SetRenderOp(value); }
    }
    /// <summary>Get the object clipping <c>obj</c> (if any).
    /// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.
    /// (Since EFL 1.22)</summary>
    /// <value>The object to clip <c>obj</c> by.</value>
    public Efl.Canvas.Object Clipper {
        get { return GetClipper(); }
        set { SetClipper(value); }
    }
    /// <summary>A hint for an object that its size will not change.
    /// When this flag is set, various optimizations may be employed by the renderer based on the fixed size of the object.
    /// 
    /// It is a user error to change the size of an object while this flag is set.
    /// (Since EFL 1.23)
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <value>Whether the object size is known to be static.</value>
    public bool HasFixedSize {
        get { return GetHasFixedSize(); }
        set { SetHasFixedSize(value); }
    }
    /// <summary>Determine whether an object is set to repeat events.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</value>
    public bool RepeatEvents {
        get { return GetRepeatEvents(); }
        set { SetRepeatEvents(value); }
    }
    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> when set as focused or <c>false</c> otherwise.</value>
    public bool KeyFocus {
        get { return GetKeyFocus(); }
        set { SetKeyFocus(value); }
    }
    /// <summary>Check if this object is focused.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</value>
    public bool SeatFocus {
        get { return GetSeatFocus(); }
    }
    /// <summary>Determine whether an object is set to use precise point collision detection.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether to use precise point collision detection or not. The default value is false.</value>
    public bool PreciseIsInside {
        get { return GetPreciseIsInside(); }
        set { SetPreciseIsInside(value); }
    }
    /// <summary>Retrieve whether an Evas object is set to propagate events.
    /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether to propagate events (<c>true</c>) or not (<c>false</c>).</value>
    public bool PropagateEvents {
        get { return GetPropagateEvents(); }
        set { SetPropagateEvents(value); }
    }
    /// <summary>Determine whether an object is set to pass (ignore) events.
    /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</value>
    public bool PassEvents {
        get { return GetPassEvents(); }
        set { SetPassEvents(value); }
    }
    /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</value>
    public bool AntiAlias {
        get { return GetAntiAlias(); }
        set { SetAntiAlias(value); }
    }
    /// <summary>Return a list of objects currently clipped by <c>obj</c>.
    /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
    /// 
    /// See also <see cref="Efl.Canvas.Object.Clipper"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>An iterator over the list of objects clipped by <c>obj</c>.</value>
    public Eina.Iterator<Efl.Canvas.Object> ClippedObjects {
        get { return GetClippedObjects(); }
    }
    /// <summary>Gets the parent smart object of a given Evas object, if it has one.
    /// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
    /// (Since EFL 1.22)</summary>
    /// <value>The parent smart object of <c>obj</c> or <c>null</c>.</value>
    protected Efl.Canvas.Object RenderParent {
        get { return GetRenderParent(); }
    }
    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.
    /// (Since EFL 1.22)</summary>
    /// <value>Paragraph direction for the given object.</value>
    public Efl.TextBidirectionalType ParagraphDirection {
        get { return GetParagraphDirection(); }
        set { SetParagraphDirection(value); }
    }
    /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
    /// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
    /// (Since EFL 1.22)</summary>
    /// <value>Enable &quot;no-render&quot; mode.</value>
    public bool NoRender {
        get { return GetNoRender(); }
        set { SetNoRender(value); }
    }
    /// <summary>Retrieves the general/main color of the given Evas object.
    /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
    }
    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).
    /// (Since EFL 1.22)</summary>
    /// <value>A 2D coordinate in pixel units.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }
    /// <summary>The 2D size of a canvas object.
    /// (Since EFL 1.22)</summary>
    /// <value>A 2D size in pixel units.</value>
    public Eina.Size2D Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    public Eina.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry(value); }
    }
    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible(value); }
    }
    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// (Since EFL 1.22)</summary>
    /// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale(value); }
    }
    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.
    /// (Since EFL 1.22)</summary>
    /// <value>Mode of interpretation.</value>
    public (Efl.Gfx.HintAspect, Eina.Size2D) HintAspect {
        get {
            Efl.Gfx.HintAspect _out_mode = default(Efl.Gfx.HintAspect);
            Eina.Size2D _out_sz = default(Eina.Size2D);
            GetHintAspect(out _out_mode,out _out_sz);
            return (_out_mode,_out_sz);
        }
        set { SetHintAspect( value.Item1,  value.Item2); }
    }
    /// <summary>Hints on the object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
    public Eina.Size2D HintSizeMax {
        get { return GetHintSizeMax(); }
        set { SetHintSizeMax(value); }
    }
    /// <summary>Internal hints for an object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="Efl.Gfx.IHint.HintSizeMax"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeRestrictedMax {
        get { return GetHintSizeRestrictedMax(); }
        set { SetHintSizeRestrictedMax(value); }
    }
    /// <summary>Read-only maximum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="Efl.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Maximum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeCombinedMax {
        get { return GetHintSizeCombinedMax(); }
    }
    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeMin {
        get { return GetHintSizeMin(); }
        set { SetHintSizeMin(value); }
    }
    /// <summary>Internal hints for an object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.IHint.HintSizeMin"/> instead.
    /// 
    /// Note: It is an error for the <see cref="Efl.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeRestrictedMin {
        get { return GetHintSizeRestrictedMin(); }
        set { SetHintSizeRestrictedMin(value); }
    }
    /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="Efl.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="Efl.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="Efl.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.
    /// (Since EFL 1.22)</summary>
    /// <value>Minimum size (hint) in pixels.</value>
    public Eina.Size2D HintSizeCombinedMin {
        get { return GetHintSizeCombinedMin(); }
    }
    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
    /// (Since EFL 1.22)</summary>
    /// <value>Integer to specify left padding.</value>
    public (int, int, int, int) HintMargin {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetHintMargin(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
        set { SetHintMargin( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.
    /// (Since EFL 1.22)</summary>
    /// <value>Non-negative double value to use as horizontal weight hint.</value>
    public (double, double) HintWeight {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetHintWeight(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintWeight( value.Item1,  value.Item2); }
    }
    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value>Double, ranging from 0.0 to 1.0.</value>
    public (double, double) HintAlign {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetHintAlign(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintAlign( value.Item1,  value.Item2); }
    }
    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</value>
    public (bool, bool) HintFill {
        get {
            bool _out_x = default(bool);
            bool _out_y = default(bool);
            GetHintFill(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintFill( value.Item1,  value.Item2); }
    }
    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
    /// (Since EFL 1.22)</summary>
    /// <value>The number of points of map</value>
    public int MappingPointCount {
        get { return GetMappingPointCount(); }
        set { SetMappingPointCount(value); }
    }
    /// <summary>Clockwise state of a map (read-only).
    /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
    public bool MappingClockwise {
        get { return GetMappingClockwise(); }
    }
    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> by default.</value>
    public bool MappingSmooth {
        get { return GetMappingSmooth(); }
        set { SetMappingSmooth(value); }
    }
    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> by default.</value>
    public bool MappingAlpha {
        get { return GetMappingAlpha(); }
        set { SetMappingAlpha(value); }
    }
    /// <summary>Retrieves the layer of its canvas that the given object is part of.
    /// See also <see cref="Efl.Gfx.IStack.SetLayer"/>
    /// (Since EFL 1.22)</summary>
    /// <value>The number of the layer to place the object on. Must be between <see cref="Efl.Gfx.Constants.StackLayerMin"/> and <see cref="Efl.Gfx.Constants.StackLayerMax"/>.</value>
    public short Layer {
        get { return GetLayer(); }
        set { SetLayer(value); }
    }
    /// <summary>Get the Evas object stacked right below <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Below {
        get { return GetBelow(); }
    }
    /// <summary>Get the Evas object stacked right above <c>obj</c>
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="Efl.Gfx.IStack.GetLayer"/>, <see cref="Efl.Gfx.IStack.SetLayer"/> and <see cref="Efl.Gfx.IStack.GetBelow"/>
    /// (Since EFL 1.22)</summary>
    /// <value>The <see cref="Efl.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public Efl.Gfx.IStack Above {
        get { return GetAbove(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Object.efl_canvas_object_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopConsumer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_object_pointer_mode_by_device_get_static_delegate == null)
            {
                efl_canvas_object_pointer_mode_by_device_get_static_delegate = new efl_canvas_object_pointer_mode_by_device_get_delegate(pointer_mode_by_device_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerModeByDevice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pointer_mode_by_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_get_static_delegate) });
            }

            if (efl_canvas_object_pointer_mode_by_device_set_static_delegate == null)
            {
                efl_canvas_object_pointer_mode_by_device_set_static_delegate = new efl_canvas_object_pointer_mode_by_device_set_delegate(pointer_mode_by_device_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPointerModeByDevice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pointer_mode_by_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_set_static_delegate) });
            }

            if (efl_canvas_object_pointer_mode_get_static_delegate == null)
            {
                efl_canvas_object_pointer_mode_get_static_delegate = new efl_canvas_object_pointer_mode_get_delegate(pointer_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pointer_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_get_static_delegate) });
            }

            if (efl_canvas_object_pointer_mode_set_static_delegate == null)
            {
                efl_canvas_object_pointer_mode_set_static_delegate = new efl_canvas_object_pointer_mode_set_delegate(pointer_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPointerMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pointer_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_set_static_delegate) });
            }

            if (efl_canvas_object_render_op_get_static_delegate == null)
            {
                efl_canvas_object_render_op_get_static_delegate = new efl_canvas_object_render_op_get_delegate(render_op_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRenderOp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_get_static_delegate) });
            }

            if (efl_canvas_object_render_op_set_static_delegate == null)
            {
                efl_canvas_object_render_op_set_static_delegate = new efl_canvas_object_render_op_set_delegate(render_op_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRenderOp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_set_static_delegate) });
            }

            if (efl_canvas_object_clipper_get_static_delegate == null)
            {
                efl_canvas_object_clipper_get_static_delegate = new efl_canvas_object_clipper_get_delegate(clipper_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClipper") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_get_static_delegate) });
            }

            if (efl_canvas_object_clipper_set_static_delegate == null)
            {
                efl_canvas_object_clipper_set_static_delegate = new efl_canvas_object_clipper_set_delegate(clipper_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetClipper") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_set_static_delegate) });
            }

            if (efl_canvas_object_has_fixed_size_get_static_delegate == null)
            {
                efl_canvas_object_has_fixed_size_get_static_delegate = new efl_canvas_object_has_fixed_size_get_delegate(has_fixed_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHasFixedSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_has_fixed_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_has_fixed_size_get_static_delegate) });
            }

            if (efl_canvas_object_has_fixed_size_set_static_delegate == null)
            {
                efl_canvas_object_has_fixed_size_set_static_delegate = new efl_canvas_object_has_fixed_size_set_delegate(has_fixed_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHasFixedSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_has_fixed_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_has_fixed_size_set_static_delegate) });
            }

            if (efl_canvas_object_repeat_events_get_static_delegate == null)
            {
                efl_canvas_object_repeat_events_get_static_delegate = new efl_canvas_object_repeat_events_get_delegate(repeat_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRepeatEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_get_static_delegate) });
            }

            if (efl_canvas_object_repeat_events_set_static_delegate == null)
            {
                efl_canvas_object_repeat_events_set_static_delegate = new efl_canvas_object_repeat_events_set_delegate(repeat_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRepeatEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_set_static_delegate) });
            }

            if (efl_canvas_object_key_focus_get_static_delegate == null)
            {
                efl_canvas_object_key_focus_get_static_delegate = new efl_canvas_object_key_focus_get_delegate(key_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeyFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_get_static_delegate) });
            }

            if (efl_canvas_object_key_focus_set_static_delegate == null)
            {
                efl_canvas_object_key_focus_set_static_delegate = new efl_canvas_object_key_focus_set_delegate(key_focus_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeyFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_set_static_delegate) });
            }

            if (efl_canvas_object_seat_focus_get_static_delegate == null)
            {
                efl_canvas_object_seat_focus_get_static_delegate = new efl_canvas_object_seat_focus_get_delegate(seat_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeatFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_get_static_delegate) });
            }

            if (efl_canvas_object_precise_is_inside_get_static_delegate == null)
            {
                efl_canvas_object_precise_is_inside_get_static_delegate = new efl_canvas_object_precise_is_inside_get_delegate(precise_is_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPreciseIsInside") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_get_static_delegate) });
            }

            if (efl_canvas_object_precise_is_inside_set_static_delegate == null)
            {
                efl_canvas_object_precise_is_inside_set_static_delegate = new efl_canvas_object_precise_is_inside_set_delegate(precise_is_inside_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPreciseIsInside") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_set_static_delegate) });
            }

            if (efl_canvas_object_propagate_events_get_static_delegate == null)
            {
                efl_canvas_object_propagate_events_get_static_delegate = new efl_canvas_object_propagate_events_get_delegate(propagate_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPropagateEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_get_static_delegate) });
            }

            if (efl_canvas_object_propagate_events_set_static_delegate == null)
            {
                efl_canvas_object_propagate_events_set_static_delegate = new efl_canvas_object_propagate_events_set_delegate(propagate_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPropagateEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_set_static_delegate) });
            }

            if (efl_canvas_object_pass_events_get_static_delegate == null)
            {
                efl_canvas_object_pass_events_get_static_delegate = new efl_canvas_object_pass_events_get_delegate(pass_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPassEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_get_static_delegate) });
            }

            if (efl_canvas_object_pass_events_set_static_delegate == null)
            {
                efl_canvas_object_pass_events_set_static_delegate = new efl_canvas_object_pass_events_set_delegate(pass_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPassEvents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_set_static_delegate) });
            }

            if (efl_canvas_object_anti_alias_get_static_delegate == null)
            {
                efl_canvas_object_anti_alias_get_static_delegate = new efl_canvas_object_anti_alias_get_delegate(anti_alias_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAntiAlias") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_get_static_delegate) });
            }

            if (efl_canvas_object_anti_alias_set_static_delegate == null)
            {
                efl_canvas_object_anti_alias_set_static_delegate = new efl_canvas_object_anti_alias_set_delegate(anti_alias_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAntiAlias") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_set_static_delegate) });
            }

            if (efl_canvas_object_clipped_objects_get_static_delegate == null)
            {
                efl_canvas_object_clipped_objects_get_static_delegate = new efl_canvas_object_clipped_objects_get_delegate(clipped_objects_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClippedObjects") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_get_static_delegate) });
            }

            if (efl_canvas_object_render_parent_get_static_delegate == null)
            {
                efl_canvas_object_render_parent_get_static_delegate = new efl_canvas_object_render_parent_get_delegate(render_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRenderParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_parent_get_static_delegate) });
            }

            if (efl_canvas_object_paragraph_direction_get_static_delegate == null)
            {
                efl_canvas_object_paragraph_direction_get_static_delegate = new efl_canvas_object_paragraph_direction_get_delegate(paragraph_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetParagraphDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_get_static_delegate) });
            }

            if (efl_canvas_object_paragraph_direction_set_static_delegate == null)
            {
                efl_canvas_object_paragraph_direction_set_static_delegate = new efl_canvas_object_paragraph_direction_set_delegate(paragraph_direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetParagraphDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_set_static_delegate) });
            }

            if (efl_canvas_object_no_render_get_static_delegate == null)
            {
                efl_canvas_object_no_render_get_static_delegate = new efl_canvas_object_no_render_get_delegate(no_render_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNoRender") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_get_static_delegate) });
            }

            if (efl_canvas_object_no_render_set_static_delegate == null)
            {
                efl_canvas_object_no_render_set_static_delegate = new efl_canvas_object_no_render_set_delegate(no_render_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNoRender") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_set_static_delegate) });
            }

            if (efl_canvas_object_coords_inside_get_static_delegate == null)
            {
                efl_canvas_object_coords_inside_get_static_delegate = new efl_canvas_object_coords_inside_get_delegate(coords_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCoordsInside") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_coords_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_coords_inside_get_static_delegate) });
            }

            if (efl_canvas_object_seat_focus_check_static_delegate == null)
            {
                efl_canvas_object_seat_focus_check_static_delegate = new efl_canvas_object_seat_focus_check_delegate(seat_focus_check);
            }

            if (methods.FirstOrDefault(m => m.Name == "CheckSeatFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_check"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_check_static_delegate) });
            }

            if (efl_canvas_object_seat_focus_add_static_delegate == null)
            {
                efl_canvas_object_seat_focus_add_static_delegate = new efl_canvas_object_seat_focus_add_delegate(seat_focus_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddSeatFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_add_static_delegate) });
            }

            if (efl_canvas_object_seat_focus_del_static_delegate == null)
            {
                efl_canvas_object_seat_focus_del_static_delegate = new efl_canvas_object_seat_focus_del_delegate(seat_focus_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelSeatFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_del"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_del_static_delegate) });
            }

            if (efl_canvas_object_clipped_objects_count_static_delegate == null)
            {
                efl_canvas_object_clipped_objects_count_static_delegate = new efl_canvas_object_clipped_objects_count_delegate(clipped_objects_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClippedObjectsCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_count"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_count_static_delegate) });
            }

            if (efl_canvas_object_key_grab_static_delegate == null)
            {
                efl_canvas_object_key_grab_static_delegate = new efl_canvas_object_key_grab_delegate(key_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_grab_static_delegate) });
            }

            if (efl_canvas_object_key_ungrab_static_delegate == null)
            {
                efl_canvas_object_key_ungrab_static_delegate = new efl_canvas_object_key_ungrab_delegate(key_ungrab);
            }

            if (methods.FirstOrDefault(m => m.Name == "UngrabKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_ungrab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_ungrab_static_delegate) });
            }

            if (efl_canvas_object_gesture_manager_get_static_delegate == null)
            {
                efl_canvas_object_gesture_manager_get_static_delegate = new efl_canvas_object_gesture_manager_get_delegate(gesture_manager_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGestureManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_gesture_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_gesture_manager_get_static_delegate) });
            }

            if (efl_canvas_pointer_inside_get_static_delegate == null)
            {
                efl_canvas_pointer_inside_get_static_delegate = new efl_canvas_pointer_inside_get_delegate(pointer_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerInside") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_pointer_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_pointer_inside_get_static_delegate) });
            }

            if (efl_gfx_color_get_static_delegate == null)
            {
                efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate) });
            }

            if (efl_gfx_color_set_static_delegate == null)
            {
                efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate) });
            }

            if (efl_gfx_color_code_get_static_delegate == null)
            {
                efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate) });
            }

            if (efl_gfx_color_code_set_static_delegate == null)
            {
                efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetColorCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate) });
            }

            if (efl_gfx_entity_position_get_static_delegate == null)
            {
                efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate) });
            }

            if (efl_gfx_entity_position_set_static_delegate == null)
            {
                efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate) });
            }

            if (efl_gfx_entity_size_get_static_delegate == null)
            {
                efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate) });
            }

            if (efl_gfx_entity_size_set_static_delegate == null)
            {
                efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate) });
            }

            if (efl_gfx_entity_geometry_get_static_delegate == null)
            {
                efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate) });
            }

            if (efl_gfx_entity_geometry_set_static_delegate == null)
            {
                efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate) });
            }

            if (efl_gfx_entity_visible_get_static_delegate == null)
            {
                efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate) });
            }

            if (efl_gfx_entity_visible_set_static_delegate == null)
            {
                efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetVisible") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate) });
            }

            if (efl_gfx_entity_scale_get_static_delegate == null)
            {
                efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate) });
            }

            if (efl_gfx_entity_scale_set_static_delegate == null)
            {
                efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate) });
            }

            if (efl_gfx_hint_aspect_get_static_delegate == null)
            {
                efl_gfx_hint_aspect_get_static_delegate = new efl_gfx_hint_aspect_get_delegate(hint_aspect_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintAspect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_get_static_delegate) });
            }

            if (efl_gfx_hint_aspect_set_static_delegate == null)
            {
                efl_gfx_hint_aspect_set_static_delegate = new efl_gfx_hint_aspect_set_delegate(hint_aspect_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintAspect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_aspect_set_static_delegate) });
            }

            if (efl_gfx_hint_size_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_max_get_static_delegate = new efl_gfx_hint_size_max_get_delegate(hint_size_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_max_set_static_delegate == null)
            {
                efl_gfx_hint_size_max_set_static_delegate = new efl_gfx_hint_size_max_set_delegate(hint_size_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_max_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_max_get_static_delegate = new efl_gfx_hint_size_restricted_max_get_delegate(hint_size_restricted_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeRestrictedMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_max_set_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_max_set_static_delegate = new efl_gfx_hint_size_restricted_max_set_delegate(hint_size_restricted_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeRestrictedMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_set_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_max_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_max_get_static_delegate = new efl_gfx_hint_size_combined_max_get_delegate(hint_size_combined_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeCombinedMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_max_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_min_get_static_delegate = new efl_gfx_hint_size_min_get_delegate(hint_size_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_min_set_static_delegate == null)
            {
                efl_gfx_hint_size_min_set_static_delegate = new efl_gfx_hint_size_min_set_delegate(hint_size_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_min_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_min_get_static_delegate = new efl_gfx_hint_size_restricted_min_get_delegate(hint_size_restricted_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeRestrictedMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_get_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_min_set_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_min_set_static_delegate = new efl_gfx_hint_size_restricted_min_set_delegate(hint_size_restricted_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeRestrictedMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_set_static_delegate) });
            }

            if (efl_gfx_hint_size_combined_min_get_static_delegate == null)
            {
                efl_gfx_hint_size_combined_min_get_static_delegate = new efl_gfx_hint_size_combined_min_get_delegate(hint_size_combined_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintSizeCombinedMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_combined_min_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_get_static_delegate == null)
            {
                efl_gfx_hint_margin_get_static_delegate = new efl_gfx_hint_margin_get_delegate(hint_margin_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintMargin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_get_static_delegate) });
            }

            if (efl_gfx_hint_margin_set_static_delegate == null)
            {
                efl_gfx_hint_margin_set_static_delegate = new efl_gfx_hint_margin_set_delegate(hint_margin_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintMargin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_margin_set_static_delegate) });
            }

            if (efl_gfx_hint_weight_get_static_delegate == null)
            {
                efl_gfx_hint_weight_get_static_delegate = new efl_gfx_hint_weight_get_delegate(hint_weight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_get_static_delegate) });
            }

            if (efl_gfx_hint_weight_set_static_delegate == null)
            {
                efl_gfx_hint_weight_set_static_delegate = new efl_gfx_hint_weight_set_delegate(hint_weight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_weight_set_static_delegate) });
            }

            if (efl_gfx_hint_align_get_static_delegate == null)
            {
                efl_gfx_hint_align_get_static_delegate = new efl_gfx_hint_align_get_delegate(hint_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_get_static_delegate) });
            }

            if (efl_gfx_hint_align_set_static_delegate == null)
            {
                efl_gfx_hint_align_set_static_delegate = new efl_gfx_hint_align_set_delegate(hint_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_align_set_static_delegate) });
            }

            if (efl_gfx_hint_fill_get_static_delegate == null)
            {
                efl_gfx_hint_fill_get_static_delegate = new efl_gfx_hint_fill_get_delegate(hint_fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_get_static_delegate) });
            }

            if (efl_gfx_hint_fill_set_static_delegate == null)
            {
                efl_gfx_hint_fill_set_static_delegate = new efl_gfx_hint_fill_set_delegate(hint_fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_fill_set_static_delegate) });
            }

            if (efl_gfx_mapping_point_count_get_static_delegate == null)
            {
                efl_gfx_mapping_point_count_get_static_delegate = new efl_gfx_mapping_point_count_get_delegate(mapping_point_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingPointCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_get_static_delegate) });
            }

            if (efl_gfx_mapping_point_count_set_static_delegate == null)
            {
                efl_gfx_mapping_point_count_set_static_delegate = new efl_gfx_mapping_point_count_set_delegate(mapping_point_count_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingPointCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_set_static_delegate) });
            }

            if (efl_gfx_mapping_clockwise_get_static_delegate == null)
            {
                efl_gfx_mapping_clockwise_get_static_delegate = new efl_gfx_mapping_clockwise_get_delegate(mapping_clockwise_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingClockwise") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_clockwise_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_get_static_delegate == null)
            {
                efl_gfx_mapping_smooth_get_static_delegate = new efl_gfx_mapping_smooth_get_delegate(mapping_smooth_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingSmooth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_set_static_delegate == null)
            {
                efl_gfx_mapping_smooth_set_static_delegate = new efl_gfx_mapping_smooth_set_delegate(mapping_smooth_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingSmooth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_set_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_get_static_delegate == null)
            {
                efl_gfx_mapping_alpha_get_static_delegate = new efl_gfx_mapping_alpha_get_delegate(mapping_alpha_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_get_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_set_static_delegate == null)
            {
                efl_gfx_mapping_alpha_set_static_delegate = new efl_gfx_mapping_alpha_set_delegate(mapping_alpha_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_set_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_get_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_get_static_delegate = new efl_gfx_mapping_coord_absolute_get_delegate(mapping_coord_absolute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingCoordAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_get_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_set_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_set_static_delegate = new efl_gfx_mapping_coord_absolute_set_delegate(mapping_coord_absolute_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingCoordAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_set_static_delegate) });
            }

            if (efl_gfx_mapping_uv_get_static_delegate == null)
            {
                efl_gfx_mapping_uv_get_static_delegate = new efl_gfx_mapping_uv_get_delegate(mapping_uv_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingUv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_get_static_delegate) });
            }

            if (efl_gfx_mapping_uv_set_static_delegate == null)
            {
                efl_gfx_mapping_uv_set_static_delegate = new efl_gfx_mapping_uv_set_delegate(mapping_uv_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingUv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_set_static_delegate) });
            }

            if (efl_gfx_mapping_color_get_static_delegate == null)
            {
                efl_gfx_mapping_color_get_static_delegate = new efl_gfx_mapping_color_get_delegate(mapping_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_get_static_delegate) });
            }

            if (efl_gfx_mapping_color_set_static_delegate == null)
            {
                efl_gfx_mapping_color_set_static_delegate = new efl_gfx_mapping_color_set_delegate(mapping_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_set_static_delegate) });
            }

            if (efl_gfx_mapping_has_static_delegate == null)
            {
                efl_gfx_mapping_has_static_delegate = new efl_gfx_mapping_has_delegate(mapping_has);
            }

            if (methods.FirstOrDefault(m => m.Name == "HasMapping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_has_static_delegate) });
            }

            if (efl_gfx_mapping_reset_static_delegate == null)
            {
                efl_gfx_mapping_reset_static_delegate = new efl_gfx_mapping_reset_delegate(mapping_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetMapping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_reset_static_delegate) });
            }

            if (efl_gfx_mapping_translate_static_delegate == null)
            {
                efl_gfx_mapping_translate_static_delegate = new efl_gfx_mapping_translate_delegate(translate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Translate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_translate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_static_delegate == null)
            {
                efl_gfx_mapping_rotate_static_delegate = new efl_gfx_mapping_rotate_delegate(rotate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_static_delegate = new efl_gfx_mapping_rotate_3d_delegate(rotate_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_static_delegate = new efl_gfx_mapping_rotate_quat_delegate(rotate_quat);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateQuat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_static_delegate == null)
            {
                efl_gfx_mapping_zoom_static_delegate = new efl_gfx_mapping_zoom_delegate(zoom);
            }

            if (methods.FirstOrDefault(m => m.Name == "Zoom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_static_delegate = new efl_gfx_mapping_lighting_3d_delegate(lighting_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Lighting3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_static_delegate = new efl_gfx_mapping_perspective_3d_delegate(perspective_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Perspective3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_absolute_static_delegate = new efl_gfx_mapping_rotate_absolute_delegate(rotate_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_absolute_static_delegate = new efl_gfx_mapping_rotate_3d_absolute_delegate(rotate_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_absolute_static_delegate = new efl_gfx_mapping_rotate_quat_absolute_delegate(rotate_quat_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateQuatAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_absolute_static_delegate == null)
            {
                efl_gfx_mapping_zoom_absolute_static_delegate = new efl_gfx_mapping_zoom_absolute_delegate(zoom_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "ZoomAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_absolute_static_delegate = new efl_gfx_mapping_lighting_3d_absolute_delegate(lighting_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Lighting3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_absolute_static_delegate = new efl_gfx_mapping_perspective_3d_absolute_delegate(perspective_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Perspective3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_absolute_static_delegate) });
            }

            if (efl_gfx_stack_layer_get_static_delegate == null)
            {
                efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLayer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate) });
            }

            if (efl_gfx_stack_layer_set_static_delegate == null)
            {
                efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLayer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate) });
            }

            if (efl_gfx_stack_below_get_static_delegate == null)
            {
                efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBelow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate) });
            }

            if (efl_gfx_stack_above_get_static_delegate == null)
            {
                efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAbove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate) });
            }

            if (efl_gfx_stack_below_static_delegate == null)
            {
                efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
            }

            if (methods.FirstOrDefault(m => m.Name == "StackBelow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate) });
            }

            if (efl_gfx_stack_raise_to_top_static_delegate == null)
            {
                efl_gfx_stack_raise_to_top_static_delegate = new efl_gfx_stack_raise_to_top_delegate(raise_to_top);
            }

            if (methods.FirstOrDefault(m => m.Name == "RaiseToTop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_raise_to_top"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_to_top_static_delegate) });
            }

            if (efl_gfx_stack_above_static_delegate == null)
            {
                efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
            }

            if (methods.FirstOrDefault(m => m.Name == "StackAbove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate) });
            }

            if (efl_gfx_stack_lower_to_bottom_static_delegate == null)
            {
                efl_gfx_stack_lower_to_bottom_static_delegate = new efl_gfx_stack_lower_to_bottom_delegate(lower_to_bottom);
            }

            if (methods.FirstOrDefault(m => m.Name == "LowerToBottom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_lower_to_bottom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_to_bottom_static_delegate) });
            }

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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Object.efl_canvas_object_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev);

        
        public delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_get_api_delegate> efl_canvas_object_pointer_mode_by_device_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_get_api_delegate>(Module, "efl_canvas_object_pointer_mode_by_device_get");

        private static Efl.Input.ObjectPointerMode pointer_mode_by_device_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device dev)
        {
            Eina.Log.Debug("function efl_canvas_object_pointer_mode_by_device_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Input.ObjectPointerMode _ret_var = default(Efl.Input.ObjectPointerMode);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPointerModeByDevice(dev);
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
                return efl_canvas_object_pointer_mode_by_device_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dev);
            }
        }

        private static efl_canvas_object_pointer_mode_by_device_get_delegate efl_canvas_object_pointer_mode_by_device_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_pointer_mode_by_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev,  Efl.Input.ObjectPointerMode pointer_mode);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_pointer_mode_by_device_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev,  Efl.Input.ObjectPointerMode pointer_mode);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_set_api_delegate> efl_canvas_object_pointer_mode_by_device_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_by_device_set_api_delegate>(Module, "efl_canvas_object_pointer_mode_by_device_set");

        private static bool pointer_mode_by_device_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device dev, Efl.Input.ObjectPointerMode pointer_mode)
        {
            Eina.Log.Debug("function efl_canvas_object_pointer_mode_by_device_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).SetPointerModeByDevice(dev, pointer_mode);
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
                return efl_canvas_object_pointer_mode_by_device_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dev, pointer_mode);
            }
        }

        private static efl_canvas_object_pointer_mode_by_device_set_delegate efl_canvas_object_pointer_mode_by_device_set_static_delegate;

        
        private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_get_api_delegate> efl_canvas_object_pointer_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_get_api_delegate>(Module, "efl_canvas_object_pointer_mode_get");

        private static Efl.Input.ObjectPointerMode pointer_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_pointer_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Input.ObjectPointerMode _ret_var = default(Efl.Input.ObjectPointerMode);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPointerMode();
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
                return efl_canvas_object_pointer_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_pointer_mode_get_delegate efl_canvas_object_pointer_mode_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_pointer_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.ObjectPointerMode pointer_mode);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_pointer_mode_set_api_delegate(System.IntPtr obj,  Efl.Input.ObjectPointerMode pointer_mode);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_set_api_delegate> efl_canvas_object_pointer_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pointer_mode_set_api_delegate>(Module, "efl_canvas_object_pointer_mode_set");

        private static bool pointer_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.ObjectPointerMode pointer_mode)
        {
            Eina.Log.Debug("function efl_canvas_object_pointer_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).SetPointerMode(pointer_mode);
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
                return efl_canvas_object_pointer_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pointer_mode);
            }
        }

        private static efl_canvas_object_pointer_mode_set_delegate efl_canvas_object_pointer_mode_set_static_delegate;

        
        private delegate Efl.Gfx.RenderOp efl_canvas_object_render_op_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.RenderOp efl_canvas_object_render_op_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate> efl_canvas_object_render_op_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate>(Module, "efl_canvas_object_render_op_get");

        private static Efl.Gfx.RenderOp render_op_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_render_op_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.RenderOp _ret_var = default(Efl.Gfx.RenderOp);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRenderOp();
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
                return efl_canvas_object_render_op_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_render_op_get_delegate efl_canvas_object_render_op_get_static_delegate;

        
        private delegate void efl_canvas_object_render_op_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.RenderOp render_op);

        
        public delegate void efl_canvas_object_render_op_set_api_delegate(System.IntPtr obj,  Efl.Gfx.RenderOp render_op);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate> efl_canvas_object_render_op_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate>(Module, "efl_canvas_object_render_op_set");

        private static void render_op_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.RenderOp render_op)
        {
            Eina.Log.Debug("function efl_canvas_object_render_op_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetRenderOp(render_op);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_render_op_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), render_op);
            }
        }

        private static efl_canvas_object_render_op_set_delegate efl_canvas_object_render_op_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_object_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_object_clipper_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate> efl_canvas_object_clipper_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate>(Module, "efl_canvas_object_clipper_get");

        private static Efl.Canvas.Object clipper_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_clipper_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).GetClipper();
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
                return efl_canvas_object_clipper_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipper_get_delegate efl_canvas_object_clipper_get_static_delegate;

        
        private delegate void efl_canvas_object_clipper_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object clipper);

        
        public delegate void efl_canvas_object_clipper_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object clipper);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate> efl_canvas_object_clipper_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate>(Module, "efl_canvas_object_clipper_set");

        private static void clipper_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object clipper)
        {
            Eina.Log.Debug("function efl_canvas_object_clipper_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetClipper(clipper);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_clipper_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), clipper);
            }
        }

        private static efl_canvas_object_clipper_set_delegate efl_canvas_object_clipper_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_has_fixed_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_has_fixed_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_has_fixed_size_get_api_delegate> efl_canvas_object_has_fixed_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_has_fixed_size_get_api_delegate>(Module, "efl_canvas_object_has_fixed_size_get");

        private static bool has_fixed_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_has_fixed_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHasFixedSize();
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
                return efl_canvas_object_has_fixed_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_has_fixed_size_get_delegate efl_canvas_object_has_fixed_size_get_static_delegate;

        
        private delegate void efl_canvas_object_has_fixed_size_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_canvas_object_has_fixed_size_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_has_fixed_size_set_api_delegate> efl_canvas_object_has_fixed_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_has_fixed_size_set_api_delegate>(Module, "efl_canvas_object_has_fixed_size_set");

        private static void has_fixed_size_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_canvas_object_has_fixed_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetHasFixedSize(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_has_fixed_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_canvas_object_has_fixed_size_set_delegate efl_canvas_object_has_fixed_size_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_repeat_events_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate> efl_canvas_object_repeat_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate>(Module, "efl_canvas_object_repeat_events_get");

        private static bool repeat_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_repeat_events_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRepeatEvents();
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
                return efl_canvas_object_repeat_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_repeat_events_get_delegate efl_canvas_object_repeat_events_get_static_delegate;

        
        private delegate void efl_canvas_object_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool repeat);

        
        public delegate void efl_canvas_object_repeat_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool repeat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate> efl_canvas_object_repeat_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate>(Module, "efl_canvas_object_repeat_events_set");

        private static void repeat_events_set(System.IntPtr obj, System.IntPtr pd, bool repeat)
        {
            Eina.Log.Debug("function efl_canvas_object_repeat_events_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetRepeatEvents(repeat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_repeat_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), repeat);
            }
        }

        private static efl_canvas_object_repeat_events_set_delegate efl_canvas_object_repeat_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_key_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_key_focus_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate> efl_canvas_object_key_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate>(Module, "efl_canvas_object_key_focus_get");

        private static bool key_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_key_focus_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetKeyFocus();
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
                return efl_canvas_object_key_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_key_focus_get_delegate efl_canvas_object_key_focus_get_static_delegate;

        
        private delegate void efl_canvas_object_key_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool focus);

        
        public delegate void efl_canvas_object_key_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool focus);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate> efl_canvas_object_key_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate>(Module, "efl_canvas_object_key_focus_set");

        private static void key_focus_set(System.IntPtr obj, System.IntPtr pd, bool focus)
        {
            Eina.Log.Debug("function efl_canvas_object_key_focus_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetKeyFocus(focus);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_key_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), focus);
            }
        }

        private static efl_canvas_object_key_focus_set_delegate efl_canvas_object_key_focus_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_seat_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_seat_focus_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate> efl_canvas_object_seat_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate>(Module, "efl_canvas_object_seat_focus_get");

        private static bool seat_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_seat_focus_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetSeatFocus();
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
                return efl_canvas_object_seat_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_seat_focus_get_delegate efl_canvas_object_seat_focus_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_precise_is_inside_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_precise_is_inside_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate> efl_canvas_object_precise_is_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate>(Module, "efl_canvas_object_precise_is_inside_get");

        private static bool precise_is_inside_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_precise_is_inside_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPreciseIsInside();
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
                return efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_precise_is_inside_get_delegate efl_canvas_object_precise_is_inside_get_static_delegate;

        
        private delegate void efl_canvas_object_precise_is_inside_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool precise);

        
        public delegate void efl_canvas_object_precise_is_inside_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool precise);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate> efl_canvas_object_precise_is_inside_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate>(Module, "efl_canvas_object_precise_is_inside_set");

        private static void precise_is_inside_set(System.IntPtr obj, System.IntPtr pd, bool precise)
        {
            Eina.Log.Debug("function efl_canvas_object_precise_is_inside_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetPreciseIsInside(precise);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), precise);
            }
        }

        private static efl_canvas_object_precise_is_inside_set_delegate efl_canvas_object_precise_is_inside_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_propagate_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_propagate_events_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate> efl_canvas_object_propagate_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate>(Module, "efl_canvas_object_propagate_events_get");

        private static bool propagate_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_propagate_events_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPropagateEvents();
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
                return efl_canvas_object_propagate_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_propagate_events_get_delegate efl_canvas_object_propagate_events_get_static_delegate;

        
        private delegate void efl_canvas_object_propagate_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool propagate);

        
        public delegate void efl_canvas_object_propagate_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool propagate);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate> efl_canvas_object_propagate_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate>(Module, "efl_canvas_object_propagate_events_set");

        private static void propagate_events_set(System.IntPtr obj, System.IntPtr pd, bool propagate)
        {
            Eina.Log.Debug("function efl_canvas_object_propagate_events_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetPropagateEvents(propagate);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_propagate_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), propagate);
            }
        }

        private static efl_canvas_object_propagate_events_set_delegate efl_canvas_object_propagate_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_pass_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_pass_events_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate> efl_canvas_object_pass_events_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate>(Module, "efl_canvas_object_pass_events_get");

        private static bool pass_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_pass_events_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPassEvents();
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
                return efl_canvas_object_pass_events_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_pass_events_get_delegate efl_canvas_object_pass_events_get_static_delegate;

        
        private delegate void efl_canvas_object_pass_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool pass);

        
        public delegate void efl_canvas_object_pass_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool pass);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate> efl_canvas_object_pass_events_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate>(Module, "efl_canvas_object_pass_events_set");

        private static void pass_events_set(System.IntPtr obj, System.IntPtr pd, bool pass)
        {
            Eina.Log.Debug("function efl_canvas_object_pass_events_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetPassEvents(pass);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_pass_events_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pass);
            }
        }

        private static efl_canvas_object_pass_events_set_delegate efl_canvas_object_pass_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_anti_alias_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_anti_alias_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate> efl_canvas_object_anti_alias_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate>(Module, "efl_canvas_object_anti_alias_get");

        private static bool anti_alias_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_anti_alias_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetAntiAlias();
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
                return efl_canvas_object_anti_alias_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_anti_alias_get_delegate efl_canvas_object_anti_alias_get_static_delegate;

        
        private delegate void efl_canvas_object_anti_alias_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

        
        public delegate void efl_canvas_object_anti_alias_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate> efl_canvas_object_anti_alias_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate>(Module, "efl_canvas_object_anti_alias_set");

        private static void anti_alias_set(System.IntPtr obj, System.IntPtr pd, bool anti_alias)
        {
            Eina.Log.Debug("function efl_canvas_object_anti_alias_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetAntiAlias(anti_alias);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_anti_alias_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), anti_alias);
            }
        }

        private static efl_canvas_object_anti_alias_set_delegate efl_canvas_object_anti_alias_set_static_delegate;

        
        private delegate System.IntPtr efl_canvas_object_clipped_objects_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_object_clipped_objects_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate> efl_canvas_object_clipped_objects_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate>(Module, "efl_canvas_object_clipped_objects_get");

        private static System.IntPtr clipped_objects_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_clipped_objects_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Canvas.Object> _ret_var = default(Eina.Iterator<Efl.Canvas.Object>);
                try
                {
                    _ret_var = ((Object)ws.Target).GetClippedObjects();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_canvas_object_clipped_objects_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipped_objects_get_delegate efl_canvas_object_clipped_objects_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_canvas_object_render_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_canvas_object_render_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate> efl_canvas_object_render_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate>(Module, "efl_canvas_object_render_parent_get");

        private static Efl.Canvas.Object render_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_render_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRenderParent();
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
                return efl_canvas_object_render_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_render_parent_get_delegate efl_canvas_object_render_parent_get_static_delegate;

        
        private delegate Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate> efl_canvas_object_paragraph_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate>(Module, "efl_canvas_object_paragraph_direction_get");

        private static Efl.TextBidirectionalType paragraph_direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_paragraph_direction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextBidirectionalType _ret_var = default(Efl.TextBidirectionalType);
                try
                {
                    _ret_var = ((Object)ws.Target).GetParagraphDirection();
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
                return efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_paragraph_direction_get_delegate efl_canvas_object_paragraph_direction_get_static_delegate;

        
        private delegate void efl_canvas_object_paragraph_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextBidirectionalType dir);

        
        public delegate void efl_canvas_object_paragraph_direction_set_api_delegate(System.IntPtr obj,  Efl.TextBidirectionalType dir);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate> efl_canvas_object_paragraph_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate>(Module, "efl_canvas_object_paragraph_direction_set");

        private static void paragraph_direction_set(System.IntPtr obj, System.IntPtr pd, Efl.TextBidirectionalType dir)
        {
            Eina.Log.Debug("function efl_canvas_object_paragraph_direction_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetParagraphDirection(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_canvas_object_paragraph_direction_set_delegate efl_canvas_object_paragraph_direction_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_no_render_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_no_render_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate> efl_canvas_object_no_render_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate>(Module, "efl_canvas_object_no_render_get");

        private static bool no_render_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_no_render_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetNoRender();
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
                return efl_canvas_object_no_render_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_no_render_get_delegate efl_canvas_object_no_render_get_static_delegate;

        
        private delegate void efl_canvas_object_no_render_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_canvas_object_no_render_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate> efl_canvas_object_no_render_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate>(Module, "efl_canvas_object_no_render_set");

        private static void no_render_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_canvas_object_no_render_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetNoRender(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_canvas_object_no_render_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_canvas_object_no_render_set_delegate efl_canvas_object_no_render_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_coords_inside_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_coords_inside_get_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate> efl_canvas_object_coords_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate>(Module, "efl_canvas_object_coords_inside_get");

        private static bool coords_inside_get(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_canvas_object_coords_inside_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetCoordsInside(_in_pos);
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
                return efl_canvas_object_coords_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_canvas_object_coords_inside_get_delegate efl_canvas_object_coords_inside_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_seat_focus_check_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_seat_focus_check_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_check_api_delegate> efl_canvas_object_seat_focus_check_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_check_api_delegate>(Module, "efl_canvas_object_seat_focus_check");

        private static bool seat_focus_check(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_canvas_object_seat_focus_check was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).CheckSeatFocus(seat);
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
                return efl_canvas_object_seat_focus_check_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_canvas_object_seat_focus_check_delegate efl_canvas_object_seat_focus_check_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_seat_focus_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_seat_focus_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_add_api_delegate> efl_canvas_object_seat_focus_add_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_add_api_delegate>(Module, "efl_canvas_object_seat_focus_add");

        private static bool seat_focus_add(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_canvas_object_seat_focus_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).AddSeatFocus(seat);
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
                return efl_canvas_object_seat_focus_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_canvas_object_seat_focus_add_delegate efl_canvas_object_seat_focus_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_seat_focus_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_seat_focus_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_del_api_delegate> efl_canvas_object_seat_focus_del_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_seat_focus_del_api_delegate>(Module, "efl_canvas_object_seat_focus_del");

        private static bool seat_focus_del(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_canvas_object_seat_focus_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).DelSeatFocus(seat);
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
                return efl_canvas_object_seat_focus_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_canvas_object_seat_focus_del_delegate efl_canvas_object_seat_focus_del_static_delegate;

        
        private delegate uint efl_canvas_object_clipped_objects_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_canvas_object_clipped_objects_count_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate> efl_canvas_object_clipped_objects_count_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate>(Module, "efl_canvas_object_clipped_objects_count");

        private static uint clipped_objects_count(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_clipped_objects_count was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Object)ws.Target).ClippedObjectsCount();
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
                return efl_canvas_object_clipped_objects_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipped_objects_count_delegate efl_canvas_object_clipped_objects_count_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_key_grab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_key_grab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_grab_api_delegate> efl_canvas_object_key_grab_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_grab_api_delegate>(Module, "efl_canvas_object_key_grab");

        private static bool key_grab(System.IntPtr obj, System.IntPtr pd, System.String keyname, Efl.Input.Modifier modifiers, Efl.Input.Modifier not_modifiers, bool exclusive)
        {
            Eina.Log.Debug("function efl_canvas_object_key_grab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GrabKey(keyname, modifiers, not_modifiers, exclusive);
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
                return efl_canvas_object_key_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), keyname, modifiers, not_modifiers, exclusive);
            }
        }

        private static efl_canvas_object_key_grab_delegate efl_canvas_object_key_grab_static_delegate;

        
        private delegate void efl_canvas_object_key_ungrab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers);

        
        public delegate void efl_canvas_object_key_ungrab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate> efl_canvas_object_key_ungrab_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate>(Module, "efl_canvas_object_key_ungrab");

        private static void key_ungrab(System.IntPtr obj, System.IntPtr pd, System.String keyname, Efl.Input.Modifier modifiers, Efl.Input.Modifier not_modifiers)
        {
            Eina.Log.Debug("function efl_canvas_object_key_ungrab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Object)ws.Target).UngrabKey(keyname, modifiers, not_modifiers);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_canvas_object_key_ungrab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), keyname, modifiers, not_modifiers);
            }
        }

        private static efl_canvas_object_key_ungrab_delegate efl_canvas_object_key_ungrab_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.GestureManager efl_canvas_object_gesture_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.GestureManager efl_canvas_object_gesture_manager_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_object_gesture_manager_get_api_delegate> efl_canvas_object_gesture_manager_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_object_gesture_manager_get_api_delegate>(Module, "efl_canvas_object_gesture_manager_get");

        private static Efl.Canvas.GestureManager gesture_manager_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_object_gesture_manager_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.GestureManager _ret_var = default(Efl.Canvas.GestureManager);
                try
                {
                    _ret_var = ((Object)ws.Target).GetGestureManager();
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
                return efl_canvas_object_gesture_manager_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_gesture_manager_get_delegate efl_canvas_object_gesture_manager_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_pointer_inside_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_pointer_inside_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate> efl_canvas_pointer_inside_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_pointer_inside_get_api_delegate>(Module, "efl_canvas_pointer_inside_get");

        private static bool pointer_inside_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_canvas_pointer_inside_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPointerInside(seat);
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
                return efl_canvas_pointer_inside_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_canvas_pointer_inside_get_delegate efl_canvas_pointer_inside_get_static_delegate;

        
        private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a);

        
        public delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(Module, "efl_gfx_color_get");

        private static void color_get(System.IntPtr obj, System.IntPtr pd, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(int);        g = default(int);        b = default(int);        a = default(int);                                            
                try
                {
                    ((Object)ws.Target).GetColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;

        
        private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a);

        
        public delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(Module, "efl_gfx_color_set");

        private static void color_set(System.IntPtr obj, System.IntPtr pd, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).SetColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(Module, "efl_gfx_color_code_get");

        private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_color_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Object)ws.Target).GetColorCode();
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
                return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;

        
        private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        
        public delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String colorcode);

        public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(Module, "efl_gfx_color_code_set");

        private static void color_code_set(System.IntPtr obj, System.IntPtr pd, System.String colorcode)
        {
            Eina.Log.Debug("function efl_gfx_color_code_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetColorCode(colorcode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), colorcode);
            }
        }

        private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(Module, "efl_gfx_entity_position_get");

        private static Eina.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPosition();
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
                return efl_gfx_entity_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;

        
        private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(Module, "efl_gfx_entity_position_set");

        private static void position_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_gfx_entity_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            
                try
                {
                    ((Object)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(Module, "efl_gfx_entity_size_get");

        private static Eina.Size2D.NativeStruct size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetSize();
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
                return efl_gfx_entity_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;

        
        private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(Module, "efl_gfx_entity_size_set");

        private static void size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_entity_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((Object)ws.Target).SetSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(Module, "efl_gfx_entity_geometry_get");

        private static Eina.Rect.NativeStruct geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Object)ws.Target).GetGeometry();
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
                return efl_gfx_entity_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;

        
        private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect);

        
        public delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(Module, "efl_gfx_entity_geometry_set");

        private static void geometry_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_gfx_entity_geometry_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                            
                try
                {
                    ((Object)ws.Target).SetGeometry(_in_rect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_geometry_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect);
            }
        }

        private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(Module, "efl_gfx_entity_visible_get");

        private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_visible_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetVisible();
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
                return efl_gfx_entity_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;

        
        private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(Module, "efl_gfx_entity_visible_set");

        private static void visible_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            Eina.Log.Debug("function efl_gfx_entity_visible_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetVisible(v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), v);
            }
        }

        private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;

        
        private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(Module, "efl_gfx_entity_scale_get");

        private static double scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_entity_scale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Object)ws.Target).GetScale();
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
                return efl_gfx_entity_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;

        
        private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        public delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,  double scale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(Module, "efl_gfx_entity_scale_set");

        private static void scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            Eina.Log.Debug("function efl_gfx_entity_scale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetScale(scale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scale);
            }
        }

        private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;

        
        private delegate void efl_gfx_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Gfx.HintAspect mode,  out Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_aspect_get_api_delegate(System.IntPtr obj,  out Efl.Gfx.HintAspect mode,  out Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate> efl_gfx_hint_aspect_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_get_api_delegate>(Module, "efl_gfx_hint_aspect_get");

        private static void hint_aspect_get(System.IntPtr obj, System.IntPtr pd, out Efl.Gfx.HintAspect mode, out Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_aspect_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        mode = default(Efl.Gfx.HintAspect);        Eina.Size2D _out_sz = default(Eina.Size2D);
                            
                try
                {
                    ((Object)ws.Target).GetHintAspect(out mode, out _out_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                sz = _out_sz;
                        
            }
            else
            {
                efl_gfx_hint_aspect_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out mode, out sz);
            }
        }

        private static efl_gfx_hint_aspect_get_delegate efl_gfx_hint_aspect_get_static_delegate;

        
        private delegate void efl_gfx_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.HintAspect mode,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_aspect_set_api_delegate(System.IntPtr obj,  Efl.Gfx.HintAspect mode,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate> efl_gfx_hint_aspect_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_aspect_set_api_delegate>(Module, "efl_gfx_hint_aspect_set");

        private static void hint_aspect_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.HintAspect mode, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_aspect_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _in_sz = sz;
                                            
                try
                {
                    ((Object)ws.Target).SetHintAspect(mode, _in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_aspect_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode, sz);
            }
        }

        private static efl_gfx_hint_aspect_set_delegate efl_gfx_hint_aspect_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate> efl_gfx_hint_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_get_api_delegate>(Module, "efl_gfx_hint_size_max_get");

        private static Eina.Size2D.NativeStruct hint_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeMax();
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
                return efl_gfx_hint_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_max_get_delegate efl_gfx_hint_size_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_max_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate> efl_gfx_hint_size_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_max_set_api_delegate>(Module, "efl_gfx_hint_size_max_set");

        private static void hint_size_max_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Object)ws.Target).SetHintSizeMax(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_max_set_delegate efl_gfx_hint_size_max_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate> efl_gfx_hint_size_restricted_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_get");

        private static Eina.Size2D.NativeStruct hint_size_restricted_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeRestrictedMax();
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
                return efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_max_get_delegate efl_gfx_hint_size_restricted_max_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_max_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate> efl_gfx_hint_size_restricted_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_set");

        private static void hint_size_restricted_max_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Object)ws.Target).SetHintSizeRestrictedMax(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_restricted_max_set_delegate efl_gfx_hint_size_restricted_max_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate> efl_gfx_hint_size_combined_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_max_get_api_delegate>(Module, "efl_gfx_hint_size_combined_max_get");

        private static Eina.Size2D.NativeStruct hint_size_combined_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_combined_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeCombinedMax();
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
                return efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_max_get_delegate efl_gfx_hint_size_combined_max_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate> efl_gfx_hint_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_get_api_delegate>(Module, "efl_gfx_hint_size_min_get");

        private static Eina.Size2D.NativeStruct hint_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeMin();
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
                return efl_gfx_hint_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_min_get_delegate efl_gfx_hint_size_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_min_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate> efl_gfx_hint_size_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_min_set_api_delegate>(Module, "efl_gfx_hint_size_min_set");

        private static void hint_size_min_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Object)ws.Target).SetHintSizeMin(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_min_set_delegate efl_gfx_hint_size_min_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_restricted_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate> efl_gfx_hint_size_restricted_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_get_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_get");

        private static Eina.Size2D.NativeStruct hint_size_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeRestrictedMin();
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
                return efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_restricted_min_get_delegate efl_gfx_hint_size_restricted_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_set");

        private static void hint_size_restricted_min_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_restricted_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Object)ws.Target).SetHintSizeRestrictedMin(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_restricted_min_set_delegate efl_gfx_hint_size_restricted_min_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_hint_size_combined_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate> efl_gfx_hint_size_combined_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_size_combined_min_get_api_delegate>(Module, "efl_gfx_hint_size_combined_min_get");

        private static Eina.Size2D.NativeStruct hint_size_combined_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_hint_size_combined_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetHintSizeCombinedMin();
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
                return efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_hint_size_combined_min_get_delegate efl_gfx_hint_size_combined_min_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_hint_margin_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate> efl_gfx_hint_margin_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_get_api_delegate>(Module, "efl_gfx_hint_margin_get");

        private static void hint_margin_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_hint_margin_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((Object)ws.Target).GetHintMargin(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_hint_margin_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_hint_margin_get_delegate efl_gfx_hint_margin_get_static_delegate;

        
        private delegate void efl_gfx_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b);

        
        public delegate void efl_gfx_hint_margin_set_api_delegate(System.IntPtr obj,  int l,  int r,  int t,  int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate> efl_gfx_hint_margin_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_margin_set_api_delegate>(Module, "efl_gfx_hint_margin_set");

        private static void hint_margin_set(System.IntPtr obj, System.IntPtr pd, int l, int r, int t, int b)
        {
            Eina.Log.Debug("function efl_gfx_hint_margin_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).SetHintMargin(l, r, t, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_hint_margin_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), l, r, t, b);
            }
        }

        private static efl_gfx_hint_margin_set_delegate efl_gfx_hint_margin_set_static_delegate;

        
        private delegate void efl_gfx_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_hint_weight_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate> efl_gfx_hint_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_get_api_delegate>(Module, "efl_gfx_hint_weight_get");

        private static void hint_weight_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_weight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((Object)ws.Target).GetHintWeight(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_weight_get_delegate efl_gfx_hint_weight_get_static_delegate;

        
        private delegate void efl_gfx_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_hint_weight_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate> efl_gfx_hint_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_weight_set_api_delegate>(Module, "efl_gfx_hint_weight_set");

        private static void hint_weight_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_weight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Object)ws.Target).SetHintWeight(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_weight_set_delegate efl_gfx_hint_weight_set_static_delegate;

        
        private delegate void efl_gfx_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_gfx_hint_align_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate> efl_gfx_hint_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_get_api_delegate>(Module, "efl_gfx_hint_align_get");

        private static void hint_align_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((Object)ws.Target).GetHintAlign(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_align_get_delegate efl_gfx_hint_align_get_static_delegate;

        
        private delegate void efl_gfx_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_gfx_hint_align_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate> efl_gfx_hint_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_align_set_api_delegate>(Module, "efl_gfx_hint_align_set");

        private static void hint_align_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_gfx_hint_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Object)ws.Target).SetHintAlign(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_align_set_delegate efl_gfx_hint_align_set_static_delegate;

        
        private delegate void efl_gfx_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        
        public delegate void efl_gfx_hint_fill_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool x, [MarshalAs(UnmanagedType.U1)] out bool y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate> efl_gfx_hint_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_get_api_delegate>(Module, "efl_gfx_hint_fill_get");

        private static void hint_fill_get(System.IntPtr obj, System.IntPtr pd, out bool x, out bool y)
        {
            Eina.Log.Debug("function efl_gfx_hint_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(bool);        y = default(bool);                            
                try
                {
                    ((Object)ws.Target).GetHintFill(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_gfx_hint_fill_get_delegate efl_gfx_hint_fill_get_static_delegate;

        
        private delegate void efl_gfx_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        
        public delegate void efl_gfx_hint_fill_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool x, [MarshalAs(UnmanagedType.U1)] bool y);

        public static Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate> efl_gfx_hint_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_hint_fill_set_api_delegate>(Module, "efl_gfx_hint_fill_set");

        private static void hint_fill_set(System.IntPtr obj, System.IntPtr pd, bool x, bool y)
        {
            Eina.Log.Debug("function efl_gfx_hint_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Object)ws.Target).SetHintFill(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_hint_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_gfx_hint_fill_set_delegate efl_gfx_hint_fill_set_static_delegate;

        
        private delegate int efl_gfx_mapping_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_mapping_point_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate> efl_gfx_mapping_point_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate>(Module, "efl_gfx_mapping_point_count_get");

        private static int mapping_point_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_point_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Object)ws.Target).GetMappingPointCount();
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
                return efl_gfx_mapping_point_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_point_count_get_delegate efl_gfx_mapping_point_count_get_static_delegate;

        
        private delegate void efl_gfx_mapping_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int count);

        
        public delegate void efl_gfx_mapping_point_count_set_api_delegate(System.IntPtr obj,  int count);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate> efl_gfx_mapping_point_count_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate>(Module, "efl_gfx_mapping_point_count_set");

        private static void mapping_point_count_set(System.IntPtr obj, System.IntPtr pd, int count)
        {
            Eina.Log.Debug("function efl_gfx_mapping_point_count_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetMappingPointCount(count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_point_count_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), count);
            }
        }

        private static efl_gfx_mapping_point_count_set_delegate efl_gfx_mapping_point_count_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_clockwise_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate> efl_gfx_mapping_clockwise_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate>(Module, "efl_gfx_mapping_clockwise_get");

        private static bool mapping_clockwise_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_clockwise_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetMappingClockwise();
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
                return efl_gfx_mapping_clockwise_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_clockwise_get_delegate efl_gfx_mapping_clockwise_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_smooth_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate> efl_gfx_mapping_smooth_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate>(Module, "efl_gfx_mapping_smooth_get");

        private static bool mapping_smooth_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_smooth_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetMappingSmooth();
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
                return efl_gfx_mapping_smooth_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_smooth_get_delegate efl_gfx_mapping_smooth_get_static_delegate;

        
        private delegate void efl_gfx_mapping_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool smooth);

        
        public delegate void efl_gfx_mapping_smooth_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool smooth);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate> efl_gfx_mapping_smooth_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate>(Module, "efl_gfx_mapping_smooth_set");

        private static void mapping_smooth_set(System.IntPtr obj, System.IntPtr pd, bool smooth)
        {
            Eina.Log.Debug("function efl_gfx_mapping_smooth_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetMappingSmooth(smooth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_smooth_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), smooth);
            }
        }

        private static efl_gfx_mapping_smooth_set_delegate efl_gfx_mapping_smooth_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_alpha_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate> efl_gfx_mapping_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate>(Module, "efl_gfx_mapping_alpha_get");

        private static bool mapping_alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_alpha_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetMappingAlpha();
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
                return efl_gfx_mapping_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_alpha_get_delegate efl_gfx_mapping_alpha_get_static_delegate;

        
        private delegate void efl_gfx_mapping_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        public delegate void efl_gfx_mapping_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate> efl_gfx_mapping_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate>(Module, "efl_gfx_mapping_alpha_set");

        private static void mapping_alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            Eina.Log.Debug("function efl_gfx_mapping_alpha_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetMappingAlpha(alpha);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), alpha);
            }
        }

        private static efl_gfx_mapping_alpha_set_delegate efl_gfx_mapping_alpha_set_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double x,  out double y,  out double z);

        
        public delegate void efl_gfx_mapping_coord_absolute_get_api_delegate(System.IntPtr obj,  int idx,  out double x,  out double y,  out double z);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate> efl_gfx_mapping_coord_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_get");

        private static void mapping_coord_absolute_get(System.IntPtr obj, System.IntPtr pd, int idx, out double x, out double y, out double z)
        {
            Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                x = default(double);        y = default(double);        z = default(double);                                            
                try
                {
                    ((Object)ws.Target).GetMappingCoordAbsolute(idx, out x, out y, out z);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out x, out y, out z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_get_delegate efl_gfx_mapping_coord_absolute_get_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double x,  double y,  double z);

        
        public delegate void efl_gfx_mapping_coord_absolute_set_api_delegate(System.IntPtr obj,  int idx,  double x,  double y,  double z);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate> efl_gfx_mapping_coord_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_set");

        private static void mapping_coord_absolute_set(System.IntPtr obj, System.IntPtr pd, int idx, double x, double y, double z)
        {
            Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).SetMappingCoordAbsolute(idx, x, y, z);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, x, y, z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_set_delegate efl_gfx_mapping_coord_absolute_set_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double u,  out double v);

        
        public delegate void efl_gfx_mapping_uv_get_api_delegate(System.IntPtr obj,  int idx,  out double u,  out double v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate> efl_gfx_mapping_uv_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate>(Module, "efl_gfx_mapping_uv_get");

        private static void mapping_uv_get(System.IntPtr obj, System.IntPtr pd, int idx, out double u, out double v)
        {
            Eina.Log.Debug("function efl_gfx_mapping_uv_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        u = default(double);        v = default(double);                                    
                try
                {
                    ((Object)ws.Target).GetMappingUv(idx, out u, out v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_uv_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out u, out v);
            }
        }

        private static efl_gfx_mapping_uv_get_delegate efl_gfx_mapping_uv_get_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double u,  double v);

        
        public delegate void efl_gfx_mapping_uv_set_api_delegate(System.IntPtr obj,  int idx,  double u,  double v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate> efl_gfx_mapping_uv_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate>(Module, "efl_gfx_mapping_uv_set");

        private static void mapping_uv_set(System.IntPtr obj, System.IntPtr pd, int idx, double u, double v)
        {
            Eina.Log.Debug("function efl_gfx_mapping_uv_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Object)ws.Target).SetMappingUv(idx, u, v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_uv_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, u, v);
            }
        }

        private static efl_gfx_mapping_uv_set_delegate efl_gfx_mapping_uv_set_static_delegate;

        
        private delegate void efl_gfx_mapping_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out int r,  out int g,  out int b,  out int a);

        
        public delegate void efl_gfx_mapping_color_get_api_delegate(System.IntPtr obj,  int idx,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate> efl_gfx_mapping_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate>(Module, "efl_gfx_mapping_color_get");

        private static void mapping_color_get(System.IntPtr obj, System.IntPtr pd, int idx, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_mapping_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                        r = default(int);        g = default(int);        b = default(int);        a = default(int);                                                    
                try
                {
                    ((Object)ws.Target).GetMappingColor(idx, out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out r, out g, out b, out a);
            }
        }

        private static efl_gfx_mapping_color_get_delegate efl_gfx_mapping_color_get_static_delegate;

        
        private delegate void efl_gfx_mapping_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  int r,  int g,  int b,  int a);

        
        public delegate void efl_gfx_mapping_color_set_api_delegate(System.IntPtr obj,  int idx,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate> efl_gfx_mapping_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate>(Module, "efl_gfx_mapping_color_set");

        private static void mapping_color_set(System.IntPtr obj, System.IntPtr pd, int idx, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_mapping_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Object)ws.Target).SetMappingColor(idx, r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, r, g, b, a);
            }
        }

        private static efl_gfx_mapping_color_set_delegate efl_gfx_mapping_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_has_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_has_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate> efl_gfx_mapping_has_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate>(Module, "efl_gfx_mapping_has");

        private static bool mapping_has(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_has was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).HasMapping();
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
                return efl_gfx_mapping_has_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_has_delegate efl_gfx_mapping_has_static_delegate;

        
        private delegate void efl_gfx_mapping_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_mapping_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate> efl_gfx_mapping_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate>(Module, "efl_gfx_mapping_reset");

        private static void mapping_reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Object)ws.Target).ResetMapping();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_mapping_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_reset_delegate efl_gfx_mapping_reset_static_delegate;

        
        private delegate void efl_gfx_mapping_translate_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz);

        
        public delegate void efl_gfx_mapping_translate_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate> efl_gfx_mapping_translate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate>(Module, "efl_gfx_mapping_translate");

        private static void translate(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_translate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Object)ws.Target).Translate(dx, dy, dz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_translate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz);
            }
        }

        private static efl_gfx_mapping_translate_delegate efl_gfx_mapping_translate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_rotate_api_delegate(System.IntPtr obj,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate> efl_gfx_mapping_rotate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate>(Module, "efl_gfx_mapping_rotate");

        private static void rotate(System.IntPtr obj, System.IntPtr pd, double degrees, Efl.Gfx.IEntity pivot, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).Rotate(degrees, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), degrees, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_delegate efl_gfx_mapping_rotate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_3d_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate> efl_gfx_mapping_rotate_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate>(Module, "efl_gfx_mapping_rotate_3d");

        private static void rotate_3d(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, Efl.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_3d was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                    
                try
                {
                    ((Object)ws.Target).Rotate3d(dx, dy, dz, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_delegate efl_gfx_mapping_rotate_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_quat_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate> efl_gfx_mapping_rotate_quat_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate>(Module, "efl_gfx_mapping_rotate_quat");

        private static void rotate_quat(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, Efl.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_quat was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                            
                try
                {
                    ((Object)ws.Target).RotateQuat(qx, qy, qz, qw, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_quat_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), qx, qy, qz, qw, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_delegate efl_gfx_mapping_rotate_quat_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_zoom_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate> efl_gfx_mapping_zoom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate>(Module, "efl_gfx_mapping_zoom");

        private static void zoom(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, Efl.Gfx.IEntity pivot, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_zoom was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Object)ws.Target).Zoom(zoomx, zoomy, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_zoom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), zoomx, zoomy, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_delegate efl_gfx_mapping_zoom_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        public delegate void efl_gfx_mapping_lighting_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate> efl_gfx_mapping_lighting_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate>(Module, "efl_gfx_mapping_lighting_3d");

        private static void lighting_3d(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            Eina.Log.Debug("function efl_gfx_mapping_lighting_3d was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                                                                            
                try
                {
                    ((Object)ws.Target).Lighting3d(pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_lighting_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_delegate efl_gfx_mapping_lighting_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        
        public delegate void efl_gfx_mapping_perspective_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate> efl_gfx_mapping_perspective_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate>(Module, "efl_gfx_mapping_perspective_3d");

        private static void perspective_3d(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity pivot, double px, double py, double z0, double foc)
        {
            Eina.Log.Debug("function efl_gfx_mapping_perspective_3d was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Object)ws.Target).Perspective3d(pivot, px, py, z0, foc);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_perspective_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pivot, px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_delegate efl_gfx_mapping_perspective_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_rotate_absolute_api_delegate(System.IntPtr obj,  double degrees,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate> efl_gfx_mapping_rotate_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_absolute");

        private static void rotate_absolute(System.IntPtr obj, System.IntPtr pd, double degrees, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((Object)ws.Target).RotateAbsolute(degrees, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), degrees, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_absolute_delegate efl_gfx_mapping_rotate_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_3d_absolute_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate> efl_gfx_mapping_rotate_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_3d_absolute");

        private static void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_3d_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                            
                try
                {
                    ((Object)ws.Target).Rotate3dAbsolute(dx, dy, dz, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_absolute_delegate efl_gfx_mapping_rotate_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_quat_absolute_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate> efl_gfx_mapping_rotate_quat_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_quat_absolute");

        private static void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_quat_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                    
                try
                {
                    ((Object)ws.Target).RotateQuatAbsolute(qx, qy, qz, qw, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), qx, qy, qz, qw, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_absolute_delegate efl_gfx_mapping_rotate_quat_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_zoom_absolute_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate> efl_gfx_mapping_zoom_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate>(Module, "efl_gfx_mapping_zoom_absolute");

        private static void zoom_absolute(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_zoom_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).ZoomAbsolute(zoomx, zoomy, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), zoomx, zoomy, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_absolute_delegate efl_gfx_mapping_zoom_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        public delegate void efl_gfx_mapping_lighting_3d_absolute_api_delegate(System.IntPtr obj,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate> efl_gfx_mapping_lighting_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_lighting_3d_absolute");

        private static void lighting_3d_absolute(System.IntPtr obj, System.IntPtr pd, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            Eina.Log.Debug("function efl_gfx_mapping_lighting_3d_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                                                    
                try
                {
                    ((Object)ws.Target).Lighting3dAbsolute(lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_absolute_delegate efl_gfx_mapping_lighting_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc);

        
        public delegate void efl_gfx_mapping_perspective_3d_absolute_api_delegate(System.IntPtr obj,  double px,  double py,  double z0,  double foc);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate> efl_gfx_mapping_perspective_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_perspective_3d_absolute");

        private static void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd, double px, double py, double z0, double foc)
        {
            Eina.Log.Debug("function efl_gfx_mapping_perspective_3d_absolute was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Object)ws.Target).Perspective3dAbsolute(px, py, z0, foc);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_absolute_delegate efl_gfx_mapping_perspective_3d_absolute_static_delegate;

        
        private delegate short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate short efl_gfx_stack_layer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate> efl_gfx_stack_layer_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate>(Module, "efl_gfx_stack_layer_get");

        private static short layer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_layer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            short _ret_var = default(short);
                try
                {
                    _ret_var = ((Object)ws.Target).GetLayer();
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
                return efl_gfx_stack_layer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;

        
        private delegate void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,  short l);

        
        public delegate void efl_gfx_stack_layer_set_api_delegate(System.IntPtr obj,  short l);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate> efl_gfx_stack_layer_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate>(Module, "efl_gfx_stack_layer_set");

        private static void layer_set(System.IntPtr obj, System.IntPtr pd, short l)
        {
            Eina.Log.Debug("function efl_gfx_stack_layer_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).SetLayer(l);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_layer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), l);
            }
        }

        private static efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IStack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IStack efl_gfx_stack_below_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate> efl_gfx_stack_below_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_get_api_delegate>(Module, "efl_gfx_stack_below_get");

        private static Efl.Gfx.IStack below_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_below_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
                try
                {
                    _ret_var = ((Object)ws.Target).GetBelow();
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
                return efl_gfx_stack_below_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IStack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IStack efl_gfx_stack_above_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate> efl_gfx_stack_above_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_get_api_delegate>(Module, "efl_gfx_stack_above_get");

        private static Efl.Gfx.IStack above_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_above_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.IStack _ret_var = default(Efl.Gfx.IStack);
                try
                {
                    _ret_var = ((Object)ws.Target).GetAbove();
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
                return efl_gfx_stack_above_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;

        
        private delegate void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack below);

        
        public delegate void efl_gfx_stack_below_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack below);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate> efl_gfx_stack_below_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_below_api_delegate>(Module, "efl_gfx_stack_below");

        private static void stack_below(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IStack below)
        {
            Eina.Log.Debug("function efl_gfx_stack_below was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).StackBelow(below);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_below_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), below);
            }
        }

        private static efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;

        
        private delegate void efl_gfx_stack_raise_to_top_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_stack_raise_to_top_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate> efl_gfx_stack_raise_to_top_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate>(Module, "efl_gfx_stack_raise_to_top");

        private static void raise_to_top(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_raise_to_top was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Object)ws.Target).RaiseToTop();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_stack_raise_to_top_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_raise_to_top_delegate efl_gfx_stack_raise_to_top_static_delegate;

        
        private delegate void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack above);

        
        public delegate void efl_gfx_stack_above_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IStack above);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate> efl_gfx_stack_above_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_above_api_delegate>(Module, "efl_gfx_stack_above");

        private static void stack_above(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IStack above)
        {
            Eina.Log.Debug("function efl_gfx_stack_above was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Object)ws.Target).StackAbove(above);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_stack_above_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), above);
            }
        }

        private static efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;

        
        private delegate void efl_gfx_stack_lower_to_bottom_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_stack_lower_to_bottom_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate> efl_gfx_stack_lower_to_bottom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate>(Module, "efl_gfx_stack_lower_to_bottom");

        private static void lower_to_bottom(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_stack_lower_to_bottom was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Object)ws.Target).LowerToBottom();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;

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
                    _ret_var = ((Object)ws.Target).GetSeatEventFilter(seat);
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
                    ((Object)ws.Target).SetSeatEventFilter(seat, enable);
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
public static class Efl_CanvasObject_ExtensionMethods {
    
    public static Efl.BindableProperty<Efl.Input.ObjectPointerMode> PointerMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Efl.Input.ObjectPointerMode>("pointer_mode", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.RenderOp> RenderOp<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Efl.Gfx.RenderOp>("render_op", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Object> Clipper<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Efl.Canvas.Object>("clipper", fac);
    }

    public static Efl.BindableProperty<bool> HasFixedSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("has_fixed_size", fac);
    }

    public static Efl.BindableProperty<bool> RepeatEvents<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("repeat_events", fac);
    }

    public static Efl.BindableProperty<bool> KeyFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("key_focus", fac);
    }

    
    public static Efl.BindableProperty<bool> PreciseIsInside<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("precise_is_inside", fac);
    }

    public static Efl.BindableProperty<bool> PropagateEvents<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("propagate_events", fac);
    }

    public static Efl.BindableProperty<bool> PassEvents<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("pass_events", fac);
    }

    public static Efl.BindableProperty<bool> AntiAlias<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("anti_alias", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.TextBidirectionalType> ParagraphDirection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Efl.TextBidirectionalType>("paragraph_direction", fac);
    }

    public static Efl.BindableProperty<bool> NoRender<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("no_render", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> ColorCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<System.String>("color_code", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> Position<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Position2D>("position", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> Size<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Size2D>("size", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Geometry<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Rect>("geometry", fac);
    }

    public static Efl.BindableProperty<bool> Visible<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("visible", fac);
    }

    public static Efl.BindableProperty<double> Scale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<double>("scale", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> HintSizeMax<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_max", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintSizeRestrictedMax<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_restricted_max", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> HintSizeMin<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_min", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintSizeRestrictedMin<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<Eina.Size2D>("hint_size_restricted_min", fac);
    }

    
    
    
    
    
    public static Efl.BindableProperty<int> MappingPointCount<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<int>("mapping_point_count", fac);
    }

    
    public static Efl.BindableProperty<bool> MappingSmooth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("mapping_smooth", fac);
    }

    public static Efl.BindableProperty<bool> MappingAlpha<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<bool>("mapping_alpha", fac);
    }

    
    
    
    public static Efl.BindableProperty<short> Layer<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Object, T>magic = null) where T : Efl.Canvas.Object {
        return new Efl.BindableProperty<short>("layer", fac);
    }

    
    
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Canvas {

/// <summary>Information of animation events</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ObjectAnimationEvent
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObjectAnimationEvent(IntPtr ptr)
    {
        var tmp = (ObjectAnimationEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObjectAnimationEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObjectAnimationEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObjectAnimationEvent.NativeStruct(ObjectAnimationEvent _external_struct)
        {
            var _internal_struct = new ObjectAnimationEvent.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObjectAnimationEvent(ObjectAnimationEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ObjectAnimationEvent();
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

/// <summary>EFL event animator tick data structure</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct EventAnimatorTick
{
    /// <summary>Area of the canvas that will be pushed to screen.</summary>
    /// <value>A rectangle in pixel dimensions.</value>
    public Eina.Rect Update_area;
    /// <summary>Constructor for EventAnimatorTick.</summary>
    /// <param name="Update_area">Area of the canvas that will be pushed to screen.</param>;
    public EventAnimatorTick(
        Eina.Rect Update_area = default(Eina.Rect)    )
    {
        this.Update_area = Update_area;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator EventAnimatorTick(IntPtr ptr)
    {
        var tmp = (EventAnimatorTick.NativeStruct)Marshal.PtrToStructure(ptr, typeof(EventAnimatorTick.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct EventAnimatorTick.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public Eina.Rect.NativeStruct Update_area;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator EventAnimatorTick.NativeStruct(EventAnimatorTick _external_struct)
        {
            var _internal_struct = new EventAnimatorTick.NativeStruct();
            _internal_struct.Update_area = _external_struct.Update_area;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator EventAnimatorTick(EventAnimatorTick.NativeStruct _internal_struct)
        {
            var _external_struct = new EventAnimatorTick();
            _external_struct.Update_area = _internal_struct.Update_area;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

