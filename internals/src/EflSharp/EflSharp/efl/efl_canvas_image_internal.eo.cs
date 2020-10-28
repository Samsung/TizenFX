#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Efl canvas internal image class</summary>
[ImageInternalNativeInherit]
public abstract class ImageInternal : Efl.Canvas.Object, Efl.Eo.IWrapper,Efl.IFileSave,Efl.IOrientation,Efl.Canvas.Filter.IInternal,Efl.Gfx.IBuffer,Efl.Gfx.IFill,Efl.Gfx.IFilter,Efl.Gfx.IImage,Efl.Gfx.IView
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (ImageInternal))
                return Efl.Canvas.ImageInternalNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_image_internal_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public ImageInternal(Efl.Object parent= null
            ) :
        base(efl_canvas_image_internal_class_get(), typeof(ImageInternal), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected ImageInternal(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    [Efl.Eo.PrivateNativeClass]
    private class ImageInternalRealized : ImageInternal
    {
        private ImageInternalRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected ImageInternal(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ImagePreloadEvt_delegate = new Efl.EventCb(on_ImagePreloadEvt_NativeCallback);
        evt_ImageResizeEvt_delegate = new Efl.EventCb(on_ImageResizeEvt_NativeCallback);
        evt_ImageUnloadEvt_delegate = new Efl.EventCb(on_ImageUnloadEvt_NativeCallback);
    }
    /// <summary>Save the given image object&apos;s contents to an (image) file.
    /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
    /// 
    /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
    /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
    /// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool Save( System.String file,  System.String key,  ref Efl.FileSaveInfo info) {
                         Efl.FileSaveInfo.NativeStruct _in_info = info;
                                                        var _ret_var = Efl.IFileSaveNativeInherit.efl_file_save_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), file,  key,  ref _in_info);
        Eina.Error.RaiseIfUnhandledException();
                                                info = _in_info;
        return _ret_var;
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
    /// <summary>Marks this filter as changed.</summary>
    /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetFilterChanged( bool val) {
                                 Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_changed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Marks this filter as invalid.</summary>
    /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetFilterInvalid( bool val) {
                                 Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_invalid_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <returns>Output buffer</returns>
    virtual public System.IntPtr GetFilterOutputBuffer() {
         var _ret_var = Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_output_buffer_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FilterInputAlpha() {
         var _ret_var = Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_input_alpha_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
    /// <param name="state">State info to fill in</param>
    /// <param name="data">Private data for the class</param>
    /// <returns></returns>
    virtual public void FilterStatePrepare( out Efl.Canvas.Filter.State state,  System.IntPtr data) {
                         var _out_state = new Efl.Canvas.Filter.State.NativeStruct();
                                Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_state_prepare_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out _out_state,  data);
        Eina.Error.RaiseIfUnhandledException();
        state = _out_state;
                                 }
    /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
    /// <param name="filter">Current filter context</param>
    /// <param name="engine">Engine context</param>
    /// <param name="output">Output context</param>
    /// <param name="drawctx">Draw context (for evas engine)</param>
    /// <param name="data">Private data used by textblock</param>
    /// <param name="l">Left</param>
    /// <param name="r">Right</param>
    /// <param name="t">Top</param>
    /// <param name="b">Bottom</param>
    /// <param name="x">X offset</param>
    /// <param name="y">Y offset</param>
    /// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
    /// <returns>Indicates success from the object render function.</returns>
    virtual public bool FilterInputRender( System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y,  bool do_async) {
                                                                                                                                                                                                                                                                                                         var _ret_var = Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_input_render_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Called when filter changes must trigger a redraw of the object.
    /// Virtual, to be implemented in the parent class.</summary>
    /// <returns></returns>
    virtual public void FilterDirty() {
         Efl.Canvas.Filter.IInternalNativeInherit.evas_filter_dirty_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <returns>Size of the buffer in pixels.</returns>
    virtual public Eina.Size2D GetBufferSize() {
         var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Potentially not implemented, <see cref="Efl.Gfx.IBuffer.BufferSize"/> may be read-only.</summary>
    /// <param name="sz">Size of the buffer in pixels.</param>
    /// <returns></returns>
    virtual public void SetBufferSize( Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns the current encoding of this buffer&apos;s pixels.
    /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
    /// <returns>Colorspace</returns>
    virtual public Efl.Gfx.Colorspace GetColorspace() {
         var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_colorspace_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
    /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
    virtual public bool GetAlpha() {
         var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_alpha_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change alpha channel usage for this object.
    /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
    /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
    /// <returns></returns>
    virtual public void SetAlpha( bool alpha) {
                                 Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_alpha_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), alpha);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <returns>Stride</returns>
    virtual public int GetStride() {
         var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_stride_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    /// <param name="l">Left border pixels, usually 0 or 1</param>
    /// <param name="r">Right border pixels, usually 0 or 1</param>
    /// <param name="t">Top border pixels, usually 0 or 1</param>
    /// <param name="b">Bottom border pixels, usually 0 or 1</param>
    /// <returns></returns>
    virtual public void GetBufferBorders( out uint l,  out uint r,  out uint t,  out uint b) {
                                                                                                         Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_borders_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out l,  out r,  out t,  out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Mark a sub-region of the given image object to be redrawn.
    /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
    /// <param name="region">The updated region.</param>
    /// <returns></returns>
    virtual public void AddBufferUpdate( ref Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_update_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ref _in_region);
        Eina.Error.RaiseIfUnhandledException();
                region = _in_region;
         }
    /// <summary>Map a region of this buffer for read or write access by the CPU.
    /// Fetches data from the GPU if needed. This operation may be slow if cpu_readable_fast or cpu_writeable_fast are not true, or if the required colorspace is different from the internal one.
    /// 
    /// Note that if the buffer has <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/>, then <c>x</c> and <c>y</c> may be negative.</summary>
    /// <param name="mode">Specifies whether to map for read-only, write-only or read-write access (OR combination of flags).</param>
    /// <param name="region">The region to map.</param>
    /// <param name="cspace">Requested colorspace. If different from the internal cspace, map should try to convert the data into a new buffer. argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <param name="stride">Returns the length in bytes of a mapped line</param>
    /// <returns>The data slice. In case of failure, the memory pointer will be <c>null</c>.</returns>
    virtual public Eina.RwSlice BufferMap( Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride) {
                 Eina.Rect.NativeStruct _in_region = region;
                                                                                                                var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_map_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mode,  ref _in_region,  cspace,  plane,  out stride);
        Eina.Error.RaiseIfUnhandledException();
                                                        region = _in_region;
                                return _ret_var;
 }
    /// <summary>Unmap a region of this buffer, and update the internal data if needed.
    /// EFL will update the internal image if the map had write access.
    /// 
    /// Note: The <c>slice</c> struct does not need to be the one returned by <see cref="Efl.Gfx.IBuffer.BufferMap"/>, only its contents (<c>mem</c> and <c>len</c>) must match. But after a call to <see cref="Efl.Gfx.IBuffer.BufferUnmap"/> the original <c>slice</c> structure is not valid anymore.</summary>
    /// <param name="slice">Data slice returned by a previous call to map.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool BufferUnmap( Eina.RwSlice slice) {
                                 var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_unmap_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), slice);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set the pixels for this buffer by copying them, or allocate a new memory region.
    /// This will allocate a new buffer in memory and copy the input <c>pixels</c> to it. The internal colorspace is not guaranteed to be preserved, and colorspace conversion may happen internally.
    /// 
    /// If <c>pixels</c> is <c>null</c>, then a new empty buffer will be allocated. If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// <c>slice</c> should not be the return value of <see cref="Efl.Gfx.IBuffer.GetBufferManaged"/>.</summary>
    /// <param name="slice">If <c>null</c>, allocates an empty buffer</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SetBufferCopy( Eina.Slice slice,  Eina.Size2D size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane) {
         var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
        Eina.Size2D.NativeStruct _in_size = size;
                                                                                                                var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_copy_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_slice,  _in_size,  stride,  cspace,  plane);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Set the pixels for this buffer, managed externally by the client.
    /// EFL will use the pixel data directly, and update the GPU-side texture if required. This will mark the image as dirty. If <c>slice</c> is <c>null</c>, this will detach the pixel data.
    /// 
    /// If the buffer already had pixel data, the previous image data will be dropped. This is the same as <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/>.
    /// 
    /// The memory buffer <c>pixels</c> must be large enough to hold <c>width</c> x <c>height</c> pixels encoded in the colorspace <c>cspace</c>.
    /// 
    /// See also <see cref="Efl.Gfx.IBuffer.SetBufferCopy"/> if you want EFL to copy the input buffer internally.</summary>
    /// <param name="slice">If <c>null</c>, detaches the previous buffer.</param>
    /// <param name="size">The size in pixels.</param>
    /// <param name="stride">If 0, automatically guessed from the <c>width</c>.</param>
    /// <param name="cspace">argb8888 by default.</param>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SetBufferManaged( Eina.Slice slice,  Eina.Size2D size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane) {
         var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
        Eina.Size2D.NativeStruct _in_size = size;
                                                                                                                var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_managed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_slice,  _in_size,  stride,  cspace,  plane);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Get a direct pointer to the internal pixel data, if available.
    /// This will return <c>null</c> unless <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
    virtual public Eina.Slice GetBufferManaged( int plane) {
                                 var _ret_var = Efl.Gfx.IBufferNativeInherit.efl_gfx_buffer_managed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), plane);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
    /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
    /// 
    /// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
    /// 
    /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
    /// <returns><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</returns>
    virtual public bool GetFillAuto() {
         var _ret_var = Efl.Gfx.IFillNativeInherit.efl_gfx_fill_auto_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
    /// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
    /// 
    /// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
    /// 
    /// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
    /// <param name="filled"><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</param>
    /// <returns></returns>
    virtual public void SetFillAuto( bool filled) {
                                 Efl.Gfx.IFillNativeInherit.efl_gfx_fill_auto_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), filled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
    virtual public Eina.Rect GetFill() {
         var _ret_var = Efl.Gfx.IFillNativeInherit.efl_gfx_fill_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
    /// <returns></returns>
    virtual public void SetFill( Eina.Rect fill) {
         Eina.Rect.NativeStruct _in_fill = fill;
                        Efl.Gfx.IFillNativeInherit.efl_gfx_fill_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    /// <returns></returns>
    virtual public void GetFilterProgram( out System.String code,  out System.String name) {
                                                         Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_program_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out code,  out name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set a graphical filter program on this object.
    /// Valid for Text and Image objects at the moment.
    /// 
    /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
    /// 
    /// Set to <c>null</c> to disable filtering.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    /// <returns></returns>
    virtual public void SetFilterProgram( System.String code,  System.String name) {
                                                         Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_program_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), code,  name);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    /// <returns></returns>
    virtual public void GetFilterState( out System.String cur_state,  out double cur_val,  out System.String next_state,  out double next_val,  out double pos) {
                                                                                                                                 Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_state_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <param name="cur_state">Current state of the filter</param>
    /// <param name="cur_val">Current value</param>
    /// <param name="next_state">Next filter state, optional</param>
    /// <param name="next_val">Next value, optional</param>
    /// <param name="pos">Position, optional</param>
    /// <returns></returns>
    virtual public void SetFilterState( System.String cur_state,  double cur_val,  System.String next_state,  double next_val,  double pos) {
                                                                                                                                 Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_state_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cur_state,  cur_val,  next_state,  next_val,  pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Gets the padding required to apply this filter.</summary>
    /// <param name="l">Padding on the left</param>
    /// <param name="r">Padding on the right</param>
    /// <param name="t">Padding on the top</param>
    /// <param name="b">Padding on the bottom</param>
    /// <returns></returns>
    virtual public void GetFilterPadding( out int l,  out int r,  out int t,  out int b) {
                                                                                                         Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_padding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out l,  out r,  out t,  out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <returns>Object to use as a source of pixels.</returns>
    virtual public Efl.Gfx.IEntity GetFilterSource( System.String name) {
                                 var _ret_var = Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_source_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <param name="source">Object to use as a source of pixels.</param>
    /// <returns></returns>
    virtual public void SetFilterSource( System.String name,  Efl.Gfx.IEntity source) {
                                                         Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_source_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    /// <returns></returns>
    virtual public void GetFilterData( System.String name,  out System.String value,  out bool execute) {
                                                                                 Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_data_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  out value,  out execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    /// <returns></returns>
    virtual public void SetFilterData( System.String name,  System.String value,  bool execute) {
                                                                                 Efl.Gfx.IFilterNativeInherit.efl_gfx_filter_data_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), name,  value,  execute);
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
    /// <summary>Marks this filter as changed.</summary>
/// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
    public bool FilterChanged {
        set { SetFilterChanged( value); }
    }
    /// <summary>Marks this filter as invalid.</summary>
/// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
    public bool FilterInvalid {
        set { SetFilterInvalid( value); }
    }
    /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
/// <value>Output buffer</value>
    public System.IntPtr FilterOutputBuffer {
        get { return GetFilterOutputBuffer(); }
    }
    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
/// <value>Size of the buffer in pixels.</value>
    public Eina.Size2D BufferSize {
        get { return GetBufferSize(); }
        set { SetBufferSize( value); }
    }
    /// <summary>The colorspace defines how pixels are encoded in the image in memory.
/// By default, images are encoded in 32-bit BGRA, ie. each pixel takes 4 bytes in memory, with each channel B,G,R,A encoding the color with values from 0 to 255.
/// 
/// All images used in EFL use alpha-premultipied BGRA values, which means that for each pixel, B &lt;= A, G &lt;= A and R &lt;= A.</summary>
/// <value>Colorspace</value>
    public Efl.Gfx.Colorspace Colorspace {
        get { return GetColorspace(); }
    }
    /// <summary>Indicates whether the alpha channel should be used.
/// This does not indicate whether the image source file contains an alpha channel, only whether to respect it or discard it.</summary>
/// <value>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</value>
    public bool Alpha {
        get { return GetAlpha(); }
        set { SetAlpha( value); }
    }
    /// <summary>Length in bytes of one row of pixels in memory.
/// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
/// 
/// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
/// <value>Stride</value>
    public int Stride {
        get { return GetStride(); }
    }
    /// <summary>Binds the object&apos;s <see cref="Efl.Gfx.IFill.Fill"/> property to its actual geometry.
/// If <c>true</c>, then every time the object is resized, it will automatically trigger a call to <see cref="Efl.Gfx.IFill.SetFill"/> with the new size (and 0, 0 as source image&apos;s origin), so the image will cover the whole object&apos;s area.
/// 
/// This property takes precedence over <see cref="Efl.Gfx.IFill.Fill"/>. If set to <c>false</c>, then <see cref="Efl.Gfx.IFill.Fill"/> should be set.
/// 
/// This flag is <c>true</c> by default (used to be <c>false</c> with the old APIs, and was known as &quot;filled&quot;).</summary>
/// <value><c>true</c> to make the fill property follow object size or <c>false</c> otherwise.</value>
    public bool FillAuto {
        get { return GetFillAuto(); }
        set { SetFillAuto( value); }
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
/// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
/// 
/// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
/// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    public Eina.Rect Fill {
        get { return GetFill(); }
        set { SetFill( value); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
    }
}
public class ImageInternalNativeInherit : Efl.Canvas.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_file_save_static_delegate == null)
            efl_file_save_static_delegate = new efl_file_save_delegate(save);
        if (methods.FirstOrDefault(m => m.Name == "Save") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_save"), func = Marshal.GetFunctionPointerForDelegate(efl_file_save_static_delegate)});
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
        if (evas_filter_changed_set_static_delegate == null)
            evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterChanged") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate)});
        if (evas_filter_invalid_set_static_delegate == null)
            evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterInvalid") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate)});
        if (evas_filter_output_buffer_get_static_delegate == null)
            evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterOutputBuffer") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate)});
        if (evas_filter_input_alpha_static_delegate == null)
            evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
        if (methods.FirstOrDefault(m => m.Name == "FilterInputAlpha") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate)});
        if (evas_filter_state_prepare_static_delegate == null)
            evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
        if (methods.FirstOrDefault(m => m.Name == "FilterStatePrepare") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate)});
        if (evas_filter_input_render_static_delegate == null)
            evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
        if (methods.FirstOrDefault(m => m.Name == "FilterInputRender") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate)});
        if (evas_filter_dirty_static_delegate == null)
            evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
        if (methods.FirstOrDefault(m => m.Name == "FilterDirty") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate)});
        if (efl_gfx_buffer_size_get_static_delegate == null)
            efl_gfx_buffer_size_get_static_delegate = new efl_gfx_buffer_size_get_delegate(buffer_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBufferSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_get_static_delegate)});
        if (efl_gfx_buffer_size_set_static_delegate == null)
            efl_gfx_buffer_size_set_static_delegate = new efl_gfx_buffer_size_set_delegate(buffer_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBufferSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_set_static_delegate)});
        if (efl_gfx_buffer_colorspace_get_static_delegate == null)
            efl_gfx_buffer_colorspace_get_static_delegate = new efl_gfx_buffer_colorspace_get_delegate(colorspace_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColorspace") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_colorspace_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_colorspace_get_static_delegate)});
        if (efl_gfx_buffer_alpha_get_static_delegate == null)
            efl_gfx_buffer_alpha_get_static_delegate = new efl_gfx_buffer_alpha_get_delegate(alpha_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAlpha") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_get_static_delegate)});
        if (efl_gfx_buffer_alpha_set_static_delegate == null)
            efl_gfx_buffer_alpha_set_static_delegate = new efl_gfx_buffer_alpha_set_delegate(alpha_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAlpha") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_set_static_delegate)});
        if (efl_gfx_buffer_stride_get_static_delegate == null)
            efl_gfx_buffer_stride_get_static_delegate = new efl_gfx_buffer_stride_get_delegate(stride_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStride") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_stride_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_stride_get_static_delegate)});
        if (efl_gfx_buffer_borders_get_static_delegate == null)
            efl_gfx_buffer_borders_get_static_delegate = new efl_gfx_buffer_borders_get_delegate(buffer_borders_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBufferBorders") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_borders_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_borders_get_static_delegate)});
        if (efl_gfx_buffer_update_add_static_delegate == null)
            efl_gfx_buffer_update_add_static_delegate = new efl_gfx_buffer_update_add_delegate(buffer_update_add);
        if (methods.FirstOrDefault(m => m.Name == "AddBufferUpdate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_update_add"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_update_add_static_delegate)});
        if (efl_gfx_buffer_map_static_delegate == null)
            efl_gfx_buffer_map_static_delegate = new efl_gfx_buffer_map_delegate(buffer_map);
        if (methods.FirstOrDefault(m => m.Name == "BufferMap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_map"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_map_static_delegate)});
        if (efl_gfx_buffer_unmap_static_delegate == null)
            efl_gfx_buffer_unmap_static_delegate = new efl_gfx_buffer_unmap_delegate(buffer_unmap);
        if (methods.FirstOrDefault(m => m.Name == "BufferUnmap") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_unmap"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_unmap_static_delegate)});
        if (efl_gfx_buffer_copy_set_static_delegate == null)
            efl_gfx_buffer_copy_set_static_delegate = new efl_gfx_buffer_copy_set_delegate(buffer_copy_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBufferCopy") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_copy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_copy_set_static_delegate)});
        if (efl_gfx_buffer_managed_set_static_delegate == null)
            efl_gfx_buffer_managed_set_static_delegate = new efl_gfx_buffer_managed_set_delegate(buffer_managed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBufferManaged") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_managed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_set_static_delegate)});
        if (efl_gfx_buffer_managed_get_static_delegate == null)
            efl_gfx_buffer_managed_get_static_delegate = new efl_gfx_buffer_managed_get_delegate(buffer_managed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBufferManaged") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_buffer_managed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_get_static_delegate)});
        if (efl_gfx_fill_auto_get_static_delegate == null)
            efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFillAuto") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate)});
        if (efl_gfx_fill_auto_set_static_delegate == null)
            efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFillAuto") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate)});
        if (efl_gfx_fill_get_static_delegate == null)
            efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate)});
        if (efl_gfx_fill_set_static_delegate == null)
            efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFill") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate)});
        if (efl_gfx_filter_program_get_static_delegate == null)
            efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterProgram") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate)});
        if (efl_gfx_filter_program_set_static_delegate == null)
            efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterProgram") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate)});
        if (efl_gfx_filter_state_get_static_delegate == null)
            efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterState") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate)});
        if (efl_gfx_filter_state_set_static_delegate == null)
            efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterState") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate)});
        if (efl_gfx_filter_padding_get_static_delegate == null)
            efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterPadding") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate)});
        if (efl_gfx_filter_source_get_static_delegate == null)
            efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterSource") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate)});
        if (efl_gfx_filter_source_set_static_delegate == null)
            efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterSource") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate)});
        if (efl_gfx_filter_data_get_static_delegate == null)
            efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFilterData") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate)});
        if (efl_gfx_filter_data_set_static_delegate == null)
            efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFilterData") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate)});
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
        if (efl_gfx_view_size_get_static_delegate == null)
            efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetViewSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate)});
        if (efl_gfx_view_size_set_static_delegate == null)
            efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetViewSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_save_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key,   ref Efl.FileSaveInfo.NativeStruct info);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_save_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key,   ref Efl.FileSaveInfo.NativeStruct info);
     public static Efl.Eo.FunctionWrapper<efl_file_save_api_delegate> efl_file_save_ptr = new Efl.Eo.FunctionWrapper<efl_file_save_api_delegate>(_Module, "efl_file_save");
     private static bool save(System.IntPtr obj, System.IntPtr pd,  System.String file,  System.String key,  ref Efl.FileSaveInfo.NativeStruct info)
    {
        Eina.Log.Debug("function efl_file_save was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    Efl.FileSaveInfo _in_info = info;
                                                            bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).Save( file,  key,  ref _in_info);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                info = _in_info;
        return _ret_var;
        } else {
            return efl_file_save_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file,  key,  ref info);
        }
    }
    private static efl_file_save_delegate efl_file_save_static_delegate;


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
                _ret_var = ((ImageInternal)wrapper).GetOrientation();
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
                ((ImageInternal)wrapper).SetOrientation( dir);
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
                _ret_var = ((ImageInternal)wrapper).GetFlip();
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
                ((ImageInternal)wrapper).SetFlip( flip);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_orientation_flip_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flip);
        }
    }
    private static efl_orientation_flip_set_delegate efl_orientation_flip_set_static_delegate;


     private delegate void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


     public delegate void evas_filter_changed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
     public static Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate> evas_filter_changed_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate>(_Module, "evas_filter_changed_set");
     private static void filter_changed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
    {
        Eina.Log.Debug("function evas_filter_changed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageInternal)wrapper).SetFilterChanged( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            evas_filter_changed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;


     private delegate void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


     public delegate void evas_filter_invalid_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
     public static Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate> evas_filter_invalid_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate>(_Module, "evas_filter_invalid_set");
     private static void filter_invalid_set(System.IntPtr obj, System.IntPtr pd,  bool val)
    {
        Eina.Log.Debug("function evas_filter_invalid_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageInternal)wrapper).SetFilterInvalid( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            evas_filter_invalid_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;


     private delegate System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr evas_filter_output_buffer_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate> evas_filter_output_buffer_get_ptr = new Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate>(_Module, "evas_filter_output_buffer_get");
     private static System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function evas_filter_output_buffer_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.IntPtr _ret_var = default(System.IntPtr);
            try {
                _ret_var = ((ImageInternal)wrapper).GetFilterOutputBuffer();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return evas_filter_output_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool evas_filter_input_alpha_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate> evas_filter_input_alpha_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate>(_Module, "evas_filter_input_alpha");
     private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function evas_filter_input_alpha was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).FilterInputAlpha();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return evas_filter_input_alpha_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;


     private delegate void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Canvas.Filter.State.NativeStruct state,   System.IntPtr data);


     public delegate void evas_filter_state_prepare_api_delegate(System.IntPtr obj,   out Efl.Canvas.Filter.State.NativeStruct state,   System.IntPtr data);
     public static Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate> evas_filter_state_prepare_ptr = new Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate>(_Module, "evas_filter_state_prepare");
     private static void filter_state_prepare(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data)
    {
        Eina.Log.Debug("function evas_filter_state_prepare was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                                    
            try {
                ((ImageInternal)wrapper).FilterStatePrepare( out _out_state,  data);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        state = _out_state;
                                        } else {
            evas_filter_state_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out state,  data);
        }
    }
    private static evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool evas_filter_input_render_api_delegate(System.IntPtr obj,   System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);
     public static Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate> evas_filter_input_render_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate>(_Module, "evas_filter_input_render");
     private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y,  bool do_async)
    {
        Eina.Log.Debug("function evas_filter_input_render was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                                                                                                                                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).FilterInputRender( filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                                                                                                                        return _ret_var;
        } else {
            return evas_filter_input_render_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
        }
    }
    private static evas_filter_input_render_delegate evas_filter_input_render_static_delegate;


     private delegate void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void evas_filter_dirty_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate> evas_filter_dirty_ptr = new Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate>(_Module, "evas_filter_dirty");
     private static void filter_dirty(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function evas_filter_dirty was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((ImageInternal)wrapper).FilterDirty();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            evas_filter_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static evas_filter_dirty_delegate evas_filter_dirty_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate> efl_gfx_buffer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate>(_Module, "efl_gfx_buffer_size_get");
     private static Eina.Size2D.NativeStruct buffer_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_buffer_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((ImageInternal)wrapper).GetBufferSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_buffer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_buffer_size_get_delegate efl_gfx_buffer_size_get_static_delegate;


     private delegate void efl_gfx_buffer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct sz);


     public delegate void efl_gfx_buffer_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct sz);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate> efl_gfx_buffer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate>(_Module, "efl_gfx_buffer_size_set");
     private static void buffer_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz)
    {
        Eina.Log.Debug("function efl_gfx_buffer_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_sz = sz;
                            
            try {
                ((ImageInternal)wrapper).SetBufferSize( _in_sz);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_buffer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
        }
    }
    private static efl_gfx_buffer_size_set_delegate efl_gfx_buffer_size_set_static_delegate;


     private delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate> efl_gfx_buffer_colorspace_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate>(_Module, "efl_gfx_buffer_colorspace_get");
     private static Efl.Gfx.Colorspace colorspace_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_buffer_colorspace_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.Colorspace _ret_var = default(Efl.Gfx.Colorspace);
            try {
                _ret_var = ((ImageInternal)wrapper).GetColorspace();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_buffer_colorspace_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_buffer_colorspace_get_delegate efl_gfx_buffer_colorspace_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_buffer_alpha_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate> efl_gfx_buffer_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate>(_Module, "efl_gfx_buffer_alpha_get");
     private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_buffer_alpha_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).GetAlpha();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_buffer_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_buffer_alpha_get_delegate efl_gfx_buffer_alpha_get_static_delegate;


     private delegate void efl_gfx_buffer_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);


     public delegate void efl_gfx_buffer_alpha_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate> efl_gfx_buffer_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate>(_Module, "efl_gfx_buffer_alpha_set");
     private static void alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
    {
        Eina.Log.Debug("function efl_gfx_buffer_alpha_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageInternal)wrapper).SetAlpha( alpha);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_buffer_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
        }
    }
    private static efl_gfx_buffer_alpha_set_delegate efl_gfx_buffer_alpha_set_static_delegate;


     private delegate int efl_gfx_buffer_stride_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_gfx_buffer_stride_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate> efl_gfx_buffer_stride_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate>(_Module, "efl_gfx_buffer_stride_get");
     private static int stride_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_buffer_stride_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((ImageInternal)wrapper).GetStride();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_buffer_stride_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_buffer_stride_get_delegate efl_gfx_buffer_stride_get_static_delegate;


     private delegate void efl_gfx_buffer_borders_get_delegate(System.IntPtr obj, System.IntPtr pd,   out uint l,   out uint r,   out uint t,   out uint b);


     public delegate void efl_gfx_buffer_borders_get_api_delegate(System.IntPtr obj,   out uint l,   out uint r,   out uint t,   out uint b);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate> efl_gfx_buffer_borders_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate>(_Module, "efl_gfx_buffer_borders_get");
     private static void buffer_borders_get(System.IntPtr obj, System.IntPtr pd,  out uint l,  out uint r,  out uint t,  out uint b)
    {
        Eina.Log.Debug("function efl_gfx_buffer_borders_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    l = default(uint);        r = default(uint);        t = default(uint);        b = default(uint);                                            
            try {
                ((ImageInternal)wrapper).GetBufferBorders( out l,  out r,  out t,  out b);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_buffer_borders_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
        }
    }
    private static efl_gfx_buffer_borders_get_delegate efl_gfx_buffer_borders_get_static_delegate;


     private delegate void efl_gfx_buffer_update_add_delegate(System.IntPtr obj, System.IntPtr pd,   ref Eina.Rect.NativeStruct region);


     public delegate void efl_gfx_buffer_update_add_api_delegate(System.IntPtr obj,   ref Eina.Rect.NativeStruct region);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate> efl_gfx_buffer_update_add_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate>(_Module, "efl_gfx_buffer_update_add");
     private static void buffer_update_add(System.IntPtr obj, System.IntPtr pd,  ref Eina.Rect.NativeStruct region)
    {
        Eina.Log.Debug("function efl_gfx_buffer_update_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_region = region;
                            
            try {
                ((ImageInternal)wrapper).AddBufferUpdate( ref _in_region);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                region = _in_region;
                } else {
            efl_gfx_buffer_update_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref region);
        }
    }
    private static efl_gfx_buffer_update_add_delegate efl_gfx_buffer_update_add_static_delegate;


     private delegate Eina.RwSlice efl_gfx_buffer_map_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect.NativeStruct region,   Efl.Gfx.Colorspace cspace,   int plane,   out int stride);


     public delegate Eina.RwSlice efl_gfx_buffer_map_api_delegate(System.IntPtr obj,   Efl.Gfx.BufferAccessMode mode,   ref Eina.Rect.NativeStruct region,   Efl.Gfx.Colorspace cspace,   int plane,   out int stride);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate> efl_gfx_buffer_map_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate>(_Module, "efl_gfx_buffer_map");
     private static Eina.RwSlice buffer_map(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect.NativeStruct region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride)
    {
        Eina.Log.Debug("function efl_gfx_buffer_map was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                            Eina.Rect _in_region = region;
                                                                stride = default(int);                                                    Eina.RwSlice _ret_var = default(Eina.RwSlice);
            try {
                _ret_var = ((ImageInternal)wrapper).BufferMap( mode,  ref _in_region,  cspace,  plane,  out stride);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        region = _in_region;
                                return _ret_var;
        } else {
            return efl_gfx_buffer_map_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  ref region,  cspace,  plane,  out stride);
        }
    }
    private static efl_gfx_buffer_map_delegate efl_gfx_buffer_map_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_unmap_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.RwSlice slice);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_buffer_unmap_api_delegate(System.IntPtr obj,   Eina.RwSlice slice);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate> efl_gfx_buffer_unmap_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate>(_Module, "efl_gfx_buffer_unmap");
     private static bool buffer_unmap(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice)
    {
        Eina.Log.Debug("function efl_gfx_buffer_unmap was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).BufferUnmap( slice);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gfx_buffer_unmap_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice);
        }
    }
    private static efl_gfx_buffer_unmap_delegate efl_gfx_buffer_unmap_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_copy_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,   Eina.Size2D.NativeStruct size,   int stride,   Efl.Gfx.Colorspace cspace,   int plane);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_buffer_copy_set_api_delegate(System.IntPtr obj,   System.IntPtr slice,   Eina.Size2D.NativeStruct size,   int stride,   Efl.Gfx.Colorspace cspace,   int plane);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate> efl_gfx_buffer_copy_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate>(_Module, "efl_gfx_buffer_copy_set");
     private static bool buffer_copy_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane)
    {
        Eina.Log.Debug("function efl_gfx_buffer_copy_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
        Eina.Size2D _in_size = size;
                                                                                                                    bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).SetBufferCopy( _in_slice,  _in_size,  stride,  cspace,  plane);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                        return _ret_var;
        } else {
            return efl_gfx_buffer_copy_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
        }
    }
    private static efl_gfx_buffer_copy_set_delegate efl_gfx_buffer_copy_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_buffer_managed_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr slice,   Eina.Size2D.NativeStruct size,   int stride,   Efl.Gfx.Colorspace cspace,   int plane);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_buffer_managed_set_api_delegate(System.IntPtr obj,   System.IntPtr slice,   Eina.Size2D.NativeStruct size,   int stride,   Efl.Gfx.Colorspace cspace,   int plane);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate> efl_gfx_buffer_managed_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate>(_Module, "efl_gfx_buffer_managed_set");
     private static bool buffer_managed_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane)
    {
        Eina.Log.Debug("function efl_gfx_buffer_managed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
        Eina.Size2D _in_size = size;
                                                                                                                    bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).SetBufferManaged( _in_slice,  _in_size,  stride,  cspace,  plane);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                        return _ret_var;
        } else {
            return efl_gfx_buffer_managed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  slice,  size,  stride,  cspace,  plane);
        }
    }
    private static efl_gfx_buffer_managed_set_delegate efl_gfx_buffer_managed_set_static_delegate;


     private delegate Eina.Slice efl_gfx_buffer_managed_get_delegate(System.IntPtr obj, System.IntPtr pd,   int plane);


     public delegate Eina.Slice efl_gfx_buffer_managed_get_api_delegate(System.IntPtr obj,   int plane);
     public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate> efl_gfx_buffer_managed_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate>(_Module, "efl_gfx_buffer_managed_get");
     private static Eina.Slice buffer_managed_get(System.IntPtr obj, System.IntPtr pd,  int plane)
    {
        Eina.Log.Debug("function efl_gfx_buffer_managed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Eina.Slice _ret_var = default(Eina.Slice);
            try {
                _ret_var = ((ImageInternal)wrapper).GetBufferManaged( plane);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gfx_buffer_managed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  plane);
        }
    }
    private static efl_gfx_buffer_managed_get_delegate efl_gfx_buffer_managed_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_fill_auto_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate> efl_gfx_fill_auto_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate>(_Module, "efl_gfx_fill_auto_get");
     private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((ImageInternal)wrapper).GetFillAuto();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_fill_auto_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;


     private delegate void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool filled);


     public delegate void efl_gfx_fill_auto_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool filled);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate> efl_gfx_fill_auto_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate>(_Module, "efl_gfx_fill_auto_set");
     private static void fill_auto_set(System.IntPtr obj, System.IntPtr pd,  bool filled)
    {
        Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((ImageInternal)wrapper).SetFillAuto( filled);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_fill_auto_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filled);
        }
    }
    private static efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_gfx_fill_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate> efl_gfx_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate>(_Module, "efl_gfx_fill_get");
     private static Eina.Rect.NativeStruct fill_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_fill_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((ImageInternal)wrapper).GetFill();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;


     private delegate void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct fill);


     public delegate void efl_gfx_fill_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct fill);
     public static Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate> efl_gfx_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate>(_Module, "efl_gfx_fill_set");
     private static void fill_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct fill)
    {
        Eina.Log.Debug("function efl_gfx_fill_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_fill = fill;
                            
            try {
                ((ImageInternal)wrapper).SetFill( _in_fill);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  fill);
        }
    }
    private static efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;


     private delegate void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String name);


     public delegate void efl_gfx_filter_program_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String name);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate> efl_gfx_filter_program_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate>(_Module, "efl_gfx_filter_program_get");
     private static void filter_program_get(System.IntPtr obj, System.IntPtr pd,  out System.String code,  out System.String name)
    {
        Eina.Log.Debug("function efl_gfx_filter_program_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    System.String _out_code = default(System.String);
        System.String _out_name = default(System.String);
                            
            try {
                ((ImageInternal)wrapper).GetFilterProgram( out _out_code,  out _out_name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        code = _out_code;
        name = _out_name;
                                } else {
            efl_gfx_filter_program_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out code,  out name);
        }
    }
    private static efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;


     private delegate void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);


     public delegate void efl_gfx_filter_program_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate> efl_gfx_filter_program_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate>(_Module, "efl_gfx_filter_program_set");
     private static void filter_program_set(System.IntPtr obj, System.IntPtr pd,  System.String code,  System.String name)
    {
        Eina.Log.Debug("function efl_gfx_filter_program_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageInternal)wrapper).SetFilterProgram( code,  name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_filter_program_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code,  name);
        }
    }
    private static efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;


     private delegate void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String next_state,   out double next_val,   out double pos);


     public delegate void efl_gfx_filter_state_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String next_state,   out double next_val,   out double pos);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate> efl_gfx_filter_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate>(_Module, "efl_gfx_filter_state_get");
     private static void filter_state_get(System.IntPtr obj, System.IntPtr pd,  out System.String cur_state,  out double cur_val,  out System.String next_state,  out double next_val,  out double pos)
    {
        Eina.Log.Debug("function efl_gfx_filter_state_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                            System.String _out_cur_state = default(System.String);
        cur_val = default(double);        System.String _out_next_state = default(System.String);
        next_val = default(double);        pos = default(double);                                                    
            try {
                ((ImageInternal)wrapper).GetFilterState( out _out_cur_state,  out cur_val,  out _out_next_state,  out next_val,  out pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        cur_state = _out_cur_state;
                next_state = _out_next_state;
                                                                        } else {
            efl_gfx_filter_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
        }
    }
    private static efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;


     private delegate void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String next_state,   double next_val,   double pos);


     public delegate void efl_gfx_filter_state_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String next_state,   double next_val,   double pos);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate> efl_gfx_filter_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate>(_Module, "efl_gfx_filter_state_set");
     private static void filter_state_set(System.IntPtr obj, System.IntPtr pd,  System.String cur_state,  double cur_val,  System.String next_state,  double next_val,  double pos)
    {
        Eina.Log.Debug("function efl_gfx_filter_state_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                
            try {
                ((ImageInternal)wrapper).SetFilterState( cur_state,  cur_val,  next_state,  next_val,  pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                                } else {
            efl_gfx_filter_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur_state,  cur_val,  next_state,  next_val,  pos);
        }
    }
    private static efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;


     private delegate void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out int l,   out int r,   out int t,   out int b);


     public delegate void efl_gfx_filter_padding_get_api_delegate(System.IntPtr obj,   out int l,   out int r,   out int t,   out int b);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate> efl_gfx_filter_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate>(_Module, "efl_gfx_filter_padding_get");
     private static void filter_padding_get(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b)
    {
        Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
            try {
                ((ImageInternal)wrapper).GetFilterPadding( out l,  out r,  out t,  out b);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_filter_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
        }
    }
    private static efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate> efl_gfx_filter_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate>(_Module, "efl_gfx_filter_source_get");
     private static Efl.Gfx.IEntity filter_source_get(System.IntPtr obj, System.IntPtr pd,  System.String name)
    {
        Eina.Log.Debug("function efl_gfx_filter_source_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((ImageInternal)wrapper).GetFilterSource( name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_gfx_filter_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
        }
    }
    private static efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;


     private delegate void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity source);


     public delegate void efl_gfx_filter_source_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity source);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate> efl_gfx_filter_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate>(_Module, "efl_gfx_filter_source_set");
     private static void filter_source_set(System.IntPtr obj, System.IntPtr pd,  System.String name,  Efl.Gfx.IEntity source)
    {
        Eina.Log.Debug("function efl_gfx_filter_source_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((ImageInternal)wrapper).SetFilterSource( name,  source);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_filter_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  source);
        }
    }
    private static efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;


     private delegate void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);


     public delegate void efl_gfx_filter_data_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate> efl_gfx_filter_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate>(_Module, "efl_gfx_filter_data_get");
     private static void filter_data_get(System.IntPtr obj, System.IntPtr pd,  System.String name,  out System.String value,  out bool execute)
    {
        Eina.Log.Debug("function efl_gfx_filter_data_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    System.String _out_value = default(System.String);
        execute = default(bool);                                    
            try {
                ((ImageInternal)wrapper).GetFilterData( name,  out _out_value,  out execute);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                value = _out_value;
                                                } else {
            efl_gfx_filter_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  out value,  out execute);
        }
    }
    private static efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;


     private delegate void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);


     public delegate void efl_gfx_filter_data_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
     public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate> efl_gfx_filter_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate>(_Module, "efl_gfx_filter_data_set");
     private static void filter_data_set(System.IntPtr obj, System.IntPtr pd,  System.String name,  System.String value,  bool execute)
    {
        Eina.Log.Debug("function efl_gfx_filter_data_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((ImageInternal)wrapper).SetFilterData( name,  value,  execute);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_gfx_filter_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  value,  execute);
        }
    }
    private static efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;


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
                _ret_var = ((ImageInternal)wrapper).GetSmoothScale();
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
                ((ImageInternal)wrapper).SetSmoothScale( smooth_scale);
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
                _ret_var = ((ImageInternal)wrapper).GetScaleType();
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
                ((ImageInternal)wrapper).SetScaleType( scale_type);
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
                _ret_var = ((ImageInternal)wrapper).GetRatio();
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
                ((ImageInternal)wrapper).GetBorder( out l,  out r,  out t,  out b);
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
                ((ImageInternal)wrapper).SetBorder( l,  r,  t,  b);
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
                _ret_var = ((ImageInternal)wrapper).GetBorderScale();
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
                ((ImageInternal)wrapper).SetBorderScale( scale);
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
                _ret_var = ((ImageInternal)wrapper).GetBorderCenterFill();
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
                ((ImageInternal)wrapper).SetBorderCenterFill( fill);
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
                _ret_var = ((ImageInternal)wrapper).GetImageSize();
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
                _ret_var = ((ImageInternal)wrapper).GetContentHint();
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
                ((ImageInternal)wrapper).SetContentHint( hint);
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
                _ret_var = ((ImageInternal)wrapper).GetScaleHint();
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
                ((ImageInternal)wrapper).SetScaleHint( hint);
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
                _ret_var = ((ImageInternal)wrapper).GetImageLoadError();
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
                _ret_var = ((ImageInternal)wrapper).GetViewSize();
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
                ((ImageInternal)wrapper).SetViewSize( _in_size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_view_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;
}
} } 
