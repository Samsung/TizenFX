#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl canvas internal image class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.ImageInternal.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class ImageInternal : Efl.Canvas.Object, Efl.IFileSave, Efl.Canvas.Filter.IInternal, Efl.Gfx.IBuffer, Efl.Gfx.IFill, Efl.Gfx.IFilter, Efl.Gfx.IImage, Efl.Gfx.IImageOrientable, Efl.Gfx.IView
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ImageInternal))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_image_internal_class_get();
    /// <summary>Initializes a new instance of the <see cref="ImageInternal"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ImageInternal(Efl.Object parent= null
            ) : base(efl_canvas_image_internal_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ImageInternal(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ImageInternal"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ImageInternal(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class ImageInternalRealized : ImageInternal
    {
        private ImageInternalRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="ImageInternal"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ImageInternal(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImagePreloadEvt.</summary>
    public void OnImagePreloadEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageResizeEvt.</summary>
    public void OnImageResizeEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event ImageUnloadEvt.</summary>
    public void OnImageUnloadEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_EVENT_IMAGE_UNLOAD";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
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
    virtual public bool Save(System.String file, System.String key, ref Efl.FileSaveInfo info) {
                         Efl.FileSaveInfo.NativeStruct _in_info = info;
                                                        var _ret_var = Efl.IFileSaveConcrete.NativeMethods.efl_file_save_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file, key, ref _in_info);
        Eina.Error.RaiseIfUnhandledException();
                                                info = _in_info;
        return _ret_var;
 }
    /// <summary>Marks this filter as changed.</summary>
    /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
    virtual public void SetFilterChanged(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_changed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Marks this filter as invalid.</summary>
    /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
    virtual public void SetFilterInvalid(bool val) {
                                 Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_invalid_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieve cached output buffer, if any.
    /// Does not increment the reference count.</summary>
    /// <returns>Output buffer</returns>
    virtual public System.IntPtr GetFilterOutputBuffer() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_output_buffer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FilterInputAlpha() {
         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_alpha_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
    /// <param name="state">State info to fill in</param>
    /// <param name="data">Private data for the class</param>
    virtual public void FilterStatePrepare(out Efl.Canvas.Filter.State state, System.IntPtr data) {
                         var _out_state = new Efl.Canvas.Filter.State.NativeStruct();
                                Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_state_prepare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out _out_state, data);
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
    virtual public bool FilterInputRender(System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async) {
                                                                                                                                                                                                                                                                                                         var _ret_var = Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_input_render_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                                                        return _ret_var;
 }
    /// <summary>Called when filter changes must trigger a redraw of the object.
    /// Virtual, to be implemented in the parent class.</summary>
    virtual public void FilterDirty() {
         Efl.Canvas.Filter.IInternalConcrete.NativeMethods.evas_filter_dirty_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Rectangular size of the pixel buffer as allocated in memory.</summary>
    /// <returns>Size of the buffer in pixels.</returns>
    virtual public Eina.Size2D GetBufferSize() {
         var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Potentially not implemented, <see cref="Efl.Gfx.IBuffer.BufferSize"/> may be read-only.</summary>
    /// <param name="sz">Size of the buffer in pixels.</param>
    virtual public void SetBufferSize(Eina.Size2D sz) {
         Eina.Size2D.NativeStruct _in_sz = sz;
                        Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_sz);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns the current encoding of this buffer&apos;s pixels.
    /// See <see cref="Efl.Gfx.Colorspace"/> for more information on the supported formats.</summary>
    /// <returns>Colorspace</returns>
    virtual public Efl.Gfx.Colorspace GetColorspace() {
         var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_colorspace_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieve whether alpha channel data is used on this object.</summary>
    /// <returns>Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</returns>
    virtual public bool GetAlpha() {
         var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change alpha channel usage for this object.
    /// This function sets a flag on an image object indicating whether or not to use alpha channel data. A value of <c>true</c> makes it use alpha channel data, and <c>false</c> makes it ignore that data. Note that this has nothing to do with an object&apos;s color as manipulated by <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
    /// <param name="alpha">Whether to use alpha channel (<c>true</c>) data or not (<c>false</c>).</param>
    virtual public void SetAlpha(bool alpha) {
                                 Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),alpha);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <returns>Stride</returns>
    virtual public int GetStride() {
         var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_stride_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    /// <param name="l">Left border pixels, usually 0 or 1</param>
    /// <param name="r">Right border pixels, usually 0 or 1</param>
    /// <param name="t">Top border pixels, usually 0 or 1</param>
    /// <param name="b">Bottom border pixels, usually 0 or 1</param>
    virtual public void GetBufferBorders(out uint l, out uint r, out uint t, out uint b) {
                                                                                                         Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_borders_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Mark a sub-region of the given image object to be redrawn.
    /// This function schedules a particular rectangular region of an image object to be updated (redrawn) at the next rendering cycle.</summary>
    /// <param name="region">The updated region.</param>
    virtual public void AddBufferUpdate(ref Eina.Rect region) {
         Eina.Rect.NativeStruct _in_region = region;
                        Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_update_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_region);
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
    virtual public Eina.RwSlice BufferMap(Efl.Gfx.BufferAccessMode mode, ref Eina.Rect region, Efl.Gfx.Colorspace cspace, int plane, out int stride) {
                 Eina.Rect.NativeStruct _in_region = region;
                                                                                                                var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_map_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode, ref _in_region, cspace, plane, out stride);
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
    virtual public bool BufferUnmap(Eina.RwSlice slice) {
                                 var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_unmap_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),slice);
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
    virtual public bool SetBufferCopy(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane) {
         var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
        Eina.Size2D.NativeStruct _in_size = size;
                                                                                                                var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_copy_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_slice, _in_size, stride, cspace, plane);
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
    virtual public bool SetBufferManaged(Eina.Slice slice, Eina.Size2D size, int stride, Efl.Gfx.Colorspace cspace, int plane) {
         var _in_slice = Eina.PrimitiveConversion.ManagedToPointerAlloc(slice);
        Eina.Size2D.NativeStruct _in_size = size;
                                                                                                                var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_managed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_slice, _in_size, stride, cspace, plane);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Get a direct pointer to the internal pixel data, if available.
    /// This will return <c>null</c> unless <see cref="Efl.Gfx.IBuffer.SetBufferManaged"/> was used to pass in an external data pointer.</summary>
    /// <param name="plane">Plane ID. 0 by default. Useful for planar formats only.</param>
    /// <returns>The data slice. The memory pointer will be <c>null</c> in case of failure.</returns>
    virtual public Eina.Slice GetBufferManaged(int plane) {
                                 var _ret_var = Efl.Gfx.IBufferConcrete.NativeMethods.efl_gfx_buffer_managed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),plane);
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
         var _ret_var = Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_auto_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    virtual public void SetFillAuto(bool filled) {
                                 Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_auto_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),filled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <returns>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</returns>
    virtual public Eina.Rect GetFill() {
         var _ret_var = Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <param name="fill">The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</param>
    virtual public void SetFill(Eina.Rect fill) {
         Eina.Rect.NativeStruct _in_fill = fill;
                        Efl.Gfx.IFillConcrete.NativeMethods.efl_gfx_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_fill);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <param name="code">The Lua program source code.</param>
    /// <param name="name">An optional name for this filter.</param>
    virtual public void GetFilterProgram(out System.String code, out System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out code, out name);
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
    virtual public void SetFilterProgram(System.String code, System.String name) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_program_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code, name);
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
    virtual public void GetFilterState(out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out cur_state, out cur_val, out next_state, out next_val, out pos);
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
    virtual public void SetFilterState(System.String cur_state, double cur_val, System.String next_state, double next_val, double pos) {
                                                                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_state_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cur_state, cur_val, next_state, next_val, pos);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Gets the padding required to apply this filter.</summary>
    /// <param name="l">Padding on the left</param>
    /// <param name="r">Padding on the right</param>
    /// <param name="t">Padding on the top</param>
    /// <param name="b">Padding on the bottom</param>
    virtual public void GetFilterPadding(out int l, out int r, out int t, out int b) {
                                                                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out l, out r, out t, out b);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <returns>Object to use as a source of pixels.</returns>
    virtual public Efl.Gfx.IEntity GetFilterSource(System.String name) {
                                 var _ret_var = Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Bind an object to use as a mask or texture in a filter program.
    /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).</summary>
    /// <param name="name">Buffer name as used in the program.</param>
    /// <param name="source">Object to use as a source of pixels.</param>
    virtual public void SetFilterSource(System.String name, Efl.Gfx.IEntity source) {
                                                         Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, source);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void GetFilterData(System.String name, out System.String value, out bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, out value, out execute);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Extra data used by the filter program.
    /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
    /// 
    /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.</summary>
    /// <param name="name">Name of the global variable</param>
    /// <param name="value">String value to use as data</param>
    /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;</param>
    virtual public void SetFilterData(System.String name, System.String value, bool execute) {
                                                                                 Efl.Gfx.IFilterConcrete.NativeMethods.efl_gfx_filter_data_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, value, execute);
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
    /// <summary>Marks this filter as changed.</summary>
    /// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
    public bool FilterChanged {
        set { SetFilterChanged(value); }
    }
    /// <summary>Marks this filter as invalid.</summary>
    /// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
    public bool FilterInvalid {
        set { SetFilterInvalid(value); }
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
        set { SetBufferSize(value); }
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
        set { SetAlpha(value); }
    }
    /// <summary>Length in bytes of one row of pixels in memory.
    /// Usually this will be equal to width * 4, with a plain BGRA image. This may return 0 if the stride is not applicable.
    /// 
    /// When applicable, this will include the <see cref="Efl.Gfx.IBuffer.GetBufferBorders"/> as well as potential extra padding.</summary>
    /// <value>Stride</value>
    public int Stride {
        get { return GetStride(); }
    }
    /// <summary>Duplicated pixel borders inside this buffer.
    /// Internally, EFL may require an image to have its border pixels duplicated, in particular for GL textures. This property exposes the internal duplicated borders to allow calling <see cref="Efl.Gfx.IBuffer.BufferMap"/> with the entire pixel data, including those edge pixels.</summary>
    public (uint, uint, uint, uint) BufferBorders {
        get {
            uint _out_l = default(uint);
            uint _out_r = default(uint);
            uint _out_t = default(uint);
            uint _out_b = default(uint);
            GetBufferBorders(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
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
        set { SetFillAuto(value); }
    }
    /// <summary>Specifies how to tile an image to fill its rectangle geometry.
    /// Note that if <c>w</c> or <c>h</c> are smaller than the dimensions of the object, the displayed image will be tiled around the object&apos;s area. To have only one copy of the bound image drawn, <c>x</c> and <c>y</c> must be 0 and <c>w</c> and <c>h</c> need to be the exact width and height of the image object itself, respectively.
    /// 
    /// Setting this property will reset the <see cref="Efl.Gfx.IFill.FillAuto"/> to <c>false</c>.</summary>
    /// <value>The top-left corner to start drawing from as well as the size at which the bound image will be displayed.</value>
    public Eina.Rect Fill {
        get { return GetFill(); }
        set { SetFill(value); }
    }
    /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.</summary>
    /// <value>The Lua program source code.</value>
    public (System.String, System.String) FilterProgram {
        get {
            System.String _out_code = default(System.String);
            System.String _out_name = default(System.String);
            GetFilterProgram(out _out_code,out _out_name);
            return (_out_code,_out_name);
        }
        set { SetFilterProgram( value.Item1,  value.Item2); }
    }
    /// <summary>Set the current state of the filter.
    /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
    /// 
    /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.</summary>
    /// <value>Current state of the filter</value>
    public (System.String, double, System.String, double, double) FilterState {
        get {
            System.String _out_cur_state = default(System.String);
            double _out_cur_val = default(double);
            System.String _out_next_state = default(System.String);
            double _out_next_val = default(double);
            double _out_pos = default(double);
            GetFilterState(out _out_cur_state,out _out_cur_val,out _out_next_state,out _out_next_val,out _out_pos);
            return (_out_cur_state,_out_cur_val,_out_next_state,_out_next_val,_out_pos);
        }
        set { SetFilterState( value.Item1,  value.Item2,  value.Item3,  value.Item4,  value.Item5); }
    }
    /// <summary>Required padding to apply this filter without cropping.
    /// Read-only property that can be used to calculate the object&apos;s final geometry. This can be overridden (set) from inside the filter program by using the function &apos;padding_set&apos; in the Lua program.</summary>
    public (int, int, int, int) FilterPadding {
        get {
            int _out_l = default(int);
            int _out_r = default(int);
            int _out_t = default(int);
            int _out_b = default(int);
            GetFilterPadding(out _out_l,out _out_r,out _out_t,out _out_b);
            return (_out_l,_out_r,_out_t,_out_b);
        }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_file_save_static_delegate == null)
            {
                efl_file_save_static_delegate = new efl_file_save_delegate(save);
            }

            if (methods.FirstOrDefault(m => m.Name == "Save") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_save"), func = Marshal.GetFunctionPointerForDelegate(efl_file_save_static_delegate) });
            }

            if (evas_filter_changed_set_static_delegate == null)
            {
                evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterChanged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate) });
            }

            if (evas_filter_invalid_set_static_delegate == null)
            {
                evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterInvalid") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate) });
            }

            if (evas_filter_output_buffer_get_static_delegate == null)
            {
                evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterOutputBuffer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate) });
            }

            if (evas_filter_input_alpha_static_delegate == null)
            {
                evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate) });
            }

            if (evas_filter_state_prepare_static_delegate == null)
            {
                evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterStatePrepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate) });
            }

            if (evas_filter_input_render_static_delegate == null)
            {
                evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterInputRender") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate) });
            }

            if (evas_filter_dirty_static_delegate == null)
            {
                evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "FilterDirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate) });
            }

            if (efl_gfx_buffer_size_get_static_delegate == null)
            {
                efl_gfx_buffer_size_get_static_delegate = new efl_gfx_buffer_size_get_delegate(buffer_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_get_static_delegate) });
            }

            if (efl_gfx_buffer_size_set_static_delegate == null)
            {
                efl_gfx_buffer_size_set_static_delegate = new efl_gfx_buffer_size_set_delegate(buffer_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_size_set_static_delegate) });
            }

            if (efl_gfx_buffer_colorspace_get_static_delegate == null)
            {
                efl_gfx_buffer_colorspace_get_static_delegate = new efl_gfx_buffer_colorspace_get_delegate(colorspace_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetColorspace") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_colorspace_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_colorspace_get_static_delegate) });
            }

            if (efl_gfx_buffer_alpha_get_static_delegate == null)
            {
                efl_gfx_buffer_alpha_get_static_delegate = new efl_gfx_buffer_alpha_get_delegate(alpha_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_get_static_delegate) });
            }

            if (efl_gfx_buffer_alpha_set_static_delegate == null)
            {
                efl_gfx_buffer_alpha_set_static_delegate = new efl_gfx_buffer_alpha_set_delegate(alpha_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_alpha_set_static_delegate) });
            }

            if (efl_gfx_buffer_stride_get_static_delegate == null)
            {
                efl_gfx_buffer_stride_get_static_delegate = new efl_gfx_buffer_stride_get_delegate(stride_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStride") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_stride_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_stride_get_static_delegate) });
            }

            if (efl_gfx_buffer_borders_get_static_delegate == null)
            {
                efl_gfx_buffer_borders_get_static_delegate = new efl_gfx_buffer_borders_get_delegate(buffer_borders_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferBorders") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_borders_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_borders_get_static_delegate) });
            }

            if (efl_gfx_buffer_update_add_static_delegate == null)
            {
                efl_gfx_buffer_update_add_static_delegate = new efl_gfx_buffer_update_add_delegate(buffer_update_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddBufferUpdate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_update_add"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_update_add_static_delegate) });
            }

            if (efl_gfx_buffer_map_static_delegate == null)
            {
                efl_gfx_buffer_map_static_delegate = new efl_gfx_buffer_map_delegate(buffer_map);
            }

            if (methods.FirstOrDefault(m => m.Name == "BufferMap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_map"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_map_static_delegate) });
            }

            if (efl_gfx_buffer_unmap_static_delegate == null)
            {
                efl_gfx_buffer_unmap_static_delegate = new efl_gfx_buffer_unmap_delegate(buffer_unmap);
            }

            if (methods.FirstOrDefault(m => m.Name == "BufferUnmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_unmap"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_unmap_static_delegate) });
            }

            if (efl_gfx_buffer_copy_set_static_delegate == null)
            {
                efl_gfx_buffer_copy_set_static_delegate = new efl_gfx_buffer_copy_set_delegate(buffer_copy_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferCopy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_copy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_copy_set_static_delegate) });
            }

            if (efl_gfx_buffer_managed_set_static_delegate == null)
            {
                efl_gfx_buffer_managed_set_static_delegate = new efl_gfx_buffer_managed_set_delegate(buffer_managed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBufferManaged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_managed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_set_static_delegate) });
            }

            if (efl_gfx_buffer_managed_get_static_delegate == null)
            {
                efl_gfx_buffer_managed_get_static_delegate = new efl_gfx_buffer_managed_get_delegate(buffer_managed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBufferManaged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_buffer_managed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_buffer_managed_get_static_delegate) });
            }

            if (efl_gfx_fill_auto_get_static_delegate == null)
            {
                efl_gfx_fill_auto_get_static_delegate = new efl_gfx_fill_auto_get_delegate(fill_auto_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFillAuto") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_auto_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_get_static_delegate) });
            }

            if (efl_gfx_fill_auto_set_static_delegate == null)
            {
                efl_gfx_fill_auto_set_static_delegate = new efl_gfx_fill_auto_set_delegate(fill_auto_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFillAuto") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_auto_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_auto_set_static_delegate) });
            }

            if (efl_gfx_fill_get_static_delegate == null)
            {
                efl_gfx_fill_get_static_delegate = new efl_gfx_fill_get_delegate(fill_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_get_static_delegate) });
            }

            if (efl_gfx_fill_set_static_delegate == null)
            {
                efl_gfx_fill_set_static_delegate = new efl_gfx_fill_set_delegate(fill_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFill") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_fill_set_static_delegate) });
            }

            if (efl_gfx_filter_program_get_static_delegate == null)
            {
                efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate) });
            }

            if (efl_gfx_filter_program_set_static_delegate == null)
            {
                efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterProgram") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate) });
            }

            if (efl_gfx_filter_state_get_static_delegate == null)
            {
                efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate) });
            }

            if (efl_gfx_filter_state_set_static_delegate == null)
            {
                efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate) });
            }

            if (efl_gfx_filter_padding_get_static_delegate == null)
            {
                efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterPadding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate) });
            }

            if (efl_gfx_filter_source_get_static_delegate == null)
            {
                efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate) });
            }

            if (efl_gfx_filter_source_set_static_delegate == null)
            {
                efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate) });
            }

            if (efl_gfx_filter_data_get_static_delegate == null)
            {
                efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate) });
            }

            if (efl_gfx_filter_data_set_static_delegate == null)
            {
                efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFilterData") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate) });
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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.ImageInternal.efl_canvas_image_internal_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_save_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  ref Efl.FileSaveInfo.NativeStruct info);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_save_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  ref Efl.FileSaveInfo.NativeStruct info);

        public static Efl.Eo.FunctionWrapper<efl_file_save_api_delegate> efl_file_save_ptr = new Efl.Eo.FunctionWrapper<efl_file_save_api_delegate>(Module, "efl_file_save");

        private static bool save(System.IntPtr obj, System.IntPtr pd, System.String file, System.String key, ref Efl.FileSaveInfo.NativeStruct info)
        {
            Eina.Log.Debug("function efl_file_save was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.FileSaveInfo _in_info = info;
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).Save(file, key, ref _in_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                info = _in_info;
        return _ret_var;

            }
            else
            {
                return efl_file_save_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file, key, ref info);
            }
        }

        private static efl_file_save_delegate efl_file_save_static_delegate;

        
        private delegate void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_changed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate> evas_filter_changed_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate>(Module, "evas_filter_changed_set");

        private static void filter_changed_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_changed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ImageInternal)ws.Target).SetFilterChanged(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_changed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;

        
        private delegate void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void evas_filter_invalid_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate> evas_filter_invalid_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate>(Module, "evas_filter_invalid_set");

        private static void filter_invalid_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function evas_filter_invalid_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ImageInternal)ws.Target).SetFilterInvalid(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                evas_filter_invalid_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;

        
        private delegate System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr evas_filter_output_buffer_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate> evas_filter_output_buffer_get_ptr = new Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate>(Module, "evas_filter_output_buffer_get");

        private static System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_output_buffer_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.IntPtr _ret_var = default(System.IntPtr);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetFilterOutputBuffer();
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
                return evas_filter_output_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_alpha_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate> evas_filter_input_alpha_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate>(Module, "evas_filter_input_alpha");

        private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_input_alpha was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).FilterInputAlpha();
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
                return evas_filter_input_alpha_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;

        
        private delegate void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        
        public delegate void evas_filter_state_prepare_api_delegate(System.IntPtr obj,  out Efl.Canvas.Filter.State.NativeStruct state,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate> evas_filter_state_prepare_ptr = new Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate>(Module, "evas_filter_state_prepare");

        private static void filter_state_prepare(System.IntPtr obj, System.IntPtr pd, out Efl.Canvas.Filter.State.NativeStruct state, System.IntPtr data)
        {
            Eina.Log.Debug("function evas_filter_state_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                                    
                try
                {
                    ((ImageInternal)ws.Target).FilterStatePrepare(out _out_state, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        state = _out_state;
                                
            }
            else
            {
                evas_filter_state_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out state, data);
            }
        }

        private static evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool evas_filter_input_render_api_delegate(System.IntPtr obj,  System.IntPtr filter,  System.IntPtr engine,  System.IntPtr output,  System.IntPtr drawctx,  System.IntPtr data,  int l,  int r,  int t,  int b,  int x,  int y, [MarshalAs(UnmanagedType.U1)] bool do_async);

        public static Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate> evas_filter_input_render_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate>(Module, "evas_filter_input_render");

        private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd, System.IntPtr filter, System.IntPtr engine, System.IntPtr output, System.IntPtr drawctx, System.IntPtr data, int l, int r, int t, int b, int x, int y, bool do_async)
        {
            Eina.Log.Debug("function evas_filter_input_render was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                                                                                                                                                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).FilterInputRender(filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
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
                return evas_filter_input_render_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filter, engine, output, drawctx, data, l, r, t, b, x, y, do_async);
            }
        }

        private static evas_filter_input_render_delegate evas_filter_input_render_static_delegate;

        
        private delegate void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void evas_filter_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate> evas_filter_dirty_ptr = new Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate>(Module, "evas_filter_dirty");

        private static void filter_dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function evas_filter_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ImageInternal)ws.Target).FilterDirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                evas_filter_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static evas_filter_dirty_delegate evas_filter_dirty_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_buffer_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate> efl_gfx_buffer_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_get_api_delegate>(Module, "efl_gfx_buffer_size_get");

        private static Eina.Size2D.NativeStruct buffer_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetBufferSize();
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
                return efl_gfx_buffer_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_size_get_delegate efl_gfx_buffer_size_get_static_delegate;

        
        private delegate void efl_gfx_buffer_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct sz);

        
        public delegate void efl_gfx_buffer_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct sz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate> efl_gfx_buffer_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_size_set_api_delegate>(Module, "efl_gfx_buffer_size_set");

        private static void buffer_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct sz)
        {
            Eina.Log.Debug("function efl_gfx_buffer_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_sz = sz;
                            
                try
                {
                    ((ImageInternal)ws.Target).SetBufferSize(_in_sz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_buffer_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sz);
            }
        }

        private static efl_gfx_buffer_size_set_delegate efl_gfx_buffer_size_set_static_delegate;

        
        private delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.Colorspace efl_gfx_buffer_colorspace_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate> efl_gfx_buffer_colorspace_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_colorspace_get_api_delegate>(Module, "efl_gfx_buffer_colorspace_get");

        private static Efl.Gfx.Colorspace colorspace_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_colorspace_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.Colorspace _ret_var = default(Efl.Gfx.Colorspace);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetColorspace();
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
                return efl_gfx_buffer_colorspace_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_colorspace_get_delegate efl_gfx_buffer_colorspace_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_alpha_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate> efl_gfx_buffer_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_get_api_delegate>(Module, "efl_gfx_buffer_alpha_get");

        private static bool alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_alpha_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetAlpha();
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
                return efl_gfx_buffer_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_alpha_get_delegate efl_gfx_buffer_alpha_get_static_delegate;

        
        private delegate void efl_gfx_buffer_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        public delegate void efl_gfx_buffer_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate> efl_gfx_buffer_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_alpha_set_api_delegate>(Module, "efl_gfx_buffer_alpha_set");

        private static void alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            Eina.Log.Debug("function efl_gfx_buffer_alpha_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ImageInternal)ws.Target).SetAlpha(alpha);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_buffer_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), alpha);
            }
        }

        private static efl_gfx_buffer_alpha_set_delegate efl_gfx_buffer_alpha_set_static_delegate;

        
        private delegate int efl_gfx_buffer_stride_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_buffer_stride_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate> efl_gfx_buffer_stride_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_stride_get_api_delegate>(Module, "efl_gfx_buffer_stride_get");

        private static int stride_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_buffer_stride_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetStride();
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
                return efl_gfx_buffer_stride_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_buffer_stride_get_delegate efl_gfx_buffer_stride_get_static_delegate;

        
        private delegate void efl_gfx_buffer_borders_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint l,  out uint r,  out uint t,  out uint b);

        
        public delegate void efl_gfx_buffer_borders_get_api_delegate(System.IntPtr obj,  out uint l,  out uint r,  out uint t,  out uint b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate> efl_gfx_buffer_borders_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_borders_get_api_delegate>(Module, "efl_gfx_buffer_borders_get");

        private static void buffer_borders_get(System.IntPtr obj, System.IntPtr pd, out uint l, out uint r, out uint t, out uint b)
        {
            Eina.Log.Debug("function efl_gfx_buffer_borders_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(uint);        r = default(uint);        t = default(uint);        b = default(uint);                                            
                try
                {
                    ((ImageInternal)ws.Target).GetBufferBorders(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_buffer_borders_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_buffer_borders_get_delegate efl_gfx_buffer_borders_get_static_delegate;

        
        private delegate void efl_gfx_buffer_update_add_delegate(System.IntPtr obj, System.IntPtr pd,  ref Eina.Rect.NativeStruct region);

        
        public delegate void efl_gfx_buffer_update_add_api_delegate(System.IntPtr obj,  ref Eina.Rect.NativeStruct region);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate> efl_gfx_buffer_update_add_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_update_add_api_delegate>(Module, "efl_gfx_buffer_update_add");

        private static void buffer_update_add(System.IntPtr obj, System.IntPtr pd, ref Eina.Rect.NativeStruct region)
        {
            Eina.Log.Debug("function efl_gfx_buffer_update_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_region = region;
                            
                try
                {
                    ((ImageInternal)ws.Target).AddBufferUpdate(ref _in_region);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                region = _in_region;
        
            }
            else
            {
                efl_gfx_buffer_update_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref region);
            }
        }

        private static efl_gfx_buffer_update_add_delegate efl_gfx_buffer_update_add_static_delegate;

        
        private delegate Eina.RwSlice efl_gfx_buffer_map_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect.NativeStruct region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride);

        
        public delegate Eina.RwSlice efl_gfx_buffer_map_api_delegate(System.IntPtr obj,  Efl.Gfx.BufferAccessMode mode,  ref Eina.Rect.NativeStruct region,  Efl.Gfx.Colorspace cspace,  int plane,  out int stride);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate> efl_gfx_buffer_map_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_map_api_delegate>(Module, "efl_gfx_buffer_map");

        private static Eina.RwSlice buffer_map(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.BufferAccessMode mode, ref Eina.Rect.NativeStruct region, Efl.Gfx.Colorspace cspace, int plane, out int stride)
        {
            Eina.Log.Debug("function efl_gfx_buffer_map was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_region = region;
                                                                stride = default(int);                                                    Eina.RwSlice _ret_var = default(Eina.RwSlice);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).BufferMap(mode, ref _in_region, cspace, plane, out stride);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        region = _in_region;
                                return _ret_var;

            }
            else
            {
                return efl_gfx_buffer_map_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode, ref region, cspace, plane, out stride);
            }
        }

        private static efl_gfx_buffer_map_delegate efl_gfx_buffer_map_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_unmap_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.RwSlice slice);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_unmap_api_delegate(System.IntPtr obj,  Eina.RwSlice slice);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate> efl_gfx_buffer_unmap_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_unmap_api_delegate>(Module, "efl_gfx_buffer_unmap");

        private static bool buffer_unmap(System.IntPtr obj, System.IntPtr pd, Eina.RwSlice slice)
        {
            Eina.Log.Debug("function efl_gfx_buffer_unmap was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).BufferUnmap(slice);
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
                return efl_gfx_buffer_unmap_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice);
            }
        }

        private static efl_gfx_buffer_unmap_delegate efl_gfx_buffer_unmap_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_copy_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_copy_set_api_delegate(System.IntPtr obj,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate> efl_gfx_buffer_copy_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_copy_set_api_delegate>(Module, "efl_gfx_buffer_copy_set");

        private static bool buffer_copy_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr slice, Eina.Size2D.NativeStruct size, int stride, Efl.Gfx.Colorspace cspace, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_copy_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
        Eina.Size2D _in_size = size;
                                                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).SetBufferCopy(_in_slice, _in_size, stride, cspace, plane);
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
                return efl_gfx_buffer_copy_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice, size, stride, cspace, plane);
            }
        }

        private static efl_gfx_buffer_copy_set_delegate efl_gfx_buffer_copy_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_buffer_managed_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_buffer_managed_set_api_delegate(System.IntPtr obj,  System.IntPtr slice,  Eina.Size2D.NativeStruct size,  int stride,  Efl.Gfx.Colorspace cspace,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate> efl_gfx_buffer_managed_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_set_api_delegate>(Module, "efl_gfx_buffer_managed_set");

        private static bool buffer_managed_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr slice, Eina.Size2D.NativeStruct size, int stride, Efl.Gfx.Colorspace cspace, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_managed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_slice = Eina.PrimitiveConversion.PointerToManaged<Eina.Slice>(slice);
        Eina.Size2D _in_size = size;
                                                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).SetBufferManaged(_in_slice, _in_size, stride, cspace, plane);
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
                return efl_gfx_buffer_managed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), slice, size, stride, cspace, plane);
            }
        }

        private static efl_gfx_buffer_managed_set_delegate efl_gfx_buffer_managed_set_static_delegate;

        
        private delegate Eina.Slice efl_gfx_buffer_managed_get_delegate(System.IntPtr obj, System.IntPtr pd,  int plane);

        
        public delegate Eina.Slice efl_gfx_buffer_managed_get_api_delegate(System.IntPtr obj,  int plane);

        public static Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate> efl_gfx_buffer_managed_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_buffer_managed_get_api_delegate>(Module, "efl_gfx_buffer_managed_get");

        private static Eina.Slice buffer_managed_get(System.IntPtr obj, System.IntPtr pd, int plane)
        {
            Eina.Log.Debug("function efl_gfx_buffer_managed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Slice _ret_var = default(Eina.Slice);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetBufferManaged(plane);
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
                return efl_gfx_buffer_managed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), plane);
            }
        }

        private static efl_gfx_buffer_managed_get_delegate efl_gfx_buffer_managed_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_fill_auto_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_fill_auto_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate> efl_gfx_fill_auto_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_get_api_delegate>(Module, "efl_gfx_fill_auto_get");

        private static bool fill_auto_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_fill_auto_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetFillAuto();
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
                return efl_gfx_fill_auto_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_fill_auto_get_delegate efl_gfx_fill_auto_get_static_delegate;

        
        private delegate void efl_gfx_fill_auto_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool filled);

        
        public delegate void efl_gfx_fill_auto_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool filled);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate> efl_gfx_fill_auto_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_auto_set_api_delegate>(Module, "efl_gfx_fill_auto_set");

        private static void fill_auto_set(System.IntPtr obj, System.IntPtr pd, bool filled)
        {
            Eina.Log.Debug("function efl_gfx_fill_auto_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ImageInternal)ws.Target).SetFillAuto(filled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_fill_auto_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), filled);
            }
        }

        private static efl_gfx_fill_auto_set_delegate efl_gfx_fill_auto_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_gfx_fill_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_gfx_fill_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate> efl_gfx_fill_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_get_api_delegate>(Module, "efl_gfx_fill_get");

        private static Eina.Rect.NativeStruct fill_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_fill_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetFill();
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
                return efl_gfx_fill_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_fill_get_delegate efl_gfx_fill_get_static_delegate;

        
        private delegate void efl_gfx_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct fill);

        
        public delegate void efl_gfx_fill_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct fill);

        public static Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate> efl_gfx_fill_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_fill_set_api_delegate>(Module, "efl_gfx_fill_set");

        private static void fill_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct fill)
        {
            Eina.Log.Debug("function efl_gfx_fill_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_fill = fill;
                            
                try
                {
                    ((ImageInternal)ws.Target).SetFill(_in_fill);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_fill_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fill);
            }
        }

        private static efl_gfx_fill_set_delegate efl_gfx_fill_set_static_delegate;

        
        private delegate void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        
        public delegate void efl_gfx_filter_program_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate> efl_gfx_filter_program_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate>(Module, "efl_gfx_filter_program_get");

        private static void filter_program_get(System.IntPtr obj, System.IntPtr pd, out System.String code, out System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_code = default(System.String);
        System.String _out_name = default(System.String);
                            
                try
                {
                    ((ImageInternal)ws.Target).GetFilterProgram(out _out_code, out _out_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        code = _out_code;
        name = _out_name;
                        
            }
            else
            {
                efl_gfx_filter_program_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out code, out name);
            }
        }

        private static efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;

        
        private delegate void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        
        public delegate void efl_gfx_filter_program_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate> efl_gfx_filter_program_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate>(Module, "efl_gfx_filter_program_set");

        private static void filter_program_set(System.IntPtr obj, System.IntPtr pd, System.String code, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_program_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ImageInternal)ws.Target).SetFilterProgram(code, name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_program_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), code, name);
            }
        }

        private static efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;

        
        private delegate void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        
        public delegate void efl_gfx_filter_state_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String cur_state,  out double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String next_state,  out double next_val,  out double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate> efl_gfx_filter_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate>(Module, "efl_gfx_filter_state_get");

        private static void filter_state_get(System.IntPtr obj, System.IntPtr pd, out System.String cur_state, out double cur_val, out System.String next_state, out double next_val, out double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                System.String _out_cur_state = default(System.String);
        cur_val = default(double);        System.String _out_next_state = default(System.String);
        next_val = default(double);        pos = default(double);                                                    
                try
                {
                    ((ImageInternal)ws.Target).GetFilterState(out _out_cur_state, out cur_val, out _out_next_state, out next_val, out pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        cur_state = _out_cur_state;
                next_state = _out_next_state;
                                                                
            }
            else
            {
                efl_gfx_filter_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out cur_state, out cur_val, out next_state, out next_val, out pos);
            }
        }

        private static efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;

        
        private delegate void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        
        public delegate void efl_gfx_filter_state_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cur_state,  double cur_val, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String next_state,  double next_val,  double pos);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate> efl_gfx_filter_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate>(Module, "efl_gfx_filter_state_set");

        private static void filter_state_set(System.IntPtr obj, System.IntPtr pd, System.String cur_state, double cur_val, System.String next_state, double next_val, double pos)
        {
            Eina.Log.Debug("function efl_gfx_filter_state_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((ImageInternal)ws.Target).SetFilterState(cur_state, cur_val, next_state, next_val, pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_filter_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cur_state, cur_val, next_state, next_val, pos);
            }
        }

        private static efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;

        
        private delegate void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int l,  out int r,  out int t,  out int b);

        
        public delegate void efl_gfx_filter_padding_get_api_delegate(System.IntPtr obj,  out int l,  out int r,  out int t,  out int b);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate> efl_gfx_filter_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate>(Module, "efl_gfx_filter_padding_get");

        private static void filter_padding_get(System.IntPtr obj, System.IntPtr pd, out int l, out int r, out int t, out int b)
        {
            Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        l = default(int);        r = default(int);        t = default(int);        b = default(int);                                            
                try
                {
                    ((ImageInternal)ws.Target).GetFilterPadding(out l, out r, out t, out b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_filter_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out l, out r, out t, out b);
            }
        }

        private static efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_gfx_filter_source_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate> efl_gfx_filter_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate>(Module, "efl_gfx_filter_source_get");

        private static Efl.Gfx.IEntity filter_source_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((ImageInternal)ws.Target).GetFilterSource(name);
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
                return efl_gfx_filter_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;

        
        private delegate void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        
        public delegate void efl_gfx_filter_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity source);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate> efl_gfx_filter_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate>(Module, "efl_gfx_filter_source_set");

        private static void filter_source_set(System.IntPtr obj, System.IntPtr pd, System.String name, Efl.Gfx.IEntity source)
        {
            Eina.Log.Debug("function efl_gfx_filter_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ImageInternal)ws.Target).SetFilterSource(name, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_gfx_filter_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, source);
            }
        }

        private static efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;

        
        private delegate void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        
        public delegate void efl_gfx_filter_data_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String value, [MarshalAs(UnmanagedType.U1)] out bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate> efl_gfx_filter_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate>(Module, "efl_gfx_filter_data_get");

        private static void filter_data_get(System.IntPtr obj, System.IntPtr pd, System.String name, out System.String value, out bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        System.String _out_value = default(System.String);
        execute = default(bool);                                    
                try
                {
                    ((ImageInternal)ws.Target).GetFilterData(name, out _out_value, out execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                value = _out_value;
                                        
            }
            else
            {
                efl_gfx_filter_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, out value, out execute);
            }
        }

        private static efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;

        
        private delegate void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        
        public delegate void efl_gfx_filter_data_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value, [MarshalAs(UnmanagedType.U1)] bool execute);

        public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate> efl_gfx_filter_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate>(Module, "efl_gfx_filter_data_set");

        private static void filter_data_set(System.IntPtr obj, System.IntPtr pd, System.String name, System.String value, bool execute)
        {
            Eina.Log.Debug("function efl_gfx_filter_data_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((ImageInternal)ws.Target).SetFilterData(name, value, execute);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_filter_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, value, execute);
            }
        }

        private static efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;

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
                    _ret_var = ((ImageInternal)ws.Target).GetSmoothScale();
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
                    ((ImageInternal)ws.Target).SetSmoothScale(smooth_scale);
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
                    _ret_var = ((ImageInternal)ws.Target).GetScaleType();
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
                    ((ImageInternal)ws.Target).SetScaleType(scale_type);
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
                    _ret_var = ((ImageInternal)ws.Target).GetCanUpscale();
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
                    ((ImageInternal)ws.Target).SetCanUpscale(upscale);
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
                    _ret_var = ((ImageInternal)ws.Target).GetCanDownscale();
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
                    ((ImageInternal)ws.Target).SetCanDownscale(downscale);
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
                    _ret_var = ((ImageInternal)ws.Target).GetRatio();
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
                    _ret_var = ((ImageInternal)ws.Target).GetContentRegion();
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
                    ((ImageInternal)ws.Target).GetBorder(out l, out r, out t, out b);
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
                    ((ImageInternal)ws.Target).SetBorder(l, r, t, b);
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
                    _ret_var = ((ImageInternal)ws.Target).GetBorderScale();
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
                    ((ImageInternal)ws.Target).SetBorderScale(scale);
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
                    _ret_var = ((ImageInternal)ws.Target).GetBorderCenterFill();
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
                    ((ImageInternal)ws.Target).SetBorderCenterFill(fill);
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
                    ((ImageInternal)ws.Target).GetStretchRegion(out _out_horizontal, out _out_vertical);
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
                    _ret_var = ((ImageInternal)ws.Target).SetStretchRegion(_in_horizontal, _in_vertical);
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
                    _ret_var = ((ImageInternal)ws.Target).GetImageSize();
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
                    _ret_var = ((ImageInternal)ws.Target).GetContentHint();
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
                    ((ImageInternal)ws.Target).SetContentHint(hint);
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
                    _ret_var = ((ImageInternal)ws.Target).GetScaleHint();
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
                    ((ImageInternal)ws.Target).SetScaleHint(hint);
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
                    _ret_var = ((ImageInternal)ws.Target).GetImageLoadError();
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
                    _ret_var = ((ImageInternal)ws.Target).GetImageOrientation();
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
                    ((ImageInternal)ws.Target).SetImageOrientation(dir);
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
                    _ret_var = ((ImageInternal)ws.Target).GetViewSize();
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
                    ((ImageInternal)ws.Target).SetViewSize(_in_size);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasImageInternal_ExtensionMethods {
    public static Efl.BindableProperty<bool> FilterChanged<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("filter_changed", fac);
    }

    public static Efl.BindableProperty<bool> FilterInvalid<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("filter_invalid", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> BufferSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Eina.Size2D>("buffer_size", fac);
    }

    
    public static Efl.BindableProperty<bool> Alpha<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("alpha", fac);
    }

    
    
    public static Efl.BindableProperty<bool> FillAuto<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("fill_auto", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Fill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Eina.Rect>("fill", fac);
    }

    
    
    
    
    
    public static Efl.BindableProperty<bool> SmoothScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("smooth_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleType> ScaleType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleType>("scale_type", fac);
    }

    public static Efl.BindableProperty<bool> CanUpscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("can_upscale", fac);
    }

    public static Efl.BindableProperty<bool> CanDownscale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<bool>("can_downscale", fac);
    }

    
    
    
    public static Efl.BindableProperty<double> BorderScale<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<double>("border_scale", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.BorderFillMode> BorderCenterFill<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Efl.Gfx.BorderFillMode>("border_center_fill", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Gfx.ImageContentHint> ContentHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Efl.Gfx.ImageContentHint>("content_hint", fac);
    }

    public static Efl.BindableProperty<Efl.Gfx.ImageScaleHint> ScaleHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Efl.Gfx.ImageScaleHint>("scale_hint", fac);
    }

    
    public static Efl.BindableProperty<Efl.Gfx.ImageOrientation> ImageOrientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Efl.Gfx.ImageOrientation>("image_orientation", fac);
    }

    public static Efl.BindableProperty<Eina.Size2D> ViewSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.ImageInternal, T>magic = null) where T : Efl.Canvas.ImageInternal {
        return new Efl.BindableProperty<Eina.Size2D>("view_size", fac);
    }

}
#pragma warning restore CS1591
#endif
