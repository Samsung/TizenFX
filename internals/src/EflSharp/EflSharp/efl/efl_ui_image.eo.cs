#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Image.DropEvt"/>.</summary>
public class ImageDropEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
/// <summary>Efl UI image class
/// When loading images from a file, the <see cref="Efl.IFile.Key"/> property can be used to access different streams. For example, when accessing Evas image caches.</summary>
[ImageNativeInherit]
public class Image : Efl.Ui.Widget, Efl.Eo.IWrapper,Efl.IFile,Efl.IOrientation,Efl.IPlayer,Efl.Gfx.IImage,Efl.Gfx.IImageLoadController,Efl.Gfx.IView,Efl.Layout.ICalc,Efl.Layout.IGroup,Efl.Layout.ISignal,Efl.Ui.IClickable,Efl.Ui.IDraggable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Image))
                return Efl.Ui.ImageNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_image_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Image(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_image_class_get(), typeof(Image), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Image(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Image(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object DropEvtKey = new object();
    /// <summary>Called when drop from drag and drop happened</summary>
    public event EventHandler<Efl.Ui.ImageDropEvt_Args> DropEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_EVENT_DROP";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_DropEvt_delegate)) {
                    eventHandlers.AddHandler(DropEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_IMAGE_EVENT_DROP";
                if (RemoveNativeEventHandler(key, this.evt_DropEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DropEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DropEvt.</summary>
    public void On_DropEvt(Efl.Ui.ImageDropEvt_Args e)
    {
        EventHandler<Efl.Ui.ImageDropEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ImageDropEvt_Args>)eventHandlers[DropEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DropEvt_delegate;
    private void on_DropEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ImageDropEvt_Args args = new Efl.Ui.ImageDropEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
        try {
            On_DropEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ImagePreloadEvtKey = new object();
    /// <summary>Image data has been preloaded.</summary>
    public event EventHandler ImagePreloadEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ImagePreloadEvt_delegate)) {
                    eventHandlers.AddHandler(ImagePreloadEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                if (RemoveNativeEventHandler(key, this.evt_ImagePreloadEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ImagePreloadEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ImagePreloadEvt.</summary>
    public void On_ImagePreloadEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ImagePreloadEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ImagePreloadEvt_delegate;
    private void on_ImagePreloadEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ImagePreloadEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ImageResizeEvtKey = new object();
    /// <summary>Image was resized (its pixel data).</summary>
    public event EventHandler ImageResizeEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ImageResizeEvt_delegate)) {
                    eventHandlers.AddHandler(ImageResizeEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
                if (RemoveNativeEventHandler(key, this.evt_ImageResizeEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ImageResizeEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ImageResizeEvt.</summary>
    public void On_ImageResizeEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ImageResizeEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ImageResizeEvt_delegate;
    private void on_ImageResizeEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ImageResizeEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ImageUnloadEvtKey = new object();
    /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
    public event EventHandler ImageUnloadEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ImageUnloadEvt_delegate)) {
                    eventHandlers.AddHandler(ImageUnloadEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                if (RemoveNativeEventHandler(key, this.evt_ImageUnloadEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ImageUnloadEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ImageUnloadEvt.</summary>
    public void On_ImageUnloadEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ImageUnloadEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ImageUnloadEvt_delegate;
    private void on_ImageUnloadEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ImageUnloadEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadDoneEvtKey = new object();
    /// <summary>Called when he image was loaded</summary>
    public event EventHandler LoadDoneEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_LoadDoneEvt_delegate)) {
                    eventHandlers.AddHandler(LoadDoneEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                if (RemoveNativeEventHandler(key, this.evt_LoadDoneEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadDoneEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadDoneEvt.</summary>
    public void On_LoadDoneEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[LoadDoneEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadDoneEvt_delegate;
    private void on_LoadDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_LoadDoneEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LoadErrorEvtKey = new object();
    /// <summary>Called when an error happened during image loading</summary>
    public event EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_LoadErrorEvt_delegate)) {
                    eventHandlers.AddHandler(LoadErrorEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                if (RemoveNativeEventHandler(key, this.evt_LoadErrorEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LoadErrorEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LoadErrorEvt.</summary>
    public void On_LoadErrorEvt(Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args e)
    {
        EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args>)eventHandlers[LoadErrorEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LoadErrorEvt_delegate;
    private void on_LoadErrorEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args args = new Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args();
      args.arg = (Eina.Error)Marshal.PtrToStructure(evt.Info, typeof(Eina.Error));
        try {
            On_LoadErrorEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object RecalcEvtKey = new object();
    /// <summary>The layout was recalculated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler RecalcEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                if (AddNativeEventHandler(efl.Libs.Edje, key, this.evt_RecalcEvt_delegate)) {
                    eventHandlers.AddHandler(RecalcEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                if (RemoveNativeEventHandler(key, this.evt_RecalcEvt_delegate)) { 
                    eventHandlers.RemoveHandler(RecalcEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event RecalcEvt.</summary>
    public void On_RecalcEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[RecalcEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_RecalcEvt_delegate;
    private void on_RecalcEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_RecalcEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object CircularDependencyEvtKey = new object();
    /// <summary>A circular dependency between parts of the object was found.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args> CircularDependencyEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                if (AddNativeEventHandler(efl.Libs.Edje, key, this.evt_CircularDependencyEvt_delegate)) {
                    eventHandlers.AddHandler(CircularDependencyEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                if (RemoveNativeEventHandler(key, this.evt_CircularDependencyEvt_delegate)) { 
                    eventHandlers.RemoveHandler(CircularDependencyEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event CircularDependencyEvt.</summary>
    public void On_CircularDependencyEvt(Efl.Layout.ICalcCircularDependencyEvt_Args e)
    {
        EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args>)eventHandlers[CircularDependencyEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_CircularDependencyEvt_delegate;
    private void on_CircularDependencyEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Layout.ICalcCircularDependencyEvt_Args args = new Efl.Layout.ICalcCircularDependencyEvt_Args();
      args.arg = new Eina.Array<System.String>(evt.Info, false, false);
        try {
            On_CircularDependencyEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedEvtKey = new object();
    /// <summary>Called when object is clicked</summary>
    public event EventHandler ClickedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED";
                if (RemoveNativeEventHandler(key, this.evt_ClickedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void On_ClickedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedEvt_delegate;
    private void on_ClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedDoubleEvtKey = new object();
    /// <summary>Called when object receives a double click</summary>
    public event EventHandler ClickedDoubleEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedDoubleEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedDoubleEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                if (RemoveNativeEventHandler(key, this.evt_ClickedDoubleEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedDoubleEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedDoubleEvt.</summary>
    public void On_ClickedDoubleEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedDoubleEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedDoubleEvt_delegate;
    private void on_ClickedDoubleEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedDoubleEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedTripleEvtKey = new object();
    /// <summary>Called when object receives a triple click</summary>
    public event EventHandler ClickedTripleEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedTripleEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedTripleEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                if (RemoveNativeEventHandler(key, this.evt_ClickedTripleEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedTripleEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedTripleEvt.</summary>
    public void On_ClickedTripleEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedTripleEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedTripleEvt_delegate;
    private void on_ClickedTripleEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedTripleEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedRightEvtKey = new object();
    /// <summary>Called when object receives a right click</summary>
    public event EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> ClickedRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedRightEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_ClickedRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedRightEvt.</summary>
    public void On_ClickedRightEvt(Efl.Ui.IClickableClickedRightEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableClickedRightEvt_Args>)eventHandlers[ClickedRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedRightEvt_delegate;
    private void on_ClickedRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableClickedRightEvt_Args args = new Efl.Ui.IClickableClickedRightEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ClickedRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PressedEvtKey = new object();
    /// <summary>Called when the object is pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_PRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PressedEvt_delegate)) {
                    eventHandlers.AddHandler(PressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_PRESSED";
                if (RemoveNativeEventHandler(key, this.evt_PressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void On_PressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickablePressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickablePressedEvt_Args>)eventHandlers[PressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PressedEvt_delegate;
    private void on_PressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_PressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object UnpressedEvtKey = new object();
    /// <summary>Called when the object is no longer pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_UnpressedEvt_delegate)) {
                    eventHandlers.AddHandler(UnpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                if (RemoveNativeEventHandler(key, this.evt_UnpressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(UnpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void On_UnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableUnpressedEvt_Args>)eventHandlers[UnpressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_UnpressedEvt_delegate;
    private void on_UnpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_UnpressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LongpressedEvtKey = new object();
    /// <summary>Called when the object receives a long press</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_LongpressedEvt_delegate)) {
                    eventHandlers.AddHandler(LongpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                if (RemoveNativeEventHandler(key, this.evt_LongpressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LongpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void On_LongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableLongpressedEvt_Args>)eventHandlers[LongpressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LongpressedEvt_delegate;
    private void on_LongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_LongpressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object RepeatedEvtKey = new object();
    /// <summary>Called when the object receives repeated presses/clicks</summary>
    public event EventHandler RepeatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_REPEATED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_RepeatedEvt_delegate)) {
                    eventHandlers.AddHandler(RepeatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_REPEATED";
                if (RemoveNativeEventHandler(key, this.evt_RepeatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(RepeatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event RepeatedEvt.</summary>
    public void On_RepeatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[RepeatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_RepeatedEvt_delegate;
    private void on_RepeatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_RepeatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragEvtKey = new object();
    /// <summary>Called when drag operation starts</summary>
    public event EventHandler<Efl.Ui.IDraggableDragEvt_Args> DragEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragEvt_delegate)) {
                    eventHandlers.AddHandler(DragEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG";
                if (RemoveNativeEventHandler(key, this.evt_DragEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragEvt.</summary>
    public void On_DragEvt(Efl.Ui.IDraggableDragEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragEvt_Args>)eventHandlers[DragEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragEvt_delegate;
    private void on_DragEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragEvt_Args args = new Efl.Ui.IDraggableDragEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStartEvtKey = new object();
    /// <summary>Called when drag started</summary>
    public event EventHandler DragStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStartEvt_delegate)) {
                    eventHandlers.AddHandler(DragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START";
                if (RemoveNativeEventHandler(key, this.evt_DragStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStartEvt.</summary>
    public void On_DragStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[DragStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStartEvt_delegate;
    private void on_DragStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_DragStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStopEvtKey = new object();
    /// <summary>Called when drag stopped</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStopEvt_Args> DragStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStopEvt_delegate)) {
                    eventHandlers.AddHandler(DragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_STOP";
                if (RemoveNativeEventHandler(key, this.evt_DragStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStopEvt.</summary>
    public void On_DragStopEvt(Efl.Ui.IDraggableDragStopEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragStopEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragStopEvt_Args>)eventHandlers[DragStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStopEvt_delegate;
    private void on_DragStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragStopEvt_Args args = new Efl.Ui.IDraggableDragStopEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragEndEvtKey = new object();
    /// <summary>Called when drag operation ends</summary>
    public event EventHandler DragEndEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_END";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragEndEvt_delegate)) {
                    eventHandlers.AddHandler(DragEndEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_END";
                if (RemoveNativeEventHandler(key, this.evt_DragEndEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragEndEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragEndEvt.</summary>
    public void On_DragEndEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[DragEndEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragEndEvt_delegate;
    private void on_DragEndEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_DragEndEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStartUpEvtKey = new object();
    /// <summary>Called when drag starts into up direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args> DragStartUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStartUpEvt_delegate)) {
                    eventHandlers.AddHandler(DragStartUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                if (RemoveNativeEventHandler(key, this.evt_DragStartUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStartUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStartUpEvt.</summary>
    public void On_DragStartUpEvt(Efl.Ui.IDraggableDragStartUpEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args>)eventHandlers[DragStartUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStartUpEvt_delegate;
    private void on_DragStartUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragStartUpEvt_Args args = new Efl.Ui.IDraggableDragStartUpEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragStartUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStartDownEvtKey = new object();
    /// <summary>Called when drag starts into down direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args> DragStartDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStartDownEvt_delegate)) {
                    eventHandlers.AddHandler(DragStartDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_DragStartDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStartDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStartDownEvt.</summary>
    public void On_DragStartDownEvt(Efl.Ui.IDraggableDragStartDownEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args>)eventHandlers[DragStartDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStartDownEvt_delegate;
    private void on_DragStartDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragStartDownEvt_Args args = new Efl.Ui.IDraggableDragStartDownEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragStartDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStartRightEvtKey = new object();
    /// <summary>Called when drag starts into right direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args> DragStartRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStartRightEvt_delegate)) {
                    eventHandlers.AddHandler(DragStartRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_DragStartRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStartRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStartRightEvt.</summary>
    public void On_DragStartRightEvt(Efl.Ui.IDraggableDragStartRightEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args>)eventHandlers[DragStartRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStartRightEvt_delegate;
    private void on_DragStartRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragStartRightEvt_Args args = new Efl.Ui.IDraggableDragStartRightEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragStartRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object DragStartLeftEvtKey = new object();
    /// <summary>Called when drag starts into left direction</summary>
    public event EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args> DragStartLeftEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_DragStartLeftEvt_delegate)) {
                    eventHandlers.AddHandler(DragStartLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                if (RemoveNativeEventHandler(key, this.evt_DragStartLeftEvt_delegate)) { 
                    eventHandlers.RemoveHandler(DragStartLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event DragStartLeftEvt.</summary>
    public void On_DragStartLeftEvt(Efl.Ui.IDraggableDragStartLeftEvt_Args e)
    {
        EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args>)eventHandlers[DragStartLeftEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_DragStartLeftEvt_delegate;
    private void on_DragStartLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IDraggableDragStartLeftEvt_Args args = new Efl.Ui.IDraggableDragStartLeftEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_DragStartLeftEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_DropEvt_delegate = new Efl.EventCb(on_DropEvt_NativeCallback);
        evt_ImagePreloadEvt_delegate = new Efl.EventCb(on_ImagePreloadEvt_NativeCallback);
        evt_ImageResizeEvt_delegate = new Efl.EventCb(on_ImageResizeEvt_NativeCallback);
        evt_ImageUnloadEvt_delegate = new Efl.EventCb(on_ImageUnloadEvt_NativeCallback);
        evt_LoadDoneEvt_delegate = new Efl.EventCb(on_LoadDoneEvt_NativeCallback);
        evt_LoadErrorEvt_delegate = new Efl.EventCb(on_LoadErrorEvt_NativeCallback);
        evt_RecalcEvt_delegate = new Efl.EventCb(on_RecalcEvt_NativeCallback);
        evt_CircularDependencyEvt_delegate = new Efl.EventCb(on_CircularDependencyEvt_NativeCallback);
        evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
        evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
        evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
        evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
        evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
        evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
        evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
        evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
        evt_DragEvt_delegate = new Efl.EventCb(on_DragEvt_NativeCallback);
        evt_DragStartEvt_delegate = new Efl.EventCb(on_DragStartEvt_NativeCallback);
        evt_DragStopEvt_delegate = new Efl.EventCb(on_DragStopEvt_NativeCallback);
        evt_DragEndEvt_delegate = new Efl.EventCb(on_DragEndEvt_NativeCallback);
        evt_DragStartUpEvt_delegate = new Efl.EventCb(on_DragStartUpEvt_NativeCallback);
        evt_DragStartDownEvt_delegate = new Efl.EventCb(on_DragStartDownEvt_NativeCallback);
        evt_DragStartRightEvt_delegate = new Efl.EventCb(on_DragStartRightEvt_NativeCallback);
        evt_DragStartLeftEvt_delegate = new Efl.EventCb(on_DragStartLeftEvt_NativeCallback);
    }
    /// <summary>Enable or disable scaling up or down the internal image.</summary>
    /// <param name="scale_up">If <c>true</c>, the internal image might be scaled up if necessary according to the scale type. if <c>false</c>, the internal image is not scaled up no matter what the scale type is.</param>
    /// <param name="scale_down">If <c>true</c>, the internal image might be scaled down if necessary according to the scale type. if <c>false</c>, the internal image is not scaled down no matter what the scale type is.</param>
    /// <returns></returns>
    virtual public void GetScalable( out bool scale_up,  out bool scale_down) {
                                                         Efl.Ui.ImageNativeInherit.efl_ui_image_scalable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out scale_up,  out scale_down);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Enable or disable scaling up or down the internal image.</summary>
    /// <param name="scale_up">If <c>true</c>, the internal image might be scaled up if necessary according to the scale type. if <c>false</c>, the internal image is not scaled up no matter what the scale type is.</param>
    /// <param name="scale_down">If <c>true</c>, the internal image might be scaled down if necessary according to the scale type. if <c>false</c>, the internal image is not scaled down no matter what the scale type is.</param>
    /// <returns></returns>
    virtual public void SetScalable( bool scale_up,  bool scale_down) {
                                                         Efl.Ui.ImageNativeInherit.efl_ui_image_scalable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scale_up,  scale_down);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls how the internal image is positioned inside an image object.</summary>
    /// <param name="align_x">Alignment in the horizontal axis (0 &lt;= align_x &lt;= 1).</param>
    /// <param name="align_y">Alignment in the vertical axis (0 &lt;= align_y &lt;= 1).</param>
    /// <returns></returns>
    virtual public void GetAlign( out double align_x,  out double align_y) {
                                                         Efl.Ui.ImageNativeInherit.efl_ui_image_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out align_x,  out align_y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls how the internal image is positioned inside an image object.</summary>
    /// <param name="align_x">Alignment in the horizontal axis (0 &lt;= align_x &lt;= 1).</param>
    /// <param name="align_y">Alignment in the vertical axis (0 &lt;= align_y &lt;= 1).</param>
    /// <returns></returns>
    virtual public void SetAlign( double align_x,  double align_y) {
                                                         Efl.Ui.ImageNativeInherit.efl_ui_image_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), align_x,  align_y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the icon name of image set by icon standard names.
    /// If the image was set using efl_file_set() instead of <see cref="Efl.Ui.Image.SetIcon"/>, then this function will return null.</summary>
    /// <returns>The icon name</returns>
    virtual public System.String GetIcon() {
         var _ret_var = Efl.Ui.ImageNativeInherit.efl_ui_image_icon_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the image by icon standards names.
    /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
    /// 
    /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="Efl.Ui.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
    /// 
    /// Note: The image set by this function is changed when <see cref="Efl.IFile.Load"/> is called.
    /// 
    /// Note: This function does not accept relative icon path.
    /// 
    /// See also <see cref="Efl.Ui.Image.GetIcon"/>.</summary>
    /// <param name="name">The icon name</param>
    /// <returns><c>true</c> on success, <c>false</c> on error</returns>
    virtual public bool SetIcon( System.String name) {
                                 var _ret_var = Efl.Ui.ImageNativeInherit.efl_ui_image_icon_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    virtual public Eina.File GetMmap() {
         var _ret_var = Efl.IFileNativeInherit.efl_file_mmap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetMmap( Eina.File f) {
                                 var _ret_var = Efl.IFileNativeInherit.efl_file_mmap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    virtual public System.String GetFile() {
         var _ret_var = Efl.IFileNativeInherit.efl_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetFile( System.String file) {
                                 var _ret_var = Efl.IFileNativeInherit.efl_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), file);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    virtual public System.String GetKey() {
         var _ret_var = Efl.IFileNativeInherit.efl_file_key_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    /// <returns></returns>
    virtual public void SetKey( System.String key) {
                                 Efl.IFileNativeInherit.efl_file_key_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    virtual public bool GetLoaded() {
         var _ret_var = Efl.IFileNativeInherit.efl_file_loaded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error Load() {
         var _ret_var = Efl.IFileNativeInherit.efl_file_load_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    virtual public void Unload() {
         Efl.IFileNativeInherit.efl_file_unload_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Control the orientation of a given object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <returns>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</returns>
    virtual public Efl.Orient GetOrientation() {
         var _ret_var = Efl.IOrientationNativeInherit.efl_orientation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the orientation of a given object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <param name="dir">The rotation angle (CCW), see <see cref="Efl.Orient"/>.</param>
    /// <returns></returns>
    virtual public void SetOrientation( Efl.Orient dir) {
                                 Efl.IOrientationNativeInherit.efl_orientation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the flip of the given image
    /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
    /// <returns>Flip method</returns>
    virtual public Efl.Flip GetFlip() {
         var _ret_var = Efl.IOrientationNativeInherit.efl_orientation_flip_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the flip of the given image
    /// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
    /// <param name="flip">Flip method</param>
    /// <returns></returns>
    virtual public void SetFlip( Efl.Flip flip) {
                                 Efl.IOrientationNativeInherit.efl_orientation_flip_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), flip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether or not the playable can be played.</summary>
    /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
    virtual public bool GetPlayable() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_playable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get play/pause state of the media file.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    virtual public bool GetPlay() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_play_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set play/pause state of the media file.
    /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns></returns>
    virtual public void SetPlay( bool play) {
                                 Efl.IPlayerNativeInherit.efl_player_play_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the position in the media file.
    /// The position is returned as the number of seconds since the beginning of the media file.</summary>
    /// <returns>The position (in seconds).</returns>
    virtual public double GetPos() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the position in the media file.
    /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    /// <returns></returns>
    virtual public void SetPos( double sec) {
                                 Efl.IPlayerNativeInherit.efl_player_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get how much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    virtual public double GetProgress() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_progress_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    virtual public double GetPlaySpeed() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_play_speed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    /// <returns></returns>
    virtual public void SetPlaySpeed( double speed) {
                                 Efl.IPlayerNativeInherit.efl_player_play_speed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), speed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    virtual public double GetVolume() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_volume_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    /// <returns></returns>
    virtual public void SetVolume( double volume) {
                                 Efl.IPlayerNativeInherit.efl_player_volume_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), volume);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    virtual public bool GetMute() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_mute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    /// <returns></returns>
    virtual public void SetMute( bool mute) {
                                 Efl.IPlayerNativeInherit.efl_player_mute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mute);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    virtual public double GetLength() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_length_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    virtual public bool GetSeekable() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_seekable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a playing playable object.</summary>
    /// <returns></returns>
    virtual public void Start() {
         Efl.IPlayerNativeInherit.efl_player_start_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop playable object.</summary>
    /// <returns></returns>
    virtual public void Stop() {
         Efl.IPlayerNativeInherit.efl_player_stop_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
    /// 
    /// <c>true</c> by default</summary>
    /// <returns>Whether to use smooth scale or not.</returns>
    virtual public bool GetSmoothScale() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
    /// 
    /// <c>true</c> by default</summary>
    /// <param name="smooth_scale">Whether to use smooth scale or not.</param>
    /// <returns></returns>
    virtual public void SetSmoothScale( bool smooth_scale) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), smooth_scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control how the image is scaled.</summary>
    /// <returns>Image scale type</returns>
    virtual public Efl.Gfx.ImageScaleType GetScaleType() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_scale_type_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control how the image is scaled.</summary>
    /// <param name="scale_type">Image scale type</param>
    /// <returns></returns>
    virtual public void SetScaleType( Efl.Gfx.ImageScaleType scale_type) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_scale_type_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scale_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns 1.0 if not applicable (eg. height = 0).</summary>
    /// <returns>The image&apos;s ratio.</returns>
    virtual public double GetRatio() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_ratio_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
    /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
    /// 
    /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
    /// 
    /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.IImage.SetBorderScale"/> function.
    /// 
    /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
    /// 
    /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
    /// <param name="l">The border&apos;s left width.</param>
    /// <param name="r">The border&apos;s right width.</param>
    /// <param name="t">The border&apos;s top height.</param>
    /// <param name="b">The border&apos;s bottom height.</param>
    /// <returns></returns>
    virtual public void GetBorder( out int l,  out int r,  out int t,  out int b) {
                                                                                                         Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out l,  out r,  out t,  out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
    /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
    /// 
    /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
    /// 
    /// Note: The border region itself may be scaled by the <see cref="Efl.Gfx.IImage.SetBorderScale"/> function.
    /// 
    /// Note: By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
    /// 
    /// Note: Similar to the concepts of 9-patch images or cap insets.</summary>
    /// <param name="l">The border&apos;s left width.</param>
    /// <param name="r">The border&apos;s right width.</param>
    /// <param name="t">The border&apos;s top height.</param>
    /// <param name="b">The border&apos;s bottom height.</param>
    /// <returns></returns>
    virtual public void SetBorder( int l,  int r,  int t,  int b) {
                                                                                                         Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), l,  r,  t,  b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
    /// 
    /// Default value is 1.0 (no scaling).</summary>
    /// <returns>The scale factor.</returns>
    virtual public double GetBorderScale() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_scale_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
    /// 
    /// Default value is 1.0 (no scaling).</summary>
    /// <param name="scale">The scale factor.</param>
    /// <returns></returns>
    virtual public void SetBorderScale( double scale) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_scale_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
    /// 
    /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
    /// <returns>Fill mode of the center region.</returns>
    virtual public Efl.Gfx.BorderFillMode GetBorderCenterFill() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_center_fill_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
    /// 
    /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
    /// <param name="fill">Fill mode of the center region.</param>
    /// <returns></returns>
    virtual public void SetBorderCenterFill( Efl.Gfx.BorderFillMode fill) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_border_center_fill_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This represents the size of the original image in pixels.
    /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
    /// 
    /// This is a read-only property, and may return 0x0.</summary>
    /// <returns>The size in pixels.</returns>
    virtual public Eina.Size2D GetImageSize() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the content hint setting of a given image object of the canvas.
    /// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
    /// <returns>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></returns>
    virtual public Efl.Gfx.ImageContentHint GetContentHint() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_content_hint_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the content hint setting of a given image object of the canvas.
    /// This function sets the content hint value of the given image of the canvas. For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to #EVAS_IMAGE_CONTENT_HINT_DYNAMIC will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <param name="hint">Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></param>
    /// <returns></returns>
    virtual public void SetContentHint( Efl.Gfx.ImageContentHint hint) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_content_hint_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the scale hint of a given image of the canvas.
    /// This function returns the scale hint value of the given image object of the canvas.</summary>
    /// <returns>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></returns>
    virtual public Efl.Gfx.ImageScaleHint GetScaleHint() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the scale hint of a given image of the canvas.
    /// This function sets the scale hint value of the given image object in the canvas, which will affect how Evas is to cache scaled versions of its original source image.</summary>
    /// <param name="hint">Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></param>
    /// <returns></returns>
    virtual public void SetScaleHint( Efl.Gfx.ImageScaleHint hint) {
                                 Efl.Gfx.IImageNativeInherit.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the (last) file loading error for a given object.</summary>
    /// <returns>The load error code.</returns>
    virtual public Eina.Error GetImageLoadError() {
         var _ret_var = Efl.Gfx.IImageNativeInherit.efl_gfx_image_load_error_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns the requested load size.</summary>
    /// <returns>The image load size.</returns>
    virtual public Eina.Size2D GetLoadSize() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the canvas to load the image at the given size.
    /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
    /// <param name="size">The image load size.</param>
    /// <returns></returns>
    virtual public void SetLoadSize( Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <returns>The DPI resolution.</returns>
    virtual public double GetLoadDpi() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the DPI resolution of an image object&apos;s source image.
    /// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
    /// <param name="dpi">The DPI resolution.</param>
    /// <returns></returns>
    virtual public void SetLoadDpi( double dpi) {
                                 Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dpi);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
    virtual public bool GetLoadRegionSupport() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
    /// <returns>A region of the image.</returns>
    virtual public Eina.Rect GetLoadRegion() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This function is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
    /// <param name="region">A region of the image.</param>
    /// <returns></returns>
    virtual public void SetLoadRegion( Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_region);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <returns><c>true</c> means that it should honor the orientation information.</returns>
    virtual public bool GetLoadOrientation() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
    /// <returns></returns>
    virtual public void SetLoadOrientation( bool enable) {
                                 Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scale down factor is a divider on the original image size.
    /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
    /// 
    /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
    /// 
    /// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
    /// <returns>The scale down dividing factor.</returns>
    virtual public int GetLoadScaleDown() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
    /// <param name="div">The scale down dividing factor.</param>
    /// <returns></returns>
    virtual public void SetLoadScaleDown( int div) {
                                 Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), div);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <returns>Will be true if header is to be skipped.</returns>
    virtual public bool GetLoadSkipHeader() {
         var _ret_var = Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
    /// <param name="skip">Will be true if header is to be skipped.</param>
    /// <returns></returns>
    virtual public void SetLoadSkipHeader( bool skip) {
                                 Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), skip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Begin preloading an image object&apos;s image data in the background.
    /// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
    /// <returns></returns>
    virtual public void LoadAsyncStart() {
         Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Cancel preloading an image object&apos;s image data in the background.
    /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
    /// <returns></returns>
    virtual public void LoadAsyncCancel() {
         Efl.Gfx.IImageLoadControllerNativeInherit.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The dimensions of this object&apos;s viewport.
    /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
    /// 
    /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
    /// 
    /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
    /// 
    /// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
    /// 
    /// Refer to each implementing class specific documentation for more details.</summary>
    /// <returns>Size of the view.</returns>
    virtual public Eina.Size2D GetViewSize() {
         var _ret_var = Efl.Gfx.IViewNativeInherit.efl_gfx_view_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The dimensions of this object&apos;s viewport.
    /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
    /// 
    /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
    /// 
    /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
    /// 
    /// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
    /// 
    /// Refer to each implementing class specific documentation for more details.</summary>
    /// <param name="size">Size of the view.</param>
    /// <returns></returns>
    virtual public void SetViewSize( Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IViewNativeInherit.efl_gfx_view_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether this object updates its size hints automatically.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether or not update the size hints.</returns>
    virtual public bool GetCalcAutoUpdateHints() {
         var _ret_var = Efl.Layout.ICalcNativeInherit.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable auto-update of size hints.
    /// (Since EFL 1.22)</summary>
    /// <param name="update">Whether or not update the size hints.</param>
    /// <returns></returns>
    virtual public void SetCalcAutoUpdateHints( bool update) {
                                 Efl.Layout.ICalcNativeInherit.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), update);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Calculates the minimum required size for a given layout object.
    /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
    /// 
    /// Note: At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
    /// 
    /// Warning: Be advised that invisible parts in the object will be taken into account in this calculation.
    /// (Since EFL 1.22)</summary>
    /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
    /// <returns>The minimum required size.</returns>
    virtual public Eina.Size2D CalcSizeMin( Eina.Size2D restricted) {
         Eina.Size2D.NativeStruct _in_restricted = restricted;
                        var _ret_var = Efl.Layout.ICalcNativeInherit.efl_layout_calc_size_min_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_restricted);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
    /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
    /// 
    /// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.
    /// (Since EFL 1.22)</summary>
    /// <returns>The calculated region.</returns>
    virtual public Eina.Rect CalcPartsExtends() {
         var _ret_var = Efl.Layout.ICalcNativeInherit.efl_layout_calc_parts_extends_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freezes the layout object.
    /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The frozen state or 0 on error</returns>
    virtual public int FreezeCalc() {
         var _ret_var = Efl.Layout.ICalcNativeInherit.efl_layout_calc_freeze_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Thaws the layout object.
    /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
    /// 
    /// Note: If successive freezes were done, an equal number of thaws will be required.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
    virtual public int ThawCalc() {
         var _ret_var = Efl.Layout.ICalcNativeInherit.efl_layout_calc_thaw_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Forces a Size/Geometry calculation.
    /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns></returns>
    virtual public void CalcForce() {
         Efl.Layout.ICalcNativeInherit.efl_layout_calc_force_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
    /// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The minimum size as set in EDC.</returns>
    virtual public Eina.Size2D GetGroupSizeMin() {
         var _ret_var = Efl.Layout.IGroupNativeInherit.efl_layout_group_size_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
    /// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The maximum size as set in EDC.</returns>
    virtual public Eina.Size2D GetGroupSizeMax() {
         var _ret_var = Efl.Layout.IGroupNativeInherit.efl_layout_group_size_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrives an EDC data field&apos;s value from a given Edje object&apos;s group.
    /// This function fetches an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
    /// 
    /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// 
    /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
    /// 
    /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The data field&apos;s key string</param>
    /// <returns>The data&apos;s value string.</returns>
    virtual public System.String GetGroupData( System.String key) {
                                 var _ret_var = Efl.Layout.IGroupNativeInherit.efl_layout_group_data_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns <c>true</c> if the part exists in the EDC group.
    /// (Since EFL 1.22)</summary>
    /// <param name="part">The part name to check.</param>
    /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
    virtual public bool GetPartExist( System.String part) {
                                 var _ret_var = Efl.Layout.IGroupNativeInherit.efl_layout_group_part_exist_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), part);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sends an (Edje) message to a given Edje object
    /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
    /// 
    /// Messages can go both ways, from code to theme, or theme to code.
    /// 
    /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).
    /// (Since EFL 1.22)</summary>
    /// <param name="id">A identification number for the message to be sent</param>
    /// <param name="msg">The message&apos;s payload</param>
    /// <returns></returns>
    virtual public void MessageSend( int id,  Eina.Value msg) {
                                                         Efl.Layout.ISignalNativeInherit.efl_layout_signal_message_send_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id,  msg);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
    /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
    /// 
    /// Signals can go both ways, from code to theme, or theme to code.
    /// 
    /// Though there are those common uses for the two strings, one is free to use them however they like.
    /// 
    /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[&quot; set of <c>fnmatch</c>() operators can be used, both for emission and source.
    /// 
    /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
    /// 
    /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="Efl.Layout.ISignal.DelSignalCallback"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    virtual public bool AddSignalCallback( System.String emission,  System.String source,  EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalNativeInherit.efl_layout_signal_callback_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Removes a signal-triggered callback from an object.
    /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <param name="func">The callback function to be executed when the signal is emitted.</param>
    /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
    virtual public bool DelSignalCallback( System.String emission,  System.String source,  EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalNativeInherit.efl_layout_signal_callback_del_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Sends/emits an Edje signal to this layout.
    /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
    /// 
    /// See also the Edje Data Collection Reference for EDC files.
    /// 
    /// See <see cref="Efl.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.
    /// (Since EFL 1.22)</summary>
    /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
    /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
    /// <returns></returns>
    virtual public void EmitSignal( System.String emission,  System.String source) {
                                                         Efl.Layout.ISignalNativeInherit.efl_layout_signal_emit_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), emission,  source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Processes an object&apos;s messages and signals queue.
    /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
    /// 
    /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
    /// (Since EFL 1.22)</summary>
    /// <param name="recurse">Whether to process messages on children objects.</param>
    /// <returns></returns>
    virtual public void SignalProcess( bool recurse) {
                                 Efl.Layout.ISignalNativeInherit.efl_layout_signal_process_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), recurse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <returns>Turn on or off drop_target. Default is <c>false</c>.</returns>
    virtual public bool GetDragTarget() {
         var _ret_var = Efl.Ui.IDraggableNativeInherit.efl_ui_draggable_drag_target_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <param name="set">Turn on or off drop_target. Default is <c>false</c>.</param>
    /// <returns></returns>
    virtual public void SetDragTarget( bool set) {
                                 Efl.Ui.IDraggableNativeInherit.efl_ui_draggable_drag_target_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the icon name of image set by icon standard names.
/// If the image was set using efl_file_set() instead of <see cref="Efl.Ui.Image.SetIcon"/>, then this function will return null.</summary>
/// <value>The icon name</value>
    public System.String Icon {
        get { return GetIcon(); }
        set { SetIcon( value); }
    }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
/// (Since EFL 1.22)</summary>
/// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap( value); }
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile( value); }
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
/// 
/// You must not modify the strings on the returned pointers.
/// (Since EFL 1.22)</summary>
/// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey( value); }
    }
    /// <summary>Get the load state of the object.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }
    /// <summary>Control the orientation of a given object.
/// This can be used to set the rotation on an image or a window, for instance.</summary>
/// <value>The rotation angle (CCW), see <see cref="Efl.Orient"/>.</value>
    public Efl.Orient Orientation {
        get { return GetOrientation(); }
        set { SetOrientation( value); }
    }
    /// <summary>Control the flip of the given image
/// Use this function to change how your image is to be flipped: vertically or horizontally or transpose or traverse.</summary>
/// <value>Flip method</value>
    public Efl.Flip Flip {
        get { return GetFlip(); }
        set { SetFlip( value); }
    }
    /// <summary>Whether or not the playable can be played.</summary>
/// <value><c>true</c> if the object have playable data, <c>false</c> otherwise</value>
    public bool Playable {
        get { return GetPlayable(); }
    }
    /// <summary>Get play/pause state of the media file.</summary>
/// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    public bool Play {
        get { return GetPlay(); }
        set { SetPlay( value); }
    }
    /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
/// <value>The position (in seconds).</value>
    public double Pos {
        get { return GetPos(); }
        set { SetPos( value); }
    }
    /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
/// <value>The progress within the [0, 1] range.</value>
    public double Progress {
        get { return GetProgress(); }
    }
    /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
/// <value>The play speed in the [0, infinity) range.</value>
    public double PlaySpeed {
        get { return GetPlaySpeed(); }
        set { SetPlaySpeed( value); }
    }
    /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <value>The volume level</value>
    public double Volume {
        get { return GetVolume(); }
        set { SetVolume( value); }
    }
    /// <summary>This property controls the audio mute state.</summary>
/// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    public bool Mute {
        get { return GetMute(); }
        set { SetMute( value); }
    }
    /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
    public double Length {
        get { return GetLength(); }
    }
    /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
    public bool Seekable {
        get { return GetSeekable(); }
    }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
/// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
/// 
/// <c>true</c> by default</summary>
/// <value>Whether to use smooth scale or not.</value>
    public bool SmoothScale {
        get { return GetSmoothScale(); }
        set { SetSmoothScale( value); }
    }
    /// <summary>Control how the image is scaled.</summary>
/// <value>Image scale type</value>
    public Efl.Gfx.ImageScaleType ScaleType {
        get { return GetScaleType(); }
        set { SetScaleType( value); }
    }
    /// <summary>The native width/height ratio of the image.</summary>
/// <value>The image&apos;s ratio.</value>
    public double Ratio {
        get { return GetRatio(); }
    }
    /// <summary>Scaling factor applied to the image borders.
/// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
/// 
/// Default value is 1.0 (no scaling).</summary>
/// <value>The scale factor.</value>
    public double BorderScale {
        get { return GetBorderScale(); }
        set { SetBorderScale( value); }
    }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
/// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
/// 
/// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
/// <value>Fill mode of the center region.</value>
    public Efl.Gfx.BorderFillMode BorderCenterFill {
        get { return GetBorderCenterFill(); }
        set { SetBorderCenterFill( value); }
    }
    /// <summary>This represents the size of the original image in pixels.
/// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
/// 
/// This is a read-only property, and may return 0x0.</summary>
/// <value>The size in pixels.</value>
    public Eina.Size2D ImageSize {
        get { return GetImageSize(); }
    }
    /// <summary>Get the content hint setting of a given image object of the canvas.
/// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
/// <value>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></value>
    public Efl.Gfx.ImageContentHint ContentHint {
        get { return GetContentHint(); }
        set { SetContentHint( value); }
    }
    /// <summary>Get the scale hint of a given image of the canvas.
/// This function returns the scale hint value of the given image object of the canvas.</summary>
/// <value>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></value>
    public Efl.Gfx.ImageScaleHint ScaleHint {
        get { return GetScaleHint(); }
        set { SetScaleHint( value); }
    }
    /// <summary>Gets the (last) file loading error for a given object.</summary>
/// <value>The load error code.</value>
    public Eina.Error ImageLoadError {
        get { return GetImageLoadError(); }
    }
    /// <summary>The load size of an image.
/// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like svg.
/// 
/// By default, the load size is not specified, so it is 0x0.</summary>
/// <value>The image load size.</value>
    public Eina.Size2D LoadSize {
        get { return GetLoadSize(); }
        set { SetLoadSize( value); }
    }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
/// This function returns the DPI resolution of the given canvas image.</summary>
/// <value>The DPI resolution.</value>
    public double LoadDpi {
        get { return GetLoadDpi(); }
        set { SetLoadDpi( value); }
    }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
/// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise</value>
    public bool LoadRegionSupport {
        get { return GetLoadRegionSupport(); }
    }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
/// <value>A region of the image.</value>
    public Eina.Rect LoadRegion {
        get { return GetLoadRegion(); }
        set { SetLoadRegion( value); }
    }
    /// <summary>Defines whether the orientation information in the image file should be honored.
/// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
/// <value><c>true</c> means that it should honor the orientation information.</value>
    public bool LoadOrientation {
        get { return GetLoadOrientation(); }
        set { SetLoadOrientation( value); }
    }
    /// <summary>The scale down factor is a divider on the original image size.
/// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
/// 
/// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
/// 
/// Powers of two (2, 4, 8) are best supported (especially with JPEG)</summary>
/// <value>The scale down dividing factor.</value>
    public int LoadScaleDown {
        get { return GetLoadScaleDown(); }
        set { SetLoadScaleDown( value); }
    }
    /// <summary>Initial load should skip header check and leave it all to data load
/// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
/// <value>Will be true if header is to be skipped.</value>
    public bool LoadSkipHeader {
        get { return GetLoadSkipHeader(); }
        set { SetLoadSkipHeader( value); }
    }
    /// <summary>The dimensions of this object&apos;s viewport.
/// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
/// 
/// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
/// 
/// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
/// 
/// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
/// 
/// Refer to each implementing class specific documentation for more details.</summary>
/// <value>Size of the view.</value>
    public Eina.Size2D ViewSize {
        get { return GetViewSize(); }
        set { SetViewSize( value); }
    }
    /// <summary>Whether this object updates its size hints automatically.
/// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
/// 
/// A layout recalculation can be triggered by <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.
/// (Since EFL 1.22)</summary>
/// <value>Whether or not update the size hints.</value>
    public bool CalcAutoUpdateHints {
        get { return GetCalcAutoUpdateHints(); }
        set { SetCalcAutoUpdateHints( value); }
    }
    /// <summary>Gets the minimum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
/// 
/// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
/// 
/// Note: On failure, this function also return 0x0.
/// 
/// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
/// (Since EFL 1.22)</summary>
/// <value>The minimum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMin {
        get { return GetGroupSizeMin(); }
    }
    /// <summary>Gets the maximum size specified -- as an EDC property -- for a given Edje object
/// This function retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
/// 
/// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
/// 
/// Note: On failure, this function will return 0x0.
/// 
/// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
/// (Since EFL 1.22)</summary>
/// <value>The maximum size as set in EDC.</value>
    public Eina.Size2D GroupSizeMax {
        get { return GetGroupSizeMax(); }
    }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
/// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
/// <value>Turn on or off drop_target. Default is <c>false</c>.</value>
    public bool DragTarget {
        get { return GetDragTarget(); }
        set { SetDragTarget( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Image.efl_ui_image_class_get();
    }
}
public class ImageNativeInherit : Efl.Ui.WidgetNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_image_scalable_get_static_delegate == null)
            efl_ui_image_scalable_get_static_delegate = new efl_ui_image_scalable_get_delegate(scalable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScalable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_scalable_get_static_delegate)});
        if (efl_ui_image_scalable_set_static_delegate == null)
            efl_ui_image_scalable_set_static_delegate = new efl_ui_image_scalable_set_delegate(scalable_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScalable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_scalable_set_static_delegate)});
        if (efl_ui_image_align_get_static_delegate == null)
            efl_ui_image_align_get_static_delegate = new efl_ui_image_align_get_delegate(align_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAlign") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_align_get_static_delegate)});
        if (efl_ui_image_align_set_static_delegate == null)
            efl_ui_image_align_set_static_delegate = new efl_ui_image_align_set_delegate(align_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAlign") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_align_set_static_delegate)});
        if (efl_ui_image_icon_get_static_delegate == null)
            efl_ui_image_icon_get_static_delegate = new efl_ui_image_icon_get_delegate(icon_get);
        if (methods.FirstOrDefault(m => m.Name == "GetIcon") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_icon_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_get_static_delegate)});
        if (efl_ui_image_icon_set_static_delegate == null)
            efl_ui_image_icon_set_static_delegate = new efl_ui_image_icon_set_delegate(icon_set);
        if (methods.FirstOrDefault(m => m.Name == "SetIcon") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_image_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_set_static_delegate)});
        if (efl_file_mmap_get_static_delegate == null)
            efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMmap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate)});
        if (efl_file_mmap_set_static_delegate == null)
            efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMmap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate)});
        if (efl_file_get_static_delegate == null)
            efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFile") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate)});
        if (efl_file_set_static_delegate == null)
            efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFile") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate)});
        if (efl_file_key_get_static_delegate == null)
            efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
        if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate)});
        if (efl_file_key_set_static_delegate == null)
            efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
        if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate)});
        if (efl_file_loaded_get_static_delegate == null)
            efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoaded") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate)});
        if (efl_file_load_static_delegate == null)
            efl_file_load_static_delegate = new efl_file_load_delegate(load);
        if (methods.FirstOrDefault(m => m.Name == "Load") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate)});
        if (efl_file_unload_static_delegate == null)
            efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
        if (methods.FirstOrDefault(m => m.Name == "Unload") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate)});
        if (efl_orientation_get_static_delegate == null)
            efl_orientation_get_static_delegate = new efl_orientation_get_delegate(orientation_get);
        if (methods.FirstOrDefault(m => m.Name == "GetOrientation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_get_static_delegate)});
        if (efl_orientation_set_static_delegate == null)
            efl_orientation_set_static_delegate = new efl_orientation_set_delegate(orientation_set);
        if (methods.FirstOrDefault(m => m.Name == "SetOrientation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_set_static_delegate)});
        if (efl_orientation_flip_get_static_delegate == null)
            efl_orientation_flip_get_static_delegate = new efl_orientation_flip_get_delegate(flip_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFlip") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_flip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_get_static_delegate)});
        if (efl_orientation_flip_set_static_delegate == null)
            efl_orientation_flip_set_static_delegate = new efl_orientation_flip_set_delegate(flip_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFlip") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_orientation_flip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_orientation_flip_set_static_delegate)});
        if (efl_player_playable_get_static_delegate == null)
            efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlayable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate)});
        if (efl_player_play_get_static_delegate == null)
            efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlay") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate)});
        if (efl_player_play_set_static_delegate == null)
            efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPlay") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate)});
        if (efl_player_pos_get_static_delegate == null)
            efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate)});
        if (efl_player_pos_set_static_delegate == null)
            efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate)});
        if (efl_player_progress_get_static_delegate == null)
            efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
        if (methods.FirstOrDefault(m => m.Name == "GetProgress") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate)});
        if (efl_player_play_speed_get_static_delegate == null)
            efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlaySpeed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate)});
        if (efl_player_play_speed_set_static_delegate == null)
            efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPlaySpeed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate)});
        if (efl_player_volume_get_static_delegate == null)
            efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
        if (methods.FirstOrDefault(m => m.Name == "GetVolume") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate)});
        if (efl_player_volume_set_static_delegate == null)
            efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
        if (methods.FirstOrDefault(m => m.Name == "SetVolume") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate)});
        if (efl_player_mute_get_static_delegate == null)
            efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate)});
        if (efl_player_mute_set_static_delegate == null)
            efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate)});
        if (efl_player_length_get_static_delegate == null)
            efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate)});
        if (efl_player_seekable_get_static_delegate == null)
            efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSeekable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate)});
        if (efl_player_start_static_delegate == null)
            efl_player_start_static_delegate = new efl_player_start_delegate(start);
        if (methods.FirstOrDefault(m => m.Name == "Start") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate)});
        if (efl_player_stop_static_delegate == null)
            efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
        if (methods.FirstOrDefault(m => m.Name == "Stop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate)});
        if (efl_gfx_image_smooth_scale_get_static_delegate == null)
            efl_gfx_image_smooth_scale_get_static_delegate = new efl_gfx_image_smooth_scale_get_delegate(smooth_scale_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSmoothScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_smooth_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_get_static_delegate)});
        if (efl_gfx_image_smooth_scale_set_static_delegate == null)
            efl_gfx_image_smooth_scale_set_static_delegate = new efl_gfx_image_smooth_scale_set_delegate(smooth_scale_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSmoothScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_smooth_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_set_static_delegate)});
        if (efl_gfx_image_scale_type_get_static_delegate == null)
            efl_gfx_image_scale_type_get_static_delegate = new efl_gfx_image_scale_type_get_delegate(scale_type_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScaleType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_get_static_delegate)});
        if (efl_gfx_image_scale_type_set_static_delegate == null)
            efl_gfx_image_scale_type_set_static_delegate = new efl_gfx_image_scale_type_set_delegate(scale_type_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScaleType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_set_static_delegate)});
        if (efl_gfx_image_ratio_get_static_delegate == null)
            efl_gfx_image_ratio_get_static_delegate = new efl_gfx_image_ratio_get_delegate(ratio_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRatio") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_ratio_get_static_delegate)});
        if (efl_gfx_image_border_get_static_delegate == null)
            efl_gfx_image_border_get_static_delegate = new efl_gfx_image_border_get_delegate(border_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBorder") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_get_static_delegate)});
        if (efl_gfx_image_border_set_static_delegate == null)
            efl_gfx_image_border_set_static_delegate = new efl_gfx_image_border_set_delegate(border_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBorder") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_set_static_delegate)});
        if (efl_gfx_image_border_scale_get_static_delegate == null)
            efl_gfx_image_border_scale_get_static_delegate = new efl_gfx_image_border_scale_get_delegate(border_scale_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBorderScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_get_static_delegate)});
        if (efl_gfx_image_border_scale_set_static_delegate == null)
            efl_gfx_image_border_scale_set_static_delegate = new efl_gfx_image_border_scale_set_delegate(border_scale_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBorderScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_set_static_delegate)});
        if (efl_gfx_image_border_center_fill_get_static_delegate == null)
            efl_gfx_image_border_center_fill_get_static_delegate = new efl_gfx_image_border_center_fill_get_delegate(border_center_fill_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBorderCenterFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_center_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_get_static_delegate)});
        if (efl_gfx_image_border_center_fill_set_static_delegate == null)
            efl_gfx_image_border_center_fill_set_static_delegate = new efl_gfx_image_border_center_fill_set_delegate(border_center_fill_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBorderCenterFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_border_center_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_set_static_delegate)});
        if (efl_gfx_image_size_get_static_delegate == null)
            efl_gfx_image_size_get_static_delegate = new efl_gfx_image_size_get_delegate(image_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetImageSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_size_get_static_delegate)});
        if (efl_gfx_image_content_hint_get_static_delegate == null)
            efl_gfx_image_content_hint_get_static_delegate = new efl_gfx_image_content_hint_get_delegate(content_hint_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContentHint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_content_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_get_static_delegate)});
        if (efl_gfx_image_content_hint_set_static_delegate == null)
            efl_gfx_image_content_hint_set_static_delegate = new efl_gfx_image_content_hint_set_delegate(content_hint_set);
        if (methods.FirstOrDefault(m => m.Name == "SetContentHint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_content_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_set_static_delegate)});
        if (efl_gfx_image_scale_hint_get_static_delegate == null)
            efl_gfx_image_scale_hint_get_static_delegate = new efl_gfx_image_scale_hint_get_delegate(scale_hint_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScaleHint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_get_static_delegate)});
        if (efl_gfx_image_scale_hint_set_static_delegate == null)
            efl_gfx_image_scale_hint_set_static_delegate = new efl_gfx_image_scale_hint_set_delegate(scale_hint_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScaleHint") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_scale_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_set_static_delegate)});
        if (efl_gfx_image_load_error_get_static_delegate == null)
            efl_gfx_image_load_error_get_static_delegate = new efl_gfx_image_load_error_get_delegate(image_load_error_get);
        if (methods.FirstOrDefault(m => m.Name == "GetImageLoadError") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_error_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_size_get_static_delegate == null)
            efl_gfx_image_load_controller_load_size_get_static_delegate = new efl_gfx_image_load_controller_load_size_get_delegate(load_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_size_set_static_delegate == null)
            efl_gfx_image_load_controller_load_size_set_static_delegate = new efl_gfx_image_load_controller_load_size_set_delegate(load_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_dpi_get_static_delegate == null)
            efl_gfx_image_load_controller_load_dpi_get_static_delegate = new efl_gfx_image_load_controller_load_dpi_get_delegate(load_dpi_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadDpi") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_dpi_set_static_delegate == null)
            efl_gfx_image_load_controller_load_dpi_set_static_delegate = new efl_gfx_image_load_controller_load_dpi_set_delegate(load_dpi_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadDpi") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_dpi_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_region_support_get_static_delegate == null)
            efl_gfx_image_load_controller_load_region_support_get_static_delegate = new efl_gfx_image_load_controller_load_region_support_get_delegate(load_region_support_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadRegionSupport") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_region_support_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_support_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_region_get_static_delegate == null)
            efl_gfx_image_load_controller_load_region_get_static_delegate = new efl_gfx_image_load_controller_load_region_get_delegate(load_region_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadRegion") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_region_set_static_delegate == null)
            efl_gfx_image_load_controller_load_region_set_static_delegate = new efl_gfx_image_load_controller_load_region_set_delegate(load_region_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadRegion") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_orientation_get_static_delegate == null)
            efl_gfx_image_load_controller_load_orientation_get_static_delegate = new efl_gfx_image_load_controller_load_orientation_get_delegate(load_orientation_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadOrientation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_orientation_set_static_delegate == null)
            efl_gfx_image_load_controller_load_orientation_set_static_delegate = new efl_gfx_image_load_controller_load_orientation_set_delegate(load_orientation_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadOrientation") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_scale_down_get_static_delegate == null)
            efl_gfx_image_load_controller_load_scale_down_get_static_delegate = new efl_gfx_image_load_controller_load_scale_down_get_delegate(load_scale_down_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadScaleDown") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_scale_down_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_scale_down_set_static_delegate == null)
            efl_gfx_image_load_controller_load_scale_down_set_static_delegate = new efl_gfx_image_load_controller_load_scale_down_set_delegate(load_scale_down_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadScaleDown") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_scale_down_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_skip_header_get_static_delegate == null)
            efl_gfx_image_load_controller_load_skip_header_get_static_delegate = new efl_gfx_image_load_controller_load_skip_header_get_delegate(load_skip_header_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLoadSkipHeader") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_skip_header_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_get_static_delegate)});
        if (efl_gfx_image_load_controller_load_skip_header_set_static_delegate == null)
            efl_gfx_image_load_controller_load_skip_header_set_static_delegate = new efl_gfx_image_load_controller_load_skip_header_set_delegate(load_skip_header_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLoadSkipHeader") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_skip_header_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_set_static_delegate)});
        if (efl_gfx_image_load_controller_load_async_start_static_delegate == null)
            efl_gfx_image_load_controller_load_async_start_static_delegate = new efl_gfx_image_load_controller_load_async_start_delegate(load_async_start);
        if (methods.FirstOrDefault(m => m.Name == "LoadAsyncStart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_async_start"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_start_static_delegate)});
        if (efl_gfx_image_load_controller_load_async_cancel_static_delegate == null)
            efl_gfx_image_load_controller_load_async_cancel_static_delegate = new efl_gfx_image_load_controller_load_async_cancel_delegate(load_async_cancel);
        if (methods.FirstOrDefault(m => m.Name == "LoadAsyncCancel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_image_load_controller_load_async_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_cancel_static_delegate)});
        if (efl_gfx_view_size_get_static_delegate == null)
            efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetViewSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate)});
        if (efl_gfx_view_size_set_static_delegate == null)
            efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetViewSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate)});
        if (efl_layout_calc_auto_update_hints_get_static_delegate == null)
            efl_layout_calc_auto_update_hints_get_static_delegate = new efl_layout_calc_auto_update_hints_get_delegate(calc_auto_update_hints_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCalcAutoUpdateHints") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_auto_update_hints_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_get_static_delegate)});
        if (efl_layout_calc_auto_update_hints_set_static_delegate == null)
            efl_layout_calc_auto_update_hints_set_static_delegate = new efl_layout_calc_auto_update_hints_set_delegate(calc_auto_update_hints_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCalcAutoUpdateHints") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_auto_update_hints_set"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_set_static_delegate)});
        if (efl_layout_calc_size_min_static_delegate == null)
            efl_layout_calc_size_min_static_delegate = new efl_layout_calc_size_min_delegate(calc_size_min);
        if (methods.FirstOrDefault(m => m.Name == "CalcSizeMin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_size_min"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_size_min_static_delegate)});
        if (efl_layout_calc_parts_extends_static_delegate == null)
            efl_layout_calc_parts_extends_static_delegate = new efl_layout_calc_parts_extends_delegate(calc_parts_extends);
        if (methods.FirstOrDefault(m => m.Name == "CalcPartsExtends") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_parts_extends"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_parts_extends_static_delegate)});
        if (efl_layout_calc_freeze_static_delegate == null)
            efl_layout_calc_freeze_static_delegate = new efl_layout_calc_freeze_delegate(calc_freeze);
        if (methods.FirstOrDefault(m => m.Name == "FreezeCalc") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_freeze_static_delegate)});
        if (efl_layout_calc_thaw_static_delegate == null)
            efl_layout_calc_thaw_static_delegate = new efl_layout_calc_thaw_delegate(calc_thaw);
        if (methods.FirstOrDefault(m => m.Name == "ThawCalc") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_thaw_static_delegate)});
        if (efl_layout_calc_force_static_delegate == null)
            efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
        if (methods.FirstOrDefault(m => m.Name == "CalcForce") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate)});
        if (efl_layout_group_size_min_get_static_delegate == null)
            efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate)});
        if (efl_layout_group_size_max_get_static_delegate == null)
            efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMax") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate)});
        if (efl_layout_group_data_get_static_delegate == null)
            efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGroupData") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate)});
        if (efl_layout_group_part_exist_get_static_delegate == null)
            efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPartExist") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate)});
        if (efl_layout_signal_message_send_static_delegate == null)
            efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
        if (methods.FirstOrDefault(m => m.Name == "MessageSend") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate)});
        if (efl_layout_signal_callback_add_static_delegate == null)
            efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
        if (methods.FirstOrDefault(m => m.Name == "AddSignalCallback") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate)});
        if (efl_layout_signal_callback_del_static_delegate == null)
            efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
        if (methods.FirstOrDefault(m => m.Name == "DelSignalCallback") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate)});
        if (efl_layout_signal_emit_static_delegate == null)
            efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
        if (methods.FirstOrDefault(m => m.Name == "EmitSignal") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate)});
        if (efl_layout_signal_process_static_delegate == null)
            efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
        if (methods.FirstOrDefault(m => m.Name == "SignalProcess") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate)});
        if (efl_ui_draggable_drag_target_get_static_delegate == null)
            efl_ui_draggable_drag_target_get_static_delegate = new efl_ui_draggable_drag_target_get_delegate(drag_target_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDragTarget") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_draggable_drag_target_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_get_static_delegate)});
        if (efl_ui_draggable_drag_target_set_static_delegate == null)
            efl_ui_draggable_drag_target_set_static_delegate = new efl_ui_draggable_drag_target_set_delegate(drag_target_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDragTarget") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_draggable_drag_target_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Image.efl_ui_image_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Image.efl_ui_image_class_get();
    }


     private delegate void efl_ui_image_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool scale_up,  [MarshalAs(UnmanagedType.U1)]  out bool scale_down);


     public delegate void efl_ui_image_scalable_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool scale_up,  [MarshalAs(UnmanagedType.U1)]  out bool scale_down);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_scalable_get_api_delegate> efl_ui_image_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_scalable_get_api_delegate>(_Module, "efl_ui_image_scalable_get");
     private static void scalable_get(System.IntPtr obj, System.IntPtr pd,  out bool scale_up,  out bool scale_down)
    {
        Eina.Log.Debug("function efl_ui_image_scalable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    scale_up = default(bool);        scale_down = default(bool);                            
            try {
                ((Image)wrapper).GetScalable( out scale_up,  out scale_down);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_image_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out scale_up,  out scale_down);
        }
    }
    private static efl_ui_image_scalable_get_delegate efl_ui_image_scalable_get_static_delegate;


     private delegate void efl_ui_image_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool scale_up,  [MarshalAs(UnmanagedType.U1)]  bool scale_down);


     public delegate void efl_ui_image_scalable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool scale_up,  [MarshalAs(UnmanagedType.U1)]  bool scale_down);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_scalable_set_api_delegate> efl_ui_image_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_scalable_set_api_delegate>(_Module, "efl_ui_image_scalable_set");
     private static void scalable_set(System.IntPtr obj, System.IntPtr pd,  bool scale_up,  bool scale_down)
    {
        Eina.Log.Debug("function efl_ui_image_scalable_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Image)wrapper).SetScalable( scale_up,  scale_down);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_image_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale_up,  scale_down);
        }
    }
    private static efl_ui_image_scalable_set_delegate efl_ui_image_scalable_set_static_delegate;


     private delegate void efl_ui_image_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double align_x,   out double align_y);


     public delegate void efl_ui_image_align_get_api_delegate(System.IntPtr obj,   out double align_x,   out double align_y);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_align_get_api_delegate> efl_ui_image_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_align_get_api_delegate>(_Module, "efl_ui_image_align_get");
     private static void align_get(System.IntPtr obj, System.IntPtr pd,  out double align_x,  out double align_y)
    {
        Eina.Log.Debug("function efl_ui_image_align_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    align_x = default(double);        align_y = default(double);                            
            try {
                ((Image)wrapper).GetAlign( out align_x,  out align_y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_image_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out align_x,  out align_y);
        }
    }
    private static efl_ui_image_align_get_delegate efl_ui_image_align_get_static_delegate;


     private delegate void efl_ui_image_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double align_x,   double align_y);


     public delegate void efl_ui_image_align_set_api_delegate(System.IntPtr obj,   double align_x,   double align_y);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_align_set_api_delegate> efl_ui_image_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_align_set_api_delegate>(_Module, "efl_ui_image_align_set");
     private static void align_set(System.IntPtr obj, System.IntPtr pd,  double align_x,  double align_y)
    {
        Eina.Log.Debug("function efl_ui_image_align_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Image)wrapper).SetAlign( align_x,  align_y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_image_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  align_x,  align_y);
        }
    }
    private static efl_ui_image_align_set_delegate efl_ui_image_align_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_image_icon_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_image_icon_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_icon_get_api_delegate> efl_ui_image_icon_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_icon_get_api_delegate>(_Module, "efl_ui_image_icon_get");
     private static System.String icon_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_image_icon_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Image)wrapper).GetIcon();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_image_icon_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_image_icon_get_delegate efl_ui_image_icon_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_image_icon_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_image_icon_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);
     public static Efl.Eo.FunctionWrapper<efl_ui_image_icon_set_api_delegate> efl_ui_image_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_icon_set_api_delegate>(_Module, "efl_ui_image_icon_set");
     private static bool icon_set(System.IntPtr obj, System.IntPtr pd,  System.String name)
    {
        Eina.Log.Debug("function efl_ui_image_icon_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).SetIcon( name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_image_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
        }
    }
    private static efl_ui_image_icon_set_delegate efl_ui_image_icon_set_static_delegate;


     private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(_Module, "efl_file_mmap_get");
     private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_mmap_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.File _ret_var = default(Eina.File);
            try {
                _ret_var = ((Image)wrapper).GetMmap();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;


     private delegate Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.File f);


     public delegate Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,   Eina.File f);
     public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(_Module, "efl_file_mmap_set");
     private static Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd,  Eina.File f)
    {
        Eina.Log.Debug("function efl_file_mmap_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Image)wrapper).SetMmap( f);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
        }
    }
    private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_file_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(_Module, "efl_file_get");
     private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Image)wrapper).GetFile();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_get_delegate efl_file_get_static_delegate;


     private delegate Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String file);


     public delegate Eina.Error efl_file_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String file);
     public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(_Module, "efl_file_set");
     private static Eina.Error file_set(System.IntPtr obj, System.IntPtr pd,  System.String file)
    {
        Eina.Log.Debug("function efl_file_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Image)wrapper).SetFile( file);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file);
        }
    }
    private static efl_file_set_delegate efl_file_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(_Module, "efl_file_key_get");
     private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_key_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Image)wrapper).GetKey();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_key_get_delegate efl_file_key_get_static_delegate;


     private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key);


     public delegate void efl_file_key_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key);
     public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(_Module, "efl_file_key_set");
     private static void key_set(System.IntPtr obj, System.IntPtr pd,  System.String key)
    {
        Eina.Log.Debug("function efl_file_key_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetKey( key);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
        }
    }
    private static efl_file_key_set_delegate efl_file_key_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(_Module, "efl_file_loaded_get");
     private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_loaded_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetLoaded();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;


     private delegate Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Error efl_file_load_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(_Module, "efl_file_load");
     private static Eina.Error load(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_load was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Image)wrapper).Load();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_load_delegate efl_file_load_static_delegate;


     private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_file_unload_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(_Module, "efl_file_unload");
     private static void unload(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_file_unload was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).Unload();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_unload_delegate efl_file_unload_static_delegate;


     private delegate Efl.Orient efl_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Orient efl_orientation_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_orientation_get_api_delegate> efl_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_get_api_delegate>(_Module, "efl_orientation_get");
     private static Efl.Orient orientation_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_orientation_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Orient _ret_var = default(Efl.Orient);
            try {
                _ret_var = ((Image)wrapper).GetOrientation();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_orientation_get_delegate efl_orientation_get_static_delegate;


     private delegate void efl_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Orient dir);


     public delegate void efl_orientation_set_api_delegate(System.IntPtr obj,   Efl.Orient dir);
     public static Efl.Eo.FunctionWrapper<efl_orientation_set_api_delegate> efl_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_set_api_delegate>(_Module, "efl_orientation_set");
     private static void orientation_set(System.IntPtr obj, System.IntPtr pd,  Efl.Orient dir)
    {
        Eina.Log.Debug("function efl_orientation_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetOrientation( dir);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
        }
    }
    private static efl_orientation_set_delegate efl_orientation_set_static_delegate;


     private delegate Efl.Flip efl_orientation_flip_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Flip efl_orientation_flip_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_orientation_flip_get_api_delegate> efl_orientation_flip_get_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_flip_get_api_delegate>(_Module, "efl_orientation_flip_get");
     private static Efl.Flip flip_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_orientation_flip_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Flip _ret_var = default(Efl.Flip);
            try {
                _ret_var = ((Image)wrapper).GetFlip();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_orientation_flip_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_orientation_flip_get_delegate efl_orientation_flip_get_static_delegate;


     private delegate void efl_orientation_flip_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Flip flip);


     public delegate void efl_orientation_flip_set_api_delegate(System.IntPtr obj,   Efl.Flip flip);
     public static Efl.Eo.FunctionWrapper<efl_orientation_flip_set_api_delegate> efl_orientation_flip_set_ptr = new Efl.Eo.FunctionWrapper<efl_orientation_flip_set_api_delegate>(_Module, "efl_orientation_flip_set");
     private static void flip_set(System.IntPtr obj, System.IntPtr pd,  Efl.Flip flip)
    {
        Eina.Log.Debug("function efl_orientation_flip_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetFlip( flip);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_orientation_flip_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flip);
        }
    }
    private static efl_orientation_flip_set_delegate efl_orientation_flip_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_playable_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate> efl_player_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate>(_Module, "efl_player_playable_get");
     private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_playable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetPlayable();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_playable_get_delegate efl_player_playable_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_play_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_play_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate> efl_player_play_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate>(_Module, "efl_player_play_get");
     private static bool play_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_play_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetPlay();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_play_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_play_get_delegate efl_player_play_get_static_delegate;


     private delegate void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool play);


     public delegate void efl_player_play_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
     public static Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate> efl_player_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate>(_Module, "efl_player_play_set");
     private static void play_set(System.IntPtr obj, System.IntPtr pd,  bool play)
    {
        Eina.Log.Debug("function efl_player_play_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetPlay( play);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_play_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  play);
        }
    }
    private static efl_player_play_set_delegate efl_player_play_set_static_delegate;


     private delegate double efl_player_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_pos_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate> efl_player_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate>(_Module, "efl_player_pos_get");
     private static double pos_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_pos_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetPos();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_pos_get_delegate efl_player_pos_get_static_delegate;


     private delegate void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);


     public delegate void efl_player_pos_set_api_delegate(System.IntPtr obj,   double sec);
     public static Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate> efl_player_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate>(_Module, "efl_player_pos_set");
     private static void pos_set(System.IntPtr obj, System.IntPtr pd,  double sec)
    {
        Eina.Log.Debug("function efl_player_pos_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetPos( sec);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
        }
    }
    private static efl_player_pos_set_delegate efl_player_pos_set_static_delegate;


     private delegate double efl_player_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_progress_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate> efl_player_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate>(_Module, "efl_player_progress_get");
     private static double progress_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_progress_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetProgress();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_progress_get_delegate efl_player_progress_get_static_delegate;


     private delegate double efl_player_play_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_play_speed_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate> efl_player_play_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate>(_Module, "efl_player_play_speed_get");
     private static double play_speed_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_play_speed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetPlaySpeed();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_play_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_play_speed_get_delegate efl_player_play_speed_get_static_delegate;


     private delegate void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,   double speed);


     public delegate void efl_player_play_speed_set_api_delegate(System.IntPtr obj,   double speed);
     public static Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate> efl_player_play_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate>(_Module, "efl_player_play_speed_set");
     private static void play_speed_set(System.IntPtr obj, System.IntPtr pd,  double speed)
    {
        Eina.Log.Debug("function efl_player_play_speed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetPlaySpeed( speed);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_play_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  speed);
        }
    }
    private static efl_player_play_speed_set_delegate efl_player_play_speed_set_static_delegate;


     private delegate double efl_player_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_volume_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate> efl_player_volume_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate>(_Module, "efl_player_volume_get");
     private static double volume_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_volume_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetVolume();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_volume_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_volume_get_delegate efl_player_volume_get_static_delegate;


     private delegate void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,   double volume);


     public delegate void efl_player_volume_set_api_delegate(System.IntPtr obj,   double volume);
     public static Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate> efl_player_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate>(_Module, "efl_player_volume_set");
     private static void volume_set(System.IntPtr obj, System.IntPtr pd,  double volume)
    {
        Eina.Log.Debug("function efl_player_volume_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetVolume( volume);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_volume_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  volume);
        }
    }
    private static efl_player_volume_set_delegate efl_player_volume_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_mute_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate> efl_player_mute_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate>(_Module, "efl_player_mute_get");
     private static bool mute_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_mute_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetMute();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_mute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_mute_get_delegate efl_player_mute_get_static_delegate;


     private delegate void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool mute);


     public delegate void efl_player_mute_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
     public static Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate> efl_player_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate>(_Module, "efl_player_mute_set");
     private static void mute_set(System.IntPtr obj, System.IntPtr pd,  bool mute)
    {
        Eina.Log.Debug("function efl_player_mute_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetMute( mute);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_mute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mute);
        }
    }
    private static efl_player_mute_set_delegate efl_player_mute_set_static_delegate;


     private delegate double efl_player_length_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_length_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate> efl_player_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate>(_Module, "efl_player_length_get");
     private static double length_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_length_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetLength();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_length_get_delegate efl_player_length_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_seekable_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate> efl_player_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate>(_Module, "efl_player_seekable_get");
     private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_seekable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetSeekable();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_seekable_get_delegate efl_player_seekable_get_static_delegate;


     private delegate void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_player_start_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_start_api_delegate> efl_player_start_ptr = new Efl.Eo.FunctionWrapper<efl_player_start_api_delegate>(_Module, "efl_player_start");
     private static void start(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_start was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).Start();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_player_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_start_delegate efl_player_start_static_delegate;


     private delegate void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_player_stop_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate> efl_player_stop_ptr = new Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate>(_Module, "efl_player_stop");
     private static void stop(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_stop was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).Stop();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_player_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_stop_delegate efl_player_stop_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_image_smooth_scale_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate> efl_gfx_image_smooth_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate>(_Module, "efl_gfx_image_smooth_scale_get");
     private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetSmoothScale();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_smooth_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_smooth_scale_get_delegate efl_gfx_image_smooth_scale_get_static_delegate;


     private delegate void efl_gfx_image_smooth_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);


     public delegate void efl_gfx_image_smooth_scale_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth_scale);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate> efl_gfx_image_smooth_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate>(_Module, "efl_gfx_image_smooth_scale_set");
     private static void smooth_scale_set(System.IntPtr obj, System.IntPtr pd,  bool smooth_scale)
    {
        Eina.Log.Debug("function efl_gfx_image_smooth_scale_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetSmoothScale( smooth_scale);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_smooth_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth_scale);
        }
    }
    private static efl_gfx_image_smooth_scale_set_delegate efl_gfx_image_smooth_scale_set_static_delegate;


     private delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate> efl_gfx_image_scale_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate>(_Module, "efl_gfx_image_scale_type_get");
     private static Efl.Gfx.ImageScaleType scale_type_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_scale_type_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.ImageScaleType _ret_var = default(Efl.Gfx.ImageScaleType);
            try {
                _ret_var = ((Image)wrapper).GetScaleType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_scale_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_scale_type_get_delegate efl_gfx_image_scale_type_get_static_delegate;


     private delegate void efl_gfx_image_scale_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleType scale_type);


     public delegate void efl_gfx_image_scale_type_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageScaleType scale_type);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate> efl_gfx_image_scale_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate>(_Module, "efl_gfx_image_scale_type_set");
     private static void scale_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleType scale_type)
    {
        Eina.Log.Debug("function efl_gfx_image_scale_type_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetScaleType( scale_type);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_scale_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale_type);
        }
    }
    private static efl_gfx_image_scale_type_set_delegate efl_gfx_image_scale_type_set_static_delegate;


     private delegate double efl_gfx_image_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_image_ratio_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate> efl_gfx_image_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate>(_Module, "efl_gfx_image_ratio_get");
     private static double ratio_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_ratio_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetRatio();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_ratio_get_delegate efl_gfx_image_ratio_get_static_delegate;


     private delegate void efl_gfx_image_border_get_delegate(System.IntPtr obj, System.IntPtr pd,   out int l,   out int r,   out int t,   out int b);


     public delegate void efl_gfx_image_border_get_api_delegate(System.IntPtr obj,   out int l,   out int r,   out int t,   out int b);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate> efl_gfx_image_border_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate>(_Module, "efl_gfx_image_border_get");
     private static void border_get(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b)
    {
        Eina.Log.Debug("function efl_gfx_image_border_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
            try {
                ((Image)wrapper).GetBorder( out l,  out r,  out t,  out b);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_image_border_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
        }
    }
    private static efl_gfx_image_border_get_delegate efl_gfx_image_border_get_static_delegate;


     private delegate void efl_gfx_image_border_set_delegate(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b);


     public delegate void efl_gfx_image_border_set_api_delegate(System.IntPtr obj,   int l,   int r,   int t,   int b);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate> efl_gfx_image_border_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate>(_Module, "efl_gfx_image_border_set");
     private static void border_set(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b)
    {
        Eina.Log.Debug("function efl_gfx_image_border_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((Image)wrapper).SetBorder( l,  r,  t,  b);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_image_border_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
        }
    }
    private static efl_gfx_image_border_set_delegate efl_gfx_image_border_set_static_delegate;


     private delegate double efl_gfx_image_border_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_image_border_scale_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate> efl_gfx_image_border_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate>(_Module, "efl_gfx_image_border_scale_get");
     private static double border_scale_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_border_scale_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetBorderScale();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_border_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_border_scale_get_delegate efl_gfx_image_border_scale_get_static_delegate;


     private delegate void efl_gfx_image_border_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);


     public delegate void efl_gfx_image_border_scale_set_api_delegate(System.IntPtr obj,   double scale);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate> efl_gfx_image_border_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate>(_Module, "efl_gfx_image_border_scale_set");
     private static void border_scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
    {
        Eina.Log.Debug("function efl_gfx_image_border_scale_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetBorderScale( scale);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_border_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
        }
    }
    private static efl_gfx_image_border_scale_set_delegate efl_gfx_image_border_scale_set_static_delegate;


     private delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate> efl_gfx_image_border_center_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate>(_Module, "efl_gfx_image_border_center_fill_get");
     private static Efl.Gfx.BorderFillMode border_center_fill_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_border_center_fill_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.BorderFillMode _ret_var = default(Efl.Gfx.BorderFillMode);
            try {
                _ret_var = ((Image)wrapper).GetBorderCenterFill();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_border_center_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_border_center_fill_get_delegate efl_gfx_image_border_center_fill_get_static_delegate;


     private delegate void efl_gfx_image_border_center_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BorderFillMode fill);


     public delegate void efl_gfx_image_border_center_fill_set_api_delegate(System.IntPtr obj,   Efl.Gfx.BorderFillMode fill);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate> efl_gfx_image_border_center_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate>(_Module, "efl_gfx_image_border_center_fill_set");
     private static void border_center_fill_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BorderFillMode fill)
    {
        Eina.Log.Debug("function efl_gfx_image_border_center_fill_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetBorderCenterFill( fill);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_border_center_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
        }
    }
    private static efl_gfx_image_border_center_fill_set_delegate efl_gfx_image_border_center_fill_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_image_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_image_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate> efl_gfx_image_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate>(_Module, "efl_gfx_image_size_get");
     private static Eina.Size2D.NativeStruct image_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).GetImageSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_size_get_delegate efl_gfx_image_size_get_static_delegate;


     private delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate> efl_gfx_image_content_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate>(_Module, "efl_gfx_image_content_hint_get");
     private static Efl.Gfx.ImageContentHint content_hint_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_content_hint_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.ImageContentHint _ret_var = default(Efl.Gfx.ImageContentHint);
            try {
                _ret_var = ((Image)wrapper).GetContentHint();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_content_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_content_hint_get_delegate efl_gfx_image_content_hint_get_static_delegate;


     private delegate void efl_gfx_image_content_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageContentHint hint);


     public delegate void efl_gfx_image_content_hint_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageContentHint hint);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate> efl_gfx_image_content_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate>(_Module, "efl_gfx_image_content_hint_set");
     private static void content_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageContentHint hint)
    {
        Eina.Log.Debug("function efl_gfx_image_content_hint_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetContentHint( hint);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_content_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
        }
    }
    private static efl_gfx_image_content_hint_set_delegate efl_gfx_image_content_hint_set_static_delegate;


     private delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate> efl_gfx_image_scale_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate>(_Module, "efl_gfx_image_scale_hint_get");
     private static Efl.Gfx.ImageScaleHint scale_hint_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_scale_hint_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.ImageScaleHint _ret_var = default(Efl.Gfx.ImageScaleHint);
            try {
                _ret_var = ((Image)wrapper).GetScaleHint();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_scale_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_scale_hint_get_delegate efl_gfx_image_scale_hint_get_static_delegate;


     private delegate void efl_gfx_image_scale_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.ImageScaleHint hint);


     public delegate void efl_gfx_image_scale_hint_set_api_delegate(System.IntPtr obj,   Efl.Gfx.ImageScaleHint hint);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate> efl_gfx_image_scale_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate>(_Module, "efl_gfx_image_scale_hint_set");
     private static void scale_hint_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleHint hint)
    {
        Eina.Log.Debug("function efl_gfx_image_scale_hint_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetScaleHint( hint);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_scale_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hint);
        }
    }
    private static efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;


     private delegate Eina.Error efl_gfx_image_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Error efl_gfx_image_load_error_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate> efl_gfx_image_load_error_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate>(_Module, "efl_gfx_image_load_error_get");
     private static Eina.Error image_load_error_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_error_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Error _ret_var = default(Eina.Error);
            try {
                _ret_var = ((Image)wrapper).GetImageLoadError();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_error_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_error_get_delegate efl_gfx_image_load_error_get_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate> efl_gfx_image_load_controller_load_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_size_get");
     private static Eina.Size2D.NativeStruct load_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).GetLoadSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_size_get_delegate efl_gfx_image_load_controller_load_size_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct size);


     public delegate void efl_gfx_image_load_controller_load_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct size);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate> efl_gfx_image_load_controller_load_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_size_set");
     private static void load_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_size = size;
                            
            try {
                ((Image)wrapper).SetLoadSize( _in_size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_gfx_image_load_controller_load_size_set_delegate efl_gfx_image_load_controller_load_size_set_static_delegate;


     private delegate double efl_gfx_image_load_controller_load_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_image_load_controller_load_dpi_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate> efl_gfx_image_load_controller_load_dpi_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_dpi_get");
     private static double load_dpi_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Image)wrapper).GetLoadDpi();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_dpi_get_delegate efl_gfx_image_load_controller_load_dpi_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_dpi_set_delegate(System.IntPtr obj, System.IntPtr pd,   double dpi);


     public delegate void efl_gfx_image_load_controller_load_dpi_set_api_delegate(System.IntPtr obj,   double dpi);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate> efl_gfx_image_load_controller_load_dpi_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_dpi_set");
     private static void load_dpi_set(System.IntPtr obj, System.IntPtr pd,  double dpi)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetLoadDpi( dpi);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dpi);
        }
    }
    private static efl_gfx_image_load_controller_load_dpi_set_delegate efl_gfx_image_load_controller_load_dpi_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_region_support_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_image_load_controller_load_region_support_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate> efl_gfx_image_load_controller_load_region_support_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_region_support_get");
     private static bool load_region_support_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_support_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetLoadRegionSupport();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_region_support_get_delegate efl_gfx_image_load_controller_load_region_support_get_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate> efl_gfx_image_load_controller_load_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_region_get");
     private static Eina.Rect.NativeStruct load_region_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((Image)wrapper).GetLoadRegion();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_region_get_delegate efl_gfx_image_load_controller_load_region_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_region_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct region);


     public delegate void efl_gfx_image_load_controller_load_region_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct region);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate> efl_gfx_image_load_controller_load_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_region_set");
     private static void load_region_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct region)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_region = region;
                            
            try {
                ((Image)wrapper).SetLoadRegion( _in_region);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  region);
        }
    }
    private static efl_gfx_image_load_controller_load_region_set_delegate efl_gfx_image_load_controller_load_region_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_image_load_controller_load_orientation_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate> efl_gfx_image_load_controller_load_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_orientation_get");
     private static bool load_orientation_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetLoadOrientation();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_orientation_get_delegate efl_gfx_image_load_controller_load_orientation_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);


     public delegate void efl_gfx_image_load_controller_load_orientation_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate> efl_gfx_image_load_controller_load_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_orientation_set");
     private static void load_orientation_set(System.IntPtr obj, System.IntPtr pd,  bool enable)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetLoadOrientation( enable);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
        }
    }
    private static efl_gfx_image_load_controller_load_orientation_set_delegate efl_gfx_image_load_controller_load_orientation_set_static_delegate;


     private delegate int efl_gfx_image_load_controller_load_scale_down_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_gfx_image_load_controller_load_scale_down_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate> efl_gfx_image_load_controller_load_scale_down_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_scale_down_get");
     private static int load_scale_down_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((Image)wrapper).GetLoadScaleDown();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_scale_down_get_delegate efl_gfx_image_load_controller_load_scale_down_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_scale_down_set_delegate(System.IntPtr obj, System.IntPtr pd,   int div);


     public delegate void efl_gfx_image_load_controller_load_scale_down_set_api_delegate(System.IntPtr obj,   int div);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate> efl_gfx_image_load_controller_load_scale_down_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_scale_down_set");
     private static void load_scale_down_set(System.IntPtr obj, System.IntPtr pd,  int div)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetLoadScaleDown( div);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  div);
        }
    }
    private static efl_gfx_image_load_controller_load_scale_down_set_delegate efl_gfx_image_load_controller_load_scale_down_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_image_load_controller_load_skip_header_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_image_load_controller_load_skip_header_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate> efl_gfx_image_load_controller_load_skip_header_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate>(_Module, "efl_gfx_image_load_controller_load_skip_header_get");
     private static bool load_skip_header_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetLoadSkipHeader();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_skip_header_get_delegate efl_gfx_image_load_controller_load_skip_header_get_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_skip_header_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool skip);


     public delegate void efl_gfx_image_load_controller_load_skip_header_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool skip);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate> efl_gfx_image_load_controller_load_skip_header_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate>(_Module, "efl_gfx_image_load_controller_load_skip_header_set");
     private static void load_skip_header_set(System.IntPtr obj, System.IntPtr pd,  bool skip)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetLoadSkipHeader( skip);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  skip);
        }
    }
    private static efl_gfx_image_load_controller_load_skip_header_set_delegate efl_gfx_image_load_controller_load_skip_header_set_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_async_start_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_gfx_image_load_controller_load_async_start_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate> efl_gfx_image_load_controller_load_async_start_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate>(_Module, "efl_gfx_image_load_controller_load_async_start");
     private static void load_async_start(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_start was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).LoadAsyncStart();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_async_start_delegate efl_gfx_image_load_controller_load_async_start_static_delegate;


     private delegate void efl_gfx_image_load_controller_load_async_cancel_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_gfx_image_load_controller_load_async_cancel_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate> efl_gfx_image_load_controller_load_async_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate>(_Module, "efl_gfx_image_load_controller_load_async_cancel");
     private static void load_async_cancel(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_cancel was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).LoadAsyncCancel();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate> efl_gfx_view_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate>(_Module, "efl_gfx_view_size_get");
     private static Eina.Size2D.NativeStruct view_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_view_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).GetViewSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_view_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;


     private delegate void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct size);


     public delegate void efl_gfx_view_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct size);
     public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate> efl_gfx_view_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate>(_Module, "efl_gfx_view_size_set");
     private static void view_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size)
    {
        Eina.Log.Debug("function efl_gfx_view_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_size = size;
                            
            try {
                ((Image)wrapper).SetViewSize( _in_size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_view_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_calc_auto_update_hints_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_calc_auto_update_hints_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate> efl_layout_calc_auto_update_hints_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate>(_Module, "efl_layout_calc_auto_update_hints_get");
     private static bool calc_auto_update_hints_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_calc_auto_update_hints_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetCalcAutoUpdateHints();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_calc_auto_update_hints_get_delegate efl_layout_calc_auto_update_hints_get_static_delegate;


     private delegate void efl_layout_calc_auto_update_hints_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool update);


     public delegate void efl_layout_calc_auto_update_hints_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool update);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate> efl_layout_calc_auto_update_hints_set_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate>(_Module, "efl_layout_calc_auto_update_hints_set");
     private static void calc_auto_update_hints_set(System.IntPtr obj, System.IntPtr pd,  bool update)
    {
        Eina.Log.Debug("function efl_layout_calc_auto_update_hints_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetCalcAutoUpdateHints( update);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  update);
        }
    }
    private static efl_layout_calc_auto_update_hints_set_delegate efl_layout_calc_auto_update_hints_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct restricted);


     public delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct restricted);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate> efl_layout_calc_size_min_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate>(_Module, "efl_layout_calc_size_min");
     private static Eina.Size2D.NativeStruct calc_size_min(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct restricted)
    {
        Eina.Log.Debug("function efl_layout_calc_size_min was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_restricted = restricted;
                            Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).CalcSizeMin( _in_restricted);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_layout_calc_size_min_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  restricted);
        }
    }
    private static efl_layout_calc_size_min_delegate efl_layout_calc_size_min_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate> efl_layout_calc_parts_extends_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate>(_Module, "efl_layout_calc_parts_extends");
     private static Eina.Rect.NativeStruct calc_parts_extends(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_calc_parts_extends was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((Image)wrapper).CalcPartsExtends();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_calc_parts_extends_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_calc_parts_extends_delegate efl_layout_calc_parts_extends_static_delegate;


     private delegate int efl_layout_calc_freeze_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_layout_calc_freeze_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate> efl_layout_calc_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate>(_Module, "efl_layout_calc_freeze");
     private static int calc_freeze(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_calc_freeze was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((Image)wrapper).FreezeCalc();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_calc_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_calc_freeze_delegate efl_layout_calc_freeze_static_delegate;


     private delegate int efl_layout_calc_thaw_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_layout_calc_thaw_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate> efl_layout_calc_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate>(_Module, "efl_layout_calc_thaw");
     private static int calc_thaw(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_calc_thaw was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((Image)wrapper).ThawCalc();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_calc_thaw_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_calc_thaw_delegate efl_layout_calc_thaw_static_delegate;


     private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate>(_Module, "efl_layout_calc_force");
     private static void calc_force(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_calc_force was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Image)wrapper).CalcForce();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_layout_calc_force_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate> efl_layout_group_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate>(_Module, "efl_layout_group_size_min_get");
     private static Eina.Size2D.NativeStruct group_size_min_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_group_size_min_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).GetGroupSizeMin();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_group_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate> efl_layout_group_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate>(_Module, "efl_layout_group_size_max_get");
     private static Eina.Size2D.NativeStruct group_size_max_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_layout_group_size_max_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Image)wrapper).GetGroupSizeMax();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_layout_group_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_layout_group_data_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key);
     public static Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate> efl_layout_group_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate>(_Module, "efl_layout_group_data_get");
     private static System.String group_data_get(System.IntPtr obj, System.IntPtr pd,  System.String key)
    {
        Eina.Log.Debug("function efl_layout_group_data_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Image)wrapper).GetGroupData( key);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_layout_group_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
        }
    }
    private static efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_group_part_exist_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);
     public static Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate> efl_layout_group_part_exist_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate>(_Module, "efl_layout_group_part_exist_get");
     private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd,  System.String part)
    {
        Eina.Log.Debug("function efl_layout_group_part_exist_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetPartExist( part);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_layout_group_part_exist_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  part);
        }
    }
    private static efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;


     private delegate void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,   int id,   Eina.ValueNative msg);


     public delegate void efl_layout_signal_message_send_api_delegate(System.IntPtr obj,   int id,   Eina.ValueNative msg);
     public static Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate> efl_layout_signal_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate>(_Module, "efl_layout_signal_message_send");
     private static void message_send(System.IntPtr obj, System.IntPtr pd,  int id,  Eina.ValueNative msg)
    {
        Eina.Log.Debug("function efl_layout_signal_message_send was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Image)wrapper).MessageSend( id,  msg);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_layout_signal_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id,  msg);
        }
    }
    private static efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_signal_callback_add_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);
     public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate> efl_layout_signal_callback_add_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate>(_Module, "efl_layout_signal_callback_add");
     private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd,  System.String emission,  System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
    {
        Eina.Log.Debug("function efl_layout_signal_callback_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                        EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).AddSignalCallback( emission,  source,  func_wrapper.ManagedCb);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_layout_signal_callback_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source, func_data, func, func_free_cb);
        }
    }
    private static efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_layout_signal_callback_del_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);
     public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate> efl_layout_signal_callback_del_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate>(_Module, "efl_layout_signal_callback_del");
     private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd,  System.String emission,  System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
    {
        Eina.Log.Debug("function efl_layout_signal_callback_del was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                        EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).DelSignalCallback( emission,  source,  func_wrapper.ManagedCb);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        return _ret_var;
        } else {
            return efl_layout_signal_callback_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source, func_data, func, func_free_cb);
        }
    }
    private static efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;


     private delegate void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source);


     public delegate void efl_layout_signal_emit_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String emission,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String source);
     public static Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate> efl_layout_signal_emit_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate>(_Module, "efl_layout_signal_emit");
     private static void signal_emit(System.IntPtr obj, System.IntPtr pd,  System.String emission,  System.String source)
    {
        Eina.Log.Debug("function efl_layout_signal_emit was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Image)wrapper).EmitSignal( emission,  source);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_layout_signal_emit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  emission,  source);
        }
    }
    private static efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;


     private delegate void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool recurse);


     public delegate void efl_layout_signal_process_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool recurse);
     public static Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate> efl_layout_signal_process_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate>(_Module, "efl_layout_signal_process");
     private static void signal_process(System.IntPtr obj, System.IntPtr pd,  bool recurse)
    {
        Eina.Log.Debug("function efl_layout_signal_process was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SignalProcess( recurse);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_layout_signal_process_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  recurse);
        }
    }
    private static efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_draggable_drag_target_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_draggable_drag_target_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate> efl_ui_draggable_drag_target_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate>(_Module, "efl_ui_draggable_drag_target_get");
     private static bool drag_target_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_draggable_drag_target_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Image)wrapper).GetDragTarget();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_draggable_drag_target_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_draggable_drag_target_get_delegate efl_ui_draggable_drag_target_get_static_delegate;


     private delegate void efl_ui_draggable_drag_target_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool set);


     public delegate void efl_ui_draggable_drag_target_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool set);
     public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate> efl_ui_draggable_drag_target_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate>(_Module, "efl_ui_draggable_drag_target_set");
     private static void drag_target_set(System.IntPtr obj, System.IntPtr pd,  bool set)
    {
        Eina.Log.Debug("function efl_ui_draggable_drag_target_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Image)wrapper).SetDragTarget( set);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_draggable_drag_target_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  set);
        }
    }
    private static efl_ui_draggable_drag_target_set_delegate efl_ui_draggable_drag_target_set_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary>Structure associated with smart callback &apos;download,progress&apos;.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ImageProgress
{
    /// <summary>Current percentage</summary>
    public double Now;
    /// <summary>Total percentage</summary>
    public double Total;
    ///<summary>Constructor for ImageProgress.</summary>
    public ImageProgress(
        double Now=default(double),
        double Total=default(double)    )
    {
        this.Now = Now;
        this.Total = Total;
    }

    public static implicit operator ImageProgress(IntPtr ptr)
    {
        var tmp = (ImageProgress.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ImageProgress.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct ImageProgress.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Now;
        
        public double Total;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ImageProgress.NativeStruct(ImageProgress _external_struct)
        {
            var _internal_struct = new ImageProgress.NativeStruct();
            _internal_struct.Now = _external_struct.Now;
            _internal_struct.Total = _external_struct.Total;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ImageProgress(ImageProgress.NativeStruct _internal_struct)
        {
            var _external_struct = new ImageProgress();
            _external_struct.Now = _internal_struct.Now;
            _external_struct.Total = _internal_struct.Total;
            return _external_struct;
        }

    }

}

} } 
namespace Efl { namespace Ui { 
/// <summary>Structure associated with smart callback &apos;download,progress&apos;.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ImageError
{
    /// <summary>Error status of the download</summary>
    public int Status;
    /// <summary><c>true</c> if the error happened when opening the file, <c>false</c> otherwise</summary>
    public bool Open_error;
    ///<summary>Constructor for ImageError.</summary>
    public ImageError(
        int Status=default(int),
        bool Open_error=default(bool)    )
    {
        this.Status = Status;
        this.Open_error = Open_error;
    }

    public static implicit operator ImageError(IntPtr ptr)
    {
        var tmp = (ImageError.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ImageError.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct ImageError.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Status;
        ///<summary>Internal wrapper for field Open_error</summary>
        public System.Byte Open_error;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ImageError.NativeStruct(ImageError _external_struct)
        {
            var _internal_struct = new ImageError.NativeStruct();
            _internal_struct.Status = _external_struct.Status;
            _internal_struct.Open_error = _external_struct.Open_error ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ImageError(ImageError.NativeStruct _internal_struct)
        {
            var _external_struct = new ImageError();
            _external_struct.Status = _internal_struct.Status;
            _external_struct.Open_error = _internal_struct.Open_error != 0;
            return _external_struct;
        }

    }

}

} } 
