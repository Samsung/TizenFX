#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ImageZoomable.DownloadProgressEvt"/>.</summary>
public class ImageZoomableDownloadProgressEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.Photocam.Progress arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ImageZoomable.DownloadErrorEvt"/>.</summary>
public class ImageZoomableDownloadErrorEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.Photocam.Error arg { get; set; }
}
/// <summary>Elementary Image Zoomable class</summary>
[ImageZoomableNativeInherit]
public class ImageZoomable : Efl.Ui.Image, Efl.Eo.IWrapper,Efl.Ui.IScrollable,Efl.Ui.IScrollableInteractive,Efl.Ui.IScrollbar,Efl.Ui.IZoom
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ImageZoomable))
                return Efl.Ui.ImageZoomableNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_image_zoomable_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public ImageZoomable(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_image_zoomable_class_get(), typeof(ImageZoomable), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ImageZoomable(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ImageZoomable(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
private static object PressEvtKey = new object();
    /// <summary>Called when photocam got pressed</summary>
    public event EventHandler PressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_PRESS";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_PressEvt_delegate)) {
                    eventHandlers.AddHandler(PressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_PRESS";
                if (RemoveNativeEventHandler(key, this.evt_PressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PressEvt.</summary>
    public void On_PressEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PressEvt_delegate;
    private void on_PressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadEvtKey = new object();
    /// <summary>Called when photocam loading started</summary>
    public event EventHandler LoadEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_LoadEvt_delegate)) {
                    eventHandlers.AddHandler(LoadEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD";
                if (RemoveNativeEventHandler(key, this.evt_LoadEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadEvt.</summary>
    public void On_LoadEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[LoadEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadEvt_delegate;
    private void on_LoadEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_LoadEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadedEvtKey = new object();
    /// <summary>Called when photocam loading finished</summary>
    public event EventHandler LoadedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_LoadedEvt_delegate)) {
                    eventHandlers.AddHandler(LoadedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED";
                if (RemoveNativeEventHandler(key, this.evt_LoadedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadedEvt.</summary>
    public void On_LoadedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[LoadedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadedEvt_delegate;
    private void on_LoadedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_LoadedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadDetailEvtKey = new object();
    /// <summary>Called when photocal detail loading started</summary>
    public event EventHandler LoadDetailEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD_DETAIL";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_LoadDetailEvt_delegate)) {
                    eventHandlers.AddHandler(LoadDetailEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD_DETAIL";
                if (RemoveNativeEventHandler(key, this.evt_LoadDetailEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadDetailEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadDetailEvt.</summary>
    public void On_LoadDetailEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[LoadDetailEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadDetailEvt_delegate;
    private void on_LoadDetailEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_LoadDetailEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadedDetailEvtKey = new object();
    /// <summary>Called when photocam detail loading finished</summary>
    public event EventHandler LoadedDetailEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED_DETAIL";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_LoadedDetailEvt_delegate)) {
                    eventHandlers.AddHandler(LoadedDetailEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED_DETAIL";
                if (RemoveNativeEventHandler(key, this.evt_LoadedDetailEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadedDetailEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadedDetailEvt.</summary>
    public void On_LoadedDetailEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[LoadedDetailEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadedDetailEvt_delegate;
    private void on_LoadedDetailEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_LoadedDetailEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DownloadStartEvtKey = new object();
    /// <summary>Called when photocam download started</summary>
    public event EventHandler DownloadStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_START";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_DownloadStartEvt_delegate)) {
                    eventHandlers.AddHandler(DownloadStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_START";
                if (RemoveNativeEventHandler(key, this.evt_DownloadStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DownloadStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DownloadStartEvt.</summary>
    public void On_DownloadStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[DownloadStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DownloadStartEvt_delegate;
    private void on_DownloadStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_DownloadStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DownloadProgressEvtKey = new object();
    /// <summary>Called when photocam download progress updated</summary>
    public event EventHandler<Efl.Ui.ImageZoomableDownloadProgressEvt_Args> DownloadProgressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_PROGRESS";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_DownloadProgressEvt_delegate)) {
                    eventHandlers.AddHandler(DownloadProgressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_PROGRESS";
                if (RemoveNativeEventHandler(key, this.evt_DownloadProgressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DownloadProgressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DownloadProgressEvt.</summary>
    public void On_DownloadProgressEvt(Efl.Ui.ImageZoomableDownloadProgressEvt_Args e)
    {
        EventHandler<Efl.Ui.ImageZoomableDownloadProgressEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ImageZoomableDownloadProgressEvt_Args>)eventHandlers[DownloadProgressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DownloadProgressEvt_delegate;
    private void on_DownloadProgressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ImageZoomableDownloadProgressEvt_Args args = new Efl.Ui.ImageZoomableDownloadProgressEvt_Args();
      args.arg = default(Elm.Photocam.Progress);
        try {
            On_DownloadProgressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DownloadDoneEvtKey = new object();
    /// <summary>Called when photocam download finished</summary>
    public event EventHandler DownloadDoneEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_DONE";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_DownloadDoneEvt_delegate)) {
                    eventHandlers.AddHandler(DownloadDoneEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_DONE";
                if (RemoveNativeEventHandler(key, this.evt_DownloadDoneEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DownloadDoneEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DownloadDoneEvt.</summary>
    public void On_DownloadDoneEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[DownloadDoneEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DownloadDoneEvt_delegate;
    private void on_DownloadDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_DownloadDoneEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DownloadErrorEvtKey = new object();
    /// <summary>Called when photocam download failed</summary>
    public event EventHandler<Efl.Ui.ImageZoomableDownloadErrorEvt_Args> DownloadErrorEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_ERROR";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_DownloadErrorEvt_delegate)) {
                    eventHandlers.AddHandler(DownloadErrorEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_ERROR";
                if (RemoveNativeEventHandler(key, this.evt_DownloadErrorEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DownloadErrorEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DownloadErrorEvt.</summary>
    public void On_DownloadErrorEvt(Efl.Ui.ImageZoomableDownloadErrorEvt_Args e)
    {
        EventHandler<Efl.Ui.ImageZoomableDownloadErrorEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ImageZoomableDownloadErrorEvt_Args>)eventHandlers[DownloadErrorEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DownloadErrorEvt_delegate;
    private void on_DownloadErrorEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ImageZoomableDownloadErrorEvt_Args args = new Efl.Ui.ImageZoomableDownloadErrorEvt_Args();
      args.arg = default(Elm.Photocam.Error);
        try {
            On_DownloadErrorEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollStartEvtKey = new object();
    /// <summary>Called when scroll operation starts</summary>
    public event EventHandler ScrollStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollStartEvt.</summary>
    public void On_ScrollStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollStartEvt_delegate;
    private void on_ScrollStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollEvtKey = new object();
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL";
                if (RemoveNativeEventHandler(key, this.evt_ScrollEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollEvt.</summary>
    public void On_ScrollEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollEvt_delegate;
    private void on_ScrollEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollStopEvtKey = new object();
    /// <summary>Called when scroll operation stops</summary>
    public event EventHandler ScrollStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollStopEvt.</summary>
    public void On_ScrollStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollStopEvt_delegate;
    private void on_ScrollStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollUpEvtKey = new object();
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollUpEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollUpEvt.</summary>
    public void On_ScrollUpEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollUpEvt_delegate;
    private void on_ScrollUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDownEvtKey = new object();
    /// <summary>Called when scrolling downwards</summary>
    public event EventHandler ScrollDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDownEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDownEvt.</summary>
    public void On_ScrollDownEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDownEvt_delegate;
    private void on_ScrollDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollLeftEvtKey = new object();
    /// <summary>Called when scrolling left</summary>
    public event EventHandler ScrollLeftEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollLeftEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                if (RemoveNativeEventHandler(key, this.evt_ScrollLeftEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollLeftEvt.</summary>
    public void On_ScrollLeftEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollLeftEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollLeftEvt_delegate;
    private void on_ScrollLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollLeftEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollRightEvtKey = new object();
    /// <summary>Called when scrolling right</summary>
    public event EventHandler ScrollRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollRightEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_ScrollRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollRightEvt.</summary>
    public void On_ScrollRightEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollRightEvt_delegate;
    private void on_ScrollRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeUpEvtKey = new object();
    /// <summary>Called when hitting the top edge</summary>
    public event EventHandler EdgeUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeUpEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                if (RemoveNativeEventHandler(key, this.evt_EdgeUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeUpEvt.</summary>
    public void On_EdgeUpEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeUpEvt_delegate;
    private void on_EdgeUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeDownEvtKey = new object();
    /// <summary>Called when hitting the bottom edge</summary>
    public event EventHandler EdgeDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeDownEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_EdgeDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeDownEvt.</summary>
    public void On_EdgeDownEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeDownEvt_delegate;
    private void on_EdgeDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeLeftEvtKey = new object();
    /// <summary>Called when hitting the left edge</summary>
    public event EventHandler EdgeLeftEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeLeftEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                if (RemoveNativeEventHandler(key, this.evt_EdgeLeftEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeLeftEvt.</summary>
    public void On_EdgeLeftEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeLeftEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeLeftEvt_delegate;
    private void on_EdgeLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeLeftEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeRightEvtKey = new object();
    /// <summary>Called when hitting the right edge</summary>
    public event EventHandler EdgeRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeRightEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_EdgeRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeRightEvt.</summary>
    public void On_EdgeRightEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeRightEvt_delegate;
    private void on_EdgeRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollAnimStartEvtKey = new object();
    /// <summary>Called when scroll animation starts</summary>
    public event EventHandler ScrollAnimStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollAnimStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollAnimStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollAnimStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollAnimStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStartEvt.</summary>
    public void On_ScrollAnimStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollAnimStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollAnimStartEvt_delegate;
    private void on_ScrollAnimStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollAnimStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollAnimStopEvtKey = new object();
    /// <summary>Called when scroll animation stopps</summary>
    public event EventHandler ScrollAnimStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollAnimStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollAnimStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollAnimStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollAnimStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStopEvt.</summary>
    public void On_ScrollAnimStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollAnimStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollAnimStopEvt_delegate;
    private void on_ScrollAnimStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollAnimStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDragStartEvtKey = new object();
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDragStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDragStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStartEvt.</summary>
    public void On_ScrollDragStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDragStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDragStartEvt_delegate;
    private void on_ScrollDragStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDragStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDragStopEvtKey = new object();
    /// <summary>Called when scroll drag stops</summary>
    public event EventHandler ScrollDragStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDragStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDragStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStopEvt.</summary>
    public void On_ScrollDragStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDragStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDragStopEvt_delegate;
    private void on_ScrollDragStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDragStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarPressEvtKey = new object();
    /// <summary>Called when bar is pressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarPressEvt_delegate)) {
                    eventHandlers.AddHandler(BarPressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                if (RemoveNativeEventHandler(key, this.evt_BarPressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarPressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarPressEvt.</summary>
    public void On_BarPressEvt(Efl.Ui.IScrollbarBarPressEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args>)eventHandlers[BarPressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarPressEvt_delegate;
    private void on_BarPressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarPressEvt_Args args = new Efl.Ui.IScrollbarBarPressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarPressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarUnpressEvtKey = new object();
    /// <summary>Called when bar is unpressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarUnpressEvt_delegate)) {
                    eventHandlers.AddHandler(BarUnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                if (RemoveNativeEventHandler(key, this.evt_BarUnpressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarUnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarUnpressEvt.</summary>
    public void On_BarUnpressEvt(Efl.Ui.IScrollbarBarUnpressEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args>)eventHandlers[BarUnpressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarUnpressEvt_delegate;
    private void on_BarUnpressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarUnpressEvt_Args args = new Efl.Ui.IScrollbarBarUnpressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarUnpressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarDragEvtKey = new object();
    /// <summary>Called when bar is dragged</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarDragEvt_delegate)) {
                    eventHandlers.AddHandler(BarDragEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                if (RemoveNativeEventHandler(key, this.evt_BarDragEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarDragEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarDragEvt.</summary>
    public void On_BarDragEvt(Efl.Ui.IScrollbarBarDragEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args>)eventHandlers[BarDragEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarDragEvt_delegate;
    private void on_BarDragEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarDragEvt_Args args = new Efl.Ui.IScrollbarBarDragEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarDragEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarSizeChangedEvtKey = new object();
    /// <summary>Called when bar size is changed</summary>
    public event EventHandler BarSizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarSizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(BarSizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_BarSizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarSizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarSizeChangedEvt.</summary>
    public void On_BarSizeChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[BarSizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarSizeChangedEvt_delegate;
    private void on_BarSizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_BarSizeChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarPosChangedEvtKey = new object();
    /// <summary>Called when bar position is changed</summary>
    public event EventHandler BarPosChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarPosChangedEvt_delegate)) {
                    eventHandlers.AddHandler(BarPosChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_BarPosChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarPosChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarPosChangedEvt.</summary>
    public void On_BarPosChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[BarPosChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarPosChangedEvt_delegate;
    private void on_BarPosChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_BarPosChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarShowEvtKey = new object();
    /// <summary>Callend when bar is shown</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarShowEvt_delegate)) {
                    eventHandlers.AddHandler(BarShowEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                if (RemoveNativeEventHandler(key, this.evt_BarShowEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarShowEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarShowEvt.</summary>
    public void On_BarShowEvt(Efl.Ui.IScrollbarBarShowEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args>)eventHandlers[BarShowEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarShowEvt_delegate;
    private void on_BarShowEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarShowEvt_Args args = new Efl.Ui.IScrollbarBarShowEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarShowEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarHideEvtKey = new object();
    /// <summary>Called when bar is hidden</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarHideEvt_delegate)) {
                    eventHandlers.AddHandler(BarHideEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                if (RemoveNativeEventHandler(key, this.evt_BarHideEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarHideEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarHideEvt.</summary>
    public void On_BarHideEvt(Efl.Ui.IScrollbarBarHideEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args>)eventHandlers[BarHideEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarHideEvt_delegate;
    private void on_BarHideEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarHideEvt_Args args = new Efl.Ui.IScrollbarBarHideEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarHideEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ZoomStartEvtKey = new object();
    /// <summary>Called when zooming started</summary>
    public event EventHandler ZoomStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomStartEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_START";
                if (RemoveNativeEventHandler(key, this.evt_ZoomStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ZoomStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ZoomStartEvt.</summary>
    public void On_ZoomStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ZoomStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ZoomStartEvt_delegate;
    private void on_ZoomStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ZoomStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ZoomStopEvtKey = new object();
    /// <summary>Called when zooming stopped</summary>
    public event EventHandler ZoomStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomStopEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ZoomStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ZoomStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ZoomStopEvt.</summary>
    public void On_ZoomStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ZoomStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ZoomStopEvt_delegate;
    private void on_ZoomStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ZoomStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ZoomChangeEvtKey = new object();
    /// <summary>Called when zooming changed</summary>
    public event EventHandler ZoomChangeEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ZoomChangeEvt_delegate)) {
                    eventHandlers.AddHandler(ZoomChangeEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                if (RemoveNativeEventHandler(key, this.evt_ZoomChangeEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ZoomChangeEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ZoomChangeEvt.</summary>
    public void On_ZoomChangeEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ZoomChangeEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ZoomChangeEvt_delegate;
    private void on_ZoomChangeEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ZoomChangeEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_PressEvt_delegate = new Efl.EventCb(on_PressEvt_NativeCallback);
        evt_LoadEvt_delegate = new Efl.EventCb(on_LoadEvt_NativeCallback);
        evt_LoadedEvt_delegate = new Efl.EventCb(on_LoadedEvt_NativeCallback);
        evt_LoadDetailEvt_delegate = new Efl.EventCb(on_LoadDetailEvt_NativeCallback);
        evt_LoadedDetailEvt_delegate = new Efl.EventCb(on_LoadedDetailEvt_NativeCallback);
        evt_DownloadStartEvt_delegate = new Efl.EventCb(on_DownloadStartEvt_NativeCallback);
        evt_DownloadProgressEvt_delegate = new Efl.EventCb(on_DownloadProgressEvt_NativeCallback);
        evt_DownloadDoneEvt_delegate = new Efl.EventCb(on_DownloadDoneEvt_NativeCallback);
        evt_DownloadErrorEvt_delegate = new Efl.EventCb(on_DownloadErrorEvt_NativeCallback);
        evt_ScrollStartEvt_delegate = new Efl.EventCb(on_ScrollStartEvt_NativeCallback);
        evt_ScrollEvt_delegate = new Efl.EventCb(on_ScrollEvt_NativeCallback);
        evt_ScrollStopEvt_delegate = new Efl.EventCb(on_ScrollStopEvt_NativeCallback);
        evt_ScrollUpEvt_delegate = new Efl.EventCb(on_ScrollUpEvt_NativeCallback);
        evt_ScrollDownEvt_delegate = new Efl.EventCb(on_ScrollDownEvt_NativeCallback);
        evt_ScrollLeftEvt_delegate = new Efl.EventCb(on_ScrollLeftEvt_NativeCallback);
        evt_ScrollRightEvt_delegate = new Efl.EventCb(on_ScrollRightEvt_NativeCallback);
        evt_EdgeUpEvt_delegate = new Efl.EventCb(on_EdgeUpEvt_NativeCallback);
        evt_EdgeDownEvt_delegate = new Efl.EventCb(on_EdgeDownEvt_NativeCallback);
        evt_EdgeLeftEvt_delegate = new Efl.EventCb(on_EdgeLeftEvt_NativeCallback);
        evt_EdgeRightEvt_delegate = new Efl.EventCb(on_EdgeRightEvt_NativeCallback);
        evt_ScrollAnimStartEvt_delegate = new Efl.EventCb(on_ScrollAnimStartEvt_NativeCallback);
        evt_ScrollAnimStopEvt_delegate = new Efl.EventCb(on_ScrollAnimStopEvt_NativeCallback);
        evt_ScrollDragStartEvt_delegate = new Efl.EventCb(on_ScrollDragStartEvt_NativeCallback);
        evt_ScrollDragStopEvt_delegate = new Efl.EventCb(on_ScrollDragStopEvt_NativeCallback);
        evt_BarPressEvt_delegate = new Efl.EventCb(on_BarPressEvt_NativeCallback);
        evt_BarUnpressEvt_delegate = new Efl.EventCb(on_BarUnpressEvt_NativeCallback);
        evt_BarDragEvt_delegate = new Efl.EventCb(on_BarDragEvt_NativeCallback);
        evt_BarSizeChangedEvt_delegate = new Efl.EventCb(on_BarSizeChangedEvt_NativeCallback);
        evt_BarPosChangedEvt_delegate = new Efl.EventCb(on_BarPosChangedEvt_NativeCallback);
        evt_BarShowEvt_delegate = new Efl.EventCb(on_BarShowEvt_NativeCallback);
        evt_BarHideEvt_delegate = new Efl.EventCb(on_BarHideEvt_NativeCallback);
        evt_ZoomStartEvt_delegate = new Efl.EventCb(on_ZoomStartEvt_NativeCallback);
        evt_ZoomStopEvt_delegate = new Efl.EventCb(on_ZoomStopEvt_NativeCallback);
        evt_ZoomChangeEvt_delegate = new Efl.EventCb(on_ZoomChangeEvt_NativeCallback);
    }
    /// <summary>Get the gesture state for photocam.
    /// This gets the current gesture state for the photocam object.</summary>
    /// <returns>The gesture state.</returns>
    virtual public bool GetGestureEnabled() {
         var _ret_var = Efl.Ui.ImageZoomableNativeInherit.efl_ui_image_zoomable_gesture_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the gesture state for photocam.
    /// This sets the gesture state to on or off for photocam. The default is off. This will start multi touch zooming.</summary>
    /// <param name="gesture">The gesture state.</param>
    /// <returns></returns>
    virtual public void SetGestureEnabled( bool gesture) {
                                 Efl.Ui.ImageZoomableNativeInherit.efl_ui_image_zoomable_gesture_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), gesture);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the region of the image that is currently shown
    /// See also <see cref="Efl.Ui.ImageZoomable.SetImageRegion"/>.</summary>
    /// <returns>The region in the original image pixels.</returns>
    virtual public Eina.Rect GetImageRegion() {
         var _ret_var = Efl.Ui.ImageZoomableNativeInherit.efl_ui_image_zoomable_image_region_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the viewed region of the image
    /// This shows the region of the image without using animation.</summary>
    /// <param name="region">The region in the original image pixels.</param>
    /// <returns></returns>
    virtual public void SetImageRegion( Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Ui.ImageZoomableNativeInherit.efl_ui_image_zoomable_image_region_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_region);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    virtual public Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    /// <returns></returns>
    virtual public void SetContentPos( Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    virtual public Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    virtual public Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    /// <returns></returns>
    virtual public void GetBounceEnabled( out bool horiz,  out bool vert) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out horiz,  out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    /// <returns></returns>
    virtual public void SetBounceEnabled( bool horiz,  bool vert) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), horiz,  vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    virtual public bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetScrollFreeze( bool freeze) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    virtual public bool GetScrollHold() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetScrollHold( bool hold) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    /// <returns></returns>
    virtual public void GetLooping( out bool loop_h,  out bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out loop_h,  out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    /// <returns></returns>
    virtual public void SetLooping( bool loop_h,  bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), loop_h,  loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    /// <returns></returns>
    virtual public void SetMovementBlock( Efl.Ui.ScrollBlock block) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), block);
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
    /// <returns></returns>
    virtual public void GetGravity( out double x,  out double y) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
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
    /// <returns></returns>
    virtual public void SetGravity( double x,  double y) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    /// <returns></returns>
    virtual public void SetMatchContent( bool w,  bool h) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), w,  h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    virtual public Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    /// <returns></returns>
    virtual public void SetStepSize( Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    /// <returns></returns>
    virtual public void Scroll( Eina.Rect rect,  bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_rect,  animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    /// <returns></returns>
    virtual public void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out hbar,  out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    /// <returns></returns>
    virtual public void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hbar,  vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0</param>
    /// <param name="height">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void GetBarSize( out double width,  out double height) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out width,  out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void GetBarPosition( out double posx,  out double posy) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out posx,  out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void SetBarPosition( double posx,  double posy) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), posx,  posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar need to be shown or hidden.</summary>
    /// <returns></returns>
    virtual public void UpdateBarVisibility() {
         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <returns>The paused state.</returns>
    virtual public bool GetZoomAnimation() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_animation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <param name="paused">The paused state.</param>
    /// <returns></returns>
    virtual public void SetZoomAnimation( bool paused) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_animation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), paused);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom level of the photo
    /// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
    /// <returns>The zoom level to set</returns>
    virtual public double GetZoomLevel() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_level_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom level of the photo
    /// This sets the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).</summary>
    /// <param name="zoom">The zoom level to set</param>
    /// <returns></returns>
    virtual public void SetZoomLevel( double zoom) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_level_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), zoom);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the zoom mode
    /// This gets the current zoom mode of the zoomable object.</summary>
    /// <returns>The zoom mode.</returns>
    virtual public Efl.Ui.ZoomMode GetZoomMode() {
         var _ret_var = Efl.Ui.IZoomNativeInherit.efl_ui_zoom_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the zoom mode
    /// This sets the zoom mode to manual or one of several automatic levels. Manual (EFL_UI_ZOOM_MODE_MANUAL) means that zoom is set manually by <see cref="Efl.Ui.IZoom.SetZoomLevel"/> and will stay at that level until changed by code or until zoom mode is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on properties.
    /// 
    /// #EFL_UI_ZOOM_MODE_AUTO_FIT) will adjust zoom so the photo fits EXACTLY inside the scroll frame with no pixels outside this region. #EFL_UI_ZOOM_MODE_AUTO_FILL will be similar but ensure no pixels within the frame are left unfilled.</summary>
    /// <param name="mode">The zoom mode.</param>
    /// <returns></returns>
    virtual public void SetZoomMode( Efl.Ui.ZoomMode mode) {
                                 Efl.Ui.IZoomNativeInherit.efl_ui_zoom_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the gesture state for photocam.
/// This gets the current gesture state for the photocam object.</summary>
/// <value>The gesture state.</value>
    public bool GestureEnabled {
        get { return GetGestureEnabled(); }
        set { SetGestureEnabled( value); }
    }
    /// <summary>Get the region of the image that is currently shown
/// See also <see cref="Efl.Ui.ImageZoomable.SetImageRegion"/>.</summary>
/// <value>The region in the original image pixels.</value>
    public Eina.Rect ImageRegion {
        get { return GetImageRegion(); }
        set { SetImageRegion( value); }
    }
    /// <summary>The content position</summary>
/// <value>The position is virtual value, (0, 0) starting at the top-left.</value>
    public Eina.Position2D ContentPos {
        get { return GetContentPos(); }
        set { SetContentPos( value); }
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
        set { SetScrollFreeze( value); }
    }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
/// <value><c>true</c> if hold, <c>false</c> otherwise</value>
    public bool ScrollHold {
        get { return GetScrollHold(); }
        set { SetScrollHold( value); }
    }
    /// <summary>Blocking of scrolling (per axis)
/// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
/// <value>Which axis (or axes) to block</value>
    public Efl.Ui.ScrollBlock MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock( value); }
    }
    /// <summary>Control the step size
/// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
/// <value>The step size in pixels</value>
    public Eina.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize( value); }
    }
    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
/// <value>The paused state.</value>
    public bool ZoomAnimation {
        get { return GetZoomAnimation(); }
        set { SetZoomAnimation( value); }
    }
    /// <summary>Get the zoom level of the photo
/// This returns the current zoom level of the zoomable object. Note that if you set the fill mode to other than #EFL_UI_ZOOM_MODE_MANUAL (which is the default), the zoom level may be changed at any time by the  zoomable object itself to account for photo size and zoomable viewport size.</summary>
/// <value>The zoom level to set</value>
    public double ZoomLevel {
        get { return GetZoomLevel(); }
        set { SetZoomLevel( value); }
    }
    /// <summary>Get the zoom mode
/// This gets the current zoom mode of the zoomable object.</summary>
/// <value>The zoom mode.</value>
    public Efl.Ui.ZoomMode ZoomMode {
        get { return GetZoomMode(); }
        set { SetZoomMode( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ImageZoomable.efl_ui_image_zoomable_class_get();
    }
}
public class ImageZoomableNativeInherit : Efl.Ui.ImageNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_image_zoomable_gesture_enabled_get_static_delegate == null)
            efl_ui_image_zoomable_gesture_enabled_get_static_delegate = new efl_ui_image_zoomable_gesture_enabled_get_delegate(gesture_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGestureEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_zoomable_gesture_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_gesture_enabled_get_static_delegate)});
        if (efl_ui_image_zoomable_gesture_enabled_set_static_delegate == null)
            efl_ui_image_zoomable_gesture_enabled_set_static_delegate = new efl_ui_image_zoomable_gesture_enabled_set_delegate(gesture_enabled_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGestureEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_zoomable_gesture_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_gesture_enabled_set_static_delegate)});
        if (efl_ui_image_zoomable_image_region_get_static_delegate == null)
            efl_ui_image_zoomable_image_region_get_static_delegate = new efl_ui_image_zoomable_image_region_get_delegate(image_region_get);
        if (methods.FirstOrDefault(m => m.Name == "GetImageRegion") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_zoomable_image_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_image_region_get_static_delegate)});
        if (efl_ui_image_zoomable_image_region_set_static_delegate == null)
            efl_ui_image_zoomable_image_region_set_static_delegate = new efl_ui_image_zoomable_image_region_set_delegate(image_region_set);
        if (methods.FirstOrDefault(m => m.Name == "SetImageRegion") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_zoomable_image_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_image_region_set_static_delegate)});
        if (efl_ui_scrollable_content_pos_get_static_delegate == null)
            efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContentPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate)});
        if (efl_ui_scrollable_content_pos_set_static_delegate == null)
            efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
        if (methods.FirstOrDefault(m => m.Name == "SetContentPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate)});
        if (efl_ui_scrollable_content_size_get_static_delegate == null)
            efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContentSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate)});
        if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
            efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetViewportGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate)});
        if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
            efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBounceEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate)});
        if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
            efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBounceEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate)});
        if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
            efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScrollFreeze") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate)});
        if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
            efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScrollFreeze") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate)});
        if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
            efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScrollHold") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate)});
        if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
            efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScrollHold") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate)});
        if (efl_ui_scrollable_looping_get_static_delegate == null)
            efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLooping") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate)});
        if (efl_ui_scrollable_looping_set_static_delegate == null)
            efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLooping") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate)});
        if (efl_ui_scrollable_movement_block_get_static_delegate == null)
            efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMovementBlock") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate)});
        if (efl_ui_scrollable_movement_block_set_static_delegate == null)
            efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMovementBlock") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate)});
        if (efl_ui_scrollable_gravity_get_static_delegate == null)
            efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGravity") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate)});
        if (efl_ui_scrollable_gravity_set_static_delegate == null)
            efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGravity") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate)});
        if (efl_ui_scrollable_match_content_set_static_delegate == null)
            efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMatchContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate)});
        if (efl_ui_scrollable_step_size_get_static_delegate == null)
            efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStepSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate)});
        if (efl_ui_scrollable_step_size_set_static_delegate == null)
            efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetStepSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate)});
        if (efl_ui_scrollable_scroll_static_delegate == null)
            efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
        if (methods.FirstOrDefault(m => m.Name == "Scroll") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate)});
        if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate)});
        if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBarMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate)});
        if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate)});
        if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate)});
        if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBarPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate)});
        if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
        if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate)});
        if (efl_ui_zoom_animation_get_static_delegate == null)
            efl_ui_zoom_animation_get_static_delegate = new efl_ui_zoom_animation_get_delegate(zoom_animation_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomAnimation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_get_static_delegate)});
        if (efl_ui_zoom_animation_set_static_delegate == null)
            efl_ui_zoom_animation_set_static_delegate = new efl_ui_zoom_animation_set_delegate(zoom_animation_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomAnimation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_animation_set_static_delegate)});
        if (efl_ui_zoom_level_get_static_delegate == null)
            efl_ui_zoom_level_get_static_delegate = new efl_ui_zoom_level_get_delegate(zoom_level_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomLevel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_level_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_get_static_delegate)});
        if (efl_ui_zoom_level_set_static_delegate == null)
            efl_ui_zoom_level_set_static_delegate = new efl_ui_zoom_level_set_delegate(zoom_level_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomLevel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_level_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_level_set_static_delegate)});
        if (efl_ui_zoom_mode_get_static_delegate == null)
            efl_ui_zoom_mode_get_static_delegate = new efl_ui_zoom_mode_get_delegate(zoom_mode_get);
        if (methods.FirstOrDefault(m => m.Name == "GetZoomMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_get_static_delegate)});
        if (efl_ui_zoom_mode_set_static_delegate == null)
            efl_ui_zoom_mode_set_static_delegate = new efl_ui_zoom_mode_set_delegate(zoom_mode_set);
        if (methods.FirstOrDefault(m => m.Name == "SetZoomMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_zoom_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_zoom_mode_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.ImageZoomable.efl_ui_image_zoomable_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ImageZoomable.efl_ui_image_zoomable_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_image_zoomable_gesture_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_image_zoomable_gesture_enabled_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_get_api_delegate> efl_ui_image_zoomable_gesture_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_get_api_delegate>(_Module, "efl_ui_image_zoomable_gesture_enabled_get");
     private static bool gesture_enabled_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_image_zoomable_gesture_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetGestureEnabled();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_image_zoomable_gesture_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_image_zoomable_gesture_enabled_get_delegate efl_ui_image_zoomable_gesture_enabled_get_static_delegate;


     private delegate void efl_ui_image_zoomable_gesture_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool gesture);


     public delegate void efl_ui_image_zoomable_gesture_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool gesture);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_set_api_delegate> efl_ui_image_zoomable_gesture_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_set_api_delegate>(_Module, "efl_ui_image_zoomable_gesture_enabled_set");
     private static void gesture_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool gesture)
    {
        Eina.Log.Debug("function efl_ui_image_zoomable_gesture_enabled_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetGestureEnabled( gesture);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_image_zoomable_gesture_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  gesture);
        }
    }
    private static efl_ui_image_zoomable_gesture_enabled_set_delegate efl_ui_image_zoomable_gesture_enabled_set_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_ui_image_zoomable_image_region_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_ui_image_zoomable_image_region_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_get_api_delegate> efl_ui_image_zoomable_image_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_get_api_delegate>(_Module, "efl_ui_image_zoomable_image_region_get");
     private static Eina.Rect.NativeStruct image_region_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_image_zoomable_image_region_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetImageRegion();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_image_zoomable_image_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_image_zoomable_image_region_get_delegate efl_ui_image_zoomable_image_region_get_static_delegate;


     private delegate void efl_ui_image_zoomable_image_region_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct region);


     public delegate void efl_ui_image_zoomable_image_region_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct region);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_set_api_delegate> efl_ui_image_zoomable_image_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_set_api_delegate>(_Module, "efl_ui_image_zoomable_image_region_set");
     private static void image_region_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct region)
    {
        Eina.Log.Debug("function efl_ui_image_zoomable_image_region_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_region = region;
                            
            try {
                ((ImageZoomable)wrapper).SetImageRegion( _in_region);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_image_zoomable_image_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  region);
        }
    }
    private static efl_ui_image_zoomable_image_region_set_delegate efl_ui_image_zoomable_image_region_set_static_delegate;


     private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(_Module, "efl_ui_scrollable_content_pos_get");
     private static Eina.Position2D.NativeStruct content_pos_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetContentPos();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;


     private delegate void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct pos);


     public delegate void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct pos);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(_Module, "efl_ui_scrollable_content_pos_set");
     private static void content_pos_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_pos = pos;
                            
            try {
                ((ImageZoomable)wrapper).SetContentPos( _in_pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
        }
    }
    private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(_Module, "efl_ui_scrollable_content_size_get");
     private static Eina.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetContentSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(_Module, "efl_ui_scrollable_viewport_geometry_get");
     private static Eina.Rect.NativeStruct viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetViewportGeometry();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;


     private delegate void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);


     public delegate void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_get");
     private static void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd,  out bool horiz,  out bool vert)
    {
        Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    horiz = default(bool);        vert = default(bool);                            
            try {
                ((ImageZoomable)wrapper).GetBounceEnabled( out horiz,  out vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out horiz,  out vert);
        }
    }
    private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;


     private delegate void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);


     public delegate void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_set");
     private static void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool horiz,  bool vert)
    {
        Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetBounceEnabled( horiz,  vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horiz,  vert);
        }
    }
    private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_get");
     private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetScrollFreeze();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;


     private delegate void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool freeze);


     public delegate void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_set");
     private static void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd,  bool freeze)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetScrollFreeze( freeze);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  freeze);
        }
    }
    private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_get");
     private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetScrollHold();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;


     private delegate void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hold);


     public delegate void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hold);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_set");
     private static void scroll_hold_set(System.IntPtr obj, System.IntPtr pd,  bool hold)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetScrollHold( hold);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hold);
        }
    }
    private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;


     private delegate void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);


     public delegate void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(_Module, "efl_ui_scrollable_looping_get");
     private static void looping_get(System.IntPtr obj, System.IntPtr pd,  out bool loop_h,  out bool loop_v)
    {
        Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    loop_h = default(bool);        loop_v = default(bool);                            
            try {
                ((ImageZoomable)wrapper).GetLooping( out loop_h,  out loop_v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_looping_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out loop_h,  out loop_v);
        }
    }
    private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;


     private delegate void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);


     public delegate void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(_Module, "efl_ui_scrollable_looping_set");
     private static void looping_set(System.IntPtr obj, System.IntPtr pd,  bool loop_h,  bool loop_v)
    {
        Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetLooping( loop_h,  loop_v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_looping_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  loop_h,  loop_v);
        }
    }
    private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;


     private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(_Module, "efl_ui_scrollable_movement_block_get");
     private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetMovementBlock();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;


     private delegate void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollBlock block);


     public delegate void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollBlock block);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(_Module, "efl_ui_scrollable_movement_block_set");
     private static void movement_block_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block)
    {
        Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetMovementBlock( block);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  block);
        }
    }
    private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;


     private delegate void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


     public delegate void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(_Module, "efl_ui_scrollable_gravity_get");
     private static void gravity_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
    {
        Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    x = default(double);        y = default(double);                            
            try {
                ((ImageZoomable)wrapper).GetGravity( out x,  out y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_gravity_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
        }
    }
    private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;


     private delegate void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


     public delegate void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,   double x,   double y);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(_Module, "efl_ui_scrollable_gravity_set");
     private static void gravity_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
    {
        Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetGravity( x,  y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_gravity_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
        }
    }
    private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;


     private delegate void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);


     public delegate void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(_Module, "efl_ui_scrollable_match_content_set");
     private static void match_content_set(System.IntPtr obj, System.IntPtr pd,  bool w,  bool h)
    {
        Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetMatchContent( w,  h);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_match_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w,  h);
        }
    }
    private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;


     private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(_Module, "efl_ui_scrollable_step_size_get");
     private static Eina.Position2D.NativeStruct step_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_step_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetStepSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;


     private delegate void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct step);


     public delegate void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct step);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(_Module, "efl_ui_scrollable_step_size_set");
     private static void step_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct step)
    {
        Eina.Log.Debug("function efl_ui_scrollable_step_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_step = step;
                            
            try {
                ((ImageZoomable)wrapper).SetStepSize( _in_step);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_step_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  step);
        }
    }
    private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;


     private delegate void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);


     public delegate void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(_Module, "efl_ui_scrollable_scroll");
     private static void scroll(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect,  bool animation)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_rect = rect;
                                                    
            try {
                ((ImageZoomable)wrapper).Scroll( _in_rect,  animation);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  animation);
        }
    }
    private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;


     private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);


     public delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_get");
     private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    hbar = default(Efl.Ui.ScrollbarMode);        vbar = default(Efl.Ui.ScrollbarMode);                            
            try {
                ((ImageZoomable)wrapper).GetBarMode( out hbar,  out vbar);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hbar,  out vbar);
        }
    }
    private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);


     public delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_set");
     private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetBarMode( hbar,  vbar);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hbar,  vbar);
        }
    }
    private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;


     private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double width,   out double height);


     public delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,   out double width,   out double height);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_size_get");
     private static void bar_size_get(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    width = default(double);        height = default(double);                            
            try {
                ((ImageZoomable)wrapper).GetBarSize( out width,  out height);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out width,  out height);
        }
    }
    private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double posx,   out double posy);


     public delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,   out double posx,   out double posy);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_get");
     private static void bar_position_get(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    posx = default(double);        posy = default(double);                            
            try {
                ((ImageZoomable)wrapper).GetBarPosition( out posx,  out posy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out posx,  out posy);
        }
    }
    private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   double posx,   double posy);


     public delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,   double posx,   double posy);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_set");
     private static void bar_position_set(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageZoomable)wrapper).SetBarPosition( posx,  posy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  posx,  posy);
        }
    }
    private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;


     private delegate void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_scrollbar_bar_visibility_update_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate> efl_ui_scrollbar_bar_visibility_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate>(_Module, "efl_ui_scrollbar_bar_visibility_update");
     private static void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((ImageZoomable)wrapper).UpdateBarVisibility();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_zoom_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_zoom_animation_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate> efl_ui_zoom_animation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_get_api_delegate>(_Module, "efl_ui_zoom_animation_get");
     private static bool zoom_animation_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_animation_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetZoomAnimation();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_animation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_animation_get_delegate efl_ui_zoom_animation_get_static_delegate;


     private delegate void efl_ui_zoom_animation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool paused);


     public delegate void efl_ui_zoom_animation_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool paused);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate> efl_ui_zoom_animation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_animation_set_api_delegate>(_Module, "efl_ui_zoom_animation_set");
     private static void zoom_animation_set(System.IntPtr obj, System.IntPtr pd,  bool paused)
    {
        Eina.Log.Debug("function efl_ui_zoom_animation_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetZoomAnimation( paused);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_animation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  paused);
        }
    }
    private static efl_ui_zoom_animation_set_delegate efl_ui_zoom_animation_set_static_delegate;


     private delegate double efl_ui_zoom_level_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_ui_zoom_level_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate> efl_ui_zoom_level_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_get_api_delegate>(_Module, "efl_ui_zoom_level_get");
     private static double zoom_level_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_level_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetZoomLevel();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_level_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_level_get_delegate efl_ui_zoom_level_get_static_delegate;


     private delegate void efl_ui_zoom_level_set_delegate(System.IntPtr obj, System.IntPtr pd,   double zoom);


     public delegate void efl_ui_zoom_level_set_api_delegate(System.IntPtr obj,   double zoom);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate> efl_ui_zoom_level_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_level_set_api_delegate>(_Module, "efl_ui_zoom_level_set");
     private static void zoom_level_set(System.IntPtr obj, System.IntPtr pd,  double zoom)
    {
        Eina.Log.Debug("function efl_ui_zoom_level_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetZoomLevel( zoom);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_level_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoom);
        }
    }
    private static efl_ui_zoom_level_set_delegate efl_ui_zoom_level_set_static_delegate;


     private delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.ZoomMode efl_ui_zoom_mode_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate> efl_ui_zoom_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_get_api_delegate>(_Module, "efl_ui_zoom_mode_get");
     private static Efl.Ui.ZoomMode zoom_mode_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_zoom_mode_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.ZoomMode _ret_var = default(Efl.Ui.ZoomMode);
            try {
                _ret_var = ((ImageZoomable)wrapper).GetZoomMode();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_zoom_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_zoom_mode_get_delegate efl_ui_zoom_mode_get_static_delegate;


     private delegate void efl_ui_zoom_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ZoomMode mode);


     public delegate void efl_ui_zoom_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.ZoomMode mode);
     public static Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate> efl_ui_zoom_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_zoom_mode_set_api_delegate>(_Module, "efl_ui_zoom_mode_set");
     private static void zoom_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ZoomMode mode)
    {
        Eina.Log.Debug("function efl_ui_zoom_mode_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageZoomable)wrapper).SetZoomMode( mode);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_zoom_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
        }
    }
    private static efl_ui_zoom_mode_set_delegate efl_ui_zoom_mode_set_static_delegate;
}
} } 
namespace Elm { namespace Photocam { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct Error
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator Error(IntPtr ptr)
    {
        var tmp = (Error.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Error.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct Error.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Error.NativeStruct(Error _external_struct)
        {
            var _internal_struct = new Error.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Error(Error.NativeStruct _internal_struct)
        {
            var _external_struct = new Error();
            return _external_struct;
        }

    }

}

} } 
namespace Elm { namespace Photocam { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct Progress
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator Progress(IntPtr ptr)
    {
        var tmp = (Progress.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Progress.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct Progress.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Progress.NativeStruct(Progress _external_struct)
        {
            var _internal_struct = new Progress.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Progress(Progress.NativeStruct _internal_struct)
        {
            var _external_struct = new Progress();
            return _external_struct;
        }

    }

}

} } 
