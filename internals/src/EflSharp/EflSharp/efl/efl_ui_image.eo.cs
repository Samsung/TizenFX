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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Image.DropEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ImageDropEventArgs : EventArgs {
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
    /// <value><see cref="Efl.Ui.ImageDropEventArgs"/></value>
    public event EventHandler<Efl.Ui.ImageDropEventArgs> DropEvent
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
                        Efl.Ui.ImageDropEventArgs args = new Efl.Ui.ImageDropEventArgs();
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
    /// <summary>Method to raise event DropEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDropEvent(Efl.Ui.ImageDropEventArgs e)
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
    public event EventHandler ImagePreloadEvent
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
    /// <summary>Method to raise event ImagePreloadEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImagePreloadEvent(EventArgs e)
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
    /// <summary>Image was resized (its pixel data). The event data is the image&apos;s new size.</summary>
    /// <value><see cref="Efl.Gfx.ImageImageResizedEventArgs"/></value>
    public event EventHandler<Efl.Gfx.ImageImageResizedEventArgs> ImageResizedEvent
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
                        Efl.Gfx.ImageImageResizedEventArgs args = new Efl.Gfx.ImageImageResizedEventArgs();
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

                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageResizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImageResizedEvent(Efl.Gfx.ImageImageResizedEventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
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
    /// <summary>Image data has been unloaded (by some mechanism in EFL that threw out the original image data).</summary>
    public event EventHandler ImageUnloadEvent
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
    /// <summary>Method to raise event ImageUnloadEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnImageUnloadEvent(EventArgs e)
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
    /// <summary>Emitted after the image has been loaded.</summary>
    public event EventHandler LoadDoneEvent
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
    /// <summary>Method to raise event LoadDoneEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadDoneEvent(EventArgs e)
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
    /// <summary>Emitted if an error happened during image loading.</summary>
    /// <value><see cref="Efl.Gfx.ImageLoadControllerLoadErrorEventArgs"/></value>
    public event EventHandler<Efl.Gfx.ImageLoadControllerLoadErrorEventArgs> LoadErrorEvent
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
                        Efl.Gfx.ImageLoadControllerLoadErrorEventArgs args = new Efl.Gfx.ImageLoadControllerLoadErrorEventArgs();
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
    /// <summary>Method to raise event LoadErrorEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadErrorEvent(Efl.Gfx.ImageLoadControllerLoadErrorEventArgs e)
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
    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent
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
                        Efl.Input.ClickableClickedEventArgs args = new Efl.Input.ClickableClickedEventArgs();
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
    /// <summary>Method to raise event ClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedEvent(Efl.Input.ClickableClickedEventArgs e)
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
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
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
                        Efl.Input.ClickableClickedAnyEventArgs args = new Efl.Input.ClickableClickedAnyEventArgs();
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
    /// <summary>Method to raise event ClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedAnyEvent(Efl.Input.ClickableClickedAnyEventArgs e)
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
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent
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
                        Efl.Input.ClickablePressedEventArgs args = new Efl.Input.ClickablePressedEventArgs();
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
    /// <summary>Method to raise event PressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressedEvent(Efl.Input.ClickablePressedEventArgs e)
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
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent
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
                        Efl.Input.ClickableUnpressedEventArgs args = new Efl.Input.ClickableUnpressedEventArgs();
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
    /// <summary>Method to raise event UnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressedEvent(Efl.Input.ClickableUnpressedEventArgs e)
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
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent
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
                        Efl.Input.ClickableLongpressedEventArgs args = new Efl.Input.ClickableLongpressedEventArgs();
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
    /// <summary>Method to raise event LongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLongpressedEvent(Efl.Input.ClickableLongpressedEventArgs e)
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
    public event EventHandler RecalcEvent
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
    /// <summary>Method to raise event RecalcEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRecalcEvent(EventArgs e)
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
    /// <value><see cref="Efl.Layout.CalcCircularDependencyEventArgs"/></value>
    public event EventHandler<Efl.Layout.CalcCircularDependencyEventArgs> CircularDependencyEvent
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
                        Efl.Layout.CalcCircularDependencyEventArgs args = new Efl.Layout.CalcCircularDependencyEventArgs();
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
    /// <summary>Method to raise event CircularDependencyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCircularDependencyEvent(Efl.Layout.CalcCircularDependencyEventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragEventArgs> DragEvent
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
                        Efl.Ui.DraggableDragEventArgs args = new Efl.Ui.DraggableDragEventArgs();
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
    /// <summary>Method to raise event DragEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragEvent(Efl.Ui.DraggableDragEventArgs e)
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
    public event EventHandler DragStartEvent
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
    /// <summary>Method to raise event DragStartEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStartEvent(EventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragStopEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragStopEventArgs> DragStopEvent
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
                        Efl.Ui.DraggableDragStopEventArgs args = new Efl.Ui.DraggableDragStopEventArgs();
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
    /// <summary>Method to raise event DragStopEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStopEvent(Efl.Ui.DraggableDragStopEventArgs e)
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
    public event EventHandler DragEndEvent
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
    /// <summary>Method to raise event DragEndEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragEndEvent(EventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragStartUpEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragStartUpEventArgs> DragStartUpEvent
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
                        Efl.Ui.DraggableDragStartUpEventArgs args = new Efl.Ui.DraggableDragStartUpEventArgs();
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
    /// <summary>Method to raise event DragStartUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStartUpEvent(Efl.Ui.DraggableDragStartUpEventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragStartDownEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragStartDownEventArgs> DragStartDownEvent
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
                        Efl.Ui.DraggableDragStartDownEventArgs args = new Efl.Ui.DraggableDragStartDownEventArgs();
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
    /// <summary>Method to raise event DragStartDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStartDownEvent(Efl.Ui.DraggableDragStartDownEventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragStartRightEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragStartRightEventArgs> DragStartRightEvent
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
                        Efl.Ui.DraggableDragStartRightEventArgs args = new Efl.Ui.DraggableDragStartRightEventArgs();
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
    /// <summary>Method to raise event DragStartRightEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStartRightEvent(Efl.Ui.DraggableDragStartRightEventArgs e)
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
    /// <value><see cref="Efl.Ui.DraggableDragStartLeftEventArgs"/></value>
    public event EventHandler<Efl.Ui.DraggableDragStartLeftEventArgs> DragStartLeftEvent
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
                        Efl.Ui.DraggableDragStartLeftEventArgs args = new Efl.Ui.DraggableDragStartLeftEventArgs();
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
    /// <summary>Method to raise event DragStartLeftEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDragStartLeftEvent(Efl.Ui.DraggableDragStartLeftEventArgs e)
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
    /// <summary>The image name, using icon standards names.
    /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
    /// 
    /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="Efl.Ui.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
    /// 
    /// If the image was set using <see cref="Efl.IFile.File"/> instead of <see cref="Efl.Ui.Image.SetIcon"/>, then reading this property will return null.
    /// 
    /// Note: The image set by this function is changed when <see cref="Efl.IFile.Load"/> is called.
    /// 
    /// Note: This function does not accept relative icon paths.
    /// 
    /// See also <see cref="Efl.Ui.Image.GetIcon"/>.</summary>
    /// <returns>The icon name</returns>
    public virtual System.String GetIcon() {
         var _ret_var = Efl.Ui.Image.NativeMethods.efl_ui_image_icon_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The image name, using icon standards names.
    /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
    /// 
    /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="Efl.Ui.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
    /// 
    /// If the image was set using <see cref="Efl.IFile.File"/> instead of <see cref="Efl.Ui.Image.SetIcon"/>, then reading this property will return null.
    /// 
    /// Note: The image set by this function is changed when <see cref="Efl.IFile.Load"/> is called.
    /// 
    /// Note: This function does not accept relative icon paths.
    /// 
    /// See also <see cref="Efl.Ui.Image.GetIcon"/>.</summary>
    /// <param name="name">The icon name</param>
    /// <returns><c>true</c> on success, <c>false</c> on error</returns>
    public virtual bool SetIcon(System.String name) {
                                 var _ret_var = Efl.Ui.Image.NativeMethods.efl_ui_image_icon_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    public virtual Eina.File GetMmap() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    public virtual System.String GetFile() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    public virtual System.String GetKey() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    public virtual void SetKey(System.String key) {
                                 Efl.FileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    public virtual bool GetLoaded() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error Load() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    public virtual void Unload() {
         Efl.FileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Whether or not the playable can be played.</summary>
    /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
    public virtual bool GetPlayable() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    public virtual bool GetPlay() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_play_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
    public virtual void SetPlay(bool play) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_play_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <returns>The position (in seconds).</returns>
    public virtual double GetPos() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    public virtual void SetPos(double sec) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    public virtual double GetProgress() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    public virtual double GetPlaySpeed() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_play_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    public virtual void SetPlaySpeed(double speed) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_play_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),speed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    public virtual double GetVolume() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_volume_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    public virtual void SetVolume(double volume) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_volume_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),volume);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    public virtual bool GetMute() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_mute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    public virtual void SetMute(bool mute) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_mute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mute);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    public virtual double GetLength() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    public virtual bool GetSeekable() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_seekable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a playing playable object.</summary>
    public virtual void Start() {
         Efl.PlayerConcrete.NativeMethods.efl_player_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop playable object.</summary>
    public virtual void Stop() {
         Efl.PlayerConcrete.NativeMethods.efl_player_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <returns>Whether to use smooth scale or not. The default value is <c>true</c>.</returns>
    public virtual bool GetSmoothScale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether to use high-quality image scaling algorithm for this image.
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <param name="smooth_scale">Whether to use smooth scale or not. The default value is <c>true</c>.</param>
    public virtual void SetSmoothScale(bool smooth_scale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),smooth_scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <returns>Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</returns>
    public virtual Efl.Gfx.ImageScaleMethod GetScaleMethod() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_method_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <param name="scale_method">Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</param>
    public virtual void SetScaleMethod(Efl.Gfx.ImageScaleMethod scale_method) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_method_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale_method);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <returns>Whether to allow image upscaling. The default value is <c>true</c>.</returns>
    public virtual bool GetCanUpscale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_upscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <param name="upscale">Whether to allow image upscaling. The default value is <c>true</c>.</param>
    public virtual void SetCanUpscale(bool upscale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_upscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),upscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <returns>Whether to allow image downscaling. The default value is <c>true</c>.</returns>
    public virtual bool GetCanDownscale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_downscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <param name="downscale">Whether to allow image downscaling. The default value is <c>true</c>.</param>
    public virtual void SetCanDownscale(bool downscale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_can_downscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),downscale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The native width/height ratio of the image.
    /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
    /// <returns>The image&apos;s ratio. The default value is <c>1.0</c>.</returns>
    public virtual double GetRatio() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <returns>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="Efl.Gfx.IImage.GetBorder"/> values subtracted.</returns>
    public virtual Eina.Rect GetContentRegion() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    /// <param name="l">The border&apos;s left width. The default value is $0.</param>
    /// <param name="r">The border&apos;s right width. The default value is $0.</param>
    /// <param name="t">The border&apos;s top height. The default value is $0.</param>
    /// <param name="b">The border&apos;s bottom height. The default value is $0.</param>
    public virtual void GetBorder(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
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
    /// <param name="l">The border&apos;s left width. The default value is $0.</param>
    /// <param name="r">The border&apos;s right width. The default value is $0.</param>
    /// <param name="t">The border&apos;s top height. The default value is $0.</param>
    /// <param name="b">The border&apos;s bottom height. The default value is $0.</param>
    public virtual void SetBorder(int l, int r, int t, int b) {
                                                                                                         Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),l, r, t, b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <returns>The scale factor. The default value is <c>1.0</c>.</returns>
    public virtual double GetBorderScale() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Scaling factor applied to the image borders.
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <param name="scale">The scale factor. The default value is <c>1.0</c>.</param>
    public virtual void SetBorderScale(double scale) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_border_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <returns>Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</returns>
    public virtual Efl.Gfx.CenterFillMode GetCenterFillMode() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_center_fill_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <param name="fill">Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</param>
    public virtual void SetCenterFillMode(Efl.Gfx.CenterFillMode fill) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_center_fill_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</param>
    /// <param name="vertical">Representation of areas that are stretchable in the image vertical space. The default value is <c>NULL</c>.</param>
    public virtual void GetStretchRegion(out Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, out Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
                         System.IntPtr _out_horizontal = System.IntPtr.Zero;
        System.IntPtr _out_vertical = System.IntPtr.Zero;
                        Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_stretch_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_horizontal, out _out_vertical);
        Eina.Error.RaiseIfUnhandledException();
        horizontal = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_horizontal, false);
        vertical = new Eina.Iterator<Efl.Gfx.ImageStretchRegion>(_out_vertical, false);
                         }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</param>
    /// <param name="vertical">Representation of areas that are stretchable in the image vertical space. The default value is <c>NULL</c>.</param>
    /// <returns>Return an error code if the provided values are incorrect.</returns>
    public virtual Eina.Error SetStretchRegion(Eina.Iterator<Efl.Gfx.ImageStretchRegion> horizontal, Eina.Iterator<Efl.Gfx.ImageStretchRegion> vertical) {
         var _in_horizontal = horizontal.Handle;
        var _in_vertical = vertical.Handle;
                                        var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_stretch_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_horizontal, _in_vertical);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>This represents the size of the original image in pixels.
    /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
    /// 
    /// This is a read-only property and may return 0x0.</summary>
    /// <returns>The size in pixels. The default value is the size of the image&apos;s internal buffer.</returns>
    public virtual Eina.Size2D GetImageSize() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <returns>Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</returns>
    public virtual Efl.Gfx.ImageContentHint GetContentHint() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <param name="hint">Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</param>
    public virtual void SetContentHint(Efl.Gfx.ImageContentHint hint) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_content_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <returns>Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</returns>
    public virtual Efl.Gfx.ImageScaleHint GetScaleHint() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <param name="hint">Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</param>
    public virtual void SetScaleHint(Efl.Gfx.ImageScaleHint hint) {
                                 Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hint);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
    /// <returns>The load error code. A value of $0 indicates no error.</returns>
    public virtual Eina.Error GetImageLoadError() {
         var _ret_var = Efl.Gfx.ImageConcrete.NativeMethods.efl_gfx_image_load_error_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns the requested load size.</summary>
    /// <returns>The image load size.</returns>
    public virtual Eina.Size2D GetLoadSize() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the canvas to load the image at the given size.
    /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.</summary>
    /// <param name="size">The image load size.</param>
    public virtual void SetLoadSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The DPI resolution of an image object&apos;s source image.
    /// Most useful for the SVG image loader.</summary>
    /// <returns>The DPI resolution.</returns>
    public virtual double GetLoadDpi() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The DPI resolution of an image object&apos;s source image.
    /// Most useful for the SVG image loader.</summary>
    /// <param name="dpi">The DPI resolution.</param>
    public virtual void SetLoadDpi(double dpi) {
                                 Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dpi);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</returns>
    public virtual bool GetLoadRegionSupport() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This property is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="Efl.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
    /// <returns>A region of the image.</returns>
    public virtual Eina.Rect GetLoadRegion() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This property is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="Efl.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
    /// <param name="region">A region of the image.</param>
    public virtual void SetLoadRegion(Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_region);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <returns><c>true</c> means that it should honor the orientation information.</returns>
    public virtual bool GetLoadOrientation() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Defines whether the orientation information in the image file should be honored.
    /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
    /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
    public virtual void SetLoadOrientation(bool enable) {
                                 Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The scale down factor is a divider on the original image size.
    /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
    /// 
    /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
    /// 
    /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
    /// <returns>The scale down dividing factor.</returns>
    public virtual int GetLoadScaleDown() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Requests the image loader to scale down by <c>div</c> times. Call this before starting the actual image load.</summary>
    /// <param name="div">The scale down dividing factor.</param>
    public virtual void SetLoadScaleDown(int div) {
                                 Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),div);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Initial load should skip header check and leave it all to data load.
    /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <returns><c>true</c> if header is to be skipped.</returns>
    public virtual bool GetLoadSkipHeader() {
         var _ret_var = Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Initial load should skip header check and leave it all to data load.
    /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <param name="skip"><c>true</c> if header is to be skipped.</param>
    public virtual void SetLoadSkipHeader(bool skip) {
                                 Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),skip);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Begin preloading an image object&apos;s image data in the background.
    /// Once the background task is complete the event @[.load,done] will be emitted if loading succeeded, @[.load,error] otherwise.</summary>
    public virtual void LoadAsyncStart() {
         Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Cancel preloading an image object&apos;s image data in the background.
    /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
    public virtual void LoadAsyncCancel() {
         Efl.Gfx.ImageLoadControllerConcrete.NativeMethods.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <returns>The final orientation of the object.</returns>
    public virtual Efl.Gfx.ImageOrientation GetImageOrientation() {
         var _ret_var = Efl.Gfx.ImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the orientation (rotation and flipping) of a visual object.
    /// This can be used to set the rotation on an image or a window, for instance.</summary>
    /// <param name="dir">The final orientation of the object.</param>
    public virtual void SetImageOrientation(Efl.Gfx.ImageOrientation dir) {
                                 Efl.Gfx.ImageOrientableConcrete.NativeMethods.efl_gfx_image_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
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
    public virtual Eina.Size2D GetViewSize() {
         var _ret_var = Efl.Gfx.ViewConcrete.NativeMethods.efl_gfx_view_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    public virtual void SetViewSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.ViewConcrete.NativeMethods.efl_gfx_view_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public virtual bool GetInteraction() {
         var _ret_var = Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Press(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Unpress(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    protected virtual void ResetButtonState(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    protected virtual void LongpressAbort(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether this object updates its size hints automatically.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether or not update the size hints.</returns>
    public virtual bool GetCalcAutoUpdateHints() {
         var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable auto-update of size hints.
    /// (Since EFL 1.22)</summary>
    /// <param name="update">Whether or not update the size hints.</param>
    public virtual void SetCalcAutoUpdateHints(bool update) {
                                 Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),update);
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
    public virtual Eina.Size2D CalcSizeMin(Eina.Size2D restricted) {
         Eina.Size2D.NativeStruct _in_restricted = restricted;
                        var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_restricted);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
    /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
    /// 
    /// Note: On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.
    /// (Since EFL 1.22)</summary>
    /// <returns>The calculated region.</returns>
    public virtual Eina.Rect CalcPartsExtends() {
         var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freezes the layout object.
    /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The frozen state or 0 on error</returns>
    public virtual int FreezeCalc() {
         var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    public virtual int ThawCalc() {
         var _ret_var = Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Forces a Size/Geometry calculation.
    /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
    /// 
    /// See also <see cref="Efl.Layout.ICalc.FreezeCalc"/> and <see cref="Efl.Layout.ICalc.ThawCalc"/>.
    /// (Since EFL 1.22)</summary>
    protected virtual void CalcForce() {
         Efl.Layout.CalcConcrete.NativeMethods.efl_layout_calc_force_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
    /// 
    /// Note: If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
    /// 
    /// Note: On failure, this function also return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMax"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The minimum size as set in EDC.</returns>
    public virtual Eina.Size2D GetGroupSizeMin() {
         var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
    /// 
    /// Note: If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
    /// 
    /// Note: On failure, this function will return 0x0.
    /// 
    /// See also <see cref="Efl.Layout.IGroup.GetGroupSizeMin"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>The maximum size as set in EDC.</returns>
    public virtual Eina.Size2D GetGroupSizeMax() {
         var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
    /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
    /// 
    /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
    /// 
    /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
    /// 
    /// Warning: Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The data field&apos;s key string</param>
    /// <returns>The data&apos;s value string.</returns>
    public virtual System.String GetGroupData(System.String key) {
                                 var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns <c>true</c> if the part exists in the EDC group.
    /// (Since EFL 1.22)</summary>
    /// <param name="part">The part name to check.</param>
    /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
    public virtual bool GetPartExist(System.String part) {
                                 var _ret_var = Efl.Layout.GroupConcrete.NativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),part);
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
    public virtual void MessageSend(int id, Eina.Value msg) {
                                                         Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id, msg);
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
    public virtual bool AddSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
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
    public virtual bool DelSignalCallback(System.String emission, System.String source, EflLayoutSignalCb func) {
                                                                         GCHandle func_handle = GCHandle.Alloc(func);
        var _ret_var = Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source, GCHandle.ToIntPtr(func_handle), EflLayoutSignalCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
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
    public virtual void EmitSignal(System.String emission, System.String source) {
                                                         Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_emit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),emission, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Processes an object&apos;s messages and signals queue.
    /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
    /// 
    /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.
    /// (Since EFL 1.22)</summary>
    /// <param name="recurse">Whether to process messages on children objects.</param>
    public virtual void SignalProcess(bool recurse) {
                                 Efl.Layout.SignalConcrete.NativeMethods.efl_layout_signal_process_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),recurse);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <returns>Turn on or off drop_target. Default is <c>false</c>.</returns>
    public virtual bool GetDragTarget() {
         var _ret_var = Efl.Ui.DraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the object&apos;s content is changed by drag and drop.
    /// If <c>drag_target</c> is true the object can be the target of a dragging object. The content of this object can then be changed into dragging content. For example, if an object deals with image and <c>drag_target</c> is true, the user can drag the new image and drop it into said object. This object&apos;s image can then be changed into a new image.</summary>
    /// <param name="set">Turn on or off drop_target. Default is <c>false</c>.</param>
    public virtual void SetDragTarget(bool set) {
                                 Efl.Ui.DraggableConcrete.NativeMethods.efl_ui_draggable_drag_target_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),set);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The image name, using icon standards names.
    /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
    /// 
    /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="Efl.Ui.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
    /// 
    /// If the image was set using <see cref="Efl.IFile.File"/> instead of <see cref="Efl.Ui.Image.SetIcon"/>, then reading this property will return null.
    /// 
    /// Note: The image set by this function is changed when <see cref="Efl.IFile.Load"/> is called.
    /// 
    /// Note: This function does not accept relative icon paths.
    /// 
    /// See also <see cref="Efl.Ui.Image.GetIcon"/>.</summary>
    /// <value>The icon name</value>
    public System.String Icon {
        get { return GetIcon(); }
        set { SetIcon(value); }
    }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>The load state of the object.
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
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    public bool Play {
        get { return GetPlay(); }
        set { SetPlay(value); }
    }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <value>The position (in seconds).</value>
    public double Pos {
        get { return GetPos(); }
        set { SetPos(value); }
    }
    /// <summary>How much of the file has been played.
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
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</value>
    public (double, double) ContentAlign {
        get {
            double _out_align_horiz = default(double);
            double _out_align_vert = default(double);
            GetContentAlign(out _out_align_horiz,out _out_align_vert);
            return (_out_align_horiz,_out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Horizontal padding. The default value is 0.0.</value>
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
    /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
    /// <value>Whether to use smooth scale or not. The default value is <c>true</c>.</value>
    public bool SmoothScale {
        get { return GetSmoothScale(); }
        set { SetSmoothScale(value); }
    }
    /// <summary>Determine how the image is scaled at render time.
    /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
    /// <value>Image scale type to use. The default value is <see cref="Efl.Gfx.ImageScaleMethod.None"/>.</value>
    public Efl.Gfx.ImageScaleMethod ScaleMethod {
        get { return GetScaleMethod(); }
        set { SetScaleMethod(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
    /// <value>Whether to allow image upscaling. The default value is <c>true</c>.</value>
    public bool CanUpscale {
        get { return GetCanUpscale(); }
        set { SetCanUpscale(value); }
    }
    /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
    /// <value>Whether to allow image downscaling. The default value is <c>true</c>.</value>
    public bool CanDownscale {
        get { return GetCanDownscale(); }
        set { SetCanDownscale(value); }
    }
    /// <summary>The native width/height ratio of the image.
    /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
    /// <value>The image&apos;s ratio. The default value is <c>1.0</c>.</value>
    public double Ratio {
        get { return GetRatio(); }
    }
    /// <summary>Return the relative area enclosed inside the image where content is expected.
    /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
    /// 
    /// The geometry of the area is expressed relative to the geometry of the object.</summary>
    /// <value>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="Efl.Gfx.IImage.GetBorder"/> values subtracted.</value>
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
    /// <value>The border&apos;s left width. The default value is $0.</value>
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
    /// This value multiplies the size of the <see cref="Efl.Gfx.IImage.GetBorder"/> when scaling an object.</summary>
    /// <value>The scale factor. The default value is <c>1.0</c>.</value>
    public double BorderScale {
        get { return GetBorderScale(); }
        set { SetBorderScale(value); }
    }
    /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
    /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="Efl.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="Efl.Gfx.IImage.GetBorder"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <see cref="Efl.Gfx.IFill.FillAuto"/>) to use as a frame.</summary>
    /// <value>Fill mode of the center region. The default value is <see cref="Efl.Gfx.CenterFillMode.Default"/>, i.e. render and scale the center area, respecting its transparency.</value>
    public Efl.Gfx.CenterFillMode CenterFillMode {
        get { return GetCenterFillMode(); }
        set { SetCenterFillMode(value); }
    }
    /// <summary>This property defines the stretchable pixels region of an image.
    /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="Efl.Gfx.IImage.GetBorder"/>, <see cref="Efl.Gfx.IImage.BorderScale"/> and <see cref="Efl.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
    /// <value>Representation of areas that are stretchable in the image horizontal space. The default value is <c>NULL</c>.</value>
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
    /// This is a read-only property and may return 0x0.</summary>
    /// <value>The size in pixels. The default value is the size of the image&apos;s internal buffer.</value>
    public Eina.Size2D ImageSize {
        get { return GetImageSize(); }
    }
    /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
    /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="Efl.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
    /// <value>Dynamic or static content hint. The default value is <see cref="Efl.Gfx.ImageContentHint.None"/>.</value>
    public Efl.Gfx.ImageContentHint ContentHint {
        get { return GetContentHint(); }
        set { SetContentHint(value); }
    }
    /// <summary>The scale hint of a given image of the canvas.
    /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
    /// <value>Scalable or static size hint. The default value is <see cref="Efl.Gfx.ImageScaleHint.None"/>.</value>
    public Efl.Gfx.ImageScaleHint ScaleHint {
        get { return GetScaleHint(); }
        set { SetScaleHint(value); }
    }
    /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
    /// <value>The load error code. A value of $0 indicates no error.</value>
    public Eina.Error ImageLoadError {
        get { return GetImageLoadError(); }
    }
    /// <summary>The load size of an image.
    /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
    /// 
    /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
    /// <value>The image load size.</value>
    public Eina.Size2D LoadSize {
        get { return GetLoadSize(); }
        set { SetLoadSize(value); }
    }
    /// <summary>The DPI resolution of an image object&apos;s source image.
    /// Most useful for the SVG image loader.</summary>
    /// <value>The DPI resolution.</value>
    public double LoadDpi {
        get { return GetLoadDpi(); }
        set { SetLoadDpi(value); }
    }
    /// <summary>Indicates whether the <see cref="Efl.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
    /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</value>
    public bool LoadRegionSupport {
        get { return GetLoadRegionSupport(); }
    }
    /// <summary>Inform a given image object to load a selective region of its source image.
    /// This property is useful when one is not showing all of an image&apos;s area on its image object.
    /// 
    /// Note: The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="Efl.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
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
    /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
    /// <value>The scale down dividing factor.</value>
    public int LoadScaleDown {
        get { return GetLoadScaleDown(); }
        set { SetLoadScaleDown(value); }
    }
    /// <summary>Initial load should skip header check and leave it all to data load.
    /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
    /// <value><c>true</c> if header is to be skipped.</value>
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
    /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
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
    /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
    /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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

            if (efl_layout_calc_force_static_delegate == null)
            {
                efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
            }

            if (methods.FirstOrDefault(m => m.Name == "CalcForce") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
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

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleMethod> ScaleMethod<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleMethod>("scale_method", fac);
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

    public static Efl.BindableProperty<Efl.Gfx.CenterFillMode> CenterFillMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Image, T>magic = null) where T : Efl.Ui.Image {
        return new Efl.BindableProperty<Efl.Gfx.CenterFillMode>("center_fill_mode", fac);
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
    /// <param name="Now">Current percentage</param>
    /// <param name="Total">Total percentage</param>
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
    /// <param name="Status">Error status of the download</param>
    /// <param name="Open_error"><c>true</c> if the error happened when opening the file, <c>false</c> otherwise</param>
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

