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

/// <summary>Low-level Image object.
/// This replaces the legacy Evas Object Image, with only image-related interfaces: file and data images only. This object does not implement any special features such as proxy, snapshot or GL.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Image.NativeMethods]
[Efl.Eo.BindingEntity]
public class Image : Efl.Canvas.ImageInternal, Efl.IFile, Efl.Gfx.IFrameController, Efl.Gfx.IImageLoadController
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

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_image_class_get();
    /// <summary>Initializes a new instance of the <see cref="Image"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Image(Efl.Object parent= null
            ) : base(efl_canvas_image_class_get(), parent)
    {
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event LoadDoneEvt.</summary>
    public void OnLoadDoneEvt(EventArgs e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event LoadErrorEvt.</summary>
    public void OnLoadErrorEvt(Efl.Gfx.IImageLoadControllerLoadErrorEvt_Args e)
    {
        var key = "_EFL_GFX_IMAGE_LOAD_CONTROLLER_EVENT_LOAD_ERROR";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
    /// <summary>Check if an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <returns><c>true</c> if the object is animated</returns>
    virtual public bool GetAnimated() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_animated_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
    /// <returns>The index of current frame.</returns>
    virtual public int GetFrame() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the frame to current frame of an animated object.</summary>
    /// <param name="frame_index">The index of current frame.</param>
    /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
    virtual public bool SetFrame(int frame_index) {
                                 var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),frame_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <returns>The number of frames in the animated object.</returns>
    virtual public int GetFrameCount() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the kind of looping the animated object does.
    /// This returns the kind of looping the animated object wants to do.
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <returns>Loop type of the animated object.</returns>
    virtual public Efl.Gfx.FrameControllerLoopHint GetLoopType() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <returns>The number of loop of an animated object.</returns>
    virtual public int GetLoopCount() {
         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the duration of a sequence of frames.
    /// This returns total duration in seconds that the specified sequence of frames should take.
    /// 
    /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.</summary>
    /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>.</param>
    /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
    /// <returns>Duration in seconds</returns>
    virtual public double GetFrameDuration(int start_frame, int frame_num) {
                                                         var _ret_var = Efl.Gfx.IFrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_frame, frame_num);
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
    /// <summary>Check if an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <value><c>true</c> if the object is animated</value>
    public bool Animated {
        get { return GetAnimated(); }
    }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/>.</summary>
    /// <value>The index of current frame.</value>
    public int Frame {
        get { return GetFrame(); }
        set { SetFrame(value); }
    }
    /// <summary>Get the total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <value>The number of frames in the animated object.</value>
    public int FrameCount {
        get { return GetFrameCount(); }
    }
    /// <summary>Get the kind of looping the animated object does.
    /// This returns the kind of looping the animated object wants to do.
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <value>Loop type of the animated object.</value>
    public Efl.Gfx.FrameControllerLoopHint LoopType {
        get { return GetLoopType(); }
    }
    /// <summary>Get the number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <value>The number of loop of an animated object.</value>
    public int LoopCount {
        get { return GetLoopCount(); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Image.efl_canvas_image_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.ImageInternal.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

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

            if (efl_gfx_frame_controller_animated_get_static_delegate == null)
            {
                efl_gfx_frame_controller_animated_get_static_delegate = new efl_gfx_frame_controller_animated_get_delegate(animated_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnimated") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_animated_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_animated_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_get_static_delegate = new efl_gfx_frame_controller_frame_get_delegate(frame_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_set_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_set_static_delegate = new efl_gfx_frame_controller_frame_set_delegate(frame_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_set_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_count_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_count_get_static_delegate = new efl_gfx_frame_controller_frame_count_get_delegate(frame_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrameCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_count_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_loop_type_get_static_delegate == null)
            {
                efl_gfx_frame_controller_loop_type_get_static_delegate = new efl_gfx_frame_controller_loop_type_get_delegate(loop_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoopType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_loop_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_type_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_loop_count_get_static_delegate == null)
            {
                efl_gfx_frame_controller_loop_count_get_static_delegate = new efl_gfx_frame_controller_loop_count_get_delegate(loop_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoopCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_loop_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_loop_count_get_static_delegate) });
            }

            if (efl_gfx_frame_controller_frame_duration_get_static_delegate == null)
            {
                efl_gfx_frame_controller_frame_duration_get_static_delegate = new efl_gfx_frame_controller_frame_duration_get_delegate(frame_duration_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrameDuration") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_frame_controller_frame_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_frame_controller_frame_duration_get_static_delegate) });
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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Image.efl_canvas_image_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
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
        private delegate bool efl_gfx_frame_controller_animated_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_frame_controller_animated_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate> efl_gfx_frame_controller_animated_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_animated_get_api_delegate>(Module, "efl_gfx_frame_controller_animated_get");

        private static bool animated_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_animated_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).GetAnimated();
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
                return efl_gfx_frame_controller_animated_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_animated_get_delegate efl_gfx_frame_controller_animated_get_static_delegate;

        
        private delegate int efl_gfx_frame_controller_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_frame_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate> efl_gfx_frame_controller_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_get");

        private static int frame_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).GetFrame();
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
                return efl_gfx_frame_controller_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_frame_get_delegate efl_gfx_frame_controller_frame_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_frame_controller_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,  int frame_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_frame_controller_frame_set_api_delegate(System.IntPtr obj,  int frame_index);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate> efl_gfx_frame_controller_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_set_api_delegate>(Module, "efl_gfx_frame_controller_frame_set");

        private static bool frame_set(System.IntPtr obj, System.IntPtr pd, int frame_index)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Image)ws.Target).SetFrame(frame_index);
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
                return efl_gfx_frame_controller_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), frame_index);
            }
        }

        private static efl_gfx_frame_controller_frame_set_delegate efl_gfx_frame_controller_frame_set_static_delegate;

        
        private delegate int efl_gfx_frame_controller_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_frame_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate> efl_gfx_frame_controller_frame_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_count_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_count_get");

        private static int frame_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).GetFrameCount();
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
                return efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_frame_count_get_delegate efl_gfx_frame_controller_frame_count_get_static_delegate;

        
        private delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Gfx.FrameControllerLoopHint efl_gfx_frame_controller_loop_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate> efl_gfx_frame_controller_loop_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_type_get_api_delegate>(Module, "efl_gfx_frame_controller_loop_type_get");

        private static Efl.Gfx.FrameControllerLoopHint loop_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_loop_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Gfx.FrameControllerLoopHint _ret_var = default(Efl.Gfx.FrameControllerLoopHint);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoopType();
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
                return efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_loop_type_get_delegate efl_gfx_frame_controller_loop_type_get_static_delegate;

        
        private delegate int efl_gfx_frame_controller_loop_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_frame_controller_loop_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate> efl_gfx_frame_controller_loop_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_loop_count_get_api_delegate>(Module, "efl_gfx_frame_controller_loop_count_get");

        private static int loop_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_loop_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Image)ws.Target).GetLoopCount();
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
                return efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_frame_controller_loop_count_get_delegate efl_gfx_frame_controller_loop_count_get_static_delegate;

        
        private delegate double efl_gfx_frame_controller_frame_duration_get_delegate(System.IntPtr obj, System.IntPtr pd,  int start_frame,  int frame_num);

        
        public delegate double efl_gfx_frame_controller_frame_duration_get_api_delegate(System.IntPtr obj,  int start_frame,  int frame_num);

        public static Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate> efl_gfx_frame_controller_frame_duration_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_frame_controller_frame_duration_get_api_delegate>(Module, "efl_gfx_frame_controller_frame_duration_get");

        private static double frame_duration_get(System.IntPtr obj, System.IntPtr pd, int start_frame, int frame_num)
        {
            Eina.Log.Debug("function efl_gfx_frame_controller_frame_duration_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Image)ws.Target).GetFrameDuration(start_frame, frame_num);
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
                return efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_frame, frame_num);
            }
        }

        private static efl_gfx_frame_controller_frame_duration_get_delegate efl_gfx_frame_controller_frame_duration_get_static_delegate;

        
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasImage_ExtensionMethods {
    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    
    
    public static Efl.BindableProperty<int> Frame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<int>("frame", fac);
    }

    
    
    
    
    public static Efl.BindableProperty<Eina.Size2D> LoadSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<Eina.Size2D>("load_size", fac);
    }

    public static Efl.BindableProperty<double> LoadDpi<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<double>("load_dpi", fac);
    }

    
    public static Efl.BindableProperty<Eina.Rect> LoadRegion<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<Eina.Rect>("load_region", fac);
    }

    public static Efl.BindableProperty<bool> LoadOrientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<bool>("load_orientation", fac);
    }

    public static Efl.BindableProperty<int> LoadScaleDown<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<int>("load_scale_down", fac);
    }

    public static Efl.BindableProperty<bool> LoadSkipHeader<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Image, T>magic = null) where T : Efl.Canvas.Image {
        return new Efl.BindableProperty<bool>("load_skip_header", fac);
    }

}
#pragma warning restore CS1591
#endif
