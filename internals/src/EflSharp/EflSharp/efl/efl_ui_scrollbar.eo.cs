#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

[Efl.Ui.IScrollbarConcrete.NativeMethods]
public interface IScrollbar : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar</param>
/// <param name="vbar">Vertical scrollbar</param>
void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar);
    /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar</param>
/// <param name="vbar">Vertical scrollbar</param>
void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar);
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
/// <param name="width">Value between 0.0 and 1.0</param>
/// <param name="height">Value between 0.0 and 1.0</param>
void GetBarSize(out double width, out double height);
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0</param>
/// <param name="posy">Value between 0.0 and 1.0</param>
void GetBarPosition(out double posx, out double posy);
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0</param>
/// <param name="posy">Value between 0.0 and 1.0</param>
void SetBarPosition(double posx, double posy);
    /// <summary>Update bar visibility.
/// The object will call this function whenever the bar need to be shown or hidden.</summary>
void UpdateBarVisibility();
                            /// <summary>Called when bar is pressed</summary>
    event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt;
    /// <summary>Called when bar is unpressed</summary>
    event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt;
    /// <summary>Called when bar is dragged</summary>
    event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt;
    /// <summary>Called when bar size is changed</summary>
    event EventHandler BarSizeChangedEvt;
    /// <summary>Called when bar position is changed</summary>
    event EventHandler BarPosChangedEvt;
    /// <summary>Callend when bar is shown</summary>
    event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt;
    /// <summary>Called when bar is hidden</summary>
    event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarPressEvt"/>.</summary>
public class IScrollbarBarPressEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarUnpressEvt"/>.</summary>
public class IScrollbarBarUnpressEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarDragEvt"/>.</summary>
public class IScrollbarBarDragEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarShowEvt"/>.</summary>
public class IScrollbarBarShowEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.IScrollbar.BarHideEvt"/>.</summary>
public class IScrollbarBarHideEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.ScrollbarDirection arg { get; set; }
}
sealed public class IScrollbarConcrete : 

IScrollbar
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IScrollbarConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)> eoEvents = new Dictionary<(IntPtr desc, object evtDelegate), (IntPtr evtCallerPtr, Efl.EventCb evtCaller)>();
    private readonly object eventLock = new object();
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_scrollbar_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IScrollbar"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IScrollbarConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IScrollbarConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (eoEvents.Count != 0)
            {
                GCHandle gcHandle = GCHandle.Alloc(eoEvents);
                gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            }

            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    ///<summary>Adds a new event handler, registering it to the native event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtCaller">Delegate to be called by native code on event raising.</param>
    ///<param name="evtDelegate">Managed delegate that will be called by evtCaller on event raising.</param>
    private void AddNativeEventHandler(string lib, string key, Efl.EventCb evtCaller, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
        }

        if (eoEvents.ContainsKey((desc, evtDelegate)))
        {
            Eina.Log.Warning($"Event proxy for event {key} already registered!");
            return;
        }

        IntPtr evtCallerPtr = Marshal.GetFunctionPointerForDelegate(evtCaller);
        if (!Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evtCallerPtr, IntPtr.Zero))
        {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return;
        }

        eoEvents[(desc, evtDelegate)] = (evtCallerPtr, evtCaller);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Removes the given event handler for the given event. For internal use only.</summary>
    ///<param name="lib">The name of the native library definining the event.</param>
    ///<param name="key">The name of the native event.</param>
    ///<param name="evtDelegate">The delegate to be removed.</param>
    private void RemoveNativeEventHandler(string lib, string key, object evtDelegate)
    {
        IntPtr desc = Efl.EventDescription.GetNative(lib, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        var evtPair = (desc, evtDelegate);
        if (eoEvents.TryGetValue(evtPair, out var caller))
        {
            if (!Efl.Eo.Globals.efl_event_callback_del(handle, desc, caller.evtCallerPtr, IntPtr.Zero))
            {
                Eina.Log.Error($"Failed to remove event proxy for event {key}");
                return;
            }

            eoEvents.Remove(evtPair);
            Eina.Error.RaiseIfUnhandledException();
        }
        else
        {
            Eina.Log.Error($"Trying to remove proxy for event {key} when it is nothing registered.");
        }
    }

    /// <summary>Called when bar is pressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarPressEvt.</summary>
    public void OnBarPressEvt(Efl.Ui.IScrollbarBarPressEvt_Args e)
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
    /// <summary>Called when bar is unpressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarUnpressEvt.</summary>
    public void OnBarUnpressEvt(Efl.Ui.IScrollbarBarUnpressEvt_Args e)
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
    /// <summary>Called when bar is dragged</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarDragEvt.</summary>
    public void OnBarDragEvt(Efl.Ui.IScrollbarBarDragEvt_Args e)
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
    /// <summary>Called when bar size is changed</summary>
    public event EventHandler BarSizeChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarSizeChangedEvt.</summary>
    public void OnBarSizeChangedEvt(EventArgs e)
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
    /// <summary>Called when bar position is changed</summary>
    public event EventHandler BarPosChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarPosChangedEvt.</summary>
    public void OnBarPosChangedEvt(EventArgs e)
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
    /// <summary>Callend when bar is shown</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarShowEvt.</summary>
    public void OnBarShowEvt(Efl.Ui.IScrollbarBarShowEvt_Args e)
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
    /// <summary>Called when bar is hidden</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event BarHideEvt.</summary>
    public void OnBarHideEvt(Efl.Ui.IScrollbarBarHideEvt_Args e)
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
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    public void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(this.NativeHandle,out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    public void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(this.NativeHandle,hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0</param>
    /// <param name="height">Value between 0.0 and 1.0</param>
    public void GetBarSize(out double width, out double height) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(this.NativeHandle,out width, out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    public void GetBarPosition(out double posx, out double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(this.NativeHandle,out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    public void SetBarPosition(double posx, double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(this.NativeHandle,posx, posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar need to be shown or hidden.</summary>
    public void UpdateBarVisibility() {
         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IScrollbarConcrete.efl_ui_scrollbar_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            {
                efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IScrollbarConcrete.efl_ui_scrollbar_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        
        public delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_get");

        private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd, out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        hbar = default(Efl.Ui.ScrollbarMode);        vbar = default(Efl.Ui.ScrollbarMode);                            
                try
                {
                    ((IScrollbar)wrapper).GetBarMode(out hbar, out vbar);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((IScrollbar)wrapper).SetBarMode(hbar, vbar);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        width = default(double);        height = default(double);                            
                try
                {
                    ((IScrollbar)wrapper).GetBarSize(out width, out height);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        posx = default(double);        posy = default(double);                            
                try
                {
                    ((IScrollbar)wrapper).GetBarPosition(out posx, out posy);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((IScrollbar)wrapper).SetBarPosition(posx, posy);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IScrollbar)wrapper).UpdateBarVisibility();
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

public enum ScrollbarMode
{
/// <summary>Visible if necessary</summary>
Auto = 0,
/// <summary>Always visible</summary>
On = 1,
/// <summary>Always invisible</summary>
Off = 2,
/// <summary>For internal use only</summary>
Last = 3,
}

}

}

namespace Efl {

namespace Ui {

public enum ScrollbarDirection
{
Horizontal = 0,
Vertical = 1,
Last = 2,
}

}

}

