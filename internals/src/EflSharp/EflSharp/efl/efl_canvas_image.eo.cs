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
    /// <summary>Method to raise event LoadDoneEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadDoneEvent(EventArgs e)
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
    /// <summary>Method to raise event LoadErrorEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLoadErrorEvent(Efl.Gfx.ImageLoadControllerLoadErrorEventArgs e)
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
    /// <summary>Whether an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <returns><c>true</c> if the object is animated</returns>
    public virtual bool GetAnimated() {
         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_animated_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/> is <c>true</c>.</summary>
    /// <returns>The index of current frame.</returns>
    public virtual int GetFrame() {
         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/> is <c>true</c>.</summary>
    /// <param name="frame_index">The index of current frame.</param>
    /// <returns>Returns <c>true</c> if the frame index is valid.</returns>
    public virtual bool SetFrame(int frame_index) {
                                 var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),frame_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <returns>The number of frames in the animated object.</returns>
    public virtual int GetFrameCount() {
         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The kind of looping the animated object does.
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <returns>Loop type of the animated object.</returns>
    public virtual Efl.Gfx.FrameControllerLoopHint GetLoopType() {
         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <returns>The number of loop of an animated object.</returns>
    public virtual int GetLoopCount() {
         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_loop_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The duration of a sequence of frames.
    /// This returns total duration in seconds that the specified sequence of frames should take.
    /// 
    /// If <c>start_frame</c> is 1 and <c>frame_num</c> is 0, this returns the duration of frame 1. If <c>start_frame</c> is 1 and <c>frame_num</c> is 1, this returns the total duration of frame 1 + frame 2.</summary>
    /// <param name="start_frame">The first frame, rangers from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>.</param>
    /// <param name="frame_num">Number of frames in the sequence, starts from 0.</param>
    /// <returns>Duration in seconds</returns>
    public virtual double GetFrameDuration(int start_frame, int frame_num) {
                                                         var _ret_var = Efl.Gfx.FrameControllerConcrete.NativeMethods.efl_gfx_frame_controller_frame_duration_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_frame, frame_num);
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
    /// <summary>Whether an object can be animated (has multiple frames).
    /// This will be <c>true</c> for animated object for instance but <c>false</c> for a single frame object.</summary>
    /// <value><c>true</c> if the object is animated</value>
    public bool Animated {
        get { return GetAnimated(); }
    }
    /// <summary>Index of the current frame of an animated object.
    /// Ranges from 1 to <see cref="Efl.Gfx.IFrameController.GetFrameCount"/>. Valid only if <see cref="Efl.Gfx.IFrameController.GetAnimated"/> is <c>true</c>.</summary>
    /// <value>The index of current frame.</value>
    public int Frame {
        get { return GetFrame(); }
        set { SetFrame(value); }
    }
    /// <summary>The total number of frames of the object, if animated.
    /// Returns -1 if not animated.</summary>
    /// <value>The number of frames in the animated object.</value>
    public int FrameCount {
        get { return GetFrameCount(); }
    }
    /// <summary>The kind of looping the animated object does.
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>, you should display frames in a sequence like: 1-&gt;2-&gt;3-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// If it returns <see cref="Efl.Gfx.FrameControllerLoopHint.Pingpong"/>, it is better to display frames in a sequence like: 1-&gt;2-&gt;3-&gt;2-&gt;1-&gt;2-&gt;3-&gt;1...
    /// 
    /// The default type is <see cref="Efl.Gfx.FrameControllerLoopHint.Loop"/>.</summary>
    /// <value>Loop type of the animated object.</value>
    public Efl.Gfx.FrameControllerLoopHint LoopType {
        get { return GetLoopType(); }
    }
    /// <summary>The number times the animation of the object loops.
    /// This returns loop count of animated object. The loop count is the number of times the animation will play fully from first to last frame until the animation should stop (at the final frame).
    /// 
    /// If 0 is returned, then looping should happen indefinitely (no limit to the number of times it loops).</summary>
    /// <value>The number of loop of an animated object.</value>
    public int LoopCount {
        get { return GetLoopCount(); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Image.efl_canvas_image_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.ImageInternal.NativeMethods
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
            return Efl.Canvas.Image.efl_canvas_image_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

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
