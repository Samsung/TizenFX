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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Image.DropEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ImageDropEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when drop from drag and drop happened</value>
    public System.String arg { get; set; }
}
/// <summary>Efl UI image class
/// When loading images from a file, the <see cref="Efl.IFile.Key"/> property can be used to access different streams. For example, when accessing Evas image caches.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Image.NativeMethods]
[Efl.Eo.BindingEntity]
public class Image : Efl.Ui.Widget, Efl.IFile, Efl.IPlayer, Efl.Gfx.IArrangement, Efl.Gfx.IImage, Efl.Gfx.IImageLoadController, Efl.Gfx.IImageOrientable, Efl.Gfx.IView, Efl.Input.IClickable, Efl.Layout.ICalc, Efl.Layout.IGroup, Efl.Layout.ISignal, Efl.Ui.IDraggable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Image))
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
        efl_ui_image_class_get();
    /// <summary>Initializes a new instance of the <see cref="Image"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Image(Efl.Object parent
            , System.String style = null) : base(efl_ui_image_class_get(), parent)
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
    protected Image(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Image"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Image(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Image"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Image(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when drop from drag and drop happened</summary>
    /// <value><see cref="Efl.Ui.ImageDropEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ImageDropEvt_Args> DropEvt
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
                        Efl.Ui.ImageDropEvt_Args args = new Efl.Ui.ImageDropEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
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

                string key = "_EFL_UI_IMAGE_EVENT_DROP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_IMAGE_EVENT_DROP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DropEvt.</summary>
    public void OnDropEvt(Efl.Ui.ImageDropEvt_Args e)
    {
        var key = "_EFL_UI_IMAGE_EVENT_DROP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Image data has been preloaded.</summary>
    public event EventHandler ImagePreloadEvt
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

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImagePreloadEvt.</summary>
    public void OnImagePreloadEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Image was resized (its pixel data).</summary>
    public event EventHandler ImageResizeEvt
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

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageResizeEvt.</summary>
    public void OnImageResizeEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
    public event EventHandler ImageUnloadEvt
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

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageUnloadEvt.</summary>
    public void OnImageUnloadEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when he image was loaded</summary>
    public event EventHandler LoadDoneEvt
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

                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LoadDoneEvt.</summary>
    public void OnLoadDoneEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when an error happened during image loading</summary>
    /// <value><see cref="Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args"/></value>
    public event EventHandler<Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args> LoadErrorEvt
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
                        Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args args = new Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args();
                        args.arg = (Eina.Error)Marshal.PtrToStructure(evt.Info, typeof(Eina.Error));
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

                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LoadErrorEvt.</summary>
    public void OnLoadErrorEvt(Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc((int)e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when object is in sequence pressed and unpressed, by the primary button</summary>
    /// <value><see cref="Efl.Input.IClickableClickedEvt_Args"/></value>
    public event EventHandler<Efl.Input.IClickableClickedEvt_Args> ClickedEvt
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
                        Efl.Input.IClickableClickedEvt_Args args = new Efl.Input.IClickableClickedEvt_Args();
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

                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(Efl.Input.IClickableClickedEvt_Args e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED";
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
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <value><see cref="Efl.Input.IClickableClickedAnyEvt_Args"/></value>
    public event EventHandler<Efl.Input.IClickableClickedAnyEvt_Args> ClickedAnyEvt
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
                        Efl.Input.IClickableClickedAnyEvt_Args args = new Efl.Input.IClickableClickedAnyEvt_Args();
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

                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedAnyEvt.</summary>
    public void OnClickedAnyEvt(Efl.Input.IClickableClickedAnyEvt_Args e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED_ANY";
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
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.IClickablePressedEvt_Args"/></value>
    public event EventHandler<Efl.Input.IClickablePressedEvt_Args> PressedEvt
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
                        Efl.Input.IClickablePressedEvt_Args args = new Efl.Input.IClickablePressedEvt_Args();
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

                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Input.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_INPUT_EVENT_PRESSED";
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
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.IClickableUnpressedEvt_Args"/></value>
    public event EventHandler<Efl.Input.IClickableUnpressedEvt_Args> UnpressedEvt
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
                        Efl.Input.IClickableUnpressedEvt_Args args = new Efl.Input.IClickableUnpressedEvt_Args();
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

                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Input.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_INPUT_EVENT_UNPRESSED";
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
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.IClickableLongpressedEvt_Args"/></value>
    public event EventHandler<Efl.Input.IClickableLongpressedEvt_Args> LongpressedEvt
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
                        Efl.Input.IClickableLongpressedEvt_Args args = new Efl.Input.IClickableLongpressedEvt_Args();
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

                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Input.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_INPUT_EVENT_LONGPRESSED";
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
    /// <summary>The layout was recalculated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler RecalcEvt
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

                string key = "_EFL_LAYOUT_EVENT_RECALC";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RecalcEvt.</summary>
    public void OnRecalcEvt(EventArgs e)
    {
        var key = "_EFL_LAYOUT_EVENT_RECALC";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>A circular dependency between parts of the object was found.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Layout.ICalcCircularDependencyEvt_Args"/></value>
    public event EventHandler<Efl.Layout.ICalcCircularDependencyEvt_Args> CircularDependencyEvt
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
                        Efl.Layout.ICalcCircularDependencyEvt_Args args = new Efl.Layout.ICalcCircularDependencyEvt_Args();
                        args.arg = new Eina.Array<System.String>(evt.Info, false, false);
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

                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event CircularDependencyEvt.</summary>
    public void OnCircularDependencyEvt(Efl.Layout.ICalcCircularDependencyEvt_Args e)
    {
        var key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.Handle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag operation starts</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragEvt_Args> DragEvt
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
                        Efl.Ui.IDraggableDragEvt_Args args = new Efl.Ui.IDraggableDragEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragEvt.</summary>
    public void OnDragEvt(Efl.Ui.IDraggableDragEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag started</summary>
    public event EventHandler DragStartEvt
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

                string key = "_EFL_UI_EVENT_DRAG_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStartEvt.</summary>
    public void OnDragStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when drag stopped</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragStopEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragStopEvt_Args> DragStopEvt
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
                        Efl.Ui.IDraggableDragStopEvt_Args args = new Efl.Ui.IDraggableDragStopEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStopEvt.</summary>
    public void OnDragStopEvt(Efl.Ui.IDraggableDragStopEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag operation ends</summary>
    public event EventHandler DragEndEvt
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

                string key = "_EFL_UI_EVENT_DRAG_END";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_END";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragEndEvt.</summary>
    public void OnDragEndEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_DRAG_END";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when drag starts into up direction</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragStartUpEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragStartUpEvt_Args> DragStartUpEvt
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
                        Efl.Ui.IDraggableDragStartUpEvt_Args args = new Efl.Ui.IDraggableDragStartUpEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStartUpEvt.</summary>
    public void OnDragStartUpEvt(Efl.Ui.IDraggableDragStartUpEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into down direction</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragStartDownEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragStartDownEvt_Args> DragStartDownEvt
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
                        Efl.Ui.IDraggableDragStartDownEvt_Args args = new Efl.Ui.IDraggableDragStartDownEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStartDownEvt.</summary>
    public void OnDragStartDownEvt(Efl.Ui.IDraggableDragStartDownEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into right direction</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragStartRightEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragStartRightEvt_Args> DragStartRightEvt
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
                        Efl.Ui.IDraggableDragStartRightEvt_Args args = new Efl.Ui.IDraggableDragStartRightEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStartRightEvt.</summary>
    public void OnDragStartRightEvt(Efl.Ui.IDraggableDragStartRightEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when drag starts into left direction</summary>
    /// <value><see cref="Efl.Ui.IDraggableDragStartLeftEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IDraggableDragStartLeftEvt_Args> DragStartLeftEvt
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
                        Efl.Ui.IDraggableDragStartLeftEvt_Args args = new Efl.Ui.IDraggableDragStartLeftEvt_Args();
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

                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_DRAG_START_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DragStartLeftEvt.</summary>
    public void OnDragStartLeftEvt(Efl.Ui.IDraggableDragStartLeftEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_DRAG_START_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Get the icon name of image set by icon standard names.
    /// If the image was set using efl_file_set() instead of <see cref="Efl.Ui.Image.SetIcon"/>, then this function will return null.</summary>
    /// <returns>The icon name</returns>
    virtual public System.String GetIcon() {
         var _ret_var = Efl.Ui.Image.NativeMethods.efl_ui_image_icon_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public bool SetIcon(System.String name) {
                                 var _ret_var = Efl.Ui.Image.NativeMethods.efl_ui_image_icon_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    virtual public Eina.File GetMmap() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    virtual public System.String GetFile() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
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
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    virtual public void SetKey(System.String key) {
                                 Efl.IFileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    virtual public bool GetLoaded() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    virtual public void Unload() {
         Efl.IFileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Whether or not the playable can be played.</summary>
    /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
    virtual public bool GetPlayable() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_playable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get play/pause state of the media file.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    virtual public bool GetPlay() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_play_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set play/pause state of the media file.
    /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
    virtual public void SetPlay(bool play) {
                                 Efl.IPlayerConcrete.NativeMethods.efl_player_play_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the position in the media file.
    /// The position is returned as the number of seconds since the beginning of the media file.</summary>
    /// <returns>The position (in seconds).</returns>
    virtual public double GetPos() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the position in the media file.
    /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    virtual public void SetPos(double sec) {
                                 Efl.IPlayerConcrete.NativeMethods.efl_player_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get how much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    virtual public double GetProgress() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    virtual public double GetPlaySpeed() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_play_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    virtual public void SetPlaySpeed(double speed) {
                                 Efl.IPlayerConcrete.NativeMethods.efl_player_play_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),speed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    virtual public double GetVolume() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_volume_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    virtual public void SetVolume(double volume) {
                                 Efl.IPlayerConcrete.NativeMethods.efl_player_volume_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),volume);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    virtual public bool GetMute() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_mute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    virtual public void SetMute(bool mute) {
                                 Efl.IPlayerConcrete.NativeMethods.efl_player_mute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mute);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    virtual public double GetLength() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    virtual public bool GetSeekable() {
         var _ret_var = Efl.IPlayerConcrete.NativeMethods.efl_player_seekable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a playing playable object.</summary>
    virtual public void Start() {
         Efl.IPlayerConcrete.NativeMethods.efl_player_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop playable object.</summary>
    virtual public void Stop() {
         Efl.IPlayerConcrete.NativeMethods.efl_player_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    virtual public void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    virtual public void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.IArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
    /// 
    /// <c>true</c> by default</summary>
    /// <returns>Whether to use smooth scale or not.</returns>
    virtual public bool GetSmoothScale() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
    /// 
    /// <c>true</c> by default</summary>
    /// <param name="smooth_scale">Whether to use smooth scale or not.</param>
    virtual public void SetSmoothScale(bool smooth_scale) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),smooth_scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control how the image is scaled.</summary>
    /// <returns>Image scale type</returns>
    virtual public Efl.Gfx.ImageScaleType GetScaleType() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_scale_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control how the image is scaled.</summary>
    /// <param name="scale_type">Image scale type</param>
    virtual public void SetScaleType(Efl.Gfx.ImageScaleType scale_type) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_scale_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size. This is set to <c>true</c> by default.</summary>
    /// <returns>Allow image upscaling</returns>
    virtual public bool GetCanUpscale() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_can_upscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size. This is set to <c>true</c> by default.</summary>
    /// <param name="upscale">Allow image upscaling</param>
    virtual public void SetCanUpscale(bool upscale) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_can_upscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),upscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size. This is set to <c>true</c> by default.</summary>
    /// <returns>Allow image downscaling</returns>
    virtual public bool GetCanDownscale() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_can_downscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size. This is set to <c>true</c> by default.</summary>
    /// <param name="downscale">Allow image downscaling</param>
    virtual public void SetCanDownscale(bool downscale) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_can_downscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),downscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns 1.0 if not applicable (eg. height = 0).</summary>
    /// <returns>The image&apos;s ratio.</returns>
    virtual public double GetRatio() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non strechable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <returns>A rectangle inside the object boundary that where content is expected.</returns>
    virtual public Eina.Rect GetContentRegion() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_content_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public void GetBorder(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
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
    virtual public void SetBorder(int l, int r, int t, int b) {
                                                                                                         Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l, r, t, b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
    /// 
    /// Default value is 1.0 (no scaling).</summary>
    /// <returns>The scale factor.</returns>
    virtual public double GetBorderScale() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
    /// 
    /// Default value is 1.0 (no scaling).</summary>
    /// <param name="scale">The scale factor.</param>
    virtual public void SetBorderScale(double scale) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
    /// 
    /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
    /// <returns>Fill mode of the center region.</returns>
    virtual public Efl.Gfx.BorderFillMode GetBorderCenterFill() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_center_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
    /// 
    /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
    /// <param name="fill">Fill mode of the center region.</param>
    virtual public void SetBorderCenterFill(Efl.Gfx.BorderFillMode fill) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_border_center_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.BorderCenterFill"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of area that are stretchable in the image horizontal space.</param>
    /// <param name="vertical">Representation of area that are stretchable in the image vertical space.</param>
    virtual public void GetStretchRegion(out Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, out Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
                         System.IntPtr _out_horizontal = System.IntPtr.Zero;
        System.IntPtr _out_vertical = System.IntPtr.Zero;
                        Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_stretch_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_horizontal, out _out_vertical);
        Eina.Error.RaiseIfUnhandledException();
        horizontal = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_horizontal, false);
        vertical = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_vertical, false);
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.BorderCenterFill"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of area that are stretchable in the image horizontal space.</param>
    /// <param name="vertical">Representation of area that are stretchable in the image vertical space.</param>
    /// <returns>return an error code if the stretch_region provided are incorrect.</returns>
    virtual public Eina.Error SetStretchRegion(Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
         var _in_horizontal = horizontal.Handle;
        var _in_vertical = vertical.Handle;
                                        var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_stretch_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_horizontal, _in_vertical);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>This represents the size of the original image in pixels.
    /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
    /// 
    /// This is a read-only property, and may return 0x0.</summary>
    /// <returns>The size in pixels.</returns>
    virtual public Eina.Size2D GetImageSize() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the content hint setting of a given image object of the canvas.
    /// This returns #EVAS_IMAGE_CONTENT_HINT_NONE on error.</summary>
    /// <returns>Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></returns>
    virtual public Efl.Gfx.ImageContentHint GetContentHint() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_content_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the content hint setting of a given image object of the canvas.
    /// This function sets the content hint value of the given image of the canvas. For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to #EVAS_IMAGE_CONTENT_HINT_DYNAMIC will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <param name="hint">Dynamic or static content hint, see <see cref="Efl.Gfx.ImageContentHint"/></param>
    virtual public void SetContentHint(Efl.Gfx.ImageContentHint hint) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_content_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the scale hint of a given image of the canvas.
    /// This function returns the scale hint value of the given image object of the canvas.</summary>
    /// <returns>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></returns>
    virtual public Efl.Gfx.ImageScaleHint GetScaleHint() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the scale hint of a given image of the canvas.
    /// This function sets the scale hint value of the given image object in the canvas, which will affect how Evas is to cache scaled versions of its original source image.</summary>
    /// <param name="hint">Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></param>
    virtual public void SetScaleHint(Efl.Gfx.ImageScaleHint hint) {
                                 Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the (last) file loading error for a given object.</summary>
    /// <returns>The load error code.</returns>
    virtual public Eina.Error GetImageLoadError() {
         var _ret_var = Efl.Gfx.IImageConcrete.NativeMethods.efl_gfx_image_load_error_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns the requested load size.</summary>
    /// <returns>The image load size.</returns>
    virtual public Eina.Size2D GetLoadSize() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the canvas to load the image at the given size.
    /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
    /// <param name="size">The image load size.</param>
    virtual public void SetLoadSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <returns>The DPI resolution.</returns>
    virtual public double GetLoadDpi() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the DPI resolution of an image object&apos;s source image.
    /// This function sets the DPI resolution of a given loaded canvas image. Most useful for the SVG image loader.</summary>
    /// <param name="dpi">The DPI resolution.</param>
    virtual public void SetLoadDpi(double dpi) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dpi);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise</returns>
    virtual public bool GetLoadRegionSupport() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieve the coordinates of a given image object&apos;s selective (source image) load region.</summary>
    /// <returns>A region of the image.</returns>
    virtual public Eina.Rect GetLoadRegion() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This function is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work.</summary>
    /// <param name="region">A region of the image.</param>
    virtual public void SetLoadRegion(Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_region);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <returns><c>true</c> means that it should honor the orientation information.</returns>
    virtual public bool GetLoadOrientation() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
    virtual public void SetLoadOrientation(bool enable) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
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
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
    /// <param name="div">The scale down dividing factor.</param>
    virtual public void SetLoadScaleDown(int div) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),div);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <returns>Will be true if header is to be skipped.</returns>
    virtual public bool GetLoadSkipHeader() {
         var _ret_var = Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the skip header state for susbsequent loads of a file.</summary>
    /// <param name="skip">Will be true if header is to be skipped.</param>
    virtual public void SetLoadSkipHeader(bool skip) {
                                 Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),skip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Begin preloading an image object&apos;s image data in the background.
    /// Once the background task is complete the event <c>load</c>,done will be emitted.</summary>
    virtual public void LoadAsyncStart() {
         Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Cancel preloading an image object&apos;s image data in the background.
    /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
    virtual public void LoadAsyncCancel() {
         Efl.Gfx.IImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <returns>The final orientation of the object.</returns>
    virtual public Efl.Gfx.ImageOrientation GetImageOrientation() {
         var _ret_var = Efl.Gfx.IImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <param name="dir">The final orientation of the object.</param>
    virtual public void SetImageOrientation(Efl.Gfx.ImageOrientation dir) {
                                 Efl.Gfx.IImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
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
         var _ret_var = Efl.Gfx.IViewConcrete.NativeMethods.efl_gfx_view_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public void SetViewSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IViewConcrete.NativeMethods.efl_gfx_view_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    virtual public bool GetInteraction() {
         var _ret_var = Efl.Input.IClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Press(uint button) {
                                 Efl.Input.IClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Unpress(uint button) {
                                 Efl.Input.IClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress. And set the state of the clickable mixin back into the unpressed state.</summary>
    virtual public void ResetButtonState(uint button) {
                                 Efl.Input.IClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    virtual public void LongpressAbort(uint button) {
                                 Efl.Input.IClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether this object updates its size hints automatically.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether or not update the size hints.</returns>
    virtual public bool GetCalcAutoUpdateHints() {
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable auto-update of size hints.
    /// (Since EFL 1.22)</summary>
    /// <param name="update">Whether or not update the size hints.</param>
    virtual public void SetCalcAutoUpdateHints(bool update) {
                                 Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),update);
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
    virtual public Eina.Size2D CalcSizeMin(Eina.Size2D restricted) {
         Eina.Size2D.NativeStruct _in_restricted = restricted;
                        var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_restricted);
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
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Forces a Size/Geometry calculation.
    /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    virtual public void CalcForce() {
         Efl.Layout.ICalcConcrete.NativeMethods.efl_layout_calc_force_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.Layout.IGroupConcrete.NativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.Layout.IGroupConcrete.NativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public System.String GetGroupData(System.String key) {
                                 var _ret_var = Efl.Layout.IGroupConcrete.NativeMethods.efl_layout_group_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns <c>true</c> if the part exists in the EDC group.
    /// (Since EFL 1.22)</summary>
    /// <param name="part">The part name to check.</param>
    /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
    virtual public bool GetPartExist(System.String part) {
                                 var _ret_var = Efl.Layout.IGroupConcrete.NativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),part);
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
    virtual public void MessageSend(int id, Eina.Value msg) {
                                                         Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id, msg);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
    /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
    /// 
    /// Signals can go both ways, from code to theme, or theme to code.
    /// 
    /// Though there are those common uses for the two strings, one is free to use them however they like.
    /// 
    /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[" set of <c>fnmatch</c>() operators can be used, both for emission and source.
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
    virtual public bool AddSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
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
    virtual public bool DelSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
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
    virtual public void EmitSignal(System.String emission, System.String source) {
                                                         Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_emit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Processes an object&apos;s messages and signals queue.
    /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
    /// 
    /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
    /// (Since EFL 1.22)</summary>
    /// <param name="recurse">Whether to process messages on children objects.</param>
    virtual public void SignalProcess(bool recurse) {
                                 Efl.Layout.ISignalConcrete.NativeMethods.efl_layout_signal_process_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),recurse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <returns>Turn on or off drop_target. Default is <c>false</c>.</returns>
    virtual public bool GetDragTarget() {
         var _ret_var = Efl.Ui.IDraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <param name="set">Turn on or off drop_target. Default is <c>false</c>.</param>
    virtual public void SetDragTarget(bool set) {
                                 Efl.Ui.IDraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the icon name of image set by icon standard names.
    /// If the image was set using efl_file_set() instead of <see cref="Efl.Ui.Image.SetIcon"/>, then this function will return null.</summary>
    /// <value>The icon name</value>
    public System.String Icon {
        get { return GetIcon(); }
        set { SetIcon(value); }
    }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
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
        set { SetPlay(value); }
    }
    /// <summary>Get the position in the media file.
    /// The position is returned as the number of seconds since the beginning of the media file.</summary>
    /// <value>The position (in seconds).</value>
    public double Pos {
        get { return GetPos(); }
        set { SetPos(value); }
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
        set { SetPlaySpeed(value); }
    }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <value>The volume level</value>
    public double Volume {
        get { return GetVolume(); }
        set { SetVolume(value); }
    }
    /// <summary>This property controls the audio mute state.</summary>
    /// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    public bool Mute {
        get { return GetMute(); }
        set { SetMute(value); }
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
    /// <summary>Alignment of the container within its bounds</summary>
    /// <value>Horizontal alignment</value>
    public (double, double) ContentAlign {
        get {
            double _out_align_horiz = default(double);
            double _out_align_vert = default(double);
            GetContentAlign(out _out_align_horiz,out _out_align_vert);
            return (_out_align_horiz,_out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }
    /// <summary>Padding between items contained in this object.</summary>
    /// <value>Horizontal padding</value>
    public (double, double, bool) ContentPadding {
        get {
            double _out_pad_horiz = default(double);
            double _out_pad_vert = default(double);
            bool _out_scalable = default(bool);
            GetContentPadding(out _out_pad_horiz,out _out_pad_vert,out _out_scalable);
            return (_out_pad_horiz,_out_pad_vert,_out_scalable);
        }
        set { SetContentPadding( value.Item1,  value.Item2,  value.Item3); }
    }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.
    /// 
    /// <c>true</c> by default</summary>
    /// <value>Whether to use smooth scale or not.</value>
    public bool SmoothScale {
        get { return GetSmoothScale(); }
        set { SetSmoothScale(value); }
    }
    /// <summary>Control how the image is scaled.</summary>
    /// <value>Image scale type</value>
    public Efl.Gfx.ImageScaleType ScaleType {
        get { return GetScaleType(); }
        set { SetScaleType(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size. This is set to <c>true</c> by default.</summary>
    /// <value>Allow image upscaling</value>
    public bool CanUpscale {
        get { return GetCanUpscale(); }
        set { SetCanUpscale(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size. This is set to <c>true</c> by default.</summary>
    /// <value>Allow image downscaling</value>
    public bool CanDownscale {
        get { return GetCanDownscale(); }
        set { SetCanDownscale(value); }
    }
    /// <summary>The native width/height ratio of the image.</summary>
    /// <value>The image&apos;s ratio.</value>
    public double Ratio {
        get { return GetRatio(); }
    }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non strechable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <value>A rectangle inside the object boundary that where content is expected.</value>
    public Eina.Rect ContentRegion {
        get { return GetContentRegion(); }
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
    /// <value>The border&apos;s left width.</value>
    public (int, int, int, int) Border {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetBorder(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
        set { SetBorder( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.
    /// 
    /// Default value is 1.0 (no scaling).</summary>
    /// <value>The scale factor.</value>
    public double BorderScale {
        get { return GetBorderScale(); }
        set { SetBorderScale(value); }
    }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.BorderFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.
    /// 
    /// The default value is <see cref="Efl.Gfx.BorderFillMode.Default"/>, ie. render and scale the center area, respecting its transparency.</summary>
    /// <value>Fill mode of the center region.</value>
    public Efl.Gfx.BorderFillMode BorderCenterFill {
        get { return GetBorderCenterFill(); }
        set { SetBorderCenterFill(value); }
    }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.BorderCenterFill"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <value>Representation of area that are stretchable in the image horizontal space.</value>
    public (Eina.Iterator<Efl.Gfx.ImageStretchRegion>, Eina.Iterator<Efl.Gfx.ImageStretchRegion>) StretchRegion {
        get {
            Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_horizontal = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
            Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_vertical = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
            GetStretchRegion(out _out_horizontal,out _out_vertical);
            return (_out_horizontal,_out_vertical);
        }
        set { SetStretchRegion( value.Item1,  value.Item2); }
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
        set { SetContentHint(value); }
    }
    /// <summary>Get the scale hint of a given image of the canvas.
    /// This function returns the scale hint value of the given image object of the canvas.</summary>
    /// <value>Scalable or static size hint, see <see cref="Efl.Gfx.ImageScaleHint"/></value>
    public Efl.Gfx.ImageScaleHint ScaleHint {
        get { return GetScaleHint(); }
        set { SetScaleHint(value); }
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
        set { SetLoadSize(value); }
    }
    /// <summary>Get the DPI resolution of a loaded image object in the canvas.
    /// This function returns the DPI resolution of the given canvas image.</summary>
    /// <value>The DPI resolution.</value>
    public double LoadDpi {
        get { return GetLoadDpi(); }
        set { SetLoadDpi(value); }
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
        set { SetLoadRegion(value); }
    }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <value><c>true</c> means that it should honor the orientation information.</value>
    public bool LoadOrientation {
        get { return GetLoadOrientation(); }
        set { SetLoadOrientation(value); }
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
        set { SetLoadScaleDown(value); }
    }
    /// <summary>Initial load should skip header check and leave it all to data load
    /// If this is true, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <value>Will be true if header is to be skipped.</value>
    public bool LoadSkipHeader {
        get { return GetLoadSkipHeader(); }
        set { SetLoadSkipHeader(value); }
    }
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <value>The final orientation of the object.</value>
    public Efl.Gfx.ImageOrientation ImageOrientation {
        get { return GetImageOrientation(); }
        set { SetImageOrientation(value); }
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
        set { SetViewSize(value); }
    }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
    }
    /// <summary>Whether this object updates its size hints automatically.
    /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
    /// 
    /// A layout recalculation can be triggered by <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcSizeMin"/>, <see cref="Efl.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether or not update the size hints.</value>
    public bool CalcAutoUpdateHints {
        get { return GetCalcAutoUpdateHints(); }
        set { SetCalcAutoUpdateHints(value); }
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
        set { SetDragTarget(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Image.efl_ui_image_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_image_icon_get_static_delegate == null)
            {
                efl_ui_image_icon_get_static_delegate = new efl_ui_image_icon_get_delegate(icon_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_icon_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_get_static_delegate) });
            }

            if (efl_ui_image_icon_set_static_delegate == null)
            {
                efl_ui_image_icon_set_static_delegate = new efl_ui_image_icon_set_delegate(icon_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_set_static_delegate) });
            }

            if (efl_file_mmap_get_static_delegate == null)
            {
                efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate) });
            }

            if (efl_file_mmap_set_static_delegate == null)
            {
                efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate) });
            }

            if (efl_file_get_static_delegate == null)
            {
                efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate) });
            }

            if (efl_file_set_static_delegate == null)
            {
                efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate) });
            }

            if (efl_file_key_get_static_delegate == null)
            {
                efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate) });
            }

            if (efl_file_key_set_static_delegate == null)
            {
                efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate) });
            }

            if (efl_file_loaded_get_static_delegate == null)
            {
                efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoaded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate) });
            }

            if (efl_file_load_static_delegate == null)
            {
                efl_file_load_static_delegate = new efl_file_load_delegate(load);
            }

            if (methods.FirstOrDefault(m => m.Name == "Load") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate) });
            }

            if (efl_file_unload_static_delegate == null)
            {
                efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unload") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate) });
            }

            if (efl_player_playable_get_static_delegate == null)
            {
                efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlayable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate) });
            }

            if (efl_player_play_get_static_delegate == null)
            {
                efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate) });
            }

            if (efl_player_play_set_static_delegate == null)
            {
                efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate) });
            }

            if (efl_player_pos_get_static_delegate == null)
            {
                efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate) });
            }

            if (efl_player_pos_set_static_delegate == null)
            {
                efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate) });
            }

            if (efl_player_progress_get_static_delegate == null)
            {
                efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate) });
            }

            if (efl_player_play_speed_get_static_delegate == null)
            {
                efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlaySpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate) });
            }

            if (efl_player_play_speed_set_static_delegate == null)
            {
                efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPlaySpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate) });
            }

            if (efl_player_volume_get_static_delegate == null)
            {
                efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetVolume") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate) });
            }

            if (efl_player_volume_set_static_delegate == null)
            {
                efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetVolume") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate) });
            }

            if (efl_player_mute_get_static_delegate == null)
            {
                efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate) });
            }

            if (efl_player_mute_set_static_delegate == null)
            {
                efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate) });
            }

            if (efl_player_length_get_static_delegate == null)
            {
                efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate) });
            }

            if (efl_player_seekable_get_static_delegate == null)
            {
                efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeekable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate) });
            }

            if (efl_player_start_static_delegate == null)
            {
                efl_player_start_static_delegate = new efl_player_start_delegate(start);
            }

            if (methods.FirstOrDefault(m => m.Name == "Start") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate) });
            }

            if (efl_player_stop_static_delegate == null)
            {
                efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
            }

            if (methods.FirstOrDefault(m => m.Name == "Stop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate) });
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

            if (efl_gfx_image_smooth_scale_get_static_delegate == null)
            {
                efl_gfx_image_smooth_scale_get_static_delegate = new efl_gfx_image_smooth_scale_get_delegate(smooth_scale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSmoothScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_smooth_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_get_static_delegate) });
            }

            if (efl_gfx_image_smooth_scale_set_static_delegate == null)
            {
                efl_gfx_image_smooth_scale_set_static_delegate = new efl_gfx_image_smooth_scale_set_delegate(smooth_scale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSmoothScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_smooth_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_smooth_scale_set_static_delegate) });
            }

            if (efl_gfx_image_scale_type_get_static_delegate == null)
            {
                efl_gfx_image_scale_type_get_static_delegate = new efl_gfx_image_scale_type_get_delegate(scale_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScaleType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_get_static_delegate) });
            }

            if (efl_gfx_image_scale_type_set_static_delegate == null)
            {
                efl_gfx_image_scale_type_set_static_delegate = new efl_gfx_image_scale_type_set_delegate(scale_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScaleType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_type_set_static_delegate) });
            }

            if (efl_gfx_image_can_upscale_get_static_delegate == null)
            {
                efl_gfx_image_can_upscale_get_static_delegate = new efl_gfx_image_can_upscale_get_delegate(can_upscale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanUpscale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_upscale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_upscale_get_static_delegate) });
            }

            if (efl_gfx_image_can_upscale_set_static_delegate == null)
            {
                efl_gfx_image_can_upscale_set_static_delegate = new efl_gfx_image_can_upscale_set_delegate(can_upscale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanUpscale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_upscale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_upscale_set_static_delegate) });
            }

            if (efl_gfx_image_can_downscale_get_static_delegate == null)
            {
                efl_gfx_image_can_downscale_get_static_delegate = new efl_gfx_image_can_downscale_get_delegate(can_downscale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanDownscale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_downscale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_downscale_get_static_delegate) });
            }

            if (efl_gfx_image_can_downscale_set_static_delegate == null)
            {
                efl_gfx_image_can_downscale_set_static_delegate = new efl_gfx_image_can_downscale_set_delegate(can_downscale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanDownscale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_can_downscale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_can_downscale_set_static_delegate) });
            }

            if (efl_gfx_image_ratio_get_static_delegate == null)
            {
                efl_gfx_image_ratio_get_static_delegate = new efl_gfx_image_ratio_get_delegate(ratio_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRatio") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_ratio_get_static_delegate) });
            }

            if (efl_gfx_image_content_region_get_static_delegate == null)
            {
                efl_gfx_image_content_region_get_static_delegate = new efl_gfx_image_content_region_get_delegate(content_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_region_get_static_delegate) });
            }

            if (efl_gfx_image_border_get_static_delegate == null)
            {
                efl_gfx_image_border_get_static_delegate = new efl_gfx_image_border_get_delegate(border_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBorder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_get_static_delegate) });
            }

            if (efl_gfx_image_border_set_static_delegate == null)
            {
                efl_gfx_image_border_set_static_delegate = new efl_gfx_image_border_set_delegate(border_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBorder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_set_static_delegate) });
            }

            if (efl_gfx_image_border_scale_get_static_delegate == null)
            {
                efl_gfx_image_border_scale_get_static_delegate = new efl_gfx_image_border_scale_get_delegate(border_scale_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBorderScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_get_static_delegate) });
            }

            if (efl_gfx_image_border_scale_set_static_delegate == null)
            {
                efl_gfx_image_border_scale_set_static_delegate = new efl_gfx_image_border_scale_set_delegate(border_scale_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBorderScale") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_scale_set_static_delegate) });
            }

            if (efl_gfx_image_border_center_fill_get_static_delegate == null)
            {
                efl_gfx_image_border_center_fill_get_static_delegate = new efl_gfx_image_border_center_fill_get_delegate(border_center_fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBorderCenterFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_center_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_get_static_delegate) });
            }

            if (efl_gfx_image_border_center_fill_set_static_delegate == null)
            {
                efl_gfx_image_border_center_fill_set_static_delegate = new efl_gfx_image_border_center_fill_set_delegate(border_center_fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBorderCenterFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_border_center_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_border_center_fill_set_static_delegate) });
            }

            if (efl_gfx_image_stretch_region_get_static_delegate == null)
            {
                efl_gfx_image_stretch_region_get_static_delegate = new efl_gfx_image_stretch_region_get_delegate(stretch_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStretchRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_stretch_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_stretch_region_get_static_delegate) });
            }

            if (efl_gfx_image_stretch_region_set_static_delegate == null)
            {
                efl_gfx_image_stretch_region_set_static_delegate = new efl_gfx_image_stretch_region_set_delegate(stretch_region_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStretchRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_stretch_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_stretch_region_set_static_delegate) });
            }

            if (efl_gfx_image_size_get_static_delegate == null)
            {
                efl_gfx_image_size_get_static_delegate = new efl_gfx_image_size_get_delegate(image_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_size_get_static_delegate) });
            }

            if (efl_gfx_image_content_hint_get_static_delegate == null)
            {
                efl_gfx_image_content_hint_get_static_delegate = new efl_gfx_image_content_hint_get_delegate(content_hint_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_get_static_delegate) });
            }

            if (efl_gfx_image_content_hint_set_static_delegate == null)
            {
                efl_gfx_image_content_hint_set_static_delegate = new efl_gfx_image_content_hint_set_delegate(content_hint_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_content_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_content_hint_set_static_delegate) });
            }

            if (efl_gfx_image_scale_hint_get_static_delegate == null)
            {
                efl_gfx_image_scale_hint_get_static_delegate = new efl_gfx_image_scale_hint_get_delegate(scale_hint_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScaleHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_get_static_delegate) });
            }

            if (efl_gfx_image_scale_hint_set_static_delegate == null)
            {
                efl_gfx_image_scale_hint_set_static_delegate = new efl_gfx_image_scale_hint_set_delegate(scale_hint_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScaleHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_scale_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_scale_hint_set_static_delegate) });
            }

            if (efl_gfx_image_load_error_get_static_delegate == null)
            {
                efl_gfx_image_load_error_get_static_delegate = new efl_gfx_image_load_error_get_delegate(image_load_error_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageLoadError") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_error_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_error_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_size_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_get_static_delegate = new efl_gfx_image_load_controller_load_size_get_delegate(load_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_size_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_size_set_static_delegate = new efl_gfx_image_load_controller_load_size_set_delegate(load_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_size_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_get_static_delegate = new efl_gfx_image_load_controller_load_dpi_get_delegate(load_dpi_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadDpi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_dpi_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_dpi_set_static_delegate = new efl_gfx_image_load_controller_load_dpi_set_delegate(load_dpi_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadDpi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_dpi_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_dpi_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_support_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_support_get_static_delegate = new efl_gfx_image_load_controller_load_region_support_get_delegate(load_region_support_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadRegionSupport") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_support_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_support_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_get_static_delegate = new efl_gfx_image_load_controller_load_region_get_delegate(load_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_region_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_region_set_static_delegate = new efl_gfx_image_load_controller_load_region_set_delegate(load_region_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_region_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_region_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_get_static_delegate = new efl_gfx_image_load_controller_load_orientation_get_delegate(load_orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_orientation_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_orientation_set_static_delegate = new efl_gfx_image_load_controller_load_orientation_set_delegate(load_orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_orientation_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_get_static_delegate = new efl_gfx_image_load_controller_load_scale_down_get_delegate(load_scale_down_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadScaleDown") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_scale_down_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_scale_down_set_static_delegate = new efl_gfx_image_load_controller_load_scale_down_set_delegate(load_scale_down_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadScaleDown") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_scale_down_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_scale_down_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_get_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_get_static_delegate = new efl_gfx_image_load_controller_load_skip_header_get_delegate(load_skip_header_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoadSkipHeader") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_get_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_skip_header_set_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_skip_header_set_static_delegate = new efl_gfx_image_load_controller_load_skip_header_set_delegate(load_skip_header_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadSkipHeader") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_skip_header_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_skip_header_set_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_start_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_start_static_delegate = new efl_gfx_image_load_controller_load_async_start_delegate(load_async_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "LoadAsyncStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_start"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_start_static_delegate) });
            }

            if (efl_gfx_image_load_controller_load_async_cancel_static_delegate == null)
            {
                efl_gfx_image_load_controller_load_async_cancel_static_delegate = new efl_gfx_image_load_controller_load_async_cancel_delegate(load_async_cancel);
            }

            if (methods.FirstOrDefault(m => m.Name == "LoadAsyncCancel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_load_controller_load_async_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_load_controller_load_async_cancel_static_delegate) });
            }

            if (efl_gfx_image_orientation_get_static_delegate == null)
            {
                efl_gfx_image_orientation_get_static_delegate = new efl_gfx_image_orientation_get_delegate(image_orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetImageOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_get_static_delegate) });
            }

            if (efl_gfx_image_orientation_set_static_delegate == null)
            {
                efl_gfx_image_orientation_set_static_delegate = new efl_gfx_image_orientation_set_delegate(image_orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetImageOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_image_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_image_orientation_set_static_delegate) });
            }

            if (efl_gfx_view_size_get_static_delegate == null)
            {
                efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate) });
            }

            if (efl_gfx_view_size_set_static_delegate == null)
            {
                efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetViewSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate) });
            }

            if (efl_input_clickable_interaction_get_static_delegate == null)
            {
                efl_input_clickable_interaction_get_static_delegate = new efl_input_clickable_interaction_get_delegate(interaction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInteraction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_interaction_get_static_delegate) });
            }

            if (efl_input_clickable_press_static_delegate == null)
            {
                efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
            }

            if (efl_input_clickable_unpress_static_delegate == null)
            {
                efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
            }

            if (efl_input_clickable_button_state_reset_static_delegate == null)
            {
                efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
            }

            if (efl_input_clickable_longpress_abort_static_delegate == null)
            {
                efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
            }

            if (methods.FirstOrDefault(m => m.Name == "LongpressAbort") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
            }

            if (efl_layout_calc_auto_update_hints_get_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_get_static_delegate = new efl_layout_calc_auto_update_hints_get_delegate(calc_auto_update_hints_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCalcAutoUpdateHints") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_get_static_delegate) });
            }

            if (efl_layout_calc_auto_update_hints_set_static_delegate == null)
            {
                efl_layout_calc_auto_update_hints_set_static_delegate = new efl_layout_calc_auto_update_hints_set_delegate(calc_auto_update_hints_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCalcAutoUpdateHints") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_auto_update_hints_set"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_auto_update_hints_set_static_delegate) });
            }

            if (efl_layout_calc_size_min_static_delegate == null)
            {
                efl_layout_calc_size_min_static_delegate = new efl_layout_calc_size_min_delegate(calc_size_min);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_size_min"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_size_min_static_delegate) });
            }

            if (efl_layout_calc_parts_extends_static_delegate == null)
            {
                efl_layout_calc_parts_extends_static_delegate = new efl_layout_calc_parts_extends_delegate(calc_parts_extends);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcPartsExtends") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_parts_extends"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_parts_extends_static_delegate) });
            }

            if (efl_layout_calc_freeze_static_delegate == null)
            {
                efl_layout_calc_freeze_static_delegate = new efl_layout_calc_freeze_delegate(calc_freeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "FreezeCalc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_freeze_static_delegate) });
            }

            if (efl_layout_calc_thaw_static_delegate == null)
            {
                efl_layout_calc_thaw_static_delegate = new efl_layout_calc_thaw_delegate(calc_thaw);
            }

            if (methods.FirstOrDefault(m => m.Name == "ThawCalc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_thaw"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_thaw_static_delegate) });
            }

            if (efl_layout_calc_force_static_delegate == null)
            {
                efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcForce") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
            }

            if (efl_layout_group_size_min_get_static_delegate == null)
            {
                efl_layout_group_size_min_get_static_delegate = new efl_layout_group_size_min_get_delegate(group_size_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_min_get_static_delegate) });
            }

            if (efl_layout_group_size_max_get_static_delegate == null)
            {
                efl_layout_group_size_max_get_static_delegate = new efl_layout_group_size_max_get_delegate(group_size_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupSizeMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_size_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_size_max_get_static_delegate) });
            }

            if (efl_layout_group_data_get_static_delegate == null)
            {
                efl_layout_group_data_get_static_delegate = new efl_layout_group_data_get_delegate(group_data_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGroupData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_data_get_static_delegate) });
            }

            if (efl_layout_group_part_exist_get_static_delegate == null)
            {
                efl_layout_group_part_exist_get_static_delegate = new efl_layout_group_part_exist_get_delegate(part_exist_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPartExist") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_group_part_exist_get"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_group_part_exist_get_static_delegate) });
            }

            if (efl_layout_signal_message_send_static_delegate == null)
            {
                efl_layout_signal_message_send_static_delegate = new efl_layout_signal_message_send_delegate(message_send);
            }

            if (methods.FirstOrDefault(m => m.Name == "MessageSend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_message_send_static_delegate) });
            }

            if (efl_layout_signal_callback_add_static_delegate == null)
            {
                efl_layout_signal_callback_add_static_delegate = new efl_layout_signal_callback_add_delegate(signal_callback_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddSignalCallback") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_add"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_add_static_delegate) });
            }

            if (efl_layout_signal_callback_del_static_delegate == null)
            {
                efl_layout_signal_callback_del_static_delegate = new efl_layout_signal_callback_del_delegate(signal_callback_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelSignalCallback") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_callback_del"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_callback_del_static_delegate) });
            }

            if (efl_layout_signal_emit_static_delegate == null)
            {
                efl_layout_signal_emit_static_delegate = new efl_layout_signal_emit_delegate(signal_emit);
            }

            if (methods.FirstOrDefault(m => m.Name == "EmitSignal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_emit"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_emit_static_delegate) });
            }

            if (efl_layout_signal_process_static_delegate == null)
            {
                efl_layout_signal_process_static_delegate = new efl_layout_signal_process_delegate(signal_process);
            }

            if (methods.FirstOrDefault(m => m.Name == "SignalProcess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_signal_process"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_signal_process_static_delegate) });
            }

            if (efl_ui_draggable_drag_target_get_static_delegate == null)
            {
                efl_ui_draggable_drag_target_get_static_delegate = new efl_ui_draggable_drag_target_get_delegate(drag_target_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDragTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_draggable_drag_target_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_get_static_delegate) });
            }

            if (efl_ui_draggable_drag_target_set_static_delegate == null)
            {
                efl_ui_draggable_drag_target_set_static_delegate = new efl_ui_draggable_drag_target_set_delegate(drag_target_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDragTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_draggable_drag_target_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_draggable_drag_target_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Image.efl_ui_image_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_image_icon_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_image_icon_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_icon_get_api_delegate> efl_ui_image_icon_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_icon_get_api_delegate>(Module, "efl_ui_image_icon_get");

        private static System.String icon_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_image_icon_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Image)ws.Target).GetIcon();
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
                return efl_ui_image_icon_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_image_icon_get_delegate efl_ui_image_icon_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_image_icon_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_image_icon_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_ui_image_icon_set_api_delegate> efl_ui_image_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_image_icon_set_api_delegate>(Module, "efl_ui_image_icon_set");

        private static bool icon_set(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_ui_image_icon_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).SetIcon(name);
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
                return efl_ui_image_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_ui_image_icon_set_delegate efl_ui_image_icon_set_static_delegate;

        
        private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(Module, "efl_file_mmap_get");

        private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_mmap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.File _ret_var = default(Eina.File);
                try
                {
                    _ret_var = ((Image)ws.Target).GetMmap();
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
                return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;

        
        private delegate Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.File f);

        
        public delegate Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,  Eina.File f);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(Module, "efl_file_mmap_set");

        private static Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd, Eina.File f)
        {
            Eina.Log.Debug("function efl_file_mmap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Image)ws.Target).SetMmap(f);
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
                return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(Module, "efl_file_get");

        private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Image)ws.Target).GetFile();
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
                return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_get_delegate efl_file_get_static_delegate;

        
        private delegate Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        
        public delegate Eina.Error efl_file_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(Module, "efl_file_set");

        private static Eina.Error file_set(System.IntPtr obj, System.IntPtr pd, System.String file)
        {
            Eina.Log.Debug("function efl_file_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Image)ws.Target).SetFile(file);
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
                return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file);
            }
        }

        private static efl_file_set_delegate efl_file_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(Module, "efl_file_key_get");

        private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_key_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Image)ws.Target).GetKey();
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
                return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_key_get_delegate efl_file_key_get_static_delegate;

        
        private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_file_key_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(Module, "efl_file_key_set");

        private static void key_set(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_file_key_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetKey(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_file_key_set_delegate efl_file_key_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(Module, "efl_file_loaded_get");

        private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_loaded_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoaded();
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
                return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;

        
        private delegate Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_file_load_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(Module, "efl_file_load");

        private static Eina.Error load(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_load was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Image)ws.Target).Load();
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
                return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_load_delegate efl_file_load_static_delegate;

        
        private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_file_unload_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(Module, "efl_file_unload");

        private static void unload(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_unload was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).Unload();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_unload_delegate efl_file_unload_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_playable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate> efl_player_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate>(Module, "efl_player_playable_get");

        private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_playable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetPlayable();
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
                return efl_player_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_playable_get_delegate efl_player_playable_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_play_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_play_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate> efl_player_play_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate>(Module, "efl_player_play_get");

        private static bool play_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_play_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetPlay();
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
                return efl_player_play_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_play_get_delegate efl_player_play_get_static_delegate;

        
        private delegate void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool play);

        
        public delegate void efl_player_play_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool play);

        public static Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate> efl_player_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate>(Module, "efl_player_play_set");

        private static void play_set(System.IntPtr obj, System.IntPtr pd, bool play)
        {
            Eina.Log.Debug("function efl_player_play_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetPlay(play);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_player_play_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), play);
            }
        }

        private static efl_player_play_set_delegate efl_player_play_set_static_delegate;

        
        private delegate double efl_player_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_pos_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate> efl_player_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate>(Module, "efl_player_pos_get");

        private static double pos_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_pos_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetPos();
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
                return efl_player_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_pos_get_delegate efl_player_pos_get_static_delegate;

        
        private delegate void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        public delegate void efl_player_pos_set_api_delegate(System.IntPtr obj,  double sec);

        public static Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate> efl_player_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate>(Module, "efl_player_pos_set");

        private static void pos_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            Eina.Log.Debug("function efl_player_pos_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetPos(sec);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_player_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sec);
            }
        }

        private static efl_player_pos_set_delegate efl_player_pos_set_static_delegate;

        
        private delegate double efl_player_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_progress_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate> efl_player_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate>(Module, "efl_player_progress_get");

        private static double progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_progress_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetProgress();
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
                return efl_player_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_progress_get_delegate efl_player_progress_get_static_delegate;

        
        private delegate double efl_player_play_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_play_speed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate> efl_player_play_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate>(Module, "efl_player_play_speed_get");

        private static double play_speed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_play_speed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetPlaySpeed();
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
                return efl_player_play_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_play_speed_get_delegate efl_player_play_speed_get_static_delegate;

        
        private delegate void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  double speed);

        
        public delegate void efl_player_play_speed_set_api_delegate(System.IntPtr obj,  double speed);

        public static Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate> efl_player_play_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate>(Module, "efl_player_play_speed_set");

        private static void play_speed_set(System.IntPtr obj, System.IntPtr pd, double speed)
        {
            Eina.Log.Debug("function efl_player_play_speed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetPlaySpeed(speed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_player_play_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), speed);
            }
        }

        private static efl_player_play_speed_set_delegate efl_player_play_speed_set_static_delegate;

        
        private delegate double efl_player_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_volume_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate> efl_player_volume_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate>(Module, "efl_player_volume_get");

        private static double volume_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_volume_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetVolume();
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
                return efl_player_volume_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_volume_get_delegate efl_player_volume_get_static_delegate;

        
        private delegate void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,  double volume);

        
        public delegate void efl_player_volume_set_api_delegate(System.IntPtr obj,  double volume);

        public static Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate> efl_player_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate>(Module, "efl_player_volume_set");

        private static void volume_set(System.IntPtr obj, System.IntPtr pd, double volume)
        {
            Eina.Log.Debug("function efl_player_volume_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetVolume(volume);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_player_volume_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), volume);
            }
        }

        private static efl_player_volume_set_delegate efl_player_volume_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_mute_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate> efl_player_mute_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate>(Module, "efl_player_mute_get");

        private static bool mute_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_mute_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetMute();
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
                return efl_player_mute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_mute_get_delegate efl_player_mute_get_static_delegate;

        
        private delegate void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool mute);

        
        public delegate void efl_player_mute_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool mute);

        public static Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate> efl_player_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate>(Module, "efl_player_mute_set");

        private static void mute_set(System.IntPtr obj, System.IntPtr pd, bool mute)
        {
            Eina.Log.Debug("function efl_player_mute_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetMute(mute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_player_mute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mute);
            }
        }

        private static efl_player_mute_set_delegate efl_player_mute_set_static_delegate;

        
        private delegate double efl_player_length_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_length_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate> efl_player_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate>(Module, "efl_player_length_get");

        private static double length_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_length_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLength();
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
                return efl_player_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_length_get_delegate efl_player_length_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_seekable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate> efl_player_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate>(Module, "efl_player_seekable_get");

        private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_seekable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetSeekable();
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
                return efl_player_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_seekable_get_delegate efl_player_seekable_get_static_delegate;

        
        private delegate void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_player_start_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_start_api_delegate> efl_player_start_ptr = new Efl.Eo.FunctionWrapper<efl_player_start_api_delegate>(Module, "efl_player_start");

        private static void start(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).Start();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_player_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_start_delegate efl_player_start_static_delegate;

        
        private delegate void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_player_stop_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate> efl_player_stop_ptr = new Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate>(Module, "efl_player_stop");

        private static void stop(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_stop was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).Stop();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_player_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_stop_delegate efl_player_stop_static_delegate;

        
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
                    ((Image)ws.Target).GetContentAlign(out align_horiz, out align_vert);
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
                    ((Image)ws.Target).SetContentAlign(align_horiz, align_vert);
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
                    ((Image)ws.Target).GetContentPadding(out pad_horiz, out pad_vert, out scalable);
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
                    ((Image)ws.Target).SetContentPadding(pad_horiz, pad_vert, scalable);
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

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_smooth_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_smooth_scale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate> efl_gfx_image_smooth_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_get_api_delegate>(Module, "efl_gfx_image_smooth_scale_get");

        private static bool smooth_scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_smooth_scale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetSmoothScale();
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
                return efl_gfx_image_smooth_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_smooth_scale_get_delegate efl_gfx_image_smooth_scale_get_static_delegate;

        
        private delegate void efl_gfx_image_smooth_scale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool smooth_scale);

        
        public delegate void efl_gfx_image_smooth_scale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool smooth_scale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate> efl_gfx_image_smooth_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_smooth_scale_set_api_delegate>(Module, "efl_gfx_image_smooth_scale_set");

        private static void smooth_scale_set(System.IntPtr obj, System.IntPtr pd, bool smooth_scale)
        {
            Eina.Log.Debug("function efl_gfx_image_smooth_scale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetSmoothScale(smooth_scale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_smooth_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), smooth_scale);
            }
        }

        private static efl_gfx_image_smooth_scale_set_delegate efl_gfx_image_smooth_scale_set_static_delegate;

        
        private delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.ImageScaleType efl_gfx_image_scale_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate> efl_gfx_image_scale_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_get_api_delegate>(Module, "efl_gfx_image_scale_type_get");

        private static Efl.Gfx.ImageScaleType scale_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_scale_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.ImageScaleType _ret_var = default(Efl.Gfx.ImageScaleType);
                try
                {
                    _ret_var = ((Image)ws.Target).GetScaleType();
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
                return efl_gfx_image_scale_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_scale_type_get_delegate efl_gfx_image_scale_type_get_static_delegate;

        
        private delegate void efl_gfx_image_scale_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleType scale_type);

        
        public delegate void efl_gfx_image_scale_type_set_api_delegate(System.IntPtr obj,  Efl.Gfx.ImageScaleType scale_type);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate> efl_gfx_image_scale_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_type_set_api_delegate>(Module, "efl_gfx_image_scale_type_set");

        private static void scale_type_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.ImageScaleType scale_type)
        {
            Eina.Log.Debug("function efl_gfx_image_scale_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetScaleType(scale_type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_scale_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scale_type);
            }
        }

        private static efl_gfx_image_scale_type_set_delegate efl_gfx_image_scale_type_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_can_upscale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_can_upscale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_can_upscale_get_api_delegate> efl_gfx_image_can_upscale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_can_upscale_get_api_delegate>(Module, "efl_gfx_image_can_upscale_get");

        private static bool can_upscale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_can_upscale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetCanUpscale();
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
                return efl_gfx_image_can_upscale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_can_upscale_get_delegate efl_gfx_image_can_upscale_get_static_delegate;

        
        private delegate void efl_gfx_image_can_upscale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool upscale);

        
        public delegate void efl_gfx_image_can_upscale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool upscale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_can_upscale_set_api_delegate> efl_gfx_image_can_upscale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_can_upscale_set_api_delegate>(Module, "efl_gfx_image_can_upscale_set");

        private static void can_upscale_set(System.IntPtr obj, System.IntPtr pd, bool upscale)
        {
            Eina.Log.Debug("function efl_gfx_image_can_upscale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetCanUpscale(upscale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_can_upscale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), upscale);
            }
        }

        private static efl_gfx_image_can_upscale_set_delegate efl_gfx_image_can_upscale_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_can_downscale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_can_downscale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_can_downscale_get_api_delegate> efl_gfx_image_can_downscale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_can_downscale_get_api_delegate>(Module, "efl_gfx_image_can_downscale_get");

        private static bool can_downscale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_can_downscale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetCanDownscale();
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
                return efl_gfx_image_can_downscale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_can_downscale_get_delegate efl_gfx_image_can_downscale_get_static_delegate;

        
        private delegate void efl_gfx_image_can_downscale_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool downscale);

        
        public delegate void efl_gfx_image_can_downscale_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool downscale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_can_downscale_set_api_delegate> efl_gfx_image_can_downscale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_can_downscale_set_api_delegate>(Module, "efl_gfx_image_can_downscale_set");

        private static void can_downscale_set(System.IntPtr obj, System.IntPtr pd, bool downscale)
        {
            Eina.Log.Debug("function efl_gfx_image_can_downscale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetCanDownscale(downscale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_can_downscale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), downscale);
            }
        }

        private static efl_gfx_image_can_downscale_set_delegate efl_gfx_image_can_downscale_set_static_delegate;

        
        private delegate double efl_gfx_image_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_image_ratio_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate> efl_gfx_image_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_ratio_get_api_delegate>(Module, "efl_gfx_image_ratio_get");

        private static double ratio_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_ratio_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetRatio();
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
                return efl_gfx_image_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_ratio_get_delegate efl_gfx_image_ratio_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_image_content_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_image_content_region_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_region_get_api_delegate> efl_gfx_image_content_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_region_get_api_delegate>(Module, "efl_gfx_image_content_region_get");

        private static Eina.Rect.NativeStruct content_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_content_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Image)ws.Target).GetContentRegion();
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
                return efl_gfx_image_content_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_content_region_get_delegate efl_gfx_image_content_region_get_static_delegate;

        
        private delegate void efl_gfx_image_border_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_image_border_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate> efl_gfx_image_border_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_get_api_delegate>(Module, "efl_gfx_image_border_get");

        private static void border_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_image_border_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((Image)ws.Target).GetBorder(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_image_border_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_image_border_get_delegate efl_gfx_image_border_get_static_delegate;

        
        private delegate void efl_gfx_image_border_set_delegate(System.IntPtr obj, System.IntPtr pd,  int l,  int r,  int t,  int b);

        
        public delegate void efl_gfx_image_border_set_api_delegate(System.IntPtr obj,  int l,  int r,  int t,  int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate> efl_gfx_image_border_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_set_api_delegate>(Module, "efl_gfx_image_border_set");

        private static void border_set(System.IntPtr obj, System.IntPtr pd, int l, int r, int t, int b)
        {
            Eina.Log.Debug("function efl_gfx_image_border_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Image)ws.Target).SetBorder(l, r, t, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_image_border_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), l, r, t, b);
            }
        }

        private static efl_gfx_image_border_set_delegate efl_gfx_image_border_set_static_delegate;

        
        private delegate double efl_gfx_image_border_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_image_border_scale_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate> efl_gfx_image_border_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_get_api_delegate>(Module, "efl_gfx_image_border_scale_get");

        private static double border_scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_border_scale_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetBorderScale();
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
                return efl_gfx_image_border_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_border_scale_get_delegate efl_gfx_image_border_scale_get_static_delegate;

        
        private delegate void efl_gfx_image_border_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        public delegate void efl_gfx_image_border_scale_set_api_delegate(System.IntPtr obj,  double scale);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate> efl_gfx_image_border_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_scale_set_api_delegate>(Module, "efl_gfx_image_border_scale_set");

        private static void border_scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            Eina.Log.Debug("function efl_gfx_image_border_scale_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetBorderScale(scale);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_border_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scale);
            }
        }

        private static efl_gfx_image_border_scale_set_delegate efl_gfx_image_border_scale_set_static_delegate;

        
        private delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.BorderFillMode efl_gfx_image_border_center_fill_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate> efl_gfx_image_border_center_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_get_api_delegate>(Module, "efl_gfx_image_border_center_fill_get");

        private static Efl.Gfx.BorderFillMode border_center_fill_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_border_center_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.BorderFillMode _ret_var = default(Efl.Gfx.BorderFillMode);
                try
                {
                    _ret_var = ((Image)ws.Target).GetBorderCenterFill();
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
                return efl_gfx_image_border_center_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_border_center_fill_get_delegate efl_gfx_image_border_center_fill_get_static_delegate;

        
        private delegate void efl_gfx_image_border_center_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BorderFillMode fill);

        
        public delegate void efl_gfx_image_border_center_fill_set_api_delegate(System.IntPtr obj,  Efl.Gfx.BorderFillMode fill);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate> efl_gfx_image_border_center_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_border_center_fill_set_api_delegate>(Module, "efl_gfx_image_border_center_fill_set");

        private static void border_center_fill_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.BorderFillMode fill)
        {
            Eina.Log.Debug("function efl_gfx_image_border_center_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetBorderCenterFill(fill);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_border_center_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fill);
            }
        }

        private static efl_gfx_image_border_center_fill_set_delegate efl_gfx_image_border_center_fill_set_static_delegate;

        
        private delegate void efl_gfx_image_stretch_region_get_delegate(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr horizontal,  out System.IntPtr vertical);

        
        public delegate void efl_gfx_image_stretch_region_get_api_delegate(System.IntPtr obj,  out System.IntPtr horizontal,  out System.IntPtr vertical);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_stretch_region_get_api_delegate> efl_gfx_image_stretch_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_stretch_region_get_api_delegate>(Module, "efl_gfx_image_stretch_region_get");

        private static void stretch_region_get(System.IntPtr obj, System.IntPtr pd, out System.IntPtr horizontal, out System.IntPtr vertical)
        {
            Eina.Log.Debug("function efl_gfx_image_stretch_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_horizontal = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
        Eina.Iterator<Efl.Gfx.ImageStretchRegion> _out_vertical = default(Eina.Iterator<Efl.Gfx.ImageStretchRegion>);
                            
                try
                {
                    ((Image)ws.Target).GetStretchRegion(out _out_horizontal, out _out_vertical);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        horizontal = _out_horizontal.Handle;
        vertical = _out_vertical.Handle;
                        
            }
            else
            {
                efl_gfx_image_stretch_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out horizontal, out vertical);
            }
        }

        private static efl_gfx_image_stretch_region_get_delegate efl_gfx_image_stretch_region_get_static_delegate;

        
        private delegate Eina.Error efl_gfx_image_stretch_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr horizontal,  System.IntPtr vertical);

        
        public delegate Eina.Error efl_gfx_image_stretch_region_set_api_delegate(System.IntPtr obj,  System.IntPtr horizontal,  System.IntPtr vertical);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_stretch_region_set_api_delegate> efl_gfx_image_stretch_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_stretch_region_set_api_delegate>(Module, "efl_gfx_image_stretch_region_set");

        private static Eina.Error stretch_region_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr horizontal, System.IntPtr vertical)
        {
            Eina.Log.Debug("function efl_gfx_image_stretch_region_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_horizontal = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(horizontal, false);
        var _in_vertical = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(vertical, false);
                                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Image)ws.Target).SetStretchRegion(_in_horizontal, _in_vertical);
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
                return efl_gfx_image_stretch_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), horizontal, vertical);
            }
        }

        private static efl_gfx_image_stretch_region_set_delegate efl_gfx_image_stretch_region_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_image_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_image_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate> efl_gfx_image_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_size_get_api_delegate>(Module, "efl_gfx_image_size_get");

        private static Eina.Size2D.NativeStruct image_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).GetImageSize();
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
                return efl_gfx_image_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_size_get_delegate efl_gfx_image_size_get_static_delegate;

        
        private delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.ImageContentHint efl_gfx_image_content_hint_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate> efl_gfx_image_content_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_get_api_delegate>(Module, "efl_gfx_image_content_hint_get");

        private static Efl.Gfx.ImageContentHint content_hint_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_content_hint_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.ImageContentHint _ret_var = default(Efl.Gfx.ImageContentHint);
                try
                {
                    _ret_var = ((Image)ws.Target).GetContentHint();
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
                return efl_gfx_image_content_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_content_hint_get_delegate efl_gfx_image_content_hint_get_static_delegate;

        
        private delegate void efl_gfx_image_content_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageContentHint hint);

        
        public delegate void efl_gfx_image_content_hint_set_api_delegate(System.IntPtr obj,  Efl.Gfx.ImageContentHint hint);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate> efl_gfx_image_content_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_content_hint_set_api_delegate>(Module, "efl_gfx_image_content_hint_set");

        private static void content_hint_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.ImageContentHint hint)
        {
            Eina.Log.Debug("function efl_gfx_image_content_hint_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetContentHint(hint);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_content_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hint);
            }
        }

        private static efl_gfx_image_content_hint_set_delegate efl_gfx_image_content_hint_set_static_delegate;

        
        private delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.ImageScaleHint efl_gfx_image_scale_hint_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate> efl_gfx_image_scale_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_get_api_delegate>(Module, "efl_gfx_image_scale_hint_get");

        private static Efl.Gfx.ImageScaleHint scale_hint_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_scale_hint_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.ImageScaleHint _ret_var = default(Efl.Gfx.ImageScaleHint);
                try
                {
                    _ret_var = ((Image)ws.Target).GetScaleHint();
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
                return efl_gfx_image_scale_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_scale_hint_get_delegate efl_gfx_image_scale_hint_get_static_delegate;

        
        private delegate void efl_gfx_image_scale_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageScaleHint hint);

        
        public delegate void efl_gfx_image_scale_hint_set_api_delegate(System.IntPtr obj,  Efl.Gfx.ImageScaleHint hint);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate> efl_gfx_image_scale_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_scale_hint_set_api_delegate>(Module, "efl_gfx_image_scale_hint_set");

        private static void scale_hint_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.ImageScaleHint hint)
        {
            Eina.Log.Debug("function efl_gfx_image_scale_hint_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetScaleHint(hint);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_scale_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hint);
            }
        }

        private static efl_gfx_image_scale_hint_set_delegate efl_gfx_image_scale_hint_set_static_delegate;

        
        private delegate Eina.Error efl_gfx_image_load_error_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_gfx_image_load_error_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate> efl_gfx_image_load_error_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_error_get_api_delegate>(Module, "efl_gfx_image_load_error_get");

        private static Eina.Error image_load_error_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_error_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Image)ws.Target).GetImageLoadError();
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
                return efl_gfx_image_load_error_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_error_get_delegate efl_gfx_image_load_error_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_image_load_controller_load_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate> efl_gfx_image_load_controller_load_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_get");

        private static Eina.Size2D.NativeStruct load_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadSize();
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
                return efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_size_get_delegate efl_gfx_image_load_controller_load_size_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_image_load_controller_load_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate> efl_gfx_image_load_controller_load_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_size_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_size_set");

        private static void load_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((Image)ws.Target).SetLoadSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_image_load_controller_load_size_set_delegate efl_gfx_image_load_controller_load_size_set_static_delegate;

        
        private delegate double efl_gfx_image_load_controller_load_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_image_load_controller_load_dpi_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate> efl_gfx_image_load_controller_load_dpi_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_get");

        private static double load_dpi_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadDpi();
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
                return efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_get_delegate efl_gfx_image_load_controller_load_dpi_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_dpi_set_delegate(System.IntPtr obj, System.IntPtr pd,  double dpi);

        
        public delegate void efl_gfx_image_load_controller_load_dpi_set_api_delegate(System.IntPtr obj,  double dpi);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate> efl_gfx_image_load_controller_load_dpi_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_dpi_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_dpi_set");

        private static void load_dpi_set(System.IntPtr obj, System.IntPtr pd, double dpi)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_dpi_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetLoadDpi(dpi);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dpi);
            }
        }

        private static efl_gfx_image_load_controller_load_dpi_set_delegate efl_gfx_image_load_controller_load_dpi_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_region_support_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_region_support_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate> efl_gfx_image_load_controller_load_region_support_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_support_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_support_get");

        private static bool load_region_support_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_support_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadRegionSupport();
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
                return efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_support_get_delegate efl_gfx_image_load_controller_load_region_support_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_image_load_controller_load_region_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate> efl_gfx_image_load_controller_load_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_get");

        private static Eina.Rect.NativeStruct load_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadRegion();
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
                return efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_region_get_delegate efl_gfx_image_load_controller_load_region_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_region_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct region);

        
        public delegate void efl_gfx_image_load_controller_load_region_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct region);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate> efl_gfx_image_load_controller_load_region_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_region_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_region_set");

        private static void load_region_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct region)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_region_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_region = region;
                            
                try
                {
                    ((Image)ws.Target).SetLoadRegion(_in_region);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), region);
            }
        }

        private static efl_gfx_image_load_controller_load_region_set_delegate efl_gfx_image_load_controller_load_region_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate> efl_gfx_image_load_controller_load_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_get");

        private static bool load_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadOrientation();
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
                return efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_get_delegate efl_gfx_image_load_controller_load_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_gfx_image_load_controller_load_orientation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate> efl_gfx_image_load_controller_load_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_orientation_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_orientation_set");

        private static void load_orientation_set(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetLoadOrientation(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_gfx_image_load_controller_load_orientation_set_delegate efl_gfx_image_load_controller_load_orientation_set_static_delegate;

        
        private delegate int efl_gfx_image_load_controller_load_scale_down_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_image_load_controller_load_scale_down_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate> efl_gfx_image_load_controller_load_scale_down_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_get");

        private static int load_scale_down_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadScaleDown();
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
                return efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_get_delegate efl_gfx_image_load_controller_load_scale_down_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_scale_down_set_delegate(System.IntPtr obj, System.IntPtr pd,  int div);

        
        public delegate void efl_gfx_image_load_controller_load_scale_down_set_api_delegate(System.IntPtr obj,  int div);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate> efl_gfx_image_load_controller_load_scale_down_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_scale_down_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_scale_down_set");

        private static void load_scale_down_set(System.IntPtr obj, System.IntPtr pd, int div)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_scale_down_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetLoadScaleDown(div);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), div);
            }
        }

        private static efl_gfx_image_load_controller_load_scale_down_set_delegate efl_gfx_image_load_controller_load_scale_down_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_image_load_controller_load_skip_header_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_image_load_controller_load_skip_header_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate> efl_gfx_image_load_controller_load_skip_header_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_get_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_get");

        private static bool load_skip_header_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoadSkipHeader();
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
                return efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_get_delegate efl_gfx_image_load_controller_load_skip_header_get_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_skip_header_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool skip);

        
        public delegate void efl_gfx_image_load_controller_load_skip_header_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool skip);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate> efl_gfx_image_load_controller_load_skip_header_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_skip_header_set_api_delegate>(Module, "efl_gfx_image_load_controller_load_skip_header_set");

        private static void load_skip_header_set(System.IntPtr obj, System.IntPtr pd, bool skip)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_skip_header_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetLoadSkipHeader(skip);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), skip);
            }
        }

        private static efl_gfx_image_load_controller_load_skip_header_set_delegate efl_gfx_image_load_controller_load_skip_header_set_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_start_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_image_load_controller_load_async_start_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate> efl_gfx_image_load_controller_load_async_start_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_start_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_start");

        private static void load_async_start(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).LoadAsyncStart();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_start_delegate efl_gfx_image_load_controller_load_async_start_static_delegate;

        
        private delegate void efl_gfx_image_load_controller_load_async_cancel_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_image_load_controller_load_async_cancel_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate> efl_gfx_image_load_controller_load_async_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_load_controller_load_async_cancel_api_delegate>(Module, "efl_gfx_image_load_controller_load_async_cancel");

        private static void load_async_cancel(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_load_controller_load_async_cancel was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).LoadAsyncCancel();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;

        
        private delegate Efl.Gfx.ImageOrientation efl_gfx_image_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.ImageOrientation efl_gfx_image_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate> efl_gfx_image_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_get_api_delegate>(Module, "efl_gfx_image_orientation_get");

        private static Efl.Gfx.ImageOrientation image_orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_image_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.ImageOrientation _ret_var = default(Efl.Gfx.ImageOrientation);
                try
                {
                    _ret_var = ((Image)ws.Target).GetImageOrientation();
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
                return efl_gfx_image_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_image_orientation_get_delegate efl_gfx_image_orientation_get_static_delegate;

        
        private delegate void efl_gfx_image_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.ImageOrientation dir);

        
        public delegate void efl_gfx_image_orientation_set_api_delegate(System.IntPtr obj,  Efl.Gfx.ImageOrientation dir);

        public static Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate> efl_gfx_image_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_image_orientation_set_api_delegate>(Module, "efl_gfx_image_orientation_set");

        private static void image_orientation_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.ImageOrientation dir)
        {
            Eina.Log.Debug("function efl_gfx_image_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetImageOrientation(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_image_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_gfx_image_orientation_set_delegate efl_gfx_image_orientation_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate> efl_gfx_view_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate>(Module, "efl_gfx_view_size_get");

        private static Eina.Size2D.NativeStruct view_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_view_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).GetViewSize();
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
                return efl_gfx_view_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;

        
        private delegate void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_view_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate> efl_gfx_view_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate>(Module, "efl_gfx_view_size_set");

        private static void view_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_view_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((Image)ws.Target).SetViewSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_view_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_clickable_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_clickable_interaction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate> efl_input_clickable_interaction_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate>(Module, "efl_input_clickable_interaction_get");

        private static bool interaction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_clickable_interaction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetInteraction();
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
                return efl_input_clickable_interaction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_clickable_interaction_get_delegate efl_input_clickable_interaction_get_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_longpress_abort was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).LongpressAbort(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_longpress_abort_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_calc_auto_update_hints_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_calc_auto_update_hints_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate> efl_layout_calc_auto_update_hints_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_get_api_delegate>(Module, "efl_layout_calc_auto_update_hints_get");

        private static bool calc_auto_update_hints_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_auto_update_hints_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetCalcAutoUpdateHints();
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
                return efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_auto_update_hints_get_delegate efl_layout_calc_auto_update_hints_get_static_delegate;

        
        private delegate void efl_layout_calc_auto_update_hints_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool update);

        
        public delegate void efl_layout_calc_auto_update_hints_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool update);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate> efl_layout_calc_auto_update_hints_set_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_auto_update_hints_set_api_delegate>(Module, "efl_layout_calc_auto_update_hints_set");

        private static void calc_auto_update_hints_set(System.IntPtr obj, System.IntPtr pd, bool update)
        {
            Eina.Log.Debug("function efl_layout_calc_auto_update_hints_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetCalcAutoUpdateHints(update);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), update);
            }
        }

        private static efl_layout_calc_auto_update_hints_set_delegate efl_layout_calc_auto_update_hints_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct restricted);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_calc_size_min_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct restricted);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate> efl_layout_calc_size_min_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_size_min_api_delegate>(Module, "efl_layout_calc_size_min");

        private static Eina.Size2D.NativeStruct calc_size_min(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct restricted)
        {
            Eina.Log.Debug("function efl_layout_calc_size_min was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_restricted = restricted;
                            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).CalcSizeMin(_in_restricted);
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
                return efl_layout_calc_size_min_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), restricted);
            }
        }

        private static efl_layout_calc_size_min_delegate efl_layout_calc_size_min_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_layout_calc_parts_extends_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate> efl_layout_calc_parts_extends_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_parts_extends_api_delegate>(Module, "efl_layout_calc_parts_extends");

        private static Eina.Rect.NativeStruct calc_parts_extends(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_parts_extends was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Image)ws.Target).CalcPartsExtends();
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
                return efl_layout_calc_parts_extends_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_parts_extends_delegate efl_layout_calc_parts_extends_static_delegate;

        
        private delegate int efl_layout_calc_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_layout_calc_freeze_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate> efl_layout_calc_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_freeze_api_delegate>(Module, "efl_layout_calc_freeze");

        private static int calc_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_freeze was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).FreezeCalc();
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
                return efl_layout_calc_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_freeze_delegate efl_layout_calc_freeze_static_delegate;

        
        private delegate int efl_layout_calc_thaw_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_layout_calc_thaw_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate> efl_layout_calc_thaw_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_thaw_api_delegate>(Module, "efl_layout_calc_thaw");

        private static int calc_thaw(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_thaw was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).ThawCalc();
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
                return efl_layout_calc_thaw_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_thaw_delegate efl_layout_calc_thaw_static_delegate;

        
        private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new Efl.Eo.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

        private static void calc_force(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_calc_force was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Image)ws.Target).CalcForce();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_layout_calc_force_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_group_size_min_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate> efl_layout_group_size_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_min_get_api_delegate>(Module, "efl_layout_group_size_min_get");

        private static Eina.Size2D.NativeStruct group_size_min_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_group_size_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).GetGroupSizeMin();
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
                return efl_layout_group_size_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_group_size_min_get_delegate efl_layout_group_size_min_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_layout_group_size_max_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate> efl_layout_group_size_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_size_max_get_api_delegate>(Module, "efl_layout_group_size_max_get");

        private static Eina.Size2D.NativeStruct group_size_max_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_layout_group_size_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Image)ws.Target).GetGroupSizeMax();
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
                return efl_layout_group_size_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_layout_group_size_max_get_delegate efl_layout_group_size_max_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_layout_group_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_layout_group_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate> efl_layout_group_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_data_get_api_delegate>(Module, "efl_layout_group_data_get");

        private static System.String group_data_get(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_layout_group_data_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Image)ws.Target).GetGroupData(key);
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
                return efl_layout_group_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_layout_group_data_get_delegate efl_layout_group_data_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_group_part_exist_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_group_part_exist_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        public static Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate> efl_layout_group_part_exist_get_ptr = new Efl.Eo.FunctionWrapper<efl_layout_group_part_exist_get_api_delegate>(Module, "efl_layout_group_part_exist_get");

        private static bool part_exist_get(System.IntPtr obj, System.IntPtr pd, System.String part)
        {
            Eina.Log.Debug("function efl_layout_group_part_exist_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetPartExist(part);
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
                return efl_layout_group_part_exist_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), part);
            }
        }

        private static efl_layout_group_part_exist_get_delegate efl_layout_group_part_exist_get_static_delegate;

        
        private delegate void efl_layout_signal_message_send_delegate(System.IntPtr obj, System.IntPtr pd,  int id,  Eina.ValueNative msg);

        
        public delegate void efl_layout_signal_message_send_api_delegate(System.IntPtr obj,  int id,  Eina.ValueNative msg);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate> efl_layout_signal_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_message_send_api_delegate>(Module, "efl_layout_signal_message_send");

        private static void message_send(System.IntPtr obj, System.IntPtr pd, int id, Eina.ValueNative msg)
        {
            Eina.Log.Debug("function efl_layout_signal_message_send was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Image)ws.Target).MessageSend(id, msg);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_layout_signal_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id, msg);
            }
        }

        private static efl_layout_signal_message_send_delegate efl_layout_signal_message_send_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_signal_callback_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate> efl_layout_signal_callback_add_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_add_api_delegate>(Module, "efl_layout_signal_callback_add");

        private static bool signal_callback_add(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_layout_signal_callback_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                            EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).AddSignalCallback(emission, source, func_wrapper.ManagedCb);
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
                return efl_layout_signal_callback_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_add_delegate efl_layout_signal_callback_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_layout_signal_callback_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_layout_signal_callback_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source,  IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate> efl_layout_signal_callback_del_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_callback_del_api_delegate>(Module, "efl_layout_signal_callback_del");

        private static bool signal_callback_del(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source, IntPtr func_data, EflLayoutSignalCbInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_layout_signal_callback_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                            EflLayoutSignalCbWrapper func_wrapper = new EflLayoutSignalCbWrapper(func, func_data, func_free_cb);
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).DelSignalCallback(emission, source, func_wrapper.ManagedCb);
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
                return efl_layout_signal_callback_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source, func_data, func, func_free_cb);
            }
        }

        private static efl_layout_signal_callback_del_delegate efl_layout_signal_callback_del_static_delegate;

        
        private delegate void efl_layout_signal_emit_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source);

        
        public delegate void efl_layout_signal_emit_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String emission, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String source);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate> efl_layout_signal_emit_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_emit_api_delegate>(Module, "efl_layout_signal_emit");

        private static void signal_emit(System.IntPtr obj, System.IntPtr pd, System.String emission, System.String source)
        {
            Eina.Log.Debug("function efl_layout_signal_emit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Image)ws.Target).EmitSignal(emission, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_layout_signal_emit_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), emission, source);
            }
        }

        private static efl_layout_signal_emit_delegate efl_layout_signal_emit_static_delegate;

        
        private delegate void efl_layout_signal_process_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool recurse);

        
        public delegate void efl_layout_signal_process_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool recurse);

        public static Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate> efl_layout_signal_process_ptr = new Efl.Eo.FunctionWrapper<efl_layout_signal_process_api_delegate>(Module, "efl_layout_signal_process");

        private static void signal_process(System.IntPtr obj, System.IntPtr pd, bool recurse)
        {
            Eina.Log.Debug("function efl_layout_signal_process was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SignalProcess(recurse);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_layout_signal_process_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), recurse);
            }
        }

        private static efl_layout_signal_process_delegate efl_layout_signal_process_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_draggable_drag_target_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_draggable_drag_target_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate> efl_ui_draggable_drag_target_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_get_api_delegate>(Module, "efl_ui_draggable_drag_target_get");

        private static bool drag_target_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_draggable_drag_target_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetDragTarget();
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
                return efl_ui_draggable_drag_target_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_draggable_drag_target_get_delegate efl_ui_draggable_drag_target_get_static_delegate;

        
        private delegate void efl_ui_draggable_drag_target_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool set);

        
        public delegate void efl_ui_draggable_drag_target_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool set);

        public static Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate> efl_ui_draggable_drag_target_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_draggable_drag_target_set_api_delegate>(Module, "efl_ui_draggable_drag_target_set");

        private static void drag_target_set(System.IntPtr obj, System.IntPtr pd, bool set)
        {
            Eina.Log.Debug("function efl_ui_draggable_drag_target_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Image)ws.Target).SetDragTarget(set);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_draggable_drag_target_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), set);
            }
        }

        private static efl_ui_draggable_drag_target_set_delegate efl_ui_draggable_drag_target_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiImage_ExtensionMethods {
    public static Efl.BindableProperty<System.String> Icon<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<System.String>("icon", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    
    
    public static Efl.BindableProperty<bool> Play<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("play", fac);
    }

    public static Efl.BindableProperty<double> Pos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<double>("pos", fac);
    }

    
    public static Efl.BindableProperty<double> PlaySpeed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<double>("play_speed", fac);
    }

    public static Efl.BindableProperty<double> Volume<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<double>("volume", fac);
    }

    public static Efl.BindableProperty<bool> Mute<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("mute", fac);
    }

    
    
    
    
    public static Efl.BindableProperty<bool> SmoothScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("smooth_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleType> ScaleType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleType>("scale_type", fac);
    }

    public static Efl.BindableProperty<bool> CanUpscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("can_upscale", fac);
    }

    public static Efl.BindableProperty<bool> CanDownscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("can_downscale", fac);
    }

    
    
    
    public static Efl.BindableProperty<double> BorderScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<double>("border_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.BorderFillMode> BorderCenterFill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.BorderFillMode>("border_center_fill", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Gfx.ImageContentHint> ContentHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageContentHint>("content_hint", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleHint> ScaleHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleHint>("scale_hint", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> LoadSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Eina.Size2D>("load_size", fac);
    }

    public static Efl.BindableProperty<double> LoadDpi<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<double>("load_dpi", fac);
    }

    
    public static Efl.BindableProperty<Eina.Rect> LoadRegion<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Eina.Rect>("load_region", fac);
    }

    public static Efl.BindableProperty<bool> LoadOrientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("load_orientation", fac);
    }

    public static Efl.BindableProperty<int> LoadScaleDown<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<int>("load_scale_down", fac);
    }

    public static Efl.BindableProperty<bool> LoadSkipHeader<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("load_skip_header", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageOrientation> ImageOrientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageOrientation>("image_orientation", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> ViewSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Eina.Size2D>("view_size", fac);
    }

    
    public static Efl.BindableProperty<bool> CalcAutoUpdateHints<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("calc_auto_update_hints", fac);
    }

    
    
    
    
    public static Efl.BindableProperty<bool> DragTarget<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<bool>("drag_target", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Structure associated with smart callback &apos;download,progress&apos;.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ImageProgress
{
    /// <summary>Current percentage</summary>
    public double Now;
    /// <summary>Total percentage</summary>
    public double Total;
    /// <summary>Constructor for ImageProgress.</summary>
    /// <param name="Now">Current percentage</param>;
    /// <param name="Total">Total percentage</param>;
    public ImageProgress(
        double Now = default(double),
        double Total = default(double)    )
    {
        this.Now = Now;
        this.Total = Total;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ImageProgress(IntPtr ptr)
    {
        var tmp = (ImageProgress.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ImageProgress.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ImageProgress.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public double Now;
        
        public double Total;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ImageProgress.NativeStruct(ImageProgress _external_struct)
        {
            var _internal_struct = new ImageProgress.NativeStruct();
            _internal_struct.Now = _external_struct.Now;
            _internal_struct.Total = _external_struct.Total;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ImageProgress(ImageProgress.NativeStruct _internal_struct)
        {
            var _external_struct = new ImageProgress();
            _external_struct.Now = _internal_struct.Now;
            _external_struct.Total = _internal_struct.Total;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

namespace Efl {

namespace Ui {

/// <summary>Structure associated with smart callback &apos;download,progress&apos;.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ImageError
{
    /// <summary>Error status of the download</summary>
    public int Status;
    /// <summary><c>true</c> if the error happened when opening the file, <c>false</c> otherwise</summary>
    public bool Open_error;
    /// <summary>Constructor for ImageError.</summary>
    /// <param name="Status">Error status of the download</param>;
    /// <param name="Open_error"><c>true</c> if the error happened when opening the file, <c>false</c> otherwise</param>;
    public ImageError(
        int Status = default(int),
        bool Open_error = default(bool)    )
    {
        this.Status = Status;
        this.Open_error = Open_error;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ImageError(IntPtr ptr)
    {
        var tmp = (ImageError.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ImageError.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ImageError.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public int Status;
        /// <summary>Internal wrapper for field Open_error</summary>
        public System.Byte Open_error;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ImageError.NativeStruct(ImageError _external_struct)
        {
            var _internal_struct = new ImageError.NativeStruct();
            _internal_struct.Status = _external_struct.Status;
            _internal_struct.Open_error = _external_struct.Open_error ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ImageError(ImageError.NativeStruct _internal_struct)
        {
            var _external_struct = new ImageError();
            _external_struct.Status = _internal_struct.Status;
            _external_struct.Open_error = _internal_struct.Open_error != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

