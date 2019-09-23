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

/// <summary>Interface used by widgets which can display scrollbars, enabling them to contain more content than actually fits inside them.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ScrollbarConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IScrollbar : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar.</param>
/// <param name="vbar">Vertical scrollbar.</param>
void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar);
    /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar.</param>
/// <param name="vbar">Vertical scrollbar.</param>
void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar);
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
/// <param name="width">Value between 0.0 and 1.0.</param>
/// <param name="height">Value between 0.0 and 1.0.</param>
void GetBarSize(out double width, out double height);
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0.</param>
/// <param name="posy">Value between 0.0 and 1.0.</param>
void GetBarPosition(out double posx, out double posy);
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0.</param>
/// <param name="posy">Value between 0.0 and 1.0.</param>
void SetBarPosition(double posx, double posy);
                                /// <summary>Called when bar is pressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarPressEventArgs"/></value>
    event EventHandler<Efl.Ui.ScrollbarBarPressEventArgs> BarPressEvent;
    /// <summary>Called when bar is unpressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarUnpressEventArgs"/></value>
    event EventHandler<Efl.Ui.ScrollbarBarUnpressEventArgs> BarUnpressEvent;
    /// <summary>Called when bar is dragged.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarDragEventArgs"/></value>
    event EventHandler<Efl.Ui.ScrollbarBarDragEventArgs> BarDragEvent;
    /// <summary>Called when bar size is changed.</summary>
    event EventHandler BarSizeChangedEvent;
    /// <summary>Called when bar position is changed.</summary>
    event EventHandler BarPosChangedEvent;
    /// <summary>Callend when bar is shown.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarShowEventArgs"/></value>
    event EventHandler<Efl.Ui.ScrollbarBarShowEventArgs> BarShowEvent;
    /// <summary>Called when bar is hidden.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarHideEventArgs"/></value>
    event EventHandler<Efl.Ui.ScrollbarBarHideEventArgs> BarHideEvent;
    /// <summary>Scrollbar visibility policy</summary>
    /// <value>Horizontal scrollbar.</value>
    (Efl.Ui.ScrollbarMode, Efl.Ui.ScrollbarMode) BarMode {
        get;
        set;
    }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    (double, double) BarSize {
        get;
    }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <value>Value between 0.0 and 1.0.</value>
    (double, double) BarPosition {
        get;
        set;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarPressEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ScrollbarBarPressEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when bar is pressed.</value>
    public Efl.Ui.LayoutOrientation arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarUnpressEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ScrollbarBarUnpressEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when bar is unpressed.</value>
    public Efl.Ui.LayoutOrientation arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarDragEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ScrollbarBarDragEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when bar is dragged.</value>
    public Efl.Ui.LayoutOrientation arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarShowEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ScrollbarBarShowEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Callend when bar is shown.</value>
    public Efl.Ui.LayoutOrientation arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarHideEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ScrollbarBarHideEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when bar is hidden.</value>
    public Efl.Ui.LayoutOrientation arg { get; set; }
}
/// <summary>Interface used by widgets which can display scrollbars, enabling them to contain more content than actually fits inside them.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class ScrollbarConcrete :
    Efl.Eo.EoWrapper
    , IScrollbar
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ScrollbarConcrete))
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
    private ScrollbarConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_scrollbar_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IScrollbar"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ScrollbarConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when bar is pressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarPressEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarPressEventArgs> BarPressEvent
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
                        Efl.Ui.ScrollbarBarPressEventArgs args = new Efl.Ui.ScrollbarBarPressEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarPressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPressEvent(Efl.Ui.ScrollbarBarPressEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Called when bar is unpressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarUnpressEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarUnpressEventArgs> BarUnpressEvent
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
                        Efl.Ui.ScrollbarBarUnpressEventArgs args = new Efl.Ui.ScrollbarBarUnpressEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarUnpressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarUnpressEvent(Efl.Ui.ScrollbarBarUnpressEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Called when bar is dragged.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarDragEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarDragEventArgs> BarDragEvent
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
                        Efl.Ui.ScrollbarBarDragEventArgs args = new Efl.Ui.ScrollbarBarDragEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarDragEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarDragEvent(Efl.Ui.ScrollbarBarDragEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Called when bar size is changed.</summary>
    public event EventHandler BarSizeChangedEvent
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarSizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarSizeChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar position is changed.</summary>
    public event EventHandler BarPosChangedEvent
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarPosChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPosChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Callend when bar is shown.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarShowEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarShowEventArgs> BarShowEvent
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
                        Efl.Ui.ScrollbarBarShowEventArgs args = new Efl.Ui.ScrollbarBarShowEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarShowEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarShowEvent(Efl.Ui.ScrollbarBarShowEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <summary>Called when bar is hidden.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarHideEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarHideEventArgs> BarHideEvent
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
                        Efl.Ui.ScrollbarBarHideEventArgs args = new Efl.Ui.ScrollbarBarHideEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarHideEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarHideEvent(Efl.Ui.ScrollbarBarHideEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
#pragma warning disable CS0628
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    public void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(this.NativeHandle,out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    public void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(this.NativeHandle,hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0.</param>
    /// <param name="height">Value between 0.0 and 1.0.</param>
    public void GetBarSize(out double width, out double height) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(this.NativeHandle,out width, out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    public void GetBarPosition(out double posx, out double posy) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(this.NativeHandle,out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    public void SetBarPosition(double posx, double posy) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(this.NativeHandle,posx, posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar needs to be shown or hidden.</summary>
    protected void UpdateBarVisibility() {
         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <value>Horizontal scrollbar.</value>
    public (Efl.Ui.ScrollbarMode, Efl.Ui.ScrollbarMode) BarMode {
        get {
            Efl.Ui.ScrollbarMode _out_hbar = default(Efl.Ui.ScrollbarMode);
            Efl.Ui.ScrollbarMode _out_vbar = default(Efl.Ui.ScrollbarMode);
            GetBarMode(out _out_hbar,out _out_vbar);
            return (_out_hbar,_out_vbar);
        }
        set { SetBarMode( value.Item1,  value.Item2); }
    }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    public (double, double) BarSize {
        get {
            double _out_width = default(double);
            double _out_height = default(double);
            GetBarSize(out _out_width,out _out_height);
            return (_out_width,_out_height);
        }
    }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <value>Value between 0.0 and 1.0.</value>
    public (double, double) BarPosition {
        get {
            double _out_posx = default(double);
            double _out_posy = default(double);
            GetBarPosition(out _out_posx,out _out_posy);
            return (_out_posx,_out_posy);
        }
        set { SetBarPosition( value.Item1,  value.Item2); }
    }
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ScrollbarConcrete.efl_ui_scrollbar_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

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
            return Efl.Ui.ScrollbarConcrete.efl_ui_scrollbar_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
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
                    ((IScrollbar)ws.Target).GetBarMode(out hbar, out vbar);
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
                    ((IScrollbar)ws.Target).SetBarMode(hbar, vbar);
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
                    ((IScrollbar)ws.Target).GetBarSize(out width, out height);
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
                    ((IScrollbar)ws.Target).GetBarPosition(out posx, out posy);
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
                    ((IScrollbar)ws.Target).SetBarPosition(posx, posy);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiScrollbarConcrete_ExtensionMethods {
    
    
    
}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>When should the scrollbar be shown.</summary>
[Efl.Eo.BindingEntity]
public enum ScrollbarMode
{
/// <summary>Visible if necessary.</summary>
Auto = 0,
/// <summary>Always visible.</summary>
On = 1,
/// <summary>Always invisible.</summary>
Off = 2,
/// <summary>For internal use only.</summary>
Last = 3,
}

}

}

