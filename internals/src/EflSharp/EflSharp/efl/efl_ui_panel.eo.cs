#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary panel class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Panel.NativeMethods]
[Efl.Eo.BindingEntity]
public class Panel : Efl.Ui.LayoutBase, Efl.IContent, Efl.Ui.IScrollable, Efl.Ui.IScrollableInteractive, Efl.Ui.IWidgetFocusManager, Efl.Ui.Focus.ILayer, Efl.Ui.Focus.IManager
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Panel))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_panel_class_get();
    /// <summary>Initializes a new instance of the <see cref="Panel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Panel(Efl.Object parent
            , System.String style = null) : base(efl_ui_panel_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Panel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Panel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Panel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Panel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Panel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when the hidden state was toggled</summary>
    public event EventHandler ToggledEvent
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

                string key = "_EFL_UI_PANEL_EVENT_TOGGLED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PANEL_EVENT_TOGGLED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ToggledEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnToggledEvent(EventArgs e)
    {
        var key = "_EFL_UI_PANEL_EVENT_TOGGLED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContentContentChangedEventArgs"/></value>
    public event EventHandler<Efl.ContentContentChangedEventArgs> ContentChangedEvent
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
                        Efl.ContentContentChangedEventArgs args = new Efl.ContentContentChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentChangedEvent(Efl.ContentContentChangedEventArgs e)
    {
        var key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when scroll operation starts</summary>
    public event EventHandler ScrollStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollChangedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll operation finishes</summary>
    public event EventHandler ScrollFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollUpEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling downwards</summary>
    public event EventHandler ScrollDownEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDownEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling left</summary>
    public event EventHandler ScrollLeftEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollLeftEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollLeftEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling right</summary>
    public event EventHandler ScrollRightEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollRightEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollRightEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the top edge</summary>
    public event EventHandler EdgeUpEvent
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

                string key = "_EFL_UI_EVENT_EDGE_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeUpEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the bottom edge</summary>
    public event EventHandler EdgeDownEvent
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

                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeDownEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the left edge</summary>
    public event EventHandler EdgeLeftEvent
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

                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeLeftEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeLeftEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the right edge</summary>
    public event EventHandler EdgeRightEvent
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

                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeRightEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeRightEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation starts</summary>
    public event EventHandler ScrollAnimStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollAnimStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation finishes</summary>
    public event EventHandler ScrollAnimFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollAnimFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDragStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag finishes</summary>
    public event EventHandler ScrollDragFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDragFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Redirect object has changed, the old manager is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerRedirectChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEventArgs> RedirectChangedEvent
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
                        Efl.Ui.Focus.ManagerRedirectChangedEventArgs args = new Efl.Ui.Focus.ManagerRedirectChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ManagerConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RedirectChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRedirectChangedEvent(Efl.Ui.Focus.ManagerRedirectChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>After this event, the manager object will calculate relations in the graph. Can be used to add / remove children in a lazy fashion.
    /// (Since EFL 1.22)</summary>
    public event EventHandler FlushPreEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event FlushPreEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFlushPreEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Cached relationship calculation results have been invalidated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler CoordsDirtyEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event CoordsDirtyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCoordsDirtyEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The manager_focus property has changed. The previously focused object is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs> ManagerFocusChangedEvent
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
                        Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs args = new Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ObjectConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ManagerFocusChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnManagerFocusChangedEvent(Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when this focus manager is frozen or thawed, even_info being <c>true</c> indicates that it is now frozen, <c>false</c> indicates that it is thawed.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs> DirtyLogicFreezeChangedEvent
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
                        Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs args = new Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs();
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DirtyLogicFreezeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDirtyLogicFreezeChangedEvent(Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    /// <summary>The orientation of the panel
    /// Sets from where the panel will (dis)appear.</summary>
    /// <returns>The panel orientation.</returns>
    public virtual Efl.Ui.PanelOrient GetOrient() {
         var _ret_var = Efl.Ui.Panel.NativeMethods.efl_ui_panel_orient_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The orientation of the panel
    /// Sets from where the panel will (dis)appear.</summary>
    /// <param name="orient">The panel orientation.</param>
    public virtual void SetOrient(Efl.Ui.PanelOrient orient) {
                                 Efl.Ui.Panel.NativeMethods.efl_ui_panel_orient_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),orient);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The state of the panel.</summary>
    /// <returns>If <c>true</c>, the panel will run the animation to disappear.</returns>
    public virtual bool GetHidden() {
         var _ret_var = Efl.Ui.Panel.NativeMethods.efl_ui_panel_hidden_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The state of the panel.</summary>
    /// <param name="hidden">If <c>true</c>, the panel will run the animation to disappear.</param>
    public virtual void SetHidden(bool hidden) {
                                 Efl.Ui.Panel.NativeMethods.efl_ui_panel_hidden_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hidden);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scrollability of the panel.</summary>
    /// <returns>The scrollable state.</returns>
    public virtual bool GetScrollable() {
         var _ret_var = Efl.Ui.Panel.NativeMethods.efl_ui_panel_scrollable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The scrollability of the panel.</summary>
    /// <param name="scrollable">The scrollable state.</param>
    public virtual void SetScrollable(bool scrollable) {
                                 Efl.Ui.Panel.NativeMethods.efl_ui_panel_scrollable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scrollable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The size of the scrollable panel.</summary>
    /// <returns>Size ratio</returns>
    public virtual double GetScrollableContentSize() {
         var _ret_var = Efl.Ui.Panel.NativeMethods.efl_ui_panel_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The size of the scrollable panel.</summary>
    /// <param name="ratio">Size ratio</param>
    public virtual void SetScrollableContentSize(double ratio) {
                                 Efl.Ui.Panel.NativeMethods.efl_ui_panel_scrollable_content_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ratio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Toggle the hidden state of the panel from code</summary>
    public virtual void Toggle() {
         Efl.Ui.Panel.NativeMethods.efl_ui_panel_toggle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <returns>The sub-object.</returns>
    public virtual Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The sub-object.</param>
    /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
    public virtual bool SetContent(Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    public virtual Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.ContentConcrete.NativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    public virtual Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    public virtual void SetContentPos(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    public virtual Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    public virtual Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void GetBounceEnabled(out bool horiz, out bool vert) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out horiz, out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void SetBounceEnabled(bool horiz, bool vert) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),horiz, vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    public virtual bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    public virtual void SetScrollFreeze(bool freeze) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    public virtual bool GetScrollHold() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    public virtual void SetScrollHold(bool hold) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void GetLooping(out bool loop_h, out bool loop_v) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out loop_h, out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void SetLooping(bool loop_h, bool loop_v) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),loop_h, loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    public virtual Efl.Ui.LayoutOrientation GetMovementBlock() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    public virtual void SetMovementBlock(Efl.Ui.LayoutOrientation block) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),block);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows.
    /// 
    /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
    /// 
    /// Default values for x and y are 0.0</summary>
    /// <param name="x">Horizontal scrolling gravity</param>
    /// <param name="y">Vertical scrolling gravity</param>
    public virtual void GetGravity(out double x, out double y) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows.
    /// 
    /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
    /// 
    /// Default values for x and y are 0.0</summary>
    /// <param name="x">Horizontal scrolling gravity</param>
    /// <param name="y">Vertical scrolling gravity</param>
    public virtual void SetGravity(double x, double y) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    public virtual void SetMatchContent(bool w, bool h) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),w, h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    public virtual Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    public virtual void SetStepSize(Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    public virtual void Scroll(Eina.Rect rect, bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overridden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    protected virtual Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.WidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <returns><c>true</c> to set enable.</returns>
    protected virtual bool GetEnable() {
         var _ret_var = Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <param name="v"><c>true</c> to set enable.</param>
    protected virtual void SetEnable(bool v) {
                                 Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected virtual void GetBehaviour(out bool enable_on_visible, out bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out enable_on_visible, out cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected virtual void SetBehaviour(bool enable_on_visible, bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable_on_visible, cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    public virtual Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    public virtual void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new focus manager.</returns>
    public virtual Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The new focus manager.</param>
    public virtual void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>An iterator over the viewport border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Object to register as the root of this manager object.</returns>
    public virtual Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Object to register as the root of this manager object.</param>
    /// <returns><c>true</c> on success, <c>false</c> if it had already been set.</returns>
    public virtual bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Moves the focus in the given direction to the next regular widget.
    /// This call flushes all changes. This means all changes since last flush are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    public virtual Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a regular. Note that in a <see cref="Efl.Ui.Focus.IManager.Move"/> call logical nodes will not get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    public virtual Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Returns the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    public virtual Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Fetches the data from a registered node.
    /// Note: This function triggers a computation of all dirty nodes.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="child">The child object to inspect.</param>
    /// <returns>The list of relations starting from <c>child</c>.</returns>
    public virtual Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Returns the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move in the &quot;next&quot; direction.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    public virtual Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    public virtual void ResetHistory() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Removes the uppermost history element, and focuses the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    public virtual void PopHistoryStack() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as a result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    public virtual void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widgets in the set do not change and complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    public virtual void FreezeDirtyLogic() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    public virtual void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The orientation of the panel
    /// Sets from where the panel will (dis)appear.</summary>
    /// <value>The panel orientation.</value>
    public Efl.Ui.PanelOrient Orient {
        get { return GetOrient(); }
        set { SetOrient(value); }
    }
    /// <summary>The state of the panel.</summary>
    /// <value>If <c>true</c>, the panel will run the animation to disappear.</value>
    public bool Hidden {
        get { return GetHidden(); }
        set { SetHidden(value); }
    }
    /// <summary>The scrollability of the panel.</summary>
    /// <value>The scrollable state.</value>
    public bool Scrollable {
        get { return GetScrollable(); }
        set { SetScrollable(value); }
    }
    /// <summary>The size of the scrollable panel.</summary>
    /// <value>Size ratio</value>
    public double ScrollableContentSize {
        get { return GetScrollableContentSize(); }
        set { SetScrollableContentSize(value); }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }
    /// <summary>The content position</summary>
    /// <value>The position is virtual value, (0, 0) starting at the top-left.</value>
    public Eina.Position2D ContentPos {
        get { return GetContentPos(); }
        set { SetContentPos(value); }
    }
    /// <summary>The content size</summary>
    /// <value>The content size in pixels.</value>
    public Eina.Size2D ContentSize {
        get { return GetContentSize(); }
    }
    /// <summary>The viewport geometry</summary>
    /// <value>It is absolute geometry.</value>
    public Eina.Rect ViewportGeometry {
        get { return GetViewportGeometry(); }
    }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <value>Horizontal bounce policy.</value>
    public (bool, bool) BounceEnabled {
        get {
            bool _out_horiz = default(bool);
            bool _out_vert = default(bool);
            GetBounceEnabled(out _out_horiz,out _out_vert);
            return (_out_horiz,_out_vert);
        }
        set { SetBounceEnabled( value.Item1,  value.Item2); }
    }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <value><c>true</c> if freeze, <c>false</c> otherwise</value>
    public bool ScrollFreeze {
        get { return GetScrollFreeze(); }
        set { SetScrollFreeze(value); }
    }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <value><c>true</c> if hold, <c>false</c> otherwise</value>
    public bool ScrollHold {
        get { return GetScrollHold(); }
        set { SetScrollHold(value); }
    }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <value>The scrolling horizontal loop</value>
    public (bool, bool) Looping {
        get {
            bool _out_loop_h = default(bool);
            bool _out_loop_v = default(bool);
            GetLooping(out _out_loop_h,out _out_loop_v);
            return (_out_loop_h,_out_loop_v);
        }
        set { SetLooping( value.Item1,  value.Item2); }
    }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block</value>
    public Efl.Ui.LayoutOrientation MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock(value); }
    }
    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows.
    /// 
    /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
    /// 
    /// Default values for x and y are 0.0</summary>
    /// <value>Horizontal scrolling gravity</value>
    public (double, double) Gravity {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetGravity(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetGravity( value.Item1,  value.Item2); }
    }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <value>Whether to limit the minimum horizontal size</value>
    public (bool, bool) MatchContent {
        set { SetMatchContent( value.Item1,  value.Item2); }
    }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <value>The step size in pixels</value>
    public Eina.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize(value); }
    }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <value><c>true</c> to set enable.</value>
    protected bool Enable {
        get { return GetEnable(); }
        set { SetEnable(value); }
    }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <value><c>true</c> means layer will enable itself once the widget becomes visible</value>
    protected (bool, bool) Behaviour {
        get {
            bool _out_enable_on_visible = default(bool);
            bool _out_cycle = default(bool);
            GetBehaviour(out _out_enable_on_visible,out _out_cycle);
            return (_out_enable_on_visible,_out_cycle);
        }
        set { SetBehaviour( value.Item1,  value.Item2); }
    }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <value>Currently focused element.</value>
    public Efl.Ui.Focus.IObject ManagerFocus {
        get { return GetManagerFocus(); }
        set { SetManagerFocus(value); }
    }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <value>The new focus manager.</value>
    public Efl.Ui.Focus.IManager Redirect {
        get { return GetRedirect(); }
        set { SetRedirect(value); }
    }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>An iterator over the border objects.</value>
    public Eina.Iterator<Efl.Ui.Focus.IObject> BorderElements {
        get { return GetBorderElements(); }
    }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <value>Object to register as the root of this manager object.</value>
    public Efl.Ui.Focus.IObject Root {
        get { return GetRoot(); }
        set { SetRoot(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Panel.efl_ui_panel_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_panel_orient_get_static_delegate == null)
            {
                efl_ui_panel_orient_get_static_delegate = new efl_ui_panel_orient_get_delegate(orient_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOrient") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_orient_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_orient_get_static_delegate) });
            }

            if (efl_ui_panel_orient_set_static_delegate == null)
            {
                efl_ui_panel_orient_set_static_delegate = new efl_ui_panel_orient_set_delegate(orient_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOrient") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_orient_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_orient_set_static_delegate) });
            }

            if (efl_ui_panel_hidden_get_static_delegate == null)
            {
                efl_ui_panel_hidden_get_static_delegate = new efl_ui_panel_hidden_get_delegate(hidden_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHidden") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_hidden_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_hidden_get_static_delegate) });
            }

            if (efl_ui_panel_hidden_set_static_delegate == null)
            {
                efl_ui_panel_hidden_set_static_delegate = new efl_ui_panel_hidden_set_delegate(hidden_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHidden") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_hidden_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_hidden_set_static_delegate) });
            }

            if (efl_ui_panel_scrollable_get_static_delegate == null)
            {
                efl_ui_panel_scrollable_get_static_delegate = new efl_ui_panel_scrollable_get_delegate(scrollable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_scrollable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_scrollable_get_static_delegate) });
            }

            if (efl_ui_panel_scrollable_set_static_delegate == null)
            {
                efl_ui_panel_scrollable_set_static_delegate = new efl_ui_panel_scrollable_set_delegate(scrollable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_scrollable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_scrollable_set_static_delegate) });
            }

            if (efl_ui_panel_scrollable_content_size_get_static_delegate == null)
            {
                efl_ui_panel_scrollable_content_size_get_static_delegate = new efl_ui_panel_scrollable_content_size_get_delegate(scrollable_content_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollableContentSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_scrollable_content_size_get_static_delegate) });
            }

            if (efl_ui_panel_scrollable_content_size_set_static_delegate == null)
            {
                efl_ui_panel_scrollable_content_size_set_static_delegate = new efl_ui_panel_scrollable_content_size_set_delegate(scrollable_content_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollableContentSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_scrollable_content_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_scrollable_content_size_set_static_delegate) });
            }

            if (efl_ui_panel_toggle_static_delegate == null)
            {
                efl_ui_panel_toggle_static_delegate = new efl_ui_panel_toggle_delegate(toggle);
            }

            if (methods.FirstOrDefault(m => m.Name == "Toggle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_panel_toggle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panel_toggle_static_delegate) });
            }

            if (efl_ui_widget_focus_manager_create_static_delegate == null)
            {
                efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusManagerCreate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate) });
            }

            if (efl_ui_focus_layer_enable_get_static_delegate == null)
            {
                efl_ui_focus_layer_enable_get_static_delegate = new efl_ui_focus_layer_enable_get_delegate(enable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEnable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_enable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_enable_get_static_delegate) });
            }

            if (efl_ui_focus_layer_enable_set_static_delegate == null)
            {
                efl_ui_focus_layer_enable_set_static_delegate = new efl_ui_focus_layer_enable_set_delegate(enable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEnable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_enable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_enable_set_static_delegate) });
            }

            if (efl_ui_focus_layer_behaviour_get_static_delegate == null)
            {
                efl_ui_focus_layer_behaviour_get_static_delegate = new efl_ui_focus_layer_behaviour_get_delegate(behaviour_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBehaviour") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_behaviour_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_behaviour_get_static_delegate) });
            }

            if (efl_ui_focus_layer_behaviour_set_static_delegate == null)
            {
                efl_ui_focus_layer_behaviour_set_static_delegate = new efl_ui_focus_layer_behaviour_set_delegate(behaviour_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBehaviour") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_layer_behaviour_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_layer_behaviour_set_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Panel.efl_ui_panel_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.PanelOrient efl_ui_panel_orient_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.PanelOrient efl_ui_panel_orient_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_orient_get_api_delegate> efl_ui_panel_orient_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_orient_get_api_delegate>(Module, "efl_ui_panel_orient_get");

        private static Efl.Ui.PanelOrient orient_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panel_orient_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.PanelOrient _ret_var = default(Efl.Ui.PanelOrient);
                try
                {
                    _ret_var = ((Panel)ws.Target).GetOrient();
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
                return efl_ui_panel_orient_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panel_orient_get_delegate efl_ui_panel_orient_get_static_delegate;

        
        private delegate void efl_ui_panel_orient_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.PanelOrient orient);

        
        public delegate void efl_ui_panel_orient_set_api_delegate(System.IntPtr obj,  Efl.Ui.PanelOrient orient);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_orient_set_api_delegate> efl_ui_panel_orient_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_orient_set_api_delegate>(Module, "efl_ui_panel_orient_set");

        private static void orient_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.PanelOrient orient)
        {
            Eina.Log.Debug("function efl_ui_panel_orient_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panel)ws.Target).SetOrient(orient);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panel_orient_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), orient);
            }
        }

        private static efl_ui_panel_orient_set_delegate efl_ui_panel_orient_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_panel_hidden_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_panel_hidden_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_hidden_get_api_delegate> efl_ui_panel_hidden_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_hidden_get_api_delegate>(Module, "efl_ui_panel_hidden_get");

        private static bool hidden_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panel_hidden_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Panel)ws.Target).GetHidden();
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
                return efl_ui_panel_hidden_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panel_hidden_get_delegate efl_ui_panel_hidden_get_static_delegate;

        
        private delegate void efl_ui_panel_hidden_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool hidden);

        
        public delegate void efl_ui_panel_hidden_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool hidden);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_hidden_set_api_delegate> efl_ui_panel_hidden_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_hidden_set_api_delegate>(Module, "efl_ui_panel_hidden_set");

        private static void hidden_set(System.IntPtr obj, System.IntPtr pd, bool hidden)
        {
            Eina.Log.Debug("function efl_ui_panel_hidden_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panel)ws.Target).SetHidden(hidden);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panel_hidden_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hidden);
            }
        }

        private static efl_ui_panel_hidden_set_delegate efl_ui_panel_hidden_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_panel_scrollable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_panel_scrollable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_get_api_delegate> efl_ui_panel_scrollable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_get_api_delegate>(Module, "efl_ui_panel_scrollable_get");

        private static bool scrollable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panel_scrollable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Panel)ws.Target).GetScrollable();
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
                return efl_ui_panel_scrollable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panel_scrollable_get_delegate efl_ui_panel_scrollable_get_static_delegate;

        
        private delegate void efl_ui_panel_scrollable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool scrollable);

        
        public delegate void efl_ui_panel_scrollable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool scrollable);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_set_api_delegate> efl_ui_panel_scrollable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_set_api_delegate>(Module, "efl_ui_panel_scrollable_set");

        private static void scrollable_set(System.IntPtr obj, System.IntPtr pd, bool scrollable)
        {
            Eina.Log.Debug("function efl_ui_panel_scrollable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panel)ws.Target).SetScrollable(scrollable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panel_scrollable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scrollable);
            }
        }

        private static efl_ui_panel_scrollable_set_delegate efl_ui_panel_scrollable_set_static_delegate;

        
        private delegate double efl_ui_panel_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_panel_scrollable_content_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_content_size_get_api_delegate> efl_ui_panel_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_content_size_get_api_delegate>(Module, "efl_ui_panel_scrollable_content_size_get");

        private static double scrollable_content_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panel_scrollable_content_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Panel)ws.Target).GetScrollableContentSize();
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
                return efl_ui_panel_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panel_scrollable_content_size_get_delegate efl_ui_panel_scrollable_content_size_get_static_delegate;

        
        private delegate void efl_ui_panel_scrollable_content_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ratio);

        
        public delegate void efl_ui_panel_scrollable_content_size_set_api_delegate(System.IntPtr obj,  double ratio);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_content_size_set_api_delegate> efl_ui_panel_scrollable_content_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_scrollable_content_size_set_api_delegate>(Module, "efl_ui_panel_scrollable_content_size_set");

        private static void scrollable_content_size_set(System.IntPtr obj, System.IntPtr pd, double ratio)
        {
            Eina.Log.Debug("function efl_ui_panel_scrollable_content_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panel)ws.Target).SetScrollableContentSize(ratio);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_panel_scrollable_content_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ratio);
            }
        }

        private static efl_ui_panel_scrollable_content_size_set_delegate efl_ui_panel_scrollable_content_size_set_static_delegate;

        
        private delegate void efl_ui_panel_toggle_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_panel_toggle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_panel_toggle_api_delegate> efl_ui_panel_toggle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panel_toggle_api_delegate>(Module, "efl_ui_panel_toggle");

        private static void toggle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_panel_toggle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Panel)ws.Target).Toggle();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_panel_toggle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_panel_toggle_delegate efl_ui_panel_toggle_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate> efl_ui_widget_focus_manager_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate>(Module, "efl_ui_widget_focus_manager_create");

        private static Efl.Ui.Focus.IManager focus_manager_create(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject root)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_manager_create was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = ((Panel)ws.Target).FocusManagerCreate(root);
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
                return efl_ui_widget_focus_manager_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_ui_widget_focus_manager_create_delegate efl_ui_widget_focus_manager_create_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_layer_enable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_layer_enable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate> efl_ui_focus_layer_enable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate>(Module, "efl_ui_focus_layer_enable_get");

        private static bool enable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_enable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Panel)ws.Target).GetEnable();
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
                return efl_ui_focus_layer_enable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_layer_enable_get_delegate efl_ui_focus_layer_enable_get_static_delegate;

        
        private delegate void efl_ui_focus_layer_enable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_ui_focus_layer_enable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate> efl_ui_focus_layer_enable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate>(Module, "efl_ui_focus_layer_enable_set");

        private static void enable_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_enable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Panel)ws.Target).SetEnable(v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_layer_enable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), v);
            }
        }

        private static efl_ui_focus_layer_enable_set_delegate efl_ui_focus_layer_enable_set_static_delegate;

        
        private delegate void efl_ui_focus_layer_behaviour_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate> efl_ui_focus_layer_behaviour_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate>(Module, "efl_ui_focus_layer_behaviour_get");

        private static void behaviour_get(System.IntPtr obj, System.IntPtr pd, out bool enable_on_visible, out bool cycle)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_behaviour_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        enable_on_visible = default(bool);        cycle = default(bool);                            
                try
                {
                    ((Panel)ws.Target).GetBehaviour(out enable_on_visible, out cycle);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_focus_layer_behaviour_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out enable_on_visible, out cycle);
            }
        }

        private static efl_ui_focus_layer_behaviour_get_delegate efl_ui_focus_layer_behaviour_get_static_delegate;

        
        private delegate void efl_ui_focus_layer_behaviour_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate> efl_ui_focus_layer_behaviour_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate>(Module, "efl_ui_focus_layer_behaviour_set");

        private static void behaviour_set(System.IntPtr obj, System.IntPtr pd, bool enable_on_visible, bool cycle)
        {
            Eina.Log.Debug("function efl_ui_focus_layer_behaviour_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Panel)ws.Target).SetBehaviour(enable_on_visible, cycle);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_focus_layer_behaviour_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable_on_visible, cycle);
            }
        }

        private static efl_ui_focus_layer_behaviour_set_delegate efl_ui_focus_layer_behaviour_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiPanel_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.PanelOrient> Orient<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Ui.PanelOrient>("orient", fac);
    }

    public static Efl.BindableProperty<bool> Hidden<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<bool>("hidden", fac);
    }

    public static Efl.BindableProperty<bool> Scrollable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<bool>("scrollable", fac);
    }

    public static Efl.BindableProperty<double> ScrollableContentSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<double>("scrollable_content_size", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> ContentPos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Eina.Position2D>("content_pos", fac);
    }

    
    
    
    public static Efl.BindableProperty<bool> ScrollFreeze<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<bool>("scroll_freeze", fac);
    }

    public static Efl.BindableProperty<bool> ScrollHold<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<bool>("scroll_hold", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> MovementBlock<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("movement_block", fac);
    }

    
    
    public static Efl.BindableProperty<Eina.Position2D> StepSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Eina.Position2D>("step_size", fac);
    }

    public static Efl.BindableProperty<bool> Enable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<bool>("enable", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> ManagerFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("manager_focus", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IManager> Redirect<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Ui.Focus.IManager>("redirect", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> Root<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Panel, T>magic = null) where T : Efl.Ui.Panel {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("root", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Panel orientation mode</summary>
[Efl.Eo.BindingEntity]
public enum PanelOrient
{
/// <summary>Panel (dis)appears from the top</summary>
Top = 0,
/// <summary>Panel (dis)appears from the bottom</summary>
Bottom = 1,
/// <summary>Panel (dis)appears from the left</summary>
Left = 2,
/// <summary>Panel (dis)appears from the right</summary>
Right = 3,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Panel scroll information</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct PanelScrollInfo
{
    /// <summary>content scrolled position (0.0 ~ 1.0) in the panel</summary>
    public double Rel_x;
    /// <summary>content scrolled position (0.0 ~ 1.0) in the panel</summary>
    public double Rel_y;
    /// <summary>Constructor for PanelScrollInfo.</summary>
    /// <param name="Rel_x">content scrolled position (0.0 ~ 1.0) in the panel</param>
    /// <param name="Rel_y">content scrolled position (0.0 ~ 1.0) in the panel</param>
    public PanelScrollInfo(
        double Rel_x = default(double),
        double Rel_y = default(double)    )
    {
        this.Rel_x = Rel_x;
        this.Rel_y = Rel_y;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator PanelScrollInfo(IntPtr ptr)
    {
        var tmp = (PanelScrollInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(PanelScrollInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct PanelScrollInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Rel_x;
        
        public double Rel_y;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator PanelScrollInfo.NativeStruct(PanelScrollInfo _external_struct)
        {
            var _internal_struct = new PanelScrollInfo.NativeStruct();
            _internal_struct.Rel_x = _external_struct.Rel_x;
            _internal_struct.Rel_y = _external_struct.Rel_y;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator PanelScrollInfo(PanelScrollInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new PanelScrollInfo();
            _external_struct.Rel_x = _internal_struct.Rel_x;
            _external_struct.Rel_y = _internal_struct.Rel_y;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

