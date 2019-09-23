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

/// <summary>Elementary widget internal part background class
/// This part will proxy the calls on it to the <see cref="Efl.Ui.Bg"/> internal object of this widget. This internal object is stacked below the <see cref="Efl.Ui.Widget.SetResizeObject"/> and co-located with the widget.
/// 
/// All <see cref="Efl.Ui.Widget"/> objects have this part, allowing the background of the widget to be customized.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.WidgetPartBg.NativeMethods]
[Efl.Eo.BindingEntity]
public class WidgetPartBg : Efl.Ui.WidgetPart, Efl.IFile, Efl.Gfx.IColor, Efl.Gfx.IImage
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(WidgetPartBg))
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
        efl_ui_widget_part_bg_class_get();
    /// <summary>Initializes a new instance of the <see cref="WidgetPartBg"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public WidgetPartBg(Efl.Object parent= null
            ) : base(efl_ui_widget_part_bg_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected WidgetPartBg(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetPartBg"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected WidgetPartBg(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="WidgetPartBg"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected WidgetPartBg(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
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
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public virtual void GetColor(out int r, out int g, out int b, out int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public virtual void SetColor(int r, int g, int b, int a) {
                                                                                                         Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    public virtual System.String GetColorCode() {
         var _ret_var = Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    public virtual void SetColorCode(System.String colorcode) {
                                 Efl.Gfx.ColorConcrete.NativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),colorcode);
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
    /// <summary>The general/main color of the given Evas object.
    /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    public (int, int, int, int) Color {
        get {
            int _out_r = default(int);
            int _out_g = default(int);
            int _out_b = default(int);
            int _out_a = default(int);
            GetColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).
    /// (Since EFL 1.22)</summary>
    /// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode(value); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.WidgetPartBg.efl_ui_widget_part_bg_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.WidgetPart.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Ui.WidgetPartBg.efl_ui_widget_part_bg_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiWidgetPartBg_ExtensionMethods {
    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    
    
    public static Efl.BindableProperty<System.String> ColorCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<System.String>("color_code", fac);
    }

    public static Efl.BindableProperty<bool> SmoothScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<bool>("smooth_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleMethod> ScaleMethod<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleMethod>("scale_method", fac);
    }

    public static Efl.BindableProperty<bool> CanUpscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<bool>("can_upscale", fac);
    }

    public static Efl.BindableProperty<bool> CanDownscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<bool>("can_downscale", fac);
    }

    
    
    
    public static Efl.BindableProperty<double> BorderScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<double>("border_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.CenterFillMode> CenterFillMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<Efl.Gfx.CenterFillMode>("center_fill_mode", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Gfx.ImageContentHint> ContentHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<Efl.Gfx.ImageContentHint>("content_hint", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleHint> ScaleHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.WidgetPartBg, T>magic = null) where T : Efl.Ui.WidgetPartBg {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleHint>("scale_hint", fac);
    }

    
}
#pragma warning restore CS1591
#endif
