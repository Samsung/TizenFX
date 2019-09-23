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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Win.FullscreenChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class WinFullscreenChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when window is set to or from fullscreen</value>
    public bool arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Win.MaximizedChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class WinMaximizedChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when window is set to or from maximized</value>
    public bool arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Win.WinRotationChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class WinWinRotationChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when window rotation is changed, sends current rotation in degrees</value>
    public int arg { get; set; }
}
/// <summary>Efl UI window class.
/// (Since EFL 1.22)</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Win.NativeMethods]
[Efl.Eo.BindingEntity]
public class Win : Efl.Ui.Widget, Efl.IConfig, Efl.IContent, Efl.IScreen, Efl.IText, Efl.Access.IWindow, Efl.Canvas.IScene, Efl.Input.IState, Efl.Ui.IWidgetFocusManager, Efl.Ui.Focus.IManager, Efl.Ui.Focus.IManagerWindowRoot
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Win))
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
        efl_ui_win_class_get();
    /// <summary>Initializes a new instance of the <see cref="Win"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="winName">The window name. See <see cref="Efl.Ui.Win.SetWinName" /></param>
    /// <param name="winType">The type of the window. See <see cref="Efl.Ui.Win.SetWinType" /></param>
    /// <param name="accelPreference">The hardware acceleration preference for this window. See <see cref="Efl.Ui.Win.SetAccelPreference" /></param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Win(Efl.Object parent
            , System.String winName = null, Efl.Ui.WinType? winType = null, System.String accelPreference = null, System.String style = null) : base(efl_ui_win_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(winName))
        {
            SetWinName(Efl.Eo.Globals.GetParamHelper(winName));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(winType))
        {
            SetWinType(Efl.Eo.Globals.GetParamHelper(winType));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(accelPreference))
        {
            SetAccelPreference(Efl.Eo.Globals.GetParamHelper(accelPreference));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Win(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Win"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Win(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Win"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Win(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when the window receives a delete request
    /// (Since EFL 1.22)</summary>
    public event EventHandler DeleteRequestEvent
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

                string key = "_EFL_UI_WIN_EVENT_DELETE_REQUEST";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_DELETE_REQUEST";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeleteRequestEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDeleteRequestEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_DELETE_REQUEST";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is withdrawn
    /// (Since EFL 1.22)</summary>
    public event EventHandler WithdrawnEvent
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

                string key = "_EFL_UI_WIN_EVENT_WITHDRAWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_WITHDRAWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WithdrawnEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWithdrawnEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_WITHDRAWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is minimized
    /// (Since EFL 1.22)</summary>
    public event EventHandler MinimizedEvent
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

                string key = "_EFL_UI_WIN_EVENT_MINIMIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_MINIMIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event MinimizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMinimizedEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_MINIMIZED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is set to normal state
    /// (Since EFL 1.22)</summary>
    public event EventHandler NormalEvent
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

                string key = "_EFL_UI_WIN_EVENT_NORMAL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_NORMAL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event NormalEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnNormalEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_NORMAL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is set as sticky
    /// (Since EFL 1.22)</summary>
    public event EventHandler StickEvent
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

                string key = "_EFL_UI_WIN_EVENT_STICK";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_STICK";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event StickEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStickEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_STICK";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is no  longer set as sticky
    /// (Since EFL 1.22)</summary>
    public event EventHandler UnstickEvent
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

                string key = "_EFL_UI_WIN_EVENT_UNSTICK";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_UNSTICK";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnstickEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnstickEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_UNSTICK";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window is set to or from fullscreen
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.WinFullscreenChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.WinFullscreenChangedEventArgs> FullscreenChangedEvent
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
                        Efl.Ui.WinFullscreenChangedEventArgs args = new Efl.Ui.WinFullscreenChangedEventArgs();
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

                string key = "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event FullscreenChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFullscreenChangedEvent(Efl.Ui.WinFullscreenChangedEventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_FULLSCREEN_CHANGED";
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
    /// <summary>Called when window is set to or from maximized
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.WinMaximizedChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.WinMaximizedChangedEventArgs> MaximizedChangedEvent
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
                        Efl.Ui.WinMaximizedChangedEventArgs args = new Efl.Ui.WinMaximizedChangedEventArgs();
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

                string key = "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event MaximizedChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMaximizedChangedEvent(Efl.Ui.WinMaximizedChangedEventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_MAXIMIZED_CHANGED";
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
    /// <summary>Called when indicator is property changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler IndicatorPropChangedEvent
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

                string key = "_EFL_UI_WIN_EVENT_INDICATOR_PROP_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_INDICATOR_PROP_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event IndicatorPropChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnIndicatorPropChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_INDICATOR_PROP_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window rotation is changed, sends current rotation in degrees
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.WinWinRotationChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.WinWinRotationChangedEventArgs> WinRotationChangedEvent
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
                        Efl.Ui.WinWinRotationChangedEventArgs args = new Efl.Ui.WinWinRotationChangedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WinRotationChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWinRotationChangedEvent(Efl.Ui.WinWinRotationChangedEventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_WIN_ROTATION_CHANGED";
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
    /// <summary>Called when profile is changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler ProfileChangedEvent
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

                string key = "_EFL_UI_WIN_EVENT_PROFILE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_PROFILE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ProfileChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnProfileChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_PROFILE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window manager rotation is changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler WmRotationChangedEvent
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

                string key = "_EFL_UI_WIN_EVENT_WM_ROTATION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_WM_ROTATION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WmRotationChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWmRotationChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_WM_ROTATION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when theme is changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler ThemeChangedEvent
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

                string key = "_EFL_UI_WIN_EVENT_THEME_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_THEME_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ThemeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnThemeChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_THEME_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when elementary block menu action occurs
    /// (Since EFL 1.22)</summary>
    public event EventHandler ElmActionBlockMenuEvent
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

                string key = "_EFL_UI_WIN_EVENT_ELM_ACTION_BLOCK_MENU";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_ELM_ACTION_BLOCK_MENU";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ElmActionBlockMenuEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnElmActionBlockMenuEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_ELM_ACTION_BLOCK_MENU";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when the window is not going be displayed for some time
    /// (Since EFL 1.22)</summary>
    public event EventHandler PauseEvent
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

                string key = "_EFL_UI_WIN_EVENT_PAUSE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_PAUSE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PauseEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPauseEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_PAUSE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called before a window is rendered after a pause event
    /// (Since EFL 1.22)</summary>
    public event EventHandler ResumeEvent
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

                string key = "_EFL_UI_WIN_EVENT_RESUME";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIN_EVENT_RESUME";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ResumeEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnResumeEvent(EventArgs e)
    {
        var key = "_EFL_UI_WIN_EVENT_RESUME";
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
    /// <summary>Called when new window has been created.</summary>
    public event EventHandler WindowCreatedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_CREATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_CREATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowCreatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowCreatedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_CREATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been destroyed.</summary>
    public event EventHandler WindowDestroyedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DESTROYED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DESTROYED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowDestroyedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowDestroyedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DESTROYED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been activated. (focused)</summary>
    public event EventHandler WindowActivatedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_ACTIVATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_ACTIVATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowActivatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowActivatedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_ACTIVATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been deactivated (unfocused).</summary>
    public event EventHandler WindowDeactivatedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DEACTIVATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DEACTIVATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowDeactivatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowDeactivatedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_DEACTIVATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been maximized</summary>
    public event EventHandler WindowMaximizedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MAXIMIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MAXIMIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowMaximizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowMaximizedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MAXIMIZED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been minimized</summary>
    public event EventHandler WindowMinimizedEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MINIMIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MINIMIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowMinimizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowMinimizedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_MINIMIZED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when window has been restored</summary>
    public event EventHandler WindowRestoredEvent
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

                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_RESTORED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_RESTORED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event WindowRestoredEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnWindowRestoredEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_WINDOW_EVENT_WINDOW_RESTORED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scene got focus
    /// (Since EFL 1.22)</summary>
    public event EventHandler SceneFocusInEvent
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

                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SceneFocusInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSceneFocusInEvent(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scene lost focus
    /// (Since EFL 1.22)</summary>
    public event EventHandler SceneFocusOutEvent
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

                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SceneFocusOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSceneFocusOutEvent(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_SCENE_FOCUS_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object got focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneObjectFocusInEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneObjectFocusInEventArgs> ObjectFocusInEvent
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
                        Efl.Canvas.SceneObjectFocusInEventArgs args = new Efl.Canvas.SceneObjectFocusInEventArgs();
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

                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ObjectFocusInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnObjectFocusInEvent(Efl.Canvas.SceneObjectFocusInEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_IN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when object lost focus
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneObjectFocusOutEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneObjectFocusOutEventArgs> ObjectFocusOutEvent
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
                        Efl.Canvas.SceneObjectFocusOutEventArgs args = new Efl.Canvas.SceneObjectFocusOutEventArgs();
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

                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ObjectFocusOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnObjectFocusOutEvent(Efl.Canvas.SceneObjectFocusOutEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_OBJECT_FOCUS_OUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when pre render happens
    /// (Since EFL 1.22)</summary>
    public event EventHandler RenderPreEvent
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

                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RenderPreEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRenderPreEvent(EventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_RENDER_PRE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when post render happens
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneRenderPostEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneRenderPostEventArgs> RenderPostEvent
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
                        Efl.Canvas.SceneRenderPostEventArgs args = new Efl.Canvas.SceneRenderPostEventArgs();
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

                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RenderPostEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRenderPostEvent(Efl.Canvas.SceneRenderPostEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_RENDER_POST";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
    /// <summary>Called when input device changed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneDeviceChangedEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneDeviceChangedEventArgs> DeviceChangedEvent
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
                        Efl.Canvas.SceneDeviceChangedEventArgs args = new Efl.Canvas.SceneDeviceChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDeviceChangedEvent(Efl.Canvas.SceneDeviceChangedEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when input device was added
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneDeviceAddedEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneDeviceAddedEventArgs> DeviceAddedEvent
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
                        Efl.Canvas.SceneDeviceAddedEventArgs args = new Efl.Canvas.SceneDeviceAddedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDeviceAddedEvent(Efl.Canvas.SceneDeviceAddedEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when input device was removed
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Canvas.SceneDeviceRemovedEventArgs"/></value>
    public event EventHandler<Efl.Canvas.SceneDeviceRemovedEventArgs> DeviceRemovedEvent
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
                        Efl.Canvas.SceneDeviceRemovedEventArgs args = new Efl.Canvas.SceneDeviceRemovedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Input.Device);
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

                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DeviceRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDeviceRemovedEvent(Efl.Canvas.SceneDeviceRemovedEventArgs e)
    {
        var key = "_EFL_CANVAS_SCENE_EVENT_DEVICE_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
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
    /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
    /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.
    /// (Since EFL 1.22)</summary>
    /// <returns>The type, one of <see cref="Efl.Ui.WinIndicatorMode"/>.</returns>
    public virtual Efl.Ui.WinIndicatorMode GetIndicatorMode() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_indicator_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
    /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.
    /// (Since EFL 1.22)</summary>
    /// <param name="type">The type, one of <see cref="Efl.Ui.WinIndicatorMode"/>.</param>
    public virtual void SetIndicatorMode(Efl.Ui.WinIndicatorMode type) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_indicator_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The keyboard mode of the window.
    /// (Since EFL 1.22)</summary>
    /// <returns>The mode, one of <see cref="Efl.Ui.WinKeyboardMode"/>.</returns>
    public virtual Efl.Ui.WinKeyboardMode GetKeyboardMode() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_keyboard_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The keyboard mode of the window.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">The mode, one of <see cref="Efl.Ui.WinKeyboardMode"/>.</param>
    public virtual void SetKeyboardMode(Efl.Ui.WinKeyboardMode mode) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_keyboard_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines which rotations this window supports.
    /// The window manager will refer to these hints and rotate the window accordingly, depending on the device orientation, for instance.
    /// (Since EFL 1.22)</summary>
    /// <param name="allow_0">Normal orientation.</param>
    /// <param name="allow_90">Rotated 90 degrees CCW.</param>
    /// <param name="allow_180">Rotated 180 degrees.</param>
    /// <param name="allow_270">Rotated 270 degrees CCW (i.e. 90 CW).</param>
    /// <returns>Returns <c>false</c> if available rotations were not specified.</returns>
    public virtual bool GetWmAvailableRotations(out bool allow_0, out bool allow_90, out bool allow_180, out bool allow_270) {
                                                                                                         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_wm_available_rotations_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out allow_0, out allow_90, out allow_180, out allow_270);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Defines which rotations this window supports.
    /// The window manager will refer to these hints and rotate the window accordingly, depending on the device orientation, for instance.
    /// (Since EFL 1.22)</summary>
    /// <param name="allow_0">Normal orientation.</param>
    /// <param name="allow_90">Rotated 90 degrees CCW.</param>
    /// <param name="allow_180">Rotated 180 degrees.</param>
    /// <param name="allow_270">Rotated 270 degrees CCW (i.e. 90 CW).</param>
    public virtual void SetWmAvailableRotations(bool allow_0, bool allow_90, bool allow_180, bool allow_270) {
                                                                                                         Efl.Ui.Win.NativeMethods.efl_ui_win_wm_available_rotations_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),allow_0, allow_90, allow_180, allow_270);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Available profiles on a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>A list of profiles.</returns>
    public virtual Eina.Array<System.String> GetWmAvailableProfiles() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_wm_available_profiles_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Array<System.String>(_ret_var, false, false);
 }
    /// <summary>Available profiles on a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="profiles">A list of profiles.</param>
    public virtual void SetWmAvailableProfiles(Eina.Array<System.String> profiles) {
         var _in_profiles = profiles.Handle;
                        Efl.Ui.Win.NativeMethods.efl_ui_win_wm_available_profiles_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_profiles);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Constrain the maximum width and height of a window to the width and height of the screen.
    /// When <c>constrain</c> is <c>true</c>, <c>obj</c> will never resize larger than the screen.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> to restrict the window&apos;s maximum size.</returns>
    public virtual bool GetScreenConstrain() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_screen_constrain_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Constrain the maximum width and height of a window to the width and height of the screen.
    /// When <c>constrain</c> is <c>true</c>, <c>obj</c> will never resize larger than the screen.
    /// (Since EFL 1.22)</summary>
    /// <param name="constrain"><c>true</c> to restrict the window&apos;s maximum size.</param>
    public virtual void SetScreenConstrain(bool constrain) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_screen_constrain_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),constrain);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the window to be skipped by keyboard focus.
    /// This sets the window to be skipped by normal keyboard input. This means a window manager will be asked not to focus this window as well as omit it from things like the taskbar, pager, &quot;alt-tab&quot; list etc. etc.
    /// 
    /// Call this and enable it on a window BEFORE you show it for the first time, otherwise it may have no effect.
    /// 
    /// Use this for windows that have only output information or might only be interacted with by the mouse or touchscreen, never for typing. This may have side-effects like making the window non-accessible in some cases unless the window is specially handled. Use this with care.
    /// (Since EFL 1.22)</summary>
    /// <param name="skip">The skip flag state (<c>true</c> if it is to be skipped).</param>
    public virtual void SetPropFocusSkip(bool skip) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_prop_focus_skip_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),skip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Window&apos;s autohide state.
    /// When closing the window in any way outside of the program control, like pressing the X button in the titlebar or using a command from the Window Manager, a &quot;delete,request&quot; signal is emitted to indicate that this event occurred and the developer can take any action, which may include, or not, destroying the window object.
    /// 
    /// When this property is set to <c>true</c>, the window will be automatically hidden when this event occurs, after the signal is emitted. If this property is <c>false</c> nothing will happen, beyond the event emission.
    /// 
    /// C applications can use this option along with the quit policy <c>ELM_POLICY_QUIT_LAST_WINDOW_HIDDEN</c> which allows exiting EFL&apos;s main loop when all the windows are hidden.
    /// 
    /// Note: <c>autodel</c> and <c>autohide</c> are not mutually exclusive. The window will be deleted if both are set to <c>true</c>.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window will automatically hide itself when closed.</returns>
    public virtual bool GetAutohide() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_autohide_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Window&apos;s autohide state.
    /// When closing the window in any way outside of the program control, like pressing the X button in the titlebar or using a command from the Window Manager, a &quot;delete,request&quot; signal is emitted to indicate that this event occurred and the developer can take any action, which may include, or not, destroying the window object.
    /// 
    /// When this property is set to <c>true</c>, the window will be automatically hidden when this event occurs, after the signal is emitted. If this property is <c>false</c> nothing will happen, beyond the event emission.
    /// 
    /// C applications can use this option along with the quit policy <c>ELM_POLICY_QUIT_LAST_WINDOW_HIDDEN</c> which allows exiting EFL&apos;s main loop when all the windows are hidden.
    /// 
    /// Note: <c>autodel</c> and <c>autohide</c> are not mutually exclusive. The window will be deleted if both are set to <c>true</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="autohide">If <c>true</c>, the window will automatically hide itself when closed.</param>
    public virtual void SetAutohide(bool autohide) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_autohide_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),autohide);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Enable quitting the main loop when this window is closed.
    /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.
    /// (Since EFL 1.22)</summary>
    /// <returns>The exit code to use when exiting</returns>
    public virtual Eina.Value GetExitOnClose() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_exit_on_close_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable quitting the main loop when this window is closed.
    /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.
    /// (Since EFL 1.22)</summary>
    /// <param name="exit_code">The exit code to use when exiting</param>
    public virtual void SetExitOnClose(Eina.Value exit_code) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_exit_on_close_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),exit_code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A window object&apos;s icon.
    /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <see cref="Efl.Canvas.Image"/> or <see cref="Efl.Ui.Image"/> are allowed.
    /// (Since EFL 1.22)</summary>
    /// <returns>The Evas image object to use for an icon.</returns>
    public virtual Efl.Canvas.Object GetIconObject() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_icon_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A window object&apos;s icon.
    /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <see cref="Efl.Canvas.Image"/> or <see cref="Efl.Ui.Image"/> are allowed.
    /// (Since EFL 1.22)</summary>
    /// <param name="icon">The image object to use for an icon.</param>
    public virtual void SetIconObject(Efl.Canvas.Object icon) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_icon_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),icon);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The minimized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window is minimized.</returns>
    public virtual bool GetMinimized() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_minimized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The minimized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="state">If <c>true</c>, the window is minimized.</param>
    public virtual void SetMinimized(bool state) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_minimized_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),state);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The maximized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window is maximized.</returns>
    public virtual bool GetMaximized() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_maximized_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The maximized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="maximized">If <c>true</c>, the window is maximized.</param>
    public virtual void SetMaximized(bool maximized) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_maximized_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),maximized);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The fullscreen state of a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window is fullscreen.</returns>
    public virtual bool GetFullscreen() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_fullscreen_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The fullscreen state of a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="fullscreen">If <c>true</c>, the window is fullscreen.</param>
    public virtual void SetFullscreen(bool fullscreen) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_fullscreen_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fullscreen);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The sticky state of the window.
    /// Hints the Window Manager that the window in <c>obj</c> should be left fixed at its position even when the virtual desktop it&apos;s on moves or changes.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window&apos;s sticky state is enabled.</returns>
    public virtual bool GetSticky() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_sticky_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The sticky state of the window.
    /// Hints the Window Manager that the window in <c>obj</c> should be left fixed at its position even when the virtual desktop it&apos;s on moves or changes.
    /// (Since EFL 1.22)</summary>
    /// <param name="sticky">If <c>true</c>, the window&apos;s sticky state is enabled.</param>
    public virtual void SetSticky(bool sticky) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_sticky_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sticky);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The urgent state of a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>The mode of a urgent window, one of <see cref="Efl.Ui.WinUrgentMode"/>.</returns>
    public virtual Efl.Ui.WinUrgentMode GetUrgent() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_urgent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The urgent state of a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="urgent">The mode of a urgent window, one of <see cref="Efl.Ui.WinUrgentMode"/>.</param>
    public virtual void SetUrgent(Efl.Ui.WinUrgentMode urgent) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_urgent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),urgent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The modal state of a window.
    /// (Since EFL 1.22)</summary>
    /// <returns>The mode of a window, one of <see cref="Efl.Ui.WinModalMode"/>.</returns>
    public virtual Efl.Ui.WinModalMode GetModal() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_modal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The modal state of a window.
    /// (Since EFL 1.22)</summary>
    /// <param name="modal">The mode of a window, one of <see cref="Efl.Ui.WinModalMode"/>.</param>
    public virtual void SetModal(Efl.Ui.WinModalMode modal) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_modal_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),modal);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The borderless state of a window.
    /// This function requests the Window Manager not to draw any decoration around the window.
    /// (Since EFL 1.22)</summary>
    /// <returns>If <c>true</c>, the window is borderless.</returns>
    public virtual bool GetBorderless() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_borderless_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The borderless state of a window.
    /// This function requests the Window Manager not to draw any decoration around the window.
    /// (Since EFL 1.22)</summary>
    /// <param name="borderless">If <c>true</c>, the window is borderless.</param>
    public virtual void SetBorderless(bool borderless) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_borderless_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),borderless);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The role of the window.
    /// It is a hint of how the Window Manager should handle it. Unlike <see cref="Efl.Ui.Win.WinType"/> and <see cref="Efl.Ui.Win.WinName"/> this can be changed at runtime.
    /// 
    /// The returned string is an internal one and should not be freed or modified. It will also be invalid if a new role is set or if the window is destroyed.
    /// (Since EFL 1.22)</summary>
    /// <returns>The role to set.</returns>
    public virtual System.String GetWinRole() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_role_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The role of the window.
    /// It is a hint of how the Window Manager should handle it. Unlike <see cref="Efl.Ui.Win.WinType"/> and <see cref="Efl.Ui.Win.WinName"/> this can be changed at runtime.
    /// 
    /// The returned string is an internal one and should not be freed or modified. It will also be invalid if a new role is set or if the window is destroyed.
    /// (Since EFL 1.22)</summary>
    /// <param name="role">The role to set.</param>
    public virtual void SetWinRole(System.String role) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_role_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),role);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The window name.
    /// The meaning of name depends on the underlying windowing system.
    /// 
    /// The window name is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
    /// 
    /// Note: Once set, it cannot be modified afterwards.
    /// (Since EFL 1.22)</summary>
    /// <returns>Window name</returns>
    public virtual System.String GetWinName() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name can only be set before finalize.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">Window name</param>
    public virtual void SetWinName(System.String name) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If the object is not window object, returns <c>unknown</c>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Window type</returns>
    public virtual Efl.Ui.WinType GetWinType() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type can on be set before finalize.
    /// (Since EFL 1.22)</summary>
    /// <param name="type">Window type</param>
    public virtual void SetWinType(Efl.Ui.WinType type) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This will return the value of &quot;accel_preference&quot; when the window was created.
    /// (Since EFL 1.22)</summary>
    /// <returns>Acceleration</returns>
    public virtual System.String GetAccelPreference() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_accel_preference_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The hardware acceleration preference for this window.
    /// This is a constructor function and can only be called before <see cref="Efl.Object.FinalizeAdd"/>.
    /// 
    /// This property overrides the global EFL configuration option &quot;accel_preference&quot; for this single window, and accepts the same syntax.
    /// 
    /// The <c>accel</c> string is a freeform C string that indicates what kind of acceleration is preferred. Here &quot;acceleration&quot; generally refers to rendering and the hardware with which the unit application renders GUIs. This may or may not be honored but a best attempt will be made. Known strings are as follows:
    /// 
    /// &quot;gl&quot;, &quot;opengl&quot; - try use OpenGL. &quot;3d&quot; - try to use a 3d acceleration unit. &quot;hw&quot;, &quot;hardware&quot;, &quot;accel&quot; - try any acceleration unit (best possible) &quot;none&quot; - use no acceleration but software instead (since 1.16)
    /// 
    /// Since 1.14, it is also possible to specify some GL properties for the GL window surface. This allows applications to use GLView with depth, stencil and MSAA buffers with direct rendering. The new accel preference string format is thus &quot;{HW Accel}[:depth{value}[:stencil{value}[:msaa{str}$]$]$]&quot;.
    /// 
    /// Accepted values for depth are for instance &quot;depth&quot;, &quot;depth16&quot;, &quot;depth24&quot;. Accepted values for stencil are &quot;stencil&quot;, &quot;stencil1&quot;, &quot;stencil8&quot;. For MSAA, only predefined strings are accepted: &quot;msaa&quot;, &quot;msaa_low&quot;, &quot;msaa_mid&quot; and &quot;msaa_high&quot;. The selected configuration is not guaranteed and is only valid in case of GL acceleration. Only the base acceleration string will be saved (e.g. &quot;gl&quot; or &quot;hw&quot;).
    /// 
    /// Full examples include:
    /// 
    /// &quot;gl&quot;, - try to use OpenGL &quot;hw:depth:stencil&quot;, - use HW acceleration with default depth and stencil buffers &quot;opengl:depth24:stencil8:msaa_mid&quot; - use OpenGL with 24-bit depth, 8-bit stencil and a medium number of MSAA samples in the backbuffer.
    /// 
    /// Note that this option may be overriden by environment variables or the configuration option &quot;accel_preference_override&quot;.
    /// (Since EFL 1.22)</summary>
    /// <param name="accel">Acceleration</param>
    public virtual void SetAccelPreference(System.String accel) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_accel_preference_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),accel);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The alpha channel state of a window.
    /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
    /// 
    /// Note: Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</returns>
    public virtual bool GetAlpha() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The alpha channel state of a window.
    /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
    /// 
    /// Note: Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.
    /// (Since EFL 1.22)</summary>
    /// <param name="alpha"><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</param>
    public virtual void SetAlpha(bool alpha) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),alpha);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the stack ID string of the window as an opaque string.
    /// This ID is immutable and can never be modified. It will be an opaque string that has no specific defined format or content other than being a string (no character with a value of 0).
    /// 
    /// This string is intended for use as a stack master ID to be use by other windows to make this window part of a stack of windows to be placed on top of each other as if they are a series of dialogs or questions one after the other, allowing you to go back through history.
    /// (Since EFL 1.22)</summary>
    /// <returns>An opaque string that has no specific format but identifies a specific unique window on the display.</returns>
    public virtual System.String GetStackId() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_stack_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The window stack ID to use as the master top-level.
    /// This sets the ID string to be used as the master top-level window as the base of a stack of windows. This must be set before the first time the window is shown and should never be changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <returns>An opaque string that has no specific format, but identifies a specific unique window on the display.</returns>
    public virtual System.String GetStackMasterId() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_stack_master_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The window stack ID to use as the master top-level.
    /// This sets the ID string to be used as the master top-level window as the base of a stack of windows. This must be set before the first time the window is shown and should never be changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <param name="id">An opaque string that has no specific format, but identifies a specific unique window on the display.</param>
    public virtual void SetStackMasterId(System.String id) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_stack_master_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The stack base state of this window
    /// This is a boolean flag that determines if this window will become the base of a stack at all. You must enable this on a base (the bottom of a window stack) for things to work correctly.
    /// 
    /// This state should be set before a window is shown for the first time and never changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if this is a stack base window, <c>false</c> otherwise.</returns>
    public virtual bool GetStackBase() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_stack_base_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The stack base state of this window
    /// This is a boolean flag that determines if this window will become the base of a stack at all. You must enable this on a base (the bottom of a window stack) for things to work correctly.
    /// 
    /// This state should be set before a window is shown for the first time and never changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_base"><c>true</c> if this is a stack base window, <c>false</c> otherwise.</param>
    public virtual void SetStackBase(bool kw_base) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_stack_base_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_base);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Enable quitting the main loop when all windows are closed.
    /// When set, the main loop will quit with the passed exit code once all windows have been closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnClose"/> which exits when a given window is closed.
    /// (Since EFL 1.22)</summary>
    /// <returns>The exit code to use when exiting.</returns>
    public static Eina.Value GetExitOnAllWindowsClosed() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_exit_on_all_windows_closed_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable quitting the main loop when all windows are closed.
    /// When set, the main loop will quit with the passed exit code once all windows have been closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnClose"/> which exits when a given window is closed.
    /// (Since EFL 1.22)</summary>
    /// <param name="exit_code">The exit code to use when exiting.</param>
    public static void SetExitOnAllWindowsClosed(Eina.Value exit_code) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_exit_on_all_windows_closed_set_ptr.Value.Delegate(exit_code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Base size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// 
    /// See also <see cref="Efl.Ui.Win.HintStep"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Base size (hint) in pixels.</returns>
    public virtual Eina.Size2D GetHintBase() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_hint_base_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Base size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// 
    /// See also <see cref="Efl.Ui.Win.HintStep"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Base size (hint) in pixels.</param>
    public virtual void SetHintBase(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Ui.Win.NativeMethods.efl_ui_win_hint_base_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Step size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Set this to for an object to scale up by steps and not continuously.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// (Since EFL 1.22)</summary>
    /// <returns>Step size (hint) in pixels.</returns>
    public virtual Eina.Size2D GetHintStep() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_hint_step_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Step size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Set this to for an object to scale up by steps and not continuously.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// (Since EFL 1.22)</summary>
    /// <param name="sz">Step size (hint) in pixels.</param>
    public virtual void SetHintStep(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Ui.Win.NativeMethods.efl_ui_win_hint_step_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The rotation of this window
    /// The value will automatically change when the Window Manager of this window changes its rotation. This rotation is automatically applied to all <see cref="Efl.Ui.Layout"/> objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>The rotation of the window</returns>
    public virtual int GetWinRotation() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_rotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The rotation of this window
    /// The value will automatically change when the Window Manager of this window changes its rotation. This rotation is automatically applied to all <see cref="Efl.Ui.Layout"/> objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="rotation">The rotation of the window</param>
    public virtual void SetWinRotation(int rotation) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_rotation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),rotation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the enabled value of the focus highlight for this window.
    /// (Since EFL 1.22)</summary>
    /// <returns>The enabled value for the highlight.</returns>
    public virtual bool GetFocusHighlightEnabled() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the enabled status for the focus highlight in a window.
    /// This function will enable or disable the focus highlight, regardless of the global setting for it.
    /// (Since EFL 1.22)</summary>
    /// <param name="enabled">The enabled value for the highlight.</param>
    public virtual void SetFocusHighlightEnabled(bool enabled) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the widget focus highlight style.
    /// If <c>style</c> is <c>null</c>, the default will be used.
    /// 
    /// See also <see cref="Efl.Ui.Win.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Win.FocusHighlightAnimate"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The name of the focus highlight style.</returns>
    public virtual System.String GetFocusHighlightStyle() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the widget focus highlight style.
    /// If <c>style</c> is <c>null</c>, the default will be used.
    /// 
    /// See also <see cref="Efl.Ui.Win.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Win.FocusHighlightAnimate"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="style">The name of the focus highlight style.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool SetFocusHighlightStyle(System.String style) {
                                 var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the animate value of the focus highlight for this window.
    /// (Since EFL 1.22)</summary>
    /// <returns>The enabled value for the highlight animation.</returns>
    public virtual bool GetFocusHighlightAnimate() {
         var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_animate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the animate status for the focus highlight for this window.
    /// This function will enable or disable the animation of focus highlight.
    /// (Since EFL 1.22)</summary>
    /// <param name="animate">The enabled value for the highlight animation.</param>
    public virtual void SetFocusHighlightAnimate(bool animate) {
                                 Efl.Ui.Win.NativeMethods.efl_ui_win_focus_highlight_animate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),animate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Pop (delete) all windows in the stack above this window.
    /// This will try and delete all the windows in the stack that are above the window.
    /// (Since EFL 1.22)</summary>
    public virtual void StackPopTo() {
         Efl.Ui.Win.NativeMethods.efl_ui_win_stack_pop_to_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Activate a window object.
    /// This function sends a request to the Window Manager to activate the window pointed by <c>obj</c>. If honored by the WM, the window will receive the keyboard focus.
    /// 
    /// Note: This is just a request that a Window Manager may ignore, so calling this function does not ensure in any way that the window will be the active one afterwards.
    /// (Since EFL 1.22)</summary>
    public virtual void Activate() {
         Efl.Ui.Win.NativeMethods.efl_ui_win_activate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Center a window on the screen.
    /// This function centers window <c>obj</c> horizontally and/or vertically based on the values of <c>h</c> and <c>v</c>.
    /// 
    /// Note: This is just a request that a Window Manager may ignore, so calling this function does not ensure in any way that the window will be centered afterwards.
    /// (Since EFL 1.22)</summary>
    /// <param name="h">If <c>true</c>, center horizontally. If <c>false</c>, do not change horizontal location.</param>
    /// <param name="v">If <c>true</c>, center vertically. If <c>false</c>, do not change vertical location.</param>
    public virtual void Center(bool h, bool v) {
                                                         Efl.Ui.Win.NativeMethods.efl_ui_win_center_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),h, v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Start moving or resizing the window.
    /// The user can request the display server to start moving or resizing the window by combining modes from <see cref="Efl.Ui.WinMoveResizeMode"/>. This API can only be called if none of the following conditions is true:
    /// 
    /// 1. Called in the absence of a pointer down event, 2. Called more than once before a pointer up event, 3. Called when the window is already being resized or moved, 4. Called with an unsupported combination of modes.
    /// 
    /// Right usage: 1. Pointer (mouse or touch) down event, 2. <see cref="Efl.Ui.Win.MoveResizeStart"/> called only once with a supported mode, 3. Pointer (mouse or touch) up event.
    /// 
    /// If a pointer up event occurs after calling the function, it automatically ends the window move and resize operation.
    /// 
    /// Currently, only the following 9 combinations are allowed, and possibly more combinations may be added in the future: 1. <see cref="Efl.Ui.WinMoveResizeMode.Move"/> 2. <see cref="Efl.Ui.WinMoveResizeMode.Top"/> 3. <see cref="Efl.Ui.WinMoveResizeMode.Bottom"/> 4. <see cref="Efl.Ui.WinMoveResizeMode.Left"/> 5. <see cref="Efl.Ui.WinMoveResizeMode.Right"/> 6. <see cref="Efl.Ui.WinMoveResizeMode.Top"/> | <see cref="Efl.Ui.WinMoveResizeMode.Left"/> 7. <see cref="Efl.Ui.WinMoveResizeMode.Top"/> | <see cref="Efl.Ui.WinMoveResizeMode.Right"/> 8. <see cref="Efl.Ui.WinMoveResizeMode.Bottom"/> | <see cref="Efl.Ui.WinMoveResizeMode.Left"/> 9. <see cref="Efl.Ui.WinMoveResizeMode.Bottom"/> | <see cref="Efl.Ui.WinMoveResizeMode.Right"/>
    /// 
    /// In particular move and resize cannot happen simultaneously.
    /// 
    /// Note: the result of this API can only guarantee that the request has been forwarded to the server, but there is no guarantee that the request can be processed by the display server.
    /// (Since EFL 1.22)</summary>
    /// <param name="mode">The requested move or resize mode.</param>
    /// <returns><c>true</c> if the request was successfully sent to the display server, <c>false</c> in case of error.</returns>
    public virtual bool MoveResizeStart(Efl.Ui.WinMoveResizeMode mode) {
                                 var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_move_resize_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns an iterator over the current known pointer positions.
    /// This is used to iterate over the current known multi-touch positions, including the first finger. Each pointer position is represented by an object of type <see cref="Efl.Input.Pointer"/>.
    /// 
    /// Each finger in a multi touch environment can then be identified by the <see cref="Efl.Input.Pointer.TouchId"/> property. The order of the pointers in this iterator is not defined.
    /// 
    /// Note: If the input surface supports hovering input, some pointers may not be in a &quot;down&quot; state. To retrieve the list of such pointers, set the <c>hover</c> value to <c>true</c>. Remember though that most devices currently don&apos;t support this.
    /// (Since EFL 1.22)</summary>
    /// <param name="hover"><c>false</c> by default, <c>true</c> means to include fingers that are currently hovering.</param>
    /// <returns>Iterator to pointer positions</returns>
    public virtual Eina.Iterator<Efl.Input.Pointer> PointerIterate(bool hover) {
                                 var _ret_var = Efl.Ui.Win.NativeMethods.efl_ui_win_pointer_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hover);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Input.Pointer>(_ret_var, false);
 }
    /// <summary>A generic configuration value, referred to by name.</summary>
    /// <param name="name">Configuration option name.</param>
    /// <returns>The value. It will be empty if it doesn&apos;t exist. The caller must free it after use (using <c>eina_value_free</c>() in C).</returns>
    public virtual Eina.Value GetConfig(System.String name) {
                                 var _ret_var = Efl.ConfigConcrete.NativeMethods.efl_config_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>A generic configuration value, referred to by name.</summary>
    /// <param name="name">Configuration option name.</param>
    /// <param name="value">Configuration option value. May be <c>null</c> if not found.</param>
    /// <returns><c>false</c> in case of error: value type was invalid, the config can&apos;t be changed, config does not exist...</returns>
    public virtual bool SetConfig(System.String name, Eina.Value value) {
                                                         var _ret_var = Efl.ConfigConcrete.NativeMethods.efl_config_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, value);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
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
    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <returns>The screen size in pixels.</returns>
    public virtual Eina.Size2D GetScreenSizeInPixels() {
         var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_size_in_pixels_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <returns>The screen scaling factor.</returns>
    public virtual float GetScreenScaleFactor() {
         var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_scale_factor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.
    /// (Since EFL 1.22)</summary>
    /// <returns>Screen rotation in degrees.</returns>
    public virtual int GetScreenRotation() {
         var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_rotation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.
    /// (Since EFL 1.22)</summary>
    /// <param name="xdpi">Horizontal DPI.</param>
    /// <param name="ydpi">Vertical DPI.</param>
    public virtual void GetScreenDpi(out int xdpi, out int ydpi) {
                                                         Efl.ScreenConcrete.NativeMethods.efl_screen_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out xdpi, out ydpi);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
         var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetText(System.String text) {
                                 Efl.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The maximum image size the canvas can possibly handle.
    /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
    /// 
    /// The default limit is 65535x65535.
    /// (Since EFL 1.22)</summary>
    /// <param name="max">The maximum image size (in pixels).</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool GetImageMaxSize(out Eina.Size2D max) {
                 var _out_max = new Eina.Size2D.NativeStruct();
                var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_image_max_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_max);
        Eina.Error.RaiseIfUnhandledException();
        max = _out_max;
                return _ret_var;
 }
    /// <summary>Get if the canvas is currently calculating group objects.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if currently calculating group objects.</returns>
    public virtual bool GetGroupObjectsCalculating() {
         var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_group_objects_calculating_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get a device by name.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="name">The name of the seat to find.</param>
    /// <returns>The device or seat, <c>null</c> if not found.</returns>
    public virtual Efl.Input.Device GetDevice(System.String name) {
                                 var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get a seat by id.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="id">The id of the seat to find.</param>
    /// <returns>The seat or <c>null</c> if not found.</returns>
    public virtual Efl.Input.Device GetSeat(int id) {
                                 var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_seat_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the default seat.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>The default seat or <c>null</c> if one does not exist.</returns>
    public virtual Efl.Input.Device GetSeatDefault() {
         var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_seat_default_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The current known pointer coordinates.
    /// This function returns the current position of the main input pointer (mouse, pen, etc...).
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="seat">The seat, or <c>null</c> to use the default.</param>
    /// <param name="pos">The pointer position in pixels.</param>
    /// <returns><c>true</c> if a pointer exists for the given seat, otherwise <c>false</c>.</returns>
    public virtual bool GetPointerPosition(Efl.Input.Device seat, out Eina.Position2D pos) {
                                 var _out_pos = new Eina.Position2D.NativeStruct();
                        var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_pointer_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat, out _out_pos);
        Eina.Error.RaiseIfUnhandledException();
                pos = _out_pos;
                        return _ret_var;
 }
    /// <summary>Call user-provided <c>calculate</c> group functions and unset the flag signalling that the object needs to get recalculated to all group objects in the canvas.
    /// (Since EFL 1.22)</summary>
    public virtual void CalculateGroupObjects() {
         Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_group_objects_calculate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Retrieve a list of objects at a given position in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">The pixel position.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> GetObjectsAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                                                                        var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_objects_at_xy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">The pixel position.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The canvas object that is over all other objects at the given position.</returns>
    public virtual Efl.Gfx.IEntity GetObjectTopAtXy(Eina.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                                                                        var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_object_top_at_xy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Retrieve a list of objects overlapping a given rectangular region in a canvas.
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The rectangular region.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>Iterator to objects</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> GetObjectsInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                                        var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_objects_in_rectangle_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Retrieve the canvas object stacked at the top of a given rectangular region in a canvas
    /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
    /// 
    /// Warning: This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The rectangular region.</param>
    /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
    /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
    /// <returns>The object that is over all other objects at the given rectangular region.</returns>
    public virtual Efl.Gfx.IEntity GetObjectTopInRectangle(Eina.Rect rect, bool include_pass_events_objects, bool include_hidden_objects) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                                        var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_object_top_in_rectangle_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, include_pass_events_objects, include_hidden_objects);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Iterate over the available input device seats for the canvas.
    /// A &quot;seat&quot; is the term used for a group of input devices, typically including a pointer and a keyboard. A seat object is the parent of the individual input devices.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <returns>An iterator over the attached seats.</returns>
    public virtual Eina.Iterator<Efl.Input.Device> Seats() {
         var _ret_var = Efl.Canvas.SceneConcrete.NativeMethods.efl_canvas_scene_seats_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Input.Device>(_ret_var, true);
 }
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    public virtual bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mod, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    public virtual bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_lock, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
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
    /// <summary>In some environments you may have an indicator that shows battery status, reception, time etc. This is the indicator.
    /// Sometimes you don&apos;t want this because you provide the same functionality inside your app, so this will request that the indicator is disabled in such circumstances. The default settings depends on the environment. For example, on phones, the default is to enable the indicator. The indicator is disabled on devices like televisions however.
    /// (Since EFL 1.22)</summary>
    /// <value>The type, one of <see cref="Efl.Ui.WinIndicatorMode"/>.</value>
    public Efl.Ui.WinIndicatorMode IndicatorMode {
        get { return GetIndicatorMode(); }
        set { SetIndicatorMode(value); }
    }
    /// <summary>The keyboard mode of the window.
    /// (Since EFL 1.22)</summary>
    /// <value>The mode, one of <see cref="Efl.Ui.WinKeyboardMode"/>.</value>
    public Efl.Ui.WinKeyboardMode KeyboardMode {
        get { return GetKeyboardMode(); }
        set { SetKeyboardMode(value); }
    }
    /// <summary>Defines which rotations this window supports.
    /// The window manager will refer to these hints and rotate the window accordingly, depending on the device orientation, for instance.
    /// (Since EFL 1.22)</summary>
    /// <value>Normal orientation.</value>
    public (bool, bool, bool, bool) WmAvailableRotations {
        get {
            bool _out_allow_0 = default(bool);
            bool _out_allow_90 = default(bool);
            bool _out_allow_180 = default(bool);
            bool _out_allow_270 = default(bool);
            GetWmAvailableRotations(out _out_allow_0,out _out_allow_90,out _out_allow_180,out _out_allow_270);
            return (_out_allow_0,_out_allow_90,_out_allow_180,_out_allow_270);
        }
        set { SetWmAvailableRotations( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Available profiles on a window.
    /// (Since EFL 1.22)</summary>
    /// <value>A list of profiles.</value>
    public Eina.Array<System.String> WmAvailableProfiles {
        get { return GetWmAvailableProfiles(); }
        set { SetWmAvailableProfiles(value); }
    }
    /// <summary>Constrain the maximum width and height of a window to the width and height of the screen.
    /// When <c>constrain</c> is <c>true</c>, <c>obj</c> will never resize larger than the screen.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> to restrict the window&apos;s maximum size.</value>
    public bool ScreenConstrain {
        get { return GetScreenConstrain(); }
        set { SetScreenConstrain(value); }
    }
    /// <summary>Set the window to be skipped by keyboard focus.
    /// This sets the window to be skipped by normal keyboard input. This means a window manager will be asked not to focus this window as well as omit it from things like the taskbar, pager, &quot;alt-tab&quot; list etc. etc.
    /// 
    /// Call this and enable it on a window BEFORE you show it for the first time, otherwise it may have no effect.
    /// 
    /// Use this for windows that have only output information or might only be interacted with by the mouse or touchscreen, never for typing. This may have side-effects like making the window non-accessible in some cases unless the window is specially handled. Use this with care.
    /// (Since EFL 1.22)</summary>
    /// <value>The skip flag state (<c>true</c> if it is to be skipped).</value>
    public bool PropFocusSkip {
        set { SetPropFocusSkip(value); }
    }
    /// <summary>Window&apos;s autohide state.
    /// When closing the window in any way outside of the program control, like pressing the X button in the titlebar or using a command from the Window Manager, a &quot;delete,request&quot; signal is emitted to indicate that this event occurred and the developer can take any action, which may include, or not, destroying the window object.
    /// 
    /// When this property is set to <c>true</c>, the window will be automatically hidden when this event occurs, after the signal is emitted. If this property is <c>false</c> nothing will happen, beyond the event emission.
    /// 
    /// C applications can use this option along with the quit policy <c>ELM_POLICY_QUIT_LAST_WINDOW_HIDDEN</c> which allows exiting EFL&apos;s main loop when all the windows are hidden.
    /// 
    /// Note: <c>autodel</c> and <c>autohide</c> are not mutually exclusive. The window will be deleted if both are set to <c>true</c>.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window will automatically hide itself when closed.</value>
    public bool Autohide {
        get { return GetAutohide(); }
        set { SetAutohide(value); }
    }
    /// <summary>Enable quitting the main loop when this window is closed.
    /// When set, the window&apos;s loop object will exit using the passed exit code if the window is closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnAllWindowsClosed"/> which exits when ALL windows are closed.
    /// (Since EFL 1.22)</summary>
    /// <value>The exit code to use when exiting</value>
    public Eina.Value ExitOnClose {
        get { return GetExitOnClose(); }
        set { SetExitOnClose(value); }
    }
    /// <summary>A window object&apos;s icon.
    /// This sets an image to be used as the icon for the given window, in the window manager decoration part. The exact pixel dimensions of the object (not object size) will be used and the image pixels will be used as-is when this function is called. If the image object has been updated, then call this function again to source the image pixels and place them in the window&apos;s icon. Note that only objects of type <see cref="Efl.Canvas.Image"/> or <see cref="Efl.Ui.Image"/> are allowed.
    /// (Since EFL 1.22)</summary>
    /// <value>The image object to use for an icon.</value>
    public Efl.Canvas.Object IconObject {
        get { return GetIconObject(); }
        set { SetIconObject(value); }
    }
    /// <summary>The minimized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window is minimized.</value>
    public bool Minimized {
        get { return GetMinimized(); }
        set { SetMinimized(value); }
    }
    /// <summary>The maximized state of a window.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window is maximized.</value>
    public bool Maximized {
        get { return GetMaximized(); }
        set { SetMaximized(value); }
    }
    /// <summary>The fullscreen state of a window.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window is fullscreen.</value>
    public bool Fullscreen {
        get { return GetFullscreen(); }
        set { SetFullscreen(value); }
    }
    /// <summary>The sticky state of the window.
    /// Hints the Window Manager that the window in <c>obj</c> should be left fixed at its position even when the virtual desktop it&apos;s on moves or changes.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window&apos;s sticky state is enabled.</value>
    public bool Sticky {
        get { return GetSticky(); }
        set { SetSticky(value); }
    }
    /// <summary>The urgent state of a window.
    /// (Since EFL 1.22)</summary>
    /// <value>The mode of a urgent window, one of <see cref="Efl.Ui.WinUrgentMode"/>.</value>
    public Efl.Ui.WinUrgentMode Urgent {
        get { return GetUrgent(); }
        set { SetUrgent(value); }
    }
    /// <summary>The modal state of a window.
    /// (Since EFL 1.22)</summary>
    /// <value>The mode of a window, one of <see cref="Efl.Ui.WinModalMode"/>.</value>
    public Efl.Ui.WinModalMode Modal {
        get { return GetModal(); }
        set { SetModal(value); }
    }
    /// <summary>The borderless state of a window.
    /// This function requests the Window Manager not to draw any decoration around the window.
    /// (Since EFL 1.22)</summary>
    /// <value>If <c>true</c>, the window is borderless.</value>
    public bool Borderless {
        get { return GetBorderless(); }
        set { SetBorderless(value); }
    }
    /// <summary>The role of the window.
    /// It is a hint of how the Window Manager should handle it. Unlike <see cref="Efl.Ui.Win.WinType"/> and <see cref="Efl.Ui.Win.WinName"/> this can be changed at runtime.
    /// 
    /// The returned string is an internal one and should not be freed or modified. It will also be invalid if a new role is set or if the window is destroyed.
    /// (Since EFL 1.22)</summary>
    /// <value>The role to set.</value>
    public System.String WinRole {
        get { return GetWinRole(); }
        set { SetWinRole(value); }
    }
    /// <summary>The window name.
    /// The meaning of name depends on the underlying windowing system.
    /// 
    /// The window name is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
    /// 
    /// Note: Once set, it cannot be modified afterwards.
    /// (Since EFL 1.22)</summary>
    /// <value>Window name</value>
    public System.String WinName {
        get { return GetWinName(); }
        set { SetWinName(value); }
    }
    /// <summary>The type of the window.
    /// It is a hint of how the Window Manager should handle it.
    /// 
    /// The window type is a construction property that can only be set at creation time, before finalize. In C this means inside <c>efl_add</c>().
    /// 
    /// Note: Once set, it cannot be modified afterward.
    /// (Since EFL 1.22)</summary>
    /// <value>Window type</value>
    public Efl.Ui.WinType WinType {
        get { return GetWinType(); }
        set { SetWinType(value); }
    }
    /// <summary>The hardware acceleration preference for this window.
    /// This is a constructor function and can only be called before <see cref="Efl.Object.FinalizeAdd"/>.
    /// 
    /// This property overrides the global EFL configuration option &quot;accel_preference&quot; for this single window, and accepts the same syntax.
    /// 
    /// The <c>accel</c> string is a freeform C string that indicates what kind of acceleration is preferred. Here &quot;acceleration&quot; generally refers to rendering and the hardware with which the unit application renders GUIs. This may or may not be honored but a best attempt will be made. Known strings are as follows:
    /// 
    /// &quot;gl&quot;, &quot;opengl&quot; - try use OpenGL. &quot;3d&quot; - try to use a 3d acceleration unit. &quot;hw&quot;, &quot;hardware&quot;, &quot;accel&quot; - try any acceleration unit (best possible) &quot;none&quot; - use no acceleration but software instead (since 1.16)
    /// 
    /// Since 1.14, it is also possible to specify some GL properties for the GL window surface. This allows applications to use GLView with depth, stencil and MSAA buffers with direct rendering. The new accel preference string format is thus &quot;{HW Accel}[:depth{value}[:stencil{value}[:msaa{str}$]$]$]&quot;.
    /// 
    /// Accepted values for depth are for instance &quot;depth&quot;, &quot;depth16&quot;, &quot;depth24&quot;. Accepted values for stencil are &quot;stencil&quot;, &quot;stencil1&quot;, &quot;stencil8&quot;. For MSAA, only predefined strings are accepted: &quot;msaa&quot;, &quot;msaa_low&quot;, &quot;msaa_mid&quot; and &quot;msaa_high&quot;. The selected configuration is not guaranteed and is only valid in case of GL acceleration. Only the base acceleration string will be saved (e.g. &quot;gl&quot; or &quot;hw&quot;).
    /// 
    /// Full examples include:
    /// 
    /// &quot;gl&quot;, - try to use OpenGL &quot;hw:depth:stencil&quot;, - use HW acceleration with default depth and stencil buffers &quot;opengl:depth24:stencil8:msaa_mid&quot; - use OpenGL with 24-bit depth, 8-bit stencil and a medium number of MSAA samples in the backbuffer.
    /// 
    /// Note that this option may be overriden by environment variables or the configuration option &quot;accel_preference_override&quot;.
    /// (Since EFL 1.22)</summary>
    /// <value>Acceleration</value>
    public System.String AccelPreference {
        get { return GetAccelPreference(); }
        set { SetAccelPreference(value); }
    }
    /// <summary>The alpha channel state of a window.
    /// If <c>alpha</c> is true, the alpha channel of the canvas will be enabled possibly making parts of the window completely or partially transparent. This is also subject to the underlying system supporting it, for example a system using a compositing manager.
    /// 
    /// Note: Alpha window can be enabled automatically by window theme style&apos;s property. If &quot;alpha&quot; data.item is &quot;1&quot; or &quot;true&quot; in window style(eg. elm/win/base/default), the window is switched to alpha automatically without the explicit api call.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the window alpha channel is enabled, <c>false</c> otherwise.</value>
    public bool Alpha {
        get { return GetAlpha(); }
        set { SetAlpha(value); }
    }
    /// <summary>Get the stack ID string of the window as an opaque string.
    /// This ID is immutable and can never be modified. It will be an opaque string that has no specific defined format or content other than being a string (no character with a value of 0).
    /// 
    /// This string is intended for use as a stack master ID to be use by other windows to make this window part of a stack of windows to be placed on top of each other as if they are a series of dialogs or questions one after the other, allowing you to go back through history.
    /// (Since EFL 1.22)</summary>
    /// <value>An opaque string that has no specific format but identifies a specific unique window on the display.</value>
    public System.String StackId {
        get { return GetStackId(); }
    }
    /// <summary>The window stack ID to use as the master top-level.
    /// This sets the ID string to be used as the master top-level window as the base of a stack of windows. This must be set before the first time the window is shown and should never be changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <value>An opaque string that has no specific format, but identifies a specific unique window on the display.</value>
    public System.String StackMasterId {
        get { return GetStackMasterId(); }
        set { SetStackMasterId(value); }
    }
    /// <summary>The stack base state of this window
    /// This is a boolean flag that determines if this window will become the base of a stack at all. You must enable this on a base (the bottom of a window stack) for things to work correctly.
    /// 
    /// This state should be set before a window is shown for the first time and never changed afterwards.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if this is a stack base window, <c>false</c> otherwise.</value>
    public bool StackBase {
        get { return GetStackBase(); }
        set { SetStackBase(value); }
    }
    /// <summary>Enable quitting the main loop when all windows are closed.
    /// When set, the main loop will quit with the passed exit code once all windows have been closed.
    /// 
    /// The <see cref="Eina.Value"/> passed should be <c>EMPTY</c> to unset this state or an int value to be used as the exit code.
    /// 
    /// Note this is different from <see cref="Efl.Ui.Win.ExitOnClose"/> which exits when a given window is closed.
    /// (Since EFL 1.22)</summary>
    /// <value>The exit code to use when exiting.</value>
    public static Eina.Value ExitOnAllWindowsClosed {
        get { return GetExitOnAllWindowsClosed(); }
        set { SetExitOnAllWindowsClosed(value); }
    }
    /// <summary>Base size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// 
    /// See also <see cref="Efl.Ui.Win.HintStep"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>Base size (hint) in pixels.</value>
    public Eina.Size2D HintBase {
        get { return GetHintBase(); }
        set { SetHintBase(value); }
    }
    /// <summary>Step size for objects with sizing restrictions.
    /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
    /// 
    /// Set this to for an object to scale up by steps and not continuously.
    /// 
    /// <see cref="Efl.Ui.Win.HintBase"/> + N x <see cref="Efl.Ui.Win.HintStep"/> is what is calculated for object sizing restrictions.
    /// (Since EFL 1.22)</summary>
    /// <value>Step size (hint) in pixels.</value>
    public Eina.Size2D HintStep {
        get { return GetHintStep(); }
        set { SetHintStep(value); }
    }
    /// <summary>The rotation of this window
    /// The value will automatically change when the Window Manager of this window changes its rotation. This rotation is automatically applied to all <see cref="Efl.Ui.Layout"/> objects.
    /// (Since EFL 1.22)</summary>
    /// <value>The rotation of the window</value>
    public int WinRotation {
        get { return GetWinRotation(); }
        set { SetWinRotation(value); }
    }
    /// <summary>Whether focus highlight is enabled or not.
    /// See also <see cref="Efl.Ui.Win.FocusHighlightStyle"/>. See also <see cref="Efl.Ui.Win.FocusHighlightAnimate"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The enabled value for the highlight.</value>
    public bool FocusHighlightEnabled {
        get { return GetFocusHighlightEnabled(); }
        set { SetFocusHighlightEnabled(value); }
    }
    /// <summary>Control the widget focus highlight style.
    /// If <c>style</c> is <c>null</c>, the default will be used.
    /// 
    /// See also <see cref="Efl.Ui.Win.FocusHighlightEnabled"/>. See also <see cref="Efl.Ui.Win.FocusHighlightAnimate"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The name of the focus highlight style.</value>
    public System.String FocusHighlightStyle {
        get { return GetFocusHighlightStyle(); }
        set { SetFocusHighlightStyle(value); }
    }
    /// <summary>Whether focus highlight should animate or not.
    /// See also <see cref="Efl.Ui.Win.FocusHighlightStyle"/>. See also <see cref="Efl.Ui.Win.FocusHighlightEnabled"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>The enabled value for the highlight animation.</value>
    public bool FocusHighlightAnimate {
        get { return GetFocusHighlightAnimate(); }
        set { SetFocusHighlightAnimate(value); }
    }
    /// <summary>Sub-object currently set as this object&apos;s single content.
    /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).
    /// (Since EFL 1.22)</summary>
    /// <value>The sub-object.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent(value); }
    }
    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <value>The screen size in pixels.</value>
    public Eina.Size2D ScreenSizeInPixels {
        get { return GetScreenSizeInPixels(); }
    }
    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <value>The screen scaling factor.</value>
    public float ScreenScaleFactor {
        get { return GetScreenScaleFactor(); }
    }
    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.
    /// (Since EFL 1.22)</summary>
    /// <value>Screen rotation in degrees.</value>
    public int ScreenRotation {
        get { return GetScreenRotation(); }
    }
    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.
    /// (Since EFL 1.22)</summary>
    public (int, int) ScreenDpi {
        get {
            int _out_xdpi = default(int);
            int _out_ydpi = default(int);
            GetScreenDpi(out _out_xdpi,out _out_ydpi);
            return (_out_xdpi,_out_ydpi);
        }
    }
    /// <summary>The maximum image size the canvas can possibly handle.
    /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
    /// 
    /// The default limit is 65535x65535.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> on success, <c>false</c> otherwise</value>
    public Eina.Size2D ImageMaxSize {
        get {
            Eina.Size2D _out_max = default(Eina.Size2D);
            GetImageMaxSize(out _out_max);
            return (_out_max);
        }
    }
    /// <summary>Get if the canvas is currently calculating group objects.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if currently calculating group objects.</value>
    public bool GroupObjectsCalculating {
        get { return GetGroupObjectsCalculating(); }
    }
    /// <summary>Get the default seat attached to this canvas.
    /// A canvas may have exactly one default seat.
    /// 
    /// See also <see cref="Efl.Canvas.IScene.GetDevice"/> to find a seat by name. See also <see cref="Efl.Canvas.IScene.GetSeat"/> to find a seat by id.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA property</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <value>The default seat or <c>null</c> if one does not exist.</value>
    public Efl.Input.Device SeatDefault {
        get { return GetSeatDefault(); }
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
        return Efl.Ui.Win.efl_ui_win_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_win_indicator_mode_get_static_delegate == null)
            {
                efl_ui_win_indicator_mode_get_static_delegate = new efl_ui_win_indicator_mode_get_delegate(indicator_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndicatorMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_indicator_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_indicator_mode_get_static_delegate) });
            }

            if (efl_ui_win_indicator_mode_set_static_delegate == null)
            {
                efl_ui_win_indicator_mode_set_static_delegate = new efl_ui_win_indicator_mode_set_delegate(indicator_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIndicatorMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_indicator_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_indicator_mode_set_static_delegate) });
            }

            if (efl_ui_win_keyboard_mode_get_static_delegate == null)
            {
                efl_ui_win_keyboard_mode_get_static_delegate = new efl_ui_win_keyboard_mode_get_delegate(keyboard_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeyboardMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_keyboard_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_keyboard_mode_get_static_delegate) });
            }

            if (efl_ui_win_keyboard_mode_set_static_delegate == null)
            {
                efl_ui_win_keyboard_mode_set_static_delegate = new efl_ui_win_keyboard_mode_set_delegate(keyboard_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeyboardMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_keyboard_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_keyboard_mode_set_static_delegate) });
            }

            if (efl_ui_win_wm_available_rotations_get_static_delegate == null)
            {
                efl_ui_win_wm_available_rotations_get_static_delegate = new efl_ui_win_wm_available_rotations_get_delegate(wm_available_rotations_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWmAvailableRotations") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_wm_available_rotations_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_wm_available_rotations_get_static_delegate) });
            }

            if (efl_ui_win_wm_available_rotations_set_static_delegate == null)
            {
                efl_ui_win_wm_available_rotations_set_static_delegate = new efl_ui_win_wm_available_rotations_set_delegate(wm_available_rotations_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWmAvailableRotations") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_wm_available_rotations_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_wm_available_rotations_set_static_delegate) });
            }

            if (efl_ui_win_wm_available_profiles_get_static_delegate == null)
            {
                efl_ui_win_wm_available_profiles_get_static_delegate = new efl_ui_win_wm_available_profiles_get_delegate(wm_available_profiles_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWmAvailableProfiles") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_wm_available_profiles_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_wm_available_profiles_get_static_delegate) });
            }

            if (efl_ui_win_wm_available_profiles_set_static_delegate == null)
            {
                efl_ui_win_wm_available_profiles_set_static_delegate = new efl_ui_win_wm_available_profiles_set_delegate(wm_available_profiles_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWmAvailableProfiles") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_wm_available_profiles_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_wm_available_profiles_set_static_delegate) });
            }

            if (efl_ui_win_screen_constrain_get_static_delegate == null)
            {
                efl_ui_win_screen_constrain_get_static_delegate = new efl_ui_win_screen_constrain_get_delegate(screen_constrain_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenConstrain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_screen_constrain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_screen_constrain_get_static_delegate) });
            }

            if (efl_ui_win_screen_constrain_set_static_delegate == null)
            {
                efl_ui_win_screen_constrain_set_static_delegate = new efl_ui_win_screen_constrain_set_delegate(screen_constrain_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScreenConstrain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_screen_constrain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_screen_constrain_set_static_delegate) });
            }

            if (efl_ui_win_prop_focus_skip_set_static_delegate == null)
            {
                efl_ui_win_prop_focus_skip_set_static_delegate = new efl_ui_win_prop_focus_skip_set_delegate(prop_focus_skip_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPropFocusSkip") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_prop_focus_skip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_prop_focus_skip_set_static_delegate) });
            }

            if (efl_ui_win_autohide_get_static_delegate == null)
            {
                efl_ui_win_autohide_get_static_delegate = new efl_ui_win_autohide_get_delegate(autohide_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutohide") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_autohide_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_autohide_get_static_delegate) });
            }

            if (efl_ui_win_autohide_set_static_delegate == null)
            {
                efl_ui_win_autohide_set_static_delegate = new efl_ui_win_autohide_set_delegate(autohide_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutohide") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_autohide_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_autohide_set_static_delegate) });
            }

            if (efl_ui_win_exit_on_close_get_static_delegate == null)
            {
                efl_ui_win_exit_on_close_get_static_delegate = new efl_ui_win_exit_on_close_get_delegate(exit_on_close_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExitOnClose") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_exit_on_close_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_exit_on_close_get_static_delegate) });
            }

            if (efl_ui_win_exit_on_close_set_static_delegate == null)
            {
                efl_ui_win_exit_on_close_set_static_delegate = new efl_ui_win_exit_on_close_set_delegate(exit_on_close_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExitOnClose") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_exit_on_close_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_exit_on_close_set_static_delegate) });
            }

            if (efl_ui_win_icon_object_get_static_delegate == null)
            {
                efl_ui_win_icon_object_get_static_delegate = new efl_ui_win_icon_object_get_delegate(icon_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIconObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_icon_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_icon_object_get_static_delegate) });
            }

            if (efl_ui_win_icon_object_set_static_delegate == null)
            {
                efl_ui_win_icon_object_set_static_delegate = new efl_ui_win_icon_object_set_delegate(icon_object_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIconObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_icon_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_icon_object_set_static_delegate) });
            }

            if (efl_ui_win_minimized_get_static_delegate == null)
            {
                efl_ui_win_minimized_get_static_delegate = new efl_ui_win_minimized_get_delegate(minimized_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMinimized") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_minimized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_minimized_get_static_delegate) });
            }

            if (efl_ui_win_minimized_set_static_delegate == null)
            {
                efl_ui_win_minimized_set_static_delegate = new efl_ui_win_minimized_set_delegate(minimized_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMinimized") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_minimized_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_minimized_set_static_delegate) });
            }

            if (efl_ui_win_maximized_get_static_delegate == null)
            {
                efl_ui_win_maximized_get_static_delegate = new efl_ui_win_maximized_get_delegate(maximized_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMaximized") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_maximized_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_maximized_get_static_delegate) });
            }

            if (efl_ui_win_maximized_set_static_delegate == null)
            {
                efl_ui_win_maximized_set_static_delegate = new efl_ui_win_maximized_set_delegate(maximized_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMaximized") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_maximized_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_maximized_set_static_delegate) });
            }

            if (efl_ui_win_fullscreen_get_static_delegate == null)
            {
                efl_ui_win_fullscreen_get_static_delegate = new efl_ui_win_fullscreen_get_delegate(fullscreen_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFullscreen") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_fullscreen_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_fullscreen_get_static_delegate) });
            }

            if (efl_ui_win_fullscreen_set_static_delegate == null)
            {
                efl_ui_win_fullscreen_set_static_delegate = new efl_ui_win_fullscreen_set_delegate(fullscreen_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFullscreen") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_fullscreen_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_fullscreen_set_static_delegate) });
            }

            if (efl_ui_win_sticky_get_static_delegate == null)
            {
                efl_ui_win_sticky_get_static_delegate = new efl_ui_win_sticky_get_delegate(sticky_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSticky") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_sticky_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_sticky_get_static_delegate) });
            }

            if (efl_ui_win_sticky_set_static_delegate == null)
            {
                efl_ui_win_sticky_set_static_delegate = new efl_ui_win_sticky_set_delegate(sticky_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSticky") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_sticky_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_sticky_set_static_delegate) });
            }

            if (efl_ui_win_urgent_get_static_delegate == null)
            {
                efl_ui_win_urgent_get_static_delegate = new efl_ui_win_urgent_get_delegate(urgent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUrgent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_urgent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_urgent_get_static_delegate) });
            }

            if (efl_ui_win_urgent_set_static_delegate == null)
            {
                efl_ui_win_urgent_set_static_delegate = new efl_ui_win_urgent_set_delegate(urgent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUrgent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_urgent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_urgent_set_static_delegate) });
            }

            if (efl_ui_win_modal_get_static_delegate == null)
            {
                efl_ui_win_modal_get_static_delegate = new efl_ui_win_modal_get_delegate(modal_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_modal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_modal_get_static_delegate) });
            }

            if (efl_ui_win_modal_set_static_delegate == null)
            {
                efl_ui_win_modal_set_static_delegate = new efl_ui_win_modal_set_delegate(modal_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetModal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_modal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_modal_set_static_delegate) });
            }

            if (efl_ui_win_borderless_get_static_delegate == null)
            {
                efl_ui_win_borderless_get_static_delegate = new efl_ui_win_borderless_get_delegate(borderless_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBorderless") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_borderless_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_borderless_get_static_delegate) });
            }

            if (efl_ui_win_borderless_set_static_delegate == null)
            {
                efl_ui_win_borderless_set_static_delegate = new efl_ui_win_borderless_set_delegate(borderless_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBorderless") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_borderless_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_borderless_set_static_delegate) });
            }

            if (efl_ui_win_role_get_static_delegate == null)
            {
                efl_ui_win_role_get_static_delegate = new efl_ui_win_role_get_delegate(win_role_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWinRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_role_get_static_delegate) });
            }

            if (efl_ui_win_role_set_static_delegate == null)
            {
                efl_ui_win_role_set_static_delegate = new efl_ui_win_role_set_delegate(win_role_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWinRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_role_set_static_delegate) });
            }

            if (efl_ui_win_name_get_static_delegate == null)
            {
                efl_ui_win_name_get_static_delegate = new efl_ui_win_name_get_delegate(win_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWinName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_name_get_static_delegate) });
            }

            if (efl_ui_win_name_set_static_delegate == null)
            {
                efl_ui_win_name_set_static_delegate = new efl_ui_win_name_set_delegate(win_name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWinName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_name_set_static_delegate) });
            }

            if (efl_ui_win_type_get_static_delegate == null)
            {
                efl_ui_win_type_get_static_delegate = new efl_ui_win_type_get_delegate(win_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWinType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_type_get_static_delegate) });
            }

            if (efl_ui_win_type_set_static_delegate == null)
            {
                efl_ui_win_type_set_static_delegate = new efl_ui_win_type_set_delegate(win_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWinType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_type_set_static_delegate) });
            }

            if (efl_ui_win_accel_preference_get_static_delegate == null)
            {
                efl_ui_win_accel_preference_get_static_delegate = new efl_ui_win_accel_preference_get_delegate(accel_preference_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccelPreference") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_accel_preference_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_accel_preference_get_static_delegate) });
            }

            if (efl_ui_win_accel_preference_set_static_delegate == null)
            {
                efl_ui_win_accel_preference_set_static_delegate = new efl_ui_win_accel_preference_set_delegate(accel_preference_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAccelPreference") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_accel_preference_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_accel_preference_set_static_delegate) });
            }

            if (efl_ui_win_alpha_get_static_delegate == null)
            {
                efl_ui_win_alpha_get_static_delegate = new efl_ui_win_alpha_get_delegate(alpha_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_alpha_get_static_delegate) });
            }

            if (efl_ui_win_alpha_set_static_delegate == null)
            {
                efl_ui_win_alpha_set_static_delegate = new efl_ui_win_alpha_set_delegate(alpha_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_alpha_set_static_delegate) });
            }

            if (efl_ui_win_stack_id_get_static_delegate == null)
            {
                efl_ui_win_stack_id_get_static_delegate = new efl_ui_win_stack_id_get_delegate(stack_id_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStackId") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_id_get_static_delegate) });
            }

            if (efl_ui_win_stack_master_id_get_static_delegate == null)
            {
                efl_ui_win_stack_master_id_get_static_delegate = new efl_ui_win_stack_master_id_get_delegate(stack_master_id_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStackMasterId") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_master_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_master_id_get_static_delegate) });
            }

            if (efl_ui_win_stack_master_id_set_static_delegate == null)
            {
                efl_ui_win_stack_master_id_set_static_delegate = new efl_ui_win_stack_master_id_set_delegate(stack_master_id_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStackMasterId") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_master_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_master_id_set_static_delegate) });
            }

            if (efl_ui_win_stack_base_get_static_delegate == null)
            {
                efl_ui_win_stack_base_get_static_delegate = new efl_ui_win_stack_base_get_delegate(stack_base_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStackBase") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_base_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_base_get_static_delegate) });
            }

            if (efl_ui_win_stack_base_set_static_delegate == null)
            {
                efl_ui_win_stack_base_set_static_delegate = new efl_ui_win_stack_base_set_delegate(stack_base_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStackBase") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_base_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_base_set_static_delegate) });
            }

            if (efl_ui_win_hint_base_get_static_delegate == null)
            {
                efl_ui_win_hint_base_get_static_delegate = new efl_ui_win_hint_base_get_delegate(hint_base_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintBase") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_base_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_base_get_static_delegate) });
            }

            if (efl_ui_win_hint_base_set_static_delegate == null)
            {
                efl_ui_win_hint_base_set_static_delegate = new efl_ui_win_hint_base_set_delegate(hint_base_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintBase") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_base_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_base_set_static_delegate) });
            }

            if (efl_ui_win_hint_step_get_static_delegate == null)
            {
                efl_ui_win_hint_step_get_static_delegate = new efl_ui_win_hint_step_get_delegate(hint_step_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHintStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_step_get_static_delegate) });
            }

            if (efl_ui_win_hint_step_set_static_delegate == null)
            {
                efl_ui_win_hint_step_set_static_delegate = new efl_ui_win_hint_step_set_delegate(hint_step_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHintStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_hint_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_hint_step_set_static_delegate) });
            }

            if (efl_ui_win_rotation_get_static_delegate == null)
            {
                efl_ui_win_rotation_get_static_delegate = new efl_ui_win_rotation_get_delegate(win_rotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWinRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_rotation_get_static_delegate) });
            }

            if (efl_ui_win_rotation_set_static_delegate == null)
            {
                efl_ui_win_rotation_set_static_delegate = new efl_ui_win_rotation_set_delegate(win_rotation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWinRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_rotation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_rotation_set_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_enabled_get_static_delegate == null)
            {
                efl_ui_win_focus_highlight_enabled_get_static_delegate = new efl_ui_win_focus_highlight_enabled_get_delegate(focus_highlight_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusHighlightEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_enabled_get_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_enabled_set_static_delegate == null)
            {
                efl_ui_win_focus_highlight_enabled_set_static_delegate = new efl_ui_win_focus_highlight_enabled_set_delegate(focus_highlight_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusHighlightEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_enabled_set_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_style_get_static_delegate == null)
            {
                efl_ui_win_focus_highlight_style_get_static_delegate = new efl_ui_win_focus_highlight_style_get_delegate(focus_highlight_style_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusHighlightStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_style_get_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_style_set_static_delegate == null)
            {
                efl_ui_win_focus_highlight_style_set_static_delegate = new efl_ui_win_focus_highlight_style_set_delegate(focus_highlight_style_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusHighlightStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_style_set_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_animate_get_static_delegate == null)
            {
                efl_ui_win_focus_highlight_animate_get_static_delegate = new efl_ui_win_focus_highlight_animate_get_delegate(focus_highlight_animate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusHighlightAnimate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_animate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_animate_get_static_delegate) });
            }

            if (efl_ui_win_focus_highlight_animate_set_static_delegate == null)
            {
                efl_ui_win_focus_highlight_animate_set_static_delegate = new efl_ui_win_focus_highlight_animate_set_delegate(focus_highlight_animate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusHighlightAnimate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_focus_highlight_animate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_focus_highlight_animate_set_static_delegate) });
            }

            if (efl_ui_win_stack_pop_to_static_delegate == null)
            {
                efl_ui_win_stack_pop_to_static_delegate = new efl_ui_win_stack_pop_to_delegate(stack_pop_to);
            }

            if (methods.FirstOrDefault(m => m.Name == "StackPopTo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_stack_pop_to"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_stack_pop_to_static_delegate) });
            }

            if (efl_ui_win_activate_static_delegate == null)
            {
                efl_ui_win_activate_static_delegate = new efl_ui_win_activate_delegate(activate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Activate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_activate_static_delegate) });
            }

            if (efl_ui_win_center_static_delegate == null)
            {
                efl_ui_win_center_static_delegate = new efl_ui_win_center_delegate(center);
            }

            if (methods.FirstOrDefault(m => m.Name == "Center") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_center"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_center_static_delegate) });
            }

            if (efl_ui_win_move_resize_start_static_delegate == null)
            {
                efl_ui_win_move_resize_start_static_delegate = new efl_ui_win_move_resize_start_delegate(move_resize_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "MoveResizeStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_move_resize_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_move_resize_start_static_delegate) });
            }

            if (efl_ui_win_pointer_iterate_static_delegate == null)
            {
                efl_ui_win_pointer_iterate_static_delegate = new efl_ui_win_pointer_iterate_delegate(pointer_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "PointerIterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_win_pointer_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_win_pointer_iterate_static_delegate) });
            }

            if (efl_ui_widget_focus_manager_create_static_delegate == null)
            {
                efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusManagerCreate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate) });
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
            return Efl.Ui.Win.efl_ui_win_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.WinIndicatorMode efl_ui_win_indicator_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.WinIndicatorMode efl_ui_win_indicator_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_indicator_mode_get_api_delegate> efl_ui_win_indicator_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_indicator_mode_get_api_delegate>(Module, "efl_ui_win_indicator_mode_get");

        private static Efl.Ui.WinIndicatorMode indicator_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_indicator_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.WinIndicatorMode _ret_var = default(Efl.Ui.WinIndicatorMode);
                try
                {
                    _ret_var = ((Win)ws.Target).GetIndicatorMode();
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
                return efl_ui_win_indicator_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_indicator_mode_get_delegate efl_ui_win_indicator_mode_get_static_delegate;

        
        private delegate void efl_ui_win_indicator_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinIndicatorMode type);

        
        public delegate void efl_ui_win_indicator_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.WinIndicatorMode type);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_indicator_mode_set_api_delegate> efl_ui_win_indicator_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_indicator_mode_set_api_delegate>(Module, "efl_ui_win_indicator_mode_set");

        private static void indicator_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinIndicatorMode type)
        {
            Eina.Log.Debug("function efl_ui_win_indicator_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetIndicatorMode(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_indicator_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_ui_win_indicator_mode_set_delegate efl_ui_win_indicator_mode_set_static_delegate;

        
        private delegate Efl.Ui.WinKeyboardMode efl_ui_win_keyboard_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.WinKeyboardMode efl_ui_win_keyboard_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_keyboard_mode_get_api_delegate> efl_ui_win_keyboard_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_keyboard_mode_get_api_delegate>(Module, "efl_ui_win_keyboard_mode_get");

        private static Efl.Ui.WinKeyboardMode keyboard_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_keyboard_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.WinKeyboardMode _ret_var = default(Efl.Ui.WinKeyboardMode);
                try
                {
                    _ret_var = ((Win)ws.Target).GetKeyboardMode();
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
                return efl_ui_win_keyboard_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_keyboard_mode_get_delegate efl_ui_win_keyboard_mode_get_static_delegate;

        
        private delegate void efl_ui_win_keyboard_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinKeyboardMode mode);

        
        public delegate void efl_ui_win_keyboard_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.WinKeyboardMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_keyboard_mode_set_api_delegate> efl_ui_win_keyboard_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_keyboard_mode_set_api_delegate>(Module, "efl_ui_win_keyboard_mode_set");

        private static void keyboard_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinKeyboardMode mode)
        {
            Eina.Log.Debug("function efl_ui_win_keyboard_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetKeyboardMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_keyboard_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_win_keyboard_mode_set_delegate efl_ui_win_keyboard_mode_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_wm_available_rotations_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool allow_0, [MarshalAs(UnmanagedType.U1)] out bool allow_90, [MarshalAs(UnmanagedType.U1)] out bool allow_180, [MarshalAs(UnmanagedType.U1)] out bool allow_270);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_wm_available_rotations_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool allow_0, [MarshalAs(UnmanagedType.U1)] out bool allow_90, [MarshalAs(UnmanagedType.U1)] out bool allow_180, [MarshalAs(UnmanagedType.U1)] out bool allow_270);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_rotations_get_api_delegate> efl_ui_win_wm_available_rotations_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_rotations_get_api_delegate>(Module, "efl_ui_win_wm_available_rotations_get");

        private static bool wm_available_rotations_get(System.IntPtr obj, System.IntPtr pd, out bool allow_0, out bool allow_90, out bool allow_180, out bool allow_270)
        {
            Eina.Log.Debug("function efl_ui_win_wm_available_rotations_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        allow_0 = default(bool);        allow_90 = default(bool);        allow_180 = default(bool);        allow_270 = default(bool);                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWmAvailableRotations(out allow_0, out allow_90, out allow_180, out allow_270);
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
                return efl_ui_win_wm_available_rotations_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out allow_0, out allow_90, out allow_180, out allow_270);
            }
        }

        private static efl_ui_win_wm_available_rotations_get_delegate efl_ui_win_wm_available_rotations_get_static_delegate;

        
        private delegate void efl_ui_win_wm_available_rotations_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allow_0, [MarshalAs(UnmanagedType.U1)] bool allow_90, [MarshalAs(UnmanagedType.U1)] bool allow_180, [MarshalAs(UnmanagedType.U1)] bool allow_270);

        
        public delegate void efl_ui_win_wm_available_rotations_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allow_0, [MarshalAs(UnmanagedType.U1)] bool allow_90, [MarshalAs(UnmanagedType.U1)] bool allow_180, [MarshalAs(UnmanagedType.U1)] bool allow_270);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_rotations_set_api_delegate> efl_ui_win_wm_available_rotations_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_rotations_set_api_delegate>(Module, "efl_ui_win_wm_available_rotations_set");

        private static void wm_available_rotations_set(System.IntPtr obj, System.IntPtr pd, bool allow_0, bool allow_90, bool allow_180, bool allow_270)
        {
            Eina.Log.Debug("function efl_ui_win_wm_available_rotations_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Win)ws.Target).SetWmAvailableRotations(allow_0, allow_90, allow_180, allow_270);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_ui_win_wm_available_rotations_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), allow_0, allow_90, allow_180, allow_270);
            }
        }

        private static efl_ui_win_wm_available_rotations_set_delegate efl_ui_win_wm_available_rotations_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_win_wm_available_profiles_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_win_wm_available_profiles_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_profiles_get_api_delegate> efl_ui_win_wm_available_profiles_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_profiles_get_api_delegate>(Module, "efl_ui_win_wm_available_profiles_get");

        private static System.IntPtr wm_available_profiles_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_wm_available_profiles_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Array<System.String> _ret_var = default(Eina.Array<System.String>);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWmAvailableProfiles();
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
                return efl_ui_win_wm_available_profiles_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_wm_available_profiles_get_delegate efl_ui_win_wm_available_profiles_get_static_delegate;

        
        private delegate void efl_ui_win_wm_available_profiles_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr profiles);

        
        public delegate void efl_ui_win_wm_available_profiles_set_api_delegate(System.IntPtr obj,  System.IntPtr profiles);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_profiles_set_api_delegate> efl_ui_win_wm_available_profiles_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_wm_available_profiles_set_api_delegate>(Module, "efl_ui_win_wm_available_profiles_set");

        private static void wm_available_profiles_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr profiles)
        {
            Eina.Log.Debug("function efl_ui_win_wm_available_profiles_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_profiles = new Eina.Array<System.String>(profiles, false, false);
                            
                try
                {
                    ((Win)ws.Target).SetWmAvailableProfiles(_in_profiles);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_wm_available_profiles_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), profiles);
            }
        }

        private static efl_ui_win_wm_available_profiles_set_delegate efl_ui_win_wm_available_profiles_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_screen_constrain_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_screen_constrain_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_screen_constrain_get_api_delegate> efl_ui_win_screen_constrain_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_screen_constrain_get_api_delegate>(Module, "efl_ui_win_screen_constrain_get");

        private static bool screen_constrain_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_screen_constrain_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetScreenConstrain();
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
                return efl_ui_win_screen_constrain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_screen_constrain_get_delegate efl_ui_win_screen_constrain_get_static_delegate;

        
        private delegate void efl_ui_win_screen_constrain_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool constrain);

        
        public delegate void efl_ui_win_screen_constrain_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool constrain);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_screen_constrain_set_api_delegate> efl_ui_win_screen_constrain_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_screen_constrain_set_api_delegate>(Module, "efl_ui_win_screen_constrain_set");

        private static void screen_constrain_set(System.IntPtr obj, System.IntPtr pd, bool constrain)
        {
            Eina.Log.Debug("function efl_ui_win_screen_constrain_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetScreenConstrain(constrain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_screen_constrain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), constrain);
            }
        }

        private static efl_ui_win_screen_constrain_set_delegate efl_ui_win_screen_constrain_set_static_delegate;

        
        private delegate void efl_ui_win_prop_focus_skip_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool skip);

        
        public delegate void efl_ui_win_prop_focus_skip_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool skip);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_prop_focus_skip_set_api_delegate> efl_ui_win_prop_focus_skip_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_prop_focus_skip_set_api_delegate>(Module, "efl_ui_win_prop_focus_skip_set");

        private static void prop_focus_skip_set(System.IntPtr obj, System.IntPtr pd, bool skip)
        {
            Eina.Log.Debug("function efl_ui_win_prop_focus_skip_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetPropFocusSkip(skip);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_prop_focus_skip_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), skip);
            }
        }

        private static efl_ui_win_prop_focus_skip_set_delegate efl_ui_win_prop_focus_skip_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_autohide_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_autohide_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_autohide_get_api_delegate> efl_ui_win_autohide_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_autohide_get_api_delegate>(Module, "efl_ui_win_autohide_get");

        private static bool autohide_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_autohide_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetAutohide();
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
                return efl_ui_win_autohide_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_autohide_get_delegate efl_ui_win_autohide_get_static_delegate;

        
        private delegate void efl_ui_win_autohide_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool autohide);

        
        public delegate void efl_ui_win_autohide_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool autohide);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_autohide_set_api_delegate> efl_ui_win_autohide_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_autohide_set_api_delegate>(Module, "efl_ui_win_autohide_set");

        private static void autohide_set(System.IntPtr obj, System.IntPtr pd, bool autohide)
        {
            Eina.Log.Debug("function efl_ui_win_autohide_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetAutohide(autohide);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_autohide_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), autohide);
            }
        }

        private static efl_ui_win_autohide_set_delegate efl_ui_win_autohide_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_ui_win_exit_on_close_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_ui_win_exit_on_close_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_close_get_api_delegate> efl_ui_win_exit_on_close_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_close_get_api_delegate>(Module, "efl_ui_win_exit_on_close_get");

        private static Eina.Value exit_on_close_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_exit_on_close_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = ((Win)ws.Target).GetExitOnClose();
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
                return efl_ui_win_exit_on_close_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_exit_on_close_get_delegate efl_ui_win_exit_on_close_get_static_delegate;

        
        private delegate void efl_ui_win_exit_on_close_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value exit_code);

        
        public delegate void efl_ui_win_exit_on_close_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value exit_code);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_close_set_api_delegate> efl_ui_win_exit_on_close_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_close_set_api_delegate>(Module, "efl_ui_win_exit_on_close_set");

        private static void exit_on_close_set(System.IntPtr obj, System.IntPtr pd, Eina.Value exit_code)
        {
            Eina.Log.Debug("function efl_ui_win_exit_on_close_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetExitOnClose(exit_code);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_exit_on_close_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), exit_code);
            }
        }

        private static efl_ui_win_exit_on_close_set_delegate efl_ui_win_exit_on_close_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_win_icon_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_win_icon_object_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_icon_object_get_api_delegate> efl_ui_win_icon_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_icon_object_get_api_delegate>(Module, "efl_ui_win_icon_object_get");

        private static Efl.Canvas.Object icon_object_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_icon_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Win)ws.Target).GetIconObject();
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
                return efl_ui_win_icon_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_icon_object_get_delegate efl_ui_win_icon_object_get_static_delegate;

        
        private delegate void efl_ui_win_icon_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object icon);

        
        public delegate void efl_ui_win_icon_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_icon_object_set_api_delegate> efl_ui_win_icon_object_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_icon_object_set_api_delegate>(Module, "efl_ui_win_icon_object_set");

        private static void icon_object_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object icon)
        {
            Eina.Log.Debug("function efl_ui_win_icon_object_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetIconObject(icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_icon_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), icon);
            }
        }

        private static efl_ui_win_icon_object_set_delegate efl_ui_win_icon_object_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_minimized_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_minimized_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_minimized_get_api_delegate> efl_ui_win_minimized_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_minimized_get_api_delegate>(Module, "efl_ui_win_minimized_get");

        private static bool minimized_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_minimized_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetMinimized();
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
                return efl_ui_win_minimized_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_minimized_get_delegate efl_ui_win_minimized_get_static_delegate;

        
        private delegate void efl_ui_win_minimized_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool state);

        
        public delegate void efl_ui_win_minimized_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool state);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_minimized_set_api_delegate> efl_ui_win_minimized_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_minimized_set_api_delegate>(Module, "efl_ui_win_minimized_set");

        private static void minimized_set(System.IntPtr obj, System.IntPtr pd, bool state)
        {
            Eina.Log.Debug("function efl_ui_win_minimized_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetMinimized(state);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_minimized_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state);
            }
        }

        private static efl_ui_win_minimized_set_delegate efl_ui_win_minimized_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_maximized_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_maximized_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_maximized_get_api_delegate> efl_ui_win_maximized_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_maximized_get_api_delegate>(Module, "efl_ui_win_maximized_get");

        private static bool maximized_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_maximized_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetMaximized();
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
                return efl_ui_win_maximized_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_maximized_get_delegate efl_ui_win_maximized_get_static_delegate;

        
        private delegate void efl_ui_win_maximized_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool maximized);

        
        public delegate void efl_ui_win_maximized_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool maximized);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_maximized_set_api_delegate> efl_ui_win_maximized_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_maximized_set_api_delegate>(Module, "efl_ui_win_maximized_set");

        private static void maximized_set(System.IntPtr obj, System.IntPtr pd, bool maximized)
        {
            Eina.Log.Debug("function efl_ui_win_maximized_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetMaximized(maximized);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_maximized_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), maximized);
            }
        }

        private static efl_ui_win_maximized_set_delegate efl_ui_win_maximized_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_fullscreen_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_fullscreen_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_fullscreen_get_api_delegate> efl_ui_win_fullscreen_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_fullscreen_get_api_delegate>(Module, "efl_ui_win_fullscreen_get");

        private static bool fullscreen_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_fullscreen_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetFullscreen();
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
                return efl_ui_win_fullscreen_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_fullscreen_get_delegate efl_ui_win_fullscreen_get_static_delegate;

        
        private delegate void efl_ui_win_fullscreen_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool fullscreen);

        
        public delegate void efl_ui_win_fullscreen_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool fullscreen);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_fullscreen_set_api_delegate> efl_ui_win_fullscreen_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_fullscreen_set_api_delegate>(Module, "efl_ui_win_fullscreen_set");

        private static void fullscreen_set(System.IntPtr obj, System.IntPtr pd, bool fullscreen)
        {
            Eina.Log.Debug("function efl_ui_win_fullscreen_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetFullscreen(fullscreen);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_fullscreen_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fullscreen);
            }
        }

        private static efl_ui_win_fullscreen_set_delegate efl_ui_win_fullscreen_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_sticky_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_sticky_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_sticky_get_api_delegate> efl_ui_win_sticky_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_sticky_get_api_delegate>(Module, "efl_ui_win_sticky_get");

        private static bool sticky_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_sticky_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetSticky();
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
                return efl_ui_win_sticky_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_sticky_get_delegate efl_ui_win_sticky_get_static_delegate;

        
        private delegate void efl_ui_win_sticky_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool sticky);

        
        public delegate void efl_ui_win_sticky_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool sticky);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_sticky_set_api_delegate> efl_ui_win_sticky_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_sticky_set_api_delegate>(Module, "efl_ui_win_sticky_set");

        private static void sticky_set(System.IntPtr obj, System.IntPtr pd, bool sticky)
        {
            Eina.Log.Debug("function efl_ui_win_sticky_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetSticky(sticky);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_sticky_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sticky);
            }
        }

        private static efl_ui_win_sticky_set_delegate efl_ui_win_sticky_set_static_delegate;

        
        private delegate Efl.Ui.WinUrgentMode efl_ui_win_urgent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.WinUrgentMode efl_ui_win_urgent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_urgent_get_api_delegate> efl_ui_win_urgent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_urgent_get_api_delegate>(Module, "efl_ui_win_urgent_get");

        private static Efl.Ui.WinUrgentMode urgent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_urgent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.WinUrgentMode _ret_var = default(Efl.Ui.WinUrgentMode);
                try
                {
                    _ret_var = ((Win)ws.Target).GetUrgent();
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
                return efl_ui_win_urgent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_urgent_get_delegate efl_ui_win_urgent_get_static_delegate;

        
        private delegate void efl_ui_win_urgent_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinUrgentMode urgent);

        
        public delegate void efl_ui_win_urgent_set_api_delegate(System.IntPtr obj,  Efl.Ui.WinUrgentMode urgent);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_urgent_set_api_delegate> efl_ui_win_urgent_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_urgent_set_api_delegate>(Module, "efl_ui_win_urgent_set");

        private static void urgent_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinUrgentMode urgent)
        {
            Eina.Log.Debug("function efl_ui_win_urgent_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetUrgent(urgent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_urgent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), urgent);
            }
        }

        private static efl_ui_win_urgent_set_delegate efl_ui_win_urgent_set_static_delegate;

        
        private delegate Efl.Ui.WinModalMode efl_ui_win_modal_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.WinModalMode efl_ui_win_modal_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_modal_get_api_delegate> efl_ui_win_modal_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_modal_get_api_delegate>(Module, "efl_ui_win_modal_get");

        private static Efl.Ui.WinModalMode modal_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_modal_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.WinModalMode _ret_var = default(Efl.Ui.WinModalMode);
                try
                {
                    _ret_var = ((Win)ws.Target).GetModal();
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
                return efl_ui_win_modal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_modal_get_delegate efl_ui_win_modal_get_static_delegate;

        
        private delegate void efl_ui_win_modal_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinModalMode modal);

        
        public delegate void efl_ui_win_modal_set_api_delegate(System.IntPtr obj,  Efl.Ui.WinModalMode modal);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_modal_set_api_delegate> efl_ui_win_modal_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_modal_set_api_delegate>(Module, "efl_ui_win_modal_set");

        private static void modal_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinModalMode modal)
        {
            Eina.Log.Debug("function efl_ui_win_modal_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetModal(modal);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_modal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), modal);
            }
        }

        private static efl_ui_win_modal_set_delegate efl_ui_win_modal_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_borderless_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_borderless_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_borderless_get_api_delegate> efl_ui_win_borderless_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_borderless_get_api_delegate>(Module, "efl_ui_win_borderless_get");

        private static bool borderless_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_borderless_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetBorderless();
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
                return efl_ui_win_borderless_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_borderless_get_delegate efl_ui_win_borderless_get_static_delegate;

        
        private delegate void efl_ui_win_borderless_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool borderless);

        
        public delegate void efl_ui_win_borderless_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool borderless);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_borderless_set_api_delegate> efl_ui_win_borderless_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_borderless_set_api_delegate>(Module, "efl_ui_win_borderless_set");

        private static void borderless_set(System.IntPtr obj, System.IntPtr pd, bool borderless)
        {
            Eina.Log.Debug("function efl_ui_win_borderless_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetBorderless(borderless);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_borderless_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), borderless);
            }
        }

        private static efl_ui_win_borderless_set_delegate efl_ui_win_borderless_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_role_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_role_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_role_get_api_delegate> efl_ui_win_role_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_role_get_api_delegate>(Module, "efl_ui_win_role_get");

        private static System.String win_role_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_role_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWinRole();
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
                return efl_ui_win_role_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_role_get_delegate efl_ui_win_role_get_static_delegate;

        
        private delegate void efl_ui_win_role_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String role);

        
        public delegate void efl_ui_win_role_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String role);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_role_set_api_delegate> efl_ui_win_role_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_role_set_api_delegate>(Module, "efl_ui_win_role_set");

        private static void win_role_set(System.IntPtr obj, System.IntPtr pd, System.String role)
        {
            Eina.Log.Debug("function efl_ui_win_role_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetWinRole(role);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_role_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), role);
            }
        }

        private static efl_ui_win_role_set_delegate efl_ui_win_role_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_name_get_api_delegate> efl_ui_win_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_name_get_api_delegate>(Module, "efl_ui_win_name_get");

        private static System.String win_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWinName();
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
                return efl_ui_win_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_name_get_delegate efl_ui_win_name_get_static_delegate;

        
        private delegate void efl_ui_win_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_ui_win_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_name_set_api_delegate> efl_ui_win_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_name_set_api_delegate>(Module, "efl_ui_win_name_set");

        private static void win_name_set(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_ui_win_name_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetWinName(name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_ui_win_name_set_delegate efl_ui_win_name_set_static_delegate;

        
        private delegate Efl.Ui.WinType efl_ui_win_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.WinType efl_ui_win_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_type_get_api_delegate> efl_ui_win_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_type_get_api_delegate>(Module, "efl_ui_win_type_get");

        private static Efl.Ui.WinType win_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.WinType _ret_var = default(Efl.Ui.WinType);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWinType();
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
                return efl_ui_win_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_type_get_delegate efl_ui_win_type_get_static_delegate;

        
        private delegate void efl_ui_win_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinType type);

        
        public delegate void efl_ui_win_type_set_api_delegate(System.IntPtr obj,  Efl.Ui.WinType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_type_set_api_delegate> efl_ui_win_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_type_set_api_delegate>(Module, "efl_ui_win_type_set");

        private static void win_type_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinType type)
        {
            Eina.Log.Debug("function efl_ui_win_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetWinType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_ui_win_type_set_delegate efl_ui_win_type_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_accel_preference_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_accel_preference_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_accel_preference_get_api_delegate> efl_ui_win_accel_preference_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_accel_preference_get_api_delegate>(Module, "efl_ui_win_accel_preference_get");

        private static System.String accel_preference_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_accel_preference_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetAccelPreference();
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
                return efl_ui_win_accel_preference_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_accel_preference_get_delegate efl_ui_win_accel_preference_get_static_delegate;

        
        private delegate void efl_ui_win_accel_preference_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String accel);

        
        public delegate void efl_ui_win_accel_preference_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String accel);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_accel_preference_set_api_delegate> efl_ui_win_accel_preference_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_accel_preference_set_api_delegate>(Module, "efl_ui_win_accel_preference_set");

        private static void accel_preference_set(System.IntPtr obj, System.IntPtr pd, System.String accel)
        {
            Eina.Log.Debug("function efl_ui_win_accel_preference_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetAccelPreference(accel);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_accel_preference_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), accel);
            }
        }

        private static efl_ui_win_accel_preference_set_delegate efl_ui_win_accel_preference_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_alpha_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_alpha_get_api_delegate> efl_ui_win_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_alpha_get_api_delegate>(Module, "efl_ui_win_alpha_get");

        private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_alpha_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetAlpha();
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
                return efl_ui_win_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_alpha_get_delegate efl_ui_win_alpha_get_static_delegate;

        
        private delegate void efl_ui_win_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        public delegate void efl_ui_win_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_alpha_set_api_delegate> efl_ui_win_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_alpha_set_api_delegate>(Module, "efl_ui_win_alpha_set");

        private static void alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            Eina.Log.Debug("function efl_ui_win_alpha_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetAlpha(alpha);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), alpha);
            }
        }

        private static efl_ui_win_alpha_set_delegate efl_ui_win_alpha_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_stack_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_stack_id_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_id_get_api_delegate> efl_ui_win_stack_id_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_id_get_api_delegate>(Module, "efl_ui_win_stack_id_get");

        private static System.String stack_id_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_stack_id_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetStackId();
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
                return efl_ui_win_stack_id_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_stack_id_get_delegate efl_ui_win_stack_id_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_stack_master_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_stack_master_id_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_master_id_get_api_delegate> efl_ui_win_stack_master_id_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_master_id_get_api_delegate>(Module, "efl_ui_win_stack_master_id_get");

        private static System.String stack_master_id_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_stack_master_id_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetStackMasterId();
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
                return efl_ui_win_stack_master_id_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_stack_master_id_get_delegate efl_ui_win_stack_master_id_get_static_delegate;

        
        private delegate void efl_ui_win_stack_master_id_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String id);

        
        public delegate void efl_ui_win_stack_master_id_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String id);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_master_id_set_api_delegate> efl_ui_win_stack_master_id_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_master_id_set_api_delegate>(Module, "efl_ui_win_stack_master_id_set");

        private static void stack_master_id_set(System.IntPtr obj, System.IntPtr pd, System.String id)
        {
            Eina.Log.Debug("function efl_ui_win_stack_master_id_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetStackMasterId(id);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_stack_master_id_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_ui_win_stack_master_id_set_delegate efl_ui_win_stack_master_id_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_stack_base_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_stack_base_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_base_get_api_delegate> efl_ui_win_stack_base_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_base_get_api_delegate>(Module, "efl_ui_win_stack_base_get");

        private static bool stack_base_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_stack_base_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetStackBase();
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
                return efl_ui_win_stack_base_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_stack_base_get_delegate efl_ui_win_stack_base_get_static_delegate;

        
        private delegate void efl_ui_win_stack_base_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool kw_base);

        
        public delegate void efl_ui_win_stack_base_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool kw_base);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_base_set_api_delegate> efl_ui_win_stack_base_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_base_set_api_delegate>(Module, "efl_ui_win_stack_base_set");

        private static void stack_base_set(System.IntPtr obj, System.IntPtr pd, bool kw_base)
        {
            Eina.Log.Debug("function efl_ui_win_stack_base_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetStackBase(kw_base);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_stack_base_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_base);
            }
        }

        private static efl_ui_win_stack_base_set_delegate efl_ui_win_stack_base_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        private delegate Eina.Value efl_ui_win_exit_on_all_windows_closed_get_delegate();

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))]
        public delegate Eina.Value efl_ui_win_exit_on_all_windows_closed_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_get_api_delegate> efl_ui_win_exit_on_all_windows_closed_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_get_api_delegate>(Module, "efl_ui_win_exit_on_all_windows_closed_get");

        private static Eina.Value exit_on_all_windows_closed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_exit_on_all_windows_closed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Value _ret_var = default(Eina.Value);
                try
                {
                    _ret_var = Win.GetExitOnAllWindowsClosed();
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
                return efl_ui_win_exit_on_all_windows_closed_get_ptr.Value.Delegate();
            }
        }

        
        private delegate void efl_ui_win_exit_on_all_windows_closed_set_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value exit_code);

        
        public delegate void efl_ui_win_exit_on_all_windows_closed_set_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.ValueMarshaler))] Eina.Value exit_code);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_set_api_delegate> efl_ui_win_exit_on_all_windows_closed_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_exit_on_all_windows_closed_set_api_delegate>(Module, "efl_ui_win_exit_on_all_windows_closed_set");

        private static void exit_on_all_windows_closed_set(System.IntPtr obj, System.IntPtr pd, Eina.Value exit_code)
        {
            Eina.Log.Debug("function efl_ui_win_exit_on_all_windows_closed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    Win.SetExitOnAllWindowsClosed(exit_code);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_exit_on_all_windows_closed_set_ptr.Value.Delegate(exit_code);
            }
        }

        
        private delegate Eina.Size2D.NativeStruct efl_ui_win_hint_base_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_win_hint_base_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_hint_base_get_api_delegate> efl_ui_win_hint_base_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_hint_base_get_api_delegate>(Module, "efl_ui_win_hint_base_get");

        private static Eina.Size2D.NativeStruct hint_base_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_hint_base_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Win)ws.Target).GetHintBase();
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
                return efl_ui_win_hint_base_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_hint_base_get_delegate efl_ui_win_hint_base_get_static_delegate;

        
        private delegate void efl_ui_win_hint_base_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_ui_win_hint_base_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_hint_base_set_api_delegate> efl_ui_win_hint_base_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_hint_base_set_api_delegate>(Module, "efl_ui_win_hint_base_set");

        private static void hint_base_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_ui_win_hint_base_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Win)ws.Target).SetHintBase(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_hint_base_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_ui_win_hint_base_set_delegate efl_ui_win_hint_base_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_win_hint_step_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_win_hint_step_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_hint_step_get_api_delegate> efl_ui_win_hint_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_hint_step_get_api_delegate>(Module, "efl_ui_win_hint_step_get");

        private static Eina.Size2D.NativeStruct hint_step_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_hint_step_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Win)ws.Target).GetHintStep();
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
                return efl_ui_win_hint_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_hint_step_get_delegate efl_ui_win_hint_step_get_static_delegate;

        
        private delegate void efl_ui_win_hint_step_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_ui_win_hint_step_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_hint_step_set_api_delegate> efl_ui_win_hint_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_hint_step_set_api_delegate>(Module, "efl_ui_win_hint_step_set");

        private static void hint_step_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_ui_win_hint_step_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((Win)ws.Target).SetHintStep(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_hint_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_ui_win_hint_step_set_delegate efl_ui_win_hint_step_set_static_delegate;

        
        private delegate int efl_ui_win_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_win_rotation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_rotation_get_api_delegate> efl_ui_win_rotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_rotation_get_api_delegate>(Module, "efl_ui_win_rotation_get");

        private static int win_rotation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_rotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Win)ws.Target).GetWinRotation();
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
                return efl_ui_win_rotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_rotation_get_delegate efl_ui_win_rotation_get_static_delegate;

        
        private delegate void efl_ui_win_rotation_set_delegate(System.IntPtr obj, System.IntPtr pd,  int rotation);

        
        public delegate void efl_ui_win_rotation_set_api_delegate(System.IntPtr obj,  int rotation);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_rotation_set_api_delegate> efl_ui_win_rotation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_rotation_set_api_delegate>(Module, "efl_ui_win_rotation_set");

        private static void win_rotation_set(System.IntPtr obj, System.IntPtr pd, int rotation)
        {
            Eina.Log.Debug("function efl_ui_win_rotation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetWinRotation(rotation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_rotation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rotation);
            }
        }

        private static efl_ui_win_rotation_set_delegate efl_ui_win_rotation_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_focus_highlight_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_focus_highlight_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_enabled_get_api_delegate> efl_ui_win_focus_highlight_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_enabled_get_api_delegate>(Module, "efl_ui_win_focus_highlight_enabled_get");

        private static bool focus_highlight_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetFocusHighlightEnabled();
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
                return efl_ui_win_focus_highlight_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_focus_highlight_enabled_get_delegate efl_ui_win_focus_highlight_enabled_get_static_delegate;

        
        private delegate void efl_ui_win_focus_highlight_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_ui_win_focus_highlight_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_enabled_set_api_delegate> efl_ui_win_focus_highlight_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_enabled_set_api_delegate>(Module, "efl_ui_win_focus_highlight_enabled_set");

        private static void focus_highlight_enabled_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetFocusHighlightEnabled(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_focus_highlight_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_ui_win_focus_highlight_enabled_set_delegate efl_ui_win_focus_highlight_enabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_win_focus_highlight_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_win_focus_highlight_style_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_style_get_api_delegate> efl_ui_win_focus_highlight_style_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_style_get_api_delegate>(Module, "efl_ui_win_focus_highlight_style_get");

        private static System.String focus_highlight_style_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_style_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Win)ws.Target).GetFocusHighlightStyle();
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
                return efl_ui_win_focus_highlight_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_focus_highlight_style_get_delegate efl_ui_win_focus_highlight_style_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_focus_highlight_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_focus_highlight_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_style_set_api_delegate> efl_ui_win_focus_highlight_style_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_style_set_api_delegate>(Module, "efl_ui_win_focus_highlight_style_set");

        private static bool focus_highlight_style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_style_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).SetFocusHighlightStyle(style);
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
                return efl_ui_win_focus_highlight_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_ui_win_focus_highlight_style_set_delegate efl_ui_win_focus_highlight_style_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_focus_highlight_animate_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_focus_highlight_animate_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_animate_get_api_delegate> efl_ui_win_focus_highlight_animate_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_animate_get_api_delegate>(Module, "efl_ui_win_focus_highlight_animate_get");

        private static bool focus_highlight_animate_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_animate_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).GetFocusHighlightAnimate();
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
                return efl_ui_win_focus_highlight_animate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_focus_highlight_animate_get_delegate efl_ui_win_focus_highlight_animate_get_static_delegate;

        
        private delegate void efl_ui_win_focus_highlight_animate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool animate);

        
        public delegate void efl_ui_win_focus_highlight_animate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool animate);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_animate_set_api_delegate> efl_ui_win_focus_highlight_animate_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_focus_highlight_animate_set_api_delegate>(Module, "efl_ui_win_focus_highlight_animate_set");

        private static void focus_highlight_animate_set(System.IntPtr obj, System.IntPtr pd, bool animate)
        {
            Eina.Log.Debug("function efl_ui_win_focus_highlight_animate_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Win)ws.Target).SetFocusHighlightAnimate(animate);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_win_focus_highlight_animate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), animate);
            }
        }

        private static efl_ui_win_focus_highlight_animate_set_delegate efl_ui_win_focus_highlight_animate_set_static_delegate;

        
        private delegate void efl_ui_win_stack_pop_to_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_win_stack_pop_to_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_stack_pop_to_api_delegate> efl_ui_win_stack_pop_to_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_stack_pop_to_api_delegate>(Module, "efl_ui_win_stack_pop_to");

        private static void stack_pop_to(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_stack_pop_to was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Win)ws.Target).StackPopTo();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_win_stack_pop_to_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_stack_pop_to_delegate efl_ui_win_stack_pop_to_static_delegate;

        
        private delegate void efl_ui_win_activate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_win_activate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_activate_api_delegate> efl_ui_win_activate_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_activate_api_delegate>(Module, "efl_ui_win_activate");

        private static void activate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_win_activate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Win)ws.Target).Activate();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_win_activate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_win_activate_delegate efl_ui_win_activate_static_delegate;

        
        private delegate void efl_ui_win_center_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool h, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_ui_win_center_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool h, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_center_api_delegate> efl_ui_win_center_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_center_api_delegate>(Module, "efl_ui_win_center");

        private static void center(System.IntPtr obj, System.IntPtr pd, bool h, bool v)
        {
            Eina.Log.Debug("function efl_ui_win_center was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Win)ws.Target).Center(h, v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_win_center_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), h, v);
            }
        }

        private static efl_ui_win_center_delegate efl_ui_win_center_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_win_move_resize_start_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WinMoveResizeMode mode);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_win_move_resize_start_api_delegate(System.IntPtr obj,  Efl.Ui.WinMoveResizeMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_move_resize_start_api_delegate> efl_ui_win_move_resize_start_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_move_resize_start_api_delegate>(Module, "efl_ui_win_move_resize_start");

        private static bool move_resize_start(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WinMoveResizeMode mode)
        {
            Eina.Log.Debug("function efl_ui_win_move_resize_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Win)ws.Target).MoveResizeStart(mode);
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
                return efl_ui_win_move_resize_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_win_move_resize_start_delegate efl_ui_win_move_resize_start_static_delegate;

        
        private delegate System.IntPtr efl_ui_win_pointer_iterate_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool hover);

        
        public delegate System.IntPtr efl_ui_win_pointer_iterate_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool hover);

        public static Efl.Eo.FunctionWrapper<efl_ui_win_pointer_iterate_api_delegate> efl_ui_win_pointer_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_ui_win_pointer_iterate_api_delegate>(Module, "efl_ui_win_pointer_iterate");

        private static System.IntPtr pointer_iterate(System.IntPtr obj, System.IntPtr pd, bool hover)
        {
            Eina.Log.Debug("function efl_ui_win_pointer_iterate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Iterator<Efl.Input.Pointer> _ret_var = default(Eina.Iterator<Efl.Input.Pointer>);
                try
                {
                    _ret_var = ((Win)ws.Target).PointerIterate(hover);
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
                return efl_ui_win_pointer_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hover);
            }
        }

        private static efl_ui_win_pointer_iterate_delegate efl_ui_win_pointer_iterate_static_delegate;

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
                    _ret_var = ((Win)ws.Target).FocusManagerCreate(root);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWin_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.WinIndicatorMode> IndicatorMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.WinIndicatorMode>("indicator_mode", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.WinKeyboardMode> KeyboardMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.WinKeyboardMode>("keyboard_mode", fac);
    }

    
    public static Efl.BindableProperty<Eina.Array<System.String>> WmAvailableProfiles<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Eina.Array<System.String>>("wm_available_profiles", fac);
    }

    public static Efl.BindableProperty<bool> ScreenConstrain<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("screen_constrain", fac);
    }

    public static Efl.BindableProperty<bool> PropFocusSkip<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("prop_focus_skip", fac);
    }

    public static Efl.BindableProperty<bool> Autohide<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("autohide", fac);
    }

    public static Efl.BindableProperty<Eina.Value> ExitOnClose<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Eina.Value>("exit_on_close", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Object> IconObject<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Canvas.Object>("icon_object", fac);
    }

    public static Efl.BindableProperty<bool> Minimized<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("minimized", fac);
    }

    public static Efl.BindableProperty<bool> Maximized<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("maximized", fac);
    }

    public static Efl.BindableProperty<bool> Fullscreen<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("fullscreen", fac);
    }

    public static Efl.BindableProperty<bool> Sticky<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("sticky", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.WinUrgentMode> Urgent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.WinUrgentMode>("urgent", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.WinModalMode> Modal<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.WinModalMode>("modal", fac);
    }

    public static Efl.BindableProperty<bool> Borderless<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("borderless", fac);
    }

    public static Efl.BindableProperty<System.String> WinRole<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<System.String>("win_role", fac);
    }

    public static Efl.BindableProperty<System.String> WinName<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<System.String>("win_name", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.WinType> WinType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.WinType>("win_type", fac);
    }

    public static Efl.BindableProperty<System.String> AccelPreference<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<System.String>("accel_preference", fac);
    }

    public static Efl.BindableProperty<bool> Alpha<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("alpha", fac);
    }

    
    public static Efl.BindableProperty<System.String> StackMasterId<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<System.String>("stack_master_id", fac);
    }

    public static Efl.BindableProperty<bool> StackBase<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("stack_base", fac);
    }

    public static Efl.BindableProperty<Eina.Value> ExitOnAllWindowsClosed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Eina.Value>("exit_on_all_windows_closed", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintBase<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Eina.Size2D>("hint_base", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> HintStep<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Eina.Size2D>("hint_step", fac);
    }

    public static Efl.BindableProperty<int> WinRotation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<int>("win_rotation", fac);
    }

    public static Efl.BindableProperty<bool> FocusHighlightEnabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("focus_highlight_enabled", fac);
    }

    public static Efl.BindableProperty<System.String> FocusHighlightStyle<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<System.String>("focus_highlight_style", fac);
    }

    public static Efl.BindableProperty<bool> FocusHighlightAnimate<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<bool>("focus_highlight_animate", fac);
    }

    
    public static Efl.BindableProperty<Efl.Gfx.IEntity> Content<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Gfx.IEntity>("content", fac);
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> ManagerFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("manager_focus", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IManager> Redirect<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.Focus.IManager>("redirect", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> Root<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Win, T>magic = null) where T : Efl.Ui.Win {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("root", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Defines the types of window that can be created.
/// These are hints set on a window so that a running Window Manager knows how the window should be handled and/or what kind of decorations it should have.
/// 
/// Currently, only the X11 backed engines use them.</summary>
[Efl.Eo.BindingEntity]
public enum WinType
{
/// <summary>Default, unknown, type</summary>
Unknown = 0,
/// <summary>A normal window. Indicates a normal, top-level window. Almost every window will be created with this type.</summary>
Basic = 1,
/// <summary>Used for simple dialog windows.</summary>
DialogBasic = 2,
/// <summary>For special desktop windows, like a background window holding desktop icons.</summary>
Desktop = 3,
/// <summary>The window is used as a dock or panel. Usually would be kept on top of any other window by the Window Manager.</summary>
Dock = 4,
/// <summary>The window is used to hold a floating toolbar or similar.</summary>
Toolbar = 5,
/// <summary>Similar to <see cref="Efl.Ui.WinType.Toolbar"/>.</summary>
Menu = 6,
/// <summary>A persistent utility window, like a toolbox or palette.</summary>
Utility = 7,
/// <summary>Splash window for a starting up application.</summary>
Splash = 8,
/// <summary>The window is a dropdown menu, as when an  entry in a menu bar is clicked. This hint exists for completeness&apos; sake, as the EFL way of implementing a menu would not normally use a separate window for its contents.</summary>
DropdownMenu = 9,
/// <summary>Like <see cref="Efl.Ui.WinType.DropdownMenu"/>, but for the menu triggered by right-clicking an object.</summary>
PopupMenu = 10,
/// <summary>The window is a tooltip. A short piece of explanatory text that typically appear after the mouse cursor hovers over an object for a while. Not commonly used in the EFL.</summary>
Tooltip = 11,
/// <summary>A notification window, like a warning about battery life or a new E-Mail received.</summary>
Notification = 12,
/// <summary>A window holding the contents of a combo box. Not commonly used in the EFL.</summary>
Combo = 13,
/// <summary>Internal use.</summary>
Dnd = 14,
/// <summary>Internal use.</summary>
InlinedImage = 15,
/// <summary>Internal use.</summary>
SocketImage = 16,
/// <summary>Used for naviframe style replacement with a back button instead of a close button.</summary>
NaviframeBasic = 17,
/// <summary>Internal use.</summary>
Fake = 18,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>The different layouts that can be requested for the virtual keyboard.
/// When the application window is being managed by Illume it may request any of the following layouts for the virtual keyboard.</summary>
[Efl.Eo.BindingEntity]
public enum WinKeyboardMode
{
/// <summary>Unknown keyboard state</summary>
Unknown = 0,
/// <summary>Request to deactivate the keyboard</summary>
Off = 1,
/// <summary>Enable keyboard with default layout</summary>
On = 2,
/// <summary>Alpha (a-z) keyboard layout</summary>
Alpha = 3,
/// <summary>Numeric keyboard layout</summary>
Numeric = 4,
/// <summary>PIN keyboard layout</summary>
Pin = 5,
/// <summary>Phone keyboard layout</summary>
PhoneNumber = 6,
/// <summary>Hexadecimal numeric keyboard layout</summary>
Hex = 7,
/// <summary>Full (QWERTY) keyboard layout</summary>
Terminal = 8,
/// <summary>Password keyboard layout</summary>
Password = 9,
/// <summary>IP keyboard layout</summary>
Ip = 10,
/// <summary>Host keyboard layout</summary>
Host = 11,
/// <summary>File keyboard layout</summary>
File = 12,
/// <summary>URL keyboard layout</summary>
Url = 13,
/// <summary>Keypad layout</summary>
Keypad = 14,
/// <summary>J2ME keyboard layout</summary>
J2me = 15,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Defines the type indicator that can be shown.
/// (Since EFL 1.22)</summary>
[Efl.Eo.BindingEntity]
public enum WinIndicatorMode
{
/// <summary>Request to deactivate the indicator.</summary>
Off = 0,
/// <summary>The indicator icon is opaque, as is the indicator background. The content of window is located at the end of the indicator. The area of indicator and window content are not overlapped.</summary>
BgOpaque = 1,
/// <summary>Be translucent the indicator</summary>
Translucent = 2,
/// <summary>Transparentizes the indicator</summary>
Transparent = 3,
/// <summary>The icon of indicator is opaque, but the background is transparent. The content of window is located under the indicator in Z-order. The area of indicator and window content are overlapped.</summary>
BgTransparent = 4,
/// <summary>The indicator is hidden so user can see only the content of window such as in video mode. If user flicks the upper side of window, the indicator is shown temporarily.</summary>
Hidden = 5,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Defines the mode of a modal window.</summary>
[Efl.Eo.BindingEntity]
public enum WinModalMode
{
/// <summary>The window is not a modal window.</summary>
None = 0,
/// <summary>The window is a modal window.</summary>
Modal = 1,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Defines the mode of a urgent window.</summary>
[Efl.Eo.BindingEntity]
public enum WinUrgentMode
{
/// <summary>The window is not a urgent window.</summary>
None = 0,
/// <summary>The window is a urgent window.</summary>
Urgent = 1,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>Define the move or resize mode of a window.
/// The user can request the display server to start moving or resizing the window by combining these modes. However only limited combinations are allowed.
/// 
/// Currently, only the following 9 combinations are permitted. More combinations may be added in future: 1. move, 2. top, 3. bottom, 4. left, 5. right, 6. top | left, 7. top | right, 8. bottom | left, 9. bottom | right.
/// (Since EFL 1.22)</summary>
[Efl.Eo.BindingEntity]
public enum WinMoveResizeMode
{
/// <summary>Start moving window</summary>
Move = 1,
/// <summary>Start resizing window to the top</summary>
Top = 2,
/// <summary>Start resizing window to the bottom</summary>
Bottom = 4,
/// <summary>Start resizing window to the left</summary>
Left = 8,
/// <summary>Start resizing window to the right</summary>
Right = 16,
}

}

}

namespace Efl {

namespace Ui {

/// <summary>List of window effect.
/// These list indicates types of window effect. When the effect started or done, the Elm_Win is notified with type information of window effect.</summary>
[Efl.Eo.BindingEntity]
public enum WinEffectType
{
Unknown = 0,
Show = 1,
Hide = 2,
Restack = 3,
}

}

}

namespace Efl {

namespace Ui {

[Efl.Eo.BindingEntity]
public enum WinConformantProperty
{
Default = 0,
IndicatorState = 1,
IndicatorGeometry = 2,
KeyboardState = 4,
KeyboardGeometry = 8,
ClipboardState = 16,
ClipboardGeometry = 32,
}

}

}

