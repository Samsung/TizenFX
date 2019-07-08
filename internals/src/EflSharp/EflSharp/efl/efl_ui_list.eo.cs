#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Simple list widget with Pack interface.</summary>
[Efl.Ui.List.NativeMethods]
public class List : Efl.Ui.LayoutBase, Efl.IPack, Efl.IPackLayout, Efl.IPackLinear, Efl.Gfx.IArrangement, Efl.Ui.IMultiSelectable, Efl.Ui.IScrollable, Efl.Ui.IScrollableInteractive, Efl.Ui.IScrollbar, Efl.Ui.ISelectable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(List))
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
        efl_ui_list_class_get();
    /// <summary>Initializes a new instance of the <see cref="List"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public List(Efl.Object parent
            , System.String style = null) : base(efl_ui_list_class_get(), typeof(List), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="List"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected List(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="List"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected List(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
    public void OnLayoutUpdatedEvt(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll operation starts</summary>
    public event EventHandler ScrollStartEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollStartEvt.</summary>
    public void OnScrollStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollEvt.</summary>
    public void OnScrollEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll operation stops</summary>
    public event EventHandler ScrollStopEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollStopEvt.</summary>
    public void OnScrollStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollUpEvt.</summary>
    public void OnScrollUpEvt(EventArgs e)
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
    public event EventHandler ScrollDownEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollDownEvt.</summary>
    public void OnScrollDownEvt(EventArgs e)
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
    public event EventHandler ScrollLeftEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollLeftEvt.</summary>
    public void OnScrollLeftEvt(EventArgs e)
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
    public event EventHandler ScrollRightEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollRightEvt.</summary>
    public void OnScrollRightEvt(EventArgs e)
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
    public event EventHandler EdgeUpEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event EdgeUpEvt.</summary>
    public void OnEdgeUpEvt(EventArgs e)
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
    public event EventHandler EdgeDownEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event EdgeDownEvt.</summary>
    public void OnEdgeDownEvt(EventArgs e)
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
    public event EventHandler EdgeLeftEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event EdgeLeftEvt.</summary>
    public void OnEdgeLeftEvt(EventArgs e)
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
    public event EventHandler EdgeRightEvt
    {
        add
        {
            lock (eventLock)
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
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event EdgeRightEvt.</summary>
    public void OnEdgeRightEvt(EventArgs e)
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
    public event EventHandler ScrollAnimStartEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStartEvt.</summary>
    public void OnScrollAnimStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation stopps</summary>
    public event EventHandler ScrollAnimStopEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStopEvt.</summary>
    public void OnScrollAnimStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStartEvt.</summary>
    public void OnScrollDragStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag stops</summary>
    public event EventHandler ScrollDragStopEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStopEvt.</summary>
    public void OnScrollDragStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar is pressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IScrollbarBarPressEvt_Args args = new Efl.Ui.IScrollbarBarPressEvt_Args();
                        args.arg = default(Efl.Ui.ScrollbarDirection);
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarPressEvt.</summary>
    public void OnBarPressEvt(Efl.Ui.IScrollbarBarPressEvt_Args e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when bar is unpressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IScrollbarBarUnpressEvt_Args args = new Efl.Ui.IScrollbarBarUnpressEvt_Args();
                        args.arg = default(Efl.Ui.ScrollbarDirection);
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarUnpressEvt.</summary>
    public void OnBarUnpressEvt(Efl.Ui.IScrollbarBarUnpressEvt_Args e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when bar is dragged</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IScrollbarBarDragEvt_Args args = new Efl.Ui.IScrollbarBarDragEvt_Args();
                        args.arg = default(Efl.Ui.ScrollbarDirection);
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarDragEvt.</summary>
    public void OnBarDragEvt(Efl.Ui.IScrollbarBarDragEvt_Args e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when bar size is changed</summary>
    public event EventHandler BarSizeChangedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarSizeChangedEvt.</summary>
    public void OnBarSizeChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar position is changed</summary>
    public event EventHandler BarPosChangedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarPosChangedEvt.</summary>
    public void OnBarPosChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Callend when bar is shown</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IScrollbarBarShowEvt_Args args = new Efl.Ui.IScrollbarBarShowEvt_Args();
                        args.arg = default(Efl.Ui.ScrollbarDirection);
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarShowEvt.</summary>
    public void OnBarShowEvt(Efl.Ui.IScrollbarBarShowEvt_Args e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when bar is hidden</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.IScrollbarBarHideEvt_Args args = new Efl.Ui.IScrollbarBarHideEvt_Args();
                        args.arg = default(Efl.Ui.ScrollbarDirection);
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarHideEvt.</summary>
    public void OnBarHideEvt(Efl.Ui.IScrollbarBarHideEvt_Args e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> ItemSelectedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.ISelectableItemSelectedEvt_Args args = new Efl.Ui.ISelectableItemSelectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemSelectedEvt.</summary>
    public void OnItemSelectedEvt(Efl.Ui.ISelectableItemSelectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when no longer selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> ItemUnselectedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.ISelectableItemUnselectedEvt_Args args = new Efl.Ui.ISelectableItemUnselectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemUnselectedEvt.</summary>
    public void OnItemUnselectedEvt(Efl.Ui.ISelectableItemUnselectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when selection is pasted</summary>
    public event EventHandler SelectionPasteEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionPasteEvt.</summary>
    public void OnSelectionPasteEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_PASTE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is copied</summary>
    public event EventHandler SelectionCopyEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionCopyEvt.</summary>
    public void OnSelectionCopyEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_COPY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is cut</summary>
    public event EventHandler SelectionCutEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionCutEvt.</summary>
    public void OnSelectionCutEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called at selection start</summary>
    public event EventHandler SelectionStartEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionStartEvt.</summary>
    public void OnSelectionStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is changed</summary>
    public event EventHandler SelectionChangedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionChangedEvt.</summary>
    public void OnSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is cleared</summary>
    public event EventHandler SelectionClearedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionClearedEvt.</summary>
    public void OnSelectionClearedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CLEARED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Property data of last selected item.</summary>
    /// <returns>last selected item of list.</returns>
    virtual public Efl.Ui.ListItem GetLastSelectedItem() {
         var _ret_var = Efl.Ui.List.NativeMethods.efl_ui_list_last_selected_item_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>scroll move the item to show in the viewport.</summary>
    /// <param name="item">Target item.</param>
    /// <param name="animation">Boolean value for animation of scroll move.</param>
    virtual public void ItemScroll(Efl.Ui.ListItem item, bool animation) {
                                                         Efl.Ui.List.NativeMethods.efl_ui_list_item_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),item, animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>scroll move the item to show at the align position of the viewport.</summary>
    /// <param name="item">Target item.</param>
    /// <param name="align">align value in Viewport.</param>
    /// <param name="animation">Boolean value for animation of scroll move.</param>
    virtual public void ItemScrollAlign(Efl.Ui.ListItem item, double align, bool animation) {
                                                                                 Efl.Ui.List.NativeMethods.efl_ui_list_item_scroll_align_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),item, align, animation);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Get the selected items iterator. The iterator sequence will be decided by selection.</summary>
    /// <returns>Iterator covered by selected items list. user have to free the iterator after used.</returns>
    virtual public Eina.Iterator<Efl.Ui.ListItem> GetSelectedItems() {
         var _ret_var = Efl.Ui.List.NativeMethods.efl_ui_list_selected_items_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.ListItem>(_ret_var, true, false);
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool ClearPack() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    virtual public bool UnpackAll() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    virtual public bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Requests EFL to call the <see cref="Efl.IPackLayout.UpdateLayout"/> method on this object.
    /// This <see cref="Efl.IPackLayout.UpdateLayout"/> may be called asynchronously.</summary>
    virtual public void LayoutRequest() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overriden to implement custom layout behaviors.</summary>
    virtual public void UpdateLayout() {
         Efl.IPackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Prepend an object at the beginning of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, 0).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the beginning.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBegin(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Append object at the end of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, -1).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack at the end.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackEnd(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend an object before an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack before <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBefore(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_before_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Append an object after an existing sub-object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack after <c>existing</c>.</param>
    /// <param name="existing">Existing reference sub-object.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAfter(Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_after_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will trigger <see cref="Efl.IPackLinear.PackBegin"/>(<c>subobj</c>) whereas <c>index</c> greater than <c>count</c>-1 will trigger <see cref="Efl.IPackLinear.PackEnd"/>(<c>subobj</c>).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Object to pack.</param>
    /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAt(Efl.Gfx.IEntity subobj, int index) {
                                                         var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj, index);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Sub-object at a given <c>index</c> in this container.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will return the last sub-object.</summary>
    /// <param name="index">Index of the existing sub-object to retrieve. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The sub-object contained at the given <c>index</c>.</returns>
    virtual public Efl.Gfx.IEntity GetPackContent(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the index of a sub-object in this container.</summary>
    /// <param name="subobj">An existing sub-object in this container.</param>
    /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range 0 to (<c>count</c>-1).</returns>
    virtual public int GetPackIndex(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
    /// <c>index</c> ranges from -<c>count</c> to <c>count</c>-1, where positive numbers go from first sub-object (0) to last (<c>count</c>-1), and negative numbers go from last sub-object (-1) to first (-<c>count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="Efl.IContainer.ContentCount"/>.
    /// 
    /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
    /// <param name="index">Index of the sub-object to remove. Valid range is -<c>count</c> to (<c>count</c>-1).</param>
    /// <returns>The sub-object if it could be removed.</returns>
    virtual public Efl.Gfx.IEntity PackUnpackAt(int index) {
                                 var _ret_var = Efl.IPackLinearConcrete.NativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    virtual public Efl.Ui.SelectMode GetSelectMode() {
         var _ret_var = Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    virtual public void SetSelectMode(Efl.Ui.SelectMode mode) {
                                 Efl.Ui.IMultiSelectableConcrete.NativeMethods.efl_ui_select_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    virtual public Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    virtual public void SetContentPos(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    virtual public Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    virtual public Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    virtual public void GetBounceEnabled(out bool horiz, out bool vert) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out horiz, out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    virtual public void SetBounceEnabled(bool horiz, bool vert) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),horiz, vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    virtual public bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    virtual public void SetScrollFreeze(bool freeze) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    virtual public bool GetScrollHold() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    virtual public void SetScrollHold(bool hold) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    virtual public void GetLooping(out bool loop_h, out bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out loop_h, out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    virtual public void SetLooping(bool loop_h, bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),loop_h, loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    virtual public void SetMovementBlock(Efl.Ui.ScrollBlock block) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),block);
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
    virtual public void GetGravity(out double x, out double y) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out x, out y);
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
    virtual public void SetGravity(double x, double y) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    virtual public void SetMatchContent(bool w, bool h) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),w, h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    virtual public Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    virtual public void SetStepSize(Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    virtual public void Scroll(Eina.Rect rect, bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_rect, animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    virtual public void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    virtual public void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0</param>
    /// <param name="height">Value between 0.0 and 1.0</param>
    virtual public void GetBarSize(out double width, out double height) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out width, out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    virtual public void GetBarPosition(out double posx, out double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    virtual public void SetBarPosition(double posx, double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),posx, posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar need to be shown or hidden.</summary>
    virtual public void UpdateBarVisibility() {
         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Property data of last selected item.</summary>
    /// <value>last selected item of list.</value>
    public Efl.Ui.ListItem LastSelectedItem {
        get { return GetLastSelectedItem(); }
    }
    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    public Efl.Ui.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
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
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
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
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block</value>
    public Efl.Ui.ScrollBlock MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock(value); }
    }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <value>The step size in pixels</value>
    public Eina.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.List.efl_ui_list_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_list_last_selected_item_get_static_delegate == null)
            {
                efl_ui_list_last_selected_item_get_static_delegate = new efl_ui_list_last_selected_item_get_delegate(last_selected_item_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLastSelectedItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_last_selected_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_last_selected_item_get_static_delegate) });
            }

            if (efl_ui_list_item_scroll_static_delegate == null)
            {
                efl_ui_list_item_scroll_static_delegate = new efl_ui_list_item_scroll_delegate(item_scroll);
            }

            if (methods.FirstOrDefault(m => m.Name == "ItemScroll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_item_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_item_scroll_static_delegate) });
            }

            if (efl_ui_list_item_scroll_align_static_delegate == null)
            {
                efl_ui_list_item_scroll_align_static_delegate = new efl_ui_list_item_scroll_align_delegate(item_scroll_align);
            }

            if (methods.FirstOrDefault(m => m.Name == "ItemScrollAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_item_scroll_align"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_item_scroll_align_static_delegate) });
            }

            if (efl_ui_list_selected_items_get_static_delegate == null)
            {
                efl_ui_list_selected_items_get_static_delegate = new efl_ui_list_selected_items_get_delegate(selected_items_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedItems") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_selected_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_selected_items_get_static_delegate) });
            }

            if (efl_pack_clear_static_delegate == null)
            {
                efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearPack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate) });
            }

            if (efl_pack_unpack_all_static_delegate == null)
            {
                efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnpackAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate) });
            }

            if (efl_pack_unpack_static_delegate == null)
            {
                efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate) });
            }

            if (efl_pack_static_delegate == null)
            {
                efl_pack_static_delegate = new efl_pack_delegate(pack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Pack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate) });
            }

            if (efl_pack_layout_request_static_delegate == null)
            {
                efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
            }

            if (methods.FirstOrDefault(m => m.Name == "LayoutRequest") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
            }

            if (efl_pack_begin_static_delegate == null)
            {
                efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackBegin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate) });
            }

            if (efl_pack_end_static_delegate == null)
            {
                efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate) });
            }

            if (efl_pack_before_static_delegate == null)
            {
                efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackBefore") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate) });
            }

            if (efl_pack_after_static_delegate == null)
            {
                efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackAfter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate) });
            }

            if (efl_pack_at_static_delegate == null)
            {
                efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackAt") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate) });
            }

            if (efl_pack_content_get_static_delegate == null)
            {
                efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate) });
            }

            if (efl_pack_index_get_static_delegate == null)
            {
                efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPackIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate) });
            }

            if (efl_pack_unpack_at_static_delegate == null)
            {
                efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackUnpackAt") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate) });
            }

            if (efl_gfx_arrangement_content_align_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_get_static_delegate = new efl_gfx_arrangement_content_align_get_delegate(content_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_align_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_align_set_static_delegate = new efl_gfx_arrangement_content_align_set_delegate(content_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_align_set_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_get_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_get_static_delegate = new efl_gfx_arrangement_content_padding_get_delegate(content_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_get_static_delegate) });
            }

            if (efl_gfx_arrangement_content_padding_set_static_delegate == null)
            {
                efl_gfx_arrangement_content_padding_set_static_delegate = new efl_gfx_arrangement_content_padding_set_delegate(content_padding_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_arrangement_content_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_arrangement_content_padding_set_static_delegate) });
            }

            if (efl_ui_select_mode_get_static_delegate == null)
            {
                efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate) });
            }

            if (efl_ui_select_mode_set_static_delegate == null)
            {
                efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate) });
            }

            if (efl_ui_scrollable_content_pos_get_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate) });
            }

            if (efl_ui_scrollable_content_pos_set_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate) });
            }

            if (efl_ui_scrollable_content_size_get_static_delegate == null)
            {
                efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
            {
                efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewportGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBounceEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBounceEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate) });
            }

            if (efl_ui_scrollable_looping_get_static_delegate == null)
            {
                efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLooping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate) });
            }

            if (efl_ui_scrollable_looping_set_static_delegate == null)
            {
                efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLooping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_get_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMovementBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_set_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMovementBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_get_static_delegate == null)
            {
                efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGravity") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_set_static_delegate == null)
            {
                efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGravity") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate) });
            }

            if (efl_ui_scrollable_match_content_set_static_delegate == null)
            {
                efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMatchContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_get_static_delegate == null)
            {
                efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStepSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_set_static_delegate == null)
            {
                efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStepSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_static_delegate == null)
            {
                efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
            }

            if (methods.FirstOrDefault(m => m.Name == "Scroll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBarMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBarPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            {
                efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.List.efl_ui_list_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.ListItem efl_ui_list_last_selected_item_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.ListItem efl_ui_list_last_selected_item_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_last_selected_item_get_api_delegate> efl_ui_list_last_selected_item_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_last_selected_item_get_api_delegate>(Module, "efl_ui_list_last_selected_item_get");

        private static Efl.Ui.ListItem last_selected_item_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_last_selected_item_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ListItem _ret_var = default(Efl.Ui.ListItem);
                try
                {
                    _ret_var = ((List)ws.Target).GetLastSelectedItem();
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
                return efl_ui_list_last_selected_item_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_last_selected_item_get_delegate efl_ui_list_last_selected_item_get_static_delegate;

        
        private delegate void efl_ui_list_item_scroll_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ListItem item, [MarshalAs(UnmanagedType.U1)] bool animation);

        
        public delegate void efl_ui_list_item_scroll_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ListItem item, [MarshalAs(UnmanagedType.U1)] bool animation);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_item_scroll_api_delegate> efl_ui_list_item_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_item_scroll_api_delegate>(Module, "efl_ui_list_item_scroll");

        private static void item_scroll(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ListItem item, bool animation)
        {
            Eina.Log.Debug("function efl_ui_list_item_scroll was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).ItemScroll(item, animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_list_item_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item, animation);
            }
        }

        private static efl_ui_list_item_scroll_delegate efl_ui_list_item_scroll_static_delegate;

        
        private delegate void efl_ui_list_item_scroll_align_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ListItem item,  double align, [MarshalAs(UnmanagedType.U1)] bool animation);

        
        public delegate void efl_ui_list_item_scroll_align_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ListItem item,  double align, [MarshalAs(UnmanagedType.U1)] bool animation);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_item_scroll_align_api_delegate> efl_ui_list_item_scroll_align_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_item_scroll_align_api_delegate>(Module, "efl_ui_list_item_scroll_align");

        private static void item_scroll_align(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ListItem item, double align, bool animation)
        {
            Eina.Log.Debug("function efl_ui_list_item_scroll_align was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((List)ws.Target).ItemScrollAlign(item, align, animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_list_item_scroll_align_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item, align, animation);
            }
        }

        private static efl_ui_list_item_scroll_align_delegate efl_ui_list_item_scroll_align_static_delegate;

        
        private delegate System.IntPtr efl_ui_list_selected_items_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_list_selected_items_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_selected_items_get_api_delegate> efl_ui_list_selected_items_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_selected_items_get_api_delegate>(Module, "efl_ui_list_selected_items_get");

        private static System.IntPtr selected_items_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_selected_items_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Ui.ListItem> _ret_var = default(Eina.Iterator<Efl.Ui.ListItem>);
                try
                {
                    _ret_var = ((List)ws.Target).GetSelectedItems();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_ui_list_selected_items_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_selected_items_get_delegate efl_ui_list_selected_items_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(Module, "efl_pack_clear");

        private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).ClearPack();
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
                return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_clear_delegate efl_pack_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(Module, "efl_pack_unpack_all");

        private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_unpack_all was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).UnpackAll();
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
                return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(Module, "efl_pack_unpack");

        private static bool unpack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_unpack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).Unpack(subobj);
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
                return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(Module, "efl_pack");

        private static bool pack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).Pack(subobj);
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
                return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_delegate efl_pack_static_delegate;

        
        private delegate void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_request_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate>(Module, "efl_pack_layout_request");

        private static void layout_request(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_request was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((List)ws.Target).LayoutRequest();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_request_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((List)ws.Target).UpdateLayout();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate>(Module, "efl_pack_begin");

        private static bool pack_begin(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_begin was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).PackBegin(subobj);
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
                return efl_pack_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_begin_delegate efl_pack_begin_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate>(Module, "efl_pack_end");

        private static bool pack_end(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).PackEnd(subobj);
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
                return efl_pack_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_end_delegate efl_pack_end_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        public static Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate>(Module, "efl_pack_before");

        private static bool pack_before(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing)
        {
            Eina.Log.Debug("function efl_pack_before was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).PackBefore(subobj, existing);
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
                return efl_pack_before_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, existing);
            }
        }

        private static efl_pack_before_delegate efl_pack_before_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity existing);

        public static Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate>(Module, "efl_pack_after");

        private static bool pack_after(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, Efl.Gfx.IEntity existing)
        {
            Eina.Log.Debug("function efl_pack_after was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).PackAfter(subobj, existing);
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
                return efl_pack_after_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, existing);
            }
        }

        private static efl_pack_after_delegate efl_pack_after_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate>(Module, "efl_pack_at");

        private static bool pack_at(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int index)
        {
            Eina.Log.Debug("function efl_pack_at was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).PackAt(subobj, index);
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
                return efl_pack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, index);
            }
        }

        private static efl_pack_at_delegate efl_pack_at_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_pack_content_get_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate>(Module, "efl_pack_content_get");

        private static Efl.Gfx.IEntity pack_content_get(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_pack_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((List)ws.Target).GetPackContent(index);
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
                return efl_pack_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;

        
        private delegate int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        
        public delegate int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate>(Module, "efl_pack_index_get");

        private static int pack_index_get(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_index_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((List)ws.Target).GetPackIndex(subobj);
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
                return efl_pack_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_pack_unpack_at_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate>(Module, "efl_pack_unpack_at");

        private static Efl.Gfx.IEntity pack_unpack_at(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_pack_unpack_at was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((List)ws.Target).PackUnpackAt(index);
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
                return efl_pack_unpack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert);

        
        public delegate void efl_gfx_arrangement_content_align_get_api_delegate(System.IntPtr obj,  out double align_horiz,  out double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate> efl_gfx_arrangement_content_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_get_api_delegate>(Module, "efl_gfx_arrangement_content_align_get");

        private static void content_align_get(System.IntPtr obj, System.IntPtr pd, out double align_horiz, out double align_vert)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        align_horiz = default(double);        align_vert = default(double);                            
                try
                {
                    ((List)ws.Target).GetContentAlign(out align_horiz, out align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_arrangement_content_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out align_horiz, out align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_get_delegate efl_gfx_arrangement_content_align_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert);

        
        public delegate void efl_gfx_arrangement_content_align_set_api_delegate(System.IntPtr obj,  double align_horiz,  double align_vert);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate> efl_gfx_arrangement_content_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_align_set_api_delegate>(Module, "efl_gfx_arrangement_content_align_set");

        private static void content_align_set(System.IntPtr obj, System.IntPtr pd, double align_horiz, double align_vert)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetContentAlign(align_horiz, align_vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_arrangement_content_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), align_horiz, align_vert);
            }
        }

        private static efl_gfx_arrangement_content_align_set_delegate efl_gfx_arrangement_content_align_set_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        
        public delegate void efl_gfx_arrangement_content_padding_get_api_delegate(System.IntPtr obj,  out double pad_horiz,  out double pad_vert, [MarshalAs(UnmanagedType.U1)] out bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate> efl_gfx_arrangement_content_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_get_api_delegate>(Module, "efl_gfx_arrangement_content_padding_get");

        private static void content_padding_get(System.IntPtr obj, System.IntPtr pd, out double pad_horiz, out double pad_vert, out bool scalable)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_padding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                pad_horiz = default(double);        pad_vert = default(double);        scalable = default(bool);                                    
                try
                {
                    ((List)ws.Target).GetContentPadding(out pad_horiz, out pad_vert, out scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out pad_horiz, out pad_vert, out scalable);
            }
        }

        private static efl_gfx_arrangement_content_padding_get_delegate efl_gfx_arrangement_content_padding_get_static_delegate;

        
        private delegate void efl_gfx_arrangement_content_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        
        public delegate void efl_gfx_arrangement_content_padding_set_api_delegate(System.IntPtr obj,  double pad_horiz,  double pad_vert, [MarshalAs(UnmanagedType.U1)] bool scalable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate> efl_gfx_arrangement_content_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_arrangement_content_padding_set_api_delegate>(Module, "efl_gfx_arrangement_content_padding_set");

        private static void content_padding_set(System.IntPtr obj, System.IntPtr pd, double pad_horiz, double pad_vert, bool scalable)
        {
            Eina.Log.Debug("function efl_gfx_arrangement_content_padding_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((List)ws.Target).SetContentPadding(pad_horiz, pad_vert, scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pad_horiz, pad_vert, scalable);
            }
        }

        private static efl_gfx_arrangement_content_padding_set_delegate efl_gfx_arrangement_content_padding_set_static_delegate;

        
        private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectMode efl_ui_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate> efl_ui_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate>(Module, "efl_ui_select_mode_get");

        private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
                try
                {
                    _ret_var = ((List)ws.Target).GetSelectMode();
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
                return efl_ui_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;

        
        private delegate void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode);

        
        public delegate void efl_ui_select_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate> efl_ui_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate>(Module, "efl_ui_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_select_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((List)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(Module, "efl_ui_scrollable_content_pos_get");

        private static Eina.Position2D.NativeStruct content_pos_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((List)ws.Target).GetContentPos();
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
                return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;

        
        private delegate void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(Module, "efl_ui_scrollable_content_pos_set");

        private static void content_pos_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            
                try
                {
                    ((List)ws.Target).SetContentPos(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(Module, "efl_ui_scrollable_content_size_get");

        private static Eina.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((List)ws.Target).GetContentSize();
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
                return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(Module, "efl_ui_scrollable_viewport_geometry_get");

        private static Eina.Rect.NativeStruct viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((List)ws.Target).GetViewportGeometry();
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
                return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        
        public delegate void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_get");

        private static void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd, out bool horiz, out bool vert)
        {
            Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        horiz = default(bool);        vert = default(bool);                            
                try
                {
                    ((List)ws.Target).GetBounceEnabled(out horiz, out vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out horiz, out vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        
        public delegate void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_set");

        private static void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd, bool horiz, bool vert)
        {
            Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetBounceEnabled(horiz, vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), horiz, vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_get");

        private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).GetScrollFreeze();
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
                return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool freeze);

        
        public delegate void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool freeze);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_set");

        private static void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd, bool freeze)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((List)ws.Target).SetScrollFreeze(freeze);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), freeze);
            }
        }

        private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_get");

        private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((List)ws.Target).GetScrollHold();
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
                return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool hold);

        
        public delegate void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool hold);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_set");

        private static void scroll_hold_set(System.IntPtr obj, System.IntPtr pd, bool hold)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((List)ws.Target).SetScrollHold(hold);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hold);
            }
        }

        private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        
        public delegate void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(Module, "efl_ui_scrollable_looping_get");

        private static void looping_get(System.IntPtr obj, System.IntPtr pd, out bool loop_h, out bool loop_v)
        {
            Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        loop_h = default(bool);        loop_v = default(bool);                            
                try
                {
                    ((List)ws.Target).GetLooping(out loop_h, out loop_v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_looping_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out loop_h, out loop_v);
            }
        }

        private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        
        public delegate void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(Module, "efl_ui_scrollable_looping_set");

        private static void looping_set(System.IntPtr obj, System.IntPtr pd, bool loop_h, bool loop_v)
        {
            Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetLooping(loop_h, loop_v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_looping_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), loop_h, loop_v);
            }
        }

        private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;

        
        private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(Module, "efl_ui_scrollable_movement_block_get");

        private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
                try
                {
                    _ret_var = ((List)ws.Target).GetMovementBlock();
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
                return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;

        
        private delegate void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block);

        
        public delegate void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,  Efl.Ui.ScrollBlock block);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(Module, "efl_ui_scrollable_movement_block_set");

        private static void movement_block_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ScrollBlock block)
        {
            Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((List)ws.Target).SetMovementBlock(block);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), block);
            }
        }

        private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(Module, "efl_ui_scrollable_gravity_get");

        private static void gravity_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((List)ws.Target).GetGravity(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_gravity_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(Module, "efl_ui_scrollable_gravity_set");

        private static void gravity_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetGravity(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_gravity_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;

        
        private delegate void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        
        public delegate void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(Module, "efl_ui_scrollable_match_content_set");

        private static void match_content_set(System.IntPtr obj, System.IntPtr pd, bool w, bool h)
        {
            Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetMatchContent(w, h);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_match_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), w, h);
            }
        }

        private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(Module, "efl_ui_scrollable_step_size_get");

        private static Eina.Position2D.NativeStruct step_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_step_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((List)ws.Target).GetStepSize();
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
                return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;

        
        private delegate void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct step);

        
        public delegate void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct step);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(Module, "efl_ui_scrollable_step_size_set");

        private static void step_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct step)
        {
            Eina.Log.Debug("function efl_ui_scrollable_step_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_step = step;
                            
                try
                {
                    ((List)ws.Target).SetStepSize(_in_step);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_step_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), step);
            }
        }

        private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        
        public delegate void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(Module, "efl_ui_scrollable_scroll");

        private static void scroll(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect, bool animation)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                                                    
                try
                {
                    ((List)ws.Target).Scroll(_in_rect, animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect, animation);
            }
        }

        private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        
        public delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_get");

        private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd, out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        hbar = default(Efl.Ui.ScrollbarMode);        vbar = default(Efl.Ui.ScrollbarMode);                            
                try
                {
                    ((List)ws.Target).GetBarMode(out hbar, out vbar);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out hbar, out vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar);

        
        public delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_set");

        private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetBarMode(hbar, vbar);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hbar, vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height);

        
        public delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,  out double width,  out double height);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(Module, "efl_ui_scrollbar_bar_size_get");

        private static void bar_size_get(System.IntPtr obj, System.IntPtr pd, out double width, out double height)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        width = default(double);        height = default(double);                            
                try
                {
                    ((List)ws.Target).GetBarSize(out width, out height);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out width, out height);
            }
        }

        private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy);

        
        public delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,  out double posx,  out double posy);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(Module, "efl_ui_scrollbar_bar_position_get");

        private static void bar_position_get(System.IntPtr obj, System.IntPtr pd, out double posx, out double posy)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        posx = default(double);        posy = default(double);                            
                try
                {
                    ((List)ws.Target).GetBarPosition(out posx, out posy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out posx, out posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy);

        
        public delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,  double posx,  double posy);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(Module, "efl_ui_scrollbar_bar_position_set");

        private static void bar_position_set(System.IntPtr obj, System.IntPtr pd, double posx, double posy)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((List)ws.Target).SetBarPosition(posx, posy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), posx, posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_scrollbar_bar_visibility_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate> efl_ui_scrollbar_bar_visibility_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate>(Module, "efl_ui_scrollbar_bar_visibility_update");

        private static void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((List)ws.Target).UpdateBarVisibility();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

