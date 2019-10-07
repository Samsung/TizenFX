#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Canvas {

/// <summary>Event argument wrapper for event <see cref="UIKit.Canvas.Object.AnimatorTickEvent"/>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
public class ObjectAnimatorTickEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Animator tick synchronized with screen vsync if possible.</value>
    public UIKit.EventAnimatorTick arg { get; set; }
}

/// <summary>UIKit canvas object abstract class</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Canvas.Object.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public abstract class Object : UIKit.LoopConsumer, UIKit.Canvas.IPointer, UIKit.Gfx.IColor, UIKit.Gfx.IEntity, UIKit.Gfx.IHint, UIKit.Gfx.IMapping, UIKit.Gfx.IStack, UIKit.Input.IInterface
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Object))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_object_class_get();

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Object(UIKit.Object parent= null
            ) : base(efl_canvas_object_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Object(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Object(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [UIKit.Wrapper.PrivateNativeClass]
    private class ObjectRealized : Object
    {
        private ObjectRealized(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Object(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Animator tick synchronized with screen vsync if possible.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Canvas.ObjectAnimatorTickEventArgs"/></value>
    public event EventHandler<UIKit.Canvas.ObjectAnimatorTickEventArgs> AnimatorTickEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Canvas.ObjectAnimatorTickEventArgs args = new UIKit.Canvas.ObjectAnimatorTickEventArgs();
                        args.arg =  evt.Info;
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

            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event AnimatorTickEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnimatorTickEvent(UIKit.Canvas.ObjectAnimatorTickEventArgs e)
    {
        var key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }


    /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityVisibilityChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntityVisibilityChangedEventArgs> VisibilityChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntityVisibilityChangedEventArgs args = new UIKit.Gfx.EntityVisibilityChangedEventArgs();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event VisibilityChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnVisibilityChangedEvent(UIKit.Gfx.EntityVisibilityChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Object was moved, its position during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntityPositionChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntityPositionChangedEventArgs> PositionChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntityPositionChangedEventArgs args = new UIKit.Gfx.EntityPositionChangedEventArgs();
                        args.arg =  evt.Info;
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

            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event PositionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPositionChangedEvent(UIKit.Gfx.EntityPositionChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Object was resized, its size during the event is the new one.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="UIKit.Gfx.EntitySizeChangedEventArgs"/></value>
    public event EventHandler<UIKit.Gfx.EntitySizeChangedEventArgs> SizeChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    UIKit.Gfx.EntitySizeChangedEventArgs args = new UIKit.Gfx.EntitySizeChangedEventArgs();
                        args.arg =  evt.Info;
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

            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event SizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSizeChangedEvent(UIKit.Gfx.EntitySizeChangedEventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }

    /// <summary>Object hints changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler HintsChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
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

            string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event HintsChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnHintsChangedEvent(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Object stacking was changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    public event EventHandler StackingChangedEvent
    {
        add
        {
            UIKit.EventCb callerCb = (IntPtr data, ref UIKit.Event.NativeStruct evt) =>
            {
                var obj = UIKit.Wrapper.Globals.WrapperSupervisorPtrToManaged(data).Target;
                if (obj != null)
                {
                    EventArgs args = EventArgs.Empty;
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

            string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
            AddNativeEventHandler(UIKit.Libs.Evas, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
            RemoveNativeEventHandler(UIKit.Libs.Evas, key, value);
        }
    }

    /// <summary>Method to raise event StackingChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStackingChangedEvent(EventArgs e)
    {
        var key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
        IntPtr desc = UIKit.EventDescription.GetNative(UIKit.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            UIKit.DataTypes.Log.Error($"Failed to get native event {key}");
            return;
        }

        UIKit.Wrapper.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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

    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="UIKit.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="UIKit.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="UIKit.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Blend or copy.</returns>
    public virtual UIKit.Gfx.RenderOp GetRenderOp() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_render_op_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="UIKit.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="UIKit.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="UIKit.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="render_op">Blend or copy.</param>
    public virtual void SetRenderOp(UIKit.Gfx.RenderOp render_op) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_render_op_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),render_op);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Clip one object to another.
    /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
    /// 
    /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
    /// 
    /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
    /// 
    /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
    /// 
    /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="UIKit.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
    /// 
    /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
    /// 
    /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
    /// 
    /// Note: Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The object to clip <c>obj</c> by.</returns>
    public virtual UIKit.Canvas.Object GetClipper() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Clip one object to another.
    /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
    /// 
    /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
    /// 
    /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
    /// 
    /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
    /// 
    /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="UIKit.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
    /// 
    /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
    /// 
    /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
    /// 
    /// Note: Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="clipper">The object to clip <c>obj</c> by.</param>
    public virtual void SetClipper(UIKit.Canvas.Object clipper) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_clipper_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),clipper);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether an Evas object is to repeat events to objects below it.
    /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</returns>
    public virtual bool GetRepeatEvents() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether an Evas object is to repeat events to objects below it.
    /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="repeat">Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</param>
    public virtual void SetRepeatEvents(bool repeat) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),repeat);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">UIKit.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> when set as focused or <c>false</c> otherwise.</returns>
    public virtual bool GetKeyFocus() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">UIKit.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="focus"><c>true</c> when set as focused or <c>false</c> otherwise.</param>
    public virtual void SetKeyFocus(bool focus) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Check if this object is focused.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</returns>
    public virtual bool GetSeatFocus() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
    /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
    /// 
    /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Whether to use precise point collision detection.</returns>
    public virtual bool GetPreciseIsInside() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
    /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
    /// 
    /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="precise">Whether to use precise point collision detection.<br/>The default value is <c>false</c>.</param>
    public virtual void SetPreciseIsInside(bool precise) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),precise);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
    /// This function has no effect if <c>obj</c> is not a member of a smart object.
    /// 
    /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPassEvents"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Whether to propagate events.</returns>
    public virtual bool GetPropagateEvents() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
    /// This function has no effect if <c>obj</c> is not a member of a smart object.
    /// 
    /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPassEvents"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="propagate">Whether to propagate events.<br/>The default value is <c>true</c>.</param>
    public virtual void SetPropagateEvents(bool propagate) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),propagate);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether an Evas object is to pass (ignore) events.
    /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPropagateEvents"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</returns>
    public virtual bool GetPassEvents() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether an Evas object is to pass (ignore) events.
    /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPropagateEvents"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pass">Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</param>
    public virtual void SetPassEvents(bool pass) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),pass);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</returns>
    public virtual bool GetAntiAlias() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="anti_alias"><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</param>
    public virtual void SetAntiAlias(bool anti_alias) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),anti_alias);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>List of objects currently clipped by <c>obj</c>.
    /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.Clipper"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>An iterator over the list of objects clipped by <c>obj</c>.</returns>
    public virtual UIKit.DataTypes.Iterator<UIKit.Canvas.Object> GetClippedObjects() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return new UIKit.DataTypes.Iterator<UIKit.Canvas.Object>(_ret_var, false);

    }

    /// <summary>Gets the parent smart object of a given Evas object, if it has one.
    /// This can be different from <see cref="UIKit.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The parent smart object of <c>obj</c> or <c>null</c>.</returns>
    protected virtual UIKit.Canvas.Object GetRenderParent() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_render_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Paragraph direction for the given object.</returns>
    public virtual UIKit.TextBidirectionalType GetParagraphDirection() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dir">Paragraph direction for the given object.</param>
    public virtual void SetParagraphDirection(UIKit.TextBidirectionalType dir) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Disables all rendering on the canvas.
    /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
    /// 
    /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Enable &quot;no-render&quot; mode.</returns>
    public virtual bool GetNoRender() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_no_render_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Disables all rendering on the canvas.
    /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
    /// 
    /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="enable">Enable &quot;no-render&quot; mode.</param>
    public virtual void SetNoRender(bool enable) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_no_render_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether the coordinates are logically inside the object.
    /// A value of <c>true</c> indicates the position is logically inside the object, and <c>false</c> implies it is logically outside the object.
    /// 
    /// If <c>obj</c> is not a valid object, the return value is undefined.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pos">The coordinates in pixels.</param>
    /// <returns><c>true</c> if the coordinates are inside the object, <c>false</c> otherwise</returns>
    public virtual bool GetCoordsInside(UIKit.DataTypes.Position2D pos) {
        UIKit.DataTypes.Position2D.NativeStruct _in_pos = pos;
var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_coords_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Returns the number of objects clipped by <c>obj</c></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of objects clipped by <c>obj</c></returns>
    public virtual uint ClippedObjectsCount() {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Requests <c>keyname</c> key events be directed to <c>obj</c>.
    /// Key grabs allow one or more objects to receive key events for specific key strokes even if other objects have focus. Whenever a key is grabbed, only the objects grabbing it will get the events for the given keys.
    /// 
    /// <c>keyname</c> is a platform dependent symbolic name for the key pressed.
    /// 
    /// <c>modifiers</c> and <c>not_modifiers</c> are bit masks of all the modifiers that must and mustn&apos;t, respectively, be pressed along with <c>keyname</c> key in order to trigger this new key grab. Modifiers can be things such as Shift and Ctrl as well as user defined types via ref evas_key_modifier_add. <c>exclusive</c> will make the given object the only one permitted to grab the given key. If given <c>true</c>, subsequent calls on this function with different <c>obj</c> arguments will fail, unless the key is ungrabbed again.
    /// 
    /// Warning: Providing impossible modifier sets creates undefined behavior.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="keyname">The key to request events for.</param>
    /// <param name="modifiers">A combination of modifier keys that must be present to trigger the event.</param>
    /// <param name="not_modifiers">A combination of modifier keys that must not be present to trigger the event.</param>
    /// <param name="exclusive">Request that the <c>obj</c> is the only object receiving the <c>keyname</c> events.</param>
    /// <returns><c>true</c> if the call succeeded, <c>false</c> otherwise.</returns>
    public virtual bool GrabKey(System.String keyname, UIKit.Input.Modifier modifiers, UIKit.Input.Modifier not_modifiers, bool exclusive) {
        var _ret_var = UIKit.Canvas.Object.NativeMethods.efl_canvas_object_key_grab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),keyname, modifiers, not_modifiers, exclusive);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes the grab on <c>keyname</c> key events by <c>obj</c>.
    /// Removes a key grab on <c>obj</c> if <c>keyname</c>, <c>modifiers</c>, and <c>not_modifiers</c> match.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.GrabKey"/>, <see cref="UIKit.Canvas.Object.GetKeyFocus"/>, <see cref="UIKit.Canvas.Object.SetKeyFocus"/>, and the legacy API evas_focus_get.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="keyname">The key the grab is set for.</param>
    /// <param name="modifiers">A mask of modifiers that must be present to trigger the event.</param>
    /// <param name="not_modifiers">A mask of modifiers that must not not be present to trigger the event.</param>
    public virtual void UngrabKey(System.String keyname, UIKit.Input.Modifier modifiers, UIKit.Input.Modifier not_modifiers) {
        UIKit.Canvas.Object.NativeMethods.efl_canvas_object_key_ungrab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),keyname, modifiers, not_modifiers);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void GetColor(out int r, out int g, out int b, out int a) {
        UIKit.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void SetColor(int r, int g, int b, int a) {
        UIKit.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>the hex color code.</returns>
    public virtual System.String GetColorCode() {
        var _ret_var = UIKit.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="colorcode">the hex color code.</param>
    public virtual void SetColorCode(System.String colorcode) {
        UIKit.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),colorcode);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves the position of the given canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D coordinate in pixel units.</returns>
    public virtual UIKit.DataTypes.Position2D GetPosition() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    public virtual void SetPosition(UIKit.DataTypes.Position2D pos) {
        UIKit.DataTypes.Position2D.NativeStruct _in_pos = pos;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>A 2D size in pixel units.</returns>
    public virtual UIKit.DataTypes.Size2D GetSize() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="UIKit.Gfx.IHint"/> instead, when manipulating widgets.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="size">A 2D size in pixel units.</param>
    public virtual void SetSize(UIKit.DataTypes.Size2D size) {
        UIKit.DataTypes.Size2D.NativeStruct _in_size = size;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    public virtual UIKit.DataTypes.Rect GetGeometry() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    public virtual void SetGeometry(UIKit.DataTypes.Rect rect) {
        UIKit.DataTypes.Rect.NativeStruct _in_rect = rect;
UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    public virtual bool GetVisible() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Shows or hides this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    public virtual void SetVisible(bool v) {
        UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an object&apos;s scaling factor.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The scaling factor.</returns>
    public virtual double GetScale() {
        var _ret_var = UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Sets the scaling factor of an object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
    public virtual void SetScale(double scale) {
        UIKit.Gfx.EntityConcrete.NativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    public virtual void GetHintAspect(out UIKit.Gfx.HintAspect mode, out UIKit.DataTypes.Size2D sz) {
        var _out_sz = new UIKit.DataTypes.Size2D.NativeStruct();
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_aspect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out mode, out _out_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
sz = _out_sz;
        
    }

    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="mode">Mode of interpretation.</param>
    /// <param name="sz">Base size to use for aspecting.</param>
    public virtual void SetHintAspect(UIKit.Gfx.HintAspect mode, UIKit.DataTypes.Size2D sz) {
        UIKit.DataTypes.Size2D.NativeStruct _in_sz = sz;
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_aspect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode, _in_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
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
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeMax() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
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
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
    public virtual void SetHintSizeMax(UIKit.DataTypes.Size2D sz) {
        UIKit.DataTypes.Size2D.NativeStruct _in_sz = sz;
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Internal hints for an object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="UIKit.Gfx.IHint.HintSizeMax"/> instead.
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Maximum size (hint) in pixels.</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeRestrictedMax() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sz">Maximum size (hint) in pixels.</param>
    protected virtual void SetHintSizeRestrictedMax(UIKit.DataTypes.Size2D sz) {
        UIKit.DataTypes.Size2D.NativeStruct _in_sz = sz;
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Read-only maximum size combining both <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="UIKit.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="UIKit.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="UIKit.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Maximum size (hint) in pixels.</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeCombinedMax() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeMin() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    public virtual void SetHintSizeMin(UIKit.DataTypes.Size2D sz) {
        UIKit.DataTypes.Size2D.NativeStruct _in_sz = sz;
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeRestrictedMin() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sz">Minimum size (hint) in pixels.</param>
    protected virtual void SetHintSizeRestrictedMin(UIKit.DataTypes.Size2D sz) {
        UIKit.DataTypes.Size2D.NativeStruct _in_sz = sz;
UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Read-only minimum size combining both <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="UIKit.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="UIKit.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="UIKit.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Minimum size (hint) in pixels.</returns>
    public virtual UIKit.DataTypes.Size2D GetHintSizeCombinedMin() {
        var _ret_var = UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    public virtual void GetHintMargin(out int l, out int r, out int t, out int b) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_margin_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="l">Integer to specify left padding.</param>
    /// <param name="r">Integer to specify right padding.</param>
    /// <param name="t">Integer to specify top padding.</param>
    /// <param name="b">Integer to specify bottom padding.</param>
    public virtual void SetHintMargin(int l, int r, int t, int b) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_margin_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),l, r, t, b);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="UIKit.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    public virtual void GetHintWeight(out double x, out double y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s weight.
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="UIKit.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
    /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
    public virtual void SetHintWeight(double x, double y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
    public virtual void GetHintAlign(out double x, out double y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s alignment.
    /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
    /// 
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</param>
    /// <param name="y">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end.</param>
    public virtual void SetHintAlign(double x, double y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="UIKit.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="UIKit.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="UIKit.Ui.Box"/> &quot;box&quot; and <see cref="UIKit.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    public virtual void GetHintFill(out bool x, out bool y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="UIKit.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="UIKit.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="UIKit.Ui.Box"/> &quot;box&quot; and <see cref="UIKit.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
    /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
    public virtual void SetHintFill(bool x, bool y) {
        UIKit.Gfx.HintConcrete.NativeMethods.efl_gfx_hint_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of points of map</returns>
    public virtual int GetMappingPointCount() {
        var _ret_var = UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_point_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="count">The number of points of map</param>
    public virtual void SetMappingPointCount(int count) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_point_count_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),count);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Clockwise state of a map (read-only).
    /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
    public virtual bool GetMappingClockwise() {
        var _ret_var = UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_clockwise_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> by default.</returns>
    public virtual bool GetMappingSmooth() {
        var _ret_var = UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_smooth_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="smooth"><c>true</c> by default.</param>
    public virtual void SetMappingSmooth(bool smooth) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_smooth_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),smooth);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">UIKit.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="UIKit.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> by default.</returns>
    public virtual bool GetMappingAlpha() {
        var _ret_var = UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">UIKit.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="UIKit.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="alpha"><c>true</c> by default.</param>
    public virtual void SetMappingAlpha(bool alpha) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),alpha);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    public virtual void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out x, out y, out z);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    public virtual void SetMappingCoordAbsolute(int idx, double x, double y, double z) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, x, y, z);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    public virtual void GetMappingUv(int idx, out double u, out double v) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_uv_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out u, out v);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    public virtual void SetMappingUv(int idx, double u, double v) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_uv_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, u, v);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    public virtual void GetMappingColor(int idx, out int r, out int g, out int b, out int a) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, out r, out g, out b, out a);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    public virtual void SetMappingColor(int idx, int r, int g, int b, int a) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx, r, g, b, a);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Read-only property indicating whether an object is mapped.
    /// This will be <c>true</c> if any transformation is applied to this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is mapped.</returns>
    public virtual bool HasMapping() {
        var _ret_var = UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_has_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Resets the map transformation to its default state.
    /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="UIKit.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="UIKit.Gfx.IMapping.MappingSmooth"/> or <see cref="UIKit.Gfx.IMapping.MappingAlpha"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void ResetMapping() {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a translation to the object using map.
    /// This does not change the real geometry of the object but will affect its visible position.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dx">Distance in pixels along the X axis.</param>
    /// <param name="dy">Distance in pixels along the Y axis.</param>
    /// <param name="dz">Distance in pixels along the Z axis.</param>
    public virtual void Translate(double dx, double dy, double dz) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_translate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a rotation to the object.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    public virtual void Rotate(double degrees, UIKit.Gfx.IEntity pivot, double cx, double cy) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),degrees, pivot, cx, cy);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rotate the object around 3 axes in 3D.
    /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="UIKit.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// As with <see cref="UIKit.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public virtual void Rotate3d(double dx, double dy, double dz, UIKit.Gfx.IEntity pivot, double cx, double cy, double cz) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz, pivot, cx, cy, cz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rotate the object in 3D using a unit quaternion.
    /// This is similar to <see cref="UIKit.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// As with <see cref="UIKit.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public virtual void RotateQuat(double qx, double qy, double qz, double qw, UIKit.Gfx.IEntity pivot, double cx, double cy, double cz) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),qx, qy, qz, qw, pivot, cx, cy, cz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a zoom to the object.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    public virtual void Zoom(double zoomx, double zoomy, UIKit.Gfx.IEntity pivot, double cx, double cy) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_zoom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),zoomx, zoomy, pivot, cx, cy);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a lighting effect on the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    public virtual void Lighting3d(UIKit.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    public virtual void Perspective3d(UIKit.Gfx.IEntity pivot, double px, double py, double z0, double foc) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),pivot, px, py, z0, foc);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a rotation to the object, using absolute coordinates.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The given coordinates are absolute values in pixels. See also <see cref="UIKit.Gfx.IMapping.Rotate"/> for a relative coordinate version.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    public virtual void RotateAbsolute(double degrees, double cx, double cy) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),degrees, cx, cy);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
    /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="UIKit.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="UIKit.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public virtual void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dx, dy, dz, cx, cy, cz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
    /// This is similar to <see cref="UIKit.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="UIKit.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public virtual void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),qx, qy, qz, qw, cx, cy, cz);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a zoom to the object, using absolute coordinates.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="UIKit.Gfx.IMapping.Zoom"/> for a pivot-based zoom.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    public virtual void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),zoomx, zoomy, cx, cy);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a lighting effect to the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="UIKit.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="lx">X absolute coordinate in pixels of the light point.</param>
    /// <param name="ly">y absolute coordinate in pixels of the light point.</param>
    /// <param name="lz">Z absolute coordinate in space of light point.</param>
    /// <param name="lr">Light red value (0 - 255).</param>
    /// <param name="lg">Light green value (0 - 255).</param>
    /// <param name="lb">Light blue value (0 - 255).</param>
    /// <param name="ar">Ambient color red value (0 - 255).</param>
    /// <param name="ag">Ambient color green value (0 - 255).</param>
    /// <param name="ab">Ambient color blue value (0 - 255).</param>
    public virtual void Lighting3dAbsolute(double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),lx, ly, lz, lr, lg, lb, ar, ag, ab);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="UIKit.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    public virtual void Perspective3dAbsolute(double px, double py, double z0, double foc) {
        UIKit.Gfx.MappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),px, py, z0, foc);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of the layer to place the object on. Must be between <see cref="UIKit.Gfx.Constants.StackLayerMin"/> and <see cref="UIKit.Gfx.Constants.StackLayerMax"/>.</returns>
    public virtual short GetLayer() {
        var _ret_var = UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_layer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="l">The number of the layer to place the object on. Must be between <see cref="UIKit.Gfx.Constants.StackLayerMin"/> and <see cref="UIKit.Gfx.Constants.StackLayerMax"/>.</param>
    public virtual void SetLayer(short l) {
        UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_layer_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),l);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The Evas object stacked right below this object.
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.Layer"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The <see cref="UIKit.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public virtual UIKit.Gfx.IStack GetBelow() {
        var _ret_var = UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_below_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Get the Evas object stacked right above this object.
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.Layer"/> and <see cref="UIKit.Gfx.IStack.GetBelow"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The <see cref="UIKit.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
    public virtual UIKit.Gfx.IStack GetAbove() {
        var _ret_var = UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_above_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
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
    /// See also <see cref="UIKit.Gfx.IStack.GetLayer"/>, <see cref="UIKit.Gfx.IStack.SetLayer"/> and <see cref="UIKit.Gfx.IStack.StackBelow"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="below">The object below which to stack</param>
    public virtual void StackBelow(UIKit.Gfx.IStack below) {
        UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_below_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),below);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Raise <c>obj</c> to the top of its layer.
    /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.StackAbove"/>, <see cref="UIKit.Gfx.IStack.StackBelow"/> and <see cref="UIKit.Gfx.IStack.LowerToBottom"/></summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void RaiseToTop() {
        UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_raise_to_top_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
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
    /// See also <see cref="UIKit.Gfx.IStack.GetLayer"/>, <see cref="UIKit.Gfx.IStack.SetLayer"/> and <see cref="UIKit.Gfx.IStack.StackBelow"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="above">The object above which to stack</param>
    public virtual void StackAbove(UIKit.Gfx.IStack above) {
        UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_above_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),above);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Lower <c>obj</c> to the bottom of its layer.
    /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.StackAbove"/>, <see cref="UIKit.Gfx.IStack.StackBelow"/> and <see cref="UIKit.Gfx.IStack.RaiseToTop"/></summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void LowerToBottom() {
        UIKit.Gfx.StackConcrete.NativeMethods.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Render mode to be used for compositing the Evas object.
    /// Only two modes are supported: - <see cref="UIKit.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="UIKit.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
    /// 
    /// Please do not assume that <see cref="UIKit.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Blend or copy.</value>
    public UIKit.Gfx.RenderOp RenderOp {
        get { return GetRenderOp(); }
        set { SetRenderOp(value); }
    }

    /// <summary>Clip one object to another.
    /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
    /// 
    /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
    /// 
    /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
    /// 
    /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
    /// 
    /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="UIKit.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
    /// 
    /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
    /// 
    /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
    /// 
    /// Note: Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The object to clip <c>obj</c> by.</value>
    public UIKit.Canvas.Object Clipper {
        get { return GetClipper(); }
        set { SetClipper(value); }
    }

    /// <summary>Whether an Evas object is to repeat events to objects below it.
    /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</value>
    public bool RepeatEvents {
        get { return GetRepeatEvents(); }
        set { SetRepeatEvents(value); }
    }

    /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
    /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">UIKit.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">UIKit.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> when set as focused or <c>false</c> otherwise.</value>
    public bool KeyFocus {
        get { return GetKeyFocus(); }
        set { SetKeyFocus(value); }
    }

    /// <summary>Check if this object is focused.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</value>
    public bool SeatFocus {
        get { return GetSeatFocus(); }
    }

    /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
    /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
    /// 
    /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Whether to use precise point collision detection.</value>
    public bool PreciseIsInside {
        get { return GetPreciseIsInside(); }
        set { SetPreciseIsInside(value); }
    }

    /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
    /// This function has no effect if <c>obj</c> is not a member of a smart object.
    /// 
    /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPassEvents"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Whether to propagate events.</value>
    public bool PropagateEvents {
        get { return GetPropagateEvents(); }
        set { SetPropagateEvents(value); }
    }

    /// <summary>Whether an Evas object is to pass (ignore) events.
    /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="UIKit.Gfx.IStack.GetBelow"/>).
    /// 
    /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.SetRepeatEvents"/>, <see cref="UIKit.Canvas.Object.SetPropagateEvents"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</value>
    public bool PassEvents {
        get { return GetPassEvents(); }
        set { SetPassEvents(value); }
    }

    /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</value>
    public bool AntiAlias {
        get { return GetAntiAlias(); }
        set { SetAntiAlias(value); }
    }

    /// <summary>List of objects currently clipped by <c>obj</c>.
    /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
    /// 
    /// See also <see cref="UIKit.Canvas.Object.Clipper"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>An iterator over the list of objects clipped by <c>obj</c>.</value>
    public UIKit.DataTypes.Iterator<UIKit.Canvas.Object> ClippedObjects {
        get { return GetClippedObjects(); }
    }

    /// <summary>Gets the parent smart object of a given Evas object, if it has one.
    /// This can be different from <see cref="UIKit.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The parent smart object of <c>obj</c> or <c>null</c>.</value>
    protected UIKit.Canvas.Object RenderParent {
        get { return GetRenderParent(); }
    }

    /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Paragraph direction for the given object.</value>
    public UIKit.TextBidirectionalType ParagraphDirection {
        get { return GetParagraphDirection(); }
        set { SetParagraphDirection(value); }
    }

    /// <summary>Disables all rendering on the canvas.
    /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
    /// 
    /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Enable &quot;no-render&quot; mode.</value>
    public bool NoRender {
        get { return GetNoRender(); }
        set { SetNoRender(value); }
    }

    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
    /// <since_tizen> 6 </since_tizen>
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

    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
    }

    /// <summary>The 2D position of a canvas object.
    /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D coordinate in pixel units.</value>
    public UIKit.DataTypes.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }

    /// <summary>The 2D size of a canvas object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>A 2D size in pixel units.</value>
    public UIKit.DataTypes.Size2D Size {
        get { return GetSize(); }
        set { SetSize(value); }
    }

    /// <summary>Rectangular geometry that combines both position and size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The X,Y position and W,H size, in pixels.</value>
    public UIKit.DataTypes.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry(value); }
    }

    /// <summary>The visibility of a canvas object.
    /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="UIKit.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
    /// 
    /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible(value); }
    }

    /// <summary>The scaling factor of an object.
    /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
    /// 
    /// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The scaling factor.</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale(value); }
    }

    /// <summary>Defines the aspect ratio to respect when scaling this object.
    /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
    /// 
    /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Mode of interpretation.</value>
    public (UIKit.Gfx.HintAspect, UIKit.DataTypes.Size2D) HintAspect {
        get {
            UIKit.Gfx.HintAspect _out_mode = default(UIKit.Gfx.HintAspect);
            UIKit.DataTypes.Size2D _out_sz = default(UIKit.DataTypes.Size2D);
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
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
    public UIKit.DataTypes.Size2D HintSizeMax {
        get { return GetHintSizeMax(); }
        set { SetHintSizeMax(value); }
    }

    /// <summary>Internal hints for an object&apos;s maximum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values -1 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="UIKit.Gfx.IHint.HintSizeMax"/> instead.
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Maximum size (hint) in pixels.</value>
    public UIKit.DataTypes.Size2D HintSizeRestrictedMax {
        get { return GetHintSizeRestrictedMax(); }
        protected set { SetHintSizeRestrictedMax(value); }
    }

    /// <summary>Read-only maximum size combining both <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="UIKit.Gfx.IHint.HintSizeMax"/> hints.
    /// <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="UIKit.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="UIKit.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Maximum size (hint) in pixels.</value>
    public UIKit.DataTypes.Size2D HintSizeCombinedMax {
        get { return GetHintSizeCombinedMax(); }
    }

    /// <summary>Hints on the object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Value 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Minimum size (hint) in pixels.</value>
    public UIKit.DataTypes.Size2D HintSizeMin {
        get { return GetHintSizeMin(); }
        set { SetHintSizeMin(value); }
    }

    /// <summary>Internal hints for an object&apos;s minimum size.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Values 0 will be treated as unset hint components, when queried by managers.
    /// 
    /// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="UIKit.Gfx.IHint.HintSizeMin"/> instead.
    /// 
    /// Note: It is an error for the <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Minimum size (hint) in pixels.</value>
    public UIKit.DataTypes.Size2D HintSizeRestrictedMin {
        get { return GetHintSizeRestrictedMin(); }
        protected set { SetHintSizeRestrictedMin(value); }
    }

    /// <summary>Read-only minimum size combining both <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="UIKit.Gfx.IHint.HintSizeMin"/> hints.
    /// <see cref="UIKit.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="UIKit.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="UIKit.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Minimum size (hint) in pixels.</value>
    public UIKit.DataTypes.Size2D HintSizeCombinedMin {
        get { return GetHintSizeCombinedMin(); }
    }

    /// <summary>Hints for an object&apos;s margin or padding space.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// The object container is in charge of fetching this property and placing the object accordingly.
    /// 
    /// Note: Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="UIKit.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
    /// 
    /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
    /// 
    /// Note: Default weight hint values are 0.0, for both axis.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// For the horizontal component, 0.0 means the start of the axis in the direction that the current language reads, 1.0 means the end of the axis.
    /// 
    /// For the vertical component, 0.0 to the top, 1.0 means to the bottom.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default alignment hint values are 0.5, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end.</value>
    public (double, double) HintAlign {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetHintAlign(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetHintAlign( value.Item1,  value.Item2); }
    }

    /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="UIKit.Gfx.IHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
    /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="UIKit.Gfx.IHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
    /// 
    /// See documentation of possible users: in Evas, they are the <see cref="UIKit.Ui.Box"/> &quot;box&quot; and <see cref="UIKit.Ui.Table"/> &quot;table&quot; smart objects.
    /// 
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Note: Default fill hint values are true, for both axes.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The number of points of map</value>
    public int MappingPointCount {
        get { return GetMappingPointCount(); }
        set { SetMappingPointCount(value); }
    }

    /// <summary>Clockwise state of a map (read-only).
    /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
    public bool MappingClockwise {
        get { return GetMappingClockwise(); }
    }

    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> by default.</value>
    public bool MappingSmooth {
        get { return GetMappingSmooth(); }
        set { SetMappingSmooth(value); }
    }

    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">UIKit.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="UIKit.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> by default.</value>
    public bool MappingAlpha {
        get { return GetMappingAlpha(); }
        set { SetMappingAlpha(value); }
    }

    /// <summary>The layer of its canvas that the given object will be part of.
    /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
    /// 
    /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
    /// 
    /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The number of the layer to place the object on. Must be between <see cref="UIKit.Gfx.Constants.StackLayerMin"/> and <see cref="UIKit.Gfx.Constants.StackLayerMax"/>.</value>
    public short Layer {
        get { return GetLayer(); }
        set { SetLayer(value); }
    }

    /// <summary>The Evas object stacked right below this object.
    /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.Layer"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The <see cref="UIKit.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public UIKit.Gfx.IStack Below {
        get { return GetBelow(); }
    }

    /// <summary>Get the Evas object stacked right above this object.
    /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
    /// 
    /// See also <see cref="UIKit.Gfx.IStack.Layer"/> and <see cref="UIKit.Gfx.IStack.GetBelow"/></summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The <see cref="UIKit.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
    public UIKit.Gfx.IStack Above {
        get { return GetAbove(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Canvas.Object.efl_canvas_object_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.LoopConsumer.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_canvas_object_render_op_get_static_delegate == null)
            {
                efl_canvas_object_render_op_get_static_delegate = new efl_canvas_object_render_op_get_delegate(render_op_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRenderOp") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_get_static_delegate) });
            }

            if (efl_canvas_object_render_op_set_static_delegate == null)
            {
                efl_canvas_object_render_op_set_static_delegate = new efl_canvas_object_render_op_set_delegate(render_op_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRenderOp") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_set_static_delegate) });
            }

            if (efl_canvas_object_clipper_get_static_delegate == null)
            {
                efl_canvas_object_clipper_get_static_delegate = new efl_canvas_object_clipper_get_delegate(clipper_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClipper") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_get_static_delegate) });
            }

            if (efl_canvas_object_clipper_set_static_delegate == null)
            {
                efl_canvas_object_clipper_set_static_delegate = new efl_canvas_object_clipper_set_delegate(clipper_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetClipper") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_set_static_delegate) });
            }

            if (efl_canvas_object_repeat_events_get_static_delegate == null)
            {
                efl_canvas_object_repeat_events_get_static_delegate = new efl_canvas_object_repeat_events_get_delegate(repeat_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRepeatEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_get_static_delegate) });
            }

            if (efl_canvas_object_repeat_events_set_static_delegate == null)
            {
                efl_canvas_object_repeat_events_set_static_delegate = new efl_canvas_object_repeat_events_set_delegate(repeat_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRepeatEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_set_static_delegate) });
            }

            if (efl_canvas_object_key_focus_get_static_delegate == null)
            {
                efl_canvas_object_key_focus_get_static_delegate = new efl_canvas_object_key_focus_get_delegate(key_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeyFocus") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_get_static_delegate) });
            }

            if (efl_canvas_object_key_focus_set_static_delegate == null)
            {
                efl_canvas_object_key_focus_set_static_delegate = new efl_canvas_object_key_focus_set_delegate(key_focus_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeyFocus") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_set_static_delegate) });
            }

            if (efl_canvas_object_seat_focus_get_static_delegate == null)
            {
                efl_canvas_object_seat_focus_get_static_delegate = new efl_canvas_object_seat_focus_get_delegate(seat_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeatFocus") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_get_static_delegate) });
            }

            if (efl_canvas_object_precise_is_inside_get_static_delegate == null)
            {
                efl_canvas_object_precise_is_inside_get_static_delegate = new efl_canvas_object_precise_is_inside_get_delegate(precise_is_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPreciseIsInside") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_get_static_delegate) });
            }

            if (efl_canvas_object_precise_is_inside_set_static_delegate == null)
            {
                efl_canvas_object_precise_is_inside_set_static_delegate = new efl_canvas_object_precise_is_inside_set_delegate(precise_is_inside_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPreciseIsInside") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_set_static_delegate) });
            }

            if (efl_canvas_object_propagate_events_get_static_delegate == null)
            {
                efl_canvas_object_propagate_events_get_static_delegate = new efl_canvas_object_propagate_events_get_delegate(propagate_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPropagateEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_get_static_delegate) });
            }

            if (efl_canvas_object_propagate_events_set_static_delegate == null)
            {
                efl_canvas_object_propagate_events_set_static_delegate = new efl_canvas_object_propagate_events_set_delegate(propagate_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPropagateEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_set_static_delegate) });
            }

            if (efl_canvas_object_pass_events_get_static_delegate == null)
            {
                efl_canvas_object_pass_events_get_static_delegate = new efl_canvas_object_pass_events_get_delegate(pass_events_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPassEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_get_static_delegate) });
            }

            if (efl_canvas_object_pass_events_set_static_delegate == null)
            {
                efl_canvas_object_pass_events_set_static_delegate = new efl_canvas_object_pass_events_set_delegate(pass_events_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPassEvents") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_set_static_delegate) });
            }

            if (efl_canvas_object_anti_alias_get_static_delegate == null)
            {
                efl_canvas_object_anti_alias_get_static_delegate = new efl_canvas_object_anti_alias_get_delegate(anti_alias_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAntiAlias") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_get_static_delegate) });
            }

            if (efl_canvas_object_anti_alias_set_static_delegate == null)
            {
                efl_canvas_object_anti_alias_set_static_delegate = new efl_canvas_object_anti_alias_set_delegate(anti_alias_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAntiAlias") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_set_static_delegate) });
            }

            if (efl_canvas_object_clipped_objects_get_static_delegate == null)
            {
                efl_canvas_object_clipped_objects_get_static_delegate = new efl_canvas_object_clipped_objects_get_delegate(clipped_objects_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetClippedObjects") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_get_static_delegate) });
            }

            if (efl_canvas_object_render_parent_get_static_delegate == null)
            {
                efl_canvas_object_render_parent_get_static_delegate = new efl_canvas_object_render_parent_get_delegate(render_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRenderParent") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_parent_get_static_delegate) });
            }

            if (efl_canvas_object_paragraph_direction_get_static_delegate == null)
            {
                efl_canvas_object_paragraph_direction_get_static_delegate = new efl_canvas_object_paragraph_direction_get_delegate(paragraph_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetParagraphDirection") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_get_static_delegate) });
            }

            if (efl_canvas_object_paragraph_direction_set_static_delegate == null)
            {
                efl_canvas_object_paragraph_direction_set_static_delegate = new efl_canvas_object_paragraph_direction_set_delegate(paragraph_direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetParagraphDirection") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_set_static_delegate) });
            }

            if (efl_canvas_object_no_render_get_static_delegate == null)
            {
                efl_canvas_object_no_render_get_static_delegate = new efl_canvas_object_no_render_get_delegate(no_render_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNoRender") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_get_static_delegate) });
            }

            if (efl_canvas_object_no_render_set_static_delegate == null)
            {
                efl_canvas_object_no_render_set_static_delegate = new efl_canvas_object_no_render_set_delegate(no_render_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNoRender") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_set_static_delegate) });
            }

            if (efl_canvas_object_coords_inside_get_static_delegate == null)
            {
                efl_canvas_object_coords_inside_get_static_delegate = new efl_canvas_object_coords_inside_get_delegate(coords_inside_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCoordsInside") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_coords_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_coords_inside_get_static_delegate) });
            }

            if (efl_canvas_object_clipped_objects_count_static_delegate == null)
            {
                efl_canvas_object_clipped_objects_count_static_delegate = new efl_canvas_object_clipped_objects_count_delegate(clipped_objects_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClippedObjectsCount") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_count"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_count_static_delegate) });
            }

            if (efl_canvas_object_key_grab_static_delegate == null)
            {
                efl_canvas_object_key_grab_static_delegate = new efl_canvas_object_key_grab_delegate(key_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabKey") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_grab_static_delegate) });
            }

            if (efl_canvas_object_key_ungrab_static_delegate == null)
            {
                efl_canvas_object_key_ungrab_static_delegate = new efl_canvas_object_key_ungrab_delegate(key_ungrab);
            }

            if (methods.FirstOrDefault(m => m.Name == "UngrabKey") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_ungrab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_ungrab_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_max_set_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_max_set_static_delegate = new efl_gfx_hint_size_restricted_max_set_delegate(hint_size_restricted_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeRestrictedMax") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_set_static_delegate) });
            }

            if (efl_gfx_hint_size_restricted_min_set_static_delegate == null)
            {
                efl_gfx_hint_size_restricted_min_set_static_delegate = new efl_gfx_hint_size_restricted_min_set_delegate(hint_size_restricted_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintSizeRestrictedMin") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_set_static_delegate) });
            }

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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.Canvas.Object.efl_canvas_object_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate UIKit.Gfx.RenderOp efl_canvas_object_render_op_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.Gfx.RenderOp efl_canvas_object_render_op_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate> efl_canvas_object_render_op_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate>(Module, "efl_canvas_object_render_op_get");

        private static UIKit.Gfx.RenderOp render_op_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_render_op_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Gfx.RenderOp _ret_var = default(UIKit.Gfx.RenderOp);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRenderOp();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_render_op_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_render_op_get_delegate efl_canvas_object_render_op_get_static_delegate;

        
        private delegate void efl_canvas_object_render_op_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.Gfx.RenderOp render_op);

        
        public delegate void efl_canvas_object_render_op_set_api_delegate(System.IntPtr obj,  UIKit.Gfx.RenderOp render_op);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate> efl_canvas_object_render_op_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate>(Module, "efl_canvas_object_render_op_set");

        private static void render_op_set(System.IntPtr obj, System.IntPtr pd, UIKit.Gfx.RenderOp render_op)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_render_op_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetRenderOp(render_op);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_render_op_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), render_op);
            }
        }

        private static efl_canvas_object_render_op_set_delegate efl_canvas_object_render_op_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Canvas.Object efl_canvas_object_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Canvas.Object efl_canvas_object_clipper_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate> efl_canvas_object_clipper_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate>(Module, "efl_canvas_object_clipper_get");

        private static UIKit.Canvas.Object clipper_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_clipper_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Canvas.Object _ret_var = default(UIKit.Canvas.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).GetClipper();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_clipper_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipper_get_delegate efl_canvas_object_clipper_get_static_delegate;

        
        private delegate void efl_canvas_object_clipper_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object clipper);

        
        public delegate void efl_canvas_object_clipper_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Canvas.Object clipper);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate> efl_canvas_object_clipper_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate>(Module, "efl_canvas_object_clipper_set");

        private static void clipper_set(System.IntPtr obj, System.IntPtr pd, UIKit.Canvas.Object clipper)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_clipper_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetClipper(clipper);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_clipper_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), clipper);
            }
        }

        private static efl_canvas_object_clipper_set_delegate efl_canvas_object_clipper_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_repeat_events_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate> efl_canvas_object_repeat_events_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate>(Module, "efl_canvas_object_repeat_events_get");

        private static bool repeat_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_repeat_events_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRepeatEvents();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_repeat_events_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_repeat_events_get_delegate efl_canvas_object_repeat_events_get_static_delegate;

        
        private delegate void efl_canvas_object_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool repeat);

        
        public delegate void efl_canvas_object_repeat_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool repeat);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate> efl_canvas_object_repeat_events_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate>(Module, "efl_canvas_object_repeat_events_set");

        private static void repeat_events_set(System.IntPtr obj, System.IntPtr pd, bool repeat)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_repeat_events_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetRepeatEvents(repeat);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_repeat_events_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), repeat);
            }
        }

        private static efl_canvas_object_repeat_events_set_delegate efl_canvas_object_repeat_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_key_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_key_focus_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate> efl_canvas_object_key_focus_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate>(Module, "efl_canvas_object_key_focus_get");

        private static bool key_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_key_focus_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetKeyFocus();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_key_focus_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_key_focus_get_delegate efl_canvas_object_key_focus_get_static_delegate;

        
        private delegate void efl_canvas_object_key_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool focus);

        
        public delegate void efl_canvas_object_key_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool focus);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate> efl_canvas_object_key_focus_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate>(Module, "efl_canvas_object_key_focus_set");

        private static void key_focus_set(System.IntPtr obj, System.IntPtr pd, bool focus)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_key_focus_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetKeyFocus(focus);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_key_focus_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), focus);
            }
        }

        private static efl_canvas_object_key_focus_set_delegate efl_canvas_object_key_focus_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_seat_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_seat_focus_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate> efl_canvas_object_seat_focus_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate>(Module, "efl_canvas_object_seat_focus_get");

        private static bool seat_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_seat_focus_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetSeatFocus();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_seat_focus_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_seat_focus_get_delegate efl_canvas_object_seat_focus_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_precise_is_inside_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_precise_is_inside_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate> efl_canvas_object_precise_is_inside_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate>(Module, "efl_canvas_object_precise_is_inside_get");

        private static bool precise_is_inside_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_precise_is_inside_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPreciseIsInside();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_precise_is_inside_get_delegate efl_canvas_object_precise_is_inside_get_static_delegate;

        
        private delegate void efl_canvas_object_precise_is_inside_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool precise);

        
        public delegate void efl_canvas_object_precise_is_inside_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool precise);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate> efl_canvas_object_precise_is_inside_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate>(Module, "efl_canvas_object_precise_is_inside_set");

        private static void precise_is_inside_set(System.IntPtr obj, System.IntPtr pd, bool precise)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_precise_is_inside_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetPreciseIsInside(precise);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), precise);
            }
        }

        private static efl_canvas_object_precise_is_inside_set_delegate efl_canvas_object_precise_is_inside_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_propagate_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_propagate_events_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate> efl_canvas_object_propagate_events_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate>(Module, "efl_canvas_object_propagate_events_get");

        private static bool propagate_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_propagate_events_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPropagateEvents();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_propagate_events_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_propagate_events_get_delegate efl_canvas_object_propagate_events_get_static_delegate;

        
        private delegate void efl_canvas_object_propagate_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool propagate);

        
        public delegate void efl_canvas_object_propagate_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool propagate);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate> efl_canvas_object_propagate_events_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate>(Module, "efl_canvas_object_propagate_events_set");

        private static void propagate_events_set(System.IntPtr obj, System.IntPtr pd, bool propagate)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_propagate_events_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetPropagateEvents(propagate);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_propagate_events_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), propagate);
            }
        }

        private static efl_canvas_object_propagate_events_set_delegate efl_canvas_object_propagate_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_pass_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_pass_events_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate> efl_canvas_object_pass_events_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate>(Module, "efl_canvas_object_pass_events_get");

        private static bool pass_events_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_pass_events_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetPassEvents();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_pass_events_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_pass_events_get_delegate efl_canvas_object_pass_events_get_static_delegate;

        
        private delegate void efl_canvas_object_pass_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool pass);

        
        public delegate void efl_canvas_object_pass_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool pass);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate> efl_canvas_object_pass_events_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate>(Module, "efl_canvas_object_pass_events_set");

        private static void pass_events_set(System.IntPtr obj, System.IntPtr pd, bool pass)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_pass_events_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetPassEvents(pass);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_pass_events_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pass);
            }
        }

        private static efl_canvas_object_pass_events_set_delegate efl_canvas_object_pass_events_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_anti_alias_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_anti_alias_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate> efl_canvas_object_anti_alias_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate>(Module, "efl_canvas_object_anti_alias_get");

        private static bool anti_alias_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_anti_alias_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetAntiAlias();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_anti_alias_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_anti_alias_get_delegate efl_canvas_object_anti_alias_get_static_delegate;

        
        private delegate void efl_canvas_object_anti_alias_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

        
        public delegate void efl_canvas_object_anti_alias_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate> efl_canvas_object_anti_alias_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate>(Module, "efl_canvas_object_anti_alias_set");

        private static void anti_alias_set(System.IntPtr obj, System.IntPtr pd, bool anti_alias)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_anti_alias_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetAntiAlias(anti_alias);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_anti_alias_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), anti_alias);
            }
        }

        private static efl_canvas_object_anti_alias_set_delegate efl_canvas_object_anti_alias_set_static_delegate;

        
        private delegate System.IntPtr efl_canvas_object_clipped_objects_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_canvas_object_clipped_objects_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate> efl_canvas_object_clipped_objects_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate>(Module, "efl_canvas_object_clipped_objects_get");

        private static System.IntPtr clipped_objects_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_clipped_objects_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Iterator<UIKit.Canvas.Object> _ret_var = default(UIKit.DataTypes.Iterator<UIKit.Canvas.Object>);
                try
                {
                    _ret_var = ((Object)ws.Target).GetClippedObjects();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var.Handle;
            }
            else
            {
                return efl_canvas_object_clipped_objects_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipped_objects_get_delegate efl_canvas_object_clipped_objects_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Canvas.Object efl_canvas_object_render_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Canvas.Object efl_canvas_object_render_parent_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate> efl_canvas_object_render_parent_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate>(Module, "efl_canvas_object_render_parent_get");

        private static UIKit.Canvas.Object render_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_render_parent_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Canvas.Object _ret_var = default(UIKit.Canvas.Object);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRenderParent();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_render_parent_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_render_parent_get_delegate efl_canvas_object_render_parent_get_static_delegate;

        
        private delegate UIKit.TextBidirectionalType efl_canvas_object_paragraph_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.TextBidirectionalType efl_canvas_object_paragraph_direction_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate> efl_canvas_object_paragraph_direction_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate>(Module, "efl_canvas_object_paragraph_direction_get");

        private static UIKit.TextBidirectionalType paragraph_direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_paragraph_direction_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.TextBidirectionalType _ret_var = default(UIKit.TextBidirectionalType);
                try
                {
                    _ret_var = ((Object)ws.Target).GetParagraphDirection();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_paragraph_direction_get_delegate efl_canvas_object_paragraph_direction_get_static_delegate;

        
        private delegate void efl_canvas_object_paragraph_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.TextBidirectionalType dir);

        
        public delegate void efl_canvas_object_paragraph_direction_set_api_delegate(System.IntPtr obj,  UIKit.TextBidirectionalType dir);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate> efl_canvas_object_paragraph_direction_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate>(Module, "efl_canvas_object_paragraph_direction_set");

        private static void paragraph_direction_set(System.IntPtr obj, System.IntPtr pd, UIKit.TextBidirectionalType dir)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_paragraph_direction_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetParagraphDirection(dir);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_canvas_object_paragraph_direction_set_delegate efl_canvas_object_paragraph_direction_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_no_render_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_no_render_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate> efl_canvas_object_no_render_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate>(Module, "efl_canvas_object_no_render_get");

        private static bool no_render_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_no_render_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetNoRender();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_no_render_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_no_render_get_delegate efl_canvas_object_no_render_get_static_delegate;

        
        private delegate void efl_canvas_object_no_render_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_canvas_object_no_render_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate> efl_canvas_object_no_render_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate>(Module, "efl_canvas_object_no_render_set");

        private static void no_render_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_no_render_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetNoRender(enable);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_no_render_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_canvas_object_no_render_set_delegate efl_canvas_object_no_render_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_coords_inside_get_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Position2D.NativeStruct pos);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_coords_inside_get_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Position2D.NativeStruct pos);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate> efl_canvas_object_coords_inside_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate>(Module, "efl_canvas_object_coords_inside_get");

        private static bool coords_inside_get(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Position2D.NativeStruct pos)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_coords_inside_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _in_pos = pos;
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GetCoordsInside(_in_pos);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_coords_inside_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_canvas_object_coords_inside_get_delegate efl_canvas_object_coords_inside_get_static_delegate;

        
        private delegate uint efl_canvas_object_clipped_objects_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_canvas_object_clipped_objects_count_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate> efl_canvas_object_clipped_objects_count_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate>(Module, "efl_canvas_object_clipped_objects_count");

        private static uint clipped_objects_count(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_clipped_objects_count was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Object)ws.Target).ClippedObjectsCount();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_clipped_objects_count_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_object_clipped_objects_count_delegate efl_canvas_object_clipped_objects_count_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_key_grab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  UIKit.Input.Modifier modifiers,  UIKit.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_canvas_object_key_grab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  UIKit.Input.Modifier modifiers,  UIKit.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_grab_api_delegate> efl_canvas_object_key_grab_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_grab_api_delegate>(Module, "efl_canvas_object_key_grab");

        private static bool key_grab(System.IntPtr obj, System.IntPtr pd, System.String keyname, UIKit.Input.Modifier modifiers, UIKit.Input.Modifier not_modifiers, bool exclusive)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_key_grab was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Object)ws.Target).GrabKey(keyname, modifiers, not_modifiers, exclusive);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_canvas_object_key_grab_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), keyname, modifiers, not_modifiers, exclusive);
            }
        }

        private static efl_canvas_object_key_grab_delegate efl_canvas_object_key_grab_static_delegate;

        
        private delegate void efl_canvas_object_key_ungrab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  UIKit.Input.Modifier modifiers,  UIKit.Input.Modifier not_modifiers);

        
        public delegate void efl_canvas_object_key_ungrab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  UIKit.Input.Modifier modifiers,  UIKit.Input.Modifier not_modifiers);

        public static UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate> efl_canvas_object_key_ungrab_ptr = new UIKit.Wrapper.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate>(Module, "efl_canvas_object_key_ungrab");

        private static void key_ungrab(System.IntPtr obj, System.IntPtr pd, System.String keyname, UIKit.Input.Modifier modifiers, UIKit.Input.Modifier not_modifiers)
        {
            UIKit.DataTypes.Log.Debug("function efl_canvas_object_key_ungrab was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).UngrabKey(keyname, modifiers, not_modifiers);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_key_ungrab_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), keyname, modifiers, not_modifiers);
            }
        }

        private static efl_canvas_object_key_ungrab_delegate efl_canvas_object_key_ungrab_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_max_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Size2D.NativeStruct sz);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate> efl_gfx_hint_size_restricted_max_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_set");

        private static void hint_size_restricted_max_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Size2D.NativeStruct sz)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_max_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Size2D _in_sz = sz;

                try
                {
                    ((Object)ws.Target).SetHintSizeRestrictedMax(_in_sz);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_restricted_max_set_delegate efl_gfx_hint_size_restricted_max_set_static_delegate;

        
        private delegate void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Size2D.NativeStruct sz);

        public static UIKit.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_set");

        private static void hint_size_restricted_min_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Size2D.NativeStruct sz)
        {
            UIKit.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_min_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Size2D _in_sz = sz;

                try
                {
                    ((Object)ws.Target).SetHintSizeRestrictedMin(_in_sz);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_hint_size_restricted_min_set_delegate efl_gfx_hint_size_restricted_min_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKit_CanvasObject_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace UIKit {

/// <summary>EFL event animator tick data structure</summary>
/// <since_tizen> 6 </since_tizen>
[StructLayout(LayoutKind.Sequential)]
[UIKit.Wrapper.BindingEntity]
public struct EventAnimatorTick
{
    /// <summary>Area of the canvas that will be pushed to screen.</summary>
    /// <value>A rectangle in pixel dimensions.</value>
    public UIKit.DataTypes.Rect Update_area;
    /// <summary>Constructor for EventAnimatorTick.</summary>
    /// <param name="Update_area">Area of the canvas that will be pushed to screen.</param>
    public EventAnimatorTick(
        UIKit.DataTypes.Rect Update_area = default(UIKit.DataTypes.Rect)    )
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
        
        public UIKit.DataTypes.Rect.NativeStruct Update_area;
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

