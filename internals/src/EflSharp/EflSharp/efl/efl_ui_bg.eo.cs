#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>The bg (background) widget is used for setting (solid) background decorations for a window (unless it has transparency enabled) or for any container object. It works just like an image, but has some properties useful for backgrounds, such as setting it to tiled, centered, scaled or stretched.</summary>
[BgNativeInherit]
public class Bg : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.IFile,Efl.Gfx.IImage,Efl.Gfx.IImageLoadController
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Bg))
                return Efl.Ui.BgNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_bg_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Bg(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_bg_class_get(), typeof(Bg), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Bg(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Bg(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ImagePreloadEvt_delegate = new Efl.EventCb(on_ImagePreloadEvt_NativeCallback);
        evt_ImageResizeEvt_delegate = new Efl.EventCb(on_ImageResizeEvt_NativeCallback);
        evt_ImageUnloadEvt_delegate = new Efl.EventCb(on_ImageUnloadEvt_NativeCallback);
        evt_LoadDoneEvt_delegate = new Efl.EventCb(on_LoadDoneEvt_NativeCallback);
        evt_LoadErrorEvt_delegate = new Efl.EventCb(on_LoadErrorEvt_NativeCallback);
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Bg.efl_ui_bg_class_get();
    }
}
public class BgNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
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
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Bg.efl_ui_bg_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Bg.efl_ui_bg_class_get();
    }


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
                _ret_var = ((Bg)wrapper).GetMmap();
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
                _ret_var = ((Bg)wrapper).SetMmap( f);
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
                _ret_var = ((Bg)wrapper).GetFile();
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
                _ret_var = ((Bg)wrapper).SetFile( file);
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
                _ret_var = ((Bg)wrapper).GetKey();
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
                ((Bg)wrapper).SetKey( key);
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
                _ret_var = ((Bg)wrapper).GetLoaded();
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
                _ret_var = ((Bg)wrapper).Load();
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
                ((Bg)wrapper).Unload();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_unload_delegate efl_file_unload_static_delegate;


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
                _ret_var = ((Bg)wrapper).GetSmoothScale();
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
                ((Bg)wrapper).SetSmoothScale( smooth_scale);
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
                _ret_var = ((Bg)wrapper).GetScaleType();
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
                ((Bg)wrapper).SetScaleType( scale_type);
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
                _ret_var = ((Bg)wrapper).GetRatio();
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
                ((Bg)wrapper).GetBorder( out l,  out r,  out t,  out b);
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
                ((Bg)wrapper).SetBorder( l,  r,  t,  b);
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
                _ret_var = ((Bg)wrapper).GetBorderScale();
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
                ((Bg)wrapper).SetBorderScale( scale);
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
                _ret_var = ((Bg)wrapper).GetBorderCenterFill();
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
                ((Bg)wrapper).SetBorderCenterFill( fill);
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
                _ret_var = ((Bg)wrapper).GetImageSize();
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
                _ret_var = ((Bg)wrapper).GetContentHint();
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
                ((Bg)wrapper).SetContentHint( hint);
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
                _ret_var = ((Bg)wrapper).GetScaleHint();
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
                ((Bg)wrapper).SetScaleHint( hint);
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
                _ret_var = ((Bg)wrapper).GetImageLoadError();
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
                _ret_var = ((Bg)wrapper).GetLoadSize();
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
                ((Bg)wrapper).SetLoadSize( _in_size);
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
                _ret_var = ((Bg)wrapper).GetLoadDpi();
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
                ((Bg)wrapper).SetLoadDpi( dpi);
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
                _ret_var = ((Bg)wrapper).GetLoadRegionSupport();
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
                _ret_var = ((Bg)wrapper).GetLoadRegion();
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
                ((Bg)wrapper).SetLoadRegion( _in_region);
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
                _ret_var = ((Bg)wrapper).GetLoadOrientation();
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
                ((Bg)wrapper).SetLoadOrientation( enable);
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
                _ret_var = ((Bg)wrapper).GetLoadScaleDown();
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
                ((Bg)wrapper).SetLoadScaleDown( div);
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
                _ret_var = ((Bg)wrapper).GetLoadSkipHeader();
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
                ((Bg)wrapper).SetLoadSkipHeader( skip);
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
                ((Bg)wrapper).LoadAsyncStart();
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
                ((Bg)wrapper).LoadAsyncCancel();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_image_load_controller_load_async_cancel_delegate efl_gfx_image_load_controller_load_async_cancel_static_delegate;
}
} } 
