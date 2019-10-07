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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ImageZoomable.DownloadProgressEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ImageZoomableDownloadProgressEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when photocam download progress updated</value>
    public Elm.Photocam.Progress arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ImageZoomable.DownloadErrorEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ImageZoomableDownloadErrorEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when photocam download failed</value>
    public Elm.Photocam.Error arg { get; set; }
}

/// <summary>Elementary Image Zoomable class</summary>
[Efl.Ui.ImageZoomable.NativeMethods]
[Efl.Eo.BindingEntity]
public class ImageZoomable : Efl.Ui.Image, Efl.Ui.IScrollable, Efl.Ui.IScrollbar, Efl.Ui.IZoom
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ImageZoomable))
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
        efl_ui_image_zoomable_class_get();

    /// <summary>Initializes a new instance of the <see cref="ImageZoomable"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public ImageZoomable(Efl.Object parent
            , System.String style = null) : base(efl_ui_image_zoomable_class_get(), parent)
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
    protected ImageZoomable(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ImageZoomable"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ImageZoomable(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ImageZoomable"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ImageZoomable(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when photocam got pressed</summary>
    public event EventHandler PressEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event PressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam loading started</summary>
    public event EventHandler LoadEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event LoadEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam loading finished</summary>
    public event EventHandler LoadedEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event LoadedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadedEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocal detail loading started</summary>
    public event EventHandler LoadDetailEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD_DETAIL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD_DETAIL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event LoadDetailEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadDetailEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOAD_DETAIL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam detail loading finished</summary>
    public event EventHandler LoadedDetailEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED_DETAIL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED_DETAIL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event LoadedDetailEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadedDetailEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_LOADED_DETAIL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam download started</summary>
    public event EventHandler DownloadStartEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event DownloadStartEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDownloadStartEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam download progress updated</summary>
    /// <value><see cref="Efl.Ui.ImageZoomableDownloadProgressEventArgs"/></value>
    public event EventHandler<Efl.Ui.ImageZoomableDownloadProgressEventArgs> DownloadProgressEvent
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
                        Efl.Ui.ImageZoomableDownloadProgressEventArgs args = new Efl.Ui.ImageZoomableDownloadProgressEventArgs();
                        args.arg =  (Elm.Photocam.Progress)evt.Info;
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_PROGRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_PROGRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event DownloadProgressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDownloadProgressEvent(Efl.Ui.ImageZoomableDownloadProgressEventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_PROGRESS";
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

    /// <summary>Called when photocam download finished</summary>
    public event EventHandler DownloadDoneEvent
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event DownloadDoneEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDownloadDoneEvent(EventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when photocam download failed</summary>
    /// <value><see cref="Efl.Ui.ImageZoomableDownloadErrorEventArgs"/></value>
    public event EventHandler<Efl.Ui.ImageZoomableDownloadErrorEventArgs> DownloadErrorEvent
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
                        Efl.Ui.ImageZoomableDownloadErrorEventArgs args = new Efl.Ui.ImageZoomableDownloadErrorEventArgs();
                        args.arg =  (Elm.Photocam.Error)evt.Info;
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

                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_ERROR";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_ERROR";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event DownloadErrorEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDownloadErrorEvent(Efl.Ui.ImageZoomableDownloadErrorEventArgs e)
    {
        var key = "_EFL_UI_IMAGE_ZOOMABLE_EVENT_DOWNLOAD_ERROR";
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

    /// <summary>Emitted when thumb is pressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarPressedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarPressedEventArgs> BarPressedEvent
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
                        Efl.Ui.ScrollbarBarPressedEventArgs args = new Efl.Ui.ScrollbarBarPressedEventArgs();
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarPressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPressedEvent(Efl.Ui.ScrollbarBarPressedEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
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

    /// <summary>Emitted when thumb is unpressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarUnpressedEventArgs> BarUnpressedEvent
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
                        Efl.Ui.ScrollbarBarUnpressedEventArgs args = new Efl.Ui.ScrollbarBarUnpressedEventArgs();
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarUnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarUnpressedEvent(Efl.Ui.ScrollbarBarUnpressedEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
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

    /// <summary>Emitted when thumb is dragged.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarDraggedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarDraggedEventArgs> BarDraggedEvent
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
                        Efl.Ui.ScrollbarBarDraggedEventArgs args = new Efl.Ui.ScrollbarBarDraggedEventArgs();
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarDraggedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarDraggedEvent(Efl.Ui.ScrollbarBarDraggedEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
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

    /// <summary>Emitted when thumb size has changed.</summary>
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarSizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarSizeChangedEvent(EventArgs e)
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

    /// <summary>Emitted when thumb position has changed.</summary>
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarPosChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPosChangedEvent(EventArgs e)
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

    /// <summary>Emitted when scrollbar is shown.</summary>
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarShowEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarShowEvent(Efl.Ui.ScrollbarBarShowEventArgs e)
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

    /// <summary>Emitted when scrollbar is hidden.</summary>
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
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event BarHideEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarHideEvent(Efl.Ui.ScrollbarBarHideEventArgs e)
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

    /// <summary>Called when zooming started</summary>
    public event EventHandler ZoomStartEvent
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

                string key = "_EFL_UI_EVENT_ZOOM_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ZoomStartEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnZoomStartEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when zooming stopped</summary>
    public event EventHandler ZoomStopEvent
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

                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ZoomStopEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnZoomStopEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Called when zooming changed</summary>
    public event EventHandler ZoomChangeEvent
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

                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ZOOM_CHANGE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ZoomChangeEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnZoomChangeEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_ZOOM_CHANGE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>The gesture state for photocam.
    /// This sets the gesture state to on or off for photocam. The default is off. This will start multi touch zooming.</summary>
    /// <returns>The gesture state.</returns>
    public virtual bool GetGestureEnabled() {
        var _ret_var = Efl.Ui.ImageZoomable.NativeMethods.efl_ui_image_zoomable_gesture_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The gesture state for photocam.
    /// This sets the gesture state to on or off for photocam. The default is off. This will start multi touch zooming.</summary>
    /// <param name="gesture">The gesture state.</param>
    public virtual void SetGestureEnabled(bool gesture) {
        Efl.Ui.ImageZoomable.NativeMethods.efl_ui_image_zoomable_gesture_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gesture);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The region of the image that is currently shown
    /// Setting it shows the region of the image without using animation.</summary>
    /// <returns>The region in the original image pixels.</returns>
    public virtual Eina.Rect GetImageRegion() {
        var _ret_var = Efl.Ui.ImageZoomable.NativeMethods.efl_ui_image_zoomable_image_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The region of the image that is currently shown
    /// Setting it shows the region of the image without using animation.</summary>
    /// <param name="region">The region in the original image pixels.</param>
    public virtual void SetImageRegion(Eina.Rect region) {
        Eina.Rect.NativeStruct _in_region = region;
Efl.Ui.ImageZoomable.NativeMethods.efl_ui_image_zoomable_image_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_region);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    public virtual Eina.Position2D GetContentPos() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    public virtual void SetContentPos(Eina.Position2D pos) {
        Eina.Position2D.NativeStruct _in_pos = pos;
Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    public virtual Eina.Size2D GetContentSize() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    public virtual Eina.Rect GetViewportGeometry() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void GetBounceEnabled(out bool horiz, out bool vert) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out horiz, out vert);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void SetBounceEnabled(bool horiz, bool vert) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),horiz, vert);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollable.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollable.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    public virtual bool GetScrollFreeze() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollable.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollable.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    public virtual void SetScrollFreeze(bool freeze) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),freeze);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    public virtual bool GetScrollHold() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    public virtual void SetScrollHold(bool hold) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hold);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void GetLooping(out bool loop_h, out bool loop_v) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out loop_h, out loop_v);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void SetLooping(bool loop_h, bool loop_v) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),loop_h, loop_v);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Blocking of scrolling (per axis).
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="Efl.Ui.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    public virtual Efl.Ui.LayoutOrientation GetMovementBlock() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Blocking of scrolling (per axis).
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="Efl.Ui.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block<br/>The default value is <see cref="Efl.Ui.LayoutOrientation.Default"/>.</param>
    public virtual void SetMovementBlock(Efl.Ui.LayoutOrientation block) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),block);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    public virtual void GetGravity(out double x, out double y) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
    public virtual void SetGravity(double x, double y) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    public virtual void SetMatchContent(bool w, bool h) {
        Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),w, h);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    public virtual Eina.Position2D GetStepSize() {
        var _ret_var = Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    public virtual void SetStepSize(Eina.Position2D step) {
        Eina.Position2D.NativeStruct _in_step = step;
Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_step);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    public virtual void Scroll(Eina.Rect rect, bool animation) {
        Eina.Rect.NativeStruct _in_rect = rect;
Efl.Ui.ScrollableConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, animation);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Scrollbar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="Efl.Ui.ScrollbarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="Efl.Ui.ScrollbarMode.Auto"/>.</param>
    public virtual void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Scrollbar visibility mode, for each of the scrollbars.</summary>
    /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="Efl.Ui.ScrollbarMode.Auto"/>.</param>
    /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="Efl.Ui.ScrollbarMode.Auto"/>.</param>
    public virtual void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    /// <param name="width">Value between <c>0.0</c> and <c>1.0</c>.</param>
    /// <param name="height">Value between <c>0.0</c> and <c>1.0</c>.</param>
    public virtual void GetBarSize(out double width, out double height) {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out width, out height);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    public virtual void GetBarPosition(out double posx, out double posy) {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
    /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
    public virtual void SetBarPosition(double posx, double posy) {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),posx, posy);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar needs to be shown or hidden.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    protected virtual void UpdateBarVisibility() {
        Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <returns>The paused state.</returns>
    public virtual bool GetZoomAnimation() {
        var _ret_var = Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_animation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <param name="paused">The paused state.</param>
    public virtual void SetZoomAnimation(bool paused) {
        Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_animation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),paused);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Zoom level of the image.
    /// This selects the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).
    /// 
    /// Note that if you set <see cref="Efl.Ui.IZoom.ZoomMode"/> to anything other than <see cref="Efl.Ui.ZoomMode.Manual"/> (which is the default value) the <see cref="Efl.Ui.IZoom.ZoomLevel"/> might be changed at any time by the zoomable object itself to account for image and viewport size changes.</summary>
    /// <returns>The image&apos;s current zoom level.</returns>
    public virtual double GetZoomLevel() {
        var _ret_var = Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_level_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Zoom level of the image.
    /// This selects the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).
    /// 
    /// Note that if you set <see cref="Efl.Ui.IZoom.ZoomMode"/> to anything other than <see cref="Efl.Ui.ZoomMode.Manual"/> (which is the default value) the <see cref="Efl.Ui.IZoom.ZoomLevel"/> might be changed at any time by the zoomable object itself to account for image and viewport size changes.</summary>
    /// <param name="zoom">The image&apos;s current zoom level.</param>
    public virtual void SetZoomLevel(double zoom) {
        Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_level_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),zoom);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Zoom mode.
    /// This sets the zoom mode to manual or one of several automatic levels. <see cref="Efl.Ui.ZoomMode.Manual"/> means that zoom is controlled manually by <see cref="Efl.Ui.IZoom.ZoomLevel"/> and will stay at that level until changed by code or until <see cref="Efl.Ui.IZoom.ZoomMode"/> is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on image and viewport size changes.</summary>
    /// <returns>The zoom mode.</returns>
    public virtual Efl.Ui.ZoomMode GetZoomMode() {
        var _ret_var = Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Zoom mode.
    /// This sets the zoom mode to manual or one of several automatic levels. <see cref="Efl.Ui.ZoomMode.Manual"/> means that zoom is controlled manually by <see cref="Efl.Ui.IZoom.ZoomLevel"/> and will stay at that level until changed by code or until <see cref="Efl.Ui.IZoom.ZoomMode"/> is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on image and viewport size changes.</summary>
    /// <param name="mode">The zoom mode.<br/>The default value is <see cref="Efl.Ui.ZoomMode.Manual"/>.</param>
    public virtual void SetZoomMode(Efl.Ui.ZoomMode mode) {
        Efl.Ui.ZoomConcrete.NativeMethods.efl_ui_zoom_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The gesture state for photocam.
    /// This sets the gesture state to on or off for photocam. The default is off. This will start multi touch zooming.</summary>
    /// <value>The gesture state.</value>
    public bool GestureEnabled {
        get { return GetGestureEnabled(); }
        set { SetGestureEnabled(value); }
    }

    /// <summary>The region of the image that is currently shown
    /// Setting it shows the region of the image without using animation.</summary>
    /// <value>The region in the original image pixels.</value>
    public Eina.Rect ImageRegion {
        get { return GetImageRegion(); }
        set { SetImageRegion(value); }
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

    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollable.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollable.SetMovementBlock"/>.</summary>
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

    /// <summary>Blocking of scrolling (per axis).
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="Efl.Ui.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block</value>
    public Efl.Ui.LayoutOrientation MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock(value); }
    }

    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
    /// <value>Horizontal scrolling gravity.</value>
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

    /// <summary>Scrollbar visibility mode, for each of the scrollbars.</summary>
    /// <value>Horizontal scrollbar mode.</value>
    public (Efl.Ui.ScrollbarMode, Efl.Ui.ScrollbarMode) BarMode {
        get {
            Efl.Ui.ScrollbarMode _out_hbar = default(Efl.Ui.ScrollbarMode);
            Efl.Ui.ScrollbarMode _out_vbar = default(Efl.Ui.ScrollbarMode);
            GetBarMode(out _out_hbar,out _out_vbar);
            return (_out_hbar,_out_vbar);
        }
        set { SetBarMode( value.Item1,  value.Item2); }
    }

    /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
    public (double, double) BarSize {
        get {
            double _out_width = default(double);
            double _out_height = default(double);
            GetBarSize(out _out_width,out _out_height);
            return (_out_width,_out_height);
        }
    }

    /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
    /// <value>Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</value>
    public (double, double) BarPosition {
        get {
            double _out_posx = default(double);
            double _out_posy = default(double);
            GetBarPosition(out _out_posx,out _out_posy);
            return (_out_posx,_out_posy);
        }
        set { SetBarPosition( value.Item1,  value.Item2); }
    }

    /// <summary>This sets the zoom animation state to on or off for zoomable. The default is off. When <c>paused</c> is <c>true</c>, it will stop zooming using animation on zoom level changes and change instantly, stopping any existing animations that are running.</summary>
    /// <value>The paused state.</value>
    public bool ZoomAnimation {
        get { return GetZoomAnimation(); }
        set { SetZoomAnimation(value); }
    }

    /// <summary>Zoom level of the image.
    /// This selects the zoom level. If <c>zoom</c> is 1, it means no zoom. If it&apos;s smaller than 1, it means zoom in. If it&apos;s bigger than 1, it means zoom out. For  example, <c>zoom</c> 1 will be 1:1 pixel for pixel. <c>zoom</c> 2 will be 2:1 (that is 2x2 photo pixels will display as 1 on-screen pixel) which is a zoom out. 4:1 will be 4x4 photo pixels as 1 screen pixel, and so on. The <c>zoom</c> parameter must be greater than 0. It is suggested to stick to powers of 2. (1, 2, 4, 8, 16, 32, etc.).
    /// 
    /// Note that if you set <see cref="Efl.Ui.IZoom.ZoomMode"/> to anything other than <see cref="Efl.Ui.ZoomMode.Manual"/> (which is the default value) the <see cref="Efl.Ui.IZoom.ZoomLevel"/> might be changed at any time by the zoomable object itself to account for image and viewport size changes.</summary>
    /// <value>The image&apos;s current zoom level.</value>
    public double ZoomLevel {
        get { return GetZoomLevel(); }
        set { SetZoomLevel(value); }
    }

    /// <summary>Zoom mode.
    /// This sets the zoom mode to manual or one of several automatic levels. <see cref="Efl.Ui.ZoomMode.Manual"/> means that zoom is controlled manually by <see cref="Efl.Ui.IZoom.ZoomLevel"/> and will stay at that level until changed by code or until <see cref="Efl.Ui.IZoom.ZoomMode"/> is changed. This is the default mode. The Automatic modes will allow the zoomable object to automatically adjust zoom mode based on image and viewport size changes.</summary>
    /// <value>The zoom mode.</value>
    public Efl.Ui.ZoomMode ZoomMode {
        get { return GetZoomMode(); }
        set { SetZoomMode(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ImageZoomable.efl_ui_image_zoomable_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Image.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_image_zoomable_gesture_enabled_get_static_delegate == null)
            {
                efl_ui_image_zoomable_gesture_enabled_get_static_delegate = new efl_ui_image_zoomable_gesture_enabled_get_delegate(gesture_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGestureEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_zoomable_gesture_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_gesture_enabled_get_static_delegate) });
            }

            if (efl_ui_image_zoomable_gesture_enabled_set_static_delegate == null)
            {
                efl_ui_image_zoomable_gesture_enabled_set_static_delegate = new efl_ui_image_zoomable_gesture_enabled_set_delegate(gesture_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGestureEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_zoomable_gesture_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_gesture_enabled_set_static_delegate) });
            }

            if (efl_ui_image_zoomable_image_region_get_static_delegate == null)
            {
                efl_ui_image_zoomable_image_region_get_static_delegate = new efl_ui_image_zoomable_image_region_get_delegate(image_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_zoomable_image_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_image_region_get_static_delegate) });
            }

            if (efl_ui_image_zoomable_image_region_set_static_delegate == null)
            {
                efl_ui_image_zoomable_image_region_set_static_delegate = new efl_ui_image_zoomable_image_region_set_delegate(image_region_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetImageRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_zoomable_image_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_zoomable_image_region_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            {
                efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate) });
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
            return Efl.Ui.ImageZoomable.efl_ui_image_zoomable_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_image_zoomable_gesture_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_image_zoomable_gesture_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_get_api_delegate> efl_ui_image_zoomable_gesture_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_get_api_delegate>(Module, "efl_ui_image_zoomable_gesture_enabled_get");

        private static bool gesture_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_image_zoomable_gesture_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageZoomable)ws.Target).GetGestureEnabled();
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
                return efl_ui_image_zoomable_gesture_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_image_zoomable_gesture_enabled_get_delegate efl_ui_image_zoomable_gesture_enabled_get_static_delegate;

        
        private delegate void efl_ui_image_zoomable_gesture_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool gesture);

        
        public delegate void efl_ui_image_zoomable_gesture_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool gesture);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_set_api_delegate> efl_ui_image_zoomable_gesture_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_gesture_enabled_set_api_delegate>(Module, "efl_ui_image_zoomable_gesture_enabled_set");

        private static void gesture_enabled_set(System.IntPtr obj, System.IntPtr pd, bool gesture)
        {
            Eina.Log.Debug("function efl_ui_image_zoomable_gesture_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((ImageZoomable)ws.Target).SetGestureEnabled(gesture);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_image_zoomable_gesture_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture);
            }
        }

        private static efl_ui_image_zoomable_gesture_enabled_set_delegate efl_ui_image_zoomable_gesture_enabled_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_image_zoomable_image_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_image_zoomable_image_region_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_get_api_delegate> efl_ui_image_zoomable_image_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_get_api_delegate>(Module, "efl_ui_image_zoomable_image_region_get");

        private static Eina.Rect.NativeStruct image_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_image_zoomable_image_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((ImageZoomable)ws.Target).GetImageRegion();
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
                return efl_ui_image_zoomable_image_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_image_zoomable_image_region_get_delegate efl_ui_image_zoomable_image_region_get_static_delegate;

        
        private delegate void efl_ui_image_zoomable_image_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct region);

        
        public delegate void efl_ui_image_zoomable_image_region_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct region);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_set_api_delegate> efl_ui_image_zoomable_image_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_zoomable_image_region_set_api_delegate>(Module, "efl_ui_image_zoomable_image_region_set");

        private static void image_region_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct region)
        {
            Eina.Log.Debug("function efl_ui_image_zoomable_image_region_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_region = region;

                try
                {
                    ((ImageZoomable)ws.Target).SetImageRegion(_in_region);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_image_zoomable_image_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), region);
            }
        }

        private static efl_ui_image_zoomable_image_region_set_delegate efl_ui_image_zoomable_image_region_set_static_delegate;

        
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
                    ((ImageZoomable)ws.Target).UpdateBarVisibility();
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

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiImageZoomable_ExtensionMethods {
    public static Efl.BindableProperty<bool> GestureEnabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<bool>("gesture_enabled", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> ImageRegion<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<Eina.Rect>("image_region", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> ContentPos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<Eina.Position2D>("content_pos", fac);
    }

    public static Efl.BindableProperty<bool> ScrollFreeze<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<bool>("scroll_freeze", fac);
    }

    public static Efl.BindableProperty<bool> ScrollHold<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<bool>("scroll_hold", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> MovementBlock<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("movement_block", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> StepSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<Eina.Position2D>("step_size", fac);
    }

    public static Efl.BindableProperty<bool> ZoomAnimation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<bool>("zoom_animation", fac);
    }

    public static Efl.BindableProperty<double> ZoomLevel<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<double>("zoom_level", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.ZoomMode> ZoomMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ImageZoomable, T>magic = null) where T : Efl.Ui.ImageZoomable {
        return new Efl.BindableProperty<Efl.Ui.ZoomMode>("zoom_mode", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Elm {

namespace Photocam {

/// <summary>Photocam error information.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Error
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Error(IntPtr ptr)
    {
        var tmp = (Error.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Error.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Error.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Error.NativeStruct(Error _external_struct)
        {
            var _internal_struct = new Error.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Error(Error.NativeStruct _internal_struct)
        {
            var _external_struct = new Error();
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

namespace Elm {

namespace Photocam {

/// <summary>Photocam progress information.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Progress
{
    /// <summary>Placeholder field</summary>
    public IntPtr field;
    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Progress(IntPtr ptr)
    {
        var tmp = (Progress.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Progress.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct Progress.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Progress.NativeStruct(Progress _external_struct)
        {
            var _internal_struct = new Progress.NativeStruct();
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Progress(Progress.NativeStruct _internal_struct)
        {
            var _external_struct = new Progress();
            return _external_struct;
        }
    }
    #pragma warning restore CS1591
}

}
}

